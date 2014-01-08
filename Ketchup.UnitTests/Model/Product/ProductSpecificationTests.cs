// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductSpecificationTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Model.Product
{
    using System.Collections.ObjectModel;
    using System.Globalization;

    using Ketchup.Model;
    using Ketchup.Model.Product;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProductSpecificationTests
    {
        [TestMethod]
        public void TestAttributesCanBeRetrievedDynamically()
        {
            var expected = 2.80M.ToString(CultureInfo.CurrentCulture);

            var productSpecification = new ProductSpecification
                                       {
                                           ProductAttributes =
                                               new Collection<ProductAttribute>
                                               {
                                                   new ProductAttribute
                                                   {
                                                       AttributeType
                                                           =
                                                           new ProductAttributeType
                                                           {
                                                               Name = "Price"
                                                           },
                                                       Value = expected
                                                   }
                                               }
                                       };

            var actual = productSpecification.Attributes.Price;

            Assert.AreEqual(expected, actual);
        }
    }
}