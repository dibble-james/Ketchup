// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    using System;
    using System.Collections.ObjectModel;
    using JamesDibble.ApplicationFramework.Data.Persistence;
    using Model.Customer;

    /// <summary>
    /// A class to manage <see cref="Model.Customer.Customer"/> objects.
    /// </summary>
    public sealed class CustomerManager : ICustomerManager
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
        /// Build a new <see cref="Model.Customer.Customer"/>.
        /// </summary>
        /// <param name="firstName">The <see cref="Model.Customer.Customer"/>s first name.</param>
        /// <param name="lastName">The <see cref="Customer"/>s last name.</param>
        /// <param name="email">The <see cref="Customer"/>s email address.</param>
        /// <param name="address">The <see cref="Customer"/>s primary <see cref="Address"/>.</param>
        /// <returns>The new <see cref="Customer"/>.</returns>
        public Customer CreateCustomer(string firstName, string lastName, string email, Address address)
        {
            var customer = new Customer
                           {
                               Addresses = new Collection<Address>(),
                               Email = email,
                               FirstName = firstName,
                               LastName = lastName
                           };

            customer.SetNewId(Guid.NewGuid());

            if(address != null)
            {
                customer.Addresses.Add(address);
            }

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

        /// <summary>
        /// Find a <see cref="Customer"/> by it's unique identifier.
        /// </summary>
        /// <param name="uniqueIdentifier">The unique identifier of the <see cref="Customer"/> to find.</param>
        /// <returns>The <see cref="Customer"/> or null if one could not be found.</returns>
        public Customer GetCustomer(Guid uniqueIdentifier)
        {
            var customer = this._persistence.Find(new PersistenceSearcher<Customer>(c => c.Id == uniqueIdentifier));

            return customer;
        }
    }
}