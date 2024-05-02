using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class UpdateSetValue
    {
        public byForm_Server.ku.by.ToolClass.Field SetField { get; private set; }

        public object Value { get; private set; }

        public UpdateSetValue(byForm_Server.ku.by.ToolClass.Field f_Field, object f_Value, string f_Operator)
        {
            this.SetField = f_Field;
            this.Value = f_Value;
            this.Operator = f_Operator;
        }

        public string Operator { get; private set; }
    }
}
