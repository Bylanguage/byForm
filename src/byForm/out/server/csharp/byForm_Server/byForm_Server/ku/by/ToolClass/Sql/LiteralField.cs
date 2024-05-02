using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class LiteralField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField
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

                return this.Literal == null ? "NULL" : this.Literal;
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                StringBuilder tmpReturnValue = new StringBuilder();
                if (this.Literal == null)
                {
                    tmpReturnValue.Append("NULL");
                }
                else
                {
                    tmpReturnValue.Append(this.Literal);
                }
                if (this.Alias != null)
                {
                    tmpReturnValue.Append(" " + this.Alias);
                }
                return tmpReturnValue.ToString();
            }
        }

        public string Literal { get; set; }

        public LiteralField(string f_Literal, byForm_Server.ku.DataTypeEnum f_Type)
        {
            this.Literal = f_Literal;
            this.FieldType = f_Type;
        }

        public LiteralField(long f_Literal, byForm_Server.ku.DataTypeEnum f_Type)
        {
            this.Literal = f_Literal.ToString();
            this.FieldType = f_Type;
        }

        public LiteralField(double f_Literal, byForm_Server.ku.DataTypeEnum f_Type)
        {
            this.Literal = f_Literal.ToString();
            this.FieldType = f_Type;
        }

        public LiteralField(float f_Literal, byForm_Server.ku.DataTypeEnum f_Type)
        {
            this.Literal = f_Literal.ToString();
            this.FieldType = f_Type;
        }

        public LiteralField(decimal f_Literal, byForm_Server.ku.DataTypeEnum f_Type)
        {
            this.Literal = f_Literal.ToString();
            this.FieldType = f_Type;
        }

        public LiteralField(bool f_Literal, byForm_Server.ku.DataTypeEnum f_Type)
        {
            this.Literal = f_Literal ? "1" : "0";
            this.FieldType = f_Type;
        }
    }
}
