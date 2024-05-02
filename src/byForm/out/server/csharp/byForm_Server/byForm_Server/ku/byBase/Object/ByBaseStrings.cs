using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Object
{
    public class ByBaseStrings
    {
        public ByBaseStrings()
        {
        }

        public static string language;

        public static string Format(string format, object[] args)
        {
            if (format == null)
            {
                return "";
            }
            if (args == null)
            {
                args = byForm_Server.ku.by.ToolClass.ToolFunction.CrateArray<object[]>(0);
            }
            for (int i = 0; i < args.Length; i++)
            {
                object arg = args[i];
                if (arg == null)
                {
                    arg = "";
                }
                format = format.Replace("{" + i + "}", arg.ToString());
            }
            return format;
        }

        public static string Format_(string format, object arg1)
        {
            return format.Replace("{0}", arg1 == null ? "" : arg1.ToString());
        }

        public static string Format_(string format, object arg1, object arg2)
        {
            return format.Replace("{0}", arg1 == null ? "" : arg1.ToString()).Replace("{1}", arg2 == null ? "" : arg2.ToString());
        }

        public static string Format_(string format, object arg1, object arg2, object arg3)
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.Format(format, new object[] { arg1, arg2, arg3 });
        }

        public static string Format_(string format, object arg1, object arg2, object arg3, object arg4)
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.Format(format, new object[] { arg1, arg2, arg3, arg4 });
        }

        public static string getString(string ch, string en)
        {
            return (language ?? byForm_Server.ku.by.Object.system.language) == "en-us" ? en : ch;
        }

        public static string Warning_Database_Insert_Failed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("对数据库 insert 失败", "database insert failed");
        }

        public static string Warning_Database_Update_Failed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("对数据库 update 失败", "database update failed");
        }

        public static string Warning_Database_Delete_Failed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("对数据库 delete 失败", "database delete failed");
        }

        public static string Warning_User_Not_Login()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("当前用户还没有登录", "The current user has not logined.");
        }

        public static string Warning_Tree_Cycle_Template(string tmpTableName, object treeRowID)
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.Format_(byForm_Server.ku.byBase.Object.ByBaseStrings.getString("树子项的父项不能为自身，这将陷入无限循环!请修改表:{0}中标记构件的列INO:{1}中的值,其不能与自身的父节点相同!", "The parent of a tree item cannot be itself, which will cause a cycle. Please change the INO value {1} of table {0}, it cannot have a value same as itself."), tmpTableName, treeRowID);
        }

        public static string Warning_EditArea_Verify_Failed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("编辑区填写的内容不合法:", "The verification of this editArea failed: ");
        }

        public static string Warning_Insert_Failed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("增加数据失败！", "Insertion failed ");
        }

        public static string Warning_Please_Select_A_Line()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("请选择一行，再尝试该操作！", "Please select a line and try again!");
        }

        public static string Warning_Cannot_Select_Multiple_Lines()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("不能多选，一次仅能选择一行编辑！", "Cannot select multiple lines, only one line can be edited at a time.");
        }

        public static string Warning_Sure_To_Delete()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("确认要删除？", "Are you sure to delete?");
        }

        public static string Warning_SQL_Failed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("执行sql没有成功:", "SQL execute failed, details: ");
        }

        public static string Warning_TreeNode_Cannot_Parent_To_Itself()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("当前节点与父节点不能一样！", "Cannot set parent node of a treenode to itself!");
        }

        public static string Warning_Please_Select_A_TreeNode()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("请先选择一个节点后，再尝试该操作！", "Please select a tree node and try again!");
        }

        public static string Warning_Sure_To_Delete_Nodes()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("确认要删除当前节点，及其所属的所有子节点吗？", "Are you sure to delete this node and all its descendant nodes?");
        }

        public static string Warning_Bridge_Cannot_Find_Reference()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("没有找到对应的表级关系信息，或者通过关系没有找到对应的popup会话窗体信息！", "Cannot find any corresponding table-identity via field-reference.");
        }

        public static string Message_Add_Completed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("新建成功！", "Add completed! ");
        }

        public static string Message_Add_Failed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("新建失败！", "Add failed. ");
        }

        public static string Message_Modify_Completed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("修改成功！", "Modify Completed!");
        }

        public static string Message_Modify_Failed()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("修改失败！", "Modify failed ");
        }

        public static string Warning_Slave_Must_Use_With_Master()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("扩展表身份只能与其对应的主表配合展表，不支持独立会话窗体进行操作！！", "Slave or extend dialog must be used with a manager and a host, cannot use this dialog alone!");
        }

        public static string Warning_DetailHost_Not_Master()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("当前合并的主dialog 没有实现 IBy.IMaster 接口，合并后将仅支持查询，不支持update、insert、delete操作！", "The host of this dialog is not a 'IBy.IMaster, only query operation is supported!");
        }

        public static string Warning_Detail_Must_Use_With_Master()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("detail 为从表身份，需要与其他主身份dialog 一起联合展示，\r\n不支持独立展示，请将当前的dialog合并到其他主dialog后才能展示！", "The detail dialog must be used with a manager and a host, cannot use this dialog alone!");
        }

        public static string UI_popupTable_popup_Title()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("弹窗选择多行或一行", "Select one or more lines in this popup dialog");
        }

        public static string UI_popupTable_popup_cGrid_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("表格网格控件", "Grid control");
        }

        public static string UI_popupTable_popup_cBtnQuery_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("检索", "Query");
        }

        public static string UI_popupTable_popup_cBtnComplete_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("完成", "Complete");
        }

        public static string UI_popupTable_popup_cMQueryArea_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("查询区", "QueryArea");
        }

        public static string UI_popupTable_popup_MenuItem_Add_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("添加数据", "Add data");
        }

        public static string UI_popupTable_popup_MenuItem_Refresh_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("刷新", "Refresh");
        }

        public static string UI_dic_manage_Title()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("字典表", "Dictioanry");
        }

        public static string UI_dic_manage_cGrid_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("字典网格控件", "Dictionary Grid");
        }

        public static string UI_dic_manage_cBtnQuery_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("检索", "Query");
        }

        public static string UI_dic_manage_cBtnAdd_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("增加", "Add");
        }

        public static string UI_dic_manage_cBtnDelete_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("删除", "Delete");
        }

        public static string UI_dic_manage_cBtnModify_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("修改", "Modify");
        }

        public static string UI_dic_manage_cBtnSave_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("保存", "Save");
        }

        public static string UI_dic_manage_cBtnCancel_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("取消", "Cancel");
        }

        public static string UI_dic_manage_cQueryArea_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("查询区", "QueryArea");
        }

        public static string UI_dic_manage_cEditArea_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("编辑区", "EditArea");
        }

        public static string UI_Tree_popup_Title()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("弹窗选择多行或一行", "Select one or more tree nodes");
        }

        public static string UI_Tree_popup_cMQueryArea_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("查询区", "Query Area");
        }

        public static string UI_Tree_popup_cBtnQuery_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("检索", "Query");
        }

        public static string UI_Tree_popup_cBtnComplete_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("完成", "Complete");
        }

        public static string UI_Tree_popup_cTree_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("表格网格控件", "Table tree control");
        }

        public static string UI_Tree_popup_MenuItem_Add_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("添加数据", "Add data");
        }

        public static string UI_Tree_popup_MenuItem_Refresh_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("刷新", "Refresh");
        }

        public static string UI_Tree_manage_Title()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("树管理", "Tree");
        }

        public static string UI_Tree_manage_cTree_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("树控件", "TreeView");
        }

        public static string UI_Tree_manage_cBtnAdd_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("增加", "Add");
        }

        public static string UI_Tree_manage_cBtnDelete_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("删除", "Delete");
        }

        public static string UI_Tree_manage_cBtnModify_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("修改", "Modify");
        }

        public static string UI_Tree_manage_cBtnSave_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("保存", "Save");
        }

        public static string UI_Tree_manage_cBtnCancel_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("取消", "Cancel");
        }

        public static string UI_Tree_manage_cEditArea_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("编辑区", "EditArea");
        }

        public static string UI_bridge_manage_Title()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("中间表管理", "Intermediate manage");
        }

        public static string UI_bridge_manage_cGridLeft_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("网格左", "Left Grid");
        }

        public static string UI_bridge_manage_cGridRight_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("网格右", "Right Grid");
        }

        public static string UI_bridge_manage_cBtnDelete_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("删除", "Delete");
        }

        public static string UI_bridge_manage_cBtnModify_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("修改", "Modify");
        }

        public static string UI_bridge_manage_MenuItem_Add_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("新建", "Add");
        }

        public static string UI_bridge_manage_MenuItem_Modify_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("修改", "Add");
        }

        public static string UI_bridge_manage_MenuItem_Save_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("保存", "Add");
        }

        public static string UI_bridge_manage_MenuItem_Delete_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("删除", "Delete");
        }

        public static string UI_extend_slave_Title()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("本项只能拼入其他dialog中，仅支持一个单行的增删改", "Only used as a merge-guest, support one-line CRUD");
        }

        public static string UI_extend_slave_cEditArea_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("编辑区", "EditArea");
        }

        public static string UI_detail_manage_cGrid_Text()
        {
            return byForm_Server.ku.byBase.Object.ByBaseStrings.getString("网格控件", "Grid View");
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
