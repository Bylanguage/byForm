using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Sql;
namespace byForm_Server.ku.byLog.SqlExpression
{
    public class sql
    {
        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _0(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
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
    }
}
