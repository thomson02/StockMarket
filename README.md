# StockMarket

The core object model for the Global Beverage Corporation Exchange (GBCE).

Consists of two Visual Studio Projects:

 * StockMarket.csproj - the core object model.
 * StockMarket.UnitTests.csproj - used for testing the core object model.

Implementation Notes
--------------------
 * Calculations.cs is a Static Class which provides static functions to perform calculations. As a Static Class it is trivial to unit test these. 
 * An Abstract Class (Stock.cs) is used to implement shared functionality for the different stock types (Common & Preferred). This abstract class cannot be instantiated. 
 * Subclasses (CommonStock.cs & PreferredStock.cs) are used to extend the abstract class and to implement subclass specific concepts/functions.
 * Additional Stock types can be added easily by implementing the abstract class.
 * A Trade class (Trade.cs) is used to store data associated to a single trade made on the stock market. 
 * The InMemoryTradeHistory Class provides functionality to store a list of Trades that have been made on the stock market. It also provides functionality to retrieve recorded trades based on time and/or stock symbol. 
 * The InMemoryTradeHistory class implements the ITradeHistory Interface. 
 * StockMarketService.cs brings everything together. It provides functionality to buy & sell stock and to peform calculations.
 * The StockMarketService constructor requires an ITradeHistory object and a Dicitionary of Stock (keyed by stock symbol). The StockMarketService should be created as a singleton. DefaultBindings.cs provides example code on how to use Ninject to configure this and to inject relevant dependencies. For example ITradeHistory could be rebound to use 'SQLBackedTradeHistory' instead of InMemoryTradeHistory.
 * A StockMaretServiceProvider is used to seed the StockMarketService constructor with a stockCatalogue (valid stocks for the stock market). The default provider could be rebound, for example, so that the same StockMarketService code can be used for the 'Glasgow Crisp Corporation Exchange'.
 * The StockMarketService can throw ArgumentExceptions if invalid calculations are performed (such as dividing by zero). It is the responsibility of the calling code to catch these and to handle appropriately (e.g. logging). 

General Notes
-------------
* Written in C# .Net 4.6.1, using Visual Studio 2015 as IDE.
* Ninject Nuget package used to support dependency injection.
* StyleCop.MSBuild Nuget package used to enforce style standards.
* RhinoMocks Nuget package used to provide Mock/Stub functionality in Unit Tests.
