// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductAttributeType.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using JamesDibble.ApplicationFramework.Data.Persistence;

    public class ProductAttributeType : UniqueObject<int>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string ValidationRegularExpression { get; set; }
    }
}