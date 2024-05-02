package $Ku.by.Event;

import $Ku.by.Object.EventArgs;
public abstract class Timertimeout$Observer {
    public Object instance;
    public java.lang.String methodName;

    public Timertimeout$Observer() {
    }

    public Timertimeout$Observer(Object instance, java.lang.String methodName) {
        this.instance = instance;
        this.methodName = methodName;
    }


    public abstract void invoke(Object sender, $Ku.by.Object.TimeoutEventArgs args)  ;
    public boolean equals(Object obj) {
        if(obj instanceof Timertimeout$Observer)
            return instance.equals(((Timertimeout$Observer) obj).instance) && methodName.equals(((Timertimeout$Observer) obj).methodName);

        return false;
    }

    public int hashCode() {
        return this.instance.hashCode() + methodName.hashCode();
    }
}
