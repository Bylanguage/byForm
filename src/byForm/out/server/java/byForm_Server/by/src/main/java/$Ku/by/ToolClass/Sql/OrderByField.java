package $Ku.by.ToolClass.Sql;

public class OrderByField {
    private $Ku.by.ToolClass.Sql.AbstractSelectField privateSourceField;
    private java.lang.String privateOField;
    private boolean privateIsDesc;

    public OrderByField(java.lang.String f_Field, boolean f_IsDesc) {
        this.setOField(f_Field);
        this.setIsDesc(f_IsDesc);
    }

    public OrderByField(java.lang.String f_Field, boolean f_IsDesc, $Ku.by.ToolClass.Sql.AbstractSelectField f_SourceField) {
        this.setOField(f_Field);
        this.setIsDesc(f_IsDesc);
        this.setSourceField(f_SourceField);
    }


    public final $Ku.by.ToolClass.Sql.AbstractSelectField getSourceField() {
        return privateSourceField;
    }

    public void setSourceField($Ku.by.ToolClass.Sql.AbstractSelectField value) {
        privateSourceField = value;
    }

    public final java.lang.String getOField() {
        return privateOField;
    }

    public void setOField(java.lang.String value) {
        privateOField = value;
    }

    public final boolean getIsDesc() {
        return privateIsDesc;
    }

    public void setIsDesc(boolean value) {
        privateIsDesc = value;
    }
}
