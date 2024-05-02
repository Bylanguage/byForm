using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class SelectTable : byForm_Server.ku.by.ToolClass.Sql.AbstractTable
    {
        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> SelectItems { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> ResultItems { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> ResultItemsWithoutAsterisk { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> TableSources { get; set; }

        public string No { get; set; }

        public string SqlValue { get; set; }

        public override string Alias { get; set; }

        public int ReturnTypeIndex;

        public string DeclarKuName { get; set; }

        public override string TableAccess
        {
            get
            {
                if (this.Alias == null)
                {
                    throw ThrowHelper.ThrowUnKnownException(ErrorInfo.SelectResultAccessWithoutAlias);
                }
                else
                {
                    DBTypeEnum tmpDBType;

                    if (!Root.GetInstance().KuTypeDic.TryGetValue(this.DeclarKuName, out tmpDBType))
                    {
                        ThrowHelper.ThrowUnKnownException(string.Format("库 {0} 类型未填充", this.DeclarKuName));
                    }

                    StringBuilder tmpDec = new StringBuilder();

                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpDec.Append("[" + this.Alias + "]");
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpDec.Append("`" + this.Alias + "`");
                    }
                    else
                    {
                        tmpDec.Append("\"" + this.Alias + "\"");
                    }

                    return tmpDec.ToString();
                }
            }
        }

        public delegate System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> OrmTypeHandler(byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, byForm_Server.ku.by.Object.Row f_Row);

        public event byForm_Server.ku.by.ToolClass.Sql.SelectTable.OrmTypeHandler GetOrmInstanceEvent;

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> GetOrmInstance(byForm_Server.ku.by.Object.Row f_Row)
        {
            if (this.GetOrmInstanceEvent == null)
            {
                return null;
            }

            return this.GetOrmInstanceEvent(this, f_Row);
        }

        public SelectTable(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_ResultItems, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableSources, string f_Sql, string f_DeclareKuName, byForm_Server.ku.by.ToolClass.Sql.SelectTable.OrmTypeHandler f_GenerateOrmMethod, string f_No)
        {
            //SelectItems只用在orm中
            this.ReturnTypeIndex = -1;
            this.SelectItems = f_SelectItems;
            this.ResultItems = f_ResultItems;
            this.TableSources = f_TableSources;
            this.SqlValue = f_Sql;
            this.JoinTables = new List<JoinTable>();
            this.ResultItemsWithoutAsterisk = new List<AbstractSelectField>();
            this.DeclarKuName = f_DeclareKuName;
            this.No = f_No;
            GetOrmInstanceEvent += f_GenerateOrmMethod;

            foreach (var item in ResultItems)
            {
                if (item is AsteriskField)
                {
                    var tmpAsteriskField = item as AsteriskField;
                    this.ResultItemsWithoutAsterisk.AddRange(tmpAsteriskField.FieldList);
                }
                else
                {
                    this.ResultItemsWithoutAsterisk.Add(item);
                }
            }
        }

        public override byForm_Server.ku.by.ToolClass.AbstractIdentityBase GetIdentity()
        {
            if (this.TableSources.Count == 0)
            {
                ThrowHelper.ThrowUnKnownException("子查询中没有表");
                //return null;
            }

            return this.TableSources[0].GetIdentity();

            //if (this.ReturnTypeIndex <= 0)
            //{
            //    return this.TableSources[0].GetIdentity();
            //}
            //else
            //{
            //    int tmpIndex = 0;
            //    foreach (var table in this.TableSources)
            //    {
            //        if (tmpIndex == this.ReturnTypeIndex)
            //        {
            //            return table.GetIdentity();
            //        }

            //        foreach (var joinTable in table.JoinTables)
            //        {
            //            tmpIndex++;
            //            if (tmpIndex == this.ReturnTypeIndex)
            //            {
            //                return joinTable.JointTable.GetIdentity();
            //            }
            //        }

            //        tmpIndex++;
            //    }

            //    throw new Exception("系统错误->查询语句表源索引错误");
            //}
        }

        public override byForm_Server.ku.by.ToolClass.IBaseDataSheet GetSource()
        {
            if (this.TableSources.Count == 0)
            {
                return null;
            }

            return this.TableSources[0].GetSource();

            //if (this.ReturnTypeIndex <= 0)
            //{
            //    return this.TableSources[0].GetSource();
            //}
            //else
            //{
            //    int tmpIndex = 0;
            //    foreach (var table in this.TableSources)
            //    {
            //        if (tmpIndex == this.ReturnTypeIndex)
            //        {
            //            return table.GetSource();
            //        }

            //        foreach (var joinTable in table.JoinTables)
            //        {
            //            tmpIndex++;
            //            if (tmpIndex == this.ReturnTypeIndex)
            //            {
            //                return joinTable.JointTable.GetSource();
            //            }
            //        }

            //        tmpIndex++;
            //    }

            //    throw new Exception("系统错误->查询语句表源索引错误");
            //}
        }

        public int GetIndexOfField(byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_Field)
        {
            int tmpIndex = 0;
            bool tmpHasFound = false;
            foreach (var item in this.SelectItems)
            {
                if (item != f_Field)
                {
                    if (item is AsteriskField)
                    {
                        var tmpField = item as AsteriskField;
                        tmpIndex += tmpField.FieldCount;
                    }
                    else if (item is PlusField)
                    {
                        var tmpField = item as PlusField;
                        tmpIndex += tmpField.FieldCount;
                    }
                    else
                    {
                        tmpIndex++;
                    }
                }
                else
                {
                    tmpHasFound = true;
                    break;
                }
            }
            if (!tmpHasFound)
            {
                ThrowHelper.ThrowUnKnownException("无法获取字段在查询结果中的索引");
            }
            return tmpIndex;
        }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase FindTableIdentityWithAlias(string f_Alias)
        {
            foreach (var tablesource in this.TableSources)
            {
                if (tablesource.Alias == f_Alias)
                {
                    return tablesource.GetIdentity();
                }
            }

            throw ThrowHelper.ThrowUnKnownException(string.Format("无法获取别名为 {0} 的表源"));
        }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable Copy()
        {
            var tmpNewTable = new SelectTable(this.SelectItems, this.ResultItems, this.TableSources, this.SqlValue, this.DeclarKuName, GetOrmInstanceEvent, this.No);
            tmpNewTable.JoinTables = this.JoinTables;
            tmpNewTable.IsOuterTable = true;
            return tmpNewTable;
        }

        public override string PrintSource()
        {
            StringBuilder tmpSource = new StringBuilder();

            foreach (var item in this.TableSources)
            {
                if (tmpSource.Length > 0)
                {
                    tmpSource.Append(", ");
                }

                tmpSource.Append(item.PrintSource());
            }

            return tmpSource.ToString();
        }

        public override string ToString()
        {
            return this.SqlValue;
        }
    }
}
