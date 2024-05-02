using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class ExecObj
    {
        public ExecObj()
        {
            this.SelectTables = new List<Sql.SelectTable>();
        }

        public string SqlCommandText { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.SelectTable> SelectTables { get; set; }
    }
}
