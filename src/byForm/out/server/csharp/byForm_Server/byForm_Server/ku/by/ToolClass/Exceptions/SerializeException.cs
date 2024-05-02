using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Exceptions
{
    public class SerializeException : byForm_Server.ku.by.ToolClass.Exceptions.TheKnownException
    {
        public SerializeException(string f_Message)
            : base(f_Message)
        {
        }
    }
}
