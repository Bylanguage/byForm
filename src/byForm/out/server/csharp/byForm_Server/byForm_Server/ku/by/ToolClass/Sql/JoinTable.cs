using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class JoinTable
    {
        public byForm_Server.ku.by.ToolClass.Sql.AbstractTable JointTable { get; set; }

        public System.Text.StringBuilder Condition { get; set; }

        public string JoinMode { get; set; }

        public JoinTable(byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_JoinTable)
        {
            this.Condition = new StringBuilder();
            this.JointTable = f_JoinTable;
        }
    }
}
