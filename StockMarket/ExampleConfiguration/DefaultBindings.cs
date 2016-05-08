// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBindings.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The default bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.ExampleConfiguration
{
    using System;
    using System.Collections.Generic;
    using Ninject.Activation;
    using Ninject.Modules;
    using GBCE;
    using CoreTypes.Stock;
    using Repositories;

    /// <summary>
    /// The default bindings.
    /// </summary>
    public class DefaultBindings : NinjectModule
    {
        /// <summary>
        /// The load of bindings.
        /// </summary>
        public override void Load()
        {
            this.Bind<StockMarketService>().ToProvider(new StockMarketServiceProvider()).InSingletonScope();
        }
    }

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
                new InMemoryTradeHistory(),       // Could use an alternative ITradeHistory implementation. Perhaps backed by a database. 
                new Dictionary<string, Stock>()); // Used to initially seed the StockMarket with valid stock types.
        }

        /// <summary>
        /// The type of object
        /// </summary>
        public Type Type => typeof(StockMarketService);
    }
}
