using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byExternal
{
    public class byExternal : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byExternal()
        {
            this.Name = "byExternal";

            this.sqlLocation = new SqlExpression.SqlLocation();
        }
    }
}
