using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class catalog : byForm_Server.ku.byBase.Identity.dic
    {
        public catalog()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public override byForm_Server.ku.by.Identity.Name iName { get; set; }

        public byForm_Server.ku.by.Identity.Reference iBillID { get; set; }

        public override byForm_Server.ku.by.Identity.Attribute iSummary { get; set; }

        public byForm_Server.ku.by.Object.Row getRow(byForm_Server.ku.by.Identity.Table f_table)
        {
            byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpList = this.load(null, null);
            foreach (byForm_Server.ku.by.Object.Row item in tmpList)
            {
                byForm_Server.ku.by.Object.Row tmpCatelogRow = (byForm_Server.ku.by.Object.Row)item;
                if (System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpCatelogRow, "iName").value) == (f_table.to as byForm_Server.ku.by.Object.table).name)
                {
                    return tmpCatelogRow;
                }
            }
            return null;
        }
    }
}
