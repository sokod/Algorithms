using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            int[] b = new int[n];
            string[] inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(inputs[i]);
            }
            inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                b[i] = int.Parse(inputs[i]);
            }
            Console.WriteLine(maxDotProduct(a, b));
            Console.ReadKey();
        }

        private static long maxDotProduct(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            long result = 0;
            for (int i = a.Length-1; i >= 0; i--)
            {
                result += a[i] * (long)b[i];
            }
            return result;
        }
    }
}
