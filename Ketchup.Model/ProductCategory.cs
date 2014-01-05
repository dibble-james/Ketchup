// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCategory.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using JamesDibble.ApplicationFramework.Data.Persistence;

    public class ProductCategory : UniqueObject<int>
    {
        public ProductCategorySpecification Specification { get; set; }
    }
}