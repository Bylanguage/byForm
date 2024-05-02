using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public interface IExecItem
    {
        string SqlCommandText { get; }

        string ExecuteKuName();

        string DecKuName();

        void FillDateset(System.Data.DataTable f_DataTable);
    }
}
