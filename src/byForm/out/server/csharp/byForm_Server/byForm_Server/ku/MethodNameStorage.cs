using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku
{
    public static class MethodNameStorage
    {
        static MethodNameStorage()
        {
            SkillNames.Add("by.0", "by.identity.Reference.host");
            SkillNames.Add("by.1", "by.identity.Reference.isReference");
            SkillNames.Add("by.3", "by.identity.Table.isReference");
            SkillNames.Add("by.8", "by.identity.Sys.start");
            SkillNames.Add("by.9", "by.identity.IServerDoor.comeIn");
            SkillNames.Add("byFormNew.1", "byFormNew.identity.ServerStartup.main");
            SkillNames.Add("byWebCommon.0", "byWebCommon.identity.webCommon.getQueryArgDic");
            SkillNames.Add("byBase.1", "byBase.identity.catalog.getRow");
            SkillNames.Add("byBase.2", "byBase.identity.TableSafe.confirmUserIsLogin");
            SkillNames.Add("byBase.3", "byBase.identity.popupTable.popupLoad");
            SkillNames.Add("byBase.4", "byBase.identity.Tree.popupLoad");
            SkillNames.Add("byBase.16", "byBase.identity.Tree.confirmUserIsLogin");
            ActionIdentityNames.Add("byBase.0", "byBase.identity.Tree.remove");
            ActionIdentityNames.Add("byBase.1", "byBase.identity.Tree.modify");
            ActionIdentityNames.Add("byBase.2", "byBase.identity.Tree.add");
            SkillNames.Add("byBase.17", "byBase.identity.bridge.load");
            SkillNames.Add("byBase.18", "byBase.identity.bridge.addDeleteUpdate");
            ActionIdentityNames.Add("byBase.3", "byBase.identity.bridge.add");
            ActionIdentityNames.Add("byBase.4", "byBase.identity.bridge.change");
            ActionIdentityNames.Add("byBase.5", "byBase.identity.bridge.delete");
            SkillNames.Add("byBase.21", "byBase.identity.extend.load");
            SkillNames.Add("byBase.22", "byBase.identity.extend.addUpdateDelete");
            SkillNames.Add("byBase.23", "byBase.identity.detail.load");
            SkillNames.Add("byBase.24", "byBase.identity.dic.addModifDelete");
            SkillNames.Add("byBase.26", "byBase.identity.dic.load");
            SkillNames.Add("byUser.0", "byUser.identity.user.userLoginChild");
            SkillNames.Add("byUser.1", "byUser.identity.user.userLogin");
            SkillNames.Add("byUser.2", "byUser.identity.user.confirmUserIsLogin");
            SkillNames.Add("byUser.3", "byUser.identity.user.confirmUserIsLogin");
            SkillNames.Add("byUser.4", "byUser.identity.user.confirmUserIsLogin");
            SkillNames.Add("byUser.8", "byUser.identity.user.exit");
            SkillNames.Add("byUser.9", "byUser.identity.user.userReg");
            SkillNames.Add("byUser.10", "byUser.identity.user.userReg");
            SkillNames.Add("byUser.11", "byUser.identity.user.userPwdModif");
            SkillNames.Add("byUser.12", "byUser.identity.user.userPwdModif");
            SkillNames.Add("byUser.13", "byUser.identity.user.verifyMobileFormat");
            SkillNames.Add("byUser.14", "byUser.identity.user.verifyMobileExists");
            SkillNames.Add("byUser.15", "byUser.identity.user.verifyRegMail");
            SkillNames.Add("byUser.16", "byUser.identity.user.verifyMailFormat");
            SkillNames.Add("byUser.17", "byUser.identity.user.verifyMailExists");
            SkillNames.Add("byUser.18", "byUser.identity.user.verifySafetyCodeFormat");
            SkillNames.Add("byUser.19", "byUser.identity.user.verifySafetyCode");
            SkillNames.Add("byUser.20", "byUser.identity.user.verifyCookies");
            SkillNames.Add("byUser.21", "byUser.identity.user.generateSafetyCode");
            SkillNames.Add("byUser.22", "byUser.identity.user.postSafety");
            SkillNames.Add("byUser.23", "byUser.identity.user.postSafetyModbile");
            SkillNames.Add("byUser.24", "byUser.identity.user.postSafetyMail");
            SkillNames.Add("byUser.25", "byUser.identity.user.postSafetyReg");
            SkillNames.Add("byUser.26", "byUser.identity.user.postSafetyCodeToMobile");
            SkillNames.Add("byUser.27", "byUser.identity.user.postSafetyCodeToMail");
            SkillNames.Add("byUser.28", "byUser.identity.user.getAnonymousUser");
            SkillNames.Add("byUser.29", "byUser.identity.user.createAnonymousUser");
            SkillNames.Add("byUser.30", "byUser.identity.user.getSessionUserRow");
            SkillNames.Add("byUser.32", "byUser.identity.user.init");
            SkillNames.Add("byUser.33", "byUser.identity.user.generateRsaKey");
            SkillNames.Add("byUser.34", "byUser.identity.user.getPublicKey");
            SkillNames.Add("byUser.35", "byUser.identity.user.regPublicKey");
            SkillNames.Add("byUser.36", "byUser.identity.user.rsaEncode");
            SkillNames.Add("byUser.37", "byUser.identity.user.rsaDecode");
            SkillNames.Add("byUser.38", "byUser.identity.user.md5Plus");
            SkillNames.Add("byUser.39", "byUser.identity.user.verifyPwd");
            SkillNames.Add("byUser.40", "byUser.identity.user.verifyUserFormat");
            SkillNames.Add("byUser.41", "byUser.identity.user.verifyRegisterUser");
            SkillNames.Add("byUser.42", "byUser.identity.user.userExists");
            SkillNames.Add("byUser.44", "byUser.identity.userICO.getIcoUrlPath");
            SkillNames.Add("byUser.45", "byUser.identity.userICO.getIcoDiskPath");
            SkillNames.Add("byUser.46", "byUser.identity.userICO.getIcoDiskPath");
            SkillNames.Add("byUser.47", "byUser.identity.userICO.fileUpload");
            SkillNames.Add("byUser.48", "byUser.identity.userAdmin.getAdmin");
            SkillNames.Add("byUser.49", "byUser.identity.userAdmin.isAdmin");
            SkillNames.Add("byUser.50", "byUser.identity.userAdmin.getAdmin");
            SkillNames.Add("byUser.51", "byUser.identity.userAdmin.adminAddRemove");
            SkillNames.Add("byUser.52", "byUser.identity.userAdmin.getPopupUser");
            SkillNames.Add("byUser.53", "byUser.identity.userAdmin.isFirstRun");
            SkillNames.Add("byUser.54", "byUser.identity.userAdmin.initInsertAdmin");
            SkillNames.Add("byLog.0", "byLog.identity.log.getRow");
            SkillNames.Add("byLog.1", "byLog.identity.log.writeTable");
            SkillNames.Add("byLog.2", "byLog.identity.log.writeFile");
            SkillNames.Add("byLog.3", "byLog.identity.log.write");
            SkillNames.Add("byForm.10", "byForm.identity.formField.addUpdate");
            SkillNames.Add("byForm.12", "byForm.identity.formField.delByFormId");
            SkillNames.Add("byForm.13", "byForm.identity.formData.getformDataIdentity");
            SkillNames.Add("byForm.14", "byForm.identity.formData.getformDataIdentity");
            SkillNames.Add("byForm.15", "byForm.identity.form.load");
            SkillNames.Add("byForm.16", "byForm.identity.form.loadSingle");
            SkillNames.Add("byForm.17", "byForm.identity.form.loadVDataSingle");
            SkillNames.Add("byForm.18", "byForm.identity.form.update");
            SkillNames.Add("byForm.24", "byForm.identity.form.saveField");
            SkillNames.Add("byForm.25", "byForm.identity.form.delFieldByFormId");
            SkillNames.Add("byForm.33", "byForm.identity.fieldTemplate.getList");
            SkillNames.Add("byForm.34", "byForm.identity.fieldTemplate.getFieldTemplate");
            SkillNames.Add("byCommon.3", "byCommon.identity.session.remove");
            SkillNames.Add("byCommon.4", "byCommon.identity.session.clear");
            SkillNames.Add("byCommon.8", "byCommon.identity.relatedTable.cloneListRow");
            SkillNames.Add("byCommon.15", "byCommon.identity.relatedTable.isExists");
            SkillNames.Add("byCommon.16", "byCommon.identity.relatedTable.isExists");
            SkillNames.Add("byCommon.17", "byCommon.identity.relatedTable.isNotExists");
            SkillNames.Add("byCommon.19", "byCommon.identity.general.getGuidPrefix");
            SkillNames.Add("byCommon.20", "byCommon.identity.general.getGuid");
            SkillNames.Add("byCommon.21", "byCommon.identity.general.getPlusZero");
            SkillNames.Add("byCommon.22", "byCommon.identity.general.getNoRepeatName");
            SkillNames.Add("byCommon.23", "byCommon.identity.general.getServerDatetime");
            SkillNames.Add("byCommon.24", "byCommon.identity.general.joinString");
            SkillNames.Add("byCommon.25", "byCommon.identity.general.getIDGroup");
            SkillNames.Add("byCommon.26", "byCommon.identity.general.contains");
            SkillNames.Add("byCommon.27", "byCommon.identity.general.contains");
            SkillNames.Add("byCommon.28", "byCommon.identity.general.copyRow");
            SkillNames.Add("byCommon.35", "byCommon.identity.relatedField.getFieldValue");
            SkillNames.Add("byCommon.36", "byCommon.identity.relatedField.getFieldSummery");
            SourceMethodNames.Add("byFormNew.formField.order", "by.object.System.autoID");
            SourceMethodNames.Add("byFormNew.form.createDt", "by.object.DateTime.getNow");
            SourceMethodNames.Add("byFormNew.form.currentModifyDt", "by.object.DateTime.getNow");
            SourceMethodNames.Add("byFormNew.fieldTemplate.createDt", "by.object.DateTime.getNow");
            SqlNames.Add("byBase.0", "byBase.identity.popupTable.popupLoad"); 
            SqlNames.Add("byBase.1", "byBase.identity.Tree.popupLoad"); 
            SqlNames.Add("byBase.2", ""); 
            SqlNames.Add("byBase.3", ""); 
            SqlNames.Add("byBase.4", ""); 
            SqlNames.Add("byBase.5", ""); 
            SqlNames.Add("byBase.6", ""); 
            SqlNames.Add("byBase.7", ""); 
            SqlNames.Add("byBase.8", ""); 
            SqlNames.Add("byBase.9", ""); 
            SqlNames.Add("byBase.10", "byBase.identity.manage.manage.load"); 
            SqlNames.Add("byBase.11", "byBase.identity.manage.manage.load"); 
            SqlNames.Add("byBase.12", "byBase.identity.bridge.load"); 
            SqlNames.Add("byBase.13", "byBase.identity.bridge.load"); 
            SqlNames.Add("byBase.14", "byBase.identity.bridge.addDeleteUpdate"); 
            SqlNames.Add("byBase.15", "byBase.identity.bridge.addDeleteUpdate"); 
            SqlNames.Add("byBase.16", ""); 
            SqlNames.Add("byBase.17", ""); 
            SqlNames.Add("byBase.18", ""); 
            SqlNames.Add("byBase.19", ""); 
            SqlNames.Add("byBase.20", "byBase.identity.manage.manage.actionModifBegin"); 
            SqlNames.Add("byBase.21", "byBase.identity.manage.manage.actionModifBegin"); 
            SqlNames.Add("byBase.22", "byBase.identity.manage.manage.actionDelete"); 
            SqlNames.Add("byBase.23", "byBase.identity.extend.load"); 
            SqlNames.Add("byBase.24", "byBase.identity.extend.addUpdateDelete"); 
            SqlNames.Add("byBase.25", "byBase.identity.extend.addUpdateDelete"); 
            SqlNames.Add("byBase.26", "byBase.identity.extend.addUpdateDelete"); 
            SqlNames.Add("byBase.27", "byBase.identity.slave.slave.slave"); 
            SqlNames.Add("byBase.28", "byBase.identity.slave.slave.slave"); 
            SqlNames.Add("byBase.29", "byBase.identity.slave.slave.slave"); 
            SqlNames.Add("byBase.30", "byBase.identity.detail.load"); 
            SqlNames.Add("byBase.31", "byBase.identity.dic.addModifDelete"); 
            SqlNames.Add("byBase.32", "byBase.identity.dic.addModifDelete"); 
            SqlNames.Add("byBase.33", "byBase.identity.dic.addModifDelete"); 
            SqlNames.Add("byBase.34", "byBase.identity.dic.load"); 
            SqlNames.Add("byBase.35", "byBase.identity.dic.load"); 
            SqlNames.Add("byBase.36", "byBase.identity.dic.load"); 
            SqlNames.Add("byBase.37", "byBase.identity.dic.load"); 
            TranNames.Add("byBase.0", "");
            TranNames.Add("byBase.1", "");
            TranNames.Add("byBase.2", "");
            TranNames.Add("byBase.3", "byBase.identity.bridge.addDeleteUpdate");
            TranNames.Add("byBase.4", "");
            TranNames.Add("byBase.5", "");
            TranNames.Add("byBase.6", "byBase.identity.manage.manage.actionModifBegin");
            TranNames.Add("byBase.7", "byBase.identity.manage.manage.actionDelete");
            TranNames.Add("byBase.8", "byBase.identity.dic.addModifDelete");
            TranNames.Add("byBase.9", "byBase.identity.dic.addModifDelete");
            TranNames.Add("byBase.10", "byBase.identity.dic.addModifDelete");
            SqlNames.Add("byUser.0", "byUser.identity.user.userLogin"); 
            SqlNames.Add("byUser.1", "byUser.identity.user.userLogin"); 
            SqlNames.Add("byUser.2", "byUser.identity.user.userReg"); 
            SqlNames.Add("byUser.3", "byUser.identity.user.userPwdModif"); 
            SqlNames.Add("byUser.4", "byUser.identity.user.userPwdModif"); 
            SqlNames.Add("byUser.5", "byUser.identity.user.userPwdModif"); 
            SqlNames.Add("byUser.6", "byUser.identity.user.userPwdModif"); 
            SqlNames.Add("byUser.7", "byUser.identity.user.userPwdModif"); 
            SqlNames.Add("byUser.8", "byUser.identity.user.userPwdModif"); 
            SqlNames.Add("byUser.9", "byUser.identity.user.verifyMobileExists"); 
            SqlNames.Add("byUser.10", "byUser.identity.user.verifyMailExists"); 
            SqlNames.Add("byUser.11", "byUser.identity.user.postSafety"); 
            SqlNames.Add("byUser.12", "byUser.identity.user.postSafety"); 
            SqlNames.Add("byUser.13", "byUser.identity.user.postSafety"); 
            SqlNames.Add("byUser.14", "byUser.identity.user.postSafetyReg"); 
            SqlNames.Add("byUser.15", "byUser.identity.user.postSafetyReg"); 
            SqlNames.Add("byUser.16", "byUser.identity.user.getAnonymousUser"); 
            SqlNames.Add("byUser.17", "byUser.identity.user.getAnonymousUser"); 
            SqlNames.Add("byUser.18", "byUser.identity.user.getAnonymousUser"); 
            SqlNames.Add("byUser.19", "byUser.identity.user.getAnonymousUser"); 
            SqlNames.Add("byUser.20", "byUser.identity.user.createAnonymousUser"); 
            SqlNames.Add("byUser.21", "byUser.identity.user.createAnonymousUser"); 
            SqlNames.Add("byUser.22", "byUser.identity.user.createAnonymousUser"); 
            SqlNames.Add("byUser.23", "byUser.identity.user.createAnonymousUser"); 
            SqlNames.Add("byUser.24", "byUser.identity.user.userExists"); 
            SqlNames.Add("byUser.25", "byUser.identity.modifyInfo.modifyInfo.cSureButton_click"); 
            SqlNames.Add("byUser.26", "byUser.identity.userICO.fileUpload"); 
            SqlNames.Add("byUser.27", "byUser.identity.userICO.fileUpload"); 
            SqlNames.Add("byUser.28", "byUser.identity.userICO.fileUpload"); 
            SqlNames.Add("byUser.29", "byUser.identity.userICO.fileUpload"); 
            SqlNames.Add("byUser.30", "byUser.identity.userICO.fileUpload"); 
            SqlNames.Add("byUser.31", "byUser.identity.userICO.fileUpload"); 
            SqlNames.Add("byUser.32", "byUser.identity.userAdmin.getAdmin"); 
            SqlNames.Add("byUser.33", "byUser.identity.userAdmin.getAdmin"); 
            SqlNames.Add("byUser.34", "byUser.identity.userAdmin.adminAddRemove"); 
            SqlNames.Add("byUser.35", "byUser.identity.userAdmin.adminAddRemove"); 
            SqlNames.Add("byUser.36", "byUser.identity.userAdmin.getPopupUser"); 
            SqlNames.Add("byUser.37", "byUser.identity.userAdmin.getPopupUser"); 
            SqlNames.Add("byUser.38", "byUser.identity.userAdmin.initInsertAdmin"); 
            SqlNames.Add("byUser.39", "byUser.identity.userAdmin.initInsertAdmin"); 
            SqlNames.Add("byUser.40", "byUser.identity.userAdmin.initInsertAdmin"); 
            SqlNames.Add("byUser.41", "byUser.identity.userAdmin.initInsertAdmin"); 
            TranNames.Add("byUser.0", "byUser.identity.user.userPwdModif");
            TranNames.Add("byUser.1", "byUser.identity.user.createAnonymousUser");
            TranNames.Add("byUser.2", "byUser.identity.userICO.fileUpload");
            TranNames.Add("byUser.3", "byUser.identity.userICO.fileUpload");
            TranNames.Add("byUser.4", "byUser.identity.userAdmin.initInsertAdmin");
            SourceMethodNames.Add("byUser.userUpload.fileSize", "by.object.System.autoID");
            SourceMethodNames.Add("byUser.log.dt", "by.object.DateTime.getNow");
            SourceMethodNames.Add("byUser.anonymous.regDt", "by.object.DateTime.getNow");
            SqlNames.Add("byLog.0", "byLog.identity.log.writeTable"); 
            SqlNames.Add("byForm.0", "byForm.identity.formResult.main"); 
            SqlNames.Add("byForm.1", "byForm.identity.formResult.main"); 
            SqlNames.Add("byForm.2", "byForm.identity.formAnalyzer.main"); 
            SqlNames.Add("byForm.3", "byForm.identity.formAnalyzer.main"); 
            SqlNames.Add("byForm.4", "byForm.identity.formAnalyzer.analyze"); 
            SqlNames.Add("byForm.5", "byForm.identity.formAnalyzer.analyze"); 
            SqlNames.Add("byForm.6", "byForm.identity.formAnalyzer.analyze"); 
            SqlNames.Add("byForm.7", "byForm.identity.formAnalyzer.analyze"); 
            SqlNames.Add("byForm.8", "byForm.identity.formField.addUpdate"); 
            SqlNames.Add("byForm.9", "byForm.identity.formField.addUpdate"); 
            SqlNames.Add("byForm.10", "byForm.identity.formField.showAllFieldInfoAsTemplate"); 
            SqlNames.Add("byForm.11", "byForm.identity.formField.delByFormId"); 
            SqlNames.Add("byForm.12", "byForm.identity.form.load"); 
            SqlNames.Add("byForm.13", "byForm.identity.form.load"); 
            SqlNames.Add("byForm.14", "byForm.identity.form.loadSingle"); 
            SqlNames.Add("byForm.15", "byForm.identity.form.loadSingle"); 
            SqlNames.Add("byForm.16", "byForm.identity.form.loadVDataSingle"); 
            SqlNames.Add("byForm.17", "byForm.identity.form.loadVDataSingle"); 
            SqlNames.Add("byForm.18", "byForm.identity.form.loadVDataSingle"); 
            SqlNames.Add("byForm.19", "byForm.identity.form.loadVDataSingle"); 
            SqlNames.Add("byForm.20", "byForm.identity.form.update"); 
            SqlNames.Add("byForm.21", "byForm.identity.form.update"); 
            SqlNames.Add("byForm.22", "byForm.identity.form.update"); 
            SqlNames.Add("byForm.23", "byForm.identity.form.displayFormData"); 
            SqlNames.Add("byForm.24", "byForm.identity.manage.manage.requireLogin"); 
            SqlNames.Add("byForm.25", "byForm.identity.manage.manage.save"); 
            SqlNames.Add("byForm.26", "byForm.identity.manage.manage.manage"); 
            SqlNames.Add("byForm.27", "byForm.identity.formsManager.formsManager.showManageFromTemplate"); 
            SqlNames.Add("byForm.28", "byForm.identity.formsManager.formsManager.showManageFromTemplate"); 
            SqlNames.Add("byForm.29", "byForm.identity.formsManager.formsManager.RefreshFormListPanel"); 
            SqlNames.Add("byForm.30", "byForm.identity.formsManager.formsManager.onDeleteButtonClick"); 
            SqlNames.Add("byForm.31", "byForm.identity.formsManager.formsManager.onDeleteButtonClick"); 
            SqlNames.Add("byForm.32", "byForm.identity.formsManager.formsManager.onDeleteButtonClick"); 
            SqlNames.Add("byForm.33", "byForm.identity.formsManager.formsManager.createNewForm"); 
            SqlNames.Add("byForm.34", "byForm.identity.formFilling.main"); 
            SqlNames.Add("byForm.35", "byForm.identity.formFilling.main"); 
            SqlNames.Add("byForm.36", "byForm.identity.formFilling.main"); 
            SqlNames.Add("byForm.37", "byForm.identity.fieldTemplate.getList"); 
            TranNames.Add("byForm.0", "byForm.identity.form.update");
            TranNames.Add("byForm.1", "byForm.identity.formsManager.formsManager.onDeleteButtonClick");
            TranNames.Add("byForm.2", "byForm.identity.formFilling.main");
        }

        public static System.Collections.Generic.Dictionary<string, string> SkillNames = new System.Collections.Generic.Dictionary<string, string>();

        public static System.Collections.Generic.Dictionary<string, string> ActionIdentityNames = new System.Collections.Generic.Dictionary<string, string>();

        public static System.Collections.Generic.Dictionary<string, string> SourceMethodNames = new System.Collections.Generic.Dictionary<string, string>();

        public static System.Collections.Generic.Dictionary<string, string> SqlNames = new System.Collections.Generic.Dictionary<string, string>();

        public static System.Collections.Generic.Dictionary<string, string> TranNames = new System.Collections.Generic.Dictionary<string, string>();
    }
}
