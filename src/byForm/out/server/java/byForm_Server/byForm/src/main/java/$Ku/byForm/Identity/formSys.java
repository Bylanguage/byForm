package $Ku.byForm.Identity;

public class formSys extends $Ku.by.Identity.Sys {
    public $Ku.byForm.Identity.form rForm;
    public $Ku.byForm.Identity.formField rFormField;
    public $Ku.byForm.Identity.formData rFormData;
    public $Ku.byForm.Identity.fieldTemplate rFieldTemplate;
    public $Ku.byForm.Identity.formTemplate rFormTemplate;
    public $Ku.byForm.Identity.formData rVData64;
    public $Ku.byForm.Identity.formData rVData256;
    public $Ku.byForm.Identity.formData rVData1024;
    public $Ku.byForm.Identity.formData rVData4000;
    public $Ku.byUser.Identity.user rUser;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public formSys() {
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
