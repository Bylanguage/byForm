package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
import $Ku.by.ToolClass.ErrorInfo;
public class BinaryOperationField extends AbstractSelectField {
    private java.lang.String privateAlias;
    private $Ku.by.ToolClass.Sql.AbstractTable privateFieldTable;
    private java.lang.String privateOperator;
    private $Ku.by.ToolClass.Sql.AbstractSelectField privateLeft;
    private $Ku.by.ToolClass.Sql.AbstractSelectField privateRight;

    public BinaryOperationField($Ku.by.ToolClass.Sql.AbstractSelectField f_Left, $Ku.by.ToolClass.Sql.AbstractSelectField f_Right, java.lang.String f_Operator) {
        this.setLeft(f_Left);
        this.setRight(f_Right);
        this.setOperator(f_Operator);
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
            return this.getFieldTable().getAlias() + "." + this.getAlias();
        }
        else
        {
            StringBuilder tmpReturn = new StringBuilder();
            $Ku.by.ToolClass.Sql.AbstractSelectField tempVar = this.getLeft();

            AbstractSelectField tmpLeftField = (AbstractSelectField)((tempVar instanceof AbstractSelectField) ? tempVar : null);
            tmpReturn.append(tmpLeftField.getFieldAccess());
            tmpReturn.append(" ");
            tmpReturn.append(this.getOperator());
            tmpReturn.append(" ");
            $Ku.by.ToolClass.Sql.AbstractSelectField tempVar2 = this.getRight();

            AbstractSelectField tmpRightField = (AbstractSelectField)((tempVar2 instanceof AbstractSelectField) ? tempVar2 : null);
            tmpReturn.append(tmpRightField.getFieldAccess());
            return tmpReturn.toString();
        }
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(privateFieldTable.GetSource().getKuName());
        if (this.getOperator() == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.OperatorIsNull);
        }
        StringBuilder tmpReturnValue = new StringBuilder();
        $Ku.by.ToolClass.Sql.AbstractSelectField tempVar = this.getLeft();

        AbstractSelectField tmpLeft = (AbstractSelectField)((tempVar instanceof AbstractSelectField) ? tempVar : null);
        tmpReturnValue.append(tmpLeft.getFieldAccess());
        tmpReturnValue.append(" ");
        tmpReturnValue.append(this.getOperator());
        tmpReturnValue.append(" ");
        $Ku.by.ToolClass.Sql.AbstractSelectField tempVar2 = this.getRight();

        AbstractSelectField tmpRight = (AbstractSelectField)((tempVar2 instanceof AbstractSelectField) ? tempVar2 : null);
        tmpReturnValue.append(tmpRight.getFieldAccess());
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

    public final java.lang.String getOperator() {
        return privateOperator;
    }

    public final void setOperator(java.lang.String value) {
        privateOperator = value;
    }

    public final $Ku.by.ToolClass.Sql.AbstractSelectField getLeft() {
        return privateLeft;
    }

    public final void setLeft($Ku.by.ToolClass.Sql.AbstractSelectField value) {
        privateLeft = value;
    }

    public final $Ku.by.ToolClass.Sql.AbstractSelectField getRight() {
        return privateRight;
    }

    public final void setRight($Ku.by.ToolClass.Sql.AbstractSelectField value) {
        privateRight = value;
    }
}
