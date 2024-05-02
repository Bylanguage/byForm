package $Ku.by.JsonUtils;

import java.util.ArrayList;
import java.util.Locale;
public class ConvertStringJson {
    public static char[] toArray(java.util.ArrayList<java.lang.Character> list) {
        char[] array = new char[list.size()];
        for (int i = 0; i < list.size(); i++)
        {
            array[i] = list.get(i);
        }
        return array;
    }

    private static void SkipWhiteSpace($Ku.by.JsonUtils.JsonStr str) {
        while (true)
        {
            switch (str.getCurChar()) {
                case ' ' :
                case '\t' :
                case '\n' :
                case '\r' :
                    short stepCount = 1;
                    str.MoveNext(stepCount);
                    continue;

            }
            break;
        }
    }

    public static $Ku.by.JsonUtils.JsonObject ParseValue(java.lang.String str) {
        if (str == null || str.isEmpty()) {
            throw new RuntimeException("消息为空");
        }
        JsonStr tmpJsonStr = new JsonStr(str);
        SkipWhiteSpace(tmpJsonStr);
        if (tmpJsonStr.getCurChar() != '{') {
            throw new RuntimeException("Json must start with '{'");
        }
        return ParseObject(tmpJsonStr, true);
    }

    private static $Ku.by.JsonUtils.IJsonValue ParseAtomic($Ku.by.JsonUtils.JsonStr str) {
        SkipWhiteSpace(str);
        char tmpCurChar;
        switch (tmpCurChar = str.getCurChar())
        {
            case '{':
                return ParseObject(str, false);
            case '[':
                return ParseArray(str);
            case '"':
                return ParseString(str);
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
            case '-':
                return ParseNumber(str);
            case 'f':
                if (str.CompareCharbyChar("false"))
                {
                    short stepCount=5;
                    str.MoveNext(stepCount);
                    return new JsonBool(false);
                }
                break;
            case 't':
                if (str.CompareCharbyChar("true"))
                {
                    short stepCount=4;
                    str.MoveNext(stepCount);
                    return new JsonBool(true);
                }
                break;
            case 'n':
                if (str.CompareCharbyChar("null"))
                {
                    short stepCount=4;
                    str.MoveNext(stepCount);
                    return new JsonNull();
                }
                break;
        }

        throw new RuntimeException(String.format("Json ParseValue error on char '%c'", tmpCurChar));

    }

    private static $Ku.by.JsonUtils.JsonObject ParseObject($Ku.by.JsonUtils.JsonStr str, boolean isFirst) {
        if (str.getCurChar() != '{')
        {
            throw new IllegalArgumentException("Json ParseObject error on char '{'");
        }
        short stepCount=1;
        str.MoveNext(stepCount); //skip '{'
        JsonObject jsonObject = new JsonObject();
        do
        {
            SkipWhiteSpace(str);
            //对象格式 '{' 字符之后存在两种情况
            //1. '}' 字符, 标识空的Object "{}"
            //2. '"' 字符, 标识对象的 key
            //其他的全部出错

            //空的Object
            if (str.getCurChar() == '}')
            {
                str.MoveNext(stepCount);
                break;
            }
            if (str.getCurChar() != '"')
            {
                throw new RuntimeException(String.format("Json ParseObject error, char '%s' should be '\"' ", str.getCurChar()));
            }
            str.MoveNext(stepCount); //首先 跳过 '"' 字符

            ArrayList<Character> key = new ArrayList<>();
            while (true)
            {
                char curChar = str.getCurChar();
                str.MoveNext(stepCount);
                if (curChar == '"')
                {
                    break;
                }
                else
                {
                    if (curChar == '\\') //为了避免转义字符 '\"' 意外结束 key
                    {
                        key.add(curChar);
                        key.add(str.getCurChar());
                        str.MoveNext(stepCount);
                    }
                    else
                    {
                        key.add(curChar);
                    }
                }
            }

            SkipWhiteSpace(str);

            if (str.getCurChar() != ':')
            {
                String tempstr = String.format(Locale.CHINA,"Json ParseObject error(Json格式错误), after key = %1$s(在值%1$s后), char '%2$s' should be ':' (字符'%2$s'应当是':')", key.toString().replaceAll(",|\\[|\\ |\\]", ""), str.getCurChar());
                throw new RuntimeException(tempstr);
            }
            str.MoveNext(stepCount);

            jsonObject.Add(new String(toArray(key)), ParseAtomic(str)); //递归调用 ParseValue 获取 对象的 value 值

            SkipWhiteSpace(str);

            //解析 对象的 value之后, 有三种情况
            //1. ',' 字符
            //2. '}' 对象结束
            //4. 其他字符

            if (str.getCurChar() == ',')
            {
                str.MoveNext(stepCount);
                continue;
            }
            if (str.getCurChar() != '}')
            {
                throw new RuntimeException(String.format(Locale.CHINA,"Json ParseObject error(Json格式错误), after key = %1$s(在值%1$s后), char '%2$s' is not correct", key.toString().replaceAll(",|\\[|\\ |\\]", ""),str.getCurChar()));
            }
            else
            {
                if (!isFirst)
                {
                    str.MoveNext(stepCount);
                }
            }
            break;
        } while (true);

        return jsonObject;
    }

