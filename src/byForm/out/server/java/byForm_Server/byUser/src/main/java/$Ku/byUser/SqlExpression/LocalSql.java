package $Ku.byUser.SqlExpression;

import $Ku.*;
import $Ku.by.Identity.*;
import $Ku.by.ToolClass.Sql.*;
import $Ku.by.Object.Cell;
import $Ku.by.Object.Row;
import $Ku.by.Object.List;
import $Ku.by.ToolClass.*;
import java.util.ArrayList;
public class LocalSql {
    public static $Ku.by.ToolClass.SqlType _1($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._1(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.Orm0> _0($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        ITableSource tmpSource0 = f_Tables[0];
        $Ku.by.ToolClass.Sql.AbstractTable tmpTable0 = tmpSource0.getSource();
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        $Ku.byUser.Identity.userAdmin tmpSource1 = ($Ku.byUser.Identity.userAdmin)f_Tables[1];
        IBaseDataSheet tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet1, null);
        tmpTableList.add(tmpTable1);
        tmpTable0.setIsOuterTable(false);
        tmpTable1.setAlias("b");
        $Ku.byUser.Identity.userICO tmpSource2 = ($Ku.byUser.Identity.userICO)f_Tables[2];
        IBaseDataSheet tmpDataSheet2 = Root.GetInstance().GetDataSheetByInstance(tmpSource2);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable2 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet2, null);
        tmpTableList.add(tmpTable2);
        tmpTable0.setIsOuterTable(false);
        tmpTable2.setAlias("c");
        SelectTable tmpSelectTable = Sql._0(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        java.util.ArrayList<$Ku.byUser.Orm.Orm0> tmpOrmList = new java.util.ArrayList<>();
        OrmResult<$Ku.byUser.Orm.Orm0> tmpResult = new OrmResult<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.byUser.Orm.Orm0.class));
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField = tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));
            $Ku.byUser.Orm.Orm0 tmpOrm = new $Ku.byUser.Orm.Orm0(tmpSelectTable, selectRow);
            tmpOrmList.add(tmpOrm);
        }
        tmpResult.setSource(tmpSelectTable);
        tmpResult.setRows(tmpOrmList);
        return tmpResult;
    }

    public static Integer _2(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byUser.SqlExpression.Sql._2(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static $Ku.by.ToolClass.SqlType _3($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._3(tmpParamsPackage);
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

    public static Integer _4($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParamList = new java.util.ArrayList<>();
        ParamsPackage f_Parameter = new ParamsPackage(null, null, tmpTableList, tmpParamList);
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));

        String tmpSql = $Ku.byUser.SqlExpression.Sql._4(f_Parameter);
        return SqlHelper.ExecuteNonQuery(tmpSql, tmpDataSheet0.getKuName());
    }

    public static $Ku.by.ToolClass.SqlType _5($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._5(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.SqlType _6($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._6(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.SqlType _7($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._7(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.Sql.ParamsPackage _8($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParamList = new java.util.ArrayList<>();
        ParamsPackage f_Parameter = new ParamsPackage(null, null, tmpTableList, tmpParamList);
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));

        return f_Parameter;
    }

    public static void Tran_0(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_8(new ITableSource[] { f_Identity.get(0) }, new ArrayList[]{f_Params.get(0)}));
        String[] tmpSql = $Ku.byUser.SqlExpression.Sql.Tran_0(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static $Ku.by.ToolClass.SqlType _9($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._9(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.SqlType _10($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._10(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.SqlType _11($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._11(tmpParamsPackage);
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
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
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
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
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

    public static $Ku.by.ToolClass.SqlType _14($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._14(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.SqlType _15($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._15(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.Sql.SelectTable _17($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.anonymous tmpSource0 = ($Ku.byUser.Identity.anonymous)f_Tables[0] ;
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("b");
        $Ku.byUser.Identity.user tmpSource1 = ($Ku.byUser.Identity.user)f_Tables[1] ;
        IBaseDataSheet tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet1, null);
        tmpTableList.add(tmpTable1);
        tmpTable1.setIsOuterTable(true);
        tmpTable1.setAlias("a");
        return $Ku.byUser.SqlExpression.Sql._17(tmpParamsPackage);
    }

    public static $Ku.by.ToolClass.SqlType _16($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._16(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.SqlType _19($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._19(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.Orm0> _18($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        ITableSource tmpSource0 = f_Tables[0];
        $Ku.by.ToolClass.Sql.AbstractTable tmpTable0 = tmpSource0.getSource();
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        $Ku.byUser.Identity.userAdmin tmpSource1 = ($Ku.byUser.Identity.userAdmin)f_Tables[1];
        IBaseDataSheet tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet1, null);
        tmpTableList.add(tmpTable1);
        tmpTable0.setIsOuterTable(false);
        tmpTable1.setAlias("b");
        $Ku.byUser.Identity.userICO tmpSource2 = ($Ku.byUser.Identity.userICO)f_Tables[2];
        IBaseDataSheet tmpDataSheet2 = Root.GetInstance().GetDataSheetByInstance(tmpSource2);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable2 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet2, null);
        tmpTableList.add(tmpTable2);
        tmpTable0.setIsOuterTable(false);
        tmpTable2.setAlias("c");
        SelectTable tmpSelectTable = Sql._18(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        java.util.ArrayList<$Ku.byUser.Orm.Orm0> tmpOrmList = new java.util.ArrayList<>();
        OrmResult<$Ku.byUser.Orm.Orm0> tmpResult = new OrmResult<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.byUser.Orm.Orm0.class));
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField = tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));
            $Ku.byUser.Orm.Orm0 tmpOrm = new $Ku.byUser.Orm.Orm0(tmpSelectTable, selectRow);
            tmpOrmList.add(tmpOrm);
        }
        tmpResult.setSource(tmpSelectTable);
        tmpResult.setRows(tmpOrmList);
        return tmpResult;
    }

    public static ParamsPackage _20(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _21(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_1(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_20(f_Params.get(0).toArray()));
        tmpParamsList.add(_21(f_Params.get(1).toArray()));
        String[] tmpSql = $Ku.byUser.SqlExpression.Sql.Tran_1(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static $Ku.by.ToolClass.SqlType _23($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._23(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.Orm0> _22($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        ITableSource tmpSource0 = f_Tables[0];
        $Ku.by.ToolClass.Sql.AbstractTable tmpTable0 = tmpSource0.getSource();
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        $Ku.byUser.Identity.userAdmin tmpSource1 = ($Ku.byUser.Identity.userAdmin)f_Tables[1];
        IBaseDataSheet tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet1, null);
        tmpTableList.add(tmpTable1);
        tmpTable0.setIsOuterTable(false);
        tmpTable1.setAlias("b");
        $Ku.byUser.Identity.userICO tmpSource2 = ($Ku.byUser.Identity.userICO)f_Tables[2];
        IBaseDataSheet tmpDataSheet2 = Root.GetInstance().GetDataSheetByInstance(tmpSource2);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable2 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet2, null);
        tmpTableList.add(tmpTable2);
        tmpTable0.setIsOuterTable(false);
        tmpTable2.setAlias("c");
        SelectTable tmpSelectTable = Sql._22(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        java.util.ArrayList<$Ku.byUser.Orm.Orm0> tmpOrmList = new java.util.ArrayList<>();
        OrmResult<$Ku.byUser.Orm.Orm0> tmpResult = new OrmResult<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.byUser.Orm.Orm0.class));
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField = tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));
            $Ku.byUser.Orm.Orm0 tmpOrm = new $Ku.byUser.Orm.Orm0(tmpSelectTable, selectRow);
            tmpOrmList.add(tmpOrm);
        }
        tmpResult.setSource(tmpSelectTable);
        tmpResult.setRows(tmpOrmList);
        return tmpResult;
    }

    public static $Ku.by.ToolClass.SqlType _24($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._24(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.SqlType _26($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.userICO tmpSource0 = ($Ku.byUser.Identity.userICO)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._26(tmpParamsPackage);
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

    public static ParamsPackage _27(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static $Ku.by.ToolClass.Sql.ParamsPackage _28(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_2(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_27(f_Params.get(0).toArray()));
        tmpParamsList.add(_28(f_Params.get(1).toArray()));
        String[] tmpSql = $Ku.byUser.SqlExpression.Sql.Tran_2(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static ParamsPackage _29(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _30(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_3(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_29(f_Params.get(0).toArray()));
        tmpParamsList.add(_30(f_Params.get(1).toArray()));
        String[] tmpSql = $Ku.byUser.SqlExpression.Sql.Tran_3(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static Integer _31(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byUser.SqlExpression.Sql._31(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static $Ku.by.ToolClass.SqlType _32($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.userAdmin tmpSource0 = ($Ku.byUser.Identity.userAdmin)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._32(tmpParamsPackage);
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

    public static $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.Orm1> _33($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.userAdmin tmpSource0 = ($Ku.byUser.Identity.userAdmin)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        $Ku.byUser.Identity.user tmpSource1 = ($Ku.byUser.Identity.user)f_Tables[1];
        IBaseDataSheet tmpDataSheet1 = Root.GetInstance().GetDataSheetByInstance(tmpSource1);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable1 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet1, null);
        tmpTableList.add(tmpTable1);
        tmpTable1.setIsOuterTable(false);
        tmpTable1.setAlias("b");
        SelectTable tmpSelectTable = Sql._33(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        java.util.ArrayList<$Ku.byUser.Orm.Orm1> tmpOrmList = new java.util.ArrayList<>();
        OrmResult<$Ku.byUser.Orm.Orm1> tmpResult = new OrmResult<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.byUser.Orm.Orm1.class));
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField = tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));
            $Ku.byUser.Orm.Orm1 tmpOrm = new $Ku.byUser.Orm.Orm1(tmpSelectTable, selectRow);
            tmpOrmList.add(tmpOrm);
        }
        tmpResult.setSource(tmpSelectTable);
        tmpResult.setRows(tmpOrmList);
        return tmpResult;
    }

    public static Integer _34(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byUser.SqlExpression.Sql._34(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static Integer _35(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byUser.SqlExpression.Sql._35(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static $Ku.by.ToolClass.SqlType _36($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
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
        $Ku.byUser.Identity.user tmpSource0 = ($Ku.byUser.Identity.user)f_Tables[0];
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

    public static $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.TemporaryOrm$0> _38($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.userAdmin tmpSource0 = ($Ku.byUser.Identity.userAdmin)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._38(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        java.util.ArrayList<$Ku.byUser.Orm.TemporaryOrm$0> tmpOrmList = new java.util.ArrayList<>();
        OrmResult<$Ku.byUser.Orm.TemporaryOrm$0> tmpResult = new OrmResult<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.byUser.Orm.TemporaryOrm$0.class));
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField = tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));
            $Ku.byUser.Orm.TemporaryOrm$0 tmpOrm = new $Ku.byUser.Orm.TemporaryOrm$0(tmpSelectTable, selectRow);
            tmpOrmList.add(tmpOrm);
        }
        tmpResult.setSource(tmpSelectTable);
        tmpResult.setRows(tmpOrmList);
        return tmpResult;
    }

    public static $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.TemporaryOrm$1> _39($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byUser.Identity.userAdmin tmpSource0 = ($Ku.byUser.Identity.userAdmin)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._39(tmpParamsPackage);
        String tmpSql = tmpSelectTable.getSqlValue();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpValue = SqlHelper.SelectReturnRows(tmpSql, tmpTable0.GetSource().getKuName());
        java.util.ArrayList<$Ku.byUser.Orm.TemporaryOrm$1> tmpOrmList = new java.util.ArrayList<>();
        OrmResult<$Ku.byUser.Orm.TemporaryOrm$1> tmpResult = new OrmResult<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.byUser.Orm.TemporaryOrm$1.class));
        for ($Ku.by.Object.Row selectRow : tmpValue)
        {
            for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++)
            {
                $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                $Ku.by.ToolClass.Sql.AbstractSelectField tmpField = tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                tmpCell.MatchField(tmpField);
                tmpCell.checkValue();
            }
            selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));
            $Ku.byUser.Orm.TemporaryOrm$1 tmpOrm = new $Ku.byUser.Orm.TemporaryOrm$1(tmpSelectTable, selectRow);
            tmpOrmList.add(tmpOrm);
        }
        tmpResult.setSource(tmpSelectTable);
        tmpResult.setRows(tmpOrmList);
        return tmpResult;
    }

    public static ParamsPackage _40(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _41(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_4(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_40(f_Params.get(0).toArray()));
        tmpParamsList.add(_41(f_Params.get(1).toArray()));
        String[] tmpSql = $Ku.byUser.SqlExpression.Sql.Tran_4(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }
}
