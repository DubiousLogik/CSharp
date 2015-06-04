using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAndHexWorkbook
{
    public static class HexConverter
    {
        public static bool TryParseToInt32(string input, out int output)
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
            bool isValidHexNumber = true;
            char[] digits = input.ToCharArray();

            for (int i=0; i<input.Length; i++)
            {
                if (((digits[i] >= '0') && (digits[i] <= '9')) || ((digits[i] >= 'A') && (digits[i] <= 'F')) || ((digits[i] >= 'a') && (digits[i] <= 'f')))
                {
                    //Ok
                }
                else
                {
                    isValidHexNumber = false;
                }
            }
            return isValidHexNumber;
        }

        static int ToInt32(string input)
        {
            int returnNumber = 0;
            int thisDigit = 0;
            int power = 0;
            int base16 = 16;

            char[] digits = input.ToCharArray();
            
            for (int i = input.Length - 1; i >= 0; i--)
            {
                //Parse using char distance approach
                char c = digits[i];
                if ((c >= '0') && (c <= '9'))
                {
                    thisDigit = c - '0';
                }
                if ((c >= 'A') && (c <= 'F'))
                {
                    thisDigit = c + 10 - 'A';
                }
                if ((c >= 'a') && (c <= 'f'))
                {
                    thisDigit = c + 10 - 'a';
                }
                double d = Math.Pow(Convert.ToDouble(base16), Convert.ToDouble(power));
                returnNumber += Convert.ToInt32(d) * thisDigit;                
                power++;
            }
            return returnNumber;
        }

    }
}
