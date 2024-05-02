using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byUser.Identity
{
    public class userUpload : byForm_Server.ku.by.Identity.Table
    {
        public userUpload()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.ID iFileName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFileSize { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iSummery { get; set; }

        public byForm_Server.ku.by.Identity.Reference iUserID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iDT { get; set; }

        public byForm_Server.ku.byUser.Identity.user rUser { get; set; }
    }
}
