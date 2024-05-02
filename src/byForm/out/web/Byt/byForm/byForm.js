Byt.defineKu("byForm", [ "by", "byBase", "byCommon", "byExternal", "byInterface", "byExternalChartjs", "byExternalSMS", "byLog", "byUser", "byWebCommon" ], ($by, $byBase, $byCommon, $byExternal, $byInterface, $byExternalChartjs, $byExternalSMS, $byLog, $byUser, $byWebCommon, $byForm) => ({
    enum: {
        ctrType: { textbox: 0, muiltTextbox: 1, dropdownList: 2, radbutton: 3, checkBox: 4, checkBoxList: 5, slider: 6, dateTimePicker: 7, datePicker: 8, timePicker: 9 },
        DraggingItemType: { termLabel: 0, termPanel: 1 },
        memberMode: { structureForm: 0, structureData64: 1, structureData256: 2, structureData1024: 3, structureData4000: 4 }
    },
    object: {
        FormInstancePanel: {
            type: class FormInstancePanel extends Byt.Object {
                $1(f_row){
                    this.headPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.namePanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.summaryPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.contentPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.operatePanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.nameLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.summaryLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.submitButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.defaultSubmitButtonText; });
                    this.cancelButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.cancel; });
                    this.add(this.headPanel);
                    this.add(this.contentPanel);
                    this.add(this.operatePanel);
                    this.headPanel.add(this.namePanel);
                    if(f_row.i$access("iSummary") != null && f_row.i$access("iSummary") != ""){
                        this.summaryLabel.text = f_row.i$access("iSummary");
                        this.headPanel.add(this.summaryPanel);
                    }
                    this.namePanel.add(this.nameLabel);
                    this.summaryPanel.add(this.summaryLabel);
                    this.operatePanel.add(this.submitButton);
                    this.nameLabel.text = f_row.i$access("iName");
                    this.submitButton.text = (f_row.i$access("iSubmitButton") != null && f_row.i$access("iSubmitButton") != "") ? f_row.i$access("iSubmitButton") : $byForm.object.TextHelper.defaultSubmitButtonText;
                    {
                        this.element.addClass($byForm.object.CssClassNameHelper.publishFormPanel);
                        this.headPanel.element.addClass($byForm.object.CssClassNameHelper.publishFormHeadPanel);
                        this.namePanel.element.addClass($byForm.object.CssClassNameHelper.publishFormNamePanel);
                        this.summaryPanel.element.addClass($byForm.object.CssClassNameHelper.publishFormSummaryPanel);
                        this.summaryPanel.element.children[0].addClass($byForm.object.CssClassNameHelper.publishFormSummaryPanelInner);
                        this.contentPanel.element.addClass($byForm.object.CssClassNameHelper.publishFormContentPanel);
                        this.operatePanel.element.addClass($byForm.object.CssClassNameHelper.publishFormOperatePanel);
                        this.nameLabel.element.addClass($byForm.object.CssClassNameHelper.publishFormNameLabel);
                        this.summaryLabel.element.addClass($byForm.object.CssClassNameHelper.publishFormSummaryLabel);
                        this.summaryLabel.element.children[0].addClass($byForm.object.CssClassNameHelper.publishFormSummaryLabelInner);
                        this.submitButton.element.addClass($byForm.object.CssClassNameHelper.publishFormSubmitButton);
                        this.cancelButton.element.addClass($byForm.object.CssClassNameHelper.publishFormCancelButton);
                    }
                    this.submitButton.click.$add(async (sender, args) => { await this.submitButtonClick.$invoke(this, args); });
                    this.cancelButton.click.$add(async (sender, args) => { await this.cancelButtonClick.$invoke(this, args); });
                }
                getContentPanel(){ return this.contentPanel; }
                setSubmitButtonText(text){ this.submitButton.text = text; }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { headPanel: $by.object.Panel, namePanel: $by.object.Panel, summaryPanel: $by.object.Panel, contentPanel: $by.object.Panel, operatePanel: $by.object.Panel, nameLabel: $by.object.Label, summaryLabel: $by.object.Label, submitButton: $by.object.Button, cancelButton: $by.object.Button }, events: [ "submitButtonClick", "cancelButtonClick" ] }
        },
        Common: {
            type: class Common extends Byt.Object {
                static isInt(value){ return value.by$isMatch("^-?[1-9]\\d*|0$", "multiIgnoreCase"); }
                static isPositiveInt(value){ return value.by$isMatch("^[1-9]\\d*$", "multiIgnoreCase"); }
                static isNonnegativeInt(value){ return value.by$isMatch("^[1-9]\\d*|0$", "multiIgnoreCase"); }
                static isQuoted(value){ return value.by$isMatch("^[\'\"]+$", "multiIgnoreCase"); }
                static setDateTimePickerMode(dateTimePicker, pickerType){
                    if(pickerType == "datePicker"){ dateTimePicker.mode = "date"; }
                    else if(pickerType == "timePicker"){ dateTimePicker.mode = "time"; }
                    else if(pickerType == "dateTimePicker"){ dateTimePicker.mode = "dateTime"; }
                    else {
                        throw Error(new $by.object.Exception("时间日期选择器类型错误"));
                    }
                }
                static async getColors(length, a){
                    let colors = Byt.Array.$create($by.object.Color, 1, [ length ]);
                    for (let colorIndex = 0; colorIndex < length; colorIndex++){
                        let r = await $byExternal.object.random.next$1(0, 256);
                        let g = await $byExternal.object.random.next$1(0, 256);
                        let b = await $byExternal.object.random.next$1(0, 256);
                        if(a == 255){ colors[colorIndex] = new $by.object.Color(r, g, b); }
                        else { colors[colorIndex] = new $by.object.Color(r, g, b, a); }
                    }
                    return colors;
                }
                static async getStringColors(length, a){
                    let colors = Byt.Array.$create(Byt.String, 1, [ length ]);
                    for (let colorIndex = 0; colorIndex < length; colorIndex++){
                        let r = await $byExternal.object.random.next$1(0, 256);
                        let g = await $byExternal.object.random.next$1(0, 256);
                        let b = await $byExternal.object.random.next$1(0, 256);
                        if(a == 255){ colors[colorIndex] = "rgb(" + r + "," + g + "," + b + ")"; }
                        else { colors[colorIndex] = "rgba(" + r + "," + g + "," + b + "," + a + ")"; }
                    }
                    return colors;
                }
                static toFloatArray(ints){
                    let floatValues = new $by.object.List();
                    for (let tempValue of ints){ floatValues.add(tempValue); }
                    return floatValues.toArray();
                }
                static isEmptyString(value){ return value == null || value == ""; }
                static getLengthMaxError(name, maxLength){ return Byt.String(name) + Byt.String($byForm.object.TextHelper.lengthMaxError) + maxLength; }
            }
        },
        ValueHelper: {
            type: class ValueHelper extends Byt.Object {
                static $0(){
                    this.popupWindowWidth = 350;
                    this.popupWindowHeight = 200;
                    this.formListLabelFontSize = 20;
                    this.formItemNameLabelFontSize = 20;
                    this.selectionInitCount = 2;
                    this.grayColorForButton = new $by.object.Color(102, 102, 102);
                    this.summaryValueBoxWidth = 300;
                    this.summaryValueBoxHeight = 150;
                    this.summaryInputBoxWidth = 200;
                    this.summaryInputBoxHeight = 100;
                    this.multiTextboxWidth = 400;
                    this.multiTextboxHeight = 100;
                    this.defaultSliderMin = 0;
                    this.defaultSliderMax = 10;
                    this.defaultSliderDelta = 1;
                    this.defaultCheckBoxListMin = -1;
                    this.defaultCheckBoxListMax = -1;
                    this.resultPanelPaddingTop = 10;
                    this.resultPanelPaddingBottom = 10;
                    this.initChartWidth = 0;
                    this.initChartHeight = 0;
                    this.chartWidth = 300;
                    this.chartHeight = 300;
                    this.publishDialogWidth = 880;
                    this.publishDialogHeight = 500;
                    this.publishSaasBoxWidth = 880;
                    this.publishSaasSampleBoxHeight = 220;
                    this.publishSaasBoxHeight = 70;
                    this.cFieldPanelPaddingBottom = 100;
                    this.numberBase = 1000000;
                    this.formDataCellMax = 4000;
                    this.selectionsLengthMax = 1000;
                    this.generalTextMax = 200;
                }
            },
            transmit: [ ],
            static: { props: { popupWindowWidth: Byt.Int, popupWindowHeight: Byt.Int, formListLabelFontSize: Byt.Int, formItemNameLabelFontSize: Byt.Int, selectionInitCount: Byt.Int, grayColorForButton: $by.object.Color, summaryValueBoxWidth: Byt.Int, summaryValueBoxHeight: Byt.Int, summaryInputBoxWidth: Byt.Int, summaryInputBoxHeight: Byt.Int, multiTextboxWidth: Byt.Int, multiTextboxHeight: Byt.Int, defaultSliderMin: Byt.Int, defaultSliderMax: Byt.Int, defaultSliderDelta: Byt.Int, defaultCheckBoxListMin: Byt.Int, defaultCheckBoxListMax: Byt.Int, resultPanelPaddingTop: Byt.Int, resultPanelPaddingBottom: Byt.Int, initChartWidth: Byt.Int, initChartHeight: Byt.Int, chartWidth: Byt.Int, chartHeight: Byt.Int, publishDialogWidth: Byt.Int, publishDialogHeight: Byt.Int, publishSaasBoxWidth: Byt.Int, publishSaasSampleBoxHeight: Byt.Int, publishSaasBoxHeight: Byt.Int, cFieldPanelPaddingBottom: Byt.Int, numberBase: Byt.Int, formDataCellMax: Byt.Int, selectionsLengthMax: Byt.Int, generalTextMax: Byt.Int } }
        },
        FieldControlEditor: {
            type: class FieldControlEditor extends Byt.Object {
                $1(fieldInfo){
                    this.titleEditor = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.contentEditor = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.propertyEditor = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.contentOperateEditor = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.saveEditor = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.selectionDatas = new $by.object.List();
                    this.titleTextBox = new $by.object.TextBox();
                    this.addButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.add; });
                    this.saveButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.save; });
                    this.closeButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.close; });
                    this.messageLabel = new $by.object.Label();
                    this.isModified = false;
                    this.fieldNotNullPanel = new $by.object.Panel();
                    this.fieldNotNullCheckBox = new $by.object.CheckBox().$init($ => {
                        $.isChecked = true;
                        $.text = $byForm.object.TextHelper.notNull;
                    });
                    this.fieldMaxPanel = new $byForm.object.PropertyNumberBox().$init($ => {
                        $.$1($byForm.object.TextHelper.fieldMax);
                        $.restoreValue = 4000;
                    });
                    this.fieldMinPanel = new $byForm.object.PropertyNumberBox().$init($ => {
                        $.$1($byForm.object.TextHelper.fieldMin);
                        $.restoreValue = 0;
                    });
                    this.fieldRegPanel = new $byForm.object.PropertyInputBox().$init($ => $.$1($byForm.object.TextHelper.fieldRegex));
                    this.fieldRegMsgPanel = new $byForm.object.PropertyInputBox().$init($ => $.$1($byForm.object.TextHelper.fieldRegexMessage));
                    this.fieldInfo = fieldInfo;
                    this.titleTextBox.text = fieldInfo.i$access("iFieldName");
                    this.titleEditor.add(this.titleTextBox);
                    this.add(this.titleEditor);
                    if(fieldInfo.i$access("iFieldCtrl") == "checkBoxList" || fieldInfo.i$access("iFieldCtrl") == "radbutton" || fieldInfo.i$access("iFieldCtrl") == "dropdownList"){
                        this.add(this.contentEditor);
                        this.add(this.contentOperateEditor);
                        this.contentOperateEditor.add(this.addButton);
                    }
                    if(fieldInfo.i$access("iFieldCtrl") == "checkBox"){ this.add(this.contentEditor); }
                    this.add(this.propertyEditor);
                    this.buildGeneralPropertyEditor();
                    this.saveEditor.add(this.saveButton);
                    this.saveEditor.add(this.closeButton);
                    this.add(this.saveEditor);
                    {
                        this.element.addClass($byForm.object.CssClassNameHelper.generalDetail);
                        this.titleEditor.element.addClass($byForm.object.CssClassNameHelper.generalDetailTitleEditor);
                        this.titleTextBox.element.addClass($byForm.object.CssClassNameHelper.generalDetailTitleTextBox);
                        this.contentEditor.element.addClass($byForm.object.CssClassNameHelper.generalDetailContentEditor);
                        this.contentOperateEditor.element.addClass($byForm.object.CssClassNameHelper.generalDetailContentOperateEditor);
                        this.saveButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSaveButton);
                        this.closeButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailCancelButton);
                        this.addButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailAddButton);
                    }
                    this.addButton.click.$add(async (sender, args) => {
                        let newSelectionData = new $byForm.object.SelectionData().$init($ => {
                            $.$0();
                            $.text = "";
                            $.defaultText = "选项" + Byt.String(this.getNextSelectionCount().by$toString());
                            $.order = this.selectionDatas.count;
                        });
                        this.selectionDatas.add(newSelectionData);
                        this.refreshSelectionDatas();
                        await this.buildSelectionItems();
                        $byForm.object.FieldControlEditor.selectionGrowOnlyCount++;
                        await this.addButtonClick.$invoke(this, args);
                    });
                    this.saveButton.click.$add(async (sender, args) => { await this.saveButtonClick.$invoke(this, args); });
                    this.closeButton.click.$add(async (sender, args) => { await this.cancelButtonClick.$invoke(this, args); });
                }
                getNextSelectionCount(){ return (($by.object.Math.max($byForm.object.FieldControlEditor.selectionGrowOnlyCount, this.selectionDatas.count) + 1) | 0); }
                async refreshFieldInfo(){
                    if(this.titleTextBox.text.length > $byForm.object.ValueHelper.generalTextMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError($byForm.object.TextHelper.formName, $byForm.object.ValueHelper.generalTextMax);
                    }); }
                    let count = 1;
                    let selectValueBuilder = new $by.object.StringBuilder();
                    for (let selection of this.contentEditor.children){
                        let selectionText = await ($byForm.object.SelectionEditor.$convert(selection)).getText();
                        if(selectionText.length > $byForm.object.ValueHelper.generalTextMax){ return new $by.object.Result().$init($ => {
                            $.isOk = false;
                            $.info = $byForm.object.Common.getLengthMaxError("选项名称", $byForm.object.ValueHelper.generalTextMax);
                        }); }
                        selectValueBuilder.append(selectionText);
                        if(count < this.contentEditor.children.count){
                            selectValueBuilder.append("\n");
                            count++;
                        }
                    }
                    if(selectValueBuilder.length > $byForm.object.ValueHelper.selectionsLengthMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError("选项名称总", $byForm.object.ValueHelper.selectionsLengthMax);
                    }); }
                    this.fieldInfo.i$assign("iFieldName", this.titleTextBox.text);
                    this.fieldInfo.i$assign("iSelectValue", selectValueBuilder.by$toString());
                    this.fieldInfo.i$assign("iNotNull", this.fieldNotNullCheckBox.isChecked);
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                readSelections(selections){
                    for (let selectionText of selections){
                        let selectionData = new $byForm.object.SelectionData().$init($ => {
                            $.$0();
                            $.text = selectionText;
                            $.defaultText = selectionText;
                            $.order = this.selectionDatas.count;
                        });
                        this.selectionDatas.add(selectionData);
                    }
                }
                buildTextPropertyEditor(){
                    if(this.fieldInfo.i$access("iFieldType") == "int"){
                        this.fieldMinPanel.setName($byForm.object.TextHelper.valueMin);
                        this.fieldMaxPanel.setName($byForm.object.TextHelper.valueMax);
                    }
                    this.propertyEditor.add(this.fieldMaxPanel);
                    this.propertyEditor.add(this.fieldMinPanel);
                    this.propertyEditor.add(this.fieldRegPanel);
                    this.propertyEditor.add(this.fieldRegMsgPanel);
                    this.fieldMaxPanel.setValue(Byt.Decimal(this.fieldInfo.i$access("iFieldMax")));
                    this.fieldMinPanel.setValue(Byt.Decimal(this.fieldInfo.i$access("iFieldMin")));
                    this.fieldRegPanel.setText(this.fieldInfo.i$access("iFieldReg").by$toString());
                    this.fieldRegMsgPanel.setText(this.fieldInfo.i$access("iFieldRegMsg").by$toString());
                }
                buildGeneralPropertyEditor(){
                    this.propertyEditor.add(this.fieldNotNullPanel);
                    this.fieldNotNullPanel.add(this.fieldNotNullCheckBox);
                    this.fieldNotNullCheckBox.isChecked = this.fieldInfo.i$access("iNotNull");
                }
                setMessage(message){
                    this.messageLabel.remove();
                    this.messageLabel.text = message;
                    this.add(this.messageLabel);
                }
                clearMessage(message){
                    this.messageLabel.text = "";
                    this.messageLabel.remove();
                }
                async buildSelectionItems(){
                    this.contentEditor.clear();
                    for (let selectionData of this.selectionDatas){
                        let selectionEditor = await new $byForm.object.SelectionEditor().$init($ => $.$1(selectionData, this.fieldInfo.i$access("iFieldCtrl") != "checkBox"));
                        selectionEditor.addButtonClick.$add(this.$access("onSelectionAddButtonClick"));
                        selectionEditor.delButtonClick.$add(this.$access("onSelectionDelButtonClick"));
                        selectionEditor.textBoxTextChanged.$add(this.$access("onSelectionTextChanged"));
                        this.contentEditor.add(selectionEditor);
                    }
                }
                refreshSelectionDatas(){
                    let selectionCount = 0;
                    for (let selectionData of this.selectionDatas){
                        selectionData.order = selectionCount;
                        selectionCount++;
                    }
                }
                onTitleTextChanged(sender, args){ this.fieldInfo.i$assign("iFieldName", this.titleTextBox.text); }
                async onSelectionAddButtonClick(sender, args){
                    let selectionEditor = $byForm.object.SelectionEditor.$convert(sender);
                    let newSelectionData = new $byForm.object.SelectionData().$init($ => {
                        $.$0();
                        $.text = "";
                        $.defaultText = "选项" + Byt.String(this.getNextSelectionCount().by$toString());
                        $.order = ((selectionEditor.data.order + 1) | 0);
                    });
                    this.selectionDatas.insert(((selectionEditor.data.order + 1) | 0), newSelectionData);
                    this.refreshSelectionDatas();
                    await this.buildSelectionItems();
                    $byForm.object.FieldControlEditor.selectionGrowOnlyCount++;
                    await this.addButtonClick.$invoke(this, args);
                }
                async onSelectionDelButtonClick(sender, args){
                    this.selectionDatas.removeAt(($byForm.object.SelectionEditor.$convert(sender)).data.order);
                    this.refreshSelectionDatas();
                    await this.buildSelectionItems();
                }
                async onSelectionTextChanged(sender, args){
                    this.selectionDatas.$get(($byForm.object.SelectionEditor.$convert(sender)).data.order).text = await ($byForm.object.SelectionEditor.$convert(sender)).getText();
                    await this.refreshFieldInfo();
                }
                static $0(){ this.selectionGrowOnlyCount = 2; }
                static async getEditor(fieldInfo){
                    switch(fieldInfo.i$access("iFieldCtrl")){
                        case "textbox":
                            return new $byForm.object.FieldTextBoxEditor().$init($ => $.$1(fieldInfo));
                        case "checkBox":
                            return await new $byForm.object.FieldCheckBoxEditor().$init($ => $.$1(fieldInfo));
                        case "radbutton":
                            return await new $byForm.object.FieldRadioButtonGroupEditor().$init($ => $.$1(fieldInfo));
                        case "checkBoxList":
                            return await new $byForm.object.FieldCheckBoxListEditor().$init($ => $.$1(fieldInfo));
                        case "dropdownList":
                            return await new $byForm.object.FieldComboBoxEditor().$init($ => $.$1(fieldInfo));
                        case "muiltTextbox":
                            return new $byForm.object.FieldMultiTextBoxEditor().$init($ => $.$1(fieldInfo));
                        case "slider":
                            return new $byForm.object.FieldSliderEditor().$init($ => $.$1(fieldInfo));
                        case "datePicker":
                        case "timePicker":
                        case "dateTimePicker":
                            return new $byForm.object.FieldDateTimePickerEditor().$init($ => $.$1(fieldInfo));
                        default:
                            throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                    }
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { titleEditor: $by.object.Panel, contentEditor: $by.object.Panel, propertyEditor: $by.object.Panel, contentOperateEditor: $by.object.Panel, saveEditor: $by.object.Panel, fieldInfo: Byt.Row, selections: [ Byt.Array, Byt.String ], selectionDatas: [ "by.object.List", "byForm.object.SelectionData" ], titleTextBox: $by.object.TextBox, addButton: $by.object.Button, saveButton: $by.object.Button, closeButton: $by.object.Button, messageLabel: $by.object.Label, isModified: Byt.Bool, fieldNotNullPanel: $by.object.Panel, fieldNotNullCheckBox: $by.object.CheckBox, fieldMaxPanel: "byForm.object.PropertyNumberBox", fieldMinPanel: "byForm.object.PropertyNumberBox", fieldRegPanel: "byForm.object.PropertyInputBox", fieldRegMsgPanel: "byForm.object.PropertyInputBox" }, events: [ "addButtonClick", "saveButtonClick", "cancelButtonClick" ] },
            static: { props: { selectionGrowOnlyCount: Byt.Int } }
        },
        FieldComboBoxEditor: {
            type: class FieldComboBoxEditor extends Byt.Object {
                async $1(fieldInfo){
                    super.$1(fieldInfo);
                    this.readSelections(fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n")));
                    await this.buildSelectionItems();
                }
            },
            base: { inherit: "byForm.object.FieldControlEditor" }
        },
        FieldControl: {
            type: class FieldControl extends Byt.Object {
                $1(row){
                    this.titlePanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.orderLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.titleLabel = new $by.object.Label();
                    this.notNullLabel = new $by.object.Label().$init($ => {
                        $.hasBorder = false;
                        $.text = "*";
                        $.foreColor = $by.object.Color.RED;
                    });
                    this.summaryPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.summaryLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.contentPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.fieldPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.messageLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.isLegal = false;
                    this.fieldRow = row;
                    this.add(this.titlePanel);
                    this.add(this.contentPanel);
                    this.titlePanel.add(this.orderLabel);
                    this.titlePanel.add(this.titleLabel);
                    this.titlePanel.add(this.notNullLabel);
                    this.contentPanel.add(this.fieldPanel);
                    this.hasBorder = false;
                    {
                        this.titlePanel.element.addClass($byForm.object.CssClassNameHelper.publishFieldTitlePanel);
                        this.orderLabel.element.addClass($byForm.object.CssClassNameHelper.publishFieldOrderLabel);
                        this.titleLabel.element.addClass($byForm.object.CssClassNameHelper.publishFieldTitleLabel);
                        this.notNullLabel.element.addClass($byForm.object.CssClassNameHelper.publishFieldNotNullLabel);
                        this.summaryPanel.element.addClass($byForm.object.CssClassNameHelper.publishFieldSummaryPanel);
                        this.summaryLabel.element.addClass($byForm.object.CssClassNameHelper.publishFieldSummaryLabel);
                        this.contentPanel.element.addClass($byForm.object.CssClassNameHelper.publishFieldContentPanel);
                        this.fieldPanel.element.addClass($byForm.object.CssClassNameHelper.publishFieldFieldPanel);
                        this.messageLabel.element.addClass($byForm.object.CssClassNameHelper.publishFieldMessageLabel);
                        if(this.fieldRow.i$access("iNotNull")){ this.titleLabel.element.addClass($byForm.object.CssClassNameHelper.publishFieldNotNull); }
                    }
                    this.titleLabel.text = row.i$access("iFieldName");
                    this.titleLabel.toolTip = row.i$access("iSummary");
                    this.notNullLabel.text = this.fieldRow.i$access("iNotNull") ? "*" : "";
                    this.setOrder((($by.object.Int.parse(row.i$access("iFieldNO")) + 1) | 0));
                    this.paddingTop = 10;
                    this.paddingBottom = 10;
                    this.hasBorder = false;
                }
                clearMessage(){
                    this.messageLabel.text = "";
                    this.messageLabel.remove();
                }
                setMessage(msg, color){
                    this.clearMessage();
                    if(msg == null || msg == ""){ return; }
                    this.messageLabel.text = msg;
                    this.messageLabel.foreColor = color;
                    this.contentPanel.add(this.messageLabel);
                }
                setMessage$1(msg){ this.setMessage(msg, $by.object.Color.RED); }
                getMessage(){ return this.messageLabel.text; }
                setOrder(order){ this.orderLabel.text = Byt.String(order.by$toString()) + "."; }
                verify(){ return new $by.object.Result().$init($ => { $.isOk = true; }); }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { titlePanel: $by.object.Panel, orderLabel: $by.object.Label, titleLabel: $by.object.Label, notNullLabel: $by.object.Label, summaryPanel: $by.object.Panel, summaryLabel: $by.object.Label, contentPanel: $by.object.Panel, fieldPanel: $by.object.Panel, messageLabel: $by.object.Label, fieldRow: Byt.Row, isLegal: Byt.Bool } }
        },
        FieldDateTimePicker: {
            type: class FieldDateTimePicker extends Byt.Object {
                $1(row){
                    super.$1(row);
                    this.dateTimePicker = new $by.object.DateTimePicker();
                    this.fieldPanel.add(this.dateTimePicker);
                    $byForm.object.Common.setDateTimePickerMode(this.dateTimePicker, row.i$access("iFieldCtrl"));
                    this.dateTimePicker.valueChanged.$add((sender, args) => { this.verify(); });
                }
                getValue(){
                    let value = this.dateTimePicker.value;
                    let datetimeSplit = value.by$toString().by$split(Byt.Char(" "));
                    if(this.fieldRow.i$access("iFieldCtrl") == "datePicker"){ return datetimeSplit[0]; }
                    else if(this.fieldRow.i$access("iFieldCtrl") == "timePicker"){ return datetimeSplit[1]; }
                    else { return value.by$toString(); }
                }
                verifyEmpty(){
                    if(this.fieldRow.i$access("iNotNull") && Byt.DateTime.by$equals(this.dateTimePicker.value, null)){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = "此项为必填项";
                    }); }
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                verify(){
                    let result = this.verifyEmpty();
                    this.setMessage$1(result.info);
                    return result;
                }
            },
            base: { inherit: "byForm.object.FieldControl" },
            instance: { props: { dateTimePicker: $by.object.DateTimePicker } }
        },
        PropertyComboBox: {
            type: class PropertyComboBox extends Byt.Object {
                $1(proeprtyName){
                    this.propertyLabel = new $by.object.Label();
                    this.propertyComboBox = new $by.object.ComboBox();
                    {
                        this.propertyLabel.webWidthFilled = true;
                        this.propertyComboBox.webWidthFilled = true;
                    }
                    this.scrollable = false;
                    this.add(this.propertyLabel);
                    this.add(this.propertyComboBox);
                    this.propertyLabel.text = proeprtyName;
                    this.propertyComboBox.selectionChanged.$add(async (sender, args) => { await this.propertyComboChanged.$invoke(this, args); });
                }
                addOption(option){ this.propertyComboBox.add(option); }
                setOptions(options){
                    this.propertyComboBox.clear();
                    for (let op of options){ this.addOption(op); }
                }
                setCountOption(optionCount){
                    let selection = this.propertyComboBox.selectedItem;
                    this.propertyComboBox.clear();
                    this.propertyComboBox.add($byForm.object.NameHelper.unlimit);
                    for (let i = 1; i <= optionCount; i++){ this.propertyComboBox.add(i.by$toString()); }
                    this.propertyComboBox.selectedItem = selection;
                }
                getSelection(){ return this.propertyComboBox.selectedItem.by$toString(); }
                setSelection(selection){
                    try{ this.propertyComboBox.selectedItem = selection; }
                    catch(e$){
                        if($by.object.Exception.$check(e$)){
                            let e = $by.object.Exception.$convert(e$);
                            throw Error(new $by.object.Exception("未添加的下拉框选项" + Byt.String(e.message)));
                        }
                    }
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { propertyLabel: $by.object.Label, propertyComboBox: $by.object.ComboBox }, events: [ "propertyComboChanged" ] }
        },
        PropertyInputBox: {
            type: class PropertyInputBox extends Byt.Object {
                $1(propertyName){
                    this.propertyLabel = new $by.object.Label();
                    this.propertyBox = new $by.object.TextBox();
                    {
                        this.webWidthFilled = true;
                        this.propertyLabel.webWidthFilled = true;
                        this.propertyBox.webWidthFilled = true;
                    }
                    this.scrollable = false;
                    this.setName(propertyName);
                    this.add(this.propertyLabel);
                    this.add(this.propertyBox);
                    this.propertyBox.textChanged.$add(async (sender, args) => { await this.propertyTextChanged.$invoke(this, args); });
                }
                setName(propertyName){ this.propertyLabel.text = propertyName; }
                getName(){ return this.propertyLabel.text; }
                setText(value){ this.propertyBox.text = value; }
                getText(){
                    { return $byForm.object.Common.isEmptyString(this.propertyBox.text) ? this.getPlaceHolderText() : this.propertyBox.text; }
                    
                }
                async setPlaceHolderText(value){
                    let inputElement = this.propertyBox.element.children[0];
                    if(inputElement == null || inputElement.tagName.by$toLower() != $byForm.object.NameHelper.placeHolderTag){
                        await $by.object.Message.alert("当前输入框子成员不存在input标签" + Byt.String(inputElement.tagName));
                        return;
                    }
                    inputElement.addAttribute($byForm.object.NameHelper.placeholderAttributeName, value);
                }
                getPlaceHolderText(){
                    let inputElement = this.propertyBox.element.children[0];
                    if(inputElement == null || inputElement.tagName.by$toLower() != $byForm.object.NameHelper.placeHolderTag){ return ""; }
                    let placeHolderText = inputElement.getAttribute($byForm.object.NameHelper.placeholderAttributeName);
                    return placeHolderText == null ? "" : placeHolderText;
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { propertyLabel: $by.object.Label, propertyBox: $by.object.TextBox }, events: [ "propertyTextChanged" ] }
        },
        PropertyMultilineInputBox: {
            type: class PropertyMultilineInputBox extends Byt.Object {
                $1(propertyName){
                    super.$1(propertyName);
                    this.propertyBox.isMultiLine = true;
                    this.propertyBox.width = $byForm.object.ValueHelper.multiTextboxWidth;
                    this.propertyBox.height = $byForm.object.ValueHelper.multiTextboxHeight;
                    {
                        try{ this.propertyBox.element.children[1].style.setProperty("width", "100%"); }
                        catch(e$){
                            if($by.object.Exception.$check(e$)){
                                let e = $by.object.Exception.$convert(e$);
                            }
                        }
                    }
                }
                setBoxWidth(width){ this.propertyBox.width = width; }
                setBoxHeight(height){ this.propertyBox.height = height; }
            },
            base: { inherit: "byForm.object.PropertyInputBox" }
        },
        TextHelper: {
            type: class TextHelper extends Byt.Object {
                static $0(){
                    this.invalidFieldTemplateID = "错误的字段模板ID";
                    this.invalidFieldID = "错误的字段ID";
                    this.misssingListData = "无效数据，列表中没有数据！";
                    this.illegalInjection = "非法注入，不支持的表源身份行！";
                    this.unexpectedControl = "未定义的控件类型";
                    this.formTemplateNotFound = "未找到对应的表单模板";
                    this.formNotFound = "未找到对应表单";
                    this.illegalMaxCount = "要求最多选中数量不合法";
                    this.sliderMinMaxCountError = "滑块最大值应当大于最小值";
                    this.fieldMinMaxCountError = "最大长度应当大于最小长度";
                    this.negativeMinMaxError = "最小长度和最大长度应当大于等于零";
                    this.dataLengthMaxError = "文本最大长度错误，允许的最大长度为";
                    this.lengthMaxError = "长度不能超过";
                    this.invalidValueError = "无效的值!";
                    this.formIdLoss = "缺少formid,请检查链接是否正确";
                    this.formIdError = "请检查参数formID是否正确";
                    this.unsupportedChart = "字段类型与图表类型不匹配 或 尚未支持的图表/字段类型";
                    this.formUserLoss = "用户未登录或身份验证失败";
                    this.stasticsFieldLess = "当前表单缺少字段,无法统计";
                    this.formOutdateError = "未知(由于表单版本过时)";
                    this.sheetSubmittedLoss = "不存在的信息，这条信息可能已经被删除！";
                    this.labelEventError = "错误的标签事件绑定";
                    this.templateLabelRowLossError = "标签控件未绑定到字段模板数据行";
                    this.fieldCreatedLossError = "拖拽生成的字段信息为空";
                    this.restored = "已恢复到修改前";
                    this.saveSuccess = "保存成功!";
                    this.saveFail = "保存失败!";
                    this.remainError = "存在未解决的错误:";
                    this.saveFormFailed = "保存表单信息错误!";
                    this.emptyFieldPanel = "字段面板为空";
                    this.unexpectedControlInFieldPanel = "字段面板中存在未预料的控件类型，预期类型：FieldTermPanel";
                    this.notLoggedIn = "当前用户还没有登录！";
                    this.pleaseLogIn = "请先登录!";
                    this.insufficientPermissions = "当前用户权限不足";
                    this.formNameNull = "表单名称不能为空";
                    this.previewOnly = "此页面仅供预览,无法提交!";
                    this.defaultSubmitSuccessMessage = "谢谢,我们会尽快处理！";
                    this.defaultSubmitButtonText = "确认提交";
                    this.edit = "编辑";
                    this.delete = "删除";
                    this.add = "增加";
                    this.save = "保存";
                    this.notSave = "不保存";
                    this.cancel = "取消";
                    this.close = "关闭";
                    this.publish = "发布";
                    this.viewResult = "查看答卷";
                    this.statisticsResult = "统计结果";
                    this.statisticsResultTip = "统计并展示图表";
                    this.appendChart = "增加字段";
                    this.appendChartTip = "在当前统计图表增加新的字段项组成复合图表";
                    this.deleteChartContainer = "删除图表";
                    this.createChart = "创建新图表";
                    this.createChartTip = "创建一个新的空白图表";
                    this.exit = "退出";
                    this.queryDeleteField = "检查到已在编辑区打开，请选择是否删除?";
                    this.querySave = "可能有未保存的修改,请问是否保存?";
                    this.formSaveSuccessMessage = "保存成功，请问是否退出当前表单编辑界面?";
                    this.queryDeleteForm = "您确认删除问卷\"{0}\"吗？";
                    this.notNull = "必填";
                    this.sliderMax = "最大值";
                    this.sliderMin = "最小值";
                    this.sliderDelta = "间隔";
                    this.checkMin = "最少选择数";
                    this.checkMax = "最多选择数";
                    this.fieldMax = "最大长度";
                    this.fieldMin = "最小长度";
                    this.valueMax = "最大值";
                    this.valueMin = "最小值";
                    this.fieldRegex = "正则验证表达式";
                    this.fieldRegexMessage = "正则验证消息";
                    this.optionName = "选项名称";
                    this.formName = "表单名称";
                    this.formSummary = "表单说明";
                    this.successMessage = "保存成功的信息提示";
                    this.submitButtonText = "提交按钮的文本";
                    this.defaultFormName = "新建未命名表单";
                    this.defaultFormSummary = "";
                    this.fieldName = "字段名称";
                    this.formListLabelText = "表单列表";
                    this.createFormButtonText = "新建表单";
                    this.summary = "说明";
                    this.createButtonText = "创建";
                    this.saveForm = "保存到表单";
                    this.preview = "预览";
                    this.saasInfo = "saas服务调用代码";
                    this.saasSample = "saas服务调用示例";
                    this.defaultCheckItem = "判断项";
                    this.defaultCheckItemOne = "选项1";
                    this.defaultCheckItemTwo = "选项2";
                    this.defaultSelectValues = Byt.String($byForm.object.TextHelper.defaultCheckItemOne) + "\n" + Byt.String($byForm.object.TextHelper.defaultCheckItemTwo);
                    this.defaultSliderSelectValue = "0\n10\n1";
                    this.defaultTextboxText = "";
                    this.formNameEditTip = "点击可编辑";
                    this.draggableTip = "可拖动当前元素到中间区域";
                    this.saasDivTip = "本div如果存在则会把生成表单放入其中，本项可以没有";
                }
            },
            transmit: [ ],
            static: { props: { invalidFieldTemplateID: Byt.String, invalidFieldID: Byt.String, misssingListData: Byt.String, illegalInjection: Byt.String, unexpectedControl: Byt.String, formTemplateNotFound: Byt.String, formNotFound: Byt.String, illegalMaxCount: Byt.String, sliderMinMaxCountError: Byt.String, fieldMinMaxCountError: Byt.String, negativeMinMaxError: Byt.String, dataLengthMaxError: Byt.String, lengthMaxError: Byt.String, invalidValueError: Byt.String, formIdLoss: Byt.String, formIdError: Byt.String, unsupportedChart: Byt.String, formUserLoss: Byt.String, stasticsFieldLess: Byt.String, formOutdateError: Byt.String, sheetSubmittedLoss: Byt.String, labelEventError: Byt.String, templateLabelRowLossError: Byt.String, fieldCreatedLossError: Byt.String, restored: Byt.String, saveSuccess: Byt.String, saveFail: Byt.String, remainError: Byt.String, saveFormFailed: Byt.String, emptyFieldPanel: Byt.String, unexpectedControlInFieldPanel: Byt.String, notLoggedIn: Byt.String, pleaseLogIn: Byt.String, insufficientPermissions: Byt.String, formNameNull: Byt.String, previewOnly: Byt.String, defaultSubmitSuccessMessage: Byt.String, defaultSubmitButtonText: Byt.String, edit: Byt.String, delete: Byt.String, add: Byt.String, save: Byt.String, notSave: Byt.String, cancel: Byt.String, close: Byt.String, publish: Byt.String, viewResult: Byt.String, statisticsResult: Byt.String, statisticsResultTip: Byt.String, appendChart: Byt.String, appendChartTip: Byt.String, deleteChartContainer: Byt.String, createChart: Byt.String, createChartTip: Byt.String, exit: Byt.String, queryDeleteField: Byt.String, querySave: Byt.String, formSaveSuccessMessage: Byt.String, queryDeleteForm: Byt.String, notNull: Byt.String, sliderMax: Byt.String, sliderMin: Byt.String, sliderDelta: Byt.String, checkMin: Byt.String, checkMax: Byt.String, fieldMax: Byt.String, fieldMin: Byt.String, valueMax: Byt.String, valueMin: Byt.String, fieldRegex: Byt.String, fieldRegexMessage: Byt.String, optionName: Byt.String, formName: Byt.String, formSummary: Byt.String, successMessage: Byt.String, submitButtonText: Byt.String, defaultFormName: Byt.String, defaultFormSummary: Byt.String, fieldName: Byt.String, formListLabelText: Byt.String, createFormButtonText: Byt.String, summary: Byt.String, createButtonText: Byt.String, saveForm: Byt.String, preview: Byt.String, saasInfo: Byt.String, saasSample: Byt.String, defaultCheckItem: Byt.String, defaultCheckItemOne: Byt.String, defaultCheckItemTwo: Byt.String, defaultSelectValues: Byt.String, defaultSliderSelectValue: Byt.String, defaultTextboxText: Byt.String, formNameEditTip: Byt.String, draggableTip: Byt.String, saasDivTip: Byt.String } }
        },
        AnalyzeConfigInfo: {
            type: class AnalyzeConfigInfo extends Byt.Object { },
            instance: { props: { fieldID: Byt.String, chartType: "byExternalChartjs.enum.chartType" } }
        },
        FieldSlider: {
            type: class FieldSlider extends Byt.Object {
                $1(row){
                    super.$1(row);
                    this.slider = new $by.object.Slider();
                    this.fieldPanel.add(this.slider);
                    let sliderProperty = row.i$access("iSelectValue").by$split(Byt.Char("\n"));
                    if(sliderProperty.length == 3){
                        this.slider.min = $by.object.Int.parse(sliderProperty[0]);
                        this.slider.max = $by.object.Int.parse(sliderProperty[1]);
                        this.slider.delta = $by.object.Int.parse(sliderProperty[2]);
                    }
                }
                getValue(){ return this.slider.value.by$toString(); }
                verify(){ return super.verify(); }
            },
            base: { inherit: "byForm.object.FieldControl" },
            instance: { props: { slider: $by.object.Slider } }
        },
        FieldComboBox: {
            type: class FieldComboBox extends Byt.Object {
                $1(row){
                    super.$1(row);
                    this.comboBox = new $by.object.ComboBox();
                    this.fieldPanel.add(this.comboBox);
                    for (let selectValue of row.i$access("iSelectValue").by$split(Byt.Char("\n"))){ this.comboBox.add(selectValue); }
                }
                getValue(){
                    if(this.comboBox.selectedItem == null){ return null; }
                    return this.comboBox.selectedItem.by$toString();
                }
                verifyEmpty(){
                    if(this.fieldRow.i$access("iNotNull") && this.comboBox.selectedIndex == -1){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = "此项未必填项";
                    }); }
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                verify(){ return this.verifyEmpty(); }
            },
            base: { inherit: "byForm.object.FieldControl" },
            instance: { props: { comboBox: $by.object.ComboBox } }
        },
        FieldSliderEditor: {
            type: class FieldSliderEditor extends Byt.Object {
                $1(fieldInfo){
                    super.$1(fieldInfo);
                    this.fieldSliderMaxPanel = new $byForm.object.PropertyNumberBox().$init($ => $.$1($byForm.object.TextHelper.sliderMax));
                    this.fieldSliderMinPanel = new $byForm.object.PropertyNumberBox().$init($ => $.$1($byForm.object.TextHelper.sliderMin));
                    this.fieldSliderDeltaPanel = new $byForm.object.PropertyNumberBox().$init($ => $.$1($byForm.object.TextHelper.sliderDelta));
                    this.buildSliderPropertyEditor();
                }
                buildSliderPropertyEditor(){
                    this.propertyEditor.add(this.fieldSliderMinPanel);
                    this.propertyEditor.add(this.fieldSliderMaxPanel);
                    this.propertyEditor.add(this.fieldSliderDeltaPanel);
                    let sliderProperty = this.fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n"));
                    if(sliderProperty.length == 3){
                        this.fieldSliderMinPanel.setValue(Byt.Decimal($by.object.Int.parse(sliderProperty[0])));
                        this.fieldSliderMaxPanel.setValue(Byt.Decimal($by.object.Int.parse(sliderProperty[1])));
                        this.fieldSliderDeltaPanel.setValue(Byt.Decimal($by.object.Int.parse(sliderProperty[2])));
                    }
                }
                async refreshFieldInfo(){
                    let baseResult = await super.refreshFieldInfo();
                    if(!baseResult.isOk){ return baseResult; }
                    let sliderMin = this.fieldSliderMinPanel.getValue();
                    let sliderMax = this.fieldSliderMaxPanel.getValue();
                    let sliderDelta = this.fieldSliderDeltaPanel.getValue();
                    if(Byt.Decimal[">="](sliderMin, sliderMax)){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.TextHelper.sliderMinMaxCountError;
                    }); }
                    let sliderSelectValue = Byt.String(sliderMin.by$toString()) + "\n" + Byt.String(sliderMax.by$toString()) + "\n" + Byt.String(sliderDelta.by$toString());
                    if(sliderSelectValue.length > $byForm.object.ValueHelper.selectionsLengthMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError("滑块相关数值总", $byForm.object.ValueHelper.selectionsLengthMax);
                    }); }
                    this.fieldInfo.i$assign("iSelectValue", sliderSelectValue);
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
            },
            base: { inherit: "byForm.object.FieldControlEditor" },
            instance: { props: { fieldSliderMaxPanel: "byForm.object.PropertyNumberBox", fieldSliderMinPanel: "byForm.object.PropertyNumberBox", fieldSliderDeltaPanel: "byForm.object.PropertyNumberBox" } }
        },
        ResultPanel: {
            type: class ResultPanel extends Byt.Object {
                $1(formDatas){
                    this.headPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.contentPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.headLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.hasBorder = false;
                    this.paddingTop = $byForm.object.ValueHelper.resultPanelPaddingTop;
                    this.paddingBottom = $byForm.object.ValueHelper.resultPanelPaddingBottom;
                    this.add(this.headPanel);
                    this.headPanel.add(this.headLabel);
                    this.add(this.contentPanel);
                    for (let data of formDatas){
                        let fieldResultPanel = new $byForm.object.FieldResultPanel().$init($ => $.$1(data.i$access("iFieldName"), data.i$access("iCellValue")));
                        this.contentPanel.add(fieldResultPanel);
                    }
                    {
                        this.element.addClass($byForm.object.CssClassNameHelper.resultPanel);
                        this.headPanel.element.addClass($byForm.object.CssClassNameHelper.resultHeadPanel);
                        this.headLabel.element.addClass($byForm.object.CssClassNameHelper.resultHeadLabel);
                        this.contentPanel.element.addClass($byForm.object.CssClassNameHelper.resultContentPanel);
                    }
                }
                setHeadInfo(info){ this.headLabel.text = info; }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { headPanel: $by.object.Panel, contentPanel: $by.object.Panel, headLabel: $by.object.Label } }
        },
        FieldRadioButtonGroupEditor: {
            type: class FieldRadioButtonGroupEditor extends Byt.Object {
                async $1(fieldInfo){
                    super.$1(fieldInfo);
                    this.readSelections(fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n")));
                    await this.buildSelectionItems();
                }
            },
            base: { inherit: "byForm.object.FieldControlEditor" }
        },
        FieldCheckBoxEditor: {
            type: class FieldCheckBoxEditor extends Byt.Object {
                async $1(fieldInfo){
                    super.$1(fieldInfo);
                    let selectionData = new $byForm.object.SelectionData().$init($ => {
                        $.$0();
                        $.text = fieldInfo.i$access("iSelectValue");
                        $.order = 0;
                    });
                    this.selectionDatas.add(selectionData);
                    await this.buildSelectionItems();
                }
            },
            base: { inherit: "byForm.object.FieldControlEditor" }
        },
        SelectionEditor: {
            type: class SelectionEditor extends Byt.Object {
                async $1(selectionData, isExtensible){
                    super.$0();
                    this.selectionLabel = new $by.object.Label().$init($ => { $.text = $byForm.object.TextHelper.optionName; });
                    this.selectionValueBox = new $by.object.TextBox();
                    this.addButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.add; });
                    this.delButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.delete; });
                    this.data = selectionData;
                    this.selectionValueBox.text = selectionData.text;
                    this.add(this.selectionLabel);
                    this.add(this.selectionValueBox);
                    if(isExtensible){
                        this.add(this.addButton);
                        this.add(this.delButton);
                    }
                    {
                        await this.setPlaceHolderText(selectionData.defaultText);
                        this.selectionLabel.element.addClass($byForm.object.CssClassNameHelper.generalDetailSelectionLabel);
                        this.selectionValueBox.element.addClass($byForm.object.CssClassNameHelper.generalDetailSelectionValueBox);
                        this.addButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSelectionAddButton);
                        this.delButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSelectionDelButton);
                    }
                    this.addButton.click.$add(async (sender, args) => { await this.addButtonClick.$invoke(this, args); });
                    this.delButton.click.$add(async (sender, args) => { await this.delButtonClick.$invoke(this, args); });
                    this.selectionValueBox.textChanged.$add(async (sender, args) => { await this.textBoxTextChanged.$invoke(this, args); });
                }
                async getText(){
                    { return $byForm.object.Common.isEmptyString(this.selectionValueBox.text) ? await this.getPlaceHolderText() : this.selectionValueBox.text; }
                    
                }
                async setPlaceHolderText(value){
                    let inputElement = this.selectionValueBox.element.children[0];
                    if(inputElement == null || inputElement.tagName.by$toLower() != $byForm.object.NameHelper.placeHolderTag){
                        await $by.object.Message.alert("当前输入框子成员不存在input标签" + Byt.String(inputElement.tagName));
                        return;
                    }
                    inputElement.addAttribute($byForm.object.NameHelper.placeholderAttributeName, value);
                }
                async getPlaceHolderText(){
                    let inputElement = this.selectionValueBox.element.children[0];
                    if(inputElement == null || inputElement.tagName.by$toLower() != $byForm.object.NameHelper.placeHolderTag){
                        await $by.object.Message.alert("当前输入框子成员不存在input标签" + Byt.String(inputElement.tagName));
                        return "";
                    }
                    let placeHolderText = inputElement.getAttribute($byForm.object.NameHelper.placeholderAttributeName);
                    return placeHolderText == null ? "" : placeHolderText;
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { selectionLabel: $by.object.Label, selectionValueBox: $by.object.TextBox, addButton: $by.object.Button, delButton: $by.object.Button, data: "byForm.object.SelectionData" }, events: [ "addButtonClick", "delButtonClick", "textBoxTextChanged" ] }
        },
        FieldTextBoxEditor: {
            type: class FieldTextBoxEditor extends Byt.Object {
                $1(fieldInfo){
                    super.$1(fieldInfo);
                    this.buildTextPropertyEditor();
                }
                async refreshFieldInfo(){
                    let baseResult = await super.refreshFieldInfo();
                    if(!baseResult.isOk){ return baseResult; }
                    let fieldMin = Byt.Int(this.fieldMinPanel.getValue());
                    let fieldMax = Byt.Int(this.fieldMaxPanel.getValue());
                    if(fieldMin > fieldMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.TextHelper.fieldMinMaxCountError;
                    }); }
                    if(fieldMin < 0 || fieldMax < 0){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.TextHelper.negativeMinMaxError;
                    }); }
                    if(this.fieldInfo.i$access("iFieldType") == "string" && fieldMax > $byForm.object.ValueHelper.formDataCellMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = Byt.String($byForm.object.TextHelper.dataLengthMaxError) + Byt.String($byForm.object.ValueHelper.formDataCellMax.by$toString());
                    }); }
                    if(this.fieldRegPanel.getText().length > $byForm.object.ValueHelper.generalTextMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError(this.fieldRegPanel.getName(), $byForm.object.ValueHelper.generalTextMax);
                    }); }
                    if(this.fieldRegMsgPanel.getText().length > $byForm.object.ValueHelper.generalTextMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError(this.fieldRegMsgPanel.getName(), $byForm.object.ValueHelper.generalTextMax);
                    }); }
                    this.fieldInfo.i$assign("iFieldMin", fieldMin);
                    this.fieldInfo.i$assign("iFieldMax", fieldMax);
                    this.fieldInfo.i$assign("iFieldReg", this.fieldRegPanel.getText());
                    this.fieldInfo.i$assign("iFieldRegMsg", this.fieldRegMsgPanel.getText());
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
            },
            base: { inherit: "byForm.object.FieldControlEditor" }
        },
        CssClassNameHelper: {
            type: class CssClassNameHelper extends Byt.Object {
                static $0(){
                    this.formManageDialog = "form-manage-dialog";
                    this.formNamePanel = "form-name-Panel";
                    this.formNameValueLabel = "form-name-valueLabel";
                    this.formPanel = "form-panel";
                    this.formManagePanel = "form-manage-panel";
                    this.formButtonContainer = "form-button-container";
                    this.formFieldContainer = "form-field-contianer";
                    this.formFieldDetailContainer = "form-fieldDetail-container";
                    this.formManageNameValueLabel = "form-manage-name-value-label";
                    this.formManageSummaryValueLabel = "form-manage-summary-value-label";
                    this.formManageButtonContainer = "form-manage-button-container";
                    this.formPreviewButton = "form-previewButton";
                    this.formPublishButton = "form-publishButton";
                    this.formFieldTemplateContainer = "form-fieldTemplate-container";
                    this.generalFieldTemplateLabel = "general-field-template-label";
                    this.generalFieldTemplateInnerLabel = "general-field-template-inner-label";
                    this.queryDialog = "query-dialog";
                    this.querySaveTextLabel = "query-save-textLabel";
                    this.querySaveNotSaveButton = "query-save-notSaveButton";
                    this.queryDeleteTextLabel = "query-delete-textLabel";
                    this.queryDeleteButtonContainer = "query-delete-buttonContainer";
                    this.generalFieldPanel = "general-field-panel";
                    this.generalFieldOrderLabel = "general-field-orderLabel";
                    this.generalFieldTitleLabel = "general-field-titleLabel";
                    this.generalFieldDisplayArea = "general-field-displayArea";
                    this.generalFieldEditArea = "general-field-editArea";
                    this.generalFieldCoreControl = "general-field-coreControl";
                    this.generalFieldEditButton = "general-field-editButton";
                    this.generalFieldDeleteButton = "general-field-deleteButton";
                    this.generalDetail = "general-detail";
                    this.generalDetailTitleEditor = "general-detail-titleEditor";
                    this.generalDetailTitleTextBox = "general-detail-titleTextBox";
                    this.generalDetailContentEditor = "general-detail-contentEditor";
                    this.generalDetailContentOperateEditor = "general-detail-contentOperateEditor";
                    this.generalDetailSaveButton = "general-detail-saveButton";
                    this.generalDetailCancelButton = "general-detail-cancelButton";
                    this.generalDetailAddButton = "general-detail-addButton";
                    this.generalDetailSelectionLabel = "general-detail-selection-label";
                    this.generalDetailSelectionValueBox = "general-detail-selection-valueBox";
                    this.generalDetailSelectionAddButton = "general-detail-selection-addButton";
                    this.generalDetailSelectionDelButton = "general-detail-selection-delButton";
                    this.formsManagerOperateArea = "forms-operateArea";
                    this.formsManagerDisplayArea = "forms-displayArea";
                    this.formsManagerHeadMenuBar = "forms-head-menuBar";
                    this.formsManagerFormsHeader = "forms-list-header";
                    this.formsManagerFormListLabel = "forms-list-label";
                    this.formsManagerFormListPanel = "forms-list-panel";
                    this.formsManagerCreateFormButton = "forms-add-form-button";
                    this.formItemInfoArea = "form-item-infoArea";
                    this.formItemOperateArea = "form-item-operateArea";
                    this.formItemIDLabel = "form-item-id-valueLabel";
                    this.formItemNameLabel = "form-item-name-valueLabel";
                    this.formItemStatePanel = "form-item-statePanel";
                    this.formItemCreateDateLabel = "form-item-dateLabel";
                    this.formItemEditButton = "form-item-editButton";
                    this.formItemSendButton = "form-item-sendButton";
                    this.formItemDeleteButton = "form-item-deleteButton";
                    this.formItemViewResultButton = "form-item-viewResultButton";
                    this.formItemStatisticsButton = "form-item-statisticsButton";
                    this.formCreateDialog = "form-create-dialog";
                    this.formCreateHeadPanel = "form-create-headPanel";
                    this.formCreateBodyPanel = "form-create-bodyPanel";
                    this.formCreateContentPanel = "form-create-contentPanel";
                    this.formCreateOperatePanel = "form-create-operatePanel";
                    this.formCreateNamePanel = "form-create-namePanel";
                    this.formCreateNameLabel = "form-create-nameLabel";
                    this.formCreateNameBox = "form-create-nameBox";
                    this.formCreateSummaryPanel = "form-create-summaryPanel";
                    this.formCreateSummaryLabel = "form-create-summaryLabel";
                    this.formCreateSummaryBox = "form-create-summaryBox";
                    this.publishFormPanel = "publish-form-panel";
                    this.publishFormHeadPanel = "publish-form-headPanel";
                    this.publishFormNamePanel = "publish-form-namePanel";
                    this.publishFormSummaryPanel = "publish-form-summaryPanel";
                    this.publishFormSummaryPanelInner = "publish-form-summaryPanel-inner";
                    this.publishFormSummaryLabelInner = "publish-form-summaryLabel-inner";
                    this.publishFormContentPanel = "publish-form-contentPanel";
                    this.publishFormOperatePanel = "publish-form-operatePanel";
                    this.publishFormNameLabel = "publish-form-nameLabel";
                    this.publishFormSummaryLabel = "publish-form-summaryLabel";
                    this.publishFormSubmitButton = "publish-form-submitButton";
                    this.publishFormCancelButton = "publish-form-cancelButton";
                    this.publishFieldTitlePanel = "publish-field-titlePanel";
                    this.publishFieldOrderLabel = "publish-field-orderLabel";
                    this.publishFieldTitleLabel = "publish-field-titleLabel";
                    this.publishFieldNotNullLabel = "publish-field-notNullLabel";
                    this.publishFieldSummaryPanel = "publish-field-summaryPanel";
                    this.publishFieldSummaryLabel = "publish-field-summaryLabel";
                    this.publishFieldContentPanel = "publish-field-contentPanel";
                    this.publishFieldFieldPanel = "publish-field-fieldPanel";
                    this.publishFieldMessageLabel = "publish-field-messageLabel";
                    this.publishFieldNotNull = "publish-field-not-null";
                    this.resultsPanel = "results-panel";
                    this.resultsHeadPanel = "results-head-panel";
                    this.resultsContentPanel = "results-content-panel";
                    this.resultsTitleLabel = "results-title-label";
                    this.resultsSummaryLabel = "results-summary-label";
                    this.resultPanel = "result-panel";
                    this.resultHeadPanel = "result-head-panel";
                    this.resultHeadLabel = "result-head-label";
                    this.resultContentPanel = "result-content-panel";
                    this.resultFieldPanel = "result-field-panel";
                    this.resultFieldNameLabel = "result-field-nameLabel";
                    this.resultFieldValueLabel = "result-field-valueLabel";
                    this.analyzeFieldSelector = "analyzer-fieldSelector";
                    this.analyzerChartSelector = "analyzer-ChartSelector";
                    this.analyzerChartCreateButton = "analyzer-chart-createButton";
                    this.analyzerFieldButtonContainer = "analyzer-field-buttonContainer";
                    this.analyzerFieldAddButton = "analyzer-field-addButton";
                    this.analyzerFieldDisplayButton = "analyzer-field-displayButton";
                    this.analyzerFieldDeleteButton = "analyzer-field-deleteButton";
                    this.analzyerFormInfoArea = "analyzer-form-infoArea";
                    this.analyzerChartContainer = "analyzer-chart-container";
                    this.analyzerChartCanvas = "analyzer-chart-canvas";
                    this.indexUserMenuBar = "index-user-MenuBar";
                }
            },
            transmit: [ ],
            static: { props: { formManageDialog: Byt.String, formNamePanel: Byt.String, formNameValueLabel: Byt.String, formPanel: Byt.String, formManagePanel: Byt.String, formButtonContainer: Byt.String, formFieldContainer: Byt.String, formFieldDetailContainer: Byt.String, formManageNameValueLabel: Byt.String, formManageSummaryValueLabel: Byt.String, formManageButtonContainer: Byt.String, formPreviewButton: Byt.String, formPublishButton: Byt.String, formFieldTemplateContainer: Byt.String, generalFieldTemplateLabel: Byt.String, generalFieldTemplateInnerLabel: Byt.String, queryDialog: Byt.String, querySaveTextLabel: Byt.String, querySaveNotSaveButton: Byt.String, queryDeleteTextLabel: Byt.String, queryDeleteButtonContainer: Byt.String, generalFieldPanel: Byt.String, generalFieldOrderLabel: Byt.String, generalFieldTitleLabel: Byt.String, generalFieldDisplayArea: Byt.String, generalFieldEditArea: Byt.String, generalFieldCoreControl: Byt.String, generalFieldEditButton: Byt.String, generalFieldDeleteButton: Byt.String, generalDetail: Byt.String, generalDetailTitleEditor: Byt.String, generalDetailTitleTextBox: Byt.String, generalDetailContentEditor: Byt.String, generalDetailContentOperateEditor: Byt.String, generalDetailSaveButton: Byt.String, generalDetailCancelButton: Byt.String, generalDetailAddButton: Byt.String, generalDetailSelectionLabel: Byt.String, generalDetailSelectionValueBox: Byt.String, generalDetailSelectionAddButton: Byt.String, generalDetailSelectionDelButton: Byt.String, formsManagerOperateArea: Byt.String, formsManagerDisplayArea: Byt.String, formsManagerHeadMenuBar: Byt.String, formsManagerFormsHeader: Byt.String, formsManagerFormListLabel: Byt.String, formsManagerFormListPanel: Byt.String, formsManagerCreateFormButton: Byt.String, formItemInfoArea: Byt.String, formItemOperateArea: Byt.String, formItemIDLabel: Byt.String, formItemNameLabel: Byt.String, formItemStatePanel: Byt.String, formItemCreateDateLabel: Byt.String, formItemEditButton: Byt.String, formItemSendButton: Byt.String, formItemDeleteButton: Byt.String, formItemViewResultButton: Byt.String, formItemStatisticsButton: Byt.String, formCreateDialog: Byt.String, formCreateHeadPanel: Byt.String, formCreateBodyPanel: Byt.String, formCreateContentPanel: Byt.String, formCreateOperatePanel: Byt.String, formCreateNamePanel: Byt.String, formCreateNameLabel: Byt.String, formCreateNameBox: Byt.String, formCreateSummaryPanel: Byt.String, formCreateSummaryLabel: Byt.String, formCreateSummaryBox: Byt.String, publishFormPanel: Byt.String, publishFormHeadPanel: Byt.String, publishFormNamePanel: Byt.String, publishFormSummaryPanel: Byt.String, publishFormSummaryPanelInner: Byt.String, publishFormSummaryLabelInner: Byt.String, publishFormContentPanel: Byt.String, publishFormOperatePanel: Byt.String, publishFormNameLabel: Byt.String, publishFormSummaryLabel: Byt.String, publishFormSubmitButton: Byt.String, publishFormCancelButton: Byt.String, publishFieldTitlePanel: Byt.String, publishFieldOrderLabel: Byt.String, publishFieldTitleLabel: Byt.String, publishFieldNotNullLabel: Byt.String, publishFieldSummaryPanel: Byt.String, publishFieldSummaryLabel: Byt.String, publishFieldContentPanel: Byt.String, publishFieldFieldPanel: Byt.String, publishFieldMessageLabel: Byt.String, publishFieldNotNull: Byt.String, resultsPanel: Byt.String, resultsHeadPanel: Byt.String, resultsContentPanel: Byt.String, resultsTitleLabel: Byt.String, resultsSummaryLabel: Byt.String, resultPanel: Byt.String, resultHeadPanel: Byt.String, resultHeadLabel: Byt.String, resultContentPanel: Byt.String, resultFieldPanel: Byt.String, resultFieldNameLabel: Byt.String, resultFieldValueLabel: Byt.String, analyzeFieldSelector: Byt.String, analyzerChartSelector: Byt.String, analyzerChartCreateButton: Byt.String, analyzerFieldButtonContainer: Byt.String, analyzerFieldAddButton: Byt.String, analyzerFieldDisplayButton: Byt.String, analyzerFieldDeleteButton: Byt.String, analzyerFormInfoArea: Byt.String, analyzerChartContainer: Byt.String, analyzerChartCanvas: Byt.String, indexUserMenuBar: Byt.String } }
        },
        FormNameEditor: {
            type: class FormNameEditor extends Byt.Object {
                async $1(row){
                    this.formNamePanel = new $byForm.object.PropertyInputBox().$init($ => $.$1($byForm.object.TextHelper.formName));
                    this.formSummaryPanel = new $byForm.object.PropertyMultilineInputBox().$init($ => $.$1($byForm.object.TextHelper.formSummary));
                    this.formSuccessMessagePanel = new $byForm.object.PropertyInputBox().$init($ => $.$1($byForm.object.TextHelper.successMessage));
                    this.formSubmitButtonTextPanel = new $byForm.object.PropertyInputBox().$init($ => $.$1($byForm.object.TextHelper.submitButtonText));
                    this.saveEditor = new $by.object.Panel();
                    this.saveButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.save; });
                    this.cancelButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.cancel; });
                    this.formRow = row;
                    this.add(this.formNamePanel);
                    this.add(this.formSummaryPanel);
                    this.add(this.formSuccessMessagePanel);
                    this.add(this.formSubmitButtonTextPanel);
                    this.add(this.saveEditor);
                    this.saveEditor.add(this.saveButton);
                    this.saveEditor.add(this.cancelButton);
                    this.formNamePanel.setText(row.i$access("iName"));
                    this.formSummaryPanel.setText(row.i$access("iSummary"));
                    this.formSuccessMessagePanel.setText(row.i$access("iSuccessMsg"));
                    this.formSubmitButtonTextPanel.setText(row.i$access("iSubmitButton"));
                    {
                        await this.formNamePanel.setPlaceHolderText($byForm.object.TextHelper.defaultFormName);
                        await this.formSummaryPanel.setPlaceHolderText($byForm.object.TextHelper.defaultFormSummary);
                        await this.formSuccessMessagePanel.setPlaceHolderText($byForm.object.TextHelper.defaultSubmitSuccessMessage);
                        await this.formSubmitButtonTextPanel.setPlaceHolderText($byForm.object.TextHelper.defaultSubmitButtonText);
                        this.saveButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSaveButton);
                        this.cancelButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailCancelButton);
                    }
                    this.formNamePanel.propertyTextChanged.$add(async (sender, args) => { await this.formNameChange.$invoke(this, args); });
                    this.formSummaryPanel.propertyTextChanged.$add(async (sender, args) => { await this.formSummaryChange.$invoke(this, args); });
                    this.formSuccessMessagePanel.propertyTextChanged.$add(async (sender, args) => { await this.formSuccessMsgChange.$invoke(this, args); });
                    this.formSubmitButtonTextPanel.propertyTextChanged.$add(async (sender, args) => { await this.formSubmitButtonTextChange.$invoke(this, args); });
                    this.saveButton.click.$add(async (sender, args) => { await this.saveButtonClick.$invoke(this, args); });
                    this.cancelButton.click.$add(async (sender, args) => { await this.cancelButtonClick.$invoke(this, args); });
                }
                getEditFormName(){ return this.formNamePanel.getText(); }
                getEditFormSummary(){ return this.formSummaryPanel.getText(); }
                getEditFormSuccessMsg(){ return this.formSuccessMessagePanel.getText(); }
                getEditFormSubmitButtonText(){ return this.formSubmitButtonTextPanel.getText(); }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { formNamePanel: "byForm.object.PropertyInputBox", formSummaryPanel: "byForm.object.PropertyMultilineInputBox", formSuccessMessagePanel: "byForm.object.PropertyInputBox", formSubmitButtonTextPanel: "byForm.object.PropertyInputBox", saveEditor: $by.object.Panel, saveButton: $by.object.Button, cancelButton: $by.object.Button, formRow: Byt.Row }, events: [ "saveButtonClick", "cancelButtonClick", "formNameChange", "formSummaryChange", "formSuccessMsgChange", "formSubmitButtonTextChange" ] }
        },
        FieldRadioButtonGroup: {
            type: class FieldRadioButtonGroup extends Byt.Object {
                $1(row){
                    super.$1(row);
                    this.radioButtonGroup = new $by.object.RadioButtonGroup();
                    for (let selectValue of row.i$access("iSelectValue").by$split(Byt.Char("\n"))){ this.radioButtonGroup.add(new $by.object.RadioButton().$init($ => { $.text = selectValue; })); }
                    this.fieldPanel.add(this.radioButtonGroup);
                }
                getValue(){
                    if(this.radioButtonGroup.checkedButton != null){ return this.radioButtonGroup.checkedButton.text; }
                    else { return ""; }
                }
                verify(){ return super.verify(); }
            },
            base: { inherit: "byForm.object.FieldControl" },
            instance: { props: { radioButtonGroup: $by.object.RadioButtonGroup } }
        },
        FormItem: {
            type: class FormItem extends Byt.Object {
                $1(row){
                    this.infoArea = new $by.object.Panel();
                    this.operateArea = new $by.object.Panel();
                    this.idLabel = new $by.object.Label();
                    this.nameLabel = new $by.object.Label().$init($ => { $.fontSize = $byForm.object.ValueHelper.formItemNameLabelFontSize; });
                    this.statePanel = new $by.object.Panel();
                    this.createDateLabel = new $by.object.Label();
                    this.editButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.edit;
                        $.foreColor = $byForm.object.ValueHelper.grayColorForButton;
                    });
                    this.sendButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.publish;
                        $.foreColor = $byForm.object.ValueHelper.grayColorForButton;
                    });
                    this.deleteButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.delete;
                        $.foreColor = $byForm.object.ValueHelper.grayColorForButton;
                    });
                    this.viewResultButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.viewResult;
                        $.foreColor = $byForm.object.ValueHelper.grayColorForButton;
                    });
                    this.statisticsButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.statisticsResult;
                        $.foreColor = $byForm.object.ValueHelper.grayColorForButton;
                    });
                    this.nameLabel.text = row.i$access("iName");
                    this.idLabel.text = row.i$access("iID");
                    this.createDateLabel.text = Byt.DateTime.by$equals(row.i$access("iCreateDt"), null) ? $byForm.object.TextHelper.formOutdateError : row.i$access("iCreateDt").format("yyyy-MM-dd hh:mm:ss");
                    this.add(this.infoArea);
                    this.add(this.operateArea);
                    this.infoArea.add(this.nameLabel);
                    this.infoArea.add(this.statePanel);
                    this.statePanel.add(this.createDateLabel);
                    this.operateArea.add(this.editButton);
                    this.operateArea.add(this.sendButton);
                    this.operateArea.add(this.deleteButton);
                    this.operateArea.add(this.viewResultButton);
                    this.operateArea.add(this.statisticsButton);
                    this.relativeRow = row;
                    {
                        this.infoArea.element.addClass($byForm.object.CssClassNameHelper.formItemInfoArea);
                        this.operateArea.element.addClass($byForm.object.CssClassNameHelper.formItemOperateArea);
                        this.idLabel.element.addClass($byForm.object.CssClassNameHelper.formItemIDLabel);
                        this.nameLabel.element.addClass($byForm.object.CssClassNameHelper.formItemNameLabel);
                        this.statePanel.element.addClass($byForm.object.CssClassNameHelper.formItemStatePanel);
                        this.createDateLabel.element.addClass($byForm.object.CssClassNameHelper.formItemCreateDateLabel);
                        this.editButton.element.addClass($byForm.object.CssClassNameHelper.formItemEditButton);
                        this.sendButton.element.addClass($byForm.object.CssClassNameHelper.formItemSendButton);
                        this.deleteButton.element.addClass($byForm.object.CssClassNameHelper.formItemDeleteButton);
                        this.viewResultButton.element.addClass($byForm.object.CssClassNameHelper.formItemViewResultButton);
                        this.statisticsButton.element.addClass($byForm.object.CssClassNameHelper.formItemStatisticsButton);
                    }
                    this.editButton.click.$add(async (sender, args) => { await this.editButtonClick.$invoke(this, args); });
                    this.deleteButton.click.$add(async (sender, args) => { await this.delButtonClick.$invoke(this, args); });
                    this.sendButton.click.$add(async (sender, args) => { await this.sendButtonClick.$invoke(this, args); });
                    this.viewResultButton.click.$add(async (sender, args) => { await this.resultButtonClick.$invoke(this, args); });
                    this.statisticsButton.click.$add(async (sender, args) => { await this.statisticsButtonClick.$invoke(this, args); });
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { infoArea: $by.object.Panel, operateArea: $by.object.Panel, idLabel: $by.object.Label, nameLabel: $by.object.Label, statePanel: $by.object.Panel, createDateLabel: $by.object.Label, editButton: $by.object.Button, sendButton: $by.object.Button, deleteButton: $by.object.Button, viewResultButton: $by.object.Button, statisticsButton: $by.object.Button, relativeRow: Byt.Row }, events: [ "editButtonClick", "sendButtonClick", "delButtonClick", "resultButtonClick", "statisticsButtonClick" ] }
        },
        FieldCheckBoxListEditor: {
            type: class FieldCheckBoxListEditor extends Byt.Object {
                async $1(fieldInfo){
                    super.$1(fieldInfo);
                    this.fieldCheckBoxListMinPanel = new $byForm.object.PropertyComboBox().$init($ => $.$1($byForm.object.TextHelper.checkMin));
                    this.fieldCheckBoxListMaxPanel = new $byForm.object.PropertyComboBox().$init($ => $.$1($byForm.object.TextHelper.checkMax));
                    this.readSelections(fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n")));
                    await this.buildSelectionItems();
                    this.buildOptionalNumberEditor();
                }
                buildOptionalNumberEditor(){
                    this.propertyEditor.add(this.fieldCheckBoxListMinPanel);
                    this.propertyEditor.add(this.fieldCheckBoxListMaxPanel);
                    this.fieldCheckBoxListMinPanel.setCountOption(this.selectionDatas.count);
                    this.fieldCheckBoxListMaxPanel.setCountOption(this.selectionDatas.count);
                    if(this.fieldInfo.i$access("iFieldMin") < 0){ this.fieldCheckBoxListMinPanel.setSelection($byForm.object.NameHelper.unlimit); }
                    else { this.fieldCheckBoxListMinPanel.setSelection(this.fieldInfo.i$access("iFieldMin").by$toString()); }
                    if(this.fieldInfo.i$access("iFieldMax") < 0){ this.fieldCheckBoxListMaxPanel.setSelection($byForm.object.NameHelper.unlimit); }
                    else { this.fieldCheckBoxListMaxPanel.setSelection(this.fieldInfo.i$access("iFieldMax").by$toString()); }
                    this.fieldCheckBoxListMinPanel.propertyComboChanged.$add(async (sender, args) => { await this.verifyMinMaxCount(); });
                    this.fieldCheckBoxListMaxPanel.propertyComboChanged.$add(async (sender, args) => { await this.verifyMinMaxCount(); });
                    this.addButtonClick.$add((sender, args) => {
                        this.fieldCheckBoxListMaxPanel.setCountOption(this.selectionDatas.count);
                        this.fieldCheckBoxListMinPanel.setCountOption(this.selectionDatas.count);
                    });
                }
                async verifyMinMaxCount(){
                    if(this.fieldCheckBoxListMinPanel.getSelection() == $byForm.object.NameHelper.unlimit || this.fieldCheckBoxListMaxPanel.getSelection() == $byForm.object.NameHelper.unlimit){ return; }
                    let minCount = $by.object.Int.parse(this.fieldCheckBoxListMinPanel.getSelection());
                    let maxCount = $by.object.Int.parse(this.fieldCheckBoxListMaxPanel.getSelection());
                    if(minCount > maxCount){
                        await $by.object.Message.alert($byForm.object.TextHelper.illegalMaxCount);
                        this.fieldCheckBoxListMinPanel.setSelection(maxCount.by$toString());
                    }
                }
                async refreshFieldInfo(){
                    let baseResult = await super.refreshFieldInfo();
                    if(!baseResult.isOk){ return baseResult; }
                    await this.verifyMinMaxCount();
                    if(this.fieldCheckBoxListMaxPanel.getSelection() == $byForm.object.NameHelper.unlimit){ this.fieldInfo.i$assign("iFieldMax", -1); }
                    else { this.fieldInfo.i$assign("iFieldMax", $by.object.Int.parse(this.fieldCheckBoxListMaxPanel.getSelection())); }
                    if(this.fieldCheckBoxListMaxPanel.getSelection() == $byForm.object.NameHelper.unlimit){ this.fieldInfo.i$assign("iFieldMin", -1); }
                    else { this.fieldInfo.i$assign("iFieldMin", $by.object.Int.parse(this.fieldCheckBoxListMinPanel.getSelection())); }
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
            },
            base: { inherit: "byForm.object.FieldControlEditor" },
            instance: { props: { fieldCheckBoxListMinPanel: "byForm.object.PropertyComboBox", fieldCheckBoxListMaxPanel: "byForm.object.PropertyComboBox" } }
        },
        FieldResultPanel: {
            type: class FieldResultPanel extends Byt.Object {
                $1(fieldName, fieldValue){
                    this.fieldNameValueLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.fieldValueValueLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.analyzeButton = new $by.object.Button().$init($ => { $.text = "统计"; });
                    this.hasBorder = false;
                    this.fieldNameValueLabel.text = fieldName;
                    this.fieldValueValueLabel.text = fieldValue;
                    this.add(this.fieldNameValueLabel);
                    this.add(this.fieldValueValueLabel);
                    {
                        this.fieldValueValueLabel.element.children[0].style.setProperty("width", "100%");
                        this.fieldValueValueLabel.element.children[0].style.setProperty("height", "max-content");
                        this.fieldValueValueLabel.element.children[0].style.setProperty("text-align", "left");
                        this.element.addClass($byForm.object.CssClassNameHelper.resultFieldPanel);
                        this.element.addClass($byForm.object.CssClassNameHelper.resultFieldNameLabel);
                        this.element.addClass($byForm.object.CssClassNameHelper.resultFieldValueLabel);
                    }
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { fieldNameValueLabel: $by.object.Label, fieldValueValueLabel: $by.object.Label, analyzeButton: $by.object.Button } }
        },
        FieldAnalyzePanel: {
            type: class FieldAnalyzePanel extends Byt.Object {
                $1(fields){
                    this.fields = new $by.object.List();
                    this.fieldSelector = new $by.object.ComboBox();
                    this.chartSelector = new $by.object.ComboBox();
                    this.deleteButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.delete; });
                    this.hasBorder = false;
                    this.add(this.fieldSelector);
                    this.add(this.chartSelector);
                    this.add(this.deleteButton);
                    this.fields = fields;
                    {
                        this.deleteButton.element.addClass($byForm.object.CssClassNameHelper.generalFieldDeleteButton);
                        this.fieldSelector.element.addClass($byForm.object.CssClassNameHelper.analyzeFieldSelector);
                        this.chartSelector.element.addClass($byForm.object.CssClassNameHelper.analyzerChartSelector);
                    }
                    for (let field of fields){ this.fieldSelector.add(field.i$access("iFieldName")); }
                    for (let type of $byExternalChartjs.enum.chartType.$values()){ this.chartSelector.add(type); }
                    this.chartSelector.selectedIndex = 0;
                    this.deleteButton.click.$add((sender, args) => { this.remove(); });
                }
                getFieldID(){
                    if(this.fieldSelector.selectedIndex == -1){ return null; }
                    else { return this.fields.$get(this.fieldSelector.selectedIndex).i$access("iID"); }
                }
                getChartType(){
                    for (let type of $byExternalChartjs.enum.chartType.$values()){
                        if(type.by$toString() == this.chartSelector.selectedItem.by$toString()){ return type; }
                    }
                    return "bar";
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { fields: [ "by.object.List", Byt.Row ], fieldSelector: $by.object.ComboBox, chartSelector: $by.object.ComboBox, deleteButton: $by.object.Button } }
        },
        FieldTextBox: {
            type: class FieldTextBox extends Byt.Object {
                $1(row){
                    super.$1(row);
                    this.inputBox = new $by.object.TextBox();
                    this.lengthCountLabel = new $by.object.Label().$init($ => { $.hasBorder = false; });
                    this.fieldPanel.add(this.inputBox);
                    this.contentPanel.add(this.lengthCountLabel);
                    this.inputBox.text = row.i$access("iFieldDefault");
                    this.inputBox.textChanged.$add(this.$access("onTextChanged"));
                    this.inputBox.keyUp.$add(this.$access("onKeyUp"));
                    if(row.i$access("iFieldType") == "int"){ this.lengthCountLabel.text = Byt.String($byForm.object.TextHelper.valueMin) + ":" + row.i$access("iFieldMin") + ", " + Byt.String($byForm.object.TextHelper.valueMax) + ":" + row.i$access("iFieldMax"); }
                    else if(row.i$access("iFieldType") == "string"){ this.lengthCountLabel.text = Byt.String(this.inputBox.text.length.by$toString()) + "/" + Byt.String(this.fieldRow.i$access("iFieldMax").by$toString()); }
                }
                onTextChanged(sender, args){
                    this.clearMessage();
                    let result = this.verifyText();
                    if(!result.isOk){ this.setMessage$1(result.info); }
                }
                onKeyUp(sender, args){
                    if(this.fieldRow.i$access("iFieldType") == "int"){}
                    else if(this.fieldRow.i$access("iFieldType") == "string"){
                        if(this.fieldRow.i$access("iFieldMax") > 0){
                            this.lengthCountLabel.text = Byt.String(this.inputBox.text.length.by$toString()) + "/" + Byt.String(this.fieldRow.i$access("iFieldMax").by$toString());
                            if(this.inputBox.text.length > this.fieldRow.i$access("iFieldMax")){ this.lengthCountLabel.foreColor = $by.object.Color.RED; }
                            else { this.lengthCountLabel.foreColor = $by.object.Color.BLACK; }
                        }
                    }
                }
                getValue(){ return this.inputBox.text; }
                verifyStringText(){
                    let value = this.inputBox.text;
                    if(this.fieldRow.i$access("iFieldMax") > 0 && value.length > this.fieldRow.i$access("iFieldMax")){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = "长度限制在" + this.fieldRow.i$access("iFieldMin") + "-" + this.fieldRow.i$access("iFieldMax") + "个字符!";
                    }); }
                    if(this.fieldRow.i$access("iFieldMin") > 0 && value.length < this.fieldRow.i$access("iFieldMin")){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = "长度限制在" + this.fieldRow.i$access("iFieldMin") + "-" + this.fieldRow.i$access("iFieldMax") + "个字符!";
                    }); }
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                verifyIntText(){
                    if(!this.inputBox.text.by$isMatch("^(\\-|\\+)?\\d+(\\.\\d+)?$", "multiline")){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = "格式错误,非数值类型！";
                    }); }
                    let value = $by.object.Int.parse(this.inputBox.text);
                    if(value > this.fieldRow.i$access("iFieldMax") || value < this.fieldRow.i$access("iFieldMin")){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = "数值超出范围，最小值:" + this.fieldRow.i$access("iFieldMin") + ",最大值:" + this.fieldRow.i$access("iFieldMax");
                    }); }
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                verifyText(){
                    let value = this.inputBox.text;
                    if(value == "" || value == null){
                        if(this.fieldRow.i$access("iNotNull")){ return new $by.object.Result().$init($ => {
                            $.isOk = false;
                            $.info = "此项为必填项";
                        }); }
                        else { return new $by.object.Result().$init($ => { $.isOk = true; }); }
                    }
                    if(this.fieldRow.i$access("iFieldType") == "int"){
                        let result = this.verifyIntText();
                        if(!result.isOk){ return result; }
                    }
                    if(this.fieldRow.i$access("iFieldType") == "string"){
                        let result = this.verifyStringText();
                        if(!result.isOk){ return result; }
                    }
                    if(this.fieldRow.i$access("iFieldReg") != null && this.fieldRow.i$access("iFieldReg") != ""){
                        if(!value.by$isMatch(this.fieldRow.i$access("iFieldReg"), "multiIgnoreCase")){ return new $by.object.Result().$init($ => {
                            $.isOk = false;
                            $.info = this.fieldRow.i$access("iFieldRegMsg");
                        }); }
                    }
                    if($byForm.object.Common.isQuoted(value)){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = "不能有单引号或双引号!";
                    }); }
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                verify(){
                    let textResult = this.verifyText();
                    this.setMessage$1(textResult.info);
                    return textResult;
                }
            },
            base: { inherit: "byForm.object.FieldControl" },
            instance: { props: { inputBox: $by.object.TextBox, lengthCountLabel: $by.object.Label } }
        },
        FieldMultiTextBox: {
            type: class FieldMultiTextBox extends Byt.Object {
                $1(row){
                    super.$1(row);
                    this.inputBox.isMultiLine = true;
                    this.inputBox.width = 200;
                    this.inputBox.height = 100;
                }
                verify(){ return super.verify(); }
            },
            base: { inherit: "byForm.object.FieldTextBox" }
        },
        FormDataAnalyzeArea: {
            type: class FormDataAnalyzeArea extends Byt.Object {
                $1(formRow, fieldRows){
                    this.fieldSelectionsPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.buttonContainer = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.displayButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.statisticsResult;
                        $.toolTip = $byForm.object.TextHelper.statisticsResult;
                    });
                    this.appendButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.appendChart;
                        $.toolTip = $byForm.object.TextHelper.appendChartTip;
                    });
                    this.deleteButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.delete;
                        $.toolTip = $byForm.object.TextHelper.deleteChartContainer;
                    });
                    this.fieldSelectionsPanel.add(new $byForm.object.FieldAnalyzePanel().$init($ => $.$1(fieldRows)));
                    this.add(this.fieldSelectionsPanel);
                    this.add(this.buttonContainer);
                    this.buttonContainer.add(this.appendButton);
                    this.buttonContainer.add(this.displayButton);
                    this.buttonContainer.add(this.deleteButton);
                    {
                        this.buttonContainer.element.addClass($byForm.object.CssClassNameHelper.analyzerFieldButtonContainer);
                        this.appendButton.element.addClass($byForm.object.CssClassNameHelper.analyzerFieldAddButton);
                        this.displayButton.element.addClass($byForm.object.CssClassNameHelper.analyzerFieldDisplayButton);
                        this.deleteButton.element.addClass($byForm.object.CssClassNameHelper.analyzerFieldDeleteButton);
                    }
                    this.hasBorder = false;
                    this.displayButton.click.$add(async (sender, args) => { await this.displayButtonClick.$invoke(this, args); });
                    this.appendButton.click.$add(async (sender, args) => {
                        if(fieldRows.count == 0){
                            await $by.object.Message.alert($byForm.object.TextHelper.stasticsFieldLess);
                            return;
                        }
                        this.fieldSelectionsPanel.add(new $byForm.object.FieldAnalyzePanel().$init($ => $.$1(fieldRows)));
                    });
                    this.deleteButton.click.$add(async (sender, args) => { await this.deleteButtonClick.$invoke(this, args); });
                }
                getAnalyzeConfig(){
                    let info = new $byForm.object.AnalyzeConfigInfo().$init($ => $.$0());
                    info.fieldID = ($byForm.object.FieldAnalyzePanel.$convert(this.fieldSelectionsPanel.children.$get(0))).getFieldID();
                    info.chartType = ($byForm.object.FieldAnalyzePanel.$convert(this.fieldSelectionsPanel.children.$get(0))).getChartType();
                    return info;
                }
                getAnalyzeConfigs(){
                    let analyzeConfigInfoList = new $by.object.List();
                    for (let selectionControl of this.fieldSelectionsPanel.children){
                        let fieldAnalyzePanel = $byForm.object.FieldAnalyzePanel.$convert(selectionControl);
                        let info = new $byForm.object.AnalyzeConfigInfo().$init($ => $.$0());
                        info.fieldID = fieldAnalyzePanel.getFieldID();
                        info.chartType = fieldAnalyzePanel.getChartType();
                        analyzeConfigInfoList.add(info);
                    }
                    return analyzeConfigInfoList;
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { fieldSelectionsPanel: $by.object.Panel, buttonContainer: $by.object.Panel, displayButton: $by.object.Button, appendButton: $by.object.Button, deleteButton: $by.object.Button }, events: [ "displayButtonClick", "deleteButtonClick" ] }
        },
        FieldTermDisplayArea: {
            type: class FieldTermDisplayArea extends Byt.Object { },
            base: { inherit: $by.object.Panel }
        },
        EditorManager: {
            type: class EditorManager extends Byt.Object { },
            instance: { props: { formNameEditor: "byForm.object.FormNameEditor", fieldControlEditor: "byForm.object.FieldControlEditor" } }
        },
        FieldMultiTextBoxEditor: {
            type: class FieldMultiTextBoxEditor extends Byt.Object {
                $1(fieldInfo){ super.$1(fieldInfo); }
            },
            base: { inherit: "byForm.object.FieldTextBoxEditor" }
        },
        NameHelper: {
            type: class NameHelper extends Byt.Object {
                static $0(){
                    this.draggingItemType = "draggingItemType";
                    this.draggingItemOrder = "draggingItemOrder";
                    this.screenY = "screenY";
                    this.formID = "formid";
                    this.fieldID = "fieldid";
                    this.fieldTemplateID = "fieldTemplateID";
                    this.canvasID = "init-chart";
                    this.formInfoID = "form-info";
                    this.operateAreaID = "init-operate-area";
                    this.containerID = "init-container";
                    this.chartsContainerID = "charts";
                    this.placeHolderTag = "input";
                    this.placeholderAttributeName = "placeholder";
                    this.unlimit = "无限制";
                }
            },
            transmit: [ ],
            static: { props: { draggingItemType: Byt.String, draggingItemOrder: Byt.String, screenY: Byt.String, formID: Byt.String, fieldID: Byt.String, fieldTemplateID: Byt.String, canvasID: Byt.String, formInfoID: Byt.String, operateAreaID: Byt.String, containerID: Byt.String, chartsContainerID: Byt.String, placeHolderTag: Byt.String, placeholderAttributeName: Byt.String, unlimit: Byt.String } }
        },
        FieldCheckBoxList: {
            type: class FieldCheckBoxList extends Byt.Object {
                $1(row){
                    super.$1(row);
                    this.checkBoxList = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.fieldPanel.add(this.checkBoxList);
                    for (let selectValue of row.i$access("iSelectValue").by$split(Byt.Char("\n"))){
                        let checkBox = new $by.object.CheckBox().$init($ => { $.text = selectValue; });
                        checkBox.checkedChanged.$add((sender, args) => {
                            this.clearMessage();
                            this.verifySelectionCount();
                        });
                        this.checkBoxList.add(checkBox);
                    }
                }
                getValue(){
                    let checkedValue = "";
                    for (let control of this.checkBoxList.children){
                        let checkBox = $by.object.CheckBox.$convert(control);
                        if(checkBox.isChecked){
                            if(checkedValue != ""){ checkedValue = Byt.String["+"](checkedValue, "\n"); }
                            checkedValue = Byt.String["+"](checkedValue, checkBox.text);
                        }
                    }
                    return checkedValue;
                }
                verifySelectionCount(){
                    let count = 0;
                    for (let control of this.checkBoxList.children){
                        if(($by.object.CheckBox.$convert(control)).isChecked){ count++; }
                    }
                    if(count > this.fieldRow.i$access("iFieldMax") && this.fieldRow.i$access("iFieldMax") > 0){
                        let errorInfo = "勾选数不能超过" + Byt.String(this.fieldRow.i$access("iFieldMax").by$toString());
                        return new $by.object.Result().$init($ => {
                            $.isOk = false;
                            $.info = errorInfo;
                        });
                    }
                    if(count < this.fieldRow.i$access("iFieldMin") && this.fieldRow.i$access("iFieldMin") > 0){
                        let errorInfo = "勾选数不能少于" + Byt.String(this.fieldRow.i$access("iFieldMin").by$toString());
                        return new $by.object.Result().$init($ => {
                            $.isOk = false;
                            $.info = errorInfo;
                        });
                    }
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                verify(){
                    let result = this.verifySelectionCount();
                    this.setMessage$1(result.info);
                    return result;
                }
            },
            base: { inherit: "byForm.object.FieldControl" },
            instance: { props: { checkBoxList: $by.object.Panel, selectionCount: Byt.Int } }
        },
        FieldTermPanel: {
            type: class FieldTermPanel extends Byt.Object {
                $1(row, isAllInit){
                    this.fieldTermOrderLabel = new $by.object.Label();
                    this.fieldTermLabel = new $by.object.Label();
                    this.fieldTermDisplayArea = new $byForm.object.FieldTermDisplayArea().$init($ => {
                        $.$0();
                        $.hasBorder = false;
                    });
                    this.fieldTermEditArea = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    this.editButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.edit; });
                    this.deleteButton = new $by.object.Button().$init($ => { $.text = $byForm.object.TextHelper.delete; });
                    this.fieldInfo = row;
                    this.add(this.fieldTermOrderLabel);
                    this.add(this.fieldTermLabel);
                    this.GenerateFieldTermDisplayArea(isAllInit);
                    this.add(this.fieldTermDisplayArea);
                    this.fieldTermEditArea.add(this.editButton);
                    this.fieldTermEditArea.add(this.deleteButton);
                    this.add(this.fieldTermEditArea);
                    {
                        this.element.addClass($byForm.object.CssClassNameHelper.generalFieldPanel);
                        this.fieldTermOrderLabel.element.addClass($byForm.object.CssClassNameHelper.generalFieldOrderLabel);
                        this.fieldTermLabel.element.addClass($byForm.object.CssClassNameHelper.generalFieldTitleLabel);
                        this.fieldTermDisplayArea.element.addClass($byForm.object.CssClassNameHelper.generalFieldDisplayArea);
                        this.fieldTermEditArea.element.addClass($byForm.object.CssClassNameHelper.generalFieldEditArea);
                        this.coreControl.element.addClass($byForm.object.CssClassNameHelper.generalFieldCoreControl);
                        this.editButton.element.addClass($byForm.object.CssClassNameHelper.generalFieldEditButton);
                        this.deleteButton.element.addClass($byForm.object.CssClassNameHelper.generalFieldDeleteButton);
                    }
                    
                    this.setOrder((($by.object.Int.parse(this.fieldInfo.i$access("iFieldNO")) + 1) | 0));
                    this.fieldTermLabel.text = this.fieldInfo.i$access("iFieldName").by$toString();
                    this.allowDrag = true;
                    this.allowDrop = true;
                    this.fieldTermLabel.click.$add(async (sender, args) => { await this.generalClick.$invoke(this, args); });
                    this.fieldTermDisplayArea.click.$add(async (sender, args) => { await this.generalClick.$invoke(this, args); });
                    this.click.$add(async (sender, args) => { await this.generalClick.$invoke(this, args); });
                    this.editButton.click.$add(async (sender, args) => { await this.generalClick.$invoke(this, args); });
                    this.deleteButton.click.$add(async (sender, args) => { await this.deleteButtonClick.$invoke(this, args); });
                    this.fieldTermEditArea.click.$add(async (sender, args) => { await this.generalClick.$invoke(this, args); });
                }
                GenerateFieldTermDisplayArea(isAllInit){
                    if(isAllInit){ this.coreControl = this.generateCoreControl(); }
                    else { this.coreControl = this.buildCoreControlFromFieldInfo(); }
                    this.coreControl.toolTip = this.fieldInfo.i$access("iSummary");
                    this.coreControl.click.$add(async (sender, args) => { await this.generalClick.$invoke(this, args); });
                    this.fieldTermDisplayArea.add(this.coreControl);
                }
                generateCoreControl(){
                    switch(this.fieldInfo.i$access("iFieldCtrl")){
                        case "textbox":
                            {
                                this.fieldInfo.i$assign("iFieldType", "string");
                                this.text = this.fieldInfo.i$access("iFieldDefault");
                                return new $by.object.TextBox();
                            }
                        case "checkBox":
                            {
                                this.fieldInfo.i$assign("iSelectValue", $byForm.object.TextHelper.defaultCheckItem);
                                return new $by.object.CheckBox().$init($ => { $.text = $byForm.object.TextHelper.defaultCheckItem; });
                            }
                        case "dropdownList":
                            {
                                this.fieldInfo.i$assign("iSelectValue", $byForm.object.TextHelper.defaultSelectValues);
                                let comboBox = new $by.object.ComboBox();
                                comboBox.add($byForm.object.TextHelper.defaultCheckItemOne);
                                comboBox.add($byForm.object.TextHelper.defaultCheckItemTwo);
                                return comboBox;
                            }
                        case "muiltTextbox":
                            {
                                this.fieldInfo.i$assign("iFieldType", "string");
                                this.fieldInfo.i$assign("iFieldDefault", this.fieldInfo.i$access("iFieldDefault"));
                                let multiTextBox = new $by.object.TextBox().$init($ => {
                                    $.isMultiLine = true;
                                    $.width = $byForm.object.ValueHelper.multiTextboxWidth;
                                    $.height = $byForm.object.ValueHelper.multiTextboxHeight;
                                });
                                return multiTextBox;
                            }
                        case "radbutton":
                            {
                                this.fieldInfo.i$assign("iSelectValue", $byForm.object.TextHelper.defaultSelectValues);
                                let radioButtonGroup = new $by.object.RadioButtonGroup();
                                radioButtonGroup.add(new $by.object.RadioButton().$init($ => { $.text = $byForm.object.TextHelper.defaultCheckItemOne; }));
                                radioButtonGroup.add(new $by.object.RadioButton().$init($ => { $.text = $byForm.object.TextHelper.defaultCheckItemTwo; }));
                                return radioButtonGroup;
                            }
                        case "slider":
                            {
                                this.fieldInfo.i$assign("iSelectValue", $byForm.object.TextHelper.defaultSliderSelectValue);
                                let slider = new $by.object.Slider().$init($ => {
                                    $.min = $byForm.object.ValueHelper.defaultSliderMin;
                                    $.max = $byForm.object.ValueHelper.defaultSliderMax;
                                    $.delta = $byForm.object.ValueHelper.defaultSliderDelta;
                                });
                                return slider;
                            }
                        case "checkBoxList":
                            {
                                this.fieldInfo.i$assign("iSelectValue", $byForm.object.TextHelper.defaultSelectValues);
                                this.fieldInfo.i$assign("iFieldMin", $byForm.object.ValueHelper.defaultCheckBoxListMin);
                                this.fieldInfo.i$assign("iFieldMax", $byForm.object.ValueHelper.defaultCheckBoxListMax);
                                let checkBoxs = new $by.object.Panel();
                                checkBoxs.add(new $by.object.CheckBox().$init($ => { $.text = $byForm.object.TextHelper.defaultCheckItemOne; }));
                                checkBoxs.add(new $by.object.CheckBox().$init($ => { $.text = $byForm.object.TextHelper.defaultCheckItemTwo; }));
                                return checkBoxs;
                            }
                        case "datePicker":
                        case "timePicker":
                        case "dateTimePicker":
                            {
                                let dateTimePicker = new $by.object.DateTimePicker();
                                $byForm.object.Common.setDateTimePickerMode(dateTimePicker, this.fieldInfo.i$access("iFieldCtrl"));
                                return new $by.object.DateTimePicker();
                            }
                        default:
                            {
                                throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                            }
                    }
                }
                buildCoreControlFromFieldInfo(){
                    let coreControlType = this.fieldInfo.i$access("iFieldCtrl");
                    switch(this.fieldInfo.i$access("iFieldCtrl")){
                        case "textbox":
                            { return new $by.object.TextBox(); }
                        case "checkBox":
                            { return new $by.object.CheckBox().$init($ => { $.text = this.fieldInfo.i$access("iSelectValue"); }); }
                        case "dropdownList":
                            {
                                let comboBox = new $by.object.ComboBox();
                                for (let selectValue of this.fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n"))){ comboBox.add(selectValue); }
                                return comboBox;
                            }
                        case "muiltTextbox":
                            {
                                let size = this.fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n"));
                                let multiTextBox = new $by.object.TextBox().$init($ => {
                                    $.isMultiLine = true;
                                    $.width = 400;
                                    $.height = 100;
                                });
                                return multiTextBox;
                            }
                        case "radbutton":
                            {
                                let radioButtonGroup = new $by.object.RadioButtonGroup();
                                for (let selectValue of this.fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n"))){ radioButtonGroup.add(new $by.object.RadioButton().$init($ => { $.text = selectValue; })); }
                                return radioButtonGroup;
                            }
                        case "slider":
                            {
                                let sliderProperty = this.fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n"));
                                if(sliderProperty.length == 3){
                                    let slider = new $by.object.Slider();
                                    slider.min = $by.object.Int.parse(sliderProperty[0]);
                                    slider.max = $by.object.Int.parse(sliderProperty[1]);
                                    slider.delta = $by.object.Int.parse(sliderProperty[2]);
                                }
                                return new $by.object.Slider();
                            }
                        case "checkBoxList":
                            {
                                let checkBoxes = new $by.object.Panel();
                                for (let selectValue of this.fieldInfo.i$access("iSelectValue").by$split(Byt.Char("\n"))){ checkBoxes.add(new $by.object.CheckBox().$init($ => { $.text = selectValue; })); }
                                return checkBoxes;
                            }
                        case "datePicker":
                        case "timePicker":
                        case "dateTimePicker":
                            {
                                let dateTimePicker = new $by.object.DateTimePicker();
                                $byForm.object.Common.setDateTimePickerMode(dateTimePicker, this.fieldInfo.i$access("iFieldCtrl"));
                                return dateTimePicker;
                            }
                        default:
                            {
                                throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                            }
                    }
                    return new $by.object.TextBox();
                }
                setOrder(order){ this.fieldTermOrderLabel.text = Byt.String(order.by$toString()) + "."; }
                static generateControlField(fieldRow){
                    switch(fieldRow.i$access("iFieldCtrl")){
                        case "textbox":
                            {
                                fieldRow.i$assign("iFieldType", "string");
                                fieldRow.i$assign("iFieldDefault", $byForm.object.TextHelper.defaultTextboxText);
                                return fieldRow;
                            }
                        case "checkBox":
                            {
                                fieldRow.i$assign("iSelectValue", $byForm.object.TextHelper.defaultCheckItem);
                                return fieldRow;
                            }
                        case "dropdownList":
                            {
                                fieldRow.i$assign("iSelectValue", $byForm.object.TextHelper.defaultSelectValues);
                                return fieldRow;
                            }
                        case "muiltTextbox":
                            {
                                fieldRow.i$assign("iFieldType", "string");
                                fieldRow.i$assign("iFieldDefault", $byForm.object.TextHelper.defaultTextboxText);
                                return fieldRow;
                            }
                        case "radbutton":
                            {
                                fieldRow.i$assign("iSelectValue", $byForm.object.TextHelper.defaultSelectValues);
                                return fieldRow;
                            }
                        case "slider":
                            {
                                fieldRow.i$assign("iSelectValue", $byForm.object.TextHelper.defaultSliderSelectValue);
                                return fieldRow;
                            }
                        case "checkBoxList":
                            {
                                fieldRow.i$assign("iSelectValue", $byForm.object.TextHelper.defaultSelectValues);
                                fieldRow.i$assign("iFieldMin", $byForm.object.ValueHelper.defaultCheckBoxListMin);
                                fieldRow.i$assign("iFieldMax", $byForm.object.ValueHelper.defaultCheckBoxListMax);
                                return fieldRow;
                            }
                        case "datePicker":
                        case "timePicker":
                        case "dateTimePicker":
                            { return fieldRow; }
                        default:
                            {
                                throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                            }
                    }
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { fieldTermOrderLabel: $by.object.Label, fieldTermLabel: $by.object.Label, fieldTermDisplayArea: "byForm.object.FieldTermDisplayArea", fieldTermEditArea: $by.object.Panel, fieldInfo: Byt.Row, editButton: $by.object.Button, deleteButton: $by.object.Button, coreControl: $by.object.Control }, events: [ "generalClick", "generalDragStart", "generalDragDrop", "deleteButtonClick" ] }
        },
        FieldDateTimePickerEditor: {
            type: class FieldDateTimePickerEditor extends Byt.Object {
                $1(fieldInfo){ super.$1(fieldInfo); }
            },
            base: { inherit: "byForm.object.FieldControlEditor" }
        },
        PropertyNumberBox: {
            type: class PropertyNumberBox extends Byt.Object {
                $1(propertyName){
                    this.propertyLabel = new $by.object.Label();
                    this.propertyBox = new $by.object.NumberBox();
                    this.restoreValue = Byt.Decimal(0);
                    {
                        this.propertyLabel.webWidthFilled = true;
                        this.propertyBox.webWidthFilled = true;
                    }
                    this.scrollable = false;
                    this.setName(propertyName);
                    this.add(this.propertyLabel);
                    this.add(this.propertyBox);
                    this.propertyBox.valueChanged.$add(async (sender, args) => {
                        if(this.propertyBox.text == "" || this.propertyBox.text == null){
                            this.setValue(this.restoreValue);
                            await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.invalidValueError) + Byt.String($byForm.object.TextHelper.restored));
                            return;
                        }
                        this.restoreValue = this.getValue();
                    });
                }
                setName(propertyName){ this.propertyLabel.text = propertyName; }
                setValue(value){ this.propertyBox.value = value; }
                getValue(){ return this.propertyBox.value; }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { propertyLabel: $by.object.Label, propertyBox: $by.object.NumberBox, restoreValue: Byt.Decimal } }
        },
        FieldCheckBox: {
            type: class FieldCheckBox extends Byt.Object {
                $1(row){
                    super.$1(row);
                    this.checkBox = new $by.object.CheckBox();
                    this.checkBox.text = row.i$access("iSelectValue");
                    this.fieldPanel.add(this.checkBox);
                }
                getValue(){ return this.checkBox.isChecked ? "1" : "0"; }
                verify(){ return super.verify(); }
            },
            base: { inherit: "byForm.object.FieldControl" },
            instance: { props: { checkBox: $by.object.CheckBox } }
        },
        SelectionData: {
            type: class SelectionData extends Byt.Object {
                $0(){
                    this.text = "";
                    this.defaultText = "";
                }
            },
            instance: { props: { text: Byt.String, defaultText: Byt.String, order: Byt.Int } }
        },
        FormInfoArea: {
            type: class FormInfoArea extends Byt.Object {
                $1(formRow){
                    this.formInfoLabel = new $by.object.Label();
                    this.createChartButton = new $by.object.Button().$init($ => {
                        $.text = $byForm.object.TextHelper.createChart;
                        $.toolTip = $byForm.object.TextHelper.createChartTip;
                    });
                    this.hasBorder = false;
                    this.formInfoLabel.text = formRow.i$access("iName");
                    this.add(this.formInfoLabel);
                    this.add(this.createChartButton);
                    {
                        this.element.addClass($byForm.object.CssClassNameHelper.formItemInfoArea);
                        this.formInfoLabel.element.addClass($byForm.object.CssClassNameHelper.formNameValueLabel);
                        this.createChartButton.element.addClass($byForm.object.CssClassNameHelper.analyzerChartCreateButton);
                    }
                    this.createChartButton.click.$add(async (sender, args) => { await this.createButtonClick.$invoke(this, args); });
                }
            },
            base: { inherit: $by.object.Panel },
            instance: { props: { formInfoLabel: $by.object.Label, createChartButton: $by.object.Button }, events: [ "createButtonClick" ] }
        },
        cFieldPanel: {
            type: class cFieldPanel extends Byt.Object { },
            base: { inherit: $by.object.Panel }
        }
    },
    identity: {
        formResult: {
            type: class formResult extends Byt.Identity {
                async main(queryArgs){
                    let queryDic = $byWebCommon.identity.webCommon.getQueryArgDic(queryArgs);
                    if(!queryDic.containsKey($byForm.object.NameHelper.formID)){
                        await $by.object.Message.alert($byForm.object.TextHelper.formIdLoss);
                        return;
                    }
                    if(queryDic.$get($byForm.object.NameHelper.formID) == null || queryDic.$get($byForm.object.NameHelper.formID) == ""){
                        await $by.object.Message.alert($byForm.object.TextHelper.formIdError);
                        return;
                    }
                    let formQueryResult = (await $byForm.$sql({ ["#sql"]: "select", number: 0, args: [ queryDic.$get($byForm.object.NameHelper.formID) ], argTypes: [ Byt.String ], from: { a: this.rFormSys.rForm } })).rows.$get(0);
                    let formDataQueryResult = (await $byForm.$sql({ ["#sql"]: "select", number: 1, args: [ queryDic.$get($byForm.object.NameHelper.formID) ], argTypes: [ Byt.String ], from: { b: this.rFormSys.rFormData } })).rows;
                    if(!this.rFormSys.rUser.confirmUserIsLogin$2(formQueryResult.i$access("iUserID"))){
                        await $by.object.Message.alert($byForm.object.TextHelper.formUserLoss);
                        return;
                    }
                    let formDataPanel = new $by.object.Panel().$init($ => { $.hasBorder = false; });
                    try{ await this.rFormSys.rForm.displayFormData(formQueryResult, formDataQueryResult, formDataPanel); }
                    catch(e$){
                        if($by.object.Exception.$check(e$)){
                            let e = $by.object.Exception.$convert(e$);
                            throw Error(new $by.object.Exception(e.message));
                        }
                    }
                    $by.object.System.currentDocument.body.append(formDataPanel.element);
                }
            },
            base: { inherit: $by.identity.Page },
            instance: { components: [ "rFormSys" ] }
        },
        formAnalyzer: {
            type: class formAnalyzer extends Byt.Identity {
                async main(queryArgs){
                    super.main(queryArgs);
                    let queryDic = $byWebCommon.identity.webCommon.getQueryArgDic(queryArgs);
                    if(!queryDic.containsKey($byForm.object.NameHelper.formID)){
                        await $by.object.Message.alert($byForm.object.TextHelper.formIdLoss);
                        return;
                    }
                    if($byForm.object.Common.isEmptyString(queryDic.$get($byForm.object.NameHelper.formID))){
                        await $by.object.Message.alert($byForm.object.TextHelper.formIdError);
                        return;
                    }
                    let formQueryResult = await $byForm.$sql({ ["#sql"]: "select", number: 2, args: [ queryDic.$get($byForm.object.NameHelper.formID) ], argTypes: [ Byt.String ], from: { a: this.rFormSys.rForm } });
                    let formFieldQueryResult = await $byForm.$sql({ ["#sql"]: "select", number: 3, args: [ queryDic.$get($byForm.object.NameHelper.formID) ], argTypes: [ Byt.String ], from: { b: this.rFormSys.rFormField } });
                    let formRow = formQueryResult.rows.$get(0);
                    let fieldRows = formFieldQueryResult.rows;
                    if(!this.rFormSys.rUser.confirmUserIsLogin$2(formRow.i$access("iUserID"))){
                        await $by.object.Message.alert($byForm.object.TextHelper.formUserLoss);
                        return;
                    }
                    let formInfoArea = new $byForm.object.FormInfoArea().$init($ => $.$1(formRow));
                    $by.object.System.currentDocument.getElementByID($byForm.object.NameHelper.formInfoID).append(formInfoArea.element);
                    this.generateAnalyzeOperateArea(formRow, fieldRows, $byForm.object.NameHelper.operateAreaID, $byForm.object.NameHelper.canvasID, $byForm.object.NameHelper.containerID);
                    formInfoArea.createButtonClick.$add((sender, args) => {
                        let chartsContainer = $by.object.System.currentDocument.getElementByID($byForm.object.NameHelper.chartsContainerID);
                        let operateAreaId = "op" + chartsContainer.children.length;
                        let canvasId = "cv" + chartsContainer.children.length;
                        let chartId = "chart" + chartsContainer.children.length;
                        let newOperateArea = $by.object.System.currentDocument.createElement("div");
                        let newCanvasArea = $by.object.System.currentDocument.createElement("canvas");
                        let newChartContainer = $by.object.System.currentDocument.createElement("div");
                        newOperateArea.addAttribute("id", operateAreaId);
                        newCanvasArea.addAttribute("id", canvasId);
                        newCanvasArea.addAttribute("width", $byForm.object.ValueHelper.initChartWidth.by$toString());
                        newCanvasArea.addAttribute("height", $byForm.object.ValueHelper.initChartHeight.by$toString());
                        newChartContainer.addAttribute("id", chartId);
                        newChartContainer.addClass($byForm.object.CssClassNameHelper.analyzerChartContainer);
                        newCanvasArea.addClass($byForm.object.CssClassNameHelper.analyzerChartCanvas);
                        newChartContainer.append(newOperateArea);
                        newChartContainer.append(newCanvasArea);
                        chartsContainer.append(newChartContainer);
                        this.generateAnalyzeOperateArea(formRow, fieldRows, operateAreaId, canvasId, chartId);
                    });
                }
                generateAnalyzeOperateArea(formRow, fieldRows, elementID, canvasID, containerID){
                    let analyzeArea = new $byForm.object.FormDataAnalyzeArea().$init($ => $.$1(formRow, fieldRows));
                    analyzeArea.displayButtonClick.$add(async (sender, args) => {
                        let configInfos = analyzeArea.getAnalyzeConfigs();
                        if(configInfos.count == 0){
                            await $by.object.Message.alert($byForm.object.TextHelper.stasticsFieldLess);
                            return;
                        }
                        if(configInfos.count == 1){
                            let configInfo = configInfos.$get(0);
                            await this.analyze(configInfo, canvasID);
                        }
                        else { await this.analyze$1(configInfos, canvasID); }
                    });
                    analyzeArea.deleteButtonClick.$add((sender, args) => {
                        let containerElement = $by.object.System.currentDocument.getElementByID(containerID);
                        containerElement.remove();
                    });
                    $by.object.System.currentDocument.getElementByID(elementID).append(analyzeArea.element);
                }
                async analyze(configInfo, canvasID){
                    if(configInfo.fieldID == null){
                        await $by.object.Message.alert($byForm.object.TextHelper.stasticsFieldLess);
                        return;
                    }
                    let fieldID = configInfo.fieldID;
                    let type = configInfo.chartType;
                    let fields = (await $byForm.$sql({ ["#sql"]: "select", number: 4, args: [ fieldID ], argTypes: [ Byt.String ], from: { a: this.rFormSys.rFormField } })).rows;
                    let fieldData = (await $byForm.$sql({ ["#sql"]: "select", number: 5, args: [ fieldID ], argTypes: [ Byt.String ], from: { b: this.rFormSys.rFormData } })).rows;
                    let fieldRow = fields.$get(0);
                    if(!await this.checkFieldChartMatch(fieldRow.i$access("iFieldCtrl"), type)){ return; }
                    this.expandCanvas(canvasID);
                    switch(fieldRow.i$access("iFieldCtrl")){
                        case "dropdownList":
                        case "radbutton":
                        case "checkBoxList":
                        case "checkBox":
                            {
                                await this.displayCheckBox(fieldData, fieldRow, canvasID, type);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                async analyze$1(configInfos, canvasID){
                    let charts = new $by.object.List();
                    let selectionsList = new $by.object.List();
                    let selectionList = null;
                    let valuesList = new $by.object.List();
                    let summaries = new $by.object.List();
                    for (let configInfo of configInfos){
                        if(configInfo.fieldID == null){
                            await $by.object.Message.alert($byForm.object.TextHelper.stasticsFieldLess);
                            return;
                        }
                        let fields = (await $byForm.$sql({ ["#sql"]: "select", number: 6, args: [ configInfo.fieldID ], argTypes: [ Byt.String ], from: { a: this.rFormSys.rFormField } })).rows;
                        let fieldData = (await $byForm.$sql({ ["#sql"]: "select", number: 7, args: [ configInfo.fieldID ], argTypes: [ Byt.String ], from: { b: this.rFormSys.rFormData } })).rows;
                        let field = fields.$get(0);
                        if(!await this.checkFieldChartMatch(field.i$access("iFieldCtrl"), configInfo.chartType)){ return; }
                        let countTable = this.statisticsFormDataList(fieldData, field);
                        selectionsList.add(countTable.keys.toArray());
                        valuesList.add(countTable.values.toArray());
                        charts.add(configInfo.chartType.by$toString());
                        summaries.add(field.i$access("iSummary"));
                        selectionList = countTable.keys.toArray();
                    }
                    this.expandCanvas(canvasID);
                    await $byExternalChartjs.object.chartjs.fullMix(canvasID, charts.toArray(), summaries.toArray(), selectionList, valuesList.toArray(), await $byForm.object.Common.getStringColors(configInfos.count, 0.2), await $byForm.object.Common.getStringColors(configInfos.count, 1), await $byForm.object.Common.getStringColors(configInfos.count, 1));
                }
                expandCanvas(canvasID){
                    $by.object.System.currentDocument.getElementByID(canvasID).addAttribute("width", $byForm.object.ValueHelper.chartWidth.by$toString());
                    $by.object.System.currentDocument.getElementByID(canvasID).addAttribute("height", $byForm.object.ValueHelper.chartHeight.by$toString());
                }
                async checkFieldChartMatch(ctrl, chart){
                    switch(ctrl){
                        case "dropdownList":
                        case "radbutton":
                        case "checkBoxList":
                        case "checkBox":
                            {
                                if(chart == "bar" || chart == "doughnut" || chart == "line" || chart == "pie" || chart == "polarArea"){ return true; }
                                else {
                                    await $by.object.Message.alert($byForm.object.TextHelper.unsupportedChart);
                                    return false;
                                }
                            }
                        default:
                            {
                                await $by.object.Message.alert($byForm.object.TextHelper.unsupportedChart);
                                return false;
                            }
                    }
                }
                async displayCheckBox(formDataList, fieldRow, canvasID, chart){
                    let countTable = this.statisticsFormDataList(formDataList, fieldRow);
                    if(chart == "bar"){ await $byExternalChartjs.object.chartjs.fullBar(canvasID, fieldRow.i$access("iFieldName"), countTable.keys.toArray(), countTable.values.toArray(), await $byForm.object.Common.getStringColors(countTable.keys.count, 1), await $byForm.object.Common.getStringColors(countTable.keys.count, 1)); }
                    else if(chart == "pie"){ await $byExternalChartjs.object.chartjs.fullPie(canvasID, fieldRow.i$access("iFieldName"), countTable.keys.toArray(), countTable.values.toArray(), await $byForm.object.Common.getStringColors(countTable.keys.count, 1)); }
                    else if(chart == "doughnut"){ await $byExternalChartjs.object.chartjs.fullDoughnut(canvasID, fieldRow.i$access("iFieldName"), countTable.keys.toArray(), countTable.values.toArray(), await $byForm.object.Common.getStringColors(countTable.keys.count, 1)); }
                    else if(chart == "line"){ await $byExternalChartjs.object.chartjs.fullLine(canvasID, fieldRow.i$access("iFieldName"), countTable.keys.toArray(), countTable.values.toArray(), await $byForm.object.Common.getStringColors(countTable.keys.count, 1)); }
                    else if(chart == "polarArea"){ await $byExternalChartjs.object.chartjs.fullPolarArea(canvasID, fieldRow.i$access("iFieldName"), countTable.keys.toArray(), countTable.values.toArray(), await $byForm.object.Common.getStringColors(countTable.keys.count, 1)); }
                    else { await $by.object.Message.alert($byForm.object.TextHelper.unsupportedChart); }
                }
                statisticsFormDataList(formDataList, fieldRow){
                    let options = fieldRow.i$access("iSelectValue").by$split(Byt.Char("\n"));
                    if(fieldRow.i$access("iFieldCtrl") == "checkBox"){
                        options = Byt.Array.$create(Byt.String, 1, [ 2 ]);
                        options[0] = "0";
                        options[1] = "1";
                    }
                    let countTable = new $by.object.Dictionary();
                    for (let option of options){ countTable.add(option, 0); }
                    for (let dataRow of formDataList){
                        let selections = dataRow.i$access("iCellValue").by$split(Byt.Char("\n"));
                        for (let selection of selections){
                            if(countTable.containsKey(selection)){ countTable.$set(selection, 1, Byt.Float["+"]); }
                        }
                    }
                    return countTable;
                }
            },
            base: { inherit: $by.identity.Page },
            instance: { components: [ "rFormSys" ] }
        },
        formFilling: {
            type: class formFilling extends Byt.Identity {
                $0(){
                    super.$0();
                    this.isPreview = false;
                }
                async main(queryArgs){
                    let queryDic = $byWebCommon.identity.webCommon.getQueryArgDic(queryArgs);
                    if(!queryDic.containsKey($byForm.object.NameHelper.formID)){
                        if($by.object.System.bySaaSID == null || $by.object.System.bySaaSID == ""){
                            await $by.object.Message.alert($byForm.object.TextHelper.formIdLoss);
                            return;
                        }
                        else { queryDic.add($byForm.object.NameHelper.formID, $by.object.System.bySaaSID); }
                    }
                    if(queryDic.$get($byForm.object.NameHelper.formID) == null || queryDic.$get($byForm.object.NameHelper.formID) == ""){
                        await $by.object.Message.alert($byForm.object.TextHelper.formIdError);
                        return;
                    }
                    let formQueryResult = await $byForm.$sql({ ["#sql"]: "select", number: 34, args: [ queryDic.$get($byForm.object.NameHelper.formID) ], argTypes: [ Byt.String ], from: { a: this.rFormSys.rForm } });
                    let formFieldQueryResult = await $byForm.$sql({ ["#sql"]: "select", number: 35, args: [ queryDic.$get($byForm.object.NameHelper.formID) ], argTypes: [ Byt.String ], from: { b: this.rFormSys.rFormField } });
                    try{
                        if(formQueryResult.rows.count == 0){
                            await $by.object.Message.alert($byForm.object.TextHelper.sheetSubmittedLoss);
                            return;
                        }
                        let f_row = formQueryResult.rows.$get(0);
                        let formInstancePanel = this.rFormSys.rForm.generateFormInstancePanel(f_row, formFieldQueryResult.rows);
                        formInstancePanel.setSubmitButtonText(f_row.i$access("iSubmitButton"));
                        formInstancePanel.submitButtonClick.$add(async (sender, args) => {
                            if(this.isPreview){
                                await $by.object.Message.alert($byForm.object.TextHelper.previewOnly);
                                return;
                            }
                            let verifyResult = this.rFormSys.rForm.verifyFieldDatas(formInstancePanel.getContentPanel(), f_row);
                            if(!verifyResult.isOk){
                                await $by.object.Message.alert(verifyResult.info);
                                return;
                            }
                            let tmpList = await this.rFormSys.rForm.getFieldDatas(formInstancePanel.getContentPanel(), f_row);
                            let commitResult = new $by.object.Result().$init($ => {
                                $.isOk = true;
                                $.info = "";
                            });
                            for (let formdata of tmpList){
                                let targetFormData = this.rFormSys.rFormData.getformDataIdentity$1(formdata.i$access("iCellValue").length);
                                try{ await $byForm.$tran({ NO: 2, args: [ ], argTypes: [ ], sqls: [ { ["#sql"]: "insert", number: 36, args: [ formdata ], argTypes: [ Byt.Row ], from: targetFormData } ] }); }
                                catch(errorInfo){
                                    errorInfo = errorInfo.message;
                                    commitResult.isOk = false;
                                    commitResult.$assign("info", (Byt.String(formdata.i$access("iFieldName")) + "--" + Byt.String(errorInfo)), Byt.String["+"]);
                                }
                            }
                            if(commitResult.isOk){
                                await $by.object.Message.alert(f_row.i$access("iSuccessMsg"));
                                formInstancePanel.hide();
                            }
                            else {
                                await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.saveFail) + Byt.String(commitResult.info));
                                await this.rFormSys.rUser.rLog.write("Error", Byt.String($byForm.object.TextHelper.saveFail) + Byt.String(commitResult.info));
                            }
                            
                        });
                        if($by.object.System.bySaaSID != null && $by.object.System.bySaaSID != ""){
                            let tmpSaasEle = this.pageWindow.document.getElementByID($by.object.System.bySaaSID);
                            if(tmpSaasEle != null)
                                tmpSaasEle.append(formInstancePanel.element);
                            else 
                                $by.object.System.currentDocument.body.append(formInstancePanel.element);
                        }
                        else 
                            $by.object.System.currentDocument.body.append(formInstancePanel.element);
                    }
                    catch(e$){
                        if($by.object.Exception.$check(e$)){
                            let e = $by.object.Exception.$convert(e$);
                            throw Error(new $by.object.Exception(e.message));
                        }
                    }
                }
            },
            base: { inherit: $by.identity.Page },
            instance: { components: [ "rFormSys" ], props: { isPreview: Byt.Bool } }
        },
        previewFormFilling: {
            type: class previewFormFilling extends Byt.Identity {
                async main(queryArgs){
                    await super.main(queryArgs);
                    this.isPreview = true;
                }
            },
            base: { inherit: "byForm.identity.formFilling" },
            instance: { components: [ "rFormSys" ] }
        },
        formField: {
            type: class formField extends Byt.Identity {
                async addUpdate(f_formField, action){
                    
                    return await $byForm.$remote({ kind: "SKILL", NO: 10, target: this, args: [ f_formField, action ], argTypes: [ Byt.Row, $by.enum.Action ], return: Byt.Int });
                }
                async showAllFieldInfoAsTemplate(){
                    if(this.rFormSys.rUser.pSession == null){
                        await $by.object.Message.alert($byForm.object.TextHelper.notLoggedIn);
                        return;
                    }
                    if(this.rFormSys.rUser.pSession.a.i$access("iRank") != "vip"){
                        await $by.object.Message.alert($byForm.object.TextHelper.insufficientPermissions);
                        return;
                    }
                    let queryResult = await $byForm.$sql({ ["#sql"]: "select", number: 10, from: { data: this } });
                    let allfield = "";
                    for (let fieldRow of queryResult.rows){
                        let text = "";
                        text = Byt.String["+"](text, "{");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iID")) + "\",");
                        text = Byt.String["+"](text, " \"formID\",");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iFieldNO")) + "\",");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iFieldName")) + "\",");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iFieldType")) + "\",");
                        text = Byt.String["+"](text, Byt.String(fieldRow.i$access("iFieldCtrl")) + ",");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iSelectValue")) + "\",");
                        text = Byt.String["+"](text, " " + fieldRow.i$access("iFieldMin") + ",");
                        text = Byt.String["+"](text, " " + fieldRow.i$access("iFieldMax") + ",");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iFieldReg")) + "\",");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iFieldRegMsg")) + "\",");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iFieldDefault")) + "\",");
                        text = Byt.String["+"](text, " " + fieldRow.i$access("iOrder") + ",");
                        text = Byt.String["+"](text, " " + fieldRow.i$access("iNotNull") + ",");
                        text = Byt.String["+"](text, " " + fieldRow.i$access("iVDataValue") + ",");
                        text = Byt.String["+"](text, " \"" + "\",");
                        text = Byt.String["+"](text, " \"" + Byt.String(fieldRow.i$access("iSummary")) + "\"");
                        text = Byt.String["+"](text, "}\r\n");
                        allfield = Byt.String["+"](allfield, text);
                    }
                    let tmpdialog = new $by.object.Dialog();
                    tmpdialog.add(new $by.object.TextBox().$init($ => {
                        $.isMultiLine = true;
                        $.text = allfield;
                    }));
                    tmpdialog.show();
                }
                async delByFormId(formID){
                    
                    { await $byForm.$remote({ kind: "SKILL", NO: 12, target: this, args: [ formID ], argTypes: [ Byt.String ] }); }
                }
            },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iFormID", "iFieldNO", "iFieldName", "iSummary", "iFieldType", "iFieldCtrl", "iSelectValue", "iFieldMin", "iFieldMax", "iFieldReg", "iFieldRegMsg", "iFieldDefault", "iNotNull", "iOrder", "iVDataValue", "iUserID", "rFormSys" ] }
        },
        formSys: {
            type: class formSys extends Byt.Identity { },
            base: { inherit: $by.identity.Sys },
            instance: { components: [ "rForm", "rFormField", "rFormData", "rFieldTemplate", "rFormTemplate", "rVData64", "rVData256", "rVData1024", "rVData4000", "rUser", "rFormFilling", "rPreviewFormFilling", "rFormResult", "rFormAnalyzer" ] }
        },
        formTemplate: {
            type: class formTemplate extends Byt.Identity { },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iName", "iFormID", "iUserID", "rFormSys" ] }
        },
        formData: {
            type: class formData extends Byt.Identity {
                getformDataIdentity(f_formField){ return this.getformDataIdentity$1(f_formField.i$access("iVDataValue")); }
                getformDataIdentity$1(f_Value){
                    if(f_Value <= 64)
                        return this.rFormSys.rVData64;
                    if(f_Value <= 256)
                        return this.rFormSys.rVData256;
                    if(f_Value <= 1024)
                        return this.rFormSys.rVData1024;
                    else if(f_Value >= 4000)
                        return this.rFormSys.rVData4000;
                    else 
                        return this.rFormSys.rVData4000;
                }
            },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iFormID", "iRowPK", "iFieldID", "iFieldName", "iCellValue", "iUserID", "rFormSys" ] }
        },
        form: {
            type: class form extends Byt.Identity {
                async load(f_userID){
                    if(!$byCommon.object.verifyRequest.isOk(f_userID, 32) || !this.rFormSys.rUser.confirmUserIsLogin$2(f_userID))
                        return null;
                    
                    return await $byForm.$remote({ kind: "SKILL", NO: 15, target: this, args: [ await this.rFormSys.rUser.rsaEncode(f_userID) ], argTypes: [ Byt.String ], return: [ Byt.Array, [ "by.object.List", Byt.Row ] ] });
                }
                async loadSingle(f_FormID){
                    if(!$byCommon.object.verifyRequest.isOk(f_FormID, 32))
                        return null;
                    
                    return await $byForm.$remote({ kind: "SKILL", NO: 16, target: this, args: [ f_FormID ], argTypes: [ Byt.String ], return: [ Byt.Array, [ "by.object.List", Byt.Row ] ] });
                }
                async loadVDataSingle(f_FormID){
                    if(!$byCommon.object.verifyRequest.isOk(f_FormID, 32))
                        return null;
                    
                    return await $byForm.$remote({ kind: "SKILL", NO: 17, target: this, args: [ f_FormID ], argTypes: [ Byt.String ], return: [ "by.object.List", Byt.Row ] });
                }
                async update(f_list, f_action){
                    if(f_list.count == 0)
                        return new $by.object.Result().$init($ => { $.info = $byForm.object.TextHelper.misssingListData; });
                    let tmpID = [ this, this.rFormSys.rVData1024, this.rFormSys.rVData256, this.rFormSys.rVData4000, this.rFormSys.rVData64 ];
                    if(!$byCommon.object.verifyRowIdentity.isExists(f_list, tmpID))
                        return new $by.object.Result().$init($ => { $.info = $byForm.object.TextHelper.illegalInjection; });
                    
                    return await $byForm.$remote({ kind: "SKILL", NO: 18, target: this, args: [ f_list, f_action ], argTypes: [ [ "by.object.List", Byt.Row ], $by.enum.Action ], return: $by.object.Result });
                }
                vDataToStringArr(f_vDataList, f_fieldName){
                    let tmpDic = this.rowStructureDataToDic(f_vDataList);
                    let tmpResultList = new $by.object.List();
                    for (let item of tmpDic){
                        let tmpArr = Byt.Array.$create(Byt.String, 1, [ ((f_fieldName.length + 1) | 0) ]);
                        tmpArr[0] = item.key;
                        for (let i = 1; i < tmpArr.length; i++){
                            let tmpFieldName = f_fieldName[((i - 1) | 0)];
                            if(item.value.containsKey(tmpFieldName)){ tmpArr[i] = item.value.$get(tmpFieldName).i$access("iCellValue"); }
                        }
                        tmpResultList.add(tmpArr);
                    }
                    return tmpResultList;
                }
                rowStructureDataToDic(f_vDataList){
                    let tmpDic = new $by.object.Dictionary();
                    for (let item of f_vDataList){
                        if(!tmpDic.containsKey(item.i$access("iRowPK"))){ tmpDic.add(item.i$access("iRowPK"), new $by.object.Dictionary()); }
                        tmpDic.$get(item.i$access("iRowPK")).add(item.i$access("iFieldName"), item);
                    }
                    return tmpDic;
                }
                async toVDataDic(f_userID, f_fieldName, f_pkIndex, f_DataList){
                    let tmpDic = new $by.object.Dictionary();
                    for (let item of f_DataList){
                        let tmpPk = item[f_pkIndex];
                        let tmpForDic = new $by.object.Dictionary();
                        tmpDic.add(tmpPk, tmpForDic);
                        for (let i = 0; i < f_fieldName.length; i++){
                            if(item[i] != null){
                                let tmpVData = new $by.object.Row().$bindIdentity(this.rFormSys.rVData256);
                                tmpVData.i$assign("iID", await $byCommon.identity.general.getGuid());
                                tmpVData.i$assign("iUserID", f_userID);
                                tmpVData.i$assign("iFieldName", f_fieldName[i]);
                                tmpVData.i$assign("iCellValue", item[i]);
                                tmpVData.i$assign("iRowPK", item[f_pkIndex]);
                                tmpForDic.add(tmpVData.i$access("iFieldName"), tmpVData);
                            }
                        }
                    }
                    return tmpDic;
                }
                async toVDataDic$1(f_FormID, f_fieldName, f_pkFieldName, f_DataList){
                    let tmpPkIndex = this.getPkIndex(f_fieldName, f_pkFieldName);
                    return await this.toVDataDic(f_FormID, f_fieldName, tmpPkIndex, f_DataList);
                }
                getPkIndex(f_fieldNameArr, f_pkName){
                    let tmpPkIndex = 0;
                    for (let i = 0; i < f_fieldNameArr.length; i++){
                        if(f_fieldNameArr[i] == f_pkName){
                            tmpPkIndex = i;
                            break;
                        }
                    }
                    return tmpPkIndex;
                }
                async saveField(f_formField, action){ await this.rFormSys.rFormField.addUpdate(f_formField, action); }
                async delFieldByFormId(formID){ await this.rFormSys.rFormField.delByFormId(formID); }
                async displayFormData(f_row, f_dataList, f_panel){
                    let titleLabel = new $by.object.Label().$init($ => {
                        $.webWidthFilled = true;
                        $.text = f_row.i$access("iName");
                        $.fontIsBold = true;
                        $.fontSize = 25;
                    });
                    let summaryLabel = new $by.object.Label().$init($ => {
                        $.webWidthFilled = true;
                        $.text = f_row.i$access("iSummary") == null ? "" : f_row.i$access("iSummary");
                    });
                    {
                        f_panel.element.addClass($byForm.object.CssClassNameHelper.resultsPanel);
                        summaryLabel.element.addClass($byForm.object.CssClassNameHelper.resultsSummaryLabel);
                        titleLabel.element.addClass($byForm.object.CssClassNameHelper.resultsTitleLabel);
                    }
                    f_panel.add(titleLabel);
                    if(summaryLabel.text != ""){ f_panel.add(summaryLabel); }
                    let result = await $byForm.$sql({ ["#sql"]: "select", number: 23, args: [ f_row.i$access("iID") ], argTypes: [ Byt.String ], from: { a: this.rFormSys.rFormData } });
                    let resultDict = new $by.object.Dictionary();
                    for (let row of result.rows){
                        if(!resultDict.containsKey(row.i$access("iRowPK"))){ resultDict.add(row.i$access("iRowPK"), new $by.object.List()); }
                        resultDict.$get(row.i$access("iRowPK")).add(row);
                    }
                    for (let rowPK of resultDict.keys){
                        let resultPanel = new $byForm.object.ResultPanel().$init($ => $.$1(resultDict.$get(rowPK)));
                        resultPanel.setHeadInfo(rowPK);
                        f_panel.add(resultPanel);
                    }
                }
                generateFormInstancePanel(f_row, f_fieldList){
                    let formInstancePanel = new $byForm.object.FormInstancePanel().$init($ => $.$1(f_row));
                    this.generateInstanceFields(f_fieldList, formInstancePanel.getContentPanel());
                    return formInstancePanel;
                }
                generateInstanceFields(fieldRows, f_panel){
                    for (let fieldRow of fieldRows){
                        let fieldControl = this.generateInstanceField(fieldRow);
                        f_panel.add(fieldControl);
                    }
                }
                generateInstanceField(fieldRow){
                    switch(fieldRow.i$access("iFieldCtrl")){
                        case "checkBox":
                            { return new $byForm.object.FieldCheckBox().$init($ => $.$1(fieldRow)); }
                        case "checkBoxList":
                            { return new $byForm.object.FieldCheckBoxList().$init($ => $.$1(fieldRow)); }
                        case "dropdownList":
                            { return new $byForm.object.FieldComboBox().$init($ => $.$1(fieldRow)); }
                        case "muiltTextbox":
                            { return new $byForm.object.FieldMultiTextBox().$init($ => $.$1(fieldRow)); }
                        case "radbutton":
                            { return new $byForm.object.FieldRadioButtonGroup().$init($ => $.$1(fieldRow)); }
                        case "slider":
                            { return new $byForm.object.FieldSlider().$init($ => $.$1(fieldRow)); }
                        case "textbox":
                            { return new $byForm.object.FieldTextBox().$init($ => $.$1(fieldRow)); }
                        case "datePicker":
                        case "timePicker":
                        case "dateTimePicker":
                            { return new $byForm.object.FieldDateTimePicker().$init($ => $.$1(fieldRow)); }
                        default:
                            {
                                throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                            }
                    }
                }
                async getFieldDatas(fieldsPanel, row){
                    let resultList = new $by.object.List();
                    let rowPK = await $byCommon.identity.general.getGuid();
                    for (let control of fieldsPanel.children){
                        if(!($byForm.object.FieldControl.$check(control))){
                            throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                        }
                        let fieldControl = $byForm.object.FieldControl.$convert(control);
                        let tmpRow = new $by.object.Row().$bindIdentity(this.rFormSys.rVData64.getformDataIdentity$1(fieldControl.fieldRow.i$access("iVDataValue")));
                        resultList.add(tmpRow);
                        tmpRow.i$assign("iID", await $byCommon.identity.general.getGuid());
                        tmpRow.i$assign("iRowPK", rowPK);
                        tmpRow.i$assign("iFieldName", fieldControl.fieldRow.i$access("iFieldName"));
                        tmpRow.i$assign("iFormID", fieldControl.fieldRow.i$access("iFormID"));
                        tmpRow.i$assign("iUserID", fieldControl.fieldRow.i$access("iUserID"));
                        tmpRow.i$assign("iFieldID", fieldControl.fieldRow.i$access("iID"));
                        switch(fieldControl.fieldRow.i$access("iFieldCtrl")){
                            case "checkBox":
                                {
                                    tmpRow.i$assign("iCellValue", ($byForm.object.FieldCheckBox.$convert(fieldControl)).getValue());
                                    break;
                                }
                            case "checkBoxList":
                                {
                                    tmpRow.i$assign("iCellValue", ($byForm.object.FieldCheckBoxList.$convert(fieldControl)).getValue());
                                    break;
                                }
                            case "dropdownList":
                                {
                                    tmpRow.i$assign("iCellValue", ($byForm.object.FieldComboBox.$convert(fieldControl)).getValue());
                                    break;
                                }
                            case "muiltTextbox":
                                {
                                    tmpRow.i$assign("iCellValue", ($byForm.object.FieldMultiTextBox.$convert(fieldControl)).getValue());
                                    break;
                                }
                            case "radbutton":
                                {
                                    tmpRow.i$assign("iCellValue", ($byForm.object.FieldRadioButtonGroup.$convert(fieldControl)).getValue());
                                    break;
                                }
                            case "slider":
                                {
                                    tmpRow.i$assign("iCellValue", ($byForm.object.FieldSlider.$convert(fieldControl)).getValue());
                                    break;
                                }
                            case "datePicker":
                            case "timePicker":
                            case "dateTimePicker":
                                {
                                    tmpRow.i$assign("iCellValue", ($byForm.object.FieldDateTimePicker.$convert(fieldControl)).getValue());
                                    break;
                                }
                            case "textbox":
                                {
                                    tmpRow.i$assign("iCellValue", ($byForm.object.FieldTextBox.$convert(fieldControl)).getValue());
                                    break;
                                }
                            default:
                                {
                                    throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                                }
                        }
                    }
                    return resultList;
                }
                verifyFieldDatas(fieldsPanel, row){
                    let results = new $by.object.List();
                    for (let control of fieldsPanel.children){
                        if(!($byForm.object.FieldControl.$check(control))){
                            throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                        }
                        let fieldControl = $byForm.object.FieldControl.$convert(control);
                        let result = null;
                        switch(fieldControl.fieldRow.i$access("iFieldCtrl")){
                            case "checkBox":
                                {
                                    result = ($byForm.object.FieldCheckBox.$convert(fieldControl)).verify();
                                    break;
                                }
                            case "checkBoxList":
                                {
                                    result = ($byForm.object.FieldCheckBoxList.$convert(fieldControl)).verify();
                                    break;
                                }
                            case "dropdownList":
                                {
                                    result = ($byForm.object.FieldComboBox.$convert(fieldControl)).verify();
                                    break;
                                }
                            case "muiltTextbox":
                                {
                                    result = ($byForm.object.FieldMultiTextBox.$convert(fieldControl)).verify();
                                    break;
                                }
                            case "radbutton":
                                {
                                    result = ($byForm.object.FieldRadioButtonGroup.$convert(fieldControl)).verify();
                                    break;
                                }
                            case "slider":
                                {
                                    result = ($byForm.object.FieldSlider.$convert(fieldControl)).verify();
                                    break;
                                }
                            case "textbox":
                                {
                                    result = ($byForm.object.FieldTextBox.$convert(fieldControl)).verify();
                                    break;
                                }
                            case "datePicker":
                            case "timePicker":
                            case "dateTimePicker":
                                {
                                    result = ($byForm.object.FieldDateTimePicker.$convert(fieldControl)).verify();
                                    break;
                                }
                            default:
                                {
                                    throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControl));
                                }
                        }
                        result.info = Byt.String((Byt.String(fieldControl.fieldRow.i$access("iFieldNO")) + 1).by$toString()) + " " + Byt.String(fieldControl.fieldRow.i$access("iFieldName")) + "--" + Byt.String(result.info);
                        results.add(result);
                    }
                    for (let result of results){
                        if(result != null){
                            if(!result.isOk){ return result; }
                        }
                    }
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
            },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iName", "iSuccessMsg", "iSubmitButton", "iSummary", "iUserID", "rFormSys", "iCreateDt", "iCurrentModifyDt" ] }
        },
        fieldTemplate: {
            type: class fieldTemplate extends Byt.Identity {
                async getList(){
                    
                    return await $byForm.$remote({ kind: "SKILL", NO: 33, target: this, return: [ "by.object.List", Byt.Row ] });
                }
                async getFieldTemplate(id){
                    let templateList = await this.getList();
                    for (let templateRow of templateList){
                        if(templateRow.i$access("iID") == id){ return templateRow; }
                    }
                    throw Error(new $by.object.Exception($byForm.object.TextHelper.invalidFieldTemplateID));
                }
            },
            base: { inherit: "byBase.identity.dic" },
            instance: { components: [ "iID", "iName", "iSummary", "iCtrType", "iIco", "iMin", "iMax", "iDefault", "iReg", "iRegMsg", "iCreateDt", "rFormSys", "rUser" ], props: { pList: [ "by.object.List", Byt.Row ] } }
        }
    },
    dialog: {
        form$manage: {
            type: class manage extends Byt.Dialog {
                async $1(f_formRow){
                    this.cFormPanel.$init($ => { $.scrollable = false; });
                    this.cFormNamePanel.$init($ => { $.scrollable = false; });
                    this.cFormNameValueLabel.$init($ => { $.toolTip = $byForm.object.TextHelper.formNameEditTip; });
                    this.cFieldPanel.$init($ => { $.paddingBottom = $byForm.object.ValueHelper.cFieldPanelPaddingBottom; });
                    this.saveButton.$init($ => { $.text = $byForm.object.TextHelper.saveForm; });
                    this.previewButton.$init($ => { $.text = $byForm.object.TextHelper.preview; });
                    this.publishButton.$init($ => { $.text = $byForm.object.TextHelper.publish; });
                    this.editorManager = new $byForm.object.EditorManager().$init($ => $.$0());
                    this.isModified = false;
                    this.cFieldInfos = new $by.object.List();
                    this.isFullscreen = true;
                    this.mainPanel.add(this.formManage);
                    this.mainPanel.add(this.buttonContainer);
                    this.formManage.add(this.cFieldTemplatePanel);
                    this.formManage.add(this.cFormPanel);
                    this.formManage.add(this.cDetailPanel);
                    this.cFormPanel.add(this.cFormNamePanel);
                    this.cFormPanel.add(this.cFieldPanel);
                    this.cFormNameValueLabel.text = $byForm.object.Common.isEmptyString(f_formRow.i$access("iName")) ? $byForm.object.TextHelper.defaultFormName : f_formRow.i$access("iName");
                    this.cFormNamePanel.add(this.cFormNameValueLabel);
                    this.buttonContainer.add(this.previewButton);
                    this.buttonContainer.add(this.saveButton);
                    this.buttonContainer.add(this.publishButton);
                    this.setFieldControlEditor(null);
                    this.setFormNameEditor(null);
                    this.formManage.scrollable = false;
                    {
                        this.mainPanel.webStyle = "height:100%;width:100%;min-width:800px;min-height:600px";
                        this.mainPanel.element.children[0].style.setProperty("height", "100%");
                        this.formManage.webStyle = "height:90%;width:100%";
                        this.formManage.element.children[0].style.setProperty("height", "100%");
                        this.cFieldTemplatePanel.webStyle = "float:left;width:18%;height:100%;";
                        this.cFormPanel.webStyle = "float:left;width:45%;height:100%";
                        this.cDetailPanel.webStyle = "float:right;width:30%;height=100%;";
                        this.cFieldPanel.webStyle = "width:100%;height:100%;";
                        this.cFormNamePanel.webStyle = "width:100%;";
                        this.cFormPanel.element.children[0].style.setProperty("height", "90%");
                        this.element.addClass($byForm.object.CssClassNameHelper.formManageDialog);
                        this.formManage.element.addClass($byForm.object.CssClassNameHelper.formManagePanel);
                        this.cFormPanel.element.addClass($byForm.object.CssClassNameHelper.formPanel);
                        this.cFormNamePanel.element.addClass($byForm.object.CssClassNameHelper.formNamePanel);
                        this.cFormNameValueLabel.element.addClass($byForm.object.CssClassNameHelper.formNameValueLabel);
                        this.cFieldPanel.element.addClass($byForm.object.CssClassNameHelper.formFieldContainer);
                        this.cFieldTemplatePanel.element.addClass($byForm.object.CssClassNameHelper.formFieldTemplateContainer);
                        this.cDetailPanel.element.addClass($byForm.object.CssClassNameHelper.formFieldDetailContainer);
                        this.buttonContainer.element.addClass($byForm.object.CssClassNameHelper.formButtonContainer);
                        this.saveButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSaveButton);
                        this.previewButton.element.addClass($byForm.object.CssClassNameHelper.formPreviewButton);
                        this.publishButton.element.addClass($byForm.object.CssClassNameHelper.formPublishButton);
                    }
                    this.formRow = f_formRow;
                    let tmpFieldTemplateRow = null;
                    for (let item of await this.$identity().rFormSys.rFieldTemplate.getList()){
                        let tmpLabel = new $by.object.Label().$init($ => {
                            $.text = item.i$access("iSummary");
                            $.tag = item;
                            $.allowDrop = true;
                            $.image = $by.object.Ku.getKu("byForm").getResource(item.i$access("iIco")).toImage();
                        });
                        {
                            tmpLabel.element.addClass($byForm.object.CssClassNameHelper.generalFieldTemplateLabel);
                            tmpLabel.element.children[0].addClass($byForm.object.CssClassNameHelper.generalFieldTemplateInnerLabel);
                            tmpLabel.webWidthFilled = true;
                        }
                        this.cFieldTemplatePanel.add(tmpLabel);
                        tmpLabel.allowDrag = true;
                        tmpLabel.toolTip = $byForm.object.TextHelper.draggableTip;
                        tmpLabel.dragStart.$add(this.$access("onTemplateLabelDragStart"));
                    }
                    this.cFieldPanel.allowDrop = true;
                    this.cFieldPanel.dragDrop.$add(this.$access("onTemplateLabelDragDrop"));
                    this.cFieldPanel.dragDrop.$add(this.$access("onFieldPanelTermDragDrop"));
                    this.saveButton.click.$add(this.$access("onSaveButtonClick"));
                    this.previewButton.click.$add(this.$access("onPreviewButtonClick"));
                    this.publishButton.click.$add(this.$access("onPublishButtonClick"));
                    this.modified.$add(() => { this.isModified = true; });
                    this.cFormNamePanel.click.$add(async (sender, args) => { await this.formNameClick.$invoke(this, args); });
                    this.cFormNameValueLabel.click.$add(async (sender, args) => { await this.formNameClick.$invoke(this, args); });
                    this.formNameClick.$add(this.$access("onFormNameClick"));
                    let fieldQueryResult = await $byForm.$sql({ ["#sql"]: "select", number: 26, args: [ f_formRow.i$access("iID") ], argTypes: [ Byt.String ], from: { a: this.$identity().rFormSys.rFormField } });
                    for (let fieldRow of fieldQueryResult.rows){ this.cFieldInfos.add(fieldRow); }
                    await this.reloadFromChildrenList();
                    this.dialogClosing.$add(async (sender, args) => {
                        if(!this.isModified){ return; }
                        let saveDialog = await $byForm.dialog.form$querySaveDialog.$new(this.$identity(), $ => $.$0());
                        saveDialog.saveButtonClick.$add(async (sender2, args2) => {
                            if(!await this.requireLogin()){
                                await $by.object.Message.alert($byForm.object.TextHelper.pleaseLogIn);
                                return;
                            }
                            let saveResult = await this.save();
                            if(!saveResult.isOk){
                                await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.remainError) + Byt.String(saveResult.info));
                                args.cancel = true;
                                return;
                            }
                            saveDialog.close();
                        });
                        saveDialog.notSaveButtonClick.$add((sender2, args2) => { saveDialog.close(); });
                        saveDialog.cancelButtonClick.$add((sender2, args2) => {
                            args.cancel = true;
                            saveDialog.close();
                        });
                        await saveDialog.showDialog();
                    });
                    await this.openFormNameEditor();
                }
                injectInfoPanel(targetPanel){ targetPanel.add(this.mainPanel); }
                async checkLogin(){
                    if(!await this.$identity().rFormSys.rUser.confirmUserIsLogin()){
                        await $by.object.Message.alert($byForm.object.TextHelper.notLoggedIn);
                        return false;
                    }
                    return true;
                }
                async createFieldInfo(fieldTemplateRow){
                    let fieldRow = new $by.object.Row().$bindIdentity(this.$identity().rFormSys.rFormField);
                    fieldRow.i$assign("iFieldCtrl", fieldTemplateRow.i$access("iCtrType"));
                    fieldRow.i$assign("iID", await $byCommon.identity.general.getGuid());
                    fieldRow.i$assign("iFormID", this.formRow.i$access("iID"));
                    fieldRow.i$assign("iFieldName", fieldTemplateRow.i$access("iSummary"));
                    fieldRow.i$assign("iSummary", fieldTemplateRow.i$access("iSummary"));
                    fieldRow.i$assign("iFieldReg", fieldTemplateRow.i$access("iReg"));
                    fieldRow.i$assign("iFieldRegMsg", fieldTemplateRow.i$access("iRegMsg"));
                    fieldRow.i$assign("iUserID", this.formRow.i$access("iUserID"));
                    fieldRow.i$assign("iFieldDefault", fieldTemplateRow.i$access("iDefault"));
                    fieldRow.i$assign("iFieldMin", 0);
                    fieldRow.i$assign("iFieldMax", 64);
                    fieldRow.i$assign("iFieldType", "string");
                    fieldRow.i$assign("iNotNull", true);
                    fieldRow = $byForm.object.FieldTermPanel.generateControlField(fieldRow);
                    return fieldRow;
                }
                async createField(fieldTemplateRow){
                    let fieldRow = await this.createFieldInfo(fieldTemplateRow);
                    return await this.rebuildField(fieldRow);
                }
                async rebuildField(row){
                    let fieldTermPanel = new $byForm.object.FieldTermPanel().$init($ => $.$1(row, false));
                    fieldTermPanel.dragStart.$add(this.$access("onFieldPanelTermDragStart"));
                    fieldTermPanel.dragDrop.$add(this.$access("onFieldPanelTermDragDrop"));
                    fieldTermPanel.dragDrop.$add(this.$access("onTemplateLabelDragDrop"));
                    fieldTermPanel.generalClick.$add(this.$access("onFieldClick"));
                    fieldTermPanel.deleteButtonClick.$add(this.$access("onFieldDelete"));
                    await this.modified.$invoke();
                    return fieldTermPanel;
                }
                async fillVDataGrid(f_rowForm){
                    let tmpVdataList = await this.$identity().loadVDataSingle(f_rowForm.i$access("iID"));
                    {
                        let tmpDiv = $by.object.System.currentDocument.createElement("div");
                    }
                }
                onTemplateLabelDragStart(sender, args){
                    if(!($by.object.Label.$check(sender))){
                        throw Error(new $by.object.Exception($byForm.object.TextHelper.labelEventError));
                    }
                    let tmpLabel = $by.object.Label.$convert(sender);
                    if(!(Byt.Row.$check(tmpLabel.tag, $byForm.identity.fieldTemplate))){
                        throw Error(new $by.object.Exception($byForm.object.TextHelper.templateLabelRowLossError));
                    }
                    let rowFieldTemplate = Byt.Row.$convert(tmpLabel.tag, $byForm.identity.fieldTemplate);
                    args.data.setData($byForm.object.NameHelper.draggingItemType, "termLabel".by$toString());
                    args.data.setData($byForm.object.NameHelper.fieldTemplateID, rowFieldTemplate.i$access("iID"));
                }
                async onTemplateLabelDragDrop(sender, args){
                    if(args.data.getData($byForm.object.NameHelper.draggingItemType) != "termLabel".by$toString()){ return; }
                    let fieldTemplateId = args.data.getData($byForm.object.NameHelper.fieldTemplateID);
                    if(fieldTemplateId == null){
                        throw Error(new $by.object.Exception($byForm.object.TextHelper.fieldCreatedLossError));
                    }
                    let templateRow = await this.$identity().rFormSys.rFieldTemplate.getFieldTemplate(fieldTemplateId);
                    let fieldInfo = await this.createFieldInfo(templateRow);
                    if($byForm.object.FieldTermPanel.$check(sender)){
                        this.cFieldInfos.insert($by.object.Int.parse(($byForm.object.FieldTermPanel.$convert(sender)).fieldInfo.i$access("iFieldNO")), fieldInfo);
                        await this.reloadFromChildrenList();
                    }
                    else {
                        this.cFieldInfos.add(fieldInfo);
                        this.reorderChildrenList();
                        this.cFieldPanel.add(await this.rebuildField(fieldInfo));
                    }
                }
                onFieldPanelTermDragStart(sender, args){
                    args.data.setData($byForm.object.NameHelper.draggingItemType, "termPanel".by$toString());
                    args.data.setData($byForm.object.NameHelper.draggingItemOrder, ($byForm.object.FieldTermPanel.$convert(sender)).fieldInfo.i$access("iFieldNO").by$toString());
                    args.data.setData($byForm.object.NameHelper.screenY, args.screenY.by$toString());
                }
                async onFieldPanelTermDragDrop(sender, args){
                    if(args.data.getData($byForm.object.NameHelper.draggingItemType) != "termPanel".by$toString()){ return; }
                    let newRelativeY = ((((this.cFieldPanel.children.$get($by.object.Int.parse(args.data.getData($byForm.object.NameHelper.draggingItemOrder))).top + args.screenY) | 0) - $by.object.Int.parse(args.data.getData($byForm.object.NameHelper.screenY))) | 0);
                    let newOrderId = this.getTermOrderAtPoint(newRelativeY);
                    await this.setTermMove(args.data.getData($byForm.object.NameHelper.draggingItemOrder), newOrderId);
                }
                async onFieldClick(sender, args){
                    let saveResult = await this.saveModifyOfEditor();
                    if(!saveResult.isOk){
                        await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.remainError) + Byt.String(saveResult.info));
                        return;
                    }
                    this.cDetailPanel.clear();
                    this.setFormNameEditor(null);
                    this.setFieldControlEditor(await $byForm.object.FieldControlEditor.getEditor(($byForm.object.FieldTermPanel.$convert(sender)).fieldInfo));
                    this.getFieldControlEditor().saveButtonClick.$add(this.$access("onDetailSaveButtonClick"));
                    this.getFieldControlEditor().cancelButtonClick.$add(this.$access("onDetailCancelButtonClick"));
                    this.cDetailPanel.add(this.getFieldControlEditor());
                    await this.modified.$invoke();
                }
                async onFieldDelete(sender, args){
                    let fieldTermPanel = $byForm.object.FieldTermPanel.$convert(sender);
                    let fieldNO = $by.object.Int.parse(fieldTermPanel.fieldInfo.i$access("iFieldNO"));
                    if(this.editorManager.fieldControlEditor != null){
                        if(this.editorManager.fieldControlEditor.fieldInfo.i$access("iID") == fieldTermPanel.fieldInfo.i$access("iID")){
                            let deleteDialog = await $byForm.dialog.form$queryDeleteDialog.$new(this.$identity(), $ => $.$0());
                            deleteDialog.deleteButtonClick.$add(async (sender2, args2) => {
                                deleteDialog.close();
                                this.cFieldInfos.removeAt(fieldNO);
                                await this.reloadFromChildrenList();
                                this.cDetailPanel.clear();
                            });
                            deleteDialog.cancelButtonClick.$add((sender2, args2) => { deleteDialog.close(); });
                            await deleteDialog.showDialog();
                            return;
                        }
                    }
                    this.cFieldInfos.removeAt(fieldNO);
                    await this.reloadFromChildrenList();
                    await this.modified.$invoke();
                }
                async onDetailSaveButtonClick(sender, args){
                    let saveResult = await this.saveModifyOfFieldEditor(this.getFieldControlEditor());
                    if(saveResult.isOk){ await $by.object.Message.alert($byForm.object.TextHelper.saveSuccess); }
                    else { await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.saveFail) + Byt.String(saveResult.info)); }
                }
                async onDetailCancelButtonClick(sender, args){
                    let querySaveDialog = await $byForm.dialog.form$querySaveDialog.$new(this.$identity(), $ => $.$0());
                    querySaveDialog.cancelButtonClick.$add((sender2, args2) => { querySaveDialog.close(); });
                    querySaveDialog.saveButtonClick.$add(async (sender2, args2) => {
                        this.getFieldControlEditor().remove();
                        this.setFieldControlEditor(null);
                        await this.onDetailSaveButtonClick(this, args2);
                        querySaveDialog.close();
                    });
                    querySaveDialog.notSaveButtonClick.$add((sender2, args2) => {
                        this.getFieldControlEditor().remove();
                        this.setFieldControlEditor(null);
                        querySaveDialog.close();
                    });
                    await querySaveDialog.showDialog();
                }
                async saveModifyOfFieldEditor(controlEditor){
                    if(controlEditor == null){ return new $by.object.Result().$init($ => { $.isOk = true; }); }
                    let result = null;
                    switch(controlEditor.fieldInfo.i$access("iFieldCtrl")){
                        case "slider":
                            {
                                result = await ($byForm.object.FieldSliderEditor.$convert(controlEditor)).refreshFieldInfo();
                                break;
                            }
                        case "checkBoxList":
                            {
                                result = await ($byForm.object.FieldCheckBoxListEditor.$convert(controlEditor)).refreshFieldInfo();
                                break;
                            }
                        case "textbox":
                            {
                                result = await ($byForm.object.FieldTextBoxEditor.$convert(controlEditor)).refreshFieldInfo();
                                break;
                            }
                        case "muiltTextbox":
                            {
                                result = await ($byForm.object.FieldMultiTextBoxEditor.$convert(controlEditor)).refreshFieldInfo();
                                break;
                            }
                        default:
                            {
                                result = await controlEditor.refreshFieldInfo();
                                break;
                            }
                    }
                    if(!result.isOk){ return result; }
                    for (let fieldNO = 0; fieldNO < this.cFieldInfos.count; fieldNO++){
                        if(this.cFieldInfos.$get(fieldNO).i$access("iID") == controlEditor.fieldInfo.i$access("iID")){ this.cFieldInfos.$set(fieldNO, controlEditor.fieldInfo); }
                    }
                    await this.reloadFromChildrenList();
                    return result;
                }
                async saveModifyOfFormNameEditor(formNameEditor){
                    if(formNameEditor == null){ return new $by.object.Result().$init($ => { $.isOk = true; }); }
                    let tempName = formNameEditor.getEditFormName();
                    if(tempName == null || tempName.by$lTrim() == ""){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.TextHelper.formNameNull;
                    }); }
                    if(tempName.length > $byForm.object.ValueHelper.generalTextMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError($byForm.object.TextHelper.formName, $byForm.object.ValueHelper.generalTextMax);
                    }); }
                    if(formNameEditor.getEditFormSummary().length > $byForm.object.ValueHelper.generalTextMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError($byForm.object.TextHelper.formSummary, $byForm.object.ValueHelper.generalTextMax);
                    }); }
                    if(formNameEditor.getEditFormSuccessMsg().length > $byForm.object.ValueHelper.generalTextMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError($byForm.object.TextHelper.successMessage, $byForm.object.ValueHelper.generalTextMax);
                    }); }
                    if(formNameEditor.getEditFormSubmitButtonText().length > $byForm.object.ValueHelper.generalTextMax){ return new $by.object.Result().$init($ => {
                        $.isOk = false;
                        $.info = $byForm.object.Common.getLengthMaxError($byForm.object.TextHelper.submitButtonText, $byForm.object.ValueHelper.generalTextMax);
                    }); }
                    this.formRow.i$assign("iName", formNameEditor.getEditFormName());
                    this.formRow.i$assign("iSummary", formNameEditor.getEditFormSummary());
                    this.formRow.i$assign("iSuccessMsg", formNameEditor.getEditFormSuccessMsg());
                    this.formRow.i$assign("iSubmitButton", formNameEditor.getEditFormSubmitButtonText());
                    this.cFormNameValueLabel.text = this.formRow.i$access("iName");
                    await this.modified.$invoke();
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                async saveModifyOfEditor(){
                    let fieldSaveResult = await this.saveModifyOfFieldEditor(this.getFieldControlEditor());
                    if(!fieldSaveResult.isOk){ return fieldSaveResult; }
                    let formNameSaveResult = await this.saveModifyOfFormNameEditor(this.getFormNameEditor());
                    if(!formNameSaveResult.isOk){ return formNameSaveResult; }
                    await this.modified.$invoke();
                    return new $by.object.Result().$init($ => { $.isOk = true; });
                }
                async onSaveButtonClick(sender, args){
                    if(!await this.requireLogin()){
                        await $by.object.Message.alert($byForm.object.TextHelper.pleaseLogIn);
                        return;
                    }
                    let saveResult = await this.save();
                    if(!saveResult.isOk){
                        await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.remainError) + Byt.String(saveResult.info));
                        return;
                    }
                    let exitDialog = await $byForm.dialog.form$queryExitDialog.$new(this.$identity(), $ => $.$0());
                    exitDialog.exitButtonClick.$add((sender2, args2) => {
                        exitDialog.close();
                        this.close();
                    });
                    exitDialog.cancelButtonClick.$add((sender2, args2) => { exitDialog.close(); });
                    await exitDialog.showDialog();
                }
                async onPreviewButtonClick(sender, args){
                    if(!await this.requireLogin()){
                        await $by.object.Message.alert($byForm.object.TextHelper.pleaseLogIn);
                        return;
                    }
                    let saveResult = await this.save();
                    if(!saveResult.isOk){
                        await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.remainError) + Byt.String(saveResult.info));
                        return;
                    }
                    {
                        this.$identity().rFormSys.rPreviewFormFilling.isPreview = true;
                        $by.identity.Page.open(this.$identity().rFormSys.rPreviewFormFilling, "formID=" + Byt.String(this.formRow.i$access("iID").by$toString()));
                    }
                }
                async onPublishButtonClick(sender, args){
                    if(!await this.requireLogin()){
                        await $by.object.Message.alert($byForm.object.TextHelper.pleaseLogIn);
                        return;
                    }
                    let saveResult = await this.save();
                    if(!saveResult.isOk){
                        await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.remainError) + Byt.String(saveResult.info));
                        return;
                    }
                    {
                        let publishDialog = await $byForm.dialog.form$publishDialog.$new(this.$identity(), $ => $.$1(this.formRow));
                        publishDialog.show();
                        this.$identity().rFormSys.rFormFilling.isPreview = false;
                    }
                }
                async requireLogin(){
                    if(await this.$identity().rFormSys.rUser.confirmUserIsLogin()){
                        if(this.formRow.i$access("iUserID") == null || this.formRow.i$access("iUserID") == ""){
                            this.formRow.i$assign("iUserID", this.$identity().rFormSys.rUser.pSession.a.i$access("iID"));
                            await $byForm.$sql({ ["#sql"]: "row", number: 24, args: [ this.formRow ], argTypes: [ Byt.Row ] });
                            await this.insertFormRow.$invoke(this, new $by.object.EventArgs());
                        }
                        return true;
                    }
                    return false;
                }
                async save(){
                    if(this.$identity().rFormSys.rUser.pSession != null){
                        this.formRow.i$assign("iUserID", this.$identity().rFormSys.rUser.pSession.a.i$access("iID"));
                        for (let fieldRow of this.cFieldInfos){ fieldRow.i$assign("iUserID", this.$identity().rFormSys.rUser.pSession.a.i$access("iID")); }
                    }
                    let saveResult = await this.saveModifyOfEditor();
                    if(!saveResult.isOk){ return saveResult; }
                    try{
                        this.formRow.i$assign("iCurrentModifyDt", $by.object.DateTime.getNow());
                        await $byForm.$sql({ ["#sql"]: "row", number: 25, args: [ this.formRow ], argTypes: [ Byt.Row ] });
                        await this.$identity().delFieldByFormId(this.formRow.i$access("iID"));
                        for (let fieldInfo of this.cFieldInfos){ await this.$identity().saveField(fieldInfo, "insert"); }
                        this.isModified = false;
                        return new $by.object.Result().$init($ => { $.isOk = true; });
                    }
                    catch(e$){
                        if($by.object.Exception.$check(e$)){
                            let e = $by.object.Exception.$convert(e$);
                            throw Error(new $by.object.Exception(Byt.String($byForm.object.TextHelper.saveFormFailed) + Byt.String(e.message)));
                        }
                    }
                }
                async saveAs(){
                    let saveResult = await this.saveModifyOfEditor();
                    if(!saveResult.isOk){ return saveResult; }
                    try{
                        this.formRow.i$assign("iID", await $byCommon.identity.general.getGuid());
                        this.formRow.i$assign("iCurrentModifyDt", $by.object.DateTime.getNow());
                        for (let fieldInfo of this.cFieldInfos){
                            let orginFieldID = fieldInfo.i$access("iID");
                            fieldInfo.i$assign("iID", await $byCommon.identity.general.getGuid());
                            await this.$identity().saveField(fieldInfo, "insert");
                            if(this.getFieldControlEditor() != null){
                                if(this.getFieldControlEditor().fieldInfo.i$access("iID") == orginFieldID){ this.getFieldControlEditor().fieldInfo.i$assign("iID", fieldInfo.i$access("iID")); }
                            }
                        }
                        this.isModified = false;
                        return new $by.object.Result().$init($ => { $.isOk = true; });
                    }
                    catch(e$){
                        if($by.object.Exception.$check(e$)){
                            let e = $by.object.Exception.$convert(e$);
                            throw Error(new $by.object.Exception(Byt.String($byForm.object.TextHelper.saveFormFailed) + Byt.String(e.message)));
                        }
                    }
                }
                async onFormNameClick(sender, args){ await this.openFormNameEditor(); }
                async openFormNameEditor(){
                    let saveResult = await this.saveModifyOfEditor();
                    if(!saveResult.isOk){
                        await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.remainError) + Byt.String(saveResult.info));
                        return;
                    }
                    this.setFieldControlEditor(null);
                    this.setFormNameEditor(await new $byForm.object.FormNameEditor().$init($ => $.$1(this.formRow)));
                    this.cDetailPanel.clear();
                    this.cDetailPanel.add(this.getFormNameEditor());
                    this.getFormNameEditor().saveButtonClick.$add(this.$access("onNameSaveButtonClick"));
                    this.getFormNameEditor().cancelButtonClick.$add(this.$access("onNameCancelButtonClick"));
                    await this.modified.$invoke();
                }
                async onNameSaveButtonClick(sender, args){
                    let saveResult = await this.saveModifyOfFormNameEditor(this.getFormNameEditor());
                    if(saveResult.isOk){ await $by.object.Message.alert($byForm.object.TextHelper.saveSuccess); }
                    else { await $by.object.Message.alert(Byt.String($byForm.object.TextHelper.saveFail) + Byt.String(saveResult.info)); }
                }
                onNameCancelButtonClick(sender, args){
                    this.getFormNameEditor().remove();
                    this.setFormNameEditor(null);
                }
                getTermOrderAtPoint(relativeLocationY){
                    if(this.cFieldPanel.children.count == 0){
                        throw Error(new $by.object.Exception($byForm.object.TextHelper.emptyFieldPanel));
                    }
                    let calculatedTermCount = 0;
                    for (let termPanel of this.cFieldPanel.children){
                        if(!($by.object.Panel.$check(termPanel))){
                            throw Error(new $by.object.Exception($byForm.object.TextHelper.unexpectedControlInFieldPanel));
                        }
                        if(((termPanel.top + termPanel.height) | 0) > relativeLocationY){ return ($byForm.object.FieldTermPanel.$convert(termPanel)).fieldInfo.i$access("iFieldNO"); }
                    }
                    return this.cFieldInfos.count.by$toString();
                }
                async setTermMove(originOrder, newOrder){
                    let tmpFieldRow = null;
                    for (let fieldInfo of this.cFieldInfos){
                        if(fieldInfo.i$access("iFieldNO") == originOrder){
                            tmpFieldRow = fieldInfo;
                            this.cFieldInfos.remove(fieldInfo);
                        }
                    }
                    this.cFieldInfos.insert($by.object.Int.parse(newOrder), tmpFieldRow);
                    await this.reloadFromChildrenList();
                }
                async reloadFromChildrenList(){
                    this.reorderChildrenList();
                    this.cFieldPanel.clear();
                    for (let fieldInfo of this.cFieldInfos){ this.cFieldPanel.add(await this.rebuildField(fieldInfo)); }
                }
                reorderChildrenList(){
                    let fieldTermPanelCount = 0;
                    for (let fieldInfo of this.cFieldInfos){
                        fieldInfo.i$assign("iFieldNO", fieldTermPanelCount.by$toString());
                        fieldTermPanelCount++;
                    }
                }
                getFieldControlEditor(){ return this.editorManager.fieldControlEditor; }
                setFieldControlEditor(fieldControlEditor){ this.editorManager.fieldControlEditor = fieldControlEditor; }
                getFormNameEditor(){ return this.editorManager.formNameEditor; }
                setFormNameEditor(formNameEditor){ this.editorManager.formNameEditor = formNameEditor; }
            },
            instance: { props: { formRow: Byt.Row, editorManager: "byForm.object.EditorManager", isModified: Byt.Bool, cFieldInfos: [ "by.object.List", Byt.Row ] }, events: [ "formNameClick", "saveButtonClick", "modified", "insertFormRow" ] },
            dialog: { props: { mainPanel: $by.object.Panel, formManage: $by.object.Panel, cFieldTemplatePanel: $by.object.Panel, cFormPanel: $by.object.Panel, cFormNamePanel: $by.object.Panel, cFormNameValueLabel: $by.object.Label, cFieldPanel: $by.object.Panel, cDetailPanel: $by.object.Panel, buttonContainer: $by.object.Panel, saveButton: $by.object.Button, previewButton: $by.object.Button, publishButton: $by.object.Button } }
        },
        form$formsManager: {
            type: class formsManager extends Byt.Dialog {
                $0(){
                    this.formListLabel.$init($ => { $.text = $byForm.object.TextHelper.formListLabelText; });
                    this.createFormButton.$init($ => { $.text = $byForm.object.TextHelper.createFormButtonText; });
                    {
                        this.webStyle = "min-width:750px;min-height:550px";
                        this.mainPanel.webStyle = "min-width:700px;min-height:450px;width:100%;height:100%";
                        this.mainPanel.element.children[0].style.setProperty("height", "100%");
                        this.operateArea.element.addClass($byForm.object.CssClassNameHelper.formsManagerOperateArea);
                        this.displayArea.element.addClass($byForm.object.CssClassNameHelper.formsManagerDisplayArea);
                        this.formListLabel.element.addClass($byForm.object.CssClassNameHelper.formsManagerFormListLabel);
                        this.formListPanel.element.addClass($byForm.object.CssClassNameHelper.formsManagerFormListPanel);
                        this.createFormButton.element.addClass($byForm.object.CssClassNameHelper.formsManagerCreateFormButton);
                        this.formsHeader.element.addClass($byForm.object.CssClassNameHelper.formsManagerFormsHeader);
                        this.formListLabel.fontSize = $byForm.object.ValueHelper.formListLabelFontSize;
                    }
                    this.$identity().rFormSys.rUser.pVerifyMode = "session";
                    this.$identity().rFormSys.rUser.loginSuccessEvent.$add(this.$access("onUserLoginSuccess"));
                    this.$identity().rFormSys.rUser.userExitEvent.$add(this.$access("onUserExit"));
                    this.createFormButton.click.$add(this.$access("onCreateFormButtonClick"));
                    this.mainPanel.add(this.operateArea);
                    this.mainPanel.add(this.displayArea);
                    this.displayArea.add(this.formsHeader);
                    this.displayArea.add(this.formListPanel);
                    this.operateArea.add(this.createFormButton);
                    this.formsHeader.add(this.formListLabel);
                    this.isFullscreen = true;
                }
                async initShowManage(){
                    let trialWaiting = await $byCommon.identity.relatedDialog.Loading();
                    let tmpFormRow = await this.createFormRow();
                    let formManage = await $byForm.dialog.form$manage.$new(this.$identity(), $ => $.$1(tmpFormRow));
                    formManage.show();
                    trialWaiting.close();
                }
                async showManageFromTemplate(templateID){
                    let trialWaiting = await $byCommon.identity.relatedDialog.Loading();
                    let templateQueryResult = await $byForm.$sql({ ["#sql"]: "select", number: 27, args: [ templateID ], argTypes: [ Byt.String ], from: { a: this.$identity().rFormSys.rFormTemplate } });
                    let formTemplate = templateQueryResult.rows.$get(0);
                    if(formTemplate == null){ await $by.object.Message.alert($byForm.object.TextHelper.formTemplateNotFound); }
                    let formQueryResult = await $byForm.$sql({ ["#sql"]: "select", number: 28, args: [ formTemplate.i$access("iFormID") ], argTypes: [ Byt.String ], from: { b: this.$identity().rFormSys.rForm } });
                    let formRow = formQueryResult.rows.$get(0);
                    if(formRow == null){ await $by.object.Message.alert($byForm.object.TextHelper.formNotFound); }
                    let formManage = await $byForm.dialog.form$manage.$new(this.$identity(), $ => $.$1(formRow));
                    formManage.formRow.i$assign("iID", await $byCommon.identity.general.getGuid());
                    for (let formField of formManage.cFieldInfos){
                        formField.i$assign("iFormID", formManage.formRow.i$access("iID"));
                        formField.i$assign("iID", await $byCommon.identity.general.getGuid());
                    }
                    await formManage.reloadFromChildrenList();
                    formManage.show();
                    trialWaiting.close();
                }
                setParent(targetPanel){ targetPanel.add(this.mainPanel); }
                async onUserLoginSuccess(f_userRow){
                    if(!this.$identity().rFormSys.rUser.confirmUserIsLogin$2(f_userRow.a.i$access("iID"))){
                        await $by.object.Message.alert($byForm.object.TextHelper.notLoggedIn);
                        return;
                    }
                    await this.RefreshFormListPanel();
                }
                onUserExit(f_userRow){ this.formListPanel.clear(); }
                async RefreshFormListPanel(){
                    this.formListPanel.clear();
                    let formListResult = await $byForm.$sql({ ["#sql"]: "select", number: 29, args: [ this.$identity().rFormSys.rUser.pSession.a.i$access("iID") ], argTypes: [ Byt.String ], from: { r: this.$identity() } });
                    for (let row of formListResult.rows){ this.formListPanel.add(this.createFormItem(row)); }
                }
                createFormItem(row){
                    let formItem = new $byForm.object.FormItem().$bindIdentity(Byt.Identity(row)).$init($ => $.$1(row));
                    formItem.editButtonClick.$add(this.$access("onEditButtonClick"));
                    formItem.sendButtonClick.$add(this.$access("onSendButtonClick"));
                    formItem.delButtonClick.$add(this.$access("onDeleteButtonClick"));
                    formItem.resultButtonClick.$add(this.$access("onResultButtonClick"));
                    formItem.statisticsButtonClick.$add(this.$access("onStatisticsButtonClick"));
                    return formItem;
                }
                async onEditButtonClick(sender, args){
                    let row = ($byForm.object.FormItem.$convert(sender, $byForm.identity.form)).relativeRow;
                    let formManage = await $byForm.dialog.form$manage.$new(this.$identity(), $ => $.$1(row));
                    formManage.show();
                }
                async onSendButtonClick(sender, args){
                    {
                        let publishDialog = await $byForm.dialog.form$publishDialog.$new(this.$identity(), $ => $.$1(($byForm.object.FormItem.$convert(sender, $byForm.identity.form)).relativeRow));
                        publishDialog.show();
                        this.$identity().rFormSys.rFormFilling.isPreview = false;
                    }
                }
                async onDeleteButtonClick(sender, args){
                    let queryDialog = await $byForm.dialog.form$queryDeleteDialog.$new(this.$identity(), $ => $.$0());
                    let row = ($byForm.object.FormItem.$convert(sender, $byForm.identity.form)).relativeRow;
                    queryDialog.setText($byForm.object.TextHelper.queryDeleteForm.by$replace("{0}", row.i$access("iName")));
                    queryDialog.cancelButtonClick.$add((sender2, args2) => { queryDialog.close(); });
                    queryDialog.deleteButtonClick.$add(async (sender2, args2) => {
                        queryDialog.close();
                        try{ await $byForm.$tran({ NO: 1, args: [ ], argTypes: [ ], sqls: [ { ["#sql"]: "delete", number: 30, args: [ row.i$access("iID") ], argTypes: [ Byt.String ], from: this.$identity().rFormSys.rFormData }, { ["#sql"]: "delete", number: 31, args: [ row.i$access("iID") ], argTypes: [ Byt.String ], from: this.$identity().rFormSys.rFormField }, { ["#sql"]: "row", number: 32, args: [ row ], argTypes: [ Byt.Row ] } ] }); }
                        catch(errorInfo){
                            errorInfo = errorInfo.message;
                            await $by.object.Message.alert(errorInfo);
                            return;
                        }
                        await this.RefreshFormListPanel();
                    });
                    await queryDialog.showDialog();
                }
                onResultButtonClick(sender, args){
                    let row = ($byForm.object.FormItem.$convert(sender, $byForm.identity.form)).relativeRow;
                    { $by.identity.Page.open(this.$identity().rFormSys.rFormResult, "formID=" + Byt.String(row.i$access("iID"))); }
                }
                onStatisticsButtonClick(sender, args){
                    let row = ($byForm.object.FormItem.$convert(sender, $byForm.identity.form)).relativeRow;
                    { $by.identity.Page.open(this.$identity().rFormSys.rFormAnalyzer, "formID=" + Byt.String(row.i$access("iID"))); }
                }
                async createNewForm(){
                    let createDialog = await $byForm.dialog.form$formCreateDialog.$new(this.$identity(), $ => $.$0());
                    createDialog.cancelButtonClick.$add((sender, args) => { createDialog.close(); });
                    createDialog.createButtonClick.$add(async (sender, args) => {
                        if(createDialog.isNameInputBoxEmpty()){ await $by.object.Message.alert($byForm.object.TextHelper.formNameNull); }
                        else {
                            let newForm = await this.createFormRow();
                            newForm.i$assign("iName", createDialog.getInputName());
                            newForm.i$assign("iSummary", createDialog.getInputSummary());
                            if(this.$identity().rFormSys.rUser.pSession != null){
                                newForm.i$assign("iUserID", this.$identity().rFormSys.rUser.pSession.a.i$access("iID"));
                                await $byForm.$sql({ ["#sql"]: "row", number: 33, args: [ newForm ], argTypes: [ Byt.Row ] });
                            }
                            let formManage = await $byForm.dialog.form$manage.$new(this.$identity(), $ => $.$1(newForm));
                            createDialog.close();
                            formManage.show();
                            this.formListPanel.add(this.createFormItem(formManage.formRow));
                        }
                    });
                    await createDialog.showDialog();
                }
                async createFormRow(){
                    let newForm = new $by.object.Row().$bindIdentity(this.$identity().rFormSys.rForm);
                    newForm.i$assign("iID", await $byCommon.identity.general.getGuid());
                    newForm.i$assign("iName", "");
                    newForm.i$assign("iSummary", "");
                    newForm.i$assign("iCreateDt", $by.object.DateTime.getNow());
                    newForm.i$assign("iCurrentModifyDt", $by.object.DateTime.getNow());
                    newForm.i$assign("iSuccessMsg", "");
                    newForm.i$assign("iSubmitButton", "");
                    return newForm;
                }
                async onCreateFormButtonClick(sender, args){
                    if(await this.$identity().rFormSys.rUser.confirmUserIsLogin()){ await this.createNewForm(); }
                }
            },
            dialog: { props: { mainPanel: $by.object.Panel, operateArea: $by.object.Panel, displayArea: $by.object.Panel, formsHeader: $by.object.Panel, formListLabel: $by.object.Label, formListPanel: $by.object.Panel, createFormButton: $by.object.Button } }
        },
        form$querySaveDialog: {
            type: class querySaveDialog extends Byt.Dialog {
                $0(){
                    this.textLabel.$init($ => { $.text = $byForm.object.TextHelper.querySave; });
                    this.saveButton.$init($ => { $.text = $byForm.object.TextHelper.save; });
                    this.notSaveButton.$init($ => { $.text = $byForm.object.TextHelper.notSave; });
                    this.cancelButton.$init($ => { $.text = $byForm.object.TextHelper.cancel; });
                    {
                        this.element.addClass($byForm.object.CssClassNameHelper.queryDialog);
                        this.textLabel.element.addClass($byForm.object.CssClassNameHelper.querySaveTextLabel);
                        this.saveButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSaveButton);
                        this.notSaveButton.element.addClass($byForm.object.CssClassNameHelper.querySaveNotSaveButton);
                        this.cancelButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailCancelButton);
                        this.buttonContainer.element.addClass($byForm.object.CssClassNameHelper.queryDeleteButtonContainer);
                    }
                    this.buttonContainer.add(this.saveButton);
                    this.buttonContainer.add(this.notSaveButton);
                    this.buttonContainer.add(this.cancelButton);
                    this.height = $byForm.object.ValueHelper.popupWindowHeight;
                    this.width = $byForm.object.ValueHelper.popupWindowWidth;
                    this.saveButton.click.$add(async (sender, args) => { await this.saveButtonClick.$invoke(this, args); });
                    this.notSaveButton.click.$add(async (sender, args) => { await this.notSaveButtonClick.$invoke(this, args); });
                    this.cancelButton.click.$add(async (sender, args) => { await this.cancelButtonClick.$invoke(this, args); });
                }
            },
            instance: { events: [ "saveButtonClick", "notSaveButtonClick", "cancelButtonClick" ] },
            dialog: { props: { textLabel: $by.object.Label, buttonContainer: $by.object.Panel, saveButton: $by.object.Button, notSaveButton: $by.object.Button, cancelButton: $by.object.Button } }
        },
        form$queryDeleteDialog: {
            type: class queryDeleteDialog extends Byt.Dialog {
                $0(){
                    this.textLabel.$init($ => { $.text = $byForm.object.TextHelper.queryDeleteField; });
                    this.deleteButton.$init($ => { $.text = $byForm.object.TextHelper.delete; });
                    this.cancelButton.$init($ => { $.text = $byForm.object.TextHelper.cancel; });
                    {
                        this.element.addClass($byForm.object.CssClassNameHelper.queryDialog);
                        this.textLabel.element.addClass($byForm.object.CssClassNameHelper.queryDeleteTextLabel);
                        this.buttonContainer.element.addClass($byForm.object.CssClassNameHelper.queryDeleteButtonContainer);
                        this.cancelButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailCancelButton);
                        this.deleteButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSelectionDelButton);
                    }
                    this.buttonContainer.add(this.deleteButton);
                    this.buttonContainer.add(this.cancelButton);
                    this.width = $byForm.object.ValueHelper.popupWindowWidth;
                    this.height = $byForm.object.ValueHelper.popupWindowHeight;
                    this.deleteButton.click.$add(async (sender, args) => { await this.deleteButtonClick.$invoke(sender, args); });
                    this.cancelButton.click.$add(async (sender, args) => { await this.cancelButtonClick.$invoke(sender, args); });
                }
                setText(text){ this.textLabel.text = text; }
            },
            instance: { events: [ "deleteButtonClick", "cancelButtonClick" ] },
            dialog: { props: { textLabel: $by.object.Label, buttonContainer: $by.object.Panel, deleteButton: $by.object.Button, cancelButton: $by.object.Button } }
        },
        form$queryExitDialog: {
            type: class queryExitDialog extends Byt.Dialog {
                $0(){
                    this.textLabel.$init($ => { $.text = $byForm.object.TextHelper.formSaveSuccessMessage; });
                    this.exitButton.$init($ => { $.text = $byForm.object.TextHelper.exit; });
                    this.cancelButton.$init($ => { $.text = $byForm.object.TextHelper.cancel; });
                    this.buttonContainer.add(this.exitButton);
                    this.buttonContainer.add(this.cancelButton);
                    this.width = $byForm.object.ValueHelper.popupWindowWidth;
                    this.height = $byForm.object.ValueHelper.popupWindowHeight;
                    {
                        this.buttonContainer.element.addClass($byForm.object.CssClassNameHelper.queryDeleteButtonContainer);
                        this.exitButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSaveButton);
                        this.cancelButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailCancelButton);
                    }
                    this.exitButton.click.$add(async (sender, args) => { await this.exitButtonClick.$invoke(this, args); });
                    this.cancelButton.click.$add(async (sender, args) => { await this.cancelButtonClick.$invoke(this, args); });
                }
            },
            instance: { events: [ "exitButtonClick", "cancelButtonClick" ] },
            dialog: { props: { textLabel: $by.object.Label, buttonContainer: $by.object.Panel, exitButton: $by.object.Button, cancelButton: $by.object.Button } }
        },
        form$formCreateDialog: {
            type: class formCreateDialog extends Byt.Dialog {
                $0(){
                    this.headLabel.$init($ => { $.text = $byForm.object.TextHelper.createFormButtonText; });
                    this.nameLabel.$init($ => { $.text = $byForm.object.TextHelper.formName; });
                    this.summaryLabel.$init($ => { $.text = $byForm.object.TextHelper.summary; });
                    this.summaryInputBox.$init($ => {
                        $.isMultiLine = true;
                        $.width = $byForm.object.ValueHelper.summaryInputBoxWidth;
                        $.height = $byForm.object.ValueHelper.summaryInputBoxHeight;
                    });
                    this.createButton.$init($ => { $.text = $byForm.object.TextHelper.createButtonText; });
                    this.cancelButton.$init($ => { $.text = $byForm.object.TextHelper.cancel; });
                    this.headPanel.add(this.headLabel);
                    this.bodyPanel.add(this.contentPanel);
                    this.bodyPanel.add(this.buttonContainer);
                    this.contentPanel.add(this.namePanel);
                    this.contentPanel.add(this.summaryPanel);
                    this.namePanel.add(this.nameLabel);
                    this.namePanel.add(this.nameInputBox);
                    this.summaryPanel.add(this.summaryLabel);
                    this.summaryPanel.add(this.summaryInputBox);
                    this.buttonContainer.add(this.createButton);
                    this.buttonContainer.add(this.cancelButton);
                    {
                        this.headPanel.element.addClass($byForm.object.CssClassNameHelper.formCreateHeadPanel);
                        this.bodyPanel.element.addClass($byForm.object.CssClassNameHelper.formCreateBodyPanel);
                        this.contentPanel.element.addClass($byForm.object.CssClassNameHelper.formCreateContentPanel);
                        this.buttonContainer.element.addClass($byForm.object.CssClassNameHelper.formCreateOperatePanel);
                        this.namePanel.element.addClass($byForm.object.CssClassNameHelper.formCreateNamePanel);
                        this.nameLabel.element.addClass($byForm.object.CssClassNameHelper.formCreateNameLabel);
                        this.nameInputBox.element.addClass($byForm.object.CssClassNameHelper.formCreateNameBox);
                        this.summaryPanel.element.addClass($byForm.object.CssClassNameHelper.formCreateSummaryLabel);
                        this.summaryLabel.element.addClass($byForm.object.CssClassNameHelper.formCreateSummaryLabel);
                        this.summaryInputBox.element.addClass($byForm.object.CssClassNameHelper.formCreateSummaryBox);
                        this.createButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailSaveButton);
                        this.cancelButton.element.addClass($byForm.object.CssClassNameHelper.generalDetailCancelButton);
                    }
                    this.createButton.click.$add(async (sender, args) => { await this.createButtonClick.$invoke(this, args); });
                    this.cancelButton.click.$add(async (sender, args) => { await this.cancelButtonClick.$invoke(this, args); });
                }
                isNameInputBoxEmpty(){ return this.nameInputBox.text == "" || this.nameInputBox.text == null; }
                getInputName(){ return this.nameInputBox.text; }
                getInputSummary(){ return this.summaryInputBox.text; }
            },
            instance: { events: [ "createButtonClick", "cancelButtonClick" ] },
            dialog: { props: { headPanel: $by.object.Panel, headLabel: $by.object.Label, bodyPanel: $by.object.Panel, contentPanel: $by.object.Panel, namePanel: $by.object.Panel, nameLabel: $by.object.Label, nameInputBox: $by.object.TextBox, summaryPanel: $by.object.Panel, summaryLabel: $by.object.Label, summaryInputBox: $by.object.TextBox, buttonContainer: $by.object.Panel, createButton: $by.object.Button, cancelButton: $by.object.Button } }
        },
        form$publishDialog: {
            type: class publishDialog extends Byt.Dialog {
                $1(formRow){
                    let saasJsBox = new $byForm.object.PropertyMultilineInputBox().$init($ => $.$1($byForm.object.TextHelper.saasInfo));
                    saasJsBox.setBoxHeight($byForm.object.ValueHelper.publishSaasBoxHeight);
                    this.saasPanel.add(saasJsBox);
                    let saasSampleBox = new $byForm.object.PropertyMultilineInputBox().$init($ => $.$1($byForm.object.TextHelper.saasSample));
                    saasSampleBox.setBoxHeight($byForm.object.ValueHelper.publishSaasSampleBoxHeight);
                    this.saasSamplePanel.add(saasSampleBox);
                    this.width = $byForm.object.ValueHelper.publishDialogWidth;
                    this.height = $byForm.object.ValueHelper.publishDialogHeight;
                    {
                        this.element.addAttribute("div", "publish-info-dialog");
                        this.urlLabel.webWidthFilled = true;
                    }
                    {
                        let tmpUrl = Byt.String($by.object.System.webRootPath.by$replace("/Byt", "")) + Byt.String(this.$identity().rFormSys.rFormFilling.pageName);
                        tmpUrl = Byt.String(tmpUrl.by$replaceReg("[\\.][^\r\n\\.]+$", "", "multiline")) + ".js";
                        let scriptTemplate = Byt.String("    <script>window.localStorage.setItem(\"_byt_saasid_storage\", \"{1}\")</script>\r\n".by$replace("{1}", formRow.i$access("iID"))) + Byt.String("    <script src=\"{2}\"> </script>\r\n".by$replace("{2}", tmpUrl));
                        let htmlTemplate = "<!DOCTYPE html>\r\n" + "<html>\r\n" + "  <head>\r\n" + "    <meta http-equiv=\"Content-Type\" content=\"text/html\" charset=\"utf-8\" />\r\n" + "    <title>{0}</title>\r\n" + "  </head>\r\n" + "  <body>\r\n" + "    <script>window.localStorage.setItem(\"_byt_saasid_storage\", \"{1}\")</script>\r\n" + "    <script src=\"{2}\"> </script>\r\n" + "    <div id=\"{1}\"><!--" + Byt.String($byForm.object.TextHelper.saasDivTip) + "--></div>\r\n" + "  </body>\r\n" + "</html>";
                        htmlTemplate = htmlTemplate.by$replace("{0}", formRow.i$access("iName")).by$replace("{1}", formRow.i$access("iID")).by$replace("{2}", tmpUrl);
                        saasJsBox.setText(scriptTemplate);
                        saasSampleBox.setText(htmlTemplate);
                        let urla = $by.object.System.currentDocument.createElement("a");
                        let url = Byt.String($by.object.System.webRootPath.by$replace("/Byt", "")) + Byt.String(this.$identity().rFormSys.rFormFilling.pageName) + "?" + Byt.String($byForm.object.NameHelper.formID) + "=" + Byt.String(formRow.i$access("iID"));
                        urla.addAttribute("href", url);
                        urla.addAttribute("target", "_blank");
                        urla.innerHTML = url;
                        this.urlLabel.text = "链接:";
                        this.urlLabel.element.append(urla);
                    }
                }
            },
            dialog: { props: { saasPanel: $by.object.Panel, saasSamplePanel: $by.object.Panel, urlLabel: $by.object.Label } }
        }
    }
}))