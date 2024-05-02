package $Ku.by.ToolClass.Sql;

public abstract class AbstractTable {
    public java.util.ArrayList<$Ku.by.ToolClass.Sql.JoinTable> privateJoinTables;
    private boolean privateIsOuterTable;

    public abstract java.lang.String getAlias()  ;
    public abstract void setAlias(java.lang.String value)  ;
    public final java.util.ArrayList<$Ku.by.ToolClass.Sql.JoinTable> getJoinTables() {
        return privateJoinTables;
    }

    public final void setJoinTables(java.util.ArrayList<$Ku.by.ToolClass.Sql.JoinTable> value) {
        privateJoinTables = value;
    }

    public abstract java.lang.String getTableAccess()  ;
    public abstract $Ku.by.ToolClass.AbstractIdentityBase GetIdentity()  ;
    public abstract $Ku.by.ToolClass.IBaseDataSheet GetSource()  ;
    public final boolean getIsOuterTable() {
        return privateIsOuterTable;
    }

    public final void setIsOuterTable(boolean value) {
        privateIsOuterTable = value;
    }

    public abstract $Ku.by.ToolClass.Sql.AbstractTable Copy()  ;}
