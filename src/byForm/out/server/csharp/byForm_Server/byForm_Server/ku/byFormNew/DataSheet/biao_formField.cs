using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.byFormNew.DataSheet
{
    public class biao_formField : byForm_Server.ku.by.Object.table, byForm_Server.ku.by.ToolClass.IBaseDataSheet
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
            string[] tmpColumns = { "iD", "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "summary", "order", "notNull" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            string[] tmpColumns = { "iD", "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "summary", "order", "notNull" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            string[] tmpColumns = { "iD", "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "summary", "order", "notNull" };
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
            string[] tmpColumns = { "iD", "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "summary", "order", "notNull" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            string[] tmpColumns = { "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "order", "notNull" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            string[] tmpColumns = { "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "order", "notNull" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            string[] tmpColumns = { "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "order", "notNull" };
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
            string[] tmpColumns = { "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "order", "notNull" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            string[] tmpColumns = { "iD", "summary" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            string[] tmpColumns = { "iD", "summary" };
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
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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
            string[] tmpColumns = { "iD", "summary" };
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
            string[] tmpColumns = { "iD", "summary" };
            var tmpDataSheet = Root.GetInstance().KuDic["byFormNew"].DataSheetDic["formField"];
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

        public biao_formField()
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
                this.SheetName = "formField";
                DataSheet = this;
                tableType = by.Enum.TableType.data;
                IdentityName = "byForm.formField";

                VerifyDic.Add("iD", new Dictionary<ku.by.Enum.attribute, string>());
                bool iD_notNull = true;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.notNull, iD_notNull.ToString());
                int iD_max = 32;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.max, iD_max.ToString());
                VerifyDic.Add("form", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fieldNO", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fieldName", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fieldType", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fieldCtrl", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("selectValue", new Dictionary<ku.by.Enum.attribute, string>());
                int selectValue_max = 1024;
                VerifyDic["selectValue"].Add(ku.by.Enum.attribute.max, selectValue_max.ToString());
                VerifyDic.Add("fieldMin", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fieldMax", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fieldReg", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fieldRegMsg", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fieldDefault", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("order", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("notNull", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("vDataValue", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("userID", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("summary", new Dictionary<ku.by.Enum.attribute, string>());
                int summary_max = 256;
                VerifyDic["summary"].Add(ku.by.Enum.attribute.max, summary_max.ToString());
                FieldDic.Add("iD", new Field(this.KuName, this.SheetName, "iD", ku.DataTypeEnum.String));
                ComponentDic.Add("iID", this.FieldDic["iD"]);
                Fields.Add("iD", new field(this.FieldDic["iD"], "编号"));
                FieldDic.Add("form", new Field(this.KuName, this.SheetName, "form", ku.DataTypeEnum.String));
                ComponentDic.Add("iFormID", this.FieldDic["form"]);
                Fields.Add("form", new field(this.FieldDic["form"], "表单ID"));
                FieldDic.Add("fieldNO", new Field(this.KuName, this.SheetName, "fieldNO", ku.DataTypeEnum.String));
                ComponentDic.Add("iFieldNO", this.FieldDic["fieldNO"]);
                Fields.Add("fieldNO", new field(this.FieldDic["fieldNO"], "系统自动编号"));
                FieldDic.Add("fieldName", new Field(this.KuName, this.SheetName, "fieldName", ku.DataTypeEnum.String));
                ComponentDic.Add("iFieldName", this.FieldDic["fieldName"]);
                Fields.Add("fieldName", new field(this.FieldDic["fieldName"], "字段名"));
                FieldDic.Add("fieldType", new Field(this.KuName, this.SheetName, "fieldType", ku.DataTypeEnum.String));
                ComponentDic.Add("iFieldType", this.FieldDic["fieldType"]);
                Fields.Add("fieldType", new field(this.FieldDic["fieldType"], "字段类型，int string"));
                FieldDic.Add("fieldCtrl", new Field(this.KuName, this.SheetName, "fieldCtrl", typeof(ku.byForm.Enum.ctrType)));
                ComponentDic.Add("iFieldCtrl", this.FieldDic["fieldCtrl"]);
                Fields.Add("fieldCtrl", new field(this.FieldDic["fieldCtrl"], "显示为文本框、下拉框、单选、多选"));
                FieldDic.Add("selectValue", new Field(this.KuName, this.SheetName, "selectValue", ku.DataTypeEnum.String));
                ComponentDic.Add("iSelectValue", this.FieldDic["selectValue"]);
                Fields.Add("selectValue", new field(this.FieldDic["selectValue"], "单选、多选、下拉列表值"));
                FieldDic.Add("fieldMin", new Field(this.KuName, this.SheetName, "fieldMin", ku.DataTypeEnum.Int));
                ComponentDic.Add("iFieldMin", this.FieldDic["fieldMin"]);
                Fields.Add("fieldMin", new field(this.FieldDic["fieldMin"], "字段最小值"));
                FieldDic.Add("fieldMax", new Field(this.KuName, this.SheetName, "fieldMax", ku.DataTypeEnum.Int));
                ComponentDic.Add("iFieldMax", this.FieldDic["fieldMax"]);
                Fields.Add("fieldMax", new field(this.FieldDic["fieldMax"], "字段最大值，最大值为 4000即表的最大长度 "));
                FieldDic.Add("fieldReg", new Field(this.KuName, this.SheetName, "fieldReg", ku.DataTypeEnum.String));
                ComponentDic.Add("iFieldReg", this.FieldDic["fieldReg"]);
                Fields.Add("fieldReg", new field(this.FieldDic["fieldReg"], "正则验证"));
                FieldDic.Add("fieldRegMsg", new Field(this.KuName, this.SheetName, "fieldRegMsg", ku.DataTypeEnum.String));
                ComponentDic.Add("iFieldRegMsg", this.FieldDic["fieldRegMsg"]);
                Fields.Add("fieldRegMsg", new field(this.FieldDic["fieldRegMsg"], "正则验证提示消息文本"));
                FieldDic.Add("fieldDefault", new Field(this.KuName, this.SheetName, "fieldDefault", ku.DataTypeEnum.String));
                ComponentDic.Add("iFieldDefault", this.FieldDic["fieldDefault"]);
                Fields.Add("fieldDefault", new field(this.FieldDic["fieldDefault"], "默认值"));
                FieldDic.Add("order", new Field(this.KuName, this.SheetName, "order", ku.DataTypeEnum.Int));
                ComponentDic.Add("iOrder", this.FieldDic["order"]);
                Fields.Add("order", new field(this.FieldDic["order"], "排序"));
                FieldDic.Add("notNull", new Field(this.KuName, this.SheetName, "notNull", ku.DataTypeEnum.Bool));
                ComponentDic.Add("iNotNull", this.FieldDic["notNull"]);
                Fields.Add("notNull", new field(this.FieldDic["notNull"], "必填,true=必填"));
                FieldDic.Add("vDataValue", new Field(this.KuName, this.SheetName, "vDataValue", ku.DataTypeEnum.Int));
                ComponentDic.Add("iVDataValue", this.FieldDic["vDataValue"]);
                Fields.Add("vDataValue", new field(this.FieldDic["vDataValue"], "数据保存的位置表(vData)ID"));
                FieldDic.Add("userID", new Field(this.KuName, this.SheetName, "userID", ku.DataTypeEnum.String));
                ComponentDic.Add("iUserID", this.FieldDic["userID"]);
                Fields.Add("userID", new field(this.FieldDic["userID"], "用户ID"));
                FieldDic.Add("summary", new Field(this.KuName, this.SheetName, "summary", ku.DataTypeEnum.String));
                ComponentDic.Add("iSummary", this.FieldDic["summary"]);
                Fields.Add("summary", new field(this.FieldDic["summary"], "说明"));
                SourceDic.Add("iD", new by.ToolClass.Source(this, "equal",  FieldDic["iD"]));
                SourceDic.Add("form", new by.ToolClass.Source(this, "equal",  FieldDic["form"]));
                SourceDic.Add("fieldNO", new by.ToolClass.Source(this, "equal",  FieldDic["fieldNO"]));
                SourceDic.Add("fieldName", new by.ToolClass.Source(this, "equal",  FieldDic["fieldName"]));
                SourceDic.Add("fieldType", new by.ToolClass.Source(this, "equal",  FieldDic["fieldType"]));
                SourceDic.Add("fieldCtrl", new by.ToolClass.Source(this, "equal",  FieldDic["fieldCtrl"]));
                SourceDic.Add("selectValue", new by.ToolClass.Source(this, "equal",  FieldDic["selectValue"]));
                SourceDic.Add("fieldMin", new by.ToolClass.Source(this, "equal",  FieldDic["fieldMin"]));
                SourceDic.Add("fieldMax", new by.ToolClass.Source(this, "equal",  FieldDic["fieldMax"]));
                SourceDic.Add("fieldReg", new by.ToolClass.Source(this, "equal",  FieldDic["fieldReg"]));
                SourceDic.Add("fieldRegMsg", new by.ToolClass.Source(this, "equal",  FieldDic["fieldRegMsg"]));
                SourceDic.Add("fieldDefault", new by.ToolClass.Source(this, "equal",  FieldDic["fieldDefault"]));
                SourceDic.Add("vDataValue", new by.ToolClass.Source(this, "equal",  FieldDic["vDataValue"]));
                SourceDic.Add("userID", new by.ToolClass.Source(this, "equal",  FieldDic["userID"]));
                SourceDic.Add("summary", new by.ToolClass.Source(this, "equal",  FieldDic["summary"]));
                SourceDic.Add("order", new by.ToolClass.Source(this, "equal",  FieldDic["order"]));
                SourceDic.Add("notNull", new by.ToolClass.Source(this, "equal",  FieldDic["notNull"]));
                FlowDic.Add("insert", flow_insert);
                RowFlowDic.Add("insert", FlowString_insert);
                RowsFlowDic.Add("insert", FlowString_insert);
                RowFlowInTranDic.Add("insert", FlowStringInTran_insert);
                RowsFlowInTranDic.Add("insert", FlowStringInTran_insert);
                FlowDic["insert"].Add(SourceDic["iD"]);
                FlowDic["insert"].Add(SourceDic["fieldNO"]);
                FlowDic["insert"].Add(SourceDic["fieldName"]);
                FlowDic["insert"].Add(SourceDic["fieldType"]);
                FlowDic["insert"].Add(SourceDic["fieldCtrl"]);
                FlowDic["insert"].Add(SourceDic["selectValue"]);
                FlowDic["insert"].Add(SourceDic["fieldMin"]);
                FlowDic["insert"].Add(SourceDic["fieldMax"]);
                FlowDic["insert"].Add(SourceDic["fieldReg"]);
                FlowDic["insert"].Add(SourceDic["fieldRegMsg"]);
                FlowDic["insert"].Add(SourceDic["fieldDefault"]);
                FlowDic["insert"].Add(SourceDic["vDataValue"]);
                FlowDic["insert"].Add(SourceDic["form"]);
                FlowDic["insert"].Add(SourceDic["userID"]);
                FlowDic["insert"].Add(SourceDic["summary"]);
                FlowDic["insert"].Add(SourceDic["order"]);
                FlowDic["insert"].Add(SourceDic["notNull"]);
                FlowDic.Add("update", flow_update);
                RowFlowDic.Add("update", FlowString_update);
                RowsFlowDic.Add("update", FlowString_update);
                RowFlowInTranDic.Add("update", FlowStringInTran_update);
                RowsFlowInTranDic.Add("update", FlowStringInTran_update);
                FlowDic["update"].Add(SourceDic["fieldNO"]);
                FlowDic["update"].Add(SourceDic["fieldName"]);
                FlowDic["update"].Add(SourceDic["fieldType"]);
                FlowDic["update"].Add(SourceDic["fieldCtrl"]);
                FlowDic["update"].Add(SourceDic["selectValue"]);
                FlowDic["update"].Add(SourceDic["fieldMin"]);
                FlowDic["update"].Add(SourceDic["fieldMax"]);
                FlowDic["update"].Add(SourceDic["fieldReg"]);
                FlowDic["update"].Add(SourceDic["fieldRegMsg"]);
                FlowDic["update"].Add(SourceDic["fieldDefault"]);
                FlowDic["update"].Add(SourceDic["vDataValue"]);
                FlowDic["update"].Add(SourceDic["form"]);
                FlowDic["update"].Add(SourceDic["userID"]);
                FlowDic["update"].Add(SourceDic["order"]);
                FlowDic["update"].Add(SourceDic["notNull"]);
                FlowDic.Add("delete", flow_delete);
                RowFlowDic.Add("delete", FlowString_delete);
                RowsFlowDic.Add("delete", FlowString_delete);
                RowFlowInTranDic.Add("delete", FlowStringInTran_delete);
                RowsFlowInTranDic.Add("delete", FlowStringInTran_delete);
                FlowDic["delete"].Add(SourceDic["iD"]);
                FlowDic["delete"].Add(SourceDic["summary"]);
                FlowDic.Add("select", flow_select);
                FlowDic["select"].Add(SourceDic["iD"]);
                FlowDic["select"].Add(SourceDic["fieldNO"]);
                FlowDic["select"].Add(SourceDic["fieldName"]);
                FlowDic["select"].Add(SourceDic["fieldType"]);
                FlowDic["select"].Add(SourceDic["fieldCtrl"]);
                FlowDic["select"].Add(SourceDic["selectValue"]);
                FlowDic["select"].Add(SourceDic["fieldMin"]);
                FlowDic["select"].Add(SourceDic["fieldMax"]);
                FlowDic["select"].Add(SourceDic["fieldReg"]);
                FlowDic["select"].Add(SourceDic["fieldRegMsg"]);
                FlowDic["select"].Add(SourceDic["fieldDefault"]);
                FlowDic["select"].Add(SourceDic["vDataValue"]);
                FlowDic["select"].Add(SourceDic["form"]);
                FlowDic["select"].Add(SourceDic["userID"]);
                FlowDic["select"].Add(SourceDic["summary"]);
                FlowDic["select"].Add(SourceDic["order"]);
                FlowDic["select"].Add(SourceDic["notNull"]);
                FlowDic.Add("popup", flow_popup);
                FlowDic["popup"].Add(SourceDic["iD"]);
                FlowDic["popup"].Add(SourceDic["form"]);
                FlowDic["popup"].Add(SourceDic["userID"]);
                FlowDic["popup"].Add(SourceDic["summary"]);
                FlowDic["popup"].Add(SourceDic["order"]);
                FlowDic["popup"].Add(SourceDic["notNull"]);
                PrimaryKeyList.Add(this.FieldDic["iD"]);
                AddRow(new object[] { "sign-0-0", "form-sign-0", "0", "姓名", "string", "textbox", "", 0, 64, "^[一-龥_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "", 0, true, 0, "", "姓名"});
                AddRow(new object[] { "sign-0-1", "form-sign-0", "1", "性别", "string", "radbutton", "男\n女", 0, 64, "", "", "", 0, true, 0, "", "单选"});
                AddRow(new object[] { "sign-0-2", "form-sign-0", "2", "年龄", "int", "textbox", "", 0, 120, "^[1-9]\\d*$", "年龄应当为正整数", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "sign-0-3", "form-sign-0", "3", "手机", "string", "textbox", "", 0, 64, "(^\\d{11}$)", "非法的手机号码", "", 0, true, 0, "", "电话"});
                AddRow(new object[] { "sign-0-4", "form-sign-0", "4", "邮箱", "string", "textbox", "", 0, 64, "^[\\-_\\w]{1,}@[\\w]{1,}\\.[\\-_\\w\\.]+$", "邮箱格式非法", "", 0, true, 0, "", "邮箱"});
                AddRow(new object[] { "sign-0-5", "form-sign-0", "5", "身份证号码", "string", "textbox", "", 18, 18, "^[1-9]\\d{5}(19|20)\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])\\d{3}(\\d|X|x)$", "身份证号格式错误，请输入中国18位身份证号，最后位x不区分大小写", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "register-0-0", "form-register-0", "0", "姓名", "string", "textbox", "", 0, 64, "^[一-龥_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "register-0-1", "form-register-0", "1", "性别", "string", "radbutton", "男\n女", 0, 64, "", "", "", 0, true, 0, "", "单选"});
                AddRow(new object[] { "register-0-2", "form-register-0", "2", "年龄", "int", "textbox", "", 0, 120, "^[1-9]\\d*$", "年龄应当为正整数", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "register-0-3", "form-register-0", "3", "手机", "string", "textbox", "", 0, 64, "(^\\d{11}$)", "非法的手机号码", "", 0, true, 0, "", "电话"});
                AddRow(new object[] { "register-0-4", "form-register-0", "4", "邮箱", "string", "textbox", "", 0, 64, "^[\\-_\\w]{1,}@[\\w]{1,}\\.[\\-_\\w\\.]+$", "邮箱格式非法", "", 0, true, 0, "", "邮箱"});
                AddRow(new object[] { "collect-0-0", "form-collect-0", "0", "反馈人姓名", "string", "textbox", "", 0, 64, "^[^\"\"\"\"]*$", "不能输入单引号 及双引号", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "collect-0-1", "form-collect-0", "1", "联系电话", "string", "textbox", "", 0, 64, "(^\\d+[\\-]\\d{5,11}$)|(^\\d{11}$)", "非法的手机号或固定电话号码", "", 0, false, 0, "", "电话"});
                AddRow(new object[] { "collect-0-2", "form-collect-0", "2", "反馈内容", "string", "muiltTextbox", "", 0, 1000, "^[^\"\"]*$", "不能输入单引号", "", 0, true, 0, "", "多行文本"});
                AddRow(new object[] { "appointment-0-0", "form-appointment-0", "0", "预约人姓名", "string", "textbox", "", 0, 64, "^[一-龥_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "", 0, true, 0, "", "姓名"});
                AddRow(new object[] { "appointment-0-1", "form-appointment-0", "1", "预约人部门", "string", "dropdownList", "开发部\n研发部\n销售部\n人事部", 0, 64, "", "", "", 0, true, 0, "", "下拉"});
                AddRow(new object[] { "appointment-0-2", "form-appointment-0", "2", "会议主题", "string", "textbox", "", 0, 64, "^[^\"\"\"\"]*$", "不能输入单引号 及双引号", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "appointment-0-3", "form-appointment-0", "3", "会议开始时间", "string", "dateTimePicker", "", 0, 64, "", "", "", 0, true, 0, "", "日期时间"});
                AddRow(new object[] { "appointment-0-4", "form-appointment-0", "4", "会议持续时间", "string", "dropdownList", "30分钟\n1小时\n2小时\n3小时", 0, 64, "", "", "", 0, true, 0, "", "下拉"});
                AddRow(new object[] { "appointment-0-5", "form-appointment-0", "5", "参会人数", "int", "textbox", "", 1, 3000, "^[1-9]\\d*$", "请输入正整数", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "appointment-0-6", "form-appointment-0", "6", "备注信息", "string", "muiltTextbox", "", 0, 64, "^[^\"\"]*$", "不能输入单引号", "", 0, true, 0, "", "多行文本"});
                AddRow(new object[] { "order-0-0", "form-order-0", "0", "客户姓名", "string", "textbox", "", 0, 64, "^[一-龥_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "", 0, true, 0, "", "姓名"});
                AddRow(new object[] { "order-0-1", "form-order-0", "1", "联系电话", "string", "textbox", "", 0, 64, "(^\\d+[\\-]\\d{5,11}$)|(^\\d{11}$)", "非法的手机号或固定电话号码", "", 0, true, 0, "", "电话"});
                AddRow(new object[] { "order-0-2", "form-order-0", "2", "订购产品名称", "string", "dropdownList", "产品A\n产品B\n产品C", 0, 64, "", "", "", 0, true, 0, "", "下拉"});
                AddRow(new object[] { "order-0-3", "form-order-0", "3", "订购数量", "int", "textbox", "", 1, 500000, "^[1-9]\\d*$", "订购数量需要为正整数", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "order-0-4", "form-order-0", "4", "收货地址", "string", "muiltTextbox", "", 0, 64, "^[^\"\"\"\"]*$", "不能输入单引号 及双引号", "", 0, true, 0, "", "地址"});
                AddRow(new object[] { "order-0-5", "form-order-0", "5", "付款方式", "string", "dropdownList", "微信支付\n支付宝\n信用卡", 0, 64, "", "", "", 0, true, 0, "", "下拉"});
                AddRow(new object[] { "statistics-0-0", "form-statistics-0", "0", "姓名", "string", "textbox", "", 0, 64, "^[一-龥_a-zA-Z0-9]+$", "不能输入单引号 及双引号", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "statistics-0-1", "form-statistics-0", "1", "性别", "string", "radbutton", "男\n女", 0, 64, "", "", "", 0, true, 0, "", "单选"});
                AddRow(new object[] { "statistics-0-2", "form-statistics-0", "2", "年龄", "int", "textbox", "", 0, 120, "^[1-9]\\d*$", "年龄应当为正整数", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "statistics-0-3", "form-statistics-0", "3", "身高(cm)", "int", "textbox", "", 50, 250, "^[1-9]\\d*$", "年龄应当为正整数", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "statistics-0-4", "form-statistics-0", "4", "体重(kg,取整数)", "int", "textbox", "", 0, 250, "^[1-9]\\d*$", "体重请取正整数", "", 0, true, 0, "", "单行文本"});
                AddRow(new object[] { "statistics-0-5", "form-statistics-0", "5", "健康状况", "string", "dropdownList", "健康\n良好\n不良", 0, 64, "", "", "", 0, true, 0, "", "下拉"});
                AddRow(new object[] { "statistics-0-6", "form-statistics-0", "6", "运动频率 ", "string", "dropdownList", "每天\n经常\n偶尔\n从不", 0, 64, "", "", "", 0, true, 0, "", "下拉"});
                AddRow(new object[] { "statistics-0-7", "form-statistics-0", "7", "球类爱好", "string", "checkBoxList", "篮球\n足球\n羽毛球\n乒乓球\n排球\n棒球\n台球", -1, -1, "", "", "", 0, true, 0, "", "多选"});
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
            FieldDic["form"].ReferenceField = Root.GetInstance()["byFormNew"]["form"].FieldDic["iD"];

        }

        private void AddRow(object[] f_CellValue)
        {
            var tmpNewRow = new Row();
            tmpNewRow.AddCell(Fields["iD"], f_CellValue[0]);
            tmpNewRow.AddCell(Fields["form"], f_CellValue[1]);
            tmpNewRow.AddCell(Fields["fieldNO"], f_CellValue[2]);
            tmpNewRow.AddCell(Fields["fieldName"], f_CellValue[3]);
            tmpNewRow.AddCell(Fields["fieldType"], f_CellValue[4]);
            tmpNewRow.AddCell(Fields["fieldCtrl"], f_CellValue[5]);
            tmpNewRow.AddCell(Fields["selectValue"], f_CellValue[6]);
            tmpNewRow.AddCell(Fields["fieldMin"], f_CellValue[7]);
            tmpNewRow.AddCell(Fields["fieldMax"], f_CellValue[8]);
            tmpNewRow.AddCell(Fields["fieldReg"], f_CellValue[9]);
            tmpNewRow.AddCell(Fields["fieldRegMsg"], f_CellValue[10]);
            tmpNewRow.AddCell(Fields["fieldDefault"], f_CellValue[11]);
            tmpNewRow.AddCell(Fields["order"], f_CellValue[12]);
            tmpNewRow.AddCell(Fields["notNull"], f_CellValue[13]);
            tmpNewRow.AddCell(Fields["vDataValue"], f_CellValue[14]);
            tmpNewRow.AddCell(Fields["userID"], f_CellValue[15]);
            tmpNewRow.AddCell(Fields["summary"], f_CellValue[16]);
            this.Rows.Add(tmpNewRow);

        }
    }
}
