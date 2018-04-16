using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Utility
    {
        public static string TrimLength(string input,int maxLength)
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
            else
                return input;
        }
    }
}
