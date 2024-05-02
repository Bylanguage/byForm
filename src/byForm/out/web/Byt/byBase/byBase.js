Byt.defineKu("byBase", [ "by", "byCommon", "byExternal", "byInterface" ], ($by, $byCommon, $byExternal, $byInterface, $byBase) => ({
    enum: {
        sort: { asc: 0, desc: 1 },
        ButtonState: { update: 0, inquiry: 1, Lock: 2, init: 3 }
    },
    object: {
        buttonLock: {
            type: class buttonLock extends Byt.Object {
                $1(f_inquiry, f_AddUpdate, f_Init){
                    this.pCacheList = new $by.object.List();
                    this.pInquiry = new $by.object.List();
                    this.pAddUpdate = new $by.object.List();
                    this.pInit = new $by.object.List();
                    this.pInquiry.addRange(f_inquiry);
                    this.pAddUpdate.addRange(f_AddUpdate);
                    this.pInit.addRange(f_Init);
                    this.appendCache(this.pInquiry);
                    this.appendCache(this.pAddUpdate);
                    this.appendCache(this.pInit);
                }
                appendCache(f_list){
                    for (let item of f_list){
                        if(!this.pCacheList.contains(item)){ this.pCacheList.add(item); }
                    }
                }
                setButtonState(f_ButtonState){
                    switch(f_ButtonState){
                        case "init":
                            this.setState(this.pInit);
                            break;
                        case "inquiry":
                            this.setState(this.pInquiry);
                            break;
                        case "update":
                            this.setState(this.pAddUpdate);
                            break;
                        case "Lock":
                            this.setState(new $by.object.List());
                            break;
                    }
                }
                setState(f_enablelist){
                    for (let item of this.pCacheList){
                        if(!f_enablelist.contains(item)){ item.isEnabled = false; }
                        else { item.isEnabled = true; }
                    }
                }
            },
            instance: { props: { pCacheList: [ "by.object.List", $by.object.Control ], pInquiry: [ "by.object.List", $by.object.Control ], pAddUpdate: [ "by.object.List", $by.object.Control ], pInit: [ "by.object.List", $by.object.Control ] } }
        },
        mergeDialog: {
            type: class mergeDialog extends Byt.Object {
                $1(f_currentDialog, f_table){
                    this.pCtrList = new $by.object.List();
                    this.pMergeDialog = $by.object.Manager.getMergeDialog(f_currentDialog);
                    if(this.pMergeDialog != null){
                        let tmpIMaster = $byInterface.dialog.IBy$IMaster.$convert(this.pMergeDialog);
                        if(tmpIMaster != null && $byInterface.dialog.IBy$ISlave.$check(f_currentDialog)){ tmpIMaster.$access([ $byInterface.dialog.IBy$IMaster, "pSlaveDialogList" ]).add($byInterface.dialog.IBy$ISlave.$convert(f_currentDialog)); }
                        let tmpTargetList = new $by.object.List();
                        this.tranControl(this.pMergeDialog.children, tmpTargetList);
                        let tmpCurrentList = new $by.object.List();
                        this.tranControl(f_currentDialog.children, tmpCurrentList);
                        for (let item of tmpCurrentList){
                            let itemCurId = $by.object.Control.$convert(item, $by.identity.Table);
                            for (let itemMerge of tmpTargetList){
                                let itemMergeId = $by.object.Control.$convert(itemMerge, $by.identity.Table);
                                if(itemCurId.$identity().isReference(itemMergeId.$identity())){
                                    let tmpMergeRelation = new $byBase.object.mergeRelationCtrl().$init($ => $.$1(Byt.Identity(item), itemMergeId));
                                    this.pCtrList.add(tmpMergeRelation);
                                    break;
                                }
                            }
                        }
                        if(tmpCurrentList.count == 0){
                            for (let itemMerge of tmpTargetList){
                                if(itemMerge.$identity().isReference(f_table)){
                                    let tmpMergeRelation = new $byBase.object.mergeRelationCtrl().$init($ => $.$1(f_table, itemMerge));
                                    this.pCtrList.add(tmpMergeRelation);
                                    break;
                                }
                            }
                        }
                    }
                }
                tranControl(f_rdList, f_resultList){
                    for (let item of f_rdList){
                        if($by.object.Grid.$check(item, $by.identity.Table) || $by.object.Tree.$check(item, $by.identity.Table)){ f_resultList.add($by.object.Control.$convert(item, $by.identity.Table)); }
                        else if($by.object.Panel.$check(item)){ this.tranControl(($by.object.Panel.$convert(item)).children, f_resultList); }
                        else if($by.object.TableLayoutPanel.$check(item)){ this.tranControl(($by.object.TableLayoutPanel.$convert(item)).children, f_resultList); }
                    }
                }
                getMergeRelationCtrl(f_ctrlId){
                    for (let item of this.pCtrList){
                        if(item.pCurrentCtr == f_ctrlId){ return item; }
                    }
                    return null;
                }
                static async getAddUpdateDeleteList(f_ISlaveList, f_addList, f_updateList, f_deleteList){
                    for (let item of f_ISlaveList){
                        let tmpDic = await item.$access([ $byInterface.dialog.IBy$ISlave, "getAddDeleteUpdate" ])();
                        for (let itemCurd of tmpDic){
                            switch(itemCurd.key){
                                case "insert":
                                    f_addList.addRange(itemCurd.value);
                                    break;
                                case "update":
                                    f_updateList.addRange(itemCurd.value);
                                    break;
                                case "delete":
                                    f_deleteList.addRange(itemCurd.value);
                                    break;
                            }
                        }
                    }
                }
                static async verifySlaveDialog(f_IMaster){
                    for (let item of f_IMaster.$access([ $byInterface.dialog.IBy$IMaster, "pSlaveDialogList" ])){
                        if(!await item.$access([ $byInterface.dialog.IBy$ISlave, "verifyAddDeleteUpdate" ])())
                            return false;
                    }
                    return true;
                }
            },
            instance: { props: { pMergeDialog: $by.object.Dialog, pCtrList: [ "by.object.List", "byBase.object.mergeRelationCtrl" ] } }
        },
        ByBaseStrings: {
            type: class ByBaseStrings extends Byt.Object {
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
                static Format$3(format, arg1, arg2, arg3){ return $byBase.object.ByBaseStrings.Format(format, [ arg1, arg2, arg3 ]); }
                static Format$4(format, arg1, arg2, arg3, arg4){ return $byBase.object.ByBaseStrings.Format(format, [ arg1, arg2, arg3, arg4 ]); }
                static getString(ch, en){ return ($byBase.object.ByBaseStrings.language || $by.object.System.language) == "en-us" ? en : ch; }
                static Warning_Database_Insert_Failed(){ return $byBase.object.ByBaseStrings.getString("对数据库 insert 失败", "database insert failed"); }
                static Warning_Database_Update_Failed(){ return $byBase.object.ByBaseStrings.getString("对数据库 update 失败", "database update failed"); }
                static Warning_Database_Delete_Failed(){ return $byBase.object.ByBaseStrings.getString("对数据库 delete 失败", "database delete failed"); }
                static Warning_User_Not_Login(){ return $byBase.object.ByBaseStrings.getString("当前用户还没有登录", "The current user has not logined."); }
                static Warning_Tree_Cycle_Template(tmpTableName, treeRowID){ return $byBase.object.ByBaseStrings.Format$2($byBase.object.ByBaseStrings.getString("树子项的父项不能为自身，这将陷入无限循环!请修改表:{0}中标记构件的列INO:{1}中的值,其不能与自身的父节点相同!", "The parent of a tree item cannot be itself, which will cause a cycle. Please change the INO value {1} of table {0}, it cannot have a value same as itself."), tmpTableName, treeRowID); }
                static Warning_EditArea_Verify_Failed(){ return $byBase.object.ByBaseStrings.getString("编辑区填写的内容不合法:", "The verification of this editArea failed: "); }
                static Warning_Insert_Failed(){ return $byBase.object.ByBaseStrings.getString("增加数据失败！", "Insertion failed "); }
                static Warning_Please_Select_A_Line(){ return $byBase.object.ByBaseStrings.getString("请选择一行，再尝试该操作！", "Please select a line and try again!"); }
                static Warning_Cannot_Select_Multiple_Lines(){ return $byBase.object.ByBaseStrings.getString("不能多选，一次仅能选择一行编辑！", "Cannot select multiple lines, only one line can be edited at a time."); }
                static Warning_Sure_To_Delete(){ return $byBase.object.ByBaseStrings.getString("确认要删除？", "Are you sure to delete?"); }
                static Warning_SQL_Failed(){ return $byBase.object.ByBaseStrings.getString("执行sql没有成功:", "SQL execute failed, details: "); }
                static Warning_TreeNode_Cannot_Parent_To_Itself(){ return $byBase.object.ByBaseStrings.getString("当前节点与父节点不能一样！", "Cannot set parent node of a treenode to itself!"); }
                static Warning_Please_Select_A_TreeNode(){ return $byBase.object.ByBaseStrings.getString("请先选择一个节点后，再尝试该操作！", "Please select a tree node and try again!"); }
                static Warning_Sure_To_Delete_Nodes(){ return $byBase.object.ByBaseStrings.getString("确认要删除当前节点，及其所属的所有子节点吗？", "Are you sure to delete this node and all its descendant nodes?"); }
                static Warning_Bridge_Cannot_Find_Reference(){ return $byBase.object.ByBaseStrings.getString("没有找到对应的表级关系信息，或者通过关系没有找到对应的popup会话窗体信息！", "Cannot find any corresponding table-identity via field-reference."); }
                static Message_Add_Completed(){ return $byBase.object.ByBaseStrings.getString("新建成功！", "Add completed! "); }
                static Message_Add_Failed(){ return $byBase.object.ByBaseStrings.getString("新建失败！", "Add failed. "); }
                static Message_Modify_Completed(){ return $byBase.object.ByBaseStrings.getString("修改成功！", "Modify Completed!"); }
                static Message_Modify_Failed(){ return $byBase.object.ByBaseStrings.getString("修改失败！", "Modify failed "); }
                static Warning_Slave_Must_Use_With_Master(){ return $byBase.object.ByBaseStrings.getString("扩展表身份只能与其对应的主表配合展表，不支持独立会话窗体进行操作！！", "Slave or extend dialog must be used with a manager and a host, cannot use this dialog alone!"); }
                static Warning_DetailHost_Not_Master(){ return $byBase.object.ByBaseStrings.getString("当前合并的主dialog 没有实现 IBy.IMaster 接口，合并后将仅支持查询，不支持update、insert、delete操作！", "The host of this dialog is not a 'IBy.IMaster, only query operation is supported!"); }
                static Warning_Detail_Must_Use_With_Master(){ return $byBase.object.ByBaseStrings.getString("detail 为从表身份，需要与其他主身份dialog 一起联合展示，\r\n不支持独立展示，请将当前的dialog合并到其他主dialog后才能展示！", "The detail dialog must be used with a manager and a host, cannot use this dialog alone!"); }
                static UI_popupTable_popup_Title(){ return $byBase.object.ByBaseStrings.getString("弹窗选择多行或一行", "Select one or more lines in this popup dialog"); }
                static UI_popupTable_popup_cGrid_Text(){ return $byBase.object.ByBaseStrings.getString("表格网格控件", "Grid control"); }
                static UI_popupTable_popup_cBtnQuery_Text(){ return $byBase.object.ByBaseStrings.getString("检索", "Query"); }
                static UI_popupTable_popup_cBtnComplete_Text(){ return $byBase.object.ByBaseStrings.getString("完成", "Complete"); }
                static UI_popupTable_popup_cMQueryArea_Text(){ return $byBase.object.ByBaseStrings.getString("查询区", "QueryArea"); }
                static UI_popupTable_popup_MenuItem_Add_Text(){ return $byBase.object.ByBaseStrings.getString("添加数据", "Add data"); }
                static UI_popupTable_popup_MenuItem_Refresh_Text(){ return $byBase.object.ByBaseStrings.getString("刷新", "Refresh"); }
                static UI_dic_manage_Title(){ return $byBase.object.ByBaseStrings.getString("字典表", "Dictioanry"); }
                static UI_dic_manage_cGrid_Text(){ return $byBase.object.ByBaseStrings.getString("字典网格控件", "Dictionary Grid"); }
                static UI_dic_manage_cBtnQuery_Text(){ return $byBase.object.ByBaseStrings.getString("检索", "Query"); }
                static UI_dic_manage_cBtnAdd_Text(){ return $byBase.object.ByBaseStrings.getString("增加", "Add"); }
                static UI_dic_manage_cBtnDelete_Text(){ return $byBase.object.ByBaseStrings.getString("删除", "Delete"); }
                static UI_dic_manage_cBtnModify_Text(){ return $byBase.object.ByBaseStrings.getString("修改", "Modify"); }
                static UI_dic_manage_cBtnSave_Text(){ return $byBase.object.ByBaseStrings.getString("保存", "Save"); }
                static UI_dic_manage_cBtnCancel_Text(){ return $byBase.object.ByBaseStrings.getString("取消", "Cancel"); }
                static UI_dic_manage_cQueryArea_Text(){ return $byBase.object.ByBaseStrings.getString("查询区", "QueryArea"); }
                static UI_dic_manage_cEditArea_Text(){ return $byBase.object.ByBaseStrings.getString("编辑区", "EditArea"); }
                static UI_Tree_popup_Title(){ return $byBase.object.ByBaseStrings.getString("弹窗选择多行或一行", "Select one or more tree nodes"); }
                static UI_Tree_popup_cMQueryArea_Text(){ return $byBase.object.ByBaseStrings.getString("查询区", "Query Area"); }
                static UI_Tree_popup_cBtnQuery_Text(){ return $byBase.object.ByBaseStrings.getString("检索", "Query"); }
                static UI_Tree_popup_cBtnComplete_Text(){ return $byBase.object.ByBaseStrings.getString("完成", "Complete"); }
                static UI_Tree_popup_cTree_Text(){ return $byBase.object.ByBaseStrings.getString("表格网格控件", "Table tree control"); }
                static UI_Tree_popup_MenuItem_Add_Text(){ return $byBase.object.ByBaseStrings.getString("添加数据", "Add data"); }
                static UI_Tree_popup_MenuItem_Refresh_Text(){ return $byBase.object.ByBaseStrings.getString("刷新", "Refresh"); }
                static UI_Tree_manage_Title(){ return $byBase.object.ByBaseStrings.getString("树管理", "Tree"); }
                static UI_Tree_manage_cTree_Text(){ return $byBase.object.ByBaseStrings.getString("树控件", "TreeView"); }
                static UI_Tree_manage_cBtnAdd_Text(){ return $byBase.object.ByBaseStrings.getString("增加", "Add"); }
                static UI_Tree_manage_cBtnDelete_Text(){ return $byBase.object.ByBaseStrings.getString("删除", "Delete"); }
                static UI_Tree_manage_cBtnModify_Text(){ return $byBase.object.ByBaseStrings.getString("修改", "Modify"); }
                static UI_Tree_manage_cBtnSave_Text(){ return $byBase.object.ByBaseStrings.getString("保存", "Save"); }
                static UI_Tree_manage_cBtnCancel_Text(){ return $byBase.object.ByBaseStrings.getString("取消", "Cancel"); }
                static UI_Tree_manage_cEditArea_Text(){ return $byBase.object.ByBaseStrings.getString("编辑区", "EditArea"); }
                static UI_bridge_manage_Title(){ return $byBase.object.ByBaseStrings.getString("中间表管理", "Intermediate manage"); }
                static UI_bridge_manage_cGridLeft_Text(){ return $byBase.object.ByBaseStrings.getString("网格左", "Left Grid"); }
                static UI_bridge_manage_cGridRight_Text(){ return $byBase.object.ByBaseStrings.getString("网格右", "Right Grid"); }
                static UI_bridge_manage_cBtnDelete_Text(){ return $byBase.object.ByBaseStrings.getString("删除", "Delete"); }
                static UI_bridge_manage_cBtnModify_Text(){ return $byBase.object.ByBaseStrings.getString("修改", "Modify"); }
                static UI_bridge_manage_MenuItem_Add_Text(){ return $byBase.object.ByBaseStrings.getString("新建", "Add"); }
                static UI_bridge_manage_MenuItem_Modify_Text(){ return $byBase.object.ByBaseStrings.getString("修改", "Add"); }
                static UI_bridge_manage_MenuItem_Save_Text(){ return $byBase.object.ByBaseStrings.getString("保存", "Add"); }
                static UI_bridge_manage_MenuItem_Delete_Text(){ return $byBase.object.ByBaseStrings.getString("删除", "Delete"); }
                static UI_extend_slave_Title(){ return $byBase.object.ByBaseStrings.getString("本项只能拼入其他dialog中，仅支持一个单行的增删改", "Only used as a merge-guest, support one-line CRUD"); }
                static UI_extend_slave_cEditArea_Text(){ return $byBase.object.ByBaseStrings.getString("编辑区", "EditArea"); }
                static UI_detail_manage_cGrid_Text(){ return $byBase.object.ByBaseStrings.getString("网格控件", "Grid View"); }
            },
            transmit: [ ],
            static: { props: { language: Byt.String } }
        },
        mergeRelationCtrl: {
            type: class mergeRelationCtrl extends Byt.Object {
                $1(f_currentCtr, f_mergeCtr){
                    this.pCurrentCtr = f_currentCtr;
                    this.pMergeCtr = f_mergeCtr;
                    if($by.object.Grid.$check(this.pMergeCtr)){
                        let tmpGrid = $by.object.Grid.$convert(this.pMergeCtr, $by.identity.Table);
                        tmpGrid.selectionChanged.$add(async (sender, args) => {
                            if(!this.selectChangeEvent.by$equals(null)){ await this.selectChangeEvent.$invoke(tmpGrid.selectedRows.toList()); }
                        });
                    }
                    else if($by.object.Tree.$check(this.pMergeCtr)){
                        let tmpTree = $by.object.Tree.$convert(this.pMergeCtr, $by.identity.Table);
                        tmpTree.selectionChanged.$add(async (sender, treeNodeArgs) => {
                            if(!this.selectChangeEvent.by$equals(null)){
                                let tmpSelectRow = new $by.object.List();
                                for (let item of tmpTree.selectedNodes){ tmpSelectRow.add(Byt.Row.$convert(item.tag, $by.identity.Table)); }
                                await this.selectChangeEvent.$invoke(tmpSelectRow);
                            }
                        });
                    }
                }
                getMergeSelectRowList(){
                    let tmpResultList = new $by.object.List();
                    if($by.object.Grid.$check(this.pMergeCtr)){ return ($by.object.Grid.$convert(this.pMergeCtr, $by.identity.Table)).selectedRows.toList(); }
                    else if($by.object.Tree.$check(this.pMergeCtr)){
                        let tmpNodes = ($by.object.Tree.$convert(this.pMergeCtr, $by.identity.Table)).selectedNodes;
                        for (let item of tmpNodes){ tmpResultList.add(Byt.Row.$convert(item.tag, $by.identity.Table)); }
                    }
                    return tmpResultList;
                }
            },
            instance: { props: { pCurrentCtr: $by.identity.Table, pMergeCtr: $by.object.Control }, events: [ "selectChangeEvent" ] }
        }
    },
    identity: {
        relatedEditArea: {
            type: class relatedEditArea extends Byt.Identity {
                static editAreaReferenceTran(f_editArea){ f_editArea.unitEditBegin.$add(async (sender, args) => {
                    if($by.identity.Reference.$check(($by.object.Field.$convert(args.targetUnit.field, $by.identity.Field)).$identity())){
                        if(args.targetUnit.readonly || f_editArea.$identity() == ($by.object.Field.$convert(args.targetUnit.field, $by.identity.Reference)).$identity().host())
                            return;
                        let tmpRefTable = args.targetUnit.field.refTable;
                        if(tmpRefTable == null){ return; }
                        let tmpEques = $by.object.Table.$convert(tmpRefTable, $by.identity.Table);
                        if(tmpEques == null){ return; }
                        let tmpTest = $byInterface.identity.IBy.$convert(tmpEques);
                        if(tmpTest == null){ return; }
                        let tmpRowList = new $by.object.List();
                        let tmpSelectDialog = await tmpTest.$access([ $byInterface.identity.IBy, "getInstanceCURDPopup" ])(tmpRowList, false);
                        await tmpSelectDialog.showDialog();
                        if(tmpRowList.count > 0){ f_editArea.setEditingValueRelationally(args.targetIndex, tmpRowList.$get(0)); }
                    }
                }); }
            }
        },
        TableSafe: {
            type: class TableSafe extends Byt.Identity {
                confirmUserIsLogin(){ return true; }
            },
            base: { inherit: $by.identity.Table }
        },
        popupTable: {
            type: class popupTable extends Byt.Identity {
                async popupLoad(f_QueryData){
                    
                    {
                        if(this.pCacheList != null && f_QueryData.values.length == 0)
                            return this.pCacheList;
                        else {
                            if(f_QueryData.values.length == 0)
                                return this.pCacheList = await $byBase.$remote({ kind: "SKILL", NO: 3, target: this, args: [ f_QueryData ], argTypes: [ $by.object.QueryData ], return: [ "by.object.List", Byt.Row ] });
                            else 
                                return await $byBase.$remote({ kind: "SKILL", NO: 3, target: this, args: [ f_QueryData ], argTypes: [ $by.object.QueryData ], return: [ "by.object.List", Byt.Row ] });
                        }
                    }
                }
            },
            base: { inherit: "byBase.identity.TableSafe" },
            instance: { props: { pCacheList: [ "by.object.List", Byt.Row ] } }
        },
        dic: {
            type: class dic extends Byt.Identity {
                async addModifDelete(f_row, f_action){
                    
                    return await $byBase.$remote({ kind: "SKILL", NO: 24, target: this, args: [ f_row, f_action ], argTypes: [ Byt.Row, $by.enum.Action ], return: $by.object.Result });
                }
                async curdOverride(f_row, f_action){ return await this.addModifDelete(f_row, f_action); }
                async load(f_selectRowList, f_QueryData){
                    
                    { return await $byBase.$remote({ kind: "SKILL", NO: 26, target: this, args: [ f_selectRowList, f_QueryData ], argTypes: [ [ "by.object.List", Byt.Row ], $by.object.QueryData ], return: [ "by.object.List", Byt.Row ] }); }
                }
                async getInstanceCURDPopup(f_selectList, f_isMultiLine){ return await $byBase.dialog.popupTable$popup.$new(this.$identity(), $ => $.$1(f_selectList, f_isMultiLine)); }
                async getInstanceCURDManage(){ return await $byBase.dialog.dic$manage.$new(this.$identity(), $ => $.$0()); }
            },
            base: { inherit: "byBase.identity.popupTable", implements: [ "byInterface.identity.IBy" ] },
            instance: { components: [ "iID", "iName", "iSummary" ], events: [ "CURDChangeEvent" ] }
        },
        catalog: {
            type: class catalog extends Byt.Identity {
                async getRow(f_table){
                    let tmpList = await this.load(null, null);
                    for (let item of tmpList){
                        let tmpCatelogRow = Byt.Row.$convert(item, $byBase.identity.catalog);
                        if(tmpCatelogRow.i$access("iName") == f_table.$to().name){ return tmpCatelogRow; }
                    }
                    return null;
                }
            },
            base: { inherit: "byBase.identity.dic" },
            instance: { components: [ "iID", "iName", "iBillID", "iSummary" ] }
        },
        Tree: {
            type: class Tree extends Byt.Identity {
                async popupLoad(f_QueryData){
                    
                    { return await $byBase.$remote({ kind: "SKILL", NO: 4, target: this, args: [ f_QueryData ], argTypes: [ $by.object.QueryData ], return: [ "by.object.List", Byt.Row ] }); }
                }
                refresh(f_tree, f_row){
                    for (let rootNode of f_tree.nodes){
                        for (let childNode of rootNode.getAllNodes()){
                            if(Byt.Row["~=="](Byt.Row.$convert(childNode.tag, $byBase.identity.Tree), f_row)){
                                let tmpNodeTag = Byt.Row.$convert(childNode.tag, $byBase.identity.Tree);
                                Byt.Row["~="](tmpNodeTag, f_row);
                                childNode.text = Byt.String(f_row.i$access("iName")) + " " + Byt.String(f_row.i$access("iID"));
                                return;
                            }
                        }
                    }
                }
                async getInstanceCURDPopup(f_selectList, f_isMultiLine){ return await $byBase.dialog.Tree$popup.$new(this.$identity(), $ => $.$1(f_selectList, f_isMultiLine)); }
                async getInstanceCURDManage(){ return await $byBase.dialog.Tree$manage.$new(this.$identity(), $ => $.$0()); }
                confirmUserIsLogin(){ return true; }
                static async fill(f_tree, f_RowList){
                    f_tree.clear();
                    let nodeDic = new $by.object.Dictionary();
                    for (let treeRow of f_RowList){
                        let tmpNO = treeRow.i$access("iID");
                        let tmpForNode = new $by.object.TreeNode().$bindIdentity(Byt.Identity(f_tree));
                        tmpForNode.text = treeRow.i$access("iName");
                        tmpForNode.tag = treeRow;
                        nodeDic.add(tmpNO, tmpForNode);
                    }
                    for (let treeRow of f_RowList){
                        if(!nodeDic.containsKey(treeRow.i$access("iParent"))){ f_tree.add(nodeDic.$get(treeRow.i$access("iID"))); }
                        else {
                            if(treeRow.i$access("iParent") == treeRow.i$access("iID")){
                                let tmpTableName = ($by.identity.Table.$convert(treeRow)).$to().name;
                                await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Tree_Cycle_Template(tmpTableName, treeRow.i$access("iID")));
                            }
                            else { nodeDic.$get(treeRow.i$access("iParent")).add(nodeDic.$get(treeRow.i$access("iID"))); }
                        }
                    }
                }
                static addNewNode(f_tree, f_RowList){
                    for (let item of f_RowList){ $byBase.identity.Tree.addNewNode$1(f_tree, item); }
                }
                static addNewNode$1(f_tree, f_Row){
                    let tmpNodeList = f_tree.getAllNodes();
                    for (let item of tmpNodeList){
                        if(item.tag == null)
                            continue;
                        let tmpTreeRow = Byt.Row.$convert(item.tag, $byBase.identity.Tree);
                        let tmpNode = new $by.object.TreeNode().$bindIdentity(Byt.Identity(f_tree));
                        tmpNode.text = f_Row.i$access("iName");
                        tmpNode.tag = f_Row;
                        if(f_Row.i$access("iParent") == "" || f_Row.i$access("iParent") == null){
                            f_tree.add(tmpNode);
                            return;
                        }
                        else if(tmpTreeRow.i$access("iID") == f_Row.i$access("iParent")){
                            item.add(tmpNode);
                            item.expand();
                            return;
                        }
                    }
                }
                static nodeListToRowList(f_identity, f_list){
                    let tmpResultList = new $by.object.List();
                    for (let item of f_list){ tmpResultList.add(new $by.object.Row().$bindIdentity(f_identity)); }
                    return tmpResultList;
                }
                static getRelationRows(f_Tree, f_list){
                    let tmpResultList = new $by.object.List();
                    let tmpTreeNodeList = new $by.object.List();
                    for (let item of f_Tree.getAllNodes()){
                        for (let itemSelectRow of f_list){
                            if(item.tag != null && Byt.Row["~=="](Byt.Row.$convert(item.tag, $byBase.identity.Tree), itemSelectRow)){
                                tmpResultList.add(item);
                                break;
                            }
                        }
                    }
                    return tmpResultList;
                }
                static deleteTreeRelationRows(f_Tree, f_list){
                    let tmpResultList = $byBase.identity.Tree.getRelationRows(f_Tree, f_list);
                    for (let item of tmpResultList){ f_Tree.removeChild(item); }
                }
                static updateTreeRelationRows(f_Tree, f_list){
                    let tmpResultList = $byBase.identity.Tree.getRelationRows(f_Tree, f_list);
                    for (let item of tmpResultList){
                        let tmpItemRow = Byt.Row.$convert(item.tag, $byBase.identity.Tree);
                        for (let itemNewsRow of f_list){
                            if(Byt.Row["~=="](tmpItemRow, itemNewsRow)){
                                Byt.Row["~="](tmpItemRow, itemNewsRow);
                                item.text = tmpItemRow.i$access("iName");
                                break;
                            }
                        }
                    }
                }
                static setSelectRows(f_Tree, f_selectList){
                    let tmpResultList = $byBase.identity.Tree.getRelationRows(f_Tree, f_selectList);
                    f_Tree.selectedNodes = new $by.object.ReadOnlyList(tmpResultList);
                }
            },
            base: { inherit: "byBase.identity.TableSafe", implements: [ "byInterface.identity.IBy" ] },
            instance: { components: [ "iID", "iParent", "iName" ], events: [ "CURDChangeEvent" ] }
        },
        bridge: {
            type: class bridge extends Byt.Identity {
                async load(f_selectRowList, f_leftRight){
                    
                    { return f_selectRowList == null ? null : await $byBase.$remote({ kind: "SKILL", NO: 17, target: this, args: [ f_selectRowList, f_leftRight ], argTypes: [ [ "by.object.List", Byt.Row ], $by.enum.MouseButton ], return: [ "by.object.List", Byt.Row ] }); }
                }
                async addDeleteUpdate(f_addList, f_deleteList){
                    
                    { await $byBase.$remote({ kind: "SKILL", NO: 18, target: this, args: [ f_addList, f_deleteList ], argTypes: [ [ "by.object.List", Byt.Row ], [ "by.object.List", Byt.Row ] ] }); }
                }
                getInstanceCURDPopup(f_selectList, f_isMultiLine){ return null; }
                getInstanceCURDManage(){ return null; }
            },
            base: { inherit: "byBase.identity.TableSafe", implements: [ "byInterface.identity.IBy" ] },
            instance: { components: [ "iID", "iLeft", "iRight" ], events: [ "CURDChangeEvent" ] }
        },
        extend: {
            type: class extend extends Byt.Identity {
                async load(f_ID){
                    
                    { return await $byBase.$remote({ kind: "SKILL", NO: 21, target: this, args: [ f_ID ], argTypes: [ Byt.String ], return: Byt.Row }); }
                }
                async addUpdateDelete(f_row, f_action){
                    
                    return await $byBase.$remote({ kind: "SKILL", NO: 22, target: this, args: [ f_row, f_action ], argTypes: [ Byt.Row, $by.enum.Action ], return: Byt.Int });
                }
            },
            base: { inherit: "byBase.identity.TableSafe" },
            instance: { components: [ "iID", "iName" ] }
        },
        detail: {
            type: class detail extends Byt.Identity {
                async load(f_row){
                    
                    { return await $byBase.$remote({ kind: "SKILL", NO: 23, target: this, args: [ f_row ], argTypes: [ Byt.Row ], return: [ "by.object.List", Byt.Row ] }); }
                }
            },
            base: { inherit: "byBase.identity.TableSafe" }
        },
        cloud: {
            type: class cloud extends Byt.Identity { },
            base: { inherit: "byBase.identity.TableSafe" },
            instance: { components: [ "iID", "iName", "iUser" ] }
        }
    },
    dialog: {
        popupTable$popup: {
            type: class popup extends Byt.Dialog {
                async $1(f_selectList, f_isMultiLine){
                    this.cGrid.$bindIdentity(this.$identity()).$init($ => { $.contextMenu = this.cContextMenu; });
                    this.cContextMenu = new $by.object.ContextMenu();
                    this.cMQueryArea.$bindIdentity(this.$identity());
                    this.initUI();
                    await this.init(f_selectList, f_isMultiLine, null);
                }
                async $2(f_selectList, f_isMultiLine, f_table){
                    this.cGrid.$bindIdentity(this.$identity()).$init($ => { $.contextMenu = this.cContextMenu; });
                    this.cContextMenu = new $by.object.ContextMenu();
                    this.cMQueryArea.$bindIdentity(this.$identity());
                    this.initUI();
                    await this.init(f_selectList, f_isMultiLine, f_table);
                }
                initUI(){
                    this.text = $byBase.object.ByBaseStrings.UI_popupTable_popup_Title();
                    this.cGrid.text = $byBase.object.ByBaseStrings.UI_popupTable_popup_cGrid_Text();
                    this.cBtnQuery.text = $byBase.object.ByBaseStrings.UI_popupTable_popup_cBtnQuery_Text();
                    this.cBtnComplete.text = $byBase.object.ByBaseStrings.UI_popupTable_popup_cBtnComplete_Text();
                    this.cMQueryArea.text = $byBase.object.ByBaseStrings.UI_popupTable_popup_cMQueryArea_Text();
                }
                async init(f_selectList, f_isMultiLine, f_table){
                    this.pChildIdentity = f_table == null ? this.$identity() : f_table;
                    let tmpMenuItem = new $by.object.MenuItem();
                    tmpMenuItem.text = $byBase.object.ByBaseStrings.UI_popupTable_popup_MenuItem_Add_Text();
                    tmpMenuItem.click.$add(async (sender, args) => {
                        let tmpCurdDialog = $byInterface.identity.IBy.$convert(this.$identity());
                        if(tmpCurdDialog == null)
                            return;
                        tmpCurdDialog.$access([ $byInterface.identity.IBy, "CURDChangeEvent" ]).$add(this.$access("tmpCurdDialog_CURDChangeEvent"));
                        let tmpManage = await tmpCurdDialog.$access([ $byInterface.identity.IBy, "getInstanceCURDManage" ])();
                        await tmpManage.showDialog();
                        tmpCurdDialog.$access([ $byInterface.identity.IBy, "CURDChangeEvent" ]).$remove(this.$access("tmpCurdDialog_CURDChangeEvent"));
                    });
                    this.cContextMenu.add(tmpMenuItem);
                    let tmpMenuRefresh = new $by.object.MenuItem();
                    tmpMenuRefresh.text = $byBase.object.ByBaseStrings.UI_popupTable_popup_MenuItem_Refresh_Text();
                    tmpMenuRefresh.click.$add(async (sender, args) => { await this.load(); });
                    this.cContextMenu.add(tmpMenuRefresh);
                    this.cGrid.contextMenu = this.cContextMenu;
                    this.cGrid.isMultiLine = f_isMultiLine;
                    this.pRowList = f_selectList;
                    this.cBtnComplete.click.$add(this.$access("btnComplete_click"));
                    this.cBtnQuery.click.$add(async (sender, args) => { await this.load(); });
                    await this.load();
                    if(this.$identity().$to().summary == null || this.$identity().$to().summary == "")
                        this.text = this.$identity().$to().name;
                    else 
                        this.text = this.$identity().$to().summary;
                    this.cGrid.cellDoubleClick.$add(this.$access("mGrid_cellDoubleClick"));
                }
                tmpCurdDialog_CURDChangeEvent(f_list, f_action){
                    switch(f_action){
                        case "select":
                            this.cGrid.clear();
                            this.cGrid.addRange(f_list);
                            break;
                        case "delete":
                            $byCommon.identity.relatedGrid.deleteGridRelationRows(this.cGrid, f_list);
                            break;
                        case "update":
                            $byCommon.identity.relatedGrid.updateGridRelationRows(this.cGrid, f_list);
                            break;
                        case "insert":
                            this.cGrid.addRange(f_list);
                            break;
                    }
                }
                mGrid_cellDoubleClick(sender, args){ this.btnComplete_click(null, null); }
                btnComplete_click(sender, args){
                    this.pRowList.clear();
                    this.pRowList.addRange(this.cGrid.selectedRows.toArray());
                    this.close();
                }
                async load(){
                    this.cGrid.clear();
                    let tmpWaiting = await $byCommon.identity.relatedDialog.Loading();
                    let tmpGridRows = await this.$identity().popupLoad(this.cMQueryArea.data);
                    this.cGrid.addRange(tmpGridRows);
                    $byCommon.identity.relatedGrid.setSelectRows(this.cGrid, this.pRowList);
                    tmpWaiting.close();
                }
                async actionInquiry(){
                    this.cBtnQuery.isEnabled = false;
                    this.cBtnComplete.isEnabled = false;
                    await this.load();
                    this.cBtnQuery.isEnabled = true;
                    this.cBtnComplete.isEnabled = true;
                }
            },
            instance: { props: { cContextMenu: $by.object.ContextMenu, mSelectRowList: [ "by.object.List", Byt.Row ], pRowList: [ "by.object.List", Byt.Row ], pChildIdentity: $by.identity.Table } },
            dialog: { props: { cGrid: $by.object.Grid, cBtnQuery: $by.object.Button, cBtnComplete: $by.object.Button, cMQueryArea: $by.object.QueryArea } }
        },
        Tree$popup: {
            type: class popup extends Byt.Dialog {
                async $1(f_selectList, f_isMultiLine){
                    this.cMQueryArea.$bindIdentity(this.$identity());
                    this.cTree.$bindIdentity(this.$identity());
                    this.cContextMenu = new $by.object.ContextMenu();
                    this.initUI();
                    let tmpMenuItem = new $by.object.MenuItem();
                    tmpMenuItem.text = $byBase.object.ByBaseStrings.UI_Tree_popup_MenuItem_Add_Text();
                    tmpMenuItem.click.$add(async (sender, args) => {
                        let tmpCurdDialog = $byInterface.identity.IBy.$convert(this.$identity());
                        if(tmpCurdDialog == null)
                            return;
                        tmpCurdDialog.$access([ $byInterface.identity.IBy, "CURDChangeEvent" ]).$add(this.$access("tmpCurdDialog_CURDChangeEvent"));
                        let tmpManage = await tmpCurdDialog.$access([ $byInterface.identity.IBy, "getInstanceCURDManage" ])();
                        await tmpManage.showDialog();
                        tmpCurdDialog.$access([ $byInterface.identity.IBy, "CURDChangeEvent" ]).$remove(this.$access("tmpCurdDialog_CURDChangeEvent"));
                    });
                    this.cContextMenu.add(tmpMenuItem);
                    let tmpMenuRefresh = new $by.object.MenuItem();
                    tmpMenuRefresh.text = $byBase.object.ByBaseStrings.UI_Tree_popup_MenuItem_Refresh_Text();
                    tmpMenuRefresh.click.$add(async (sender, args) => { await this.load(); });
                    this.cContextMenu.add(tmpMenuRefresh);
                    this.cTree.contextMenu = this.cContextMenu;
                    this.cTree.nodeDoubleClick.$add((sender, treeNodeArgs) => { this.cBtnComplete_click(null, null); });
                    this.cTree.isMultiLine = f_isMultiLine;
                    this.pRowList = f_selectList;
                    this.cBtnComplete.click.$add(this.$access("cBtnComplete_click"));
                    this.text = this.$identity().$to().name;
                    await this.load();
                    this.cBtnQuery.click.$add(async (sender, args) => { await this.load(); });
                    $byBase.identity.Tree.setSelectRows(this.cTree, $by.object.List.$convert(this.pRowList));
                }
                initUI(){
                    this.text = $byBase.object.ByBaseStrings.UI_Tree_popup_Title();
                    this.cTree.text = $byBase.object.ByBaseStrings.UI_Tree_popup_cTree_Text();
                    this.cBtnQuery.text = $byBase.object.ByBaseStrings.UI_Tree_popup_cBtnQuery_Text();
                    this.cBtnComplete.text = $byBase.object.ByBaseStrings.UI_Tree_popup_cBtnComplete_Text();
                    this.cMQueryArea.text = $byBase.object.ByBaseStrings.UI_Tree_popup_cMQueryArea_Text();
                }
                cBtnComplete_click(sender, args){
                    this.pRowList.clear();
                    for (let item of this.cTree.selectedNodes){ this.pRowList.add(Byt.Row.$convert(item.tag, $byBase.identity.Tree)); }
                    this.close();
                }
                async tmpCurdDialog_CURDChangeEvent(f_list, f_action){
                    switch(f_action){
                        case "select":
                            this.cTree.clear();
                            await $byBase.identity.Tree.fill(this.cTree, $by.object.List.$convert(f_list));
                            break;
                        case "delete":
                            $byBase.identity.Tree.deleteTreeRelationRows(this.cTree, $by.object.List.$convert(f_list));
                            break;
                        case "update":
                            $byBase.identity.Tree.updateTreeRelationRows(this.cTree, $by.object.List.$convert(f_list));
                            break;
                        case "insert":
                            $byBase.identity.Tree.addNewNode(this.cTree, $by.object.List.$convert(f_list));
                            break;
                    }
                }
                async load(){
                    let tmpSelectResult = await this.$identity().popupLoad(this.cMQueryArea.data);
                    await $byBase.identity.Tree.fill(this.cTree, tmpSelectResult);
                }
            },
            instance: { props: { pRowList: [ "by.object.List", Byt.Row ], cContextMenu: $by.object.ContextMenu, pChildIdentity: $by.identity.Table } },
            dialog: { props: { cMQueryArea: $by.object.QueryArea, cBtnQuery: $by.object.Button, cTree: $by.object.Tree, cBtnComplete: $by.object.Button } }
        },
        Tree$manage: {
            type: class manage extends Byt.Dialog {
                async $0(){
                    this.cTree.$bindIdentity(this.$identity());
                    this.cEditArea.$bindIdentity(this.$identity());
                    this.mAction = "select";
                    this.pSlaveDialogList = new $by.object.List();
                    this.initUI();
                    let tmpUpdateAllow = [ this.cBtnSave, this.cBtnCancel, this.cEditArea ];
                    let tmpInitAllow = [ this.cBtnAdd, this.cBtnDelete, this.cBtnModify ];
                    this.pButtonLock = new $byBase.object.buttonLock().$init($ => $.$1([ ], tmpUpdateAllow, tmpInitAllow));
                    this.pButtonLock.setButtonState("init");
                    this.cBtnAdd.click.$add(this.$access("actionAddBegin"));
                    this.cBtnDelete.click.$add(this.$access("actionDelete"));
                    this.cBtnModify.click.$add(this.$access("actionModifyBegin"));
                    this.cBtnSave.click.$add(this.$access("actionSave"));
                    this.cBtnCancel.click.$add(this.$access("btnCancel_click"));
                    this.cTree.selectionChanged.$add(this.$access("cTree_selectionChanged"));
                    $byBase.identity.relatedEditArea.editAreaReferenceTran(this.cEditArea);
                    if($by.object.Manager.getMergeDialog(this) != null){
                        this.pMergeRelationCtrl = new $byBase.object.mergeDialog().$init($ => $.$1(this, this.$identity())).getMergeRelationCtrl(Byt.Identity(this.cTree));
                        if(this.pMergeRelationCtrl != null){ this.pMergeRelationCtrl.selectChangeEvent.$add(async f_selectList => { await this.load(f_selectList); }); }
                    }
                    else { await this.load(null); }
                }
                initUI(){
                    this.text = $byBase.object.ByBaseStrings.UI_Tree_manage_Title();
                    this.cTree.text = $byBase.object.ByBaseStrings.UI_Tree_manage_cTree_Text();
                    this.cBtnAdd.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnAdd_Text();
                    this.cBtnDelete.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnDelete_Text();
                    this.cBtnModify.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnModify_Text();
                    this.cBtnSave.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnSave_Text();
                    this.cBtnCancel.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnCancel_Text();
                    this.cEditArea.text = $byBase.object.ByBaseStrings.UI_dic_manage_cEditArea_Text();
                }
                cTree_selectionChanged(f_sender, f_e){
                    if(this.cTree.selectedNode != null && this.cTree.selectedNode.tag != null){
                        this.cEditArea.setEditingData(Byt.Row.$convert(this.cTree.selectedNode.tag));
                        let tmpRowList = $byBase.identity.Tree.nodeListToRowList(this.$identity(), this.cTree.selectedNodes.toList());
                    }
                    else { this.cEditArea.init(); }
                }
                btnCancel_click(f_sender, f_e){ this.pButtonLock.setButtonState("init"); }
                async load(f_selectRowList){
                    this.cTree.clear();
                    let tmpList = null;
                    if(f_selectRowList == null && this.pMergeRelationCtrl != null && this.pMergeRelationCtrl.getMergeSelectRowList().count > 0){ f_selectRowList = this.pMergeRelationCtrl.getMergeSelectRowList(); }
                    if(f_selectRowList == null || f_selectRowList.count == 0){
                        let a = await $byBase.$sql({ ["#sql"]: "select", number: 10, from: { a: this.$identity() } });
                        tmpList = a.rows;
                    }
                    else {
                        if(f_selectRowList.count == 1){ tmpList = (await $byBase.$sql({ ["#sql"]: "select", number: 11, args: [ f_selectRowList ], argTypes: [ [ "by.object.List", Byt.Row ] ], from: { a: this.$identity() } })).rows; }
                    }
                    await $byBase.identity.Tree.fill(this.cTree, tmpList);
                }
                async actionAddBegin(f_sender, f_e){
                    this.mAction = "insert";
                    this.cEditArea.editAction = "insert";
                    this.pButtonLock.setButtonState("update");
                    let tmpNode = this.cTree.newNode();
                    let tmpRow = new $by.object.Row().$bindIdentity(this.$identity());
                    tmpRow.i$assign("iID", await $byCommon.identity.general.getGuid());
                    tmpNode.tag = tmpRow;
                    if(this.cTree.selectedNode != null){ tmpRow.i$assign("iParent", (Byt.Row.$convert(this.cTree.selectedNode.tag, $byBase.identity.Tree)).i$access("iID")); }
                    if(this.pMergeRelationCtrl != null && this.pMergeRelationCtrl.getMergeSelectRowList().count > 0){ Byt.Row["~="](tmpRow, this.pMergeRelationCtrl.getMergeSelectRowList().$get(0)); }
                    this.cEditArea.setEditingData(tmpRow);
                    if(!this.addDeleteUpdateEvent.by$equals(null)){ await this.addDeleteUpdateEvent.$invoke(tmpRow, "addBegin"); }
                }
                async actionAddEnd(){
                    let tmpVerifyResult = this.cEditArea.verify();
                    let tmpVerify = this.cEditArea.verify();
                    if(!tmpVerifyResult.isOk || !tmpVerify.isOk){
                        await $by.object.Message.alert(Byt.String($byBase.object.ByBaseStrings.Warning_EditArea_Verify_Failed()) + Byt.String(tmpVerifyResult.info));
                        return;
                    }
                    if(!await $byBase.object.mergeDialog.verifySlaveDialog($byInterface.dialog.IBy$IMaster.$convert(this)))
                        return;
                    let tmpRow = this.cEditArea.getEditingData();
                    if((tmpRow.i$access("iParent") != null && tmpRow.i$access("iParent") != "") && tmpRow.i$access("iID") == tmpRow.i$access("iParent")){
                        await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_TreeNode_Cannot_Parent_To_Itself());
                        return;
                    }
                    let tmpMergeAddList = new $by.object.List();
                    await $byBase.object.mergeDialog.getAddUpdateDeleteList(this.pSlaveDialogList, tmpMergeAddList, null, null);
                    let tmpResult = await $byBase.$remote({ kind: "ACTION", NO: 2, target: this.$identity(), args: [ tmpRow, tmpMergeAddList ], argTypes: [ Byt.Row, [ "by.object.List", Byt.Row ] ], return: $by.object.Result });
                    if(tmpResult.isOk){
                        if(!this.addDeleteUpdateEvent.by$equals(null)){ await this.addDeleteUpdateEvent.$invoke(tmpRow, "addSave"); }
                        let tmpNode = this.cTree.newNode();
                        tmpNode.text = tmpRow.i$access("iName");
                        tmpNode.tag = tmpRow;
                        let tmpListNodesList = this.cTree.getAllNodes();
                        let tmpIsOk = false;
                        for (let item of tmpListNodesList){
                            if((Byt.Row.$convert(item.tag, $byBase.identity.Tree)).i$access("iID") == tmpRow.i$access("iParent")){
                                item.add(tmpNode);
                                tmpIsOk = true;
                            }
                        }
                        if(tmpIsOk == false){ this.cTree.add(tmpNode); }
                        if(!this.$identity().CURDChangeEvent.by$equals(null)){
                            let tmpList = new $by.object.List();
                            tmpList.add(tmpRow);
                            await this.$identity().CURDChangeEvent.$invoke(tmpList, "insert");
                        }
                    }
                    else { await $by.object.Message.alert(Byt.String($byBase.object.ByBaseStrings.Warning_SQL_Failed()) + Byt.String(tmpResult.info)); }
                    if(this.cTree.selectedNode != null){ this.cTree.selectedNode.expand(); }
                    this.pButtonLock.setButtonState("init");
                }
                async actionModifyBegin(f_sender, f_e){
                    this.mAction = "update";
                    this.pButtonLock.setButtonState("update");
                    this.cEditArea.init();
                    if(this.cTree.selectedNode == null){
                        await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Please_Select_A_TreeNode());
                        return;
                    }
                    else {
                        this.cEditArea.setEditingData(Byt.Row.$convert(this.cTree.selectedNode.tag, $byBase.identity.Tree));
                        this.cEditArea.editAction = "update";
                        if(!this.addDeleteUpdateEvent.by$equals(null)){ await this.addDeleteUpdateEvent.$invoke(Byt.Row.$convert(this.cTree.selectedNode.tag, $byBase.identity.Tree), "modifBegin"); }
                    }
                }
                async actionModifyEnd(){
                    let tmpRow = this.cEditArea.getEditingData();
                    let tmpVerifyResult = tmpRow.verify();
                    if(tmpRow == null || !tmpVerifyResult.isOk){
                        await $by.object.Message.alert(Byt.String($byBase.object.ByBaseStrings.Warning_EditArea_Verify_Failed()) + Byt.String(tmpVerifyResult.info));
                        return;
                    }
                    if(!await $byBase.object.mergeDialog.verifySlaveDialog($byInterface.dialog.IBy$IMaster.$convert(this)))
                        return;
                    let tmpMergeAddList = new $by.object.List();
                    let tmpMergeUpdateList = new $by.object.List();
                    let tmpMergeDeleteList = new $by.object.List();
                    await $byBase.object.mergeDialog.getAddUpdateDeleteList(this.pSlaveDialogList, tmpMergeAddList, tmpMergeUpdateList, tmpMergeDeleteList);
                    let tmpResult = await $byBase.$remote({ kind: "ACTION", NO: 1, target: this.$identity(), args: [ tmpRow, tmpMergeAddList, tmpMergeUpdateList, tmpMergeDeleteList ], argTypes: [ Byt.Row, [ "by.object.List", Byt.Row ], [ "by.object.List", Byt.Row ], [ "by.object.List", Byt.Row ] ], return: $by.object.Result });
                    if(tmpResult.isOk == true){
                        if(!this.addDeleteUpdateEvent.by$equals(null)){ await this.addDeleteUpdateEvent.$invoke(tmpRow, "modifSave"); }
                        this.$identity().refresh(this.cTree, tmpRow);
                        this.cTree.selectedNode.tag = tmpRow;
                        this.cTree.selectedNode.text = tmpRow.i$access("iName");
                        this.pButtonLock.setButtonState("init");
                        if(!this.$identity().CURDChangeEvent.by$equals(null)){
                            let tmpList = new $by.object.List();
                            tmpList.add(tmpRow);
                            await this.$identity().CURDChangeEvent.$invoke(tmpList, "update");
                        }
                    }
                    else {
                        await $by.object.Message.alert(tmpResult.info);
                        return;
                    }
                }
                async actionDelete(f_sender, f_e){
                    this.pButtonLock.setButtonState("Lock");
                    if(this.cTree.selectedNode == null){ await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Please_Select_A_TreeNode()); }
                    else {
                        if(await $by.object.Message.confirm($byBase.object.ByBaseStrings.Warning_Sure_To_Delete_Nodes())){
                            let tmpRowList = this.cTree.selectedNode.getAllNodeValues();
                            let tmpMergeDeleteList = new $by.object.List();
                            await $byBase.object.mergeDialog.getAddUpdateDeleteList(this.pSlaveDialogList, null, null, tmpMergeDeleteList);
                            let tmpResult = await $byBase.$remote({ kind: "ACTION", NO: 0, target: this.$identity(), args: [ tmpRowList.toArray(), tmpMergeDeleteList ], argTypes: [ [ Byt.Array, Byt.Row ], [ "by.object.List", Byt.Row ] ], return: $by.object.Result });
                            if(tmpResult.isOk){
                                if(!this.addDeleteUpdateEvent.by$equals(null) && tmpRowList.count == 1){ await this.addDeleteUpdateEvent.$invoke(tmpRowList.$get(0), "delete"); }
                                this.cTree.selectedNode.remove();
                                if(!this.$identity().CURDChangeEvent.by$equals(null)){ await this.$identity().CURDChangeEvent.$invoke(tmpRowList, "delete"); }
                            }
                            else { await $by.object.Message.alert(tmpResult.info); }
                        }
                    }
                    this.pButtonLock.setButtonState("init");
                }
                async actionSave(f_sender, f_e){
                    switch(this.mAction){
                        case "update":
                            await this.actionModifyEnd();
                            break;
                        case "insert":
                            await this.actionAddEnd();
                            break;
                    }
                }
                getSelectRows(){
                    let tmpResultValue = new $by.object.List();
                    if(this.cEditArea.editAction == "insert"){ tmpResultValue.add(this.cEditArea.getEditingData()); }
                    else if(this.cTree.selectedNode != null && this.cTree.selectedNode.tag != null){ tmpResultValue.add(Byt.Row.$convert(this.cTree.selectedNode.tag, $byBase.identity.Tree)); }
                    return tmpResultValue;
                }
            },
            base: { implements: [ "byInterface.dialog.IBy$IMaster" ] },
            instance: { props: { pButtonLock: "byBase.object.buttonLock", mAction: $by.enum.Action, pMergeRelationCtrl: "byBase.object.mergeRelationCtrl", pSlaveDialogList: [ "by.object.List", "byInterface.dialog.IBy$ISlave" ] }, events: [ "addDeleteUpdateEvent" ] },
            dialog: { props: { cTree: $by.object.Tree, cEditArea: $by.object.EditArea, cBtnAdd: $by.object.Button, cBtnDelete: $by.object.Button, cBtnModify: $by.object.Button, cBtnSave: $by.object.Button, cBtnCancel: $by.object.Button } }
        },
        bridge$manage: {
            type: class manage extends Byt.Dialog {
                async $0(){
                    this.cGridLeft.$bindIdentity(this.$identity()).$init($ => { $.visible = false; });
                    this.cGridRight.$bindIdentity(this.$identity()).$init($ => { $.visible = false; });
                    this.initUI();
                    this.cBtnDelete.click.$add(this.$access("actionDelete"));
                    if($by.object.Manager.getMergeDialog(this) != null){
                        this.pMergeRelationCtrl = new $byBase.object.mergeDialog().$init($ => $.$1(this, this.$identity())).getMergeRelationCtrl(this.$identity());
                        if(this.pMergeRelationCtrl != null){ this.pMergeRelationCtrl.selectChangeEvent.$add(async f_selectList => { await this.load(f_selectList); }); }
                    }
                    else {
                        await $by.object.Message.alert("bridge中间表身份窗体不支持独立显示！");
                        return;
                    }
                    this.cBtnModif.click.$add(this.$access("actionModifBegin"));
                    let tmpGrid = this.getCurrentGrid();
                    tmpGrid.visible = true;
                    let tmpMouseButton = this.pMergeRelationCtrl.pMergeCtr.$identity() == this.$identity().iLeft.host() ? "right" : "left";
                    for (let item of tmpGrid.gridColumns){
                        if(item.field.refTable == null)
                            continue;
                        if(tmpMouseButton == "left"){
                            if(item.field.refTable.name == this.$identity().iRight.host().$to().name)
                                item.visible = false;
                        }
                        else {
                            if(item.field.refTable.name == this.$identity().iLeft.host().$to().name)
                                item.visible = false;
                        }
                    }
                }
                initUI(){
                    this.text = $byBase.object.ByBaseStrings.UI_bridge_manage_Title();
                    this.cGridLeft.text = $byBase.object.ByBaseStrings.UI_bridge_manage_cGridLeft_Text();
                    this.cGridRight.text = $byBase.object.ByBaseStrings.UI_bridge_manage_cGridRight_Text();
                    this.cBtnDelete.text = $byBase.object.ByBaseStrings.UI_bridge_manage_cBtnDelete_Text();
                    this.cBtnModif.text = $byBase.object.ByBaseStrings.UI_bridge_manage_cBtnModify_Text();
                }
                getCurrentGrid(){
                    if(this.pMergeRelationCtrl.pMergeCtr.$identity() == this.$identity().iLeft.host())
                        return this.cGridRight;
                    else 
                        return this.cGridLeft;
                }
                async load(f_selectRowList){
                    let tmpGrid = this.getCurrentGrid();
                    tmpGrid.clear();
                    if(f_selectRowList != null && f_selectRowList.count > 0){
                        let tmpMouseButton = this.pMergeRelationCtrl.pMergeCtr.$identity() == this.$identity().iLeft.host() ? "right" : "left";
                        let tmpBridgeList = await this.$identity().load(f_selectRowList, tmpMouseButton);
                        tmpGrid.addRange(tmpBridgeList);
                    }
                }
                async actionModifBegin(f_sender, f_e){
                    if(this.pMergeRelationCtrl == null || this.pMergeRelationCtrl.getMergeSelectRowList().count == 0){
                        await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Bridge_Cannot_Find_Reference());
                        return;
                    }
                    let tmpPopupTable = null;
                    let f_leftRight = "right";
                    if(this.pMergeRelationCtrl.pMergeCtr.$identity() == this.$identity().iLeft.host())
                        tmpPopupTable = this.$identity().iRight.host();
                    else {
                        tmpPopupTable = this.$identity().iLeft.host();
                        f_leftRight = "left";
                    }
                    let tmpMergeIBy = $byInterface.identity.IBy.$convert(tmpPopupTable);
                    if(tmpMergeIBy != null){
                        let tmpSelectList = new $by.object.List();
                        let tmpGrid = this.getCurrentGrid();
                        let tmpSourceList = tmpGrid.rows.toList();
                        tmpSelectList.addRange(tmpSourceList);
                        let tmpPopup = await tmpMergeIBy.$access([ $byInterface.identity.IBy, "getInstanceCURDPopup" ])(tmpSelectList, true);
                        await tmpPopup.showDialog();
                        let tmpBridgeList = new $by.object.List();
                        let tmpDeleteList = $byCommon.identity.relatedTable.isNotExists(tmpSourceList, tmpSelectList);
                        let tmpAddList = $byCommon.identity.relatedTable.isNotExists(tmpSelectList, tmpSourceList);
                        for (let item of tmpDeleteList){ tmpGrid.removeChild(Byt.Row.$convert(item, $byBase.identity.bridge)); }
                        let tmpExeList = new $by.object.List();
                        let tmpMergeRow = this.pMergeRelationCtrl.getMergeSelectRowList();
                        for (let item of tmpAddList){
                            let tmpRow = tmpGrid.newRow();
                            tmpRow.i$assign("iID", await $byCommon.identity.general.getGuid());
                            Byt.Row["~="](tmpRow, item);
                            Byt.Row["~="](tmpRow, tmpMergeRow.$get(0));
                            tmpGrid.add(tmpRow);
                            tmpExeList.add(tmpRow);
                        }
                        if(tmpDeleteList.count == 0 && tmpExeList.count == 0)
                            return;
                        try{ await $byBase.$tran({ NO: 6, args: [ ], argTypes: [ ], sqls: [ { ["#sql"]: "row", number: 20, args: [ tmpDeleteList ], argTypes: [ [ "by.object.List", Byt.Row ] ] }, { ["#sql"]: "row", number: 21, args: [ tmpExeList ], argTypes: [ [ "by.object.List", Byt.Row ] ] } ] }); }
                        catch(errorInfo){
                            errorInfo = errorInfo.message;
                            await $by.object.Message.alert(errorInfo);
                            return;
                        }
                    }
                }
                async actionDelete(f_sender, f_e){
                    let tmpGrid = this.getCurrentGrid();
                    if(tmpGrid.selectedRows.count == 0){ await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Please_Select_A_Line()); }
                    else {
                        if(await $by.object.Message.confirm($byBase.object.ByBaseStrings.Warning_Sure_To_Delete())){
                            let tmpList = new $by.object.List();
                            for (let item of tmpGrid.rows){ tmpList.add(item); }
                            try{ await $byBase.$tran({ NO: 7, args: [ ], argTypes: [ ], sqls: [ { ["#sql"]: "row", number: 22, args: [ tmpList ], argTypes: [ [ "by.object.List", Byt.Row ] ] } ] }); }
                            catch(message){
                                message = message.message;
                                await $by.object.Message.alert(message);
                                return;
                            }
                            for (let item of tmpList){ tmpGrid.removeChild(item); }
                        }
                    }
                }
            },
            instance: { props: { pMergeRelationCtrl: "byBase.object.mergeRelationCtrl" } },
            dialog: { props: { cGridLeft: $by.object.Grid, cGridRight: $by.object.Grid, cBtnModif: $by.object.Button, cBtnDelete: $by.object.Button } }
        },
        extend$slave: {
            type: class slave extends Byt.Dialog {
                async $0(){
                    this.cEditArea.$bindIdentity(this.$identity());
                    this.cContextMenu = new $by.object.ContextMenu();
                    this.initUI();
                    if($by.object.Manager.getMergeDialog(this) != null){
                        this.pMergeRelationCtrl = new $byBase.object.mergeDialog().$init($ => $.$1(this, this.$identity())).getMergeRelationCtrl(this.$identity());
                        if(this.pMergeRelationCtrl != null){ this.pMergeRelationCtrl.selectChangeEvent.$add(async f_selectList => { await this.load(f_selectList != null && f_selectList.count == 1 ? f_selectList.$get(0).i$access("iID").by$toString() : null); }); }
                    }
                    else { this.cEditArea.init(); }
                    let tmpMaster = $by.object.Manager.getMergeDialog(this);
                    if(tmpMaster == null){
                        await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Slave_Must_Use_With_Master());
                        return;
                    }
                    let tmpMenuItem = new $by.object.MenuItem();
                    this.cContextMenu.add(tmpMenuItem);
                    tmpMenuItem.text = $byBase.object.ByBaseStrings.UI_bridge_manage_MenuItem_Add_Text();
                    tmpMenuItem.click.$add(async (sender, args) => {
                        let tmpRow = new $by.object.Row().$bindIdentity(this.$identity());
                        tmpRow.i$assign("iID", await $byCommon.identity.general.getGuid());
                        if(this.pMergeRelationCtrl != null && this.pMergeRelationCtrl.getMergeSelectRowList().count > 0){ Byt.Row["~="](tmpRow, this.pMergeRelationCtrl.getMergeSelectRowList().$get(0)); }
                        this.cEditArea.editAction = "insert";
                        this.cEditArea.setEditingData(tmpRow);
                        this.cEditArea.isEnabled = true;
                    });
                    tmpMenuItem = new $by.object.MenuItem();
                    this.cContextMenu.add(tmpMenuItem);
                    tmpMenuItem.text = $byBase.object.ByBaseStrings.UI_bridge_manage_MenuItem_Modify_Text();
                    tmpMenuItem.image = $by.object.Ku.getKu("byBase").getResource("modif.png").toImage();
                    tmpMenuItem.click.$add((sender, args) => {
                        this.cEditArea.isEnabled = true;
                        this.cEditArea.editAction = "update";
                    });
                    tmpMenuItem = new $by.object.MenuItem();
                    this.cContextMenu.add(tmpMenuItem);
                    tmpMenuItem.text = $byBase.object.ByBaseStrings.UI_bridge_manage_MenuItem_Save_Text();
                    tmpMenuItem.image = $by.object.Ku.getKu("byBase").getResource("save.png").toImage();
                    tmpMenuItem.click.$add(async (sender, args) => {
                        let tmpVerify = this.cEditArea.verify();
                        if(!tmpVerify.isOk){
                            await $by.object.Message.alert(tmpVerify.info);
                            return;
                        }
                        let tmpVerifyResult = this.cEditArea.verify();
                        if(!tmpVerifyResult.isOk){
                            await $by.object.Message.alert(tmpVerifyResult.info);
                            return;
                        }
                        let tmpRow = this.cEditArea.getEditingData();
                        if(this.cEditArea.editAction == "insert" || this.cEditArea.editAction == "update"){
                            let tmpValue = 0;
                            let isInsert = true;
                            if(this.cEditArea.editAction == "insert")
                                tmpValue = await $byBase.$sql({ ["#sql"]: "row", number: 27, args: [ tmpRow ], argTypes: [ Byt.Row ] });
                            else {
                                tmpValue = await $byBase.$sql({ ["#sql"]: "row", number: 28, args: [ tmpRow ], argTypes: [ Byt.Row ] });
                                isInsert = false;
                            }
                            if(tmpValue == 1){
                                let message = isInsert ? $byBase.object.ByBaseStrings.Message_Add_Completed() : $byBase.object.ByBaseStrings.Message_Modify_Completed();
                                await $by.object.Message.alert(message);
                            }
                            else {
                                let message = isInsert ? $byBase.object.ByBaseStrings.Message_Add_Failed() : $byBase.object.ByBaseStrings.Message_Modify_Failed();
                                await $by.object.Message.alert(message);
                                return;
                            }
                        }
                    });
                    tmpMenuItem = new $by.object.MenuItem();
                    this.cContextMenu.add(tmpMenuItem);
                    tmpMenuItem.text = $byBase.object.ByBaseStrings.UI_bridge_manage_MenuItem_Delete_Text();
                    tmpMenuItem.image = $by.object.Ku.getKu("byBase").getResource("delete.png").toImage();
                    tmpMenuItem.click.$add(async (sender, args) => {
                        let tmpRow = this.cEditArea.getEditingData();
                        if(tmpRow != null){ await $byBase.$sql({ ["#sql"]: "row", number: 29, args: [ tmpRow ], argTypes: [ Byt.Row ] }); }
                        this.cEditArea.init();
                    });
                    $byBase.identity.relatedEditArea.editAreaReferenceTran(this.cEditArea);
                    this.cEditArea.contextMenu = this.cContextMenu;
                }
                initUI(){
                    this.text = $byBase.object.ByBaseStrings.UI_extend_slave_Title();
                    this.cEditArea.text = $byBase.object.ByBaseStrings.UI_extend_slave_cEditArea_Text();
                }
                async load(f_id){
                    this.cEditArea.init();
                    let tmpRow = await this.$identity().load(f_id);
                    if(tmpRow != null){
                        this.cEditArea.editAction = "select";
                        this.cEditArea.setEditingData(tmpRow);
                    }
                }
            },
            instance: { props: { cContextMenu: $by.object.ContextMenu, pMergeRelationCtrl: "byBase.object.mergeRelationCtrl" } },
            dialog: { props: { cEditArea: $by.object.EditArea } }
        },
        detail$manage: {
            type: class manage extends Byt.Dialog {
                async $0(){
                    this.cGrid.$bindIdentity(this.$identity()).$init($ => { $.isEnabled = false; });
                    this.initUI();
                    if($by.object.Manager.getMergeDialog(this) != null){
                        this.pMergeRelationCtrl = new $byBase.object.mergeDialog().$init($ => $.$1(this, this.$identity())).getMergeRelationCtrl(Byt.Identity(this.cGrid));
                        if(this.pMergeRelationCtrl != null){
                            this.pMergeRelationCtrl.selectChangeEvent.$add(async f_selectList => { await this.load(f_selectList); });
                            let tmpIMaster = $byInterface.dialog.IBy$IMaster.$convert(this.pMergeRelationCtrl);
                            if(tmpIMaster != null){
                                tmpIMaster.$access([ $byInterface.dialog.IBy$IMaster, "pSlaveDialogList" ]).add($byInterface.dialog.IBy$ISlave.$convert(this));
                                tmpIMaster.$access([ $byInterface.dialog.IBy$IMaster, "addDeleteUpdateEvent" ]).$add((f_selectRow, f_curdAction) => {
                                    switch(f_curdAction){
                                        case "addBegin":
                                            this.cGrid.clear();
                                            this.cGrid.allowEdit = true;
                                            this.cGrid.isEnabled = true;
                                            break;
                                        case "modifBegin":
                                            this.cGrid.allowEdit = true;
                                            this.cGrid.isEnabled = true;
                                            break;
                                        case "addSave":
                                        case "modifSave":
                                            this.cGrid.allowEdit = false;
                                            this.cGrid.isEnabled = false;
                                            break;
                                        case "delete":
                                            this.cGrid.clear();
                                            this.cGrid.allowEdit = false;
                                            this.cGrid.isEnabled = false;
                                            break;
                                    }
                                });
                            }
                            else { await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_DetailHost_Not_Master()); }
                        }
                    }
                    else { await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Detail_Must_Use_With_Master()); }
                }
                initUI(){ this.cGrid.text = $byBase.object.ByBaseStrings.UI_detail_manage_cGrid_Text(); }
                async load(f_RowList){
                    this.cGrid.clear();
                    if(f_RowList != null && f_RowList.count == 1){
                        let tmpRowList = await this.$identity().load(f_RowList.$get(0));
                        if(tmpRowList.count > 0){ this.cGrid.addRange(tmpRowList); }
                    }
                }
                getAddDeleteUpdate(){ return null; }
                verifyAddDeleteUpdate(){ return false; }
            },
            base: { implements: [ "byInterface.dialog.IBy$ISlave" ] },
            instance: { props: { pMergeRelationCtrl: "byBase.object.mergeRelationCtrl" } },
            dialog: { props: { cGrid: $by.object.Grid } }
        },
        dic$manage: {
            type: class manage extends Byt.Dialog {
                async $0(){
                    this.cGrid.$bindIdentity(this.$identity());
                    this.pAction = "select";
                    this.cQueryArea.$bindIdentity(this.$identity());
                    this.cEditArea.$bindIdentity(this.$identity());
                    this.pSlaveDialogList = new $by.object.List();
                    this.initUI();
                    if(!this.$identity().confirmUserIsLogin())
                        return;
                    let tmpUpdateAllow = [ this.cBtnSave, this.cBtnCancel, this.cEditArea ];
                    let tmpInitAllow = [ this.cBtnAdd, this.cBtnDelete, this.cBtnModify, this.cBtnQuery, this.cGrid, this.cQueryArea ];
                    this.pButtonLock = new $byBase.object.buttonLock().$init($ => $.$1([ ], tmpUpdateAllow, tmpInitAllow));
                    this.cBtnQuery.click.$add(this.$access("actionInquiry"));
                    this.cBtnAdd.click.$add(this.$access("actionAddBegin"));
                    this.cBtnDelete.click.$add(this.$access("actionDelete"));
                    this.cBtnModify.click.$add(this.$access("actionModifyBegin"));
                    this.cBtnSave.click.$add(this.$access("actionSave"));
                    this.cBtnCancel.click.$add(this.$access("btnCancel_click"));
                    this.cGrid.selectionChanged.$add(this.$access("mGrid_selectionChanged"));
                    this.pButtonLock.setButtonState("init");
                    $byBase.identity.relatedEditArea.editAreaReferenceTran(this.cEditArea);
                    if($by.object.Manager.getMergeDialog(this) != null){
                        this.pMergeRelationCtrl = new $byBase.object.mergeDialog().$init($ => $.$1(this, this.$identity())).getMergeRelationCtrl(Byt.Identity($by.object.Grid.$convert(this.cGrid, $by.identity.Table)));
                        if(this.pMergeRelationCtrl != null){ this.pMergeRelationCtrl.selectChangeEvent.$add(async f_selectList => { await this.load(f_selectList); }); }
                    }
                    else { await this.load(null); }
                }
                initUI(){
                    this.text = $byBase.object.ByBaseStrings.UI_dic_manage_Title();
                    this.cGrid.text = $byBase.object.ByBaseStrings.UI_dic_manage_cGrid_Text();
                    this.cBtnQuery.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnQuery_Text();
                    this.cBtnAdd.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnAdd_Text();
                    this.cBtnDelete.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnDelete_Text();
                    this.cBtnModify.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnModify_Text();
                    this.cBtnSave.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnSave_Text();
                    this.cBtnCancel.text = $byBase.object.ByBaseStrings.UI_dic_manage_cBtnCancel_Text();
                    this.cQueryArea.text = $byBase.object.ByBaseStrings.UI_dic_manage_cQueryArea_Text();
                    this.cEditArea.text = $byBase.object.ByBaseStrings.UI_dic_manage_cEditArea_Text();
                }
                btnCancel_click(f_sender, f_e){ this.pButtonLock.setButtonState("init"); }
                mGrid_selectionChanged(f_sender, f_e){
                    if(this.cGrid.selectedRows.count == 1){ this.cEditArea.setEditingData(this.cGrid.selectedRows.$get(0)); }
                }
                async load(f_selectRowList){
                    this.cGrid.clear();
                    let tmpWaiting = await $byCommon.identity.relatedDialog.Loading();
                    if(f_selectRowList == null && this.pMergeRelationCtrl != null && this.pMergeRelationCtrl.getMergeSelectRowList().count > 0){ f_selectRowList = this.pMergeRelationCtrl.getMergeSelectRowList(); }
                    let tmpGridRows = await this.$identity().load(f_selectRowList, this.cQueryArea.data);
                    ($by.object.Grid.$convert(this.cGrid, $by.identity.Table)).addRange(tmpGridRows);
                    if(!this.$identity().CURDChangeEvent.by$equals(null)){ await this.$identity().CURDChangeEvent.$invoke(tmpGridRows, "select"); }
                    tmpWaiting.close();
                }
                async actionInquiry(f_sender, f_e){
                    this.pButtonLock.setButtonState("Lock");
                    await this.load(null);
                    this.pButtonLock.setButtonState("init");
                }
                async actionAddBegin(f_sender, f_e){
                    this.pAction = "insert";
                    this.pButtonLock.setButtonState("update");
                    let tmpRowSingle = ($by.object.Grid.$convert(this.cGrid, $by.identity.Table)).newRow();
                    for (let item of tmpRowSingle.cells){
                        if(Byt.DateTime.$check(item.value))
                            item.value = $by.object.DateTime.getNow();
                    }
                    if(this.pMergeRelationCtrl != null && this.pMergeRelationCtrl.getMergeSelectRowList().count > 0){ Byt.Row["~="](tmpRowSingle, this.pMergeRelationCtrl.getMergeSelectRowList().$get(0)); }
                    this.cEditArea.editAction = "insert";
                    this.cEditArea.setEditingData(tmpRowSingle);
                    if(!this.addDeleteUpdateEvent.by$equals(null))
                        await this.addDeleteUpdateEvent.$invoke(tmpRowSingle, "addBegin");
                }
                async actionAddEnd(){
                    let tmpRow = ($by.object.EditArea.$convert(this.cEditArea, $byBase.identity.dic)).getEditingData();
                    let tmpVerifyResult = this.cEditArea.verify();
                    if(!tmpVerifyResult.isOk){
                        await $by.object.Message.alert(Byt.String($byBase.object.ByBaseStrings.Warning_EditArea_Verify_Failed()) + Byt.String(tmpVerifyResult.info));
                        return;
                    }
                    if(!await $byBase.object.mergeDialog.verifySlaveDialog($byInterface.dialog.IBy$IMaster.$convert(this)))
                        return;
                    let tmpValue = await this.$identity().curdOverride(tmpRow, "insert");
                    $byCommon.identity.relatedGrid.refresh($by.object.Grid.$convert(this.cGrid, $by.identity.Table), tmpRow);
                    if(tmpValue.isOk){
                        this.pButtonLock.setButtonState("init");
                        this.cGrid.add(tmpRow);
                        if(!this.$identity().CURDChangeEvent.by$equals(null)){
                            let tmpList = new $by.object.List();
                            tmpList.add(tmpRow);
                            await this.$identity().CURDChangeEvent.$invoke(tmpList, "insert");
                        }
                        if(!this.addDeleteUpdateEvent.by$equals(null)){ await this.addDeleteUpdateEvent.$invoke(tmpRow, "addSave"); }
                    }
                    else { await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Insert_Failed()); }
                }
                async actionModifyBegin(f_sender, f_e){
                    this.pAction = "update";
                    this.pButtonLock.setButtonState("update");
                    this.cEditArea.init();
                    this.cEditArea.editAction = "update";
                    let tmpSelectedRows = ($by.object.Grid.$convert(this.cGrid, $byBase.identity.dic)).selectedRows;
                    if(tmpSelectedRows.count < 1){
                        await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Please_Select_A_Line());
                        this.pButtonLock.setButtonState("init");
                    }
                    else if(tmpSelectedRows.count == 1){
                        this.cEditArea.setEditingData(tmpSelectedRows.$get(0));
                        if(!this.addDeleteUpdateEvent.by$equals(null)){ await this.addDeleteUpdateEvent.$invoke(tmpSelectedRows.$get(0), "modifBegin"); }
                    }
                    else {
                        await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Cannot_Select_Multiple_Lines());
                        this.pButtonLock.setButtonState("init");
                    }
                }
                async actionModifyEnd(){
                    let tmpEditRow = ($by.object.EditArea.$convert(this.cEditArea, $byBase.identity.dic)).getEditingData();
                    let tmpVerifyResult = tmpEditRow.verify();
                    if(tmpEditRow == null || !tmpVerifyResult.isOk){
                        await $by.object.Message.alert(Byt.String($byBase.object.ByBaseStrings.Warning_EditArea_Verify_Failed()) + Byt.String(tmpVerifyResult.info));
                        return;
                    }
                    if(!await $byBase.object.mergeDialog.verifySlaveDialog($byInterface.dialog.IBy$IMaster.$convert(this)))
                        return;
                    let tmpResult = await this.$identity().curdOverride(tmpEditRow, "update");
                    if(tmpResult.isOk == true){
                        if(!this.addDeleteUpdateEvent.by$equals(null)){ await this.addDeleteUpdateEvent.$invoke(tmpEditRow, "modifSave"); }
                        $byCommon.identity.relatedGrid.refresh(($by.object.Grid.$convert(this.cGrid, $byBase.identity.dic)), tmpEditRow);
                        if(!this.$identity().CURDChangeEvent.by$equals(null)){
                            let tmpList = new $by.object.List();
                            tmpList.add(tmpEditRow);
                            await this.$identity().CURDChangeEvent.$invoke(tmpList, "update");
                        }
                    }
                    else {
                        await $by.object.Message.alert(tmpResult.info);
                        return;
                    }
                    this.pButtonLock.setButtonState("init");
                }
                async actionDelete(f_sender, f_e){
                    this.pButtonLock.setButtonState("Lock");
                    let tmpSelectedRows = ($by.object.Grid.$convert(this.cGrid, $byBase.identity.dic)).selectedRows;
                    if(tmpSelectedRows.count < 1){ await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Please_Select_A_Line()); }
                    else if(tmpSelectedRows.count == 1){
                        if(await $by.object.Message.confirm($byBase.object.ByBaseStrings.Warning_Sure_To_Delete())){
                            let tmpMergeDeleteList = new $by.object.List();
                            await $byBase.object.mergeDialog.getAddUpdateDeleteList(this.pSlaveDialogList, null, null, tmpMergeDeleteList);
                            let tmpResult = await this.$identity().curdOverride(tmpSelectedRows.$get(0), "delete");
                            if(tmpResult.isOk != true){
                                await $by.object.Message.alert(tmpResult.info);
                                if(!this.$identity().CURDChangeEvent.by$equals(null)){ await this.$identity().CURDChangeEvent.$invoke(tmpSelectedRows.toList(), "delete"); }
                            }
                            else {
                                this.cGrid.removeChild(tmpSelectedRows.$get(0));
                                if(!this.addDeleteUpdateEvent.by$equals(null)){ await this.addDeleteUpdateEvent.$invoke(tmpSelectedRows.$get(0), "delete"); }
                            }
                        }
                    }
                    else { await $by.object.Message.alert($byBase.object.ByBaseStrings.Warning_Cannot_Select_Multiple_Lines()); }
                    this.pButtonLock.setButtonState("init");
                }
                async actionSave(f_sender, f_e){
                    switch(this.pAction){
                        case "update":
                            await this.actionModifyEnd();
                            break;
                        case "insert":
                            await this.actionAddEnd();
                            break;
                    }
                }
                getSelectRows(){
                    let tmpResultValue = new $by.object.List();
                    if(this.cEditArea.editAction == "insert"){ tmpResultValue.add(($by.object.EditArea.$convert(this.cEditArea, $byBase.identity.dic)).getEditingData()); }
                    else { tmpResultValue.addRange(this.cGrid.selectedRows.toArray()); }
                    return tmpResultValue;
                }
            },
            base: { implements: [ "byInterface.dialog.IBy$IMaster" ] },
            instance: { props: { pButtonLock: "byBase.object.buttonLock", pAction: $by.enum.Action, pMergeRelationCtrl: "byBase.object.mergeRelationCtrl", pSlaveDialogList: [ "by.object.List", "byInterface.dialog.IBy$ISlave" ] }, events: [ "addDeleteUpdateEvent" ] },
            dialog: { props: { cGrid: $by.object.Grid, cBtnQuery: $by.object.Button, cBtnAdd: $by.object.Button, cBtnDelete: $by.object.Button, cBtnModify: $by.object.Button, cBtnSave: $by.object.Button, cBtnCancel: $by.object.Button, cQueryArea: $by.object.QueryArea, cEditArea: $by.object.EditArea } }
        }
    },
    orm: { bridge$myOrm: { tables: [ "a", "b" ], elements: [ "a.*" ] } }
}))