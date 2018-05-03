using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Utility
    {
        public static string TrimLength(string input,int maxLength)
        {

            if (input == null)
            {
                return input;
            }
            else if(input!=null)
            {
                if (input.Length > maxLength)
                {
                    maxLength -= "...".Length;
                    maxLength = input.Length < maxLength ? input.Length : maxLength;
                    bool isLastSpace = input[maxLength] == ' ';
                    string part = input.Substring(0, maxLength);
                    if (isLastSpace)
                        return part + "...";
                    int lastSpaceIndexBeforeMax = part.LastIndexOf(' ');
                    if (lastSpaceIndexBeforeMax == -1)
                        return part + "...";
                    else
                        return input.Substring(0, lastSpaceIndexBeforeMax) + "...";
                }
                else if (input.Length < maxLength)
                    return input;
            }          
                return input;
        }


        // Cắt HTML
        public static string RemoveHtmlTagsUsingCharArray(this string htmlString)
        {
            var array = new char[htmlString.Length];
            var arrayIndex = 0;
            var inside = false;

            foreach (var @let in htmlString)
            {
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (inside) continue;
                array[arrayIndex] = let;
                arrayIndex++;
            }
            return new string(array, 0, arrayIndex);
        }

        public static string GetAppSettings(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
