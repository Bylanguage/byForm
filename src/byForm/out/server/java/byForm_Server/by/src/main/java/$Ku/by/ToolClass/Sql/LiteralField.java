package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
import $Ku.by.ToolClass.DataTypeEnum;
import $Ku.by.ToolClass.ErrorInfo;
public class LiteralField extends AbstractSelectField {
    public $Ku.by.ToolClass.DBTypeEnum tmpDB = $Ku.by.ToolClass.DBTypeEnum.values()[0];
    private java.lang.String privateAlias;
    private $Ku.by.ToolClass.Sql.AbstractTable privateFieldTable;
    private java.lang.String privateLiteral;

    public LiteralField(java.lang.String f_Literal) {
        this.setLiteral(f_Literal);
    }

    public LiteralField(long f_Literal) {
        this.setLiteral(String.valueOf(f_Literal));
    }

    public LiteralField(java.lang.String f_Literal, java.lang.String f_Type) {
        this.setLiteral(f_Literal);
        if(f_Type.contains("DataTypeEnum")){
            f_Type = f_Type.split("\\.")[1];
        }
        this.FieldType = DataTypeEnum.valueOf(f_Type);
    }

    public LiteralField(long f_Literal, java.lang.String f_Type) {
        this.setLiteral(String.valueOf(f_Literal));
        if(f_Type.contains("DataTypeEnum")){
            f_Type = f_Type.split("\\.")[1];
        }
        this.FieldType = DataTypeEnum.valueOf(f_Type);
    }

    public LiteralField(double f_Literal, java.lang.String f_Type) {
        this.setLiteral(String.valueOf(f_Literal));
        if(f_Type.contains("DataTypeEnum")){
            f_Type = f_Type.split("\\.")[1];
        }
        this.FieldType = DataTypeEnum.valueOf(f_Type);
    }

    public LiteralField(float f_Literal, java.lang.String f_Type) {
        this.setLiteral(String.valueOf(f_Literal));
        if(f_Type.contains("DataTypeEnum")){
            f_Type = f_Type.split("\\.")[1];
        }
        this.FieldType = DataTypeEnum.valueOf(f_Type);
    }

    public LiteralField($Ku.by.Object.Decimal f_Literal, java.lang.String f_Type) {
        this.setLiteral(f_Literal.toString());
        if(f_Type.contains("DataTypeEnum")){
            f_Type = f_Type.split("\\.")[1];
        }
        this.FieldType = DataTypeEnum.valueOf(f_Type);
    }

    public LiteralField(Object f_Literal, $Ku.by.ToolClass.DataTypeEnum f_Type) {
        this.setLiteral(f_Literal.toString());
        this.FieldType = f_Type;
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
        if (this.getFieldTable() != null) {
            if (this.getFieldTable().getAlias() == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.ColumnWithoutAlias);
            }

            if (this.getAlias() == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.ColumnWithoutAlias);
            }
            switch (tmpDB) {
                case SqlServer:
                    return "[" + this.getFieldTable().getAlias() + "]" + "." + "[" + this.getAlias() + "]";
                case Mysql:
                    return "`" + this.getFieldTable().getAlias() + "`.`" + this.getAlias() + "`";
                case Oracle:
                    return "\"" + this.getFieldTable().getAlias() + "\"" + "." + "\"" + this.getAlias() + "\"";
                default:
                    throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
            }
        }

        return this.privateLiteral == null ? "NULL" : this.privateLiteral;
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        StringBuilder tmpReturnValue = new StringBuilder();
        if (this.privateLiteral == null) {
            tmpReturnValue.append("NULL");
        } else {
            tmpReturnValue.append(this.privateLiteral);
        }
        if (this.getAlias() != null) {
            switch (tmpDB) {
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
                    throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
            }
        }
        return tmpReturnValue.toString();
    }

    public final java.lang.String getLiteral() {
        return privateLiteral;
    }

    public final void setLiteral(java.lang.String value) {
        privateLiteral = value;
    }
}
