package $Ku.byBase.Identity;

public class bridge extends $Ku.byBase.Identity.TableSafe implements $Ku.byInterface.Identity.IBy  {
    public $Ku.by.Identity.Reference iLeft;
    public $Ku.by.Identity.Reference iRight;
    private $Ku.by.ToolClass.Sql.SelectTable Source;
    public $Ku.byBase.Action.Action._3 add = $Ku.byBase.Action.Action::_3_default;
    public $Ku.byBase.Action.Action._4 change = $Ku.byBase.Action.Action::_4_default;
    public $Ku.byBase.Action.Action._5 delete = $Ku.byBase.Action.Action::_5_default;

    public bridge() {
    }


    public $Ku.by.Object.List<$Ku.by.Object.Row> load($Ku.by.Object.List<$Ku.by.Object.Row> f_selectRowList, $Ku.by.Enum.MouseButton f_leftRight) {
        {
            if (java.util.Objects.equals(f_leftRight, $Ku.by.Enum.MouseButton.left)) {
                return ($Ku.byBase.SqlExpression.LocalSql._12(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_selectRowList})).rows;
            }
            else {
                return ($Ku.byBase.SqlExpression.LocalSql._13(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_selectRowList})).rows;
            }
        }
    }

    public void addDeleteUpdate($Ku.by.Object.List<$Ku.by.Object.Row> f_addList, $Ku.by.Object.List<$Ku.by.Object.Row> f_deleteList) {
        {
            try {
                java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_addList)));
                $tmpIdentityList.add(null);
                $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_deleteList)));
                $tmpIdentityList.add(null);
                $Ku.byBase.SqlExpression.LocalSql.Tran_3($tmpIdentityList, $objList, $values);
            }
            catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
                String message = $thisisjavaserverxclusiveexceptionidentifier.toString();
            }

        }
    }

    public $Ku.byBase.Identity.bridge $getThis$Ku_byBase_Identity_bridge() {
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
