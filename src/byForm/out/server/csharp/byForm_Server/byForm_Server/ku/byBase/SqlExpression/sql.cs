using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Sql;
namespace byForm_Server.ku.byBase.SqlExpression
{
    public class sql
    {
        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _0(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._0(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._0(f_Parameter);
            }
            else
            {
                return OracleAssembler._0(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _1(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._1(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._1(f_Parameter);
            }
            else
            {
                return OracleAssembler._1(f_Parameter);
            }
        }

        public static string _2(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._2(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._2(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._2(f_Parameter, f_EffectedCount);
            }
        }

        public static string _3(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._3(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._3(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._3(f_Parameter, f_EffectedCount);
            }
        }

        public static string _4(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._4(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._4(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._4(f_Parameter, f_EffectedCount);
            }
        }

        public static string _5(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._5(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._5(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._5(f_Parameter, f_EffectedCount);
            }
        }

        public static string _6(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._6(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._6(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._6(f_Parameter, f_EffectedCount);
            }
        }

        public static string _7(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._7(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._7(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._7(f_Parameter, f_EffectedCount);
            }
        }

        public static string _8(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._8(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._8(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._8(f_Parameter, f_EffectedCount);
            }
        }

        public static string _9(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._9(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._9(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._9(f_Parameter, f_EffectedCount);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _10(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._10(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._10(f_Parameter);
            }
            else
            {
                return OracleAssembler._10(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _11(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._11(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._11(f_Parameter);
            }
            else
            {
                return OracleAssembler._11(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _12(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._12(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._12(f_Parameter);
            }
            else
            {
                return OracleAssembler._12(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _13(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._13(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._13(f_Parameter);
            }
            else
            {
                return OracleAssembler._13(f_Parameter);
            }
        }

        public static string _14(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._14(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._14(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._14(f_Parameter, f_EffectedCount);
            }
        }

        public static string _15(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._15(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._15(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._15(f_Parameter, f_EffectedCount);
            }
        }

        public static string _16(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._16(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._16(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._16(f_Parameter, f_EffectedCount);
            }
        }

        public static string _17(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._17(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._17(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._17(f_Parameter, f_EffectedCount);
            }
        }

        public static string _18(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._18(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._18(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._18(f_Parameter, f_EffectedCount);
            }
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _19(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._19(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._19(f_Parameter);
            }
            else
            {
                return OracleAssembler._19(f_Parameter);
            }
        }

        public static string _20(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._20(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._20(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._20(f_Parameter, f_EffectedCount);
            }
        }

        public static string _21(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._21(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._21(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._21(f_Parameter, f_EffectedCount);
            }
        }

        public static string _22(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._22(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._22(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._22(f_Parameter, f_EffectedCount);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _23(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._23(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._23(f_Parameter);
            }
            else
            {
                return OracleAssembler._23(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _24(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._24(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._24(f_Parameter);
            }
            else
            {
                return OracleAssembler._24(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _25(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._25(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._25(f_Parameter);
            }
            else
            {
                return OracleAssembler._25(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _26(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._26(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._26(f_Parameter);
            }
            else
            {
                return OracleAssembler._26(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _27(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._27(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._27(f_Parameter);
            }
            else
            {
                return OracleAssembler._27(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _28(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._28(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._28(f_Parameter);
            }
            else
            {
                return OracleAssembler._28(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _29(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._29(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._29(f_Parameter);
            }
            else
            {
                return OracleAssembler._29(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _30(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._30(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._30(f_Parameter);
            }
            else
            {
                return OracleAssembler._30(f_Parameter);
            }
        }

        public static string _31(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._31(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._31(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._31(f_Parameter, f_EffectedCount);
            }
        }

        public static string _32(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._32(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._32(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._32(f_Parameter, f_EffectedCount);
            }
        }

        public static string _33(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];


            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._33(f_Parameter, f_EffectedCount);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._33(f_Parameter, f_EffectedCount);
            }
            else
            {
                return OracleAssembler._33(f_Parameter, f_EffectedCount);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _34(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._34(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._34(f_Parameter);
            }
            else
            {
                return OracleAssembler._34(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _35(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._35(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._35(f_Parameter);
            }
            else
            {
                return OracleAssembler._35(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _36(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._36(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._36(f_Parameter);
            }
            else
            {
                return OracleAssembler._36(f_Parameter);
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _37(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler._37(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler._37(f_Parameter);
            }
            else
            {
                return OracleAssembler._37(f_Parameter);
            }
        }

        public static string Tran_0(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_0(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_0(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_0(f_Parameter);
            }
        }

        public static string Tran_1(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_1(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_1(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_1(f_Parameter);
            }
        }

        public static string Tran_2(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_2(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_2(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_2(f_Parameter);
            }
        }

        public static string Tran_3(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_3(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_3(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_3(f_Parameter);
            }
        }

        public static string Tran_4(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_4(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_4(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_4(f_Parameter);
            }
        }

        public static string Tran_5(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_5(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_5(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_5(f_Parameter);
            }
        }

        public static string Tran_6(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_6(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_6(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_6(f_Parameter);
            }
        }

        public static string Tran_7(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_7(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_7(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_7(f_Parameter);
            }
        }

        public static string Tran_8(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_8(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_8(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_8(f_Parameter);
            }
        }

        public static string Tran_9(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_9(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_9(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_9(f_Parameter);
            }
        }

        public static string Tran_10(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            string tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
            var tmpDBType = Root.GetInstance().KuTypeDic[tmpKuName];

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlserverAssembler.Tran_10(f_Parameter);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MysqlAssembler.Tran_10(f_Parameter);
            }
            else
            {
                return OracleAssembler.Tran_10(f_Parameter);
            }
        }
    }
}
