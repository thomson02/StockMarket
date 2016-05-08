// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stock.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the Stock type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.StockMarket.CoreTypes.Stock
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The stock type.
    /// </summary>
    public enum StockType
    {
        /// <summary>
        /// The common stock type.
        /// </summary>
        Common,

        /// <summary>
        /// The preferred stock type.
        /// </summary>
        Preferred
    }

    /// <summary>
    /// The stock.
    /// </summary>
    public abstract class Stock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class. 
        /// </summary>
        /// <param name="symbol">The stock symbol</param>
        /// <param name="lastDividend">The last dividend value</param>
        /// <param name="parValue">The par value</param>
        protected Stock(string symbol, double lastDividend, double parValue)
        {
            this.Symbol = symbol;
            this.LastDividend = lastDividend;
            this.ParValue = parValue;
        }

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        public string Symbol { get; private set; }

        /// <summary>
        /// Gets the Stock Type
        /// </summary>
        public abstract StockType StockType { get; }

        /// <summary>
        /// Gets the last dividend.
        /// </summary>
        protected double LastDividend { get; private set; }

        /// <summary>
        /// Gets the par value.
        /// </summary>
        protected double ParValue { get; private set; }

        /// <summary>
        /// Calculate the dividend yield for the stock 
        /// </summary>
        /// <param name="price">The price value that calculation is based upon</param>
        /// <returns>The calculated dividend yield</returns>
        public abstract double CalcDividendYield(double price);

        /// <summary>
        /// The calc P/E ratio.
        /// </summary>
        /// <param name="price">The price value that calculation is based upon.</param>
        /// <returns>The calculated P/E Ratio.</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public double CalcPERatio(double price)
        {
            return Calculations.PERatio(price, this.CalcDividendYield(price));
        }
    }
}
