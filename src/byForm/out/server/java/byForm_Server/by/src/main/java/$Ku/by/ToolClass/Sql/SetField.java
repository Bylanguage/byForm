package $Ku.by.ToolClass.Sql;

public class SetField {
    public java.lang.String ComponentName;
    public $Ku.by.ToolClass.Sql.SqlField Field;
    public java.lang.String Operator;

    public SetField($Ku.by.ToolClass.Sql.SqlField f_Field, java.lang.String f_Operator) {
        Field = f_Field;
        Operator= f_Operator;
    }

    public SetField(java.lang.String f_ComponentName, java.lang.String f_Operator) {
        ComponentName = f_ComponentName;
        Operator = f_Operator;
    }
}
