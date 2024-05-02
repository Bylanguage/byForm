package $Ku.byForm.Identity;

public class formTemplate extends $Ku.by.Identity.Table {
    public $Ku.by.Identity.Name iName;
    public $Ku.by.Identity.Reference iFormID;
    public $Ku.by.Identity.Attribute iUserID;
    public $Ku.byForm.Identity.formSys rFormSys;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public formTemplate() {
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
