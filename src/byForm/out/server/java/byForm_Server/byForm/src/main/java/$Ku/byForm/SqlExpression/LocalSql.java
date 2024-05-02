package $Ku.byForm.SqlExpression;

import $Ku.*;
import $Ku.by.Identity.*;
import $Ku.by.ToolClass.Sql.*;
import $Ku.by.Object.Cell;
import $Ku.by.Object.Row;
import $Ku.by.Object.List;
import $Ku.by.ToolClass.*;
import java.util.ArrayList;
public class LocalSql {
    public static Integer _8(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byForm.SqlExpression.Sql._8(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static Integer _9(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byForm.SqlExpression.Sql._9(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }

    public static Integer _11($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParamList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParamList);
        $Ku.byForm.Identity.formField tmpSource0 = ($Ku.byForm.Identity.formField)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));

        String tmpSql = $Ku.byForm.SqlExpression.Sql._11(tmpParamsPackage);

        return SqlHelper.ExecuteNonQuery(tmpSql, tmpDataSheet0.getKuName());
    }

    public static $Ku.by.ToolClass.SqlType _12($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.form tmpSource0 = ($Ku.byForm.Identity.form)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._12(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _13($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.formField tmpSource0 = ($Ku.byForm.Identity.formField)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("b");
        SelectTable tmpSelectTable = Sql._13(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _14($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.form tmpSource0 = ($Ku.byForm.Identity.form)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._14(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _15($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.formField tmpSource0 = ($Ku.byForm.Identity.formField)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("b");
        SelectTable tmpSelectTable = Sql._15(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _16($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.formData tmpSource0 = ($Ku.byForm.Identity.formData)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._16(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _17($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.formData tmpSource0 = ($Ku.byForm.Identity.formData)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._17(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _18($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.formData tmpSource0 = ($Ku.byForm.Identity.formData)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._18(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static $Ku.by.ToolClass.SqlType _19($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.formData tmpSource0 = ($Ku.byForm.Identity.formData)f_Tables[0];
        IBaseDataSheet tmpDataSheet0 = Root.GetInstance().GetDataSheetByInstance(tmpSource0);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet0, null);
        tmpTableList.add(tmpTable0);
        tmpTable0.setIsOuterTable(false);
        tmpTable0.setAlias("a");
        SelectTable tmpSelectTable = Sql._19(tmpParamsPackage);
        return new SqlType(null, tmpSelectTable);
    }

    public static ParamsPackage _20(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static $Ku.by.ToolClass.Sql.ParamsPackage _21(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static ParamsPackage _22(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return tmpParamsPackage;
    }

    public static void Tran_0(java.util.ArrayList<$Ku.by.ToolClass.ITableSource> f_Identity, java.util.ArrayList<java.util.ArrayList<Object>> f_Params, java.util.ArrayList<Object> f_Values) {
        ArrayList<ParamsPackage> tmpParamsList = new ArrayList<>();
        TranParamsPackage tmpPackage = new TranParamsPackage(null, null, null, tmpParamsList, f_Values);
        tmpParamsList.add(_20(f_Params.get(0).toArray()));
        tmpParamsList.add(_21(f_Params.get(1).toArray()));
        tmpParamsList.add(_22(f_Params.get(2).toArray()));
        String[] tmpSql = $Ku.byForm.SqlExpression.Sql.Tran_0(tmpPackage);
        $Ku.by.ToolClass.Sql.SqlHelper.ExecuteNonQuery(tmpSql, tmpPackage.ExecuteKuName);
    }

    public static $Ku.by.ToolClass.SqlType _37($Ku.by.ToolClass.ITableSource[] f_Tables, Object[] f_Params) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new java.util.ArrayList<>();
        java.util.ArrayList<Object> tmpParameterList = new java.util.ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTableList, tmpParameterList);
        tmpParameterList.addAll(java.util.Arrays.asList(f_Params));
        $Ku.byForm.Identity.fieldTemplate tmpSource0 = ($Ku.byForm.Identity.fieldTemplate)f_Tables[0];
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
}
