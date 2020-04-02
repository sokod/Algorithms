using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(inputs[i]);
            }
            Console.WriteLine(LargestNumber(numbers));
            Console.ReadKey();
        }
        public static string LargestNumber(int[] digits)
        {
            string answer="";
            for (int i = 0; i < digits.Length; i++)
            {
                int maxDigit = int.MinValue;
                int posOfMaxDigit = int.MinValue;
                for (int j = 0; j < digits.Length; j++)
                {
                    //if (digits[j] >= maxDigit)
                    if(IsGreaterOrEqual(digits[j],maxDigit))
                    {
                        maxDigit = digits[j];
                        posOfMaxDigit = j;
                    }
                }
                answer += maxDigit;
                digits[posOfMaxDigit] = int.MinValue;
            }
            return answer;
        }
        /*
        public static bool IsGreaterOrEqual(int digit, int maxDigit)
        {
            if (maxDigit == int.MinValue) return true;
            if (digit == int.MinValue) return false;

            char[] _digit = digit.ToString().ToCharArray();
            char[] _maxDigit = maxDigit.ToString().ToCharArray();

            int n = (_digit.Length >= _maxDigit.Length) ? _digit.Length : _maxDigit.Length;
            for (int i = 0,posMax=0,posDig; i < n; i++)
            {
                posMax = (i >= _maxDigit.Length)?  (_maxDigit.Length - 1) : i;
                posDig = (i >= _digit.Length) ? (_digit.Length - 1) : i;
                int _max = int.Parse(_maxDigit[posMax].ToString());
                int _min = int.Parse(_digit[posDig].ToString());
                if (_min > _max)
                    return true;
                else if (_min < _max)
                    return false;
            }
            if (_digit[_digit.Length - 1] =='0' && _maxDigit[_maxDigit.Length-1]=='0') 
                return (_digit.Length >= _maxDigit.Length) ? false : true;
            return (_digit.Length >= _maxDigit.Length) ? true : false;
        }
        */
        public static bool IsGreaterOrEqual(int digit, int maxDigit)
        {
            if (maxDigit == int.MinValue) return true;
            if (digit == int.MinValue) return false;

            string a = digit.ToString() + maxDigit.ToString();
            string b = maxDigit.ToString() + digit.ToString();
            int i = String.Compare(a, b);
            if (i <= 0) return false;
            else return true;
        }
    }
}
