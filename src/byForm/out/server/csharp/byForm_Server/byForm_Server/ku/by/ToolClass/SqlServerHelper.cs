using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using byForm_Server.ku.by.Object;
namespace byForm_Server.ku.by.ToolClass
{
    public static class SqlServerHelper
    {
        public static System.Collections.Generic.Dictionary<string, string> sqlConnections;

        private static bool HasTested;

        static SqlServerHelper()
        {
            HasTested = false;
            sqlConnections = new Dictionary<string, string>();
            sqlConnections.Add("byFormNew", ConfigurationManager.ConnectionStrings["byFormNew"].ConnectionString + "Initial Catalog=byFormNew");
            sqlConnections.Add("buUserTest", ConfigurationManager.ConnectionStrings["byUser"].ConnectionString + "Initial Catalog=buUserTest");
        }

        public static void TestConnetion()
        {
            if (HasTested)
            {
                return;
            }

            foreach (var item in sqlConnections)
            {
                using (SqlConnection tmpSqlConnection = new SqlConnection(item.Value))
                {
                    tmpSqlConnection.Open();
                }
            }

            HasTested = true;
        }

        public static object Inquiry(string f_Sql, string f_KuName)
        {
            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_KuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            using (SqlConnection tmpSqlConnection = new SqlConnection(tmpConnectionstr))
            {
                SqlCommand tmpCom = new SqlCommand(f_Sql, tmpSqlConnection);
                tmpSqlConnection.Open();
                var tmpReturnValue = tmpCom.ExecuteScalar();
                return tmpReturnValue;
            }
        }

        public static int ExecuteNonQuery(string f_Sql, string f_KuName)
        {
            if (string.IsNullOrEmpty(f_Sql))
            {
                return 0;
            }

            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_KuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            using (SqlConnection tmpSqlConnection = new SqlConnection(tmpConnectionstr))
            {
                SqlCommand tmpCom = new SqlCommand(f_Sql, tmpSqlConnection);
                tmpSqlConnection.Open();
                var tmpReturnValue = tmpCom.ExecuteNonQuery();
                return tmpReturnValue;
            }
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>> ExecQueryReturnRowsCollection(string f_Sql, string f_KuName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.SelectTable> f_SelectTables)
        {
            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_KuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            DataSet tmpDs = new DataSet();

            using (SqlConnection tmpSqlConnection = new SqlConnection(tmpConnectionstr))
            {
                using (SqlDataAdapter tmpSda = new SqlDataAdapter(f_Sql, tmpSqlConnection))
                {
                    tmpSqlConnection.Open();
                    tmpSda.Fill(tmpDs);
                }
            }

            if (f_SelectTables.Count != tmpDs.Tables.Count)
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.ExecQueryTableNoMatch);
            }

            List<list<Row>> tmpReturnValue = new List<list<Row>>();

            for (int index = 0; index < f_SelectTables.Count; index++)
            {
                var tmpTable = tmpDs.Tables[index];
                var tmpSelectTable = f_SelectTables[index];
                list<Object.Row> tmpRowList = new list<Object.Row>();
                string tmpNewPattern = "#NewOrderBy\\d{1,}$";
                foreach (DataRow item in tmpTable.Rows)
                {
                    Object.Row tmpNewRow = new Object.Row();
                    for (int i = 0; i < item.ItemArray.Length; i++)
                    {
                        var tmpColumnName = tmpTable.Columns[i].ColumnName;
                        if (tmpColumnName == "#RowNum" || System.Text.RegularExpressions.Regex.IsMatch(tmpColumnName, tmpNewPattern))
                        {
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
                            var tmpField = tmpSelectTable.ResultItemsWithoutAsterisk[i];
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

                    if (tmpNewRow.cells.Count != tmpSelectTable.ResultItemsWithoutAsterisk.Count)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.SelectResultError, tmpSelectTable.PrintSource(), Root.GetInstance()[tmpSelectTable.DeclarKuName].sqlLocation.SqlLocationDic[tmpSelectTable.No]));
                    }

                    for (int i = 0; i < tmpNewRow.cells.Count; i++)
                    {
                        var tmpCell = tmpNewRow.cells[i];
                        var tmpField = tmpSelectTable.ResultItemsWithoutAsterisk[i];
                        tmpCell.MatchField(tmpField);
                    }

                    tmpRowList.Add(tmpNewRow);
                }
                tmpReturnValue.Add(tmpRowList);
            }

