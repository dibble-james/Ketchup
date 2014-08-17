// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Model.Product
{
    using System;
    using System.Collections.ObjectModel;

    using Ketchup.Model.Product;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestActiveSpecification()
        {
            var productSpecification1 = new ProductSpecification
                                        {
                                            ActiveFrom = DateTime.Now.AddDays(-3),
                                            ActiveUntil = DateTime.Now.AddDays(3)
                                        };

            var productSpecification2 = new ProductSpecification
                                        {
                                            ActiveFrom = DateTime.Now.AddDays(-6),
                                            ActiveUntil = DateTime.Now.AddDays(-3)
                                        };

            var productSpecification3 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-6),
                ActiveUntil = DateTime.Now.AddDays(-6)
            };

            var product = new Product
                          {
                              ProductSpecifications =
                                  new Collection<ProductSpecification>
                                  {
                                      productSpecification1,
                                      productSpecification2,
                                      productSpecification3
                                  }
                          };

            var actual = product.ActiveSpecification;

            Assert.AreEqual(productSpecification1, actual);
        }

        [TestMethod]
        public void TestActiveSpecificationSameEndDate()
        {
            var productSpecification1 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-5),
                ActiveUntil = DateTime.MaxValue
            };

            var productSpecification2 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-4),
                ActiveUntil = DateTime.MaxValue
            };

            var productSpecification3 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-3),
                ActiveUntil = DateTime.MaxValue
            };

            var product = new Product
            {
                ProductSpecifications =
                    new Collection<ProductSpecification>
                                  {
                                      productSpecification1,
                                      productSpecification2,
                                      productSpecification3
                                  }
            };

            var actual = product.ActiveSpecification;

            Assert.AreEqual(productSpecification3, actual);
        }

        [TestMethod]
        public void TestActiveAtSpecificationSameEndDate()
        {
            var productSpecification1 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-5),
                ActiveUntil = DateTime.MaxValue
            };

            var productSpecification2 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-4),
                ActiveUntil = DateTime.MaxValue
            };

            var productSpecification3 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-3),
                ActiveUntil = DateTime.MaxValue
            };

            var product = new Product
            {
                ProductSpecifications =
                    new Collection<ProductSpecification>
                                  {
                                      productSpecification1,
                                      productSpecification2,
                                      productSpecification3
                                  }
            };

            var actual = product.ActiveAt(DateTime.Now.AddDays(-4));

            Assert.AreEqual(productSpecification2, actual);
        }

        [TestMethod]
        public void TestActiveAtSpecificationsWithSameStartDate()
        {
            var now = DateTime.Now;

            var productSpecification1 = new ProductSpecification
            {
                ActiveFrom = now.AddDays(-5),
                ActiveUntil = DateTime.MaxValue
            };

            var productSpecification2 = new ProductSpecification
            {
                ActiveFrom = now.AddDays(-4),
                ActiveUntil = DateTime.MaxValue
            };

            var productSpecification3 = new ProductSpecification
            {
                ActiveFrom = now.AddDays(-3),
                ActiveUntil = DateTime.MaxValue
            };

            var product = new Product
            {
                ProductSpecifications =
                    new Collection<ProductSpecification>
                                  {
                                      productSpecification1,
                                      productSpecification2,
                                      productSpecification3
                                  }
            };

            var actual = product.ActiveAt(now.AddDays(-4));

            Assert.AreEqual(productSpecification2, actual);
        }

        [TestMethod]
        public void TestActiveAtSpecification()
        {
            var productSpecification1 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-3),
                ActiveUntil = DateTime.Now.AddDays(3)
            };

            var productSpecification2 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-6),
                ActiveUntil = DateTime.Now.AddDays(-3)
            };

            var productSpecification3 = new ProductSpecification
            {
                ActiveFrom = DateTime.Now.AddDays(-9),
                ActiveUntil = DateTime.Now.AddDays(-6)
            };

            var product = new Product
            {
                ProductSpecifications =
                    new Collection<ProductSpecification>
                                  {
                                      productSpecification1,
                                      productSpecification2,
                                      productSpecification3
                                  }
            };

            var actual = product.ActiveAt(DateTime.Now.AddDays(-8));

            Assert.AreEqual(productSpecification3, actual);
        }
    }
}