// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductAttribute.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Product
{
    using System;

    /// <summary>
    /// A specification value of a product.
    /// </summary>
    public class ProductAttribute
    {
        /// <summary>
        /// Gets or sets the attribute type foreign key.
        /// </summary>
        public int AttributeTypeId { get; set; }
        
        public int ProductId { get; set; }

        public DateTime AttributeActiveFrom { get; set; }

        public DateTime AttributeActiveUntil { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductSpecification"/> this <see cref="ProductAttribute"/> is
        /// part of.
        /// </summary>
        public ProductSpecification ProductSpecification { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductAttributeType"/> of this <see cref="ProductAttribute"/>.
        /// </summary>
        public ProductAttributeType AttributeType { get; set; }

        /// <summary>
        /// Gets or sets the serialised value of this <see cref="ProductAttribute"/>.
        /// </summary>
        public string Value { get; set; }
    }
}