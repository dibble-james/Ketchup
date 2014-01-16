// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategorySpecification.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Product
{
    using System.Collections.Generic;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// The <see cref="ProductAttributeType"/>s a <see cref="Product"/> in the parent <see cref="ProductCategory"/>
    /// must have.
    /// </summary>
    public class ProductCategorySpecification : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the product category foreign key.
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductCategory"/> in this relationship.
        /// </summary>
        public virtual ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductCategorySpecificationAttribute"/>s of this <see cref="ProductCategory"/>.
        /// </summary>
        public virtual ICollection<ProductCategorySpecificationAttribute> Attributes { get; set; } 
    }
}