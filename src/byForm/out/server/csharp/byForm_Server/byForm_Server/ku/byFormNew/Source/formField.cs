using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byFormNew.Source
{
    public static class formField
    {
        public static int order(byForm_Server.ku.by.Object.table f_Table)
        {
            return byForm_Server.ku.by.Object.system.autoID(f_Table, 1);
        }
    }
}
