// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Calculations.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The calculations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.StockMarket
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Thomson02.StockMarket.CoreTypes.Trade;

    /// <summary>
    /// The calculations.
    /// </summary>
    public static class Calculations
    {
        /// <summary>
        /// The last dividend yield.
        /// </summary>
        /// <param name="lastDividend">The last dividend.</param>
        /// <param name="price">The price.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double LastDividendYield(double lastDividend, double price)
        {
            if (Convert.ToInt32(price) == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }

            return lastDividend / price;
        }

        /// <summary>
        /// The fixed dividend yield.
        /// </summary>
        /// <param name="fixedDividend">The fixed dividend.</param>
        /// <param name="parValue">The par value.</param>
        /// <param name="price">The price.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double FixedDividendYield(double fixedDividend, double parValue, double price)
        {
            if (Convert.ToInt32(price) == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }

            return (fixedDividend * parValue) / price;
        }

        /// <summary>
        /// The pe ratio.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="dividend">The dividend.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public static double PERatio(double price, double dividend)
        {
            if (Convert.ToInt32(dividend) == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }

            return price / dividend;
        }

        /// <summary>
        /// The geometric mean.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double GeometricMean(IList<double> values)
        {
            if (!values.Any())
            {
                throw new ArgumentException("Non-zero root must be specified");
            }

            var total = values.Aggregate<double, double>(1, (x, y) => x * y);
            return Math.Pow(total, 1.0 / values.Count);
        }

        /// <summary>
        /// The volume weighted stock price.
        /// </summary>
        /// <param name="trades">The trades.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double VolumeWeightedStockPrice(IList<Trade> trades)
        {
            return trades.Sum(t => t.Price * t.Quantity) / trades.Sum(t => t.Quantity);
        }
    }
}
