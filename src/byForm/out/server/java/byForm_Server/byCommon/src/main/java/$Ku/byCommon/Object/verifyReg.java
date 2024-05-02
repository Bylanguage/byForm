package $Ku.byCommon.Object;

public class verifyReg extends $Ku.by.Object.ByObject {
    public verifyReg() {
    }


    public static java.lang.String getVeriable(java.lang.Integer f_min, java.lang.Integer f_max) {
        if (f_min >= 1) {
            f_min = f_min - 1;
        }
        return "^[a-zA-Z_]{1}[a-zA-Z0-9_]{" + $Ku.by.ToolClass.ToolFunction.toString(f_min) + "," + $Ku.by.ToolClass.ToolFunction.toString(f_max) + "}$";
    }

    public static java.lang.String getText(java.lang.Integer f_min, java.lang.Integer f_max) {
        return "^[a-zA-Z0-9_\\xff-\\uffff,.; \\r\\n\\t   ]{" + $Ku.by.ToolClass.ToolFunction.toString(f_min) + "," + $Ku.by.ToolClass.ToolFunction.toString(f_max) + "}$";
    }

    public static java.lang.String getStrictText(java.lang.Integer f_min, java.lang.Integer f_max) {
        if (f_min >= 1) {
            f_min = f_min - 1;
        }
        return "^[a-zA-Z\\xff-\\uffff{1}][a-zA-Z0-9_\\xff-\\uffff]{" + $Ku.by.ToolClass.ToolFunction.toString(f_min) + "," + $Ku.by.ToolClass.ToolFunction.toString(f_max) + "}$";
    }

    public static java.lang.String getInteger(java.lang.Integer f_min, java.lang.Integer f_max) {
        return "^[0-9]{" + $Ku.by.ToolClass.ToolFunction.toString(f_min) + "," + $Ku.by.ToolClass.ToolFunction.toString(f_max) + "}$";
    }

    public static java.lang.String verfyLength(java.lang.Integer f_min, java.lang.Integer f_max) {
        return "^.{" + $Ku.by.ToolClass.ToolFunction.toString(f_min) + "," + $Ku.by.ToolClass.ToolFunction.toString(f_max) + "}$";
    }

    public $Ku.byCommon.Object.verifyReg $getThis$Ku_byCommon_Object_verifyReg() {
        return this;
    }
}
