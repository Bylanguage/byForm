package $Ku.byCommon.Identity;

public class relatedField extends $Ku.by.Identity.Identity {
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public relatedField() {
    }


    public static java.lang.String getFieldValue($Ku.by.Object.Row f_row, java.lang.String f_fieldNmae) {
        for ($Ku.by.Object.Cell item : f_row.cells()) {
            if (java.util.Objects.equals(item.field().name, f_fieldNmae)) {
                return java.util.Objects.equals(item.value, null) ? null : item.value.toString();
            }
        }
        return null;
    }

    public static java.lang.String getFieldSummery($Ku.by.Object.Row f_row, java.lang.String f_fieldNmae) {
        for ($Ku.by.Object.Cell item : f_row.cells()) {
            if (java.util.Objects.equals(item.field().name, f_fieldNmae)) {
                return java.util.Objects.equals(item.value, null) ? null : item.field().summary;
            }
        }
        return null;
    }

    public $Ku.byCommon.Identity.relatedField $getThis$Ku_byCommon_Identity_relatedField() {
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
