using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byFormNew.Identity
{
    public class ServerStartup : byForm_Server.ku.by.Identity.Role
    {
        public ServerStartup()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public static void main(string[] args)
        {
            byForm_Server.ku.Root.GetNewIdentity<byForm_Server.ku.byUser.Identity.user>("byUser", "New_user").pIsGetServerUserRow = false;
            byForm_Server.ku.Root.GetNewIdentity<byForm_Server.ku.byUser.Identity.user>("byUser", "New_user").pConfigSMSCode = false;
            byForm_Server.ku.Root.GetNewIdentity<byForm_Server.ku.byUser.Identity.user>("byUser", "New_user").rLog.pLogMode = byForm_Server.ku.byLog.Enum.logMode.file;
            byForm_Server.ku.Root.GetNewIdentity<byForm_Server.ku.byUser.Identity.userAdmin>("byUser", "New_userAdmin").initInsertAdmin();
        }
    }
}
