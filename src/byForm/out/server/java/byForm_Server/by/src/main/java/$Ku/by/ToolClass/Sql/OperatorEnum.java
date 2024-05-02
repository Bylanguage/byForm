package $Ku.by.ToolClass.Sql;

public enum OperatorEnum{
    insert,
    delete,
    update,
    select;
    public int getValue() {
        return this.ordinal();
    }
    public static $Ku.by.ToolClass.Sql.OperatorEnum forValue(int value) {
        return values()[value];
    }

}