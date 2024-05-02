package $Ku.byFormNew;

public class byFormNew extends $Ku.by.ToolClass.BaseKu {
    public byFormNew() {
        this.Name = "byFormNew";

        $Ku.byFormNew.DataSheet.biao$formField sheet$formField = new $Ku.byFormNew.DataSheet.biao$formField();

        this.DataSheetDic.put("formField", sheet$formField);

        this.RelationDic.put("formField", new java.util.ArrayList<>());

        this.RelationDic.get("formField").add(new $Ku.by.ToolClass.SheetRelation("form.iD", "formField.form"));

        $Ku.byFormNew.DataSheet.biao$formTemplate sheet$formTemplate = new $Ku.byFormNew.DataSheet.biao$formTemplate();

        this.DataSheetDic.put("formTemplate", sheet$formTemplate);

        this.RelationDic.put("formTemplate", new java.util.ArrayList<>());

        this.RelationDic.get("formTemplate").add(new $Ku.by.ToolClass.SheetRelation("user.ID", "formTemplate.userID"));

        $Ku.byFormNew.DataSheet.biao$formData sheet$formData = new $Ku.byFormNew.DataSheet.biao$formData();

        this.DataSheetDic.put("formData", sheet$formData);

        this.RelationDic.put("formData", new java.util.ArrayList<>());

        this.RelationDic.get("formData").add(new $Ku.by.ToolClass.SheetRelation("form.iD", "formData.formID"));

        this.RelationDic.get("formData").add(new $Ku.by.ToolClass.SheetRelation("formField.iD", "formData.fieldID"));

        this.RelationDic.get("formData").add(new $Ku.by.ToolClass.SheetRelation("user.ID", "formData.userID"));

        $Ku.byFormNew.DataSheet.biao$form sheet$form = new $Ku.byFormNew.DataSheet.biao$form();

        this.DataSheetDic.put("form", sheet$form);

        this.RelationDic.put("form", new java.util.ArrayList<>());

        this.RelationDic.get("form").add(new $Ku.by.ToolClass.SheetRelation("user.ID", "form.userID"));

        $Ku.byFormNew.DataSheet.biao$fieldTemplate sheet$fieldTemplate = new $Ku.byFormNew.DataSheet.biao$fieldTemplate();

        this.DataSheetDic.put("fieldTemplate", sheet$fieldTemplate);

        $Ku.byForm.Identity.formField NewInstanceformField = new $Ku.byForm.Identity.formField();
        this.NewIdentityDic.put("New_formField", NewInstanceformField);
        this.NewIdentityKeyIsId.put(NewInstanceformField, "New_formField");
        $Ku.byForm.Identity.formSys NewInstanceformSys = new $Ku.byForm.Identity.formSys();
        this.NewIdentityDic.put("New_formSys", NewInstanceformSys);
        this.NewIdentityKeyIsId.put(NewInstanceformSys, "New_formSys");
        $Ku.byForm.Identity.formTemplate NewInstanceformTemplate = new $Ku.byForm.Identity.formTemplate();
        this.NewIdentityDic.put("New_formTemplate", NewInstanceformTemplate);
        this.NewIdentityKeyIsId.put(NewInstanceformTemplate, "New_formTemplate");
        $Ku.byForm.Identity.formData NewInstanceformData = new $Ku.byForm.Identity.formData();
        this.NewIdentityDic.put("New_formData", NewInstanceformData);
        this.NewIdentityKeyIsId.put(NewInstanceformData, "New_formData");
        $Ku.byForm.Identity.form NewInstanceform = new $Ku.byForm.Identity.form();
        this.NewIdentityDic.put("New_form", NewInstanceform);
        this.NewIdentityKeyIsId.put(NewInstanceform, "New_form");
        $Ku.byForm.Identity.fieldTemplate NewInstancefieldTemplate = new $Ku.byForm.Identity.fieldTemplate();
        this.NewIdentityDic.put("New_fieldTemplate", NewInstancefieldTemplate);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate, "New_fieldTemplate");
        NewInstanceformField.setKu("byFormNew");
        NewInstanceformField.setTo(sheet$formField);

