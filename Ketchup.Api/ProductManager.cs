// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    using System.Collections.ObjectModel;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Ketchup.Model;

    /// <summary>
    /// A class to perform actions upon <see cref="Product"/>s.
    /// </summary>
    public sealed class ProductManager : IProductManager
    {
        private readonly IPersistenceManager _persistence;

        /// <summary>
        /// Create a new instance of the <see cref="ProductManager"/> class.
        /// </summary>
        /// <param name="persistenceManager">A connection to a persistence source.</param>
        public ProductManager(IPersistenceManager persistenceManager)
        {
            this._persistence = persistenceManager;
        }

        /// <summary>
        /// Build a new <see cref="ProductCategory"/> and save it.
        /// </summary>
        /// <param name="name">The name of the new <see cref="ProductCategory"/>.</param>
        /// <param name="specification">
        /// The attributes required for <see cref="Product"/>s of this <see cref="ProductCategory"/>.
        /// </param>
        /// <returns>The new <see cref="ProductCategory"/>.</returns>
        public ProductCategory CreateProductCategory(string name, ProductCategorySpecification specification)
        {
            var productCategory = new ProductCategory { Name = name, Specification = specification };

            this._persistence.Add(productCategory);

            this._persistence.Commit();

            return productCategory;
        }

        /// <summary>
        /// Build a new <see cref="Product"/> and save it.
        /// </summary>
        /// <param name="productCategory">The group of the new <see cref="Product"/>.</param>
        /// <param name="productSpecification">The attributes of the new <see cref="Product"/>.</param>
        /// <returns>The new <see cref="Product"/>.</returns>
        public Product CreateProduct(ProductCategory productCategory, ProductSpecification productSpecification)
        {
            var product = new Product
                          {
                              Category = productCategory, 
                              ProductSpecifications = new Collection<ProductSpecification> { productSpecification }
                          };

            this._persistence.Add(product);

            this._persistence.Commit();

            return product;
        }
    }
}