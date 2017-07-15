using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities
{
    /// <summary>
    /// Extention methods for string
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Extract a sub string from a given string by using a regular expression.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regularExpression"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string Extract(this string text, string regularExpression, string group = null, bool nullable = false)
        {
            Regex regex = new Regex(regularExpression,
                RegexOptions.CultureInvariant | RegexOptions.Compiled);
            var match = regex.Match(text);
            if (match.Success)
            {
                return @group == null ? match.Groups[1].Value : match.Groups[@group].Value;
            }
            if (nullable)
                return null;

            throw new Exception(@group == null
                                    ? "Could not extract given string"
                                    : String.Format("Could not extract {0} from given string", @group));
        }


        public static bool Contains(this string text, params string[] values)
        {
            return values.Any(text.Contains);
        }

        public static bool Contains(this string text, StringComparison stringComparison, params string[] values)
        {
            return values.Any(x => text.IndexOf(x, stringComparison) > -1);
        }

        public static bool Equals(this string text, StringComparison stringComparison, params string[] values)
        {
            return values.Any(x => text.Equals(x, stringComparison));
        }

        public static int ToIntSafely(this string text)
        {
            try
            {
                return Convert.ToInt32(text);
            }
            catch
            {

            }
            return 0;
        }

        public static List<T> Extract<T>(this string text, string regularExpression, Func<Match, T> func)
        {
            Regex regex = new Regex(regularExpression,
                RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matches = regex.Matches(text);
            return (from Match match in matches select func(match)).ToList();
        }

        public static void Extract(this string text, string regularExpression, Action<Match> func)
        {
            Regex regex = new Regex(regularExpression,
                RegexOptions.CultureInvariant | RegexOptions.Compiled);
            var matches = regex.Matches(text);
            matches.Cast<Match>().ToList().ForEach(func);
        }

        public static decimal ExtractDecimal(this string text)
        {
            //(?<number>[+-]?\d+(\.\d+)?)
            return text.Extract("(?<number>[+-]?[\\d,]+(\\.\\d+)?)", g => Convert.ToDecimal(g.Groups["number"].Value))
                    .FirstOrDefault();
        }

        public static bool Test(this string text, string regularExpression)
        {
            Regex regex = new Regex(regularExpression, RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return regex.IsMatch(text);
        }

        public static string ReplaceRegex(this string text, string regularExpression, string replacement)
        {
            Regex regex = new Regex(regularExpression, RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return regex.Replace(text, replacement);
        }


        public static string ExtractString(this string source, string left, string right, out int index, int startIndex = 0)
        {
            int pos = source.IndexOf(left, startIndex);
            if (pos == -1)
            {
                throw new Exception(String.Format("Partern left {0} was not found in the given string", left));
            }
            pos += left.Length;
            index = pos;
            int pos2 = source.IndexOf(right, pos);
            if (pos2 == -1)
            {
                throw new Exception(String.Format("Partern right {0} was not found in the given string", right));
            } //End If

            return source.Substring(pos, pos2 - pos);
        }
        public static string ExtractString(this string source, string left, string right, int startIndex = 0)
        {
            int index = 0;
            return ExtractString(source, left, right, out index, startIndex);
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripHtmlTags(this string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (@let == '<')
                {
                    inside = true;
                    continue;
                }
                if (@let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = @let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static bool EqualIgnoreCase(this string source, string text)
        {
            return source.Equals(text, StringComparison.CurrentCultureIgnoreCase);
        }


        public static bool IEqualsTo(this string source, string text)
        {
            return source.Equals(text, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsIn<T>(this T t, IEnumerable<T> args)
        {
            return In(t, args);
        }

        public static bool IsIn<T>(this T t, params T[] args)
        {
            return In(t, args);
        }

        public static bool In<T>(this T t, IEnumerable<T> args)
        {
            return args.Any(x => x.Equals(t));
        }

        public static bool In<T>(this T t, params T[] args)
        {
            return args.Any(x => x.Equals(t));
        }

        public static T To<T>(this string text)
        {
            return (T)Convert.ChangeType(text, typeof(T));
        }


    }
}
