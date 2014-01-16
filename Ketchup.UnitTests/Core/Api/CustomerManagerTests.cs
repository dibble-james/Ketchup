// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerManagerTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Core.Api
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Ketchup.Api;
    using Ketchup.Model.Customer;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CustomerManagerTests
    {
        private Mock<IPersistenceManager> _fakePersistence;
        private CustomerManager _target;

        [TestInitialize]
        public void Setup()
        {
            this._fakePersistence = new Mock<IPersistenceManager>();
            this._fakePersistence.Setup(p => p.Commit()).Callback(() => { return; });

            this._target = new CustomerManager(this._fakePersistence.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this._fakePersistence = null;
            this._target = null;
        }

        [TestMethod]
        public void TestAddCustomer()
        {
            var customers = new List<Customer>();

            this._fakePersistence.Setup(p => p.Add(It.IsAny<Customer>())).Callback<Customer>(customers.Add);

            this._target.CreateCustomer(string.Empty, string.Empty, string.Empty, new Address());

            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void TestAddAddress()
        {
            var newAddress = new Address();
            var customer = new Customer { Addresses = new Collection<Address>() };

            this._target.AddAddress(customer, newAddress);

            Assert.IsTrue(customer.Addresses.Contains(newAddress));
        }
    }
}