﻿// --------------------------------------------------------------------------------------------------------------------
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

    /// <summary>
    /// An item for sale.
    /// </summary>
    public class Product : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the <see cref="ProductCategory"/> of this <see cref="Product"/>.
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProductSpecification"/>s, the attributes of this product according to its category.
        /// </summary>
        public ICollection<ProductSpecification> ProductSpecifications { get; set; }

        /// <summary>
        /// Gets the current <see cref="ProductSpecification"/>.
        /// </summary>
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

        /// <summary>
        /// Gets the <see cref="ProductSpecification"/> at a given <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="context">The <see cref="System.DateTime"/> to check for a specification for.</param>
        /// <returns>
        /// The <see cref="ProductSpecification"/> or <see langword="null" /> if at that time there was no specification.
        /// </returns>
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