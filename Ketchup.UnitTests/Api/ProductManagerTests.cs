// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductManagerTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Api
{
    using System.Collections.Generic;
    using System.Linq;

    using JamesDibble.ApplicationFramework.Data.Persistence;
    using JamesDibble.ApplicationFramework.Data.Persistence.Fakes;

    using Ketchup.Api;
    using Ketchup.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProductManagerTests
    {
        private IList<ProductCategory> _productCategories;
        private IList<Product> _products;
        private IPersistenceManager _fakePersistenceManager;
        private ProductManager _target;

        [TestInitialize]
        public void TestSetup()
        {
            this._productCategories = new List<ProductCategory>();
            this._products = new List<Product>();

            var fakePersistence = new StubIPersistenceManager
                                  {
                                      Commit = () => { return; }
                                  };

            fakePersistence.AddOf1M0<ProductCategory>(c => this._productCategories.Add(c));
            fakePersistence.AddOf1M0<Product>(p => this._products.Add(p));

            this._fakePersistenceManager = fakePersistence;

            this._target = new ProductManager(this._fakePersistenceManager);
        }

        [TestMethod]
        public void TestCreateProductCategory()
        {
            var actual = this._target.CreateProductCategory("Fake Name", new ProductCategorySpecification());

            Assert.IsNotNull(actual);

            Assert.IsTrue(this._productCategories.Any());
        }

        [TestMethod]
        public void TestCreateProduct()
        {
            var actual = this._target.CreateProduct(new ProductCategory(), new ProductSpecification());

            Assert.IsNotNull(actual);

            Assert.IsTrue(this._products.Any());
        }
    }
}