    public static $Ku.by.JsonUtils.JsonArray ParseArray($Ku.by.JsonUtils.JsonStr str) {
        if (str.getCurChar() != '[')
        {
            throw new IllegalArgumentException("Json ParseObject error on char '[' ");
        }
        short stepCount=1;
        str.MoveNext(stepCount); //跳过 '['


        JsonArray jsonArray = new JsonArray();

        do
        {
            SkipWhiteSpace(str);

            if (str.getCurChar() == ']')
            {
                str.MoveNext(stepCount); //跳过 ']'
                break;
            }

            jsonArray.Add(ParseAtomic(str));

            SkipWhiteSpace(str);

            //','
            if (str.getCurChar() == ',')
            {
                str.MoveNext(stepCount);
                continue;
            }
            if (str.getCurChar() != ']')
            {
                throw new RuntimeException(String.format("Json ParseArray error, char '%c' should be ']'", str.getCurChar()));
            }
            else
            {
                str.MoveNext(stepCount);
            }
            break;
        } while (true);

        return jsonArray;
    }

    public static $Ku.by.JsonUtils.JsonString ParseString($Ku.by.JsonUtils.JsonStr str) {
        if (str.getCurChar() != '"')
        {
            throw new IllegalArgumentException("Json ParseObject error on char '\"'");
        }
        short stepCount=1;
        str.MoveNext(stepCount); //跳过 '['

        StringBuffer buff = new StringBuffer();
        while (true)
        {
            char curChar = str.getCurChar();
            if (curChar == '"')
            {
                str.MoveNext(stepCount);
                break;
            }
            else
            {
                if (curChar == '\\') //转义字符
                {
                    str.MoveNext(stepCount);
                    switch (str.getCurChar()) {
                        case '"' :buff.append('"');
                        break;
                        case '\'' : buff.append('\'');
                            break;
                        case '\\' : buff.append('\\');
                            break;
                        case '/' : buff.append('/');
                            break;
                        case 'n' : buff.append('\n');
                            break;
                        case 'r' : buff.append('\r');
                            break;
                        case 't' : buff.append('\t');
                            break;
                        case 'f' : buff.append('\f');
                            break;
                        case 'u' : {
                            str.MoveNext(stepCount);
                            char c1 = str.getCurChar();
                            str.MoveNext(stepCount);
                            char c2 = str.getCurChar();
                            str.MoveNext(stepCount);
                            char c3 = str.getCurChar();
                            str.MoveNext(stepCount);
                            char c4 = str.getCurChar();
                            buff.append(GetUnicodeCodePoint(c1, c2, c3, c4));
                        }
                        break;
                        default : buff.append('\\').append(str.getCurChar());
                    }
                    str.MoveNext(stepCount);
                }
                else
                {
                    buff.append(curChar);
                    str.MoveNext(stepCount);
                }
            }
        }
        String string = buff.toString();
        return new JsonString(buff.toString());
    }

    private static char GetUnicodeCodePoint(char c1, char c2, char c3, char c4) {
        return (char)(UnicodeCharToInt(c1) * 0x1000 + UnicodeCharToInt(c2) * 0x100 + UnicodeCharToInt(c3) * 0x10 + UnicodeCharToInt(c4));
    }

    private static int UnicodeCharToInt(char c) {
        switch (c)
        {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                return c - '0';

            case 'a':
            case 'b':
            case 'c':
            case 'd':
            case 'e':
            case 'f':
                return c - 'a' + 10;

            case 'A':
            case 'B':
            case 'C':
            case 'D':
            case 'E':
            case 'F':
                return c - 'A' + 10;
        }

        throw new RuntimeException(String.format("Json Unicode char '%1$s' error", c));
    }

    public static $Ku.by.JsonUtils.JsonNumber ParseNumber($Ku.by.JsonUtils.JsonStr str) {
        StringBuilder buff = new StringBuilder();
        while (true)
        {
            char curChar = str.getCurChar();
            short stepCount = 1;
            switch (curChar) {
                case '0' :
                case '5' :
                case '2' :
                case '3' :
                case '4' :
                case '8' :
                case '7' :
                case '6' :
                case '1' :
                case 'E' :
                case 'e' :
                case '+' :
                case '-' :
                case '9' :
                case '.' :
                    buff.append(curChar);
                    str.MoveNext(stepCount);
                    continue;
                default:
            }
            break;
        }

        try {
            double tempDouble = Double.parseDouble(buff.toString());
            return new JsonNumber(buff.toString());
        }
        catch (NumberFormatException e) {
            throw new RuntimeException(String.format("Json ParseNumber error, can not parse string [%1$s]", buff));
        }
    }
}
