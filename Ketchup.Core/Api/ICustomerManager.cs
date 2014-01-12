// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    using Model.Customer;

    /// <summary>
    /// Implementing classes define methods to manage <see cref="Customer"/>s.
    /// </summary>
    public interface ICustomerManager
    {
        /// <summary>
        /// Build a new <see cref="Customer"/>.
        /// </summary>
        /// <param name="firstName">The <see cref="Customer"/>s first name.</param>
        /// <param name="lastName">The <see cref="Customer"/>s last name.</param>
        /// <param name="email">The <see cref="Customer"/>s email address.</param>
        /// <param name="address">The <see cref="Customer"/>s primary <see cref="Address"/>.</param>
        /// <returns>The new <see cref="Customer"/>.</returns>
        Customer CreateCustomer(string firstName, string lastName, string email, Address address);

        /// <summary>
        /// Add a new <see cref="Address"/> to a <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> to add an <see cref="Address"/> too.</param>
        /// <param name="newAddress">The new <see cref="Address"/> for the <paramref name="customer"/>.</param>
        /// <returns>The <see cref="Customer"/>.</returns>
        Customer AddAddress(Customer customer, Address newAddress);
    }
}