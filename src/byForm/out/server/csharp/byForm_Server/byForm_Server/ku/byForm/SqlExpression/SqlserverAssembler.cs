using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Sql;
namespace byForm_Server.ku.byForm.SqlExpression
{
    public class SqlserverAssembler
    {
        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _0(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "0");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _1(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "1");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _2(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "2");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _3(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "3");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _4(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "4");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _5(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFieldID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "5");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _6(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "6");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _7(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFieldID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "7");
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _8(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            return new SqlIDUResult(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.SqlServer), null, ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _9(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            StringBuilder tmpWhere = new StringBuilder();
            if (!(tmpRowParameter is ku.by.Object.Row))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return new SqlIDUResult("", null, null);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            string tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.SqlServer);

            if (string.IsNullOrEmpty(tmpUpdateSql))
            {
                return new SqlIDUResult("", null, null);
                //return "";
            }

            return new SqlIDUResult(tmpUpdateSql, null, tmpDataSheet.KuName);
            //return tmpUpdateSql;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _10(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "data";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("data.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "10");
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _11(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTableList.Add(tmpTable0);
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            tmpSql.Append(ToolFunction.GenerateDeleteFrom(tmpTable0, DBTypeEnum.SqlServer));
            tmpSql.Append(tmpWhere);
            return new SqlIDUResult(tmpSql.ToString(), null, tmpTable0.KuName);
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _12(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iUserID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "12");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _13(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iUserID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "13");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _14(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "14");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _15(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "15");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _16(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "16");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _17(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "17");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _18(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "18");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _19(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "19");
        }

        public static string _20(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.SqlServer);
        }

