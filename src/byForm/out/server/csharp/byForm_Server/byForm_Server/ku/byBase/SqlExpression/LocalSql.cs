using System;
using System.Collections.Generic;
using System.Linq;
using byForm_Server.ku.by.ToolClass.Sql;
using byForm_Server.ku.by.ToolClass;
using System.Text;
namespace byForm_Server.ku.byBase.SqlExpression
{
    public class LocalSql
    {
        public static byForm_Server.ku.by.ToolClass.SqlType _0(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "0");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.popupTable;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._0(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_0");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _1(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "1");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.Tree;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._1(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_1");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static void Tran_0(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_2(f_Params[0]));
            tmpParamsList.Add(_3(f_Params[1]));
            string tmpSql = SqlExpression.sql.Tran_0(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_0");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _2(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "2");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _3(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "3");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static void Tran_1(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_4(f_Params[0]));
            tmpParamsList.Add(_5(f_Params[1]));
            tmpParamsList.Add(_6(f_Params[2]));
            tmpParamsList.Add(_7(f_Params[3]));
            string tmpSql = SqlExpression.sql.Tran_1(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_1");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _4(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "4");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _5(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "5");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _6(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "6");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _7(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "7");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static void Tran_2(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_8(f_Params[0]));
            tmpParamsList.Add(_9(f_Params[1]));
            string tmpSql = SqlExpression.sql.Tran_2(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_2");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _8(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "8");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _9(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "9");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.bridge;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._12(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_12");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.bridge;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._13(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_13");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static void Tran_3(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_14(f_Params[0]));
            tmpParamsList.Add(_15(f_Params[1]));
            string tmpSql = SqlExpression.sql.Tran_3(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_3");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _14(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "14");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _15(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "15");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static void Tran_4(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_16(f_Params[0]));
            string tmpSql = SqlExpression.sql.Tran_4(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_4");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _16(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "16");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static void Tran_5(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_17(f_Params[0]));
            tmpParamsList.Add(_18(f_Params[1]));
            string tmpSql = SqlExpression.sql.Tran_5(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_5");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _17(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "17");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _18(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "18");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static int _19(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "19");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byBase.SqlExpression.sql._19(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _23(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "23");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.extend;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._23(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_23");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static int _24(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "24");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byBase.SqlExpression.sql._24(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static int _25(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "25");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byBase.SqlExpression.sql._25(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static int _26(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "26");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byBase.SqlExpression.sql._26(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _30(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "30");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.detail;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._30(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_30");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static void Tran_8(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_31(f_Params[0]));
            string tmpSql = SqlExpression.sql.Tran_8(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_8");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _31(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "31");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static void Tran_9(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_32(f_Params[0]));
            string tmpSql = SqlExpression.sql.Tran_9(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_9");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _32(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "32");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static void Tran_10(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_33(f_Params[0]));
            string tmpSql = SqlExpression.sql.Tran_10(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byBase_Tran_10");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _33(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "33");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _34(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "34");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.dic;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._34(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_34");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _35(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "35");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.dic;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._35(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_35");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _36(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "36");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.dic;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._36(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_36");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byBase.Identity.dic;
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
