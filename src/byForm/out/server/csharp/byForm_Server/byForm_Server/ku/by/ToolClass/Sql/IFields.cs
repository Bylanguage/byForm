using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public interface IFields
    {
        int FieldCount { get; }

        System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> FieldList { get; set; }
    }
}