            return tmpReturnValue;
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> SelectReturnRows(string f_Sql, string f_RealKuName, byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, string f_SqlNo)
        {
            //所有的单元格和行在这里没有绑定表，只有值，单元格列名也没有
            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_RealKuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            DataSet tmpDs = new DataSet();

            using (SqlConnection tmpSqlConnection = new SqlConnection(tmpConnectionstr))
            {
                using (SqlDataAdapter tmpSda = new SqlDataAdapter(f_Sql, tmpSqlConnection))
                {
                    tmpSqlConnection.Open();
                    tmpSda.Fill(tmpDs);
                }
            }

            var tmpTable = tmpDs.Tables[0];
            List<Object.Row> tmpRowList = new List<Object.Row>();
            string tmpNewPattern = "#NewOrderBy\\d{1,}$";
            foreach (DataRow item in tmpTable.Rows)
            {
                Object.Row tmpNewRow = new Object.Row();
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    var tmpColumnName = tmpTable.Columns[i].ColumnName;
                    if (tmpColumnName == "#RowNum" || System.Text.RegularExpressions.Regex.IsMatch(tmpColumnName, tmpNewPattern))
                    {
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
                        var tmpField = f_SelectTable.ResultItemsWithoutAsterisk[i];
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

                if (tmpNewRow.cells.Count != f_SelectTable.ResultItemsWithoutAsterisk.Count)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.SelectResultError, f_SelectTable.PrintSource(), Root.GetInstance()[f_SelectTable.DeclarKuName].sqlLocation.SqlLocationDic[f_SqlNo]));
                }

                for (int i = 0; i < tmpNewRow.cells.Count; i++)
                {
                    var tmpCell = tmpNewRow.cells[i];
                    var tmpField = f_SelectTable.ResultItemsWithoutAsterisk[i];
                    tmpCell.MatchField(tmpField);
                }

                tmpRowList.Add(tmpNewRow);
            }
            return new Object.list<Object.Row>(tmpRowList);
        }

        public static void ExecuteExpression(string f_ExecKuName, byForm_Server.ku.by.ToolClass.IExecItem[] f_Results)
        {
            StringBuilder tmpSqlCommand = new StringBuilder();

            foreach (IExecItem result in f_Results)
            {
                tmpSqlCommand.AppendLine(result.SqlCommandText);
            }

            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_ExecKuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            DataSet tmpDs = new DataSet();

            using (SqlConnection tmpSqlConnection = new SqlConnection(tmpConnectionstr))
            {
                using (SqlDataAdapter tmpSda = new SqlDataAdapter(tmpSqlCommand.ToString(), tmpSqlConnection))
                {
                    tmpSqlConnection.Open();
                    tmpSda.Fill(tmpDs);
                }
            }

            if (tmpDs.Tables.Count == 0)
            {
                return;
            }

            int tmpTableIndex = 0;

            foreach (var item in f_Results)
            {
                if (item is SqlIDUResult)
                {
                    continue;
                }

                var tmpTable = tmpDs.Tables[tmpTableIndex];
                tmpTableIndex++;
                item.FillDateset(tmpTable);
            }
        }

        public static void ExecuteTran(string f_Sql, string f_KuName)
        {
            ExecuteNonQuery(f_Sql, f_KuName);
        }

        public static void CheckDataSheet(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet)
        {
            string tmpKuName = f_DataSheet.RealKuName;
            string tmpSheetName = f_DataSheet.SheetName;
            string tmpConnectionStr = sqlConnections[tmpKuName];
            string tmpSqlCommond = "SELECT * FROM [" + tmpSheetName + "]";
            DataSet tmpDs = new DataSet();

            using (SqlConnection tmpConnection = new SqlConnection(tmpConnectionStr))
            {
                using (SqlDataAdapter tmpSda = new SqlDataAdapter(tmpSqlCommond, tmpConnection))
                {
                    if (tmpConnection.State != ConnectionState.Open)
                    {
                        tmpConnection.Open();
                    }

                    tmpSda.Fill(tmpDs);
                }
            }

            var tmpDataTable = tmpDs.Tables[0];

            if (tmpDataTable.Columns.Count != f_DataSheet.FieldDic.Count)
            {
                ThrowHelper.ThrowKuInitException(string.Format(ErrorInfo.DataSheetFieldsError, tmpKuName + "." + tmpSheetName, f_DataSheet.KuName + "." + tmpSheetName));
            }

            for (int i = 0; i < tmpDataTable.Columns.Count; i++)
            {
                var tmpDataColumn = tmpDataTable.Columns[i];
                string tmpColumnName = tmpDataColumn.ColumnName;
                var tmpFieldName = f_DataSheet.FieldDic.ElementAt(i).Key;
                
                if (tmpColumnName != tmpFieldName)
                {
                    ThrowHelper.ThrowKuInitException(string.Format(ErrorInfo.DataSheetFieldsError, tmpKuName + "." + tmpSheetName, f_DataSheet.KuName + "." + tmpSheetName));
                }
            }
        }
    }
}
