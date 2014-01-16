// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.UnitTests.Core
{
    using System;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class KetchupTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestNullCustomerManager()
        {
            var ketchup = KetchupBuilder.Configure(() => new Mock<IPersistenceManager>().Object).Build();

            var actual = ketchup.Customers;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestNullProductManager()
        {
            var ketchup = KetchupBuilder.Configure(() => new Mock<IPersistenceManager>().Object).Build();

            var actual = ketchup.Products;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestNullOrderManager()
        {
            var ketchup = KetchupBuilder.Configure(() => new Mock<IPersistenceManager>().Object).Build();

            var actual = ketchup.Orders;
        }
    }
}