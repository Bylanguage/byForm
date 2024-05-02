package $Ku.by.Object;

public class Table extends $Ku.by.Object.ByObject {
    public $Ku.by.Object.ReadOnlyList<$Ku.by.Object.Field> fields;
    public java.lang.String kuName;
    public java.lang.String name;
    public $Ku.by.Object.ReadOnlyList<$Ku.by.Object.Row> rows;
    public java.lang.String summary;
    public $Ku.by.Enum.TableType tableType = $Ku.by.Enum.TableType.values()[0];
    public $Ku.by.ToolClass.IBaseDataSheet DataSheet;
    public java.lang.String mByType;
    public int max;
    public java.util.ArrayList<$Ku.by.Object.Row> $rows;
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.Object.Field> $fields;

    public Table($Ku.by.Object.ReadOnlyList<$Ku.by.Object.Field> fields, java.lang.String kuName, java.lang.String name, $Ku.by.Object.ReadOnlyList<$Ku.by.Object.Row> rows, java.lang.String summary, $Ku.by.Enum.TableType tableType) {
        this.fields = fields;
        this.kuName = kuName;
        this.name = name;
        this.rows = rows;
        this.summary = summary;
        this.tableType = tableType;
    }

    public Table() {
         
    }


    public $Ku.by.Object.Field getField(java.lang.String fieldName) {
        for ($Ku.by.Object.Field field:this.fields){
            if (java.util.Objects.equals(field.name, fieldName)){
                return field;
            }
        }
        return null;
    }

    public $Ku.by.ToolClass.AbstractIdentityBase getIdentity() {
        if (this.DataSheet == null){
            return null;
        }
        else {
            return this.DataSheet.getIdentity();
        }
    }

    public void setIdentity($Ku.by.ToolClass.AbstractIdentityBase Identity) {
        this.DataSheet.setIdentity(Identity);
    }

    public static int autoNO($Ku.by.Object.Table tmpLocalVariable0, int tmpLocalVariable1) {
        if (tmpLocalVariable1 < 1)
        {
            throw new RuntimeException("错误的操作数 " + tmpLocalVariable1);
        }
        int ReturnValue = tmpLocalVariable0.max + 1;
        tmpLocalVariable0.max += tmpLocalVariable1;
        return ReturnValue;
    }

    public boolean isReference($Ku.by.Object.Table tmpLocalVariable0) {
        throw new RuntimeException("服务器端不支持的方法isReference");
    }

    public void $RefreshMax() {
        max = $Ku.by.ToolClass.ToolFunction.SetMax(DataSheet);
    }
}
