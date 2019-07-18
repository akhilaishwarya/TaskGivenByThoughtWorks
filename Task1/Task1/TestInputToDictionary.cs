using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class TestInputToDictionary : ITestInputToDictionaryBuilder
    {
        private Dictionary<string, char> InputToRomanMap = new Dictionary<string, char>();
        private Dictionary<string, string> TestInput = new Dictionary<string, string>();
        private Dictionary<string, double> MetalValues = new Dictionary<string, double>();
        public Dictionary<string, int> TestOutputRoman = new Dictionary<string, int>();
        public Dictionary<string, double> TestOutputMetal = new Dictionary<string, double>();
        private static TestInputToDictionary obj = null;
        private TestInputToDictionary()
        {
        }
        public static TestInputToDictionary CreateObject()
        {
            if (obj == null)
            {
                obj = new TestInputToDictionary();
            }
            return obj;
        }
        public bool TestInputToDictionaryBuilder(string[] inputTokens)
        {
            IStringOperations stringOperation = StringOperations.CreateObject();
            IRomanNumberComputation romanNumberComputation = RomanNumberComputation.CreateObject();
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
                        if (stringOperation.CheckFirstCharacterForCapital(inputTokens[index]))
                        {
                            indexOfCapitallatter = index;
                            break;
                        }
                        romanNumberTestInput.Append(inputTokens[index] + " ");
                    }
                    TestInput.Add(romanNumberTestInput.ToString(), inputTokens[indexOfCapitallatter]);
                    MetalValues.Add(inputTokens[indexOfCapitallatter], Convert.ToDouble(inputTokens[indexOfCapitallatter + 2]) / romanNumberComputation.RomanToInteger(romanNumberComputation.TestInputToRomanConvertor(romanNumberTestInput.ToString(), InputToRomanMap)));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TestQueriesToDictionaryBuilder(string[] inputTokens)
        {
            IStringOperations stringOperation = StringOperations.CreateObject();
            IRomanNumberComputation romanNumberComputation = RomanNumberComputation.CreateObject();
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
                        TestOutputRoman.Add(romanQuantityAndMetal.ToString(), romanNumberComputation.RomanToInteger(romanNumberComputation.TestInputToRomanConvertor(romanQuantityAndMetal.ToString(), InputToRomanMap)));
                        break;
                    case "Credits":
                        int indexOfCapitallatter = -1;
                        for (int index = 4; index < inputTokens.Length; index++)
                        {
                            if (!inputTokens[index].Equals("?"))
                            {
                                if (stringOperation.CheckFirstCharacterForCapital(inputTokens[index]))
                                {
                                    indexOfCapitallatter = index;
                                    break;
                                }
                                romanQuantityAndMetal.Append(inputTokens[index] + " ");
                            }
                        }
                        int quantityOfMetal = romanNumberComputation.RomanToInteger(romanNumberComputation.TestInputToRomanConvertor(romanQuantityAndMetal.ToString(), InputToRomanMap));
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

        public Dictionary<string, int> getOutputDictionaryForRoman()
        {
            return TestOutputRoman;
        }

        public Dictionary<string, double> getOutputDictionaryForMetal()
        {
            return TestOutputMetal;
        }
    }
}
