package $Ku.by.Identity;

public class Reference extends $Ku.by.Identity.Field {
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public Reference() {
    }


    public $Ku.by.Identity.Table host() {
        $Ku.by.Object.Field thisField = ($Ku.by.Object.Field) this.getTo();
        if (java.util.Objects.equals(thisField, null)) {
            return ($Ku.by.Identity.Table) $Ku.by.ToolClass.ToolFunction.GetByObjectIdentity(null);
        }
        $Ku.by.Object.Table refTable = $Ku.by.ToolClass.$ClassMessageUtil.as(thisField.getRefTable(), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Table.class));
        return ($Ku.by.Identity.Table) $Ku.by.ToolClass.ToolFunction.GetByObjectIdentity(java.util.Objects.equals(refTable, null) ? null : refTable);
    }

    public java.lang.Boolean isReference($Ku.by.Identity.Table f_table) {
        $Ku.by.Object.Field thisField = ($Ku.by.Object.Field) this.getTo();
        $Ku.by.Object.Table targetTable = ($Ku.by.Object.Table) f_table.getTo();
        if (java.util.Objects.equals(thisField, null) || java.util.Objects.equals(targetTable, null)) {
            return false;
        }
        $Ku.by.Object.Field thisFieldRefField = thisField.refField();
        for ($Ku.by.Object.Field field : targetTable.fields) {
            if (java.util.Objects.equals(thisFieldRefField, field) || java.util.Objects.equals(field.refField(), thisField)) {
                return true;
            }
        }
        return false;
    }

    public $Ku.by.Identity.Reference $getThis$Ku_by_Identity_Reference() {
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
