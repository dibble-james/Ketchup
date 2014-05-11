// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategorySpecificationAttribute.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Product
{
    using JamesDibble.ApplicationFramework.Data;

    /// <summary>
    /// A class that represents a link between a <see cref="ProductCategory"/> and a <see cref="ProductAttributeType"/>.
    /// </summary>
    public class ProductCategorySpecificationAttribute : IPersistedObject
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
        /// Gets or sets the ranking of this <see cref="ProductAttributeType"/> in the <see cref="ProductCategory"/> specification.
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductCategory"/> in this relationship.
        /// </summary>
        public virtual ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductAttributeType"/>s of this <see cref="ProductCategorySpecificationAttribute"/>.
        /// </summary>
        public virtual ProductAttributeType Attribute { get; set; } 
    }
}