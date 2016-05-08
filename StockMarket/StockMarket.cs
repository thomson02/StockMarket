// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockMarket.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarket type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE
{
    /// <summary>
    /// The stock market (singleton).
    /// </summary>
    public sealed class StockMarket
    {
        private StockMarket()
        {
            
        }

        public static StockMarket Instance { get; } = new StockMarket();
    }
}
