// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    using System.Collections.Generic;

    using Ketchup.Model;

    /// <summary>
    /// Implementing classes define methods to perform actions upon <see cref="Product"/>s.
    /// </summary>
    public interface IProductManager
    {
        /// <summary>
        /// Build a new <see cref="ProductCategory"/> and save it.
        /// </summary>
        /// <param name="name">The name of the new <see cref="ProductCategory"/>.</param>
        /// <param name="specification">
        /// The attributes required for <see cref="Product"/>s of this <see cref="ProductCategory"/>.
        /// </param>
        /// <returns>The new <see cref="ProductCategory"/>.</returns>
        ProductCategory CreateProductCategory(string name, ProductCategorySpecification specification);

        /// <summary>
        /// Build a new <see cref="Product"/> and save it.
        /// </summary>
        /// <param name="productCategory">The group of the new <see cref="Product"/>.</param>
        /// <param name="productSpecification">The attributes of the new <see cref="Product"/>.</param>
        /// <returns>The new <see cref="Product"/>.</returns>
        Product CreateProduct(ProductCategory productCategory, ProductSpecification productSpecification);

        /// <summary>
        /// Build a new <see cref="ProductAttributeType"/> and save it.
        /// </summary>
        /// <param name="name">The name of the new <see cref="ProductAttributeType"/>.</param>
        /// <param name="displayName">A human readable value of the <paramref name="name"/>.</param>
        /// <param name="validationRegularExpression">A regular expression to validate the value of a <see cref="ProductAttribute"/>.</param>
        /// <returns>The new <see cref="ProductAttributeType"/>.</returns>
        ProductAttributeType CreateAttributeType(string name, string displayName, string validationRegularExpression);

        /// <summary>
        /// Retrieve all known <see cref="ProductAttributeType"/>s.
        /// </summary>
        /// <returns>All known <see cref="ProductAttributeType"/>s.</returns>
        IEnumerable<ProductAttributeType> GetProductAttributeTypes();

        /// <summary>
        /// Retrieve a <see cref="ProductAttributeType"/> by name.
        /// </summary>
        /// <param name="name">The name of the <see cref="ProductAttributeType"/> required.</param>
        /// <returns>
        /// A <see cref="ProductAttributeType"/> or null if no single <see cref="ProductAttributeType"/> exists.
        /// </returns>
        ProductAttributeType GetProductAttributeType(string name);

        /// <summary>
        /// Retrieve all known <see cref="Product"/>s.
        /// </summary>
        /// <returns>All known <see cref="Product"/>s.</returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Retrieve all known <see cref="ProductCategory"/>s.
        /// </summary>
        /// <returns>All known <see cref="ProductCategory"/>s.</returns>
        IEnumerable<ProductCategory> GetProductCategories();

        /// <summary>
        /// Retrieve the child <see cref="ProductCategory"/>s for a given <paramref name="parentCategory"/>.
        /// </summary>
        /// <returns>The child <see cref="ProductCategory"/>s</returns>
        IEnumerable<ProductCategory> GetProductCategories(ProductCategory parentCategory);

        /// <summary>
        /// Retrieve a <see cref="ProductCategory"/> by name.
        /// </summary>
        /// <param name="name">The name of the <see cref="ProductCategory"/> required.</param>
        /// <returns>
        /// A <see cref="ProductCategory"/> or null if no single <see cref="ProductCategory"/> exists.
        /// </returns>
        ProductCategory GetProductCategory(string name);

        /// <summary>
        /// Retrieve a <see cref="ProductCategory"/> by ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="ProductCategory"/> required.</param>
        /// <returns>
        /// A <see cref="ProductCategory"/> or null if no single <see cref="ProductCategory"/> exists.
        /// </returns>
        ProductCategory GetProductCategory(int id);
    }
}