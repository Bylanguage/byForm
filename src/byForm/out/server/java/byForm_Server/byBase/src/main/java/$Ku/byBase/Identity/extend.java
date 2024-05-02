package $Ku.byBase.Identity;

public class extend extends $Ku.byBase.Identity.TableSafe {
    public $Ku.by.Identity.Attribute iName;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public extend() {
    }


    public $Ku.by.Object.Row load(java.lang.String f_ID) {
        {
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpList = ($Ku.byBase.SqlExpression.LocalSql._23(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_ID})).rows;
            if (tmpList.count() > 0) {
                return tmpList.get(0);
            }
            else {
                return null;
            }
        }
    }

    public java.lang.Integer addUpdateDelete($Ku.by.Object.Row f_row, $Ku.by.Enum.Action f_action) {
        {
            java.lang.Integer tmpResultValue = 0;
            switch (f_action) {
                case insert:
                    tmpResultValue = $Ku.byBase.SqlExpression.LocalSql._24(new Object[]{f_row});
                    break;
                case update:
                    tmpResultValue = $Ku.byBase.SqlExpression.LocalSql._25(new Object[]{f_row});
                    break;
                case delete:
                    tmpResultValue = $Ku.byBase.SqlExpression.LocalSql._26(new Object[]{f_row});
                    break;
            }
            return tmpResultValue;
        }
    }

    public $Ku.byBase.Identity.extend $getThis$Ku_byBase_Identity_extend() {
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
