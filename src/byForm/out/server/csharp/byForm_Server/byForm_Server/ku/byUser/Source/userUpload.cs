using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byUser.Source
{
    public static class userUpload
    {
        public static int fileSize(byForm_Server.ku.by.Object.table f_Table)
        {
            return byForm_Server.ku.by.Object.system.autoID(f_Table, 1);
        }
    }
}
