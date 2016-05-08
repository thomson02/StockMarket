// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBindings.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The default bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE.Configuration
{
    using GBCE;
    using Ninject.Modules;
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
            this.Bind<ITradeHistory>().To<InMemoryTradeHistory>();
            this.Bind<StockMarketService>().ToProvider(new StockMarketServiceProvider()).InSingletonScope();
        }
    }
}
