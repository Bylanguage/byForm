package $Ku.byForm.Identity;

public class fieldTemplate extends $Ku.byBase.Identity.dic {
    public $Ku.by.Object.List<$Ku.by.Object.Row> pList;
    public $Ku.by.Identity.Attribute iCtrType;
    public $Ku.by.Identity.Attribute iIco;
    public $Ku.by.Identity.Attribute iMin;
    public $Ku.by.Identity.Attribute iMax;
    public $Ku.by.Identity.Attribute iDefault;
    public $Ku.by.Identity.Attribute iReg;
    public $Ku.by.Identity.Attribute iRegMsg;
    public $Ku.by.Identity.Attribute iCreateDt;
    public $Ku.byForm.Identity.formSys rFormSys;
    public $Ku.byUser.Identity.user rUser;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public fieldTemplate() {
    }


    public $Ku.by.Object.List<$Ku.by.Object.Row> getList() {
        {
            if (java.util.Objects.equals(this.pList, null)) {
                this.pList = ($Ku.byForm.SqlExpression.LocalSql._37(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{})).rows;
            }
            return this.pList;
        }
    }

    public $Ku.by.Object.Row getFieldTemplate(java.lang.String id) {
        $Ku.by.Object.List<$Ku.by.Object.Row> templateList = this.getList();
        for ($Ku.by.Object.Row templateRow : templateList) {
            if (java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(templateRow, "iID").value), id)) {
                return templateRow;
            }
        }
        throw new $Ku.by.Object.Exception($Ku.byForm.Object.TextHelper.invalidFieldTemplateID);
    }

    public $Ku.byForm.Identity.fieldTemplate $getThis$Ku_byForm_Identity_fieldTemplate() {
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
