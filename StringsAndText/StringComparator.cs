using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndText
{
    public static class StringComparator
    {
        /* ************************************************
         * StringComparator.cs
         * 
         * Purpose:  Implement logic to compare a candidate string versus a source string, to see if the candidate  
         *    is contained within the source, either directly or as a permutation.  
         *    
         * Goal:  Learn string comparison logic without using RegEx nor other high level libraries.
         *   
         * Design Choices:  Each method required a different comparison approach.  Contains was the most straight-
         *    forward, overlaying the candidate on top of substrings of the source.  PermutationExact does a sort
         *    and compare - note that I chose to compare each character rather than a higher level string
         *    comparison.  PermutationSubstring needs to 'consume' each matched character to ensure repeat
         *    occurrences of a character are handled.  While PermutationSubstring did reuse Contains, I did not 
         *    find as much code reuse across these methods as I initially thought I would.  I chose to implement 
         *    these as static methods since I'm encapsulating logic but no internal data members.
         *   
         * Author:  Robbie Devine, 03 Jun 2015  
         * ************************************************
        */

        /// <summary>
        /// PermutationExact checks if the candidate string is an exact permutation of the source string
        /// </summary>
        /// <param name="source">Source string being evaluated</param>
        /// <param name="candidate">Candidate exact permutation match string</param>
        /// <returns></returns>
        public static bool PermutationExact(string source, string candidate)
        {
            if (source.Length != candidate.Length)
            {
                return false;
            }

            Char[] sourceChars = SortCharacters(source);
            Char[] candidateChars = SortCharacters(candidate);

            for (int i = 0; i < source.Length; i++)
            {
                if (sourceChars[i] != candidateChars[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static Char[] SortCharacters(string input)
        {
            Char[] arrayOfChars = input.ToCharArray();
            var listOfChars = new List<char>(arrayOfChars);
            listOfChars.Sort();
            listOfChars.CopyTo(arrayOfChars);
            return arrayOfChars;
        }

        /// <summary>
        /// The Contains method checks if the source string contains the candidate string.  Comparison is case sensitive.  Empty string is considered a valid substring.
        /// </summary>
        /// <param name="source">Source string being evaluated</param>
        /// <param name="candidate">Candidate substring of source string</param>
        /// <returns></returns>
        public static bool Contains(string source, string candidate)
        {
            if (source.Length < candidate.Length)
            {
                return false;
            }
            
            int index = 0;

            while (index + candidate.Length <= source.Length) 
            {
                if (source.Substring(index, candidate.Length) == candidate)
                {
                    return true;
                }
                index++;
            } 
                
            return false;
        }

        /// <summary>
        /// PermutationSubstring checks if the candidate substring exists within the source string in any order.  Comparison is case sensitive.  Empty string is considered a valid substring.
        /// </summary>
        /// <param name="source">Source string being evaluated</param>
        /// <param name="candidate">Candidate substring</param>
        /// <returns></returns>
        public static bool PermutationSubstring(string source, string candidate)
        {
            if (source.Length < candidate.Length) 
            {
                return false;
            }

            Char[] candidateChars = candidate.ToCharArray();

            foreach (char c in candidateChars)
            {
                if (StringComparator.Contains(source, c.ToString()))
                {
                    StringComparator.RemoveCharacter(source, c.ToString());
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The RemoveCharacter method removes a single character from the source string and returns the remainder
        /// </summary>
        /// <param name="source">Source string being operated upon</param>
        /// <param name="character">Character to remove</param>
        /// <returns></returns>
        private static string RemoveCharacter(string source, string character) 
        {
            if (character.Length != 1)
            {
                return source;
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (source.Substring(i,1) == character)
                {
                    if (i == 0)
                    {
                        return source.Substring(i + 1, source.Length - 1);
                    }

                    if (i == source.Length - 1)
                    {
                        return source.Substring(i, 1);
                    }

                    return source.Substring(0, i) + source.Substring(i + 1, source.Length - 1 - i);
                } 
            }
            return source;
        }
    }
}
