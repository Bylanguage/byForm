using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class SetField
    {
        public SetField(byForm_Server.ku.by.ToolClass.Field f_Field, string f_Operator)
        {
            Field = f_Field;
            Operator= f_Operator;
        }

        public SetField(string f_ComponentName, string f_Operator)
        {
            ComponentName = f_ComponentName;
            Operator = f_Operator;
        }

        public string ComponentName { get; set; }

        public byForm_Server.ku.by.ToolClass.Field Field { get; set; }

        public string Operator { get; set; }
    }
}
