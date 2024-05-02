package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
public class RowNumberField extends AbstractSelectField {
    private java.lang.String privateAlias;
    private $Ku.by.ToolClass.Sql.AbstractTable privateFieldTable;

    @Override
    public java.lang.String getAlias() {
        return privateAlias;
    }

    @Override
    public void setAlias(java.lang.String value) {
        privateAlias = value;
    }

    @Override
    public $Ku.by.ToolClass.Sql.AbstractTable getFieldTable() {
        return privateFieldTable;
    }

    @Override
    public void setFieldTable($Ku.by.ToolClass.Sql.AbstractTable value) {
        privateFieldTable = value;
    }

    @Override
    public java.lang.String getFieldAccess() {
        if (this.getAlias() == null){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("limit专属字段没有别名");
        }
        return this.getAlias();
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        if (this.getAlias() == null){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("limit专属字段没有别名");
        }
        return "ROW_NUMBER()over(order by GETDATE()) " + this.getAlias();
    }
}
