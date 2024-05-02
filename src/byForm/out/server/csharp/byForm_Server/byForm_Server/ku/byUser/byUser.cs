using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byUser
{
    public class byUser : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byUser()
        {
            this.Name = "byUser";

            var sheet_userUpload = new ku.byUser.DataSheet.biao_userUpload();

            this.DataSheetDic.Add("userUpload", sheet_userUpload);

            this.RelationDic.Add("userUpload", new List<SheetRelation>());

            this.RelationDic["userUpload"].Add(new SheetRelation("user.ID", "userUpload.userID"));

            var sheet_log = new ku.byUser.DataSheet.biao_log();

            this.DataSheetDic.Add("log", sheet_log);

            this.RelationDic.Add("log", new List<SheetRelation>());

            this.RelationDic["log"].Add(new SheetRelation("user.ID", "log.userID"));

            var sheet_user = new ku.byUser.DataSheet.biao_user();

            this.DataSheetDic.Add("user", sheet_user);

            var sheet_userICO = new ku.byUser.DataSheet.biao_userICO();

            this.DataSheetDic.Add("userICO", sheet_userICO);

            var sheet_anonymous = new ku.byUser.DataSheet.biao_anonymous();

            this.DataSheetDic.Add("anonymous", sheet_anonymous);

            this.RelationDic.Add("anonymous", new List<SheetRelation>());

            this.RelationDic["anonymous"].Add(new SheetRelation("user.ID", "anonymous.userID"));

            var sheet_userAdmin = new ku.byUser.DataSheet.biao_userAdmin();

            this.DataSheetDic.Add("userAdmin", sheet_userAdmin);

            byForm_Server.ku.byUser.Identity.userUpload NewInstanceuserUpload = new byForm_Server.ku.byUser.Identity.userUpload();
            this.NewIdentityDic.Add("New_userUpload", NewInstanceuserUpload);
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserUpload, "New_userUpload");
            byForm_Server.ku.byLog.Identity.log NewInstancelog = new byForm_Server.ku.byLog.Identity.log();
            this.NewIdentityDic.Add("New_log", NewInstancelog);
            this.NewIdentityDicKeyIsId.Add(NewInstancelog, "New_log");
            byForm_Server.ku.byUser.Identity.user NewInstanceuser = new byForm_Server.ku.byUser.Identity.user();
            this.NewIdentityDic.Add("New_user", NewInstanceuser);
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser, "New_user");
            byForm_Server.ku.byUser.Identity.userICO NewInstanceuserICO = new byForm_Server.ku.byUser.Identity.userICO();
            this.NewIdentityDic.Add("New_userICO", NewInstanceuserICO);
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserICO, "New_userICO");
            byForm_Server.ku.byUser.Identity.anonymous NewInstanceanonymous = new byForm_Server.ku.byUser.Identity.anonymous();
            this.NewIdentityDic.Add("New_anonymous", NewInstanceanonymous);
            this.NewIdentityDicKeyIsId.Add(NewInstanceanonymous, "New_anonymous");
            byForm_Server.ku.byUser.Identity.userAdmin NewInstanceuserAdmin = new byForm_Server.ku.byUser.Identity.userAdmin();
            this.NewIdentityDic.Add("New_userAdmin", NewInstanceuserAdmin);
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserAdmin, "New_userAdmin");
            NewInstanceuserUpload.ku = "byUser";
            NewInstanceuserUpload.to = sheet_userUpload;

            sheet_userUpload.Identity = NewInstanceuserUpload;
            this.DataSheetIdentityDic.Add(NewInstanceuserUpload, sheet_userUpload);
            NewInstanceuserUpload.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceuserUpload.iID.to = sheet_userUpload.Fields["iD"];
            sheet_userUpload.FieldDic["iD"].Identity = NewInstanceuserUpload.iID;
            sheet_userUpload.Fields["iD"].Identity = NewInstanceuserUpload.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserUpload.iID, "userUpload.iD");
            NewInstanceuserUpload.iFileName = new byForm_Server.ku.by.Identity.ID();
            NewInstanceuserUpload.iFileName.to = sheet_userUpload.Fields["fileName"];
            sheet_userUpload.FieldDic["fileName"].Identity = NewInstanceuserUpload.iFileName;
            sheet_userUpload.Fields["fileName"].Identity = NewInstanceuserUpload.iFileName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserUpload.iFileName, "userUpload.fileName");
            NewInstanceuserUpload.iUserID = new byForm_Server.ku.by.Identity.Reference();
            NewInstanceuserUpload.iUserID.to = sheet_userUpload.Fields["userID"];
            sheet_userUpload.FieldDic["userID"].Identity = NewInstanceuserUpload.iUserID;
            sheet_userUpload.Fields["userID"].Identity = NewInstanceuserUpload.iUserID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserUpload.iUserID, "userUpload.userID");
            NewInstanceuserUpload.iSummery = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserUpload.iSummery.to = sheet_userUpload.Fields["summery"];
            sheet_userUpload.FieldDic["summery"].Identity = NewInstanceuserUpload.iSummery;
            sheet_userUpload.Fields["summery"].Identity = NewInstanceuserUpload.iSummery;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserUpload.iSummery, "userUpload.summery");
            NewInstanceuserUpload.iDT = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserUpload.iDT.to = sheet_userUpload.Fields["dT"];
            sheet_userUpload.FieldDic["dT"].Identity = NewInstanceuserUpload.iDT;
            sheet_userUpload.Fields["dT"].Identity = NewInstanceuserUpload.iDT;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserUpload.iDT, "userUpload.dT");
            NewInstanceuserUpload.rUser = NewIdentityDic["New_user"] as byForm_Server.ku.byUser.Identity.user;
            NewInstanceuserUpload.iFileSize = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserUpload.iFileSize.to = sheet_userUpload.Fields["fileSize"];
            sheet_userUpload.FieldDic["fileSize"].Identity = NewInstanceuserUpload.iFileSize;
            sheet_userUpload.Fields["fileSize"].Identity = NewInstanceuserUpload.iFileSize;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserUpload.iFileSize, "userUpload.fileSize");
            NewInstancelog.ku = "byUser";
            NewInstancelog.to = sheet_log;

            sheet_log.Identity = NewInstancelog;
            this.DataSheetIdentityDic.Add(NewInstancelog, sheet_log);
            NewInstancelog.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstancelog.iID.to = sheet_log.Fields["iD"];
            sheet_log.FieldDic["iD"].Identity = NewInstancelog.iID;
            sheet_log.Fields["iD"].Identity = NewInstancelog.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstancelog.iID, "log.iD");
            NewInstancelog.iSceneType = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancelog.iSceneType.to = sheet_log.Fields["sceneType"];
            sheet_log.FieldDic["sceneType"].Identity = NewInstancelog.iSceneType;
            sheet_log.Fields["sceneType"].Identity = NewInstancelog.iSceneType;
            this.NewIdentityDicKeyIsId.Add(NewInstancelog.iSceneType, "log.sceneType");
            NewInstancelog.iUserID = new byForm_Server.ku.by.Identity.Reference();
            NewInstancelog.iUserID.to = sheet_log.Fields["userID"];
            sheet_log.FieldDic["userID"].Identity = NewInstancelog.iUserID;
            sheet_log.Fields["userID"].Identity = NewInstancelog.iUserID;
            this.NewIdentityDicKeyIsId.Add(NewInstancelog.iUserID, "log.userID");
            NewInstancelog.iUserName = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancelog.iUserName.to = sheet_log.Fields["userName"];
            sheet_log.FieldDic["userName"].Identity = NewInstancelog.iUserName;
            sheet_log.Fields["userName"].Identity = NewInstancelog.iUserName;
            this.NewIdentityDicKeyIsId.Add(NewInstancelog.iUserName, "log.userName");
            NewInstancelog.iState = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancelog.iState.to = sheet_log.Fields["state"];
            sheet_log.FieldDic["state"].Identity = NewInstancelog.iState;
            sheet_log.Fields["state"].Identity = NewInstancelog.iState;
            this.NewIdentityDicKeyIsId.Add(NewInstancelog.iState, "log.state");
            NewInstancelog.iIp = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancelog.iIp.to = sheet_log.Fields["ip"];
            sheet_log.FieldDic["ip"].Identity = NewInstancelog.iIp;
            sheet_log.Fields["ip"].Identity = NewInstancelog.iIp;
            this.NewIdentityDicKeyIsId.Add(NewInstancelog.iIp, "log.ip");
            NewInstancelog.iSummary = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancelog.iSummary.to = sheet_log.Fields["summary"];
            sheet_log.FieldDic["summary"].Identity = NewInstancelog.iSummary;
            sheet_log.Fields["summary"].Identity = NewInstancelog.iSummary;
            this.NewIdentityDicKeyIsId.Add(NewInstancelog.iSummary, "log.summary");
            NewInstancelog.iDt = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancelog.iDt.to = sheet_log.Fields["dt"];
            sheet_log.FieldDic["dt"].Identity = NewInstancelog.iDt;
            sheet_log.Fields["dt"].Identity = NewInstancelog.iDt;
            this.NewIdentityDicKeyIsId.Add(NewInstancelog.iDt, "log.dt");
            NewInstanceuser.ku = "byUser";
            NewInstanceuser.to = sheet_user;

            sheet_user.Identity = NewInstanceuser;
            this.DataSheetIdentityDic.Add(NewInstanceuser, sheet_user);
            NewInstanceuser.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceuser.iID.to = sheet_user.Fields["ID"];
            sheet_user.FieldDic["ID"].Identity = NewInstanceuser.iID;
            sheet_user.Fields["ID"].Identity = NewInstanceuser.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iID, "user.ID");
            NewInstanceuser.iFreeze = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iFreeze.to = sheet_user.Fields["freeze"];
            sheet_user.FieldDic["freeze"].Identity = NewInstanceuser.iFreeze;
            sheet_user.Fields["freeze"].Identity = NewInstanceuser.iFreeze;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iFreeze, "user.freeze");
            NewInstanceuser.iRank = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iRank.to = sheet_user.Fields["rank"];
            sheet_user.FieldDic["rank"].Identity = NewInstanceuser.iRank;
            sheet_user.Fields["rank"].Identity = NewInstanceuser.iRank;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iRank, "user.rank");
            NewInstanceuser.iName = new byForm_Server.ku.by.Identity.Name();
            NewInstanceuser.iName.to = sheet_user.Fields["name"];
            sheet_user.FieldDic["name"].Identity = NewInstanceuser.iName;
            sheet_user.Fields["name"].Identity = NewInstanceuser.iName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iName, "user.name");
            NewInstanceuser.iPassword = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iPassword.to = sheet_user.Fields["password"];
            sheet_user.FieldDic["password"].Identity = NewInstanceuser.iPassword;
            sheet_user.Fields["password"].Identity = NewInstanceuser.iPassword;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iPassword, "user.password");
            NewInstanceuser.iDisplayName = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iDisplayName.to = sheet_user.Fields["displayName"];
            sheet_user.FieldDic["displayName"].Identity = NewInstanceuser.iDisplayName;
            sheet_user.Fields["displayName"].Identity = NewInstanceuser.iDisplayName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iDisplayName, "user.displayName");
            NewInstanceuser.iMobile = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iMobile.to = sheet_user.Fields["mobile"];
            sheet_user.FieldDic["mobile"].Identity = NewInstanceuser.iMobile;
            sheet_user.Fields["mobile"].Identity = NewInstanceuser.iMobile;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iMobile, "user.mobile");
            NewInstanceuser.iMail = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iMail.to = sheet_user.Fields["mail"];
            sheet_user.FieldDic["mail"].Identity = NewInstanceuser.iMail;
            sheet_user.Fields["mail"].Identity = NewInstanceuser.iMail;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iMail, "user.mail");
            NewInstanceuser.iCerMode = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iCerMode.to = sheet_user.Fields["cerMode"];
            sheet_user.FieldDic["cerMode"].Identity = NewInstanceuser.iCerMode;
            sheet_user.Fields["cerMode"].Identity = NewInstanceuser.iCerMode;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iCerMode, "user.cerMode");
            NewInstanceuser.iCerName = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iCerName.to = sheet_user.Fields["cerName"];
            sheet_user.FieldDic["cerName"].Identity = NewInstanceuser.iCerName;
            sheet_user.Fields["cerName"].Identity = NewInstanceuser.iCerName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iCerName, "user.cerName");
            NewInstanceuser.iCerNO = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iCerNO.to = sheet_user.Fields["cerNO"];
            sheet_user.FieldDic["cerNO"].Identity = NewInstanceuser.iCerNO;
            sheet_user.Fields["cerNO"].Identity = NewInstanceuser.iCerNO;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iCerNO, "user.cerNO");
            NewInstanceuser.iMoney = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iMoney.to = sheet_user.Fields["money"];
            sheet_user.FieldDic["money"].Identity = NewInstanceuser.iMoney;
            sheet_user.Fields["money"].Identity = NewInstanceuser.iMoney;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iMoney, "user.money");
            NewInstanceuser.iRemark = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iRemark.to = sheet_user.Fields["Remark"];
            sheet_user.FieldDic["Remark"].Identity = NewInstanceuser.iRemark;
            sheet_user.Fields["Remark"].Identity = NewInstanceuser.iRemark;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iRemark, "user.Remark");
            NewInstanceuser.iRegDt = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuser.iRegDt.to = sheet_user.Fields["regDt"];
            sheet_user.FieldDic["regDt"].Identity = NewInstanceuser.iRegDt;
            sheet_user.Fields["regDt"].Identity = NewInstanceuser.iRegDt;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuser.iRegDt, "user.regDt");
            NewInstanceuser.rLog = NewIdentityDic["New_log"] as byForm_Server.ku.byLog.Identity.log;
            NewInstanceuser.rUserAdmin = NewIdentityDic["New_userAdmin"] as byForm_Server.ku.byUser.Identity.userAdmin;
            NewInstanceuser.rAnonymous = NewIdentityDic["New_anonymous"] as byForm_Server.ku.byUser.Identity.anonymous;
            NewInstanceuser.rUserICO = NewIdentityDic["New_userICO"] as byForm_Server.ku.byUser.Identity.userICO;
            NewInstanceuser.rUserUpload = NewIdentityDic["New_userUpload"] as byForm_Server.ku.byUser.Identity.userUpload;
            NewInstanceuserICO.ku = "byUser";
            NewInstanceuserICO.to = sheet_userICO;

            sheet_userICO.Identity = NewInstanceuserICO;
            this.DataSheetIdentityDic.Add(NewInstanceuserICO, sheet_userICO);
            NewInstanceuserICO.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceuserICO.iID.to = sheet_userICO.Fields["iD"];
            sheet_userICO.FieldDic["iD"].Identity = NewInstanceuserICO.iID;
            sheet_userICO.Fields["iD"].Identity = NewInstanceuserICO.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserICO.iID, "userICO.iD");
            NewInstanceuserICO.iIcoFile = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserICO.iIcoFile.to = sheet_userICO.Fields["icoFile"];
            sheet_userICO.FieldDic["icoFile"].Identity = NewInstanceuserICO.iIcoFile;
            sheet_userICO.Fields["icoFile"].Identity = NewInstanceuserICO.iIcoFile;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserICO.iIcoFile, "userICO.icoFile");
            NewInstanceuserICO.iUploadDt = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserICO.iUploadDt.to = sheet_userICO.Fields["uploadDt"];
            sheet_userICO.FieldDic["uploadDt"].Identity = NewInstanceuserICO.iUploadDt;
            sheet_userICO.Fields["uploadDt"].Identity = NewInstanceuserICO.iUploadDt;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserICO.iUploadDt, "userICO.uploadDt");
            NewInstanceuserICO.rUser = NewIdentityDic["New_user"] as byForm_Server.ku.byUser.Identity.user;
            NewInstanceuserICO.iExtendName = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserICO.iExtendName.to = sheet_userICO.Fields["extendName"];
            sheet_userICO.FieldDic["extendName"].Identity = NewInstanceuserICO.iExtendName;
            sheet_userICO.Fields["extendName"].Identity = NewInstanceuserICO.iExtendName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserICO.iExtendName, "userICO.extendName");
            NewInstanceuserICO.iFileName = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserICO.iFileName.to = sheet_userICO.Fields["fileName"];
            sheet_userICO.FieldDic["fileName"].Identity = NewInstanceuserICO.iFileName;
            sheet_userICO.Fields["fileName"].Identity = NewInstanceuserICO.iFileName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserICO.iFileName, "userICO.fileName");
            NewInstanceanonymous.ku = "byUser";
            NewInstanceanonymous.to = sheet_anonymous;

            sheet_anonymous.Identity = NewInstanceanonymous;
            this.DataSheetIdentityDic.Add(NewInstanceanonymous, sheet_anonymous);
            NewInstanceanonymous.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceanonymous.iID.to = sheet_anonymous.Fields["iD"];
            sheet_anonymous.FieldDic["iD"].Identity = NewInstanceanonymous.iID;
            sheet_anonymous.Fields["iD"].Identity = NewInstanceanonymous.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceanonymous.iID, "anonymous.iD");
            NewInstanceanonymous.iUserID = new byForm_Server.ku.by.Identity.Reference();
            NewInstanceanonymous.iUserID.to = sheet_anonymous.Fields["userID"];
            sheet_anonymous.FieldDic["userID"].Identity = NewInstanceanonymous.iUserID;
            sheet_anonymous.Fields["userID"].Identity = NewInstanceanonymous.iUserID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceanonymous.iUserID, "anonymous.userID");
            NewInstanceanonymous.iRegDt = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceanonymous.iRegDt.to = sheet_anonymous.Fields["regDt"];
            sheet_anonymous.FieldDic["regDt"].Identity = NewInstanceanonymous.iRegDt;
            sheet_anonymous.Fields["regDt"].Identity = NewInstanceanonymous.iRegDt;
            this.NewIdentityDicKeyIsId.Add(NewInstanceanonymous.iRegDt, "anonymous.regDt");
            NewInstanceanonymous.iIP = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceanonymous.iIP.to = sheet_anonymous.Fields["iP"];
            sheet_anonymous.FieldDic["iP"].Identity = NewInstanceanonymous.iIP;
            sheet_anonymous.Fields["iP"].Identity = NewInstanceanonymous.iIP;
            this.NewIdentityDicKeyIsId.Add(NewInstanceanonymous.iIP, "anonymous.iP");
            NewInstanceuserAdmin.ku = "byUser";
            NewInstanceuserAdmin.to = sheet_userAdmin;

            sheet_userAdmin.Identity = NewInstanceuserAdmin;
            this.DataSheetIdentityDic.Add(NewInstanceuserAdmin, sheet_userAdmin);
            NewInstanceuserAdmin.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceuserAdmin.iID.to = sheet_userAdmin.Fields["iD"];
            sheet_userAdmin.FieldDic["iD"].Identity = NewInstanceuserAdmin.iID;
            sheet_userAdmin.Fields["iD"].Identity = NewInstanceuserAdmin.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserAdmin.iID, "userAdmin.iD");
            NewInstanceuserAdmin.iUserMode = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserAdmin.iUserMode.to = sheet_userAdmin.Fields["userMode"];
            sheet_userAdmin.FieldDic["userMode"].Identity = NewInstanceuserAdmin.iUserMode;
            sheet_userAdmin.Fields["userMode"].Identity = NewInstanceuserAdmin.iUserMode;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserAdmin.iUserMode, "userAdmin.userMode");
            NewInstanceuserAdmin.iDt = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceuserAdmin.iDt.to = sheet_userAdmin.Fields["dt"];
            sheet_userAdmin.FieldDic["dt"].Identity = NewInstanceuserAdmin.iDt;
            sheet_userAdmin.Fields["dt"].Identity = NewInstanceuserAdmin.iDt;
            this.NewIdentityDicKeyIsId.Add(NewInstanceuserAdmin.iDt, "userAdmin.dt");
            NewInstanceuserAdmin.rUser = NewIdentityDic["New_user"] as byForm_Server.ku.byUser.Identity.user;
            this.sqlLocation = new SqlExpression.SqlLocation();
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
}
