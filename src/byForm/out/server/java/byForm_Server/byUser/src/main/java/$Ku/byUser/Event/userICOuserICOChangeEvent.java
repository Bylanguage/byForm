package $Ku.byUser.Event;

public class userICOuserICOChangeEvent {
    private final java.util.ArrayList<$Ku.byUser.Event.userICOuserICOChangeEvent$Observer> list = new java.util.ArrayList<>();

    public void add($Ku.byUser.Event.userICOuserICOChangeEvent$Observer observer) {
        list.add(observer);
    }

    public void delete($Ku.byUser.Event.userICOuserICOChangeEvent$Observer observer) {
        list.remove(observer);
    }

    public void invoke($Ku.byUser.Orm.Orm0 f_userRow) {
        for(userICOuserICOChangeEvent$Observer observer : list)
            observer.invoke(f_userRow);
        
    }
}
