using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndText
{
    public static class StringManipulator
    {
        public static Char[] SortCharacters(string input)
        {
            Char[] arrayOfChars = input.ToCharArray();
            var listOfChars = new List<char>(arrayOfChars);
            listOfChars.Sort();
            listOfChars.CopyTo(arrayOfChars);
            return arrayOfChars;
        }

        /// <summary>
        /// The RemoveCharacter method removes a single character from the source string and returns the remainder
        /// </summary>
        /// <param name="source">Source string being operated upon</param>
        /// <param name="character">Character to remove</param>
        /// <returns></returns>
        public static string RemoveCharacter(string source, string character)
        {
            if (character.Length != 1)
            {
                return source;
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (source.Substring(i, 1) == character)
                {
                    string remainder = source.Substring(0, i) + source.Substring(i + 1, source.Length - 1 - i);
                    return remainder;
                }
            }
            return source;
        }
    }
}
