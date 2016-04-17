using LargestPalindrome;
using NUnit.Framework;

namespace LargetsPalindrome.Tests
{
    [TestFixture]
    public class HighestMultiplierTests
    {
        [TestCase(3,999)]
        [TestCase(4,9999)]
        [TestCase(2,99)]
        public void HighestMultiplierByDigits_WithDigit_ReturnsHighestNumber(int amountOfDigits, int expectedNumber)
        {
            var highestMultiplierProvider = new HighestMultiplierProvider();

            var returnedNumber = highestMultiplierProvider.HighestMultiplierByDigits(amountOfDigits);

            Assert.That(returnedNumber, Is.EqualTo(expectedNumber));
        }
    }
}
