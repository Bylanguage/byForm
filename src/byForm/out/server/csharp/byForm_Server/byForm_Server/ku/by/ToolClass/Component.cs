using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class Component
    {
        public string ComponentName { get; private set; }

        public string SheetName { get; private set; }

        public Component(string f_ComponentName, string f_SheetName)
        {
            this.ComponentName = f_ComponentName;
            this.SheetName = f_SheetName;
        }
    }
}
