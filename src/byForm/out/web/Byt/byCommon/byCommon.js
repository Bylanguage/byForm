Byt.defineKu("byCommon", [ "by", "byExternal" ], ($by, $byExternal, $byCommon) => ({
    object: {
        verifyTextbox: {
            type: class verifyTextbox extends Byt.Object {
                $0(){
                    this.pLblDic = new $by.object.Dictionary();
                    this.pSourceDic = new $by.object.Dictionary();
                    this.pErrorDic = new $by.object.Dictionary();
                    this.pRegDic = new $by.object.Dictionary();
                    this.pNotNullDic = new $by.object.Dictionary();
                    this.pColorDic = new $by.object.Dictionary();
                    this.pMaxLength = new $by.object.Dictionary();
                }
                add(f_lagel, f_txtBox, f_isNotNull, f_regTxt, f_errorInfo, f_MaxLength){
                    this.pSourceDic.add(f_txtBox, f_lagel.text);
                    this.pLblDic.add(f_txtBox, f_lagel);
                    this.pNotNullDic.add(f_txtBox, f_isNotNull);
                    this.pErrorDic.add(f_txtBox, f_errorInfo);
                    this.pRegDic.add(f_txtBox, f_regTxt);
                    this.pColorDic.add(f_txtBox, f_txtBox.foreColor);
                    this.pMaxLength.add(f_txtBox, f_MaxLength);
                    f_txtBox.keyUp.$add((sender, keyEventArgs) => { this.verifySingleTextBox($by.object.TextBox.$convert(sender)); });
                    f_txtBox.leave.$add((sender, args) => { f_lagel.text = f_lagel.text.by$replaceReg("[\\d]+$", "", "none"); });
                }
                verifySingleTextBox(f_txtBox){ return this.verifySingleTextBox$1(f_txtBox, true, true); }
                verifySingleTextBox$1(f_txtBox, f_isFocus, f_isShowRemainTotal){
                    let tmpResultValue = false;
                    if(!f_txtBox.text.by$isMatch(this.pRegDic.$get(f_txtBox), "multiIgnoreCase")){
                        this.pLblDic.$get(f_txtBox).text = this.pErrorDic.$get(f_txtBox);
                        if(f_isFocus){ f_txtBox.focus(); }
                        f_txtBox.foreColor = $by.object.Color.RED;
                        this.pLblDic.$get(f_txtBox).foreColor = $by.object.Color.RED;
                    }
                    else {
                        let tmpInfo = this.pSourceDic.$get(f_txtBox);
                        if(f_isShowRemainTotal){
                            let tmpRemain = (((this.pMaxLength.$get(f_txtBox) - f_txtBox.text.length) | 0));
                            if(tmpRemain < 0){
                                this.pLblDic.$get(f_txtBox).text = Byt.String($byCommon.object.ByCommonStrings.Warning_Too_Many_Characters()) + tmpRemain;
                                f_txtBox.foreColor = $by.object.Color.RED;
                                this.pLblDic.$get(f_txtBox).foreColor = $by.object.Color.RED;
                                return false;
                            }
                            tmpInfo = Byt.String["+"](tmpInfo, " " + tmpRemain);
                        }
                        this.pLblDic.$get(f_txtBox).text = tmpInfo;
                        f_txtBox.foreColor = this.pColorDic.$get(f_txtBox);
                        this.pLblDic.$get(f_txtBox).foreColor = this.pColorDic.$get(f_txtBox);
                        tmpResultValue = true;
                    }
                    return tmpResultValue;
                }
                verify(){
                    let tmpResultValue = true;
                    for (let item of this.pLblDic){
                        if(!this.verifySingleTextBox$1(item.key, false, false)){ tmpResultValue = false; }
                    }
                    return tmpResultValue;
                }
                showError(f_textBox){
                    this.pLblDic.$get(f_textBox).text = this.pErrorDic.$get(f_textBox);
                    this.pLblDic.$get(f_textBox).foreColor = $by.object.Color.RED;
                    f_textBox.foreColor = $by.object.Color.RED;
                }
                showError$1(f_textBox, f_errorInfo){
                    this.pLblDic.$get(f_textBox).text = f_errorInfo;
                    this.pLblDic.$get(f_textBox).foreColor = $by.object.Color.RED;
                    f_textBox.foreColor = $by.object.Color.RED;
                }
            },
            instance: { props: { pLblDic: [ "by.object.Dictionary", [ $by.object.TextBox, $by.object.Label ] ], pSourceDic: [ "by.object.Dictionary", [ $by.object.TextBox, Byt.String ] ], pErrorDic: [ "by.object.Dictionary", [ $by.object.TextBox, Byt.String ] ], pRegDic: [ "by.object.Dictionary", [ $by.object.TextBox, Byt.String ] ], pNotNullDic: [ "by.object.Dictionary", [ $by.object.TextBox, Byt.Bool ] ], pColorDic: [ "by.object.Dictionary", [ $by.object.TextBox, $by.object.Color ] ], pMaxLength: [ "by.object.Dictionary", [ $by.object.TextBox, Byt.Int ] ] } }
        },
        ByCommonStrings: {
            type: class ByCommonStrings extends Byt.Object {
                static Format(format, args){
                    if(format == null)
                        return "";
                    if(args == null)
                        args = Byt.Array.$create($by.object.Object, 1, [ 0 ]);
                    for (let i = 0; i < args.length; i++){
                        let arg = args[i];
                        if(arg == null)
                            arg = "";
                        format = format.by$replace("{" + i + "}", arg.by$toString());
                    }
                    return format;
                }
                static Format$1(format, arg1){ return format.by$replace("{0}", arg1 == null ? "" : arg1.by$toString()); }
                static Format$2(format, arg1, arg2){ return format.by$replace("{0}", arg1 == null ? "" : arg1.by$toString()).by$replace("{1}", arg2 == null ? "" : arg2.by$toString()); }
                static Format$3(format, arg1, arg2, arg3){ return $byCommon.object.ByCommonStrings.Format(format, [ arg1, arg2, arg3 ]); }
                static Format$4(format, arg1, arg2, arg3, arg4){ return $byCommon.object.ByCommonStrings.Format(format, [ arg1, arg2, arg3, arg4 ]); }
                static getString(ch, en){ return ($byCommon.object.ByCommonStrings.language || $by.object.System.language) == "en-us" ? en : ch; }
                static Warning_Too_Many_Characters(){ return $byCommon.object.ByCommonStrings.getString("字数太多啦！ ", "Too many characters! "); }
                static Label_Template_Page_Results(tmpPageNum, totalCount){ return $byCommon.object.ByCommonStrings.Format$2($byCommon.object.ByCommonStrings.getString("   共：{0} 页   记录总数：{1}", "Totally {0} pages, {1} records. "), tmpPageNum, totalCount); }
                static Warning_Tree_Cycle_Template(tmpTableName, treeRowID){ return $byCommon.object.ByCommonStrings.Format$2($byCommon.object.ByCommonStrings.getString("树子项的父项不能为自身，这将陷入无限循环!请修改表:{0}中标记构件的列INO:{1}中的值,其不能与自身的父节点相同!", "The parent of a tree item cannot be itself, which will cause a cycle. Please change the INO value {1} of table {0}, it cannot have a value same as itself."), tmpTableName, treeRowID); }
                static UI_relatedDialog_loadingDialog_Title(){ return $byCommon.object.ByCommonStrings.getString("正在装入数据，请稍后...", "Loading data, please wait..."); }
                static UI_relatedDialog_loadingDialog_pLoadingImage_Text(){ return $byCommon.object.ByCommonStrings.getString("装载图片", "The loaded data"); }
                static UI_relatedDialog_notice_Title(){ return $byCommon.object.ByCommonStrings.getString("弹窗显示类似一个公告，仅即时展示一条信息", "Pop up a notice"); }
                static UI_relatedDialog_popupTree_Title(){ return $byCommon.object.ByCommonStrings.getString("显示一个树弹窗，以对象方式", "Popup a tree dialog"); }
                static UI_relatedDialog_popupTree_cTree_Text(){ return $byCommon.object.ByCommonStrings.getString("树", "Tree View"); }
                static UI_relatedDialog_popupTree_cBtnOk_Text(){ return $byCommon.object.ByCommonStrings.getString("确认", "OK"); }
                static UI_relatedDialog_popupTree_cBtnCancel_Text(){ return $byCommon.object.ByCommonStrings.getString("取消", "Cancel"); }
                static UI_relatedDialog_popupTable_Title(){ return $byCommon.object.ByCommonStrings.getString("请选择行", "Please select a row"); }
                static UI_relatedDialog_popupTable_cGrid_Text(){ return $byCommon.object.ByCommonStrings.getString("要显示的网格控件", "Grid View"); }
                static UI_relatedDialog_popupTable_cBtnOk_Text(){ return $byCommon.object.ByCommonStrings.getString("确认", "OK"); }
                static UI_relatedDialog_popupTable_cBtnCancel_Text(){ return $byCommon.object.ByCommonStrings.getString("取消", "Cancel"); }
                static UI_relatedDialog_popupList_Title(){ return $byCommon.object.ByCommonStrings.getString("请选择列表,展示一个选择列表", "Please select a row in this popupList"); }
                static UI_relatedDialog_popupList_cGrid_Text(){ return $byCommon.object.ByCommonStrings.getString("要显示的网格控件", "Grid View"); }
                static UI_relatedDialog_popupList_cBtnOk_Text(){ return $byCommon.object.ByCommonStrings.getString("确认", "OK"); }
                static UI_relatedDialog_popupList_cBtnCancel_Text(){ return $byCommon.object.ByCommonStrings.getString("取消", "Cancel"); }
                static UI_relatedDialog_popupList_Message_PleaseSelectAnItem(){ return $byCommon.object.ByCommonStrings.getString("请选择数据项", "Please select a data-row"); }
                static UI_relatedDialog_popupTextbox_Title(){ return $byCommon.object.ByCommonStrings.getString("请选择,展示一个文本框", "Please select a item in this textbox..."); }
                static UI_relatedDialog_popupTextbox_cLblTitle_Text(){ return $byCommon.object.ByCommonStrings.getString("标题", "Title"); }
                static UI_relatedDialog_popupTextbox_cBtnOk_Text(){ return $byCommon.object.ByCommonStrings.getString("确认", "OK"); }
                static UI_relatedDialog_popupTextbox_cBtnCancel_Text(){ return $byCommon.object.ByCommonStrings.getString("取消", "Cancel"); }
            },
            transmit: [ ],
            static: { props: { language: Byt.String } }
        },
        convert: {
            type: class convert extends Byt.Object {
                static $0(){ this.base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"; }
                static base64ToString(data){
                    let result = new $by.object.StringBuilder();
                    let i = 0;
                    let j = 0;
                    let octets = Byt.Array.$create(Byt.Byte, 1, [ 4 ]);
                    while(i < data.length){
                        octets[j++] = data[i++];
                        if(j == 3){
                            result.append(Byt.Char($byCommon.object.convert.base64[(octets[0] & 252) >> 2]));
                            result.append(Byt.Char($byCommon.object.convert.base64[((octets[0] & 3) << 4) | ((octets[1] & 240) >> 4)]));
                            result.append(Byt.Char($byCommon.object.convert.base64[((octets[1] & 15) << 2) | ((octets[2] & 192) >> 6)]));
                            result.append(Byt.Char($byCommon.object.convert.base64[octets[2] & 63]));
                            j = 0;
                        }
                    }
                    if(j != 0){
                        for (let k = j; k < 3; k++){ octets[k] = 0; }
                        result.append(Byt.Char($byCommon.object.convert.base64[(octets[0] & 252) >> 2]));
                        result.append(Byt.Char($byCommon.object.convert.base64[((octets[0] & 3) << 4) | ((octets[1] & 240) >> 4)]));
                        if(j == 1){ result.append("=="); }
                        else {
                            result.append(Byt.Char($byCommon.object.convert.base64[((octets[1] & 15) << 2)]));
                            result.append("=");
                        }
                    }
                    return result.by$toString();
                }
                static base64ToBytes(base64String){
                    let length = base64String.length;
                    let padding = base64String.endsWith("==") ? 2 : base64String.endsWith("=") ? 1 : 0;
                    let bufferLen = ((((((length * 3) | 0) / 4) | 0) - padding) | 0);
                    let buffer = Byt.Array.$create(Byt.Byte, 1, [ bufferLen ]);
                    let bufferIdx = 0;
                    for (let i = 0; i < length; i += 4){
                        let sextet0 = $byCommon.object.convert.base64.by$indexOf(Byt.Char(base64String[i]).by$toString());
                        let sextet1 = $byCommon.object.convert.base64.by$indexOf(Byt.Char(base64String[((i + 1) | 0)]).by$toString());
                        let sextet2 = $byCommon.object.convert.base64.by$indexOf(Byt.Char(base64String[((i + 2) | 0)]).by$toString());
                        let sextet3 = $byCommon.object.convert.base64.by$indexOf(Byt.Char(base64String[((i + 3) | 0)]).by$toString());
                        let b0 = Byt.Byte(((sextet0 << 2) | (sextet1 >> 4)));
                        let b1 = Byt.Byte((((sextet1 & 15) << 4) | (sextet2 >> 2)));
                        let b2 = Byt.Byte((((sextet2 & 3) << 6) | sextet3));
                        buffer[bufferIdx++] = b0;
                        if(bufferIdx < bufferLen){ buffer[bufferIdx++] = b1; }
                        if(bufferIdx < bufferLen){ buffer[bufferIdx++] = b2; }
                    }
                    return buffer;
                }
            },
            transmit: [ ],
            static: { props: { base64: Byt.String } }
        },
        paging: {
            type: class paging extends Byt.Object {
                $1(f_First, f_Up, f_Current, f_Next, f_Last, f_TotalLabl, f_pageSize){
                    this.cLblPageFirst = f_First;
                    this.cLblPageUp = f_Up;
                    this.cTxtPageCurrent = f_Current;
                    this.cLblPageNext = f_Next;
                    this.cLblPageLast = f_Last;
                    this.cLblTotal = f_TotalLabl;
                    this.pPageSize = f_pageSize;
                    this.init();
                }
                $2(f_First, f_Up, f_Current, f_Next, f_Last, f_TotalLabl, f_Total, f_pageSize){
                    this.cLblPageFirst = f_First;
                    this.cLblPageUp = f_Up;
                    this.cTxtPageCurrent = f_Current;
                    this.cLblPageNext = f_Next;
                    this.cLblPageLast = f_Last;
                    this.cLblTotal = f_TotalLabl;
                    this.pPageSize = f_pageSize;
                    this.setTotalPage(f_Total);
                    this.init();
                }
                init(){
                    this.cLblPageLast.cursor = this.cLblPageNext.cursor = this.cLblPageUp.cursor = this.cLblPageFirst.cursor = "hand";
                    this.cTxtPageCurrent.textChanged.$add(async (sender, args) => {
                        let tmpValue = this.cTxtPageCurrent.text.trim();
                        if(tmpValue.by$isMatch("^[\\d]+$", "multiline")){
                            let tmpGoPage = $by.object.Int.parse(tmpValue);
                            this.cTxtPageCurrent.tag = tmpGoPage;
                            let tmpTotal = this.cLblTotal.tag == null ? 1 : Byt.Int(this.cLblTotal.tag);
                            if(!this.pageChange.by$equals(null)){ await this.pageChange.$invoke(tmpGoPage); }
                        }
                    });
                    this.cLblPageFirst.click.$add((sender, args) => {
                        let tmpCurrentTotal = this.currentTotal();
                        if(tmpCurrentTotal[0] != 1){ this.setCurrentPage(1); }
                    });
                    this.cLblPageLast.click.$add((sender, args) => {
                        let tmpCurrentTotal = this.currentTotal();
                        if(tmpCurrentTotal[0] != tmpCurrentTotal[1]){ this.setCurrentPage(tmpCurrentTotal[1]); }
                    });
                    this.cLblPageUp.click.$add((sender, args) => {
                        let tmpCurrentTotal = this.currentTotal();
                        if(tmpCurrentTotal[0] > 1){ this.setCurrentPage(((tmpCurrentTotal[0] - 1) | 0)); }
                    });
                    this.cLblPageNext.click.$add((sender, args) => {
                        let tmpCurrentTotal = this.currentTotal();
                        this.setCurrentPage(((tmpCurrentTotal[0] + 1) | 0));
                    });
                }
                currentTotal(){
                    let tmpResultValue = Byt.Array.$create(Byt.Int, 1, [ 2 ]);
                    tmpResultValue[0] = this.cTxtPageCurrent.tag == null ? 1 : Byt.Int(this.cTxtPageCurrent.tag);
                    tmpResultValue[1] = this.cLblTotal.tag == null ? 1 : Byt.Int(this.cLblTotal.tag);
                    return tmpResultValue;
                }
                setTotalPage(f_total){
                    let tmpPageNum = 0;
                    if(((f_total % this.pPageSize) | 0) == 0){ tmpPageNum = ((f_total / this.pPageSize) | 0); }
                    else { tmpPageNum = ((((f_total / this.pPageSize) | 0) + 1) | 0); }
                    this.cLblTotal.tag = tmpPageNum;
                    this.cLblTotal.text = $byCommon.object.ByCommonStrings.Label_Template_Page_Results(tmpPageNum, f_total);
                }
                setCurrentPage(f_currentPageIndex){
                    let tmpTotal = this.cLblTotal.tag == null ? 1 : Byt.Int(this.cLblTotal.tag);
                    this.cTxtPageCurrent.tag = f_currentPageIndex;
                    this.cTxtPageCurrent.text = f_currentPageIndex.by$toString();
                    this.cLblPageNext.cursor = this.cLblPageLast.cursor = this.cLblPageFirst.cursor = this.cLblPageUp.cursor = "hand";
                }
            },
            instance: { props: { cLblPageFirst: $by.object.Label, cLblPageUp: $by.object.Label, cTxtPageCurrent: $by.object.TextBox, cLblPageNext: $by.object.Label, cLblPageLast: $by.object.Label, cLblTotal: $by.object.Label, pPageSize: Byt.Int }, events: [ "pageChange" ] }
        },
        dialogTran: {
            type: class dialogTran extends Byt.Object {
                static setPopupWidthHeight(f_dialog, f_popupDialog, f_percent){
                    f_popupDialog.width = $byCommon.object.dialogTran.getWidth(f_dialog, f_percent);
                    f_popupDialog.height = $byCommon.object.dialogTran.getHeight(f_dialog, f_percent);
                }
                static getHeight(f_dialog, f_percent){ return Byt.Int((f_dialog.height * f_percent)); }
                static getWidth(f_dialog, f_percent){ return Byt.Int((f_dialog.width * f_percent)); }
            }
        },
        verifyReg: {
            type: class verifyReg extends Byt.Object {
                static getVeriable(f_min, f_max){
                    if(f_min >= 1){ f_min = ((f_min - 1) | 0); }
                    return "^[a-zA-Z_]{1}[a-zA-Z0-9_]{" + Byt.String(f_min.by$toString()) + "," + Byt.String(f_max.by$toString()) + "}$";
                }
                static getText(f_min, f_max){ return "^[a-zA-Z0-9_\\xff-\\uffff,.; \\r\\n\\t   ]{" + Byt.String(f_min.by$toString()) + "," + Byt.String(f_max.by$toString()) + "}$"; }
                static getStrictText(f_min, f_max){
                    if(f_min >= 1){ f_min = ((f_min - 1) | 0); }
                    return "^[a-zA-Z\\xff-\\uffff{1}][a-zA-Z0-9_\\xff-\\uffff]{" + Byt.String(f_min.by$toString()) + "," + Byt.String(f_max.by$toString()) + "}$";
                }
                static getInteger(f_min, f_max){ return "^[0-9]{" + Byt.String(f_min.by$toString()) + "," + Byt.String(f_max.by$toString()) + "}$"; }
                static verfyLength(f_min, f_max){ return "^.{" + Byt.String(f_min.by$toString()) + "," + Byt.String(f_max.by$toString()) + "}$"; }
            },
            transmit: [ ]
        },
        verifyRequest: {
            type: class verifyRequest extends Byt.Object {
                static isOk(f_requestValue, f_max){
                    if(f_requestValue == null || f_requestValue == "" || f_requestValue.by$indexOf("'") > -1 || f_requestValue.by$indexOf("\"") > -1 || f_requestValue.length > f_max)
                        return false;
                    else 
                        return true;
                }
            },
            transmit: [ ]
        },
        verifyRowIdentity: {
            type: class verifyRowIdentity extends Byt.Object {
                static isExists(f_verifyList, f_tableIdentity){
                    for (let item of f_verifyList){
                        let tmpVia = false;
                        for (let ID of f_tableIdentity){
                            if(ID == item.$identity())
                                tmpVia = true;
                        }
                        if(!tmpVia)
                            return false;
                    }
                    return true;
                }
            },
            transmit: [ ]
        }
    },
    identity: {
        relatedDialog: {
            type: class relatedDialog extends Byt.Identity {
                static async Loading(){
                    let tmpWaiting = await $byCommon.dialog.relatedDialog$loadingDialog.$new($byCommon.newidentitys.dialogRelated, $ => $.$0());
                    tmpWaiting.show();
                    return tmpWaiting;
                }
                static setWidthHeight(f_dialog, f_width){
                    f_dialog.width = f_width;
                    f_dialog.height = Byt.Int((Byt.Decimal["*"](Byt.Decimal(f_width), Byt.Decimal("0.618"))));
                }
                static async popupTreeSelect(f_TreeList, f_returnRow, f_isMultSelect, f_id, f_parentID, f_name){
                    let tmpWaiting = await $byCommon.dialog.relatedDialog$popupTree.$new($byCommon.newidentitys.dialogRelated, $ => $.$1(f_TreeList, f_returnRow, f_isMultSelect, f_id, f_parentID, f_name));
                    await tmpWaiting.showDialog();
                }
            }
        },
        generalControl: {
            type: class generalControl extends Byt.Identity {
                static async fillTree(f_tree, f_TreeList, f_returnRowList, f_isMultSelect, f_id, f_parentID, f_name){
                    f_tree.isMultiLine = f_isMultSelect;
                    let tmpReturnRowDic = new $by.object.Dictionary();
                    for (let item of f_returnRowList){
                        if(!tmpReturnRowDic.containsKey(item.i$access("iID")))
                            tmpReturnRowDic.add(item.i$access("iID"), null);
                    }
                    let tmpNodeDic = new $by.object.Dictionary();
                    for (let treeRow of f_TreeList){
                        let tmpNO = treeRow.i$access("iID");
                        let tmpForNode = new $by.object.TreeNode();
                        tmpForNode.text = $byCommon.identity.relatedField.getFieldValue(treeRow, f_name);
                        tmpForNode.tag = treeRow;
                        tmpNodeDic.add(tmpNO, tmpForNode);
                        if(tmpReturnRowDic.containsKey(treeRow.i$access("iID")))
                            tmpReturnRowDic.add(treeRow.i$access("iID"), tmpForNode);
                    }
                    for (let treeRow of f_TreeList){
                        let tmpParentID = $byCommon.identity.relatedField.getFieldValue(treeRow, f_parentID);
                        if(!tmpNodeDic.containsKey(tmpParentID)){ f_tree.add(tmpNodeDic.$get(treeRow.i$access("iID"))); }
                        else {
                            if(tmpParentID == treeRow.i$access("iID")){
                                let tmpTableName = ($by.identity.Table.$convert(treeRow)).$to().name;
                                await $by.object.Message.alert($byCommon.object.ByCommonStrings.Warning_Tree_Cycle_Template(tmpTableName, treeRow.i$access("iID")));
                            }
                            else { tmpNodeDic.$get(tmpParentID).add(tmpNodeDic.$get(treeRow.i$access("iID"))); }
                        }
                    }
                    if(f_returnRowList.count > 0){
                        let tmpSelectRowList = new $by.object.List();
                        for (let item of tmpReturnRowDic){
                            if(item.value != null)
                                tmpSelectRowList.add(item.value);
                        }
                        f_tree.selectedNodes = new $by.object.ReadOnlyList(tmpSelectRowList);
                    }
                }
            }
        },
        relatedTable: {
            type: class relatedTable extends Byt.Identity {
                static $0(){ this.pGridDic = new $by.object.Dictionary(); }
                static findAddUpdateDelete(f_source, f_newList){
                    let tmpChangeDic = new $by.object.Dictionary();
                    tmpChangeDic.add("insert", new $by.object.List());
                    tmpChangeDic.add("update", new $by.object.List());
                    tmpChangeDic.add("delete", new $by.object.List());
                    for (let item of f_newList){
                        let tmpObj = $byCommon.identity.relatedTable.findSourceRow(f_source, item);
                        if(tmpObj == null){ tmpChangeDic.$get("insert").add(item); }
                        else {
                            if(tmpObj.by$equals(item)){}
                            else { tmpChangeDic.$get("update").add(item); }
                        }
                    }
                    for (let item of f_source){
                        let tmpResult = $byCommon.identity.relatedTable.findSourceRow(f_newList, item);
                        if(tmpResult == null){ tmpChangeDic.$get("delete").add(item); }
                    }
                    return tmpChangeDic;
                }
                static findSourceRow(f_source, f_comparisonRow){
                    for (let item of f_source){
                        if(Byt.Row["~=="](item, f_comparisonRow)){ return item; }
                    }
                    return null;
                }
                static cloneListRow(f_sourceList){
                    let tmpList = new $by.object.List();
                    for (let item of f_sourceList){ tmpList.add(item.clone()); }
                    return tmpList;
                }
                static curdRegister(f_grid){
                    if(!$byCommon.identity.relatedTable.pGridDic.containsKey(f_grid)){ $byCommon.identity.relatedTable.pGridDic.add(f_grid, $byCommon.identity.relatedTable.cloneListRow(f_grid.rows.toList())); }
                    else { $byCommon.identity.relatedTable.pGridDic.$set(f_grid, $byCommon.identity.relatedTable.cloneListRow(f_grid.rows.toList())); }
                }
                static curdCancel(f_grid){
                    if($byCommon.identity.relatedTable.pGridDic.containsKey(f_grid)){ $byCommon.identity.relatedTable.pGridDic.remove(f_grid); }
                }
                static curdChangeDic(f_grid){
                    if($byCommon.identity.relatedTable.pGridDic.containsKey(f_grid)){
                        let changedRows = $byCommon.identity.relatedTable.findAddUpdateDelete($byCommon.identity.relatedTable.pGridDic.$get(f_grid), f_grid.rows.toList());
                        return changedRows;
                    }
                    return new $by.object.Dictionary();
                }
                static curdOldRowList(f_grid){
                    if($byCommon.identity.relatedTable.pGridDic.containsKey(f_grid)){ return $byCommon.identity.relatedTable.pGridDic.$get(f_grid); }
                    return null;
                }
                static curdOldRowList$1(f_grid, f_newRowList){
                    let tmpResultValue = new $by.object.List();
                    if($byCommon.identity.relatedTable.pGridDic.containsKey(f_grid)){
                        for (let itemNew of f_newRowList){
                            for (let item of $byCommon.identity.relatedTable.pGridDic.$get(f_grid)){
                                if(Byt.Row["~=="](item, itemNew)){
                                    tmpResultValue.add(item);
                                    break;
                                }
                            }
                        }
                    }
                    return tmpResultValue;
                }
                static setAutoGridStringRow(f_grid, f_rowArr, f_fieldName, f_value){
                    let tmpFieldArr = f_fieldName.by$split(Byt.Char("."));
                    let tmpFieldName = tmpFieldArr[((tmpFieldArr.length - 1) | 0)];
                    for (let i = 0; i < f_grid.gridColumns.count; i++){
                        let item = f_grid.gridColumns.$get(i);
                        if(item.name == tmpFieldName){
                            f_rowArr[i] = f_value;
                            break;
                        }
                    }
                }
                static isExists(f_sourceRow, f_targetList){
                    for (let item of f_targetList){
                        if(Byt.Row["~=="](item, f_sourceRow)){ return true; }
                    }
                    return false;
                }
                static isExists$1(f_sourceList, f_targetList){
                    let tmpResultList = new $by.object.List();
                    for (let item of f_sourceList){
                        if($byCommon.identity.relatedTable.isExists(item, f_targetList))
                            tmpResultList.add(item);
                    }
                    return tmpResultList;
                }
                static isNotExists(f_sourceList, f_targetList){
                    let tmpResultList = new $by.object.List();
                    for (let item of f_sourceList){
                        if(!$byCommon.identity.relatedTable.isExists(item, f_targetList))
                            tmpResultList.add(item);
                    }
                    return tmpResultList;
                }
            },
            static: { props: { pGridDic: [ "by.object.Dictionary", [ $by.object.Grid, [ "by.object.List", Byt.Row ] ] ] } }
        },
        general: {
            type: class general extends Byt.Identity {
                static $0(){ this.pServerDiffSeconds = 0; }
                static findComponentGridColumn(f_grid, f_field){
                    for (let i = 0; i < f_grid.gridColumns.count; i++){
                        if(f_grid.gridColumns.$get(i).field == f_field.$to()){ return i; }
                    }
                    return -1;
                }
                static async getGuidPrefix(){
                    
                    { return await $byCommon.$remote({ kind: "SKILL", NO: 19, return: Byt.String }); }
                }
                static async getGuid(){
                    let tmpResultValue = "";
                    
                    {
                        if($byCommon.identity.general.guidPrefix == null || $byCommon.identity.general.guidPrefix == "" || $byCommon.identity.general.serialNumber >= 65535){
                            $byCommon.identity.general.guidPrefix = await $byCommon.$remote({ kind: "SKILL", NO: 19, return: Byt.String });
                            $byCommon.identity.general.serialNumber = 0;
                        }
                    }
                    let tmpSN = ++$byCommon.identity.general.serialNumber;
                    tmpResultValue = Byt.String($byCommon.identity.general.guidPrefix) + Byt.String($byCommon.identity.general.getPlusZero($by.object.Int.toString(tmpSN, 16), 4));
                    return tmpResultValue;
                }
                static getPlusZero(f_num, f_length){
                    let tmpSb = new $by.object.StringBuilder();
                    for (let i = f_num.length; i < f_length; i++){ tmpSb.append("0"); }
                    return Byt.String(tmpSb.by$toString()) + Byt.String(f_num);
                }
                static getNoRepeatName(f_list, f_name){
                    if(f_list.contains(f_name)){
                        for (let i = 1; i < 1000; i++){
                            let tmpValue = Byt.String(f_name) + "_" + i;
                            if(!f_list.contains(tmpValue)){ return tmpValue; }
                        }
                    }
                    return f_name;
                }
                static async getServerDatetime(){
                    
                    {
                        if(Byt.DateTime.by$equals($byCommon.identity.general.pServerDateTime, null) || $byCommon.identity.general.pServerDateTime.year == 1){
                            $byCommon.identity.general.pServerDateTime = await $byCommon.$remote({ kind: "SKILL", NO: 23, return: Byt.DateTime });
                            $byCommon.identity.general.pServerDiffSeconds = $byCommon.identity.general.pServerDateTime.diffSeconds($by.object.DateTime.getNow());
                        }
                        return $by.object.DateTime.getNow().addSeconds(Byt.Int($byCommon.identity.general.pServerDiffSeconds));
                    }
                }
                static joinString(f_sourceOldStr, f_newStr){
                    if(f_sourceOldStr == null || f_sourceOldStr == ""){ return f_newStr; }
                    return Byt.String(f_sourceOldStr) + "," + Byt.String(f_newStr);
                }
                static getIDGroup(f_list){
                    let tmpSb = new $by.object.StringBuilder();
                    for (let i = 0; i < f_list.count; i++){
                        if(i == 0){ tmpSb.append(f_list.$get(i).i$access("iID").by$toString()); }
                        else { tmpSb.append("," + Byt.String(f_list.$get(i).i$access("iID").by$toString())); }
                    }
                    return tmpSb.by$toString();
                }
                static contains(f_str1, f_str2){
                    f_str1 = f_str1.by$toLower();
                    f_str2 = f_str2.by$toLower();
                    if(f_str1.by$contains(f_str2)){ return true; }
                    else { return false; }
                }
                static contains$1(f_stringList, f_str){
                    for (let i = 0; i < f_stringList.count; i++){ f_stringList.$set(i, f_stringList.$get(i).by$toLower()); }
                    f_str = f_str.by$toLower();
                    if(f_stringList.contains(f_str)){ return true; }
                    else { return false; }
                }
                static copyRow(f_Row, f_copy){
                    for (let item of f_Row.cells){
                        for (let itemCopy of f_copy.cells){
                            if(item.field.name == itemCopy.field.name){
                                item.value = itemCopy.value;
                                break;
                            }
                        }
                    }
                }
            },
            static: { props: { serialNumber: Byt.Int, guidPrefix: Byt.String, pServerDateTime: Byt.DateTime, pServerDiffSeconds: Byt.Double } }
        },
        relatedGrid: {
            type: class relatedGrid extends Byt.Identity {
                static getRelationRows(f_grid, f_list){
                    let tmpResultList = new $by.object.List();
                    for (let item of f_grid.rows){
                        for (let itemSelectRow of f_list){
                            if(Byt.Row["~=="](item, itemSelectRow)){ tmpResultList.add(item); }
                        }
                    }
                    return tmpResultList;
                }
                static deleteGridRelationRows(f_grid, f_list){
                    let tmpResultList = $byCommon.identity.relatedGrid.getRelationRows(f_grid, f_list);
                    for (let item of tmpResultList){ f_grid.removeChild(item); }
                }
                static updateGridRelationRows(f_grid, f_list){
                    for (let item of f_grid.rows){
                        for (let itemNewsRow of f_list){
                            if(Byt.Row["~=="](item, itemNewsRow)){
                                Byt.Row["~="](item, itemNewsRow);
                                break;
                            }
                        }
                    }
                }
                static setSelectRows(f_grid, f_selectList){
                    let tmpResultList = $byCommon.identity.relatedGrid.getRelationRows(f_grid, f_selectList);
                    f_grid.selectedRows = new $by.object.ReadOnlyList(tmpResultList);
                }
                static refresh(f_grid, f_row){
                    for (let gridRow of f_grid.rows){
                        if(Byt.Row["~=="](gridRow, f_row)){
                            let r = gridRow;
                            Byt.Row["~="](r, f_row);
                            return;
                        }
                    }
                }
                static GridRowToTableRow(f_GridRow, f_grid, f_Table){
                    let tmpResultRow = new $by.object.Row().$bindIdentity(f_Table);
                    for (let item of tmpResultRow.cells){
                        for (let i = 0; i < f_grid.gridColumns.count; i++){
                            if(f_grid.gridColumns.$get(i).name == item.field.name){ item.value = f_GridRow.cells.$get(i).text; }
                        }
                    }
                    return tmpResultRow;
                }
            }
        },
        relatedField: {
            type: class relatedField extends Byt.Identity {
                static getFieldValue(f_row, f_fieldNmae){
                    for (let item of f_row.cells){
                        if(item.field.name == f_fieldNmae)
                            return item.value == null ? null : item.value.by$toString();
                    }
                    return null;
                }
                static getFieldSummery(f_row, f_fieldNmae){
                    for (let item of f_row.cells){
                        if(item.field.name == f_fieldNmae)
                            return item.value == null ? null : item.field.summary;
                    }
                    return null;
                }
            }
        }
    },
    dialog: {
        relatedDialog$loadingDialog: {
            type: class loadingDialog extends Byt.Dialog {
                $0(){
                    this.initUI();
                    this.pLoadingImage.image = $by.object.Ku.getKu("byCommon").getResource("loading.gif").toImage();
                    this.pLoadingImage.dock = "fill";
                    this.width = 318;
                    this.height = 196;
                }
                initUI(){
                    this.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_loadingDialog_Title();
                    this.pLoadingImage.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_loadingDialog_pLoadingImage_Text();
                }
            },
            dialog: { props: { pLoadingImage: $by.object.ImageBox } }
        },
        relatedDialog$notice: {
            type: class notice extends Byt.Dialog {
                $1(f_dialogTitle, f_title, f_content){
                    this.text = f_dialogTitle;
                    this.lblTitle.element.innerHTML = "<h2 style=\"padding:12px;\">" + Byt.String(f_title) + "</h2>";
                    this.lblTitle.element.style.setProperty("text-align", "center");
                    this.lblTitle.element.parentElement.style.setProperty("border", "none");
                    this.lblContent.element.innerHTML = f_content;
                    this.lblContent.element.parentElement.style.setProperty("border", "none");
                    this.lblContent.element.style.setProperty("padding", "20px 12px 20px 12px");
                }
            },
            dialog: { props: { lblTitle: $by.object.Panel, lblContent: $by.object.Panel } }
        },
        relatedDialog$popupTree: {
            type: class popupTree extends Byt.Dialog {
                async $1(f_TreeList, f_returnRowList, f_isMultSelect, f_id, f_parentID, f_name){
                    this.initUI();
                    await $byCommon.identity.generalControl.fillTree(this.cTree, f_TreeList, f_returnRowList, f_isMultSelect, f_id, f_parentID, f_name);
                    this.cBtnCancel.click.$add((sender, args) => {
                        f_returnRowList.clear();
                        this.close();
                    });
                    this.cBtnOk.click.$add((sender, args) => { this.isOk(f_returnRowList); });
                    this.cTree.nodeDoubleClick.$add((sender, treeNodeArgs) => { this.isOk(f_returnRowList); });
                }
                initUI(){
                    this.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTree_Title();
                    this.cTree.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTree_cTree_Text();
                    this.cBtnOk.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTree_cBtnOk_Text();
                    this.cBtnCancel.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTree_cBtnCancel_Text();
                }
                isOk(f_returnRow){
                    f_returnRow.clear();
                    if(this.cTree.selectedNodes.count > 0){
                        for (let item of this.cTree.selectedNodes)
                            f_returnRow.add(Byt.Row.$convert(item.tag, $by.identity.Table));
                    }
                    this.close();
                }
            },
            dialog: { props: { cTree: $by.object.Tree, cBtnOk: $by.object.Button, cBtnCancel: $by.object.Button } }
        },
        relatedDialog$popupTable: {
            type: class popupTable extends Byt.Dialog {
                $1(f_showList, f_returnRowList, f_isMultSelect, f_fieldArr){
                    this.initUI();
                    if(f_showList.count > 0){
                        for (let i = 0; i < f_fieldArr.length; i++){
                            let tmpSummery = $byCommon.identity.relatedField.getFieldSummery(f_showList.$get(0), f_fieldArr[i]);
                            tmpSummery = tmpSummery == null || tmpSummery == "" ? f_fieldArr[i] : tmpSummery;
                            this.cGrid.addColumn(new $by.object.GridColumn().$init($ => { $.text = tmpSummery; }));
                        }
                        for (let item of f_showList){
                            let tmpFieldArr = Byt.Array.$create(Byt.String, 1, [ f_fieldArr.length ]);
                            for (let i = 0; i < f_fieldArr.length; i++){ tmpFieldArr[i] = $byCommon.identity.relatedField.getFieldValue(item, f_fieldArr[i]); }
                            this.cGrid.add(tmpFieldArr);
                        }
                        this.cGrid.cellDoubleClick.$add((sender, gridCellArgs) => { this.complete(f_showList, f_returnRowList, f_isMultSelect); });
                        this.cBtnCancel.click.$add((sender, args) => { this.close(); });
                        this.cBtnOk.click.$add((sender, args) => { this.complete(f_showList, f_returnRowList, f_isMultSelect); });
                    }
                }
                initUI(){
                    this.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTable_Title();
                    this.cGrid.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTable_cGrid_Text();
                    this.cBtnOk.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTable_cBtnOk_Text();
                    this.cBtnCancel.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTable_cBtnCancel_Text();
                }
                complete(f_showList, f_returnRowList, f_isMultSelect){
                    f_returnRowList.clear();
                    for (let item of this.cGrid.selectedGridRows)
                        f_returnRowList.add(f_showList.$get(item.rowIndex));
                    this.close();
                }
            },
            dialog: { props: { cGrid: $by.object.Grid, cBtnOk: $by.object.Button, cBtnCancel: $by.object.Button } }
        },
        relatedDialog$popupList: {
            type: class popupList extends Byt.Dialog {
                $1(f_showList, f_returnRowList, f_isMultSelect, f_windowWidth, f_windowHeight){
                    this.initUI();
                    this.width = f_windowWidth;
                    this.height = f_windowHeight;
                    if(f_showList.count > 0){
                        this.cGrid.addColumn($byCommon.object.ByCommonStrings.UI_relatedDialog_popupList_Message_PleaseSelectAnItem());
                        let tmpReturnList = new $by.object.List();
                        for (let item of f_showList){
                            this.cGrid.add([ item ]);
                            let tmpIsOk = false;
                            for (let itemIsOk of f_returnRowList){
                                if(item == itemIsOk){
                                    tmpIsOk = true;
                                    break;
                                }
                            }
                            if(tmpIsOk)
                                tmpReturnList.add(this.cGrid.gridRows.$get(((this.cGrid.gridRows.count - 1) | 0)));
                        }
                        if(tmpReturnList.count > 0)
                            this.cGrid.selectedGridRows = new $by.object.ReadOnlyList(tmpReturnList);
                        this.cGrid.cellDoubleClick.$add((sender, gridCellArgs) => { this.complete(f_showList, f_returnRowList, f_isMultSelect); });
                        this.cBtnCancel.click.$add((sender, args) => { this.close(); });
                        this.cBtnOk.click.$add((sender, args) => { this.complete(f_showList, f_returnRowList, f_isMultSelect); });
                    }
                }
                initUI(){
                    this.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupList_Title();
                    this.cGrid.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupList_cGrid_Text();
                    this.cBtnOk.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupList_cBtnOk_Text();
                    this.cBtnCancel.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupList_cBtnCancel_Text();
                }
                complete(f_showList, f_returnRowList, f_isMultSelect){
                    f_returnRowList.clear();
                    for (let item of this.cGrid.selectedGridRows)
                        f_returnRowList.add(f_showList.$get(item.rowIndex));
                    this.close();
                }
            },
            dialog: { props: { cGrid: $by.object.Grid, cBtnOk: $by.object.Button, cBtnCancel: $by.object.Button } }
        },
        relatedDialog$popupTextbox: {
            type: class popupTextbox extends Byt.Dialog {
                $1(f_label, f_returnRowList, f_windowWidth, f_windowHeight){
                    this.cContent.$init($ => { $.isMultiLine = true; });
                    this.initUI();
                    { this.cContent.height = 200; }
                    this.cLblTitle.text = f_label;
                    this.cContent.toolTip = f_label;
                    if(f_returnRowList.count > 0)
                        this.cContent.text = f_returnRowList.$get(0);
                    this.cBtnOk.click.$add((sender, args) => {
                        f_returnRowList.clear();
                        f_returnRowList.add(this.cContent.text.trim());
                        this.close();
                    });
                    this.cBtnCancel.click.$add((sender, args) => { this.close(); });
                }
                initUI(){
                    this.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTextbox_Title();
                    this.cLblTitle.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTextbox_cLblTitle_Text();
                    this.cBtnOk.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTextbox_cBtnOk_Text();
                    this.cBtnCancel.text = $byCommon.object.ByCommonStrings.UI_relatedDialog_popupTextbox_cBtnCancel_Text();
                }
            },
            dialog: { props: { cLblTitle: $by.object.Label, cContent: $by.object.TextBox, cBtnOk: $by.object.Button, cBtnCancel: $by.object.Button } }
        }
    },
    newidentitys: { dialogRelated: { type: "byCommon.identity.relatedDialog" } }
}))