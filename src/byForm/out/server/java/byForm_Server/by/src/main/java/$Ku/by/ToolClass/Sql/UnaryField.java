package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
import $Ku.by.ToolClass.ErrorInfo;
public class UnaryField extends $Ku.by.ToolClass.Sql.AbstractSelectField {
    private java.lang.String Alias;
    private $Ku.by.ToolClass.Sql.AbstractTable FieldTable;
    private $Ku.by.ToolClass.Sql.AbstractSelectField OperatorField;
    private java.lang.String Operator;

    public UnaryField(java.lang.String f_Operator, $Ku.by.ToolClass.Sql.AbstractSelectField f_Field) {
        this.setOperator(f_Operator);
        this.setOperatorField(f_Field);
    }


    public java.lang.String getSelectItemDeclare() {
        if (this.Operator == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.OperatorIsNull);
        }

        if (this.OperatorField == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.OperatorFieldIsNull);
        }
        $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(FieldTable.GetSource().getKuName());
        StringBuilder tmpReturnValue = new StringBuilder();
        tmpReturnValue.append(this.Operator);
        tmpReturnValue.append(this.OperatorField.getFieldAccess());
        if (this.Alias != null)
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

    public java.lang.String getAlias() {
        return Alias;
    }

    public void setAlias(java.lang.String value) {
        Alias = value;
    }

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

            return this.getFieldTable().getAlias() + "." + this.getAlias();
        }

        return this.getOperator() + this.getOperatorField().getFieldAccess();
    }

    public $Ku.by.ToolClass.Sql.AbstractTable getFieldTable() {
        return FieldTable;
    }

    public void setFieldTable($Ku.by.ToolClass.Sql.AbstractTable value) {
        FieldTable = value;
    }

    public $Ku.by.ToolClass.Sql.AbstractSelectField getOperatorField() {
        return OperatorField;
    }

    public void setOperatorField($Ku.by.ToolClass.Sql.AbstractSelectField value) {
        OperatorField = value;
    }

    public java.lang.String getOperator() {
        return Operator;
    }

    public void setOperator(java.lang.String value) {
        Operator = value;
    }
}
