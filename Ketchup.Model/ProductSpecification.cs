// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductSpecification.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// The attributes of a <see cref="Product"/>.
    /// </summary>
    public class ProductSpecification : DynamicObject
    {
        /// <summary>
        /// Gets or sets the product foreign key.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Product"/> this <see cref="ProductSpecification"/>
        /// provides attributes for.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets a <see langword="dynamic" /> representation of this <see cref="ProductSpecification"/>
        /// so that attributes can be retrieved without having to dig into the specification too far with
        /// <see langword="string" />s.
        /// </summary>
        public dynamic Attributes
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> this <see cref="ProductSpecification"/> was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> this <see cref="ProductSpecification"/> is relevant from.
        /// </summary>
        public DateTime ActiveFrom { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> this <see cref="ProductSpecification"/> is relevant till.
        /// </summary>
        public DateTime ActiveUntil { get; set; }

        /// <summary>
        /// Gets or sets the specification values for the parent <see cref="Product"/>.
        /// </summary>
        public ICollection<ProductAttribute> ProductAttributes { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Image"/>s for the parent <see cref="Product"/>.
        /// </summary>
        public ICollection<Image> ProductImages { get; set; }

        /// <summary>
        /// Provides the implementation for operations that get member values. Classes derived from 
        /// the <see cref="T:System.Dynamic.DynamicObject"/> class can override this method to specify
        /// dynamic behaviour for operations such as getting a value for a property.
        /// </summary>
        /// <returns>
        /// true if the operation is successful; otherwise, false. If this method returns false, the 
        /// run-time binder of the language determines the behaviour. (In most cases, 
        /// a run-time exception is thrown.)
        /// </returns>
        /// <param name="binder">
        /// Provides information about the object that called the dynamic operation. 
        /// The binder.Name property provides the name of the member on which the dynamic operation is 
        /// performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, 
        /// where sampleObject is an instance of the class derived from the 
        /// <see cref="T:System.Dynamic.DynamicObject"/> class, binder.Name returns "SampleProperty". 
        /// The binder.IgnoreCase property specifies whether the member name is case-sensitive.
        /// </param>
        /// <param name="result">
        /// The result of the get operation. For example, if the method is called for a property, 
        /// you can assign the property value to <paramref name="result"/>.
        /// </param>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (this.ProductAttributes.All(
                pa => pa.AttributeType.Name.ToLower(CultureInfo.CurrentCulture) != binder.Name.ToLower(CultureInfo.CurrentCulture)))
            {
                return base.TryGetMember(binder, out result);
            }

            result =
                this.ProductAttributes.First(
                    pa => pa.AttributeType.Name.ToLowerInvariant() == binder.Name.ToLowerInvariant()).Value;

            return true;
        }
    }
}