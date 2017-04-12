using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata
{
    public class CartCalculator : ICartCalculator
    {
        private readonly double[] _discountPerBook;

        private const double FullPrice = 8d;

        public CartCalculator()
        {
            _discountPerBook = new double[5];
            _discountPerBook[0] = 0;//1 book
            _discountPerBook[1] = 0.05d;//2 book
            _discountPerBook[2] = 0.1d;//3 book
            _discountPerBook[3] = 0.2d;
            _discountPerBook[4] = 0.25d;

        }

        public double Total(IDictionary<int, int> cart)
        {
            var total = 0d;
            var maxAmount = cart.Max(x => x.Value);

            for (var i = 1; i <= maxAmount; i++)
            {
                var setCount = cart.Count(book => i <= book.Value);
                total += (setCount*FullPrice) - ((setCount*FullPrice)*_discountPerBook[setCount-1]);
            }
            return total;
        }
    }
}
