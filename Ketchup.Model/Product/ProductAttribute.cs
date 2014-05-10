// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductAttribute.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Product
{
    using System;
    using JamesDibble.ApplicationFramework.Data;

    /// <summary>
    /// A specification value of a product.
    /// </summary>
    public class ProductAttribute : IPersistedObject
    {
        /// <summary>
        /// Gets or sets the attribute type foreign key.
        /// </summary>
        public int AttributeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="Product"/> for this <see cref="ProductAttribute"/>.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> this <see cref="ProductAttribute"/> will be active from.
        /// </summary>
        public DateTime AttributeActiveFrom { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> this <see cref="ProductAttribute"/> will be active until.
        /// </summary>
        public DateTime AttributeActiveUntil { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductSpecification"/> this <see cref="ProductAttribute"/> is
        /// part of.
        /// </summary>
        public virtual ProductSpecification ProductSpecification { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductAttributeType"/> of this <see cref="ProductAttribute"/>.
        /// </summary>
        public virtual ProductAttributeType AttributeType { get; set; }

        /// <summary>
        /// Gets or sets the serialised value of this <see cref="ProductAttribute"/>.
        /// </summary>
        public string Value { get; set; }
    }
}