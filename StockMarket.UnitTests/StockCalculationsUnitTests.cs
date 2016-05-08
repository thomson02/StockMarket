// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockCalculationsUnitTests.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarketUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using Thomson02.GBCE;
    using Thomson02.GBCE.CoreTypes.Stock;

    /// <summary>
    /// The stock market unit tests.
    /// </summary>
    [TestClass]
    public class StockCalculationsUnitTests
    {
        /// <summary>
        /// The sample stocks.
        /// </summary>
        private Dictionary<string, Stock> stockCatalogue;

        /// <summary>
        /// The setup of the unit tests.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.stockCatalogue = SampleData.Stocks();


        }

        [TestMethod]
        public void TestMethod1()
        {
            var commonStock = new CommonStock("TEA", 0, 100);

            // Invalids
            Assert.AreEqual(-1, commonStock.CalcDividendYield(-1), "-1 as invalid calculation");
            Assert.AreEqual(-1, commonStock.CalcDividendYield(0), "-1 as invalid calculation");

            Assert.AreEqual(0, commonStock.CalcDividendYield(1), "0/1 = 0");
            Assert.AreEqual(0, commonStock.CalcDividendYield(1), "0/1 = 0");


        }


    }
}
