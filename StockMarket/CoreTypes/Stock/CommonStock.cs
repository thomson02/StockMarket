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

    public class CommonStock : Stock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonStock"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="lastDividend">The last dividend.</param>
        /// <param name="parValue">The par value.</param>
        public CommonStock(string symbol, double lastDividend, double parValue)
            : base(symbol, lastDividend, parValue)
        {
        }

        /// <summary>
        /// Gets the Stock Type
        /// </summary>
        public override StockType StockType => StockType.Common;

        /// <summary>
        /// Calculate the dividend yield for the stock 
        /// </summary>
        /// <param name="price">The price value that calculation is based upon</param>
        /// <returns>The calculated dividend yield</returns>
        public override double CalcDividendYield(double price)
        {
           return Calculations.LastDividendYield(this.LastDividend, price);
        }
    }
}
