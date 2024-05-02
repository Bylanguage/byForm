using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public abstract class AbstractTable
    {
        public abstract string Alias { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.JoinTable> JoinTables { get; set; }

        public abstract string TableAccess { get; }

        public abstract byForm_Server.ku.by.ToolClass.AbstractIdentityBase GetIdentity();

        public abstract byForm_Server.ku.by.ToolClass.IBaseDataSheet GetSource();

        public bool IsOuterTable { get; set; }

        public abstract byForm_Server.ku.by.ToolClass.Sql.AbstractTable Copy();

        public abstract string PrintSource();
    }
}
