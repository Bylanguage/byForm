package $Ku.byCommon.Identity;

public class relatedTable extends $Ku.by.Identity.Identity {
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public relatedTable() {
    }


    public static $Ku.by.Object.List<$Ku.by.Object.Row> cloneListRow($Ku.by.Object.List<$Ku.by.Object.Row> f_sourceList) {
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpList = new $Ku.by.Object.List<$Ku.by.Object.Row>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class));
        for ($Ku.by.Object.Row item : f_sourceList) {
            tmpList.add(item.Copy());
        }
        return tmpList;
    }

    public static java.lang.Boolean isExists($Ku.by.Object.Row f_sourceRow, $Ku.by.Object.List<$Ku.by.Object.Row> f_targetList) {
        for ($Ku.by.Object.Row item : f_targetList) {
            if ($Ku.by.ToolClass.ToolFunction.RowRelationEqualRow(item, f_sourceRow)) {
                return true;
            }
        }
        return false;
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> isExists($Ku.by.Object.List<$Ku.by.Object.Row> f_sourceList, $Ku.by.Object.List<$Ku.by.Object.Row> f_targetList) {
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpResultList = new $Ku.by.Object.List<$Ku.by.Object.Row>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class));
        for ($Ku.by.Object.Row item : f_sourceList) {
            if (isExists(item, f_targetList)) {
                tmpResultList.add(item);
            }
        }
        return tmpResultList;
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> isNotExists($Ku.by.Object.List<$Ku.by.Object.Row> f_sourceList, $Ku.by.Object.List<$Ku.by.Object.Row> f_targetList) {
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpResultList = new $Ku.by.Object.List<$Ku.by.Object.Row>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class));
        for ($Ku.by.Object.Row item : f_sourceList) {
            if (!isExists(item, f_targetList)) {
                tmpResultList.add(item);
            }
        }
        return tmpResultList;
    }

    public $Ku.byCommon.Identity.relatedTable $getThis$Ku_byCommon_Identity_relatedTable() {
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
