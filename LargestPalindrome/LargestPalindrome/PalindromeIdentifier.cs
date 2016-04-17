using System;

namespace LargestPalindrome
{
    public class PalindromeIdentifier : IPalindromeIdentifier
    {
        private readonly IHighestMutiplierProvider _highestMutiplierProvider;
        private readonly IPalimdromeAssertion _palimdromeAssertion;

        public PalindromeIdentifier(IHighestMutiplierProvider highestMutiplierProvider, IPalimdromeAssertion palimdromeAssertion)
        {
            if (highestMutiplierProvider == null)
            {
                throw new ArgumentNullException("highestMutiplierProvider");
            }

            if (palimdromeAssertion == null)
            {
                throw new ArgumentNullException("palimdromeAssertion");
            }

            _highestMutiplierProvider = highestMutiplierProvider;
            _palimdromeAssertion = palimdromeAssertion;
        }

        public int IdentifyPalindrome(int amountOfDigits)
        {
            var highestMultiplier = _highestMutiplierProvider.HighestMultiplierByDigits(amountOfDigits);
            var lowestMultiplier = _highestMutiplierProvider.HighestMultiplierByDigits(amountOfDigits - 1) + 1;

            return HighestPalindrome(highestMultiplier, lowestMultiplier);
        }

        private int HighestPalindrome(int highestNumber,int lowestNumber)
        {
            var max = 0;
            var no1 = 0;
            var no2 = 0;
            for (var i = highestNumber; i > lowestNumber; i--)
            {
                for (var j = i; j > lowestNumber; j--)
                {
                    var mul = j * i;
                    if (_palimdromeAssertion.IsPalidrome(mul))
                    {
                        if ((i + j) > max)
                        {
                            max = i + j;
                            no1 = i; no2 = j;
                        }
                    }
                }
            }

            return (no1 * no2);
        }
    }
}
