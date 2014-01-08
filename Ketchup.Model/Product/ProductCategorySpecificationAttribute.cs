// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategorySpecificationAttribute.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Product
{
    /// <summary>
    /// A class that represents a link between a <see cref="ProductCategory"/> and a <see cref="ProductAttributeType"/>.
    /// </summary>
    public class ProductCategorySpecificationAttribute
    {
        /// <summary>
        /// Gets or sets the product category foreign key.
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the product attribute type foreign key.
        /// </summary>
        public int ProductAttributeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductCategory"/> in this relationship.
        /// </summary>
        public ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductAttributeType"/>s of this <see cref="ProductCategorySpecificationAttribute"/>.
        /// </summary>
        public ProductAttributeType Attribute { get; set; } 
    }
}