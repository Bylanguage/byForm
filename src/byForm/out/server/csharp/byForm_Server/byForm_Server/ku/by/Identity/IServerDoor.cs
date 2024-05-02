using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Identity
{
    public interface IServerDoor
    {
        byForm_Server.ku.by.Object.Result comeIn(byForm_Server.ku.by.Object.ServerSession f_session);
    }
}
