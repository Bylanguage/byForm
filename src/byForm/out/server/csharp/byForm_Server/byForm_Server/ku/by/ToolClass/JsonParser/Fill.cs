using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser
{
    public class Fill
    {
        public Fill()
        {
        }

        public static int FindFirstNotSpace(int f_Index, char[] f_Input)
        {
            //index是之前的最后一个非空白字符的位置
            if (f_Index == f_Input.Length - 1)
            {
                return f_Index;
            }

            for (int i = f_Index + 1; i < f_Input.Length; i++)
            {
                var tmpValue = f_Input[i];
                if (tmpValue == '\r' || tmpValue == '\n' || tmpValue == ' ' || tmpValue == '\t')
                {
                    continue;
                }
                else
                {
                    return i;
                }
            }

            return -1;
        }

        public static int FindFirstDoublequotation(int f_Index, char[] f_Input)
        {
            for (int i = f_Index + 1; i < f_Input.Length; i++)
            {
                var tmpValue = f_Input[i];
                if (tmpValue == '"')
                {
                    if (i == 0)
                    {
                        return i;
                    }
                    else
                    {
                        if (f_Input[i - 1] == '\\')
                        {
                            continue;
                        }
                        else
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        public static string GetNormValue(int f_Index, char[] f_Input, bool f_IsArray, out int f_EndIndex)
        {
             //获取 有理数、布尔值、空值（null）
            //, } ] space \r\n \t  (终止符
            int tmpEndIndex = -1;
            List<char> tmpValue = new List<char>();
            tmpValue.Add(f_Input[f_Index]);
            for (int i = f_Index + 1; i < f_Input.Length; i++)
            {
                var tmpCurrent = f_Input[i];
                if (tmpCurrent == ',' || tmpCurrent == ' ' || tmpCurrent == '\r' || tmpCurrent == '\n' || tmpCurrent == '\t')
                {
                    tmpEndIndex = i;
                    if (i == f_Index + 1)
                    {
                        tmpEndIndex--;
                        break;
                    }
                    if (tmpCurrent == ',')
                    {
                        tmpEndIndex--;
                    }

                    break;
                }
                if (f_IsArray && tmpCurrent == ']')
                {
                    tmpEndIndex = i;
                    break;
                }
                if (!f_IsArray && tmpCurrent == '}')
                {
                    tmpEndIndex = i;
                    break;
                }

                tmpValue.Add(tmpCurrent);
            }
            if (tmpEndIndex == -1)
            {
                tmpEndIndex = f_Input.Length;
            }
            f_EndIndex = tmpEndIndex;

            return new string(tmpValue.ToArray());
        }

        public static string GetTargetValue(int f_Index, char[] f_Input, out int f_EndIndex)
        {
            //f_Index为对象开头的大括号所在索引
            f_EndIndex = -1;
            List<char> tmpOutPut = new List<char>();
            int tmpLeftCount = 0;
            bool tmpIsString = false;
            for (int i = f_Index; i < f_Input.Length; i++)
            {
                char tmpCurrentChar = f_Input[i];
                tmpOutPut.Add(tmpCurrentChar);

                if (tmpCurrentChar == '\\')
                {
                    if (i != f_Input.Length - 1 && (f_Input[i + 1] == '"' || f_Input[i + 1] == '\\'))
                    {
                        tmpOutPut.Add(f_Input[i + 1]);
                        i = i + 1;
                        continue;
                    } 
                }

                if (tmpCurrentChar == '"')
                {
                    if (tmpIsString)
                    {
                        tmpIsString = false;
                    }
                    else
                    {
                        tmpIsString = true;
                    }

                    continue;
                }

                if (tmpCurrentChar == '{' && !tmpIsString)
                {
                    tmpLeftCount++;
                    continue;
                }

                if (tmpCurrentChar == '}' && !tmpIsString)
                {
                    tmpLeftCount--;
                    if (tmpLeftCount == 0)
                    {
                        f_EndIndex = i;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            if (tmpLeftCount != 0)
            {
                throw new Exception(string.Format("{0} 末尾不是期望的字符 \"", new string(f_Input)));
            }

            if (tmpOutPut[tmpOutPut.Count - 1] != '}')
            {
                throw new Exception(string.Format("{0} 末尾不是期望的字符 }  ", new string(f_Input)));
            }

            return new string(tmpOutPut.ToArray());
        }

        public static string GetArrayValue(int f_Index, char[] f_Input, out int f_EndIndex)
        {
            f_EndIndex = -1;
            List<char> tmpOutPut = new List<char>();
            int tmpLeftCount = 0;
            bool tmpIsString = false;
            for (int i = f_Index; i < f_Input.Length; i++)
            {
                char tmpCurrentChar = f_Input[i];
                tmpOutPut.Add(tmpCurrentChar);

                if (tmpCurrentChar == '\\')
                {
                    if (i != f_Input.Length - 1 && (f_Input[i + 1] == '"' || f_Input[i + 1] == '\\'))
                    {
                        tmpOutPut.Add(f_Input[i + 1]);
                        i = i + 1;
                        continue;
                    }
                }

                if (tmpCurrentChar == '"')
                {
                    if (tmpIsString)
                    {
                        tmpIsString = false;
                    }
                    else
                    {
                        tmpIsString = true;
                    }

                    continue;
                }

                if (tmpCurrentChar == '[' && !tmpIsString)
                {
                    tmpLeftCount++;
                    continue;
                }

                if (tmpCurrentChar == ']' && !tmpIsString)
                {
                    tmpLeftCount--;
                    if (tmpLeftCount == 0)
                    {
                        f_EndIndex = i;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            if (tmpLeftCount != 0)
            {
                throw new Exception(string.Format("{0} 末尾不是期望的字符 \"", new string(f_Input)));
            }

            if (tmpOutPut[tmpOutPut.Count - 1] != ']')
            {
                throw new Exception(string.Format("{0} 末尾不是期望的字符 ]", new string(f_Input)));
            }

            return new string(tmpOutPut.ToArray());
        }

        public static string GetStringValue(int f_Index, char[] f_Input, out int f_EndIndex)
        {
            f_EndIndex = -1;
            //List<char> tmpOutPut = new List<char>();
            StringBuilder tmpList = new StringBuilder();
            //tmpOutPut.Add(f_Input[f_Index]);
            for (int i = f_Index + 1; i < f_Input.Length; i++)
            {
                var tmpCurrentChar = f_Input[i];

                if (tmpCurrentChar == '\\')
                {
                    if (i == f_Input.Length - 1)
                    {
                        break;
                    }
                    switch (f_Input[i + 1])
                    {
                        case'u':
                            if (i + 5 < f_Input.Length)
                            {
                                string tmpSpecialString = null;
                                if (!MatchingSpecialChar(f_Input, i + 2, out tmpSpecialString))
                                {
                                    continue;
                                }
                                i = i + 5;
                                tmpList.Append(tmpSpecialString);
                                continue;
                            }
                            break;
                        case 'b':
                            tmpList.Append("\b");
                            i = i + 1;
                            continue;
                        case 't':
                            tmpList.Append("\t");
                            i = i + 1;
                            continue;
                        case 'n':
                            tmpList.Append("\n");
                            i = i + 1;
                            continue;
                        case 'f':
                            tmpList.Append("\f");
                            i = i + 1;
                            continue;
                        case 'r':
                            tmpList.Append("\r");
                            i = i + 1;
                            continue;
                        case '"':
                            tmpList.Append(@"""");
                            i = i + 1;
                            continue;
                        case '\\':
                            tmpList.Append(@"\");
                            i = i + 1;
                            continue;
                        case '/':
                            tmpList.Append(@"/");
                            i = i + 1;
                            continue;
                    }

                }

                if (i != f_Input.Length - 1)
                {
                    tmpList.Append(tmpCurrentChar);
                }

                if (tmpCurrentChar == '"')
                {
                    f_EndIndex = i;
                    break;
                }
            }

            string tmpValue = tmpList.ToString();
            if (!tmpValue.EndsWith("\""))
            {
                throw new Exception("错误的字符串类型");
            }
            tmpValue = tmpValue.Remove(tmpValue.Length - 1);
            return tmpValue;
        }

        private static bool MatchingSpecialChar(char[] f_Input, int f_Index, out string f_OutValue)
        {
            //默认不会溢出
            char tmpValue1 = f_Input[f_Index];
            char tmpValue2 = f_Input[f_Index + 1];
            char tmpValue3 = f_Input[f_Index + 2];
            char tmpValue4 = f_Input[f_Index + 3];
            string tmpValue = tmpValue1.ToString() + tmpValue2.ToString() + tmpValue3.ToString() + tmpValue4.ToString();

            try
            {
                int tmpIntValue = Convert.ToInt32(tmpValue, 16);

                if (tmpIntValue >= 0xd800 && tmpIntValue <= 0xdfff)
                {
                    f_OutValue = ((char)tmpIntValue).ToString();
                    return true;
                }
            }
            catch
            {
                f_OutValue = null;
                return false;
            }

            switch (tmpValue)
            {
                case "0000":
                    f_OutValue = "\u0000";
                    return true;
                case "0001":
                    f_OutValue = "\u0001";
                    return true;
                case "0002":
                    f_OutValue = "\u0002";
                    return true;
                case "0003":
                    f_OutValue = "\u0003";
                    return true;
                case "0004":
                    f_OutValue = "\u0004";
                    return true;
                case "0005":
                    f_OutValue = "\u0005";
                    return true;
                case "0006":
                    f_OutValue = "\u0006";
                    return true;
                case "0007":
                    f_OutValue = "\u0007";
                    return true;
                case "000b":
                    f_OutValue = "\u000b";
                    return true;
                case "000e":
                    f_OutValue = "\u000e";
                    return true;
                case "000f":
                    f_OutValue = "\u000f";
                    return true;
                case "0010":
                    f_OutValue = "\u0010";
                    return true;
                case "0011":
                    f_OutValue = "\u0011";
                    return true;
                case "0012":
                    f_OutValue = "\u0012";
                    return true;
                case "0013":
                    f_OutValue = "\u0013";
                    return true;
                case "0014":
                    f_OutValue = "\u0014";
                    return true;
                case "0015":
                    f_OutValue = "\u0015";
                    return true;
                case "0016":
                    f_OutValue = "\u0016";
                    return true;
                case "0017":
                    f_OutValue = "\u0017";
                    return true;
                case "0018":
                    f_OutValue = "\u0018";
                    return true;
                case "0019":
                    f_OutValue = "\u0019";
                    return true;
                case "001a":
                    f_OutValue = "\u001a";
                    return true;
                case "001b":
                    f_OutValue = "\u001b";
                    return true;
                case "001c":
                    f_OutValue = "\u001c";
                    return true;
                case "001d":
                    f_OutValue = "\u001d";
                    return true;
                case "001e":
                    f_OutValue = "\u001e";
                    return true;
                case "001f":
                    f_OutValue = "\u001f";
                    return true;
                default:
                    f_OutValue = null;
                    return false;
            }
        }
    }
}
