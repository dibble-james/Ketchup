// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basket.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Order
{
    using System;
    using System.Collections.Generic;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    public class Basket : UniqueObject<Guid>
    {
        public virtual ICollection<BasketProduct> Products { get; set; }

        public virtual ICollection<Order> Orders { get; set; } 
    }
}