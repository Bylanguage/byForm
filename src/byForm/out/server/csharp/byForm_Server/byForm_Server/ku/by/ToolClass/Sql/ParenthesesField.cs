using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class ParenthesesField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField
    {
        public override string Alias { get; set; }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public override string FieldAccess
        {
            get
            {
                if (this.FieldTable != null)
                {
                    if (this.FieldTable.Alias == null)
                    {
                        ThrowHelper.ThrowUnKnownException(ErrorInfo.ColumnWithoutAlias);
                    }

                    if (this.Alias == null)
                    {
                        ThrowHelper.ThrowUnKnownException(ErrorInfo.ColumnWithoutAlias);
                    }

                    return this.FieldTable.Alias + "." + this.Alias;
                }

                return "(" + this.Value.FieldAccess + ")";
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                StringBuilder tmpReturnValue = new StringBuilder();
                tmpReturnValue.Append("(");
                tmpReturnValue.Append(this.Value.FieldAccess);
                tmpReturnValue.Append(")");
                if (this.Alias != null)
                {
                    tmpReturnValue.Append(" " + this.Alias);
                }
                return tmpReturnValue.ToString();
            }
        }

        public byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField Value { get; set; }

        public ParenthesesField(byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_Value)
        {
            this.Value = f_Value;
            this.FieldType = f_Value.FieldType;
        }
    }
}
