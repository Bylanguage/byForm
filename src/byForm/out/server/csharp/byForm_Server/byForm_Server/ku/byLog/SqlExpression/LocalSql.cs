using System;
using System.Collections.Generic;
using System.Linq;
using byForm_Server.ku.by.ToolClass.Sql;
using byForm_Server.ku.by.ToolClass;
using System.Text;
namespace byForm_Server.ku.byLog.SqlExpression
{
    public class LocalSql
    {
        public static int _0(object[] f_Params)
        {
            List<object> tmpParamList = new List<object>();
            List<AbstractTable> tmpTables = new List<AbstractTable>();
            ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList, "0");
            foreach (var item in f_Params)
            {
                tmpParamList.Add(item);
            }
            
            var tmpSqlResult = byForm_Server.ku.byLog.SqlExpression.sql._0(tmpParamsPackage);
            if (!string.IsNullOrEmpty(tmpSqlResult.OracleMethodName))
            {
                return OracleHelper.ExecuteRowsSql(tmpSqlResult.SqlCommandText, tmpSqlResult.ExecuteKuName(), tmpSqlResult.OracleMethodName);
            }

            return SqlHelper.ExecuteNonQuery(tmpSqlResult.SqlCommandText, tmpSqlResult.DecKuName());
        }
    }
}
