// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    public class Product : UniqueObject<int>
    {
        public ProductCategory Category { get; set; }

        public ICollection<ProductSpecification> ProductSpecifications { get; set; }

        public ProductSpecification ActiveSpecification
        {
            get
            {
                var active =
                    this.ProductSpecifications
                        .OrderByDescending(ps => ps.ActiveUntil)
                        .FirstOrDefault(ps => ps.ActiveFrom <= DateTime.Now);

                return active;
            }
        }

        public ProductSpecification ActiveAt(DateTime context)
        {
            var active =
                    this.ProductSpecifications
                        .OrderByDescending(ps => ps.ActiveUntil)
                        .FirstOrDefault(ps => ps.ActiveFrom <= context);

            return active;
        }
    }
}