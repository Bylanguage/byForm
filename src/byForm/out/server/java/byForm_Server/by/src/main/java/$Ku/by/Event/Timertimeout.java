package $Ku.by.Event;

import $Ku.by.Object.EventArgs;
public class Timertimeout {
    private final java.util.ArrayList<$Ku.by.Event.Timertimeout$Observer> list = new java.util.ArrayList<>();

    public void add($Ku.by.Event.Timertimeout$Observer observer) {
        list.add(observer);
    }

    public void delete($Ku.by.Event.Timertimeout$Observer observer) {
        list.remove(observer);
    }

    public void invoke(Object sender, $Ku.by.Object.TimeoutEventArgs args) {
        for(Timertimeout$Observer observer : list)
            observer.invoke(sender, args);
    }
}
