// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Order
{
    using System;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Ketchup.Model.Customer;

    /// <summary>
    /// A model for an <see cref="Order"/> placed by a <see cref="Customer"/>.
    /// </summary>
    public class Order : IPersistedObject
    {
        /// <summary>
        /// Gets or sets the human friendly order identifier.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the the <see cref="System.DateTime"/> this <see cref="Order"/> was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="Basket"/> of this <see cref="Order"/>.
        /// </summary>
        public Guid BasketId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Basket"/> of this <see cref="Order"/>.
        /// </summary>
        public Basket Basket { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="Customer"/> of this <see cref="Order"/>.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Customer"/> of this <see cref="Order"/>.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Address"/> this <see cref="Order"/> should be sent too.
        /// </summary>
        public Address ShippingAddress { get; set; }
    }
}