// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryTradeHistoryUnitTests.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarketServiceUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Data;
    using Thomson02.GBCE.CoreTypes.Stock;
    using Thomson02.GBCE.CoreTypes.Trade;
    using Thomson02.GBCE.Repositories;

    /// <summary>
    /// The In Memory Trade History Unit Tests
    /// </summary>
    [TestClass]
    public class InMemoryTradeHistoryUnitTests
    {
        /// <summary>
        /// The trade history.
        /// </summary>
        private InMemoryTradeHistory tradeHistory;

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
            this.tradeHistory = new InMemoryTradeHistory();
            this.stockCatalogue = SampleData.Stocks();
        }

        [TestMethod]
        public void CanRecordSingleTradeEvent()
        {
            var trade = new Trade(SampleData.Pop, TradeType.Buy, 50, 1);

            Assert.AreEqual(0, this.tradeHistory.GetTrades().Count(), "Trade History should be empty");
            this.tradeHistory.RecordTrade(trade);
            Assert.AreEqual(1, this.tradeHistory.GetTrades().Count(), "Trade History should have a single value");
        }
        
        [TestMethod]
        public void CanReturnAllTradeHistory()
        {
            Assert.AreEqual(0, this.tradeHistory.GetTrades().Count(), "Trade History should be empty");

            foreach (var trade in SampleData.Stocks().Select(stock => new Trade(stock.Value, TradeType.Buy, 50, 1)))
            {
                this.tradeHistory.RecordTrade(trade);
            }

            Assert.AreEqual(this.stockCatalogue.Count, this.tradeHistory.GetTrades().Count(), $"Trade History should contain {this.stockCatalogue.Count} elements");
        }

        [TestMethod]
        public void CanReturnAllTradeHistoryFromGivenPointInTime()
        {
            var startDateTime = DateTime.UtcNow;
            Assert.AreEqual(0, this.tradeHistory.GetTrades().Count(), "Trade History should be empty");

            var oldTrade = new Trade(SampleData.Tea, TradeType.Buy, 5, 2, DateTime.MinValue);
            this.tradeHistory.RecordTrade(oldTrade);

            var newTrade = new Trade(SampleData.Pop, TradeType.Buy, 10, 5, DateTime.UtcNow);
            this.tradeHistory.RecordTrade(newTrade);

            Assert.AreEqual(2, this.tradeHistory.GetTrades().Count(), "Trade History should be 2");
            Assert.AreEqual(1, this.tradeHistory.GetTrades(startDateTime).Count(), "Trade History should be 1");
            Assert.AreEqual(SampleData.Pop.Symbol, this.tradeHistory.GetTrades(startDateTime).First().StockSymbol, "Should be POP");

            Assert.AreEqual(0, this.tradeHistory.GetTrades(SampleData.Tea.Symbol, startDateTime).Count(), "Should not be able to find TEA");
            Assert.AreEqual(1, this.tradeHistory.GetTrades(SampleData.Pop.Symbol, startDateTime).Count(), "Should able to find Pop");
        }
    }
}
