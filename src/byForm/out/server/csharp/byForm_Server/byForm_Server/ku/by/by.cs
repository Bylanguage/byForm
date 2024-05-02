using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by
{
    public class by : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public by()
        {
            this.Name = "by";
            this.sqlLocation = new ku.by.SqlExpression.SqlLocation();
        }
    }
}
