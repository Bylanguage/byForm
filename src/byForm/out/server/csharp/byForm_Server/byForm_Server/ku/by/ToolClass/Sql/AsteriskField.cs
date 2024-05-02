using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class AsteriskField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField, byForm_Server.ku.by.ToolClass.Sql.IFields
    {
        public override string Alias
        {
            get
            {
                return null;
            }
            set
            {
                throw new Exception("无法设置别名");
            }
        }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public override string FieldAccess
        {
            get
            {
                return "*";
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                StringBuilder tmpValue = new StringBuilder();

                foreach (var item in this.FieldList)
                {
                    if (tmpValue.Length != 0)
                    {
                        tmpValue.Append(", ");
                    }

                    if (item.FieldTable is Table)
                    {
                        tmpValue.Append(item.SelectItemDeclare);
                    }
                    else
                    {
                        tmpValue.Append(item.FieldAccess);
                    }
                }

                return tmpValue.ToString();
            }
        }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> FieldList { get; set; }

        public int FieldCount
        {
            get
            {
                int tmpCount = 0;

                foreach (var item in this.FieldList)
                {
                    if (item is IFields)
                    {
                        throw ThrowHelper.ThrowUnKnownException("字段填充错误");
                    }
                    else
                    {
                        tmpCount++;
                    }
                }
                return tmpCount;
            }
        }

        public AsteriskField(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_FieldList, byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table)
        {
            this.FieldList = f_FieldList;
            this.FieldTable = f_Table;
        }

        public AsteriskField()
        {
            this.FieldList = null;
            this.FieldTable = null;
        }
    }
}
