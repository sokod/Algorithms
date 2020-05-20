using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            EditDistance(first, second);
            Console.ReadKey();
        }

        private static void EditDistance(string first, string second)
        {
            char[] f = first.ToCharArray();
            char[] s = second.ToCharArray();
            int[,] dist = new int[f.Length+1,s.Length+1];
            //filling in header
            for (int i = 0; i < dist.GetLength(0); i++)
            {
                dist[i, 0] = i;
            }
            for (int j = 0; j < dist.GetLength(1); j++)
            {
                dist[0, j] = j;
            }

            for (int i = 1; i < dist.GetLength(0); i++)
            {
                for (int j = 1; j < dist.GetLength(1); j++)
                { 
                    if (f[i-1]==s[j-1])
                    {
                        //insertion,deletion,match
                        dist[i, j] = Min(dist[i, j - 1] + 1, dist[i - 1, j] + 1, dist[i - 1, j - 1]);
                    }
                    else
                    {
                        //insertion,deletion,mismatch
                        dist[i, j] = Min(dist[i, j - 1] + 1, dist[i - 1, j] + 1, dist[i - 1, j - 1] + 1);
                    }
                }
            }
            Console.WriteLine(dist[dist.GetLength(0) - 1, dist.GetLength(1) - 1]);
        }

        private static int Min(int v1, int v2, int v3)
        {
            return Math.Min(Math.Min(v1, v2), v3);
        }
    }
}
