package $Ku.byCommon.Object;

public class ByCommonStrings extends $Ku.by.Object.ByObject {
    public static java.lang.String language;

    public ByCommonStrings() {
    }


    private static java.lang.String Format(java.lang.String format, java.lang.Object[] args) {
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

    private static java.lang.String Format(java.lang.String format, java.lang.Object arg1) {
        return format.replace("{0}", java.util.Objects.equals(arg1, null) ? "" : arg1.toString());
    }

    private static java.lang.String Format(java.lang.String format, java.lang.Object arg1, java.lang.Object arg2) {
        return format.replace("{0}", java.util.Objects.equals(arg1, null) ? "" : arg1.toString()).replace("{1}", java.util.Objects.equals(arg2, null) ? "" : arg2.toString());
    }

    private static java.lang.String Format(java.lang.String format, java.lang.Object arg1, java.lang.Object arg2, java.lang.Object arg3) {
        return $Ku.byCommon.Object.ByCommonStrings.Format(format, new java.lang.Object[]{arg1,arg2,arg3});
    }

    private static java.lang.String Format(java.lang.String format, java.lang.Object arg1, java.lang.Object arg2, java.lang.Object arg3, java.lang.Object arg4) {
        return $Ku.byCommon.Object.ByCommonStrings.Format(format, new java.lang.Object[]{arg1,arg2,arg3,arg4});
    }

    private static java.lang.String getString(java.lang.String ch, java.lang.String en) {
        return java.util.Objects.equals((language != null ? language : $Ku.by.Object.System.getLanguage()), "en-us") ? en : ch;
    }

    public static java.lang.String Warning_Too_Many_Characters() {
        return getString("字数太多啦！ ", "Too many characters! ");
    }

    public static java.lang.String Label_Template_Page_Results(java.lang.Integer tmpPageNum, java.lang.Integer totalCount) {
        return Format(getString("   共：{0} 页   记录总数：{1}", "Totally {0} pages, {1} records. "), tmpPageNum, totalCount);
    }

    public static java.lang.String Warning_Tree_Cycle_Template(java.lang.String tmpTableName, java.lang.Object treeRowID) {
        return Format(getString("树子项的父项不能为自身，这将陷入无限循环!请修改表:{0}中标记构件的列INO:{1}中的值,其不能与自身的父节点相同!", "The parent of a tree item cannot be itself, which will cause a cycle. Please change the INO value {1} of table {0}, it cannot have a value same as itself."), tmpTableName, treeRowID);
    }

    public static java.lang.String UI_relatedDialog_loadingDialog_Title() {
        return getString("正在装入数据，请稍后...", "Loading data, please wait...");
    }

    public static java.lang.String UI_relatedDialog_loadingDialog_pLoadingImage_Text() {
        return getString("装载图片", "The loaded data");
    }

    public static java.lang.String UI_relatedDialog_notice_Title() {
        return getString("弹窗显示类似一个公告，仅即时展示一条信息", "Pop up a notice");
    }

    public static java.lang.String UI_relatedDialog_popupTree_Title() {
        return getString("显示一个树弹窗，以对象方式", "Popup a tree dialog");
    }

    public static java.lang.String UI_relatedDialog_popupTree_cTree_Text() {
        return getString("树", "Tree View");
    }

    public static java.lang.String UI_relatedDialog_popupTree_cBtnOk_Text() {
        return getString("确认", "OK");
    }

    public static java.lang.String UI_relatedDialog_popupTree_cBtnCancel_Text() {
        return getString("取消", "Cancel");
    }

    public static java.lang.String UI_relatedDialog_popupTable_Title() {
        return getString("请选择行", "Please select a row");
    }

    public static java.lang.String UI_relatedDialog_popupTable_cGrid_Text() {
        return getString("要显示的网格控件", "Grid View");
    }

    public static java.lang.String UI_relatedDialog_popupTable_cBtnOk_Text() {
        return getString("确认", "OK");
    }

    public static java.lang.String UI_relatedDialog_popupTable_cBtnCancel_Text() {
        return getString("取消", "Cancel");
    }

    public static java.lang.String UI_relatedDialog_popupList_Title() {
        return getString("请选择列表,展示一个选择列表", "Please select a row in this popupList");
    }

    public static java.lang.String UI_relatedDialog_popupList_cGrid_Text() {
        return getString("要显示的网格控件", "Grid View");
    }

    public static java.lang.String UI_relatedDialog_popupList_cBtnOk_Text() {
        return getString("确认", "OK");
    }

    public static java.lang.String UI_relatedDialog_popupList_cBtnCancel_Text() {
        return getString("取消", "Cancel");
    }

    public static java.lang.String UI_relatedDialog_popupList_Message_PleaseSelectAnItem() {
        return getString("请选择数据项", "Please select a data-row");
    }

    public static java.lang.String UI_relatedDialog_popupTextbox_Title() {
        return getString("请选择,展示一个文本框", "Please select a item in this textbox...");
    }

    public static java.lang.String UI_relatedDialog_popupTextbox_cLblTitle_Text() {
        return getString("标题", "Title");
    }

    public static java.lang.String UI_relatedDialog_popupTextbox_cBtnOk_Text() {
        return getString("确认", "OK");
    }

    public static java.lang.String UI_relatedDialog_popupTextbox_cBtnCancel_Text() {
        return getString("取消", "Cancel");
    }

    public $Ku.byCommon.Object.ByCommonStrings $getThis$Ku_byCommon_Object_ByCommonStrings() {
        return this;
    }
}
