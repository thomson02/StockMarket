﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITradeHistory.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The TradeRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.Repositories
{
    using System.Collections.Generic;

    using Thomson02.GBCE.CoreTypes.Trade;

    /// <summary>
    /// The TradeRepository interface.
    /// </summary>
    public interface ITradeHistory
    {
        /// <summary>
        /// The record trade.
        /// </summary>
        /// <param name="trade">The trade to record.</param>
        void RecordTrade(Trade trade);

        /// <summary>
        /// The get trades by stock symbol.
        /// </summary>
        /// <param name="stockSymbol">The stock symbol.</param>
        /// <returns>The <see cref="IEnumerable"/> of filtered trades.</returns>
        IEnumerable<Trade> GetTrades(string stockSymbol);

        /// <summary>
        /// The get all trades.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/> of all trades.</returns>
        IEnumerable<Trade> GetAllTrades();
    }
}
