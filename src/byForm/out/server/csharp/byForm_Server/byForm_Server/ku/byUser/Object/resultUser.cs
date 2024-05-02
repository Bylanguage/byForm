using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byUser.Object
{
    public class resultUser : byForm_Server.ku.by.Object.Result
    {
        public resultUser()
        {
        }

        public byForm_Server.ku.byUser.Orm.Orm0 loginRow { get; set; }

        public byForm_Server.ku.by.Object.Row adminRow { get; set; }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
