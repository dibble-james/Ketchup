// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategorySpecificationAttribute.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using System.Collections.Generic;

    public class ProductCategorySpecificationAttribute
    {
        public int ProductCategoryId { get; set; }

        public int ProductAttributeTypeId { get; set; }

        public ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductAttributeType"/>s of this <see cref="ProductCategorySpecificationAttribute"/>.
        /// </summary>
        public ProductAttributeType Attribute { get; set; } 
    }
}