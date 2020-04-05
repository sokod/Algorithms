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
            Quicksort(array,0,n-1);
            ShowArray(array);
            Console.ReadKey();
        }

        private static void Quicksort(int[] array,int l, int r)
        {
            if (l >= r) return;
            int k = new Random().Next(l, r);
            Swap(array, r, k);
            int m1 = k, m2 = k;
            Partition3(array, l, r, ref m1, ref m2);
            Quicksort(array, l, m1);
            Quicksort(array, m2 + 1, r);
        }

        private static void Partition3(int[] array, int l, int r, ref int m1, ref int m2)
        {
            if (r-l<=1)
            {
                if (array[r] < array[l])
                    Swap(array, r, l);
                m1 = l;
                m2 = r;
                return;
            }
            int mid = l;
            int pivot = array[r];
            while(mid<=r)
            {
                if (array[mid] < pivot)
                    Swap(array, l++, mid++);
                else if (array[mid] == pivot)
                    mid++;
                else Swap(array, mid, r--);
            }
            m1 = l - 1;
            m2 = r - 1;
                        
        }

        private static void Swap(int[] array, int l, int k)
        {
            int buffer = array[l];
            array[l] = array[k];
            array[k] = buffer;
        }

        static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
