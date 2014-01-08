// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ketchup.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using global::Ketchup.Api;

    /// <summary>
    /// An object to inject Ketchups behavior into applications.
    /// </summary>
    public class Ketchup : IKetchup
    {
        private readonly ICustomerManager _customerManager;
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="Ketchup"/> class.
        /// </summary>
        /// <param name="customerManager">An <see cref="ICustomerManager"/> instance.</param>
        /// <param name="orderManager">An <see cref="IOrderManager"/> instance.</param>
        /// <param name="productManager">An <see cref="IProductManager"/> instance.</param>
        public Ketchup(ICustomerManager customerManager, IOrderManager orderManager, IProductManager productManager)
        {
            this._customerManager = customerManager;
            this._orderManager = orderManager;
            this._productManager = productManager;
        }

        /// <summary>
        /// Gets access to the Ketchup <see cref="ICustomerManager"/>.
        /// </summary>
        public ICustomerManager Customers
        {
            get
            {
                return this._customerManager;
            }
        }

        /// <summary>
        /// Gets access to the Ketchup <see cref="IOrderManager"/>.
        /// </summary>
        public IOrderManager Orders
        {
            get
            {
                return this._orderManager;
            }
        }

        /// <summary>
        /// Gets access to the Ketchup <see cref="IProductManager"/>.
        /// </summary>
        public IProductManager Products
        {
            get
            {
                return this._productManager;
            }
        }
    }
}