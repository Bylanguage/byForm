using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.by.ToolClass
{
    public static class SqlHelper
    {
        public static void TestConnetion()
        {
            try
            {
                string tmpConnect0 = ConfigurationManager.ConnectionStrings["byFormNew"].ConnectionString;
                string tmpConnect1 = ConfigurationManager.ConnectionStrings["byUser"].ConnectionString;
            }
            catch
            {
                throw new Exception(@"数据库连接字符串获取错误。
原因：可能手动修改过 Web.config 文件，但转译时没有勾选拜语言 IDE【菜单】-【生成】-【项目设置】-【服务端(C#)】-【覆盖 Web.config】。
解决方案：手动去 Web.config 文件中修改数据库连接信息；或者勾选拜语言 IDE【菜单】-【生成】-【项目设置】-【服务端(C#)】-【覆盖 Web.config】，并重新转译。");
            }

            SqlServerHelper.TestConnetion();
            MySqlHelper.TestConnetion();
            OracleHelper.TestConnetion();

        }

        public static object Inquiry(string f_Sql, string f_KuName)
        {
            string tmpRealKuName;

            if (!Root.GetInstance().KuNameReflectionDic.TryGetValue(f_KuName, out tmpRealKuName))
            {
                tmpRealKuName = f_KuName;
            }

            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_KuName));
            }

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlServerHelper.Inquiry(f_Sql, tmpRealKuName);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MySqlHelper.Inquiry(f_Sql, tmpRealKuName);
            }
            else
            {
                return OracleHelper.Inquiry(f_Sql, tmpRealKuName);
            }
        }

        public static int ExecuteNonQuery(string f_Sql, string f_KuName)
        {
            string tmpRealName;

            if (! Root.GetInstance().KuNameReflectionDic.TryGetValue(f_KuName, out tmpRealName))
            {
                tmpRealName = f_KuName;
            }

            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_KuName));
            }

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlServerHelper.ExecuteNonQuery(f_Sql, tmpRealName);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MySqlHelper.ExecuteNonQuery(f_Sql, tmpRealName);
            }
            else
            {
                return OracleHelper.ExecuteNonQuery(f_Sql, tmpRealName);
            }
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> SelectReturnRows(string f_Sql, string f_KuName, string f_RealKuName, byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, string f_SqlNo)
        {
            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_KuName));
            }

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlServerHelper.SelectReturnRows(f_Sql, f_RealKuName, f_SelectTable, f_SqlNo);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MySqlHelper.SelectReturnRows(f_Sql, f_RealKuName, f_SelectTable, f_SqlNo);
            }
            else
            {
                return OracleHelper.SelectReturnRows(f_Sql, f_RealKuName, f_SelectTable, f_SqlNo);
            }
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>> ExecQueryReturnRowsCollection(string f_Sql, string f_KuName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.SelectTable> f_SelectTables)
        {
            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_KuName));
            }

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                return SqlServerHelper.ExecQueryReturnRowsCollection(f_Sql, f_KuName, f_SelectTables);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                return MySqlHelper.ExecQueryReturnRowsCollection(f_Sql, f_KuName, f_SelectTables);
            }
            else
            {
                return OracleHelper.ExecQueryReturnRowsCollection(f_Sql, f_KuName, f_SelectTables);
            }
        }

        public static void ExecuteTran(string f_Sql, string f_KuName, string f_TranName)
        {
            string tmpRealKuName;

            if (!Root.GetInstance().KuNameReflectionDic.TryGetValue(f_KuName, out tmpRealKuName))
            {
                tmpRealKuName = f_KuName;
            }

            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_KuName));
            }

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                SqlServerHelper.ExecuteTran(f_Sql, tmpRealKuName);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                MySqlHelper.ExecuteTran(f_Sql, tmpRealKuName, f_TranName);
            }
            else
            {
                OracleHelper.ExecuteTran(f_Sql, tmpRealKuName);
            }
        }

        public static void ExecuteExpression(string f_DecKuName, string f_ExecKuName, byForm_Server.ku.by.ToolClass.IExecItem[] f_IExecItems)
        {
            DBTypeEnum tmpDBType;

            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_DecKuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_DecKuName));
            }

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                SqlServerHelper.ExecuteExpression(f_ExecKuName, f_IExecItems);
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                MySqlHelper.ExecuteExpression(f_ExecKuName, f_IExecItems);
            }
            else
            {
                OracleHelper.ExecuteExpression(f_ExecKuName, f_IExecItems);
            }
        }
    }
}
