package $Ku.by.Object;

import $Ku.by.ToolClass.Sql.*;
import $Ku.by.ToolClass.*;
import java.util.Objects;
public class Cell extends $Ku.by.Object.ByObject {
    public java.lang.String alias;
    public java.lang.String ColumnName;
    public $Ku.by.Object.Field cellField;
    public java.lang.Class<?> EnumType;
    public $Ku.by.ToolClass.DataTypeEnum DataTypeEnum = $Ku.by.ToolClass.DataTypeEnum.values()[0];
    public java.lang.String AggregateFunctionName;
    public java.lang.String SheetName;
    public java.lang.String KuName;
    public Object value;
    public $Ku.by.Object.Row row;

    public Cell() {
        this.value = new Object();
    }


    public $Ku.by.Object.Field field() {
        return cellField;
    }

    @Override
    public java.lang.String toString() {
        StringBuilder tmpValue = new StringBuilder();
        tmpValue.append(this.GetColumnName());
        if (this.value == null) {
            tmpValue.append(" : NULL");
        } else {
            tmpValue.append(" = ");
            tmpValue.append(this.value);
        }
        return tmpValue.toString();
    }

    public $Ku.by.Object.Cell CopyValue() {
        $Ku.by.Object.Cell tmpCell = new $Ku.by.Object.Cell();
        if (tmpCell.value instanceof $Ku.by.Object.Datetime)
        {
            tmpCell.value = $Ku.by.Object.Datetime.ConvertToDatetime(tmpCell.value);
        }
            else
        {
            tmpCell.value = value;
        }
        tmpCell.alias = alias;
        tmpCell.cellField = cellField;
        tmpCell.ColumnName = ColumnName;
        tmpCell.AggregateFunctionName = AggregateFunctionName;
        tmpCell.SheetName = SheetName;
        tmpCell.KuName = KuName;
        tmpCell.DataTypeEnum = DataTypeEnum;
        tmpCell.EnumType = EnumType;
        return tmpCell;
    }

    public void MatchField($Ku.by.ToolClass.Sql.AbstractSelectField f_Field) {
        String tmpPattern = "#TmpName\\d+";
        if (f_Field.getAlias() != null && !java.util.regex.Pattern.matches(tmpPattern, f_Field.getAlias()))
        {
            this.KuName = null;
            this.SheetName = null;
            this.alias = f_Field.getAlias();
            this.ColumnName = f_Field.getAlias();
            this.DataTypeEnum = f_Field.FieldType;
            this.EnumType = f_Field.EnumType;
            this.cellField = null;
            return;
        }

        if (f_Field instanceof LiteralField)
        {
            this.DataTypeEnum = f_Field.FieldType;
            if (this.DataTypeEnum == $Ku.by.ToolClass.DataTypeEnum.Enum)
            {
                this.EnumType = f_Field.EnumType;
            }

            this.cellField = null;
            return;
        }

        if (f_Field instanceof BinaryOperationField)
        {
            BinaryOperationField tmpBinaryOperationField =(BinaryOperationField) f_Field;
            this.KuName = null;
            this.SheetName = null;
            this.ColumnName = tmpBinaryOperationField.FieldType.toString().toLowerCase(); ;
            this.DataTypeEnum = tmpBinaryOperationField.FieldType;
            this.cellField = null;
            return;
        }

        if (f_Field instanceof FuncField)
        {
            FuncField tmpFuncField = (FuncField)f_Field ;
            if (tmpFuncField.AggregateFunction != $Ku.by.ToolClass.FunctionEnum.NONE)
            {
                if (tmpFuncField.getParams().size() != 1)
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("系统错误，非法聚合函数");
                }

                if (tmpFuncField.getParams().get(0) instanceof TableField)
                {
                    TableField tmpTableField = (TableField)tmpFuncField.getParams().get(0);
                    this.KuName = tmpTableField.getSelectedField().getKuName();
                    this.SheetName = tmpTableField.getSelectedField().getSheetName();
                    this.ColumnName = tmpTableField.getSelectedField().getName();
                    this.AggregateFunctionName = tmpFuncField.AggregateFunction.toString();
                    this.DataTypeEnum = tmpTableField.getSelectedField().getFieldType();
                    this.EnumType = tmpTableField.getSelectedField().getEnumType();
                }
                else
                {
                    this.ColumnName = f_Field.FieldType.toString().toLowerCase();
                    this.DataTypeEnum = f_Field.FieldType;
                    if (this.DataTypeEnum == $Ku.by.ToolClass.DataTypeEnum.Enum)
                    {
                        this.EnumType = f_Field.EnumType;
                    }
                }
            }
            else
            {
                this.KuName = null;
                this.SheetName = null;
                this.ColumnName = tmpFuncField.FieldType.toString().toLowerCase();
                this.DataTypeEnum = tmpFuncField.FieldType;
                if (this.DataTypeEnum == $Ku.by.ToolClass.DataTypeEnum.Enum)
                {
                    this.EnumType = tmpFuncField.EnumType;
                }
            }

            this.cellField = null;
            return;
        }

