// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasketProduct.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Order
{
    using System;

    using JamesDibble.ApplicationFramework.Data;

    using Ketchup.Model.Product;

    /// <summary>
    /// A model to join a <see cref="Product"/> to a <see cref="Basket"/>.
    /// </summary>
    public class BasketProduct : IPersistedObject
    {
        /// <summary>
        /// Gets or sets the ID of the <see cref="Basket"/> in the join.
        /// </summary>
        public Guid BasketId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="Product"/> in the join.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of <see cref="Product"/> in the <see cref="Basket"/>.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Basket"/> in the join.
        /// </summary>
        public virtual Basket Basket { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Product"/> in the join.
        /// </summary>
        public virtual Product Product { get; set; }
    }
}