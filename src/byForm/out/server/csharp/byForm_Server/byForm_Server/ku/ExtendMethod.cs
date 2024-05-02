using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using byForm_Server.ku.by.ToolClass;
using System.Text;
namespace byForm_Server.ku
{
    public class ExtendMethod
    {
        public static string[] matches(string f_Instance, string pattern, byForm_Server.ku.by.Enum.RegexMode mode)
        {
            Regex tmpRegex = null;
            MatchCollection tmpMatches = null;
            if (mode == by.Enum.RegexMode.none)
            {
                tmpRegex = new Regex(pattern, RegexOptions.None);
                tmpMatches = tmpRegex.Matches(f_Instance);
            }
            else if (mode == by.Enum.RegexMode.multiIgnoreCase)
            {
                tmpRegex = new Regex(pattern,RegexOptions.Multiline|RegexOptions.IgnoreCase);
                tmpMatches = tmpRegex.Matches(f_Instance);
            }
            else if (mode == by.Enum.RegexMode.multiline)
            {
                tmpRegex = new Regex(pattern, RegexOptions.Multiline);
                tmpMatches = tmpRegex.Matches(f_Instance);
            }
            else
            {
                tmpRegex = new Regex(pattern, RegexOptions.IgnoreCase);
                tmpMatches = tmpRegex.Matches(f_Instance);
            }

            List<string> tmpList = new List<string>();
            foreach (var item in tmpMatches)
            {
                tmpList.Add(item.ToString());
            }
            return tmpList.ToArray();
        }

        public static bool isMatch(string f_Instance, string pattern, byForm_Server.ku.by.Enum.RegexMode mode)
        {
            Regex tmpRegex = null;
            if (mode == by.Enum.RegexMode.none)
            {
                tmpRegex = new Regex(pattern, RegexOptions.None);
            }
            else if (mode == by.Enum.RegexMode.multiIgnoreCase)
            {
                tmpRegex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            }
            else if (mode == by.Enum.RegexMode.multiline)
            {
                tmpRegex = new Regex(pattern, RegexOptions.Multiline);
            }
            else
            {
                tmpRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            }

            return tmpRegex.IsMatch(f_Instance);
        }

        public static string replaceReg(string f_Instance, string pattern, string replacement, byForm_Server.ku.by.Enum.RegexMode mode)
        {
            Regex tmpRegex = null;
            if (mode == by.Enum.RegexMode.none)
            {
                tmpRegex = new Regex(pattern, RegexOptions.None);
            }
            else if (mode == by.Enum.RegexMode.multiIgnoreCase)
            {
                tmpRegex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            }
            else if (mode == by.Enum.RegexMode.multiline)
            {
                tmpRegex = new Regex(pattern, RegexOptions.Multiline);
            }
            else
            {
                tmpRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            }
            return tmpRegex.Replace(f_Instance, replacement);
        }

        public static string lTrim(string f_Instance)
        {
            return f_Instance.TrimStart(' ');
        }

        public static string rTrim(string f_Instance)
        {
            return f_Instance.TrimEnd(' ');
        }

        public static char charAt(string f_Instance, int index)
        {
            return f_Instance[index];
        }

        public static string remove(string f_Instance, int index1, int index2)
        {
            return f_Instance.Remove(index1, index2 - index1);
        }

        public static string subString(string f_Intance, int index1, int index2)
        {
            int tmpLength = index2- index1;
            return f_Intance.Substring(index1, tmpLength);
        }

        public static string replaceFirst(string f_Instance, string oldValue, string newValue)
        {
            int tmpStartIndex = f_Instance.IndexOf(oldValue);

            if (tmpStartIndex == -1)
            {
                return f_Instance;
            }

            List<char> tmpChars = new List<char>();

            for (int i = 0; i < tmpStartIndex; i++)
            {
                tmpChars.Add(f_Instance[i]);
            }

            tmpChars.AddRange(newValue);
            int tmpNewStartIndex = tmpStartIndex + oldValue.Length;

            for (int i = tmpNewStartIndex; i < f_Instance.Length; i++)
            {
                tmpChars.Add(f_Instance[i]);
            }

            return new string (tmpChars.ToArray());
        }

        public static bool isFinite(double number)
        {
            return !(double.IsNaN(number) || double.IsInfinity(number));
        }

