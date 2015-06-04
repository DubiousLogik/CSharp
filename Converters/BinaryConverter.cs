using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAndHexWorkbook
{
    public static class BinaryConverter
    {
        public static bool TryParseStringToInt32(string input, out int output)
        {
            if (Validate(input))
            {
                output = ToInt32(input);
                return true;
            }
            else
            {
                output = -1;
                return false;
            }
        }

        static bool Validate(string input)
        {
            bool isValidInput = true;
            char[] digits = input.ToCharArray();

            for (int i = 0; i < digits.Length; i++)
            {
                if ((digits[i] >= '0') && (digits[i] <= '1'))
                {
                    //Ok
                }
                else
                {
                    isValidInput = false;
                }

            }

            return isValidInput;
        }

        static int ToInt32(string input)
        {
            int output = 0;
            char[] digits = input.ToCharArray();
            int power = 0;
            int base2 = 2;

            for (int i = digits.Length-1; i >=0 ; i--)
            {
                int thisDigit = digits[i] - '0';
                double d = Math.Pow(Convert.ToDouble(base2), Convert.ToDouble(power));
                output += Convert.ToInt32(d) * thisDigit;
                power++;
            }
            return output;
        }
    }
}
