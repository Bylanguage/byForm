package $Ku.byForm.SqlExpression;

import $Ku.by.ToolClass.Sql.*;
import $Ku.by.ToolClass.*;
import java.util.ArrayList;
import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.Root;
public class Sql {
    public static $Ku.by.ToolClass.Sql.SelectTable _0($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._0(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._0(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._0(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _1($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._1(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._1(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._1(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _2($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._2(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._2(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._2(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _3($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._3(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._3(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._3(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _4($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._4(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._4(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._4(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _5($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._5(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._5(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._5(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _6($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._6(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._6(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._6(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _7($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._7(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._7(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._7(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String[] _8($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._8(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._8(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._8(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String[] _9($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._9(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._9(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._9(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _10($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._10(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._10(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._10(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String _11($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._11(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._11(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._11(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _12($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._12(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._12(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._12(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _13($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._13(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._13(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._13(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _14($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._14(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._14(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._14(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _15($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._15(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._15(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._15(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _16($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._16(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._16(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._16(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _17($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._17(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._17(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._17(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _18($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._18(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._18(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._18(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _19($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._19(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._19(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._19(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String _20($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._20(f_Parameter, f_EffectedCount);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._20(f_Parameter, f_EffectedCount);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._20(f_Parameter, f_EffectedCount);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String _21($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._21(f_Parameter, f_EffectedCount);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._21(f_Parameter, f_EffectedCount);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._21(f_Parameter, f_EffectedCount);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String _22($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._22(f_Parameter, f_EffectedCount);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._22(f_Parameter, f_EffectedCount);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._22(f_Parameter, f_EffectedCount);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _23($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._23(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._23(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._23(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String[] _24($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._24(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._24(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._24(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String[] _25($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._25(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._25(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._25(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _26($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._26(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._26(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._26(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _27($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._27(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._27(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._27(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _28($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._28(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._28(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._28(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _29($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._29(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._29(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._29(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String _30($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._30(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._30(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._30(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String _31($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._31(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._31(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._31(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String _32($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter, java.lang.String f_EffectedCount) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._32(f_Parameter, f_EffectedCount);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._32(f_Parameter, f_EffectedCount);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._32(f_Parameter, f_EffectedCount);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String[] _33($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._33(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._33(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._33(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _34($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._34(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._34(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._34(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _35($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._35(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._35(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._35(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String _36($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._36(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._36(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._36(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static $Ku.by.ToolClass.Sql.SelectTable _37($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._37(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._37(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._37(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String[] Tran_0($Ku.by.ToolClass.Sql.TranParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer)
        {
            return SqlserverAssembler.Tran_0(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql)
        {
            return MysqlAssembler.Tran_0(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle)
        {
            return OracleAssembler.Tran_0(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String[] Tran_1($Ku.by.ToolClass.Sql.TranParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer)
        {
            return SqlserverAssembler.Tran_1(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql)
        {
            return MysqlAssembler.Tran_1(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle)
        {
            return OracleAssembler.Tran_1(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }

    public static java.lang.String[] Tran_2($Ku.by.ToolClass.Sql.TranParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer)
        {
            return SqlserverAssembler.Tran_2(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql)
        {
            return MysqlAssembler.Tran_2(f_Parameter);
        }        
        else if(tmpDBType == DBTypeEnum.Oracle)
        {
            return OracleAssembler.Tran_2(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }
}
