using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class TranParamsPackage
    {
        public string KuName { get; private set; }

        public string MethodName { get; private set; }

        public string Path { get; private set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.ParamsPackage> Paramters { get; private set; }

        public string ExecuteKuName { get; set; }

        public System.Collections.Generic.List<object> Values { get; private set; }

        public TranParamsPackage(string f_KuName, string f_Path, string f_MethodName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.ParamsPackage> f_Parameters, System.Collections.Generic.List<object> f_Values)
        {
            this.KuName = f_KuName;
            this.MethodName = f_MethodName;
            this.Path = f_Path;
            this.Paramters = f_Parameters;
            this.Values = f_Values;
        }
    }
}
