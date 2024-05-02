using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Identity
{
    public class relatedField : byForm_Server.ku.by.Identity.Identity_
    {
        public relatedField()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public static string getFieldValue(byForm_Server.ku.by.Object.Row f_row, string f_fieldNmae)
        {
            foreach (byForm_Server.ku.by.Object.Cell item in f_row.Cells)
            {
                if (item.field.name == f_fieldNmae)
                {
                    return item.value == null ? null : item.value.ToString();
                }
            }
            return null;
        }

        public static string getFieldSummery(byForm_Server.ku.by.Object.Row f_row, string f_fieldNmae)
        {
            foreach (byForm_Server.ku.by.Object.Cell item in f_row.Cells)
            {
                if (item.field.name == f_fieldNmae)
                {
                    return item.value == null ? null : item.field.summary;
                }
            }
            return null;
        }
    }
}
