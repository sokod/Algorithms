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
                array[i]=int.Parse(inputs[i]);
            }
            Console.WriteLine(MergeSort(array));
            Console.ReadKey();
        }

        static int MergeSort(int[] a)
        {
            int[] temp = new int[a.Length];
            return MergeSort(a, temp, 0, a.Length - 1);
        }
        static int MergeSort(int[] a, int[] temp, int left, int right)
        {
            int mid;
            int inversions = 0;
            if (right>left)
            {
                mid = (right + left) / 2;
                inversions += MergeSort(a, temp, left, mid);
                inversions += MergeSort(a, temp, mid + 1, right);

                inversions += Merge(a, temp, left, mid + 1, right);
            }
            return inversions;
        }

        static int Merge(int[] a, int[] temp, int left, int mid, int right)
        {
            int i, j, k;
            int inversion = 0;
            i = left;
            j = mid;
            k = left;
            while((i<=mid-1)&& (j<=right))
            {
                if (a[i] <= a[j])
                    temp[k++] = a[i++];
                else
                {
                    temp[k++] = a[j++];
                    inversion += mid - i;
                }
            }
            while (i <= mid - 1)
                temp[k++] = a[i++];
            while (j <= right)
                temp[k++] = a[j++];


            for (int l = left; l <= right; l++)
            {
                a[l] = temp[l];
            }

            return inversion;
        }
    }
}
