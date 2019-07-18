using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface ITestInputToDictionaryBuilder
    {
        bool TestInputToDictionaryBuilder(string[] inputTokens);
        bool TestQueriesToDictionaryBuilder(string[] inputTokens);
        Dictionary<string, int> getOutputDictionaryForRoman();
        Dictionary<string, double> getOutputDictionaryForMetal();
    }
}
