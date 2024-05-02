using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Text;
using byForm_Server.ku.by.Object;
using MySql.Data.MySqlClient;

namespace byForm_Server.ku.by.ToolClass
{
    public class MySqlHelper
    {
        private static System.Collections.Generic.Dictionary<string, string> sqlConnections;

        private static System.Collections.Generic.HashSet<string> ExecutingTran;

        private static bool HasTested;

        static MySqlHelper()
        {
            HasTested = false;
            sqlConnections = new Dictionary<string, string>();
            ExecutingTran = new HashSet<string>();
        }

        public static void TestConnetion()
        {
            if (HasTested)
            {
                return;
            }

            foreach (var item in sqlConnections)
            {
                using (MySqlConnection tmpTest = new MySqlConnection(item.Value))
                {
                    tmpTest.Open();
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

            using (MySqlConnection tmpSqlConnection = new MySqlConnection(tmpConnectionstr))
            {
                using (MySqlCommand tmpCom = new MySqlCommand(f_Sql, tmpSqlConnection))
                {
                    tmpSqlConnection.Open();
                    var tmpReturnValue = tmpCom.ExecuteScalar();
                    return tmpReturnValue;
                }
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

            using (MySqlConnection tmpSqlConnection = new MySqlConnection(tmpConnectionstr))
            {
                using (MySqlCommand tmpCom = new MySqlCommand(f_Sql, tmpSqlConnection))
                {
                    tmpSqlConnection.Open();
                    var tmpReturnValue = tmpCom.ExecuteNonQuery();
                    return tmpReturnValue;
                }
            }
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> SelectReturnRows(string f_Sql, string f_RealKuName, byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, string f_SqlNo)
        {
            List<ku.by.Object.Row> tmpRowList = new List<ku.by.Object.Row>();
            DataSet ds = new DataSet();
            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_RealKuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            using (MySqlConnection tmpSqlConnection = new MySqlConnection(tmpConnectionstr))
            {
                using (MySqlDataAdapter tmpAdapter = new MySqlDataAdapter(f_Sql, tmpSqlConnection))
                {
                    tmpSqlConnection.Open();
                    tmpAdapter.Fill(ds);
                }
            }

            var tmpTable = ds.Tables[0];

            foreach (DataRow item in tmpTable.Rows)
            {
                ku.by.Object.Row tmpNewRow = new ku.by.Object.Row();

                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    var tmpValue = item.ItemArray[i];
                    ku.by.Object.Cell tmpNewCell = new ku.by.Object.Cell();

                    if (tmpValue is DBNull)
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
                                tmpNewCell.DataTypeEnum = DataTypeEnum.Int;
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
                    else if (tmpValue is DateTime)
                    {
                        tmpNewCell.SetValue(ku.by.Object.datetime.ConvertToDatetime(tmpValue));
                        tmpNewCell.DataTypeEnum = DataTypeEnum.Datetime;
                    }
                    else if (tmpValue is bool)
                    {
                        tmpNewCell.SetValue((bool)tmpValue);
                        tmpNewCell.DataTypeEnum = DataTypeEnum.Bool;
                    }
                    else
                    {
                        tmpNewCell.SetValue(tmpValue);
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

            return new ku.by.Object.list<ku.by.Object.Row>(tmpRowList);
        }

        public static void ExecuteExpression(string f_ExecKuName, byForm_Server.ku.by.ToolClass.IExecItem[] f_Results)
        {
            StringBuilder tmpSqlCommand = new StringBuilder();

            foreach (IExecItem result in f_Results)
            {
                tmpSqlCommand.AppendLine(result.SqlCommandText + ";");
            }

            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_ExecKuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            DataSet tmpDs = new DataSet();

            using (MySqlConnection tmpSqlConnection = new MySqlConnection(tmpConnectionstr))
            {
                using (MySqlDataAdapter tmpAdapter = new MySqlDataAdapter(tmpSqlCommand.ToString(), tmpSqlConnection))
                {
                    tmpSqlConnection.Open();
                    tmpAdapter.Fill(tmpDs);
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

        public static System.Collections.Generic.List<byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>> ExecQueryReturnRowsCollection(string f_Sql, string f_KuName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.SelectTable> f_SelectTables)
        {
            DataSet tmpDs = new DataSet();
            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_KuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            using (MySqlConnection tmpSqlConnection = new MySqlConnection(tmpConnectionstr))
            {
                using (MySqlDataAdapter tmpAdapter = new MySqlDataAdapter(f_Sql, tmpSqlConnection))
                {
                    tmpSqlConnection.Open();
                    tmpAdapter.Fill(tmpDs);
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

        public static void ExecuteTran(string f_Sql, string f_KuName, string f_TranName)
        {
            //string tmpExecuteCode = "CALL " + f_TranName + "();";
            //string tmpDropCode = "DROP PROCEDURE IF EXISTS " + f_TranName + ";";
            StringBuilder tmpCode = new StringBuilder();
            tmpCode.AppendLine(f_Sql);
            //tmpCode.AppendLine(tmpExecuteCode);
            Stopwatch tmpStopWatch = new Stopwatch();

            try
            {
                tmpStopWatch.Start();
                
                while (true)
                {
                    if (tmpStopWatch.ElapsedMilliseconds > 5000)
                    {
                        ThrowHelper.ThrowUnKnownException(ErrorInfo.SqlExecteTimeout);
                    }

                    if (ExecutingTran.Contains(f_TranName))
                    {
                        continue;
                    }
                    else
                    {
                        lock (ExecutingTran)
                        {
                            if (ExecutingTran.Contains(f_TranName))
                            {
                                continue;
                            }

                            ExecutingTran.Add(f_TranName);
                        }
                    }

                    ExecuteNonQuery(tmpCode.ToString(), f_KuName);
                    ExecutingTran.Remove(f_TranName);
                    break;
                }
            }
            finally
            {
                ExecutingTran.Remove(f_TranName);
            }

            tmpStopWatch.Stop();
        }
    }
}
