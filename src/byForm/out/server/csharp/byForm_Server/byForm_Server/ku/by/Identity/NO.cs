using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Identity
{
    public class NO : byForm_Server.ku.by.Identity.Field
    {
        public NO()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }
    }
}
