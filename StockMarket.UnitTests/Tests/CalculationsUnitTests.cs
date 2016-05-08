// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalculationsUnitTests.cs" company="Thomson02">
//    Copyright © Thomson02. All rights reserved.
// </copyright>
// <summary>
//   Defines the StockMarketServiceUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StockMarket.UnitTests.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Thomson02.StockMarket;
    using Thomson02.StockMarket.CoreTypes.Stock;
    using Thomson02.StockMarket.CoreTypes.Trade;

    /// <summary>
    /// The stock market unit tests.
    /// </summary>
    [TestClass]
    public class CalculationsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void LastDividendYieldThrowsWhenPriceIsZero()
        {
            Calculations.LastDividendYield(5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void LastDividendYieldThrowsWhenPriceIsZeroAndDouble()
        {
            Calculations.LastDividendYield(5, 0.0);
        }

        [TestMethod]
        public void LastDividendYieldShouldReturnDoubleResultWhenParamsAreValid()
        {
            Assert.AreEqual(5, Calculations.LastDividendYield(5, 1), "Result should be 5/1 = 5");
            Assert.AreEqual(2.5, Calculations.LastDividendYield(5, 2), "Result should be 5/2 = 2.5");
            Assert.AreEqual(0, Calculations.LastDividendYield(0, -1), "Result should be 0/-1 = 0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void FixedDividendYieldThrowsWhenPriceIsZero()
        {
            Calculations.FixedDividendYield(5, 2, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void FixedDividendYieldThrowsWhenPriceIsZeroAndDouble()
        {
            Calculations.FixedDividendYield(5, 2, 0.0);
        }

        [TestMethod]
        public void FixedDividendYieldShouldReturnDoubleResultWhenParamsAreValid()
        {
            Assert.AreEqual(0.0, Calculations.FixedDividendYield(5, 0, 1), "Result should be (5*0)/1 = 0");
            Assert.AreEqual(5.0, Calculations.FixedDividendYield(5, 2, 2), "Result should be (5*2)/2 = 2");
            Assert.AreEqual(2.5, Calculations.FixedDividendYield(5, 1, 2), "Result should be (5*1)/2 = 2.5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void PERatioShouldThrowExceptionWhenDividendIsZero()
        {
            Calculations.PERatio(5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Division by zero inappropriately allowed.")]
        public void PERatioShouldThrowExceptionWhenDividendIsZeroAndDouble()
        {
            Calculations.PERatio(5, 0.0);
        }

        [TestMethod]
        public void PERatioShouldReturnDoubleResultWhenParamsAreValid()
        {
            Assert.AreEqual(5, Calculations.PERatio(5, 1), "Result should be 5/1 = 5");
            Assert.AreEqual(2.5, Calculations.PERatio(5, 2), "Result should be 5/2 = 2.5");
        }

        [TestMethod]
        public void VolumeWeightedStockPriceSingleTradeSumIsCorrect()
        {
            const double ManualCalculation = (5.0 * 1.0) / 1.0;

            var trades = new List<Trade>
                             {
                                 new Trade(new CommonStock("TEST", 5, 5), TradeType.Buy, 5, 1)
                             };

            Assert.AreEqual(ManualCalculation, Calculations.VolumeWeightedStockPrice(trades), $"Expected result should be {ManualCalculation}");
        }

        [TestMethod]
        public void VolumeWeightedStockPriceTwoTradesSumIsCorrect()
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
        public void GeometricMeanOfAEmptyListThrowsException()
        {
            var values = new List<double>();
            Calculations.GeometricMean(values);
        }

        [TestMethod]
        public void GeometricMeanOfAListWithOneValue()
        {
            var values = new List<double> { 2.0 };

            Assert.AreEqual(2, Calculations.GeometricMean(values), "Expected result should be 2");
        }

        [TestMethod]
        public void GeometricMeanOfAListWithTwoValues()
        {
            var values = new List<double> { 2.0, 4.5 };

            Assert.AreEqual(3, Calculations.GeometricMean(values), "Expected result should be 3");
        }

        [TestMethod]
        public void GeometricMeanOfAListWithThreeValues()
        {
            var values = new List<double> { 2.0, 4.0, 6.0 };

            Assert.AreEqual(3.63, Math.Round(Calculations.GeometricMean(values), 2), "Expected result should be 3.63");
        }
    }
}
