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
            char[] inputs = Console.ReadLine().ToCharArray();
            Console.WriteLine(Equal(inputs));
            Console.ReadKey();
        }

        private static string Equal(char[] inputs)
        {
            char[] open = new char[] { '{', '[', '(' };
            char[] closes = new char[] { '}', ']', ')' };
            Stack<char> stack = new Stack<char>();
            Stack<int> enumerator = new Stack<int>();
            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < open.Length; j++)
                {
                    if (inputs[i] == open[j])
                    {
                        stack.Push(inputs[i]);
                        enumerator.Push(i + 1);
                        break;
                    }
                    if (inputs[i] == closes[j])
                    {
                        if (stack.Empty())
                            return (i+1).ToString();

                        char value = stack.Pop();

                        if (value != open[j])
                            return (i+1).ToString();
                        else enumerator.Pop();
                        break;
                    }
                    if (j == open.Length-1)
                    {
                        enumerator.Push(i + 1);
                    }
                }
            }
            if (stack.Empty())
                return "Success";
            else return enumerator.Pop().ToString();
        }
    }
}
