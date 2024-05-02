package $Ku.byCommon.Event;

public class timeSlotexeSQLEvent {
    private final java.util.ArrayList<$Ku.byCommon.Event.timeSlotexeSQLEvent$Observer> list = new java.util.ArrayList<>();

    public void add($Ku.byCommon.Event.timeSlotexeSQLEvent$Observer observer) {
        list.add(observer);
    }

    public void delete($Ku.byCommon.Event.timeSlotexeSQLEvent$Observer observer) {
        list.remove(observer);
    }

    public void invoke() {
        for(timeSlotexeSQLEvent$Observer observer : list)
            observer.invoke();
        
    }
}
