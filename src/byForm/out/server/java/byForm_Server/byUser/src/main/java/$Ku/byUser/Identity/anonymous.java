package $Ku.byUser.Identity;

public class anonymous extends $Ku.by.Identity.Table {
    public $Ku.by.Identity.Reference iUserID;
    public $Ku.by.Identity.Attribute iRegDt;
    public $Ku.by.Identity.Attribute iIP;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public anonymous() {
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
