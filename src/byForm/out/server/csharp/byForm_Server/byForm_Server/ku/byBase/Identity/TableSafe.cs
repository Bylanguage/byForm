using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class TableSafe : byForm_Server.ku.by.Identity.Table
    {
        public TableSafe()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public bool confirmUserIsLogin()
        {
            return true;
        }
    }
}
