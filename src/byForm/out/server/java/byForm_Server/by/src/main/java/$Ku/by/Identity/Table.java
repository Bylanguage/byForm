package $Ku.by.Identity;

public class Table extends $Ku.by.Identity.Identity implements $Ku.by.ToolClass.ITableSource  {
    public $Ku.by.Identity.ID iID;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public Table() {
    }


    public java.lang.Boolean isReference($Ku.by.Identity.Table f_table) {
        $Ku.by.Object.Table thisTable = ($Ku.by.Object.Table) this.getTo();
        $Ku.by.Object.Table targetTable = ($Ku.by.Object.Table) f_table.getTo();
        if (java.util.Objects.equals(thisTable, null) || java.util.Objects.equals(targetTable, null)) {
            return false;
        }
        for ($Ku.by.Object.Field field : thisTable.fields) {
            if (!java.util.Objects.equals(field.getRefTable(), null) && java.util.Objects.equals(field.getRefTable(), targetTable)) {
                return true;
            }
        }
        for ($Ku.by.Object.Field field : targetTable.fields) {
            if (!java.util.Objects.equals(field.getRefTable(), null) && java.util.Objects.equals(field.getRefTable(), thisTable)) {
                return true;
            }
        }
        return false;
    }

    public $Ku.by.Identity.Table $getThis$Ku_by_Identity_Table() {
        return this;
    }

    public void $setProps() {
    }

    public $Ku.by.ToolClass.Sql.SelectTable getSource() {
        return this.Source;
    }

    public void setSource($Ku.by.ToolClass.Sql.SelectTable value) {
        this.Source = value;
    }
}
