// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Ketchup.Model;
    using Ketchup.Model.Customer;
    using Ketchup.Model.Order;
    using Ketchup.Model.Product;

    /// <summary>
    /// An EntityFramework context for use with Ketchup.
    /// </summary>
    public class KetchupContext : DbContext
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="KetchupContext"/> class.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public KetchupContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
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

        /// <summary>
        /// Gets or sets the <see cref="Address"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Basket"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<Basket> Baskets { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="BasketProduct"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<BasketProduct> BasketProducts { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Order"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Customer"/> <see cref="DbSet"/>.
        /// </summary>
        public IDbSet<Customer> Customers { get; set; } 

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductAttribute>()
                .HasKey(pa => new { pa.AttributeTypeId, pa.ProductId, pa.AttributeActiveFrom, pa.AttributeActiveUntil });
            modelBuilder.Entity<ProductAttribute>()
                .HasRequired(pa => pa.ProductSpecification)
                .WithMany(ps => ps.ProductAttributes)
                .HasForeignKey(pa => new { pa.ProductId, pa.AttributeActiveFrom, pa.AttributeActiveUntil })
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<ProductAttribute>()
                .HasRequired(pa => pa.AttributeType)
                .WithMany(pat => pat.ProductAttributes)
                .HasForeignKey(pa => pa.AttributeTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ProductSpecification>()
                .HasKey(ps => new { ps.ProductId, ps.ActiveFrom, ps.ActiveUntil });

            modelBuilder.Entity<ProductCategorySpecificationAttribute>()
                .HasKey(pcsa => new { pcsa.ProductAttributeTypeId, pcsa.ProductCategoryId })
                .HasRequired(pcsa => pcsa.Attribute)
                .WithMany(pa => pa.ProductCategories);

            modelBuilder.Entity<Order>().HasKey(o => new { o.OrderDate, o.BasketId, o.CustomerId });
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Basket)
                .WithMany(b => b.Orders)
                .HasForeignKey(o => o.BasketId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>().HasRequired(o => o.ShippingAddress);

            modelBuilder.Entity<BasketProduct>().HasKey(bp => new { bp.BasketId, bp.ProductId });
            modelBuilder.Entity<BasketProduct>()
                .HasRequired(bp => bp.Basket)
                .WithMany(b => b.Products)
                .HasForeignKey(bp => bp.BasketId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<BasketProduct>()
                .HasRequired(bp => bp.Product)
                .WithMany(p => p.InBaskets)
                .HasForeignKey(bp => bp.ProductId)
                .WillCascadeOnDelete(true);
        }
    }
}