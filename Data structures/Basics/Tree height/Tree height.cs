using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(ComputeHeight(inputs));
            Console.ReadKey();
        }

        private static int ComputeHeight(int[] inputs)
        {
            int[] depth = new int[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                depth[i] = 0;
            }
            for (int i = 0; i < inputs.Length; i++)
            {
                ComputeDepth(inputs, i, depth);
            }
            return depth.Max();
        }

        private static void ComputeDepth(int[] inputs, int i, int[] depth)
        {
            if (depth[i] != 0)
                return;
            if (inputs[i] == -1)
            {
                depth[i] = 1;
                return;
            }
            if (depth[inputs[i]]==0)
            {
                ComputeDepth(inputs, inputs[i], depth);
            }
            depth[i] = depth[inputs[i]]+1;
        }
    }
}
