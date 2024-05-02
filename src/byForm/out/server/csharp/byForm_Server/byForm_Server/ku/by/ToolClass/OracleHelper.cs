using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using byForm_Server.ku.by.Object;
namespace byForm_Server.ku.by.ToolClass
{
    public class OracleHelper
    {
        private static System.Collections.Generic.Dictionary<string, string> sqlConnections;

        private static System.Collections.Generic.HashSet<string> ExcutingRows;

        private static bool HasTested;

        static OracleHelper()
        {
            ExcutingRows = new HashSet<string>();
            HasTested = false;
            sqlConnections = new Dictionary<string, string>();
        }

        public static void TestConnetion()
        {
            if (HasTested)
            {
                return;
            }

            foreach (var item in sqlConnections)
            {
                using (OracleConnection connetion = new OracleConnection(item.Value))
                {
                    connetion.Open();
                }
            }

            HasTested = true;
        }

        public static int ExecuteRowsSql(string f_Sql, string f_KuName, string f_MethodName)
        {
            //传入的sql是用于创建函数的,methodname不带双引号
            string tmpConnectionstring;
            if (!sqlConnections.TryGetValue(f_KuName, out tmpConnectionstring))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            Stopwatch tmpStopWatch = new Stopwatch();
            int tmpReturnValue = 0;

            try
            {
                tmpStopWatch.Start();

                while (true)
                {
                    if (tmpStopWatch.ElapsedMilliseconds > 5000)
                    {
                        ThrowHelper.ThrowUnKnownException(ErrorInfo.SqlExecteTimeout);
                    }

                    if (ExcutingRows.Contains(f_MethodName))
                    {
                        continue;
                    }
                    else
                    {
                        lock (ExcutingRows)
                        {
                            if (ExcutingRows.Contains(f_MethodName))
                            {
                                continue;
                            }

                            ExcutingRows.Add(f_MethodName);
                        }
                    }

                    ExecuteNonQuery(f_Sql, f_KuName);

                    using (OracleConnection tmpConnection = new OracleConnection(tmpConnectionstring))
                    {
                        tmpConnection.Open();

                        using (OracleCommand cmd = tmpConnection.CreateCommand())
                        {
                            //cmd.Connection = tmpConnection;
                            cmd.CommandText = "\"" + f_MethodName + "\"";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("returnvalue", OracleDbType.Int32).Direction = ParameterDirection.ReturnValue;
                            cmd.ExecuteNonQuery();
                            tmpReturnValue = Convert.ToInt32(cmd.Parameters["returnvalue"].Value.ToString());
                        }

                        using (OracleCommand cmd = tmpConnection.CreateCommand())
                        {
                            string tmpDROPSql = string.Format(@"DECLARE FUNCCOUNT INT :=0;
BEGIN 
SELECT COUNT(*) INTO FUNCCOUNT from dual WHERE EXISTS(SELECT * FROM ALL_OBJECTS  WHERE OBJECT_NAME = '{0}' AND OBJECT_TYPE = 'FUNCTION' );
IF FUNCCOUNT > 0
THEN EXECUTE IMMEDIATE 'DROP FUNCTION ""{0}""';
END IF;
END;", f_MethodName);
                            cmd.CommandText = tmpDROPSql;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    ExcutingRows.Remove(f_MethodName);
                    break;
                }
            }
            finally
            {
                ExcutingRows.Remove(f_MethodName);
            }

            tmpStopWatch.Stop();
            return tmpReturnValue;
        }

        public static object Inquiry(string f_Sql, string f_KuName)
        {
            string tmpConnectionstring;
            if (!sqlConnections.TryGetValue(f_KuName, out tmpConnectionstring))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            using (OracleConnection tmpConnection = new OracleConnection(tmpConnectionstring))
            {
                tmpConnection.Open();
                OracleCommand tmpCommand = new OracleCommand();
                tmpCommand.Connection = tmpConnection;
                tmpCommand.CommandText = f_Sql;
                var tmpmReturnValue = tmpCommand.ExecuteScalar();
                return tmpmReturnValue;
            }
        }

        public static int ExecuteNonQuery(string f_Sql, string f_KuName)
        {
            if (string.IsNullOrEmpty(f_Sql))
            {
                return 0;
            }

            string tmpConnectionstring;
            if (!sqlConnections.TryGetValue(f_KuName, out tmpConnectionstring))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }


            using(OracleConnection tmpOracleConnection = new OracleConnection(tmpConnectionstring))
            {
                tmpOracleConnection.Open();
                OracleCommand tmpCommand = new OracleCommand();
                tmpCommand.Connection = tmpOracleConnection;
                tmpCommand.CommandText = f_Sql;
                var tmpReturnValue = tmpCommand.ExecuteNonQuery();
                tmpOracleConnection.Close();
                if (tmpReturnValue < 0)
                {
                    return 0;
                }
                return tmpReturnValue;
            }
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> SelectReturnRows(string f_Sql, string f_RealKuName, byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, string f_SqlNo)
        {
            string tmpConnectionstring;
            if (!sqlConnections.TryGetValue(f_RealKuName, out tmpConnectionstring))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            List<ku.by.Object.Row> tmpRowList = new List<ku.by.Object.Row>();
            DataSet ds = new DataSet();

            using(OracleConnection tmpOracleConnection = new OracleConnection(tmpConnectionstring))
            {
                using (OracleDataAdapter tmpDataAdapter = new OracleDataAdapter(f_Sql, tmpOracleConnection))
                {
                    if (tmpOracleConnection.State != ConnectionState.Open)
                    {
                        tmpOracleConnection.Open();
                    }

                    tmpDataAdapter.Fill(ds);
                    tmpOracleConnection.Close();
                }
            }

            var tmpTable = ds.Tables[0];
            foreach (DataRow item in tmpTable.Rows)
            {
                ku.by.Object.Row tmpNewRow = new ku.by.Object.Row();

                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    var tmpColumnName = tmpTable.Columns[i].ColumnName;

                    if (tmpColumnName == "#RowNum")
                    {
                        continue;
                    }

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

        public static System.Collections.Generic.List<byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>> ExecQueryReturnRowsCollection(string f_Sql, string f_KuName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.SelectTable> f_SelectTables)
        {
            string tmpConnectionstring;
            if (!sqlConnections.TryGetValue(f_KuName, out tmpConnectionstring))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }

            DataSet tmpDs = new DataSet();

            using (OracleConnection tmpOracleConnection = new OracleConnection(tmpConnectionstring))
            {
                using (OracleDataAdapter tmpDataAdapter = new OracleDataAdapter(f_Sql, tmpOracleConnection))
                {
                    if (tmpOracleConnection.State != ConnectionState.Open)
                    {
                        tmpOracleConnection.Open();
                    }

                    tmpDataAdapter.Fill(tmpDs);
                    tmpOracleConnection.Close();
                }
            }

            List<list<Row>> tmpReturnValue = new List<list<Row>>();

            for (int index = 0; index < f_SelectTables.Count; index++)
            {
                var tmpTable = tmpDs.Tables[index];
                var tmpSelectTable = f_SelectTables[index];
                list<Object.Row> tmpRowList = new list<Object.Row>();
                foreach (DataRow item in tmpTable.Rows)
                {
                    ku.by.Object.Row tmpNewRow = new ku.by.Object.Row();

                    for (int i = 0; i < item.ItemArray.Length; i++)
                    {
                        var tmpColumnName = tmpTable.Columns[i].ColumnName;

                        if (tmpColumnName == "#RowNum")
                        {
                            continue;
                        }

                        var tmpValue = item.ItemArray[i];
                        ku.by.Object.Cell tmpNewCell = new ku.by.Object.Cell();

                        if (tmpValue is DBNull)
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

        public static void ExecuteExpression(string f_ExecKuName, byForm_Server.ku.by.ToolClass.IExecItem[] f_Results)
        {
            string tmpConnectionstr;

            if (!sqlConnections.TryGetValue(f_ExecKuName, out tmpConnectionstr))
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.DatabaseConnectionReflectionError);
            }
            foreach (IExecItem result in f_Results)
            {
                if (result is SqlIDUResult)
                {
                    var tmpSqlIDURest = (SqlIDUResult)result;

                    if (tmpSqlIDURest.OracleMethodName != null)
                    {
                        ExecuteRowsSql(tmpSqlIDURest.SqlCommandText, tmpSqlIDURest.ExecuteKuName(), tmpSqlIDURest.OracleMethodName);
                    }
                    else
                    {
                        ExecuteNonQuery(tmpSqlIDURest.SqlCommandText, tmpSqlIDURest.ExecuteKuName());
                    }

                    continue;
                }
                else
                {
                    DataSet tmpDs = new DataSet();
                    using (OracleConnection tmpOracleConnection = new OracleConnection(tmpConnectionstr))
                    {
                        using (OracleDataAdapter tmpDataAdapter = new OracleDataAdapter(result.SqlCommandText, tmpOracleConnection))
                        {
                            if (tmpOracleConnection.State != ConnectionState.Open)
                            {
                                tmpOracleConnection.Open();
                            }

                            tmpDataAdapter.Fill(tmpDs);
                            tmpOracleConnection.Close();
                        }
                    }

                    if (tmpDs.Tables.Count == 0)
                    {
                        return;
                    }

                    var tmpTable = tmpDs.Tables[0];
                    result.FillDateset(tmpTable);
                }
            }
        }

        public static void ExecuteTran(string f_Sql, string f_KuName)
        {
            ExecuteNonQuery(f_Sql, f_KuName);
        }
    }
}
