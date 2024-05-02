using byForm_Server.ku.by.ToolClass.Sql;
using System.Text;
using System;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.by.Object
{
    public class Cell : byForm_Server.ku.by.ToolClass.IIdentity
    {
        private readonly static System.Type charType = typeof(char);

        private readonly static System.Type byteType = typeof(sbyte);

        private readonly static System.Type shortType = typeof(short);

        private readonly static System.Type intType = typeof(int);

        private readonly static System.Type longType = typeof(long);

        private readonly static System.Type floatType = typeof(float);

        private readonly static System.Type doubleType = typeof(double);

        private readonly static System.Type decimalType = typeof(decimal);

        private readonly static System.Type boolType = typeof(bool);

        private readonly static System.Type dateTimeType = typeof(byForm_Server.ku.by.Object.datetime);

        private readonly static System.Type stringType = typeof(string);

        public Cell()
        {
            this._value = new object();
        }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }

        public byForm_Server.ku.by.Object.field field { get; set; }

        public byForm_Server.ku.by.Object.Row row { get; set; }

        public object value
        {
            get
            {
                return _value;
            }
            set
            {
                if (this.field != null)
                {
                    try
                    {
                        if (value == null)
                        {
                            if (this.field.Field.FieldType == DataTypeEnum.String || this.field.Field.FieldType == DataTypeEnum.Datetime)
                            {
                                _value = null;
                                return;
                            }

                            throw new Exception(string.Format(ErrorInfo.CellValueTypeError, "null", DataTypeEnum.ToString()));
                        }

                        var tmpValueType = value.GetType();

                        switch (DataTypeEnum)
                        {
                            case DataTypeEnum.Bool:
                                bool tmpBoolValue = Convert.ToBoolean(value);
                                _value = tmpBoolValue;
                                break;
                            case DataTypeEnum.Byte:
                                sbyte tmpByteValue = Convert.ToSByte(value);
                                _value = tmpByteValue;
                                break;
                            case DataTypeEnum.Char:
                                char tmpCharValue = Convert.ToChar(value);
                                _value = tmpCharValue;
                                break;
                            case DataTypeEnum.Datetime:
                                Object.datetime tmpDatetimeValue = Object.datetime.ConvertToDatetime(value);
                                _value = tmpDatetimeValue;
                                break;
                            case DataTypeEnum.Decimal:
                                decimal tmpDecimalValue = Convert.ToDecimal(value);
                                _value = tmpDecimalValue;
                                break;
                            case DataTypeEnum.Double:
                                double tmpDoubleValue = Convert.ToDouble(value);
                                _value = tmpDoubleValue;
                                break;
                            case DataTypeEnum.Enum:
                                var tmpEnumType = EnumType;
                                if (EnumType != field.Field.EnumType)
                                {
                                    throw new Exception(string.Format(ErrorInfo.CellTypeConvertError, value, EnumType.Name));
                                }
                                var tmpEnumValue = System.Enum.Parse(tmpEnumType, value.ToString(), true);
                                _value = tmpEnumValue;
                                break;
                            case DataTypeEnum.Float:
                                float tmpFloatValue = Convert.ToSingle(value);
                                _value = tmpFloatValue;
                                break;
                            case DataTypeEnum.Int:
                                int tmpIntValue = Convert.ToInt32(value);
                                _value = tmpIntValue;
                                break;
                            case DataTypeEnum.Long:
                                long tmpLongValue = Convert.ToInt64(value);
                                _value = tmpLongValue;
                                break;
                            case DataTypeEnum.Short:
                                short tmpShortValue = Convert.ToInt16(value);
                                _value = tmpShortValue;
                                break;
                            case DataTypeEnum.String:
                                _value = value;
                                break;
                            default:
                                throw new Exception(ErrorInfo.CellValueTypeError);
                        }
                    }
                    catch (Exception ex)
                    {
                        ThrowHelper.ThrowDataMatchException("Cell " + ex.Message);
                    }
                }
                else
                {
                    EnumType = null;
                    if (value == null)
                    {
                        if (DataTypeEnum == DataTypeEnum.String || DataTypeEnum == DataTypeEnum.Datetime)
                        {
                            _value = null;
                            return;
                        }
                        else
                        {
                            throw new Exception(string.Format(ErrorInfo.CellValueTypeError, "null", DataTypeEnum.ToString()));
                        }
                    }

                    var tmpValueType = value.GetType();

                    if (tmpValueType.IsEnum)
                    {
                        DataTypeEnum = DataTypeEnum.Enum;
                        EnumType = tmpValueType;
                    }
                    else if (tmpValueType == boolType)
                    {
                        DataTypeEnum = DataTypeEnum.Bool;
                    }
                    else if (tmpValueType == byteType)
                    {
                        DataTypeEnum = DataTypeEnum.Byte;
                    }
                    else if (tmpValueType == charType)
                    {
                        DataTypeEnum = DataTypeEnum.Char;
                    }
                    else if (tmpValueType == dateTimeType)
                    {
                        DataTypeEnum = DataTypeEnum.Datetime;
                    }
                    else if (tmpValueType == decimalType)
                    {
                        DataTypeEnum = DataTypeEnum.Decimal;
                    }
                    else if (tmpValueType == doubleType)
                    {
                        DataTypeEnum = DataTypeEnum.Double;
                    }
                    else if (tmpValueType == floatType)
                    {
                        DataTypeEnum = DataTypeEnum.Float;
                    }
                    else if (tmpValueType == intType)
                    {
                        DataTypeEnum = DataTypeEnum.Int;
                    }
                    else if (tmpValueType == longType)
                    {
                        DataTypeEnum = DataTypeEnum.Long;
                    }
                    else if (tmpValueType == shortType)
                    {
                        DataTypeEnum = DataTypeEnum.Short;
                    }
                    else if (tmpValueType == stringType)
                    {
                        DataTypeEnum = DataTypeEnum.String;
                    }
                    else
                    {
                        ThrowHelper.ThrowDataMatchException(ErrorInfo.CellValueTypeError);
                    }

                    _value = value;
                }
            }
        }

        private object _value;

        public string ColumnName { get; set; }

        public string SheetName { get; set; }

        public string KuName { get; set; }

        public string Alias { get; set; }

        public string TableAlias { get; set; }

        public byForm_Server.ku.DataTypeEnum DataTypeEnum { get; set; }

        public System.Type EnumType { get; set; }

        public string AggregateFunctionName { get; set; }

        public void AssembleField(string f_KuName, string f_SheetName, string f_ColumnName)
        {
            try
            {
                var tmpTable = Root.GetInstance()[f_KuName][f_SheetName] as table;
                var tmpField = tmpTable.Fields[f_ColumnName];
                KuName = f_KuName;
                SheetName= f_SheetName;
                ColumnName= f_ColumnName;
                field = tmpField;
            }
            catch
            {
                KuName = null;
                SheetName = null;
                ColumnName = null;
                field = null;
            }
        }

        public void AssembleField(byForm_Server.ku.by.Object.field f_Field)
        {
            var tmpField = f_Field.Field;
            KuName = tmpField.KuName;
            SheetName = tmpField.SheetName;
            ColumnName = tmpField.Name;
            field = f_Field;
        }

        public byForm_Server.ku.by.Object.Cell CopyValue()
        {
            Cell tmpCell = new Cell();

            if (tmpCell._value is datetime)
            {
                tmpCell._value = datetime.ConvertToDatetime(tmpCell._value);
            }
            else
            {
                tmpCell._value = value;
            }

            tmpCell.ColumnName = ColumnName;
            tmpCell.SheetName = SheetName;
            tmpCell.KuName = KuName;
            tmpCell.DataTypeEnum = DataTypeEnum;
            tmpCell.EnumType = EnumType;
            tmpCell.field = field;
            return tmpCell;
        }

        public override string ToString()
        {
            StringBuilder tmpValue = new StringBuilder();
            tmpValue.Append(this.GetColumnName());

            if (this._value == null)
            {
                tmpValue.Append(" : NULL");
            }
            else
            {
                tmpValue.Append(" = ");
                tmpValue.Append(this._value);
            }

            return tmpValue.ToString();
        }

        public string GetColumnName()
        {
            StringBuilder tmpValue = new StringBuilder();
            if (this.AggregateFunctionName != null)
            {
                tmpValue.Append(this.AggregateFunctionName);
                tmpValue.Append("(");
                tmpValue.Append(this.KuName);
                tmpValue.Append(".");
                tmpValue.Append(this.SheetName);
                tmpValue.Append(".");
                tmpValue.Append(this.ColumnName);
                tmpValue.Append(")");
            }
            else
            {
                if (this.KuName != null && this.SheetName != null)
                {
                    tmpValue.Append(this.KuName);
                    tmpValue.Append(".");
                    tmpValue.Append(this.SheetName);
                    tmpValue.Append(".");
                    tmpValue.Append(this.ColumnName);
                }
                else
                {
                    tmpValue.Append(this.ColumnName);
                }
            }

            return tmpValue.ToString();
        }

        public void MatchField(byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_Field)
        {
            string tmpPattern = @"#TmpName\d+";

            if (f_Field.FieldTable != null && TableAlias == null)
            {
                TableAlias = f_Field.FieldTable.Alias;
            }

            if (f_Field.Alias != null && !System.Text.RegularExpressions.Regex.IsMatch(f_Field.Alias, tmpPattern))
            {
                this.KuName = null;
                this.SheetName = null;
                this.ColumnName = f_Field.Alias;
                this.DataTypeEnum = f_Field.FieldType;
                this.EnumType = f_Field.EnumType;
                this.field = null;
                this.Alias = f_Field.Alias;

                if (this.DataTypeEnum == DataTypeEnum.Bool)
                {
                    CheckBoolValue();
                }

                return;
            }

            if (f_Field is LiteralField)
            {
                this.DataTypeEnum = f_Field.FieldType;
                if (this.DataTypeEnum == DataTypeEnum.Enum)
                {
                    this.EnumType = f_Field.EnumType;
                }

                this.ColumnName = f_Field.FieldType.ToString();
                this.field = null;

                if (this.DataTypeEnum == DataTypeEnum.Bool)
                {
                    CheckBoolValue();
                }

                return;
            }

            if (f_Field is BinaryOperationField)
            {
                var tmpBinaryOperationField = f_Field as BinaryOperationField;
                this.KuName = null;
                this.SheetName = null;
                this.ColumnName = tmpBinaryOperationField.FieldType.ToString().ToLower(); ;
                this.DataTypeEnum = tmpBinaryOperationField.FieldType;
                this.field = null;
                return;
            }

            if (f_Field is FuncField)
            {
                var tmpFuncField = f_Field as FuncField;
                if (tmpFuncField.AggregateFunction != FunctionEnum.NONE)
                {
                    if (tmpFuncField.Params.Count != 1)
                    {
                        ToolClass.ThrowHelper.ThrowUnKnownException("系统错误，非法聚合函数");
                    }

                    if (tmpFuncField.Params[0] is TableField)
                    {
                        var tmpTableField = tmpFuncField.Params[0] as TableField;
                        var tmpDataSheet = tmpTableField.FieldTable.GetSource() as table;
                        this.KuName = tmpTableField.SelectedField.KuName;
                        this.SheetName = tmpTableField.SelectedField.SheetName;
                        this.ColumnName = tmpTableField.SelectedField.Name;
                        this.AggregateFunctionName = tmpFuncField.AggregateFunction.ToString();
                        field = tmpDataSheet.Fields[ColumnName];

                        if (tmpFuncField.AggregateFunction == FunctionEnum.COUNT)
                        {
                            this.DataTypeEnum = DataTypeEnum.Int;
                            this.EnumType = null;
                        }
                        else
                        {
                            this.DataTypeEnum = tmpTableField.SelectedField.FieldType;
                            this.EnumType = tmpTableField.SelectedField.EnumType;
                        }
                    }
                    else
                    {
                        this.ColumnName = f_Field.FieldType.ToString().ToLower();
                        this.DataTypeEnum = f_Field.FieldType;
                        if (this.DataTypeEnum == DataTypeEnum.Enum)
                        {
                            this.EnumType = f_Field.EnumType;
                        }
                    }
                }
                else
                {
                    this.KuName = null;
                    this.SheetName = null;
                    this.ColumnName = tmpFuncField.FieldType.ToString().ToLower();
                    this.DataTypeEnum = tmpFuncField.FieldType;
                    if (this.DataTypeEnum == DataTypeEnum.Enum)
                    {
                        this.EnumType = tmpFuncField.EnumType;
                    }
                }

                this.field = null;

                if (this.DataTypeEnum == DataTypeEnum.Bool)
                {
                    CheckBoolValue();
                }

                return;
            }

            if (f_Field is ParenthesesField)
            {
                var tmpParenthesesField = f_Field as ParenthesesField;
                this.field = null;
                this.DataTypeEnum = tmpParenthesesField.FieldType;

                if (this.DataTypeEnum == DataTypeEnum.Bool)
                {
                    CheckBoolValue();
                }

                return;
            }

            if (f_Field is SelectField)
            {
                var tmpSelectField = f_Field as SelectField;
                this.MatchField(tmpSelectField.actualField);
                return;
            }

            if (f_Field is TableField)
            {
                var tmpTableField = f_Field as TableField;
                this.KuName = tmpTableField.SelectedField.KuName;
                this.SheetName = tmpTableField.SelectedField.SheetName;
                this.ColumnName = tmpTableField.SelectedField.Name;
                this.DataTypeEnum = tmpTableField.SelectedField.FieldType;
                this.EnumType = tmpTableField.SelectedField.EnumType;
                var tmpDataSheet = (table)ToolClass.ToolFunction.GetDataSheet(KuName, SheetName);
                field = tmpDataSheet.Fields[ColumnName];

                if (this.DataTypeEnum == DataTypeEnum.Bool)
                {
                    CheckBoolValue();
                }

                return;
            }

            if (f_Field is UnaryField)
            {
                var tmpUnaryField = f_Field as UnaryField;
                this.MatchField(tmpUnaryField.OperatorField);
                return;
            }
        }

        private void CheckBoolValue()
        {
            if (this._value == null)
            {
                throw new Exception(string.Format(ErrorInfo.CellValueTypeError, "null", "bool"));
            }

            if (this._value is bool)
            {
                return;
            }

            int tmpValue;

            if (int.TryParse(this._value.ToString(), out tmpValue))
            {
                if (tmpValue == 1)
                {
                    this._value = true;
                    return;
                }

                if (tmpValue == 0)
                {
                    this._value = false;
                    return;
                }
            }

            throw new Exception(string.Format(ErrorInfo.CellValueTypeError, "null", "bool"));
        }

        private byForm_Server.ku.DataTypeEnum GetDataTypeEnum(string f_Type)
        {
            if (f_Type.Contains("."))
            {
                //枚举
                if (f_Type.Split('.').Length == 3)
                {
                    return DataTypeEnum.Enum;
                }
            }

            if (f_Type == "double")
            {
                return DataTypeEnum.Double;
            }

            if (f_Type == "string")
            {
                return DataTypeEnum.String;
            }

            if (f_Type == "byte")
            {
                return DataTypeEnum.Byte;
            }

            if (f_Type == "short")
            {
                return DataTypeEnum.Short;
            }

            if (f_Type == "int")
            {
                return DataTypeEnum.Int;
            }

            if (f_Type == "long")
            {
                return DataTypeEnum.Long;
            }

            if (f_Type == "float")
            {
                return DataTypeEnum.Float;
            }

            if (f_Type == "decimal")
            {
                return DataTypeEnum.Decimal;
            }

            if (f_Type == "bool")
            {
                return DataTypeEnum.Bool;
            }

            return DataTypeEnum.None;
        }

        private System.Type GenerateEnumType(string f_Value)
        {
            var tmpEnumArray = f_Value.Split('.');
            string tmpQualifiedName = "byForm_Server" + ".ku." + tmpEnumArray[0] + ".Enum." + tmpEnumArray[2];
            return System.Type.GetType(tmpQualifiedName);
        }

        public void SetValue(object f_Value)
        {
            _value = f_Value;
        }

        public bool equals(byForm_Server.ku.by.Object.Cell f_Cell)
        {
            return KuName == f_Cell.KuName && SheetName == f_Cell.SheetName && ColumnName == f_Cell.ColumnName && value.Equals(f_Cell._value);
        }
    }
}
