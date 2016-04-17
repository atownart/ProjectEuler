using LargestPalindrome;
using Moq;
using NUnit.Framework;

namespace LargetsPalindrome.Tests
{
    [TestFixture]
    public class PalindromeIdenitifierTests
    {
        [Test]
        public void IdentifyPalindrome_WithDigits_ReturnsPalindrome()
        {
            const int numberOfDigits = 3;
            var sut = new PalindromeIdentifier(new HighestMultiplierProvider(), new PalindromeAssertion());

            var returnedPalindrome = sut.IdentifyPalindrome(numberOfDigits);

            
        }
    }
}
