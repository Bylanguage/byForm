package $Ku.byCommon.Identity;

public class session extends $Ku.by.Identity.Identity {
    private $Ku.by.ToolClass.Sql.SelectTable Source;
    public static $Ku.byCommon.Event.sessionremoveEvent removeEvent = new $Ku.byCommon.Event.sessionremoveEvent();
    public static $Ku.byCommon.Event.sessionclearEvent clearEvent = new $Ku.byCommon.Event.sessionclearEvent();

    public session() {
    }


    public void remove($Ku.by.Object.ServerSession f_session) {
        if (!java.util.Objects.equals(removeEvent, null)) {
            removeEvent.invoke(f_session);
        }
    }

    public void clear($Ku.by.Object.ServerSession f_session) {
        if (!java.util.Objects.equals(clearEvent, null)) {
            clearEvent.invoke();
        }
    }

    public $Ku.byCommon.Identity.session $getThis$Ku_byCommon_Identity_session() {
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