        if (f_Field instanceof ParenthesesField)
        {
            ParenthesesField tmpParenthesesField = (ParenthesesField)f_Field;
            this.cellField = null;
            this.DataTypeEnum = tmpParenthesesField.FieldType;
            //this.MatchField(tmpParenthesesField.Value);
            return;
        }

        if (f_Field instanceof SelectField)
        {
            SelectField tmpSelectField = (SelectField)f_Field;
            this.MatchField(tmpSelectField.ActualField);
            return;
        }

        if (f_Field instanceof TableField)
        {
            TableField tmpTableField = (TableField)f_Field;
            this.KuName = tmpTableField.getSelectedField().getKuName();
            this.SheetName = tmpTableField.getSelectedField().getSheetName();
            this.ColumnName = tmpTableField.getSelectedField().getName();
            this.DataTypeEnum = tmpTableField.getSelectedField().getFieldType();
            this.EnumType = tmpTableField.getSelectedField().getEnumType();
            $Ku.by.Object.Table tmpDataSheet = ($Ku.by.Object.Table)tmpTableField.getFieldTable().GetSource();
            cellField = tmpDataSheet.getField(ColumnName);
            return;
        }

        if (f_Field instanceof UnaryField)
        {
            UnaryField tmpUnaryField = (UnaryField)f_Field;
            this.MatchField(tmpUnaryField.getOperatorField());
        }
    }

    public void checkValue() {
        if(this.value != null && this.value instanceof java.math.BigDecimal && this.DataTypeEnum != null){
            java.math.BigDecimal bigDecimal = (java.math.BigDecimal) value;
            switch (this.DataTypeEnum){
                case Int:
                    this.value = bigDecimal.intValue();
                    break;
                case Decimal:
                    this.value = new $Ku.by.Object.Decimal(bigDecimal);
                    break;
                case Bool:
                    this.value = bigDecimal.intValue() != 0;
                    break;
                case Byte:
                    this.value = bigDecimal.byteValue();
                    break;
                case Short:
                    this.value = bigDecimal.shortValue();
                    break;
                case Long:
                    this.value = bigDecimal.longValue();
                    break;
                case Float:
                    this.value = bigDecimal.floatValue();
                    break;
                case Double:
                    this.value = bigDecimal.doubleValue();
                    break;
            }
        }
    }

    public final java.lang.String getSheetName() {
        return SheetName;
    }

    public void setSheetName(java.lang.String value) {
        SheetName = value;
    }

    public final java.lang.String getKuName() {
        return KuName;
    }

    public void setKuName(java.lang.String value) {
        KuName = value;
    }

    public java.lang.Class<?> GenerateEnumType(java.lang.String f_Value) {
        String[] tmpEnumArray = f_Value.split("\\.");
        String tmpQualifiedName = "$Ku." + tmpEnumArray[0] + ".Enum." + tmpEnumArray[2];
        try {
        return Class.forName(tmpQualifiedName);
        } catch (ClassNotFoundException e) {
        throw new RuntimeException(e);
        }
    }

    public $Ku.by.ToolClass.DataTypeEnum GetDataTypeEnum(java.lang.String f_Type) {
        if (f_Type == null) {
            return $Ku.by.ToolClass.DataTypeEnum.None;
        }

        if (f_Type.contains(".")) {
            //枚举
            if (f_Type.split("\\.").length == 3) {
                return $Ku.by.ToolClass.DataTypeEnum.Enum;
            }
        }

        if (f_Type.equals("double")) {
            return $Ku.by.ToolClass.DataTypeEnum.Double;
        }

        if (f_Type.equals("string")) {
            return $Ku.by.ToolClass.DataTypeEnum.String;
        }

        if (Objects.equals(f_Type, "short")) {
            return $Ku.by.ToolClass.DataTypeEnum.Short;
        }

        if (Objects.equals(f_Type, "int")) {
            return $Ku.by.ToolClass.DataTypeEnum.Int;
        }

        if (Objects.equals(f_Type, "long")) {
            return $Ku.by.ToolClass.DataTypeEnum.Long;
        }

        if (Objects.equals(f_Type, "float")) {
            return $Ku.by.ToolClass.DataTypeEnum.Float;
        }

        if (Objects.equals(f_Type, "decimal")) {
            return $Ku.by.ToolClass.DataTypeEnum.Decimal;
        }

        if (Objects.equals(f_Type, "bool")) {
            return $Ku.by.ToolClass.DataTypeEnum.Bool;
        }

        if (Objects.equals(f_Type, "byte")) {
            return $Ku.by.ToolClass.DataTypeEnum.Byte;
        }

        return $Ku.by.ToolClass.DataTypeEnum.None;
    }

    public void AssembleField(java.lang.String f_KuName, java.lang.String f_SheetName, java.lang.String f_ColumnName) {
        try
        {
            $Ku.by.Object.Table tmpTable = ($Ku.by.Object.Table)$Ku.by.ToolClass.Root.GetInstance().KuDic.get(f_KuName).DataSheetDic.get(f_SheetName);
            $Ku.by.Object.Field tmpField = tmpTable.getField(f_ColumnName);
            KuName = f_KuName;
            SheetName= f_SheetName;
            ColumnName= f_ColumnName;
            this.cellField = tmpField;
        }
        catch (java.lang.Exception e)
        {
            KuName = null;
            SheetName = null;
            ColumnName = null;
            this.cellField = null;
        }
    }

    public void AssembleField($Ku.by.Object.Field f_Field) {
        $Ku.by.ToolClass.Sql.SqlField tmpField = f_Field.Field;
        KuName = tmpField.getKuName();
        SheetName = tmpField.getSheetName();
        ColumnName = tmpField.getName();
        this.cellField = f_Field;
    }

    public java.lang.String GetColumnName() {
        StringBuilder tmpValue = new StringBuilder();
        if (this.AggregateFunctionName != null) {
            tmpValue.append(this.AggregateFunctionName);
            tmpValue.append("(");
            tmpValue.append(this.KuName);
            tmpValue.append(".");
            tmpValue.append(this.SheetName);
            tmpValue.append(".");
            tmpValue.append(this.ColumnName);
            tmpValue.append(")");
        } else {
            if (this.KuName != null && this.SheetName != null) {
                tmpValue.append(this.KuName);
                tmpValue.append(".");
                tmpValue.append(this.SheetName);
                tmpValue.append(".");
                tmpValue.append(this.ColumnName);
            } else {
                tmpValue.append(this.ColumnName);
            }
        }
        return tmpValue.toString();
    }
}
