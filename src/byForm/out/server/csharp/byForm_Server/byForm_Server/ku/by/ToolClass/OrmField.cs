using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class OrmField
    {
        public OrmField(string f_Name, int f_OrmIndex)
        {
            this.Name = f_Name;
            this.OrmIndex = f_OrmIndex;
        }

        public string Name { get; set; }

        public int OrmIndex { get; set; }
    }
}
