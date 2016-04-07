using LargestPalindrome;
using NUnit.Framework;

namespace LargetsPalindrome.Tests
{
    public class PalindromeAssertionTests
    {
        [TestCase(100001)]
        [TestCase(900009)]
        [TestCase(880088)]
        [TestCase(123321)]
        public void IsPalindrome_WithPalindromeNumber_AssertNumberIsPalinidrome(int numberUnderTest)
        {
            var palindromeAssertion = new PalindromeAssertion();

            var assertion = palindromeAssertion.IsPalidrome(numberUnderTest);

            Assert.That(assertion, Is.True);
        }

        [TestCase(100021)]
        [TestCase(660121)]
        [TestCase(100011)]
        [TestCase(120011)]
        public void IsPalindrome_WithNonPalindromeNumber_AssertNumberIsNotPalinidrome(int numberUnderTest)
        {
            var palindromeAssertion = new PalindromeAssertion();

            var assertion = palindromeAssertion.IsPalidrome(numberUnderTest);

            Assert.That(assertion, Is.False);
        }
    }
}
