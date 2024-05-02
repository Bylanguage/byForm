package $Ku.by.ToolClass;

public enum FunctionEnum{
    NONE,
    AVG,
    SUM,
    MIN,
    MAX,
    COUNT;
    public int getValue() {
        return this.ordinal();
    }
    public static $Ku.by.ToolClass.FunctionEnum forValue(int value) {
        return values()[value];
    }

}