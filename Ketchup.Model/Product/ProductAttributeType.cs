// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductAttributeType.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Product
{
    using System.Collections.Generic;

    using JamesDibble.ApplicationFramework.Data;

    /// <summary>
    /// A classification of a product specification value.
    /// </summary>
    public class ProductAttributeType : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the <see cref="ProductCategory"/>s this <see cref="ProductAttributeType"/> is part of.
        /// </summary>
        public virtual ICollection<ProductCategorySpecificationAttribute> ProductCategories { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductAttribute"/>s that use this <see cref="ProductAttributeType"/>.
        /// </summary>
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

        /// <summary>
        /// Gets or sets the name of this <see cref="ProductAttributeType"/>.
        /// </summary>
        /// <remarks>
        /// It is recommended to use C# naming specifications for this value so that it can be retrieved dynamically
        /// using the <see cref="M:ProductSpecification.Attributes"/> property.  Use <see cref="M:ProductAttributeType.DisplayName"/>
        /// to store a human friendly name.
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a human readable value of the <see cref="M:ProductAttributeType.Name"/>.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a regular expression to validate the value of a <see cref="ProductAttribute"/>.
        /// </summary>
        public string ValidationRegularExpression { get; set; }
    }
}