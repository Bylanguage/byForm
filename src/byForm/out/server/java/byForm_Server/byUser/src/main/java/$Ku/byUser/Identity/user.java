package $Ku.byUser.Identity;

public class user extends $Ku.by.Identity.Table {
    public java.lang.Boolean pIsGetServerUserRow = false;
    public $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.Datetime> pDenyIpDic;
    public java.lang.Integer pDenyIpInterval = 0;
    public java.lang.Integer pLoginExpire = 0;
    public $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.List<$Ku.by.Object.Datetime>> pDenyUserDic;
    public java.lang.String pRegMobile;
    public java.lang.String pRegMaile;
    public java.lang.String pRegSafetyCode;
    public java.lang.Boolean pConfigSMSCode = false;
    public java.lang.String publicKey;
    public java.lang.String privateKey;
    public $Ku.by.Object.Dictionary<$Ku.by.Object.ServerSession, java.lang.String> publicKeyWebClient;
    public java.lang.String regPwd;
    public java.lang.String regUserName;
    public $Ku.byUser.Enum.verifyMode pVerifyMode = $Ku.byUser.Enum.verifyMode.values()[0];
    public $Ku.by.Identity.Attribute iFreeze;
    public $Ku.by.Identity.Attribute iRank;
    public $Ku.by.Identity.Name iName;
    public $Ku.by.Identity.Attribute iPassword;
    public $Ku.by.Identity.Attribute iDisplayName;
    public $Ku.by.Identity.Attribute iMobile;
    public $Ku.by.Identity.Attribute iMail;
    public $Ku.by.Identity.Attribute iCerMode;
    public $Ku.by.Identity.Attribute iCerName;
    public $Ku.by.Identity.Attribute iCerNO;
    public $Ku.by.Identity.Attribute iMoney;
    public $Ku.by.Identity.Attribute iRemark;
    public $Ku.by.Identity.Attribute iRegDt;
    public $Ku.byUser.Identity.userICO rUserICO;
    public $Ku.byUser.Identity.userUpload rUserUpload;
    public $Ku.byLog.Identity.log rLog;
    public $Ku.byUser.Identity.userAdmin rUserAdmin;
    public $Ku.byUser.Identity.anonymous rAnonymous;
    private $Ku.by.ToolClass.Sql.SelectTable Source;
    public $Ku.byUser.Event.userloginSuccessEvent loginSuccessEvent = new $Ku.byUser.Event.userloginSuccessEvent();
    public $Ku.byUser.Event.useruserExitEvent userExitEvent = new $Ku.byUser.Event.useruserExitEvent();

