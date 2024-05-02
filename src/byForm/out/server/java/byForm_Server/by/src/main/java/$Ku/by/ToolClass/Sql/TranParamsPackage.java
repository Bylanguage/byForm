package $Ku.by.ToolClass.Sql;

public class TranParamsPackage {
    private java.lang.String KuName;
    private java.lang.String MethodName;
    public java.lang.String ExecuteKuName;
    private java.lang.String Path;
    private java.util.ArrayList<$Ku.by.ToolClass.Sql.ParamsPackage> Paramters;
    public java.util.ArrayList<Object> Values;

    public TranParamsPackage(java.lang.String f_KuName, java.lang.String f_Path, java.lang.String f_MethodName, java.util.ArrayList<$Ku.by.ToolClass.Sql.ParamsPackage> f_Parameters, java.util.ArrayList<Object> Values) {
        this.setKuName(f_KuName);
        this.setMethodName(f_MethodName);
        this.setPath(f_Path);
        this.setParamters(f_Parameters);
        this.Values = Values;
    }


    public java.lang.String getKuName() {
        return KuName;
    }

    public void setKuName(java.lang.String value) {
        KuName = value;
    }

    public java.lang.String getMethodName() {
        return MethodName;
    }

    private void setMethodName(java.lang.String value) {
        MethodName = value;
    }

    public java.lang.String getPath() {
        return Path;
    }

    private void setPath(java.lang.String value) {
        Path = value;
    }

    public java.util.ArrayList<$Ku.by.ToolClass.Sql.ParamsPackage> getParamters() {
        return Paramters;
    }

    private void setParamters(java.util.ArrayList<$Ku.by.ToolClass.Sql.ParamsPackage> value) {
        Paramters = value;
    }
}
