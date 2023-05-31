using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp.Extensions
{
    public static class StringExtensions
    {
        public static string Foo(this string input)
        {
            return input + "Foo";
        }
        public static bool IsPalindrome(this string input)
        {
            for(int i= 0,j=input.Length-1; i<j; i++, j--)
            {
                if (input[i] != input[j])
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
