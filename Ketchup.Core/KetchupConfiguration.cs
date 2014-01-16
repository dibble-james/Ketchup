//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="KetchupConfiguration.cs" company="James Dibble">
//     Copyright 2012 James Dibble
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using System;

    using Api;
    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// An instance of the <see cref="IKetchup"/> fluid context builder.
    /// </summary>
    internal sealed class KetchupConfiguration : IKetchupConfiguration
    {
        private readonly IPersistenceManager _persistence;
        private readonly Ketchup _instance;

        internal KetchupConfiguration(IPersistenceManager persistence)
        {
            Argument.CannotBeNull(
                persistence, 
                "persistence", 
                "Ketchup must be able to access it's database via an IPersistenceManager");

            this._instance = new Ketchup();
            this._persistence = persistence;
        }

        /// <summary>
        /// Define this <see cref="IKetchup"/> instance as one that can access information about and manage products.
        /// </summary>
        /// <returns>The current <see cref="IKetchupConfiguration"/>.</returns>
        public IKetchupConfiguration AsProductManager()
        {
            this._instance.Products = new ProductManager(this._persistence);

            return this;
        }

        /// <summary>
        /// Define this <see cref="IKetchup"/> instance as one that can manager customers.
        /// </summary>
        /// <returns>The current <see cref="IKetchupConfiguration"/>.</returns>
        public IKetchupConfiguration AsCustomerManager()
        {
            this._instance.Customers = new CustomerManager(this._persistence);

            return this;
        }

        /// <summary>
        /// Define this <see cref="IKetchup"/> instance as one that can create and manage orders.
        /// </summary>
        /// <param name="orderNumberGenerator">An object to create order numbers.</param>
        /// <returns>The current <see cref="IKetchupConfiguration"/>.</returns>
        public IKetchupConfiguration AsOrderManager(IOrderNumberGenerator orderNumberGenerator)
        {
            Argument.CannotBeNull(
                orderNumberGenerator, 
                "orderNumberGenerator", 
                "To be configured as an Order Manager, Ketchup must be able to generate order numbers.");

            this._instance.Orders = new OrderManager(this._persistence, orderNumberGenerator);

            return this;
        }

        /// <summary>
        /// Create an <see cref="IKetchup"/> context with the previously set parameters.
        /// </summary>
        /// <returns>An <see cref="IKetchup"/> context.</returns>
        public IKetchup Build()
        {
            return this._instance;
        }
    }
}