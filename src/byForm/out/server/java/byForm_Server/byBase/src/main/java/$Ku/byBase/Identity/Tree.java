package $Ku.byBase.Identity;

public class Tree extends $Ku.byBase.Identity.TableSafe implements $Ku.byInterface.Identity.IBy  {
    public $Ku.by.Identity.Reference iParent;
    public $Ku.by.Identity.Name iName;
    private $Ku.by.ToolClass.Sql.SelectTable Source;
    public $Ku.byBase.Action.Action._0 remove = $Ku.byBase.Action.Action::_0_default;
    public $Ku.byBase.Action.Action._1 modify = $Ku.byBase.Action.Action::_1_default;
    public $Ku.byBase.Action.Action._2 add = $Ku.byBase.Action.Action::_2_default;

    public Tree() {
    }


    public $Ku.by.Object.List<$Ku.by.Object.Row> popupLoad($Ku.by.Object.QueryData f_QueryData) {
        {
            return ($Ku.byBase.SqlExpression.LocalSql._1(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_QueryData})).rows;
        }
    }

    public java.lang.Boolean confirmUserIsLogin() {
        return true;
    }

    public $Ku.byBase.Identity.Tree $getThis$Ku_byBase_Identity_Tree() {
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
