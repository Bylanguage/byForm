package $Ku.by.ToolClass;

public class Component {
    public java.lang.String ComponentName;
    public java.lang.String SheetName;

    public Component(java.lang.String f_ComponentName, java.lang.String f_SheetName) {
        this.ComponentName = f_ComponentName;
        this.SheetName = f_SheetName;
    }


    public java.lang.String getComponentName() {
        return ComponentName;
    }

    public java.lang.String getSheetName() {
        return SheetName;
    }
}
