using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class TableField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField
    {
        private bool IsPlusField = false;

        public byForm_Server.ku.by.ToolClass.Field SelectedField { get; private set; }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public override string Alias
        {
            get
            {
                return alias;
            }
            set
            {
                alias = value;
                if (alias != null && !IsPlusField)
                {
                    SelectedField = SelectedField.CopyWithoutSheet();
                }
            }
        }

        private string alias;

        public override string FieldAccess
        {
            get
            {
                if (this.FieldTable == null)
                {
                    ThrowHelper.ThrowUnKnownException("系统错误->空的字段的表源");
                }
                StringBuilder tmpReturnValue = new StringBuilder();
                var tmpTable = this.FieldTable as Table;
                DBTypeEnum tmpDBType;

                if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpTable.KuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpTable.KuName));
                }

                tmpReturnValue.Append(this.FieldTable.TableAccess);
                tmpReturnValue.Append(".");

                if (this.Alias != null)
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpReturnValue.Append("[" + this.Alias + "]");
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpReturnValue.Append("`" + this.Alias + "`");
                    }
                    else
                    {
                        tmpReturnValue.Append("\"" + this.Alias + "\"");
                    }
                }
                else
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpReturnValue.Append("[");
                        tmpReturnValue.Append(this.SelectedField.Name);
                        tmpReturnValue.Append("]");
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpReturnValue.Append("`");
                        tmpReturnValue.Append(this.SelectedField.Name);
                        tmpReturnValue.Append("`");
                    }
                    else
                    {
                        tmpReturnValue.Append("\"");
                        tmpReturnValue.Append(this.SelectedField.Name);
                        tmpReturnValue.Append("\"");
                    }
                }

                return tmpReturnValue.ToString();
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                if (this.FieldTable == null)
                {
                    ThrowHelper.ThrowUnKnownException("系统错误->表字段表没填充");
                }

                StringBuilder tmpReturnValue = new StringBuilder();
                tmpReturnValue.Append(this.FieldTable.TableAccess + ".");
                var tmpTable = this.FieldTable as Table;
                DBTypeEnum tmpDBType;

                if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpTable.KuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpTable.KuName));
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpReturnValue.Append("[");
                    tmpReturnValue.Append(this.SelectedField.Name);
                    tmpReturnValue.Append("]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpReturnValue.Append("`");
                    tmpReturnValue.Append(this.SelectedField.Name);
                    tmpReturnValue.Append("`");
                }
                else
                {
                    tmpReturnValue.Append("\"");
                    tmpReturnValue.Append(this.SelectedField.Name);
                    tmpReturnValue.Append("\"");
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

                    tmpReturnValue.Append(" " + tmpAlias);
                }

                return tmpReturnValue.ToString();
            }
        }

        public static byForm_Server.ku.by.ToolClass.Sql.TableField GetPlusTableField(byForm_Server.ku.by.ToolClass.Field f_Field, byForm_Server.ku.by.ToolClass.Sql.Table f_Table)
        {
            var tmpTableField = new TableField();
            tmpTableField.SelectedField = f_Field;
            tmpTableField.FieldTable = f_Table;
            tmpTableField.FieldType = f_Field.FieldType;
            tmpTableField.EnumType = f_Field.EnumType;
            tmpTableField.IsPlusField = true;

            if (f_Field.KuName != f_Table.KuName)
            {
                ThrowHelper.ThrowUnKnownException(string.Format("系统错误->创建sql字段 {0} 出错！库不一致", f_Field.Name));
            }

            return tmpTableField;
        }

        public void SetAlias(string f_Alias)
        {
            this.alias = f_Alias;
        }

        private TableField()
        {
        }

        public TableField(byForm_Server.ku.by.ToolClass.Field f_Field, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, string f_Alias)
        {
            this.SelectedField = f_Field;
            this.FieldTable = f_Table;
            this.Alias = f_Alias;
            this.FieldType = f_Field.FieldType;
            this.EnumType = f_Field.EnumType;

            if (f_Field.KuName != f_Table.KuName)
            {
                ThrowHelper.ThrowUnKnownException(string.Format("系统错误->创建sql字段 {0} 出错！库不一致", f_Field.Name));
            }
        }
    }
}
