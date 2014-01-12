// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ketchup.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using System;
    using Api;
    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// An implementation of <see cref="IKetchup"/> for use with a fluid interface builder.
    /// </summary>
    internal sealed class Ketchup : IKetchup
    {
        private readonly IPersistenceManager _persistence;
        private readonly IOrderNumberGenerator _orderNumberGenerator;

        private ICustomerManager _customerManager;
        private IOrderManager _orderManager;
        private IProductManager _productManager;

        internal Ketchup(IPersistenceManager persistence)
        {
            this._persistence = persistence;
        }

        internal Ketchup(IPersistenceManager persistence, IOrderNumberGenerator orderNumberGenerator)
        {
            this._persistence = persistence;
            this._orderNumberGenerator = orderNumberGenerator;
        }

        /// <summary>
        /// Gets access to the Ketchup <see cref="ICustomerManager"/>.
        /// </summary>
        public ICustomerManager Customers
        {
            get
            {
                return this._customerManager ?? (this._customerManager = new CustomerManager(this._persistence));
            }
        }

        /// <summary>
        /// Gets access to the Ketchup <see cref="IOrderManager"/>.
        /// </summary>
        public IOrderManager Orders
        {
            get
            {
                if (this._orderNumberGenerator == null)
                {
                    throw new InvalidOperationException(
                        @"Ketchup was not configured with an IOrderNumberGenerator and therefore cannot be used to manage orders.");
                }

                return this._orderManager ?? (this._orderManager = new OrderManager(this._persistence, this._orderNumberGenerator));
            }
        }

        /// <summary>
        /// Gets access to the Ketchup <see cref="IProductManager"/>.
        /// </summary>
        public IProductManager Products
        {
            get
            {
                return this._productManager ?? (this._productManager = new ProductManager(this._persistence));
            }
        }
    }
}