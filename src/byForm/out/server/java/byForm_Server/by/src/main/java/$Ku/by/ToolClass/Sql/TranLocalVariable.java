package $Ku.by.ToolClass.Sql;

public class TranLocalVariable {
    private java.lang.String LocalName;

    public TranLocalVariable(java.lang.String f_Name) {
        this.setLocalName(f_Name);
    }


    public java.lang.String getLocalName() {
        return LocalName;
    }

    private void setLocalName(java.lang.String value) {
        LocalName = value;
    }

    public java.lang.String toString() {
        return this.getLocalName();
    }
}
