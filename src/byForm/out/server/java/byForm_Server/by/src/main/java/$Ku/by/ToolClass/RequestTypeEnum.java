package $Ku.by.ToolClass;

public enum RequestTypeEnum{
    None,
    SQL,
    ACTION,
    SOURCE,
    TRAN,
    SKILL,
    AUTOID,
    EXEC;
    public int getValue() {
        return this.ordinal();
    }
    public static $Ku.by.ToolClass.RequestTypeEnum forValue(int value) {
        return values()[value];
    }

}