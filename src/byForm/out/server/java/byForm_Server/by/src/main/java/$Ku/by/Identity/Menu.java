package $Ku.by.Identity;

public class Menu extends $Ku.by.Identity.Table {
    public $Ku.by.Identity.Name iName;
    public $Ku.by.Identity.Attribute iIco;
    public $Ku.by.Identity.Reference iParent;
    public $Ku.by.Identity.Reference iKuName;
    public $Ku.by.Identity.Attribute iDialogManagerMode;
    public $Ku.by.Identity.Attribute iNewIdentityName;
    public $Ku.by.Identity.Attribute iDialogName;
    public $Ku.by.Identity.Attribute iManagerName;
    public $Ku.by.Identity.Field iSingleton;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public Menu() {
    }


    public $Ku.by.Identity.Menu $getThis$Ku_by_Identity_Menu() {
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
