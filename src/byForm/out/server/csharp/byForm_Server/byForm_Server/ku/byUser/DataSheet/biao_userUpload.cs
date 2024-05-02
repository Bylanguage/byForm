using System;
using System.Collections.Generic;
using System.Text;
using byForm_Server.ku;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.byUser.DataSheet
{
    public class biao_userUpload : byForm_Server.ku.by.Object.table, byForm_Server.ku.by.ToolClass.IBaseDataSheet
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

        public biao_userUpload()
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
                this.SheetName = "userUpload";
                DataSheet = this;
                tableType = by.Enum.TableType.data;
                IdentityName = "byUser.userUpload";

                VerifyDic.Add("iD", new Dictionary<ku.by.Enum.attribute, string>());
                bool iD_notNull = true;
                VerifyDic["iD"].Add(ku.by.Enum.attribute.notNull, iD_notNull.ToString());
                VerifyDic.Add("fileName", new Dictionary<ku.by.Enum.attribute, string>());
                bool fileName_notNull = true;
                VerifyDic["fileName"].Add(ku.by.Enum.attribute.notNull, fileName_notNull.ToString());
                VerifyDic.Add("fileSize", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("userID", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("summery", new Dictionary<ku.by.Enum.attribute, string>());
                VerifyDic.Add("dT", new Dictionary<ku.by.Enum.attribute, string>());
                FieldDic.Add("iD", new Field(this.KuName, this.SheetName, "iD", ku.DataTypeEnum.String));
                ComponentDic.Add("iID", this.FieldDic["iD"]);
                Fields.Add("iD", new field(this.FieldDic["iD"], "上传编号"));
                FieldDic.Add("fileName", new Field(this.KuName, this.SheetName, "fileName", ku.DataTypeEnum.String));
                ComponentDic.Add("iFileName", this.FieldDic["fileName"]);
                Fields.Add("fileName", new field(this.FieldDic["fileName"], "文件名，包括扩展名，包括相对目录"));
                FieldDic.Add("fileSize", new Field(this.KuName, this.SheetName, "fileSize", ku.DataTypeEnum.Int));
                ComponentDic.Add("iFileSize", this.FieldDic["fileSize"]);
                Fields.Add("fileSize", new field(this.FieldDic["fileSize"], "文件尺寸K"));
                FieldDic.Add("userID", new Field(this.KuName, this.SheetName, "userID", ku.DataTypeEnum.String));
                ComponentDic.Add("iUserID", this.FieldDic["userID"]);
                Fields.Add("userID", new field(this.FieldDic["userID"], "用户ID"));
                FieldDic.Add("summery", new Field(this.KuName, this.SheetName, "summery", ku.DataTypeEnum.String));
                ComponentDic.Add("iSummery", this.FieldDic["summery"]);
                Fields.Add("summery", new field(this.FieldDic["summery"], "上传说明"));
                FieldDic.Add("dT", new Field(this.KuName, this.SheetName, "dT", ku.DataTypeEnum.Datetime));
                ComponentDic.Add("iDT", this.FieldDic["dT"]);
                Fields.Add("dT", new field(this.FieldDic["dT"], "上传时间"));
                SourceDic.Add("fileSize", new by.ToolClass.Source(this, "equal",  FieldDic["fileSize"]));
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
