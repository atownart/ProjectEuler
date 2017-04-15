using System.Collections.Generic;

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
                FindSetForBook(sets, cart[i], 0, true);
            }

            //iterate through each book in each set 
            //move it to the next set and get total
            var total = TotalForSets(sets);

            //total for each set
            for (var y = 0; y < sets.Count; y++)
            {
                for (var x = 0; x < sets[y].Count; x++)
                {
                    var book = sets[y][x];

                    if (FindSetForBook(sets, book, y + 1))
                    {
                        sets[y].RemoveAt(x);
                    }

                    var setsTotal = TotalForSets(sets);
                    total = setsTotal < total ? setsTotal : total;
                }
            }

            return total;
        }

        // split out
        private double TotalForSets(List<List<int>> sets)
        {
            var setTotal = 0d;
            foreach (var set in sets)
            {
                var origSetTotal = set.Count * FullPrice;
                setTotal += (origSetTotal) - (origSetTotal * _discountPerBook[set.Count - 1]);
            }
            return setTotal;
        }

        private bool FindSetForBook(List<List<int>> sets, int book, int startingSet = 0, bool allowNewSet = false)
        {
            for (var setCount = startingSet; setCount < sets.Count; setCount++)
            {
                var set = sets[setCount];

                if (!set.Contains(book))
                {
                    set.Add(book);
                    return true;
                }

                if (setCount + 1 == sets.Count && allowNewSet)
                {
                    sets.Add(new List<int>());
                }
            }
            return false;
        }
    }
}
