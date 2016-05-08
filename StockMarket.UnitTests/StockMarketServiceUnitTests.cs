// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockMarketServiceUnitTests.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarketServiceUnitTests type.
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
    public class StockMarketServiceUnitTests
    {
        /// <summary>
        /// The stock market.
        /// </summary>
        private StockMarketService stockMarketService;

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
            kernel.Rebind<StockMarketService>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("stockCatalogue", SampleData.Stocks());

            this.stockMarketService = kernel.Get<StockMarketService>();
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
