using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.byFormNew.DataSheet
{
    public class biao_formTemplate : byForm_Server.ku.by.Object.table, byForm_Server.ku.by.ToolClass.IBaseDataSheet
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

        public string GetFieldDefault(string f_FieldName)
        {
            switch (f_FieldName)
            {
                default:
                    throw new Exception(string.Format("表 {0} 错误的字段 {1} 默认值调用", this.SheetName, f_FieldName));
            }
        }

        public biao_formTemplate()
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
                this.SheetName = "formTemplate";
                DataSheet = this;
                tableType = by.Enum.TableType.data;
                IdentityName = "byForm.formTemplate";

                VerifyDic.Add("ID", new Dictionary<ku.by.Enum.attribute, string>());
                bool ID_notNull = true;
                VerifyDic["ID"].Add(ku.by.Enum.attribute.notNull, ID_notNull.ToString());
                int ID_max = 32;
                VerifyDic["ID"].Add(ku.by.Enum.attribute.max, ID_max.ToString());
                VerifyDic.Add("name", new Dictionary<ku.by.Enum.attribute, string>());
                bool name_notNull = true;
                VerifyDic["name"].Add(ku.by.Enum.attribute.notNull, name_notNull.ToString());
                int name_max = 32;
                VerifyDic["name"].Add(ku.by.Enum.attribute.max, name_max.ToString());
                VerifyDic.Add("formID", new Dictionary<ku.by.Enum.attribute, string>());
                bool formID_notNull = true;
                VerifyDic["formID"].Add(ku.by.Enum.attribute.notNull, formID_notNull.ToString());
                int formID_max = 32;
                VerifyDic["formID"].Add(ku.by.Enum.attribute.max, formID_max.ToString());
                VerifyDic.Add("userID", new Dictionary<ku.by.Enum.attribute, string>());
                FieldDic.Add("ID", new Field(this.KuName, this.SheetName, "ID", ku.DataTypeEnum.String));
                ComponentDic.Add("iID", this.FieldDic["ID"]);
                Fields.Add("ID", new field(this.FieldDic["ID"], "唯一标识"));
                FieldDic.Add("name", new Field(this.KuName, this.SheetName, "name", ku.DataTypeEnum.String));
                ComponentDic.Add("iName", this.FieldDic["name"]);
                Fields.Add("name", new field(this.FieldDic["name"], "名称"));
                FieldDic.Add("formID", new Field(this.KuName, this.SheetName, "formID", ku.DataTypeEnum.String));
                ComponentDic.Add("iFormID", this.FieldDic["formID"]);
                Fields.Add("formID", new field(this.FieldDic["formID"], "对应的表单id"));
                FieldDic.Add("userID", new Field(this.KuName, this.SheetName, "userID", ku.DataTypeEnum.String));
                ComponentDic.Add("iUserID", this.FieldDic["userID"]);
                Fields.Add("userID", new field(this.FieldDic["userID"], "用户ID"));
                PrimaryKeyList.Add(this.FieldDic["ID"]);
                AddRow(new object[] { "template-order-0", "在线订单模板", "form-order-0", ""});
                AddRow(new object[] { "template-collect-0", "意见反馈模板", "form-collect-0", ""});
                AddRow(new object[] { "template-register-0", "在线登记模板", "form-register-0", ""});
                AddRow(new object[] { "template-appointment-0", "会议预约模板", "form-appointment-0", ""});
                AddRow(new object[] { "template-sign-0", "在线登记模板", "form-sign-0", ""});
                AddRow(new object[] { "template-statistics-0", "在线统计模板", "form-statistics-0", ""});
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
            tmpNewRow.AddCell(Fields["ID"], f_CellValue[0]);
            tmpNewRow.AddCell(Fields["name"], f_CellValue[1]);
            tmpNewRow.AddCell(Fields["formID"], f_CellValue[2]);
            tmpNewRow.AddCell(Fields["userID"], f_CellValue[3]);
            this.Rows.Add(tmpNewRow);

        }
    }
}
