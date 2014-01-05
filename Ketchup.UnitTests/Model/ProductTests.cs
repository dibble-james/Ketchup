// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Model
{
    using System;
    using System.Collections.ObjectModel;

    using Ketchup.Model;

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