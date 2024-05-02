package $Ku.by.ToolClass.Sql;

public class UpdateSetValue {
    private $Ku.by.ToolClass.Sql.SqlField privateSetField;
    private Object privateValue;
    private java.lang.String privateOperator;

    public UpdateSetValue($Ku.by.ToolClass.Sql.SqlField f_Field, Object f_Value, java.lang.String f_Operator) {
        this.setSetField(f_Field);
        this.setValue(f_Value);
        this.setOperator(f_Operator);
    }


    public final $Ku.by.ToolClass.Sql.SqlField getSetField() {
        return privateSetField;
    }

    public void setSetField($Ku.by.ToolClass.Sql.SqlField value) {
        privateSetField = value;
    }

    public final Object getValue() {
        return privateValue;
    }

    public void setValue(Object value) {
        privateValue = value;
    }

    public final java.lang.String getOperator() {
        return privateOperator;
    }

    public void setOperator(java.lang.String Operator) {
        privateOperator = Operator;
    }
}
