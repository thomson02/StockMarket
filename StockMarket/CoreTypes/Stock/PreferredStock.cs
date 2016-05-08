// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonStock.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the CommonStock type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.CoreTypes.Stock
{
    using System;

    public class PreferredStock : Stock
    {
        /// <summary>
        /// The fixed dividend value
        /// </summary>
        private readonly double fixedDividend;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonStock"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="lastDividend">The last dividend.</param>
        /// <param name="parValue">The par value.</param>
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
            if (Convert.ToInt32(price) == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }

            return Calculations.FixedDividendYield(this.fixedDividend, this.ParValue, price);
        }
    }
}
