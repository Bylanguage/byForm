using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class Table : byForm_Server.ku.by.ToolClass.Sql.AbstractTable
    {
        public string KuName
        {
            get
            {
                return this.Sheet.KuName;
            }
        }

        public string RealKuName
        {
            get
            {
                return string.IsNullOrEmpty(this.Sheet.RealKuName) ? this.KuName : this.Sheet.RealKuName;
            }
        }

        public byForm_Server.ku.by.ToolClass.IBaseDataSheet Sheet { get; private set; }

        public string SourceName
        {
            get
            {
                return this.Sheet.SheetName;
            }
        }

        public override string Alias { get; set; }

        public override string TableAccess
        {
            get
            {
                DBTypeEnum tmpDBType;
                if (!Root.GetInstance().KuTypeDic.TryGetValue(this.KuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format("库 {0} 类型未填充", this.KuName));
                }

                if (this.Alias != null)
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        return "[" + this.Alias + "]";
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        return "`" + this.Alias + "`";
                    }
                    else
                    {
                        return "\"" + this.Alias + "\"";
                    }
                }
                else
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        return "[" + this.Sheet.SheetName + "]";
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        return "`" + this.Sheet.SheetName + "`";
                    }
                    else
                    {
                        return "\"" + this.Sheet.SheetName + "\"";
                    }
                }
            }
        }

        public string TableDec
        {
            get
            {
                DBTypeEnum tmpDBType;
                if (!Root.GetInstance().KuTypeDic.TryGetValue(this.KuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format("库 {0} 类型未填充", this.KuName));
                }
                StringBuilder tmpDec = new StringBuilder();
                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpDec.Append("[" + this.Sheet.SheetName + "]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpDec.Append("`" + this.Sheet.SheetName + "`");
                }
                else
                {
                    tmpDec.Append("\"" + this.Sheet.SheetName + "\"");
                }

                if (this.Alias != null)
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpDec.Append(" [" + this.Alias + "]");
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpDec.Append(" `" + this.Alias + "`");
                    }
                    else
                    {
                        tmpDec.Append(" \"" + this.Alias + "\"");
                    }
                }
                return tmpDec.ToString();
            }
        }

        public Table(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet, string f_Alias)
        {
            if (f_DataSheet == null)
            {
                ThrowHelper.ThrowUnKnownException("空的表源项");
            }
            this.Sheet = f_DataSheet;
            this.Alias = f_Alias;
            this.JoinTables = new List<JoinTable>();
        }

        public override byForm_Server.ku.by.ToolClass.AbstractIdentityBase GetIdentity()
        {
            if (this.Sheet == null)
            {
                ThrowHelper.ThrowUnKnownException("空的表源");
            }

            return this.Sheet.Identity;
        }

        public override byForm_Server.ku.by.ToolClass.IBaseDataSheet GetSource()
        {
            return this.Sheet;
        }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable Copy()
        {
            Table tmpNewTable = new Table(this.Sheet, this.Alias);
            tmpNewTable.JoinTables = this.JoinTables;
            tmpNewTable.IsOuterTable = true;
            return tmpNewTable;
        }

        public override string PrintSource()
        {
            StringBuilder tmpSource = new StringBuilder();
            tmpSource.Append(this.Sheet.SheetName);

            foreach (var item in this.JoinTables)
            {
                tmpSource.Append(", ");
                tmpSource.Append(item.JointTable.PrintSource());
            }

            return tmpSource.ToString();
        }
    }
}
