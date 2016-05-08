// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleData.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The sample data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests.Data
{
    using System.Collections.Generic;

    using Thomson02.StockMarket.CoreTypes.Stock;

    /// <summary>
    /// The sample data.
    /// </summary>
    public static class SampleData
    {
        /// <summary>
        /// The Tea.
        /// </summary>
        public static Stock Tea => new CommonStock("TEA", 0, 100);

        /// <summary>
        /// The Pop.
        /// </summary>
        public static Stock Pop => new CommonStock("POP", 8, 100);

        /// <summary>
        /// The Ale.
        /// </summary>
        public static Stock Ale => new CommonStock("ALE", 23, 60);

        /// <summary>
        /// The Gin.
        /// </summary>
        public static Stock Gin => new PreferredStock("GIN", 8, 100, 2);

        /// <summary>
        /// The Joe.
        /// </summary>
        public static Stock Joe => new CommonStock("JOE", 13, 250);

        /// <summary>
        /// The stocks.
        /// </summary>
        /// <returns>The <see cref="Dictionary"/>.</returns>
        public static Dictionary<string, Stock> Stocks()
        {
            return new Dictionary<string, Stock>
                       {
                           { Tea.Symbol, Tea },
                           { Pop.Symbol, Pop },
                           { Ale.Symbol, Ale },
                           { Gin.Symbol, Gin },
                           { Joe.Symbol, Joe },
                       };
        }
    }
}
