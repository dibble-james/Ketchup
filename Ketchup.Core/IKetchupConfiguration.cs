//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IKetchupConfiguration.cs" company="James Dibble">
//     Copyright 2012 James Dibble
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using Api;
    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// Implementing classes define methods for building <see cref="IKetchup"/> fluidly and the properties
    /// to define a <see cref="IKetchup"/> context.
    /// </summary>
    public interface IKetchupConfiguration
    {
        /// <summary>
        /// Define this <see cref="IKetchup"/> instance as one that can access information about and manage products.
        /// </summary>
        /// <returns>The current <see cref="IKetchupConfiguration"/>.</returns>
        IKetchupConfiguration AsProductManager();

        /// <summary>
        /// Define this <see cref="IKetchup"/> instance as one that can manager customers.
        /// </summary>
        /// <returns>The current <see cref="IKetchupConfiguration"/>.</returns>
        IKetchupConfiguration AsCustomerManager();

        /// <summary>
        /// Define this <see cref="IKetchup"/> instance as one that can create and manage orders.
        /// </summary>
        /// <param name="orderNumberGenerator">An object to create order numbers.</param>
        /// <returns>The current <see cref="IKetchupConfiguration"/>.</returns>
        IKetchupConfiguration AsOrderManager(IOrderNumberGenerator orderNumberGenerator);

        /// <summary>
        /// Create an <see cref="IKetchup"/> context with the previously set parameters.
        /// </summary>
        /// <returns>An <see cref="IKetchup"/> context.</returns>
        IKetchup Build();
    }
}