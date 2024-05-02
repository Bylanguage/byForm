using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class QueryDataParameter
    {
        public System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Source, object> ValueDic { get; private set; }

        public QueryDataParameter(System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Source, object> f_ValueDic)
        {
            this.ValueDic = f_ValueDic;
        }
    }
}
