using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.byUser.DataSheet
{
    public class biao_log : byForm_Server.ku.by.Object.table, byForm_Server.ku.by.ToolClass.IBaseDataSheet
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
            string[] tmpColumns = { "iD", "sceneType", "userID", "userName", "state", "ip", "summary", "dt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            string[] tmpColumns = { "iD", "sceneType", "userID", "userName", "state", "ip", "summary", "dt" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            string[] tmpColumns = { "iD", "sceneType", "userID", "userName", "state", "ip", "summary", "dt" };
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
            string[] tmpColumns = { "iD", "sceneType", "userID", "userName", "state", "ip", "summary", "dt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            string[] tmpColumns = { "sceneType", "userID", "userName", "state", "ip", "summary", "dt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            string[] tmpColumns = { "sceneType", "userID", "userName", "state", "ip", "summary", "dt" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            string[] tmpColumns = { "sceneType", "userID", "userName", "state", "ip", "summary", "dt" };
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
            string[] tmpColumns = { "sceneType", "userID", "userName", "state", "ip", "summary", "dt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byUser"].DataSheetDic["log"];
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

        public biao_log()
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
                this.SheetName = "log";
                DataSheet = this;
                tableType = by.Enum.TableType.data;
                IdentityName = "byLog.log";

                VerifyDic.Add("iD", new Dictionary<ku.by.Enum.attribute, string>());
                bool iD_notNull = true;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.notNull, iD_notNull.ToString());
                VerifyDic.Add("sceneType", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("userID", new Dictionary<ku.by.Enum.attribute, string>());
                bool userID_notNull = true;
                VerifyDic["userID"].Add(ku.by.Enum.attribute.notNull, userID_notNull.ToString());
                VerifyDic.Add("userName", new Dictionary<ku.by.Enum.attribute, string>());
                bool userName_notNull = true;
                VerifyDic["userName"].Add(ku.by.Enum.attribute.notNull, userName_notNull.ToString());
                VerifyDic.Add("state", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("ip", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("summary", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("dt", new Dictionary<ku.by.Enum.attribute, string>());
                FieldDic.Add("iD", new Field(this.KuName, this.SheetName, "iD", ku.DataTypeEnum.String));
                ComponentDic.Add("iID", this.FieldDic["iD"]);
                Fields.Add("iD", new field(this.FieldDic["iD"], "日志编号"));
                FieldDic.Add("sceneType", new Field(this.KuName, this.SheetName, "sceneType", typeof(ku.by.Enum.SceneType)));
                ComponentDic.Add("iSceneType", this.FieldDic["sceneType"]);
                Fields.Add("sceneType", new field(this.FieldDic["sceneType"], "日志产生的场景"));
                FieldDic.Add("userID", new Field(this.KuName, this.SheetName, "userID", ku.DataTypeEnum.String));
                ComponentDic.Add("iUserID", this.FieldDic["userID"]);
                Fields.Add("userID", new field(this.FieldDic["userID"], "用户ID"));
                FieldDic.Add("userName", new Field(this.KuName, this.SheetName, "userName", ku.DataTypeEnum.String));
                ComponentDic.Add("iUserName", this.FieldDic["userName"]);
                Fields.Add("userName", new field(this.FieldDic["userName"], "用户名"));
                FieldDic.Add("state", new Field(this.KuName, this.SheetName, "state", typeof(ku.byLog.Enum.logState)));
                ComponentDic.Add("iState", this.FieldDic["state"]);
                Fields.Add("state", new field(this.FieldDic["state"], "日志分类"));
                FieldDic.Add("ip", new Field(this.KuName, this.SheetName, "ip", ku.DataTypeEnum.String));
                ComponentDic.Add("iIp", this.FieldDic["ip"]);
                Fields.Add("ip", new field(this.FieldDic["ip"], "ip地址"));
                FieldDic.Add("summary", new Field(this.KuName, this.SheetName, "summary", ku.DataTypeEnum.String));
                ComponentDic.Add("iSummary", this.FieldDic["summary"]);
                Fields.Add("summary", new field(this.FieldDic["summary"], "说明"));
                FieldDic.Add("dt", new Field(this.KuName, this.SheetName, "dt", ku.DataTypeEnum.Datetime));
                ComponentDic.Add("iDt", this.FieldDic["dt"]);
                Fields.Add("dt", new field(this.FieldDic["dt"], "登录时间"));
                SourceDic.Add("iD", new by.ToolClass.Source(this, "equal",  FieldDic["iD"]));
                SourceDic.Add("sceneType", new by.ToolClass.Source(this, "equal",  FieldDic["sceneType"]));
                SourceDic.Add("userID", new by.ToolClass.Source(this, "equal",  FieldDic["userID"]));
                SourceDic.Add("userName", new by.ToolClass.Source(this, "equal",  FieldDic["userName"]));
                SourceDic.Add("state", new by.ToolClass.Source(this, "equal",  FieldDic["state"]));
                SourceDic.Add("ip", new by.ToolClass.Source(this, "equal",  FieldDic["ip"]));
                SourceDic.Add("summary", new by.ToolClass.Source(this, "equal",  FieldDic["summary"]));
                SourceDic.Add("dt", new by.ToolClass.Source(this, "equal",  FieldDic["dt"]));
                FlowDic.Add("insert", flow_insert);
                RowFlowDic.Add("insert", FlowString_insert);
                RowsFlowDic.Add("insert", FlowString_insert);
                RowFlowInTranDic.Add("insert", FlowStringInTran_insert);
                RowsFlowInTranDic.Add("insert", FlowStringInTran_insert);
                FlowDic["insert"].Add(SourceDic["iD"]);
                FlowDic["insert"].Add(SourceDic["sceneType"]);
                FlowDic["insert"].Add(SourceDic["userID"]);
                FlowDic["insert"].Add(SourceDic["userName"]);
                FlowDic["insert"].Add(SourceDic["state"]);
                FlowDic["insert"].Add(SourceDic["ip"]);
                FlowDic["insert"].Add(SourceDic["summary"]);
                FlowDic["insert"].Add(SourceDic["dt"]);
                FlowDic.Add("update", flow_update);
                RowFlowDic.Add("update", FlowString_update);
                RowsFlowDic.Add("update", FlowString_update);
                RowFlowInTranDic.Add("update", FlowStringInTran_update);
                RowsFlowInTranDic.Add("update", FlowStringInTran_update);
                FlowDic["update"].Add(SourceDic["sceneType"]);
                FlowDic["update"].Add(SourceDic["userID"]);
                FlowDic["update"].Add(SourceDic["userName"]);
                FlowDic["update"].Add(SourceDic["state"]);
                FlowDic["update"].Add(SourceDic["ip"]);
                FlowDic["update"].Add(SourceDic["summary"]);
                FlowDic["update"].Add(SourceDic["dt"]);
                FlowDic.Add("delete", flow_delete);
                RowFlowDic.Add("delete", FlowString_delete);
                RowsFlowDic.Add("delete", FlowString_delete);
                RowFlowInTranDic.Add("delete", FlowStringInTran_delete);
                RowsFlowInTranDic.Add("delete", FlowStringInTran_delete);
                FlowDic["delete"].Add(SourceDic["iD"]);
                FlowDic.Add("select", flow_select);
                FlowDic["select"].Add(SourceDic["iD"]);
                FlowDic["select"].Add(SourceDic["sceneType"]);
                FlowDic["select"].Add(SourceDic["userID"]);
                FlowDic["select"].Add(SourceDic["userName"]);
                FlowDic["select"].Add(SourceDic["state"]);
                FlowDic["select"].Add(SourceDic["ip"]);
                FlowDic["select"].Add(SourceDic["summary"]);
                FlowDic["select"].Add(SourceDic["dt"]);
                FlowDic.Add("popup", flow_popup);
                FlowDic["popup"].Add(SourceDic["iD"]);
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
