// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Model.Customer;
    using Model.Order;
    using Model.Product;

    /// <summary>
    /// An object to manage <see cref="Order"/> objects.
    /// </summary>
    public sealed class OrderManager : IOrderManager
    {
        private readonly IPersistenceManager _persistence;
        private readonly IOrderNumberGenerator _orderNumberGenerator;

        /// <summary>
        /// Initialises a new instance of the <see cref="OrderManager"/> class.
        /// </summary>
        /// <param name="persistence">A connection to a persistence source.</param>
        /// <param name="orderNumberGenerator">An object to create order numbers.</param>
        public OrderManager(IPersistenceManager persistence, IOrderNumberGenerator orderNumberGenerator)
        {
            this._persistence = persistence;
            this._orderNumberGenerator = orderNumberGenerator;
        }

        /// <summary>
        /// Build a new <see cref="Basket"/>.
        /// </summary>
        /// <param name="products">The <see cref="Product"/>s to create the basket with.</param>
        /// <returns>The new <see cref="Basket"/>.</returns>
        public Basket CreateBasket(IEnumerable<BasketProduct> products)
        {
            var basket = new Basket { Products = new Collection<BasketProduct>(), Id = Guid.NewGuid() };

            var basketProducts = products.Select(product => new BasketProduct { Basket = basket, Product = product.Product, Quantity = product.Quantity });

            basket.Products = new Collection<BasketProduct>(basketProducts.ToList());

            this._persistence.Add(basket);

            this._persistence.Commit();

            return basket;
        }

        /// <summary>
        /// Build a new <see cref="Basket"/>.
        /// </summary>
        /// <param name="products">The <see cref="Product"/>s to create the basket with.</param>
        /// <returns>The new <see cref="Basket"/>.</returns>
        public Basket CreateBasket(params BasketProduct[] products)
        {
            return this.CreateBasket(products.AsEnumerable());
        }

        /// <summary>
        /// Retrieve a <see cref="Basket"/> using it's identifier.
        /// </summary>
        /// <param name="basketIdentifier">The unique identifier of the <see cref="Basket"/>.</param>
        /// <returns>
        /// The <see cref="Basket"/> with the given <paramref name="basketIdentifier"/> or null if
        /// no <see cref="Basket"/> exists with the given <paramref name="basketIdentifier"/>.
        /// </returns>
        public Basket GetBasket(Guid basketIdentifier)
        {
            var basket = this._persistence.Find(new PersistenceSearcher<Basket>(b => b.Id == basketIdentifier));

            return basket;
        }

        /// <summary>
        /// Add a <see cref="Product"/> to an existing <see cref="Basket"/>.
        /// </summary>
        /// <param name="basket">The <see cref="Basket"/> to add a <see cref="Product"/> too.</param>
        /// <param name="productToAdd">The new <see cref="Product"/> for the <paramref name="basket"/>.</param>
        /// <param name="quantity">The quantity of <see cref="Product"/> for the <paramref name="basket"/>.</param>
        /// <returns>The <see cref="Basket"/>.</returns>
        public Basket AddProductToBasket(Basket basket, Product productToAdd, int quantity)
        {
            var basketProduct = new BasketProduct { Basket = basket, Product = productToAdd, Quantity = quantity };

            basket.Products.Add(basketProduct);

            this._persistence.Change(basket);

            this._persistence.Commit();

            return basket;
        }

        /// <summary>
        /// Build a new <see cref="Order"/>.
        /// </summary>
        /// <param name="basket">The <see cref="Product"/>s the new <see cref="Order"/> is for.</param>
        /// <param name="customer">The <see cref="Customer"/> the new <see cref="Order"/> is for.</param>
        /// <param name="shippingAddress">The <see cref="Address"/> to send the <see cref="Order"/> too.</param>
        /// <returns>The new <see cref="Order"/>.</returns>
        public Order CreateOrder(Basket basket, Customer customer, Address shippingAddress)
        {
            var orderNumber = this._orderNumberGenerator.NextOrderNumber();

            var order = new Order
                        {
                            Basket = basket, 
                            Customer = customer, 
                            OrderNumber = orderNumber, 
                            OrderDate = DateTime.Now,
                            ShippingAddress = shippingAddress
                        };

            this._persistence.Add(order);

            this._persistence.Commit();

            return order;
        }

        /// <summary>
        /// Retrieve an <see cref="Order"/> for a given <paramref name="customer"/> on a given <paramref name="orderDate"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> to retrieve an <see cref="Order"/> for.</param>
        /// <param name="orderDate">The <see cref="System.DateTime"/> the order was made upon.</param>
        /// <returns>
        /// An <see cref="Order"/> with the matching <paramref name="customer"/> and <paramref name="orderDate"/> 
        /// or null if no <see cref="Order"/>s match.
        /// </returns>
        public Order GetOrder(Customer customer, DateTime orderDate)
        {
            var order =
                this._persistence.Find(
                    new PersistenceSearcher<Order>(o => o.Customer.Id == customer.Id && o.OrderDate == orderDate));

            return order;
        }

        /// <summary>
        /// Retrieve an <see cref="Order"/> with a given <paramref name="orderNumber"/>.
        /// </summary>
        /// <param name="orderNumber">The human friendly identifier of the required <see cref="Order"/>.</param>
        /// <returns>
        /// The <see cref="Order"/> with the matching <paramref name="orderNumber"/> or null if no
        /// matching <see cref="Order"/> could be found.
        /// </returns>
        public Order GetOrder(string orderNumber)
        {
            var order =
                this._persistence.Find(
                    new PersistenceSearcher<Order>(o => o.OrderNumber == orderNumber));

            return order;
        }

        /// <summary>
        /// Retrieve all <see cref="Order"/>s for a given <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> to find <see cref="Order"/>s for.</param>
        /// <returns>All <see cref="Order"/>s for a given <see cref="Customer"/>.</returns>
        public IEnumerable<Order> GetOrders(Customer customer)
        {
            var orders =
                this._persistence.Find(
                    new PersistenceCollectionSearcher<Order>(o => o.Customer.Id == customer.Id));

            return orders;
        }

        /// <summary>
        /// Retrieve all <see cref="Order"/>s for a given <see cref="Product"/>.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to find <see cref="Order"/>s for.</param>
        /// <returns>All <see cref="Order"/>s for a given <see cref="Product"/>.</returns>
        public IEnumerable<Order> GetOrders(Product product)
        {
            var orders =
                this._persistence.Find(
                    new PersistenceCollectionSearcher<Order>(o => o.Basket.Products.Any(bp => bp.Product.Id == product.Id)));

            return orders;
        }

        /// <summary>
        /// Retrieve all <see cref="Order"/>s made between two <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="from">The oldest <see cref="System.DateTime"/>.</param>
        /// <param name="to">The closest <see cref="System.DateTime"/>.</param>
        /// <returns>All <see cref="Order"/>s made between two given <see cref="System.DateTime"/>.</returns>
        public IEnumerable<Order> GetOrders(DateTime @from, DateTime to)
        {
            var orders =
                this._persistence.Find(
                    new PersistenceCollectionSearcher<Order>(o => o.OrderDate <= @from && o.OrderDate >= @to));

            return orders;
        }

        /// <summary>
        /// The given <see cref="BasketProduct"/> is no longer required so take it out of the <see cref="M:BasketProduct.Basket"/>
        /// </summary>
        /// <param name="basketProductToRemove">The <see cref="BasketProduct"/> to remove.</param>
        /// <returns>The <see cref="Basket"/> as it now stands.</returns>
        public Basket RemoveFromBasket(BasketProduct basketProductToRemove)
        {
            var basketId = basketProductToRemove.BasketId;
            
            this._persistence.Remove(basketProductToRemove);

            this._persistence.Commit();
            
            var basket = this._persistence.Find(
                new PersistenceSearcher<Basket>(b => b.Id == basketId));

            return basket;
        }

        /// <summary>
        /// The given <see cref="BasketProduct"/> has changed so update it.
        /// </summary>
        /// <param name="basketProductToRemove">The <see cref="BasketProduct"/> to update.</param>
        /// <returns>The <see cref="Basket"/> as it now stands.</returns>
        public Basket UpdateBasket(BasketProduct basketProductToRemove)
        {
            this._persistence.Change(basketProductToRemove);

            this._persistence.Commit();

            var basket = this._persistence.Find(
                new PersistenceSearcher<Basket>(b => b.Id == basketProductToRemove.BasketId));

            return basket;
        }
    }
}