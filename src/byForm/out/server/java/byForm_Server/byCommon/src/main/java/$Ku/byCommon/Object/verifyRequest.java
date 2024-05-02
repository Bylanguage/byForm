package $Ku.byCommon.Object;

public class verifyRequest extends $Ku.by.Object.ByObject {
    public verifyRequest() {
    }


    public static java.lang.Boolean isOk(java.lang.String f_requestValue, java.lang.Integer f_max) {
        if (java.util.Objects.equals(f_requestValue, null) || java.util.Objects.equals(f_requestValue, "") || f_requestValue.indexOf("'") > -1 || f_requestValue.indexOf("\"") > -1 || f_requestValue.length() > f_max) {
            return false;
        }
        else {
            return true;
        }
    }

    public $Ku.byCommon.Object.verifyRequest $getThis$Ku_byCommon_Object_verifyRequest() {
        return this;
    }
}
