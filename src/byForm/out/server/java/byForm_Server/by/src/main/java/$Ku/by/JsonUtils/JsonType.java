package $Ku.by.JsonUtils;

public enum JsonType{
    Object,
    Array,
    String,
    Number,
    Bool,
    Null;
    public int getValue() {
        return this.ordinal();
    }
    public static $Ku.by.JsonUtils.JsonType forValue(int value) {
        return values()[value];
    }

}