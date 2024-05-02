package $Ku.byBase.Object;

public class ByBaseStrings extends $Ku.by.Object.ByObject {
    public static java.lang.String language;

    public ByBaseStrings() {
    }


    public static java.lang.String Format(java.lang.String format, java.lang.Object[] args) {
        if (java.util.Objects.equals(format, null)) {
            return "";
        }
        if (java.util.Objects.equals(args, null)) {
            args = new java.lang.Object[0];
        }
        for (java.lang.Integer i = 0; i < args.length; i++) {
            java.lang.Object arg = args[i];
            if (java.util.Objects.equals(arg, null)) {
                arg = "";
            }
            format = format.replace("{" + i + "}", arg.toString());
        }
        return format;
    }

    public static java.lang.String Format(java.lang.String format, java.lang.Object arg1) {
        return format.replace("{0}", java.util.Objects.equals(arg1, null) ? "" : arg1.toString());
    }

    public static java.lang.String Format(java.lang.String format, java.lang.Object arg1, java.lang.Object arg2) {
        return format.replace("{0}", java.util.Objects.equals(arg1, null) ? "" : arg1.toString()).replace("{1}", java.util.Objects.equals(arg2, null) ? "" : arg2.toString());
    }

    public static java.lang.String Format(java.lang.String format, java.lang.Object arg1, java.lang.Object arg2, java.lang.Object arg3) {
        return Format(format, new java.lang.Object[]{arg1,arg2,arg3});
    }

    public static java.lang.String Format(java.lang.String format, java.lang.Object arg1, java.lang.Object arg2, java.lang.Object arg3, java.lang.Object arg4) {
        return Format(format, new java.lang.Object[]{arg1,arg2,arg3,arg4});
    }

    public static java.lang.String getString(java.lang.String ch, java.lang.String en) {
        return java.util.Objects.equals((language != null ? language : $Ku.by.Object.System.getLanguage()), "en-us") ? en : ch;
    }

    public static java.lang.String Warning_Database_Insert_Failed() {
        return getString("对数据库 insert 失败", "database insert failed");
    }

    public static java.lang.String Warning_Database_Update_Failed() {
        return getString("对数据库 update 失败", "database update failed");
    }

    public static java.lang.String Warning_Database_Delete_Failed() {
        return getString("对数据库 delete 失败", "database delete failed");
    }

    public static java.lang.String Warning_User_Not_Login() {
        return getString("当前用户还没有登录", "The current user has not logined.");
    }

    public static java.lang.String Warning_Tree_Cycle_Template(java.lang.String tmpTableName, java.lang.Object treeRowID) {
        return Format(getString("树子项的父项不能为自身，这将陷入无限循环!请修改表:{0}中标记构件的列INO:{1}中的值,其不能与自身的父节点相同!", "The parent of a tree item cannot be itself, which will cause a cycle. Please change the INO value {1} of table {0}, it cannot have a value same as itself."), tmpTableName, treeRowID);
    }

    public static java.lang.String Warning_EditArea_Verify_Failed() {
        return getString("编辑区填写的内容不合法:", "The verification of this editArea failed: ");
    }

    public static java.lang.String Warning_Insert_Failed() {
        return getString("增加数据失败！", "Insertion failed ");
    }

    public static java.lang.String Warning_Please_Select_A_Line() {
        return getString("请选择一行，再尝试该操作！", "Please select a line and try again!");
    }

    public static java.lang.String Warning_Cannot_Select_Multiple_Lines() {
        return getString("不能多选，一次仅能选择一行编辑！", "Cannot select multiple lines, only one line can be edited at a time.");
    }

    public static java.lang.String Warning_Sure_To_Delete() {
        return getString("确认要删除？", "Are you sure to delete?");
    }

    public static java.lang.String Warning_SQL_Failed() {
        return getString("执行sql没有成功:", "SQL execute failed, details: ");
    }

