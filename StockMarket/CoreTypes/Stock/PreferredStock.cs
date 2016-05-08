// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonStock.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the CommonStock type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.StockMarket.CoreTypes.Stock
{
    public class PreferredStock : Stock
    {
        /// <summary>
        /// The fixed dividend value
        /// </summary>
        private readonly double fixedDividend;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonStock"/> class.
        /// </summary>
        /// <param name="lastDividend">The symbol.</param>
        /// <param name="parValue">The last dividend.</param>
        /// <param name="fixedDividend">The par value.</param>
        /// <param name="fixedDividend">The fixed dividend value</param>
        public PreferredStock(string symbol, double lastDividend, double parValue, double fixedDividend)
            : base(symbol, lastDividend, parValue)
        {
            this.fixedDividend = fixedDividend;
        }

        /// <summary>
        /// Gets the Stock Type
        /// </summary>
        public override StockType StockType => StockType.Preferred;

        /// <summary>
        /// Calculate the dividend yield for the stock 
        /// </summary>
        /// <param name="price">The price value that calculation is based upon</param>
        /// <returns>The calculated dividend yield</returns>
        public override double CalcDividendYield(double price)
        {
            return Calculations.FixedDividendYield(this.fixedDividend, this.ParValue, price);
        }
    }
}
