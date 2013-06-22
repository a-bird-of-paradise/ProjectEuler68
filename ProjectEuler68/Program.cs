using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler68
{
    class Program
    {
        static void Main(string[] args)
        {

            const int max = 6;

            int[] Initial = new int[max];
            int[] Final = new int[max];

            for (int i = 0; i < max; i++)
            {
                Initial[i] = i + 1;
                Final[max - i - 1] = i + 1;
            }

            int[] Perm = new int[max];
            for (int i = 0; i < max; i++) Perm[i] = Initial[i];

            int k = 0, l = 0, m = 0, Temp;

            long accum = 0, ToAdd = 0;

            while (!Perm.SequenceEqual(Final))
            {
                k = -1;
                for (m = 0; m < Initial.Length - 1; m++)
                    if (Perm[m] < Perm[m + 1])
                        k = m;
                l = -1;
                for (m = k; m < Initial.Length; m++)
                    if (Perm[k] < Perm[m])
                        l = m;
                Temp = Perm[k];
                Perm[k] = Perm[l];
                Perm[l] = Temp;
                Array.Reverse(Perm, k + 1, Initial.Length - (k + 1));
            }
        }
    }
}
