//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="KetchupConfigurationTests.cs" company="James Dibble">
//     Copyright 2012 James Dibble
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Ketchup.UnitTests.Core
{
    using JamesDibble.ApplicationFramework.Data.Persistence;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class KetchupConfigurationTests
    {
        [TestMethod]
        public void TestBuilder()
        {
            var fakePersistence = new Mock<IPersistenceManager>().Object;

            var ketchup = KetchupBuilder.Configure().With(k => k.Persistence, fakePersistence).Build();

            Assert.IsNotNull(ketchup);
        }
    }
}