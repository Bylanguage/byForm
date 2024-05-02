package $Ku.byBase.Identity;

public class catalog extends $Ku.byBase.Identity.dic {
    public $Ku.by.Identity.Reference iBillID;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public catalog() {
    }


    public $Ku.by.Object.Row getRow($Ku.by.Identity.Table f_table) {
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpList = this.load(($Ku.by.Object.List<$Ku.by.Object.Row>) null, ($Ku.by.Object.QueryData) null);
        for ($Ku.by.Object.Row item : tmpList) {
            $Ku.by.Object.Row tmpCatelogRow = ($Ku.by.Object.Row) item;
            if (java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpCatelogRow, "iName").value), (($Ku.by.Object.Table) f_table.getTo()).name)) {
                return tmpCatelogRow;
            }
        }
        return null;
    }

    public $Ku.byBase.Identity.catalog $getThis$Ku_byBase_Identity_catalog() {
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
