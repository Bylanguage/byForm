using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Identity
{
    public class Reference : byForm_Server.ku.by.Identity.Field
    {
        public Reference()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public byForm_Server.ku.by.Identity.Table host()
        {
            byForm_Server.ku.by.Object.field thisField = (this.to as byForm_Server.ku.by.Object.field);
            if (thisField == null)
            {
                return null;
            }
            byForm_Server.ku.by.Object.table refTable = thisField.refTable as byForm_Server.ku.by.Object.table;
            return byForm_Server.ku.by.ToolClass.ToolFunction.GetIdentityOfTildeValue<byForm_Server.ku.by.Identity.Table>(refTable == null ? null : refTable);
        }

        public bool isReference(byForm_Server.ku.by.Identity.Table f_table)
        {
            byForm_Server.ku.by.Object.field thisField = (this.to as byForm_Server.ku.by.Object.field);
            byForm_Server.ku.by.Object.table targetTable = (f_table.to as byForm_Server.ku.by.Object.table);
            if (thisField == null || targetTable == null)
            {
                return false;
            }
            byForm_Server.ku.by.Object.field thisFieldRefField = thisField.refField;
            foreach (byForm_Server.ku.by.Object.field field in targetTable.fields)
            {
                if (thisFieldRefField == field || field.refField == thisField)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
