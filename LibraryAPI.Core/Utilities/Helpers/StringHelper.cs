using System.Text.RegularExpressions;

namespace LibraryAPI.Core.Utilities.Helpers
{
    public static class StringHelper
    {
        public static string RemoveSpaces(this string variable)
        {
            return variable.Replace(" ", "");
        }
        public static string ToLowerAndRemoveSpaces(this string variable)
        {
            return variable.ToLower().Replace(" ", "");
        }
        public static bool IsNumberExist(string variable)
        {
            if (string.IsNullOrEmpty(variable)) return false;
            return Regex.IsMatch(variable,@"\d");
        }
        public static string UppercaseFirstLetterOfEachWordAndOtherLower(string variable)
        {
            if (string.IsNullOrEmpty(variable))
                return variable;

            string[] words = variable.ToLower().Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    char[] chars = words[i].ToCharArray();
                    chars[0] = char.ToUpper(chars[0]);
                    words[i] = new string(chars);
                }
            }

            return string.Join(" ", words);
        }
    }
}

