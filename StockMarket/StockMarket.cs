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
    using Thomson02.GBCE.CoreTypes.Stock;
    using Thomson02.GBCE.CoreTypes.Trade;
    using Thomson02.GBCE.Logging;
    using Thomson02.GBCE.Repositories;

    /// <summary>
    /// The stock market (singleton).
    /// </summary>
    public sealed class StockMarket
    {
        /// <summary>
        /// The log helper.
        /// </summary>
        private ILogHelper logHelper;

        /// <summary>
        /// The trade repository.
        /// </summary>
        private ITradeRepository tradeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockMarket"/> class.
        /// </summary>
        /// <param name="logHelper">The log helper.</param>
        /// <param name="tradeRepository">The trade repository.</param>
        private StockMarket(ILogHelper logHelper, ITradeRepository tradeRepository)
        {
            this.logHelper = logHelper;
            this.tradeRepository = tradeRepository;
        }

        public void BuyStock(Stock stock, double price, int quantity)
        {
            var trade = new Trade(stock, TradeType.Buy, price, quantity);
        }

        public void SellStock(Stock stock, double price, int quantity)
        {
            var trade = new Trade(stock, TradeType.Sell, price, quantity);
        }
    }
}
