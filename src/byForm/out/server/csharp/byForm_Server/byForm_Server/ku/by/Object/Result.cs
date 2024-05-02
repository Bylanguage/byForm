using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class Result : byForm_Server.ku.by.ToolClass.IIdentity
    {
        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }

        public Result()
        {
        }

        public string info { get; set; }

        public bool isOk { get; set; }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
