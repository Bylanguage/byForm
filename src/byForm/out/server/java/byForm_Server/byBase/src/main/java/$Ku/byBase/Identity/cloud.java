package $Ku.byBase.Identity;

public class cloud extends $Ku.byBase.Identity.TableSafe {
    public $Ku.by.Identity.ID iName;
    public $Ku.by.Identity.Reference iUser;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public cloud() {
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
