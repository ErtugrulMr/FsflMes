using System;

namespace Core.Extensions
{
    public static class StringExtensions
    {
       public static string Capitalize(this String word)
        {

            if (word.Length == 1)
            {
                word = char.ToUpper(word[0]).ToString();
            }
            else
            {
                word = char.ToUpper(word[0]) + word.Substring(1);
            }

            return word;
        }
    }
}
