package $Ku.by.ToolClass;

public enum DBTypeEnum{
    SqlServer,
    Mysql,
    Oracle;
    public int getValue() {
        return this.ordinal();
    }
    public static $Ku.by.ToolClass.DBTypeEnum forValue(int value) {
        return values()[value];
    }

}