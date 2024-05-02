package $Ku.byBase.Action;

public class Action {
    public static $Ku.by.Object.Result _0_default($Ku.byBase.Identity.Tree $this, $Ku.by.Object.Row[] f_treeRows, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveDelete) {
        if (!$this.confirmUserIsLogin()) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login()));
        }
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        tmpResult.isOk = true;
        try {
            java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
            java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
            java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_treeRows)));
            $tmpIdentityList.add(null);
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_slaveDelete)));
            $tmpIdentityList.add(null);
            $Ku.byBase.SqlExpression.LocalSql.Tran_0($tmpIdentityList, $objList, $values);
        }
        catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
            String message = $thisisjavaserverxclusiveexceptionidentifier.toString();
            tmpResult.isOk = false;
            tmpResult.info = message;
        }

        return tmpResult;
    }

    public static $Ku.by.Object.Result _1_default($Ku.byBase.Identity.Tree $this, $Ku.by.Object.Row f_treeRow, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveAdd, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveUpdate, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveDelete) {
        if (!$this.confirmUserIsLogin()) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login()));
        }
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        tmpResult.isOk = true;
        try {
            java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
            java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
            java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_treeRow)));
            $tmpIdentityList.add(null);
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_slaveAdd)));
            $tmpIdentityList.add(null);
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_slaveUpdate)));
            $tmpIdentityList.add(null);
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_slaveDelete)));
            $tmpIdentityList.add(null);
            $Ku.byBase.SqlExpression.LocalSql.Tran_1($tmpIdentityList, $objList, $values);
        }
        catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
            String message = $thisisjavaserverxclusiveexceptionidentifier.toString();
            tmpResult.isOk = false;
            tmpResult.info = message;
        }

        return tmpResult;
    }

    public static $Ku.by.Object.Result _2_default($Ku.byBase.Identity.Tree $this, $Ku.by.Object.Row f_treeRow, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveAdd) {
        if (!$this.confirmUserIsLogin()) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login()));
        }
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        tmpResult.isOk = true;
        if (java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_treeRow, "iID").value), null) || java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_treeRow, "iID").value), "")) {
            $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_treeRow, "iID").value = $Ku.byCommon.Identity.general.getGuid();
        }
        try {
            java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
            java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
            java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_treeRow)));
            $tmpIdentityList.add(null);
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_slaveAdd)));
            $tmpIdentityList.add(null);
            $Ku.byBase.SqlExpression.LocalSql.Tran_2($tmpIdentityList, $objList, $values);
        }
        catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
            String message = $thisisjavaserverxclusiveexceptionidentifier.toString();
            tmpResult.isOk = false;
            tmpResult.info = message;
        }

        return tmpResult;
    }

    public static $Ku.by.Object.Result _3_default($Ku.byBase.Identity.bridge $this, $Ku.by.Object.List<$Ku.by.Object.Row> f_bridgeRowList) {
        if (!$this.confirmUserIsLogin()) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login()));
        }
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        tmpResult.isOk = true;
        for ($Ku.by.Object.Row item : f_bridgeRowList) {
            if (java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value), null) || java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value), "")) {
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value = $Ku.byCommon.Identity.general.getGuid();
            }
        }
        java.lang.Integer tmpListCount = f_bridgeRowList.count();
        try {
            java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
            java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
            $values.add(tmpListCount);
            java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_bridgeRowList)));
            $tmpIdentityList.add(null);
            $Ku.byBase.SqlExpression.LocalSql.Tran_4($tmpIdentityList, $objList, $values);
        }
        catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
            String errorInfo = $thisisjavaserverxclusiveexceptionidentifier.toString();
            tmpResult.isOk = false;
            tmpResult.info = errorInfo;
        }

        return tmpResult;
    }

    public static $Ku.by.Object.Result _4_default($Ku.byBase.Identity.bridge $this, $Ku.by.Object.List<$Ku.by.Object.Row> f_bridgeAddList, $Ku.by.Object.List<$Ku.by.Object.Row> f_bridgeDeleteList) {
        if (!$this.confirmUserIsLogin()) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login()));
        }
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        tmpResult.isOk = true;
        if (f_bridgeAddList.count() > 0 || f_bridgeDeleteList.count() > 0) {
            for ($Ku.by.Object.Row item : f_bridgeAddList) {
                if (java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value), null) || java.util.Objects.equals(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value), "")) {
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value = $Ku.byCommon.Identity.general.getGuid();
                }
            }
            try {
                java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_bridgeAddList)));
                $tmpIdentityList.add(null);
                $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_bridgeDeleteList)));
                $tmpIdentityList.add(null);
                $Ku.byBase.SqlExpression.LocalSql.Tran_5($tmpIdentityList, $objList, $values);
            }
            catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
                String message = $thisisjavaserverxclusiveexceptionidentifier.toString();
                tmpResult.isOk = false;
                tmpResult.info = message;
            }

        }
        return tmpResult;
    }

    public static $Ku.by.Object.Result _5_default($Ku.byBase.Identity.bridge $this, $Ku.by.Object.List<$Ku.by.Object.Row> f_bridgeRowList) {
        if (!$this.confirmUserIsLogin()) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login()));
        }
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        tmpResult.isOk = true;
        try {
            $Ku.byBase.SqlExpression.LocalSql._19(new Object[]{f_bridgeRowList});
        }
        catch ($Ku.by.Object.Exception e) {
            tmpResult.isOk = false;
            tmpResult.info = e.message();
        }

        return tmpResult;
    }


    public interface _0{
        $Ku.by.Object.Result invoke($Ku.byBase.Identity.Tree $this, $Ku.by.Object.Row[] f_treeRows, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveDelete) ;
    }

    public interface _1{
        $Ku.by.Object.Result invoke($Ku.byBase.Identity.Tree $this, $Ku.by.Object.Row f_treeRow, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveAdd, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveUpdate, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveDelete) ;
    }

    public interface _2{
        $Ku.by.Object.Result invoke($Ku.byBase.Identity.Tree $this, $Ku.by.Object.Row f_treeRow, $Ku.by.Object.List<$Ku.by.Object.Row> f_slaveAdd) ;
    }

    public interface _3{
        $Ku.by.Object.Result invoke($Ku.byBase.Identity.bridge $this, $Ku.by.Object.List<$Ku.by.Object.Row> f_bridgeRowList) ;
    }

    public interface _4{
        $Ku.by.Object.Result invoke($Ku.byBase.Identity.bridge $this, $Ku.by.Object.List<$Ku.by.Object.Row> f_bridgeAddList, $Ku.by.Object.List<$Ku.by.Object.Row> f_bridgeDeleteList) ;
    }

    public interface _5{
        $Ku.by.Object.Result invoke($Ku.byBase.Identity.bridge $this, $Ku.by.Object.List<$Ku.by.Object.Row> f_bridgeRowList) ;
    }
}
