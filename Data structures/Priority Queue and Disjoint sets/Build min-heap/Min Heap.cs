using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    struct Swap
    {
        public int previous { get; private set; }
        public int current { get; private set; }
        public Swap(int before, int after)
        {
            previous = before;
            current = after;
        }
    }
    class Program
    {
        public static List<Swap> swaps = new List<Swap>();
        static void Main(string[] args)
        {
            Console.ReadLine();
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            BuildHeap(inputs);
            Console.WriteLine(swaps.Count);
            foreach(Swap s in swaps)
            {
                Console.WriteLine(s.previous + " " + s.current);
            }
            Console.ReadKey();
        }
        static void SiftDown(int i, int[] arr)
        {
            int minIndex = i;
            int l = LeftChild(i);
            if (l < arr.Length && arr[l] < arr[minIndex])
                minIndex = l;
            int r = RightChild(i);
            if (r < arr.Length && arr[r] < arr[minIndex])
                minIndex = r;

            if (i != minIndex)
            {
                swaps.Add(new Swap(i, minIndex));
                int buffer = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = buffer;
                SiftDown(minIndex, arr);
            }
        }
        static void BuildHeap(int[] arr)
        {
            for (int i = ((arr.Length-1) / 2); i >= 0; i--)
            {
                SiftDown(i, arr);
            }
        }
        static int Parent(int i)
        {
            return ((i - 1) / 2);
        }
        static int LeftChild(int i)
        {
            return ((2 * i) + 1);
        }
        static int RightChild(int i)
        {
            return ((2 * i) + 2);
        }
    }
}
