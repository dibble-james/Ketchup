// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaketProduct.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Order
{
    using System;

    using Ketchup.Model.Product;

    public class BasketProduct
    {
        public Guid BasketId { get; set; }

        public int ProductId { get; set; }

        public Basket Basket { get; set; }

        public Product Product { get; set; }
    }
}