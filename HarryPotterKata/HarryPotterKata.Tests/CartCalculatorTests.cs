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

        [TestCase(1,8d)]
        [TestCase(2, 15.2d)]
        [TestCase(3, 21.6d)]
        [TestCase(4, 25.6d)]
        [TestCase(5, 30d)]
        public void Total_AmountOfDifferentBooks_ExpectedDiscount(int amountDifferentBooks, double expectedTotal)
        {
            //Arrange 
            var cart = new Dictionary<int,int>();
            for (var i = 0; i < amountDifferentBooks; i++)
            {
                cart.Add(i +1,1);
            }

            //Act
            var result = _classUnderTest.Total(cart);

            //Assert
            Assert.AreEqual(expectedTotal,result,$"Expecting total of {expectedTotal.ToString()} but got {result.ToString()}");
        }
    }
}
