// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trade.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the Trade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.CoreTypes.Trade
{
    using System;
    using Stock;

    /// <summary>
    /// The trade.
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// The timestamp of the trade. 
        /// </summary>
        public readonly DateTime Timestamp;

        /// <summary>
        /// The type of the trade
        /// </summary>
        private readonly TradeType tradeType;

        /// <summary>
        /// The quantity.
        /// </summary>
        private readonly int quantity;

        /// <summary>
        /// The price.
        /// </summary>
        private readonly double price;

        /// <summary>
        /// The stock symbol.
        /// </summary>
        private readonly string stockSymbol;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        /// <param name="stock">The stock that is being traded.</param>
        /// <param name="tradeType">The trade type i.e. Buy or Sell</param>
        /// <param name="price">The price of stock being traded.</param>
        /// <param name="quantity">The quantity of stock being traded.</param>
        public Trade(Stock stock, TradeType tradeType, double price, int quantity)
        {
            this.stockSymbol = stock.Symbol;
            this.tradeType = tradeType;
            this.price = price;
            this.quantity = quantity;
            this.Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// Converts the <see cref="Trade"/> to a string.
        /// </summary>
        /// <returns>string representation of the <see cref="Trade"/></returns>
        public override string ToString()
        {
            return $"{this.Timestamp}   TRADE/{this.tradeType}    STOCK: {this.stockSymbol}   QTY: {this.quantity}    PRICE: {this.price}";
        }
    }

    /// <summary>
    /// The different types of trading.
    /// </summary>
    public enum TradeType
    {
        Buy,
        Sell
    }
}