    public static java.lang.String Warning_TreeNode_Cannot_Parent_To_Itself() {
        return getString("当前节点与父节点不能一样！", "Cannot set parent node of a treenode to itself!");
    }

    public static java.lang.String Warning_Please_Select_A_TreeNode() {
        return getString("请先选择一个节点后，再尝试该操作！", "Please select a tree node and try again!");
    }

    public static java.lang.String Warning_Sure_To_Delete_Nodes() {
        return getString("确认要删除当前节点，及其所属的所有子节点吗？", "Are you sure to delete this node and all its descendant nodes?");
    }

    public static java.lang.String Warning_Bridge_Cannot_Find_Reference() {
        return getString("没有找到对应的表级关系信息，或者通过关系没有找到对应的popup会话窗体信息！", "Cannot find any corresponding table-identity via field-reference.");
    }

    public static java.lang.String Message_Add_Completed() {
        return getString("新建成功！", "Add completed! ");
    }

    public static java.lang.String Message_Add_Failed() {
        return getString("新建失败！", "Add failed. ");
    }

    public static java.lang.String Message_Modify_Completed() {
        return getString("修改成功！", "Modify Completed!");
    }

    public static java.lang.String Message_Modify_Failed() {
        return getString("修改失败！", "Modify failed ");
    }

    public static java.lang.String Warning_Slave_Must_Use_With_Master() {
        return getString("扩展表身份只能与其对应的主表配合展表，不支持独立会话窗体进行操作！！", "Slave or extend dialog must be used with a manager and a host, cannot use this dialog alone!");
    }

    public static java.lang.String Warning_DetailHost_Not_Master() {
        return getString("当前合并的主dialog 没有实现 IBy.IMaster 接口，合并后将仅支持查询，不支持update、insert、delete操作！", "The host of this dialog is not a 'IBy.IMaster, only query operation is supported!");
    }

    public static java.lang.String Warning_Detail_Must_Use_With_Master() {
        return getString("detail 为从表身份，需要与其他主身份dialog 一起联合展示，\r\n不支持独立展示，请将当前的dialog合并到其他主dialog后才能展示！", "The detail dialog must be used with a manager and a host, cannot use this dialog alone!");
    }

    public static java.lang.String UI_popupTable_popup_Title() {
        return getString("弹窗选择多行或一行", "Select one or more lines in this popup dialog");
    }

    public static java.lang.String UI_popupTable_popup_cGrid_Text() {
        return getString("表格网格控件", "Grid control");
    }

    public static java.lang.String UI_popupTable_popup_cBtnQuery_Text() {
        return getString("检索", "Query");
    }

    public static java.lang.String UI_popupTable_popup_cBtnComplete_Text() {
        return getString("完成", "Complete");
    }

    public static java.lang.String UI_popupTable_popup_cMQueryArea_Text() {
        return getString("查询区", "QueryArea");
    }

    public static java.lang.String UI_popupTable_popup_MenuItem_Add_Text() {
        return getString("添加数据", "Add data");
    }

    public static java.lang.String UI_popupTable_popup_MenuItem_Refresh_Text() {
        return getString("刷新", "Refresh");
    }

    public static java.lang.String UI_dic_manage_Title() {
        return getString("字典表", "Dictioanry");
    }

    public static java.lang.String UI_dic_manage_cGrid_Text() {
        return getString("字典网格控件", "Dictionary Grid");
    }

    public static java.lang.String UI_dic_manage_cBtnQuery_Text() {
        return getString("检索", "Query");
    }

    public static java.lang.String UI_dic_manage_cBtnAdd_Text() {
        return getString("增加", "Add");
    }

    public static java.lang.String UI_dic_manage_cBtnDelete_Text() {
        return getString("删除", "Delete");
    }

    public static java.lang.String UI_dic_manage_cBtnModify_Text() {
        return getString("修改", "Modify");
    }

    public static java.lang.String UI_dic_manage_cBtnSave_Text() {
        return getString("保存", "Save");
    }

