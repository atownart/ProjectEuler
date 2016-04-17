namespace LargestPalindrome
{
    public class HighestMultiplierProvider : IHighestMutiplierProvider
    {
        public int HighestMultiplierByDigits(int amountOfDigits)
        {
            var highestNumber = 1;
            for (var i = 0; i < amountOfDigits; i++)
            {
                highestNumber = highestNumber*10;
            }
            return highestNumber - 1;
        }
    }
}
