package $Ku.by.Object;

public class Exception extends java.lang.RuntimeException implements $Ku.by.ToolClass.IIdentity  {
    public final $Ku.by.Object.Exception innerException;
    public $Ku.by.ToolClass.AbstractIdentityBase $Identity;

    public Exception() {
        super();
        innerException = null;
    }

    public Exception(java.lang.String message) {
        super(message);
        innerException = null;
    }

    public Exception(java.lang.String message, $Ku.by.Object.Exception innerException) {
        super(message);
        this.innerException = innerException;
    }


    public java.lang.String message() {
        return this.getMessage();
    }

    public java.lang.String toString() {
        StringBuilder result = new StringBuilder();

        result.append("Exception: ").append(this.getClass().getName()).append("\n");
        result.append("Message: ").append(this.getMessage()).append("\n");

        if (innerException != null) {
            result.append("Inner Exception: ").append(innerException.getClass().getName()).append("\n");
            result.append("Inner Exception Message: ").append(innerException.getMessage());
        }

        return result.toString();
    }

    @Override
    public $Ku.by.ToolClass.AbstractIdentityBase $getIdentity() {
        return $Identity;
    }

    public void $setIdentity($Ku.by.ToolClass.AbstractIdentityBase value) {
        $Identity = value;
    }
}
