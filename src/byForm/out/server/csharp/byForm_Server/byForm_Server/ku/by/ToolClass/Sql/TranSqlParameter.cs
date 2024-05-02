using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class TranSqlParameter
    {
        public System.Collections.Generic.List<string> SourceList { get; private set; }

        public System.Collections.Generic.List<object> ParameterList { get; private set; }

        public TranSqlParameter(System.Collections.Generic.List<string> f_Source, System.Collections.Generic.List<object> f_Parameter)
        {
            this.SourceList = f_Source;
            this.ParameterList = f_Parameter;
        }
    }
}