    public user() {
        this.pIsGetServerUserRow = true;
        this.pDenyIpDic = new $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.Datetime>($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Datetime.class));
        this.pDenyIpInterval = 60;
        this.pLoginExpire = 2;
        this.pDenyUserDic = new $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.List<$Ku.by.Object.Datetime>>($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.List.class).addTypeArgument(0, $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Datetime.class)));
        this.pRegMobile = "^[\\d]{11}$";
        this.pRegMaile = "^[_\\-0-9a-z]+@(([_\\-0-9a-z]{1,32}\\.[0-9a-z]{2,6})|([_\\-0-9a-z]{1,32}\\.[_\\-0-9a-z]{1,32}\\.[0-9a-z]{2,6}))$";
        this.pRegSafetyCode = "^[0-9]{4,8}$";
        this.pConfigSMSCode = false;
        this.publicKeyWebClient = new $Ku.by.Object.Dictionary<$Ku.by.Object.ServerSession, java.lang.String>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.ServerSession.class), $Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class));
        this.regPwd = "^[a-zA-Z0-9_@#$]{6,32}$";
        this.regUserName = "^[0-9a-zA-Z@_#\\.\\-]{2,32}$";
        this.pVerifyMode = $Ku.byUser.Enum.verifyMode.cookie;
    }


    public java.lang.Boolean userLoginChild($Ku.byUser.Object.resultUser f_resultValue, java.lang.String f_user, java.lang.String f_pwd) {
        f_resultValue.info = this.verifyUserFormat(f_user);
        if (!java.util.Objects.equals(f_resultValue.info, null)) {
            return false;
        }
        f_resultValue.info = this.verifyPwd(f_pwd);
        if (!java.util.Objects.equals(f_resultValue.info, null)) {
            return false;
        }
        return true;
    }

    public $Ku.byUser.Object.resultUser userLogin(java.lang.String f_user, java.lang.String f_pwd) {
        $Ku.byUser.Object.resultUser tmpResultValue = new $Ku.byUser.Object.resultUser();
        {
            f_user = this.rsaDecode(f_user);
            f_pwd = this.rsaDecode(f_pwd);
            $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
            java.lang.String tmpSessionIp = tmpSession.ip;
            if (this.pDenyIpDic.containsKey(tmpSessionIp)) {
                java.lang.String tmpLogSummary = $Ku.byUser.Object.ByUserStrings.Info_IP_Locked_Template(tmpSessionIp, this.pDenyIpInterval);
                this.rLog.write($Ku.byLog.Enum.logState.user, f_user + "  " + tmpLogSummary + "  " + tmpSession.ip);
                $Ku.by.Object.Datetime tmpIp = this.pDenyIpDic.get(tmpSessionIp);
                if ($Ku.by.Object.Datetime.getNow().diffMinutes(tmpIp) > this.pDenyIpInterval) {
                    this.pDenyIpDic.remove(tmpSessionIp);
                }
                else {
                    tmpResultValue.info = tmpLogSummary;
                    return tmpResultValue;
                }
            }
            if (this.pDenyUserDic.containsKey(f_user)) {
                $Ku.by.Object.List<$Ku.by.Object.Datetime> tmpDtList = this.pDenyUserDic.get(f_user);
                if (tmpDtList.count() > 5) {
                    if ($Ku.by.Object.Datetime.getNow().diffMinutes(tmpDtList.get(tmpDtList.count() - 1)) > this.pDenyIpInterval) {
                        this.pDenyUserDic.remove(f_user);
                    }
                    else {
                        tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Login_MultipleTimes_Locked(this.pDenyIpInterval);
                        this.rLog.write($Ku.byLog.Enum.logState.user, f_user + "  " + tmpResultValue.info + "  " + tmpSession.ip);
                        return tmpResultValue;
                    }
                }
            }
            $Ku.by.ToolClass.SqlType tmpSelectTable1 = $Ku.byUser.SqlExpression.LocalSql._1(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_user,f_pwd});
            $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.Orm0> tmpList = $Ku.byUser.SqlExpression.LocalSql._0(new $Ku.by.ToolClass.ITableSource[]{tmpSelectTable1,this.rUserAdmin,this.rUserICO}, new Object[]{$Ku.byUser.Enum.uploadMode.userIco.toString()});
            if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(tmpList.rows.count(), 0)) {
                if (this.pDenyUserDic.containsKey(f_user)) {
                    this.pDenyUserDic.get(f_user).add($Ku.by.Object.Datetime.getNow());
                }
                else {
                    $Ku.by.Object.List<$Ku.by.Object.Datetime> tmpDtList = new $Ku.by.Object.List<$Ku.by.Object.Datetime>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Datetime.class));
                    tmpDtList.add($Ku.by.Object.Datetime.getNow());
                    this.pDenyUserDic.add(f_user, tmpDtList);
                }
                tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Login_MultipleTimes_Will_Lock(this.pDenyIpInterval);
                this.rLog.write($Ku.byLog.Enum.logState.user, f_user + "  " + tmpResultValue.info + "  " + tmpSession.ip);
                return tmpResultValue;
            }
            else {
                if (((java.lang.Boolean) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpList.rows.get(0).Table0, "iFreeze").value)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Freezed_User();
                    this.rLog.write($Ku.byLog.Enum.logState.user, ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpList.rows.get(0).Table0, "iID").value) + "  " + f_user + "  " + tmpResultValue.info + "  " + tmpSession.ip);
                    return tmpResultValue;
                }
                if (this.pDenyUserDic.containsKey(f_user)) {
                    this.pDenyUserDic.remove(f_user);
                }
                tmpResultValue.loginRow = tmpList.rows.get(0);
                tmpResultValue.isOk = true;
                tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Login_Completed();
                tmpResultValue.loginRow = tmpList.rows.get(0);
                tmpSession.user = tmpList.rows.get(0).Table0;
                tmpSession.other = tmpList.rows.get(0);
                this.rLog.write($Ku.byLog.Enum.logState.user, ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpList.rows.get(0).Table0, "iID").value) + "  " + f_user + "  " + tmpResultValue.info + "  " + tmpSession.ip);
                if (!java.util.Objects.equals(this.loginSuccessEvent, null)) {
                    this.loginSuccessEvent.invoke(tmpList.rows.get(0));
                }
                if (!this.publicKeyWebClient.containsKey(tmpSession)) {
                    tmpResultValue.loginRow = null;
                    tmpResultValue.isOk = false;
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Login_Failed_RSA_Missing();
                    return tmpResultValue;
                }
                else {
                    java.lang.String tmpFrontPublicKey = this.publicKeyWebClient.get(tmpSession);
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpResultValue.loginRow.Table0, "iName").value = this.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpResultValue.loginRow.Table0, "iName").value));
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpResultValue.loginRow.Table0, "iDisplayName").value = this.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpResultValue.loginRow.Table0, "iDisplayName").value));
                }
            }
            return tmpResultValue;
        }
    }

    public java.lang.Boolean confirmUserIsLogin() {
        return confirmUserIsLogin($Ku.byUser.Enum.confirmUserIsLoginMode.verifyLogin);
    }

    public java.lang.Boolean confirmUserIsLogin($Ku.byUser.Enum.confirmUserIsLoginMode f_verifyMode) {
        {
            $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
            if (java.util.Objects.equals(this.pVerifyMode, $Ku.byUser.Enum.verifyMode.cookie)) {
                return java.util.Objects.equals(tmpSession.getCookie(), null) || java.util.Objects.equals(tmpSession.getCookie(), "") ? false : true;
            }
            else {
                return java.util.Objects.equals(tmpSession.user, null) || java.util.Objects.equals(((java.lang.Object) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpSession.user, "iID").value), null) || java.util.Objects.equals(((java.lang.Object) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpSession.user, "iID").value), "") ? false : true;
            }
        }
    }

    public java.lang.Boolean confirmUserIsLogin(java.lang.String f_userID) {
        {
            $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
            if (java.util.Objects.equals(this.pVerifyMode, $Ku.byUser.Enum.verifyMode.cookie)) {
                java.lang.String tmpUserID = tmpSession.getCookie();
                if (java.util.Objects.equals(tmpUserID, null) || java.util.Objects.equals(tmpUserID, "")) {
                    return false;
                }
                else {
                    return java.util.Objects.equals(tmpUserID, f_userID) ? true : false;
                }
            }
            else {
                return java.util.Objects.equals(tmpSession.user, null) || java.util.Objects.equals(((java.lang.Object) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpSession.user, "iID").value), null) || java.util.Objects.equals(((java.lang.Object) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpSession.user, "iID").value), "") ? false : true;
            }
        }
    }

    public void exit() {
        {
            $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
            if (!java.util.Objects.equals(this.userExitEvent, null)) {
                this.userExitEvent.invoke(($Ku.byUser.Orm.Orm0) tmpSession.other);
            }
            tmpSession.user = null;
            tmpSession.other = null;
        }
    }

    public $Ku.by.Object.Result userReg($Ku.by.Object.Row f_userRow, java.lang.String f_SafetyCode) {
        {
            f_SafetyCode = this.rsaDecode(f_SafetyCode);
            $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iDisplayName").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iDisplayName").value));
            $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMail").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMail").value));
            $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMobile").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMobile").value));
            $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iName").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iName").value));
            if (this.pConfigSMSCode) {
                $Ku.by.Object.Result tmpResultValue = this.verifySafetyCode(f_SafetyCode);
                if (!tmpResultValue.isOk) {
                    return tmpResultValue;
                }
            }
            return this.userReg(f_userRow);
        }
    }

    public $Ku.by.Object.Result userReg($Ku.by.Object.Row f_userRow) {
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iID").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iID").value));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iRank").value = $Ku.byUser.Enum.rank.register;
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iName").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iName").value));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iPassword").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iPassword").value));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMobile").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMobile").value));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMail").value = this.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iMail").value));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_userRow, "iRegDt").value = $Ku.byCommon.Identity.general.getServerDatetime();
        $Ku.by.Object.Result tmpResultValue = new $Ku.by.Object.Result();
        if (java.util.Objects.equals(f_userRow, null)) {
            tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Register_UserName_Cannot_Be_Null();
            tmpResultValue.isOk = false;
            return tmpResultValue;
        }
        java.lang.Integer tmpRowCount = $Ku.byUser.SqlExpression.LocalSql._2(new Object[]{f_userRow});
        if (!java.util.Objects.equals(tmpRowCount, 1)) {
            tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Register_Failed();
            tmpResultValue.isOk = false;
            return tmpResultValue;
        }
        tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Register_Completed();
        tmpResultValue.isOk = true;
        return tmpResultValue;
    }

    public $Ku.by.Object.Result userPwdModif(java.lang.String f_sourcePwd, java.lang.String f_newPwd, java.lang.String f_ID) {
        {
            f_sourcePwd = this.rsaDecode(f_sourcePwd);
            f_newPwd = this.rsaDecode(f_newPwd);
            f_ID = this.rsaDecode(f_ID);
            $Ku.by.Object.Result tmpResultValue = new $Ku.by.Object.Result();
            $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
            if (java.util.Objects.equals(tmpSession, null) || java.util.Objects.equals(tmpSession.user, null) || !java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent((($Ku.by.Object.Row) tmpSession.user), "iID").value), f_ID)) {
                tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Modify_Failed_Illegal();
                tmpResultValue.isOk = false;
                return tmpResultValue;
            }
            $Ku.by.ToolClass.SqlType tmpList = $Ku.byUser.SqlExpression.LocalSql._3(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_ID,f_sourcePwd});
            if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(tmpList.rows.count(), 1)) {
                if (((java.lang.Boolean) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpList.rows.get(0), "iFreeze").value)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Modify_Failed_Freezed();
                    tmpResultValue.isOk = false;
                    return tmpResultValue;
                }
                java.lang.Integer tmpRowCount = $Ku.byUser.SqlExpression.LocalSql._4(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_newPwd,f_ID});
                if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(tmpRowCount, 1)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Modify_Completed();
                    tmpResultValue.isOk = true;
                    return tmpResultValue;
                }
                else {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Modify_Failed();
                    tmpResultValue.isOk = false;
                    return tmpResultValue;
                }
            }
            else {
                tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Modify_Failed_Old_Password_Wrong();
                tmpResultValue.isOk = false;
                return tmpResultValue;
            }
        }
    }

    public $Ku.by.Object.Result userPwdModif(java.lang.String f_userMailMobile, $Ku.byUser.Enum.safetyCodeMode f_safetyCodeMode, java.lang.String f_newPwd, java.lang.String f_safetyCode) {
        {
            $Ku.by.Object.Result tmpResultValue = new $Ku.by.Object.Result();
            f_userMailMobile = this.rsaDecode(f_userMailMobile);
            f_newPwd = this.rsaDecode(f_newPwd);
            f_safetyCode = this.rsaDecode(f_safetyCode);
            tmpResultValue = this.verifySafetyCode(f_safetyCode);
            if (!tmpResultValue.isOk) {
                return tmpResultValue;
            }
            $Ku.by.Object.List<$Ku.by.Object.Row> rowList = null;
            java.lang.String tmpVerfy = null;
            if (java.util.Objects.equals(f_safetyCodeMode, $Ku.byUser.Enum.safetyCodeMode.user)) {
                tmpVerfy = this.verifyUserFormat(f_userMailMobile);
                if (!java.util.Objects.equals(tmpVerfy, null)) {
                    tmpResultValue.info = tmpVerfy;
                    return tmpResultValue;
                }
                rowList = ($Ku.byUser.SqlExpression.LocalSql._5(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_userMailMobile})).rows;
            }
            else {
                if (java.util.Objects.equals(f_safetyCodeMode, $Ku.byUser.Enum.safetyCodeMode.mail)) {
                    tmpVerfy = this.verifyMailFormat(f_userMailMobile);
                    if (!java.util.Objects.equals(tmpVerfy, null)) {
                        tmpResultValue.info = tmpVerfy;
                        return tmpResultValue;
                    }
                    rowList = ($Ku.byUser.SqlExpression.LocalSql._6(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_userMailMobile})).rows;
                }
                else {
                    if (java.util.Objects.equals(f_safetyCodeMode, $Ku.byUser.Enum.safetyCodeMode.mobile)) {
                        tmpVerfy = this.verifyUserFormat(f_userMailMobile);
                        if (!java.util.Objects.equals(tmpVerfy, null)) {
                            tmpResultValue.info = tmpVerfy;
                            return tmpResultValue;
                        }
                        rowList = ($Ku.byUser.SqlExpression.LocalSql._7(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_userMailMobile})).rows;
                    }
                }
            }
            if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(rowList.count(), 0)) {
                tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Illegal_User();
                return tmpResultValue;
            }
            else {
                if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(rowList.count(), 1)) {
                    if (((java.lang.Boolean) $Ku.by.ToolClass.ToolFunction.GetRowComponent(rowList.get(0), "iFreeze").value)) {
                        tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Freezed_User();
                        return tmpResultValue;
                    }
                    this.rLog.write($Ku.byLog.Enum.logState.user, ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(rowList.get(0), "iID").value) + "  " + ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(rowList.get(0), "iName").value) + "  " + "用户修改密码" + "  " + $Ku.by.Object.ServerSession.getCurrentSession().ip);
                    try {
                        java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                        java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                        java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                        $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_newPwd,((java.lang.String)$Ku.by.ToolClass.ToolFunction.GetRowComponent(rowList.get(0), "iID").value))));
                        $tmpIdentityList.add(this);
                        $Ku.byUser.SqlExpression.LocalSql.Tran_0($tmpIdentityList, $objList, $values);
                    }
                    catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
                        String message = $thisisjavaserverxclusiveexceptionidentifier.toString();
                        tmpResultValue.info = message;
                        return tmpResultValue;
                    }

                }
            }
            tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Reset_Password_Completed();
            tmpResultValue.isOk = true;
            return tmpResultValue;
        }
    }

    public java.lang.String verifyMobileFormat(java.lang.String f_mobile) {
        if (!$Ku.by.ToolClass.StringUtil.isMatch(f_mobile, this.pRegMobile, $Ku.by.Enum.RegexMode.multiIgnoreCase)) {
            return $Ku.byUser.Object.ByUserStrings.Info_Phone_Must_11_Digits();
        }
        return null;
    }

    public java.lang.Boolean verifyMobileExists(java.lang.String f_mobile) {
        {
            f_mobile = this.rsaDecode(f_mobile);
        }
        if (!java.util.Objects.equals(this.verifyMobileFormat(f_mobile), null)) {
            return false;
        }
        {
            $Ku.by.ToolClass.SqlType tmpList = $Ku.byUser.SqlExpression.LocalSql._9(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_mobile});
            return tmpList.rows.count() > 0 ? true : false;
        }
    }

    public java.lang.String verifyRegMail(java.lang.String f_mail) {
        {
            f_mail = this.rsaDecode(f_mail);
        }
        java.lang.String tmpFormat = this.verifyMailFormat(f_mail);
        if (!java.util.Objects.equals(tmpFormat, null)) {
            return tmpFormat;
        }
        {
            if (this.verifyMailExists(f_mail).isOk) {
                return $Ku.byUser.Object.ByUserStrings.Info_Email_Already_Exists();
            }
        }
        return null;
    }

    public java.lang.String verifyMailFormat(java.lang.String f_mail) {
        if (f_mail.length() > 64 || f_mail.length() < 6) {
            return $Ku.byUser.Object.ByUserStrings.Info_Email_Too_Long_Or_Too_Short();
        }
        if (!$Ku.by.ToolClass.StringUtil.isMatch(f_mail, this.pRegMaile, $Ku.by.Enum.RegexMode.multiIgnoreCase)) {
            return $Ku.byUser.Object.ByUserStrings.Info_Email_Format_Invalid();
        }
        return null;
    }

    public $Ku.by.Object.Result verifyMailExists(java.lang.String f_mail) {
        {
            f_mail = this.rsaDecode(f_mail);
        }
        $Ku.by.Object.Result tmpResulValue = new $Ku.by.Object.Result();
        tmpResulValue.info = this.verifyMailFormat(f_mail);
        if (!java.util.Objects.equals(tmpResulValue.info, null)) {
            return tmpResulValue;
        }
        {
            $Ku.by.ToolClass.SqlType tmpList = $Ku.byUser.SqlExpression.LocalSql._10(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_mail});
            if (tmpList.rows.count() > 0) {
                tmpResulValue.isOk = true;
            }
            else {
                tmpResulValue.info = $Ku.byUser.Object.ByUserStrings.Info_Email_Not_Exist();
            }
            return tmpResulValue;
        }
    }

    public java.lang.Boolean verifySafetyCodeFormat(java.lang.String f_SafetyCode) {
        return $Ku.by.ToolClass.StringUtil.isMatch(f_SafetyCode, "^[\\d]{4,8}$", $Ku.by.Enum.RegexMode.multiline);
    }

    public $Ku.by.Object.Result verifySafetyCode(java.lang.String f_safetyCode) {
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        if (!$Ku.by.ToolClass.StringUtil.isMatch(f_safetyCode, this.pRegSafetyCode, $Ku.by.Enum.RegexMode.multiIgnoreCase)) {
            tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_SecurityCode_Invalid();
            return tmpResult;
        }
        $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
        if (java.util.Objects.equals(tmpSession, null)) {
            tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_SecurityCode_Session_Timeout();
            return tmpResult;
        }
        if (!java.util.Objects.equals(tmpSession.other, null)) {
            java.lang.Object[] objArr = (java.lang.Object[]) tmpSession.other;
            tmpSession.other = null;
            if (!java.util.Objects.equals(f_safetyCode, objArr[0].toString())) {
                tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_SecurityCode_Dismatch();
                return tmpResult;
            }
            else {
                java.lang.Double tmpMin = (($Ku.by.Object.Datetime) objArr[1]).diffMinutes($Ku.by.Object.Datetime.getNow());
                if (tmpMin > 15D) {
                    tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_SecurityCode_Timeout();
                    return tmpResult;
                }
            }
            tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_SecurityCode_Verification_Succeed();
            tmpResult.isOk = true;
            return tmpResult;
        }
        tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_SecurityCode_Missing();
        return tmpResult;
    }

    public $Ku.by.Object.Result verifyCookies(java.lang.String f_cookie) {
        $Ku.by.Object.Result tmpResultValue = new $Ku.by.Object.Result();
        if (!$Ku.by.ToolClass.StringUtil.isMatch(f_cookie, "^[0-9a-z]{2,32}$", $Ku.by.Enum.RegexMode.multiIgnoreCase)) {
            tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Cookie_Invalid(f_cookie);
            return tmpResultValue;
        }
        tmpResultValue.isOk = true;
        return tmpResultValue;
    }

    public java.lang.Integer generateSafetyCode() {
        java.lang.Integer tmpMin = byExternal.random.next(1000, 2000);
        java.lang.Integer tmpMax = byExternal.random.next(8000, 9999);
        return byExternal.random.next(tmpMin, tmpMax);
    }

    public $Ku.by.Object.Result postSafety($Ku.byUser.Enum.safetyCodeMode f_safetyCodeMode, java.lang.String f_userMobileMail) {
        $Ku.by.Object.Result tmpResultValue = new $Ku.by.Object.Result();
        f_userMobileMail = this.rsaDecode(f_userMobileMail);
        switch (f_safetyCodeMode) {
            case user:
                if (!java.util.Objects.equals(this.verifyUserFormat(f_userMobileMail), null)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_UserName_Invalid();
                    return tmpResultValue;
                }
                $Ku.by.ToolClass.SqlType tmpUserList = $Ku.byUser.SqlExpression.LocalSql._11(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_userMobileMail});
                if (!java.util.Objects.equals(tmpUserList.rows.count(), 1)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_UserName_Not_Exist();
                    return tmpResultValue;
                }
                if (((java.lang.Boolean) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserList.rows.get(0), "iFreeze").value)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Freezed_User();
                    return tmpResultValue;
                }
                $Ku.by.Object.Result mobileResult = this.postSafetyModbile(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserList.rows.get(0), "iMobile").value));
                if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(mobileResult.isOk, true)) {
                    return mobileResult;
                }
                else {
                    $Ku.by.Object.Result mailResult = this.postSafetyMail(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserList.rows.get(0), "iMail").value));
                    if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(mailResult.isOk, false)) {
                        mailResult.info += "\r\n" + mobileResult.info;
                        ;
                    }
                    return mailResult;
                }
            case mail:
                if (!java.util.Objects.equals(this.verifyMailFormat(f_userMobileMail), null)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Email_Invalid();
                    return tmpResultValue;
                }
                $Ku.by.ToolClass.SqlType tmpMailList = $Ku.byUser.SqlExpression.LocalSql._12(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_userMobileMail});
                if (!java.util.Objects.equals(tmpMailList.rows.count(), 1)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Email_Not_Exist();
                    return tmpResultValue;
                }
                if (((java.lang.Boolean) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpMailList.rows.get(0), "iFreeze").value)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Email_Freezed();
                    return tmpResultValue;
                }
                return this.postSafetyMail(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpMailList.rows.get(0), "iMail").value));
            case mobile:
                if (!java.util.Objects.equals(this.verifyMobileFormat(f_userMobileMail), null)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Phone_Invalid();
                    return tmpResultValue;
                }
                $Ku.by.ToolClass.SqlType tmpMobileList = $Ku.byUser.SqlExpression.LocalSql._13(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_userMobileMail});
                if (!java.util.Objects.equals(tmpMobileList.rows.count(), 1)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Phone_Not_Exist();
                    return tmpResultValue;
                }
                if (((java.lang.Boolean) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpMobileList.rows.get(0), "iFreeze").value)) {
                    tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Phone_Freezed();
                    return tmpResultValue;
                }
                return this.postSafetyModbile(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpMobileList.rows.get(0), "iMobile").value));
        }
        return tmpResultValue;
    }

    public $Ku.by.Object.Result postSafetyModbile(java.lang.String f_mobile) {
        $Ku.by.Object.Result tmpMobileResult = this.postSafetyCodeToMobile(f_mobile);
        return tmpMobileResult;
    }

    public $Ku.by.Object.Result postSafetyMail(java.lang.String f_mail) {
        $Ku.by.Object.Result tmpMailResult = this.postSafetyCodeToMail(f_mail);
        return tmpMailResult;
    }

    public $Ku.by.Object.Result postSafetyReg(java.lang.String f_mail, java.lang.String f_mobile) {
        {
            $Ku.by.Object.Result tmpResultValue = new $Ku.by.Object.Result();
            f_mail = this.rsaDecode(f_mail);
            f_mobile = this.rsaDecode(f_mobile);
            tmpResultValue.info = this.verifyMailFormat(f_mail);
            if (!java.util.Objects.equals(tmpResultValue.info, null)) {
                return tmpResultValue;
            }
            tmpResultValue.info = this.verifyMobileFormat(f_mobile);
            if (!java.util.Objects.equals(tmpResultValue.info, null)) {
                return tmpResultValue;
            }
            $Ku.by.ToolClass.SqlType tmpList = $Ku.byUser.SqlExpression.LocalSql._14(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_mobile});
            if (tmpList.rows.count() > 0) {
                tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Phone_Already_Exists();
                return tmpResultValue;
            }
            $Ku.by.ToolClass.SqlType tmpList2 = $Ku.byUser.SqlExpression.LocalSql._15(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_mail});
            if (tmpList2.rows.count() > 0) {
                tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Email_Already_Exists();
                return tmpResultValue;
            }
            $Ku.by.Object.Result mobileResult = this.postSafetyModbile(f_mobile);
            if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(mobileResult.isOk, true)) {
                return mobileResult;
            }
            else {
                $Ku.by.Object.Result mailResult = this.postSafetyMail(f_mail);
                if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(mailResult.isOk, false)) {
                    mailResult.info += "\r\n" + mobileResult.info;
                    ;
                }
                return mailResult;
            }
        }
    }

    public $Ku.by.Object.Result postSafetyCodeToMobile(java.lang.String f_mobile) {
        f_mobile = this.rsaDecode(f_mobile);
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        java.lang.Integer tmpCodeValue = this.generateSafetyCode();
        if (java.util.Objects.equals(this.verifyMobileFormat(f_mobile), null)) {
            java.lang.String tmpResultValue = $Ku.byExternalSMS.Object.feigeSend.sendSafetyCode(f_mobile, $Ku.by.ToolClass.ToolFunction.toString(tmpCodeValue));
            this.rLog.write($Ku.byLog.Enum.logState.user, "用户注册发送验证码" + f_mobile + "  " + $Ku.by.Object.ServerSession.getCurrentSession().ip);
            if (java.util.Objects.equals(tmpResultValue, null)) {
                $Ku.by.Object.ServerSession.getCurrentSession().other = new java.lang.Object[]{tmpCodeValue,$Ku.by.Object.Datetime.getNow()};
                tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Mobile();
                tmpResult.isOk = true;
                return tmpResult;
            }
            else {
                tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Mobile_Failed() + tmpResultValue;
                return tmpResult;
            }
        }
        else {
            tmpResult.info = $Ku.byUser.Object.ByUserStrings.Info_Phone_Invalid();
            return tmpResult;
        }
    }

    public $Ku.by.Object.Result postSafetyCodeToMail(java.lang.String f_mail) {
        f_mail = this.rsaDecode(f_mail);
        $Ku.by.Object.Result tmpResultValue = new $Ku.by.Object.Result();
        if (!java.util.Objects.equals(this.verifyMailFormat(f_mail), null)) {
            tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Email_Format_Invalid_Template(f_mail);
            return tmpResultValue;
        }
        if (java.util.Objects.equals(byExternal.mail.host, null) || java.util.Objects.equals(byExternal.mail.host, "")) {
            tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Email_Config_Missing();
            return tmpResultValue;
        }
        java.lang.Integer tmpCodeValue = this.generateSafetyCode();
        java.lang.Boolean tmpSendResult = byExternal.mail.send(f_mail, $Ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Email_Title(), $Ku.byUser.Object.ByUserStrings.Info_Send_SecurityCode_Email_Content(tmpCodeValue));
        this.rLog.write($Ku.byLog.Enum.logState.user, "用户注册发送验证码:" + f_mail + "  " + $Ku.by.Object.ServerSession.getCurrentSession().ip);
        if (tmpSendResult) {
            $Ku.by.Object.ServerSession.getCurrentSession().other = new java.lang.Object[]{tmpCodeValue,$Ku.by.Object.Datetime.getNow()};
            tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Send_Security_Code_Email_Succeed(f_mail);
            tmpResultValue.isOk = true;
            return tmpResultValue;
        }
        else {
            tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Send_Security_Code_Email_Failed(f_mail);
            return tmpResultValue;
        }
    }

    public $Ku.byUser.Object.resultUser getAnonymousUser() {
        $Ku.byUser.Object.resultUser tmpResultValue = new $Ku.byUser.Object.resultUser();
        {
            $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
            java.lang.String tmpCookie = tmpSession.getCookie();
            if (java.util.Objects.equals(tmpCookie, null) || java.util.Objects.equals(tmpCookie, "")) {
                if (!this.createAnonymousUser(tmpResultValue).isOk) {
                    return tmpResultValue;
                }
            }
            else {
                $Ku.by.Object.Result tmpVerifyCookie = this.verifyCookies(tmpCookie);
                if (!tmpVerifyCookie.isOk) {
                    tmpResultValue.info = tmpVerifyCookie.info;
                    return tmpResultValue;
                }
                $Ku.by.ToolClass.Sql.SelectTable tmpSelectTable17 = $Ku.byUser.SqlExpression.LocalSql._17(new $Ku.by.ToolClass.ITableSource[]{this.rAnonymous,this}, new Object[]{tmpCookie});
                $Ku.by.ToolClass.SqlType tmpList = $Ku.byUser.SqlExpression.LocalSql._16(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{tmpSelectTable17});
                if (tmpList.rows.count() > 0) {
                    $Ku.by.Object.Row tmpRow = tmpList.rows.get(0);
                    if (((java.lang.Boolean) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iFreeze").value)) {
                        tmpResultValue.info = $Ku.byUser.Object.ByUserStrings.Info_Annoymous_User_Freezed_Deny_Service();
                        return tmpResultValue;
                    }
                    $Ku.by.ToolClass.SqlType tmpSelectTable19 = $Ku.byUser.SqlExpression.LocalSql._19(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{((java.lang.String)$Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iID").value)});
                    tmpResultValue.loginRow = ($Ku.byUser.SqlExpression.LocalSql._18(new $Ku.by.ToolClass.ITableSource[]{tmpSelectTable19,this.rUserAdmin,this.rUserICO}, new Object[]{$Ku.byUser.Enum.uploadMode.userIco.toString()})).rows.get(0);
                    tmpResultValue.isOk = true;
                }
                else {
                    if (!this.createAnonymousUser(tmpResultValue).isOk) {
                        return tmpResultValue;
                    }
                }
            }
            if (!java.util.Objects.equals(tmpResultValue.loginRow, null)) {
                tmpSession.user = tmpResultValue.loginRow.Table0.Copy();
                tmpSession.other = tmpResultValue.loginRow;
                if (!java.util.Objects.equals(this.loginSuccessEvent, null)) {
                    this.loginSuccessEvent.invoke(($Ku.byUser.Orm.Orm0) tmpSession.other);
                }
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpResultValue.loginRow.Table0, "iName").value = this.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpResultValue.loginRow.Table0, "iName").value));
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpResultValue.loginRow.Table0, "iDisplayName").value = this.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpResultValue.loginRow.Table0, "iDisplayName").value));
            }
        }
        return tmpResultValue;
    }

    public $Ku.byUser.Object.resultUser createAnonymousUser($Ku.byUser.Object.resultUser f_resultUser) {
        $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
        $Ku.by.Object.Row tmpAnonymousUserRow = $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Row(), ($t, $objs) -> {
            Class<?> $clazz = $t.getClass();
            try {
                for ($Ku.by.ToolClass.Entry<String, Object> $item : $objs){
                    if($item.k.equals("$Identity")){
                        java.lang.reflect.Method method = $clazz.getMethod("$setIdentity", $Ku.by.ToolClass.AbstractIdentityBase.class);
                        method.invoke($t, $item.v);
                    }
                    else{
                        $clazz.getField($item.k).set($t, $item.v);
                    }
                }
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
            return $t;
        }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("$Identity", this.rAnonymous));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAnonymousUserRow, "iIP").value = tmpSession.ip;
        $Ku.by.Object.Row tmpUserRow = $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Row(), ($t, $objs) -> {
            Class<?> $clazz = $t.getClass();
            try {
                for ($Ku.by.ToolClass.Entry<String, Object> $item : $objs){
                    if($item.k.equals("$Identity")){
                        java.lang.reflect.Method method = $clazz.getMethod("$setIdentity", $Ku.by.ToolClass.AbstractIdentityBase.class);
                        method.invoke($t, $item.v);
                    }
                    else{
                        $clazz.getField($item.k).set($t, $item.v);
                    }
                }
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
            return $t;
        }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("$Identity", this));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iID").value = $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAnonymousUserRow, "iUserID").value = $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAnonymousUserRow, "iID").value = $Ku.byCommon.Identity.general.getGuid();
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iName").value = $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iDisplayName").value = $Ku.byUser.Object.ByUserStrings.Annoymous_User_Name_Template(byExternal.random.next(1111, 9999));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iFreeze").value = false;
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRank").value = $Ku.byUser.Enum.rank.anonymous;
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRegDt").value = $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAnonymousUserRow, "iRegDt").value = $Ku.by.Object.Datetime.getNow();
        try {
            java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
            java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
            java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(tmpAnonymousUserRow)));
            $tmpIdentityList.add(null);
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(tmpUserRow)));
            $tmpIdentityList.add(null);
            $Ku.byUser.SqlExpression.LocalSql.Tran_1($tmpIdentityList, $objList, $values);
        }
        catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
            String message = $thisisjavaserverxclusiveexceptionidentifier.toString();
            f_resultUser.info = message;
            return f_resultUser;
        }

        $Ku.by.ToolClass.SqlType tmpSelectTable23 = $Ku.byUser.SqlExpression.LocalSql._23(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{((java.lang.String)$Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iID").value)});
        f_resultUser.loginRow = ($Ku.byUser.SqlExpression.LocalSql._22(new $Ku.by.ToolClass.ITableSource[]{tmpSelectTable23,this.rUserAdmin,this.rUserICO}, new Object[]{$Ku.byUser.Enum.uploadMode.userIco.toString()})).rows.get(0);
        f_resultUser.isOk = true;
        return f_resultUser;
    }

    public $Ku.byUser.Orm.Orm0 getSessionUserRow() {
        return this.pIsGetServerUserRow && !java.util.Objects.equals($Ku.by.Object.ServerSession.getCurrentSession().user, null) ? ($Ku.byUser.Orm.Orm0) $Ku.by.Object.ServerSession.getCurrentSession().other : null;
    }

    public void init() {
        this.generateRsaKey();
    }

    public void generateRsaKey() {
        if (java.util.Objects.equals(this.publicKey, null) || java.util.Objects.equals(this.publicKey, "")) {
            java.lang.String[] tmpKey = byExternal.security.rsaCreatePublicKeyAndPrivateKey();
            this.publicKey = tmpKey[0];
            this.privateKey = tmpKey[1];
        }
        {
            $Ku.byCommon.Identity.session.clearEvent.add(new $Ku.byCommon.Event.sessionclearEvent$Observer(new Object(), "$lambda") {
                public void invoke() {
                    $getThis$Ku_byUser_Identity_user().publicKeyWebClient.clear();
                }
            }
);
            $Ku.byCommon.Identity.session.removeEvent.add(new $Ku.byCommon.Event.sessionremoveEvent$Observer(new Object(), "$lambda") {
                public void invoke($Ku.by.Object.ServerSession f_session) {
                    if ($getThis$Ku_byUser_Identity_user().publicKeyWebClient.containsKey(f_session)) {
                        $getThis$Ku_byUser_Identity_user().publicKeyWebClient.remove(f_session);
                    }
                }
            }
);
        }
    }

    public java.lang.String getPublicKey() {
        if (java.util.Objects.equals(this.publicKey, null) || java.util.Objects.equals(this.publicKey, "")) {
            this.generateRsaKey();
        }
        return this.publicKey;
    }

    public java.lang.Boolean regPublicKey(java.lang.String f_publicKey) {
        $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
        if (!this.publicKeyWebClient.containsKey(tmpSession)) {
            this.publicKeyWebClient.add(tmpSession, f_publicKey);
        }
        else {
            this.publicKeyWebClient.assign(tmpSession, f_publicKey);
        }
        return true;
    }

    public java.lang.String rsaEncode(java.lang.String f_encede) {
        if (java.util.Objects.equals(f_encede, null) || java.util.Objects.equals(f_encede, "") || f_encede.length() > 245) {
            return f_encede;
        }
        {
            $Ku.by.Object.ServerSession tmpSession = $Ku.by.Object.ServerSession.getCurrentSession();
            if (this.publicKeyWebClient.containsKey(tmpSession)) {
                return byExternal.security.rsaEncrypt(f_encede, this.publicKeyWebClient.get(tmpSession));
            }
        }
        return f_encede;
    }

    public java.lang.String rsaDecode(java.lang.String f_decode) {
        if (java.util.Objects.equals(f_decode, null) || !java.util.Objects.equals(f_decode.length(), 344)) {
            return f_decode;
        }
        return byExternal.security.rsaDecrypt(f_decode, this.privateKey);
    }

    public java.lang.String md5Plus(java.lang.String f_sourcePwd) {
        java.lang.StringBuilder tmpSb = new java.lang.StringBuilder();
        for (java.lang.Integer i = 0; i < f_sourcePwd.length(); i++) {
            tmpSb.append(java.lang.Integer.toString($Ku.by.ToolClass.ToolFunction.castToInteger($Ku.by.ToolClass.StringUtil.charAt(f_sourcePwd, i)), 2));
            tmpSb.append($Ku.by.ToolClass.StringUtil.charAt(f_sourcePwd, f_sourcePwd.length() - i - 1));
            tmpSb.append(java.lang.Integer.toString($Ku.by.ToolClass.ToolFunction.castToInteger($Ku.by.ToolClass.StringUtil.charAt(f_sourcePwd, i)), 16));
        }
        return byExternal.security.md5(tmpSb.toString());
    }

    public java.lang.String verifyPwd(java.lang.String f_pwd) {
        if (!$Ku.by.ToolClass.StringUtil.isMatch(f_pwd, this.regPwd, $Ku.by.Enum.RegexMode.multiIgnoreCase)) {
            return $Ku.byUser.Object.ByUserStrings.Info_Password_Pattern_Invalid();
        }
        return null;
    }

    public java.lang.String verifyUserFormat(java.lang.String f_user) {
        if (f_user.length() < 2 || f_user.length() > 32) {
            return $Ku.byUser.Object.ByUserStrings.Info_UserName_Length_Invalid();
        }
        if (!$Ku.by.ToolClass.StringUtil.isMatch(f_user, this.regUserName, $Ku.by.Enum.RegexMode.multiIgnoreCase)) {
            return $Ku.byUser.Object.ByUserStrings.Info_UserName_Pattern_Invalid();
        }
        return null;
    }

    public java.lang.String verifyRegisterUser(java.lang.String f_user) {
        {
            f_user = this.rsaDecode(f_user);
        }
        java.lang.String tmpUserFormat = this.verifyUserFormat(f_user);
        if (!java.util.Objects.equals(tmpUserFormat, null)) {
            return tmpUserFormat;
        }
        {
            java.lang.Boolean tmpResultValue = this.userExists(f_user);
            return tmpResultValue ? $Ku.byUser.Object.ByUserStrings.Info_UserName_Already_Exist() : null;
        }
    }

    public java.lang.Boolean userExists(java.lang.String f_user) {
        {
            f_user = this.rsaDecode(f_user);
        }
        if (!java.util.Objects.equals(this.verifyUserFormat(f_user), null)) {
            return false;
        }
        {
            $Ku.by.ToolClass.SqlType tmpList = $Ku.byUser.SqlExpression.LocalSql._24(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_user});
            return tmpList.rows.count() > 0 ? true : false;
        }
    }

    public $Ku.byUser.Identity.user $getThis$Ku_byUser_Identity_user() {
        return this;
    }

    public void $setProps() {
    }

    public $Ku.by.ToolClass.Sql.SelectTable getSource() {
        return this.Source;
    }

    public void setSource($Ku.by.ToolClass.Sql.SelectTable value) {
        this.Source = value;
    }
}
