package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
import $Ku.by.ToolClass.ErrorInfo;
public class AsteriskField extends AbstractSelectField implements IFields  {
    private $Ku.by.ToolClass.Sql.AbstractTable privateFieldTable;
    private java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> privateFieldList;

    public AsteriskField(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_FieldList, $Ku.by.ToolClass.Sql.AbstractTable f_Table) {
        this.setFieldList(f_FieldList);
        this.setFieldTable(f_Table);
    }

    public AsteriskField() {
        this.setFieldList(null);
        this.setFieldTable(null);
    }


    @Override
    public java.lang.String getAlias() {
        return null;
    }

    @Override
    public void setAlias(java.lang.String value) {
        throw new RuntimeException("无法设置别名");
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
        return "*";
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        StringBuilder tmpValue = new StringBuilder();

        for (AbstractSelectField item : this.privateFieldList) {
            if (tmpValue.length() != 0) {
                tmpValue.append(", ");
            }

            if (item.getFieldTable() instanceof SqlTable) {
                tmpValue.append(item.getSelectItemDeclare());
            } else {
                tmpValue.append(item.getFieldAccess());
            }
        }

        return tmpValue.toString();
    }

    public final java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> getFieldList() {
        return privateFieldList;
    }

    public final void setFieldList(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> value) {
        privateFieldList = value;
    }

    public final int getFieldCount() {
        int tmpCount = 0;


        for (AbstractSelectField item : this.getFieldList())
        {
            if (item instanceof IFields)
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("字段填充错误");
            }
            else
            {
                tmpCount++;
            }
        }
        return tmpCount;
    }
}
