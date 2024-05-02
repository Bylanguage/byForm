using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Object
{
    public class ByCommonStrings
    {
        public ByCommonStrings()
        {
        }

        public static string language;

        private static string Format(string format, object[] args)
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

        private static string Format_(string format, object arg1)
        {
            return format.Replace("{0}", arg1 == null ? "" : arg1.ToString());
        }

        private static string Format_(string format, object arg1, object arg2)
        {
            return format.Replace("{0}", arg1 == null ? "" : arg1.ToString()).Replace("{1}", arg2 == null ? "" : arg2.ToString());
        }

        private static string Format_(string format, object arg1, object arg2, object arg3)
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.Format(format, new object[] { arg1, arg2, arg3 });
        }

        private static string Format_(string format, object arg1, object arg2, object arg3, object arg4)
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.Format(format, new object[] { arg1, arg2, arg3, arg4 });
        }

        private static string getString(string ch, string en)
        {
            return (language ?? byForm_Server.ku.by.Object.system.language) == "en-us" ? en : ch;
        }

        public static string Warning_Too_Many_Characters()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("字数太多啦！ ", "Too many characters! ");
        }

        public static string Label_Template_Page_Results(int tmpPageNum, int totalCount)
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.Format_(byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("   共：{0} 页   记录总数：{1}", "Totally {0} pages, {1} records. "), tmpPageNum, totalCount);
        }

        public static string Warning_Tree_Cycle_Template(string tmpTableName, object treeRowID)
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.Format_(byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("树子项的父项不能为自身，这将陷入无限循环!请修改表:{0}中标记构件的列INO:{1}中的值,其不能与自身的父节点相同!", "The parent of a tree item cannot be itself, which will cause a cycle. Please change the INO value {1} of table {0}, it cannot have a value same as itself."), tmpTableName, treeRowID);
        }

        public static string UI_relatedDialog_loadingDialog_Title()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("正在装入数据，请稍后...", "Loading data, please wait...");
        }

        public static string UI_relatedDialog_loadingDialog_pLoadingImage_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("装载图片", "The loaded data");
        }

        public static string UI_relatedDialog_notice_Title()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("弹窗显示类似一个公告，仅即时展示一条信息", "Pop up a notice");
        }

        public static string UI_relatedDialog_popupTree_Title()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("显示一个树弹窗，以对象方式", "Popup a tree dialog");
        }

        public static string UI_relatedDialog_popupTree_cTree_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("树", "Tree View");
        }

        public static string UI_relatedDialog_popupTree_cBtnOk_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("确认", "OK");
        }

        public static string UI_relatedDialog_popupTree_cBtnCancel_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("取消", "Cancel");
        }

        public static string UI_relatedDialog_popupTable_Title()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("请选择行", "Please select a row");
        }

        public static string UI_relatedDialog_popupTable_cGrid_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("要显示的网格控件", "Grid View");
        }

        public static string UI_relatedDialog_popupTable_cBtnOk_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("确认", "OK");
        }

        public static string UI_relatedDialog_popupTable_cBtnCancel_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("取消", "Cancel");
        }

        public static string UI_relatedDialog_popupList_Title()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("请选择列表,展示一个选择列表", "Please select a row in this popupList");
        }

        public static string UI_relatedDialog_popupList_cGrid_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("要显示的网格控件", "Grid View");
        }

        public static string UI_relatedDialog_popupList_cBtnOk_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("确认", "OK");
        }

        public static string UI_relatedDialog_popupList_cBtnCancel_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("取消", "Cancel");
        }

        public static string UI_relatedDialog_popupList_Message_PleaseSelectAnItem()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("请选择数据项", "Please select a data-row");
        }

        public static string UI_relatedDialog_popupTextbox_Title()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("请选择,展示一个文本框", "Please select a item in this textbox...");
        }

        public static string UI_relatedDialog_popupTextbox_cLblTitle_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("标题", "Title");
        }

        public static string UI_relatedDialog_popupTextbox_cBtnOk_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("确认", "OK");
        }

        public static string UI_relatedDialog_popupTextbox_cBtnCancel_Text()
        {
            return byForm_Server.ku.byCommon.Object.ByCommonStrings.getString("取消", "Cancel");
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
