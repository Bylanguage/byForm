package $Ku.byUser.Identity;

public class userUpload extends $Ku.by.Identity.Table {
    public $Ku.by.Identity.ID iFileName;
    public $Ku.by.Identity.Attribute iFileSize;
    public $Ku.by.Identity.Attribute iSummery;
    public $Ku.by.Identity.Reference iUserID;
    public $Ku.by.Identity.Attribute iDT;
    public $Ku.byUser.Identity.user rUser;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public userUpload() {
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
