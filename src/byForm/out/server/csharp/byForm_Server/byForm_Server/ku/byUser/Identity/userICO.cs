using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byUser.Identity
{
    public class userICO : byForm_Server.ku.by.Identity.Table
    {
        public userICO()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
            pAllowUploadFileType = ",txt,jpg,png,ico,sql,by,mp4,zip,rar,";
            pUploadFileSize = 2097152;
            pUploadUserICOFileSize = 50000;
        }

        public string pAllowUploadFileType { get; set; }

        private int pUploadSerialNumber { get; set; }

        public int pUploadFileSize { get; set; }

        public int pUploadUserICOFileSize { get; set; }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iIcoFile { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFileName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iExtendName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iUploadDt { get; set; }

        public byForm_Server.ku.byUser.Identity.user rUser { get; set; }

        public string getIcoUrlPath(string f_pathICO)
        {
            string tmpServerPath = default(string);
            {
                tmpServerPath = byForm_Server.ku.by.Object.ServerSession.getCurrentSession().url;
            }
            return byForm_Server.ku.ExtendMethod.replaceReg(tmpServerPath, "[^/]+$", "", byForm_Server.ku.by.Enum.RegexMode.none) + byForm_Server.ku.byUser.Enum.uploadMode.userIco.ToString() + "/" + byForm_Server.ku.ExtendMethod.replaceReg(f_pathICO, "[\\\\]+", "/", byForm_Server.ku.by.Enum.RegexMode.none);
        }

        public string getIcoDiskPath(string f_fileName, string f_extendName, byForm_Server.ku.byUser.Enum.uploadMode f_uploadMode)
        {
            return getIcoDiskPath_(f_fileName + "." + f_extendName, f_uploadMode);
        }

        public string getIcoDiskPath_(string f_fileFullName, byForm_Server.ku.byUser.Enum.uploadMode f_uploadMode)
        {
            string tmpDir = byForm_Server.ku.by.Object.system.currentDirectory + f_uploadMode.ToString();
            if (!System.IO.Directory.Exists(tmpDir))
            {
                System.IO.Directory.CreateDirectory(tmpDir);
            }
            return tmpDir + "\\" + f_fileFullName;
        }

        public byForm_Server.ku.by.Object.Result fileUpload(sbyte[] f_fileBytes, byForm_Server.ku.byUser.Enum.uploadMode f_dirMode, string f_extendName)
        {
            if (f_extendName == null || this.pAllowUploadFileType.IndexOf("," + f_extendName.ToLower() + ",") == -1)
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Upload_Format_Unsupported(byForm_Server.ku.ExtendMethod.replaceReg(this.pAllowUploadFileType, "(^,)|(,$)", "", byForm_Server.ku.by.Enum.RegexMode.none)) };
            }
            if (f_dirMode == byForm_Server.ku.byUser.Enum.uploadMode.userIco)
            {
                if (f_fileBytes.Length > this.pUploadUserICOFileSize)
                {
                    return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Upload_File_To_Large(this.pUploadUserICOFileSize / 1024) };
                }
            }
            else
            {
                if (f_dirMode == byForm_Server.ku.byUser.Enum.uploadMode.contentOther)
                {
                    if (f_fileBytes.Length > this.pUploadFileSize)
                    {
                        return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Upload_File_To_Large(this.pUploadFileSize / 1024) };
                    }
                    ;
                }
            }
            {
                if (!this.rUser.confirmUserIsLogin_(byForm_Server.ku.byUser.Enum.confirmUserIsLoginMode.verifyLogin))
                {
                    return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Upload_User_Not_Login() };
                }
                try
                {
                    byForm_Server.ku.by.Object.Row tmpUploadRow = new byForm_Server.ku.by.Object.Row() { _InitIdentity_ = this.rUser.rUserUpload };
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUploadRow, "iID", byForm_Server.ku.byCommon.Identity.general.getGuid(), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iDT").value = byForm_Server.ku.by.Object.datetime.getNow();
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUploadRow, "iUserID", System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(((byForm_Server.ku.by.Object.Row)byForm_Server.ku.by.Object.ServerSession.getCurrentSession().user), "iID").value), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnInt(tmpUploadRow, "iFileSize", f_fileBytes.Length / 1024, "=");
                    if (f_dirMode == byForm_Server.ku.byUser.Enum.uploadMode.userIco)
                    {
                        byForm_Server.ku.by.Object.Row tmpUserIcoRow = new byForm_Server.ku.by.Object.Row() { _InitIdentity_ = this };
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserIcoRow, "iID", System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iUserID").value), "=");
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserIcoRow, "iIcoFile", byForm_Server.ku.byCommon.Object.convert.base64ToString(f_fileBytes), "=");
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserIcoRow, "iFileName", byForm_Server.ku.byCommon.Identity.general.getGuid(), "=");
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserIcoRow, "iExtendName", f_extendName, "=");
                        byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iUploadDt").value = byForm_Server.ku.by.Object.datetime.getNow();
                        byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpOldIcoList = (byForm_Server.ku.byUser.SqlExpression.LocalSql._26(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { (string)byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iID").value })).rows;
                        if (tmpOldIcoList.count > 0)
                        {
                            string tmpPathFileName = this.getIcoDiskPath(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpOldIcoList[0], "iFileName").value), System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpOldIcoList[0], "iExtendName").value), f_dirMode);
                            if (System.IO.File.Exists(tmpPathFileName))
                            {
                                System.IO.File.Delete(tmpPathFileName);
                            }
                        }
                        string newIcoPath = getIcoDiskPath(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iFileName").value), f_extendName, f_dirMode);
                        byForm_Server.ku.ExtendMethod.WriteAllBytes(newIcoPath, f_fileBytes, false);
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUploadRow, "iSummery", "上传图标", "=");
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUploadRow, "iFileName", System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iFileName").value) + "." + f_extendName, "=");
                        if (tmpOldIcoList.count > 0)
                        {
                            try
                            {
                                System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                                System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                                System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                                _objList_.Add(new object[] { tmpUploadRow });
                                _tmpIdentityList_.Add(null);
                                _objList_.Add(new object[] { tmpUserIcoRow });
                                _tmpIdentityList_.Add(null);
                                SqlExpression.LocalSql.Tran_2(_tmpIdentityList_.ToArray(), _objList_, _values_);
                            }
                            catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                            {
                                string errorInfo = thisiscsharpserverxclusiveexceptionidentifier.Message;
                                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_SQL_Execution_Failed() + errorInfo };
                            }
                        }
                        else
                        {
                            try
                            {
                                System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                                System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                                System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                                _objList_.Add(new object[] { tmpUploadRow });
                                _tmpIdentityList_.Add(null);
                                _objList_.Add(new object[] { tmpUserIcoRow });
                                _tmpIdentityList_.Add(null);
                                SqlExpression.LocalSql.Tran_3(_tmpIdentityList_.ToArray(), _objList_, _values_);
                            }
                            catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                            {
                                string errorInfo = thisiscsharpserverxclusiveexceptionidentifier.Message;
                                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_SQL_Execution_Failed() + errorInfo };
                            }
                        }
                        return new byForm_Server.ku.by.Object.Result() { isOk = true, info = f_dirMode.ToString() + "\\" + System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iFileName").value) + "." + f_extendName };
                    }
                    else
                    {
                        if (f_dirMode == byForm_Server.ku.byUser.Enum.uploadMode.contentOther)
                        {
                            string tmpFileName = byForm_Server.ku.byCommon.Identity.general.getGuid();
                            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUploadRow, "iSummery", "上传文件", "=");
                            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUploadRow, "iFileName", tmpFileName + "." + f_extendName, "=");
                            byForm_Server.ku.byUser.SqlExpression.LocalSql._31(new object[] { tmpUploadRow });
                            byForm_Server.ku.ExtendMethod.WriteAllBytes(this.getIcoDiskPath(tmpFileName, f_extendName, f_dirMode), f_fileBytes, false);
                            return new byForm_Server.ku.by.Object.Result() { isOk = true, info = f_dirMode.ToString() + "\\" + System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iFileName").value) };
                        }
                        else
                        {
                            return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Upload_File_Only_Allow_Icon() };
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    return new byForm_Server.ku.by.Object.Result() { info = ex.Message + "[" + byForm_Server.ku.by.Object.system.currentDirectory + "]" };
                }
            }
        }

        public event byForm_Server.ku.by.Delegates.KuDelegates.Delegate_1<byForm_Server.ku.byUser.Orm.Orm0> userICOChangeEvent;
    }
}
