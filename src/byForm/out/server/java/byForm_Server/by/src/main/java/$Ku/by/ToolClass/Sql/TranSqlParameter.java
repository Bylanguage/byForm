package $Ku.by.ToolClass.Sql;

public class TranSqlParameter {
    private java.util.ArrayList<java.lang.String> SourceList;
    private java.util.ArrayList<Object> ParameterList;

    public TranSqlParameter(java.util.ArrayList<java.lang.String> f_Source, java.util.ArrayList<Object> f_Parameter) {
        this.setSourceList(f_Source);
        this.setParameterList(f_Parameter);
    }


    public java.util.ArrayList<java.lang.String> getSourceList() {
        return SourceList;
    }

    private void setSourceList(java.util.ArrayList<java.lang.String> value) {
        SourceList = value;
    }

    public java.util.ArrayList<Object> getParameterList() {
        return ParameterList;
    }

    private void setParameterList(java.util.ArrayList<Object> value) {
        ParameterList = value;
    }
}
