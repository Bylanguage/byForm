package $Ku.byUser.Event;

public abstract class userICOuserICOChangeEvent$Observer {
    public Object instance;
    public java.lang.String methodName;

    public userICOuserICOChangeEvent$Observer() {
    }

    public userICOuserICOChangeEvent$Observer(Object instance, java.lang.String methodName) {
        this.instance = instance;
        this.methodName = methodName;
    }


    public abstract void invoke($Ku.byUser.Orm.Orm0 f_userRow)  ;
    public boolean equals(Object obj) {
        if(obj instanceof userICOuserICOChangeEvent$Observer)
            return instance.equals(((userICOuserICOChangeEvent$Observer) obj).instance) && methodName.equals(((userICOuserICOChangeEvent$Observer) obj).methodName);
        
        return false;
    }

    public int hashCode() {
        return instance.hashCode() + methodName.hashCode();
    }
}
