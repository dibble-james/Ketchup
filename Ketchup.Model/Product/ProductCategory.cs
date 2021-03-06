﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategory.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Product
{
    using System.Collections.Generic;

    using JamesDibble.ApplicationFramework.Data;

    /// <summary>
    /// A grouping of <see cref="Product"/>s.
    /// </summary>
    public class ProductCategory : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the name of this <see cref="ProductCategory"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductCategorySpecificationAttribute"/>s of this <see cref="ProductCategory"/>.
        /// </summary>
        public virtual ICollection<ProductCategorySpecificationAttribute> Specification { get; set; } 

        /// <summary>
        /// Gets or sets the products in this <see cref="ProductCategory"/>.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="ProductCategory"/>.
        /// </summary>
        public virtual ProductCategory ParentCategory { get; set; }
    }
}