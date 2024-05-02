package $Ku.by.Object;

public class ServerCallInfo extends $Ku.by.Object.ByObject {
    public java.lang.String identityName;
    public java.lang.String methodName;

    public ServerCallInfo() {
    }


    public static $Ku.by.Object.ServerCallInfo getCallInfo($Ku.by.Object.ServerSession tmpLocalVariable0) {
        $Ku.by.Object.ServerCallInfo tmpValue = new $Ku.by.Object.ServerCallInfo();
        tmpValue.identityName = tmpLocalVariable0.identityName;
        tmpValue.methodName = tmpLocalVariable0.methodName;
        return tmpValue;
    }
}
