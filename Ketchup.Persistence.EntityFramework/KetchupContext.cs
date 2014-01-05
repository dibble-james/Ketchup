// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework
{
    using System.Data.Entity;

    using Ketchup.Model;

    /// <summary>
    /// An EntityFramework context for use with Ketchup.
    /// </summary>
    public class KetchupContext : DbContext
    {
        /// <summary>
        /// Gets or sets the <see cref="Image"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Product"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<Product> Products { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ProductAttribute"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<ProductAttribute> ProductAttributes { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ProductAttributeType"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<ProductAttributeType> ProductAttributeTypes { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ProductCategory"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<ProductCategory> ProductCategorys { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ProductCategorySpecification"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<ProductCategorySpecification> ProductCategorySpecifications { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ProductSpecification"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<ProductSpecification> ProductSpecifications { get; set; }
    }
}