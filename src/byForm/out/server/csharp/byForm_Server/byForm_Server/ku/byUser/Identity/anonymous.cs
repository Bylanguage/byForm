using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byUser.Identity
{
    public class anonymous : byForm_Server.ku.by.Identity.Table
    {
        public anonymous()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Reference iUserID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iRegDt { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iIP { get; set; }
    }
}
