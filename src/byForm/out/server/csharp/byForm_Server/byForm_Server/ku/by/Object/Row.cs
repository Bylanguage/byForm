using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.by.Object
{
    public class Row : byForm_Server.ku.by.ToolClass.IIdentity
    {
        public Row()
        {
            this.cells = new List<Cell>();
        }

        public byForm_Server.ku.by.Object.Cell this[string f_QualifiedName]
        {
            get
            {
                var tmpArray = f_QualifiedName.Split('.');

                if (tmpArray.Length != 3)
                {
                    throw new Exception(String.Format(ErrorInfo.CanNotFindCellInRow, f_QualifiedName));
                }

                string tmpKuName = tmpArray[0];
                string tmpSheetName = tmpArray[1];
                string tmpColName = tmpArray[2];
                var tmpCell = this.cells.Find(item => item.KuName == tmpKuName && item.SheetName == tmpSheetName && item.ColumnName == tmpColName);

                if (tmpCell == null)
                {
                    throw new Exception(String.Format(ErrorInfo.CanNotFindCellInRow, f_QualifiedName));
                }

                return tmpCell;
            }
        }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.Object.Cell> cells { get; set; }

        public byForm_Server.ku.by.Object.ReadOnlyList<byForm_Server.ku.by.Object.Cell> Cells
        {
            get
            {
                return new ReadOnlyList<Cell>(cells);
            }
        }

        public byForm_Server.ku.by.Object.table table
        {
            get
            {
                if (KuName == null || SheetName == null)
                {
                    return null;
                }

                return (table)ToolClass.ToolFunction.GetDataSheet(KuName, SheetName);
            }
        }

        public string SheetName
        {
            get
            {
                if (this.Identity == null)
                {
                    throw ThrowHelper.ThrowDataMatchException(ErrorInfo.RowIdentityIsNullCanNotFindSheet);
                }
                else
                {
                    var tmpDataSheet = this.Identity.to as IBaseDataSheet;

                    if (tmpDataSheet == null)
                    {
                        throw ThrowHelper.ThrowDataMatchException(ErrorInfo.RowIdentityIsNullCanNotFindSheet);
                    }

                    return tmpDataSheet.SheetName;
                }
            }
        }

        public string KuName
        {
            get
            {
                if (this.Identity == null)
                {
                    throw ThrowHelper.ThrowDataMatchException(ErrorInfo.RowIdentityIsNullCanNotFindSheet);
                }
                else
                {
                    var tmpDataSheet = this.Identity.to as IBaseDataSheet;

                    if (tmpDataSheet == null)
                    {
                        throw ThrowHelper.ThrowDataMatchException(ErrorInfo.RowIdentityIsNullCanNotFindSheet);
                    }

                    return tmpDataSheet.KuName;
                }
            }
        }

        public byForm_Server.ku.by.Object.Row Copy()
        {
            var tmpRow = new Row();
            tmpRow.Identity = this.Identity;
            tmpRow.cells = new List<Cell>();

            for (int i = 0; i < this.cells.Count; i++)
            {
                //值类型或datetime
                var tmpThisCell = this.cells[i];
                var tmpCell = tmpThisCell.CopyValue();
                tmpCell.row = this;
                tmpRow.cells.Add(tmpCell);
            }

            return tmpRow;
        }

        public void AddCell(byForm_Server.ku.by.Object.field f_Field, object f_Value)
        {
            var tmpField = f_Field.Field;
            var tmpCell = new Cell();
            tmpCell.AssembleField(f_Field);
            tmpCell.DataTypeEnum = tmpField.FieldType;
            tmpCell.field = f_Field;
            tmpCell.row = this;
            if (tmpField.EnumType != null)
            {
                tmpCell.EnumType = tmpField.EnumType;
            }

            if (f_Value == null)
            {
                string tmpValueType = null;
                switch (tmpField.FieldType)
                {
                    case DataTypeEnum.Bool:
                        tmpValueType = "bool";
                        break;
                    case DataTypeEnum.Byte:
                        tmpValueType = "byte";
                        break;
                    case DataTypeEnum.Char:
                        tmpValueType = "char";
                        break;
                    case DataTypeEnum.Decimal:
                        tmpValueType = "decimal";
                        break;
                    case DataTypeEnum.Double:
                        tmpValueType = "double";
                        break;
                    case DataTypeEnum.Enum:
                        if (tmpField.EnumType == null)
                        {
                            tmpValueType = "enum";
                        }
                        else
                        {
                            tmpValueType = tmpField.EnumType.Name;
                        }
                        break;
                    case DataTypeEnum.Float:
                        tmpValueType = "float";
                        break;
                    case DataTypeEnum.Int:
                        tmpValueType = "int";
                        break;
                    case DataTypeEnum.Long:
                        tmpValueType = "long";
                        break;
                    case DataTypeEnum.Short:
                        tmpValueType = "short";
                        break;
                    default:
                        break;
                }
                if (tmpValueType == null)
                {
                    tmpCell.SetValue(null);
                    return;
                }
                else
                {
                    ToolClass.ThrowHelper.ThrowVerifyException(string.Format(ToolClass.ErrorInfo.CannotConvertNull, tmpValueType));
                }
            }

            try
            {
                object tmpValue = f_Value;
                if (f_Value is char)
                {
                    tmpValue = Convert.ToInt32(f_Value);
                }
                switch (tmpField.FieldType)
                {
                    case DataTypeEnum.Bool:
                        bool tmpBoolValue = Convert.ToBoolean(tmpValue);
                        tmpCell.SetValue(tmpBoolValue);
                        break;
                    case DataTypeEnum.Byte:
                        sbyte tmpByteValue = Convert.ToSByte(tmpValue);
                        tmpCell.SetValue(tmpByteValue);
                        break;
                    case DataTypeEnum.Char:
                        char tmpCharValue = Convert.ToChar(tmpValue);
                        tmpCell.SetValue(tmpCharValue);
                        break;
                    case DataTypeEnum.Datetime:
                        DateTime tmpDatetimeValue = Convert.ToDateTime(tmpValue);
                        datetime tmpdatetimeValue = datetime.ConvertToDatetime(tmpDatetimeValue);
                        tmpCell.SetValue(tmpdatetimeValue);
                        break;
                    case DataTypeEnum.Decimal:
                        decimal tmpDecimalValue = Convert.ToDecimal(tmpValue);
                        tmpCell.SetValue(tmpDecimalValue);
                        break;
                    case DataTypeEnum.Double:
                        double tmpDoubleValue = Convert.ToDouble(tmpValue);
                        tmpCell.SetValue(tmpDoubleValue);
                        break;
                    case DataTypeEnum.Enum:
                        var tmpEnumType = tmpField.EnumType;
                        var tmpEnumValue = System.Enum.Parse(tmpEnumType, tmpValue.ToString(), true);
                        tmpCell.SetValue(tmpEnumValue);
                        break;
                    case DataTypeEnum.Float:
                        float tmpFloatValue = Convert.ToSingle(tmpValue);
                        tmpCell.SetValue(tmpFloatValue);
                        break;
                    case DataTypeEnum.Int:
                        int tmpIntValue = Convert.ToInt32(tmpValue);
                        tmpCell.SetValue(tmpIntValue);
                        break;
                    case DataTypeEnum.Long:
                        long tmpLongValue = Convert.ToInt64(tmpValue);
                        tmpCell.SetValue(tmpLongValue);
                        break;
                    case DataTypeEnum.Short:
                        short tmpShortValue = Convert.ToInt16(tmpValue);
                        tmpCell.SetValue(tmpShortValue);
                        break;
                    case DataTypeEnum.String:
                        tmpCell.SetValue(tmpValue);
                        break;
                }
            }
            catch
            {
                string tmpFieldName = tmpField.KuName + "." + tmpField.SheetName + "." + tmpField.Name;
                if (tmpField.FieldType == DataTypeEnum.Enum)
                {
                    ToolClass.ThrowHelper.ThrowVerifyException(string.Format(ToolClass.ErrorInfo.RowValueTypeConvertError, tmpFieldName, f_Value.ToString(), tmpField.EnumType.Name));
                }
                ToolClass.ThrowHelper.ThrowVerifyException(string.Format(ToolClass.ErrorInfo.RowValueTypeConvertError, tmpFieldName, f_Value.ToString(), tmpField.FieldType.ToString().ToLower()));
            }

           this.cells.Add(tmpCell);
        }

        public override string ToString()
        {
            StringBuilder tmpValue = new StringBuilder();
            for (int i = 0; i < this.cells.Count; i++)
            {
                if (i != 0)
                {
                    tmpValue.Append("\r\n");
                }

                var tmpCell = this.cells[i];
                tmpValue.Append(tmpCell.ToString());
            }
            return tmpValue.ToString();
        }

        public bool equals(byForm_Server.ku.by.Object.Row targetRow)
        {
            if (this.cells.Count != targetRow.cells.Count)
            {
                return false;
            }

            for (int i = 0; i < this.cells.Count; i++)
            {
                var tmpCell1 = this.cells[i];
                var tmpCell2 = targetRow.cells[i];

                if (!tmpCell1.equals(tmpCell2))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var tmpRow = obj as Row;

            if (tmpRow == null)
            {
                return false;
            }

            return equals(tmpRow);
        }

        public byForm_Server.ku.by.Object.Result verify()
        {
            Result tmpResult = new Result();
            try
            {
                var tmpDataSheet = ToolClass.ToolFunction.GetDataSheet(this.KuName, this.SheetName);
                foreach (var item in this.cells)
                {
                    if (item.KuName != this.KuName)
                    {
                        continue;
                    }

                    if (item.SheetName != this.SheetName)
                    {
                        continue;
                    }

                    if (item.AggregateFunctionName != null)
                    {
                        continue;
                    }

                    field tmpField = null;
                    if (!(tmpDataSheet as table).Fields.TryGetValue(item.ColumnName, out tmpField))
                    {
                        ToolClass.ThrowHelper.ThrowDataMatchException(String.Format(ToolClass.ErrorInfo.CanNotFindComponentInSheet, item.KuName + "." + item.SheetName, item.ColumnName));
                    }

                    ToolClass.VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[item.ColumnName], tmpField.Field, item.value);
                }
            }
            catch (Exception ex)
            {
                tmpResult.isOk = false;
                tmpResult.info = ex.Message;
                return tmpResult;
            }

            tmpResult.isOk = true;
            tmpResult.info = null;
            return tmpResult;
        }

        public byForm_Server.ku.by.Object.Row clone()
        {
            return this.Copy();
        }

        public byForm_Server.ku.by.Object.orm OrmSource { get; set; }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase _InitIdentity_
        {
            set
            {
                if (this.Identity != null)
                {
                    return;
                }
                this.Identity = value;
                if (value.to != null && value.to is ToolClass.IBaseDataSheet)
                {
                    var tmpDataSheet = value.to as ToolClass.IBaseDataSheet;
                    this.cells.Clear();
                    foreach (var item in tmpDataSheet.FieldDic)
                    {
                        var tmpField = item.Value;
                        var tmpNewCell = new Cell() { DataTypeEnum = tmpField.FieldType, EnumType = tmpField.EnumType, row = this };
                        tmpNewCell.AssembleField(tmpField.KuName, tmpField.SheetName, tmpField.Name);
                        switch (tmpNewCell.DataTypeEnum)
                        {
                            case DataTypeEnum.Byte:
                            case DataTypeEnum.Decimal:
                            case DataTypeEnum.Double:
                            case DataTypeEnum.Float:
                            case DataTypeEnum.Int:
                            case DataTypeEnum.Long:
                            case DataTypeEnum.Short:
                                tmpNewCell.SetValue(0);
                                break;
                            case DataTypeEnum.Bool:
                                tmpNewCell.SetValue(false);
                                break;
                            case DataTypeEnum.Char:
                                tmpNewCell.SetValue('\0');
                                break;
                            case DataTypeEnum.Datetime:
                                tmpNewCell.SetValue(datetime.ConvertToDatetime(default(DateTime)));
                                break;
                            case DataTypeEnum.String:
                                tmpNewCell.SetValue("");
                                break;
                            case DataTypeEnum.Enum:
                                var tmpEnumType = tmpField.EnumType;
                                var tmpEnumValues = System.Enum.GetValues(tmpEnumType);
                                if (tmpEnumValues.Length == 0)
                                {
                                    tmpNewCell.SetValue(Activator.CreateInstance(tmpEnumType));
                                }
                                else
                                {
                                    tmpNewCell.SetValue(tmpEnumValues.GetValue(0));
                                }
                                break;
                            default:
                                tmpNewCell.SetValue(null);
                                break;
                        }

                        this.cells.Add(tmpNewCell);
                    }
                }
            }
        }
    }
}
