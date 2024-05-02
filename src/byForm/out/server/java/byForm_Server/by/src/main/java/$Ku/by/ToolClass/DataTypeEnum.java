package $Ku.by.ToolClass;

public enum DataTypeEnum{
    None,
    Int,
    Decimal,
    Bool,
    String,
    Datetime,
    Char,
    Byte,
    Short,
    Long,
    Float,
    Double,
    Enum;
    public int getValue() {
        return this.ordinal();
    }
    public static $Ku.by.ToolClass.DataTypeEnum forValue(int value) {
        return values()[value];
    }

}