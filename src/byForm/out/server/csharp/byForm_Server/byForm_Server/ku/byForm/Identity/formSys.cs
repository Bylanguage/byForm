using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Identity
{
    public class formSys : byForm_Server.ku.by.Identity.Sys
    {
        public formSys()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public byForm_Server.ku.byForm.Identity.form rForm { get; set; }

        public byForm_Server.ku.byForm.Identity.formField rFormField { get; set; }

        public byForm_Server.ku.byForm.Identity.formData rFormData { get; set; }

        public byForm_Server.ku.byForm.Identity.fieldTemplate rFieldTemplate { get; set; }

        public byForm_Server.ku.byForm.Identity.formTemplate rFormTemplate { get; set; }

        public byForm_Server.ku.byForm.Identity.formData rVData64 { get; set; }

        public byForm_Server.ku.byForm.Identity.formData rVData256 { get; set; }

        public byForm_Server.ku.byForm.Identity.formData rVData1024 { get; set; }

        public byForm_Server.ku.byForm.Identity.formData rVData4000 { get; set; }

        public byForm_Server.ku.byUser.Identity.user rUser { get; set; }
    }
}
