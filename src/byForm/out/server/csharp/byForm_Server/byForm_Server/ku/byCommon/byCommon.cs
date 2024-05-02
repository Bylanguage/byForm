using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byCommon
{
    public class byCommon : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byCommon()
        {
            this.Name = "byCommon";

            this.sqlLocation = new SqlExpression.SqlLocation();
        }
    }
}
