package $Ku.by.ToolClass;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
public class StringUtil {
    public final static java.lang.String EMPTY = "";

    public static java.lang.String lTrim(java.lang.String str) {
        int len = str.length();
        int st = 0;
        char[] val = str.toCharArray();    /* avoid getfield opcode */

        while ((st < len) && (val[st] <= ' ')) {
            st++;
        }

        return ((st > 0)) ? str.substring(st, len) : str;
    }

    public static java.lang.Boolean isNullOrEmpty(java.lang.String value) {
        return value == null || value.isEmpty();
    }

    public static java.lang.String join(java.lang.String separator, Object[] values) {
        String[] strings = Arrays.copyOf(values, values.length, String[].class);
        return String.join(separator, strings);
    }

    public static java.lang.String[] matches(java.lang.String input, java.lang.String pattern, $Ku.by.Enum.RegexMode mode) {
        ArrayList<String> matches = new ArrayList<>();

        int flags = 0;
        if (mode == $Ku.by.Enum.RegexMode.ignoreCase) {
            flags |= Pattern.CASE_INSENSITIVE;
        }
        if (mode == $Ku.by.Enum.RegexMode.multiline) {
            flags |= Pattern.MULTILINE;
        }
        if (mode == $Ku.by.Enum.RegexMode.multiIgnoreCase) {
            flags |= Pattern.CASE_INSENSITIVE | Pattern.MULTILINE;
        }

        Pattern regexPattern = Pattern.compile(pattern, flags);
        if (mode == $Ku.by.Enum.RegexMode.none) {
            regexPattern = Pattern.compile(pattern);
        }
        Matcher matcher = regexPattern.matcher(input);

        while (matcher.find()) {
            matches.add(matcher.group());
        }

        return matches.toArray(new String[0]);
    }

    public static java.lang.String rTrim(java.lang.String str) {
        int len = str.length();
        int st = 0;
        char[] val = str.toCharArray();    /* avoid getfield opcode */

        while ((st < len) && (val[len - 1] <= ' ')) {
            len--;
        }
        return ((len < str.length())) ? str.substring(st, len) : str;
    }

    public static java.lang.Integer compare(java.lang.String strA, int indexA, java.lang.String strB, int indexB, int length) {
        if(strA == null){
            if(strB == null){
                return 0;
            }
            return -1;
        }
        if(strB == null){
            return 1;
        }

        if(indexA < 0 || indexB <0){
            throw new RuntimeException("索引不能小于0");
        }

        if(length < 0){
            throw new RuntimeException("指定长度不能小于0");
        }

        int num1 = length;
        int num2 = length;

        if(indexA >= strA.length()){
            throw new StringIndexOutOfBoundsException("indexA");
        }

        if(indexB >= strB.length()){
            throw new StringIndexOutOfBoundsException("indexB");
        }

        if(strA.length() - indexA < num1){
            num1 = strA.length() - indexA;
        }

        if(strB.length() - indexB < num2){
            num2 = strB.length() - indexB;
        }

        String subA = strA.substring(indexA, indexA + num1);
        String subB = strB.substring(indexB, indexB + num2);
        return compare(subA, subB);
    }

    public static java.lang.Integer compare(java.lang.String strA, java.lang.String strB) {
        if(strA == null){
            if(strB == null){
                return 0;
            }
            return -1;
        }
        if(strB == null){
            return 1;
        }
        int result = strA.compareTo(strB);
        return -Integer.compare(result, 0);
    }

    public static java.lang.String concat(java.lang.String[] items) {
        StringBuilder builder = new StringBuilder();
        for (String item : items){
            builder.append(item);
        }
        return builder.toString();
    }

    public static java.lang.String insert(java.lang.String oldString, int index, java.lang.String insertString) {
        StringBuilder stringBuilder = new StringBuilder(oldString);
        stringBuilder.insert(index, insertString);
        return stringBuilder.toString();
    }

