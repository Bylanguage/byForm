using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class popupTable : byForm_Server.ku.byBase.Identity.TableSafe
    {
        public popupTable()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> popupLoad(byForm_Server.ku.by.Object.QueryData f_QueryData)
        {
            {
                byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpGridRows = new byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>();
                tmpGridRows = (byForm_Server.ku.byBase.SqlExpression.LocalSql._0(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_QueryData })).rows;
                return tmpGridRows;
            }
        }
    }
}
