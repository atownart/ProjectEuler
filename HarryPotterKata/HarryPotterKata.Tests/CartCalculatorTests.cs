using NUnit.Framework;
using System.Collections.Generic;

namespace HarryPotterKata.Tests
{
    [TestFixture]
    public class CartCalculatorTests
    {
        private readonly CartCalculator _classUnderTest;

        public CartCalculatorTests()
        {
            _classUnderTest = new CartCalculator();
        }

        [TestCase(1, 8d)]
        [TestCase(2, 15.2d)]
        [TestCase(3, 21.6d)]
        [TestCase(4, 25.6d)]
        [TestCase(5, 30d)]
        public void Total_1SetOfBooks_ExpectedDiscount(int amountDifferentBooks, double expectedTotal)
        {
            //Arrange 
            var cart = new int[amountDifferentBooks];
            for (var i = 0; i < amountDifferentBooks; i++)
            {
                cart[i] = i + 1;
            }

            //Act
            var result = _classUnderTest.Total(cart);

            //Assert
            Assert.AreEqual(expectedTotal, result, $"Expecting total of {expectedTotal.ToString()} but got {result.ToString()}");
        }

        [TestCase(new int[] { 1, 1, 2 }, 23.2d)]
        [TestCase(new int[] { 1, 1, 2, 2 }, 30.4d)]
        [TestCase(new int[] { 1, 1, 2, 3, 3, 4 }, 40.8d)]
        [TestCase(new int[] { 1, 2, 2, 3, 4, 5 }, 38d)]
        public void Total_MultipleSets_ExpectedDiscount(int[] cart, double expectedTotal)
        {
            //Act
            var result = _classUnderTest.Total(cart);

            //Assert
            Assert.AreEqual(expectedTotal, result, $"Expecting total with simple sets of {expectedTotal.ToString()} but got {result.ToString()}");
        }

        [TestCase(new int[] {1, 1, 2, 2, 3, 3, 4, 5}, 51.2d)]
        public void Total_EdgeCases_FindsCheapestTotal(int[] cart, double expectedTotal)
        {
            //Act
            var result = _classUnderTest.Total(cart);

            //Assert
            Assert.AreEqual(expectedTotal, result, $"Expecting total with edge case sets of {expectedTotal.ToString()} but got {result.ToString()}");
        }
    }
}
