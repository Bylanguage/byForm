using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Sql;
namespace byForm_Server.ku.byLog.SqlExpression
{
    public class OracleAssembler
    {
        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _0(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            StringBuilder tmpSql = new StringBuilder();

                tmpSql.AppendLine(@"CREATE OR REPLACE FUNCTION ""ORows$byLog$0""
    RETURN INT IS
    EFFECTCOUNT INT;
    BEGIN
    EFFECTCOUNT:= 0;");
            tmpSql.AppendLine(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.Oracle));
                return new SqlIDUResult(tmpSql.ToString(), "ORows$byLog$0", ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));

        }
    }
}
