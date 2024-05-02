using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class ParamsPackage
    {
        public string Path { get; private set; }

        public string MethodName { get; private set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> TableSourceList { get; private set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> UnSortedTableList { get; private set; }

        public System.Collections.Generic.List<object> ParameterList { get; private set; }

        public string No { get; private set; }

        public string DecKuName { get; private set; }

        public ParamsPackage(string f_Path, string f_MethodName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableList, System.Collections.Generic.List<object> f_ParamsList, string f_No)
        {
            Path = f_Path;
            MethodName = f_MethodName;
            TableSourceList = f_TableList;
            ParameterList = f_ParamsList;
            No = f_No;
            //TableSourceList = new List<AbstractTable>();
        }
    }
}
