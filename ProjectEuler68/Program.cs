using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler68
{
    class Program
    {
        static bool IsMagic5Gon(int[] x)
        {
            int sum = x[0] + x[5] + x[6];

            if (sum != x[1] + x[6] + x[7]) return false;
            if (sum != x[2] + x[7] + x[8]) return false;
            if (sum != x[3] + x[8] + x[9]) return false;
            if (sum != x[4] + x[9] + x[5]) return false;

            return true;
        }
        
        static UInt64 Value5Gon(int[] x)
        {
            UInt64 answer = 0;

            int[] pattern = new int[15] { 0, 5, 6, 1, 6, 7, 2, 7, 8, 3, 8, 9, 4, 9, 5 };

            for (int i = 0; i < 15; i++)
            {
                if (x[pattern[i]] == 10)
                {
                    answer *= (UInt64)100;
                    answer += (UInt64)x[pattern[i]];
                }
                else
                {
                    answer *= (UInt64)10;
                    answer += (UInt64)x[pattern[i]];
                }
            }
            return answer;
        }              

        static void Main(string[] args)
        {

            System.Diagnostics.Stopwatch Timer = new System.Diagnostics.Stopwatch();
            Timer.Start();

            int[] Initial = new int[10];
            int[] Final = new int[10];

            int[] pattern = new int[15] { 0, 5, 6, 1, 6, 7, 2, 7, 8, 3, 8, 9, 4, 9, 5 };

            for (int i = 0; i < 10; i++)
            {
                Initial[i] = i + 1;
                Final[10 - i - 1] = i + 1;
            }

            int[] Perm = new int[10];
            for (int i = 0; i < 10; i++) Perm[i] = Initial[i];

            int k = 0, l = 0, m = 0, Temp;

            bool KeepGoing = true, NextIsLast = false;

            UInt64 answer = 0;

            while (KeepGoing)
            {
                if (Perm[0] >= 7) break;

                if (Perm.Take(5).Contains(10) == true && Perm.Take(5).Min() == Perm[0] && IsMagic5Gon(Perm))
                {
                    if (Value5Gon(Perm) > answer)
                        answer = Value5Gon(Perm);
                    foreach (int x in pattern) Console.Write(Perm[x] + " ");
                    Console.Write("\n");
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
                    KeepGoing = false;
            }
            Console.WriteLine(answer);
            Console.WriteLine(Timer.ElapsedMilliseconds);
        }
    }
}
