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
    using System.Linq;

    public class ProductSpecification : DynamicObject
    {
        public dynamic Attributes
        {
            get
            {
                return this;
            }
        }

        public DateTime Created { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveUntil { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }

        public ICollection<Image> ProductImages { get; set; }

        /// <summary>
        /// Provides the implementation for operations that get member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject"/> class can override this method to specify dynamic behavior for operations such as getting a value for a property.
        /// </summary>
        /// <returns>
        /// true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a run-time exception is thrown.)
        /// </returns>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject"/> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param><param name="result">The result of the get operation. For example, if the method is called for a property, you can assign the property value to <paramref name="result"/>.</param>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (this.ProductAttributes.All(pa => pa.AttributeType.Name.ToLowerInvariant() != binder.Name.ToLowerInvariant()))
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