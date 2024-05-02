using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class byObject : byForm_Server.ku.by.ToolClass.IIdentity
    {
        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            if (Identity == null)
            {
                return "by.object.Object";
            }
            else
            {
                return "by.object.Object~" + this.Identity.ToString();
            }
        }
    }
}
