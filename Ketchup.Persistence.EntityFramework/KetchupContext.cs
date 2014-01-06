// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework
{
    using System.Data.Entity;

    using Ketchup.Model;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Data.Common;

    /// <summary>
    /// An EntityFramework context for use with Ketchup.
    /// </summary>
    public class KetchupContext : DbContext
    {
        public KetchupContext()
            : base()
        {
        }

        public KetchupContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public KetchupContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }
                
        public KetchupContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }
        
        public KetchupContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public KetchupContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }
        
        protected KetchupContext(DbCompiledModel model) 
            : base(model)
        {
        }

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
        /// <summary>
        /// Gets or sets the <see cref="ProductCategorySpecificationAttribute"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<ProductCategorySpecificationAttribute> ProductCategorySpecificationAttributes { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductAttribute>()
                .HasKey(pa => new { pa.AttributeTypeId })
                .HasRequired(pa => pa.ProductSpecification)
                .WithMany(ps => ps.ProductAttributes);

            modelBuilder.Entity<ProductSpecification>()
                .HasKey(ps => new { ps.ProductId, ps.ActiveFrom, ps.ActiveUntil });

            modelBuilder.Entity<ProductCategorySpecificationAttribute>()
                .HasKey(pcsa => new { pcsa.ProductAttributeTypeId, pcsa.ProductCategoryId })
                .HasRequired(pcsa => pcsa.Attribute)
                .WithMany(pa => pa.ProductCategories);
        }
    }
}