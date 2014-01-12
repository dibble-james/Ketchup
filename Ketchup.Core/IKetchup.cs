// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKetchup.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using Api;

    /// <summary>
    /// Implementing classes define access points to eCommerce functions.
    /// </summary>
    public interface IKetchup
    {
        /// <summary>
        /// Gets access to the Ketchup <see cref="ICustomerManager"/>.
        /// </summary>
        ICustomerManager Customers { get; }

        /// <summary>
        /// Gets access to the Ketchup <see cref="IOrderManager"/>.
        /// </summary>
        IOrderManager Orders { get; }

        /// <summary>
        /// Gets access to the Ketchup <see cref="IProductManager"/>.
        /// </summary>
        IProductManager Products { get; }
    }
}