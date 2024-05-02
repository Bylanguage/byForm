using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class OrderByField
    {
        public string OField { get; private set; }

        public bool IsDesc { get; private set; }

        public byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField SourceField { get; private set; }

        public OrderByField(string f_Field, bool f_IsDesc, byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_SourceField)
        {
            this.OField = f_Field;
            this.IsDesc = f_IsDesc;
            this.SourceField = f_SourceField;
        }

        public OrderByField(string f_Field, bool f_IsDesc)
        {
            this.OField = f_Field;
            this.IsDesc = f_IsDesc;
            this.SourceField = null;
        }
    }
}
