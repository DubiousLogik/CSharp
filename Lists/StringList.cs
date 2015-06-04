using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lists
{
    /* ************************************************
     * StringList.cs
     * 
     * Purpose:  StringList implements a subset of the C# StringBuilder functionality, including Add and OutputToString
     * 
     * Goal:  Learn data structures behind StringBuilder, in this case an ArrayList.  Implement a basic ArrayList using  
     *   data structures such as Array, which is fixed in size and does not automatically grow as you need to add more
     *   elements beyond the array maximum size.  Add logic to handle growing the array size as necessary by detecting
     *   limit cases (double the size when full).
     *   
     * Design Choices:  At some point I needed to handle each character individually in order to get an array of single 
     *   digit values from which I'd concatenate the final output.  I chose to not pay this cost in the Add method, 
     *   since in my experience that is generally called lots of times as the string gets built. If I converted strings 
     *   to single digits up front (during Add) I'd have to call Double a lot more often, resulting in more copying of
     *   data from one array to its doubled replacement.  Instead I convert to a char array once on OutputToString.
     *   
     * Author:  Robbie Devine, 02 Jun 2015  
     * ************************************************
    */

    class StringList
    {
        private String[] _stringArray;
        private const int _initialSize = 4;
        private int _maxSize;
        private int _nextIndexValue;
        private int _countOfCharacters;

        public StringList()
        {
            _stringArray = new String[_initialSize];
            _maxSize = _initialSize;
            _nextIndexValue = 0;
            _countOfCharacters = 0;
        }

        public void Add(string value)
        {
            if (_nextIndexValue == _maxSize)
            {
                DoubleCurrentSize();
            }
            _stringArray[_nextIndexValue] = value;
            _nextIndexValue++;
            _countOfCharacters += value.Length;
        }

        private void DoubleCurrentSize()
        {
            String[] temp = new String[_maxSize * 2];

            for (int i = 0; i < _stringArray.Length; i++)
            {
                temp[i] = _stringArray[i];
            }

            _stringArray = temp;
            _maxSize *= 2;
        }

        public string OutputToString()
        {
            Char[] characters = new Char[_countOfCharacters];
            int index = 0;

            for (int i = 0; i <_nextIndexValue; i++)
            {
                char[] currentValue = _stringArray[i].ToCharArray();

                for (int j = 0; j < currentValue.Length; j++)
                {
                    characters[index] = currentValue[j];
                    index++;
                }
            }

            return new string(characters);
        }

        public int MaxSize
        {
            get { return _maxSize; }
        }

        public int NextIndexValue
        {
            get { return _nextIndexValue; }
        }

        public int CountOfCharacters
        {
            get { return _countOfCharacters; }
        }

    }
}
