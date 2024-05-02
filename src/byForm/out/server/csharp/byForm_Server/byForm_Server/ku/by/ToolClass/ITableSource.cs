using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public interface ITableSource
    {
        byForm_Server.ku.by.ToolClass.Sql.SelectTable Source { get; set; }
    }
}
