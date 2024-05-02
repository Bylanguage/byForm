package $Ku.by.ToolClass.Sql;

public class ParamsPackage {
    private java.lang.String privatePath;
    public java.lang.String No;
    private java.lang.String privateMethodName;
    private java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> privateTableSourceList;
    private java.util.ArrayList<Object> privateParameterList;

    public ParamsPackage(java.lang.String f_Path, java.lang.String f_MethodName, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList, java.util.ArrayList<Object> f_ParamsList) {
        this.setPath(f_Path);
        this.setMethodName(f_MethodName);
        this.setTableSourceList(f_TableList);
        this.setParameterList(f_ParamsList);
    }


    public final java.lang.String getPath() {
        return privatePath;
    }

    public void setPath(java.lang.String value) {
        privatePath = value;
    }

    public final java.lang.String getMethodName() {
        return privateMethodName;
    }

    public void setMethodName(java.lang.String value) {
        privateMethodName = value;
    }

    public final java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> getTableSourceList() {
        return privateTableSourceList;
    }

    public void setTableSourceList(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> value) {
        privateTableSourceList = value;
    }

    public final java.util.ArrayList<Object> getParameterList() {
        return privateParameterList;
    }

    public void setParameterList(java.util.ArrayList<Object> value) {
        privateParameterList = value;
    }
}
