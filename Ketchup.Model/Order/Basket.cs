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

    /// <summary>
    /// A model to represent a selection of <see cref="Product"/>s.
    /// </summary>
    public class Basket : UniqueObject<Guid>
    {
        /// <summary>
        /// Gets or sets the <see cref="Product"/>s selected in this <see cref="Basket"/>.
        /// </summary>
        public virtual ICollection<BasketProduct> Products { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Orders"/> this <see cref="Basket"/> has been used in.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } 
    }
}