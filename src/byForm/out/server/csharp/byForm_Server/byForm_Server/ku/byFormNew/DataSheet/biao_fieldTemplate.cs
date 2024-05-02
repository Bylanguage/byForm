using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.byFormNew.DataSheet
{
    public class biao_fieldTemplate : byForm_Server.ku.by.Object.table, byForm_Server.ku.by.ToolClass.IBaseDataSheet
    {
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source>> FlowDic { get; set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string>> VerifyDic { get; set; }

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.Field> FieldDic { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> PrimaryKeyList { get; set; }

        public System.Collections.Generic.List<string> DefaultColumnList { get; set; }

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.Source> SourceDic { get; set; }

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.Field> ComponentDic { get; set; }

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Delegates.KuDelegates.RowFlowDelegate> RowFlowDic { get; set; }

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Delegates.KuDelegates.RowsFlowDelegatge> RowsFlowDic { get; set; }

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Delegates.KuDelegates.RowFlowInTranDelegate> RowFlowInTranDic { get; set; }

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Delegates.KuDelegates.RowsFlowInTranDelegate> RowsFlowInTranDic { get; set; }

        public string KuName { get; set; }

        public string RealKuName
        {
            get
            {
                string tmpKuName;
                if (Root.GetInstance().KuNameReflectionDic.TryGetValue(this.KuName, out tmpKuName))
                {
                    return tmpKuName;
                }

                return this.KuName;
            }
        }

        public string SheetName { get; set; }

        private int _max;

        private bool maxSet = false;

        public override int max
        {
            get
            {
                if (!maxSet)
                {
                    _max = ToolFunction.SetMax(this);
                    maxSet = true;
                }

                return _max;
            }
            set
            {
                _max = value;
            }
        }

        public bool IsConst { get; set; }

        public string IdentityName { get; set; }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> flow_insert = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source>();

        public string FlowString_insert(System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, params System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_RelationRow)
        {
            if (f_Rows.Count == 0)
            {
                return "";
            }
            var tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
            var tmpRelationRowCopy = ToolFunction.CopyRowsArray(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            //涉及到的字段名，不是数据流名
            string[] tmpColumns = { "iD", "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            for (int i = 0; i < tmpRowsCopy.Count; i++)
            {
                var tmpRow = tmpRowsCopy[i];
                if (tmpRow.KuName != this.KuName || tmpRow.SheetName != this.SheetName)
                {
                    string tmpRowSheetName = tmpRow.KuName + "." + tmpRow.SheetName;
                    string tmpThisSheetName = this.KuName + "." + this.SheetName;
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
                }

                if (tmpRelationRowCopy != null && tmpRelationRowCopy.Count != 0)
                {
                    foreach (var relationrows in tmpRelationRowCopy)
                    {
                        if (relationrows.Count == 0)
                        {
                            continue;
                        }

                        if (relationrows.Count != tmpRowsCopy.Count)
                        {
                            throw new Exception("关系行集合的元素数不等于首个参数行集合的元素数");
                        }

                        var tmpRelationRow = relationrows[i];
                        ToolFunction.Replace(tmpRow.cells, tmpRelationRow);
                    }
                }

                foreach (var column in tmpRow.cells)
                {
                    if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                    {
                        continue;
                    }

                    string tmpValue = null;
                    if (column.value != null)
                    {
                        tmpValue = column.value.ToString();
                    }
                    if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                    {
                        VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                    }

                    column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
                }
                tmpSql.Append(SqlInvocation.InsertSql(this, tmpColumns, tmpRow));
                tmpSql.Append("\r\n");
            }
            return tmpSql.ToString();
        }

        public string FlowString_insert(byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            if (f_CurrentRow == null)
            {
                return "";
            }
            if (f_CurrentRow.KuName != this.KuName || f_CurrentRow.SheetName != this.SheetName)
            {
                string tmpRowSheetName = f_CurrentRow.KuName + "." + f_CurrentRow.SheetName;
                string tmpThisSheetName = this.KuName + "." + this.SheetName;
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
            var tmpRowCopy = f_CurrentRow.Copy();
            var tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            foreach (var item in tmpRelationRowCopy)
            {
                ToolFunction.Replace(tmpRowCopy.cells, item);
            }

            foreach (var column in tmpRowCopy.cells)
            {
                if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                {
                    //引用的其他表
                    continue;
                }
                string tmpValue = null;
                if (column.value != null)
                {
                    tmpValue = column.value.ToString();
                }
                if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                {
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                }

                column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
            }

            //替换成数据库中对应格式
            string[] tmpColumns = { "iD", "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" };
            return SqlInvocation.InsertSql(this, tmpColumns, tmpRowCopy);
        }

        public string FlowStringInTran_insert(string f_EffectCount, byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            if (f_CurrentRow == null)
            {
                return string.Format("SET @{0} = 0\r\n", f_EffectCount);
            }
            if (f_CurrentRow.KuName != this.KuName || f_CurrentRow.SheetName != this.SheetName)
            {
                string tmpRowSheetName = f_CurrentRow.KuName + "." + f_CurrentRow.SheetName;
                string tmpThisSheetName = this.KuName + "." + this.SheetName;
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
            var tmpRowCopy = f_CurrentRow.Copy();
            var tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("SET @{0} = 0", f_EffectCount));
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            foreach (var item in tmpRelationRowCopy)
            {
                ToolFunction.Replace(tmpRowCopy.cells, item);
            }

            foreach (var column in tmpRowCopy.cells)
            {
                if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                {
                    //引用的其他表
                    continue;
                }
                string tmpValue = null;
                if (column.value != null)
                {
                    tmpValue = column.value.ToString();
                }
                if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                {
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                }

                column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
            }

            //替换成数据库中对应格式
            string[] tmpColumns = { "iD", "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" };
            tmpSql.Append(SqlInvocation.InsertSql(this, tmpColumns, tmpRowCopy));
            tmpSql.Append(string.Format("\r\nSET @{0} = @{0} + @@ROWCOUNT\r\n", f_EffectCount));
            return tmpSql.ToString();
        }

        public string FlowStringInTran_insert(string f_EffectCount, System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, params System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_RelationRow)
        {
            if (f_Rows.Count == 0)
            {
                return string.Format("SET @{0} = 0\r\n", f_EffectCount);
            }
            var tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
            var tmpRelationRowCopy = ToolFunction.CopyRowsArray(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.Append(string.Format("set @{0} = 0\r\n", f_EffectCount));
            //涉及到的字段名，不是数据流名
            string[] tmpColumns = { "iD", "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            for (int i = 0; i < tmpRowsCopy.Count; i++)
            {
                var tmpRow = tmpRowsCopy[i];
                if (tmpRow.KuName != this.KuName || tmpRow.SheetName != this.SheetName)
                {
                    string tmpRowSheetName = tmpRow.KuName + "." + tmpRow.SheetName;
                    string tmpThisSheetName = this.KuName + "." + this.SheetName;
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
                }

                if (tmpRelationRowCopy != null && tmpRelationRowCopy.Count != 0)
                {
                    foreach (var relationrows in tmpRelationRowCopy)
                    {
                        if (relationrows.Count == 0)
                        {
                            continue;
                        }

                        if (relationrows.Count != tmpRowsCopy.Count)
                        {
                            throw new Exception("关系行集合的元素数不等于首个参数行集合的元素数");
                        }

                        var tmpRelationRow = relationrows[i];
                        ToolFunction.Replace(tmpRow.cells, tmpRelationRow);
                    }
                }

                foreach (var column in tmpRow.cells)
                {
                    if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                    {
                        continue;
                    }

                    string tmpValue = null;
                    if (column.value != null)
                    {
                        tmpValue = column.value.ToString();
                    }
                    if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                    {
                        VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                    }

                    column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
                }
                tmpSql.Append(SqlInvocation.InsertSql(this, tmpColumns, tmpRow));

                tmpSql.Append(string.Format("\r\nSET @{0} = @{0} + @@ROWCOUNT\r\n", f_EffectCount));
            }
            return tmpSql.ToString();
        }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> flow_update = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source>();

        public string FlowString_update(System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, params System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_RelationRow)
        {
            if (f_Rows.Count == 0)
            {
                return "";
            }
            var tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
            var tmpRelationRowCopy = ToolFunction.CopyRowsArray(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            //涉及到的字段名，不是数据流名
            string[] tmpColumns = { "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            for (int i = 0; i < tmpRowsCopy.Count; i++)
            {
                var tmpRow = tmpRowsCopy[i];
                if (tmpRow.KuName != this.KuName || tmpRow.SheetName != this.SheetName)
                {
                    string tmpRowSheetName = tmpRow.KuName + "." + tmpRow.SheetName;
                    string tmpThisSheetName = this.KuName + "." + this.SheetName;
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
                }

                if (tmpRelationRowCopy != null && tmpRelationRowCopy.Count != 0)
                {
                    foreach (var relationrows in tmpRelationRowCopy)
                    {
                        if (relationrows.Count == 0)
                        {
                            continue;
                        }

                        if (relationrows.Count != tmpRowsCopy.Count)
                        {
                            throw new Exception("关系行集合的元素数不等于首个参数行集合的元素数");
                        }

                        var tmpRelationRow = relationrows[i];
                        ToolFunction.Replace(tmpRow.cells, tmpRelationRow);
                    }
                }

                foreach (var column in tmpRow.cells)
                {
                    if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                    {
                        continue;
                    }

                    string tmpValue = null;
                    if (column.value != null)
                    {
                        tmpValue = column.value.ToString();
                    }
                    if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                    {
                        VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                    }

                    column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
                }
                tmpSql.Append(SqlInvocation.UpdateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
                tmpSql.Append("\r\n");
            }
            return tmpSql.ToString();
        }

        public string FlowString_update(byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            if (f_CurrentRow == null)
            {
                return "";
            }
            if (f_CurrentRow.KuName != this.KuName || f_CurrentRow.SheetName != this.SheetName)
            {
                string tmpRowSheetName = f_CurrentRow.KuName + "." + f_CurrentRow.SheetName;
                string tmpThisSheetName = this.KuName + "." + this.SheetName;
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
            var tmpRowCopy = f_CurrentRow.Copy();
            var tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            foreach (var item in tmpRelationRowCopy)
            {
                ToolFunction.Replace(tmpRowCopy.cells, item);
            }

            foreach (var column in tmpRowCopy.cells)
            {
                if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                {
                    //引用的其他表
                    continue;
                }
                string tmpValue = null;
                if (column.value != null)
                {
                    tmpValue = column.value.ToString();
                }
                if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                {
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                }

                column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
            }

            //替换成数据库中对应格式
            string[] tmpColumns = { "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" };
            return SqlInvocation.UpdateSql(tmpDataSheet, tmpColumns, tmpRowCopy, tmpDataSheet.PrimaryKeyList);
        }

        public string FlowStringInTran_update(string f_EffectCount, byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            if (f_CurrentRow == null)
            {
                return string.Format("SET @{0} = 0\r\n", f_EffectCount);
            }
            if (f_CurrentRow.KuName != this.KuName || f_CurrentRow.SheetName != this.SheetName)
            {
                string tmpRowSheetName = f_CurrentRow.KuName + "." + f_CurrentRow.SheetName;
                string tmpThisSheetName = this.KuName + "." + this.SheetName;
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
            var tmpRowCopy = f_CurrentRow.Copy();
            var tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("SET @{0} = 0", f_EffectCount));
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            foreach (var item in tmpRelationRowCopy)
            {
                ToolFunction.Replace(tmpRowCopy.cells, item);
            }

            foreach (var column in tmpRowCopy.cells)
            {
                if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                {
                    //引用的其他表
                    continue;
                }
                string tmpValue = null;
                if (column.value != null)
                {
                    tmpValue = column.value.ToString();
                }
                if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                {
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                }

                column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
            }

            //替换成数据库中对应格式
            string[] tmpColumns = { "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" };
            tmpSql.Append(SqlInvocation.UpdateSql(tmpDataSheet, tmpColumns, tmpRowCopy, tmpDataSheet.PrimaryKeyList));
            tmpSql.Append(string.Format("\r\nSET @{0} = @{0} + @@ROWCOUNT\r\n", f_EffectCount));
            return tmpSql.ToString();
        }

        public string FlowStringInTran_update(string f_EffectCount, System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, params System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_RelationRow)
        {
            if (f_Rows.Count == 0)
            {
                return string.Format("SET @{0} = 0\r\n", f_EffectCount);
            }
            var tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
            var tmpRelationRowCopy = ToolFunction.CopyRowsArray(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.Append(string.Format("set @{0} = 0\r\n", f_EffectCount));
            //涉及到的字段名，不是数据流名
            string[] tmpColumns = { "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            for (int i = 0; i < tmpRowsCopy.Count; i++)
            {
                var tmpRow = tmpRowsCopy[i];
                if (tmpRow.KuName != this.KuName || tmpRow.SheetName != this.SheetName)
                {
                    string tmpRowSheetName = tmpRow.KuName + "." + tmpRow.SheetName;
                    string tmpThisSheetName = this.KuName + "." + this.SheetName;
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
                }

                if (tmpRelationRowCopy != null && tmpRelationRowCopy.Count != 0)
                {
                    foreach (var relationrows in tmpRelationRowCopy)
                    {
                        if (relationrows.Count == 0)
                        {
                            continue;
                        }

                        if (relationrows.Count != tmpRowsCopy.Count)
                        {
                            throw new Exception("关系行集合的元素数不等于首个参数行集合的元素数");
                        }

                        var tmpRelationRow = relationrows[i];
                        ToolFunction.Replace(tmpRow.cells, tmpRelationRow);
                    }
                }

                foreach (var column in tmpRow.cells)
                {
                    if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                    {
                        continue;
                    }

                    string tmpValue = null;
                    if (column.value != null)
                    {
                        tmpValue = column.value.ToString();
                    }
                    if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                    {
                        VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                    }

                    column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
                }
                tmpSql.Append(SqlInvocation.UpdateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));

                tmpSql.Append(string.Format("\r\nSET @{0} = @{0} + @@ROWCOUNT\r\n", f_EffectCount));
            }
            return tmpSql.ToString();
        }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> flow_delete = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source>();

        public string FlowString_delete(System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, params System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_RelationRow)
        {
            if (f_Rows.Count == 0)
            {
                return "";
            }
            var tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
            var tmpRelationRowCopy = ToolFunction.CopyRowsArray(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            //涉及到的字段名，不是数据流名
            string[] tmpColumns = { "iD" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            for (int i = 0; i < tmpRowsCopy.Count; i++)
            {
                var tmpRow = tmpRowsCopy[i];
                if (tmpRow.KuName != this.KuName || tmpRow.SheetName != this.SheetName)
                {
                    string tmpRowSheetName = tmpRow.KuName + "." + tmpRow.SheetName;
                    string tmpThisSheetName = this.KuName + "." + this.SheetName;
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
                }

                if (tmpRelationRowCopy != null && tmpRelationRowCopy.Count != 0)
                {
                    foreach (var relationrows in tmpRelationRowCopy)
                    {
                        if (relationrows.Count == 0)
                        {
                            continue;
                        }

                        if (relationrows.Count != tmpRowsCopy.Count)
                        {
                            throw new Exception("关系行集合的元素数不等于首个参数行集合的元素数");
                        }

                        var tmpRelationRow = relationrows[i];
                        ToolFunction.Replace(tmpRow.cells, tmpRelationRow);
                    }
                }

                foreach (var column in tmpRow.cells)
                {
                    if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                    {
                        continue;
                    }

                    string tmpValue = null;
                    if (column.value != null)
                    {
                        tmpValue = column.value.ToString();
                    }
                    if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                    {
                        VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                    }

                    column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
                }
                tmpSql.Append(SqlInvocation.DeleteSql(tmpDataSheet, tmpColumns, tmpRow));
                tmpSql.Append("\r\n");
            }
            return tmpSql.ToString();
        }

        public string FlowString_delete(byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            if (f_CurrentRow == null)
            {
                return "";
            }
            if (f_CurrentRow.KuName != this.KuName || f_CurrentRow.SheetName != this.SheetName)
            {
                string tmpRowSheetName = f_CurrentRow.KuName + "." + f_CurrentRow.SheetName;
                string tmpThisSheetName = this.KuName + "." + this.SheetName;
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
            var tmpRowCopy = f_CurrentRow.Copy();
            var tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            foreach (var item in tmpRelationRowCopy)
            {
                ToolFunction.Replace(tmpRowCopy.cells, item);
            }

            foreach (var column in tmpRowCopy.cells)
            {
                if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                {
                    //引用的其他表
                    continue;
                }
                string tmpValue = null;
                if (column.value != null)
                {
                    tmpValue = column.value.ToString();
                }
                if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                {
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                }

                column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
            }

            //替换成数据库中对应格式
            string[] tmpColumns = { "iD" };
            return SqlInvocation.DeleteSql(tmpDataSheet, tmpColumns, tmpRowCopy);
        }

        public string FlowStringInTran_delete(string f_EffectCount, byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            if (f_CurrentRow == null)
            {
                return string.Format("SET @{0} = 0\r\n", f_EffectCount);
            }
            if (f_CurrentRow.KuName != this.KuName || f_CurrentRow.SheetName != this.SheetName)
            {
                string tmpRowSheetName = f_CurrentRow.KuName + "." + f_CurrentRow.SheetName;
                string tmpThisSheetName = this.KuName + "." + this.SheetName;
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
            var tmpRowCopy = f_CurrentRow.Copy();
            var tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("SET @{0} = 0", f_EffectCount));
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            foreach (var item in tmpRelationRowCopy)
            {
                ToolFunction.Replace(tmpRowCopy.cells, item);
            }

            foreach (var column in tmpRowCopy.cells)
            {
                if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                {
                    //引用的其他表
                    continue;
                }
                string tmpValue = null;
                if (column.value != null)
                {
                    tmpValue = column.value.ToString();
                }
                if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                {
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                }

                column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
            }

            //替换成数据库中对应格式
            string[] tmpColumns = { "iD" };
            tmpSql.Append(SqlInvocation.DeleteSql(tmpDataSheet, tmpColumns, tmpRowCopy));
            tmpSql.Append(string.Format("\r\nSET @{0} = @{0} + @@ROWCOUNT\r\n", f_EffectCount));
            return tmpSql.ToString();
        }

        public string FlowStringInTran_delete(string f_EffectCount, System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, params System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_RelationRow)
        {
            if (f_Rows.Count == 0)
            {
                return string.Format("SET @{0} = 0\r\n", f_EffectCount);
            }
            var tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
            var tmpRelationRowCopy = ToolFunction.CopyRowsArray(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.Append(string.Format("set @{0} = 0\r\n", f_EffectCount));
            //涉及到的字段名，不是数据流名
            string[] tmpColumns = { "iD" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["fieldTemplate"];
            for (int i = 0; i < tmpRowsCopy.Count; i++)
            {
                var tmpRow = tmpRowsCopy[i];
                if (tmpRow.KuName != this.KuName || tmpRow.SheetName != this.SheetName)
                {
                    string tmpRowSheetName = tmpRow.KuName + "." + tmpRow.SheetName;
                    string tmpThisSheetName = this.KuName + "." + this.SheetName;
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
                }

                if (tmpRelationRowCopy != null && tmpRelationRowCopy.Count != 0)
                {
                    foreach (var relationrows in tmpRelationRowCopy)
                    {
                        if (relationrows.Count == 0)
                        {
                            continue;
                        }

                        if (relationrows.Count != tmpRowsCopy.Count)
                        {
                            throw new Exception("关系行集合的元素数不等于首个参数行集合的元素数");
                        }

                        var tmpRelationRow = relationrows[i];
                        ToolFunction.Replace(tmpRow.cells, tmpRelationRow);
                    }
                }

                foreach (var column in tmpRow.cells)
                {
                    if (!tmpDataSheet.FieldDic.ContainsKey(column.ColumnName))
                    {
                        continue;
                    }

                    string tmpValue = null;
                    if (column.value != null)
                    {
                        tmpValue = column.value.ToString();
                    }
                    if (tmpDataSheet.VerifyDic.ContainsKey(column.ColumnName))
                    {
                        VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic[column.ColumnName], tmpDataSheet.FieldDic[column.ColumnName], tmpValue);
                    }

                    column.SetValue(ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic[column.ColumnName].FieldType));
                }
                tmpSql.Append(SqlInvocation.DeleteSql(tmpDataSheet, tmpColumns, tmpRow));

                tmpSql.Append(string.Format("\r\nSET @{0} = @{0} + @@ROWCOUNT\r\n", f_EffectCount));
            }
            return tmpSql.ToString();
        }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> flow_select = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source>();

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> flow_popup = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source>();

        public string GetFieldDefault(string f_FieldName)
        {
            switch (f_FieldName)
            {
                default:
                    throw new Exception(string.Format("表 {0} 错误的字段 {1} 默认值调用", this.SheetName, f_FieldName));
            }
        }

        public biao_fieldTemplate()
        {
            try
            {
                FieldDic = new Dictionary<string, Field>();
                FlowDic = new Dictionary<string, List<by.ToolClass.Source>>();
                RowFlowDic = new Dictionary<string, by.Delegates.KuDelegates.RowFlowDelegate>();
                RowFlowInTranDic = new Dictionary<string, by.Delegates.KuDelegates.RowFlowInTranDelegate>();
                RowsFlowDic = new Dictionary<string, by.Delegates.KuDelegates.RowsFlowDelegatge>();
                RowsFlowInTranDic = new Dictionary<string, by.Delegates.KuDelegates.RowsFlowInTranDelegate>();
                PrimaryKeyList = new List<Field>();
                ComponentDic = new Dictionary<string, Field>();
                VerifyDic = new Dictionary<string, Dictionary<by.Enum.attribute, string>>();
                SourceDic = new Dictionary<string, by.ToolClass.Source>();
                DefaultColumnList = new List<string>();
                Fields = new Dictionary<string, field>();
                Rows = new List<Row>();
                IsConst = false;
                KuName = "byFormNew";
                this.SheetName = "fieldTemplate";
                DataSheet = this;
                tableType = by.Enum.TableType.data;
                IdentityName = "byForm.fieldTemplate";

                VerifyDic.Add("iD", new Dictionary<ku.by.Enum.attribute, string>());
                bool iD_notNull = true;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.notNull, iD_notNull.ToString());
                int iD_max = 32;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.max, iD_max.ToString());
                VerifyDic.Add("name", new Dictionary<ku.by.Enum.attribute, string>());
                bool name_notNull = true;
                VerifyDic["name"].Add(ku.by.Enum.attribute.notNull, name_notNull.ToString());
                int name_max = 32;
                VerifyDic["name"].Add(ku.by.Enum.attribute.max, name_max.ToString());
                VerifyDic.Add("summary", new Dictionary<ku.by.Enum.attribute, string>());
                int summary_max = 32;
                VerifyDic["summary"].Add(ku.by.Enum.attribute.max, summary_max.ToString());
                VerifyDic.Add("ctrType", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("ico", new Dictionary<ku.by.Enum.attribute, string>());
                int ico_max = 128;
                VerifyDic["ico"].Add(ku.by.Enum.attribute.max, ico_max.ToString());
                VerifyDic.Add("min", new Dictionary<ku.by.Enum.attribute, string>());
                int min_max = 256;
                VerifyDic["min"].Add(ku.by.Enum.attribute.max, min_max.ToString());
                VerifyDic.Add("max", new Dictionary<ku.by.Enum.attribute, string>());
                int max_max = 256;
                VerifyDic["max"].Add(ku.by.Enum.attribute.max, max_max.ToString());
                VerifyDic.Add("default2", new Dictionary<ku.by.Enum.attribute, string>());
                int default2_min = 0;
                VerifyDic["default2"].Add(ku.by.Enum.attribute.min, default2_min.ToString());
                int default2_max = 32;
                VerifyDic["default2"].Add(ku.by.Enum.attribute.max, default2_max.ToString());
                VerifyDic.Add("reg", new Dictionary<ku.by.Enum.attribute, string>());
                int reg_min = 0;
                VerifyDic["reg"].Add(ku.by.Enum.attribute.min, reg_min.ToString());
                int reg_max = 256;
                VerifyDic["reg"].Add(ku.by.Enum.attribute.max, reg_max.ToString());
                VerifyDic.Add("regMsg", new Dictionary<ku.by.Enum.attribute, string>());
                int regMsg_min = 0;
                VerifyDic["regMsg"].Add(ku.by.Enum.attribute.min, regMsg_min.ToString());
                int regMsg_max = 256;
                VerifyDic["regMsg"].Add(ku.by.Enum.attribute.max, regMsg_max.ToString());
                VerifyDic.Add("createDt", new Dictionary<ku.by.Enum.attribute, string>());
                FieldDic.Add("iD", new Field(this.KuName, this.SheetName, "iD", ku.DataTypeEnum.String));
                ComponentDic.Add("iID", this.FieldDic["iD"]);
                Fields.Add("iD", new field(this.FieldDic["iD"], "ID"));
                FieldDic.Add("name", new Field(this.KuName, this.SheetName, "name", ku.DataTypeEnum.String));
                ComponentDic.Add("iName", this.FieldDic["name"]);
                Fields.Add("name", new field(this.FieldDic["name"], "名称"));
                FieldDic.Add("summary", new Field(this.KuName, this.SheetName, "summary", ku.DataTypeEnum.String));
                ComponentDic.Add("iSummary", this.FieldDic["summary"]);
                Fields.Add("summary", new field(this.FieldDic["summary"], "说明"));
                FieldDic.Add("ctrType", new Field(this.KuName, this.SheetName, "ctrType", typeof(ku.byForm.Enum.ctrType)));
                ComponentDic.Add("iCtrType", this.FieldDic["ctrType"]);
                Fields.Add("ctrType", new field(this.FieldDic["ctrType"], "控件类型"));
                FieldDic.Add("ico", new Field(this.KuName, this.SheetName, "ico", ku.DataTypeEnum.String));
                ComponentDic.Add("iIco", this.FieldDic["ico"]);
                Fields.Add("ico", new field(this.FieldDic["ico"], "图标"));
                FieldDic.Add("min", new Field(this.KuName, this.SheetName, "min", ku.DataTypeEnum.Int));
                ComponentDic.Add("iMin", this.FieldDic["min"]);
                Fields.Add("min", new field(this.FieldDic["min"], "最小值"));
                FieldDic.Add("max", new Field(this.KuName, this.SheetName, "max", ku.DataTypeEnum.Int));
                ComponentDic.Add("iMax", this.FieldDic["max"]);
                Fields.Add("max", new field(this.FieldDic["max"], "最大值"));
                FieldDic.Add("default2", new Field(this.KuName, this.SheetName, "default2", ku.DataTypeEnum.String));
                ComponentDic.Add("iDefault", this.FieldDic["default2"]);
                Fields.Add("default2", new field(this.FieldDic["default2"], "默认值"));
                FieldDic.Add("reg", new Field(this.KuName, this.SheetName, "reg", ku.DataTypeEnum.String));
                ComponentDic.Add("iReg", this.FieldDic["reg"]);
                Fields.Add("reg", new field(this.FieldDic["reg"], "正则验证"));
                FieldDic.Add("regMsg", new Field(this.KuName, this.SheetName, "regMsg", ku.DataTypeEnum.String));
                ComponentDic.Add("iRegMsg", this.FieldDic["regMsg"]);
                Fields.Add("regMsg", new field(this.FieldDic["regMsg"], "正则验证出错后消息"));
                FieldDic.Add("createDt", new Field(this.KuName, this.SheetName, "createDt", ku.DataTypeEnum.Datetime));
                ComponentDic.Add("iCreateDt", this.FieldDic["createDt"]);
                Fields.Add("createDt", new field(this.FieldDic["createDt"], "创建时间"));
                SourceDic.Add("iD", new by.ToolClass.Source(this, "equal",  FieldDic["iD"]));
                SourceDic.Add("name", new by.ToolClass.Source(this, "equal",  FieldDic["name"]));
                SourceDic.Add("summary", new by.ToolClass.Source(this, "equal",  FieldDic["summary"]));
                SourceDic.Add("ctrType", new by.ToolClass.Source(this, "equal",  FieldDic["ctrType"]));
                SourceDic.Add("ico", new by.ToolClass.Source(this, "equal",  FieldDic["ico"]));
                SourceDic.Add("min", new by.ToolClass.Source(this, "equal",  FieldDic["min"]));
                SourceDic.Add("max", new by.ToolClass.Source(this, "equal",  FieldDic["max"]));
                SourceDic.Add("default2", new by.ToolClass.Source(this, "equal",  FieldDic["default2"]));
                SourceDic.Add("reg", new by.ToolClass.Source(this, "equal",  FieldDic["reg"]));
                SourceDic.Add("regMsg", new by.ToolClass.Source(this, "equal",  FieldDic["regMsg"]));
                SourceDic.Add("createDt", new by.ToolClass.Source(this, "equal",  FieldDic["createDt"]));
                FlowDic.Add("insert", flow_insert);
                RowFlowDic.Add("insert", FlowString_insert);
                RowsFlowDic.Add("insert", FlowString_insert);
                RowFlowInTranDic.Add("insert", FlowStringInTran_insert);
                RowsFlowInTranDic.Add("insert", FlowStringInTran_insert);
                FlowDic["insert"].Add(SourceDic["iD"]);
                FlowDic["insert"].Add(SourceDic["name"]);
                FlowDic["insert"].Add(SourceDic["summary"]);
                FlowDic["insert"].Add(SourceDic["ctrType"]);
                FlowDic["insert"].Add(SourceDic["ico"]);
                FlowDic["insert"].Add(SourceDic["min"]);
                FlowDic["insert"].Add(SourceDic["max"]);
                FlowDic["insert"].Add(SourceDic["default2"]);
                FlowDic["insert"].Add(SourceDic["reg"]);
                FlowDic["insert"].Add(SourceDic["regMsg"]);
                FlowDic["insert"].Add(SourceDic["createDt"]);
                FlowDic.Add("update", flow_update);
                RowFlowDic.Add("update", FlowString_update);
                RowsFlowDic.Add("update", FlowString_update);
                RowFlowInTranDic.Add("update", FlowStringInTran_update);
                RowsFlowInTranDic.Add("update", FlowStringInTran_update);
                FlowDic["update"].Add(SourceDic["name"]);
                FlowDic["update"].Add(SourceDic["summary"]);
                FlowDic["update"].Add(SourceDic["ctrType"]);
                FlowDic["update"].Add(SourceDic["ico"]);
                FlowDic["update"].Add(SourceDic["min"]);
                FlowDic["update"].Add(SourceDic["max"]);
                FlowDic["update"].Add(SourceDic["default2"]);
                FlowDic["update"].Add(SourceDic["reg"]);
                FlowDic["update"].Add(SourceDic["regMsg"]);
                FlowDic["update"].Add(SourceDic["createDt"]);
                FlowDic.Add("delete", flow_delete);
                RowFlowDic.Add("delete", FlowString_delete);
                RowsFlowDic.Add("delete", FlowString_delete);
                RowFlowInTranDic.Add("delete", FlowStringInTran_delete);
                RowsFlowInTranDic.Add("delete", FlowStringInTran_delete);
                FlowDic["delete"].Add(SourceDic["iD"]);
                FlowDic.Add("select", flow_select);
                FlowDic["select"].Add(SourceDic["iD"]);
                FlowDic["select"].Add(SourceDic["name"]);
                FlowDic["select"].Add(SourceDic["summary"]);
                FlowDic["select"].Add(SourceDic["ctrType"]);
                FlowDic["select"].Add(SourceDic["ico"]);
                FlowDic["select"].Add(SourceDic["min"]);
                FlowDic["select"].Add(SourceDic["max"]);
                FlowDic["select"].Add(SourceDic["default2"]);
                FlowDic["select"].Add(SourceDic["reg"]);
                FlowDic["select"].Add(SourceDic["regMsg"]);
                FlowDic["select"].Add(SourceDic["createDt"]);
                FlowDic.Add("popup", flow_popup);
                FlowDic["popup"].Add(SourceDic["iD"]);
                FlowDic["popup"].Add(SourceDic["name"]);
                FlowDic["popup"].Add(SourceDic["createDt"]);
                PrimaryKeyList.Add(this.FieldDic["iD"]);
                AddRow(new object[] { "1", "singleTextbox", "单行文本", "textbox", "singleTextbox.svg", 0, 0, "", "^[^\'\'\"\"]*$", "不能输入单引号 及双引号", "2024-04-28 00:00:00"});
                AddRow(new object[] { "2", "multiTextbox", "多行文本", "muiltTextbox", "multiTextbox.svg", 0, 0, "", "^[^\'\']*$", "不能输入单引号", "2024-04-28 00:00:10"});
                AddRow(new object[] { "3", "checkBox", "判断", "checkBox", "checkBox.svg", 0, 0, "", "", "", "2024-04-28 00:00:20"});
                AddRow(new object[] { "4", "dropdownList", "下拉", "dropdownList", "dropdownList.svg", 0, 0, "", "", "", "2024-04-28 00:00:30"});
                AddRow(new object[] { "5", "radbutton", "单选", "radbutton", "radbutton.svg", 0, 0, "", "", "", "2024-04-28 00:00:40"});
                AddRow(new object[] { "6", "checkBoxList", "多选", "checkBoxList", "checkBoxList.svg", 0, 0, "", "", "", "2024-04-28 00:00:50"});
                AddRow(new object[] { "7", "name", "姓名", "textbox", "name.svg", 0, 0, "", "^[一-龥_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "2024-04-28 00:01:00"});
                AddRow(new object[] { "8", "address", "地址", "muiltTextbox", "address.svg", 0, 0, "", "^[^\'\'\"\"]*$", "不能输入单引号 及双引号", "2024-04-28 00:01:10"});
                AddRow(new object[] { "9", "telephone", "电话", "textbox", "telephone.svg", 0, 0, "", "(^\\d+[\\-]\\d{5,11}$)|(^\\d{11}$)", "非法的手机号或固定电话号码", "2024-04-28 00:01:20"});
                AddRow(new object[] { "10", "mail", "邮箱", "textbox", "mail.svg", 0, 0, "", "^[\\-_\\w]{1,}@[\\w]{1,}\\.[\\-_\\w\\.]+$", "邮箱格式非法", "2024-04-28 00:01:30"});
                AddRow(new object[] { "11", "summary", "说明", "muiltTextbox", "summary.svg", 0, 0, "", "^[^\'\']*$", "不能输入单引号", "2024-04-28 00:01:40"});
                AddRow(new object[] { "12", "NO", "编号", "textbox", "no.svg", 0, 0, "", "^[_\\-0-9a-zA-Z]+$", "仅支持字母、数字及\"-_\"", "2024-04-28 00:01:50"});
                AddRow(new object[] { "13", "decimal", "小数", "textbox", "decimal.svg", 0, 0, "", "(^\\-?[\\d]+$)|(^\\-?[\\d]+\\.[\\d]+$)", "非法的小数格式", "2024-04-28 00:02:00"});
                AddRow(new object[] { "14", "date", "日期", "datePicker", "date.svg", 0, 0, "", "", "", "2024-04-28 00:02:10"});
                AddRow(new object[] { "15", "time", "时间", "timePicker", "time.svg", 0, 0, "", "", "", "2024-04-28 00:02:20"});
                AddRow(new object[] { "16", "datetime", "日期时间", "dateTimePicker", "datetime.svg", 0, 0, "", "", "", "2024-04-28 00:02:30"});
                AddRow(new object[] { "17", "money", "货币", "textbox", "money.svg", 0, 0, "", "(^\\-?[\\d]+$)|(^\\-?[\\d]+\\.[\\d]+$)", "非法的金额", "2024-04-28 00:02:40"});
                AddRow(new object[] { "18", "slider", "滑块", "slider", "slider.svg", 0, 0, "", "", "", "2024-04-28 00:02:50"});
                summary = null;

            }
            catch (System.Exception e)
            {
                StringBuilder tmpMessage = new StringBuilder(string.Format("库 {0} 中数据表 {1} 初始化出错", this.KuName, this.SheetName));
                if (e is System.Data.SqlClient.SqlException)
                {
                    tmpMessage.Append(",来自sql server的错误:");
                }
                tmpMessage.Append(" " + e.Message);
                throw new KuInitException(tmpMessage.ToString());
            }
        }

        public void AssembleFieldRefrence()
        {
        }

        private void AddRow(object[] f_CellValue)
        {
            var tmpNewRow = new Row();
            tmpNewRow.AddCell(Fields["iD"], f_CellValue[0]);
            tmpNewRow.AddCell(Fields["name"], f_CellValue[1]);
            tmpNewRow.AddCell(Fields["summary"], f_CellValue[2]);
            tmpNewRow.AddCell(Fields["ctrType"], f_CellValue[3]);
            tmpNewRow.AddCell(Fields["ico"], f_CellValue[4]);
            tmpNewRow.AddCell(Fields["min"], f_CellValue[5]);
            tmpNewRow.AddCell(Fields["max"], f_CellValue[6]);
            tmpNewRow.AddCell(Fields["default2"], f_CellValue[7]);
            tmpNewRow.AddCell(Fields["reg"], f_CellValue[8]);
            tmpNewRow.AddCell(Fields["regMsg"], f_CellValue[9]);
            tmpNewRow.AddCell(Fields["createDt"], f_CellValue[10]);
            this.Rows.Add(tmpNewRow);

        }
    }
}
