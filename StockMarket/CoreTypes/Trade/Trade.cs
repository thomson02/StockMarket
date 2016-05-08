// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trade.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the Trade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.StockMarket.CoreTypes.Trade
{
    using System;

    using Stock;

    /// <summary>
    /// The different types of trading.
    /// </summary>
    public enum TradeType
    {
        /// <summary>
        /// The buy trade type.
        /// </summary>
        Buy,

        /// <summary>
        /// The sell trade type.
        /// </summary>
        Sell
    }

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
        /// The stock symbol.
        /// </summary>
        public readonly string StockSymbol;

        /// <summary>
        /// The type of the trade
        /// </summary>
        private readonly TradeType tradeType;

        /// <summary>
        /// The quantity.
        /// </summary>
        public readonly int Quantity;

        /// <summary>
        /// The price.
        /// </summary>
        public readonly double Price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        /// <param name="stock">The stock that is being traded.</param>
        /// <param name="tradeType">The trade type i.e. Buy or Sell</param>
        /// <param name="price">The price of stock being traded.</param>
        /// <param name="quantity">The quantity of stock being traded.</param>
        public Trade(Stock stock, TradeType tradeType, double price, int quantity)
            : this(stock, tradeType, price, quantity, DateTime.UtcNow)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// For UnitTest use only
        /// </summary>
        /// <param name="stock">The stock that is being traded.</param>
        /// <param name="tradeType">The trade type i.e. Buy or Sell</param>
        /// <param name="price">The price of stock being traded.</param>
        /// <param name="quantity">The quantity of stock being traded.</param>
        /// <param name="timestamp">The timestamp of the trade event.</param>
        public Trade(Stock stock, TradeType tradeType, double price, int quantity, DateTime timestamp)
        {
            this.StockSymbol = stock.Symbol;
            this.tradeType = tradeType;
            this.Price = price;
            this.Quantity = quantity;
            this.Timestamp = timestamp;
        }

        /// <summary>
        /// Converts the <see cref="Trade"/> to a string.
        /// </summary>
        /// <returns>string representation of the <see cref="Trade"/></returns>
        public override string ToString()
        {
            return $"{this.Timestamp}   TRADE/{this.tradeType}    STOCK: {this.StockSymbol}   QTY: {this.Quantity}    PRICE: {this.Price}";
        }
    }
}
