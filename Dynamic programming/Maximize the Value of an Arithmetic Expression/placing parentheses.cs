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
            char[] digits = new char[] { '0','1','2','3','4','5','6','7','8','9'};

            string[] numbers = expression.Split(op);
            string[] operations = expression.Split(digits);

            long[,] Min = new long[numbers.Length+1, numbers.Length+1];
            long[,] Max = new long[numbers.Length+1, numbers.Length+1];
            for (int i = 1; i < Min.GetLength(0); i++)
            {
                Min[i, i] = int.Parse(numbers[i-1]);
                Max[i, i] = int.Parse(numbers[i-1]);
            }
            int j;
            for (int s = 1; s < numbers.Length+1; s++)
            {
                for (int i = 1; i < numbers.Length+1-s; i++)
                {
                    j = i + s;
                    long[] min_max = MinAndMax(i, j, Min, Max, operations);
                    Min[i, j] = min_max[0];
                    Max[i, j] = min_max[1];
                }
            }
            return Max[1,numbers.Length];
            throw new NotImplementedException();
        }

        public static long[] MinAndMax(int i, int j, long[,] Min, long[,] Max, string[] op)
        {
            long min = long.MaxValue;
            long max = long.MinValue;
            long a, b, c, d;
            for (int k = i; k <= j-1; k++)
            {
                a = eval(Max[i, k], Max[k + 1, j], op[k]);
                b = eval(Max[i, k], Min[k + 1, j], op[k]);
                c = eval(Min[i, k], Max[k + 1, j], op[k]);
                d = eval(Min[i, k], Min[k + 1, j], op[k]);
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
