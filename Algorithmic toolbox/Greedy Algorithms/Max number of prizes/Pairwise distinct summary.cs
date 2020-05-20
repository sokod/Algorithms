using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = MaxNumbers(n);
            Console.WriteLine(numbers.Count);
            foreach (int number in numbers)
                Console.Write(number + " ");
            Console.ReadKey();
        }

        private static List<int> MaxNumbers(int n)
        {
            List<int> numbers = new List<int>();
            // move to the middle, once we in the middle take the last number and exit
            for (int k = n,l=1;k>0;l++)
            {
                if (k<=2*l)
                {
                    numbers.Add(k);
                    k -= k;
                }
                else
                {
                    numbers.Add(l);
                    k -= l;
                }
            }
            return numbers;
        }
    }
}
