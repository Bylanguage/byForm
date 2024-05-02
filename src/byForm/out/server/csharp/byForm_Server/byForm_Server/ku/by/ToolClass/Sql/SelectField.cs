using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class SelectField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField
    {
        public override string Alias { get; set; }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public override string FieldAccess
        {
            get
            {
                if (this.FieldTable.Alias == null)
                {
                    ThrowHelper.ThrowUnKnownException(ErrorInfo.SelectTableNeedAlias);
                }

                StringBuilder tmpValue = new StringBuilder();

                var tmpKuName = FieldTable.GetSource().KuName;
                DBTypeEnum tmpDBType;

                if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpKuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpKuName));
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpValue.Append("[" + this.FieldTable.Alias + "]");
                    tmpValue.Append(".");
                    
                    if (this.Alias != null)
                    {
                        tmpValue.Append("[" + this.Alias + "]");
                    }
                    else
                    {
                        tmpValue.Append("[" + this.name + "]");
                    }
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpValue.Append("`" + this.FieldTable.Alias + "`");
                    tmpValue.Append(".");

                    if (this.Alias != null)
                    {
                        tmpValue.Append("`" + this.Alias + "`");
                    }
                    else
                    {
                        tmpValue.Append("`" + this.name + "`");
                    }
                }
                else
                {
                    tmpValue.Append("\"" + this.FieldTable.Alias + "\"");
                    tmpValue.Append(".");

                    if (this.Alias != null)
                    {
                        tmpValue.Append("\"" + this.Alias + "\"");
                    }
                    else
                    {
                        tmpValue.Append("\"" + this.name + "\"");
                    }
                }

                return tmpValue.ToString();
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                if (this.FieldTable.Alias == null)
                {
                    ThrowHelper.ThrowUnKnownException(ErrorInfo.SelectTableNeedAlias);
                }

                StringBuilder tmpValue = new StringBuilder();
                var tmpKuName = FieldTable.GetSource().KuName;
                DBTypeEnum tmpDBType;

                if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpKuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpKuName));
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpValue.Append("[" + this.FieldTable.Alias + "]");
                    tmpValue.Append(".");
                    tmpValue.Append("[" + this.name + "]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpValue.Append("`" + this.FieldTable.Alias + "`");
                    tmpValue.Append(".");
                    tmpValue.Append("`" + this.name + "`");
                }
                else
                {
                    tmpValue.Append("\"" + this.FieldTable.Alias + "\"");
                    tmpValue.Append(".");
                    tmpValue.Append("\"" + this.name + "\"");
                }

                if (this.Alias != null)
                {
                    string tmpAlias;

                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpAlias = "[" + this.Alias + "]";
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpAlias = "`" + this.Alias + "`";
                    }
                    else
                    {
                        tmpAlias = "\"" + this.Alias + "\"";
                    }

                    tmpValue.Append(" " + tmpAlias);
                }
                return tmpValue.ToString();
            }
        }

        public readonly string name;

        public readonly byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField actualField;

        public SelectField(string f_SelectName, byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_Field, byForm_Server.ku.by.ToolClass.Sql.SelectTable fieldTable)
        {
            FieldTable = fieldTable;
            name = f_SelectName;
            actualField = f_Field;
            this.FieldType = f_Field.FieldType;
        }
    }
}