    public static java.lang.String UI_dic_manage_cBtnCancel_Text() {
        return getString("取消", "Cancel");
    }

    public static java.lang.String UI_dic_manage_cQueryArea_Text() {
        return getString("查询区", "QueryArea");
    }

    public static java.lang.String UI_dic_manage_cEditArea_Text() {
        return getString("编辑区", "EditArea");
    }

    public static java.lang.String UI_Tree_popup_Title() {
        return getString("弹窗选择多行或一行", "Select one or more tree nodes");
    }

    public static java.lang.String UI_Tree_popup_cMQueryArea_Text() {
        return getString("查询区", "Query Area");
    }

    public static java.lang.String UI_Tree_popup_cBtnQuery_Text() {
        return getString("检索", "Query");
    }

    public static java.lang.String UI_Tree_popup_cBtnComplete_Text() {
        return getString("完成", "Complete");
    }

    public static java.lang.String UI_Tree_popup_cTree_Text() {
        return getString("表格网格控件", "Table tree control");
    }

    public static java.lang.String UI_Tree_popup_MenuItem_Add_Text() {
        return getString("添加数据", "Add data");
    }

    public static java.lang.String UI_Tree_popup_MenuItem_Refresh_Text() {
        return getString("刷新", "Refresh");
    }

    public static java.lang.String UI_Tree_manage_Title() {
        return getString("树管理", "Tree");
    }

    public static java.lang.String UI_Tree_manage_cTree_Text() {
        return getString("树控件", "TreeView");
    }

    public static java.lang.String UI_Tree_manage_cBtnAdd_Text() {
        return getString("增加", "Add");
    }

    public static java.lang.String UI_Tree_manage_cBtnDelete_Text() {
        return getString("删除", "Delete");
    }

    public static java.lang.String UI_Tree_manage_cBtnModify_Text() {
        return getString("修改", "Modify");
    }

    public static java.lang.String UI_Tree_manage_cBtnSave_Text() {
        return getString("保存", "Save");
    }

    public static java.lang.String UI_Tree_manage_cBtnCancel_Text() {
        return getString("取消", "Cancel");
    }

    public static java.lang.String UI_Tree_manage_cEditArea_Text() {
        return getString("编辑区", "EditArea");
    }

    public static java.lang.String UI_bridge_manage_Title() {
        return getString("中间表管理", "Intermediate manage");
    }

    public static java.lang.String UI_bridge_manage_cGridLeft_Text() {
        return getString("网格左", "Left Grid");
    }

    public static java.lang.String UI_bridge_manage_cGridRight_Text() {
        return getString("网格右", "Right Grid");
    }

    public static java.lang.String UI_bridge_manage_cBtnDelete_Text() {
        return getString("删除", "Delete");
    }

    public static java.lang.String UI_bridge_manage_cBtnModify_Text() {
        return getString("修改", "Modify");
    }

    public static java.lang.String UI_bridge_manage_MenuItem_Add_Text() {
        return getString("新建", "Add");
    }

    public static java.lang.String UI_bridge_manage_MenuItem_Modify_Text() {
        return getString("修改", "Add");
    }

    public static java.lang.String UI_bridge_manage_MenuItem_Save_Text() {
        return getString("保存", "Add");
    }

    public static java.lang.String UI_bridge_manage_MenuItem_Delete_Text() {
        return getString("删除", "Delete");
    }

    public static java.lang.String UI_extend_slave_Title() {
        return getString("本项只能拼入其他dialog中，仅支持一个单行的增删改", "Only used as a merge-guest, support one-line CRUD");
    }

    public static java.lang.String UI_extend_slave_cEditArea_Text() {
        return getString("编辑区", "EditArea");
    }

    public static java.lang.String UI_detail_manage_cGrid_Text() {
        return getString("网格控件", "Grid View");
    }

    public $Ku.byBase.Object.ByBaseStrings $getThis$Ku_byBase_Object_ByBaseStrings() {
        return this;
    }
}
