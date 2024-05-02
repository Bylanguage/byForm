package $Ku.by.Object;

import java.util.TimerTask;
import java.net.*;
import java.util.Timer;
import $Ku.by.ToolClass.Handler;
public class ServerSession extends $Ku.by.Object.ByObject {
    public java.lang.String url;
    public java.lang.String ID;
    public java.lang.String ip;
    private java.lang.String version;
    public Object other;
    private $Ku.by.Object.Datetime loginDt;
    private java.lang.String cookie;
    public java.lang.String identityName;
    public java.lang.String methodName;
    private java.util.Timer timer;
    public $Ku.by.Object.Row user;
    public java.lang.String saasID = null;

    public ServerSession() {
    }

    public ServerSession(double time) {
        timer = new java.util.Timer();
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                try {
                    autoClear();
                } catch (java.lang.Exception e) {
                    throw new RuntimeException(e);
                }
            }
        }, (long) time, (long) time);
    }


    public java.lang.String getID() {
        return ID;
    }

    public void setID(java.lang.String id) {
        this.ID = id;
        $restartTimer();
    }

    public java.lang.String getIp() {
        return ip;
    }

    public void setIp(java.lang.String ip) {
        this.ip = ip;
        $restartTimer();
    }

    public java.lang.String getVersion() {
        return version;
    }

    public void setVersion(java.lang.String version) {
        this.version = version;
        $restartTimer();
    }

    public Object getOther() {
        return other;
    }

    public void setOther(Object other) {
        this.other = other;
        $restartTimer();
    }

    public $Ku.by.Object.Datetime getLoginDt() {
        return loginDt;
    }

    public void setLoginDt($Ku.by.Object.Datetime loginDt) {
        this.loginDt = loginDt;
        $restartTimer();
    }

    public java.lang.String getCookie() {
        return cookie;
    }

    public void setCookie(java.lang.String cookie) {
        this.cookie = cookie;
    }

    public java.lang.String getIdentityName() {
        return identityName;
    }

    public void setIdentityName(java.lang.String identityName) {
        this.identityName = identityName;
    }

    public java.lang.String getMethodName() {
        return methodName;
    }

    public void setMethodName(java.lang.String methodName) {
        this.methodName = methodName;
    }

    public $Ku.by.Object.Row getUser() {
        return this.user;
    }

    public void setUser($Ku.by.Object.Row user) {
        this.user = user;
    }

    private void $restartTimer() {
        if (timer != null) {
            timer.cancel();
            timer = new Timer();
            timer.schedule(new TimerTask() {
                @Override
                public void run() {
                    try {
                        autoClear();
                    } catch (java.lang.Exception e) {
                        throw new RuntimeException(e);
                    }
                }
            }, 1000*60*15);
        }
    }

    private void autoClear() {
        if ($Ku.by.Identity.Server.cacheSessionDic == null) {
            throw new RuntimeException("session缓存区为null");
        }
        if ($Ku.by.Identity.Server.cacheSessionDic.containsKey(this.getID())) {
            $Ku.by.Identity.Server.cacheSessionDic.remove(this.getID());
            timer.cancel();
            timer.purge();
        } else {
            timer.cancel();
            timer.purge();
        }
    }

    public static $Ku.by.Object.ServerSession getCurrentSession() {
        long tmpThreadID = Thread.currentThread().getId();
        if (!Handler.currentThreadIDSession.containsKey(tmpThreadID)) {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("获取CurrentSession失败，线程ID不存在");
        }

        $Ku.by.Object.ServerSession tmpCurrentSession = Handler.currentThreadIDSession.get(tmpThreadID);
        String tmpCurrentId = tmpCurrentSession.getID();

        if (!$Ku.by.Identity.Server.cacheSessionDic.containsKey(tmpCurrentId)) {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("获取CurrentSession失败, SessionID不存在");
        }

        return $Ku.by.Identity.Server.cacheSessionDic.get(tmpCurrentId);
    }

    public $Ku.by.Object.ServerCallInfo getCallInfo() {
        $Ku.by.Object.ServerCallInfo tmpValue = new $Ku.by.Object.ServerCallInfo();
        tmpValue.identityName = this.identityName;
        tmpValue.methodName = this.methodName;
        return tmpValue;
    }

    public static java.lang.String getMac(java.lang.String remoteIP) {
        InetAddress ipAddress;
        try {
            ipAddress = InetAddress.getByName(remoteIP);
        } catch (UnknownHostException e) {
            throw new RuntimeException(e.getMessage());
        }
        NetworkInterface networkInterface;
        try {
            networkInterface = NetworkInterface.getByInetAddress(ipAddress);
        } catch (SocketException e) {
            throw new RuntimeException(e.getMessage());
        }

        if (networkInterface != null) {
            byte[] mac;
            try {
                mac = networkInterface.getHardwareAddress();
            } catch (SocketException e) {
                throw new RuntimeException(e.getMessage());
            }

            if (mac != null) {
                StringBuilder macAddress = new StringBuilder();
                for (int i = 0; i < mac.length; i++) {
                    macAddress.append(String.format("%02X%s", mac[i], (i < mac.length - 1) ? "-" : ""));
                }
                return macAddress.toString();
            }
        }
        throw new RuntimeException("无法获取 MAC 地址");
    }

    public boolean equals(Object obj) {
        if(obj instanceof $Ku.by.Object.ServerSession){
            $Ku.by.Object.ServerSession tmpSession = ($Ku.by.Object.ServerSession) obj;
            if(this.ID != null){
                return this.ID.equals(tmpSession.ID);
            }
        }
        return super.equals(obj);
    }

    public int hashCode() {
        if(this.ID != null){
            return this.ID.hashCode();
        }
        return super.hashCode();
    }
}
