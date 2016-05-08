// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockMarketUnitTests.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarketUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests
{
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using Thomson02.GBCE;

    /// <summary>
    /// The stock market unit tests.
    /// </summary>
    [TestClass]
    public class StockMarketUnitTests
    {
        /// <summary>
        /// The stock market.
        /// </summary>
        private StockMarket stockMarket;

        /// <summary>
        /// The setup of the unit tests.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Configure Ninject
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            // Configure the Stock Market to use GBCE Data
            kernel.Rebind<StockMarket>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("stockCatalogue", SampleData.Stocks());

            this.stockMarket = kernel.Get<StockMarket>();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
