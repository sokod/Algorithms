using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide_Conquer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(inputs[0]);
            int[] sorted = new int[n];
            for (int i = 1; i < inputs.Length; i++)
            {
                sorted[i-1] = int.Parse(inputs[i]);
            }
            inputs = Console.ReadLine().Split(' ');
            for (int i = 1; i < inputs.Length; i++)
            {
                Console.Write(BinarySearch(sorted,int.Parse(inputs[i])) + " ");
            }
            Console.ReadKey();
        }

        static int BinarySearch(int[] sorted,int value)
        {
            int low = 0;
            int high = sorted.Length - 1;

            while (low<=high)
            {
                int mid = (high + low) / 2;
                if (value == sorted[mid])
                {
                    return mid;
                }
                else if (value < sorted[mid])
                {
                    high = mid - 1;
                }
                else low = mid + 1;
            }
            return -1;
        }

    }
}
