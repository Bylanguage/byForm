package $Ku.by.Object;

public class ByObject implements $Ku.by.ToolClass.IIdentity  {
    public $Ku.by.ToolClass.AbstractIdentityBase $Identity;

    public $Ku.by.ToolClass.AbstractIdentityBase $getIdentity() {
        return $Identity;
    }

    public void $setIdentity($Ku.by.ToolClass.AbstractIdentityBase value) {
        this.$Identity = value;
    }

    public static java.lang.Boolean byObjectEquals(Object A, Object B) {
        if($Ku.by.ToolClass.ToolFunction.isByPrimitive(A) && $Ku.by.ToolClass.ToolFunction.isByPrimitive(B)){
            return $Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(A, B);
        }
        return java.util.Objects.equals(A, B);
    }

    public java.lang.Boolean byObjectEquals(Object A) {
        return this.equals(A);
    }

    @Override
    public java.lang.String toString() {
        if ($Identity == null) {
            return "by.object.Object";
        } else {
            return "by.object.Object~" + this.$Identity.toString();
        }
    }
}
