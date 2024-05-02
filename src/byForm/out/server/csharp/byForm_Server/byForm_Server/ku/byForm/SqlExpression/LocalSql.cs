using System;
using System.Collections.Generic;
using System.Linq;
using byForm_Server.ku.by.ToolClass.Sql;
using byForm_Server.ku.by.ToolClass;
using System.Text;
namespace byForm_Server.ku.byForm.SqlExpression
{
    public class LocalSql
    {
        public static int _8(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "8");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byForm.SqlExpression.sql._8(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static int _9(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "9");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byForm.SqlExpression.sql._9(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static int _11(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParamList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParamList, "11");
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.formField;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }

            var tmpSqlResult = ku.byForm.SqlExpression.sql._11(tmpParamsPackage);
            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpDataSheet0.KuName);
        }

        public static byForm_Server.ku.by.ToolClass.ExecResult ExecResult_0(int[] f_Index, byForm_Server.ku.by.ToolClass.IExecItem[] f_QueryResults)
        {
            string tmpDecKuName = f_QueryResults[0].DecKuName();
            string tmpExecuteKuName = f_QueryResults[0].ExecuteKuName();
            SqlHelper.ExecuteExpression(tmpDecKuName, tmpExecuteKuName, f_QueryResults);
            return new ExecResult(f_Index, f_QueryResults);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _12(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "12");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.form;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._12(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _13(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "13");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.formField;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "b";
            SelectTable tmpSelectTable = SqlExpression.sql._13(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.ExecResult ExecResult_1(int[] f_Index, byForm_Server.ku.by.ToolClass.IExecItem[] f_QueryResults)
        {
            string tmpDecKuName = f_QueryResults[0].DecKuName();
            string tmpExecuteKuName = f_QueryResults[0].ExecuteKuName();
            SqlHelper.ExecuteExpression(tmpDecKuName, tmpExecuteKuName, f_QueryResults);
            return new ExecResult(f_Index, f_QueryResults);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _14(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "14");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.form;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._14(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _15(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "15");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.formField;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "b";
            SelectTable tmpSelectTable = SqlExpression.sql._15(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.ExecResult ExecResult_2(int[] f_Index, byForm_Server.ku.by.ToolClass.IExecItem[] f_QueryResults)
        {
            string tmpDecKuName = f_QueryResults[0].DecKuName();
            string tmpExecuteKuName = f_QueryResults[0].ExecuteKuName();
            SqlHelper.ExecuteExpression(tmpDecKuName, tmpExecuteKuName, f_QueryResults);
            return new ExecResult(f_Index, f_QueryResults);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _16(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "16");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.formData;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._16(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _17(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "17");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.formData;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._17(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _18(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "18");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.formData;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._18(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _19(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "19");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.formData;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._19(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static void Tran_0(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_20(f_Params[0]));
            tmpParamsList.Add(_21(f_Params[1]));
            tmpParamsList.Add(_22(f_Params[2]));
            string tmpSql = SqlExpression.sql.Tran_0(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byForm_Tran_0");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _20(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "20");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _21(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "21");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _22(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "22");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _37(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "37");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byForm.Identity.fieldTemplate;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._37(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_37");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }
    }
}
