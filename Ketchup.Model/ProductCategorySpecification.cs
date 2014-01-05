// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategorySpecification.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using System.Collections.Generic;

    public class ProductCategorySpecification
    {
        public ICollection<ProductAttributeType> Attributes { get; set; } 
    }
}