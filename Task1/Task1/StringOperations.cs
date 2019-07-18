using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class StringOperations : IStringOperations
    {
        private static StringOperations obj = null;
        private StringOperations()
        { }
        public static StringOperations CreateObject()
        {
            if (obj == null)
            {
                obj = new StringOperations();
            }
            return obj;
        }
        public bool CheckFirstCharacterForCapital(string word)
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
    }
}
