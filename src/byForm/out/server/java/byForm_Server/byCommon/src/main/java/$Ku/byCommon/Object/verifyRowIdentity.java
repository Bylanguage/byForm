package $Ku.byCommon.Object;

public class verifyRowIdentity extends $Ku.by.Object.ByObject {
    public verifyRowIdentity() {
    }


    public static java.lang.Boolean isExists($Ku.by.Object.List<$Ku.by.Object.Row> f_verifyList, $Ku.by.Identity.Table[] f_tableIdentity) {
        for ($Ku.by.Object.Row item : f_verifyList) {
            java.lang.Boolean tmpVia = false;
            for ($Ku.by.Identity.Table ID : f_tableIdentity) {
                if (java.util.Objects.equals(ID, (($Ku.by.Identity.Table) $Ku.by.ToolClass.ToolFunction.GetByObjectIdentity(item)))) {
                    tmpVia = true;
                }
            }
            if (!tmpVia) {
                return false;
            }
        }
        return true;
    }

    public $Ku.byCommon.Object.verifyRowIdentity $getThis$Ku_byCommon_Object_verifyRowIdentity() {
        return this;
    }
}
