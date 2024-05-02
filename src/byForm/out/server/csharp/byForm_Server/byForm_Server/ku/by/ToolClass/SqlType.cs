using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class SqlType : byForm_Server.ku.by.ToolClass.ITableSource, byForm_Server.ku.by.ToolClass.IExecItem
    {
        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> rows { get; set; }

        public SqlType(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_Rows, byForm_Server.ku.by.ToolClass.Sql.SelectTable f_Source)
        {
            this.rows = f_Rows;
            this.Source = f_Source;
        }

        public byForm_Server.ku.by.ToolClass.Sql.SelectTable Source { get; set; }

        public string SqlCommandText
        {
            get
            {
                return Source.SqlValue;
            }
        }

        public void FillDateset(System.Data.DataTable f_DataTable)
        {
            rows = new Object.list<Object.Row>();
            string tmpNewPattern = "#NewOrderBy\\d{1,}$";
            foreach (System.Data.DataRow item in f_DataTable.Rows)
            {
                Object.Row tmpNewRow = new Object.Row();
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    var tmpColumnName = f_DataTable.Columns[i].ColumnName;
                    if (tmpColumnName == "#RowNum" || System.Text.RegularExpressions.Regex.IsMatch(tmpColumnName, tmpNewPattern))
                    {
                        //任何种类数据库返回数据正常数据单元格名称不会带这两个
                        continue;
                    }

                    var value = item.ItemArray[i];
                    Object.Cell tmpNewCell = new Object.Cell();
                    if (value is DateTime)
                    {
                        tmpNewCell.SetValue(Object.datetime.ConvertToDatetime(value));
                        tmpNewCell.DataTypeEnum = DataTypeEnum.Datetime;
                    }
                    else if (value is DBNull)
                    {
                        var tmpField = Source.ResultItemsWithoutAsterisk[i];
                        switch (tmpField.FieldType)
                        {
                            case DataTypeEnum.Bool:
                                tmpNewCell.SetValue(false);
                                break;
                            case DataTypeEnum.Byte:
                                tmpNewCell.SetValue(default(byte));
                                break;
                            case DataTypeEnum.Double:
                                tmpNewCell.SetValue(default(double));
                                break;
                            case DataTypeEnum.Float:
                                tmpNewCell.SetValue(default(float));
                                break;
                            case DataTypeEnum.Int:
                                tmpNewCell.SetValue(0);
                                break;
                            case DataTypeEnum.Short:
                                tmpNewCell.SetValue(default(short));
                                break;
                            case DataTypeEnum.String:
                                tmpNewCell.SetValue(null);
                                break;
                            case DataTypeEnum.Datetime:
                                tmpNewCell.SetValue(ku.by.Object.datetime.ConvertToDatetime(default(DateTime)));
                                break;
                            case DataTypeEnum.Char:
                                tmpNewCell.SetValue('\0');
                                break;
                            case DataTypeEnum.Decimal:
                                tmpNewCell.SetValue(default(decimal));
                                break;
                            case DataTypeEnum.Long:
                                tmpNewCell.SetValue(default(long));
                                break;
                            case DataTypeEnum.Enum:
                                var tmpEnumType = tmpField.EnumType;
                                if (tmpEnumType == null)
                                {
                                    throw ThrowHelper.ThrowUnKnownException("枚举类型未填充");
                                }
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
                                throw ThrowHelper.ThrowUnKnownException("查询字段类型填充错误,无法由null转化为默认值");
                        }
                    }
                    else if (value is bool)
                    {
                        var tmpBoolValue = (bool)value;
                        tmpNewCell.SetValue(tmpBoolValue ? true : false);
                        tmpNewCell.DataTypeEnum = DataTypeEnum.Bool;
                    }
                    else
                    {
                        tmpNewCell.SetValue(value);
                    }

                    tmpNewCell.row = tmpNewRow;
                    tmpNewRow.cells.Add(tmpNewCell);
                }

                if (tmpNewRow.cells.Count != Source.ResultItemsWithoutAsterisk.Count)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.SelectResultError, Source.PrintSource(), Root.GetInstance()[Source.DeclarKuName].sqlLocation.SqlLocationDic[Source.No]));
                }

                for (int i = 0; i < tmpNewRow.cells.Count; i++)
                {
                    var tmpCell = tmpNewRow.cells[i];
                    var tmpField = Source.ResultItemsWithoutAsterisk[i];
                    tmpCell.MatchField(tmpField);
                }

                tmpNewRow.Identity = Source.TableSources[0].GetIdentity();
                rows.Add(tmpNewRow);
            }
        }

        public string ExecuteKuName()
        {
            return Source.GetSource().RealKuName;
        }

        public string DecKuName()
        {
            return Source.DeclarKuName;
        }
    }
}
