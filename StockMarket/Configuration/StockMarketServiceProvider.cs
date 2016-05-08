// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockMarketServiceProvider.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarketService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.Configuration
{
    using System;
    using System.Collections.Generic;
    using Ninject;
    using Ninject.Activation;
    using Thomson02.GBCE;
    using Thomson02.GBCE.CoreTypes.Stock;
    using Thomson02.GBCE.Repositories;

    /// <summary>
    /// The stock market service provider
    /// </summary>
    public class StockMarketServiceProvider : IProvider<StockMarketService>
    {
        /// <summary>
        /// Get an instance of the stock market service
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The <see cref="StockMarketService"/></returns>
        public object Create(IContext context)
        {
            return new StockMarketService(
                context.Kernel.Get<ITradeHistory>(),
                new Dictionary<string, Stock>());
        }

        /// <summary>
        /// The type of object
        /// </summary>
        public Type Type => typeof(StockMarketService);
    }
}
