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
            int n = int.Parse(Console.ReadLine());
            PrimitiveCalculator(n);
            Console.ReadKey();
        }
        static void PrimitiveCalculator(int n)
        {
            int[] minOperations = new int[n + 1];
            minOperations[0] = 0;
            string path = "";
            for (int i = 1; i < minOperations.Length; i++)
            {
                minOperations[i] = int.MaxValue;
                for (int j = 1; j <= 3; j++)
                {
                    if (minOperations[i] > minOperations[i - 1] + 1)
                        minOperations[i] = minOperations[i - 1] + 1;
                    if (i % 2 == 0 && minOperations[i] > minOperations[i / 2] + 1)
                        minOperations[i] = minOperations[i / 2] + 1;
                    if (i % 3 == 0 && minOperations[i] > minOperations[i / 3] + 1)
                        minOperations[i] = minOperations[i / 3] + 1;
                }
            }
            OptimalSequence(minOperations);
            Console.ReadKey();
        }

        private static void OptimalSequence(int[] minOperations)
        {
            int i = minOperations.Length-1;
            int optional = minOperations[i];
            string[] path = new string[optional];
            path[optional-1] = i.ToString();
            Console.WriteLine(optional-1);

            while (i>1)
            {
                if (minOperations[i - 1] == optional - 1)
                {
                    i--;
                    path[--optional-1] = i.ToString();
                }
                else if (i % 2 == 0 && minOperations[i / 2] == optional - 1)
                {
                    i /= 2;
                    path[--optional-1] = i.ToString();
                }
                else if (i % 3 == 0 && minOperations[i / 3] == optional - 1)
                {
                    i /= 3;
                    path[--optional-1] = i.ToString();
                }
            }

            for (int j = 0; j < path.Length; j++)
            {
                Console.Write(path[j] + " ");
            }
        }
    }
}
