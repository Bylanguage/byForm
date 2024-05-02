package $Ku.by.ToolClass.Sql;

import java.util.Hashtable;
import $Ku.by.ToolClass.Source;
public class QueryDataParameter {
    private java.util.LinkedHashMap<$Ku.by.ToolClass.Source, Object> privateValueDic;

    public QueryDataParameter(java.util.LinkedHashMap<$Ku.by.ToolClass.Source, Object> f_ValueDic) {
        this.setValueDic(f_ValueDic);
    }


    public final java.util.LinkedHashMap<$Ku.by.ToolClass.Source, Object> getValueDic() {
        return privateValueDic;
    }

    public void setValueDic(java.util.LinkedHashMap<$Ku.by.ToolClass.Source, Object> value) {
        privateValueDic = value;
    }
}
