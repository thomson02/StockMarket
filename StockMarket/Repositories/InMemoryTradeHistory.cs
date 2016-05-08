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
    using Thomson02.GBCE.CoreTypes.Trade;

    /// <summary>
    /// The in memory trade repository.
    /// </summary>
    public class InMemoryTradeHistory : ITradeHistory
    {
        /// <summary>
        /// Delete trade history after specified minutes has past. 
        /// </summary>
        private readonly int keepMinutes;

        /// <summary>The trade history.</summary>
        private readonly List<Trade> history;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryTradeHistory"/> class.
        /// </summary>
        /// <param name="keepMinutes">Delete trade history after specified minutes has past.</param>
        public InMemoryTradeHistory(int keepMinutes = 5)
        {
            this.keepMinutes = keepMinutes;
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
        /// Delete trades from history if occurred after a given period of time.
        /// Ensures that we don't use loads of memory!
        /// </summary>
        private void PurgeOldTrades()
        {
            var boundaryDate = DateTime.UtcNow.Subtract(new TimeSpan(0, this.keepMinutes, 0));
            this.history.RemoveAll(t => t.Timestamp < boundaryDate);
        }
    }
}
