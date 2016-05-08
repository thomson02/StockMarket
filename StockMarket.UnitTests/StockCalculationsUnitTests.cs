// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockCalculationsUnitTests.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarketServiceUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Thomson02.GBCE;
    using Thomson02.GBCE.CoreTypes.Stock;
    using Thomson02.GBCE.CoreTypes.Trade;

    /// <summary>
    /// The stock market unit tests.
    /// </summary>
    [TestClass]
    public class StockCalculationsUnitTests
    {
        /// <summary>
        /// The sample stocks.
        /// </summary>
        private Dictionary<string, Stock> stockCatalogue;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void LastDividendYield_throws_when_price_is_zero()
        {
            Calculations.LastDividendYield(5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void LastDividendYield_throws_when_price_is_zero_and_double()
        {
            Calculations.LastDividendYield(5, 0.0);
        }

        [TestMethod]
        public void LastDividendYield_should_return_double_result_when_params_are_valid()
        {
            Assert.AreEqual(5, Calculations.LastDividendYield(5, 1), "Result should be 5/1 = 5");
            Assert.AreEqual(2.5, Calculations.LastDividendYield(5, 2), "Result should be 5/2 = 2.5");
            Assert.AreEqual(0, Calculations.LastDividendYield(0, -1), "Result should be 0/-1 = 0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void FixedDividendYield_throws_when_price_is_zero()
        {
            Calculations.FixedDividendYield(5, 2, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void FixedDividendYield_throws_when_price_is_zero_and_double()
        {
            Calculations.FixedDividendYield(5, 2, 0.0);
        }

        [TestMethod]
        public void FixedDividendYield_should_return_double_result_when_params_are_valid()
        {
            Assert.AreEqual(0.0, Calculations.FixedDividendYield(5, 0, 1), "Result should be (5*0)/1 = 0");
            Assert.AreEqual(5.0, Calculations.FixedDividendYield(5, 2, 2), "Result should be (5*2)/2 = 2");
            Assert.AreEqual(2.5, Calculations.FixedDividendYield(5, 1, 2), "Result should be (5*1)/2 = 2.5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void PERatio_should_throw_exception_when_dividend_is_zero()
        {
            Calculations.PERatio(5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void PERatio_should_throw_exception_when_dividend_is_zero_and_double()
        {
            Calculations.PERatio(5, 0.0);
        }

        [TestMethod]
        public void PERatio_should_return_double_result_when_params_are_valid()
        {
            Assert.AreEqual(5, Calculations.PERatio(5, 1), "Result should be 5/1 = 5");
            Assert.AreEqual(2.5, Calculations.PERatio(5, 2), "Result should be 5/2 = 2.5");
        }

        [TestMethod]
        public void VolumeWeightedStockPrice_single_trade_sum_is_correct()
        {
            const double ManualCalculation = (5.0 * 1.0) / 1.0;

            var trades = new List<Trade>
                             {
                                 new Trade(new CommonStock("TEST", 5, 5), TradeType.Buy, 5, 1)
                             };

            Assert.AreEqual(ManualCalculation, Calculations.VolumeWeightedStockPrice(trades), $"Expected result should be {ManualCalculation}");
        }

        [TestMethod]
        public void VolumeWeightedStockPrice_two_trades_sum_is_correct()
        {
            const double ManualCalculation = ((5.0 * 1.0) + (7.0 * 2.0)) / (1.0 + 2.0);

            var trades = new List<Trade>
                             {
                                 new Trade(new CommonStock("TEST1", 5, 5), TradeType.Buy, 5, 1),
                                 new Trade(new CommonStock("TEST2", 10, 5), TradeType.Buy, 7, 2)
                             };

            Assert.AreEqual(ManualCalculation, Calculations.VolumeWeightedStockPrice(trades), $"Expected result should be {ManualCalculation}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "zero root inappropriately allowed.")]
        public void GeometricMean_of_a_empty_list_throws_exception()
        {
            var values = new List<double>();
            Calculations.GeometricMean(values);
        }

        [TestMethod]
        public void GeometricMean_of_a_list_with_one_value()
        {
            var values = new List<double> { 2.0 };

            Assert.AreEqual(2, Calculations.GeometricMean(values), "Expected result should be 2");
        }

        [TestMethod]
        public void GeometricMean_of_a_list_with_two_values()
        {
            var values = new List<double> { 2.0, 4.0 };

            Assert.AreEqual(2.82, Math.Round(Calculations.GeometricMean(values), 2), "Expected result should be 2.82");
        }


        [TestMethod]
        public void GeometricMean_of_a_list_with_three_values()
        {
            var values = new List<double> { 2.0, 4.0, 6.0 };

            Assert.AreEqual(3.63, Math.Round(Calculations.GeometricMean(values), 2), "Expected result should be 3.63");
        }
    }
}
