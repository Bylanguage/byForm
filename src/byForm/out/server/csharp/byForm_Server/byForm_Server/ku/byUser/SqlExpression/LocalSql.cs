using System;
using System.Collections.Generic;
using System.Linq;
using byForm_Server.ku.by.ToolClass.Sql;
using byForm_Server.ku.by.ToolClass;
using System.Text;
namespace byForm_Server.ku.byUser.SqlExpression
{
    public class LocalSql
    {
        public static byForm_Server.ku.by.ToolClass.SqlType _1(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "1");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._1(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.Orm0> _0(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "0");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as ITableSource;
            var tmpTable0 = tmpSource0.Source;
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            var tmpSource1 = f_Tables[1] as byForm_Server.ku.byUser.Identity.userAdmin;
            var tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
            var tmpTable1 = new Table(tmpDataSheet1, null);
            tmpTableList.Add(tmpTable1);
            tmpTable0.IsOuterTable = false;
            tmpTable1.Alias = "b";
            var tmpSource2 = f_Tables[2] as byForm_Server.ku.byUser.Identity.userICO;
            var tmpDataSheet2 = Root.GetInstance().GetDataSheetByInstance(tmpSource2);
            var tmpTable2 = new Table(tmpDataSheet2, null);
            tmpTableList.Add(tmpTable2);
            tmpTable0.IsOuterTable = false;
            tmpTable2.Alias = "c";
            SelectTable tmpSelectTable = SqlExpression.sql._0(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_0");
            by.Object.list<byForm_Server.ku.byUser.Orm.Orm0> tmpOrmList = new by.Object.list<byForm_Server.ku.byUser.Orm.Orm0>();
            OrmResult<byForm_Server.ku.byUser.Orm.Orm0> tmpResult = new OrmResult<byForm_Server.ku.byUser.Orm.Orm0>();
            foreach (var selectRow in tmpValue)
            {
                var tmpOrm = new byForm_Server.ku.byUser.Orm.Orm0();
                tmpOrm.SetValue(tmpSelectTable, selectRow);
                tmpOrmList.Add(tmpOrm);
            }
            tmpResult.Source = tmpSelectTable;
            tmpResult.rows = tmpOrmList;
            return tmpResult;
        }

        public static int _2(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "2");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byUser.SqlExpression.sql._2(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _3(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "3");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._3(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_3");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static int _4(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParamList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParamList, "4");
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }

            var tmpSqlResult = ku.byUser.SqlExpression.sql._4(tmpParamsPackage);
            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpDataSheet0.KuName);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _5(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "5");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._5(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_5");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _6(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "6");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._6(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_6");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _7(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "7");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._7(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_7");
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
            tmpParamsList.Add(_8(new ITableSource[] { f_Identity[0] }, f_Params[0]));
            string tmpSql = SqlExpression.sql.Tran_0(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byUser_Tran_0");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _8(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParamList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParamList, "8");
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }

            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _9(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "9");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._9(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_9");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _10(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "10");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._10(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_10");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _11(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "11");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._11(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_11");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
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

        public static byForm_Server.ku.by.ToolClass.SqlType _14(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "14");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._14(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_14");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._15(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_15");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._16(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_16");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _17(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "17");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.anonymous;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "b";
            var tmpSource1 = f_Tables[1] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
            var tmpTable1 = new Table(tmpDataSheet1, null);
            tmpTableList.Add(tmpTable1);
            tmpTable1.IsOuterTable = true;
            tmpTable1.Alias = "a";
            return sql._17(tmpParamsPackage);
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._19(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.Orm0> _18(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "18");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as ITableSource;
            var tmpTable0 = tmpSource0.Source;
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            var tmpSource1 = f_Tables[1] as byForm_Server.ku.byUser.Identity.userAdmin;
            var tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
            var tmpTable1 = new Table(tmpDataSheet1, null);
            tmpTableList.Add(tmpTable1);
            tmpTable0.IsOuterTable = false;
            tmpTable1.Alias = "b";
            var tmpSource2 = f_Tables[2] as byForm_Server.ku.byUser.Identity.userICO;
            var tmpDataSheet2 = Root.GetInstance().GetDataSheetByInstance(tmpSource2);
            var tmpTable2 = new Table(tmpDataSheet2, null);
            tmpTableList.Add(tmpTable2);
            tmpTable0.IsOuterTable = false;
            tmpTable2.Alias = "c";
            SelectTable tmpSelectTable = SqlExpression.sql._18(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_18");
            by.Object.list<byForm_Server.ku.byUser.Orm.Orm0> tmpOrmList = new by.Object.list<byForm_Server.ku.byUser.Orm.Orm0>();
            OrmResult<byForm_Server.ku.byUser.Orm.Orm0> tmpResult = new OrmResult<byForm_Server.ku.byUser.Orm.Orm0>();
            foreach (var selectRow in tmpValue)
            {
                var tmpOrm = new byForm_Server.ku.byUser.Orm.Orm0();
                tmpOrm.SetValue(tmpSelectTable, selectRow);
                tmpOrmList.Add(tmpOrm);
            }
            tmpResult.Source = tmpSelectTable;
            tmpResult.rows = tmpOrmList;
            return tmpResult;
        }

        public static void Tran_1(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_20(f_Params[0]));
            tmpParamsList.Add(_21(f_Params[1]));
            string tmpSql = SqlExpression.sql.Tran_1(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byUser_Tran_1");
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

        public static byForm_Server.ku.by.ToolClass.SqlType _23(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "23");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._23(tmpParamsPackage);
            return new SqlType(null, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.Orm0> _22(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "22");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as ITableSource;
            var tmpTable0 = tmpSource0.Source;
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            var tmpSource1 = f_Tables[1] as byForm_Server.ku.byUser.Identity.userAdmin;
            var tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
            var tmpTable1 = new Table(tmpDataSheet1, null);
            tmpTableList.Add(tmpTable1);
            tmpTable0.IsOuterTable = false;
            tmpTable1.Alias = "b";
            var tmpSource2 = f_Tables[2] as byForm_Server.ku.byUser.Identity.userICO;
            var tmpDataSheet2 = Root.GetInstance().GetDataSheetByInstance(tmpSource2);
            var tmpTable2 = new Table(tmpDataSheet2, null);
            tmpTableList.Add(tmpTable2);
            tmpTable0.IsOuterTable = false;
            tmpTable2.Alias = "c";
            SelectTable tmpSelectTable = SqlExpression.sql._22(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_22");
            by.Object.list<byForm_Server.ku.byUser.Orm.Orm0> tmpOrmList = new by.Object.list<byForm_Server.ku.byUser.Orm.Orm0>();
            OrmResult<byForm_Server.ku.byUser.Orm.Orm0> tmpResult = new OrmResult<byForm_Server.ku.byUser.Orm.Orm0>();
            foreach (var selectRow in tmpValue)
            {
                var tmpOrm = new byForm_Server.ku.byUser.Orm.Orm0();
                tmpOrm.SetValue(tmpSelectTable, selectRow);
                tmpOrmList.Add(tmpOrm);
            }
            tmpResult.Source = tmpSelectTable;
            tmpResult.rows = tmpOrmList;
            return tmpResult;
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _24(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "24");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._24(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_24");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _26(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "26");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.userICO;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._26(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_26");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static void Tran_2(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_27(f_Params[0]));
            tmpParamsList.Add(_28(f_Params[1]));
            string tmpSql = SqlExpression.sql.Tran_2(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byUser_Tran_2");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _27(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "27");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _28(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "28");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static void Tran_3(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_29(f_Params[0]));
            tmpParamsList.Add(_30(f_Params[1]));
            string tmpSql = SqlExpression.sql.Tran_3(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byUser_Tran_3");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _29(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "29");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _30(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "30");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static int _31(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "31");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byUser.SqlExpression.sql._31(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static byForm_Server.ku.by.ToolClass.SqlType _32(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "32");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.userAdmin;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._32(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_32");
            foreach (var selectRow in tmpValue)
            {
                selectRow.Identity = tmpTableList[0].GetIdentity();
                //var tmpRowSheet = tmpTableList[0].GetSource();
            }
            return new SqlType(tmpValue, tmpSelectTable);
        }

        public static byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.Orm1> _33(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "33");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.userAdmin;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            var tmpSource1 = f_Tables[1] as byForm_Server.ku.byUser.Identity.user;
            var tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
            var tmpTable1 = new Table(tmpDataSheet1, null);
            tmpTableList.Add(tmpTable1);
            tmpTable1.IsOuterTable = false;
            tmpTable1.Alias = "b";
            SelectTable tmpSelectTable = SqlExpression.sql._33(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_33");
            by.Object.list<byForm_Server.ku.byUser.Orm.Orm1> tmpOrmList = new by.Object.list<byForm_Server.ku.byUser.Orm.Orm1>();
            OrmResult<byForm_Server.ku.byUser.Orm.Orm1> tmpResult = new OrmResult<byForm_Server.ku.byUser.Orm.Orm1>();
            foreach (var selectRow in tmpValue)
            {
                var tmpOrm = new byForm_Server.ku.byUser.Orm.Orm1();
                tmpOrm.SetValue(tmpSelectTable, selectRow);
                tmpOrmList.Add(tmpOrm);
            }
            tmpResult.Source = tmpSelectTable;
            tmpResult.rows = tmpOrmList;
            return tmpResult;
        }

        public static int _34(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "34");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byUser.SqlExpression.sql._34(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }

        public static int _35(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "35");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byUser.SqlExpression.sql._35(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
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
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.user;
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

        public static byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.TemporaryOrm0> _38(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "38");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.userAdmin;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._38(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_38");
            by.Object.list<byForm_Server.ku.byUser.Orm.TemporaryOrm0> tmpOrmList = new by.Object.list<byForm_Server.ku.byUser.Orm.TemporaryOrm0>();
            OrmResult<byForm_Server.ku.byUser.Orm.TemporaryOrm0> tmpResult = new OrmResult<byForm_Server.ku.byUser.Orm.TemporaryOrm0>();
            foreach (var selectRow in tmpValue)
            {
                var tmpOrm = new byForm_Server.ku.byUser.Orm.TemporaryOrm0();
                tmpOrm.SetValue(tmpSelectTable, selectRow);
                tmpOrmList.Add(tmpOrm);
            }
            tmpResult.Source = tmpSelectTable;
            tmpResult.rows = tmpOrmList;
            return tmpResult;
        }

        public static byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.TemporaryOrm1> _39(byForm_Server.ku.by.ToolClass.ITableSource[] f_Tables, object[] f_Params)
        {
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<object> tmpParameterList = new List<object>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList, "39");
            foreach (var item in f_Params)
            {
                tmpParameterList.Add(item);
            }
            var tmpSource0 = f_Tables[0] as byForm_Server.ku.byUser.Identity.userAdmin;
            var tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
            var tmpTable0 = new Table(tmpDataSheet0, null);
            tmpTableList.Add(tmpTable0);
            tmpTable0.IsOuterTable = false;
            tmpTable0.Alias = "a";
            SelectTable tmpSelectTable = SqlExpression.sql._39(tmpParamsPackage);
            string tmpSql = tmpSelectTable.SqlValue;
            var tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().KuName, tmpTable0.GetSource().RealKuName, tmpSelectTable, "_39");
            by.Object.list<byForm_Server.ku.byUser.Orm.TemporaryOrm1> tmpOrmList = new by.Object.list<byForm_Server.ku.byUser.Orm.TemporaryOrm1>();
            OrmResult<byForm_Server.ku.byUser.Orm.TemporaryOrm1> tmpResult = new OrmResult<byForm_Server.ku.byUser.Orm.TemporaryOrm1>();
            foreach (var selectRow in tmpValue)
            {
                var tmpOrm = new byForm_Server.ku.byUser.Orm.TemporaryOrm1();
                tmpOrm.SetValue(tmpSelectTable, selectRow);
                tmpOrmList.Add(tmpOrm);
            }
            tmpResult.Source = tmpSelectTable;
            tmpResult.rows = tmpOrmList;
            return tmpResult;
        }

        public static void Tran_4(byForm_Server.ku.by.ToolClass.ITableSource[] f_Identity, System.Collections.Generic.List<object[]> f_Params, System.Collections.Generic.List<object> f_Values)
        {
            List<ParamsPackage> tmpParamsList = new List<ParamsPackage>();
            TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
            tmpParamsList.Add(_40(f_Params[0]));
            tmpParamsList.Add(_41(f_Params[1]));
            string tmpSql = SqlExpression.sql.Tran_4(tmpPackage);
            ku.by.ToolClass.SqlHelper.ExecuteTran(tmpSql, tmpPackage.ExecuteKuName, "byUser_Tran_4");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _40(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "40");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.ParamsPackage _41(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "41");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            return tmpParamsPackage;
        }
    }
}
