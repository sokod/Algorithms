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
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            string[] inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < inputs.Length; i++)
            {
                array[i] = int.Parse(inputs[i]);
            }
            Console.WriteLine(GetMajority(array)>=0?1:0);
            Console.ReadKey();
        }
        
        static int GetMajority(int[] array)
        {
            if (array.Length == 1) return array[0];
            int mid = array.Length / 2;
            int[] firstHalf = new int[mid];
            int[] secondHalf = new int[array.Length-mid];
            Array.Copy(array, 0, firstHalf, 0, firstHalf.Length);
            Array.Copy(array,mid,secondHalf,0,secondHalf.Length);

            int a = GetMajority(firstHalf);
            int b = GetMajority(secondHalf);
            
            if (a!=-1)
            {
                int count=0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (a == array[i]) count++;
                }
                if (count > array.Length / 2) return a;
            }

            if (b != -1)
            {
                int count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (b == array[i]) count++;
                }
                if (count > array.Length / 2) return b;
            }

            return -1;
        }

    }
}
