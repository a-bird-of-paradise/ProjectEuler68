using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler68
{
    class Program
    {

        static bool IsMagic3Gon(int[] x)
        {
            bool answer = true;

            int sum = x[4 - 1] + x[3 - 1] + x[2 - 1];

            if (sum != x[1 - 1] + x[2 - 1] + x[6 - 1]) answer = false;
            if (sum != x[5 - 1] + x[1 - 1] + x[3 - 1]) answer = false;

            return answer;
        }

        static long Value3Gon(int[] x)
        {
            long answer = 0;
            answer += x[4-1]; answer *= 10;
            answer += x[3-1]; answer *= 10;
            answer += x[2-1]; answer *= 10;

            answer += x[6-1]; answer *= 10;
            answer += x[2-1]; answer *= 10;
            answer += x[1-1]; answer *= 10;

            answer += x[5-1]; answer *= 10;
            answer += x[1-1]; answer *= 10;
            answer += x[3-1];
            return answer;
        }

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

            bool KeepGoing = true, NextIsLast = false;

            long answer = -1;

            while (KeepGoing)
            {

                if (IsMagic3Gon(Perm) && Perm[3] < Perm[4] && Perm[3] < Perm[5])
                {
                    if (Value3Gon(Perm) > answer)
                    {
                        answer = Value3Gon(Perm);
                    }
                }

                if (!NextIsLast)
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

                    if (Perm.SequenceEqual(Final))
                        NextIsLast = true;
                }
                else
                {
                    KeepGoing = false;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
