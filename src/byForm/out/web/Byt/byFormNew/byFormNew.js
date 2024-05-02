Byt.defineKu("byFormNew", [ "by", "byForm", "byBase", "byCommon", "byExternal", "byInterface", "byExternalChartjs", "byExternalSMS", "byLog", "byUser", "byWebCommon" ], ($by, $byForm, $byBase, $byCommon, $byExternal, $byInterface, $byExternalChartjs, $byExternalSMS, $byLog, $byUser, $byWebCommon, $byFormNew) => ({
    identity: { home: {
        type: class home extends Byt.Identity {
            async main(queryArgs){
                let tmpWaiting = await $byCommon.identity.relatedDialog.Loading();
                $byUser.newidentitys.user.pConfigSMSCode = true;
                let tmpFormsManager = await $byForm.dialog.form$formsManager.$new($byFormNew.newidentitys.form, $ => $.$0());
                tmpWaiting.close();
                let tmpMenubar = new $by.object.MenuBar();
                let loginButton = $by.object.System.currentDocument.getElementByID("user");
                loginButton.after(tmpMenubar.element);
                tmpMenubar.element.style.setProperty("display", "none");
                let showFormManagersMenuItem = new $by.object.MenuItem().$init($ => { $.text = "显示所有表单"; });
                let createFormMenuItem = new $by.object.MenuItem().$init($ => { $.text = "创建表单"; });
                tmpMenubar.element.addClass($byForm.object.CssClassNameHelper.indexUserMenuBar);
                let activeButton = $by.object.System.currentDocument.getElementByID("active");
                activeButton.click.$add(async (sender, args) => { await tmpFormsManager.initShowManage(); });
                let activeButton2 = $by.object.System.currentDocument.getElementByID("active2");
                if(activeButton2 != null){ activeButton2.click.$add(async (sender, args) => { await tmpFormsManager.initShowManage(); }); }
                showFormManagersMenuItem.click.$add(async (sender, args) => {
                    if(await $byFormNew.newidentitys.form.rFormSys.rUser.confirmUserIsLogin$1("verifyLogin")){
                        tmpFormsManager.show();
                        await tmpFormsManager.RefreshFormListPanel();
                    }
                });
                createFormMenuItem.click.$add(async (sender, args) => {
                    if(await $byFormNew.newidentitys.form.rFormSys.rUser.confirmUserIsLogin$1("verifyLogin")){ await tmpFormsManager.initShowManage(); }
                });
                $byFormNew.newidentitys.formSys.rUser.loginSuccessEvent.$add(f_userRow => {
                    tmpMenubar.element.style.setProperty("display", "inline");
                    loginButton.style.setProperty("display", "none");
                    tmpMenubar.clear();
                    $byFormNew.newidentitys.form.rFormSys.rUser.addUserMenuBar(tmpMenubar);
                    tmpMenubar.add(showFormManagersMenuItem);
                    tmpMenubar.add(createFormMenuItem);
                });
                $byFormNew.newidentitys.formSys.rUser.userExitEvent.$add(f_userRow => {
                    tmpMenubar.element.style.setProperty("display", "none");
                    loginButton.style.setProperty("display", "inline");
                });
                loginButton.click.$add(async (sender, args) => {
                    let loginWaiting = await $byCommon.identity.relatedDialog.Loading();
                    (await $byUser.dialog.user$diLogin.$new($byFormNew.newidentitys.form.rFormSys.rUser, $ => $.$0())).show();
                    loginWaiting.close();
                });
                let orderTemplateBtn = $by.object.System.currentDocument.getElementByID("order");
                let signTemplateBtn = $by.object.System.currentDocument.getElementByID("sign");
                let registerTemplateBtn = $by.object.System.currentDocument.getElementByID("register");
                let collectTemplateBtn = $by.object.System.currentDocument.getElementByID("collect");
                let statisticsTemplateBtn = $by.object.System.currentDocument.getElementByID("statistics");
                let appointmentTemplateBtn = $by.object.System.currentDocument.getElementByID("appointment");
                orderTemplateBtn.click.$add(async (sender, args) => { await tmpFormsManager.showManageFromTemplate("template-order-0"); });
                signTemplateBtn.click.$add(async (sender, args) => { await tmpFormsManager.showManageFromTemplate("template-sign-0"); });
                registerTemplateBtn.click.$add(async (sender, args) => { await tmpFormsManager.showManageFromTemplate("template-register-0"); });
                collectTemplateBtn.click.$add(async (sender, args) => { await tmpFormsManager.showManageFromTemplate("template-collect-0"); });
                statisticsTemplateBtn.click.$add(async (sender, args) => { await tmpFormsManager.showManageFromTemplate("template-statistics-0"); });
                appointmentTemplateBtn.click.$add(async (sender, args) => { await tmpFormsManager.showManageFromTemplate("template-appointment-0"); });
            }
        },
        base: { inherit: $by.identity.Page }
    } },
    tables: {
        formField: {
            identity: "byFormNew.formField",
            fields: {
                iD: { summary: "编号", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true, verify: { max: 32 } } },
                form: { summary: "表单ID", type: Byt.String, identity: $by.identity.Reference, marks: { ref: "byFormNew.form.iD" } },
                fieldNO: { summary: "系统自动编号", type: Byt.String, identity: $by.identity.Attribute },
                fieldName: { summary: "字段名", type: Byt.String, identity: $by.identity.Attribute },
                fieldType: { summary: "字段类型，int string", type: Byt.String, identity: $by.identity.Attribute },
                fieldCtrl: { summary: "显示为文本框、下拉框、单选、多选", type: "byForm.enum.ctrType", identity: $by.identity.Attribute },
                selectValue: { summary: "单选、多选、下拉列表值", type: Byt.String, identity: $by.identity.Attribute, marks: { verify: { max: 1024 } } },
                fieldMin: { summary: "字段最小值", type: Byt.Int, identity: $by.identity.Attribute },
                fieldMax: { summary: "字段最大值，最大值为 4000即表的最大长度 ", type: Byt.Int, identity: $by.identity.Attribute },
                fieldReg: { summary: "正则验证", type: Byt.String, identity: $by.identity.Attribute },
                fieldRegMsg: { summary: "正则验证提示消息文本", type: Byt.String, identity: $by.identity.Attribute },
                fieldDefault: { summary: "默认值", type: Byt.String, identity: $by.identity.Attribute },
                order: { summary: "排序", type: Byt.Int, identity: $by.identity.Attribute },
                notNull: { summary: "必填,true=必填", type: Byt.Bool, identity: $by.identity.Attribute },
                vDataValue: { summary: "数据保存的位置表(vData)ID", type: Byt.Int, identity: $by.identity.Attribute },
                userID: { summary: "用户ID", type: Byt.String, identity: $by.identity.Attribute },
                summary: { summary: "说明", type: Byt.String, identity: $by.identity.ID, marks: { verify: { max: 256 } } }
            },
            rows: [
                [ "sign-0-0", "form-sign-0", "0", "姓名", "string", "textbox", "", 0, 64, "^[\u4e00-\u9fa5_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "", 0, true, 0, "", "姓名" ],
                [ "sign-0-1", "form-sign-0", "1", "性别", "string", "radbutton", "男\n女", 0, 64, "", "", "", 0, true, 0, "", "单选" ],
                [ "sign-0-2", "form-sign-0", "2", "年龄", "int", "textbox", "", 0, 120, "^[1-9]\\d*$", "年龄应当为正整数", "", 0, true, 0, "", "单行文本" ],
                [ "sign-0-3", "form-sign-0", "3", "手机", "string", "textbox", "", 0, 64, "(^\\d{11}$)", "非法的手机号码", "", 0, true, 0, "", "电话" ],
                [ "sign-0-4", "form-sign-0", "4", "邮箱", "string", "textbox", "", 0, 64, "^[\\-_\\w]{1,}@[\\w]{1,}\\.[\\-_\\w\\.]+$", "邮箱格式非法", "", 0, true, 0, "", "邮箱" ],
                [ "sign-0-5", "form-sign-0", "5", "身份证号码", "string", "textbox", "", 18, 18, "^[1-9]\\d{5}(19|20)\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])\\d{3}(\\d|X|x)$", "身份证号格式错误，请输入中国18位身份证号，最后位x不区分大小写", "", 0, true, 0, "", "单行文本" ],
                [ "register-0-0", "form-register-0", "0", "姓名", "string", "textbox", "", 0, 64, "^[\u4e00-\u9fa5_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "", 0, true, 0, "", "单行文本" ],
                [ "register-0-1", "form-register-0", "1", "性别", "string", "radbutton", "男\n女", 0, 64, "", "", "", 0, true, 0, "", "单选" ],
                [ "register-0-2", "form-register-0", "2", "年龄", "int", "textbox", "", 0, 120, "^[1-9]\\d*$", "年龄应当为正整数", "", 0, true, 0, "", "单行文本" ],
                [ "register-0-3", "form-register-0", "3", "手机", "string", "textbox", "", 0, 64, "(^\\d{11}$)", "非法的手机号码", "", 0, true, 0, "", "电话" ],
                [ "register-0-4", "form-register-0", "4", "邮箱", "string", "textbox", "", 0, 64, "^[\\-_\\w]{1,}@[\\w]{1,}\\.[\\-_\\w\\.]+$", "邮箱格式非法", "", 0, true, 0, "", "邮箱" ],
                [ "collect-0-0", "form-collect-0", "0", "反馈人姓名", "string", "textbox", "", 0, 64, "^[^\"\"\"\"]*$", "不能输入单引号 及双引号", "", 0, true, 0, "", "单行文本" ],
                [ "collect-0-1", "form-collect-0", "1", "联系电话", "string", "textbox", "", 0, 64, "(^\\d+[\\-]\\d{5,11}$)|(^\\d{11}$)", "非法的手机号或固定电话号码", "", 0, false, 0, "", "电话" ],
                [ "collect-0-2", "form-collect-0", "2", "反馈内容", "string", "muiltTextbox", "", 0, 1000, "^[^\"\"]*$", "不能输入单引号", "", 0, true, 0, "", "多行文本" ],
                [ "appointment-0-0", "form-appointment-0", "0", "预约人姓名", "string", "textbox", "", 0, 64, "^[\u4e00-\u9fa5_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "", 0, true, 0, "", "姓名" ],
                [ "appointment-0-1", "form-appointment-0", "1", "预约人部门", "string", "dropdownList", "开发部\n研发部\n销售部\n人事部", 0, 64, "", "", "", 0, true, 0, "", "下拉" ],
                [ "appointment-0-2", "form-appointment-0", "2", "会议主题", "string", "textbox", "", 0, 64, "^[^\"\"\"\"]*$", "不能输入单引号 及双引号", "", 0, true, 0, "", "单行文本" ],
                [ "appointment-0-3", "form-appointment-0", "3", "会议开始时间", "string", "dateTimePicker", "", 0, 64, "", "", "", 0, true, 0, "", "日期时间" ],
                [ "appointment-0-4", "form-appointment-0", "4", "会议持续时间", "string", "dropdownList", "30分钟\n1小时\n2小时\n3小时", 0, 64, "", "", "", 0, true, 0, "", "下拉" ],
                [ "appointment-0-5", "form-appointment-0", "5", "参会人数", "int", "textbox", "", 1, 3000, "^[1-9]\\d*$", "请输入正整数", "", 0, true, 0, "", "单行文本" ],
                [ "appointment-0-6", "form-appointment-0", "6", "备注信息", "string", "muiltTextbox", "", 0, 64, "^[^\"\"]*$", "不能输入单引号", "", 0, true, 0, "", "多行文本" ],
                [ "order-0-0", "form-order-0", "0", "客户姓名", "string", "textbox", "", 0, 64, "^[\u4e00-\u9fa5_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "", 0, true, 0, "", "姓名" ],
                [ "order-0-1", "form-order-0", "1", "联系电话", "string", "textbox", "", 0, 64, "(^\\d+[\\-]\\d{5,11}$)|(^\\d{11}$)", "非法的手机号或固定电话号码", "", 0, true, 0, "", "电话" ],
                [ "order-0-2", "form-order-0", "2", "订购产品名称", "string", "dropdownList", "产品A\n产品B\n产品C", 0, 64, "", "", "", 0, true, 0, "", "下拉" ],
                [ "order-0-3", "form-order-0", "3", "订购数量", "int", "textbox", "", 1, 500000, "^[1-9]\\d*$", "订购数量需要为正整数", "", 0, true, 0, "", "单行文本" ],
                [ "order-0-4", "form-order-0", "4", "收货地址", "string", "muiltTextbox", "", 0, 64, "^[^\"\"\"\"]*$", "不能输入单引号 及双引号", "", 0, true, 0, "", "地址" ],
                [ "order-0-5", "form-order-0", "5", "付款方式", "string", "dropdownList", "微信支付\n支付宝\n信用卡", 0, 64, "", "", "", 0, true, 0, "", "下拉" ],
                [ "statistics-0-0", "form-statistics-0", "0", "姓名", "string", "textbox", "", 0, 64, "^[\u4e00-\u9fa5_a-zA-Z0-9]+$", "不能输入单引号 及双引号", "", 0, true, 0, "", "单行文本" ],
                [ "statistics-0-1", "form-statistics-0", "1", "性别", "string", "radbutton", "男\n女", 0, 64, "", "", "", 0, true, 0, "", "单选" ],
                [ "statistics-0-2", "form-statistics-0", "2", "年龄", "int", "textbox", "", 0, 120, "^[1-9]\\d*$", "年龄应当为正整数", "", 0, true, 0, "", "单行文本" ],
                [ "statistics-0-3", "form-statistics-0", "3", "身高(cm)", "int", "textbox", "", 50, 250, "^[1-9]\\d*$", "年龄应当为正整数", "", 0, true, 0, "", "单行文本" ],
                [ "statistics-0-4", "form-statistics-0", "4", "体重(kg,取整数)", "int", "textbox", "", 0, 250, "^[1-9]\\d*$", "体重请取正整数", "", 0, true, 0, "", "单行文本" ],
                [ "statistics-0-5", "form-statistics-0", "5", "健康状况", "string", "dropdownList", "健康\n良好\n不良", 0, 64, "", "", "", 0, true, 0, "", "下拉" ],
                [ "statistics-0-6", "form-statistics-0", "6", "运动频率 ", "string", "dropdownList", "每天\n经常\n偶尔\n从不", 0, 64, "", "", "", 0, true, 0, "", "下拉" ],
                [ "statistics-0-7", "form-statistics-0", "7", "球类爱好", "string", "checkBoxList", "篮球\n足球\n羽毛球\n乒乓球\n排球\n棒球\n台球", -1, -1, "", "", "", 0, true, 0, "", "多选" ]
            ],
            marks: { primary: [ "iD" ] },
            sources: {
                iD: { mode: "user", actions: [ "select", "insert" ], access: "byFormNew.formField.iD", settings: { name: "iD", text: "编号" } },
                form: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.form", settings: { name: "form", text: "表单ID" } },
                fieldNO: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldNO", settings: { name: "fieldNO", text: "系统自动编号" } },
                fieldName: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldName", settings: { name: "fieldName", text: "字段名" } },
                fieldType: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldType", settings: { name: "fieldType", text: "字段类型，int string" } },
                fieldCtrl: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldCtrl", settings: { name: "fieldCtrl", text: "显示为文本框、下拉框、单选、多选" } },
                selectValue: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.selectValue", settings: { name: "fieldDropDown", text: "单选、多选、下拉列表值" } },
                fieldMin: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldMin", settings: { name: "fieldMin", text: "字段最小值" } },
                fieldMax: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldMax", settings: { name: "fieldMax", text: "字段最大值，最大值为 4000即表的最大长度 " } },
                fieldReg: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldReg", settings: { name: "fieldReg", text: "正则验证" } },
                fieldRegMsg: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldRegMsg", settings: { name: "fieldRegMsg", text: "正则验证提示消息文本" } },
                fieldDefault: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.fieldDefault", settings: { name: "fieldDefault", text: "默认值" } },
                vDataValue: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.vDataValue", settings: { name: "toDateTableID", text: "数据保存的位置表(vData)ID" } },
                userID: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.userID", settings: { name: "userID", text: "用户ID" } },
                summary: { mode: "user", actions: [ "select", "insert" ], access: "byFormNew.formField.summary", settings: { name: "summary", text: "说明" } },
                order: { mode: "server", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.order", settings: { name: "order", text: "排序" } },
                notNull: { mode: "client", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formField.notNull", settings: { name: "notNull", text: "必填,true=必填", isArray: true, value: () => ([ true, false ]) } }
            },
            flows: { insert: [ "iD", "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "summary", "order", "notNull" ], update: [ "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "order", "notNull" ], delete: [ "iD", "summary" ], select: [ "iD", "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "summary", "order", "notNull" ], popup: [ "iD", "form", "userID", "summary", "order", "notNull" ] },
            controls: { edit: [ "fieldNO", "fieldName", "fieldType", "fieldCtrl", "selectValue", "fieldMin", "fieldMax", "fieldReg", "fieldRegMsg", "fieldDefault", "vDataValue", "form", "userID", "summary", "order", "notNull" ], popup: [ "iD", "form", "userID", "summary", "order", "notNull" ] }
        },
        formTemplate: {
            identity: "byFormNew.formTemplate",
            fields: {
                ID: { summary: "唯一标识", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true, verify: { max: 32 } } },
                name: { summary: "名称", type: Byt.String, identity: $by.identity.Name, marks: { notNull: true, verify: { max: 32 } } },
                formID: { summary: "对应的表单id", type: Byt.String, identity: $by.identity.Reference, marks: { notNull: true, verify: { max: 32 } } },
                userID: { summary: "用户ID", type: Byt.String, identity: $by.identity.Attribute, marks: { ref: "byUser.user.ID" } }
            },
            rows: [
                [ "template-order-0", "在线订单模板", "form-order-0", "" ],
                [ "template-collect-0", "意见反馈模板", "form-collect-0", "" ],
                [ "template-register-0", "在线登记模板", "form-register-0", "" ],
                [ "template-appointment-0", "会议预约模板", "form-appointment-0", "" ],
                [ "template-sign-0", "在线登记模板", "form-sign-0", "" ],
                [ "template-statistics-0", "在线统计模板", "form-statistics-0", "" ]
            ],
            marks: { primary: [ "ID" ] }
        },
        formData: {
            identity: "byFormNew.formData",
            fields: {
                iD: { summary: "ID", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true } },
                formID: { summary: "表单ID", type: Byt.String, identity: $by.identity.Reference, marks: { ref: "byFormNew.form.iD" } },
                rowPK: { summary: "数据行中的主键，非用户录入的表字段主键值，该项由系统自动编号", type: Byt.String, identity: $by.identity.Attribute },
                fieldID: { summary: "字段ID", type: Byt.String, identity: $by.identity.Reference, marks: { ref: "byFormNew.formField.iD" } },
                fieldName: { summary: "字段名", type: Byt.String, identity: $by.identity.Reference },
                cellValue: { summary: "单元格中的值", type: Byt.String, identity: $by.identity.Attribute, marks: { verify: { max: 4000 } } },
                userID: { summary: "用户ID", type: Byt.String, identity: $by.identity.Attribute, marks: { ref: "byUser.user.ID" } }
            },
            marks: { primary: [ "iD" ] },
            sources: {
                iD: { mode: "user", actions: [ "select", "insert" ], access: "byFormNew.formData.iD", settings: { name: "iD", text: "ID" } },
                formID: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formData.formID", settings: { name: "formID", text: "表单ID" } },
                rowPK: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formData.rowPK", settings: { name: "rowPK", text: "数据行中的主键，非用户录入的表字段主键值，该项由系统自动编号" } },
                fieldID: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formData.fieldID", settings: { name: "fieldID", text: "字段ID" } },
                fieldName: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formData.fieldName", settings: { name: "fieldName", text: "字段名" } },
                cellValue: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formData.cellValue", settings: { name: "cellValue", text: "单元格中的值" } },
                userID: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.formData.userID", settings: { name: "userID", text: "用户ID" } }
            },
            flows: { insert: [ "iD", "formID", "rowPK", "fieldID", "fieldName", "cellValue", "userID" ], update: [ "formID", "rowPK", "fieldID", "fieldName", "cellValue", "userID" ], delete: [ "iD" ], select: [ "iD", "formID", "rowPK", "fieldName", "fieldID", "cellValue", "userID" ], popup: [ "iD" ] },
            controls: { edit: [ "formID", "rowPK", "fieldID", "fieldName", "cellValue", "userID" ], popup: [ "iD" ] }
        },
        form: {
            identity: "byFormNew.form",
            fields: {
                iD: { summary: "编号", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true, verify: { max: 32 } } },
                name: { summary: "表单名称", type: Byt.String, identity: $by.identity.Name, marks: { notNull: true } },
                successMsg: { summary: "用户保存成功后提示消息", type: Byt.String, identity: $by.identity.Attribute, marks: { default: "谢谢，我们会尽快处理！" } },
                submitButton: { summary: "提交按钮的文本说明", type: Byt.String, identity: $by.identity.Attribute, marks: { default: "确认提交" } },
                summary: { summary: "说明", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true, verify: { max: 256 } } },
                userID: { summary: "用户ID", type: Byt.String, identity: $by.identity.Attribute, marks: { ref: "byUser.user.ID" } },
                createDt: { summary: "创建时间", type: Byt.DateTime, identity: $by.identity.Attribute },
                currentModifyDt: { summary: "最后修改时间", type: Byt.DateTime, identity: $by.identity.Attribute }
            },
            rows: [
                [ "form-sign-0", "在线报名", "已收到您的报名信息，我们将在7个工作日内给您反馈！", "确认报名", "", "", "2024-04-28", "2024-04-28" ],
                [ "form-register-0", "在线登记", "感谢！已收到您的登记信息。", "确认登记", "", "", "2024-04-28", "2024-04-28" ],
                [ "form-collect-0", "意见反馈", "感谢您的宝贵意见,我们会尽快处理！", "确认提交", "", "", "2024-04-28", "2024-04-28" ],
                [ "form-appointment-0", "会议预约", "已收到您的预约信息，我们将尽快给您反馈！", "确认预约", "", "", "2024-04-28", "2024-04-28" ],
                [ "form-order-0", "在线订单", "谢谢,我们会尽快与您联系！", "确认订购", "", "", "2024-04-28", "2024-04-28" ],
                [ "form-statistics-0", "调查统计", "收到，感谢您的参与", "确认提交", "", "", "2024-04-28", "2024-04-28" ]
            ],
            marks: { primary: [ "iD" ] },
            sources: {
                iD: { mode: "user", actions: [ "select", "insert" ], access: "byFormNew.form.iD", settings: { name: "iD", text: "编号" } },
                name: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.form.name", settings: { name: "name", text: "表单名称" } },
                successMsg: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.form.successMsg", settings: { name: "successMsg", text: "用户保存成功后提示消息" } },
                submitButton: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.form.submitButton", settings: { name: "submitButton", text: "提交按钮的文本说明" } },
                summary: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.form.summary", settings: { name: "summary", text: "说明" } },
                userID: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.form.userID", settings: { name: "userID", text: "用户ID" } },
                createDt: { mode: "server", actions: [ "select" ], access: "byFormNew.form.createDt", settings: { name: "createDt", text: "创建时间" } },
                currentModifyDt: { mode: "server", actions: [ "select" ], access: "byFormNew.form.currentModifyDt", settings: { name: "currentModifyDt", text: "最后修改时间" } }
            },
            flows: { insert: [ "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" ], update: [ "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" ], delete: [ "iD" ], select: [ "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" ], popup: [ "iD", "name" ] },
            controls: { edit: [ "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" ], popup: [ "iD", "name" ] }
        },
        fieldTemplate: {
            identity: "byFormNew.fieldTemplate",
            fields: {
                iD: { summary: "ID", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true, verify: { max: 32 } } },
                name: { summary: "名称", type: Byt.String, identity: $by.identity.Name, marks: { notNull: true, verify: { max: 32 } } },
                summary: { summary: "说明", type: Byt.String, identity: $by.identity.Attribute, marks: { verify: { max: 32 } } },
                ctrType: { summary: "控件类型", type: "byForm.enum.ctrType", identity: $by.identity.Attribute },
                ico: { summary: "图标", type: Byt.String, identity: $by.identity.Attribute, marks: { verify: { max: 128 } } },
                min: { summary: "最小值", type: Byt.Int, identity: $by.identity.Attribute, marks: { verify: { max: 256 } } },
                max: { summary: "最大值", type: Byt.Int, identity: $by.identity.Attribute, marks: { verify: { max: 256 } } },
                default2: { summary: "默认值", type: Byt.String, identity: $by.identity.Attribute, marks: { verify: { min: 0, max: 32 } } },
                reg: { summary: "正则验证", type: Byt.String, identity: $by.identity.Attribute, marks: { verify: { min: 0, max: 256 } } },
                regMsg: { summary: "正则验证出错后消息", type: Byt.String, identity: $by.identity.Attribute, marks: { verify: { min: 0, max: 256 } } },
                createDt: { summary: "创建时间", type: Byt.DateTime, identity: $by.identity.Attribute }
            },
            rows: [
                [ "1", "singleTextbox", "单行文本", "textbox", "singleTextbox.svg", 0, 0, "", "^[^''\"\"]*$", "不能输入单引号 及双引号", "2024-04-28 00:00:00" ],
                [ "2", "multiTextbox", "多行文本", "muiltTextbox", "multiTextbox.svg", 0, 0, "", "^[^'']*$", "不能输入单引号", "2024-04-28 00:00:10" ],
                [ "3", "checkBox", "判断", "checkBox", "checkBox.svg", 0, 0, "", "", "", "2024-04-28 00:00:20" ],
                [ "4", "dropdownList", "下拉", "dropdownList", "dropdownList.svg", 0, 0, "", "", "", "2024-04-28 00:00:30" ],
                [ "5", "radbutton", "单选", "radbutton", "radbutton.svg", 0, 0, "", "", "", "2024-04-28 00:00:40" ],
                [ "6", "checkBoxList", "多选", "checkBoxList", "checkBoxList.svg", 0, 0, "", "", "", "2024-04-28 00:00:50" ],
                [ "7", "name", "姓名", "textbox", "name.svg", 0, 0, "", "^[\u4e00-\u9fa5_a-zA-Z0-9]+$", "仅支持字母、数字及中文", "2024-04-28 00:01:00" ],
                [ "8", "address", "地址", "muiltTextbox", "address.svg", 0, 0, "", "^[^''\"\"]*$", "不能输入单引号 及双引号", "2024-04-28 00:01:10" ],
                [ "9", "telephone", "电话", "textbox", "telephone.svg", 0, 0, "", "(^\\d+[\\-]\\d{5,11}$)|(^\\d{11}$)", "非法的手机号或固定电话号码", "2024-04-28 00:01:20" ],
                [ "10", "mail", "邮箱", "textbox", "mail.svg", 0, 0, "", "^[\\-_\\w]{1,}@[\\w]{1,}\\.[\\-_\\w\\.]+$", "邮箱格式非法", "2024-04-28 00:01:30" ],
                [ "11", "summary", "说明", "muiltTextbox", "summary.svg", 0, 0, "", "^[^'']*$", "不能输入单引号", "2024-04-28 00:01:40" ],
                [ "12", "NO", "编号", "textbox", "no.svg", 0, 0, "", "^[_\\-0-9a-zA-Z]+$", "仅支持字母、数字及\"-_\"", "2024-04-28 00:01:50" ],
                [ "13", "decimal", "小数", "textbox", "decimal.svg", 0, 0, "", "(^\\-?[\\d]+$)|(^\\-?[\\d]+\\.[\\d]+$)", "非法的小数格式", "2024-04-28 00:02:00" ],
                [ "14", "date", "日期", "datePicker", "date.svg", 0, 0, "", "", "", "2024-04-28 00:02:10" ],
                [ "15", "time", "时间", "timePicker", "time.svg", 0, 0, "", "", "", "2024-04-28 00:02:20" ],
                [ "16", "datetime", "日期时间", "dateTimePicker", "datetime.svg", 0, 0, "", "", "", "2024-04-28 00:02:30" ],
                [ "17", "money", "货币", "textbox", "money.svg", 0, 0, "", "(^\\-?[\\d]+$)|(^\\-?[\\d]+\\.[\\d]+$)", "非法的金额", "2024-04-28 00:02:40" ],
                [ "18", "slider", "滑块", "slider", "slider.svg", 0, 0, "", "", "", "2024-04-28 00:02:50" ]
            ],
            marks: { primary: [ "iD" ] },
            sources: {
                iD: { mode: "user", actions: [ "select", "insert" ], access: "byFormNew.fieldTemplate.iD", settings: { name: "iD", text: "ID" } },
                name: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.name", settings: { name: "name", text: "名称" } },
                summary: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.summary", settings: { name: "summary", text: "说明" } },
                ctrType: { mode: "client", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.ctrType", settings: { name: "ctrType", text: "控件类型", isArray: true, value: () => ($byForm.enum.ctrType.$values()) } },
                ico: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.ico", settings: { name: "ico", text: "图标" } },
                min: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.min", settings: { name: "min", text: "最小值" } },
                max: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.max", settings: { name: "max", text: "最大值" } },
                default2: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.default2", settings: { name: "default2", text: "默认值" } },
                reg: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.reg", settings: { name: "reg", text: "正则验证" } },
                regMsg: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.regMsg", settings: { name: "regMsg", text: "正则验证出错后消息" } },
                createDt: { mode: "server", actions: [ "insert", "delete", "update", "select" ], access: "byFormNew.fieldTemplate.createDt", settings: { name: "createDt", text: "创建时间" } }
            },
            flows: { insert: [ "iD", "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" ], update: [ "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" ], delete: [ "iD" ], select: [ "iD", "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" ], popup: [ "iD", "name", "createDt" ] },
            controls: { edit: [ "name", "summary", "ctrType", "ico", "min", "max", "default2", "reg", "regMsg", "createDt" ], popup: [ "iD", "name", "createDt" ] }
        }
    },
    newidentitys: {
        formResult: {
            type: "byForm.identity.formResult",
            page: { src: "result.html" },
            components: { rFormSys: "byFormNew.formSys" }
        },
        home: { type: "byFormNew.identity.home", page: { src: "index.html" } },
        formAnalyzer: {
            type: "byForm.identity.formAnalyzer",
            page: { src: "analyzer.html" },
            components: { rFormSys: "byFormNew.formSys" }
        },
        previewFormFilling: {
            type: "byForm.identity.previewFormFilling",
            page: { src: "preview.html" },
            components: { rFormSys: "byFormNew.formSys" }
        },
        formField: { type: "byForm.identity.formField", to: "byFormNew.formField", components: { iID: { inner: true, value: "byFormNew.formField.iD" }, iFormID: { inner: true, value: "byFormNew.formField.form" }, iFieldNO: { inner: true, value: "byFormNew.formField.fieldNO" }, iFieldName: { inner: true, value: "byFormNew.formField.fieldName" }, iSummary: { inner: true, value: "byFormNew.formField.summary" }, iFieldType: { inner: true, value: "byFormNew.formField.fieldType" }, iFieldCtrl: { inner: true, value: "byFormNew.formField.fieldCtrl" }, iSelectValue: { inner: true, value: "byFormNew.formField.selectValue" }, iFieldMin: { inner: true, value: "byFormNew.formField.fieldMin" }, iFieldMax: { inner: true, value: "byFormNew.formField.fieldMax" }, iFieldReg: { inner: true, value: "byFormNew.formField.fieldReg" }, iFieldRegMsg: { inner: true, value: "byFormNew.formField.fieldRegMsg" }, iFieldDefault: { inner: true, value: "byFormNew.formField.fieldDefault" }, iOrder: { inner: true, value: "byFormNew.formField.order" }, iVDataValue: { inner: true, value: "byFormNew.formField.vDataValue" }, rFormSys: "byFormNew.formSys", iUserID: { inner: true, value: "byFormNew.formField.userID" }, iNotNull: { inner: true, value: "byFormNew.formField.notNull" } } },
        formSys: { type: "byForm.identity.formSys", components: { rForm: "byFormNew.form", rFormField: "byFormNew.formField", rFormData: "byFormNew.formData", rFieldTemplate: "byFormNew.fieldTemplate", rFormTemplate: "byFormNew.formTemplate", rVData64: "byFormNew.formData", rVData256: "byFormNew.formData", rVData1024: "byFormNew.formData", rVData4000: "byFormNew.formData", rUser: "byUser.user", rFormFilling: "byFormNew.formFilling", rPreviewFormFilling: "byFormNew.previewFormFilling", rFormResult: "byFormNew.formResult", rFormAnalyzer: "byFormNew.formAnalyzer" } },
        formTemplate: { type: "byForm.identity.formTemplate", to: "byFormNew.formTemplate", components: { iID: { inner: true, value: "byFormNew.formTemplate.ID" }, iFormID: { inner: true, value: "byFormNew.formTemplate.formID" }, iUserID: { inner: true, value: "byFormNew.formTemplate.userID" }, iName: { inner: true, value: "byFormNew.formTemplate.name" }, rFormSys: "byFormNew.formSys" } },
        formData: { type: "byForm.identity.formData", to: "byFormNew.formData", components: { iID: { inner: true, value: "byFormNew.formData.iD" }, iFormID: { inner: true, value: "byFormNew.formData.formID" }, iRowPK: { inner: true, value: "byFormNew.formData.rowPK" }, iFieldID: { inner: true, value: "byFormNew.formData.fieldID" }, iFieldName: { inner: true, value: "byFormNew.formData.fieldName" }, iCellValue: { inner: true, value: "byFormNew.formData.cellValue" }, iUserID: { inner: true, value: "byFormNew.formData.userID" }, rFormSys: "byFormNew.formSys" } },
        form: { type: "byForm.identity.form", to: "byFormNew.form", components: { iID: { inner: true, value: "byFormNew.form.iD" }, iName: { inner: true, value: "byFormNew.form.name" }, iSuccessMsg: { inner: true, value: "byFormNew.form.successMsg" }, iSubmitButton: { inner: true, value: "byFormNew.form.submitButton" }, iSummary: { inner: true, value: "byFormNew.form.summary" }, iUserID: { inner: true, value: "byFormNew.form.userID" }, rFormSys: "byFormNew.formSys", iCreateDt: { inner: true, value: "byFormNew.form.createDt" }, iCurrentModifyDt: { inner: true, value: "byFormNew.form.currentModifyDt" } } },
        formFilling: {
            type: "byForm.identity.formFilling",
            page: { src: "form.html" },
            components: { rFormSys: "byFormNew.formSys" }
        },
        fieldTemplate: {
            type: "byForm.identity.fieldTemplate",
            to: "byFormNew.fieldTemplate",
            components: { iID: { inner: true, value: "byFormNew.fieldTemplate.iD" }, iName: { inner: true, value: "byFormNew.fieldTemplate.name" }, iSummary: { inner: true, value: "byFormNew.fieldTemplate.summary" }, iCtrType: { inner: true, value: "byFormNew.fieldTemplate.ctrType" }, iIco: { inner: true, value: "byFormNew.fieldTemplate.ico" }, iMin: { inner: true, value: "byFormNew.fieldTemplate.min" }, iMax: { inner: true, value: "byFormNew.fieldTemplate.max" }, iDefault: { inner: true, value: "byFormNew.fieldTemplate.default2" }, iReg: { inner: true, value: "byFormNew.fieldTemplate.reg" }, iRegMsg: { inner: true, value: "byFormNew.fieldTemplate.regMsg" }, rFormSys: "byFormNew.formSys", rUser: "byUser.user", iCreateDt: { inner: true, value: "byFormNew.fieldTemplate.createDt" } },
            dialogs: { ["byBase.dialog.dic$manage"]: { cEditArea: "edit", cGrid: "edit", cQueryArea: "popup" } }
        }
    }
}))