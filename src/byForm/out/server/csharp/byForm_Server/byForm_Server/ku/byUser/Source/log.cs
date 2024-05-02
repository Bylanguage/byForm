using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byUser.Source
{
    public static class log
    {
        public static byForm_Server.ku.by.Object.datetime dt(byForm_Server.ku.by.Object.table f_Table)
        {
            return byForm_Server.ku.by.Object.datetime.getNow();
        }
    }
}
