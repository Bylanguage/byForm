package $Ku.byForm.SqlExpression;

public class Exec$1 extends $Ku.by.ToolClass.Sql.AbsExec {
    private java.util.HashMap<java.lang.String, $Ku.by.ToolClass.Sql.IExecResult> selectDic = new java.util.HashMap<>();

    public Exec$1($Ku.by.ToolClass.Sql.IExecResult select1, $Ku.by.ToolClass.Sql.IExecResult select2) {
        this.selectDic.put("select1", select1);
        this.selectDic.put("select2", select2);
    }


    public java.util.HashMap<java.lang.String, $Ku.by.ToolClass.Sql.IExecResult> getSelectDic() {
        return selectDic;
    }

    public <T> T getExecItem(java.lang.String name) {
        return (T)this.selectDic.get(name);
    }
}
