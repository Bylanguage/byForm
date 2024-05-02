package $Ku.byBase.Identity;

public class popupTable extends $Ku.byBase.Identity.TableSafe {
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public popupTable() {
    }


    public $Ku.by.Object.List<$Ku.by.Object.Row> popupLoad($Ku.by.Object.QueryData f_QueryData) {
        {
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpGridRows = new $Ku.by.Object.List<$Ku.by.Object.Row>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class));
            tmpGridRows = ($Ku.byBase.SqlExpression.LocalSql._0(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_QueryData})).rows;
            return tmpGridRows;
        }
    }

    public $Ku.byBase.Identity.popupTable $getThis$Ku_byBase_Identity_popupTable() {
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
