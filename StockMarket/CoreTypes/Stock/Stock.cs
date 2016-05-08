// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stock.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the Stock type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.CoreTypes.Stock
{
    /// <summary>
    /// The stock.
    /// </summary>
    public abstract class Stock
    {
        /// <summary>
        /// The last dividend value
        /// </summary>
        private double lastDividend;

        /// <summary>
        /// The par value
        /// </summary>
        private double parValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class. 
        /// </summary>
        /// <param name="symbol">The stock symbol</param>
        /// <param name="lastDividend">The last dividend value</param>
        /// <param name="parValue">The par value</param>
        protected Stock(string symbol, double lastDividend, double parValue)
        {
            this.Symbol = symbol;
            this.lastDividend = lastDividend;
            this.parValue = parValue;
        }

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        public string Symbol { get; private set; }

        /// <summary>
        /// Gets the Stock Type
        /// </summary>
        public abstract string StockType { get; }

        /// <summary>
        /// Calculate the dividend yield for the stock 
        /// </summary>
        /// <param name="price">The price value that calculation is based upon</param>
        /// <returns>The calculated dividend yield</returns>
        public abstract double CalcDividendYield(double price);
    }
}
