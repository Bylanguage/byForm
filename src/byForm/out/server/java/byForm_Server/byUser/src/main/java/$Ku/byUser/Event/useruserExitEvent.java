package $Ku.byUser.Event;

public class useruserExitEvent {
    private final java.util.ArrayList<$Ku.byUser.Event.useruserExitEvent$Observer> list = new java.util.ArrayList<>();

    public void add($Ku.byUser.Event.useruserExitEvent$Observer observer) {
        list.add(observer);
    }

    public void delete($Ku.byUser.Event.useruserExitEvent$Observer observer) {
        list.remove(observer);
    }

    public void invoke($Ku.byUser.Orm.Orm0 f_userRow) {
        for(useruserExitEvent$Observer observer : list)
            observer.invoke(f_userRow);
        
    }
}
