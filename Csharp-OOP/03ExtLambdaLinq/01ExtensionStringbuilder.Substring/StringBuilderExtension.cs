using System;
using System.Linq;
using System.Text;

namespace ExtensionStringbuilder.Substring
{
    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder text, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= text.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (length < 0 || startIndex > text.Length - length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (length == 0)
            {
                return new StringBuilder().Append(string.Empty);
            }
            if (startIndex == 0 && length == text.Length)
            {
                return text;
            }
            char[] outputBuffer = new char[length];
            text.CopyTo(startIndex, outputBuffer, 0, length);
            return new StringBuilder(length).Append(outputBuffer);
        }
    }
}
