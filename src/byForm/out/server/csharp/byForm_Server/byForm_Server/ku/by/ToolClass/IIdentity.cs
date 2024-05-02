using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public interface IIdentity
    {
        byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }
    }
}
