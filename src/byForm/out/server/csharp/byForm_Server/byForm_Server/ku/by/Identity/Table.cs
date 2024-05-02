using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Identity
{
    public class Table : byForm_Server.ku.by.Identity.Identity_, byForm_Server.ku.by.ToolClass.ITableSource
    {
        public Table()
        {
        }

        public byForm_Server.ku.by.ToolClass.Sql.SelectTable Source { get; set; }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public virtual byForm_Server.ku.by.Identity.ID iID { get; set; }

        public bool isReference(byForm_Server.ku.by.Identity.Table f_table)
        {
            byForm_Server.ku.by.Object.table thisTable = (this.to as byForm_Server.ku.by.Object.table);
            byForm_Server.ku.by.Object.table targetTable = (f_table.to as byForm_Server.ku.by.Object.table);
            if (thisTable == null || targetTable == null)
            {
                return false;
            }
            foreach (byForm_Server.ku.by.Object.field field in thisTable.fields)
            {
                if (field.refTable != null && field.refTable == targetTable)
                {
                    return true;
                }
            }
            foreach (byForm_Server.ku.by.Object.field field in targetTable.fields)
            {
                if (field.refTable != null && field.refTable == thisTable)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
