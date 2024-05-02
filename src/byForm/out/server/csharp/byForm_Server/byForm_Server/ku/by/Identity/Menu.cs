using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Identity
{
    public class Menu : byForm_Server.ku.by.Identity.Table
    {
        public Menu()
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

        public byForm_Server.ku.by.Identity.Attribute iIco { get; set; }

        public byForm_Server.ku.by.Identity.Reference iParent { get; set; }

        public byForm_Server.ku.by.Identity.Reference iKuName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iDialogManagerMode { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iNewIdentityName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iDialogName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iManagerName { get; set; }

        public byForm_Server.ku.by.Identity.Field iSingleton { get; set; }
    }
}
