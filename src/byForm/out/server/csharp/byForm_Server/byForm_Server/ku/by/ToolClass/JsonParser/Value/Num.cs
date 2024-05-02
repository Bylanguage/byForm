using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser.Value
{
    public class Num : byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue
    {
        public Num(string f_Value)
        {
            if (f_Value.Contains("."))
            {
                this.isInt = false;
            }
            else
            {
                this.isInt = true;
            }

            if (this.isInt)
            {
                long tmpLong;
                if(!long.TryParse(f_Value,out tmpLong))
                {
                    throw new Exception(string.Format("{0} 不是数字类型", f_Value));
                }
            }
            else
            {
                double tmpDouble;
                if (!double.TryParse(f_Value, out tmpDouble))
                {
                    throw new Exception(string.Format("{0} 不是数字类型", f_Value));
                }
            }

            this.value = f_Value;
        }

        public string Value
        {
            get
            {
                return this.value;
            }
        }

        internal string value;

        public bool IsInt
        {
            get
            {
                return this.isInt;
            }
        }

        internal bool isInt;

        public override string ToString()
        {
            return this.value.ToString();
        }

        internal override void GenerateCode(System.Text.StringBuilder f_Code, int f_Tab)
        {
            f_Code.Append(this.value);
        }
    }
}
