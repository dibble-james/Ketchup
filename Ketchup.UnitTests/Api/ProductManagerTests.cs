// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductManagerTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using JamesDibble.ApplicationFramework.Data.Persistence.Fakes;

    using Ketchup.Api;
    using Ketchup.Model;
    using Ketchup.Model.Product;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProductManagerTests
    {
        private IList<ProductCategory> _productCategories;
        private IList<Product> _products;
        private IList<ProductAttributeType> _productAttributeTypes;
        private StubIPersistenceManager _fakePersistenceManager;
        private ProductManager _target;

        [TestInitialize]
        public void TestSetup()
        {
            this._productCategories = new List<ProductCategory>();
            this._products = new List<Product>();
            this._productAttributeTypes = new List<ProductAttributeType>();

            var fakePersistence = new StubIPersistenceManager
                                  {
                                      Commit = () => { return; }
                                  };

            fakePersistence.AddOf1M0<ProductCategory>(c => this._productCategories.Add(c));
            fakePersistence.AddOf1M0<Product>(p => this._products.Add(p));
            fakePersistence.AddOf1M0<ProductAttributeType>(pat => this._productAttributeTypes.Add(pat));

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

        [TestMethod]
        public void TestCreateProductAttributeType()
        {
            var actual = this._target.CreateAttributeType(string.Empty, string.Empty, @"$^");

            Assert.IsNotNull(actual);

            Assert.IsTrue(this._productAttributeTypes.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCreateProductAttributeTypeAlreadyExists()
        {
            this._fakePersistenceManager.FindOf1IPersistenceSearcherOfM0<ProductAttributeType>(ps => new ProductAttributeType());

            var actual = this._target.CreateAttributeType(string.Empty, string.Empty, @"$^");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateProductAttributeTypeInvalidRegex()
        {
            var actual = this._target.CreateAttributeType(string.Empty, string.Empty, @"$(");
        }

        [TestMethod]
        public void TestGetRelatedProducts()
        {
            var attributeType1 = new ProductAttributeType { Id = 1 };
            var attributeType2 = new ProductAttributeType { Id = 2 };
            var attributeType3 = new ProductAttributeType { Id = 3 };

            const string attributeValue1 = "TestValue1";
            const string attributeValue2 = "TestValue2";

            var product1 = new Product
                           {
                               ProductSpecifications =
                                   new Collection<ProductSpecification>
                                   {
                                       new ProductSpecification
                                       {
                                           ActiveFrom = DateTime.Now.AddDays(-3),
                                           ActiveUntil = DateTime.Now.AddDays(+3),
                                           ProductAttributes = new Collection<ProductAttribute>
                                                {
                                                   new ProductAttribute
                                                   {
                                                       AttributeType = attributeType1,
                                                       Value = attributeValue1
                                                   },
                                                   new ProductAttribute
                                                   {
                                                       AttributeType = attributeType3,
                                                       Value = "No one cares"
                                                   }
                                               }
                                       }
                                   }
                           };

            var product2 = new Product
            {
                ProductSpecifications =
                    new Collection<ProductSpecification>
                                   {
                                       new ProductSpecification
                                       {
                                           ActiveFrom = DateTime.Now.AddDays(-3),
                                           ActiveUntil = DateTime.Now.AddDays(+3),
                                           ProductAttributes = new Collection<ProductAttribute>
                                                {
                                                   new ProductAttribute
                                                   {
                                                       AttributeType = attributeType1,
                                                       Value = attributeValue1
                                                   },
                                                   new ProductAttribute
                                                   {
                                                       AttributeType = attributeType2,
                                                       Value = attributeValue2
                                                   },
                                                   new ProductAttribute
                                                   {
                                                       AttributeType = attributeType3,
                                                       Value = "No one cares"
                                                   }
                                               }
                                       }
                                   }
            };

            this._fakePersistenceManager.FindOf1IPersistenceCollectionSearcherOfM0<Product>(ps => new [] { product1, product2 });

            var actual =
                this._target.GetRelatedProducts(
                    new ProductAttribute { AttributeType = attributeType1, Value = attributeValue1 },
                    new ProductAttribute { AttributeType = attributeType2, Value = attributeValue2 });

            Assert.IsTrue(actual.Count() == 1);
            Assert.AreEqual(product2, actual.FirstOrDefault());
        }
    }
}