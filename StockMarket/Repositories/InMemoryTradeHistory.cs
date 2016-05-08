// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryTradeHistory.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The in memory trade repository.
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
        /// <summary>
        /// Delete trade history after specified minutes has past. 
        /// </summary>
        private readonly int timeframe;

        /// <summary>The trade history.</summary>
        private readonly List<Trade> history;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryTradeHistory"/> class.
        /// </summary>
        /// <param name="timeframe">Delete trade history after specified minutes has past.</param>
        public InMemoryTradeHistory(int timeframe = 5)
        {
            this.timeframe = timeframe;
            this.history = new List<Trade>();
        }

        /// <summary>
        /// The record trade.
        /// </summary>
        /// <param name="trade">The trade to record.</param>
        public void RecordTrade(Trade trade)
        {
            this.PurgeOldTrades();
            this.history.Add(trade);
        }

        /// <summary>
        /// The get trades by stock symbol.
        /// </summary>
        /// <param name="stockSymbol">The stock symbol.</param>
        /// <returns>The <see cref="IEnumerable"/> of filtered trades.</returns>
        public IEnumerable<Trade> GetTrades(string stockSymbol)
        {
            this.PurgeOldTrades();
            return this.history.Where(t => t.StockSymbol == stockSymbol);
        }

        /// <summary>
        /// The get all trades.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/> of all trades.</returns>
        public IEnumerable<Trade> GetAllTrades()
        {
            this.PurgeOldTrades();
            return this.history;
        } 

        /// <summary>
        /// Delete trades from history if occurred after a given period of time.
        /// Ensures that we don't use loads of memory!
        /// </summary>
        private void PurgeOldTrades()
        {
            var boundaryDate = DateTime.UtcNow.Subtract(new TimeSpan(0, this.timeframe, 0));
            this.history.RemoveAll(t => t.Timestamp < boundaryDate);
        }
    }
}
