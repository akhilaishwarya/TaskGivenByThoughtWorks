using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class RomanNumberComputation : IRomanNumberComputation
    {
        private static RomanNumberComputation obj = null;
        private RomanNumberComputation()
        { }
        public static RomanNumberComputation CreateObject()
        {
            if (obj == null)
            {
                obj = new RomanNumberComputation();
            }
            return obj;
        }
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        public int RomanToInteger(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                {
                    number -= RomanMap[roman[i]];
                }
                else
                {
                    number += RomanMap[roman[i]];
                }
            }
            return number;
        }

        public string TestInputToRomanConvertor(string testInput, Dictionary<string, char> InputToRomanMap)
        {
            StringBuilder romanNumber = new StringBuilder();
            if (!string.IsNullOrEmpty(testInput))
            {
                string[] tokens = testInput.Split(' ');
                foreach (string token in tokens)
                {
                    if (!string.IsNullOrEmpty(token))
                        romanNumber.Append(InputToRomanMap[token]);
                }
            }
            return romanNumber.ToString();
        }
    }
}
