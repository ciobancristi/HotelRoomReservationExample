using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationApp;
using HotelReservationApp.Refractored;
using System.Collections.Generic;
using Moq;
using HotelReservationApp.Interfaces;
using HotelReservationApp.PriceRules;

namespace Hotel.Tests
{
    [TestClass]
    public class TvaPriceRuleTest
    {
        [TestMethod]
        public void CalculatePrice__StateUnderTest__ExprectedResults()
        {
        }

        [TestMethod]
        public void CalculatePrice__RoomPriceCoorectlySetup__ReturnedTvaValueIsCorrect()
        {
            // A - arrange
            IRoom room = new Room { Price = 50 };
            IPriceRule priceRule = new TVAPriceRule();

            // A - act
            decimal result = priceRule.CalculatePrice(room);
            
            // A - assert
            Assert.AreEqual(9.5m, result);
        }

        [TestMethod]
        public void CalculatePrice__PriceIsMaxValue__DoesNotThrow()
        {
            // A - arrange
            IRoom room = new Room { Price = decimal.MaxValue };
            IPriceRule priceRule = new TVAPriceRule();

            // A - act
            decimal result = priceRule.CalculatePrice(room);

            // A - assert
            Assert.AreEqual(decimal.MaxValue * 0.19m, result);
        }

        [TestMethod]
        public void CalculatePrice__RoomIsNull__ArgumentNullExceptionIsThrown()
        {
            // A - arrange
            IRoom room = null;
            IPriceRule priceRule = new TVAPriceRule();
            bool isException = false;

            // A - act
            try
            {
                decimal result = priceRule.CalculatePrice(room);
            }
            catch (ArgumentNullException)
            {
                isException = true;
            }
            
            // A - assert
            Assert.IsTrue(isException, "ArgumentNullException is not thrown for a null Room object");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculatePrice__RoomIsNull__ArgumentNullExceptionIsThrown2()
        {
            // A - arrange
            IRoom room = null;
            IPriceRule priceRule = new TVAPriceRule();
            bool isException = false;

            // A - act
            
            decimal result = priceRule.CalculatePrice(room);
            
            // A - assert            
        }
    }

    [TestClass]
    public class PriceCalculatorTest
    {
        [TestMethod]
        public void CalculatePrice__ForMultitpleRules__ReturnedPriceIsCorrect()
        {
            
            var rule1 = new Mock<IPriceRule>();            
            rule1.Setup(x => x.CalculatePrice(It.IsAny<IRoom>())).Returns(decimal.MaxValue);

            var rule2 = new Mock<IPriceRule>();
            rule2.Setup(x => x.CalculatePrice(It.IsAny<IRoom>())).Returns(15);

            var rules = new List<IPriceRule> { rule1.Object, rule2.Object };

            IPriceCalculator priceCalculator = new PriceCalculator(rules, null);
            IRoom room = new Room();

            var result = priceCalculator.CalculatePrice(room);

            rule1.Verify(x => x.CalculatePrice(It.IsAny<IRoom>()), Times.Once);
            rule2.Verify(x => x.CalculatePrice(It.IsAny<IRoom>()), Times.Once);
        }
    }

    public class Rule1Mock : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            return 10;
        }
    }

    public class Rule2Mock : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            return 15;
        }
    }
}
