// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductManagerTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Core.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Ketchup.Api;
    using Ketchup.Model.Product;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class ProductManagerTests
    {
        private IList<ProductCategory> _productCategories;
        private IList<Product> _products;
        private IList<ProductAttributeType> _productAttributeTypes;
        private Mock<IPersistenceManager> _fakePersistenceManager;
        private ProductManager _target;

        [TestInitialize]
        public void TestSetup()
        {
            this._productCategories = new List<ProductCategory>();
            this._products = new List<Product>();
            this._productAttributeTypes = new List<ProductAttributeType>();

            var fakePersistence = new Mock<IPersistenceManager>();
            fakePersistence.Setup(p => p.Commit()).Callback(() => { return; });

            fakePersistence.Setup(p => p.Add(It.IsAny<ProductCategory>()))
                .Callback<ProductCategory>(c => this._productCategories.Add(c));
            fakePersistence.Setup(p => p.Add(It.IsAny<Product>()))
                .Callback<Product>(c => this._products.Add(c));
            fakePersistence.Setup(p => p.Add(It.IsAny<ProductAttributeType>()))
                .Callback<ProductAttributeType>(c => this._productAttributeTypes.Add(c));

            this._fakePersistenceManager = fakePersistence;

            this._target = new ProductManager(this._fakePersistenceManager.Object);
        }

        [TestMethod]
        public void TestCreateProductCategory()
        {
            var actual = this._target.CreateProductCategory("Fake Name", new List<ProductCategorySpecificationAttribute>());

            Assert.IsNotNull(actual);

            Assert.IsTrue(this._productCategories.Any());
        }

        [TestMethod]
        public void TestCreateProduct()
        {
            var fakeCategory = new ProductCategory();
            var fakeSpecification = new ProductSpecification();

            var actual = this._target.CreateProduct(fakeSpecification, fakeCategory);

            Assert.IsNotNull(actual);
            Assert.AreEqual(fakeCategory, actual.Category);
            Assert.IsTrue(actual.ProductSpecifications.Any(ps => ps == fakeSpecification));

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
            this._fakePersistenceManager.Setup(pm => pm.Find(It.IsAny<IPersistenceSearcher<ProductAttributeType>>()))
                .Returns(new ProductAttributeType());


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
                                                       AttributeType = attributeType2,
                                                       Value = "A different value"
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

            this._fakePersistenceManager
                .Setup(p => p.Find(It.IsAny<IPersistenceCollectionSearcher<Product>>()))
                .Returns(new List<Product> { product1, product2 });

            var actual =
                this._target.GetRelatedProducts(
                    new ProductAttribute { AttributeType = attributeType1, Value = attributeValue1 },
                    new ProductAttribute { AttributeType = attributeType2, Value = attributeValue2 });

            Assert.IsTrue(actual.Count() == 1);
            Assert.AreEqual(product2, actual.FirstOrDefault());
        }

        [TestMethod]
        public void TestGetRelatedProductsWithCategory()
        {
            var attributeType1 = new ProductAttributeType { Id = 1 };
            var attributeType2 = new ProductAttributeType { Id = 2 };
            var attributeType3 = new ProductAttributeType { Id = 3 };

            var category1 = new ProductCategory { Id = 1 };
            var category2 = new ProductCategory { Id = 2 };

            const string attributeValue1 = "TestValue1";
            const string attributeValue2 = "TestValue2";

            var product1 = new Product
            {
                Category = category1,
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
                Category = category2,
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

            var product3 = new Product
            {
                Category = category1,
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

            this._fakePersistenceManager
                .Setup(p => p.Find(It.IsAny<IPersistenceCollectionSearcher<Product>>()))
                .Returns(new List<Product> { product1, product2, product3 });

            var actual =
                this._target.GetRelatedProducts(
                    category2,
                    new ProductAttribute { AttributeType = attributeType1, Value = attributeValue1 },
                    new ProductAttribute { AttributeType = attributeType2, Value = attributeValue2 });

            Assert.IsTrue(actual.Count() == 1);
            Assert.AreEqual(product2, actual.FirstOrDefault());
        }

        [TestMethod]
        public void TestGetAllProductAttributeTypes()
        {
            var attributeType1 = new ProductAttributeType { Id = 1 };
            var attributeType2 = new ProductAttributeType { Id = 2 };
            var attributeType3 = new ProductAttributeType { Id = 3 };

            var expected = new List<ProductAttributeType> { attributeType1, attributeType2, attributeType3 };

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.Is<PersistenceCollectionSearcher<ProductAttributeType>>(pcs => pcs.Predicate == null)))
                .Returns(expected);

            var actual = this._target.GetProductAttributeTypes();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetProductAttributeType()
        {
            var expected = new ProductAttributeType { Id = 1 };

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.IsAny<PersistenceSearcher<ProductAttributeType>>()))
                .Returns(expected);

            var actual = this._target.GetProductAttributeType("something");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetProductsWithPredicate()
        {
            var expected = new List<Product> { new Product { Id = 1 }, new Product { Id = 2 } };

            Func<Product, bool> predicate = p => p.Id == 1;

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.Is<PersistenceCollectionSearcher<Product>>(ps => ps.Predicate == predicate))).Returns(expected);

            var actual = this._target.GetProducts(predicate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetChildCategories()
        {
            var parentCategory = new ProductCategory { Id = 1 };

            var expected = new List<ProductCategory> { new ProductCategory { Id = 2 } };

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.IsAny<PersistenceCollectionSearcher<ProductCategory>>()))
                .Returns(expected);

            var actual = this._target.GetProductCategories(parentCategory);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCategoryById()
        {
            const int id = 1;

            var expected = new ProductCategory { Id = 1 };


            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.IsAny<PersistenceSearcher<ProductCategory>>()))
                .Returns(expected);

            var actual = this._target.GetProductCategory(id);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCategoryByName()
        {
            const string name = "hello";

            var expected = new ProductCategory { Id = 1 };

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.IsAny<PersistenceSearcher<ProductCategory>>()))
                .Returns(expected);

            var actual = this._target.GetProductCategory(name);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetAllCategories()
        {
            var expected = new List<ProductCategory> { new ProductCategory { Id = 1 }, new ProductCategory { Id = 2 } };

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.Is<PersistenceCollectionSearcher<ProductCategory>>(pcs => pcs.Predicate == null)))
                .Returns(expected);

            var actual = this._target.GetProductCategories();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetGetUniqueProductAttributes()
        {
            var fakeCategory = new ProductCategory();

            var fakeAttributeType = new ProductAttributeType();

            var fakeAttribute1 = new ProductAttribute
            {
                AttributeType = fakeAttributeType,
                Value = "Hello"
            };

            var fakeAttribute2 = new ProductAttribute
            {
                AttributeType = fakeAttributeType,
                Value = "hello"
            };

            var fakeAttribute3 = new ProductAttribute
            {
                AttributeType = fakeAttributeType,
                Value = "0"
            };

            var fakeAttribute4 = new ProductAttribute
            {
                AttributeType = fakeAttributeType,
                Value = "0"
            };

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.IsAny<PersistenceCollectionSearcher<ProductAttribute>>()))
                .Returns(new List<ProductAttribute>
                {
                    fakeAttribute1,
                    fakeAttribute2,
                    fakeAttribute3,
                    fakeAttribute4
                });

            var actual = this._target.GetUniqueProductAttributes(fakeCategory, fakeAttributeType);

            Assert.IsTrue(actual.Count() == 2);
        }

        [TestMethod]
        public void TestGetProductById()
        {
            const int expectedId = 1;

            var expected = new Product { Id = expectedId };

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.IsAny<PersistenceSearcher<Product>>()))
                .Returns(expected);

            var actual = this._target.GetProduct(expectedId);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetProductByPredicate()
        {
            const int expectedId = 1;

            var expected = new Product { Id = expectedId };

            Func<Product, bool> predicate = p => p.Id == 1;

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.Is<PersistenceSearcher<Product>>(pc => pc.Predicate == predicate)))
                .Returns(expected);

            var actual = this._target.GetProduct(predicate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetProductAttributeTypeById()
        {
            const int expectedId = 1;

            var expected = new ProductAttributeType { Id = expectedId };

            this._fakePersistenceManager.Setup(
                pm => pm.Find(It.IsAny<PersistenceSearcher<ProductAttributeType>>()))
                .Returns(expected);

            var actual = this._target.GetProductAttributeType(expectedId);

            Assert.AreEqual(expected, actual);
        }
    }
}