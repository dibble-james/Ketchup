// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Customer
{
    using System;
    using System.Collections.Generic;

    using JamesDibble.ApplicationFramework.Data.Persistence;
    using Ketchup.Model.Order;

    /// <summary>
    /// A model to represent a person who can place an <see cref="Order"/>.
    /// </summary>
    public class Customer : UniqueObject<Guid>
    {
        /// <summary>
        /// Gets or sets the first name of this <see cref="Customer"/>.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of this <see cref="Customer"/>.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of this <see cref="Customer"/>.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Address"/>s this customer has disclosed.
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Order"/>s this <see cref="Customer"/> has placed.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}