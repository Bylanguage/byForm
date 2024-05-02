using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser.Value
{
    public abstract class AbstractValue
    {
        internal abstract void GenerateCode(System.Text.StringBuilder f_Code, int f_Num);
    }
}
