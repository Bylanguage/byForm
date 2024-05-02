package $Ku.byCommon.Event;

public class sessionremoveEvent {
    private final java.util.ArrayList<$Ku.byCommon.Event.sessionremoveEvent$Observer> list = new java.util.ArrayList<>();

    public void add($Ku.byCommon.Event.sessionremoveEvent$Observer observer) {
        list.add(observer);
    }

    public void delete($Ku.byCommon.Event.sessionremoveEvent$Observer observer) {
        list.remove(observer);
    }

    public void invoke($Ku.by.Object.ServerSession f_session) {
        for(sessionremoveEvent$Observer observer : list)
            observer.invoke(f_session);
        
    }
}
