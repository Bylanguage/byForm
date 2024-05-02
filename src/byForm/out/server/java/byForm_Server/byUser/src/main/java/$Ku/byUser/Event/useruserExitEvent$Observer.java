package $Ku.byUser.Event;

public abstract class useruserExitEvent$Observer {
    public Object instance;
    public java.lang.String methodName;

    public useruserExitEvent$Observer() {
    }

    public useruserExitEvent$Observer(Object instance, java.lang.String methodName) {
        this.instance = instance;
        this.methodName = methodName;
    }


    public abstract void invoke($Ku.byUser.Orm.Orm0 f_userRow)  ;
    public boolean equals(Object obj) {
        if(obj instanceof useruserExitEvent$Observer)
            return instance.equals(((useruserExitEvent$Observer) obj).instance) && methodName.equals(((useruserExitEvent$Observer) obj).methodName);
        
        return false;
    }

    public int hashCode() {
        return instance.hashCode() + methodName.hashCode();
    }
}
