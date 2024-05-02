using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class TranLocalVariable
    {
        public string LocalName { get; private set; }

        public TranLocalVariable(string f_Name)
        {
            this.LocalName = f_Name;
        }

        public override string ToString()
        {
            return this.LocalName;
        }
    }
}
