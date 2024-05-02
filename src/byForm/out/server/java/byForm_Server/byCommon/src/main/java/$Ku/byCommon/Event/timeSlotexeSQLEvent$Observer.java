package $Ku.byCommon.Event;

public abstract class timeSlotexeSQLEvent$Observer {
    public Object instance;
    public java.lang.String methodName;

    public timeSlotexeSQLEvent$Observer() {
    }

    public timeSlotexeSQLEvent$Observer(Object instance, java.lang.String methodName) {
        this.instance = instance;
        this.methodName = methodName;
    }


    public abstract void invoke()  ;
    public boolean equals(Object obj) {
        if(obj instanceof timeSlotexeSQLEvent$Observer)
            return instance.equals(((timeSlotexeSQLEvent$Observer) obj).instance) && methodName.equals(((timeSlotexeSQLEvent$Observer) obj).methodName);
        
        return false;
    }

    public int hashCode() {
        return instance.hashCode() + methodName.hashCode();
    }
}
