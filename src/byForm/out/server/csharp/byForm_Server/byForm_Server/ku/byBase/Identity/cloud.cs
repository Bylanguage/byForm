using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class cloud : byForm_Server.ku.byBase.Identity.TableSafe
    {
        public cloud()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.ID iName { get; set; }

        public byForm_Server.ku.by.Identity.Reference iUser { get; set; }
    }
}
