using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Exceptions
{
    public class TheKnownException : System.Exception
    {
        public TheKnownException(string f_Message)
            : base(f_Message)
        {
        }
    }
}
