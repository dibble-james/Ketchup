// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    using System;
    using System.Collections.Generic;

    using Model.Product;

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
        ProductCategory CreateProductCategory(string name, IEnumerable<ProductCategorySpecificationAttribute> specification);

        /// <summary>
        /// Build a new <see cref="Product"/> and save it.
        /// </summary>
        /// <param name="productSpecification">The attributes of the new <see cref="Product"/>.</param>
        /// <param name="category">The parent <see cref="ProductCategory"/> of the new <see cref="Product"/>.</param>
        /// <returns>The new <see cref="Product"/>.</returns>
        Product CreateProduct(ProductSpecification productSpecification, ProductCategory category);

        /// <summary>
        /// Concatenate an updated <see cref="ProductSpecification"/> to a given <paramref name="product"/>.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to update.</param>
        /// <param name="updatedSpecification">The updated <see cref="ProductSpecification"/>.</param>
        /// <returns>The updated <paramref name="product"/>.</returns>
        Product UpdateProduct(Product product, ProductSpecification updatedSpecification);

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
        /// Retrieve a <see cref="ProductAttributeType"/> by ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="ProductAttributeType"/> required.</param>
        /// <returns>
        /// A <see cref="ProductAttributeType"/> or null if no single <see cref="ProductAttributeType"/> exists.
        /// </returns>
        ProductAttributeType GetProductAttributeType(int id);

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
        /// Retrieve all <see cref="Product"/>s that match a given <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">An expression to match <see cref="Product"/>s by.</param>
        /// <returns>All <see cref="Product"/>s that match a given <paramref name="predicate"/>.</returns>
        IEnumerable<Product> GetProducts(Func<Product, bool> predicate);

        /// <summary>
        /// Retrieve all <see cref="Product"/>s that have the same <see cref="ProductAttribute"/>(s).
        /// </summary>
        /// <param name="relatedProductAttributes">The <see cref="ProductAttribute"/>s to match upon.</param>
        /// <returns>All <see cref="Product"/>s that have the same <see cref="ProductAttribute"/>(s).</returns>
        IEnumerable<Product> GetRelatedProducts(params ProductAttribute[] relatedProductAttributes);

        /// <summary>
        /// Retrieve all <see cref="Product"/>s that have the same <see cref="ProductAttribute"/>(s).
        /// </summary>
        /// <param name="category">The <see cref="ProductCategory"/> the matching <see cref="Product"/>s must belong.</param>
        /// <param name="relatedProductAttributes">The <see cref="ProductAttribute"/>s to match upon.</param>
        /// <returns>All <see cref="Product"/>s that have the same <see cref="ProductAttribute"/>(s).</returns>
        IEnumerable<Product> GetRelatedProducts(ProductCategory category, params ProductAttribute[] relatedProductAttributes);
            
        /// <summary>
        /// Retrieve all known <see cref="ProductCategory"/>s.
        /// </summary>
        /// <returns>All known <see cref="ProductCategory"/>s.</returns>
        IEnumerable<ProductCategory> GetProductCategories();

        /// <summary>
        /// Retrieve the child <see cref="ProductCategory"/>s for a given <paramref name="parentCategory"/>.
        /// </summary>
        /// <param name="parentCategory">The <see cref="ProductCategory"/> to get child categories for.</param>
        /// <returns>The child <see cref="ProductCategory"/>s</returns>
        IEnumerable<ProductCategory> GetProductCategories(ProductCategory parentCategory);

        /// <summary>
        /// Retrieve all the distinct <see cref="ProductAttribute"/>s for a <see cref="ProductCategory"/> and
        /// <see cref="ProductAttributeType"/> based on their value.
        /// </summary>
        /// <param name="category">The <see cref="ProductCategory"/> to find the unique attributes for.</param>
        /// <param name="attributeType">The <see cref="ProductAttributeType"/> to find the unique attributes for.</param>
        /// <returns>A collection of distinct <see cref="ProductAttribute"/>s.</returns>
        IEnumerable<ProductAttribute> GetUniqueProductAttributes(ProductCategory category, ProductAttributeType attributeType);
            
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

        /// <summary>
        /// Retrieve a <see cref="Product"/> by ID.
        /// </summary>
        /// <param name="id">The ID of the <see cref="ProductCategory"/> required.</param>
        /// <returns>
        /// A <see cref="Product"/> or null if no single <see cref="Product"/> exists.
        /// </returns>
        Product GetProduct(int id);

        /// <summary>
        /// Retrieve a <see cref="Product"/> that matches a given <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">An expression to match <see cref="Product"/> by.</param>
        /// <returns>
        /// A <see cref="Product"/> or null if no single <see cref="Product"/> exists.
        /// </returns>
        Product GetProduct(Func<Product, bool> predicate);
    }
}