using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byForm
{
    public class byForm : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byForm()
        {
            this.Name = "byForm";

            this.sqlLocation = new SqlExpression.SqlLocation();
        }
    }
}