        public static string _21(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            if (!(tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("SET @{0} = 0", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpUpdateSql = ToolFunction.FillUpdateRow(row, tmpSetList, tmpWhere, DBTypeEnum.SqlServer);

                if (string.IsNullOrEmpty(tmpUpdateSql))
                {
                    continue;
                }

                tmpSql.Append(tmpUpdateSql);
                tmpSql.AppendLine(string.Format("SET @{0} = @{0} + @@ROWCOUNT", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static string _22(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("SET @{0} = 0", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.SqlServer);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.AppendLine(tmpDeleteSql);
                tmpSql.AppendLine(string.Format("SET @{0} = @{0} + @@ROWCOUNT", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _23(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "23");
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _24(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            return new SqlIDUResult(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.SqlServer), null, ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _25(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            StringBuilder tmpWhere = new StringBuilder();
            if (!(tmpRowParameter is ku.by.Object.Row))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return new SqlIDUResult("", null, null);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            string tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.SqlServer);

            if (string.IsNullOrEmpty(tmpUpdateSql))
            {
                return new SqlIDUResult("", null, null);
                //return "";
            }

            return new SqlIDUResult(tmpUpdateSql, null, tmpDataSheet.KuName);
            //return tmpUpdateSql;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _26(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpOrderByList.Add(new OrderByField(ToolFunction.GetOrderByField("a.iFieldNO", tmpSelectFieldList, tmpTableList, DBTypeEnum.SqlServer), false));
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            ToolFunction.GenerateOrderBy(tmpOrderByList, tmpOrderBy);
            tmpSql.Append(tmpOrderBy);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "26");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _27(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "27");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _28(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "28");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _29(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "r";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("r.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("r.iUserID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "29");
        }

        public static string _30(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTableList.Add(tmpTable0);
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            tmpSql.Append(ToolFunction.GenerateDeleteFrom(tmpTable0, DBTypeEnum.SqlServer));
            tmpSql.Append(tmpWhere);
            tmpSql.Append("\r\n");
            return tmpSql.ToString();
        }

        public static string _31(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTableList.Add(tmpTable0);
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            tmpSql.Append(ToolFunction.GenerateDeleteFrom(tmpTable0, DBTypeEnum.SqlServer));
            tmpSql.Append(tmpWhere);
            tmpSql.Append("\r\n");
            return tmpSql.ToString();
        }

        public static string _32(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            StringBuilder tmpWhere = new StringBuilder();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return string.Format("SET @{0} = 0\r\n", f_EffectedCount);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("SET @{0} = 0;", f_EffectedCount));
            string tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.SqlServer);

            if (string.IsNullOrEmpty(tmpDeleteSql))
            {
                return tmpSql.ToString();
            }

            tmpSql.Append(tmpDeleteSql);
            tmpSql.AppendLine(string.Format("SET @{0} = @@ROWCOUNT", f_EffectedCount));
            return tmpSql.ToString();

        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _33(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            return new SqlIDUResult(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.SqlServer), null, ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _34(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "34");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _35(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "35");
        }

        public static string _36(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder();
            var tmpInsertValues = ToolFunction.GetNewInsertValues();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            ToolFunction.FillInsertValues(tmpInsertValues, f_Parameter.ParameterList[0], tmpTable0, DBTypeEnum.SqlServer);
            tmpSql.Append(ToolFunction.GenerateSqlByInsertValues(tmpInsertValues, tmpTable0.Sheet, DBTypeEnum.SqlServer));
            return tmpSql.ToString();
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _37(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpOrderByList.Add(new OrderByField(ToolFunction.GetOrderByField("a.iCreateDt", tmpSelectFieldList, tmpTableList, DBTypeEnum.SqlServer), false));
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            ToolFunction.GenerateOrderBy(tmpOrderByList, tmpOrderBy);
            tmpSql.Append(tmpOrderBy);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byForm", null, "37");
        }

        public static string Tran_0(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            tmpTran.AppendLine("SET LOCK_TIMEOUT 3000\r\nSET XACT_ABORT ON");
            tmpTran.AppendLine("BEGIN TRAN");
            tmpTran.AppendLine("DECLARE @EffectedCount INT");
            tmpTran.Append("IF ");
            string tmpLocalDec_0 = SaveInspect.CharactorEscape(f_TranParmas.Values[0]);
            string tmpLocalDec_1 = SaveInspect.CharactorEscape("insert");
            tmpTran.Append(ToolFunction.EqualExpression(tmpLocalDec_0, tmpLocalDec_1));

            tmpTran.AppendLine(" ");
            tmpTran.Append(_20(f_TranParmas.Paramters[0], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.Append("ELSE ");
            tmpTran.Append("IF ");
            string tmpLocalDec_2 = SaveInspect.CharactorEscape(f_TranParmas.Values[0]);
            string tmpLocalDec_3 = SaveInspect.CharactorEscape("update");
            tmpTran.Append(ToolFunction.EqualExpression(tmpLocalDec_2, tmpLocalDec_3));

            tmpTran.AppendLine(" ");
            tmpTran.Append(_21(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.Append("ELSE ");
            tmpTran.Append("IF ");
            string tmpLocalDec_4 = SaveInspect.CharactorEscape(f_TranParmas.Values[0]);
            string tmpLocalDec_5 = SaveInspect.CharactorEscape("delete");
            tmpTran.Append(ToolFunction.EqualExpression(tmpLocalDec_4, tmpLocalDec_5));

            tmpTran.AppendLine(" ");
            tmpTran.Append(_22(f_TranParmas.Paramters[2], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.AppendLine("COMMIT TRAN");
            return tmpTran.ToString();
        }

        public static string Tran_1(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            tmpTran.AppendLine("SET LOCK_TIMEOUT 3000\r\nSET XACT_ABORT ON");
            tmpTran.AppendLine("BEGIN TRAN");
            tmpTran.AppendLine("DECLARE @EffectedCount INT");
            tmpTran.Append(_30(f_TranParmas.Paramters[0]));
            tmpTran.AppendLine();
            tmpTran.Append(_31(f_TranParmas.Paramters[1]));
            tmpTran.AppendLine();
            tmpTran.Append(_32(f_TranParmas.Paramters[2], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.AppendLine("COMMIT TRAN");
            return tmpTran.ToString();
        }

        public static string Tran_2(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            tmpTran.AppendLine("SET LOCK_TIMEOUT 3000\r\nSET XACT_ABORT ON");
            tmpTran.AppendLine("BEGIN TRAN");
            tmpTran.AppendLine("DECLARE @EffectedCount INT");
            tmpTran.Append(_36(f_TranParmas.Paramters[0]));
            tmpTran.AppendLine();
            tmpTran.AppendLine("COMMIT TRAN");
            return tmpTran.ToString();
        }
    }
}
