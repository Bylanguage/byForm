package $Ku.byCommon.Event;

public abstract class sessionremoveEvent$Observer {
    public Object instance;
    public java.lang.String methodName;

    public sessionremoveEvent$Observer() {
    }

    public sessionremoveEvent$Observer(Object instance, java.lang.String methodName) {
        this.instance = instance;
        this.methodName = methodName;
    }


    public abstract void invoke($Ku.by.Object.ServerSession f_session)  ;
    public boolean equals(Object obj) {
        if(obj instanceof sessionremoveEvent$Observer)
            return instance.equals(((sessionremoveEvent$Observer) obj).instance) && methodName.equals(((sessionremoveEvent$Observer) obj).methodName);
        
        return false;
    }

    public int hashCode() {
        return instance.hashCode() + methodName.hashCode();
    }
}
