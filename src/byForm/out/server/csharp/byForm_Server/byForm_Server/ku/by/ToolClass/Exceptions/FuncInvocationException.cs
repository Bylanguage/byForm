using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Exceptions
{
    public class FuncInvocationException : byForm_Server.ku.by.ToolClass.Exceptions.TheKnownException
    {
        public FuncInvocationException(string f_Message)
            : base(f_Message)
        {
        }
    }
}
