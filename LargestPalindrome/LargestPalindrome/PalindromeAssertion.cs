using System;
using System.Linq;

namespace LargestPalindrome
{
    public class PalindromeAssertion : IPalimdromeAssertion
    {
        public bool IsPalidrome(int number)
        {
            var numberChars = number.ToString().ToCharArray();
            Array.Reverse(numberChars);
            var reversed = new string(numberChars);
            return number.ToString() == reversed;
        }
    }
}
