package $Ku.by.ToolClass;

public enum SqlObjParameterTypeEnum{
    ROW,
    QUERY,
    USERDEFINED;
    public int getValue() {
        return this.ordinal();
    }
    public static $Ku.by.ToolClass.SqlObjParameterTypeEnum forValue(int value) {
        return values()[value];
    }

}