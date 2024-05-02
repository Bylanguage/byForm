package $Ku.byBase.Orm;

public class OrmType0 implements $Ku.by.Object.IOrmType  {
    public java.lang.Class< ? > type;
    public java.util.LinkedList<java.lang.Class< ? >> identityDec;
    public java.util.concurrent.ConcurrentHashMap<java.lang.String, java.lang.String> aliasPropertiesMap;

    public OrmType0() {
        this.identityDec = new java.util.LinkedList<>();
        this.aliasPropertiesMap = new java.util.concurrent.ConcurrentHashMap<>();
        identityDec.add($Ku.byBase.Identity.bridge.class);
        identityDec.add($Ku.by.Identity.Table.class);
        type = $Ku.byBase.Orm.Orm0.class;
    }


    public java.lang.Class< ? > getType() {
        return this.type;
    }

    public void setType(java.lang.Class< ? > type) {
        this.type = type;
    }

    public java.util.LinkedList<java.lang.Class< ? >> getIdentityDec() {
        return this.identityDec;
    }

    public void setIdentityDec(java.util.LinkedList<java.lang.Class< ? >> identityDec) {
        this.identityDec = identityDec;
    }

    public java.util.concurrent.ConcurrentHashMap<java.lang.String, java.lang.String> getAliasPropertiesMap() {
        return this.aliasPropertiesMap;
    }

    public void setAliasPropertiesMap(java.util.concurrent.ConcurrentHashMap<java.lang.String, java.lang.String> map) {
        this.aliasPropertiesMap = map;
    }
}
