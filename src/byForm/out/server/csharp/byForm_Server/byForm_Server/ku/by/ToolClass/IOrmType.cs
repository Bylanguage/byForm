using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public interface IOrmType
    {
        System.Type Type { get; set; }

        System.Collections.Generic.Dictionary<string, System.Type> IdentityDec { get; set; }

        System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> OrmFields { get; set; }
    }
}
