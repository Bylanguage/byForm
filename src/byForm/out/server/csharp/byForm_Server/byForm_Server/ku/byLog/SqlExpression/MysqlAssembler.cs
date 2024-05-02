using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Sql;
namespace byForm_Server.ku.byLog.SqlExpression
{
    public class MysqlAssembler
    {
        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _0(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            return new SqlIDUResult(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.Mysql), null, ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));
        }
    }
}
