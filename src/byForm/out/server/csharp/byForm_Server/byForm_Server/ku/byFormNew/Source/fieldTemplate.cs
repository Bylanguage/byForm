using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byFormNew.Source
{
    public static class fieldTemplate
    {
        public static byForm_Server.ku.by.Object.datetime createDt(byForm_Server.ku.by.Object.table f_Table)
        {
            return byForm_Server.ku.by.Object.datetime.getNow();
        }
    }
}
