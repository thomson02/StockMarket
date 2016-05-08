// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryTradeHistory.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The in memory trade repository.
//   TODO: Need a way to purge old, irrelevant trades as this will continually eat up memory! 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Thomson02.GBCE.CoreTypes.Trade;

    /// <summary>
    /// The in memory trade repository.
    /// </summary>
    public class InMemoryTradeHistory : ITradeHistory
    {
        /// <summary>The trade history.</summary>
        private readonly List<Trade> history;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryTradeHistory"/> class.
        /// </summary>
        public InMemoryTradeHistory()
        {
            this.history = new List<Trade>();
        }

        /// <summary>
        /// The record trade.
        /// </summary>
        /// <param name="trade">The trade to record.</param>
        public void RecordTrade(Trade trade)
        {
            this.history.Add(trade);
        }

        /// <summary>
        /// The get trades by stock symbol.
        /// </summary>
        /// <param name="stockSymbol">The stock symbol.</param>
        /// <param name="dateTime">Get trades from specified time onwards</param>
        /// <returns>The <see cref="IEnumerable"/> of filtered trades.</returns>
        public IEnumerable<Trade> GetTrades(string stockSymbol, DateTime dateTime)
        {
            return this.history.Where(t => t.StockSymbol == stockSymbol && t.Timestamp >= dateTime);
        }

        /// <summary>
        /// The get trades by stock symbol.
        /// </summary>
        /// <param name="dateTime">Get trades from specified time onwards</param>
        /// <returns>The <see cref="IEnumerable"/> of filtered trades.</returns>
        public IEnumerable<Trade> GetTrades(DateTime dateTime)
        {
            return this.history.Where(t => t.Timestamp >= dateTime);
        }

        /// <summary>
        /// The get trades by stock symbol.
        /// </summary>
        /// <param name="stockSymbol">The stock symbol.</param>
        /// <returns>The <see cref="IEnumerable"/> of filtered trades.</returns>
        public IEnumerable<Trade> GetTrades(string stockSymbol)
        {
            return this.history.Where(t => t.StockSymbol == stockSymbol);
        }

        /// <summary>
        /// The get all trades.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/> of all trades.</returns>
        public IEnumerable<Trade> GetTrades()
        {
            return this.history;
        } 
    }
}
