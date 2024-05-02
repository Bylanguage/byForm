using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser
{
    public class Root
    {
        public static byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject CreateObj(string f_Content)
        {
            return new Value.JsonObject(f_Content);
        }
    }
}
