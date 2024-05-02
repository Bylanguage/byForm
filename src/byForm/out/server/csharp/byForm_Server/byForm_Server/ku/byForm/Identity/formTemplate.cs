using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Identity
{
    public class formTemplate : byForm_Server.ku.by.Identity.Table
    {
        public formTemplate()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Name iName { get; set; }

        public byForm_Server.ku.by.Identity.Reference iFormID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iUserID { get; set; }

        public byForm_Server.ku.byForm.Identity.formSys rFormSys { get; set; }
    }
}