    public static java.lang.String remove(java.lang.String oldString, int index) {
        if(oldString == null){
            throw new NullPointerException("原字符串为null");
        }
        if(index < 0){
            throw new StringIndexOutOfBoundsException("index");
        }
        if(index >= oldString.length()){
            throw new StringIndexOutOfBoundsException("index");
        }
        return oldString.substring(0,index);
    }

    public static java.lang.String remove(java.lang.String oldString, int index1, int index2) {
        if(oldString == null){
            throw new NullPointerException("原字符串为null");
        }
        if(index1 < 0 || index2 < 0){
            throw new StringIndexOutOfBoundsException(index1<0 ? "index1" : "index2");
        }

        if(index1 >= oldString.length()  || index2 >= oldString.length() ){
            throw new StringIndexOutOfBoundsException(index1 >= oldString.length() ? "index1" : "index2");
        }

        if(index2 < index1){
            throw new RuntimeException("索引2不能小于索引1");
        }

        StringBuilder stringBuilder = new StringBuilder(oldString);
        stringBuilder.replace(index1, index2, "");
        return stringBuilder.toString();
    }

    public static java.lang.Boolean isMatch(java.lang.String value, java.lang.String pattern, $Ku.by.Enum.RegexMode mode) {
        Pattern p;
        switch (mode){
            case none:
                p = Pattern.compile(pattern);
                break;
            case multiline:
                p = Pattern.compile(pattern,Pattern.MULTILINE);
                break;
            case ignoreCase:
                p = Pattern.compile(pattern,Pattern.CASE_INSENSITIVE);
                break;
            case multiIgnoreCase:
                p = Pattern.compile(pattern,Pattern.MULTILINE|Pattern.CASE_INSENSITIVE);
                break;
            default:
                throw new RuntimeException("匹配模式不存在！");
        }
        Matcher matcher = p.matcher(value);
        return matcher.find();
    }

    public static java.lang.String replaceReg(java.lang.String value, java.lang.String pattern, java.lang.String replacement, $Ku.by.Enum.RegexMode mode) {
        Pattern p;
        switch (mode){
            case none:
                p = Pattern.compile(pattern);
                break;
            case multiline:
                p = Pattern.compile(pattern,Pattern.MULTILINE);
                break;
            case ignoreCase:
                p = Pattern.compile(pattern,Pattern.CASE_INSENSITIVE);
                break;
            case multiIgnoreCase:
                p = Pattern.compile(pattern,Pattern.MULTILINE|Pattern.CASE_INSENSITIVE);
                break;
            default:
                throw new RuntimeException("匹配模式不存在！");
        }
        Matcher matcher = p.matcher(value);
        return matcher.replaceAll(replacement);
    }

    public static java.lang.String[] split(java.lang.String value, char separator) {
        switch (separator){
            case '(':
                return value.split("\\(");
            case '[':
                return value.split("\\[");
            case '{':
                return value.split("\\{");
            case '^':
                return value.split("\\^");
            case '-':
                return value.split("\\-");
            case '$':
                return value.split("\\$");
            case '|':
                return value.split("\\|");
            case '}':
                return value.split("\\}");
            case ']':
                return value.split("\\]");
            case ')':
                return value.split("\\)");
            case '?':
                return value.split("\\?");
            case '*':
                return value.split("\\*");
            case '+':
                return value.split("\\+");
            case '.':
                return value.split("\\.");
            case '/':
                return value.split("\\/");
            case '\\':
                return value.split("\\\\");
        }
        return value.split(separator + "");
    }

    public static java.lang.Character[] toCharArray(java.lang.String string) {
        char[] tmpChars = string.toCharArray();
        Character[] value = new Character[tmpChars.length];
        for(int i = 0; i < tmpChars.length; i++){
            value[i] = tmpChars[i];
        }
        return value;
    }

    public static java.lang.Character charAt(java.lang.String string, int index) {
        return string.charAt(index);
    }
}
