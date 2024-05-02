package $Ku.byBase.Identity;

public class detail extends $Ku.byBase.Identity.TableSafe {
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public detail() {
    }


    public $Ku.by.Object.List<$Ku.by.Object.Row> load($Ku.by.Object.Row f_row) {
        {
            return ($Ku.byBase.SqlExpression.LocalSql._30(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_row})).rows;
        }
    }

    public $Ku.byBase.Identity.detail $getThis$Ku_byBase_Identity_detail() {
        return this;
    }

    public void $setProps() {
    }

    public $Ku.by.ToolClass.Sql.SelectTable getSource() {
        return this.Source;
    }

    public void setSource($Ku.by.ToolClass.Sql.SelectTable value) {
        this.Source = value;
    }
}
