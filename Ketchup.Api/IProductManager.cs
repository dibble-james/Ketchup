// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
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
    }
}