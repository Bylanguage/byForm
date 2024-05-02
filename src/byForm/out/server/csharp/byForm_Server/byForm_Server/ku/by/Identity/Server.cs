using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Identity
{
    public class Server : byForm_Server.ku.by.Identity.Identity_
    {
        public Server()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public static byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.ServerSession> cacheSessionDic = new byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.ServerSession>();

        public static byForm_Server.ku.by.Identity.IServerDoor mIDoor;
    }
}
