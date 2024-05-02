using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class QueryData : byForm_Server.ku.by.ToolClass.IIdentity
    {
        public QueryData()
        {
        }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }

        public byForm_Server.ku.by.ToolClass.Sql.QueryDataParameter _QueryDataParameter { get; set; }

        public byForm_Server.ku.by.Object.table table { get; set; }

        public object[] values { get; set; }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
