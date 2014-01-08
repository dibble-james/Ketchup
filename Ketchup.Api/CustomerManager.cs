// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    using System.Collections.ObjectModel;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Ketchup.Model.Customer;

    /// <summary>
    /// A class to manage <see cref="Customer"/> objects.
    /// </summary>
    public class CustomerManager : ICustomerManager
    {
        private readonly IPersistenceManager _persistence;

        /// <summary>
        /// Initialises a new instance of the <see cref="CustomerManager"/> class.
        /// </summary>
        /// <param name="persistence">A connection to a persistence source.</param>
        public CustomerManager(IPersistenceManager persistence)
        {
            this._persistence = persistence;
        }

        /// <summary>
        /// Build a new <see cref="Customer"/>.
        /// </summary>
        /// <param name="firstName">The <see cref="Customer"/>s first name.</param>
        /// <param name="lastName">The <see cref="Customer"/>s last name.</param>
        /// <param name="email">The <see cref="Customer"/>s email address.</param>
        /// <param name="address">The <see cref="Customer"/>s primary <see cref="Address"/>.</param>
        /// <returns>The new <see cref="Customer"/>.</returns>
        public Customer CreateCustomer(string firstName, string lastName, string email, Address address)
        {
            var customer = new Customer
                           {
                               Addresses = new Collection<Address> { address },
                               Email = email,
                               FirstName = firstName,
                               LastName = lastName
                           };

            this._persistence.Add(customer);

            this._persistence.Commit();

            return customer;
        }

        /// <summary>
        /// Add a new <see cref="Address"/> to a <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> to add an <see cref="Address"/> too.</param>
        /// <param name="newAddress">The new <see cref="Address"/> for the <paramref name="customer"/>.</param>
        /// <returns>The <see cref="Customer"/>.</returns>
        public Customer AddAddress(Customer customer, Address newAddress)
        {
            customer.Addresses.Add(newAddress);

            this._persistence.Change(customer);

            this._persistence.Commit();

            return customer;
        }
    }
}