package $Ku.by.Object;

public abstract class AbstractOrm extends $Ku.by.Object.ByObject {
    public AbstractOrm() {
    }


    @Override
    public java.lang.String toString() {
        return null;
    }

    public abstract java.lang.Boolean byObjectEquals($Ku.by.Object.AbstractOrm orm)  ;
    public abstract AbstractOrm clone()  ;
    public abstract $Ku.by.Object.ReadOnlyList<$Ku.by.Object.Cell> cells()  ;
    public abstract java.util.ArrayList<$Ku.by.ToolClass.OrmField> getOrmFields()  ;
    public abstract java.util.HashMap<java.lang.String, java.util.ArrayList<java.lang.Integer>> getTablesMap()  ;}
