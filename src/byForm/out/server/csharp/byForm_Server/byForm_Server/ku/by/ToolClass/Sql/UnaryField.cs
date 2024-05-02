using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class UnaryField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField
    {
        public override string Alias { get; set; }

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

                return this.Operator + this.OperatorField.FieldAccess;
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                if (this.Operator == null)
                {
                    ThrowHelper.ThrowUnKnownException(ErrorInfo.OperatorIsNull);
                }

                if (this.OperatorField == null)
                {
                    ThrowHelper.ThrowUnKnownException(ErrorInfo.OperatorFieldIsNull);
                }

                StringBuilder tmpReturnValue = new StringBuilder();
                tmpReturnValue.Append(this.Operator);
                tmpReturnValue.Append(this.OperatorField.FieldAccess);
                if (this.Alias != null)
                {
                    tmpReturnValue.Append(" " + this.Alias);
                }
                return tmpReturnValue.ToString();
            }
        }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField OperatorField { get; set; }

        public string Operator { get; set; }

        public UnaryField(string f_Operator, byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_Field)
        {
            this.Operator = f_Operator;
            this.OperatorField = f_Field;
            this.FieldType = f_Field.FieldType;
        }
    }
}
