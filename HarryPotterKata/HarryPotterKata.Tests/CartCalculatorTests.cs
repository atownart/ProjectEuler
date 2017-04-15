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
        public void Total_MultipleSets_ExpectedDiscount(int[] cart, double expectedTotal)
        {
            //Act
            var result = _classUnderTest.Total(cart);

            //Assert
            Assert.AreEqual(expectedTotal, result, $"Expecting total of {expectedTotal.ToString()} but got {result.ToString()}");
        }

        //[Test]
        //public void Total_3Books2Different_5PercentDiscounted()
        //{
        //    //Arrange
        //    var cart = new Dictionary<int, int>() { { 1, 2 }, { 2, 1 }};

        //    //Act 
        //    var result = _classUnderTest.Total(cart);

        //    //Assert
        //    Assert.AreEqual(23.2d, result);
        //}

        //[Test]
        //public void Total_4Books2Different_5PercentDiscounted()
        //{
        //    //Arrange
        //    var cart = new Dictionary<int, int>() { { 1, 2 }, { 2, 2 } };

        //    //Act 
        //    var result = _classUnderTest.Total(cart);

        //    //Assert
        //    Assert.AreEqual(30.4d, result);
        //}

        //[Test]
        //public void Total_5Books2Different_5PercentDiscounted()
        //{
        //    //Arrange
        //    var cart = new Dictionary<int, int>() { { 1, 2 }, { 2, 2 }, {3,1} };

        //    //Act 
        //    var result = _classUnderTest.Total(cart);

        //    //Assert
        //    Assert.AreEqual(36.8d, result);
        //}

        //[Test]
        //public void Total_8Books3Different_10PercentDiscounted()
        //{
        //    //Arrange
        //    var cart = new Dictionary<int, int>() { { 1, 2 }, {2,2}, {3,2}, {4,1}, {5,1} };

        //    //Act 
        //    var result = _classUnderTest.Total(cart);

        //    //Assert
        //    Assert.AreEqual(51.2d, result);
        //}
    }
}
