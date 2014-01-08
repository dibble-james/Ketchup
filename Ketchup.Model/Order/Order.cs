// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Order
{
    using System;

    using Ketchup.Model.Customer;

    public class Order
    {
        public DateTime OrderDate { get; set; }

        public Guid BasketId { get; set; }

        public Basket Basket { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Address ShippingAddress { get; set; }
    }
}