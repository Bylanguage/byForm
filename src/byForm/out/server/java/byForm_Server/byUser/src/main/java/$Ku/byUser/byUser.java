package $Ku.byUser;

public class byUser extends $Ku.by.ToolClass.BaseKu {
    public byUser() {
        this.Name = "byUser";

        $Ku.byUser.DataSheet.biao$userUpload sheet$userUpload = new $Ku.byUser.DataSheet.biao$userUpload();

        this.DataSheetDic.put("userUpload", sheet$userUpload);

        this.RelationDic.put("userUpload", new java.util.ArrayList<>());

        this.RelationDic.get("userUpload").add(new $Ku.by.ToolClass.SheetRelation("user.ID", "userUpload.userID"));

        $Ku.byUser.DataSheet.biao$log sheet$log = new $Ku.byUser.DataSheet.biao$log();

        this.DataSheetDic.put("log", sheet$log);

        this.RelationDic.put("log", new java.util.ArrayList<>());

        this.RelationDic.get("log").add(new $Ku.by.ToolClass.SheetRelation("user.ID", "log.userID"));

        $Ku.byUser.DataSheet.biao$user sheet$user = new $Ku.byUser.DataSheet.biao$user();

        this.DataSheetDic.put("user", sheet$user);

        $Ku.byUser.DataSheet.biao$userICO sheet$userICO = new $Ku.byUser.DataSheet.biao$userICO();

        this.DataSheetDic.put("userICO", sheet$userICO);

        $Ku.byUser.DataSheet.biao$anonymous sheet$anonymous = new $Ku.byUser.DataSheet.biao$anonymous();

        this.DataSheetDic.put("anonymous", sheet$anonymous);

        this.RelationDic.put("anonymous", new java.util.ArrayList<>());

        this.RelationDic.get("anonymous").add(new $Ku.by.ToolClass.SheetRelation("user.ID", "anonymous.userID"));

        $Ku.byUser.DataSheet.biao$userAdmin sheet$userAdmin = new $Ku.byUser.DataSheet.biao$userAdmin();

        this.DataSheetDic.put("userAdmin", sheet$userAdmin);

        $Ku.byUser.Identity.userUpload NewInstanceuserUpload = new $Ku.byUser.Identity.userUpload();
        this.NewIdentityDic.put("New_userUpload", NewInstanceuserUpload);
        this.NewIdentityKeyIsId.put(NewInstanceuserUpload, "New_userUpload");
        $Ku.byLog.Identity.log NewInstancelog = new $Ku.byLog.Identity.log();
        this.NewIdentityDic.put("New_log", NewInstancelog);
        this.NewIdentityKeyIsId.put(NewInstancelog, "New_log");
        $Ku.byUser.Identity.user NewInstanceuser = new $Ku.byUser.Identity.user();
        this.NewIdentityDic.put("New_user", NewInstanceuser);
        this.NewIdentityKeyIsId.put(NewInstanceuser, "New_user");
        $Ku.byUser.Identity.userICO NewInstanceuserICO = new $Ku.byUser.Identity.userICO();
        this.NewIdentityDic.put("New_userICO", NewInstanceuserICO);
        this.NewIdentityKeyIsId.put(NewInstanceuserICO, "New_userICO");
        $Ku.byUser.Identity.anonymous NewInstanceanonymous = new $Ku.byUser.Identity.anonymous();
        this.NewIdentityDic.put("New_anonymous", NewInstanceanonymous);
        this.NewIdentityKeyIsId.put(NewInstanceanonymous, "New_anonymous");
        $Ku.byUser.Identity.userAdmin NewInstanceuserAdmin = new $Ku.byUser.Identity.userAdmin();
        this.NewIdentityDic.put("New_userAdmin", NewInstanceuserAdmin);
        this.NewIdentityKeyIsId.put(NewInstanceuserAdmin, "New_userAdmin");
        NewInstanceuserUpload.setKu("byUser");
        NewInstanceuserUpload.setTo(sheet$userUpload);

        sheet$userUpload.setIdentity(NewInstanceuserUpload);
        this.DataSheetIdentityDic.put(NewInstanceuserUpload, sheet$userUpload);
        NewInstanceuserUpload.iID = new $Ku.by.Identity.ID();
        NewInstanceuserUpload.iID.setTo(sheet$userUpload.getFieldDic().get("iD"));
        sheet$userUpload.getFieldDic().get("iD").setIdentity(NewInstanceuserUpload.iID);
        this.NewIdentityDic.put("userUpload.iD", NewInstanceuserUpload.iID);
        this.NewIdentityKeyIsId.put(NewInstanceuserUpload.iID, "userUpload.iD");
        NewInstanceuserUpload.iFileName = new $Ku.by.Identity.ID();
        NewInstanceuserUpload.iFileName.setTo(sheet$userUpload.getFieldDic().get("fileName"));
        sheet$userUpload.getFieldDic().get("fileName").setIdentity(NewInstanceuserUpload.iFileName);
        this.NewIdentityDic.put("userUpload.fileName", NewInstanceuserUpload.iFileName);
        this.NewIdentityKeyIsId.put(NewInstanceuserUpload.iFileName, "userUpload.fileName");
        NewInstanceuserUpload.iUserID = new $Ku.by.Identity.Reference();
        NewInstanceuserUpload.iUserID.setTo(sheet$userUpload.getFieldDic().get("userID"));
        sheet$userUpload.getFieldDic().get("userID").setIdentity(NewInstanceuserUpload.iUserID);
        this.NewIdentityDic.put("userUpload.userID", NewInstanceuserUpload.iUserID);
        this.NewIdentityKeyIsId.put(NewInstanceuserUpload.iUserID, "userUpload.userID");
        NewInstanceuserUpload.iSummery = new $Ku.by.Identity.Attribute();
        NewInstanceuserUpload.iSummery.setTo(sheet$userUpload.getFieldDic().get("summery"));
        sheet$userUpload.getFieldDic().get("summery").setIdentity(NewInstanceuserUpload.iSummery);
        this.NewIdentityDic.put("userUpload.summery", NewInstanceuserUpload.iSummery);
        this.NewIdentityKeyIsId.put(NewInstanceuserUpload.iSummery, "userUpload.summery");
        NewInstanceuserUpload.iDT = new $Ku.by.Identity.Attribute();
        NewInstanceuserUpload.iDT.setTo(sheet$userUpload.getFieldDic().get("dT"));
        sheet$userUpload.getFieldDic().get("dT").setIdentity(NewInstanceuserUpload.iDT);
        this.NewIdentityDic.put("userUpload.dT", NewInstanceuserUpload.iDT);
        this.NewIdentityKeyIsId.put(NewInstanceuserUpload.iDT, "userUpload.dT");
        NewInstanceuserUpload.rUser = ($Ku.byUser.Identity.user) NewIdentityDic.get("New_user");
        NewInstanceuserUpload.iFileSize = new $Ku.by.Identity.Attribute();
        NewInstanceuserUpload.iFileSize.setTo(sheet$userUpload.getFieldDic().get("fileSize"));
        sheet$userUpload.getFieldDic().get("fileSize").setIdentity(NewInstanceuserUpload.iFileSize);
        this.NewIdentityDic.put("userUpload.fileSize", NewInstanceuserUpload.iFileSize);
        this.NewIdentityKeyIsId.put(NewInstanceuserUpload.iFileSize, "userUpload.fileSize");
        NewInstancelog.setKu("byUser");
        NewInstancelog.setTo(sheet$log);

        sheet$log.setIdentity(NewInstancelog);
        this.DataSheetIdentityDic.put(NewInstancelog, sheet$log);
        NewInstancelog.iID = new $Ku.by.Identity.ID();
        NewInstancelog.iID.setTo(sheet$log.getFieldDic().get("iD"));
        sheet$log.getFieldDic().get("iD").setIdentity(NewInstancelog.iID);
        this.NewIdentityDic.put("log.iD", NewInstancelog.iID);
        this.NewIdentityKeyIsId.put(NewInstancelog.iID, "log.iD");
        NewInstancelog.iSceneType = new $Ku.by.Identity.Attribute();
        NewInstancelog.iSceneType.setTo(sheet$log.getFieldDic().get("sceneType"));
        sheet$log.getFieldDic().get("sceneType").setIdentity(NewInstancelog.iSceneType);
        this.NewIdentityDic.put("log.sceneType", NewInstancelog.iSceneType);
        this.NewIdentityKeyIsId.put(NewInstancelog.iSceneType, "log.sceneType");
        NewInstancelog.iUserID = new $Ku.by.Identity.Reference();
        NewInstancelog.iUserID.setTo(sheet$log.getFieldDic().get("userID"));
        sheet$log.getFieldDic().get("userID").setIdentity(NewInstancelog.iUserID);
        this.NewIdentityDic.put("log.userID", NewInstancelog.iUserID);
        this.NewIdentityKeyIsId.put(NewInstancelog.iUserID, "log.userID");
        NewInstancelog.iUserName = new $Ku.by.Identity.Attribute();
        NewInstancelog.iUserName.setTo(sheet$log.getFieldDic().get("userName"));
        sheet$log.getFieldDic().get("userName").setIdentity(NewInstancelog.iUserName);
        this.NewIdentityDic.put("log.userName", NewInstancelog.iUserName);
        this.NewIdentityKeyIsId.put(NewInstancelog.iUserName, "log.userName");
        NewInstancelog.iState = new $Ku.by.Identity.Attribute();
        NewInstancelog.iState.setTo(sheet$log.getFieldDic().get("state"));
        sheet$log.getFieldDic().get("state").setIdentity(NewInstancelog.iState);
        this.NewIdentityDic.put("log.state", NewInstancelog.iState);
        this.NewIdentityKeyIsId.put(NewInstancelog.iState, "log.state");
        NewInstancelog.iIp = new $Ku.by.Identity.Attribute();
        NewInstancelog.iIp.setTo(sheet$log.getFieldDic().get("ip"));
        sheet$log.getFieldDic().get("ip").setIdentity(NewInstancelog.iIp);
        this.NewIdentityDic.put("log.ip", NewInstancelog.iIp);
        this.NewIdentityKeyIsId.put(NewInstancelog.iIp, "log.ip");
        NewInstancelog.iSummary = new $Ku.by.Identity.Attribute();
        NewInstancelog.iSummary.setTo(sheet$log.getFieldDic().get("summary"));
        sheet$log.getFieldDic().get("summary").setIdentity(NewInstancelog.iSummary);
        this.NewIdentityDic.put("log.summary", NewInstancelog.iSummary);
        this.NewIdentityKeyIsId.put(NewInstancelog.iSummary, "log.summary");
        NewInstancelog.iDt = new $Ku.by.Identity.Attribute();
        NewInstancelog.iDt.setTo(sheet$log.getFieldDic().get("dt"));
        sheet$log.getFieldDic().get("dt").setIdentity(NewInstancelog.iDt);
        this.NewIdentityDic.put("log.dt", NewInstancelog.iDt);
        this.NewIdentityKeyIsId.put(NewInstancelog.iDt, "log.dt");
        NewInstanceuser.setKu("byUser");
        NewInstanceuser.setTo(sheet$user);

        sheet$user.setIdentity(NewInstanceuser);
        this.DataSheetIdentityDic.put(NewInstanceuser, sheet$user);
        NewInstanceuser.iID = new $Ku.by.Identity.ID();
        NewInstanceuser.iID.setTo(sheet$user.getFieldDic().get("ID"));
        sheet$user.getFieldDic().get("ID").setIdentity(NewInstanceuser.iID);
        this.NewIdentityDic.put("user.ID", NewInstanceuser.iID);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iID, "user.ID");
        NewInstanceuser.iFreeze = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iFreeze.setTo(sheet$user.getFieldDic().get("freeze"));
        sheet$user.getFieldDic().get("freeze").setIdentity(NewInstanceuser.iFreeze);
        this.NewIdentityDic.put("user.freeze", NewInstanceuser.iFreeze);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iFreeze, "user.freeze");
        NewInstanceuser.iRank = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iRank.setTo(sheet$user.getFieldDic().get("rank"));
        sheet$user.getFieldDic().get("rank").setIdentity(NewInstanceuser.iRank);
        this.NewIdentityDic.put("user.rank", NewInstanceuser.iRank);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iRank, "user.rank");
        NewInstanceuser.iName = new $Ku.by.Identity.Name();
        NewInstanceuser.iName.setTo(sheet$user.getFieldDic().get("name"));
        sheet$user.getFieldDic().get("name").setIdentity(NewInstanceuser.iName);
        this.NewIdentityDic.put("user.name", NewInstanceuser.iName);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iName, "user.name");
        NewInstanceuser.iPassword = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iPassword.setTo(sheet$user.getFieldDic().get("password"));
        sheet$user.getFieldDic().get("password").setIdentity(NewInstanceuser.iPassword);
        this.NewIdentityDic.put("user.password", NewInstanceuser.iPassword);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iPassword, "user.password");
        NewInstanceuser.iDisplayName = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iDisplayName.setTo(sheet$user.getFieldDic().get("displayName"));
        sheet$user.getFieldDic().get("displayName").setIdentity(NewInstanceuser.iDisplayName);
        this.NewIdentityDic.put("user.displayName", NewInstanceuser.iDisplayName);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iDisplayName, "user.displayName");
        NewInstanceuser.iMobile = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iMobile.setTo(sheet$user.getFieldDic().get("mobile"));
        sheet$user.getFieldDic().get("mobile").setIdentity(NewInstanceuser.iMobile);
        this.NewIdentityDic.put("user.mobile", NewInstanceuser.iMobile);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iMobile, "user.mobile");
        NewInstanceuser.iMail = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iMail.setTo(sheet$user.getFieldDic().get("mail"));
        sheet$user.getFieldDic().get("mail").setIdentity(NewInstanceuser.iMail);
        this.NewIdentityDic.put("user.mail", NewInstanceuser.iMail);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iMail, "user.mail");
        NewInstanceuser.iCerMode = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iCerMode.setTo(sheet$user.getFieldDic().get("cerMode"));
        sheet$user.getFieldDic().get("cerMode").setIdentity(NewInstanceuser.iCerMode);
        this.NewIdentityDic.put("user.cerMode", NewInstanceuser.iCerMode);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iCerMode, "user.cerMode");
        NewInstanceuser.iCerName = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iCerName.setTo(sheet$user.getFieldDic().get("cerName"));
        sheet$user.getFieldDic().get("cerName").setIdentity(NewInstanceuser.iCerName);
        this.NewIdentityDic.put("user.cerName", NewInstanceuser.iCerName);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iCerName, "user.cerName");
        NewInstanceuser.iCerNO = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iCerNO.setTo(sheet$user.getFieldDic().get("cerNO"));
        sheet$user.getFieldDic().get("cerNO").setIdentity(NewInstanceuser.iCerNO);
        this.NewIdentityDic.put("user.cerNO", NewInstanceuser.iCerNO);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iCerNO, "user.cerNO");
        NewInstanceuser.iMoney = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iMoney.setTo(sheet$user.getFieldDic().get("money"));
        sheet$user.getFieldDic().get("money").setIdentity(NewInstanceuser.iMoney);
        this.NewIdentityDic.put("user.money", NewInstanceuser.iMoney);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iMoney, "user.money");
        NewInstanceuser.iRemark = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iRemark.setTo(sheet$user.getFieldDic().get("Remark"));
        sheet$user.getFieldDic().get("Remark").setIdentity(NewInstanceuser.iRemark);
        this.NewIdentityDic.put("user.Remark", NewInstanceuser.iRemark);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iRemark, "user.Remark");
        NewInstanceuser.iRegDt = new $Ku.by.Identity.Attribute();
        NewInstanceuser.iRegDt.setTo(sheet$user.getFieldDic().get("regDt"));
        sheet$user.getFieldDic().get("regDt").setIdentity(NewInstanceuser.iRegDt);
        this.NewIdentityDic.put("user.regDt", NewInstanceuser.iRegDt);
        this.NewIdentityKeyIsId.put(NewInstanceuser.iRegDt, "user.regDt");
        NewInstanceuser.rLog = ($Ku.byLog.Identity.log) NewIdentityDic.get("New_log");
        NewInstanceuser.rUserAdmin = ($Ku.byUser.Identity.userAdmin) NewIdentityDic.get("New_userAdmin");
        NewInstanceuser.rAnonymous = ($Ku.byUser.Identity.anonymous) NewIdentityDic.get("New_anonymous");
        NewInstanceuser.rUserICO = ($Ku.byUser.Identity.userICO) NewIdentityDic.get("New_userICO");
        NewInstanceuser.rUserUpload = ($Ku.byUser.Identity.userUpload) NewIdentityDic.get("New_userUpload");
        NewInstanceuserICO.setKu("byUser");
        NewInstanceuserICO.setTo(sheet$userICO);

        sheet$userICO.setIdentity(NewInstanceuserICO);
        this.DataSheetIdentityDic.put(NewInstanceuserICO, sheet$userICO);
        NewInstanceuserICO.iID = new $Ku.by.Identity.ID();
        NewInstanceuserICO.iID.setTo(sheet$userICO.getFieldDic().get("iD"));
        sheet$userICO.getFieldDic().get("iD").setIdentity(NewInstanceuserICO.iID);
        this.NewIdentityDic.put("userICO.iD", NewInstanceuserICO.iID);
        this.NewIdentityKeyIsId.put(NewInstanceuserICO.iID, "userICO.iD");
        NewInstanceuserICO.iIcoFile = new $Ku.by.Identity.Attribute();
        NewInstanceuserICO.iIcoFile.setTo(sheet$userICO.getFieldDic().get("icoFile"));
        sheet$userICO.getFieldDic().get("icoFile").setIdentity(NewInstanceuserICO.iIcoFile);
        this.NewIdentityDic.put("userICO.icoFile", NewInstanceuserICO.iIcoFile);
        this.NewIdentityKeyIsId.put(NewInstanceuserICO.iIcoFile, "userICO.icoFile");
        NewInstanceuserICO.iUploadDt = new $Ku.by.Identity.Attribute();
        NewInstanceuserICO.iUploadDt.setTo(sheet$userICO.getFieldDic().get("uploadDt"));
        sheet$userICO.getFieldDic().get("uploadDt").setIdentity(NewInstanceuserICO.iUploadDt);
        this.NewIdentityDic.put("userICO.uploadDt", NewInstanceuserICO.iUploadDt);
        this.NewIdentityKeyIsId.put(NewInstanceuserICO.iUploadDt, "userICO.uploadDt");
        NewInstanceuserICO.rUser = ($Ku.byUser.Identity.user) NewIdentityDic.get("New_user");
        NewInstanceuserICO.iExtendName = new $Ku.by.Identity.Attribute();
        NewInstanceuserICO.iExtendName.setTo(sheet$userICO.getFieldDic().get("extendName"));
        sheet$userICO.getFieldDic().get("extendName").setIdentity(NewInstanceuserICO.iExtendName);
        this.NewIdentityDic.put("userICO.extendName", NewInstanceuserICO.iExtendName);
        this.NewIdentityKeyIsId.put(NewInstanceuserICO.iExtendName, "userICO.extendName");
        NewInstanceuserICO.iFileName = new $Ku.by.Identity.Attribute();
        NewInstanceuserICO.iFileName.setTo(sheet$userICO.getFieldDic().get("fileName"));
        sheet$userICO.getFieldDic().get("fileName").setIdentity(NewInstanceuserICO.iFileName);
        this.NewIdentityDic.put("userICO.fileName", NewInstanceuserICO.iFileName);
        this.NewIdentityKeyIsId.put(NewInstanceuserICO.iFileName, "userICO.fileName");
        NewInstanceanonymous.setKu("byUser");
        NewInstanceanonymous.setTo(sheet$anonymous);

        sheet$anonymous.setIdentity(NewInstanceanonymous);
        this.DataSheetIdentityDic.put(NewInstanceanonymous, sheet$anonymous);
        NewInstanceanonymous.iID = new $Ku.by.Identity.ID();
        NewInstanceanonymous.iID.setTo(sheet$anonymous.getFieldDic().get("iD"));
        sheet$anonymous.getFieldDic().get("iD").setIdentity(NewInstanceanonymous.iID);
        this.NewIdentityDic.put("anonymous.iD", NewInstanceanonymous.iID);
        this.NewIdentityKeyIsId.put(NewInstanceanonymous.iID, "anonymous.iD");
        NewInstanceanonymous.iUserID = new $Ku.by.Identity.Reference();
        NewInstanceanonymous.iUserID.setTo(sheet$anonymous.getFieldDic().get("userID"));
        sheet$anonymous.getFieldDic().get("userID").setIdentity(NewInstanceanonymous.iUserID);
        this.NewIdentityDic.put("anonymous.userID", NewInstanceanonymous.iUserID);
        this.NewIdentityKeyIsId.put(NewInstanceanonymous.iUserID, "anonymous.userID");
        NewInstanceanonymous.iRegDt = new $Ku.by.Identity.Attribute();
        NewInstanceanonymous.iRegDt.setTo(sheet$anonymous.getFieldDic().get("regDt"));
        sheet$anonymous.getFieldDic().get("regDt").setIdentity(NewInstanceanonymous.iRegDt);
        this.NewIdentityDic.put("anonymous.regDt", NewInstanceanonymous.iRegDt);
        this.NewIdentityKeyIsId.put(NewInstanceanonymous.iRegDt, "anonymous.regDt");
        NewInstanceanonymous.iIP = new $Ku.by.Identity.Attribute();
        NewInstanceanonymous.iIP.setTo(sheet$anonymous.getFieldDic().get("iP"));
        sheet$anonymous.getFieldDic().get("iP").setIdentity(NewInstanceanonymous.iIP);
        this.NewIdentityDic.put("anonymous.iP", NewInstanceanonymous.iIP);
        this.NewIdentityKeyIsId.put(NewInstanceanonymous.iIP, "anonymous.iP");
        NewInstanceuserAdmin.setKu("byUser");
        NewInstanceuserAdmin.setTo(sheet$userAdmin);

        sheet$userAdmin.setIdentity(NewInstanceuserAdmin);
        this.DataSheetIdentityDic.put(NewInstanceuserAdmin, sheet$userAdmin);
        NewInstanceuserAdmin.iID = new $Ku.by.Identity.ID();
        NewInstanceuserAdmin.iID.setTo(sheet$userAdmin.getFieldDic().get("iD"));
        sheet$userAdmin.getFieldDic().get("iD").setIdentity(NewInstanceuserAdmin.iID);
        this.NewIdentityDic.put("userAdmin.iD", NewInstanceuserAdmin.iID);
        this.NewIdentityKeyIsId.put(NewInstanceuserAdmin.iID, "userAdmin.iD");
        NewInstanceuserAdmin.iUserMode = new $Ku.by.Identity.Attribute();
        NewInstanceuserAdmin.iUserMode.setTo(sheet$userAdmin.getFieldDic().get("userMode"));
        sheet$userAdmin.getFieldDic().get("userMode").setIdentity(NewInstanceuserAdmin.iUserMode);
        this.NewIdentityDic.put("userAdmin.userMode", NewInstanceuserAdmin.iUserMode);
        this.NewIdentityKeyIsId.put(NewInstanceuserAdmin.iUserMode, "userAdmin.userMode");
        NewInstanceuserAdmin.iDt = new $Ku.by.Identity.Attribute();
        NewInstanceuserAdmin.iDt.setTo(sheet$userAdmin.getFieldDic().get("dt"));
        sheet$userAdmin.getFieldDic().get("dt").setIdentity(NewInstanceuserAdmin.iDt);
        this.NewIdentityDic.put("userAdmin.dt", NewInstanceuserAdmin.iDt);
        this.NewIdentityKeyIsId.put(NewInstanceuserAdmin.iDt, "userAdmin.dt");
        NewInstanceuserAdmin.rUser = ($Ku.byUser.Identity.user) NewIdentityDic.get("New_user");
        this.sqlLocation = new $Ku.byUser.SqlExpression.SqlLocation();
        NewInstanceuserUpload.rUser = NewInstanceuser;
        NewInstanceuser.rLog = NewInstancelog;
        NewInstanceuser.rUserAdmin = NewInstanceuserAdmin;
        NewInstanceuser.rAnonymous = NewInstanceanonymous;
        NewInstanceuser.rUserICO = NewInstanceuserICO;
        NewInstanceuser.rUserUpload = NewInstanceuserUpload;
        NewInstanceuserICO.rUser = NewInstanceuser;
        NewInstanceuserAdmin.rUser = NewInstanceuser;
    }
}
