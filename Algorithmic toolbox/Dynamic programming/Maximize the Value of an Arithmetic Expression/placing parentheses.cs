using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            string operations = Console.ReadLine();
            Console.WriteLine(Parentheses(operations));
            Console.ReadKey();
        }

        public static long Parentheses(string expression)
        {
            char[] op = new char[] { '-', '+', '*' };
            char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            string[] numbers = expression.Split(op);
            string[] operations = expression.Split(digits);

            long[,] Min = new long[numbers.Length, numbers.Length];
            for (int i = 0; i < Min.GetLength(0); i++)
            {
                Min[i, i] = int.Parse(numbers[i]);
            }
            int j;
            for (int s = 0; s < numbers.Length; s++)
            {
                for (int i = 0; i < numbers.Length - s - 1; i++)
                {
                    j = i + s + 1;
                    long[] min_max = MinAndMax(i, j, Min, operations);
                    Min[i, j] = min_max[0];
                    Min[j, i] = min_max[1];
                }
            }
            return Min[numbers.Length - 1,0];
        }

        public static long[] MinAndMax(int i, int j, long[,] Min, string[] op)
        {
            long min = long.MaxValue;
            long max = long.MinValue;
            long a, b, c, d;
            for (int k = i; k <= j - 1; k++)
            {
                a = eval(Min[k,i], Min[j,k+1], op[k + 1]);
                b = eval(Min[k,i], Min[k + 1, j], op[k + 1]);
                c = eval(Min[i, k], Min[j,k+1], op[k + 1]);
                d = eval(Min[i, k], Min[k + 1, j], op[k + 1]);
                min = Math.Min(Math.Min(Math.Min(min, a), c), d);
                max = Math.Max(Math.Max(Math.Max(max, a), c), d);
            }
            return new long[] { min, max };
        }

        private static long eval(long a, long b, string op)
        {
            if (op == "+")
            {
                return a + b;
            }
            else if (op == "-")
            {
                return a - b;
            }
            else if (op == "*")
            {
                return a * b;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }
}
