using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byBase
{
    public class byBase : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byBase()
        {
            this.Name = "byBase";

            this.sqlLocation = new SqlExpression.SqlLocation();
        }
    }
}
