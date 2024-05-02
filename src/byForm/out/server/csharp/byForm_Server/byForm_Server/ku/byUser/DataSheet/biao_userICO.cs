using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.byUser.DataSheet
{
    public class biao_userICO : byForm_Server.ku.by.Object.table, byForm_Server.ku.by.ToolClass.IBaseDataSheet
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

        public biao_userICO()
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
                this.SheetName = "userICO";
                DataSheet = this;
                tableType = by.Enum.TableType.data;
                IdentityName = "byUser.userICO";

                VerifyDic.Add("iD", new Dictionary<ku.by.Enum.attribute, string>());
                bool iD_notNull = true;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.notNull, iD_notNull.ToString());
                VerifyDic.Add("icoFile", new Dictionary<ku.by.Enum.attribute, string>());
                int icoFile_max = 5000000;
                VerifyDic["icoFile"].Add(ku.by.Enum.attribute.max, icoFile_max.ToString());
                VerifyDic.Add("uploadDt", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("fileName", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("extendName", new Dictionary<ku.by.Enum.attribute, string>());
                FieldDic.Add("iD", new Field(this.KuName, this.SheetName, "iD", ku.DataTypeEnum.String));
                ComponentDic.Add("iID", this.FieldDic["iD"]);
                Fields.Add("iD", new field(this.FieldDic["iD"], "用户ID"));
                FieldDic.Add("icoFile", new Field(this.KuName, this.SheetName, "icoFile", ku.DataTypeEnum.String));
                ComponentDic.Add("iIcoFile", this.FieldDic["icoFile"]);
                Fields.Add("icoFile", new field(this.FieldDic["icoFile"], "图标文件， < 50k"));
                FieldDic.Add("uploadDt", new Field(this.KuName, this.SheetName, "uploadDt", ku.DataTypeEnum.Datetime));
                ComponentDic.Add("iUploadDt", this.FieldDic["uploadDt"]);
                Fields.Add("uploadDt", new field(this.FieldDic["uploadDt"], "上传日期"));
                FieldDic.Add("fileName", new Field(this.KuName, this.SheetName, "fileName", ku.DataTypeEnum.String));
                ComponentDic.Add("iFileName", this.FieldDic["fileName"]);
                Fields.Add("fileName", new field(this.FieldDic["fileName"], "文件名"));
                FieldDic.Add("extendName", new Field(this.KuName, this.SheetName, "extendName", ku.DataTypeEnum.String));
                ComponentDic.Add("iExtendName", this.FieldDic["extendName"]);
                Fields.Add("extendName", new field(this.FieldDic["extendName"], "文件扩展名或文件格式"));
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
        }
    }
}
