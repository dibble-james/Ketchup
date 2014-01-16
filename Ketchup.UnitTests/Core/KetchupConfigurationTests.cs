//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="KetchupConfigurationTests.cs" company="James Dibble">
//     Copyright 2012 James Dibble
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Ketchup.UnitTests.Core
{
    using System;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Ketchup.Api;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class KetchupConfigurationTests
    {
        [TestMethod]
        public void TestBuilder()
        {
            var ketchup = KetchupBuilder.Configure(() => new Mock<IPersistenceManager>().Object).Build();

            Assert.IsNotNull(ketchup);
        }

        [TestMethod]
        public void TestBuildCustomerManager()
        {
            var ketchup =
                KetchupBuilder.Configure(() => new Mock<IPersistenceManager>().Object).AsCustomerManager().Build();

            Assert.IsNotNull(ketchup.Customers);
        }

        [TestMethod]
        public void TestBuildProductManager()
        {
            var ketchup =
                KetchupBuilder.Configure(() => new Mock<IPersistenceManager>().Object).AsProductManager().Build();

            Assert.IsNotNull(ketchup.Products);
        }

        [TestMethod]
        public void TestBuildOrderManger()
        {
            var ketchup =
                KetchupBuilder
                    .Configure(() => new Mock<IPersistenceManager>().Object)
                    .AsOrderManager(new Mock<IOrderNumberGenerator>().Object)
                    .Build();

            Assert.IsNotNull(ketchup.Orders);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestOrderManagerExpectsNumberGenerator()
        {
            KetchupBuilder.Configure(() => new Mock<IPersistenceManager>().Object).AsOrderManager(null);
        }
    }
}