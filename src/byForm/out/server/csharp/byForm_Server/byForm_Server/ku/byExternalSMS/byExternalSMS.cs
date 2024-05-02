using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byExternalSMS
{
    public class byExternalSMS : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byExternalSMS()
        {
            this.Name = "byExternalSMS";

            this.sqlLocation = new SqlExpression.SqlLocation();
        }
    }
}
