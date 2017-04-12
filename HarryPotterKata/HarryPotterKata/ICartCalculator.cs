using System.Collections.Generic;

namespace HarryPotterKata
{
    public interface ICartCalculator
    {
        double Total(IDictionary<int, int> cart);
    }
}
