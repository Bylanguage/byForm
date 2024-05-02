package $Ku.byUser.Identity;

public class userAdmin extends $Ku.by.Identity.Table {
    private $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.Row> pAdminDic;
    public java.lang.Boolean pFirstRun = false;
    public $Ku.by.Identity.Attribute iUserMode;
    public $Ku.by.Identity.Attribute iDt;
    public $Ku.byUser.Identity.user rUser;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public userAdmin() {
        this.pAdminDic = new $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.Row>($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class));
        this.pFirstRun = false;
    }


    public $Ku.by.Object.Row getAdmin(java.lang.String f_userID) {
        if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(this.pAdminDic.count(), 0)) {
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpAdminList = ($Ku.byUser.SqlExpression.LocalSql._32(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{})).rows;
            for ($Ku.by.Object.Row item : tmpAdminList) {
                this.pAdminDic.add(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value), item);
            }
        }
        if (!this.pAdminDic.containsKey($Ku.by.Object.ServerSession.getCurrentSession().getCookie())) {
            return null;
        }
        return this.pAdminDic.containsKey(f_userID) ? this.pAdminDic.get(f_userID) : null;
    }

    public java.lang.Boolean isAdmin() {
        return java.util.Objects.equals(this.getAdmin($Ku.by.Object.ServerSession.getCurrentSession().getCookie()), null) ? false : true;
    }

    public $Ku.by.Object.List<$Ku.byUser.Orm.Orm1> getAdmin() {
        if (!this.isAdmin()) {
            return null;
        }
        {
            $Ku.by.Object.List<$Ku.byUser.Orm.Orm1> tmpList = ($Ku.byUser.SqlExpression.LocalSql._33(new $Ku.by.ToolClass.ITableSource[]{this,($Ku.byUser.Identity.user)$Ku.by.ToolClass.Root.GetInstance().KuDic.get("byUser").NewIdentityDic.get("New_user")}, new Object[]{})).rows;
            for ($Ku.byUser.Orm.Orm1 item : tmpList) {
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(item.Table0, "iID").value = this.rUser.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item.Table0, "iID").value));
                item.Member2 = this.rUser.rsaEncode(item.Member2);
                item.Member3 = this.rUser.rsaEncode(item.Member3);
                item.Member1 = this.rUser.rsaEncode(item.Member3);
            }
            return tmpList;
        }
    }

    public $Ku.by.Object.Result adminAddRemove($Ku.by.Object.Row f_adminRow, $Ku.by.Enum.Action f_action) {
        if (!java.util.Objects.equals(f_action, $Ku.by.Enum.Action.delete) && !java.util.Objects.equals(f_action, $Ku.by.Enum.Action.insert)) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_Operation_Limited()));
        }
        if (!this.isAdmin()) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_Operation_Forbidden_Must_Be_Admin()));
        }
        {
            $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_adminRow, "iID").value = this.rUser.rsaDecode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_adminRow, "iID").value));
            $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_adminRow, "iDt").value = $Ku.by.Object.Datetime.getNow();
            $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_adminRow, "iUserMode").value = $Ku.byUser.Enum.adminMode.general;
            try {
                if (java.util.Objects.equals(f_action, $Ku.by.Enum.Action.delete)) {
                    $Ku.byUser.SqlExpression.LocalSql._34(new Object[]{f_adminRow});
                }
                else {
                    if (java.util.Objects.equals(f_action, $Ku.by.Enum.Action.insert)) {
                        $Ku.byUser.SqlExpression.LocalSql._35(new Object[]{f_adminRow});
                    }
                }
            }
            catch ($Ku.by.Object.Exception ex) {
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
                }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", ex.message()));
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

    public $Ku.by.Object.List<$Ku.by.Object.Row> getPopupUser(java.lang.String f_keyword) {
        if (!this.isAdmin()) {
            return null;
        }
        {
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpList = null;
            if (!java.util.Objects.equals(f_keyword, null) && !java.util.Objects.equals(f_keyword, "")) {
                tmpList = ($Ku.byUser.SqlExpression.LocalSql._36(new $Ku.by.ToolClass.ITableSource[]{this.rUser}, new Object[]{f_keyword,f_keyword,f_keyword,f_keyword,f_keyword})).rows;
            }
            else {
                tmpList = ($Ku.byUser.SqlExpression.LocalSql._37(new $Ku.by.ToolClass.ITableSource[]{this.rUser}, new Object[]{})).rows;
            }
            for ($Ku.by.Object.Row item : tmpList) {
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value = this.rUser.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value));
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iName").value = this.rUser.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iName").value));
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iDisplayName").value = this.rUser.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iDisplayName").value));
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iMobile").value = this.rUser.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iMobile").value));
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iMail").value = this.rUser.rsaEncode(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iMail").value));
            }
            return tmpList;
        }
    }

    public java.lang.Boolean isFirstRun() {
        {
            if (this.pFirstRun) {
                this.pFirstRun = false;
                return true;
            }
            else {
                return false;
            }
        }
    }

    public void initInsertAdmin() {
        $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.TemporaryOrm$0> tmpAdmin = $Ku.byUser.SqlExpression.LocalSql._38(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{});
        if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals((($Ku.byUser.Orm.TemporaryOrm$0) tmpAdmin.rows.get(0)).Member0, 0)) {
            $Ku.by.ToolClass.OrmResult<$Ku.byUser.Orm.TemporaryOrm$1> tmpUserList = $Ku.byUser.SqlExpression.LocalSql._39(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{});
            if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals((($Ku.byUser.Orm.TemporaryOrm$1) tmpUserList.rows.get(0)).Member0, 0)) {
                $Ku.by.Object.Row tmpUserRow = $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Row(), ($t, $objs) -> {
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
                }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("$Identity", this.rUser));
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iDisplayName").value = "admin";
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iFreeze").value = false;
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRank").value = $Ku.byUser.Enum.rank.vip;
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iID").value = $Ku.byCommon.Identity.general.getGuid();
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iName").value = "admin";
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iPassword").value = this.rUser.md5Plus("admin123");
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRegDt").value = $Ku.by.Object.Datetime.getNow();
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRemark").value = "系统初始化自动生成";
                $Ku.by.Object.Row tmpAdminRow = $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Row(), ($t, $objs) -> {
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
                }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("$Identity", this));
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAdminRow, "iUserMode").value = $Ku.byUser.Enum.adminMode.general;
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAdminRow, "iID").value = ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iID").value);
                ;
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAdminRow, "iDt").value = (($Ku.by.Object.Datetime) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRegDt").value);
                try {
                    java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                    java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                    java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                    $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(tmpUserRow)));
                    $tmpIdentityList.add(null);
                    $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(tmpAdminRow)));
                    $tmpIdentityList.add(null);
                    $Ku.byUser.SqlExpression.LocalSql.Tran_4($tmpIdentityList, $objList, $values);
                }
                catch (Exception $thisisjavaserverxclusiveexceptionidentifier) {
                    String message = $thisisjavaserverxclusiveexceptionidentifier.toString();
                    throw new $Ku.by.Object.Exception("初始inset 管理员数据时出错" + message);
                }

                this.pFirstRun = true;
            }
        }
    }

    public $Ku.byUser.Identity.userAdmin $getThis$Ku_byUser_Identity_userAdmin() {
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
