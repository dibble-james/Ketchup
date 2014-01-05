// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategory.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using System.Collections.Generic;

    using JamesDibble.ApplicationFramework.Data.Persistence;

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
        /// Gets or sets the <see cref="ProductCategorySpecification"/> of this <see cref="ProductCategory"/>.
        /// </summary>
        public ProductCategorySpecification Specification { get; set; }

        /// <summary>
        /// Gets or sets the products in this <see cref="ProductCategory"/>.
        /// </summary>
        public ICollection<Product> Products { get; set; } 
    }
}