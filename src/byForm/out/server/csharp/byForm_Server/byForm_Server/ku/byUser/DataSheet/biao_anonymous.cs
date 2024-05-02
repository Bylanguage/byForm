using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.byUser.DataSheet
{
    public class biao_anonymous : byForm_Server.ku.by.Object.table, byForm_Server.ku.by.ToolClass.IBaseDataSheet
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
            string[] tmpColumns = { "iD", "userID", "regDt", "iP" };
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            string[] tmpColumns = { "iD", "userID", "regDt", "iP" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            string[] tmpColumns = { "iD", "userID", "regDt", "iP" };
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
            string[] tmpColumns = { "iD", "userID", "regDt", "iP" };
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            string[] tmpColumns = { "userID", "regDt", "iP" };
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            string[] tmpColumns = { "userID", "regDt", "iP" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            string[] tmpColumns = { "userID", "regDt", "iP" };
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
            string[] tmpColumns = { "userID", "regDt", "iP" };
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["anonymous"];
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

        public biao_anonymous()
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
                KuName = "byUser";
                this.SheetName = "anonymous";
                DataSheet = this;
                tableType = by.Enum.TableType.data;
                IdentityName = "byUser.anonymous";

                VerifyDic.Add("iD", new Dictionary<ku.by.Enum.attribute, string>());
                bool iD_notNull = true;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.notNull, iD_notNull.ToString());
                VerifyDic.Add("userID", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("regDt", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("iP", new Dictionary<ku.by.Enum.attribute, string>());
                FieldDic.Add("iD", new Field(this.KuName, this.SheetName, "iD", ku.DataTypeEnum.String));
                ComponentDic.Add("iID", this.FieldDic["iD"]);
                Fields.Add("iD", new field(this.FieldDic["iD"], "session ID"));
                FieldDic.Add("userID", new Field(this.KuName, this.SheetName, "userID", ku.DataTypeEnum.String));
                ComponentDic.Add("iUserID", this.FieldDic["userID"]);
                Fields.Add("userID", new field(this.FieldDic["userID"], "用户ID"));
                FieldDic.Add("regDt", new Field(this.KuName, this.SheetName, "regDt", ku.DataTypeEnum.Datetime));
                ComponentDic.Add("iRegDt", this.FieldDic["regDt"]);
                Fields.Add("regDt", new field(this.FieldDic["regDt"], "注册日期"));
                FieldDic.Add("iP", new Field(this.KuName, this.SheetName, "iP", ku.DataTypeEnum.String));
                ComponentDic.Add("iIP", this.FieldDic["iP"]);
                Fields.Add("iP", new field(this.FieldDic["iP"], "ip地址"));
                SourceDic.Add("iD", new by.ToolClass.Source(this, "equal",  FieldDic["iD"]));
                SourceDic.Add("userID", new by.ToolClass.Source(this, "equal",  FieldDic["userID"]));
                SourceDic.Add("regDt", new by.ToolClass.Source(this, "equal",  FieldDic["regDt"]));
                SourceDic.Add("iP", new by.ToolClass.Source(this, "equal",  FieldDic["iP"]));
                FlowDic.Add("insert", flow_insert);
                RowFlowDic.Add("insert", FlowString_insert);
                RowsFlowDic.Add("insert", FlowString_insert);
                RowFlowInTranDic.Add("insert", FlowStringInTran_insert);
                RowsFlowInTranDic.Add("insert", FlowStringInTran_insert);
                FlowDic["insert"].Add(SourceDic["iD"]);
                FlowDic["insert"].Add(SourceDic["userID"]);
                FlowDic["insert"].Add(SourceDic["regDt"]);
                FlowDic["insert"].Add(SourceDic["iP"]);
                FlowDic.Add("update", flow_update);
                RowFlowDic.Add("update", FlowString_update);
                RowsFlowDic.Add("update", FlowString_update);
                RowFlowInTranDic.Add("update", FlowStringInTran_update);
                RowsFlowInTranDic.Add("update", FlowStringInTran_update);
                FlowDic["update"].Add(SourceDic["userID"]);
                FlowDic["update"].Add(SourceDic["regDt"]);
                FlowDic["update"].Add(SourceDic["iP"]);
                FlowDic.Add("delete", flow_delete);
                RowFlowDic.Add("delete", FlowString_delete);
                RowsFlowDic.Add("delete", FlowString_delete);
                RowFlowInTranDic.Add("delete", FlowStringInTran_delete);
                RowsFlowInTranDic.Add("delete", FlowStringInTran_delete);
                FlowDic["delete"].Add(SourceDic["iD"]);
                FlowDic.Add("select", flow_select);
                FlowDic["select"].Add(SourceDic["iD"]);
                FlowDic["select"].Add(SourceDic["userID"]);
                FlowDic["select"].Add(SourceDic["regDt"]);
                FlowDic["select"].Add(SourceDic["iP"]);
                FlowDic.Add("popup", flow_popup);
                FlowDic["popup"].Add(SourceDic["iD"]);
                FlowDic["popup"].Add(SourceDic["iP"]);
                PrimaryKeyList.Add(this.FieldDic["iD"]);
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
            FieldDic["userID"].ReferenceField = Root.GetInstance()["byUser"]["user"].FieldDic["ID"];

        }
    }
}
