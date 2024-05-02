package $Ku.by.ToolClass;

import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
public class ExtendMethod {
    public static java.util.ArrayList<java.lang.String> matches(java.lang.String f_Instance, java.lang.String pattern, $Ku.by.Enum.RegexMode mode) {
        Pattern tmpPattern;
        Matcher tmpMatcher;
        if (mode == $Ku.by.Enum.RegexMode.none) {
            tmpPattern = Pattern.compile(pattern, Pattern.UNICODE_CHARACTER_CLASS);
            tmpMatcher = tmpPattern.matcher(f_Instance);
        } else if (mode == $Ku.by.Enum.RegexMode.multiIgnoreCase) {
            tmpPattern = Pattern.compile(pattern, Pattern.MULTILINE | Pattern.CASE_INSENSITIVE | Pattern.UNICODE_CHARACTER_CLASS);
            tmpMatcher = tmpPattern.matcher(f_Instance);
        } else if (mode == $Ku.by.Enum.RegexMode.multiline) {
            tmpPattern = Pattern.compile(pattern, Pattern.MULTILINE | Pattern.UNICODE_CHARACTER_CLASS);
            tmpMatcher = tmpPattern.matcher(f_Instance);
        } else {
            tmpPattern = Pattern.compile(pattern, Pattern.CASE_INSENSITIVE | Pattern.UNICODE_CHARACTER_CLASS);
            tmpMatcher = tmpPattern.matcher(f_Instance);
        }

        ArrayList<String> tmpList = new ArrayList<>();
        while (tmpMatcher.find()) {
            tmpList.add(tmpMatcher.group());
        }
        return tmpList;
    }

    public static boolean isMatch(java.lang.String f_Instance, java.lang.String pattern, $Ku.by.Enum.RegexMode mode) {
        Pattern tmpPattern;
        if (mode == $Ku.by.Enum.RegexMode.none) {
            tmpPattern = Pattern.compile(pattern, Pattern.UNICODE_CHARACTER_CLASS);
        } else if (mode == $Ku.by.Enum.RegexMode.multiIgnoreCase) {
            tmpPattern = Pattern.compile(pattern, Pattern.MULTILINE | Pattern.CASE_INSENSITIVE | Pattern.UNICODE_CHARACTER_CLASS);
        } else if (mode == $Ku.by.Enum.RegexMode.multiline) {
            tmpPattern = Pattern.compile(pattern, Pattern.MULTILINE | Pattern.UNICODE_CHARACTER_CLASS);
        } else {
            tmpPattern = Pattern.compile(pattern, Pattern.CASE_INSENSITIVE | Pattern.UNICODE_CHARACTER_CLASS);
        }
        Matcher tmpMatcher = tmpPattern.matcher(f_Instance);
        return tmpMatcher.matches();
    }

    public static java.lang.String replaceReg(java.lang.String f_Instance, java.lang.String pattern, java.lang.String replacement, $Ku.by.Enum.RegexMode mode) {
        Pattern tmpPattern;
        if (mode == $Ku.by.Enum.RegexMode.none) {
            tmpPattern = Pattern.compile(pattern, Pattern.UNICODE_CHARACTER_CLASS);
        } else if (mode == $Ku.by.Enum.RegexMode.multiIgnoreCase) {
            tmpPattern = Pattern.compile(pattern, Pattern.MULTILINE | Pattern.CASE_INSENSITIVE | Pattern.UNICODE_CHARACTER_CLASS);
        } else if (mode == $Ku.by.Enum.RegexMode.multiline) {
            tmpPattern = Pattern.compile(pattern, Pattern.MULTILINE | Pattern.UNICODE_CHARACTER_CLASS);
        } else {
            tmpPattern = Pattern.compile(pattern, Pattern.CASE_INSENSITIVE | Pattern.UNICODE_CHARACTER_CLASS);
        }
        Matcher tmpMatcher = tmpPattern.matcher(f_Instance);
        return tmpMatcher.replaceAll(replacement);
    }

    public static double diffDays($Ku.by.Object.Datetime f_Instance, $Ku.by.Object.Datetime dt) {
        long tmpGap = f_Instance.getDay() - dt.getDay();
        return (double) tmpGap / (24 * 60 * 60 * 1000);
    }

    public static double diffSeconds($Ku.by.Object.Datetime f_Instance, $Ku.by.Object.Datetime dt) {
        long tmpGap = f_Instance.getSecond() - dt.getSecond();
        return (double) tmpGap / 1000;
    }

    public static int diffMilliseconds($Ku.by.Object.Datetime f_Instance, $Ku.by.Object.Datetime dt) {
        long tmpGap = f_Instance.getMilliSecond() - dt.getMilliSecond();
        return (int) tmpGap;
    }

    public static java.lang.String lTrim(java.lang.String f_Instance) {
        return f_Instance.replaceAll("^\\s+", "");
    }

    public static java.lang.String rTrim(java.lang.String f_Instance) {
        return f_Instance.replaceAll("\\s+$", "");
    }

    public static char charAt(java.lang.String f_Instance, int index) {
        return f_Instance.charAt(index);
    }
}
