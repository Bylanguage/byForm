package $Ku.byForm.SqlExpression;

import $Ku.by.ToolClass.Sql.*;
import $Ku.by.ToolClass.*;
import java.util.*;
import $Ku.by.ToolClass.*;
import $Ku.by.Object.*;
public class SqlserverAssembler {
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
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), f_Parameter.getParameterList().get(0)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
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
        tmpTable0.setAlias("b");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFormID", tmpTableList), f_Parameter.getParameterList().get(0)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _2($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), f_Parameter.getParameterList().get(0)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
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
        tmpTable0.setAlias("b");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFormID", tmpTableList), f_Parameter.getParameterList().get(0)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _4($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
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
        tmpTable0.setAlias("b");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFieldID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
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
        tmpTable0.setAlias("b");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFieldID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String[] _8($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowListNotInTran(f_Parameter.getParameterList().get(0), tmpColList, DBTypeEnum.SqlServer);

    }

    public static java.lang.String[] _9($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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

        String tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.SqlServer);

        if (tmpUpdateSql != null && (tmpUpdateSql.isEmpty()))
        {
            return new String[]{""};
        }

        return new String[]{tmpUpdateSql};

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
        tmpTable0.setAlias("data");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("data.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _11($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(0);        tmpTableList.add(tmpTable0);
        tmpWhere.append(" WHERE ");

        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(ToolFunction.GenerateDeleteFrom(tmpTable0, DBTypeEnum.SqlServer));
        tmpSql.append(tmpWhere);
        return tmpSql.toString();
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iUserID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
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
        tmpTable0.setAlias("b");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iUserID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
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
        tmpTable0.setAlias("b");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
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
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
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
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 =($Ku.by.ToolClass.Sql.SqlTable) f_Parameter.getTableSourceList().get(0);
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _20($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.SqlServer);

    }

    public static java.lang.String _21($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        StringBuilder tmpWhere = new StringBuilder();
        Object tmpRowParameter = f_Parameter.getParameterList().get(0);
        ArrayList<SetField> tmpSetList = new ArrayList<>();
        if (!(tmpRowParameter instanceof $Ku.by.Object.Row[])&&!(tmpRowParameter instanceof Iterable))
        {
            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
        }
        ArrayList<$Ku.by.Object.Row> rowArrayList =new ArrayList<>();
        if(f_Parameter.getParameterList().get(0) instanceof $Ku.by.Object.Row[]){
            $Ku.by.Object.Row[] tmpRows = ($Ku.by.Object.Row[])f_Parameter.getParameterList().get(0);
            rowArrayList.addAll(Arrays.asList(tmpRows));
        }
        else if (f_Parameter.getParameterList().get(0) instanceof Iterable){
            Iterable<$Ku.by.Object.Row> tmpRows = (Iterable<$Ku.by.Object.Row>)f_Parameter.getParameterList().get(0);
            for ($Ku.by.Object.Row row : tmpRows) {
                rowArrayList.add(row);
            }
        }
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);

            String tmpUpdateSql = ToolFunction.FillUpdateRow(row, tmpSetList, tmpWhere, DBTypeEnum.SqlServer);

            if (tmpUpdateSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpUpdateSql);
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

    }

    public static java.lang.String _22($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        Object tmpRowParameter = f_Parameter.getParameterList().get(0);

        if (!(tmpRowParameter instanceof $Ku.by.Object.Row||tmpRowParameter instanceof Iterable ||tmpRowParameter instanceof $Ku.by.Object.Row[]))
        {
            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
        }
        StringBuilder tmpWhere = new StringBuilder();
        ArrayList<$Ku.by.Object.Row> rowArrayList =new ArrayList<>();
        if(f_Parameter.getParameterList().get(0) instanceof $Ku.by.Object.Row[]){
            $Ku.by.Object.Row[] tmpRows = ($Ku.by.Object.Row[])f_Parameter.getParameterList().get(0);
            rowArrayList.addAll(Arrays.asList(tmpRows));
        }
        else if (f_Parameter.getParameterList().get(0) instanceof Iterable){
            Iterable<$Ku.by.Object.Row> tmpRows = (Iterable<$Ku.by.Object.Row>)f_Parameter.getParameterList().get(0);
            for ($Ku.by.Object.Row row : tmpRows) {
                rowArrayList.add(row);
            }
        }
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  

            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.SqlServer);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpDeleteSql);
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String[] _24($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowListNotInTran(f_Parameter.getParameterList().get(0), tmpColList, DBTypeEnum.SqlServer);

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

        String tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.SqlServer);

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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpOrderByList.add(new OrderByField(ToolFunction.GetOrderByField("a.iFieldNO", tmpSelectFieldList, tmpTableList, DBTypeEnum.SqlServer), false));
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        ToolFunction.GenerateOrderBy(tmpOrderByList, tmpOrderBy);
        tmpSql.append(tmpOrderBy);
        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _27($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _28($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _29($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        tmpTable0.setAlias("r");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("r.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("r.iUserID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _30($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(0);        tmpTableList.add(tmpTable0);
        tmpWhere.append(" WHERE ");

        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(ToolFunction.GenerateDeleteFrom(tmpTable0, DBTypeEnum.SqlServer));
        tmpSql.append(tmpWhere);
        return tmpSql.toString();
    }

    public static java.lang.String _31($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder();
        StringBuilder tmpWhere = new StringBuilder();
        ArrayList<AbstractTable> tmpTableList = new ArrayList<>();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(0);        tmpTableList.add(tmpTable0);
        tmpWhere.append(" WHERE ");

        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("iFormID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(ToolFunction.GenerateDeleteFrom(tmpTable0, DBTypeEnum.SqlServer));
        tmpSql.append(tmpWhere);
        return tmpSql.toString();
    }

    public static java.lang.String _32($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
            return String.format("SET @%s = 0\r\n", f_EffectedCount);
        }
        $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("SET @%s = 0;\r\n", f_EffectedCount));
        String tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.SqlServer);

        if (tmpDeleteSql.isEmpty())
        {
            return tmpSql.toString();
        }

        tmpSql.append(tmpDeleteSql);
        tmpSql.append(String.format("SET @%s = @@ROWCOUNT\r\n", f_EffectedCount));
        return tmpSql.toString();

    }

    public static java.lang.String[] _33($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowListNotInTran(f_Parameter.getParameterList().get(0), tmpColList, DBTypeEnum.SqlServer);

    }

    public static $Ku.by.ToolClass.Sql.SelectTable _34($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), f_Parameter.getParameterList().get(0)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _35($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("b.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("b.iFormID", tmpTableList), f_Parameter.getParameterList().get(0)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _36($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        StringBuilder tmpSql = new StringBuilder();
        java.util.LinkedHashMap<SqlField, Object> tmpInsertValues = ToolFunction.GetNewInsertValues();
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = ($Ku.by.ToolClass.Sql.SqlTable)f_Parameter.getTableSourceList().get(0);
        ToolFunction.FillInsertValues(tmpInsertValues, f_Parameter.getParameterList().get(0), tmpTable0);
        tmpSql.append(ToolFunction.GenerateSqlByInsertValues(tmpInsertValues, tmpTable0.getSheet(), DBTypeEnum.SqlServer));
        return tmpSql. toString();
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpOrderByList.add(new OrderByField(ToolFunction.GetOrderByField("a.iCreateDt", tmpSelectFieldList, tmpTableList, DBTypeEnum.SqlServer), false));
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.SqlServer, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.SqlServer);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        ToolFunction.GenerateOrderBy(tmpOrderByList, tmpOrderBy);
        tmpSql.append(tmpOrderBy);
        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String[] Tran_0($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET XACT_ABORT ON\r\n");
        tmpTran.append("BEGIN TRAN\r\n");
        tmpTran.append("DECLARE @EffectedCount INT\r\n");
        tmpTran.append("\r\nIF ");
        String tmpLocalDec_0 = SaveInspect.CharactorEscape(f_TranParmas.Values.get(0));
        String tmpLocalDec_1 = "insert";
        tmpTran.append(ToolFunction.EqualExpression(tmpLocalDec_0, tmpLocalDec_1));

        tmpTran.append(" ");
        tmpTran.append(_20(f_TranParmas.getParamters().get(0), "EffectedCount"));
        tmpTran.append("\r\n");
        tmpTran.append("ELSE \r\n");
        tmpTran.append("\r\nIF ");
        String tmpLocalDec_2 = SaveInspect.CharactorEscape(f_TranParmas.Values.get(0));
        String tmpLocalDec_3 = "update";
        tmpTran.append(ToolFunction.EqualExpression(tmpLocalDec_2, tmpLocalDec_3));

        tmpTran.append(" ");
        tmpTran.append(_21(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpTran.append("\r\n");
        tmpTran.append("ELSE \r\n");
        tmpTran.append("\r\nIF ");
        String tmpLocalDec_4 = SaveInspect.CharactorEscape(f_TranParmas.Values.get(0));
        String tmpLocalDec_5 = "delete";
        tmpTran.append(ToolFunction.EqualExpression(tmpLocalDec_4, tmpLocalDec_5));

        tmpTran.append(" ");
        tmpTran.append(_22(f_TranParmas.getParamters().get(2), "EffectedCount"));
        tmpTran.append("\r\n");
        tmpTran.append("COMMIT TRAN\r\n");
        return new String[]{tmpTran.toString()};
    }

    public static java.lang.String[] Tran_1($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET XACT_ABORT ON\r\n");
        tmpTran.append("BEGIN TRAN\r\n");
        tmpTran.append("DECLARE @EffectedCount INT\r\n");
        tmpTran.append(_30(f_TranParmas.getParamters().get(0)));
        tmpTran.append("\r\n");
        tmpTran.append(_31(f_TranParmas.getParamters().get(1)));
        tmpTran.append("\r\n");
        tmpTran.append(_32(f_TranParmas.getParamters().get(2), "EffectedCount"));
        tmpTran.append("\r\n");
        tmpTran.append("COMMIT TRAN\r\n");
        return new String[]{tmpTran.toString()};
    }

    public static java.lang.String[] Tran_2($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET XACT_ABORT ON\r\n");
        tmpTran.append("BEGIN TRAN\r\n");
        tmpTran.append("DECLARE @EffectedCount INT\r\n");
        tmpTran.append(_36(f_TranParmas.getParamters().get(0)));
        tmpTran.append("\r\n");
        tmpTran.append("COMMIT TRAN\r\n");
        return new String[]{tmpTran.toString()};
    }
}
