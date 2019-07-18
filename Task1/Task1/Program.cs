using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static Dictionary<string, char> InputToRomanMap = new Dictionary<string, char>();
        static Dictionary<string, string> TestInput = new Dictionary<string, string>();
        static Dictionary<string, double> MetalValues = new Dictionary<string, double>();
        static Dictionary<string, int> TestOutputRoman = new Dictionary<string, int>();
        static Dictionary<string, double> TestOutputMetal = new Dictionary<string, double>();
        public static void Main(string[] args)
        {
            //Your code goes here
            //Console.WriteLine("Hello, world!");
            bool moreInput = true;
            Console.WriteLine("Please provide test input ( Input '0' to go to input queries)");
            while (moreInput)
            {
                //Console.WriteLine("Enter test input:");
                string input = Console.ReadLine();
                if(input.Equals("0"))
                {
                    moreInput = false;
                    continue;
                }
                string[] tokens = input.Split(' ');
                bool validinput = TestInputToDictionaryBuilder(tokens);
                if (!validinput)
                {
                    Console.WriteLine("This input is not valid, please provide proper input");
                }
            }
            moreInput = true;
            Console.WriteLine("Please provide test queries ( Input '0' to see results)");
            while (moreInput)
            {
                //Console.WriteLine("Enter test input:");
                string input = Console.ReadLine();
                if (input.Equals("0"))
                {
                    moreInput = false;
                    continue;
                }
                string[] tokens = input.Split(' ');
                bool validinput = TestQueriesToDictionaryBuilder(tokens);
                if (!validinput)
                {
                    Console.WriteLine("This input is not valid, please provide proper input");
                }
            }          
            foreach (KeyValuePair<string, int> entryForRomanNumbers in TestOutputRoman)
            {
                Console.WriteLine(entryForRomanNumbers.Key + " is " + entryForRomanNumbers.Value.ToString());
            }
            foreach (KeyValuePair<string, double> entryForMetals in TestOutputMetal)
            {
                if (entryForMetals.Key.Equals("Error in input"))
                {
                    Console.WriteLine("I have no idea what you are talking about");
                }
                else
                { 
                    Console.WriteLine(entryForMetals.Key + " is " + entryForMetals.Value.ToString() + " Credits");
                }
            }
            Console.ReadKey();
        }
        private static bool CheckFirstCharacterForCapital(string word)
        {
            try
            {
                if (word != null && word != string.Empty && word.Length >= 1)
                {
                    char firstCharacter = Convert.ToChar(word.Substring(0, 1));
                    int ASCIIValueOfFirstCharacter = (int)firstCharacter;
                    return (ASCIIValueOfFirstCharacter >= 65 && ASCIIValueOfFirstCharacter <= 90);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
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
        private static int RomanToInteger(string roman)
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
        private static bool TestInputToDictionaryBuilder(string[] inputTokens)
        {
            try
            {
                if (inputTokens.Length == 3)
                {
                    InputToRomanMap.Add(inputTokens[0], Convert.ToChar(inputTokens[2]));
                }
                else
                {
                    StringBuilder romanNumberTestInput = new StringBuilder();
                    int indexOfCapitallatter = -1;
                    for (int index = 0; index < inputTokens.Length; index++)
                    {
                        if(CheckFirstCharacterForCapital(inputTokens[index]))
                        {
                            indexOfCapitallatter = index;
                            break;
                        }
                        romanNumberTestInput.Append(inputTokens[index] + " ");
                    }
                    TestInput.Add(romanNumberTestInput.ToString(), inputTokens[indexOfCapitallatter]);
                    MetalValues.Add(inputTokens[indexOfCapitallatter], Convert.ToDouble(inputTokens[indexOfCapitallatter + 2]) / RomanToInteger(TestInputToRomanConvertor(romanNumberTestInput.ToString())));                    
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static string TestInputToRomanConvertor(string testInput)
        {
            StringBuilder romanNumber = new StringBuilder();
            if (!string.IsNullOrEmpty(testInput))
            {
                string[] tokens = testInput.Split(' ');
                foreach (string token in tokens)
                {
                    if(!string.IsNullOrEmpty(token))
                        romanNumber.Append(InputToRomanMap[token]);
                }
            }
            return romanNumber.ToString();
        }
        private static bool TestQueriesToDictionaryBuilder(string[] inputTokens)
        {
            try
            {
                StringBuilder romanQuantityAndMetal = new StringBuilder();
                switch (inputTokens[2])
                {
                    case "is":
                        for (int index = 3; index < inputTokens.Length; index++)
                        {
                            if (!inputTokens[index].Equals("?"))
                            {
                                romanQuantityAndMetal.Append(inputTokens[index] + " ");
                            }
                        }
                        TestOutputRoman.Add(romanQuantityAndMetal.ToString(), RomanToInteger(TestInputToRomanConvertor(romanQuantityAndMetal.ToString())));
                        break;
                    case "Credits":
                        int indexOfCapitallatter = -1;
                        for (int index = 4; index < inputTokens.Length; index++)
                        {
                            if (!inputTokens[index].Equals("?"))
                            {
                                if (CheckFirstCharacterForCapital(inputTokens[index]))
                                {
                                    indexOfCapitallatter = index;
                                    break;
                                }
                                romanQuantityAndMetal.Append(inputTokens[index] + " ");
                            }
                        }
                        int quantityOfMetal = RomanToInteger(TestInputToRomanConvertor(romanQuantityAndMetal.ToString()));
                        double valueofMetal = MetalValues[inputTokens[indexOfCapitallatter]];
                        romanQuantityAndMetal.Append(inputTokens[indexOfCapitallatter]);
                        TestOutputMetal.Add(romanQuantityAndMetal.ToString(), (valueofMetal * quantityOfMetal));
                        break;
                    default:
                        TestOutputMetal.Add("Error in input", 0);
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
