using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Identity
{
    public class formField : byForm_Server.ku.by.Identity.Table
    {
        public formField()
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

        public byForm_Server.ku.by.Identity.Attribute iFieldNO { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFieldName { get; set; }

        public byForm_Server.ku.by.Identity.ID iSummary { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFieldType { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFieldCtrl { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iSelectValue { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFieldMin { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFieldMax { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFieldReg { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFieldRegMsg { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFieldDefault { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iNotNull { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iOrder { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iVDataValue { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iUserID { get; set; }

        public byForm_Server.ku.byForm.Identity.formSys rFormSys { get; set; }

        public int addUpdate(byForm_Server.ku.by.Object.Row f_formField, byForm_Server.ku.by.Enum.Action action)
        {
            {
                int tmpResultValue = 0;
                switch (action)
                {
                    case byForm_Server.ku.by.Enum.Action.insert:
                        {
                            tmpResultValue = byForm_Server.ku.byForm.SqlExpression.LocalSql._8(new object[] { f_formField });
                            break;
                        }
                    case byForm_Server.ku.by.Enum.Action.update:
                        {
                            tmpResultValue = byForm_Server.ku.byForm.SqlExpression.LocalSql._9(new object[] { f_formField });
                            break;
                        }
                    case byForm_Server.ku.by.Enum.Action.delete:
                        {
                            break;
                        }
                }
                return tmpResultValue;
            }
        }

        public void delByFormId(string formID)
        {
            {
                byForm_Server.ku.byForm.SqlExpression.LocalSql._11(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { formID });
            }
        }
    }
}
