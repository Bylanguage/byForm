using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser.Value
{
    public class BoolValue : byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue
    {
        public BoolValue(string f_Value)
        {
            bool.TryParse(f_Value, out this.value);
        }

        public BoolValue(bool f_Value)
        {
            this.value = f_Value;
        }

        public BoolValue()
        {
        }

        public bool Value
        {
            get
            {
                return this.value;
            }
        }

        internal bool value;

        public override string ToString()
        {
            return value.ToString();
        }

        internal override void GenerateCode(System.Text.StringBuilder f_Code, int f_Tab)
        {
            f_Code.Append(this.value.ToString().ToLower());
        }
    }
}
