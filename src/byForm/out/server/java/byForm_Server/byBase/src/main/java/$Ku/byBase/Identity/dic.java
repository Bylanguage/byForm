package $Ku.byBase.Identity;

public class dic extends $Ku.byBase.Identity.popupTable implements $Ku.byInterface.Identity.IBy  {
    public $Ku.by.Identity.Name iName;
    public $Ku.by.Identity.Attribute iSummary;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public dic() {
    }


    public $Ku.by.Object.Result addModifDelete($Ku.by.Object.Row f_row, $Ku.by.Enum.Action f_action) {
        {
            if (java.util.Objects.equals(f_action, $Ku.by.Enum.Action.insert)) {
                try {
                    java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                    java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                    java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                    $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_row)));
                    $tmpIdentityList.add(null);
                    $Ku.byBase.SqlExpression.LocalSql.Tran_8($tmpIdentityList, $objList, $values);
                }
                catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
                    String errorInfo = $thisisjavaserverxclusiveexceptionidentifier.toString();
                    return $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Result(), ($t, $objs) -> {
                                Class<?> $clazz = $t.getClass();
            try {
                for ($Ku.by.ToolClass.Entry<String, Object> $item : $objs){
                    if($item.k.equals("$Identity")){
                        java.lang.reflect.Method method = $clazz.getMethod("$setIdentity", $Ku.by.ToolClass.AbstractIdentityBase.class);
                        method.invoke($t, $item.v);
                    }
                    else{
                        $clazz.getField($item.k).set($t, $item.v);
                    }
                }
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
            return $t;
                    }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", errorInfo));
                }

            }
            else {
                if (java.util.Objects.equals(f_action, $Ku.by.Enum.Action.update)) {
                    try {
                        java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                        java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                        java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                        $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_row)));
                        $tmpIdentityList.add(null);
                        $Ku.byBase.SqlExpression.LocalSql.Tran_9($tmpIdentityList, $objList, $values);
                    }
                    catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
                        String errorInfo = $thisisjavaserverxclusiveexceptionidentifier.toString();
                        return $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Result(), ($t, $objs) -> {
                                    Class<?> $clazz = $t.getClass();
            try {
                for ($Ku.by.ToolClass.Entry<String, Object> $item : $objs){
                    if($item.k.equals("$Identity")){
                        java.lang.reflect.Method method = $clazz.getMethod("$setIdentity", $Ku.by.ToolClass.AbstractIdentityBase.class);
                        method.invoke($t, $item.v);
                    }
                    else{
                        $clazz.getField($item.k).set($t, $item.v);
                    }
                }
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
            return $t;
                        }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", errorInfo));
                    }

                }
                else {
                    if (java.util.Objects.equals(f_action, $Ku.by.Enum.Action.delete)) {
                        try {
                            java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                            java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                            java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_row)));
                            $tmpIdentityList.add(null);
                            $Ku.byBase.SqlExpression.LocalSql.Tran_10($tmpIdentityList, $objList, $values);
                        }
                        catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
                            String errorInfo = $thisisjavaserverxclusiveexceptionidentifier.toString();
                            return $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Result(), ($t, $objs) -> {
                                        Class<?> $clazz = $t.getClass();
            try {
                for ($Ku.by.ToolClass.Entry<String, Object> $item : $objs){
                    if($item.k.equals("$Identity")){
                        java.lang.reflect.Method method = $clazz.getMethod("$setIdentity", $Ku.by.ToolClass.AbstractIdentityBase.class);
                        method.invoke($t, $item.v);
                    }
                    else{
                        $clazz.getField($item.k).set($t, $item.v);
                    }
                }
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
            return $t;
                            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", errorInfo));
                        }

                    }
                }
            }
            return $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Result(), ($t, $objs) -> {
                        Class<?> $clazz = $t.getClass();
            try {
                for ($Ku.by.ToolClass.Entry<String, Object> $item : $objs){
                    if($item.k.equals("$Identity")){
                        java.lang.reflect.Method method = $clazz.getMethod("$setIdentity", $Ku.by.ToolClass.AbstractIdentityBase.class);
                        method.invoke($t, $item.v);
                    }
                    else{
                        $clazz.getField($item.k).set($t, $item.v);
                    }
                }
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
            return $t;
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("isOk", true));
        }
    }

    public $Ku.by.Object.List<$Ku.by.Object.Row> load($Ku.by.Object.List<$Ku.by.Object.Row> f_selectRowList, $Ku.by.Object.QueryData f_QueryData) {
        {
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpGridRows = new $Ku.by.Object.List<$Ku.by.Object.Row>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class));
            if (java.util.Objects.equals(f_selectRowList, null) || $Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(f_selectRowList.count(), 0)) {
                if (!java.util.Objects.equals(f_QueryData, null)) {
                    tmpGridRows = ($Ku.byBase.SqlExpression.LocalSql._34(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_QueryData})).rows;
                }
                else {
                    tmpGridRows = ($Ku.byBase.SqlExpression.LocalSql._35(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{})).rows;
                }
            }
            else {
                if (!java.util.Objects.equals(f_QueryData, null)) {
                    tmpGridRows = ($Ku.byBase.SqlExpression.LocalSql._36(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_QueryData,f_selectRowList.get(0)})).rows;
                }
                else {
                    tmpGridRows = ($Ku.byBase.SqlExpression.LocalSql._37(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_selectRowList.get(0)})).rows;
                }
            }
            return tmpGridRows;
        }
    }

    public $Ku.byBase.Identity.dic $getThis$Ku_byBase_Identity_dic() {
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
