package $Ku.byCommon.Event;

public abstract class sessionclearEvent$Observer {
    public Object instance;
    public java.lang.String methodName;

    public sessionclearEvent$Observer() {
    }

    public sessionclearEvent$Observer(Object instance, java.lang.String methodName) {
        this.instance = instance;
        this.methodName = methodName;
    }


    public abstract void invoke()  ;
    public boolean equals(Object obj) {
        if(obj instanceof sessionclearEvent$Observer)
            return instance.equals(((sessionclearEvent$Observer) obj).instance) && methodName.equals(((sessionclearEvent$Observer) obj).methodName);
        
        return false;
    }

    public int hashCode() {
        return instance.hashCode() + methodName.hashCode();
    }
}
