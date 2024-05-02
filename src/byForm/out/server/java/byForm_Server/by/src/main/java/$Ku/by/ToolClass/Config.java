package $Ku.by.ToolClass;

public class Config {
    public java.lang.String Name;
    public java.lang.String SheetName;
    public java.lang.String FlowName;

    public Config(java.lang.String f_ConfigName, java.lang.String f_SheetName, java.lang.String f_Flow) {
        this.Name = f_ConfigName;
        this.SheetName = f_SheetName;
        this.FlowName = f_Flow;
    }


    public java.lang.String getName() {
        return Name;
    }

    public java.lang.String getSheetName() {
        return SheetName;
    }

    public java.lang.String getFlowName() {
        return FlowName;
    }
}
