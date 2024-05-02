package $Ku.byFormNew.Identity;

public class ServerStartup extends $Ku.by.Identity.Role {
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public ServerStartup() {
    }


    public static void main$(java.lang.String[] args) {
        (($Ku.byUser.Identity.user) $Ku.by.ToolClass.Root.GetInstance().get("byUser").NewIdentityDic.get("New_user")).pIsGetServerUserRow = false;
        (($Ku.byUser.Identity.user) $Ku.by.ToolClass.Root.GetInstance().get("byUser").NewIdentityDic.get("New_user")).pConfigSMSCode = false;
        (($Ku.byUser.Identity.user) $Ku.by.ToolClass.Root.GetInstance().get("byUser").NewIdentityDic.get("New_user")).rLog.pLogMode = $Ku.byLog.Enum.logMode.file;
        (($Ku.byUser.Identity.userAdmin) $Ku.by.ToolClass.Root.GetInstance().get("byUser").NewIdentityDic.get("New_userAdmin")).initInsertAdmin();
    }

    public $Ku.byFormNew.Identity.ServerStartup $getThis$Ku_byFormNew_Identity_ServerStartup() {
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
