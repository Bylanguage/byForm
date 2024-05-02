using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byForm.Object
{
    public class TextHelper
    {
        public TextHelper()
        {
        }

        public static string invalidFieldTemplateID = "错误的字段模板ID";

        public static string invalidFieldID = "错误的字段ID";

        public static string misssingListData = "无效数据，列表中没有数据！";

        public static string illegalInjection = "非法注入，不支持的表源身份行！";

        public static string unexpectedControl = "未定义的控件类型";

        public static string formTemplateNotFound = "未找到对应的表单模板";

        public static string formNotFound = "未找到对应表单";

        public static string illegalMaxCount = "要求最多选中数量不合法";

        public static string sliderMinMaxCountError = "滑块最大值应当大于最小值";

        public static string fieldMinMaxCountError = "最大长度应当大于最小长度";

        public static string negativeMinMaxError = "最小长度和最大长度应当大于等于零";

        public static string dataLengthMaxError = "文本最大长度错误，允许的最大长度为";

        public static string lengthMaxError = "长度不能超过";

        public static string invalidValueError = "无效的值!";

        public static string formIdLoss = "缺少formid,请检查链接是否正确";

        public static string formIdError = "请检查参数formID是否正确";

        public static string unsupportedChart = "字段类型与图表类型不匹配 或 尚未支持的图表/字段类型";

        public static string formUserLoss = "用户未登录或身份验证失败";

        public static string stasticsFieldLess = "当前表单缺少字段,无法统计";

        public static string formOutdateError = "未知(由于表单版本过时)";

        public static string sheetSubmittedLoss = "不存在的信息，这条信息可能已经被删除！";

        public static string labelEventError = "错误的标签事件绑定";

        public static string templateLabelRowLossError = "标签控件未绑定到字段模板数据行";

        public static string fieldCreatedLossError = "拖拽生成的字段信息为空";

        public static string restored = "已恢复到修改前";

        public static string saveSuccess = "保存成功!";

        public static string saveFail = "保存失败!";

        public static string remainError = "存在未解决的错误:";

        public static string saveFormFailed = "保存表单信息错误!";

        public static string emptyFieldPanel = "字段面板为空";

        public static string unexpectedControlInFieldPanel = "字段面板中存在未预料的控件类型，预期类型：FieldTermPanel";

        public static string notLoggedIn = "当前用户还没有登录！";

        public static string pleaseLogIn = "请先登录!";

        public static string insufficientPermissions = "当前用户权限不足";

        public static string formNameNull = "表单名称不能为空";

        public static string previewOnly = "此页面仅供预览,无法提交!";

        public static string defaultSubmitSuccessMessage = "谢谢,我们会尽快处理！";

        public static string defaultSubmitButtonText = "确认提交";

        public static string edit = "编辑";

        public static string delete = "删除";

        public static string add = "增加";

        public static string save = "保存";

        public static string notSave = "不保存";

        public static string cancel = "取消";

        public static string close = "关闭";

        public static string publish = "发布";

        public static string viewResult = "查看答卷";

        public static string statisticsResult = "统计结果";

        public static string statisticsResultTip = "统计并展示图表";

        public static string appendChart = "增加字段";

        public static string appendChartTip = "在当前统计图表增加新的字段项组成复合图表";

        public static string deleteChartContainer = "删除图表";

        public static string createChart = "创建新图表";

        public static string createChartTip = "创建一个新的空白图表";

        public static string exit = "退出";

        public static string queryDeleteField = "检查到已在编辑区打开，请选择是否删除?";

        public static string querySave = "可能有未保存的修改,请问是否保存?";

        public static string formSaveSuccessMessage = "保存成功，请问是否退出当前表单编辑界面?";

        public static string queryDeleteForm = "您确认删除问卷\"{0}\"吗？";

        public static string notNull = "必填";

        public static string sliderMax = "最大值";

        public static string sliderMin = "最小值";

        public static string sliderDelta = "间隔";

        public static string checkMin = "最少选择数";

        public static string checkMax = "最多选择数";

        public static string fieldMax = "最大长度";

        public static string fieldMin = "最小长度";

        public static string valueMax = "最大值";

        public static string valueMin = "最小值";

        public static string fieldRegex = "正则验证表达式";

        public static string fieldRegexMessage = "正则验证消息";

        public static string optionName = "选项名称";

        public static string formName = "表单名称";

        public static string formSummary = "表单说明";

        public static string successMessage = "保存成功的信息提示";

        public static string submitButtonText = "提交按钮的文本";

        public static string defaultFormName = "新建未命名表单";

        public static string defaultFormSummary = "";

        public static string fieldName = "字段名称";

        public static string formListLabelText = "表单列表";

        public static string createFormButtonText = "新建表单";

        public static string summary = "说明";

        public static string createButtonText = "创建";

        public static string saveForm = "保存到表单";

        public static string preview = "预览";

        public static string saasInfo = "saas服务调用代码";

        public static string saasSample = "saas服务调用示例";

        public static string defaultCheckItem = "判断项";

        public static string defaultCheckItemOne = "选项1";

        public static string defaultCheckItemTwo = "选项2";

        public static string defaultSelectValues = byForm_Server.ku.byForm.Object.TextHelper.defaultCheckItemOne + "\n" + byForm_Server.ku.byForm.Object.TextHelper.defaultCheckItemTwo;

        public static string defaultSliderSelectValue = "0\n10\n1";

        public static string defaultTextboxText = "";

        public static string formNameEditTip = "点击可编辑";

        public static string draggableTip = "可拖动当前元素到中间区域";

        public static string saasDivTip = "本div如果存在则会把生成表单放入其中，本项可以没有";

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
