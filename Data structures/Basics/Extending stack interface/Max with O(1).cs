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
            int queries = int.Parse(Console.ReadLine());
            Stack stack = new Stack();
            string[] inputs = new string[queries];
            for (int i = 0; i < queries; i++)
            {
                inputs[i] = Console.ReadLine();
            }
            foreach (string input in inputs)
            {
                if (input.Length>3)
                {
                    stack.Push(int.Parse(input.Substring(4)));
                }
                else
                {
                    if (input == "max")
                        Console.WriteLine(stack.Max());
                    else if (input == "pop")
                        stack.Pop();
                }
            }
            Console.ReadKey();
        }
    }
}
