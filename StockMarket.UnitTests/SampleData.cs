// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleData.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The sample data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests
{
    using System.Collections.Generic;
    using Thomson02.GBCE.CoreTypes.Stock;

    /// <summary>
    /// The sample data.
    /// </summary>
    public static class SampleData
    {
        /// <summary>
        /// The stocks.
        /// </summary>
        /// <returns>The <see cref="Dictionary"/>.</returns>
        public static Dictionary<string, Stock> Stocks()
        {
            return new Dictionary<string, Stock>
                       {
                           { "TEA", new CommonStock("TEA", 0, 100) },
                           { "POP", new CommonStock("POP", 8, 100) },
                           { "ALE", new CommonStock("ALE", 23, 60) },
                           { "GIN", new PreferredStock("GIN", 8, 100, 2) },
                           { "JOE", new CommonStock("JOE", 13, 250) },
                       };
        } 
    }
}
