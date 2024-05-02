using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Sql;
namespace byForm_Server.ku.byUser.SqlExpression
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
            var tmpTable0 = f_Parameter.TableSourceList[0] as SelectTable;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpTable1 = f_Parameter.TableSourceList[1] as Table;
            tmpTableList.Add(tmpTable1);
            tmpTable1.Alias = "b";
            tmpTable0.JoinTables.Add(new JoinTable(tmpTable1));
            tmpTable0.JoinTables[0].JoinMode = " left join ";
            StringBuilder tmpCondition1 = new StringBuilder(" on ");
            tmpCondition1.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList)));
            tmpTable0.JoinTables[0].Condition = tmpCondition1;
            var tmpTable2 = f_Parameter.TableSourceList[2] as Table;
            tmpTableList.Add(tmpTable2);
            tmpTable2.Alias = "c";
            tmpTable0.JoinTables.Add(new JoinTable(tmpTable2));
            tmpTable0.JoinTables[1].JoinMode = " left join ";
            StringBuilder tmpCondition2 = new StringBuilder(" on ");
            tmpCondition2.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("c.iID", tmpTableList)));
            tmpTable0.JoinTables[1].Condition = tmpCondition2;
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            var tmpPlusField0 = new PlusField(tmpTable1);
            tmpPlusField0.AddField("b.iID", tmpTableList);
            tmpPlusField0.AddField("b.iUserMode", tmpTableList);
            tmpPlusField0.AddField("b.iDt", tmpTableList);
            tmpPlusField0.AddField("b.rUser", tmpTableList);
            tmpSelectFieldList.Add(tmpPlusField0);
            var tmpField1 = new LiteralField(SaveInspect.CharactorEscape(f_Parameter.ParameterList[0]), DataTypeEnum.String);
            tmpField1.Alias = "userIcoPath";
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("c.iFileName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("c.iExtendName", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", byForm_Server.ku.byUser.Orm.Orm0.GenetateTemOrm, "0");
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
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iRank", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            tmpWhere.Append(" AND ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iPassword", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[1])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "1");
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _2(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            return new SqlIDUResult(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.SqlServer), null, ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));
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
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            tmpWhere.Append(" AND ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iPassword", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[1])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "3");
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _4(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder();
            StringBuilder tmpSet = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<Field> tmpSetFields = new List<Field>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTableList.Add(tmpTable0);
            tmpTable0.Alias = "a";
            tmpSet.Append(" SET ");
            tmpSet.Append(ToolFunction.SqlserverSetAssignmentExpression((TableField)ToolFunction.ConvertFieldNameToField("a.iPassword", tmpTableList), " = ", SaveInspect.CharactorEscape(f_Parameter.ParameterList[0]), tmpSetFields, tmpSet));

            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[1])));
            tmpSql.Append("UPDATE ");
            tmpSql.Append("a");
            tmpSql.Append(tmpSet);
            tmpSql.Append(" FROM ");
            tmpSql.Append(tmpTable0.TableDec);
            tmpSql.Append(tmpWhere);
            return new SqlIDUResult(tmpSql.ToString(), null, tmpTable0.KuName);
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
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "5");
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "6");
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
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "7");
        }

        public static string _8(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder();
            StringBuilder tmpSet = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<Field> tmpSetFields = new List<Field>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTableList.Add(tmpTable0);
            tmpTable0.Alias = "a";
            tmpSet.Append(" SET ");
            tmpSet.Append(ToolFunction.SqlserverSetAssignmentExpression((TableField)ToolFunction.ConvertFieldNameToField("a.iPassword", tmpTableList), " = ", SaveInspect.CharactorEscape(f_Parameter.ParameterList[0]), tmpSetFields, tmpSet));

            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[1])));
            tmpSql.Append("UPDATE ");
            tmpSql.Append("a");
            tmpSql.Append(tmpSet);
            tmpSql.Append(" FROM ");
            tmpSql.Append(tmpTable0.TableDec);
            tmpSql.Append(tmpWhere);
            tmpSql.Append("\r\n");
            return tmpSql.ToString();
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _9(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "9");
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
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "10");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _11(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "11");
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "12");
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
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "13");
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "14");
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
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "15");
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iRank", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList).FieldAccess);
            tmpWhere.Append(" in (");
            tmpWhere.Append(((SelectTable)f_Parameter.ParameterList[0]).SqlValue);
            tmpWhere.Append(")");
            tmpWhere.Append(" AND ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iRank", tmpTableList), "'anonymous'"));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "16");
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
            tmpTable0.Alias = "b";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpTable1 = f_Parameter.TableSourceList[1] as Table;
            tmpTable1.Alias = "a";
            tmpTableList.Add(tmpTable1);
            var tmpField0 = ToolFunction.ConvertComponentToTableField("b.iUserID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "17");
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
            var tmpTable0 = f_Parameter.TableSourceList[0] as SelectTable;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpTable1 = f_Parameter.TableSourceList[1] as Table;
            tmpTableList.Add(tmpTable1);
            tmpTable1.Alias = "b";
            tmpTable0.JoinTables.Add(new JoinTable(tmpTable1));
            tmpTable0.JoinTables[0].JoinMode = " left join ";
            StringBuilder tmpCondition1 = new StringBuilder(" on ");
            tmpCondition1.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList)));
            tmpTable0.JoinTables[0].Condition = tmpCondition1;
            var tmpTable2 = f_Parameter.TableSourceList[2] as Table;
            tmpTableList.Add(tmpTable2);
            tmpTable2.Alias = "c";
            tmpTable0.JoinTables.Add(new JoinTable(tmpTable2));
            tmpTable0.JoinTables[1].JoinMode = " left join ";
            StringBuilder tmpCondition2 = new StringBuilder(" on ");
            tmpCondition2.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("c.iID", tmpTableList)));
            tmpTable0.JoinTables[1].Condition = tmpCondition2;
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            var tmpPlusField0 = new PlusField(tmpTable1);
            tmpPlusField0.AddField("b.iID", tmpTableList);
            tmpPlusField0.AddField("b.iUserMode", tmpTableList);
            tmpPlusField0.AddField("b.iDt", tmpTableList);
            tmpPlusField0.AddField("b.rUser", tmpTableList);
            tmpSelectFieldList.Add(tmpPlusField0);
            var tmpField1 = new LiteralField(SaveInspect.CharactorEscape(f_Parameter.ParameterList[0]), DataTypeEnum.String);
            tmpField1.Alias = "userIcoPath";
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("c.iFileName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("c.iExtendName", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", byForm_Server.ku.byUser.Orm.Orm0.GenetateTemOrm, "18");
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iRank", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "19");
        }

        public static string _20(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.SqlServer);
        }

        public static string _21(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.SqlServer);
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _22(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpTable0 = f_Parameter.TableSourceList[0] as SelectTable;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            var tmpTable1 = f_Parameter.TableSourceList[1] as Table;
            tmpTableList.Add(tmpTable1);
            tmpTable1.Alias = "b";
            tmpTable0.JoinTables.Add(new JoinTable(tmpTable1));
            tmpTable0.JoinTables[0].JoinMode = " left join ";
            StringBuilder tmpCondition1 = new StringBuilder(" on ");
            tmpCondition1.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList)));
            tmpTable0.JoinTables[0].Condition = tmpCondition1;
            var tmpTable2 = f_Parameter.TableSourceList[2] as Table;
            tmpTableList.Add(tmpTable2);
            tmpTable2.Alias = "c";
            tmpTable0.JoinTables.Add(new JoinTable(tmpTable2));
            tmpTable0.JoinTables[1].JoinMode = " left join ";
            StringBuilder tmpCondition2 = new StringBuilder(" on ");
            tmpCondition2.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("c.iID", tmpTableList)));
            tmpTable0.JoinTables[1].Condition = tmpCondition2;
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            var tmpPlusField0 = new PlusField(tmpTable1);
            tmpPlusField0.AddField("b.iID", tmpTableList);
            tmpPlusField0.AddField("b.iUserMode", tmpTableList);
            tmpPlusField0.AddField("b.iDt", tmpTableList);
            tmpPlusField0.AddField("b.rUser", tmpTableList);
            tmpSelectFieldList.Add(tmpPlusField0);
            var tmpField1 = new LiteralField(SaveInspect.CharactorEscape(f_Parameter.ParameterList[0]), DataTypeEnum.String);
            tmpField1.Alias = "userIcoPath";
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("c.iFileName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("c.iExtendName", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", byForm_Server.ku.byUser.Orm.Orm0.GenetateTemOrm, "22");
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iRank", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "23");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _24(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "24");
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iFileName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iExtendName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "26");
        }

        public static string _27(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.SqlServer);
        }

        public static string _28(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            StringBuilder tmpWhere = new StringBuilder();
            if (!(tmpRowParameter is ku.by.Object.Row))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            tmpSetList.Add(new SetField("iIcoFile", "="));
            tmpSetList.Add(new SetField("iFileName", "="));
            tmpSetList.Add(new SetField("iExtendName", "="));
            tmpSetList.Add(new SetField("iUploadDt", "="));
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return string.Format("SET @{0} = 0\r\n", f_EffectedCount);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("SET @{0} = 0;", f_EffectedCount));
            string tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.SqlServer);

            if (string.IsNullOrEmpty(tmpUpdateSql))
            {
                return tmpSql.ToString();
            }

            tmpSql.Append(tmpUpdateSql);
            tmpSql.AppendLine(string.Format("SET @{0} = @@ROWCOUNT", f_EffectedCount));
            return tmpSql.ToString();

        }

        public static string _29(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.SqlServer);
        }

        public static string _30(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.SqlServer);
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _31(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            return new SqlIDUResult(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.SqlServer), null, ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _32(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpPlusField0 = new PlusField(tmpTable0);
            tmpPlusField0.AddField("a.iID", tmpTableList);
            tmpPlusField0.AddField("a.iUserMode", tmpTableList);
            tmpPlusField0.AddField("a.iDt", tmpTableList);
            tmpPlusField0.AddField("a.rUser", tmpTableList);
            tmpSelectFieldList.Add(tmpPlusField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "32");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _33(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpTable1 = f_Parameter.TableSourceList[1] as Table;
            tmpTable1.Alias = "b";
            tmpTableList.Add(tmpTable1);
            tmpEquivalentTables.Add(tmpTable1);
            var tmpPlusField0 = new PlusField(tmpTable0);
            tmpPlusField0.AddField("a.iID", tmpTableList);
            tmpPlusField0.AddField("a.iUserMode", tmpTableList);
            tmpPlusField0.AddField("a.iDt", tmpTableList);
            tmpPlusField0.AddField("a.rUser", tmpTableList);
            tmpSelectFieldList.Add(tmpPlusField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("b.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("b.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("b.iMobile", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList)));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", byForm_Server.ku.byUser.Orm.Orm1.GenetateTemOrm, "33");
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _34(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            return new SqlIDUResult(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.SqlServer), null, ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _35(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
                return new SqlIDUResult("", null, null);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            string tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.SqlServer);

            if (string.IsNullOrEmpty(tmpDeleteSql))
            {
                return new SqlIDUResult("", null, null);
            }

            return new SqlIDUResult(tmpDeleteSql, null, tmpDataSheet.KuName);
            //return tmpDeleteSql;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _36(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            tmpWhere.Append(" WHERE ");
            StringBuilder tmpMethodInvocation0 = new StringBuilder();
            tmpMethodInvocation0.Append("CONVERT(");
            tmpMethodInvocation0.Append("int, ");
            tmpMethodInvocation0.Append(ToolFunction.ConvertFieldNameToField("a.iFreeze", tmpTableList));
            tmpMethodInvocation0.Append(")");
            tmpWhere.Append(ToolFunction.EqualExpression(tmpMethodInvocation0, "0"));
            tmpWhere.Append(" AND ");
            tmpWhere.Append("(");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            tmpWhere.Append(" OR ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            tmpWhere.Append(" OR ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            tmpWhere.Append(" OR ");
            tmpWhere.Append(ToolFunction.ConvertFieldNameToField("a.iDisplayName", tmpTableList).FieldAccess);
            tmpWhere.Append(" LIKE ");
            string tmpBinaryExpression1 = ToolFunction.BinaryExpression(SaveInspect.CharactorEscape("%"), " + ", SaveInspect.CharactorEscape(f_Parameter.ParameterList[0]));            string tmpBinaryExpression0 = ToolFunction.BinaryExpression(tmpBinaryExpression1, " + ", SaveInspect.CharactorEscape("%"));
            tmpWhere.Append(tmpBinaryExpression0);
            tmpWhere.Append(" OR ");
            tmpWhere.Append(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList).FieldAccess);
            tmpWhere.Append(" LIKE ");
            string tmpBinaryExpression3 = ToolFunction.BinaryExpression(SaveInspect.CharactorEscape("%"), " + ", SaveInspect.CharactorEscape(f_Parameter.ParameterList[0]));            string tmpBinaryExpression2 = ToolFunction.BinaryExpression(tmpBinaryExpression3, " + ", SaveInspect.CharactorEscape("%"));
            tmpWhere.Append(tmpBinaryExpression2);
            tmpWhere.Append(")");
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "36");
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
            var tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpField0);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpField1);
            var tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
            tmpSelectFieldList.Add(tmpField2);
            var tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
            tmpSelectFieldList.Add(tmpField3);
            var tmpField4 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
            tmpSelectFieldList.Add(tmpField4);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpOrderByList.Add(new OrderByField(ToolFunction.GetOrderByField("a.iRegDt", tmpSelectFieldList, tmpTableList, DBTypeEnum.SqlServer), true));
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            ToolFunction.GenerateOrderBy(tmpOrderByList, tmpOrderBy);
            tmpSql.Append(tmpOrderBy);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "37");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _38(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpField0 = new FuncField("count", DataTypeEnum.None, null, DBTypeEnum.SqlServer);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpField0.Params.Add(tmpField1);
            tmpField0.GenerateType();
            tmpField0.Alias = "total";
            tmpSelectFieldList.Add(tmpField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "38");
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _39(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
            var tmpField0 = new FuncField("count", DataTypeEnum.None, null, DBTypeEnum.SqlServer);
            var tmpField1 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
            tmpField0.Params.Add(tmpField1);
            tmpField0.GenerateType();
            tmpField0.Alias = "total";
            tmpSelectFieldList.Add(tmpField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byUser", null, "39");
        }

        public static string _40(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.SqlServer);
        }

        public static string _41(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.SqlServer);
        }

        public static string Tran_0(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            tmpTran.AppendLine("SET LOCK_TIMEOUT 3000\r\nSET XACT_ABORT ON");
            tmpTran.AppendLine("BEGIN TRAN");
            tmpTran.AppendLine("DECLARE @EffectedCount INT");
            tmpTran.AppendLine("DECLARE @tmpRowCount int");

            string tmpLocalDec_0 = _8(f_TranParmas.Paramters[0]);
            tmpTran.Append(tmpLocalDec_0);
            tmpTran.AppendLine("SET @tmpRowCount = @@ROWCOUNT");

            tmpTran.Append("IF ");
            string tmpLocalDec_1 = "@tmpRowCount";
            string tmpLocalDec_2 = "1";
            tmpTran.Append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

            tmpTran.AppendLine(" ");
            tmpTran.AppendLine("BEGIN");
            tmpTran.AppendLine("ROLLBACK");
            tmpTran.Append("RAISERROR(");
            tmpTran.Append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

            tmpTran.AppendLine(",16,0)\r\nROLLBACK\r\nRETURN");
            tmpTran.AppendLine("END");
            tmpTran.AppendLine("COMMIT TRAN");
            return tmpTran.ToString();
        }

        public static string Tran_1(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            tmpTran.AppendLine("SET LOCK_TIMEOUT 3000\r\nSET XACT_ABORT ON");
            tmpTran.AppendLine("BEGIN TRAN");
            tmpTran.AppendLine("DECLARE @EffectedCount INT");
            tmpTran.AppendLine("DECLARE @tmpRowCount int");

            string tmpLocalDec_0 = _20(f_TranParmas.Paramters[0], "EffectedCount");
            tmpTran.Append(tmpLocalDec_0);
            tmpTran.AppendLine("SET @tmpRowCount = @EffectedCount");

            tmpTran.Append("IF ");
            string tmpLocalDec_1 = "@tmpRowCount";
            string tmpLocalDec_2 = "1";
            tmpTran.Append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

            tmpTran.AppendLine(" ");
            tmpTran.AppendLine("BEGIN");
            tmpTran.AppendLine("ROLLBACK");
            tmpTran.Append("RAISERROR(");
            tmpTran.Append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

            tmpTran.AppendLine(",16,0)\r\nROLLBACK\r\nRETURN");
            tmpTran.AppendLine("END");
            tmpTran.Append(_21(f_TranParmas.Paramters[1], "EffectedCount"));

            tmpTran.Append("SET ");
            tmpTran.Append("@tmpRowCount");
            tmpTran.Append(" = ");
            tmpTran.Append("@EffectedCount");
            tmpTran.AppendLine();
            tmpTran.Append("IF ");
            string tmpLocalDec_3 = "@tmpRowCount";
            string tmpLocalDec_4 = "1";
            tmpTran.Append(ToolFunction.NotEqualExpression(tmpLocalDec_3, tmpLocalDec_4));

            tmpTran.AppendLine(" ");
            tmpTran.AppendLine("BEGIN");
            tmpTran.AppendLine("ROLLBACK");
            tmpTran.Append("RAISERROR(");
            tmpTran.Append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

            tmpTran.AppendLine(",16,0)\r\nROLLBACK\r\nRETURN");
            tmpTran.AppendLine("END");
            tmpTran.AppendLine("COMMIT TRAN");
            return tmpTran.ToString();
        }

        public static string Tran_2(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            tmpTran.AppendLine("SET LOCK_TIMEOUT 3000\r\nSET XACT_ABORT ON");
            tmpTran.AppendLine("BEGIN TRAN");
            tmpTran.AppendLine("DECLARE @EffectedCount INT");
            tmpTran.Append(_27(f_TranParmas.Paramters[0], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.Append(_28(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.AppendLine("COMMIT TRAN");
            return tmpTran.ToString();
        }

        public static string Tran_3(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            tmpTran.AppendLine("SET LOCK_TIMEOUT 3000\r\nSET XACT_ABORT ON");
            tmpTran.AppendLine("BEGIN TRAN");
            tmpTran.AppendLine("DECLARE @EffectedCount INT");
            tmpTran.Append(_29(f_TranParmas.Paramters[0], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.Append(_30(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.AppendLine("COMMIT TRAN");
            return tmpTran.ToString();
        }

        public static string Tran_4(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            tmpTran.AppendLine("SET LOCK_TIMEOUT 3000\r\nSET XACT_ABORT ON");
            tmpTran.AppendLine("BEGIN TRAN");
            tmpTran.AppendLine("DECLARE @EffectedCount INT");
            tmpTran.Append(_40(f_TranParmas.Paramters[0], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.Append(_41(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpTran.AppendLine();
            tmpTran.AppendLine("COMMIT TRAN");
            return tmpTran.ToString();
        }
    }
}
