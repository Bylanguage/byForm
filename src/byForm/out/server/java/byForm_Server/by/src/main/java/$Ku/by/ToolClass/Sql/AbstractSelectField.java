package $Ku.by.ToolClass.Sql;

public abstract class AbstractSelectField {
    public $Ku.by.ToolClass.DataTypeEnum FieldType = $Ku.by.ToolClass.DataTypeEnum.values()[0];
    public java.lang.Class<?> EnumType;

    public abstract java.lang.String getAlias()  ;
    public abstract void setAlias(java.lang.String value)  ;
    public abstract $Ku.by.ToolClass.Sql.AbstractTable getFieldTable()  ;
    public abstract void setFieldTable($Ku.by.ToolClass.Sql.AbstractTable value)  ;
    public abstract java.lang.String getFieldAccess()  ;
    public abstract java.lang.String getSelectItemDeclare()  ;
    public java.lang.String toString() {
        return getFieldAccess();
    }
}
