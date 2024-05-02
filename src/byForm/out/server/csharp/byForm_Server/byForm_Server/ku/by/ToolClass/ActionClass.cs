using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class ActionClass
    {
        public System.Type ActionType { get; private set; }

        public string ActionNum { get; private set; }

        public byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass ParameterList { get; private set; }

        public ActionClass(System.Type f_ActionType, string f_ActionNum, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_ParamsList)
        {
            this.ActionType = f_ActionType;
            this.ActionNum = f_ActionNum;
            this.ParameterList = f_ParamsList;
        }
    }
}
