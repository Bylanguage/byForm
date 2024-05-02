using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class Config
    {
        public string Name { get; private set; }

        public string SheetName { get; private set; }

        public string FlowName { get; private set; }

        public Config(string f_ConfigName, string f_SheetName, string f_Flow)
        {
            this.Name = f_ConfigName;
            this.SheetName = f_SheetName;
            this.FlowName = f_Flow;
        }
    }
}
