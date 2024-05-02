package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
import $Ku.by.ToolClass.ErrorInfo;
public class ParenthesesField extends AbstractSelectField {
    public $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.DBTypeEnum.values()[0];
    private java.lang.String privateAlias;
    private $Ku.by.ToolClass.Sql.AbstractTable privateFieldTable;
    private $Ku.by.ToolClass.Sql.AbstractSelectField privateValue;

    public ParenthesesField($Ku.by.ToolClass.Sql.AbstractSelectField f_Value) {
        this.setValue(f_Value);
    }


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
        if (this.getFieldTable() != null)
        {
            if (this.getFieldTable().getAlias() == null)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.ColumnWithoutAlias);
            }

            if (this.getAlias() == null)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.ColumnWithoutAlias);
            }

            $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(privateFieldTable.GetSource().getKuName());
            switch (tmpDB) {
                case SqlServer:
                case Mysql:
                    return this.getFieldTable().getAlias() + "." + this.getAlias();
                case Oracle:
                    return "\"" + this.getFieldTable().getAlias() + "\"" + "." + "\"" + this.getAlias() + "\"";
                default:
                    throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
            }
        }

        return "(" + this.getValue().getFieldAccess() + ")";
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        StringBuilder tmpReturnValue = new StringBuilder();
        tmpReturnValue.append("(");
        tmpReturnValue.append(this.getValue().getFieldAccess());
        tmpReturnValue.append(")");
        if (this.getAlias() != null)
        {
            switch (tmpDB) {
                case SqlServer:
                case Mysql:
                    tmpReturnValue.append(" " + this.getAlias());
                    break;
                case Oracle:
                    tmpReturnValue.append(" ").append("\"").append(this.getAlias()).append("\"");
                    break;
                default:
                    throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
            }
        }
        return tmpReturnValue.toString();
    }

    public final $Ku.by.ToolClass.Sql.AbstractSelectField getValue() {
        return privateValue;
    }

    public final void setValue($Ku.by.ToolClass.Sql.AbstractSelectField value) {
        privateValue = value;
    }
}
