package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.Exceptions.SqlPreCompileException;
public class SelectField extends AbstractSelectField {
    public java.lang.String Alias;
    public $Ku.by.ToolClass.Sql.AbstractTable FieldTable;
    public java.lang.String Name;
    public $Ku.by.ToolClass.Sql.AbstractSelectField ActualField;

    public SelectField(java.lang.String f_SelectName, $Ku.by.ToolClass.Sql.AbstractSelectField f_Field, $Ku.by.ToolClass.Sql.SelectTable fieldTable) {
        this.FieldTable = fieldTable;
        this.Name = f_SelectName;
        this.ActualField = f_Field;
        this.FieldType = f_Field.FieldType;
    }


    @Override
    public java.lang.String getAlias() {
        return this.Alias;
    }

    @Override
    public void setAlias(java.lang.String value) {
        this.Alias=value;
    }

    @Override
    public $Ku.by.ToolClass.Sql.AbstractTable getFieldTable() {
        return FieldTable;
    }

    @Override
    public void setFieldTable($Ku.by.ToolClass.Sql.AbstractTable value) {
        FieldTable = value;
    }

    @Override
    public java.lang.String getFieldAccess() {
        if (this.FieldTable.getAlias() == null) {
            throw new SqlPreCompileException("子查询做表源未标记别名");
        }
        $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(FieldTable.GetSource().getKuName());
        StringBuilder tmpValue = new StringBuilder();
        switch (tmpDB) {
            case SqlServer:
                tmpValue.append("[").append(this.FieldTable.getAlias()).append("]");
                break;
            case Mysql:
                tmpValue.append("`").append(this.FieldTable.getAlias()).append("`");
                break;
            case Oracle:
                tmpValue.append("\"").append(this.FieldTable.getAlias()).append("\"");
                break;
            default:
                throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError);
        }
        tmpValue.append(".");
        if (this.Alias != null) {
            switch (tmpDB) {
                case SqlServer:
                    tmpValue.append("[").append(this.Alias).append("]");
                    break;
                case Mysql:
                    tmpValue.append("`").append(this.Alias).append("`");
                    break;
                case Oracle:
                    tmpValue.append("\"").append(this.Alias).append("\"");
                    break;
                default:
                    throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError);
            }
        } else {
            switch (tmpDB) {
                case SqlServer:
                    tmpValue.append("[").append(this.Name).append("]");
                    break;
                case Mysql:
                    tmpValue.append("`").append(this.Name).append("`");
                    break;
                case Oracle:
                    tmpValue.append("\"").append(this.Name).append("\"");
                    break;
                default:
                    throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError);
            }
        }
        return tmpValue.toString();
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        if (this.FieldTable.getAlias() == null) {
            throw new SqlPreCompileException("子查询做表源未标记别名");
        }
        $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(FieldTable.GetSource().getKuName());
        StringBuilder tmpValue = new StringBuilder();
        switch (tmpDB) {
            case SqlServer:
                tmpValue.append("[").append(this.FieldTable.getAlias()).append("]");
                tmpValue.append(".");
                tmpValue.append("[").append(this.Name).append("]");
                break;
            case Mysql:
                tmpValue.append("`").append(this.FieldTable.getAlias()).append("`");
                tmpValue.append(".");
                tmpValue.append("`").append(this.Name).append("`");
                break;
            case Oracle:
                tmpValue.append("\"").append(this.FieldTable.getAlias()).append("\"");
                tmpValue.append(".");
                tmpValue.append("\"").append(this.Name).append("\"");
                break;
            default:
                throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError);
        }
        if (this.Alias != null) {
            switch (tmpDB) {
                case SqlServer:
                    tmpValue.append(" ").append("[").append(this.getAlias()).append("]");
                    break;
                case Mysql:
                    tmpValue.append(" ").append("`").append(this.getAlias()).append("`");
                    break;
                case Oracle:
                    tmpValue.append(" ").append("\"").append(this.getAlias()).append("\"");
                    break;
                default:
                    throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError);
            }
        }
        return tmpValue.toString();
    }
}
