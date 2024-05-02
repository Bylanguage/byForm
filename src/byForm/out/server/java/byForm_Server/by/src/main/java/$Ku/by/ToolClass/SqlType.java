package $Ku.by.ToolClass;

public class SqlType implements $Ku.by.ToolClass.ITableSource, $Ku.by.ToolClass.Sql.IExecResult  {
    public $Ku.by.Object.List<$Ku.by.Object.Row> rows;
    public $Ku.by.ToolClass.Sql.SelectTable Source;

    public SqlType($Ku.by.Object.List<$Ku.by.Object.Row> f_Rows, $Ku.by.ToolClass.Sql.SelectTable f_Source) {
        this.rows = f_Rows;
        this.Source = f_Source;
    }


    public $Ku.by.Object.List<$Ku.by.Object.Row> getRows() {
        return rows;
    }

    public void setRows($Ku.by.Object.List<$Ku.by.Object.Row> rows) {
        this.rows = rows;
    }

    public $Ku.by.ToolClass.Sql.SelectTable getSource() {
        return Source;
    }

    public void setSource($Ku.by.ToolClass.Sql.SelectTable Source) {
        this.Source = Source;
    }
}
