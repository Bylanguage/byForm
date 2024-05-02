using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser.Value
{
    public class NullValue : byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue
    {
        public NullValue()
        {
        }

        internal override void GenerateCode(System.Text.StringBuilder f_Code, int f_Tab)
        {
            f_Code.Append("null");
        }
    }
}
