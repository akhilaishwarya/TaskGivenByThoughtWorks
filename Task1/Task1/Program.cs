using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            ITestInputToDictionaryBuilder testInputToDictionaryBuilder = TestInputToDictionary.CreateObject();
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
                bool validinput = testInputToDictionaryBuilder.TestInputToDictionaryBuilder(tokens);
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
                bool validinput = testInputToDictionaryBuilder.TestQueriesToDictionaryBuilder(tokens);
                if (!validinput)
                {
                    Console.WriteLine("This input is not valid, please provide proper input");
                }
            }
            Dictionary<string, int> TestOutputRoman = testInputToDictionaryBuilder.getOutputDictionaryForRoman();
            Dictionary<string, double> TestOutputMetal = testInputToDictionaryBuilder.getOutputDictionaryForMetal();
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
                
        

        
    }
}
