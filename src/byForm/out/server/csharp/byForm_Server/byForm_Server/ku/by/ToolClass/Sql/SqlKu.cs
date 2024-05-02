using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class SqlKu
    {
        public SqlKu(string f_KuName, string f_RealKuName)
        {
            KuName = f_KuName;
            RealKuName = f_RealKuName;
        }

        public string KuName { get; set; }

        public string RealKuName { get; set; }
    }
}
