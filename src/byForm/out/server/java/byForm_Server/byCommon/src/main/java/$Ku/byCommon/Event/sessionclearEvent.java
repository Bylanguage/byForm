package $Ku.byCommon.Event;

public class sessionclearEvent {
    private final java.util.ArrayList<$Ku.byCommon.Event.sessionclearEvent$Observer> list = new java.util.ArrayList<>();

    public void add($Ku.byCommon.Event.sessionclearEvent$Observer observer) {
        list.add(observer);
    }

    public void delete($Ku.byCommon.Event.sessionclearEvent$Observer observer) {
        list.remove(observer);
    }

    public void invoke() {
        for(sessionclearEvent$Observer observer : list)
            observer.invoke();
        
    }
}
