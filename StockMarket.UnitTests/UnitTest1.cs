// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Thomson02">
//   
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests
{
    using System;
    using System.Reflection;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ninject;

    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            // Configure Ninject
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());


        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
