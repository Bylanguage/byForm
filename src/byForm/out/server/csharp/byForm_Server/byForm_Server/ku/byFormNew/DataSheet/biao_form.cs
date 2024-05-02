using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.byFormNew.DataSheet
{
    public class biao_form : byForm_Server.ku.by.Object.table, byForm_Server.ku.by.ToolClass.IBaseDataSheet
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
            string[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            string[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            string[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
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
            string[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            string[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            string[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            string[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
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
            string[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["form"];
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
                case "successMsg":
                    return  SaveInspect.CharactorEscape(Default_successMsg(this));
                case "submitButton":
                    return  SaveInspect.CharactorEscape(Default_submitButton(this));
                default:
                    throw new Exception(string.Format("表 {0} 错误的字段 {1} 默认值调用", this.SheetName, f_FieldName));
            }
        }

        public string Default_successMsg(byForm_Server.ku.by.Object.table f_Table)
        {
            return "谢谢，我们会尽快处理！";
        }

        public string Default_submitButton(byForm_Server.ku.by.Object.table f_Table)
        {
            return "确认提交";
        }

        public biao_form()
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
                this.SheetName = "form";
                DataSheet = this;
                tableType = by.Enum.TableType.data;
                IdentityName = "byForm.form";

                VerifyDic.Add("iD", new Dictionary<ku.by.Enum.attribute, string>());
                bool iD_notNull = true;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.notNull, iD_notNull.ToString());
                int iD_max = 32;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.max, iD_max.ToString());
                VerifyDic.Add("name", new Dictionary<ku.by.Enum.attribute, string>());
                bool name_notNull = true;
                VerifyDic["name"].Add(ku.by.Enum.attribute.notNull, name_notNull.ToString());
                VerifyDic.Add("successMsg", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("submitButton", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("summary", new Dictionary<ku.by.Enum.attribute, string>());
                bool summary_notNull = true;
                VerifyDic["summary"].Add(ku.by.Enum.attribute.notNull, summary_notNull.ToString());
                int summary_max = 256;
                VerifyDic["summary"].Add(ku.by.Enum.attribute.max, summary_max.ToString());
                VerifyDic.Add("userID", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("createDt", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("currentModifyDt", new Dictionary<ku.by.Enum.attribute, string>());
                FieldDic.Add("iD", new Field(this.KuName, this.SheetName, "iD", ku.DataTypeEnum.String));
                ComponentDic.Add("iID", this.FieldDic["iD"]);
                Fields.Add("iD", new field(this.FieldDic["iD"], "编号"));
                FieldDic.Add("name", new Field(this.KuName, this.SheetName, "name", ku.DataTypeEnum.String));
                ComponentDic.Add("iName", this.FieldDic["name"]);
                Fields.Add("name", new field(this.FieldDic["name"], "表单名称"));
                FieldDic.Add("successMsg", new Field(this.KuName, this.SheetName, "successMsg", ku.DataTypeEnum.String));
                DefaultColumnList.Add("successMsg");
                ComponentDic.Add("iSuccessMsg", this.FieldDic["successMsg"]);
                Fields.Add("successMsg", new field(this.FieldDic["successMsg"], "用户保存成功后提示消息"));
                FieldDic.Add("submitButton", new Field(this.KuName, this.SheetName, "submitButton", ku.DataTypeEnum.String));
                DefaultColumnList.Add("submitButton");
                ComponentDic.Add("iSubmitButton", this.FieldDic["submitButton"]);
                Fields.Add("submitButton", new field(this.FieldDic["submitButton"], "提交按钮的文本说明"));
                FieldDic.Add("summary", new Field(this.KuName, this.SheetName, "summary", ku.DataTypeEnum.String));
                ComponentDic.Add("iSummary", this.FieldDic["summary"]);
                Fields.Add("summary", new field(this.FieldDic["summary"], "说明"));
                FieldDic.Add("userID", new Field(this.KuName, this.SheetName, "userID", ku.DataTypeEnum.String));
                ComponentDic.Add("iUserID", this.FieldDic["userID"]);
                Fields.Add("userID", new field(this.FieldDic["userID"], "用户ID"));
                FieldDic.Add("createDt", new Field(this.KuName, this.SheetName, "createDt", ku.DataTypeEnum.Datetime));
                ComponentDic.Add("iCreateDt", this.FieldDic["createDt"]);
                Fields.Add("createDt", new field(this.FieldDic["createDt"], "创建时间"));
                FieldDic.Add("currentModifyDt", new Field(this.KuName, this.SheetName, "currentModifyDt", ku.DataTypeEnum.Datetime));
                ComponentDic.Add("iCurrentModifyDt", this.FieldDic["currentModifyDt"]);
                Fields.Add("currentModifyDt", new field(this.FieldDic["currentModifyDt"], "最后修改时间"));
                SourceDic.Add("iD", new by.ToolClass.Source(this, "equal",  FieldDic["iD"]));
                SourceDic.Add("name", new by.ToolClass.Source(this, "equal",  FieldDic["name"]));
                SourceDic.Add("successMsg", new by.ToolClass.Source(this, "equal",  FieldDic["successMsg"]));
                SourceDic.Add("submitButton", new by.ToolClass.Source(this, "equal",  FieldDic["submitButton"]));
                SourceDic.Add("summary", new by.ToolClass.Source(this, "equal",  FieldDic["summary"]));
                SourceDic.Add("userID", new by.ToolClass.Source(this, "equal",  FieldDic["userID"]));
                SourceDic.Add("createDt", new by.ToolClass.Source(this, "equal",  FieldDic["createDt"]));
                SourceDic.Add("currentModifyDt", new by.ToolClass.Source(this, "equal",  FieldDic["currentModifyDt"]));
                FlowDic.Add("insert", flow_insert);
                RowFlowDic.Add("insert", FlowString_insert);
                RowsFlowDic.Add("insert", FlowString_insert);
                RowFlowInTranDic.Add("insert", FlowStringInTran_insert);
                RowsFlowInTranDic.Add("insert", FlowStringInTran_insert);
                FlowDic["insert"].Add(SourceDic["iD"]);
                FlowDic["insert"].Add(SourceDic["name"]);
                FlowDic["insert"].Add(SourceDic["successMsg"]);
                FlowDic["insert"].Add(SourceDic["submitButton"]);
                FlowDic["insert"].Add(SourceDic["summary"]);
                FlowDic["insert"].Add(SourceDic["userID"]);
                FlowDic["insert"].Add(SourceDic["createDt"]);
                FlowDic["insert"].Add(SourceDic["currentModifyDt"]);
                FlowDic.Add("update", flow_update);
                RowFlowDic.Add("update", FlowString_update);
                RowsFlowDic.Add("update", FlowString_update);
                RowFlowInTranDic.Add("update", FlowStringInTran_update);
                RowsFlowInTranDic.Add("update", FlowStringInTran_update);
                FlowDic["update"].Add(SourceDic["name"]);
                FlowDic["update"].Add(SourceDic["successMsg"]);
                FlowDic["update"].Add(SourceDic["submitButton"]);
                FlowDic["update"].Add(SourceDic["summary"]);
                FlowDic["update"].Add(SourceDic["userID"]);
                FlowDic["update"].Add(SourceDic["currentModifyDt"]);
                FlowDic.Add("delete", flow_delete);
                RowFlowDic.Add("delete", FlowString_delete);
                RowsFlowDic.Add("delete", FlowString_delete);
                RowFlowInTranDic.Add("delete", FlowStringInTran_delete);
                RowsFlowInTranDic.Add("delete", FlowStringInTran_delete);
                FlowDic["delete"].Add(SourceDic["iD"]);
                FlowDic.Add("select", flow_select);
                FlowDic["select"].Add(SourceDic["iD"]);
                FlowDic["select"].Add(SourceDic["name"]);
                FlowDic["select"].Add(SourceDic["successMsg"]);
                FlowDic["select"].Add(SourceDic["submitButton"]);
                FlowDic["select"].Add(SourceDic["summary"]);
                FlowDic["select"].Add(SourceDic["userID"]);
                FlowDic["select"].Add(SourceDic["createDt"]);
                FlowDic["select"].Add(SourceDic["currentModifyDt"]);
                FlowDic.Add("popup", flow_popup);
                FlowDic["popup"].Add(SourceDic["iD"]);
                FlowDic["popup"].Add(SourceDic["name"]);
                PrimaryKeyList.Add(this.FieldDic["iD"]);
                AddRow(new object[] { "form-sign-0", "在线报名", "已收到您的报名信息，我们将在7个工作日内给您反馈！", "确认报名", "", "", "2024-04-28", "2024-04-28"});
                AddRow(new object[] { "form-register-0", "在线登记", "感谢！已收到您的登记信息。", "确认登记", "", "", "2024-04-28", "2024-04-28"});
                AddRow(new object[] { "form-collect-0", "意见反馈", "感谢您的宝贵意见,我们会尽快处理！", "确认提交", "", "", "2024-04-28", "2024-04-28"});
                AddRow(new object[] { "form-appointment-0", "会议预约", "已收到您的预约信息，我们将尽快给您反馈！", "确认预约", "", "", "2024-04-28", "2024-04-28"});
                AddRow(new object[] { "form-order-0", "在线订单", "谢谢,我们会尽快与您联系！", "确认订购", "", "", "2024-04-28", "2024-04-28"});
                AddRow(new object[] { "form-statistics-0", "调查统计", "收到，感谢您的参与", "确认提交", "", "", "2024-04-28", "2024-04-28"});
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

        private void AddRow(object[] f_CellValue)
        {
            var tmpNewRow = new Row();
            tmpNewRow.AddCell(Fields["iD"], f_CellValue[0]);
            tmpNewRow.AddCell(Fields["name"], f_CellValue[1]);
            tmpNewRow.AddCell(Fields["successMsg"], f_CellValue[2]);
            tmpNewRow.AddCell(Fields["submitButton"], f_CellValue[3]);
            tmpNewRow.AddCell(Fields["summary"], f_CellValue[4]);
            tmpNewRow.AddCell(Fields["userID"], f_CellValue[5]);
            tmpNewRow.AddCell(Fields["createDt"], f_CellValue[6]);
            tmpNewRow.AddCell(Fields["currentModifyDt"], f_CellValue[7]);
            this.Rows.Add(tmpNewRow);

        }
    }
}
