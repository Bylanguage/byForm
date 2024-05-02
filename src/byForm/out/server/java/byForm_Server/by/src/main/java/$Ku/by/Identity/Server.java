package $Ku.by.Identity;

public class Server extends $Ku.by.Identity.Identity {
    public static $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.ServerSession> cacheSessionDic;
    public static $Ku.by.Identity.IServerDoor mIDoor;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    static {
        cacheSessionDic = new $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.ServerSession>($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.ServerSession.class));
    }


    public Server() {
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