        sheet$formField.setIdentity(NewInstanceformField);
        this.DataSheetIdentityDic.put(NewInstanceformField, sheet$formField);
        NewInstanceformField.iID = new $Ku.by.Identity.ID();
        NewInstanceformField.iID.setTo(sheet$formField.getFieldDic().get("iD"));
        sheet$formField.getFieldDic().get("iD").setIdentity(NewInstanceformField.iID);
        this.NewIdentityDic.put("formField.iD", NewInstanceformField.iID);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iID, "formField.iD");
        NewInstanceformField.iFormID = new $Ku.by.Identity.Reference();
        NewInstanceformField.iFormID.setTo(sheet$formField.getFieldDic().get("form"));
        sheet$formField.getFieldDic().get("form").setIdentity(NewInstanceformField.iFormID);
        this.NewIdentityDic.put("formField.form", NewInstanceformField.iFormID);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFormID, "formField.form");
        NewInstanceformField.iFieldNO = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldNO.setTo(sheet$formField.getFieldDic().get("fieldNO"));
        sheet$formField.getFieldDic().get("fieldNO").setIdentity(NewInstanceformField.iFieldNO);
        this.NewIdentityDic.put("formField.fieldNO", NewInstanceformField.iFieldNO);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldNO, "formField.fieldNO");
        NewInstanceformField.iFieldName = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldName.setTo(sheet$formField.getFieldDic().get("fieldName"));
        sheet$formField.getFieldDic().get("fieldName").setIdentity(NewInstanceformField.iFieldName);
        this.NewIdentityDic.put("formField.fieldName", NewInstanceformField.iFieldName);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldName, "formField.fieldName");
        NewInstanceformField.iSummary = new $Ku.by.Identity.ID();
        NewInstanceformField.iSummary.setTo(sheet$formField.getFieldDic().get("summary"));
        sheet$formField.getFieldDic().get("summary").setIdentity(NewInstanceformField.iSummary);
        this.NewIdentityDic.put("formField.summary", NewInstanceformField.iSummary);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iSummary, "formField.summary");
        NewInstanceformField.iFieldType = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldType.setTo(sheet$formField.getFieldDic().get("fieldType"));
        sheet$formField.getFieldDic().get("fieldType").setIdentity(NewInstanceformField.iFieldType);
        this.NewIdentityDic.put("formField.fieldType", NewInstanceformField.iFieldType);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldType, "formField.fieldType");
        NewInstanceformField.iFieldCtrl = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldCtrl.setTo(sheet$formField.getFieldDic().get("fieldCtrl"));
        sheet$formField.getFieldDic().get("fieldCtrl").setIdentity(NewInstanceformField.iFieldCtrl);
        this.NewIdentityDic.put("formField.fieldCtrl", NewInstanceformField.iFieldCtrl);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldCtrl, "formField.fieldCtrl");
        NewInstanceformField.iSelectValue = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iSelectValue.setTo(sheet$formField.getFieldDic().get("selectValue"));
        sheet$formField.getFieldDic().get("selectValue").setIdentity(NewInstanceformField.iSelectValue);
        this.NewIdentityDic.put("formField.selectValue", NewInstanceformField.iSelectValue);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iSelectValue, "formField.selectValue");
        NewInstanceformField.iFieldMin = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldMin.setTo(sheet$formField.getFieldDic().get("fieldMin"));
        sheet$formField.getFieldDic().get("fieldMin").setIdentity(NewInstanceformField.iFieldMin);
        this.NewIdentityDic.put("formField.fieldMin", NewInstanceformField.iFieldMin);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldMin, "formField.fieldMin");
        NewInstanceformField.iFieldMax = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldMax.setTo(sheet$formField.getFieldDic().get("fieldMax"));
        sheet$formField.getFieldDic().get("fieldMax").setIdentity(NewInstanceformField.iFieldMax);
        this.NewIdentityDic.put("formField.fieldMax", NewInstanceformField.iFieldMax);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldMax, "formField.fieldMax");
        NewInstanceformField.iFieldReg = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldReg.setTo(sheet$formField.getFieldDic().get("fieldReg"));
        sheet$formField.getFieldDic().get("fieldReg").setIdentity(NewInstanceformField.iFieldReg);
        this.NewIdentityDic.put("formField.fieldReg", NewInstanceformField.iFieldReg);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldReg, "formField.fieldReg");
        NewInstanceformField.iFieldRegMsg = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldRegMsg.setTo(sheet$formField.getFieldDic().get("fieldRegMsg"));
        sheet$formField.getFieldDic().get("fieldRegMsg").setIdentity(NewInstanceformField.iFieldRegMsg);
        this.NewIdentityDic.put("formField.fieldRegMsg", NewInstanceformField.iFieldRegMsg);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldRegMsg, "formField.fieldRegMsg");
        NewInstanceformField.iFieldDefault = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iFieldDefault.setTo(sheet$formField.getFieldDic().get("fieldDefault"));
        sheet$formField.getFieldDic().get("fieldDefault").setIdentity(NewInstanceformField.iFieldDefault);
        this.NewIdentityDic.put("formField.fieldDefault", NewInstanceformField.iFieldDefault);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iFieldDefault, "formField.fieldDefault");
        NewInstanceformField.iOrder = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iOrder.setTo(sheet$formField.getFieldDic().get("order"));
        sheet$formField.getFieldDic().get("order").setIdentity(NewInstanceformField.iOrder);
        this.NewIdentityDic.put("formField.order", NewInstanceformField.iOrder);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iOrder, "formField.order");
        NewInstanceformField.iVDataValue = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iVDataValue.setTo(sheet$formField.getFieldDic().get("vDataValue"));
        sheet$formField.getFieldDic().get("vDataValue").setIdentity(NewInstanceformField.iVDataValue);
        this.NewIdentityDic.put("formField.vDataValue", NewInstanceformField.iVDataValue);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iVDataValue, "formField.vDataValue");
        NewInstanceformField.rFormSys = ($Ku.byForm.Identity.formSys) NewIdentityDic.get("New_formSys");
        NewInstanceformField.iUserID = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iUserID.setTo(sheet$formField.getFieldDic().get("userID"));
        sheet$formField.getFieldDic().get("userID").setIdentity(NewInstanceformField.iUserID);
        this.NewIdentityDic.put("formField.userID", NewInstanceformField.iUserID);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iUserID, "formField.userID");
        NewInstanceformField.iNotNull = new $Ku.by.Identity.Attribute();
        NewInstanceformField.iNotNull.setTo(sheet$formField.getFieldDic().get("notNull"));
        sheet$formField.getFieldDic().get("notNull").setIdentity(NewInstanceformField.iNotNull);
        this.NewIdentityDic.put("formField.notNull", NewInstanceformField.iNotNull);
        this.NewIdentityKeyIsId.put(NewInstanceformField.iNotNull, "formField.notNull");
        NewInstanceformSys.setKu("byFormNew");
        NewInstanceformTemplate.setKu("byFormNew");
        NewInstanceformTemplate.setTo(sheet$formTemplate);

        sheet$formTemplate.setIdentity(NewInstanceformTemplate);
        this.DataSheetIdentityDic.put(NewInstanceformTemplate, sheet$formTemplate);
        NewInstanceformTemplate.iID = new $Ku.by.Identity.ID();
        NewInstanceformTemplate.iID.setTo(sheet$formTemplate.getFieldDic().get("ID"));
        sheet$formTemplate.getFieldDic().get("ID").setIdentity(NewInstanceformTemplate.iID);
        this.NewIdentityDic.put("formTemplate.ID", NewInstanceformTemplate.iID);
        this.NewIdentityKeyIsId.put(NewInstanceformTemplate.iID, "formTemplate.ID");
        NewInstanceformTemplate.iFormID = new $Ku.by.Identity.Reference();
        NewInstanceformTemplate.iFormID.setTo(sheet$formTemplate.getFieldDic().get("formID"));
        sheet$formTemplate.getFieldDic().get("formID").setIdentity(NewInstanceformTemplate.iFormID);
        this.NewIdentityDic.put("formTemplate.formID", NewInstanceformTemplate.iFormID);
        this.NewIdentityKeyIsId.put(NewInstanceformTemplate.iFormID, "formTemplate.formID");
        NewInstanceformTemplate.iUserID = new $Ku.by.Identity.Attribute();
        NewInstanceformTemplate.iUserID.setTo(sheet$formTemplate.getFieldDic().get("userID"));
        sheet$formTemplate.getFieldDic().get("userID").setIdentity(NewInstanceformTemplate.iUserID);
        this.NewIdentityDic.put("formTemplate.userID", NewInstanceformTemplate.iUserID);
        this.NewIdentityKeyIsId.put(NewInstanceformTemplate.iUserID, "formTemplate.userID");
        NewInstanceformTemplate.iName = new $Ku.by.Identity.Name();
        NewInstanceformTemplate.iName.setTo(sheet$formTemplate.getFieldDic().get("name"));
        sheet$formTemplate.getFieldDic().get("name").setIdentity(NewInstanceformTemplate.iName);
        this.NewIdentityDic.put("formTemplate.name", NewInstanceformTemplate.iName);
        this.NewIdentityKeyIsId.put(NewInstanceformTemplate.iName, "formTemplate.name");
        NewInstanceformTemplate.rFormSys = ($Ku.byForm.Identity.formSys) NewIdentityDic.get("New_formSys");
        NewInstanceformData.setKu("byFormNew");
        NewInstanceformData.setTo(sheet$formData);

        sheet$formData.setIdentity(NewInstanceformData);
        this.DataSheetIdentityDic.put(NewInstanceformData, sheet$formData);
        NewInstanceformData.iID = new $Ku.by.Identity.ID();
        NewInstanceformData.iID.setTo(sheet$formData.getFieldDic().get("iD"));
        sheet$formData.getFieldDic().get("iD").setIdentity(NewInstanceformData.iID);
        this.NewIdentityDic.put("formData.iD", NewInstanceformData.iID);
        this.NewIdentityKeyIsId.put(NewInstanceformData.iID, "formData.iD");
        NewInstanceformData.iFormID = new $Ku.by.Identity.Reference();
        NewInstanceformData.iFormID.setTo(sheet$formData.getFieldDic().get("formID"));
        sheet$formData.getFieldDic().get("formID").setIdentity(NewInstanceformData.iFormID);
        this.NewIdentityDic.put("formData.formID", NewInstanceformData.iFormID);
        this.NewIdentityKeyIsId.put(NewInstanceformData.iFormID, "formData.formID");
        NewInstanceformData.iRowPK = new $Ku.by.Identity.Attribute();
        NewInstanceformData.iRowPK.setTo(sheet$formData.getFieldDic().get("rowPK"));
        sheet$formData.getFieldDic().get("rowPK").setIdentity(NewInstanceformData.iRowPK);
        this.NewIdentityDic.put("formData.rowPK", NewInstanceformData.iRowPK);
        this.NewIdentityKeyIsId.put(NewInstanceformData.iRowPK, "formData.rowPK");
        NewInstanceformData.iFieldID = new $Ku.by.Identity.Reference();
        NewInstanceformData.iFieldID.setTo(sheet$formData.getFieldDic().get("fieldID"));
        sheet$formData.getFieldDic().get("fieldID").setIdentity(NewInstanceformData.iFieldID);
        this.NewIdentityDic.put("formData.fieldID", NewInstanceformData.iFieldID);
        this.NewIdentityKeyIsId.put(NewInstanceformData.iFieldID, "formData.fieldID");
        NewInstanceformData.iFieldName = new $Ku.by.Identity.Reference();
        NewInstanceformData.iFieldName.setTo(sheet$formData.getFieldDic().get("fieldName"));
        sheet$formData.getFieldDic().get("fieldName").setIdentity(NewInstanceformData.iFieldName);
        this.NewIdentityDic.put("formData.fieldName", NewInstanceformData.iFieldName);
        this.NewIdentityKeyIsId.put(NewInstanceformData.iFieldName, "formData.fieldName");
        NewInstanceformData.iCellValue = new $Ku.by.Identity.Attribute();
        NewInstanceformData.iCellValue.setTo(sheet$formData.getFieldDic().get("cellValue"));
        sheet$formData.getFieldDic().get("cellValue").setIdentity(NewInstanceformData.iCellValue);
        this.NewIdentityDic.put("formData.cellValue", NewInstanceformData.iCellValue);
        this.NewIdentityKeyIsId.put(NewInstanceformData.iCellValue, "formData.cellValue");
        NewInstanceformData.iUserID = new $Ku.by.Identity.Attribute();
        NewInstanceformData.iUserID.setTo(sheet$formData.getFieldDic().get("userID"));
        sheet$formData.getFieldDic().get("userID").setIdentity(NewInstanceformData.iUserID);
        this.NewIdentityDic.put("formData.userID", NewInstanceformData.iUserID);
        this.NewIdentityKeyIsId.put(NewInstanceformData.iUserID, "formData.userID");
        NewInstanceformData.rFormSys = ($Ku.byForm.Identity.formSys) NewIdentityDic.get("New_formSys");
        NewInstanceform.setKu("byFormNew");
        NewInstanceform.setTo(sheet$form);

        sheet$form.setIdentity(NewInstanceform);
        this.DataSheetIdentityDic.put(NewInstanceform, sheet$form);
        NewInstanceform.iID = new $Ku.by.Identity.ID();
        NewInstanceform.iID.setTo(sheet$form.getFieldDic().get("iD"));
        sheet$form.getFieldDic().get("iD").setIdentity(NewInstanceform.iID);
        this.NewIdentityDic.put("form.iD", NewInstanceform.iID);
        this.NewIdentityKeyIsId.put(NewInstanceform.iID, "form.iD");
        NewInstanceform.iName = new $Ku.by.Identity.Name();
        NewInstanceform.iName.setTo(sheet$form.getFieldDic().get("name"));
        sheet$form.getFieldDic().get("name").setIdentity(NewInstanceform.iName);
        this.NewIdentityDic.put("form.name", NewInstanceform.iName);
        this.NewIdentityKeyIsId.put(NewInstanceform.iName, "form.name");
        NewInstanceform.iSuccessMsg = new $Ku.by.Identity.Attribute();
        NewInstanceform.iSuccessMsg.setTo(sheet$form.getFieldDic().get("successMsg"));
        sheet$form.getFieldDic().get("successMsg").setIdentity(NewInstanceform.iSuccessMsg);
        this.NewIdentityDic.put("form.successMsg", NewInstanceform.iSuccessMsg);
        this.NewIdentityKeyIsId.put(NewInstanceform.iSuccessMsg, "form.successMsg");
        NewInstanceform.iSubmitButton = new $Ku.by.Identity.Attribute();
        NewInstanceform.iSubmitButton.setTo(sheet$form.getFieldDic().get("submitButton"));
        sheet$form.getFieldDic().get("submitButton").setIdentity(NewInstanceform.iSubmitButton);
        this.NewIdentityDic.put("form.submitButton", NewInstanceform.iSubmitButton);
        this.NewIdentityKeyIsId.put(NewInstanceform.iSubmitButton, "form.submitButton");
        NewInstanceform.iSummary = new $Ku.by.Identity.ID();
        NewInstanceform.iSummary.setTo(sheet$form.getFieldDic().get("summary"));
        sheet$form.getFieldDic().get("summary").setIdentity(NewInstanceform.iSummary);
        this.NewIdentityDic.put("form.summary", NewInstanceform.iSummary);
        this.NewIdentityKeyIsId.put(NewInstanceform.iSummary, "form.summary");
        NewInstanceform.iUserID = new $Ku.by.Identity.Attribute();
        NewInstanceform.iUserID.setTo(sheet$form.getFieldDic().get("userID"));
        sheet$form.getFieldDic().get("userID").setIdentity(NewInstanceform.iUserID);
        this.NewIdentityDic.put("form.userID", NewInstanceform.iUserID);
        this.NewIdentityKeyIsId.put(NewInstanceform.iUserID, "form.userID");
        NewInstanceform.rFormSys = ($Ku.byForm.Identity.formSys) NewIdentityDic.get("New_formSys");
        NewInstanceform.iCreateDt = new $Ku.by.Identity.Attribute();
        NewInstanceform.iCreateDt.setTo(sheet$form.getFieldDic().get("createDt"));
        sheet$form.getFieldDic().get("createDt").setIdentity(NewInstanceform.iCreateDt);
        this.NewIdentityDic.put("form.createDt", NewInstanceform.iCreateDt);
        this.NewIdentityKeyIsId.put(NewInstanceform.iCreateDt, "form.createDt");
        NewInstanceform.iCurrentModifyDt = new $Ku.by.Identity.Attribute();
        NewInstanceform.iCurrentModifyDt.setTo(sheet$form.getFieldDic().get("currentModifyDt"));
        sheet$form.getFieldDic().get("currentModifyDt").setIdentity(NewInstanceform.iCurrentModifyDt);
        this.NewIdentityDic.put("form.currentModifyDt", NewInstanceform.iCurrentModifyDt);
        this.NewIdentityKeyIsId.put(NewInstanceform.iCurrentModifyDt, "form.currentModifyDt");
        NewInstancefieldTemplate.setKu("byFormNew");
        NewInstancefieldTemplate.setTo(sheet$fieldTemplate);

        sheet$fieldTemplate.setIdentity(NewInstancefieldTemplate);
        this.DataSheetIdentityDic.put(NewInstancefieldTemplate, sheet$fieldTemplate);
        NewInstancefieldTemplate.iID = new $Ku.by.Identity.ID();
        NewInstancefieldTemplate.iID.setTo(sheet$fieldTemplate.getFieldDic().get("iD"));
        sheet$fieldTemplate.getFieldDic().get("iD").setIdentity(NewInstancefieldTemplate.iID);
        this.NewIdentityDic.put("fieldTemplate.iD", NewInstancefieldTemplate.iID);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iID, "fieldTemplate.iD");
        NewInstancefieldTemplate.iName = new $Ku.by.Identity.Name();
        NewInstancefieldTemplate.iName.setTo(sheet$fieldTemplate.getFieldDic().get("name"));
        sheet$fieldTemplate.getFieldDic().get("name").setIdentity(NewInstancefieldTemplate.iName);
        this.NewIdentityDic.put("fieldTemplate.name", NewInstancefieldTemplate.iName);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iName, "fieldTemplate.name");
        NewInstancefieldTemplate.iSummary = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iSummary.setTo(sheet$fieldTemplate.getFieldDic().get("summary"));
        sheet$fieldTemplate.getFieldDic().get("summary").setIdentity(NewInstancefieldTemplate.iSummary);
        this.NewIdentityDic.put("fieldTemplate.summary", NewInstancefieldTemplate.iSummary);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iSummary, "fieldTemplate.summary");
        NewInstancefieldTemplate.iCtrType = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iCtrType.setTo(sheet$fieldTemplate.getFieldDic().get("ctrType"));
        sheet$fieldTemplate.getFieldDic().get("ctrType").setIdentity(NewInstancefieldTemplate.iCtrType);
        this.NewIdentityDic.put("fieldTemplate.ctrType", NewInstancefieldTemplate.iCtrType);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iCtrType, "fieldTemplate.ctrType");
        NewInstancefieldTemplate.iIco = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iIco.setTo(sheet$fieldTemplate.getFieldDic().get("ico"));
        sheet$fieldTemplate.getFieldDic().get("ico").setIdentity(NewInstancefieldTemplate.iIco);
        this.NewIdentityDic.put("fieldTemplate.ico", NewInstancefieldTemplate.iIco);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iIco, "fieldTemplate.ico");
        NewInstancefieldTemplate.iMin = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iMin.setTo(sheet$fieldTemplate.getFieldDic().get("min"));
        sheet$fieldTemplate.getFieldDic().get("min").setIdentity(NewInstancefieldTemplate.iMin);
        this.NewIdentityDic.put("fieldTemplate.min", NewInstancefieldTemplate.iMin);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iMin, "fieldTemplate.min");
        NewInstancefieldTemplate.iMax = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iMax.setTo(sheet$fieldTemplate.getFieldDic().get("max"));
        sheet$fieldTemplate.getFieldDic().get("max").setIdentity(NewInstancefieldTemplate.iMax);
        this.NewIdentityDic.put("fieldTemplate.max", NewInstancefieldTemplate.iMax);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iMax, "fieldTemplate.max");
        NewInstancefieldTemplate.iDefault = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iDefault.setTo(sheet$fieldTemplate.getFieldDic().get("default2"));
        sheet$fieldTemplate.getFieldDic().get("default2").setIdentity(NewInstancefieldTemplate.iDefault);
        this.NewIdentityDic.put("fieldTemplate.default2", NewInstancefieldTemplate.iDefault);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iDefault, "fieldTemplate.default2");
        NewInstancefieldTemplate.iReg = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iReg.setTo(sheet$fieldTemplate.getFieldDic().get("reg"));
        sheet$fieldTemplate.getFieldDic().get("reg").setIdentity(NewInstancefieldTemplate.iReg);
        this.NewIdentityDic.put("fieldTemplate.reg", NewInstancefieldTemplate.iReg);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iReg, "fieldTemplate.reg");
        NewInstancefieldTemplate.iRegMsg = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iRegMsg.setTo(sheet$fieldTemplate.getFieldDic().get("regMsg"));
        sheet$fieldTemplate.getFieldDic().get("regMsg").setIdentity(NewInstancefieldTemplate.iRegMsg);
        this.NewIdentityDic.put("fieldTemplate.regMsg", NewInstancefieldTemplate.iRegMsg);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iRegMsg, "fieldTemplate.regMsg");
        NewInstancefieldTemplate.rFormSys = ($Ku.byForm.Identity.formSys) NewIdentityDic.get("New_formSys");
        NewInstancefieldTemplate.iCreateDt = new $Ku.by.Identity.Attribute();
        NewInstancefieldTemplate.iCreateDt.setTo(sheet$fieldTemplate.getFieldDic().get("createDt"));
        sheet$fieldTemplate.getFieldDic().get("createDt").setIdentity(NewInstancefieldTemplate.iCreateDt);
        this.NewIdentityDic.put("fieldTemplate.createDt", NewInstancefieldTemplate.iCreateDt);
        this.NewIdentityKeyIsId.put(NewInstancefieldTemplate.iCreateDt, "fieldTemplate.createDt");
        this.sqlLocation = new $Ku.byFormNew.SqlExpression.SqlLocation();
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


    public void fillIdentityComponent() {
        (($Ku.byForm.Identity.fieldTemplate)NewIdentityDic.get("New_fieldTemplate")).rUser = ($Ku.byUser.Identity.user)$Ku.by.ToolClass.Root.GetInstance().get("byUser").NewIdentityDic.get("New_user");
        (($Ku.byForm.Identity.formSys)NewIdentityDic.get("New_formSys")).rUser = ($Ku.byUser.Identity.user)$Ku.by.ToolClass.Root.GetInstance().get("byUser").NewIdentityDic.get("New_user");
        (($Ku.byForm.Identity.fieldTemplate)NewIdentityDic.get("New_fieldTemplate")).rUser = ($Ku.byUser.Identity.user)$Ku.by.ToolClass.Root.GetInstance().get("byUser").NewIdentityDic.get("New_user");

    }
}
