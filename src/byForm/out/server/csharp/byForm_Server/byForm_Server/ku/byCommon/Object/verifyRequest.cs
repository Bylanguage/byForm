using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Object
{
    public class verifyRequest
    {
        public verifyRequest()
        {
        }

        public static bool isOk(string f_requestValue, int f_max)
        {
            if (f_requestValue == null || f_requestValue == "" || f_requestValue.IndexOf("'") > -1 || f_requestValue.IndexOf("\"") > -1 || f_requestValue.Length > f_max)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
