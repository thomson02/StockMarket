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
    using System.Collections.Generic;

    using Ninject.Modules;

    using Thomson02.GBCE.CoreTypes.Stock;
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
            this.Bind<ITradeHistory>().To<InMemoryTradeHistory>();

            var emptyStockCatalogue = new Dictionary<string, Stock>();
            this.Bind<StockMarket>().ToSelf().InSingletonScope().WithConstructorArgument("stockCatalogue", emptyStockCatalogue);
        }
    }
}
