package $Ku.by.ToolClass;

public class BaseKu {
    public java.lang.String Name;
    public java.lang.String DatabaseName;
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IBaseDataSheet> DataSheetDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, java.util.ArrayList<$Ku.by.ToolClass.SheetRelation>> RelationDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, java.util.ArrayList<$Ku.by.ToolClass.Config>> ConfigDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.AbstractIdentityBase> NewIdentityDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<$Ku.by.ToolClass.AbstractIdentityBase, java.lang.String> NewIdentityKeyIsId = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<$Ku.by.ToolClass.AbstractIdentityBase, $Ku.by.ToolClass.IBaseDataSheet> DataSheetIdentityDic = new java.util.LinkedHashMap<>();
    public $Ku.by.ToolClass.ISqlLocation sqlLocation;

    public $Ku.by.ToolClass.IBaseDataSheet get(java.lang.String f_SheetName) {
        if (this.DataSheetDic.get(f_SheetName) == null){
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.CanNotFindSheetInKu, this.Name, f_SheetName));
        }
        return this.DataSheetDic.get(f_SheetName);
    }

    public boolean ContainsKey(java.lang.String f_Key) {
        return this.DataSheetDic.get(f_Key)!= null;
    }

    public java.lang.String getDatabaseName() {
        if(this.DatabaseName != null && !this.DatabaseName.equals("")){
            return this.DatabaseName;
        }
        else {
            return this.Name;
        }
    }

    public void setDatabaseName(java.lang.String value) {
        this.DatabaseName = value;
    }
}
