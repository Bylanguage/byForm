package $Ku.byBase.SqlExpression;

import $Ku.by.ToolClass.Sql.*;
import $Ku.by.ToolClass.*;
import java.util.*;
import $Ku.by.ToolClass.*;
import $Ku.by.Object.*;
public class MysqlAssembler {
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
        int tmpConfigJoinTableCount = 0;
        String tmpConfigName0 = "selectPopup";
        String tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
        $Ku.by.ToolClass.Config tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.getKuName(), tmpIdentityName0, tmpConfigName0, tmpTable0.getSheet().getSheetName());
        ArrayList<$Ku.by.ToolClass.Source> tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.getKuName(), tmpConfig0);
        tmpMergedFieldList.addAll(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, new OutObject<>(tmpConfigJoinTableCount)));
        PlusField tmpPlusField0 = new PlusField(tmpTable0);
        tmpPlusField0.AddField("a.iID", tmpTableList);
        tmpSelectFieldList.add(tmpPlusField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationEqualQueryData(tmpTable0, (QueryData) f_Parameter.getParameterList().get(0), tmpHaving, tmpConfigJoinTableCount, DBTypeEnum.Mysql, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
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
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        int tmpConfigJoinTableCount = 0;
        String tmpConfigName0 = "selectPopup";
        String tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
        $Ku.by.ToolClass.Config tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.getKuName(), tmpIdentityName0, tmpConfigName0, tmpTable0.getSheet().getSheetName());
        ArrayList<$Ku.by.ToolClass.Source> tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.getKuName(), tmpConfig0);
        tmpMergedFieldList.addAll(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, new OutObject<>(tmpConfigJoinTableCount)));
        PlusField tmpPlusField0 = new PlusField(tmpTable0);
        tmpPlusField0.AddField("a.iID", tmpTableList);
        tmpPlusField0.AddField("a.iParent", tmpTableList);
        tmpPlusField0.AddField("a.iName", tmpTableList);
        tmpSelectFieldList.add(tmpPlusField0);
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationEqualQueryData(tmpTable0, (QueryData) f_Parameter.getParameterList().get(0), tmpHaving, tmpConfigJoinTableCount, DBTypeEnum.Mysql, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _2($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Mysql);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpDeleteSql);
            tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

    }

    public static java.lang.String _3($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Mysql);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpDeleteSql);
            tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

    }

    public static java.lang.String _4($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
            return String.format("SET $%s = 0;\r\n", f_EffectedCount);
        }
        $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));
        String tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Mysql);

        if (tmpUpdateSql != null && tmpUpdateSql.isEmpty())
        {
            return tmpSql.toString();
        }

        tmpSql.append(tmpUpdateSql);
        tmpSql.append(String.format("SET $%s = ROW_COUNT();\r\n", f_EffectedCount));
        return tmpSql.toString();

    }

    public static java.lang.String _5($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Mysql);

    }

    public static java.lang.String _6($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
        tmpSql.append(String.format("SET $%s = 0;", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);            

            String tmpUpdateSql = ToolFunction.FillUpdateRow(row, tmpSetList, tmpWhere, DBTypeEnum.Mysql);

            if (tmpUpdateSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpUpdateSql);
            tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

    }

    public static java.lang.String _7($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Mysql);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpDeleteSql);
            tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

    }

    public static java.lang.String _8($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Mysql);

    }

    public static java.lang.String _9($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Mysql);

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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpOrderByList.add(new OrderByField(ToolFunction.GetOrderByField("a.iID", tmpSelectFieldList, tmpTableList, DBTypeEnum.Mysql), false));
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        ToolFunction.GenerateOrderBy(tmpOrderByList, tmpOrderBy);
        tmpSql.append(tmpOrderBy);
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
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationInRows(tmpTable0,($Ku.by.Object.List<$Ku.by.Object.Row>)f_Parameter.getParameterList().get(0), DBTypeEnum.Mysql));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
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
        int tmpConfigJoinTableCount = 0;
        String tmpConfigName0 = "selectLeft";
        String tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
        $Ku.by.ToolClass.Config tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.getKuName(), tmpIdentityName0, tmpConfigName0, tmpTable0.getSheet().getSheetName());
        ArrayList<$Ku.by.ToolClass.Source> tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.getKuName(), tmpConfig0);
        tmpMergedFieldList.addAll(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationInRows(tmpTable0,($Ku.by.Object.List<$Ku.by.Object.Row>)f_Parameter.getParameterList().get(0), DBTypeEnum.Mysql));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
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
        int tmpConfigJoinTableCount = 0;
        String tmpConfigName0 = "selectRight";
        String tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
        $Ku.by.ToolClass.Config tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.getKuName(), tmpIdentityName0, tmpConfigName0, tmpTable0.getSheet().getSheetName());
        ArrayList<$Ku.by.ToolClass.Source> tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.getKuName(), tmpConfig0);
        tmpMergedFieldList.addAll(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationInRows(tmpTable0,($Ku.by.Object.List<$Ku.by.Object.Row>)f_Parameter.getParameterList().get(0), DBTypeEnum.Mysql));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _14($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Mysql);

    }

    public static java.lang.String _15($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Mysql);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpDeleteSql);
            tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

    }

    public static java.lang.String _16($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Mysql);

    }

    public static java.lang.String _17($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Mysql);

    }

    public static java.lang.String _18($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Mysql);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpDeleteSql);
            tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

    }

    public static java.lang.String[] _19($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        ArrayList<String> tmpSql = new ArrayList<>();

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  

            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Mysql);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.add(tmpDeleteSql);
        }

        return tmpSql.toArray(new String[0]);
    }

    public static java.lang.String _20($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Mysql);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpDeleteSql);
            tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedCount,f_EffectedCount));
        }

        return tmpSql.toString();

    }

    public static java.lang.String _21($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Mysql);

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
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));

        for ($Ku.by.Object.Row row : rowArrayList)
        {
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

            if (tmpDataSheet == null)
            {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
            String tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Mysql);

            if (tmpDeleteSql.isEmpty())
            {
                continue;
            }

            tmpSql.append(tmpDeleteSql);
            tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedCount,f_EffectedCount));
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
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.getParameterList().get(0))));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String[] _24($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowListNotInTran(f_Parameter.getParameterList().get(0), tmpColList, DBTypeEnum.Mysql);

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

        String tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Mysql);

        if (tmpUpdateSql != null && (tmpUpdateSql.isEmpty()))
        {
            return new String[]{""};
        }

        return new String[]{tmpUpdateSql};

    }

    public static java.lang.String[] _26($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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

        String tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.Mysql);

        if (tmpDeleteSql.isEmpty())
        {
            return new String[]{""};
        }

        return new String[]{tmpDeleteSql};

    }

    public static java.lang.String[] _27($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowListNotInTran(f_Parameter.getParameterList().get(0), tmpColList, DBTypeEnum.Mysql);

    }

    public static java.lang.String[] _28($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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

        String tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Mysql);

        if (tmpUpdateSql != null && (tmpUpdateSql.isEmpty()))
        {
            return new String[]{""};
        }

        return new String[]{tmpUpdateSql};

    }

    public static java.lang.String[] _29($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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

        String tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.Mysql);

        if (tmpDeleteSql.isEmpty())
        {
            return new String[]{""};
        }

        return new String[]{tmpDeleteSql};

    }

    public static $Ku.by.ToolClass.Sql.SelectTable _30($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
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
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationEqualRow(tmpTable0, ($Ku.by.Object.Row)f_Parameter.getParameterList().get(0), DBTypeEnum.Mysql));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String _31($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        ArrayList<String> tmpColList = new ArrayList<>();
        return ToolFunction.InsertRowOrRowList(f_Parameter.getParameterList().get(0), f_EffectedCount, tmpColList, true, DBTypeEnum.Mysql);

    }

    public static java.lang.String _32($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
            return String.format("SET $%s = 0;\r\n", f_EffectedCount);
        }
        $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);  
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));
        String tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Mysql);

        if (tmpUpdateSql != null && tmpUpdateSql.isEmpty())
        {
            return tmpSql.toString();
        }

        tmpSql.append(tmpUpdateSql);
        tmpSql.append(String.format("SET $%s = ROW_COUNT();\r\n", f_EffectedCount));
        return tmpSql.toString();

    }

    public static java.lang.String _33($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
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
            return String.format("SET $%s = 0;\r\n", f_EffectedCount);
        }
        $Ku.by.ToolClass.Sql.SqlTable tmpTableList = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedCount));
        String tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.Mysql);

        if (tmpDeleteSql.isEmpty())
        {
            return tmpSql.toString();
        }

        tmpSql.append(tmpDeleteSql);
        tmpSql.append(String.format("SET $%s = ROW_COUNT();\r\n", f_EffectedCount));
        return tmpSql.toString();

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
        int tmpConfigJoinTableCount = 0;
        String tmpConfigName0 = "select";
        String tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
        $Ku.by.ToolClass.Config tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.getKuName(), tmpIdentityName0, tmpConfigName0, tmpTable0.getSheet().getSheetName());
        ArrayList<$Ku.by.ToolClass.Source> tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.getKuName(), tmpConfig0);
        tmpMergedFieldList.addAll(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationEqualQueryData(tmpTable0, (QueryData) f_Parameter.getParameterList().get(0), tmpHaving, tmpConfigJoinTableCount, DBTypeEnum.Mysql, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
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
        tmpTable0.setAlias("a");
        tmpTableList.add(tmpTable0);
        tmpEquivalentTables.add(tmpTable0);
        int tmpConfigJoinTableCount = 0;
        String tmpConfigName0 = "select";
        String tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
        $Ku.by.ToolClass.Config tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.getKuName(), tmpIdentityName0, tmpConfigName0, tmpTable0.getSheet().getSheetName());
        ArrayList<$Ku.by.ToolClass.Source> tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.getKuName(), tmpConfig0);
        tmpMergedFieldList.addAll(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
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
        int tmpConfigJoinTableCount = 0;
        String tmpConfigName0 = "select";
        String tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
        $Ku.by.ToolClass.Config tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.getKuName(), tmpIdentityName0, tmpConfigName0, tmpTable0.getSheet().getSheetName());
        ArrayList<$Ku.by.ToolClass.Source> tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.getKuName(), tmpConfig0);
        tmpMergedFieldList.addAll(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationEqualQueryData(tmpTable0, (QueryData) f_Parameter.getParameterList().get(0), tmpHaving, tmpConfigJoinTableCount, DBTypeEnum.Mysql, new OutObject<>(tmpConfigJoinTableCount)));
        tmpWhere.append(" and ");
        tmpWhere.append(ToolFunction.TableRelationEqualRow(tmpTable0, ($Ku.by.Object.Row)f_Parameter.getParameterList().get(1), DBTypeEnum.Mysql));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
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
        int tmpConfigJoinTableCount = 0;
        String tmpConfigName0 = "select";
        String tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
        $Ku.by.ToolClass.Config tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.getKuName(), tmpIdentityName0, tmpConfigName0, tmpTable0.getSheet().getSheetName());
        ArrayList<$Ku.by.ToolClass.Source> tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.getKuName(), tmpConfig0);
        tmpMergedFieldList.addAll(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, new OutObject<>(tmpConfigJoinTableCount)));
        tmpSelectFieldList.add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
        ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
        tmpSql.append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, tmpOrderByList, DBTypeEnum.Mysql, false));
        tmpWhere.append(" WHERE ");
        tmpWhere.append(ToolFunction.TableRelationEqualRow(tmpTable0, ($Ku.by.Object.Row)f_Parameter.getParameterList().get(0), DBTypeEnum.Mysql));
        tmpSql.append(tmpWhere);
        ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Mysql);
        tmpSql.append(tmpGroupBy);
        tmpSql.append(tmpHaving);

        return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.toString());
    }

    public static java.lang.String[] Tran_0($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_0;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_0()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");
        tmpTran.append("DECLARE $tmpLineCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        String tmpLocalDec_0 = _2(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("SET $tmpLineCount = $EffectedCount;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "$tmpLineCount";
        String tmpLocalDec_2 = "1";
        tmpBody.append(ToolFunction.BinaryExpression(tmpLocalDec_1, " < ", tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ");
        tmpBody.append(SaveInspect.CharactorEscape("删除失败：没有符合条件的行！"));

        tmpBody.append(";\r\n");
        tmpBody.append("END IF;\r\n");
        tmpBody.append(_3(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_0();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_0;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_1($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_1;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_1()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");
        tmpTran.append("DECLARE $tmpLineCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        String tmpLocalDec_0 = _4(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("SET $tmpLineCount = $EffectedCount;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "$tmpLineCount";
        String tmpLocalDec_2 = "0";
        tmpBody.append(ToolFunction.EqualExpression(tmpLocalDec_1, tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ");
        tmpBody.append(SaveInspect.CharactorEscape("更新失败：返回0行！"));

        tmpBody.append(";\r\n");
        tmpBody.append("END IF;\r\n");
        tmpBody.append(_5(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpBody.append(_6(f_TranParmas.getParamters().get(2), "EffectedCount"));
        tmpBody.append(_7(f_TranParmas.getParamters().get(3), "EffectedCount"));
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_1();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_1;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_2($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_2;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_2()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");
        tmpTran.append("DECLARE $tmpLineCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        String tmpLocalDec_0 = _8(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("SET $tmpLineCount = $EffectedCount;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "$tmpLineCount";
        String tmpLocalDec_2 = "1";
        tmpBody.append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ");
        tmpBody.append(SaveInspect.CharactorEscape("数据插入失败！"));

        tmpBody.append(";\r\n");
        tmpBody.append("END IF;\r\n");
        tmpBody.append(_9(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_2();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_2;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_3($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_3;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_3()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        tmpBody.append(_14(f_TranParmas.getParamters().get(0), "EffectedCount"));
        tmpBody.append(_15(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_3();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_3;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_4($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_4;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_4()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");
        tmpTran.append("DECLARE $tmpRowCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        String tmpLocalDec_0 = _16(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("SET $tmpRowCount = $EffectedCount;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "$tmpRowCount";
        String tmpLocalDec_2 = SaveInspect.CharactorEscape(f_TranParmas.Values.get(0));
        tmpBody.append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("ROLLBACK;\r\n");
        tmpBody.append("SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ");
        tmpBody.append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

        tmpBody.append(";\r\n");
        tmpBody.append("END IF;\r\n");
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_4();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_4;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_5($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_5;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_5()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");
        tmpTran.append("DECLARE $tmpTotal INT;\r\n");
        tmpTran.append("DECLARE $tmpTotal2 INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        String tmpLocalDec_0 = _17(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("SET $tmpTotal = $EffectedCount;\r\n");

        String tmpLocalDec_1 = _18(f_TranParmas.getParamters().get(1), "EffectedCount");
        tmpBody.append(tmpLocalDec_1);
        tmpBody.append("SET $tmpTotal2 = $EffectedCount;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_3 = "$tmpTotal2";

        String tmpLocalDec_4 = "0";

        String tmpLocalDec_2 = ToolFunction.EqualExpression(tmpLocalDec_3, tmpLocalDec_4);
        String tmpLocalDec_6 = "$tmpTotal";

        String tmpLocalDec_7 = "0";

        String tmpLocalDec_5 = ToolFunction.EqualExpression(tmpLocalDec_6, tmpLocalDec_7);
        tmpBody.append(ToolFunction.BinaryExpression(tmpLocalDec_2, " and ", tmpLocalDec_5));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("ROLLBACK;\r\n");
        tmpBody.append("SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ");
        tmpBody.append(SaveInspect.CharactorEscape("没有返回更新成功的行数！"));

        tmpBody.append(";\r\n");
        tmpBody.append("END IF;\r\n");
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_5();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_5;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_6($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_6;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_6()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        tmpBody.append(_20(f_TranParmas.getParamters().get(0), "EffectedCount"));
        tmpBody.append(_21(f_TranParmas.getParamters().get(1), "EffectedCount"));
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_6();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_6;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_7($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_7;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_7()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        tmpBody.append(_22(f_TranParmas.getParamters().get(0), "EffectedCount"));
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_7();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_7;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_8($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_8;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_8()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");
        tmpTran.append("DECLARE $tmpRowCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        String tmpLocalDec_0 = _31(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("SET $tmpRowCount = $EffectedCount;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "$tmpRowCount";
        String tmpLocalDec_2 = "1";
        tmpBody.append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("ROLLBACK;\r\n");
        tmpBody.append("SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ");
        tmpBody.append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

        tmpBody.append(";\r\n");
        tmpBody.append("END IF;\r\n");
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_8();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_8;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_9($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_9;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_9()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");
        tmpTran.append("DECLARE $tmpRowCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        String tmpLocalDec_0 = _32(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("SET $tmpRowCount = $EffectedCount;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "$tmpRowCount";
        String tmpLocalDec_2 = "1";
        tmpBody.append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("ROLLBACK;\r\n");
        tmpBody.append("SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ");
        tmpBody.append(SaveInspect.CharactorEscape("对数据库 update 失败"));

        tmpBody.append(";\r\n");
        tmpBody.append("END IF;\r\n");
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_9();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_9;\r\n");
        return result.toArray(new String[0]);
    }

    public static java.lang.String[] Tran_10($Ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas) {
        ArrayList<String> result = new ArrayList<>();
        StringBuilder tmpTran = new StringBuilder();
        tmpTran.append("SET GLOBAL innodb_lock_wait_timeout = 50;\r\n");
        StringBuilder tmpBody = new StringBuilder("START TRANSACTION;\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_10;\r\n");
        tmpTran.append("CREATE PROCEDURE byBase_Tran_10()\r\n");
        tmpTran.append("`tran` : BEGIN\r\n");
        tmpTran.append("DECLARE $EffectedCount INT;\r\n");
        tmpTran.append("DECLARE $tmpRowCount INT;\r\n");

        tmpTran.append("DECLARE EXIT HANDLER FOR SQLEXCEPTION\r\n");
        tmpTran.append("BEGIN\r\n");
        tmpTran.append("ROLLBACK;\r\n");
        tmpTran.append("RESIGNAL;\r\n");
        tmpTran.append("END;\r\n");
        String tmpLocalDec_0 = _33(f_TranParmas.getParamters().get(0), "EffectedCount");
        tmpBody.append(tmpLocalDec_0);
        tmpBody.append("SET $tmpRowCount = $EffectedCount;\r\n");

        tmpBody.append("\r\nIF ");
        String tmpLocalDec_1 = "$tmpRowCount";
        String tmpLocalDec_2 = "1";
        tmpBody.append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

        tmpBody.append(" THEN\r\n");
        tmpBody.append("ROLLBACK;\r\n");
        tmpBody.append("SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ");
        tmpBody.append(SaveInspect.CharactorEscape("对数据库 delete 失败"));

        tmpBody.append(";\r\n");
        tmpBody.append("END IF;\r\n");
        tmpTran.append(tmpBody);
        tmpTran.append("COMMIT;\r\n");
        tmpTran.append("END;\r\n");
        result.add(String.valueOf(tmpTran));
        result.add("CALL byBase_Tran_10();\r\n");
        result.add("DROP PROCEDURE IF EXISTS byBase_Tran_10;\r\n");
        return result.toArray(new String[0]);
    }
}
