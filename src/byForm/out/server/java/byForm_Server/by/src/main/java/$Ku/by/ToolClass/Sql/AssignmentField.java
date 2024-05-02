package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
public class AssignmentField extends $Ku.by.ToolClass.Sql.AbstractSelectField {
    public java.lang.String LocalVariable;
    public $Ku.by.ToolClass.Sql.AbstractSelectField Field;
    public java.lang.String decKuName;

    public AssignmentField(java.lang.String f_LocalVariable, java.lang.String f_DecKuName, $Ku.by.ToolClass.Sql.AbstractSelectField f_Field) {
        LocalVariable = f_LocalVariable;
        Field = f_Field;
        decKuName = f_DecKuName;
    }


    @Override
    public java.lang.String getAlias() {
        return null;
    }

    @Override
    public void setAlias(java.lang.String value) {
        ThrowHelper.ThrowSqlPreCompileException("");
    }

    @Override
    public $Ku.by.ToolClass.Sql.AbstractTable getFieldTable() {
        return null;
    }

    @Override
    public void setFieldTable($Ku.by.ToolClass.Sql.AbstractTable value) {
        ThrowHelper.ThrowSqlPreCompileException("");
    }

    @Override
    public java.lang.String getFieldAccess() {
        throw ThrowHelper.ThrowSqlPreCompileException("");
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        throw ThrowHelper.ThrowSqlPreCompileException("");
    }
}
