package $Ku.by.ToolClass;

public class ActionClass {
    private java.lang.Class<?> privateActionType;
    private java.lang.String privateActionNum;
    private $Ku.by.JsonUtils.JsonArray privateParameterList;

    public ActionClass(java.lang.Class<?> f_ActionType, java.lang.String f_ActionNum, $Ku.by.JsonUtils.JsonArray f_ParamsList) {
        this.setActionType(f_ActionType);
		this.setActionNum(f_ActionNum);
		this.setParameterList(f_ParamsList);
    }


    public final java.lang.Class<?> getActionType() {
        return privateActionType;
    }

    private void setActionType(java.lang.Class<?> value) {
        privateActionType = value;
    }

    public final java.lang.String getActionNum() {
        return privateActionNum;
    }

    private void setActionNum(java.lang.String value) {
        privateActionNum = value;
    }

    public final $Ku.by.JsonUtils.JsonArray getParameterList() {
        return privateParameterList;
    }

    private void setParameterList($Ku.by.JsonUtils.JsonArray value) {
        privateParameterList = value;
    }
}
