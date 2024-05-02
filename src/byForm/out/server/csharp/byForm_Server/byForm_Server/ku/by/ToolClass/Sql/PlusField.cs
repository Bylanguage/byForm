using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class PlusField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField, byForm_Server.ku.by.ToolClass.Sql.IFields
    {
        public override string Alias
        {
            get
            {
                return null;
            }
            set
            {
                ThrowHelper.ThrowUnKnownException("无法设置别名");
            }
        }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public override string FieldAccess
        {
            get
            {
                throw ThrowHelper.ThrowUnKnownException(ErrorInfo.UnExceptedField);
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                StringBuilder tmpValue = new StringBuilder();

                for (int i = 0; i < this.FieldList.Count; i++)
                {
                    var tmpField = this.FieldList[i];
                    if (tmpField is IFields)
                    {
                        ThrowHelper.ThrowUnKnownException("字段填充错误");
                    }
                    if (tmpValue.Length != 0)
                    {
                        tmpValue.Append(", ");
                    }
                    tmpValue.Append(tmpField.SelectItemDeclare);
                }

                return tmpValue.ToString();
            }
        }

        public int FieldCount
        {
            get
            {
                int tmpCount = 0;

                foreach (var item in this.FieldList)
                {
                    if (item is IFields)
                    {
                        ThrowHelper.ThrowUnKnownException("字段填充错误");
                    }
                    tmpCount++;
                }

                return tmpCount;
            }
        }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> FieldList { get; set; }

        public void AddField(string f_Component, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables)
        {
            var tmpArray = f_Component.Split('.');
            List<ToolClass.Sql.AbstractSelectField> tmpCompared = new List<Sql.AbstractSelectField>();
            //if (tmpArray.Length == 1)
            //{
            //    foreach (var item in f_Tables)
            //    {
            //        ToolFunction.GetTableFieldInTableLength1(f_Component, item, tmpCompared, true);
            //        if (tmpCompared.Count > 1)
            //        {
            //            ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.UnClearColumnName, f_Component));
            //        }
            //    }
            //}

            if (tmpArray.Length == 2)
            {
                string tmpTableSourceAlias = tmpArray[0];
                string tmpFieldAlias = tmpArray[1];
                foreach (var item in f_Tables)
                {
                    if (item.Alias != tmpTableSourceAlias)
                    {
                        continue;
                    }

                    if (item is Table)
                    {
                        var tmpTable = item as Table;
                        var tmpDataSheet = tmpTable.Sheet;

                        if (!tmpDataSheet.ComponentDic.ContainsKey(tmpFieldAlias))
                        {
                            return;
                        }

                        tmpCompared.Add(TableField.GetPlusTableField(tmpDataSheet.ComponentDic[tmpFieldAlias], tmpTable));

                        if (tmpCompared.Count > 1)
                        {
                            ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.UnClearColumnName, f_Component));
                        }
                    }
                }
            }

            if (tmpCompared.Count != 0)
            {
                this.FieldList.Add(tmpCompared[0]);
            }
        }

        public PlusField(byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table)
        {
            this.FieldList = new List<AbstractSelectField>();
            this.FieldTable = f_Table;
        }
    }
}
