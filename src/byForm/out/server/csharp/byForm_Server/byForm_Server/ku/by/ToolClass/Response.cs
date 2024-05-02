using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.by.ToolClass
{
    public class Response
    {
        public static string ActionResponse(byForm_Server.ku.by.Object.Result f_Result)
        {
            string tmpResultMessage = null;
            if (f_Result.isOk)
            {
                f_Result.info = null;
                tmpResultMessage = SqlInvocation.SqlResult;
            }
            SqlInvocation.SqlResult = null;

            JsonObject tmpResultObj = new JsonObject();
            tmpResultObj.Add("isOk", new BoolValue(f_Result.isOk));

            if (f_Result.info == null)
            {
                tmpResultObj.Add("info", new NullValue());
            }
            else
            {
                tmpResultObj.Add("info", JsonParser.Utils.GetNewStringClass(f_Result.info));
            }
            return JsonParser.Utils.TransformToJson(tmpResultObj);
        }

        public static string SqlExpressionResponse(string f_Path, byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpClassPath = f_Path.Substring(0, f_Path.LastIndexOf('.'));
            var tmpType = Type.GetType(tmpClassPath);
            var tmpPathSpliter = f_Path.Split('.');
            if (tmpType == null)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ReflectTypeOrMethodError, tmpClassPath));
            }

            object tmpInvokeResult = null;
            string tmpSqlCommand = null;
            string tmpResult = null;
            Type tmpParamsPackageType = typeof(ku.by.ToolClass.Sql.ParamsPackage);
            var tmpMethod = tmpType.GetMethod(tmpPathSpliter[tmpPathSpliter.Length - 1], new Type[] { tmpParamsPackageType });
            if (tmpMethod == null)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ReflectTypeOrMethodError, tmpPathSpliter[tmpPathSpliter.Length - 1]));
            }
            try
            {
                tmpInvokeResult = tmpMethod.Invoke(null, new object[] { f_Parameter });
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ThrowHelper.ThrowUnKnownException(ex.Message);
            }

            if (tmpInvokeResult is ku.by.ToolClass.Sql.SelectTable)
            {
                var tmpSelectTable = tmpInvokeResult as Sql.SelectTable;
                tmpSqlCommand = tmpSelectTable.SqlValue;
            }
            else
            {
                var tmpIDUResult = tmpInvokeResult as SqlIDUResult;
                tmpSqlCommand = tmpIDUResult.SqlCommandText;
            }

            if (string.IsNullOrEmpty(tmpSqlCommand))
            {
                return "0";
            }

            string tmpKuName = FindKu(f_Parameter.TableSourceList);
            if (tmpInvokeResult is ku.by.ToolClass.Sql.SelectTable)
            {
                //按查询结果排序
                //若查询成功，返回一个json格式的数组字符串
                var tmpSelectTable = tmpInvokeResult as Sql.SelectTable;
                var tmpIBaseDataSheet = tmpSelectTable.GetSource();
                var tmpRows = SqlHelper.SelectReturnRows(tmpSqlCommand, tmpIBaseDataSheet.KuName, tmpIBaseDataSheet.RealKuName, tmpSelectTable, "_" + f_Parameter.No);
                JsonObject tmpSelectValue = new JsonObject();
                ArrayClass tmpCells = new ArrayClass();
                ArrayClass tmpValueArray = new ArrayClass();
                JsonObject tmpTableMap = new JsonObject();

                foreach (var row in tmpRows)
                {
                    if (tmpCells.Count == 0)
                    {
                        for (int i = 0; i < row.cells.Count; i++)
                        {
                            var cell = row.cells[i];
                            tmpCells.Add(Parse.CellToJson(cell));

                            if (cell.TableAlias != null)
                            {
                                if (!tmpTableMap.ContainsKey(cell.TableAlias))
                                {
                                    tmpTableMap.Add(cell.TableAlias, new ArrayClass());
                                }

                                (tmpTableMap[cell.TableAlias] as ArrayClass).Add(new Num(i.ToString()));
                            }
                        }
                    }

                    ArrayClass tmpValues = new ArrayClass();
                    tmpValueArray.Add(tmpValues);

                    foreach (var cell in row.cells)
                    {
                        var tmpValue = cell.value;
                        if (tmpValue == null)
                        {
                            tmpValues.Add(new NullValue());
                            continue;
                        }

                        if (tmpValue is sbyte || tmpValue is short || tmpValue is int || tmpValue is float || tmpValue is double)
                        {
                            if (tmpValue is double)
                            {
                                double tmpDoubleValue = (double)tmpValue;
                                if (tmpDoubleValue == double.PositiveInfinity)
                                {
                                    ThrowHelper.ThrowParseTransferException(ErrorInfo.PositiveInfinity);
                                }
                            }
                            tmpValues.Add(new Num(tmpValue.ToString()));
                            continue;
                        }

                        if (tmpValue is bool)
                        {
                            tmpValues.Add(new BoolValue(tmpValue.ToString()));
                            continue;
                        }

                        if (tmpValue is string || tmpValue is char || tmpValue is decimal || tmpValue is long || tmpValue is ku.by.Object.datetime)
                        {
                            tmpValues.Add(JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                            continue;
                        }

                        if (tmpValue is DateTime)
                        {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.RawDatetime);
                        }

                        if (tmpValue.GetType().IsEnum)
                        {
                            tmpValues.Add(JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                            continue;
                        }

                        ThrowHelper.ThrowParseTransferException(ErrorInfo.CellValueTypeError);
                    }
                }

                tmpSelectValue.Add("#", new StringClass("SQLSELECT"));

                if (tmpRows.count == 0)
                {
                    tmpSelectValue.Add("$FIELDSMAP", new NullValue());
                }
                else
                {
                    var tmpFieldMap = tmpSelectTable.GetOrmInstance(tmpRows[0]);

                    if (tmpFieldMap == null)
                    {
                        tmpSelectValue.Add("$FIELDSMAP", new NullValue());
                    }
                    else
                    {
                        JsonObject tmpFieldMapJson = new JsonObject();

                        foreach (var fieldMap in tmpFieldMap)
                        {
                            tmpFieldMapJson.Add(fieldMap.Name, new Num(fieldMap.OrmIndex.ToString()));
                        }

                        tmpSelectValue.Add("$FIELDSMAP", tmpFieldMapJson);
                    }
                }

                tmpSelectValue.Add("$FIELDS", tmpCells);
                tmpSelectValue.Add("$VALUES", tmpValueArray);
                tmpSelectValue.Add("$TABLESMAP", tmpTableMap);
                tmpResult = JsonParser.Utils.TransformToJson(tmpSelectValue);
            }

            if (tmpInvokeResult is SqlIDUResult)
            {
                var tmpSqlIDUResult = (SqlIDUResult)tmpInvokeResult;

                if (!string.IsNullOrEmpty(tmpSqlIDUResult.OracleMethodName))
                {
                    tmpResult = OracleHelper.ExecuteRowsSql(tmpSqlCommand, tmpKuName, tmpSqlIDUResult.OracleMethodName).ToString();
                }
                else
                {
                    tmpResult = SqlHelper.ExecuteNonQuery(tmpSqlCommand, tmpKuName).ToString();
                }
            }

            if (tmpResult == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.SqlUnknoweError);
            }

            return tmpResult;
        }

        public static string ExecExpressionResponse(string f_Path, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.ParamsPackage> f_Parameter)
        {
            string tmpClassPath = f_Path.Substring(0, f_Path.LastIndexOf('.'));
            var tmpType = Type.GetType(tmpClassPath);
            var tmpPathSpliter = f_Path.Split('.');
            if (tmpType == null)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ReflectTypeOrMethodError, tmpClassPath));
            }

            Type tmpPackagesType = f_Parameter.GetType();
            var tmpMethod = tmpType.GetMethod(tmpPathSpliter[tmpPathSpliter.Length - 1], new Type[] { tmpPackagesType });

            if (tmpMethod == null)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ReflectTypeOrMethodError, tmpPathSpliter[tmpPathSpliter.Length - 1]));
            }

            ExecObj tmpExecObj;

            try
            {
                tmpExecObj = tmpMethod.Invoke(null, new object[] { f_Parameter }) as ExecObj;
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ThrowHelper.ThrowUnKnownException(ex.Message);
            }

            string tmpKuName = FindKu(f_Parameter[0].TableSourceList);


            if (string.IsNullOrEmpty(tmpExecObj.SqlCommandText))
            {
                return "null";
            }

            var tmpRowsCollection = SqlHelper.ExecQueryReturnRowsCollection(tmpExecObj.SqlCommandText, tmpKuName, tmpExecObj.SelectTables);
            JsonObject tmpResultJson = new JsonObject();
            tmpResultJson.Add("#", new StringClass("EXEC"));

            for (int index = 0; index < tmpRowsCollection.Count; index++)
            {
                var tmpRows = tmpRowsCollection[index];
                var tmpSelectTable = tmpExecObj.SelectTables[index];

                JsonObject tmpSelectValue = new JsonObject();
                ArrayClass tmpCells = new ArrayClass();
                ArrayClass tmpValueArray = new ArrayClass();
                JsonObject tmpTableMap = new JsonObject();

                foreach (var row in tmpRows)
                {
                    if (tmpCells.Count == 0)
                    {
                        for (int i = 0; i < row.cells.Count; i++)
                        {
                            var cell = row.cells[i];
                            tmpCells.Add(Parse.CellToJson(cell));

                            if (cell.TableAlias != null)
                            {
                                if (!tmpTableMap.ContainsKey(cell.TableAlias))
                                {
                                    tmpTableMap.Add(cell.TableAlias, new ArrayClass());
                                }

                                (tmpTableMap[cell.TableAlias] as ArrayClass).Add(new Num(i.ToString()));
                            }
                        }
                    }

                    ArrayClass tmpValues = new ArrayClass();
                    tmpValueArray.Add(tmpValues);

                    foreach (var cell in row.cells)
                    {
                        var tmpValue = cell.value;
                        if (tmpValue == null)
                        {
                            tmpValues.Add(new NullValue());
                            continue;
                        }

                        if (tmpValue is sbyte || tmpValue is short || tmpValue is int || tmpValue is float || tmpValue is double)
                        {
                            if (tmpValue is double)
                            {
                                double tmpDoubleValue = (double)tmpValue;
                                if (tmpDoubleValue == double.PositiveInfinity)
                                {
                                    ThrowHelper.ThrowParseTransferException(ErrorInfo.PositiveInfinity);
                                }
                            }
                            tmpValues.Add(new Num(tmpValue.ToString()));
                            continue;
                        }

                        if (tmpValue is bool)
                        {
                            tmpValues.Add(new BoolValue(tmpValue.ToString()));
                            continue;
                        }

                        if (tmpValue is string || tmpValue is char || tmpValue is decimal || tmpValue is long || tmpValue is ku.by.Object.datetime)
                        {
                            tmpValues.Add(JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                            continue;
                        }

                        if (tmpValue is DateTime)
                        {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.RawDatetime);
                        }

                        if (tmpValue.GetType().IsEnum)
                        {
                            tmpValues.Add(JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                            continue;
                        }

                        ThrowHelper.ThrowParseTransferException(ErrorInfo.CellValueTypeError);
                    }
                }

                tmpSelectValue.Add("#", new StringClass("SQLSELECT"));

                if (tmpRows.count == 0)
                {
                    tmpSelectValue.Add("$FIELDSMAP", new NullValue());
                }
                else
                {
                    var tmpFieldMap = tmpSelectTable.GetOrmInstance(tmpRows[0]);

                    if (tmpFieldMap == null)
                    {
                        tmpSelectValue.Add("$FIELDSMAP", new NullValue());
                    }
                    else
                    {
                        JsonObject tmpFieldMapJson = new JsonObject();

                        foreach (var fieldMap in tmpFieldMap)
                        {
                            tmpFieldMapJson.Add(fieldMap.Name, new Num(fieldMap.OrmIndex.ToString()));
                        }

                        tmpSelectValue.Add("$FIELDSMAP", tmpFieldMapJson);
                    }
                }

                tmpSelectValue.Add("$FIELDS", tmpCells);
                tmpSelectValue.Add("$VALUES", tmpValueArray);
                tmpSelectValue.Add("$TABLESMAP", tmpTableMap);
                tmpResultJson.Add("select" + index, tmpSelectValue);
            }

            var tmpResult = JsonParser.Utils.TransformToJson(tmpResultJson);

            if (tmpResult == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.SqlUnknoweError);
            }

            return tmpResult;
        }

        private static string FindKu(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableList)
        {
            if (f_TableList == null || f_TableList.Count == 0)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SelectCanNotFindKu);
            }

            foreach (var item in f_TableList)
            {
                if (item is Sql.Table)
                {
                    var tmpTable = item as Sql.Table;
                    return tmpTable.Sheet.KuName;
                }

                if (item is Sql.SelectTable)
                {
                    var tmpSelectTable = item as Sql.SelectTable;
                    string tmpKuName = FindKu(tmpSelectTable.TableSources);
                    return tmpKuName;
                }
            }

            throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SelectCanNotFindKu);
        }

        public static string TranResponse(string f_Path, byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameters)
        {
            string tmpClassPath = f_Path.Substring(0, f_Path.LastIndexOf('.'));
            var tmpType = Type.GetType(tmpClassPath);
            var tmpPathSpliter = f_Path.Split('.');
            var tmpMethod = tmpType.GetMethod(tmpPathSpliter[tmpPathSpliter.Length - 1]);
            if (tmpMethod == null)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ReflectTypeOrMethodError, tmpPathSpliter[tmpPathSpliter.Length - 1]));
            }
            string tmpInvokeResult = null;
            try
            {
                tmpInvokeResult = (string)tmpMethod.Invoke(null, new object[] { f_Parameters });
            }
            catch(System.Reflection.TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ThrowHelper.ThrowUnKnownException(ex.Message);
            }
            SqlHelper.ExecuteTran(tmpInvokeResult, f_Parameters.ExecuteKuName, f_Parameters.KuName + "_" + f_Parameters.MethodName);
            return null;
        }

        public static string FuncResponse(byForm_Server.ku.by.ToolClass.Parse f_Parse, System.Reflection.MethodInfo f_Method, object f_Target, object[] f_Arguements)
        {
            bool tmpTypeIsVoid = false;
            if (f_Method.ReturnType.FullName == "System.Void")
            {
                //返回值为void
                tmpTypeIsVoid = true;
            }

            object tmpResult;
            try
            {
                tmpResult = f_Method.Invoke(f_Target, f_Arguements);
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ThrowHelper.ThrowUnKnownException(ex.Message);
            }

            if (tmpResult == null || tmpTypeIsVoid)
            {
                return null;
            }

            Type tmpResultType = tmpResult.GetType();
            if (tmpResultType == ToolFunction.charType || tmpResultType == ToolFunction.stringType || tmpResultType == ToolFunction.longType || tmpResultType == ToolFunction.decimalType || tmpResultType == ToolFunction.dateTimeType)
            {
                return "\"" + tmpResult.ToString() + "\"";
            }

            if (tmpResultType == ToolFunction.byteType || tmpResultType == ToolFunction.shortType || tmpResultType == ToolFunction.intType || tmpResultType == ToolFunction.floatType || tmpResultType == ToolFunction.doubleType || tmpResultType == ToolFunction.boolType)
            {
                return tmpResult.ToString();
            }

            var tmpType = tmpResult.GetType();
            var tmpObjJson = f_Parse.ObjToJson(tmpResult, tmpType);
            return JsonParser.Utils.TransformToJson(tmpObjJson);
        }
    }
}