        public static char charAt(System.Text.StringBuilder f_Instance, int index)
        {
            return f_Instance[index];
        }

        public static System.Text.StringBuilder remove(System.Text.StringBuilder f_Instance, int index1, int index2)
        {
            return f_Instance.Remove(index1, index2 - index1);
        }

        public static void setCharAt(System.Text.StringBuilder f_Instance, int index, char value)
        {
            f_Instance[index] = value;
        }

        public static string subString(System.Text.StringBuilder f_Instance, int index1, int index2)
        {
            return f_Instance.ToString(index1, index2 - index1);
        }

        public static char[] toCharArray(System.Text.StringBuilder f_Instance)
        {
            return f_Instance.ToString().ToCharArray();
        }

        public static sbyte[] ReadAllBytes(string f_Path)
        {
            byte[] tmpValue = System.IO.File.ReadAllBytes(f_Path);
            sbyte[] tmpReturnValue = new sbyte[tmpValue.Length];
            Buffer.BlockCopy(tmpValue, 0, tmpReturnValue, 0, tmpValue.Length);
            return tmpReturnValue;
        }

        public static void WriteAllBytes(string f_Path, sbyte[] f_Value, bool f_Append)
        {
            if (f_Append)
            {
                appendAllBytes(f_Path, f_Value);
                return;
            }

            byte[] tmpValue = new byte[f_Value.Length];
            Buffer.BlockCopy(f_Value, 0, tmpValue, 0, tmpValue.Length);
            System.IO.File.WriteAllBytes(f_Path, tmpValue);
        }

        public static int TimerInterval(System.Timers.Timer f_Instance)
        {
            return (int)f_Instance.Interval;
        }

        public static System.Text.Encoding Latin1()
        {
            return Encoding.GetEncoding("iso-8859-1");
        }

        public static void appendAllBytes(string f_Path, sbyte[] f_Value)
        {
            var tmpBytes = System.IO.File.ReadAllBytes(f_Path);
            byte[] tmpValue = new byte[f_Value.Length];
            Buffer.BlockCopy(f_Value, 0, tmpValue, 0, tmpValue.Length);
            var tmpNewValue = tmpBytes.Concat(tmpValue).ToArray();
            System.IO.File.WriteAllBytes(f_Path, tmpNewValue);
        }

        public static int intParse(string f_Value, int f_ToBase)
        {
            if (f_ToBase != 2 && f_ToBase != 8 && f_ToBase != 10 && f_ToBase != 16)
            {
                ThrowHelper.ThrowFuncException(ErrorInfo.FromBaseArgError + f_ToBase);
            }

            if (f_Value.StartsWith("-"))
            {
                string tmpNewValue = f_Value.Substring(1);
                return -Convert.ToInt32(tmpNewValue, f_ToBase);
            }
            else
            {
                return Convert.ToInt32(f_Value, f_ToBase);
            }
        }

        public static string intToString(int f_Value, int f_ToBase)
        {
            if (f_ToBase != 2 && f_ToBase != 8 && f_ToBase != 10 && f_ToBase != 16)
            {
                ThrowHelper.ThrowFuncException(ErrorInfo.FromBaseArgError + f_ToBase);
            }

            if (f_Value < 0)
            {
                return "-" + Convert.ToString(-f_Value, f_ToBase);
            }
            else
            {
                return Convert.ToString(f_Value, f_ToBase);
            }
        }

        public static void writeAllLines(string path, string[] lines, bool append)
        {
            if (append)
            {
                System.IO.File.AppendAllLines(path, lines);
                return;
            }

            System.IO.File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        public static void writeAllLines(string path, string[] lines, bool append, System.Text.Encoding encoding)
        {
            if (append)
            {
                System.IO.File.AppendAllLines(path, lines, encoding);
                return;
            }

            System.IO.File.WriteAllLines(path, lines, encoding);
        }

        public static void writeAllText(string path, string contents, bool append)
        {
            if (append)
            {
                System.IO.File.AppendAllText(path, contents, Encoding.UTF8);
                return;
            }

            System.IO.File.WriteAllText(path, contents, Encoding.UTF8);
        }

        public static void writeAllText(string path, string contents, bool append, System.Text.Encoding encoding)
        {
            if (append)
            {
                System.IO.File.AppendAllText(path, contents, encoding);
            }

            System.IO.File.WriteAllText (path, contents, encoding);
        }
    }
}
