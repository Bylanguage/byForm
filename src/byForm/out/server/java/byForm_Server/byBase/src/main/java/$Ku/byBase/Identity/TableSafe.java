package $Ku.byBase.Identity;

public class TableSafe extends $Ku.by.Identity.Table {
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public TableSafe() {
    }


    public java.lang.Boolean confirmUserIsLogin() {
        return true;
    }

    public $Ku.byBase.Identity.TableSafe $getThis$Ku_byBase_Identity_TableSafe() {
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
