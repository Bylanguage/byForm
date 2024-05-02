using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byUser.Identity
{
    public class user : byForm_Server.ku.by.Identity.Table
    {
        public user()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
            pIsGetServerUserRow = true;
            pDenyIpDic = new byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.datetime>();
            pDenyIpInterval = 60;
            pLoginExpire = 2;
            pDenyUserDic = new byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.datetime>>();
            pRegMobile = "^[\\d]{11}$";
            pRegMaile = "^[_\\-0-9a-z]+@(([_\\-0-9a-z]{1,32}\\.[0-9a-z]{2,6})|([_\\-0-9a-z]{1,32}\\.[_\\-0-9a-z]{1,32}\\.[0-9a-z]{2,6}))$";
            pRegSafetyCode = "^[0-9]{4,8}$";
            pConfigSMSCode = false;
            publicKeyWebClient = new byForm_Server.ku.by.Object.dictionary<byForm_Server.ku.by.Object.ServerSession, string>();
            regPwd = "^[a-zA-Z0-9_@#$]{6,32}$";
            regUserName = "^[0-9a-zA-Z@_#\\.\\-]{2,32}$";
            pVerifyMode = byForm_Server.ku.byUser.Enum.verifyMode.cookie;
        }

        public bool pIsGetServerUserRow { get; set; }

        public byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.datetime> pDenyIpDic { get; set; }

        public int pDenyIpInterval { get; set; }

        public int pLoginExpire { get; set; }

        public byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.datetime>> pDenyUserDic { get; set; }

        public string pRegMobile { get; set; }

        public string pRegMaile { get; set; }

        public string pRegSafetyCode { get; set; }

        public bool pConfigSMSCode { get; set; }

        public string publicKey { get; set; }

        public string privateKey { get; set; }

        public byForm_Server.ku.by.Object.dictionary<byForm_Server.ku.by.Object.ServerSession, string> publicKeyWebClient { get; set; }

        public string regPwd { get; set; }

        public string regUserName { get; set; }

        public byForm_Server.ku.byUser.Enum.verifyMode pVerifyMode { get; set; }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iFreeze { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iRank { get; set; }

        public byForm_Server.ku.by.Identity.Name iName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iPassword { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iDisplayName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iMobile { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iMail { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iCerMode { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iCerName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iCerNO { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iMoney { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iRemark { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iRegDt { get; set; }

        public byForm_Server.ku.byUser.Identity.userICO rUserICO { get; set; }

        public byForm_Server.ku.byUser.Identity.userUpload rUserUpload { get; set; }

        public byForm_Server.ku.byLog.Identity.log rLog { get; set; }

        public byForm_Server.ku.byUser.Identity.userAdmin rUserAdmin { get; set; }

        public byForm_Server.ku.byUser.Identity.anonymous rAnonymous { get; set; }

        public bool userLoginChild(byForm_Server.ku.byUser.Object.resultUser f_resultValue, string f_user, string f_pwd)
        {
            f_resultValue.info = this.verifyUserFormat(f_user);
            if (f_resultValue.info != null)
            {
                return false;
            }
            f_resultValue.info = this.verifyPwd(f_pwd);
            if (f_resultValue.info != null)
            {
                return false;
            }
            return true;
        }

        public byForm_Server.ku.byUser.Object.resultUser userLogin(string f_user, string f_pwd)
        {
            byForm_Server.ku.byUser.Object.resultUser tmpResultValue = new byForm_Server.ku.byUser.Object.resultUser();
            {
                f_user = this.rsaDecode(f_user);
                f_pwd = this.rsaDecode(f_pwd);
                byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
                string tmpSessionIp = tmpSession.ip;
                if (this.pDenyIpDic.containsKey(tmpSessionIp))
                {
                    string tmpLogSummary = byForm_Server.ku.byUser.Object.ByUserStrings.Info_IP_Locked_Template(tmpSessionIp, this.pDenyIpInterval);
                    this.rLog.write(byForm_Server.ku.byLog.Enum.logState.user, f_user + "  " + tmpLogSummary + "  " + tmpSession.ip);
                    byForm_Server.ku.by.Object.datetime tmpIp = this.pDenyIpDic[tmpSessionIp];
                    if (byForm_Server.ku.by.Object.datetime.getNow().diffMinutes(tmpIp) > this.pDenyIpInterval)
                    {
                        this.pDenyIpDic.remove(tmpSessionIp);
                    }
                    else
                    {
                        tmpResultValue.info = tmpLogSummary;
                        return tmpResultValue;
                    }
                }
                if (this.pDenyUserDic.containsKey(f_user))
                {
                    byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.datetime> tmpDtList = this.pDenyUserDic[f_user];
                    if (tmpDtList.count > 5)
                    {
                        if (byForm_Server.ku.by.Object.datetime.getNow().diffMinutes(tmpDtList[tmpDtList.count - 1]) > this.pDenyIpInterval)
                        {
                            this.pDenyUserDic.remove(f_user);
                        }
                        else
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Login_MultipleTimes_Locked(this.pDenyIpInterval);
                            this.rLog.write(byForm_Server.ku.byLog.Enum.logState.user, f_user + "  " + tmpResultValue.info + "  " + tmpSession.ip);
                            return tmpResultValue;
                        }
                    }
                }
                byForm_Server.ku.by.ToolClass.SqlType tmpSelectTable1 = byForm_Server.ku.byUser.SqlExpression.LocalSql._1(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_user, f_pwd });
                byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.Orm0> tmpList = byForm_Server.ku.byUser.SqlExpression.LocalSql._0(new byForm_Server.ku.by.ToolClass.ITableSource[] { tmpSelectTable1, this.rUserAdmin, this.rUserICO }, new object[] { byForm_Server.ku.byUser.Enum.uploadMode.userIco.ToString() });
                if (tmpList.rows.count == 0)
                {
                    if (this.pDenyUserDic.containsKey(f_user))
                    {
                        this.pDenyUserDic[f_user].add(byForm_Server.ku.by.Object.datetime.getNow());
                    }
                    else
                    {
                        byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.datetime> tmpDtList = new byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.datetime>();
                        tmpDtList.add(byForm_Server.ku.by.Object.datetime.getNow());
                        this.pDenyUserDic.add(f_user, tmpDtList);
                    }
                    tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Login_MultipleTimes_Will_Lock(this.pDenyIpInterval);
                    this.rLog.write(byForm_Server.ku.byLog.Enum.logState.user, f_user + "  " + tmpResultValue.info + "  " + tmpSession.ip);
                    return tmpResultValue;
                }
                else
                {
                    if (System.Convert.ToBoolean(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(((tmpList.rows[0] as byForm_Server.ku.byUser.Orm.Orm0) as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iFreeze").value))
                    {
                        tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Freezed_User();
                        this.rLog.write(byForm_Server.ku.byLog.Enum.logState.user, System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(((tmpList.rows[0] as byForm_Server.ku.byUser.Orm.Orm0) as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iID").value) + "  " + f_user + "  " + tmpResultValue.info + "  " + tmpSession.ip);
                        return tmpResultValue;
                    }
                    if (this.pDenyUserDic.containsKey(f_user))
                    {
                        this.pDenyUserDic.remove(f_user);
                    }
                    tmpResultValue.loginRow = (tmpList.rows[0] as byForm_Server.ku.byUser.Orm.Orm0);
                    tmpResultValue.isOk = true;
                    tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Login_Completed();
                    tmpResultValue.loginRow = (tmpList.rows[0] as byForm_Server.ku.byUser.Orm.Orm0);
                    tmpSession.user = ((tmpList.rows[0] as byForm_Server.ku.byUser.Orm.Orm0) as byForm_Server.ku.byUser.Orm.Orm0).Tablea;
                    tmpSession.other = (tmpList.rows[0] as byForm_Server.ku.byUser.Orm.Orm0);
                    this.rLog.write(byForm_Server.ku.byLog.Enum.logState.user, System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(((tmpList.rows[0] as byForm_Server.ku.byUser.Orm.Orm0) as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iID").value) + "  " + f_user + "  " + tmpResultValue.info + "  " + tmpSession.ip);
                    if (this.loginSuccessEvent != null)
                    {
                        this.loginSuccessEvent((tmpList.rows[0] as byForm_Server.ku.byUser.Orm.Orm0));
                    }
                    if (!this.publicKeyWebClient.containsKey(tmpSession))
                    {
                        tmpResultValue.loginRow = null;
                        tmpResultValue.isOk = false;
                        tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Login_Failed_RSA_Missing();
                        return tmpResultValue;
                    }
                    else
                    {
                        string tmpFrontPublicKey = this.publicKeyWebClient[tmpSession];
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString((tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iName", this.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent((tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iName").value)), "=");
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString((tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iDisplayName", this.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent((tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iDisplayName").value)), "=");
                    }
                }
                return tmpResultValue;
            }
        }

        public bool confirmUserIsLogin()
        {
            return confirmUserIsLogin_(byForm_Server.ku.byUser.Enum.confirmUserIsLoginMode.verifyLogin);
        }

        public bool confirmUserIsLogin_(byForm_Server.ku.byUser.Enum.confirmUserIsLoginMode f_verifyMode)
        {
            {
                byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
                if (this.pVerifyMode == byForm_Server.ku.byUser.Enum.verifyMode.cookie)
                {
                    return tmpSession.Cookie == null || tmpSession.Cookie == "" ? false : true;
                }
                else
                {
                    return tmpSession.user == null || byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpSession.user, "iID").value == null || byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpSession.user, "iID").value == "" ? false : true;
                }
            }
        }

        public bool confirmUserIsLogin_(string f_userID)
        {
            {
                byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
                if (this.pVerifyMode == byForm_Server.ku.byUser.Enum.verifyMode.cookie)
                {
                    string tmpUserID = tmpSession.Cookie;
                    if (tmpUserID == null || tmpUserID == "")
                    {
                        return false;
                    }
                    else
                    {
                        return tmpUserID == f_userID ? true : false;
                    }
                }
                else
                {
                    return tmpSession.user == null || byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpSession.user, "iID").value == null || byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpSession.user, "iID").value == "" ? false : true;
                }
            }
        }

        public void exit()
        {
            {
                byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
                if (this.userExitEvent != null)
                {
                    this.userExitEvent((byForm_Server.ku.byUser.Orm.Orm0)tmpSession.other);
                }
                tmpSession.user = null;
                tmpSession.other = null;
            }
        }

        public byForm_Server.ku.by.Object.Result userReg(byForm_Server.ku.by.Object.Row f_userRow, string f_SafetyCode)
        {
            {
                f_SafetyCode = this.rsaDecode(f_SafetyCode);
                byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iDisplayName", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iDisplayName").value)), "=");
                byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iMail", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMail").value)), "=");
                byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iMobile", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMobile").value)), "=");
                byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iName", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iName").value)), "=");
                if (this.pConfigSMSCode)
                {
                    byForm_Server.ku.by.Object.Result tmpResultValue = this.verifySafetyCode(f_SafetyCode);
                    if (!tmpResultValue.isOk)
                    {
                        return tmpResultValue;
                    }
                }
                return this.userReg_(f_userRow);
            }
        }

        public byForm_Server.ku.by.Object.Result userReg_(byForm_Server.ku.by.Object.Row f_userRow)
        {
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iID", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iID").value)), "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iRank").value = byForm_Server.ku.byUser.Enum.rank.register;
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iName", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iName").value)), "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iPassword", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iPassword").value)), "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iMobile", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMobile").value)), "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_userRow, "iMail", this.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMail").value)), "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iRegDt").value = byForm_Server.ku.byCommon.Identity.general.getServerDatetime();
            byForm_Server.ku.by.Object.Result tmpResultValue = new byForm_Server.ku.by.Object.Result();
            if (f_userRow == null)
            {
                tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Register_UserName_Cannot_Be_Null();
                tmpResultValue.isOk = false;
                return tmpResultValue;
            }
            int tmpRowCount = byForm_Server.ku.byUser.SqlExpression.LocalSql._2(new object[] { f_userRow });
            if (tmpRowCount != 1)
            {
                tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Register_Failed();
                tmpResultValue.isOk = false;
                return tmpResultValue;
            }
            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Register_Completed();
            tmpResultValue.isOk = true;
            return tmpResultValue;
        }

        public byForm_Server.ku.by.Object.Result userPwdModif(string f_sourcePwd, string f_newPwd, string f_ID)
        {
            {
                f_sourcePwd = this.rsaDecode(f_sourcePwd);
                f_newPwd = this.rsaDecode(f_newPwd);
                f_ID = this.rsaDecode(f_ID);
                byForm_Server.ku.by.Object.Result tmpResultValue = new byForm_Server.ku.by.Object.Result();
                byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
                if (tmpSession == null || tmpSession.user == null || System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(((byForm_Server.ku.by.Object.Row)tmpSession.user), "iID").value) != f_ID)
                {
                    tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Modify_Failed_Illegal();
                    tmpResultValue.isOk = false;
                    return tmpResultValue;
                }
                byForm_Server.ku.by.ToolClass.SqlType tmpList = byForm_Server.ku.byUser.SqlExpression.LocalSql._3(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_ID, f_sourcePwd });
                if (tmpList.rows.count == 1)
                {
                    if (System.Convert.ToBoolean(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpList.rows[0], "iFreeze").value))
                    {
                        tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Modify_Failed_Freezed();
                        tmpResultValue.isOk = false;
                        return tmpResultValue;
                    }
                    int tmpRowCount = byForm_Server.ku.byUser.SqlExpression.LocalSql._4(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_newPwd, f_ID });
                    if (tmpRowCount == 1)
                    {
                        tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Modify_Completed();
                        tmpResultValue.isOk = true;
                        return tmpResultValue;
                    }
                    else
                    {
                        tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Modify_Failed();
                        tmpResultValue.isOk = false;
                        return tmpResultValue;
                    }
                }
                else
                {
                    tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Modify_Failed_Old_Password_Wrong();
                    tmpResultValue.isOk = false;
                    return tmpResultValue;
                }
                return tmpResultValue;
            }
        }

        public byForm_Server.ku.by.Object.Result userPwdModif_(string f_userMailMobile, byForm_Server.ku.byUser.Enum.safetyCodeMode f_safetyCodeMode, string f_newPwd, string f_safetyCode)
        {
            {
                byForm_Server.ku.by.Object.Result tmpResultValue = new byForm_Server.ku.by.Object.Result();
                f_userMailMobile = this.rsaDecode(f_userMailMobile);
                f_newPwd = this.rsaDecode(f_newPwd);
                f_safetyCode = this.rsaDecode(f_safetyCode);
                tmpResultValue = this.verifySafetyCode(f_safetyCode);
                if (!tmpResultValue.isOk)
                {
                    return tmpResultValue;
                }
                byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> rowList = default(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>);
                string tmpVerfy = default(string);
                if (f_safetyCodeMode == byForm_Server.ku.byUser.Enum.safetyCodeMode.user)
                {
                    tmpVerfy = this.verifyUserFormat(f_userMailMobile);
                    if (tmpVerfy != null)
                    {
                        tmpResultValue.info = tmpVerfy;
                        return tmpResultValue;
                    }
                    rowList = (byForm_Server.ku.byUser.SqlExpression.LocalSql._5(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_userMailMobile })).rows;
                }
                else
                {
                    if (f_safetyCodeMode == byForm_Server.ku.byUser.Enum.safetyCodeMode.mail)
                    {
                        tmpVerfy = this.verifyMailFormat(f_userMailMobile);
                        if (tmpVerfy != null)
                        {
                            tmpResultValue.info = tmpVerfy;
                            return tmpResultValue;
                        }
                        rowList = (byForm_Server.ku.byUser.SqlExpression.LocalSql._6(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_userMailMobile })).rows;
                    }
                    else
                    {
                        if (f_safetyCodeMode == byForm_Server.ku.byUser.Enum.safetyCodeMode.mobile)
                        {
                            tmpVerfy = this.verifyUserFormat(f_userMailMobile);
                            if (tmpVerfy != null)
                            {
                                tmpResultValue.info = tmpVerfy;
                                return tmpResultValue;
                            }
                            rowList = (byForm_Server.ku.byUser.SqlExpression.LocalSql._7(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_userMailMobile })).rows;
                        }
                    }
                }
                if (rowList.count == 0)
                {
                    tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Illegal_User();
                    return tmpResultValue;
                }
                else
                {
                    if (rowList.count == 1)
                    {
                        if (System.Convert.ToBoolean(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(rowList[0], "iFreeze").value))
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Freezed_User();
                            return tmpResultValue;
                        }
                        this.rLog.write(byForm_Server.ku.byLog.Enum.logState.user, System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(rowList[0], "iID").value) + "  " + System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(rowList[0], "iName").value) + "  " + "用户修改密码" + "  " + byForm_Server.ku.by.Object.ServerSession.getCurrentSession().ip);
                        try
                        {
                            System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                            System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                            System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                            _objList_.Add(new object[] { f_newPwd, (string)byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(rowList[0], "iID").value });
                            _tmpIdentityList_.Add(this);
                            SqlExpression.LocalSql.Tran_0(_tmpIdentityList_.ToArray(), _objList_, _values_);
                        }
                        catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                        {
                            string message = thisiscsharpserverxclusiveexceptionidentifier.Message;
                            tmpResultValue.info = message;
                            return tmpResultValue;
                        }
                    }
                }
                tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Reset_Password_Completed();
                tmpResultValue.isOk = true;
                return tmpResultValue;
            }
        }

        public string verifyMobileFormat(string f_mobile)
        {
            if (!byForm_Server.ku.ExtendMethod.isMatch(f_mobile, this.pRegMobile, byForm_Server.ku.by.Enum.RegexMode.multiIgnoreCase))
            {
                return byForm_Server.ku.byUser.Object.ByUserStrings.Info_Phone_Must_11_Digits();
            }
            return null;
        }

        public bool verifyMobileExists(string f_mobile)
        {
            {
                f_mobile = this.rsaDecode(f_mobile);
            }
            if (this.verifyMobileFormat(f_mobile) != null)
            {
                return false;
            }
            {
                byForm_Server.ku.by.ToolClass.SqlType tmpList = byForm_Server.ku.byUser.SqlExpression.LocalSql._9(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_mobile });
                return tmpList.rows.count > 0 ? true : false;
            }
        }

        public string verifyRegMail(string f_mail)
        {
            {
                f_mail = this.rsaDecode(f_mail);
            }
            string tmpFormat = this.verifyMailFormat(f_mail);
            if (tmpFormat != null)
            {
                return tmpFormat;
            }
            {
                if (this.verifyMailExists(f_mail).isOk)
                {
                    return byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Already_Exists();
                }
            }
            return null;
        }

        public string verifyMailFormat(string f_mail)
        {
            if (f_mail.Length > 64 || f_mail.Length < 6)
            {
                return byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Too_Long_Or_Too_Short();
            }
            if (!byForm_Server.ku.ExtendMethod.isMatch(f_mail, this.pRegMaile, byForm_Server.ku.by.Enum.RegexMode.multiIgnoreCase))
            {
                return byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Format_Invalid();
            }
            return null;
        }

        public byForm_Server.ku.by.Object.Result verifyMailExists(string f_mail)
        {
            {
                f_mail = this.rsaDecode(f_mail);
            }
            byForm_Server.ku.by.Object.Result tmpResulValue = new byForm_Server.ku.by.Object.Result();
            tmpResulValue.info = this.verifyMailFormat(f_mail);
            if (tmpResulValue.info != null)
            {
                return tmpResulValue;
            }
            {
                byForm_Server.ku.by.ToolClass.SqlType tmpList = byForm_Server.ku.byUser.SqlExpression.LocalSql._10(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_mail });
                if (tmpList.rows.count > 0)
                {
                    tmpResulValue.isOk = true;
                }
                else
                {
                    tmpResulValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Not_Exist();
                }
                return tmpResulValue;
            }
        }

        public bool verifySafetyCodeFormat(string f_SafetyCode)
        {
            return byForm_Server.ku.ExtendMethod.isMatch(f_SafetyCode, "^[\\d]{4,8}$", byForm_Server.ku.by.Enum.RegexMode.multiline);
        }

        public byForm_Server.ku.by.Object.Result verifySafetyCode(string f_safetyCode)
        {
            byForm_Server.ku.by.Object.Result tmpResult = new byForm_Server.ku.by.Object.Result();
            if (!byForm_Server.ku.ExtendMethod.isMatch(f_safetyCode, this.pRegSafetyCode, byForm_Server.ku.by.Enum.RegexMode.multiIgnoreCase))
            {
                tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_SecurityCode_Invalid();
                return tmpResult;
            }
            byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
            if (tmpSession == null)
            {
                tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_SecurityCode_Session_Timeout();
                return tmpResult;
            }
            if (tmpSession.other != null)
            {
                object[] objArr = (object[])tmpSession.other;
                tmpSession.other = null;
                if (f_safetyCode != objArr[0].ToString())
                {
                    tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_SecurityCode_Dismatch();
                    return tmpResult;
                }
                else
                {
                    double tmpMin = ((byForm_Server.ku.by.Object.datetime)objArr[1]).diffMinutes(byForm_Server.ku.by.Object.datetime.getNow());
                    if (tmpMin > 15d)
                    {
                        tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_SecurityCode_Timeout();
                        return tmpResult;
                    }
                }
                tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_SecurityCode_Verification_Succeed();
                tmpResult.isOk = true;
                return tmpResult;
            }
            tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_SecurityCode_Missing();
            return tmpResult;
        }

        public byForm_Server.ku.by.Object.Result verifyCookies(string f_cookie)
        {
            byForm_Server.ku.by.Object.Result tmpResultValue = new byForm_Server.ku.by.Object.Result();
            if (!byForm_Server.ku.ExtendMethod.isMatch(f_cookie, "^[0-9a-z]{2,32}$", byForm_Server.ku.by.Enum.RegexMode.multiIgnoreCase))
            {
                tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Cookie_Invalid(f_cookie);
                return tmpResultValue;
            }
            tmpResultValue.isOk = true;
            return tmpResultValue;
        }

        public int generateSafetyCode()
        {
            int tmpMin = byExternalBase.random.next(1000, 2000);
            int tmpMax = byExternalBase.random.next(8000, 9999);
            return byExternalBase.random.next(tmpMin, tmpMax);
        }

        public byForm_Server.ku.by.Object.Result postSafety(byForm_Server.ku.byUser.Enum.safetyCodeMode f_safetyCodeMode, string f_userMobileMail)
        {
            byForm_Server.ku.by.Object.Result tmpResultValue = new byForm_Server.ku.by.Object.Result();
            f_userMobileMail = this.rsaDecode(f_userMobileMail);
            switch (f_safetyCodeMode)
            {
                case byForm_Server.ku.byUser.Enum.safetyCodeMode.user:
                    {
                        if (this.verifyUserFormat(f_userMobileMail) != null)
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_UserName_Invalid();
                            return tmpResultValue;
                        }
                        byForm_Server.ku.by.ToolClass.SqlType tmpUserList = byForm_Server.ku.byUser.SqlExpression.LocalSql._11(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_userMobileMail });
                        if (tmpUserList.rows.count != 1)
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_UserName_Not_Exist();
                            return tmpResultValue;
                        }
                        if (System.Convert.ToBoolean(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserList.rows[0], "iFreeze").value))
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Freezed_User();
                            return tmpResultValue;
                        }
                        byForm_Server.ku.by.Object.Result mobileResult = this.postSafetyModbile(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserList.rows[0], "iMobile").value));
                        if (mobileResult.isOk == true)
                        {
                            return mobileResult;
                        }
                        else
                        {
                            byForm_Server.ku.by.Object.Result mailResult = this.postSafetyMail(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserList.rows[0], "iMail").value));
                            if (mailResult.isOk == false)
                            {
                                mailResult.info += "\r\n" + mobileResult.info;
                                ;
                            }
                            return mailResult;
                        }
                        break;
                    }
                case byForm_Server.ku.byUser.Enum.safetyCodeMode.mail:
                    {
                        if (this.verifyMailFormat(f_userMobileMail) != null)
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Invalid();
                            return tmpResultValue;
                        }
                        byForm_Server.ku.by.ToolClass.SqlType tmpMailList = byForm_Server.ku.byUser.SqlExpression.LocalSql._12(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_userMobileMail });
                        if (tmpMailList.rows.count != 1)
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Not_Exist();
                            return tmpResultValue;
                        }
                        if (System.Convert.ToBoolean(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpMailList.rows[0], "iFreeze").value))
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Freezed();
                            return tmpResultValue;
                        }
                        return this.postSafetyMail(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpMailList.rows[0], "iMail").value));
                        break;
                    }
                case byForm_Server.ku.byUser.Enum.safetyCodeMode.mobile:
                    {
                        if (this.verifyMobileFormat(f_userMobileMail) != null)
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Phone_Invalid();
                            return tmpResultValue;
                        }
                        byForm_Server.ku.by.ToolClass.SqlType tmpMobileList = byForm_Server.ku.byUser.SqlExpression.LocalSql._13(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_userMobileMail });
                        if (tmpMobileList.rows.count != 1)
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Phone_Not_Exist();
                            return tmpResultValue;
                        }
                        if (System.Convert.ToBoolean(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpMobileList.rows[0], "iFreeze").value))
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Phone_Freezed();
                            return tmpResultValue;
                        }
                        return this.postSafetyModbile(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpMobileList.rows[0], "iMobile").value));
                        break;
                    }
            }
            return tmpResultValue;
        }

        public byForm_Server.ku.by.Object.Result postSafetyModbile(string f_mobile)
        {
            byForm_Server.ku.by.Object.Result tmpMobileResult = this.postSafetyCodeToMobile(f_mobile);
            return tmpMobileResult;
        }

        public byForm_Server.ku.by.Object.Result postSafetyMail(string f_mail)
        {
            byForm_Server.ku.by.Object.Result tmpMailResult = this.postSafetyCodeToMail(f_mail);
            return tmpMailResult;
        }

        public byForm_Server.ku.by.Object.Result postSafetyReg(string f_mail, string f_mobile)
        {
            {
                byForm_Server.ku.by.Object.Result tmpResultValue = new byForm_Server.ku.by.Object.Result();
                f_mail = this.rsaDecode(f_mail);
                f_mobile = this.rsaDecode(f_mobile);
                tmpResultValue.info = this.verifyMailFormat(f_mail);
                if (tmpResultValue.info != null)
                {
                    return tmpResultValue;
                }
                tmpResultValue.info = this.verifyMobileFormat(f_mobile);
                if (tmpResultValue.info != null)
                {
                    return tmpResultValue;
                }
                byForm_Server.ku.by.ToolClass.SqlType tmpList = byForm_Server.ku.byUser.SqlExpression.LocalSql._14(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_mobile });
                if (tmpList.rows.count > 0)
                {
                    tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Phone_Already_Exists();
                    return tmpResultValue;
                }
                byForm_Server.ku.by.ToolClass.SqlType tmpList2 = byForm_Server.ku.byUser.SqlExpression.LocalSql._15(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_mail });
                if (tmpList2.rows.count > 0)
                {
                    tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Already_Exists();
                    return tmpResultValue;
                }
                byForm_Server.ku.by.Object.Result mobileResult = this.postSafetyModbile(f_mobile);
                if (mobileResult.isOk == true)
                {
                    return mobileResult;
                }
                else
                {
                    byForm_Server.ku.by.Object.Result mailResult = this.postSafetyMail(f_mail);
                    if (mailResult.isOk == false)
                    {
                        mailResult.info += "\r\n" + mobileResult.info;
                        ;
                    }
                    return mailResult;
                }
            }
        }

        public byForm_Server.ku.by.Object.Result postSafetyCodeToMobile(string f_mobile)
        {
            f_mobile = this.rsaDecode(f_mobile);
            byForm_Server.ku.by.Object.Result tmpResult = new byForm_Server.ku.by.Object.Result();
            int tmpCodeValue = this.generateSafetyCode();
            if (this.verifyMobileFormat(f_mobile) == null)
            {
                string tmpResultValue = byForm_Server.ku.byExternalSMS.Object.feigeSend.sendSafetyCode(f_mobile, tmpCodeValue.ToString());
                this.rLog.write(byForm_Server.ku.byLog.Enum.logState.user, "用户注册发送验证码" + f_mobile + "  " + byForm_Server.ku.by.Object.ServerSession.getCurrentSession().ip);
                if (tmpResultValue == null)
                {
                    byForm_Server.ku.by.Object.ServerSession.getCurrentSession().other = new object[] { tmpCodeValue, byForm_Server.ku.by.Object.datetime.getNow() };
                    tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Mobile();
                    tmpResult.isOk = true;
                    return tmpResult;
                }
                else
                {
                    tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Mobile_Failed() + tmpResultValue;
                    return tmpResult;
                }
            }
            else
            {
                tmpResult.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Phone_Invalid();
                return tmpResult;
            }
        }

        public byForm_Server.ku.by.Object.Result postSafetyCodeToMail(string f_mail)
        {
            f_mail = this.rsaDecode(f_mail);
            byForm_Server.ku.by.Object.Result tmpResultValue = new byForm_Server.ku.by.Object.Result();
            if (this.verifyMailFormat(f_mail) != null)
            {
                tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Email_Format_Invalid_Template(f_mail);
                return tmpResultValue;
            }
            if (byExternalBase.mail.host == null || byExternalBase.mail.host == "")
            {
                tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Email_Config_Missing();
                return tmpResultValue;
            }
            int tmpCodeValue = this.generateSafetyCode();
            bool tmpSendResult = byExternalBase.mail.send(f_mail, byForm_Server.ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Email_Title(), byForm_Server.ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Email_Content(tmpCodeValue));
            this.rLog.write(byForm_Server.ku.byLog.Enum.logState.user, "用户注册发送验证码:" + f_mail + "  " + byForm_Server.ku.by.Object.ServerSession.getCurrentSession().ip);
            if (tmpSendResult)
            {
                byForm_Server.ku.by.Object.ServerSession.getCurrentSession().other = new object[] { tmpCodeValue, byForm_Server.ku.by.Object.datetime.getNow() };
                tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Send_Security_Code_Email_Succeed(f_mail);
                tmpResultValue.isOk = true;
                return tmpResultValue;
            }
            else
            {
                tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Send_Security_Code_Email_Failed(f_mail);
                return tmpResultValue;
            }
        }

        public byForm_Server.ku.byUser.Object.resultUser getAnonymousUser()
        {
            byForm_Server.ku.byUser.Object.resultUser tmpResultValue = new byForm_Server.ku.byUser.Object.resultUser();
            {
                byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
                string tmpCookie = tmpSession.Cookie;
                if (tmpCookie == null || tmpCookie == "")
                {
                    if (!this.createAnonymousUser(tmpResultValue).isOk)
                    {
                        return tmpResultValue;
                    }
                }
                else
                {
                    byForm_Server.ku.by.Object.Result tmpVerifyCookie = this.verifyCookies(tmpCookie);
                    if (!tmpVerifyCookie.isOk)
                    {
                        tmpResultValue.info = tmpVerifyCookie.info;
                        return tmpResultValue;
                    }
                    byForm_Server.ku.by.ToolClass.Sql.SelectTable tmpSelectTable17 = byForm_Server.ku.byUser.SqlExpression.LocalSql._17(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rAnonymous, this }, new object[] { tmpCookie });
                    byForm_Server.ku.by.ToolClass.SqlType tmpList = byForm_Server.ku.byUser.SqlExpression.LocalSql._16(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { tmpSelectTable17 });
                    if (tmpList.rows.count > 0)
                    {
                        byForm_Server.ku.by.Object.Row tmpRow = tmpList.rows[0];
                        if (System.Convert.ToBoolean(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iFreeze").value))
                        {
                            tmpResultValue.info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Annoymous_User_Freezed_Deny_Service();
                            return tmpResultValue;
                        }
                        byForm_Server.ku.by.ToolClass.SqlType tmpSelectTable19 = byForm_Server.ku.byUser.SqlExpression.LocalSql._19(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { (string)byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iID").value });
                        tmpResultValue.loginRow = ((byForm_Server.ku.byUser.SqlExpression.LocalSql._18(new byForm_Server.ku.by.ToolClass.ITableSource[] { tmpSelectTable19, this.rUserAdmin, this.rUserICO }, new object[] { byForm_Server.ku.byUser.Enum.uploadMode.userIco.ToString() })).rows[0] as byForm_Server.ku.byUser.Orm.Orm0);
                        tmpResultValue.isOk = true;
                    }
                    else
                    {
                        if (!this.createAnonymousUser(tmpResultValue).isOk)
                        {
                            return tmpResultValue;
                        }
                    }
                }
                if (tmpResultValue.loginRow != null)
                {
                    tmpSession.user = (tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea.clone();
                    tmpSession.other = tmpResultValue.loginRow;
                    if (this.loginSuccessEvent != null)
                    {
                        this.loginSuccessEvent((byForm_Server.ku.byUser.Orm.Orm0)tmpSession.other);
                    }
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString((tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iName", this.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent((tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iName").value)), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString((tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iDisplayName", this.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent((tmpResultValue.loginRow as byForm_Server.ku.byUser.Orm.Orm0).Tablea, "iDisplayName").value)), "=");
                }
            }
            return tmpResultValue;
        }

        public byForm_Server.ku.byUser.Object.resultUser createAnonymousUser(byForm_Server.ku.byUser.Object.resultUser f_resultUser)
        {
            byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
            byForm_Server.ku.by.Object.Row tmpAnonymousUserRow = new byForm_Server.ku.by.Object.Row() { _InitIdentity_ = this.rAnonymous };
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpAnonymousUserRow, "iIP", tmpSession.ip, "=");
            byForm_Server.ku.by.Object.Row tmpUserRow = new byForm_Server.ku.by.Object.Row() { _InitIdentity_ = this };
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserRow, "iID", byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpAnonymousUserRow, "iUserID", byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpAnonymousUserRow, "iID", byForm_Server.ku.byCommon.Identity.general.getGuid(), "="), "="), "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserRow, "iName", byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserRow, "iDisplayName", byForm_Server.ku.byUser.Object.ByUserStrings.Annoymous_User_Name_Template(byExternalBase.random.next(1111, 9999)), "="), "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iFreeze").value = false;
            byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRank").value = byForm_Server.ku.byUser.Enum.rank.anonymous;
            byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRegDt").value = byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAnonymousUserRow, "iRegDt").value = byForm_Server.ku.by.Object.datetime.getNow();
            try
            {
                System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                _objList_.Add(new object[] { tmpAnonymousUserRow });
                _tmpIdentityList_.Add(null);
                _objList_.Add(new object[] { tmpUserRow });
                _tmpIdentityList_.Add(null);
                SqlExpression.LocalSql.Tran_1(_tmpIdentityList_.ToArray(), _objList_, _values_);
            }
            catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
            {
                string message = thisiscsharpserverxclusiveexceptionidentifier.Message;
                f_resultUser.info = message;
                return f_resultUser;
            }
            byForm_Server.ku.by.ToolClass.SqlType tmpSelectTable23 = byForm_Server.ku.byUser.SqlExpression.LocalSql._23(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { (string)byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iID").value });
            f_resultUser.loginRow = ((byForm_Server.ku.byUser.SqlExpression.LocalSql._22(new byForm_Server.ku.by.ToolClass.ITableSource[] { tmpSelectTable23, this.rUserAdmin, this.rUserICO }, new object[] { byForm_Server.ku.byUser.Enum.uploadMode.userIco.ToString() })).rows[0] as byForm_Server.ku.byUser.Orm.Orm0);
            f_resultUser.isOk = true;
            return f_resultUser;
        }

        public byForm_Server.ku.byUser.Orm.Orm0 getSessionUserRow()
        {
            return this.pIsGetServerUserRow && byForm_Server.ku.by.Object.ServerSession.getCurrentSession().user != null ? (byForm_Server.ku.byUser.Orm.Orm0)byForm_Server.ku.by.Object.ServerSession.getCurrentSession().other : null;
        }

        public void init()
        {
            this.generateRsaKey();
        }

        public void generateRsaKey()
        {
            if (this.publicKey == null || this.publicKey == "")
            {
                string[] tmpKey = byExternalBase.security.rsaCreatePublicKeyAndPrivateKey();
                this.publicKey = tmpKey[0];
                this.privateKey = tmpKey[1];
            }
            {
                byForm_Server.ku.byCommon.Identity.session.clearEvent += delegate ()
                {
                    this.publicKeyWebClient.clear();
                };
                byForm_Server.ku.byCommon.Identity.session.removeEvent += delegate (byForm_Server.ku.by.Object.ServerSession f_session)
                {
                    if (this.publicKeyWebClient.containsKey(f_session))
                    {
                        this.publicKeyWebClient.remove(f_session);
                    }
                };
            }
        }

        public string getPublicKey()
        {
            if (this.publicKey == null || this.publicKey == "")
            {
                this.generateRsaKey();
            }
            return this.publicKey;
        }

        public bool regPublicKey(string f_publicKey)
        {
            byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
            if (!this.publicKeyWebClient.containsKey(tmpSession))
            {
                this.publicKeyWebClient.add(tmpSession, f_publicKey);
            }
            else
            {
                this.publicKeyWebClient[tmpSession] = f_publicKey;
            }
            return true;
        }

        public string rsaEncode(string f_encede)
        {
            if (f_encede == null || f_encede == "" || f_encede.Length > 245)
            {
                return f_encede;
            }
            {
                byForm_Server.ku.by.Object.ServerSession tmpSession = byForm_Server.ku.by.Object.ServerSession.getCurrentSession();
                if (this.publicKeyWebClient.containsKey(tmpSession))
                {
                    return byExternalBase.security.rsaEncrypt(f_encede, this.publicKeyWebClient[tmpSession]);
                }
            }
            return f_encede;
        }

        public string rsaDecode(string f_decode)
        {
            if (f_decode == null || f_decode.Length != 344)
            {
                return f_decode;
            }
            return byExternalBase.security.rsaDecrypt(f_decode, this.privateKey);
        }

        public string md5Plus(string f_sourcePwd)
        {
            System.Text.StringBuilder tmpSb = new System.Text.StringBuilder();
            for (int i = 0; i < f_sourcePwd.Length; i++)
            {
                tmpSb.Append(byForm_Server.ku.ExtendMethod.intToString((int)f_sourcePwd[i], 2));
                tmpSb.Append(f_sourcePwd[f_sourcePwd.Length - i - 1]);
                tmpSb.Append(byForm_Server.ku.ExtendMethod.intToString((int)f_sourcePwd[i], 16));
            }
            return byExternalBase.security.md5(tmpSb.ToString());
        }

        public string verifyPwd(string f_pwd)
        {
            if (!byForm_Server.ku.ExtendMethod.isMatch(f_pwd, this.regPwd, byForm_Server.ku.by.Enum.RegexMode.multiIgnoreCase))
            {
                return byForm_Server.ku.byUser.Object.ByUserStrings.Info_Password_Pattern_Invalid();
            }
            return null;
        }

        public string verifyUserFormat(string f_user)
        {
            if (f_user.Length < 2 || f_user.Length > 32)
            {
                return byForm_Server.ku.byUser.Object.ByUserStrings.Info_UserName_Length_Invalid();
            }
            if (!byForm_Server.ku.ExtendMethod.isMatch(f_user, this.regUserName, byForm_Server.ku.by.Enum.RegexMode.multiIgnoreCase))
            {
                return byForm_Server.ku.byUser.Object.ByUserStrings.Info_UserName_Pattern_Invalid();
            }
            return null;
        }

        public string verifyRegisterUser(string f_user)
        {
            {
                f_user = this.rsaDecode(f_user);
            }
            string tmpUserFormat = this.verifyUserFormat(f_user);
            if (tmpUserFormat != null)
            {
                return tmpUserFormat;
            }
            {
                bool tmpResultValue = this.userExists(f_user);
                return tmpResultValue ? byForm_Server.ku.byUser.Object.ByUserStrings.Info_UserName_Already_Exist() : null;
            }
        }

        public bool userExists(string f_user)
        {
            {
                f_user = this.rsaDecode(f_user);
            }
            if (this.verifyUserFormat(f_user) != null)
            {
                return false;
            }
            {
                byForm_Server.ku.by.ToolClass.SqlType tmpList = byForm_Server.ku.byUser.SqlExpression.LocalSql._24(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_user });
                return tmpList.rows.count > 0 ? true : false;
            }
        }

        public event byForm_Server.ku.by.Delegates.KuDelegates.Delegate_1<byForm_Server.ku.byUser.Orm.Orm0> loginSuccessEvent;

        public event byForm_Server.ku.by.Delegates.KuDelegates.Delegate_1<byForm_Server.ku.byUser.Orm.Orm0> userExitEvent;
    }
}
