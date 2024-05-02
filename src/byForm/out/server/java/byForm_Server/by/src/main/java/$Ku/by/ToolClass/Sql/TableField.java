package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
public class TableField extends AbstractSelectField {
    private java.lang.String privateAlias;
    private java.lang.Boolean IsPlusField = false;
    private $Ku.by.ToolClass.Sql.AbstractTable privateFieldTable;
    private $Ku.by.ToolClass.Sql.SqlField privateSelectedField;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public TableField($Ku.by.ToolClass.Sql.SqlField f_Field, $Ku.by.ToolClass.Sql.SqlTable f_Table, java.lang.String f_Alias) {
        this.setSelectedField(f_Field);
        this.setFieldTable(f_Table);
        this.setAlias(f_Alias);
        this.FieldType = f_Field.getFieldType();
        if (!f_Table.getKuName().equals(f_Field.getKuName()))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format("系统错误->创建sql字段 %1$s 出错！库不一致", f_Field.getName()));
        }
    }

    public TableField($Ku.by.ToolClass.Sql.SqlField f_Field, $Ku.by.ToolClass.Sql.SelectTable f_Table, java.lang.String f_Alias) {
        this.setSelectedField(f_Field);
        this.setFieldTable(f_Table);
        this.setAlias(f_Alias);
        this.FieldType = f_Field.getFieldType();
    }

    public TableField() {
        
    }


    public static $Ku.by.ToolClass.Sql.TableField GetPlusTableField($Ku.by.ToolClass.Sql.SqlField f_Field, $Ku.by.ToolClass.Sql.SqlTable f_Table) {
        TableField tmpTableField = new TableField();
        tmpTableField.setSelectedField(f_Field);
        tmpTableField.setFieldTable(f_Table);
        tmpTableField.FieldType = f_Field.getFieldType();
        tmpTableField.EnumType = f_Field.getEnumType();
        tmpTableField.IsPlusField = true;

        if (f_Field.getKuName() != f_Table.getKuName())
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format("系统错误->创建sql字段 %s 出错！库不一致", f_Field.getName()));
        }

        return tmpTableField;
    }

    @Override
    public java.lang.String getAlias() {
        return privateAlias;
    }

    @Override
    public void setAlias(java.lang.String value) {
        privateAlias = value;
        if (privateAlias != null && !IsPlusField)
        {
            privateSelectedField = privateSelectedField.CopyWithoutSheet();
        }
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
        String tmpKuName = this.privateFieldTable.GetSource().getKuName();
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (this.getFieldTable() == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("系统错误->空的字段的表源");
        }
        StringBuilder tmpReturnValue = new StringBuilder();
        $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        tmpReturnValue.append(this.getFieldTable().getTableAccess());
        tmpReturnValue.append(".");
        if (this.getAlias() != null) {
            switch (tmpDB) {
                case SqlServer:
                    tmpReturnValue.append("[").append(this.getAlias()).append("]");
                    break;
                case Mysql:
                    tmpReturnValue.append("`").append(this.getAlias()).append("`");
                    break;
                case Oracle:
                    tmpReturnValue.append("\"").append(this.getAlias()).append("\"");
                    break;
                default:
                    throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError);
            }
        } else {
            if(tmpDBType == $Ku.by.ToolClass.DBTypeEnum.SqlServer){
                tmpReturnValue.append("[");
                tmpReturnValue.append(this.getSelectedField().getName());
                tmpReturnValue.append("]");
            }
            else if(tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Mysql) {
                tmpReturnValue.append("`");
                tmpReturnValue.append(this.getSelectedField().getName());
                tmpReturnValue.append("`");
            } else if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Oracle) {
                tmpReturnValue.append("\"");
                tmpReturnValue.append(this.getSelectedField().getName());
                tmpReturnValue.append("\"");
            } else {
                tmpReturnValue.append(this.getSelectedField().getName());
            }

        }

        return tmpReturnValue.toString();
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        if (this.getFieldTable() == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("系统错误->表字段表没填充");
        }
        StringBuilder tmpReturnValue = new StringBuilder();
        String tmpKuName = this.privateFieldTable.GetSource().getKuName();
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        tmpReturnValue.append(this.getFieldTable().getTableAccess() + ".");
        if(tmpDBType == $Ku.by.ToolClass.DBTypeEnum.SqlServer){
            tmpReturnValue.append("[");
            tmpReturnValue.append(this.getSelectedField().getName());
            tmpReturnValue.append("]");
        }
        else if(tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Mysql) {
            tmpReturnValue.append("`");
            tmpReturnValue.append(this.getSelectedField().getName());
            tmpReturnValue.append("`");
        } else if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Oracle) {
            tmpReturnValue.append("\"");
            tmpReturnValue.append(this.getSelectedField().getName());
            tmpReturnValue.append("\"");
        } else {
            tmpReturnValue.append(this.getSelectedField().getName());
        }
        if (this.getAlias() != null) {
            switch (tmpDBType) {
                case SqlServer:
                    tmpReturnValue.append(" ").append("[").append(this.getAlias()).append("]");
                    break;
                case Mysql:
                    tmpReturnValue.append(" ").append("`").append(this.getAlias()).append("`");
                    break;
                case Oracle:
                    tmpReturnValue.append(" ").append("\"").append(this.getAlias()).append("\"");
                    break;
                default:
                    throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError);
            }
        }
        return tmpReturnValue.toString();
    }

    public final $Ku.by.ToolClass.Sql.SqlField getSelectedField() {
        return privateSelectedField;
    }

    private void setSelectedField($Ku.by.ToolClass.Sql.SqlField value) {
        privateSelectedField = value;
    }

    public $Ku.by.ToolClass.Sql.SelectTable getSource() {
        return this.Source;
    }

    public void setSource($Ku.by.ToolClass.Sql.SelectTable value) {
        this.Source = value;
    }
}
