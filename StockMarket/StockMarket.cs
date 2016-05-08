// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockMarket.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarket type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE
{
    using System;
    using System.Collections.Generic;
    using Thomson02.GBCE.CoreTypes.Stock;
    using Thomson02.GBCE.CoreTypes.Trade;
    using Thomson02.GBCE.Logging;
    using Thomson02.GBCE.Repositories;

    /// <summary>
    /// The stock market.
    /// </summary>
    public sealed class StockMarket
    {
        /// <summary>
        /// The log helper.
        /// </summary>
        private readonly ILogHelper logHelper;

        /// <summary>
        /// The tradable stocks
        /// </summary>
        private readonly Dictionary<string, Stock> stockCatalogue;

        /// <summary>
        /// The trade repository.
        /// </summary>
        private ITradeHistory tradeHistory;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockMarket"/> class.
        /// </summary>
        /// <param name="logHelper">The log helper.</param>
        /// <param name="tradeHistory">The trade repository.</param>
        /// <param name="stockCatalogue">The permitted, tradable stocks</param>
        private StockMarket(ILogHelper logHelper, ITradeHistory tradeHistory, Dictionary<string, Stock> stockCatalogue)
        {
            this.logHelper = logHelper;
            this.tradeHistory = tradeHistory;
            this.stockCatalogue = stockCatalogue;
        }
        
        /// <summary>
        /// Calculate the all share index.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double CalcAllShareIndex()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the volume weighted stock price for the given
        /// stock symbol based on trades in the past 5 minutes.
        /// </summary>
        /// <param name="stockSymbol"></param>
        /// <returns>The stock price.</returns>
        public double CalcVolumeWeightedStockPrice(string stockSymbol)
        {
            throw new NotImplementedException();
        }

        public double CalcDividendYield(string stockSymbol, double price)
        {
            throw new NotImplementedException();
        }

        public double CalcPERatio(string stockSymbol, double price)
        {
            if (this.stockCatalogue.ContainsKey(stockSymbol))
            {
                return this.stockCatalogue[stockSymbol].CalcDividendYield(price);
            }

            this.logHelper.LogException($"{stockSymbol} is not a tradable stock.");
            return -1;
        }

        public void BuyStock(string stockSymbol, double price, int quantity)
        {
            var trade = new Trade(stock, TradeType.Buy, price, quantity);
        }

        public void SellStock(string stockSymbol, double price, int quantity)
        {
            //var trade = new Trade(stock, TradeType.Sell, price, quantity);
        }
    }
}
