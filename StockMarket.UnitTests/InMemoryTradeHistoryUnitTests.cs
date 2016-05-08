// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryTradeHistoryUnitTests.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarketServiceUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        /// <summary>
        /// The can_ record_ single_ trade_ event.
        /// </summary>
        [TestMethod]
        public void Can_Record_Single_Trade_Event()
        {
            var stock = this.stockCatalogue.FirstOrDefault();
            var trade = new Trade(stock.Value, TradeType.Buy, 50, 1);

            Assert.AreEqual(0, this.tradeHistory.GetAllTrades().Count(), "Trade History should be empty");
            this.tradeHistory.RecordTrade(trade);
            Assert.AreEqual(1, this.tradeHistory.GetAllTrades().Count(), "Trade History should have a single value");
        }

        /// <summary>
        /// The can_ purge_ old_ trades.
        /// </summary>
        [TestMethod]
        public void Can_Purge_Old_Trades()
        {
            var stock = this.stockCatalogue.FirstOrDefault();

            Assert.AreEqual(0, this.tradeHistory.GetAllTrades().Count(), "Trade History should be empty");

            var oldTrade = new Trade(stock.Value, TradeType.Buy, 50, 1, DateTime.UtcNow.Subtract(new TimeSpan(0, 6, 0)));
            this.tradeHistory.RecordTrade(oldTrade);

            Assert.AreEqual(1, this.tradeHistory.GetAllTrades().Count(), "Trade History should have a single value");

            var newTrade = new Trade(stock.Value, TradeType.Sell, 100, 2);
            this.tradeHistory.RecordTrade(newTrade);

            Assert.AreEqual(
                1,
                this.tradeHistory.GetAllTrades().Count(),
                "Trade History should still have a single value");
        }

        [TestMethod]
        public void Can_Return_All_Trade_History()
        {
            Assert.AreEqual(0, this.tradeHistory.GetAllTrades().Count(), "Trade History should be empty");

            foreach (var trade in this.stockCatalogue.Select(stock => new Trade(stock.Value, TradeType.Buy, 50, 1)))
            {
                this.tradeHistory.RecordTrade(trade);
            }

            Assert.AreEqual(this.stockCatalogue.Count, this.tradeHistory.GetAllTrades().Count(), $"Trade History should contain {this.stockCatalogue.Count} elements");
        }
    }
}
