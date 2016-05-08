// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bindings.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   The default bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Thomson02.GBCE
{
    using Ninject.Modules;
    using Thomson02.GBCE.Logging;
    using Thomson02.GBCE.Repositories;

    /// <summary>
    /// The default bindings.
    /// </summary>
    public class Bindings : NinjectModule
    {
        /// <summary>
        /// The load of bindings.
        /// </summary>
        public override void Load()
        {
            this.Bind<ILogHelper>().To<ConsoleLogHelper>();
            this.Bind<ITradeRepository>().To<InMemoryTradeRepository>();

            this.Bind<StockMarket>().ToSelf().InSingletonScope();
        }
    }
}
