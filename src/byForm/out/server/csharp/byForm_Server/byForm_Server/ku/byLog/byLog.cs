using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byLog
{
    public class byLog : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byLog()
        {
            this.Name = "byLog";

            this.sqlLocation = new SqlExpression.SqlLocation();
        }
    }
}
