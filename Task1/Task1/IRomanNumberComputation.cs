using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface IRomanNumberComputation
    {
        string TestInputToRomanConvertor(string testInput, Dictionary<string, char> InputToRomanMap);
        int RomanToInteger(string roman);
    }
}
