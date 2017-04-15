using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        public double Total(int[] cart)
        {
            var sets = new List<List<int>>();
            sets.Add(new List<int>());
            //put into sets
            for (var i = 0; i < cart.Length; i++)
            {
                FindSetForBook(sets, cart[i]);
            }

            var total = 0d;
            //total for each set
            foreach (var set in sets)
            {
                var origSetTotal = set.Count * FullPrice;
                total += (origSetTotal) - (origSetTotal * _discountPerBook[set.Count - 1]);
            }

            return total;
        }

        private void FindSetForBook(List<List<int>> sets, int book)
        {
            for (var setCount = 0; setCount < sets.Count; setCount++)
            {
                var set = sets[setCount];

                if (!set.Contains(book))
                {
                    set.Add(book);
                    break;
                }
                sets.Add(new List<int>());
            }
        }
    }
}
