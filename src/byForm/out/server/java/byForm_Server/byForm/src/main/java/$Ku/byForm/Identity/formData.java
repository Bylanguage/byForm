package $Ku.byForm.Identity;

public class formData extends $Ku.by.Identity.Table {
    public $Ku.by.Identity.Reference iFormID;
    public $Ku.by.Identity.Attribute iRowPK;
    public $Ku.by.Identity.Reference iFieldID;
    public $Ku.by.Identity.Reference iFieldName;
    public $Ku.by.Identity.Attribute iCellValue;
    public $Ku.by.Identity.Attribute iUserID;
    public $Ku.byForm.Identity.formSys rFormSys;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public formData() {
    }


    public $Ku.byForm.Identity.formData getformDataIdentity($Ku.by.Object.Row f_formField) {
        return this.getformDataIdentity(((java.lang.Integer) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_formField, "iVDataValue").value));
    }

    public $Ku.byForm.Identity.formData getformDataIdentity(java.lang.Integer f_Value) {
        if (f_Value <= 64) {
            return this.rFormSys.rVData64;
        }
        if (f_Value <= 256) {
            return this.rFormSys.rVData256;
        }
        if (f_Value <= 1024) {
            return this.rFormSys.rVData1024;
        }
        else {
            if (f_Value >= 4000) {
                return this.rFormSys.rVData4000;
            }
            else {
                return this.rFormSys.rVData4000;
            }
        }
    }

    public $Ku.byForm.Identity.formData $getThis$Ku_byForm_Identity_formData() {
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
