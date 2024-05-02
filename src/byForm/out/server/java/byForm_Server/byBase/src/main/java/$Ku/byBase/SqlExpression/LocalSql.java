package $Ku.byBase.SqlExpression;

import $Ku.*;
import $Ku.by.Identity.*;
import $Ku.by.ToolClass.Sql.*;
import $Ku.by.Object.Cell;
import $Ku.by.Object.Row;
import $Ku.by.Object.List;
import $Ku.by.ToolClass.*;
import java.util.ArrayList;
public class LocalSql {
    public static $Ku.by.ToolClass.SqlType _0($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.popupTable tmpSource0 = ($Ku.byBase.Identity.popupTable)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._0(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _1($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.Tree tmpSource0 = ($Ku.byBase.Identity.Tree)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._1(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _12($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.bridge tmpSource0 = ($Ku.byBase.Identity.bridge)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._12(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _13($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.bridge tmpSource0 = ($Ku.byBase.Identity.bridge)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._13(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static ParamsPackage _14(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _15(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_3(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_14(f_Params.get(0).toArray()));
        tmpParamsList.add(_15(f_Params.get(1).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_3(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static $Ku.by.ToolClass.SqlType _23($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.extend tmpSource0 = ($Ku.byBase.Identity.extend)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._23(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static Integer _24(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byBase.SqlExpression.Sql._24(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static Integer _25(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byBase.SqlExpression.Sql._25(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static Integer _26(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byBase.SqlExpression.Sql._26(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static $Ku.by.ToolClass.SqlType _30($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.detail tmpSource0 = ($Ku.byBase.Identity.detail)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._30(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static ParamsPackage _31(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_8(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_31(f_Params.get(0).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_8(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static $Ku.by.ToolClass.Sql.ParamsPackage _32(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_9(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_32(f_Params.get(0).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_9(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static ParamsPackage _33(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_10(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_33(f_Params.get(0).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_10(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static $Ku.by.ToolClass.SqlType _34($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.dic tmpSource0 = ($Ku.byBase.Identity.dic)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._34(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _35($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.dic tmpSource0 = ($Ku.byBase.Identity.dic)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._35(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _36($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.dic tmpSource0 = ($Ku.byBase.Identity.dic)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._36(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _37($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byBase.Identity.dic tmpSource0 = ($Ku.byBase.Identity.dic)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._37(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            selectRow.$Identity = tmpTableList.get(0).GetIdentity();
            IBaseDataSheet tmpRowSheet = tmpTableList.get(0).GetSource();
            selectRow.setSheetName(tmpRowSheet.getSheetName());

            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField =tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));        }
        return new SqlType(tmpValue, tmpSelectTable);
    }

    public static ParamsPackage _2(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _3(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_0(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_2(f_Params.get(0).toArray()));
        tmpParamsList.add(_3(f_Params.get(1).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_0(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static $Ku.by.ToolClass.Sql.ParamsPackage _4(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _5(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static $Ku.by.ToolClass.Sql.ParamsPackage _6(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _7(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_1(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_4(f_Params.get(0).toArray()));
        tmpParamsList.add(_5(f_Params.get(1).toArray()));
        tmpParamsList.add(_6(f_Params.get(2).toArray()));
        tmpParamsList.add(_7(f_Params.get(3).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_1(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static ParamsPackage _8(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _9(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_2(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_8(f_Params.get(0).toArray()));
        tmpParamsList.add(_9(f_Params.get(1).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_2(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static ParamsPackage _16(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_4(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_16(f_Params.get(0).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_4(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static ParamsPackage _17(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _18(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_5(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_17(f_Params.get(0).toArray()));
        tmpParamsList.add(_18(f_Params.get(1).toArray()));
        String[] tmpSql = $Ku.byBase.SqlExpression.Sql.Tran_5(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static Integer _19(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byBase.SqlExpression.Sql._19(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }
}
