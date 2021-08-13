using System.Collections.Generic;
using System.Text;

namespace DentoTools.Core
{

    public static class RomanNumerals
    {

        private static readonly Dictionary<char, int> RomanNumberDictionary = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        private static readonly Dictionary<int, string> NumberRomanDictionary = new()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        public static string ToRomanNumerals(int number)
        {
            var roman = new StringBuilder();
            foreach (var item in NumberRomanDictionary)
                while (number >= item.Key)
                {
                    roman.Append(item.Value);
                    number -= item.Key;
                }
            return roman.ToString();
        }

        public static int FromRomanNumerals(string roman)
        {
            var total = 0;
            var previousRoman = '\0';
            foreach (var t in roman)
            {
                var previous = previousRoman != '\0' ? RomanNumberDictionary[previousRoman] : '\0';
                var current = RomanNumberDictionary[t];
                if (previous != 0 && current > previous)
                    total = total - 2 * previous + current;
                else
                    total += current;
                previousRoman = t;
            }
            return total;
        }

    }

}