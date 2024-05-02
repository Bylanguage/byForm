using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Identity
{
    public class formData : byForm_Server.ku.by.Identity.Table
    {
        public formData()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Reference iFormID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iRowPK { get; set; }

        public byForm_Server.ku.by.Identity.Reference iFieldID { get; set; }

        public byForm_Server.ku.by.Identity.Reference iFieldName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iCellValue { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iUserID { get; set; }

        public byForm_Server.ku.byForm.Identity.formSys rFormSys { get; set; }

        public byForm_Server.ku.byForm.Identity.formData getformDataIdentity(byForm_Server.ku.by.Object.Row f_formField)
        {
            return this.getformDataIdentity_(System.Convert.ToInt32(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_formField, "iVDataValue").value));
        }

        public byForm_Server.ku.byForm.Identity.formData getformDataIdentity_(int f_Value)
        {
            if (f_Value <= 64)
            {
                return this.rFormSys.rVData64;
            }
            if (f_Value <= 256)
            {
                return this.rFormSys.rVData256;
            }
            if (f_Value <= 1024)
            {
                return this.rFormSys.rVData1024;
            }
            else
            {
                if (f_Value >= 4000)
                {
                    return this.rFormSys.rVData4000;
                }
                else
                {
                    return this.rFormSys.rVData4000;
                }
            }
        }
    }
}
