package $Ku.byUser.SqlExpression;

import $Ku.by.ToolClass.Sql.*;
import $Ku.by.ToolClass.*;
import java.util.*;
import $Ku.by.ToolClass.*;
import $Ku.by.Object.*;
public class OracleAssembler {
    public static $Ku.by.ToolClass.Sql.SelectTable _0($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        SelectTable tmpTable0 =(SelectTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(1);
        tmpTableList.add(tmpTable1);
        tmpTable1.setAlias("b");
        tmpTable0.privateJoinTables.add(new JoinTable(tmpTable1));
        tmpTable0.getJoinTables().get(0).setJoinMode(" left join ");
        StringBuilder tmpCondition1 = new StringBuilder(" on ");
        tmpCondition1.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList)));
        tmpTable0.getJoinTables().get(0).setCondition(tmpCondition1);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable2 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(2);
        tmpTableList.add(tmpTable2);
        tmpTable2.setAlias("c");
        tmpTable0.privateJoinTables.add(new JoinTable(tmpTable2));
        tmpTable0.getJoinTables().get(1).setJoinMode(" left join ");
        StringBuilder tmpCondition2 = new StringBuilder(" on ");
        tmpCondition2.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("c.iID", tmpTableList)));
        tmpTable0.getJoinTables().get(1).setCondition(tmpCondition2);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        PlusField tmpPlusField0 = new PlusField(tmpTable1);
        tmpPlusField0.AddField("b.iID", tmpTableList);
        tmpPlusField0.AddField("b.iUserMode", tmpTableList);
        tmpPlusField0.AddField("b.iDt", tmpTableList);
        tmpPlusField0.AddField("b.rUser", tmpTableList);
        tmpSelectFieldList.add(tmpPlusField0);
        LiteralField tmpField1 = new LiteralField(SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0)), DataTypeEnum.String);
        tmpField1.tmpDB = DBTypeEnum.Oracle;
        tmpField1.setAlias("userIcoPath");
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("c.iFileName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("c.iExtendName", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString(), $Ku.byUser.Orm.Orm0.class);
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _1($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iRank", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpWhere.append(" and ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iPassword", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(1))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String[] _2($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowListNotInTran(f_Parameter.getParameterList().get(0), tmpColList, DBTypeEnum.Oracle);

    }

    public static $Ku.by.ToolClass.Sql.SelectTable _3($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpWhere.append(" and ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iPassword", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(1))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _4($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder();
        StringBuilder tmpSet = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<$Ku.by.ToolClass.Sql.SqlField> tmpSetFields = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpSet.append("SET ");

        tmpSet.append(ToolFunction.SetAssignmentExpression((TableField)ToolFunction.ConvertFieldNameToField("a.iPassword", tmpTableList), " = ", SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0)), tmpSetFields,DBTypeEnum.Oracle));
        tmpWhere.append(" WHERE ");

        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(1))));
        tmpSql.append("UPDATE " + ToolFunction.TableToCode(tmpTable0)+" ");
        tmpSql.append(tmpSet);
        tmpSql.append(tmpWhere);
        tmpSql.append("\r\n");
        return tmpSql.toString();
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _5($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _6($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _7($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _8($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder();
        StringBuilder tmpSet = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<$Ku.by.ToolClass.Sql.SqlField> tmpSetFields = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpSet.append("SET ");

        tmpSet.append(ToolFunction.SetAssignmentExpression((TableField)ToolFunction.ConvertFieldNameToField("a.iPassword", tmpTableList), " = ", SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0)), tmpSetFields,DBTypeEnum.Oracle));
        tmpWhere.append(" WHERE ");

        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(1))));
        tmpSql.append("UPDATE " + ToolFunction.TableToCode(tmpTable0)+" ");
        tmpSql.append(tmpSet);
        tmpSql.append(tmpWhere);
        tmpSql.append("\r\n");
        return tmpSql.toString();
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _9($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _10($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _11($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _12($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _13($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _14($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _15($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _16($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iRank", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList).getFieldAccess());
        tmpWhere.append(" in (");
        tmpWhere.append(((SelectTable)f_Parameter.getParameterList().get(0)).getSqlValue());
        tmpWhere.append(")");
        tmpWhere.append(" and ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iRank", tmpTableList), "'anonymous'"));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _17($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("b");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(1);
        tmpTable1.setAlias("a");
        tmpTableList.add(tmpTable1);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("b.iUserID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _18($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        SelectTable tmpTable0 =(SelectTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(1);
        tmpTableList.add(tmpTable1);
        tmpTable1.setAlias("b");
        tmpTable0.privateJoinTables.add(new JoinTable(tmpTable1));
        tmpTable0.getJoinTables().get(0).setJoinMode(" left join ");
        StringBuilder tmpCondition1 = new StringBuilder(" on ");
        tmpCondition1.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList)));
        tmpTable0.getJoinTables().get(0).setCondition(tmpCondition1);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable2 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(2);
        tmpTableList.add(tmpTable2);
        tmpTable2.setAlias("c");
        tmpTable0.privateJoinTables.add(new JoinTable(tmpTable2));
        tmpTable0.getJoinTables().get(1).setJoinMode(" left join ");
        StringBuilder tmpCondition2 = new StringBuilder(" on ");
        tmpCondition2.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("c.iID", tmpTableList)));
        tmpTable0.getJoinTables().get(1).setCondition(tmpCondition2);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        PlusField tmpPlusField0 = new PlusField(tmpTable1);
        tmpPlusField0.AddField("b.iID", tmpTableList);
        tmpPlusField0.AddField("b.iUserMode", tmpTableList);
        tmpPlusField0.AddField("b.iDt", tmpTableList);
        tmpPlusField0.AddField("b.rUser", tmpTableList);
        tmpSelectFieldList.add(tmpPlusField0);
        LiteralField tmpField1 = new LiteralField(SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0)), DataTypeEnum.String);
        tmpField1.tmpDB = DBTypeEnum.Oracle;
        tmpField1.setAlias("userIcoPath");
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("c.iFileName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("c.iExtendName", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString(), $Ku.byUser.Orm.Orm0.class);
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _19($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iRank", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _20($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Oracle);

    }

    public static java.lang.String _21($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Oracle);

    }

    public static $Ku.by.ToolClass.Sql.SelectTable _22($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        SelectTable tmpTable0 =(SelectTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(1);
        tmpTableList.add(tmpTable1);
        tmpTable1.setAlias("b");
        tmpTable0.privateJoinTables.add(new JoinTable(tmpTable1));
        tmpTable0.getJoinTables().get(0).setJoinMode(" left join ");
        StringBuilder tmpCondition1 = new StringBuilder(" on ");
        tmpCondition1.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList)));
        tmpTable0.getJoinTables().get(0).setCondition(tmpCondition1);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable2 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(2);
        tmpTableList.add(tmpTable2);
        tmpTable2.setAlias("c");
        tmpTable0.privateJoinTables.add(new JoinTable(tmpTable2));
        tmpTable0.getJoinTables().get(1).setJoinMode(" left join ");
        StringBuilder tmpCondition2 = new StringBuilder(" on ");
        tmpCondition2.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("c.iID", tmpTableList)));
        tmpTable0.getJoinTables().get(1).setCondition(tmpCondition2);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        PlusField tmpPlusField0 = new PlusField(tmpTable1);
        tmpPlusField0.AddField("b.iID", tmpTableList);
        tmpPlusField0.AddField("b.iUserMode", tmpTableList);
        tmpPlusField0.AddField("b.iDt", tmpTableList);
        tmpPlusField0.AddField("b.rUser", tmpTableList);
        tmpSelectFieldList.add(tmpPlusField0);
        LiteralField tmpField1 = new LiteralField(SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0)), DataTypeEnum.String);
        tmpField1.tmpDB = DBTypeEnum.Oracle;
        tmpField1.setAlias("userIcoPath");
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("c.iFileName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("c.iExtendName", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString(), $Ku.byUser.Orm.Orm0.class);
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _23($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iFreeze", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iRank", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _24($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String[] _25($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpWhere = new StringBuilder();
        Object tmpRowParameter = f_Parameter.getParameterList().get(0);
        ArrayList<SetField> tmpSetList = new ArrayList<>();
        if (!(tmpRowParameter instanceof $Ku.by.Object.Row))
        {
            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
        }
        $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row)tmpRowParameter;
        IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

        if (tmpDataSheet == null)
        {
            return new String[]{""};
        }
        $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  

        String tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Oracle);

        if (tmpUpdateSql != null && (tmpUpdateSql.isEmpty()))
        {
            return new String[]{""};
        }

        return new String[]{tmpUpdateSql};

    }

    public static $Ku.by.ToolClass.Sql.SelectTable _26($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iFileName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iExtendName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _27($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Oracle);

    }

    public static java.lang.String _28($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        StringBuilder tmpWhere = new StringBuilder();
        Object tmpRowParameter = f_Parameter.getParameterList().get(0);
        ArrayList<SetField> tmpSetList = new ArrayList<>();
        if (!(tmpRowParameter instanceof $Ku.by.Object.Row))
        {
            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
        }
        tmpSetList.add((new SetField("iIcoFile", "=")));
        tmpSetList.add((new SetField("iFileName", "=")));
        tmpSetList.add((new SetField("iExtendName", "=")));
        tmpSetList.add((new SetField("iUploadDt", "=")));
        $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row)tmpRowParameter;
        IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

        if (tmpDataSheet == null)
        {
            return String.format("\"%s\" := 0;\r\n", f_EffectedCount);
        }
        $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("\"%s\" := 0;\r\n", f_EffectedCount));
        String tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Oracle);

        if (tmpUpdateSql != null && tmpUpdateSql.isEmpty())
        {
            return tmpSql.toString();
        }

        tmpSql.append(tmpUpdateSql);
        tmpSql.append(String.format("\"%s\" := SQL%ROWCOUNT;\r\n", f_EffectedCount));
        return tmpSql.toString();

    }

    public static java.lang.String _29($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Oracle);

    }

    public static java.lang.String _30($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Oracle);

    }

    public static java.lang.String[] _31($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowListNotInTran(f_Parameter.getParameterList().get(0), tmpColList, DBTypeEnum.Oracle);

    }

    public static $Ku.by.ToolClass.Sql.SelectTable _32($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        PlusField tmpPlusField0 = new PlusField(tmpTable0);
        tmpPlusField0.AddField("a.iID", tmpTableList);
        tmpPlusField0.AddField("a.iUserMode", tmpTableList);
        tmpPlusField0.AddField("a.iDt", tmpTableList);
        tmpPlusField0.AddField("a.rUser", tmpTableList);
        tmpSelectFieldList.add(tmpPlusField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _33($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(1);
        tmpTable1.setAlias("b");
        tmpTableList.add(tmpTable1);
        tmpEquivalentTables.add(tmpTable1);
        PlusField tmpPlusField0 = new PlusField(tmpTable0);
        tmpPlusField0.AddField("a.iID", tmpTableList);
        tmpPlusField0.AddField("a.iUserMode", tmpTableList);
        tmpPlusField0.AddField("a.iDt", tmpTableList);
        tmpPlusField0.AddField("a.rUser", tmpTableList);
        tmpSelectFieldList.add(tmpPlusField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("b.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("b.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("b.iMobile", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString(), $Ku.byUser.Orm.Orm1.class);
    }

    public static java.lang.String[] _34($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowListNotInTran(f_Parameter.getParameterList().get(0), tmpColList, DBTypeEnum.Oracle);

    }

    public static java.lang.String[] _35($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        Object tmpRowParameter = f_Parameter.getParameterList().get(0);

        if (!(tmpRowParameter instanceof $Ku.by.Object.Row||tmpRowParameter instanceof Iterable ||tmpRowParameter instanceof $Ku.by.Object.Row[]))
        {
            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
        }
        StringBuilder tmpWhere = new StringBuilder();
        $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row)tmpRowParameter;
        IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

        if (tmpDataSheet == null)
        {
            return new String[]{""};
        }
        $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  

        String tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.Oracle);

        if (tmpDeleteSql.isEmpty())
        {
            return new String[]{""};
        }

        return new String[]{tmpDeleteSql};

    }

    public static $Ku.by.ToolClass.Sql.SelectTable _36($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpWhere.append(" WHERE ");
        StringBuilder tmpMethodInvocation0 = new StringBuilder();
        tmpMethodInvocation0.append("CAST(");
        tmpMethodInvocation0.append(ToolFunction.ConvertFieldNameToField("a.iFreeze", tmpTableList));
        tmpMethodInvocation0.append(" AS NUMBER)");
        tmpWhere.append(ToolFunction.EqualExpression(tmpMethodInvocation0, "0"));
        tmpWhere.append(" and ");
        tmpWhere.append("(");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpWhere.append(" or ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMail", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpWhere.append(" or ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iMobile", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpWhere.append(" or ");
        tmpWhere.append(ToolFunction.ConvertFieldNameToField("a.iDisplayName", tmpTableList).getFieldAccess());
        tmpWhere.append(" LIKE ");
        String tmpBinaryExpression1 = ToolFunction.BinaryExpression(SaveInspect.CharactorEscape("%"), " + ", SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0)));
        String tmpBinaryExpression0 = ToolFunction.BinaryExpression(tmpBinaryExpression1, " + ", SaveInspect.CharactorEscape("%"));
        tmpWhere.append(tmpBinaryExpression0);
        tmpWhere.append(" or ");
        tmpWhere.append(ToolFunction.ConvertFieldNameToField("a.iName", tmpTableList).getFieldAccess());
        tmpWhere.append(" LIKE ");
        String tmpBinaryExpression3 = ToolFunction.BinaryExpression(SaveInspect.CharactorEscape("%"), " + ", SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0)));
        String tmpBinaryExpression2 = ToolFunction.BinaryExpression(tmpBinaryExpression3, " + ", SaveInspect.CharactorEscape("%"));
        tmpWhere.append(tmpBinaryExpression2);
        tmpWhere.append(")");
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _37($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        AbstractSelectField tmpField0 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpField0);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpField1);
        AbstractSelectField tmpField2 = ToolFunction.ConvertComponentToTableField("a.iDisplayName", tmpTableList);
        tmpSelectFieldList.add(tmpField2);
        AbstractSelectField tmpField3 = ToolFunction.ConvertComponentToTableField("a.iMobile", tmpTableList);
        tmpSelectFieldList.add(tmpField3);
        AbstractSelectField tmpField4 = ToolFunction.ConvertComponentToTableField("a.iMail", tmpTableList);
        tmpSelectFieldList.add(tmpField4);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpOrderByList.add(new OrderByField(ToolFunction.GetOrderByField("a.iRegDt", tmpSelectFieldList, tmpTableList, DBTypeEnum.Oracle), true));
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        ToolFunction.GenerateOrderBy(tmpOrderByList, tmpOrderBy);
        tmpSql.append(tmpOrderBy);
        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _38($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        FuncField tmpField0 = new FuncField("count", DataTypeEnum.None, null, DBTypeEnum.Oracle);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpField0.getParams().add(tmpField1);
        tmpField0.GenerateType();
        tmpField0.setAlias("total");
        tmpSelectFieldList.add(tmpField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _39($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder("SELECT ");
        StringBuilder tmpFrom = new StringBuilder();
        StringBuilder tmpGroupBy = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        StringBuilder tmpHaving = new StringBuilder();
        StringBuilder tmpOrderBy = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<AbstractTable> tmpEquivalentTables = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpSelectFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpMergedFieldList = new ArrayList<>();
        ArrayList<AbstractSelectField> tmpGroupByFieldList = new ArrayList<>();
        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        FuncField tmpField0 = new FuncField("count", DataTypeEnum.None, null, DBTypeEnum.Oracle);
        AbstractSelectField tmpField1 = ToolFunction.ConvertComponentToTableField("a.iID", tmpTableList);
        tmpField0.getParams().add(tmpField1);
        tmpField0.GenerateType();
        tmpField0.setAlias("total");
        tmpSelectFieldList.add(tmpField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Oracle, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _40($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Oracle);

    }

    public static java.lang.String _41($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Oracle);

    }

    public static java.lang.String[] Tran_0($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        StringBuilder tmpTran = new StringBuilder("DECLARE\r\n");
        StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
        tmpTran.append("\"EffectedCount\" NUMBER;\r\n");
        tmpTran.append("\"tmpRowCount\" INTEGER;\r\n");

        String tmpLocalDec_0 = _8(f_TranParmas.getParamters().get(0));
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("\"tmpRowCount\" := SQL%ROWCOUNT;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "\"tmpRowCount\"";
        String tmpLocalDec_2 = "1";
        tmpBody.append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("ROLLBACK;\r\n");
        tmpBody.append("RAISE_APPLICATION_ERROR('-20000',");
        tmpBody.append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

        tmpBody.append(", FALSE);\r\n");
        tmpBody.append("RETURN;\r\n");
        tmpBody.append("END IF;\r\n");
        tmpBody.append("\r\nCOMMIT;");
        tmpBody.append("\r\nEXCEPTION");
        tmpBody.append("\r\nWHEN OTHERS THEN");
        tmpBody.append("\r\nROLLBACK;");
        tmpBody.append("\r\nRAISE_APPLICATION_ERROR(-20000, '对数据库操作失败: ' || SQLERRM);");
        tmpBody.append("\r\nEND;");
        tmpTran.append(tmpBody);
        return new String[]{tmpTran.toString()};
    }

    public static java.lang.String[] Tran_1($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        StringBuilder tmpTran = new StringBuilder("DECLARE\r\n");
        StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
        tmpTran.append("\"EffectedCount\" NUMBER;\r\n");
        tmpTran.append("\"tmpRowCount\" INTEGER;\r\n");

        String tmpLocalDec_0 = _20(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("\"tmpRowCount\" := \"EffectedCount\";\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "\"tmpRowCount\"";
        String tmpLocalDec_2 = "1";
        tmpBody.append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("ROLLBACK;\r\n");
        tmpBody.append("RAISE_APPLICATION_ERROR('-20000',");
        tmpBody.append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

        tmpBody.append(", FALSE);\r\n");
        tmpBody.append("RETURN;\r\n");
        tmpBody.append("END IF;\r\n");
        tmpBody.append(_21(f_TranParmas.getParamters().get(1), "EffectedCount"));

        tmpBody.append("\"tmpRowCount\"");
        tmpBody.append(" := ");
        tmpBody.append("\"EffectedCount\"");
        tmpBody.append(";\r\n");
        tmpBody.append("\r\nIF ");
        String tmpLocalDec_3 = "\"tmpRowCount\"";
        String tmpLocalDec_4 = "1";
        tmpBody.append(ToolFunction.NotEqualExpression(tmpLocalDec_3, tmpLocalDec_4));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("ROLLBACK;\r\n");
        tmpBody.append("RAISE_APPLICATION_ERROR('-20000',");
        tmpBody.append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

        tmpBody.append(", FALSE);\r\n");
        tmpBody.append("RETURN;\r\n");
        tmpBody.append("END IF;\r\n");
        tmpBody.append("\r\nCOMMIT;");
        tmpBody.append("\r\nEXCEPTION");
        tmpBody.append("\r\nWHEN OTHERS THEN");
        tmpBody.append("\r\nROLLBACK;");
        tmpBody.append("\r\nRAISE_APPLICATION_ERROR(-20000, '对数据库操作失败: ' || SQLERRM);");
        tmpBody.append("\r\nEND;");
        tmpTran.append(tmpBody);
        return new String[]{tmpTran.toString()};
    }

    public static java.lang.String[] Tran_2($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        StringBuilder tmpTran = new StringBuilder("DECLARE\r\n");
        StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
        tmpTran.append("\"EffectedCount\" NUMBER;\r\n");

        tmpBody.append(_27(f_TranParmas.getParamters().get(0), "EffectedCount"));
        tmpBody.append(_28(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpBody.append("\r\nCOMMIT;");
        tmpBody.append("\r\nEXCEPTION");
        tmpBody.append("\r\nWHEN OTHERS THEN");
        tmpBody.append("\r\nROLLBACK;");
        tmpBody.append("\r\nRAISE_APPLICATION_ERROR(-20000, '对数据库操作失败: ' || SQLERRM);");
        tmpBody.append("\r\nEND;");
        tmpTran.append(tmpBody);
        return new String[]{tmpTran.toString()};
    }

    public static java.lang.String[] Tran_3($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        StringBuilder tmpTran = new StringBuilder("DECLARE\r\n");
        StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
        tmpTran.append("\"EffectedCount\" NUMBER;\r\n");

        tmpBody.append(_29(f_TranParmas.getParamters().get(0), "EffectedCount"));
        tmpBody.append(_30(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpBody.append("\r\nCOMMIT;");
        tmpBody.append("\r\nEXCEPTION");
        tmpBody.append("\r\nWHEN OTHERS THEN");
        tmpBody.append("\r\nROLLBACK;");
        tmpBody.append("\r\nRAISE_APPLICATION_ERROR(-20000, '对数据库操作失败: ' || SQLERRM);");
        tmpBody.append("\r\nEND;");
        tmpTran.append(tmpBody);
        return new String[]{tmpTran.toString()};
    }

    public static java.lang.String[] Tran_4($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        StringBuilder tmpTran = new StringBuilder("DECLARE\r\n");
        StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
        tmpTran.append("\"EffectedCount\" NUMBER;\r\n");

        tmpBody.append(_40(f_TranParmas.getParamters().get(0), "EffectedCount"));
        tmpBody.append(_41(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpBody.append("\r\nCOMMIT;");
        tmpBody.append("\r\nEXCEPTION");
        tmpBody.append("\r\nWHEN OTHERS THEN");
        tmpBody.append("\r\nROLLBACK;");
        tmpBody.append("\r\nRAISE_APPLICATION_ERROR(-20000, '对数据库操作失败: ' || SQLERRM);");
        tmpBody.append("\r\nEND;");
        tmpTran.append(tmpBody);
        return new String[]{tmpTran.toString()};
    }
}
