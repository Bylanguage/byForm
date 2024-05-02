using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class detail : byForm_Server.ku.byBase.Identity.TableSafe
    {
        public detail()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> load(byForm_Server.ku.by.Object.Row f_row)
        {
            {
                return (byForm_Server.ku.byBase.SqlExpression.LocalSql._30(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_row })).rows;
            }
        }
    }
}
