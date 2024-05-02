using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byInterface
{
    public class byInterface : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byInterface()
        {
            this.Name = "byInterface";

            this.sqlLocation = new SqlExpression.SqlLocation();
        }
    }
}
