package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.ErrorInfo;
public class FuncField extends AbstractSelectField {
    public $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.DBTypeEnum.values()[0];
    public $Ku.by.ToolClass.FunctionEnum AggregateFunction = $Ku.by.ToolClass.FunctionEnum.values()[0];
    private java.lang.String privateAlias;
    private $Ku.by.ToolClass.Sql.AbstractTable privateFieldTable;
    private java.lang.String privateFuncName;
    private java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> privateParams;

    public FuncField(java.lang.String f_FuncName, $Ku.by.ToolClass.DataTypeEnum f_Type, java.lang.String f_DecKuName, $Ku.by.ToolClass.DBTypeEnum f_ExecuteDBType) {
        this.tmpDB = f_ExecuteDBType;
        switch (f_FuncName.toUpperCase())
        {
            case "AVG":
                this.AggregateFunction = FunctionEnum.AVG;
                break;
            case "SUM":
                this.AggregateFunction = FunctionEnum.SUM;
                break;
            case "MIN":
                this.AggregateFunction = FunctionEnum.MIN;
                break;
            case "COUNT":
                this.AggregateFunction = FunctionEnum.COUNT;
                break;
            case "MAX":
                this.AggregateFunction = FunctionEnum.MAX;
                break;
            default:
                this.AggregateFunction = $Ku.by.ToolClass.FunctionEnum.NONE;
                break;
        }

        if (f_DecKuName != null)
        {
            DBTypeEnum tmpDBType;

            if (!$Ku.by.ToolClass.Root.GetInstance().KuTypeDic.containsKey(f_DecKuName))
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_DecKuName));
            }
            tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(f_DecKuName);
            if (tmpDBType != f_ExecuteDBType)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format($Ku.by.ToolClass.ErrorInfo.DBMethodInvocationError, f_FuncName));
            }
        }
        this.FieldType = f_Type;
        this.setFuncName(f_FuncName);
        this.setParams(new java.util.ArrayList<>());
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

        StringBuilder tmpReturnValue = new StringBuilder();
        tmpReturnValue.append(this.getFuncName());
        tmpReturnValue.append("(");
        for (int i = 0; i < this.getParams().size(); i++)
        {
            if (i != 0)
            {
                if(this.getParams().get(i) instanceof AbstractOracleLiteralField ||  this.getParams().get(i-1) instanceof AbstractOracleLiteralField){
                    tmpReturnValue.append(" ");
                }
                else{
                    tmpReturnValue.append(", ");
                }
            }
            AbstractSelectField tmpItem = this.getParams().get(i);
            tmpReturnValue.append(tmpItem.getFieldAccess());
        }
        tmpReturnValue.append(")");
        return tmpReturnValue.toString();
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        StringBuilder tmpReturnValue = new StringBuilder();
        tmpReturnValue.append(this.getFuncName());
        tmpReturnValue.append("(");
        for (int i = 0; i < this.getParams().size(); i++)
        {
            if (i != 0)
            {
                if(this.getParams().get(i) instanceof AbstractOracleLiteralField ||  this.getParams().get(i-1) instanceof AbstractOracleLiteralField){
                    tmpReturnValue.append(" ");
                }
                else {
                    tmpReturnValue.append(", ");
                }
            }

            AbstractSelectField tmpItem = this.getParams().get(i);
            tmpReturnValue.append(tmpItem.getFieldAccess());
        }
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

    public final java.lang.String getFuncName() {
        return privateFuncName;
    }

    public final void setFuncName(java.lang.String value) {
        privateFuncName = value;
    }

    public final java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> getParams() {
        return privateParams;
    }

    public final void setParams(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> value) {
        privateParams = value;
    }

    public void GenerateType() {
        if (this.AggregateFunction != $Ku.by.ToolClass.FunctionEnum.NONE)
            {
                if (this.AggregateFunction == $Ku.by.ToolClass.FunctionEnum.COUNT)
                {
                    this.FieldType = DataTypeEnum.Int;
                    return;
                }

                AbstractSelectField tmpParam = this.getParams().get(0);
                this.FieldType = tmpParam.FieldType;
            }
    }
}
