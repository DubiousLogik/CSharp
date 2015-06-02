using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lists
{
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
