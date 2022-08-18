using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CardClasses
{
    public static class Extensions
    {
        private static Random random = new Random();

        public static List<T> Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T item = list[k];
                list[k] = list[n];
                list[n] = item;
            }

            return list;
        }

    }
}
