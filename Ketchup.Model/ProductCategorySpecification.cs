// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategorySpecification.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="ProductAttributeType"/>s a <see cref="Product"/> in the parent <see cref="ProductCategory"/>
    /// must have.
    /// </summary>
    public class ProductCategorySpecification
    {
        /// <summary>
        /// Gets or sets the <see cref="ProductAttributeType"/>s of this <see cref="ProductCategory"/>.
        /// </summary>
        public ICollection<ProductAttributeType> Attributes { get; set; } 
    }
}