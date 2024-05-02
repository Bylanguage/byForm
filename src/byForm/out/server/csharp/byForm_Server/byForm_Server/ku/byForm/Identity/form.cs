using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Identity
{
    public class form : byForm_Server.ku.by.Identity.Table
    {
        public form()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
            pCacheDic = new byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[]>();
            pCacheDicCount = 1000;
        }

        public byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[]> pCacheDic { get; set; }

        public int pCacheDicCount { get; set; }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Name iName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iSuccessMsg { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iSubmitButton { get; set; }

        public byForm_Server.ku.by.Identity.ID iSummary { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iUserID { get; set; }

        public byForm_Server.ku.byForm.Identity.formSys rFormSys { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iCreateDt { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iCurrentModifyDt { get; set; }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[] load(string f_userID)
        {
            if (!byForm_Server.ku.byCommon.Object.verifyRequest.isOk(f_userID, 32) || !this.rFormSys.rUser.confirmUserIsLogin_(f_userID))
            {
                return null;
            }
            {
                f_userID = this.rFormSys.rUser.rsaDecode(f_userID);
                byForm_Server.ku.by.ToolClass.ExecResult tmpMuiltList = byForm_Server.ku.byForm.SqlExpression.LocalSql.ExecResult_0(new int[] { 0, 1 }, new byForm_Server.ku.by.ToolClass.IExecItem[] { byForm_Server.ku.byForm.SqlExpression.LocalSql._12(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_userID }), byForm_Server.ku.byForm.SqlExpression.LocalSql._13(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rFormSys.rFormField }, new object[] { f_userID }) });
                return new byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[] { tmpMuiltList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select1").rows, tmpMuiltList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select2").rows };
            }
        }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[] loadSingle(string f_FormID)
        {
            if (!byForm_Server.ku.byCommon.Object.verifyRequest.isOk(f_FormID, 32))
            {
                return null;
            }
            {
                if (this.pCacheDic.containsKey(f_FormID))
                {
                    return this.pCacheDic[f_FormID];
                }
                else
                {
                    byForm_Server.ku.by.ToolClass.ExecResult tmpMuiltList = byForm_Server.ku.byForm.SqlExpression.LocalSql.ExecResult_1(new int[] { 0, 1 }, new byForm_Server.ku.by.ToolClass.IExecItem[] { byForm_Server.ku.byForm.SqlExpression.LocalSql._14(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_FormID }), byForm_Server.ku.byForm.SqlExpression.LocalSql._15(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rFormSys.rFormField }, new object[] { f_FormID }) });
                    byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[] tmpListArr = new byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[] { tmpMuiltList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select1").rows, tmpMuiltList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select2").rows };
                    if (this.pCacheDic.count < 1000)
                    {
                        this.pCacheDic.add(f_FormID, tmpListArr);
                    }
                    return tmpListArr;
                }
            }
        }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> loadVDataSingle(string f_FormID)
        {
            if (!byForm_Server.ku.byCommon.Object.verifyRequest.isOk(f_FormID, 32))
            {
                return null;
            }
            {
                byForm_Server.ku.by.ToolClass.ExecResult tmpExecList = byForm_Server.ku.byForm.SqlExpression.LocalSql.ExecResult_2(new int[] { 0, 1, 2, 3 }, new byForm_Server.ku.by.ToolClass.IExecItem[] { byForm_Server.ku.byForm.SqlExpression.LocalSql._16(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rFormSys.rVData64 }, new object[] { f_FormID }), byForm_Server.ku.byForm.SqlExpression.LocalSql._17(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rFormSys.rVData256 }, new object[] { f_FormID }), byForm_Server.ku.byForm.SqlExpression.LocalSql._18(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rFormSys.rVData1024 }, new object[] { f_FormID }), byForm_Server.ku.byForm.SqlExpression.LocalSql._19(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rFormSys.rVData4000 }, new object[] { f_FormID }) });
                tmpExecList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select1").rows.addRange(tmpExecList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select2").rows);
                tmpExecList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select1").rows.addRange(tmpExecList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select3").rows);
                tmpExecList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select1").rows.addRange(tmpExecList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select4").rows);
                return tmpExecList.GetMember<byForm_Server.ku.by.ToolClass.SqlType>("select1").rows;
            }
        }

        public byForm_Server.ku.by.Object.Result update(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_list, byForm_Server.ku.by.Enum.Action f_action)
        {
            if (f_list.count == 0)
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byForm.Object.TextHelper.misssingListData };
            }
            byForm_Server.ku.by.Identity.Table[] tmpID = new byForm_Server.ku.by.Identity.Table[] { this, this.rFormSys.rVData1024, this.rFormSys.rVData256, this.rFormSys.rVData4000, this.rFormSys.rVData64 };
            if (!byForm_Server.ku.byCommon.Object.verifyRowIdentity.isExists(f_list, tmpID))
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byForm.Object.TextHelper.illegalInjection };
            }
            {
                try
                {
                    System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                    System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                    _values_.Add(f_action);
                    System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                    _objList_.Add(new object[] { f_list });
                    _tmpIdentityList_.Add(null);
                    _objList_.Add(new object[] { f_list });
                    _tmpIdentityList_.Add(null);
                    _objList_.Add(new object[] { f_list });
                    _tmpIdentityList_.Add(null);
                    SqlExpression.LocalSql.Tran_0(_tmpIdentityList_.ToArray(), _objList_, _values_);
                }
                catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                {
                    string errorInfo = thisiscsharpserverxclusiveexceptionidentifier.Message;
                    return new byForm_Server.ku.by.Object.Result() { isOk = false, info = errorInfo };
                }
                return new byForm_Server.ku.by.Object.Result() { isOk = true };
            }
        }

        public void saveField(byForm_Server.ku.by.Object.Row f_formField, byForm_Server.ku.by.Enum.Action action)
        {
            this.rFormSys.rFormField.addUpdate(f_formField, action);
        }

        public void delFieldByFormId(string formID)
        {
            this.rFormSys.rFormField.delByFormId(formID);
        }
    }
}
