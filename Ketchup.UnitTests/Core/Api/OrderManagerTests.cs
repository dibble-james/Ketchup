// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderManagerTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Core.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Ketchup.Api;
    using Ketchup.Model.Customer;
    using Ketchup.Model.Order;
    using Ketchup.Model.Product;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class OrderManagerTests
    {
        private Mock<IPersistenceManager> _fakePersistence;
        private Mock<IOrderNumberGenerator> _fakeOrderNumberGenerator;
        private OrderManager _target;

        [TestInitialize]
        public void Setup()
        {
            this._fakePersistence = new Mock<IPersistenceManager>();
            this._fakePersistence.Setup(p => p.Commit()).Callback(() => { return; });

            this._fakeOrderNumberGenerator = new Mock<IOrderNumberGenerator>();

            this._target = new OrderManager(this._fakePersistence.Object, this._fakeOrderNumberGenerator.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this._fakePersistence = null;
            this._target = null;
        }

        [TestMethod]
        public void TestCreateBasket()
        {
            var product = new Product { Id = 1 };

            var baskets = new List<Basket>();

            this._fakePersistence.Setup(p => p.Add(It.IsAny<Basket>())).Callback<Basket>(baskets.Add);

            this._target.CreateBasket(product);

            Assert.IsTrue(baskets.Any());
        }

        [TestMethod]
        public void TestGetBasket()
        {
            var expected = new Basket { Id = Guid.NewGuid() };

            this._fakePersistence.Setup(p => p.Find(It.IsAny<IPersistenceSearcher<Basket>>())).Returns(expected);

            var actual = this._target.GetBasket(Guid.NewGuid());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddProductToBasket()
        {
            var product = new Product { Id = 1 };

            var basket = new Basket { Products = new Collection<BasketProduct>() };

            this._fakePersistence.Setup(p => p.Add(It.IsAny<BasketProduct>())).Callback(() => { return; });

            this._target.AddProductToBasket(basket, product);

            Assert.IsTrue(basket.Products.Any(bp => bp.Product == product));
        }

        [TestMethod]
        public void TestCreateOrder()
        {
            const string orderNumber = "ON12345";
            this._fakeOrderNumberGenerator.Setup(ong => ong.NextOrderNumber()).Returns(orderNumber);

            var orders = new List<Order>();

            this._fakePersistence.Setup(p => p.Add(It.IsAny<Order>())).Callback<Order>(orders.Add);

            this._target.CreateOrder(new Basket(), new Customer(), new Address());

            Assert.IsTrue(orders.Any(o => o.OrderNumber == orderNumber));
        }

        [TestMethod]
        public void TestGetOrderByOrderNumber()
        {
            var expected = new Order();

            this._fakePersistence.Setup(p => p.Find(It.IsAny<IPersistenceSearcher<Order>>())).Returns(expected);

            var actual = this._target.GetOrder("Something");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetOrderByCustomerAndDate()
        {
            var expected = new Order();

            this._fakePersistence
                .Setup(p => p.Find(It.IsAny<IPersistenceSearcher<Order>>()))
                .Returns(expected);

            var actual = this._target.GetOrder(new Customer(), DateTime.Now);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetOrdersByCustomer()
        {
            var expected = new List<Order> { new Order() };

            this._fakePersistence.Setup(p => p.Find(It.IsAny<IPersistenceCollectionSearcher<Order>>())).Returns(expected);

            var actual = this._target.GetOrders(new Customer());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetOrdersByProduct()
        {
            var expected = new List<Order> { new Order() };

            this._fakePersistence.Setup(p => p.Find(It.IsAny<IPersistenceCollectionSearcher<Order>>())).Returns(expected);

            var actual = this._target.GetOrders(new Product());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetOrdersByDate()
        {
            var expected = new List<Order> { new Order() };

            this._fakePersistence.Setup(p => p.Find(It.IsAny<IPersistenceCollectionSearcher<Order>>())).Returns(expected);

            var actual = this._target.GetOrders(DateTime.Now.AddDays(-3), DateTime.Now);

            Assert.AreEqual(expected, actual);
        }
    }
}