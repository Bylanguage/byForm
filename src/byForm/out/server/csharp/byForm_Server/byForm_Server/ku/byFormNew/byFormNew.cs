using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byFormNew
{
    public class byFormNew : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byFormNew()
        {
            this.Name = "byFormNew";

            var sheet_formField = new ku.byFormNew.DataSheet.biao_formField();

            this.DataSheetDic.Add("formField", sheet_formField);

            this.RelationDic.Add("formField", new List<SheetRelation>());

            this.RelationDic["formField"].Add(new SheetRelation("form.iD", "formField.form"));

            var sheet_formTemplate = new ku.byFormNew.DataSheet.biao_formTemplate();

            this.DataSheetDic.Add("formTemplate", sheet_formTemplate);

            this.RelationDic.Add("formTemplate", new List<SheetRelation>());

            this.RelationDic["formTemplate"].Add(new SheetRelation("user.ID", "formTemplate.userID"));

            var sheet_formData = new ku.byFormNew.DataSheet.biao_formData();

            this.DataSheetDic.Add("formData", sheet_formData);

            this.RelationDic.Add("formData", new List<SheetRelation>());

            this.RelationDic["formData"].Add(new SheetRelation("form.iD", "formData.formID"));

            this.RelationDic["formData"].Add(new SheetRelation("formField.iD", "formData.fieldID"));

            this.RelationDic["formData"].Add(new SheetRelation("user.ID", "formData.userID"));

            var sheet_form = new ku.byFormNew.DataSheet.biao_form();

            this.DataSheetDic.Add("form", sheet_form);

            this.RelationDic.Add("form", new List<SheetRelation>());

            this.RelationDic["form"].Add(new SheetRelation("user.ID", "form.userID"));

            var sheet_fieldTemplate = new ku.byFormNew.DataSheet.biao_fieldTemplate();

            this.DataSheetDic.Add("fieldTemplate", sheet_fieldTemplate);

            byForm_Server.ku.byForm.Identity.formField NewInstanceformField = new byForm_Server.ku.byForm.Identity.formField();
            this.NewIdentityDic.Add("New_formField", NewInstanceformField);
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField, "New_formField");
            byForm_Server.ku.byForm.Identity.formSys NewInstanceformSys = new byForm_Server.ku.byForm.Identity.formSys();
            this.NewIdentityDic.Add("New_formSys", NewInstanceformSys);
            this.NewIdentityDicKeyIsId.Add(NewInstanceformSys, "New_formSys");
            byForm_Server.ku.byForm.Identity.formTemplate NewInstanceformTemplate = new byForm_Server.ku.byForm.Identity.formTemplate();
            this.NewIdentityDic.Add("New_formTemplate", NewInstanceformTemplate);
            this.NewIdentityDicKeyIsId.Add(NewInstanceformTemplate, "New_formTemplate");
            byForm_Server.ku.byForm.Identity.formData NewInstanceformData = new byForm_Server.ku.byForm.Identity.formData();
            this.NewIdentityDic.Add("New_formData", NewInstanceformData);
            this.NewIdentityDicKeyIsId.Add(NewInstanceformData, "New_formData");
            byForm_Server.ku.byForm.Identity.form NewInstanceform = new byForm_Server.ku.byForm.Identity.form();
            this.NewIdentityDic.Add("New_form", NewInstanceform);
            this.NewIdentityDicKeyIsId.Add(NewInstanceform, "New_form");
            byForm_Server.ku.byForm.Identity.fieldTemplate NewInstancefieldTemplate = new byForm_Server.ku.byForm.Identity.fieldTemplate();
            this.NewIdentityDic.Add("New_fieldTemplate", NewInstancefieldTemplate);
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate, "New_fieldTemplate");
            NewInstanceformField.ku = "byFormNew";
            NewInstanceformField.to = sheet_formField;

            sheet_formField.Identity = NewInstanceformField;
            this.DataSheetIdentityDic.Add(NewInstanceformField, sheet_formField);
            NewInstanceformField.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceformField.iID.to = sheet_formField.Fields["iD"];
            sheet_formField.FieldDic["iD"].Identity = NewInstanceformField.iID;
            sheet_formField.Fields["iD"].Identity = NewInstanceformField.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iID, "formField.iD");
            NewInstanceformField.iFormID = new byForm_Server.ku.by.Identity.Reference();
            NewInstanceformField.iFormID.to = sheet_formField.Fields["form"];
            sheet_formField.FieldDic["form"].Identity = NewInstanceformField.iFormID;
            sheet_formField.Fields["form"].Identity = NewInstanceformField.iFormID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFormID, "formField.form");
            NewInstanceformField.iFieldNO = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldNO.to = sheet_formField.Fields["fieldNO"];
            sheet_formField.FieldDic["fieldNO"].Identity = NewInstanceformField.iFieldNO;
            sheet_formField.Fields["fieldNO"].Identity = NewInstanceformField.iFieldNO;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldNO, "formField.fieldNO");
            NewInstanceformField.iFieldName = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldName.to = sheet_formField.Fields["fieldName"];
            sheet_formField.FieldDic["fieldName"].Identity = NewInstanceformField.iFieldName;
            sheet_formField.Fields["fieldName"].Identity = NewInstanceformField.iFieldName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldName, "formField.fieldName");
            NewInstanceformField.iSummary = new byForm_Server.ku.by.Identity.ID();
            NewInstanceformField.iSummary.to = sheet_formField.Fields["summary"];
            sheet_formField.FieldDic["summary"].Identity = NewInstanceformField.iSummary;
            sheet_formField.Fields["summary"].Identity = NewInstanceformField.iSummary;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iSummary, "formField.summary");
            NewInstanceformField.iFieldType = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldType.to = sheet_formField.Fields["fieldType"];
            sheet_formField.FieldDic["fieldType"].Identity = NewInstanceformField.iFieldType;
            sheet_formField.Fields["fieldType"].Identity = NewInstanceformField.iFieldType;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldType, "formField.fieldType");
            NewInstanceformField.iFieldCtrl = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldCtrl.to = sheet_formField.Fields["fieldCtrl"];
            sheet_formField.FieldDic["fieldCtrl"].Identity = NewInstanceformField.iFieldCtrl;
            sheet_formField.Fields["fieldCtrl"].Identity = NewInstanceformField.iFieldCtrl;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldCtrl, "formField.fieldCtrl");
            NewInstanceformField.iSelectValue = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iSelectValue.to = sheet_formField.Fields["selectValue"];
            sheet_formField.FieldDic["selectValue"].Identity = NewInstanceformField.iSelectValue;
            sheet_formField.Fields["selectValue"].Identity = NewInstanceformField.iSelectValue;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iSelectValue, "formField.selectValue");
            NewInstanceformField.iFieldMin = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldMin.to = sheet_formField.Fields["fieldMin"];
            sheet_formField.FieldDic["fieldMin"].Identity = NewInstanceformField.iFieldMin;
            sheet_formField.Fields["fieldMin"].Identity = NewInstanceformField.iFieldMin;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldMin, "formField.fieldMin");
            NewInstanceformField.iFieldMax = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldMax.to = sheet_formField.Fields["fieldMax"];
            sheet_formField.FieldDic["fieldMax"].Identity = NewInstanceformField.iFieldMax;
            sheet_formField.Fields["fieldMax"].Identity = NewInstanceformField.iFieldMax;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldMax, "formField.fieldMax");
            NewInstanceformField.iFieldReg = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldReg.to = sheet_formField.Fields["fieldReg"];
            sheet_formField.FieldDic["fieldReg"].Identity = NewInstanceformField.iFieldReg;
            sheet_formField.Fields["fieldReg"].Identity = NewInstanceformField.iFieldReg;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldReg, "formField.fieldReg");
            NewInstanceformField.iFieldRegMsg = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldRegMsg.to = sheet_formField.Fields["fieldRegMsg"];
            sheet_formField.FieldDic["fieldRegMsg"].Identity = NewInstanceformField.iFieldRegMsg;
            sheet_formField.Fields["fieldRegMsg"].Identity = NewInstanceformField.iFieldRegMsg;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldRegMsg, "formField.fieldRegMsg");
            NewInstanceformField.iFieldDefault = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iFieldDefault.to = sheet_formField.Fields["fieldDefault"];
            sheet_formField.FieldDic["fieldDefault"].Identity = NewInstanceformField.iFieldDefault;
            sheet_formField.Fields["fieldDefault"].Identity = NewInstanceformField.iFieldDefault;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iFieldDefault, "formField.fieldDefault");
            NewInstanceformField.iOrder = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iOrder.to = sheet_formField.Fields["order"];
            sheet_formField.FieldDic["order"].Identity = NewInstanceformField.iOrder;
            sheet_formField.Fields["order"].Identity = NewInstanceformField.iOrder;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iOrder, "formField.order");
            NewInstanceformField.iVDataValue = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iVDataValue.to = sheet_formField.Fields["vDataValue"];
            sheet_formField.FieldDic["vDataValue"].Identity = NewInstanceformField.iVDataValue;
            sheet_formField.Fields["vDataValue"].Identity = NewInstanceformField.iVDataValue;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iVDataValue, "formField.vDataValue");
            NewInstanceformField.rFormSys = NewIdentityDic["New_formSys"] as byForm_Server.ku.byForm.Identity.formSys;
            NewInstanceformField.iUserID = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iUserID.to = sheet_formField.Fields["userID"];
            sheet_formField.FieldDic["userID"].Identity = NewInstanceformField.iUserID;
            sheet_formField.Fields["userID"].Identity = NewInstanceformField.iUserID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iUserID, "formField.userID");
            NewInstanceformField.iNotNull = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformField.iNotNull.to = sheet_formField.Fields["notNull"];
            sheet_formField.FieldDic["notNull"].Identity = NewInstanceformField.iNotNull;
            sheet_formField.Fields["notNull"].Identity = NewInstanceformField.iNotNull;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformField.iNotNull, "formField.notNull");
            NewInstanceformSys.ku = "byFormNew";
            NewInstanceformTemplate.ku = "byFormNew";
            NewInstanceformTemplate.to = sheet_formTemplate;

            sheet_formTemplate.Identity = NewInstanceformTemplate;
            this.DataSheetIdentityDic.Add(NewInstanceformTemplate, sheet_formTemplate);
            NewInstanceformTemplate.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceformTemplate.iID.to = sheet_formTemplate.Fields["ID"];
            sheet_formTemplate.FieldDic["ID"].Identity = NewInstanceformTemplate.iID;
            sheet_formTemplate.Fields["ID"].Identity = NewInstanceformTemplate.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformTemplate.iID, "formTemplate.ID");
            NewInstanceformTemplate.iFormID = new byForm_Server.ku.by.Identity.Reference();
            NewInstanceformTemplate.iFormID.to = sheet_formTemplate.Fields["formID"];
            sheet_formTemplate.FieldDic["formID"].Identity = NewInstanceformTemplate.iFormID;
            sheet_formTemplate.Fields["formID"].Identity = NewInstanceformTemplate.iFormID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformTemplate.iFormID, "formTemplate.formID");
            NewInstanceformTemplate.iUserID = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformTemplate.iUserID.to = sheet_formTemplate.Fields["userID"];
            sheet_formTemplate.FieldDic["userID"].Identity = NewInstanceformTemplate.iUserID;
            sheet_formTemplate.Fields["userID"].Identity = NewInstanceformTemplate.iUserID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformTemplate.iUserID, "formTemplate.userID");
            NewInstanceformTemplate.iName = new byForm_Server.ku.by.Identity.Name();
            NewInstanceformTemplate.iName.to = sheet_formTemplate.Fields["name"];
            sheet_formTemplate.FieldDic["name"].Identity = NewInstanceformTemplate.iName;
            sheet_formTemplate.Fields["name"].Identity = NewInstanceformTemplate.iName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformTemplate.iName, "formTemplate.name");
            NewInstanceformTemplate.rFormSys = NewIdentityDic["New_formSys"] as byForm_Server.ku.byForm.Identity.formSys;
            NewInstanceformData.ku = "byFormNew";
            NewInstanceformData.to = sheet_formData;

            sheet_formData.Identity = NewInstanceformData;
            this.DataSheetIdentityDic.Add(NewInstanceformData, sheet_formData);
            NewInstanceformData.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceformData.iID.to = sheet_formData.Fields["iD"];
            sheet_formData.FieldDic["iD"].Identity = NewInstanceformData.iID;
            sheet_formData.Fields["iD"].Identity = NewInstanceformData.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformData.iID, "formData.iD");
            NewInstanceformData.iFormID = new byForm_Server.ku.by.Identity.Reference();
            NewInstanceformData.iFormID.to = sheet_formData.Fields["formID"];
            sheet_formData.FieldDic["formID"].Identity = NewInstanceformData.iFormID;
            sheet_formData.Fields["formID"].Identity = NewInstanceformData.iFormID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformData.iFormID, "formData.formID");
            NewInstanceformData.iRowPK = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformData.iRowPK.to = sheet_formData.Fields["rowPK"];
            sheet_formData.FieldDic["rowPK"].Identity = NewInstanceformData.iRowPK;
            sheet_formData.Fields["rowPK"].Identity = NewInstanceformData.iRowPK;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformData.iRowPK, "formData.rowPK");
            NewInstanceformData.iFieldID = new byForm_Server.ku.by.Identity.Reference();
            NewInstanceformData.iFieldID.to = sheet_formData.Fields["fieldID"];
            sheet_formData.FieldDic["fieldID"].Identity = NewInstanceformData.iFieldID;
            sheet_formData.Fields["fieldID"].Identity = NewInstanceformData.iFieldID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformData.iFieldID, "formData.fieldID");
            NewInstanceformData.iFieldName = new byForm_Server.ku.by.Identity.Reference();
            NewInstanceformData.iFieldName.to = sheet_formData.Fields["fieldName"];
            sheet_formData.FieldDic["fieldName"].Identity = NewInstanceformData.iFieldName;
            sheet_formData.Fields["fieldName"].Identity = NewInstanceformData.iFieldName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformData.iFieldName, "formData.fieldName");
            NewInstanceformData.iCellValue = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformData.iCellValue.to = sheet_formData.Fields["cellValue"];
            sheet_formData.FieldDic["cellValue"].Identity = NewInstanceformData.iCellValue;
            sheet_formData.Fields["cellValue"].Identity = NewInstanceformData.iCellValue;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformData.iCellValue, "formData.cellValue");
            NewInstanceformData.iUserID = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceformData.iUserID.to = sheet_formData.Fields["userID"];
            sheet_formData.FieldDic["userID"].Identity = NewInstanceformData.iUserID;
            sheet_formData.Fields["userID"].Identity = NewInstanceformData.iUserID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceformData.iUserID, "formData.userID");
            NewInstanceformData.rFormSys = NewIdentityDic["New_formSys"] as byForm_Server.ku.byForm.Identity.formSys;
            NewInstanceform.ku = "byFormNew";
            NewInstanceform.to = sheet_form;

            sheet_form.Identity = NewInstanceform;
            this.DataSheetIdentityDic.Add(NewInstanceform, sheet_form);
            NewInstanceform.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstanceform.iID.to = sheet_form.Fields["iD"];
            sheet_form.FieldDic["iD"].Identity = NewInstanceform.iID;
            sheet_form.Fields["iD"].Identity = NewInstanceform.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceform.iID, "form.iD");
            NewInstanceform.iName = new byForm_Server.ku.by.Identity.Name();
            NewInstanceform.iName.to = sheet_form.Fields["name"];
            sheet_form.FieldDic["name"].Identity = NewInstanceform.iName;
            sheet_form.Fields["name"].Identity = NewInstanceform.iName;
            this.NewIdentityDicKeyIsId.Add(NewInstanceform.iName, "form.name");
            NewInstanceform.iSuccessMsg = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceform.iSuccessMsg.to = sheet_form.Fields["successMsg"];
            sheet_form.FieldDic["successMsg"].Identity = NewInstanceform.iSuccessMsg;
            sheet_form.Fields["successMsg"].Identity = NewInstanceform.iSuccessMsg;
            this.NewIdentityDicKeyIsId.Add(NewInstanceform.iSuccessMsg, "form.successMsg");
            NewInstanceform.iSubmitButton = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceform.iSubmitButton.to = sheet_form.Fields["submitButton"];
            sheet_form.FieldDic["submitButton"].Identity = NewInstanceform.iSubmitButton;
            sheet_form.Fields["submitButton"].Identity = NewInstanceform.iSubmitButton;
            this.NewIdentityDicKeyIsId.Add(NewInstanceform.iSubmitButton, "form.submitButton");
            NewInstanceform.iSummary = new byForm_Server.ku.by.Identity.ID();
            NewInstanceform.iSummary.to = sheet_form.Fields["summary"];
            sheet_form.FieldDic["summary"].Identity = NewInstanceform.iSummary;
            sheet_form.Fields["summary"].Identity = NewInstanceform.iSummary;
            this.NewIdentityDicKeyIsId.Add(NewInstanceform.iSummary, "form.summary");
            NewInstanceform.iUserID = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceform.iUserID.to = sheet_form.Fields["userID"];
            sheet_form.FieldDic["userID"].Identity = NewInstanceform.iUserID;
            sheet_form.Fields["userID"].Identity = NewInstanceform.iUserID;
            this.NewIdentityDicKeyIsId.Add(NewInstanceform.iUserID, "form.userID");
            NewInstanceform.rFormSys = NewIdentityDic["New_formSys"] as byForm_Server.ku.byForm.Identity.formSys;
            NewInstanceform.iCreateDt = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceform.iCreateDt.to = sheet_form.Fields["createDt"];
            sheet_form.FieldDic["createDt"].Identity = NewInstanceform.iCreateDt;
            sheet_form.Fields["createDt"].Identity = NewInstanceform.iCreateDt;
            this.NewIdentityDicKeyIsId.Add(NewInstanceform.iCreateDt, "form.createDt");
            NewInstanceform.iCurrentModifyDt = new byForm_Server.ku.by.Identity.Attribute();
            NewInstanceform.iCurrentModifyDt.to = sheet_form.Fields["currentModifyDt"];
            sheet_form.FieldDic["currentModifyDt"].Identity = NewInstanceform.iCurrentModifyDt;
            sheet_form.Fields["currentModifyDt"].Identity = NewInstanceform.iCurrentModifyDt;
            this.NewIdentityDicKeyIsId.Add(NewInstanceform.iCurrentModifyDt, "form.currentModifyDt");
            NewInstancefieldTemplate.ku = "byFormNew";
            NewInstancefieldTemplate.to = sheet_fieldTemplate;

            sheet_fieldTemplate.Identity = NewInstancefieldTemplate;
            this.DataSheetIdentityDic.Add(NewInstancefieldTemplate, sheet_fieldTemplate);
            NewInstancefieldTemplate.iID = new byForm_Server.ku.by.Identity.ID();
            NewInstancefieldTemplate.iID.to = sheet_fieldTemplate.Fields["iD"];
            sheet_fieldTemplate.FieldDic["iD"].Identity = NewInstancefieldTemplate.iID;
            sheet_fieldTemplate.Fields["iD"].Identity = NewInstancefieldTemplate.iID;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iID, "fieldTemplate.iD");
            NewInstancefieldTemplate.iName = new byForm_Server.ku.by.Identity.Name();
            NewInstancefieldTemplate.iName.to = sheet_fieldTemplate.Fields["name"];
            sheet_fieldTemplate.FieldDic["name"].Identity = NewInstancefieldTemplate.iName;
            sheet_fieldTemplate.Fields["name"].Identity = NewInstancefieldTemplate.iName;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iName, "fieldTemplate.name");
            NewInstancefieldTemplate.iSummary = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iSummary.to = sheet_fieldTemplate.Fields["summary"];
            sheet_fieldTemplate.FieldDic["summary"].Identity = NewInstancefieldTemplate.iSummary;
            sheet_fieldTemplate.Fields["summary"].Identity = NewInstancefieldTemplate.iSummary;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iSummary, "fieldTemplate.summary");
            NewInstancefieldTemplate.iCtrType = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iCtrType.to = sheet_fieldTemplate.Fields["ctrType"];
            sheet_fieldTemplate.FieldDic["ctrType"].Identity = NewInstancefieldTemplate.iCtrType;
            sheet_fieldTemplate.Fields["ctrType"].Identity = NewInstancefieldTemplate.iCtrType;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iCtrType, "fieldTemplate.ctrType");
            NewInstancefieldTemplate.iIco = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iIco.to = sheet_fieldTemplate.Fields["ico"];
            sheet_fieldTemplate.FieldDic["ico"].Identity = NewInstancefieldTemplate.iIco;
            sheet_fieldTemplate.Fields["ico"].Identity = NewInstancefieldTemplate.iIco;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iIco, "fieldTemplate.ico");
            NewInstancefieldTemplate.iMin = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iMin.to = sheet_fieldTemplate.Fields["min"];
            sheet_fieldTemplate.FieldDic["min"].Identity = NewInstancefieldTemplate.iMin;
            sheet_fieldTemplate.Fields["min"].Identity = NewInstancefieldTemplate.iMin;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iMin, "fieldTemplate.min");
            NewInstancefieldTemplate.iMax = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iMax.to = sheet_fieldTemplate.Fields["max"];
            sheet_fieldTemplate.FieldDic["max"].Identity = NewInstancefieldTemplate.iMax;
            sheet_fieldTemplate.Fields["max"].Identity = NewInstancefieldTemplate.iMax;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iMax, "fieldTemplate.max");
            NewInstancefieldTemplate.iDefault = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iDefault.to = sheet_fieldTemplate.Fields["default2"];
            sheet_fieldTemplate.FieldDic["default2"].Identity = NewInstancefieldTemplate.iDefault;
            sheet_fieldTemplate.Fields["default2"].Identity = NewInstancefieldTemplate.iDefault;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iDefault, "fieldTemplate.default2");
            NewInstancefieldTemplate.iReg = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iReg.to = sheet_fieldTemplate.Fields["reg"];
            sheet_fieldTemplate.FieldDic["reg"].Identity = NewInstancefieldTemplate.iReg;
            sheet_fieldTemplate.Fields["reg"].Identity = NewInstancefieldTemplate.iReg;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iReg, "fieldTemplate.reg");
            NewInstancefieldTemplate.iRegMsg = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iRegMsg.to = sheet_fieldTemplate.Fields["regMsg"];
            sheet_fieldTemplate.FieldDic["regMsg"].Identity = NewInstancefieldTemplate.iRegMsg;
            sheet_fieldTemplate.Fields["regMsg"].Identity = NewInstancefieldTemplate.iRegMsg;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iRegMsg, "fieldTemplate.regMsg");
            NewInstancefieldTemplate.rFormSys = NewIdentityDic["New_formSys"] as byForm_Server.ku.byForm.Identity.formSys;
            NewInstancefieldTemplate.iCreateDt = new byForm_Server.ku.by.Identity.Attribute();
            NewInstancefieldTemplate.iCreateDt.to = sheet_fieldTemplate.Fields["createDt"];
            sheet_fieldTemplate.FieldDic["createDt"].Identity = NewInstancefieldTemplate.iCreateDt;
            sheet_fieldTemplate.Fields["createDt"].Identity = NewInstancefieldTemplate.iCreateDt;
            this.NewIdentityDicKeyIsId.Add(NewInstancefieldTemplate.iCreateDt, "fieldTemplate.createDt");
            this.sqlLocation = new SqlExpression.SqlLocation();
            NewInstanceformSys.rForm = NewInstanceform;
            NewInstanceformSys.rFormField = NewInstanceformField;
            NewInstanceformSys.rFormData = NewInstanceformData;
            NewInstanceformSys.rFieldTemplate = NewInstancefieldTemplate;
            NewInstanceformSys.rFormTemplate = NewInstanceformTemplate;
            NewInstanceformSys.rVData64 = NewInstanceformData;
            NewInstanceformSys.rVData256 = NewInstanceformData;
            NewInstanceformSys.rVData1024 = NewInstanceformData;
            NewInstanceformSys.rVData4000 = NewInstanceformData;
        }

        public void FillIdentityComponent()
        {
            ((byForm_Server.ku.byForm.Identity.fieldTemplate)NewIdentityDic["New_fieldTemplate"]).rUser = Root.GetInstance()["byUser"].NewIdentityDic["New_user"] as byForm_Server.ku.byUser.Identity.user;
            ((byForm_Server.ku.byForm.Identity.formSys)NewIdentityDic["New_formSys"]).rUser = Root.GetInstance()["byUser"].NewIdentityDic["New_user"] as byForm_Server.ku.byUser.Identity.user;
            ((byForm_Server.ku.byForm.Identity.fieldTemplate)NewIdentityDic["New_fieldTemplate"]).rUser = Root.GetInstance()["byUser"].NewIdentityDic["New_user"] as byForm_Server.ku.byUser.Identity.user;

        }
    }
}
