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

    public class Customer : UniqueObject<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}