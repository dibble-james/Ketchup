// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ketchup.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using System;
    using Api;

    /// <summary>
    /// An implementation of <see cref="IKetchup"/> for use with a fluid interface builder.
    /// </summary>
    internal sealed class Ketchup : IKetchup
    {
        private ICustomerManager _customerManager;
        private IOrderManager _orderManager;
        private IProductManager _productManager;

        /// <summary>
        /// Gets or sets access to the Ketchup <see cref="ICustomerManager"/>.
        /// </summary>
        public ICustomerManager Customers
        {
            get
            {
                if (this._customerManager == null)
                {
                    throw new InvalidOperationException("This Ketchup instance was not built AsCustomerManager.");
                }

                return this._customerManager;
            }

            internal set
            {
                this._customerManager = value;
            }
        }

        /// <summary>
        /// Gets or sets access to the Ketchup <see cref="IOrderManager"/>.
        /// </summary>
        public IOrderManager Orders
        {
            get
            {
                if (this._orderManager == null)
                {
                    throw new InvalidOperationException(
                        @"This Ketchup instance was not built AsOrderManager.");
                }

                return this._orderManager;
            }

            internal set
            {
                this._orderManager = value;
            }
        }

        /// <summary>
        /// Gets or sets access to the Ketchup <see cref="IProductManager"/>.
        /// </summary>
        public IProductManager Products
        {
            get
            {
                if (this._productManager == null)
                {
                    throw new InvalidOperationException(
                        @"This Ketchup instance was not built AsProductManager.");
                }

                return this._productManager;
            }

            internal set
            {
                this._productManager = value;
            }
        }
    }
}