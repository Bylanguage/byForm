package $Ku.by.ToolClass.Sql;

public class JoinTable {
    private $Ku.by.ToolClass.Sql.AbstractTable privateJoinTable;
    public java.lang.StringBuilder privateCondition;
    private java.lang.String privateJoinMode;

    public JoinTable($Ku.by.ToolClass.Sql.AbstractTable f_JoinTable) {
        this.setCondition(new StringBuilder());
        this.setJoinTable(f_JoinTable);
    }


    public final $Ku.by.ToolClass.Sql.AbstractTable getJoinTable() {
        return privateJoinTable;
    }

    public final void setJoinTable($Ku.by.ToolClass.Sql.AbstractTable value) {
        privateJoinTable = value;
    }

    public final java.lang.StringBuilder getCondition() {
        return privateCondition;
    }

    public final void setCondition(java.lang.StringBuilder value) {
        privateCondition = value;
    }

    public final java.lang.String getJoinMode() {
        return privateJoinMode;
    }

    public final void setJoinMode(java.lang.String value) {
        privateJoinMode = value;
    }
}
