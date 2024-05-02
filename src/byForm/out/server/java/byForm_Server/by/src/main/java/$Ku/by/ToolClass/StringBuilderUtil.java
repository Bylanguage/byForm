package $Ku.by.ToolClass;

public class StringBuilderUtil {
    public static final double MIN = -1.7976931348623157E308D;

    public static java.lang.StringBuilder clear(java.lang.StringBuilder stringBuilder) {
        stringBuilder.setLength(0);
        return stringBuilder;
    }

    public static java.lang.StringBuilder append(java.lang.StringBuilder stringBuilder, $Ku.by.Object.Decimal decimal) {
        stringBuilder.append(decimal.getValue());
        return stringBuilder;
    }

    public static java.lang.Character[] toCharArray(java.lang.StringBuilder stringBuilder) {
        char[] tmpChars = stringBuilder.toString().toCharArray();
        Character[] value = new Character[tmpChars.length];
        for(int i = 0; i < tmpChars.length; i++){
            value[i] = tmpChars[i];
        }
        return value;
    }

    public static java.lang.StringBuilder append(java.lang.StringBuilder stringBuilder, java.lang.Character[] characters, java.lang.Integer startIndex, java.lang.Integer count) {
        char[] value = new char[characters.length];
        for(int i = 0; i < characters.length; i++){
            value[i] = characters[i];
        }
        stringBuilder.append(value, startIndex, count);
        return stringBuilder;
    }

    public static java.lang.StringBuilder append(java.lang.StringBuilder stringBuilder, java.lang.Character[] characters) {
        char[] value = new char[characters.length];
        for(int i = 0; i < characters.length; i++){
            value[i] = characters[i];
        }
        stringBuilder.append(value);
        return stringBuilder;
    }

    public static java.lang.StringBuilder insert(java.lang.StringBuilder stringBuilder, java.lang.Integer index, java.lang.Character[] characters) {
        char[] value = new char[characters.length];
        for(int i = 0; i < characters.length; i++){
            value[i] = characters[i];
        }
        stringBuilder.insert(index, value);
        return stringBuilder;
    }
}
