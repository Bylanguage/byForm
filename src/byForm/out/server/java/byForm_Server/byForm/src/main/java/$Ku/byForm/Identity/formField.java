package $Ku.byForm.Identity;

public class formField extends $Ku.by.Identity.Table {
    public $Ku.by.Identity.Reference iFormID;
    public $Ku.by.Identity.Attribute iFieldNO;
    public $Ku.by.Identity.Attribute iFieldName;
    public $Ku.by.Identity.ID iSummary;
    public $Ku.by.Identity.Attribute iFieldType;
    public $Ku.by.Identity.Attribute iFieldCtrl;
    public $Ku.by.Identity.Attribute iSelectValue;
    public $Ku.by.Identity.Attribute iFieldMin;
    public $Ku.by.Identity.Attribute iFieldMax;
    public $Ku.by.Identity.Attribute iFieldReg;
    public $Ku.by.Identity.Attribute iFieldRegMsg;
    public $Ku.by.Identity.Attribute iFieldDefault;
    public $Ku.by.Identity.Attribute iNotNull;
    public $Ku.by.Identity.Attribute iOrder;
    public $Ku.by.Identity.Attribute iVDataValue;
    public $Ku.by.Identity.Attribute iUserID;
    public $Ku.byForm.Identity.formSys rFormSys;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public formField() {
    }


    public java.lang.Integer addUpdate($Ku.by.Object.Row f_formField, $Ku.by.Enum.Action action) {
        {
            java.lang.Integer tmpResultValue = 0;
            switch (action) {
                case insert:
                    tmpResultValue = $Ku.byForm.SqlExpression.LocalSql._8(new Object[]{f_formField});
                    break;
                case update:
                    tmpResultValue = $Ku.byForm.SqlExpression.LocalSql._9(new Object[]{f_formField});
                    break;
                case delete:
                    break;
            }
            return tmpResultValue;
        }
    }

    public void delByFormId(java.lang.String formID) {
        {
            $Ku.byForm.SqlExpression.LocalSql._11(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{formID});
        }
    }

    public $Ku.byForm.Identity.formField $getThis$Ku_byForm_Identity_formField() {
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
