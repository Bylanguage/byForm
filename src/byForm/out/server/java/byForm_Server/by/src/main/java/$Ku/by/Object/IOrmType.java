package $Ku.by.Object;

public interface IOrmType{
    public java.lang.Class< ? > getType() ;
    public void setType(java.lang.Class< ? > type) ;
    public java.util.LinkedList<java.lang.Class< ? >> getIdentityDec() ;
    public void setIdentityDec(java.util.LinkedList<java.lang.Class< ? >> identityDec) ;
    public java.util.concurrent.ConcurrentHashMap<java.lang.String, java.lang.String> getAliasPropertiesMap() ;
    public void setAliasPropertiesMap(java.util.concurrent.ConcurrentHashMap<java.lang.String, java.lang.String> map) ;
}
