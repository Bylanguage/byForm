package $Ku.byUser.Event;

public class userloginSuccessEvent {
    private final java.util.ArrayList<$Ku.byUser.Event.userloginSuccessEvent$Observer> list = new java.util.ArrayList<>();

    public void add($Ku.byUser.Event.userloginSuccessEvent$Observer observer) {
        list.add(observer);
    }

    public void delete($Ku.byUser.Event.userloginSuccessEvent$Observer observer) {
        list.remove(observer);
    }

    public void invoke($Ku.byUser.Orm.Orm0 f_userRow) {
        for(userloginSuccessEvent$Observer observer : list)
            observer.invoke(f_userRow);
        
    }
}
