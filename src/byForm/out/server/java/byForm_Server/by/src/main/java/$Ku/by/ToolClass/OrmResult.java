package $Ku.by.ToolClass;

import $Ku.by.ToolClass.Sql.SelectTable;
import $Ku.by.Object.*;
import java.util.*;
public class OrmResult<T extends $Ku.by.Object.AbstractOrm> implements $Ku.by.ToolClass.ITableSource, $Ku.by.ToolClass.Sql.IExecResult  {
    private $Ku.by.ToolClass.$ClassMessage $T;
    public $Ku.by.Object.List<T> rows;
    public $Ku.by.ToolClass.Sql.SelectTable Source;

    public OrmResult($Ku.by.ToolClass.$ClassMessage $T) {
        this.$T = $T;
    }

    public OrmResult($Ku.by.ToolClass.$ClassMessage $T, java.util.ArrayList<T> rows, $Ku.by.ToolClass.Sql.SelectTable Source) {
        this.$T = $T;
        this.rows = new $Ku.by.Object.List<>($T,rows);
        this.Source = Source;
    }


    public final java.util.ArrayList<T> getRows() {
        ArrayList<T> result = new ArrayList<>();
        for (T orm : rows){
            result.add((T) orm.clone());
        }
        return result;
    }

    public final void setRows(java.util.ArrayList<T> value) {
        this.rows = new $Ku.by.Object.List<>($T,value);
    }

    public final $Ku.by.ToolClass.Sql.SelectTable getSource() {
        return this.Source;
    }

    public final void setSource($Ku.by.ToolClass.Sql.SelectTable value) {
        this.Source = value;
    }
}
