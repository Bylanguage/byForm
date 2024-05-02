using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Identity
{
    public class fieldTemplate : byForm_Server.ku.byBase.Identity.dic
    {
        public fieldTemplate()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> pList { get; set; }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public override byForm_Server.ku.by.Identity.Name iName { get; set; }

        public override byForm_Server.ku.by.Identity.Attribute iSummary { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iCtrType { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iIco { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iMin { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iMax { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iDefault { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iReg { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iRegMsg { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iCreateDt { get; set; }

        public byForm_Server.ku.byForm.Identity.formSys rFormSys { get; set; }

        public byForm_Server.ku.byUser.Identity.user rUser { get; set; }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> getList()
        {
            {
                if (this.pList == null)
                {
                    this.pList = (byForm_Server.ku.byForm.SqlExpression.LocalSql._37(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { })).rows;
                }
                return this.pList;
            }
        }

        public byForm_Server.ku.by.Object.Row getFieldTemplate(string id)
        {
            byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> templateList = this.getList();
            foreach (byForm_Server.ku.by.Object.Row templateRow in templateList)
            {
                if (System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(templateRow, "iID").value) == id)
                {
                    return templateRow;
                }
            }
            throw new System.Exception(byForm_Server.ku.byForm.Object.TextHelper.invalidFieldTemplateID);
        }
    }
}
