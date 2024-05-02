package $Ku.byUser.Event;

public abstract class userloginSuccessEvent$Observer {
    public Object instance;
    public java.lang.String methodName;

    public userloginSuccessEvent$Observer() {
    }

    public userloginSuccessEvent$Observer(Object instance, java.lang.String methodName) {
        this.instance = instance;
        this.methodName = methodName;
    }


    public abstract void invoke($Ku.byUser.Orm.Orm0 f_userRow)  ;
    public boolean equals(Object obj) {
        if(obj instanceof userloginSuccessEvent$Observer)
            return instance.equals(((userloginSuccessEvent$Observer) obj).instance) && methodName.equals(((userloginSuccessEvent$Observer) obj).methodName);
        
        return false;
    }

    public int hashCode() {
        return instance.hashCode() + methodName.hashCode();
    }
}
