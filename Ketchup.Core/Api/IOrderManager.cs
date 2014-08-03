// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOrderManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    using System;
    using System.Collections.Generic;

    using Model.Customer;
    using Model.Order;
    using Model.Product;

    /// <summary>
    /// Implementing classes define methods to manage <see cref="Order"/>s.
    /// </summary>
    public interface IOrderManager
    {
        /// <summary>
        /// Build a new <see cref="Basket"/>.
        /// </summary>
        /// <param name="products">The <see cref="Product"/>s to create the basket with.</param>
        /// <returns>The new <see cref="Basket"/>.</returns>
        Basket CreateBasket(IEnumerable<BasketProduct> products);

        /// <summary>
        /// Build a new <see cref="Basket"/>.
        /// </summary>
        /// <param name="products">The <see cref="Product"/>s to create the basket with.</param>
        /// <returns>The new <see cref="Basket"/>.</returns>
        Basket CreateBasket(params BasketProduct[] products);

        /// <summary>
        /// Retrieve a <see cref="Basket"/> using it's identifier.
        /// </summary>
        /// <param name="basketIdentifier">The unique identifier of the <see cref="Basket"/>.</param>
        /// <returns>
        /// The <see cref="Basket"/> with the given <paramref name="basketIdentifier"/> or null if
        /// no <see cref="Basket"/> exists with the given <paramref name="basketIdentifier"/>.
        /// </returns>
        Basket GetBasket(Guid basketIdentifier);

        /// <summary>
        /// Add a <see cref="Product"/> to an existing <see cref="Basket"/>.
        /// </summary>
        /// <param name="basket">The <see cref="Basket"/> to add a <see cref="Product"/> too.</param>
        /// <param name="productToAdd">The new <see cref="Product"/> for the <paramref name="basket"/>.</param>
        /// <param name="quantity">The quantity of <see cref="Product"/> for the <paramref name="basket"/>.</param>
        /// <returns>The <see cref="Basket"/>.</returns>
        Basket AddProductToBasket(Basket basket, Product productToAdd, int quantity);

        /// <summary>
        /// The given <see cref="BasketProduct"/> is no longer required so take it out of the <see cref="M:BasketProduct.Basket"/>
        /// </summary>
        /// <param name="basketProductToRemove">The <see cref="BasketProduct"/> to remove.</param>
        /// <returns>The <see cref="Basket"/> as it now stands.</returns>
        Basket RemoveFromBasket(BasketProduct basketProductToRemove);

        /// <summary>
        /// The given <see cref="BasketProduct"/> has changed so update it.
        /// </summary>
        /// <param name="basketProductToRemove">The <see cref="BasketProduct"/> to update.</param>
        /// <returns>The <see cref="Basket"/> as it now stands.</returns>
        Basket UpdateBasket(BasketProduct basketProductToRemove);

        /// <summary>
        /// Build a new <see cref="Order"/>.
        /// </summary>
        /// <param name="basket">The <see cref="Product"/>s the new <see cref="Order"/> is for.</param>
        /// <param name="customer">The <see cref="Customer"/> the new <see cref="Order"/> is for.</param>
        /// <param name="shippingAddress">The <see cref="Address"/> to send the <see cref="Order"/> too.</param>
        /// <returns>The new <see cref="Order"/>.</returns>
        Order CreateOrder(Basket basket, Customer customer, Address shippingAddress);

        /// <summary>
        /// Retrieve an <see cref="Order"/> for a given <paramref name="customer"/> on a given <paramref name="orderDate"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> to retrieve an <see cref="Order"/> for.</param>
        /// <param name="orderDate">The <see cref="System.DateTime"/> the order was made upon.</param>
        /// <returns>
        /// An <see cref="Order"/> with the matching <paramref name="customer"/> and <paramref name="orderDate"/> 
        /// or null if no <see cref="Order"/>s match.
        /// </returns>
        Order GetOrder(Customer customer, DateTime orderDate);

        /// <summary>
        /// Retrieve an <see cref="Order"/> with a given <paramref name="orderNumber"/>.
        /// </summary>
        /// <param name="orderNumber">The human friendly identifier of the required <see cref="Order"/>.</param>
        /// <returns>
        /// The <see cref="Order"/> with the matching <paramref name="orderNumber"/> or null if no
        /// matching <see cref="Order"/> could be found.
        /// </returns>
        Order GetOrder(string orderNumber);

        /// <summary>
        /// Retrieve all <see cref="Order"/>s for a given <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> to find <see cref="Order"/>s for.</param>
        /// <returns>All <see cref="Order"/>s for a given <see cref="Customer"/>.</returns>
        IEnumerable<Order> GetOrders(Customer customer);

        /// <summary>
        /// Retrieve all <see cref="Order"/>s for a given <see cref="Product"/>.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to find <see cref="Order"/>s for.</param>
        /// <returns>All <see cref="Order"/>s for a given <see cref="Product"/>.</returns>
        IEnumerable<Order> GetOrders(Product product);

        /// <summary>
        /// Retrieve all <see cref="Order"/>s made between two <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="from">The oldest <see cref="System.DateTime"/>.</param>
        /// <param name="to">The closest <see cref="System.DateTime"/>.</param>
        /// <returns>All <see cref="Order"/>s made between two given <see cref="System.DateTime"/>.</returns>
        IEnumerable<Order> GetOrders(DateTime from, DateTime to);
    }
}