// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductAttribute.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    /// <summary>
    /// A specification value of a product.
    /// </summary>
    public class ProductAttribute
    {
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