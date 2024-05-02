package $Ku.byForm.Identity;

public class form extends $Ku.by.Identity.Table {
    public $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.List<$Ku.by.Object.Row>[]> pCacheDic;
    public java.lang.Integer pCacheDicCount = 0;
    public $Ku.by.Identity.Name iName;
    public $Ku.by.Identity.Attribute iSuccessMsg;
    public $Ku.by.Identity.Attribute iSubmitButton;
    public $Ku.by.Identity.ID iSummary;
    public $Ku.by.Identity.Attribute iUserID;
    public $Ku.byForm.Identity.formSys rFormSys;
    public $Ku.by.Identity.Attribute iCreateDt;
    public $Ku.by.Identity.Attribute iCurrentModifyDt;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public form() {
        this.pCacheDic = new $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.List<$Ku.by.Object.Row>[]>($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.List.class).addTypeArgument(0, $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class)).generateArrayType(1));
        this.pCacheDicCount = 1000;
    }


    public $Ku.by.Object.List<$Ku.by.Object.Row>[] load(java.lang.String f_userID) {
        if (!$Ku.byCommon.Object.verifyRequest.isOk(f_userID, 32) || !this.rFormSys.rUser.confirmUserIsLogin(f_userID)) {
            return null;
        }
        {
            f_userID = this.rFormSys.rUser.rsaDecode(f_userID);
            $Ku.byForm.SqlExpression.Exec$0 tmpMuiltList = new $Ku.byForm.SqlExpression.Exec$0($Ku.byForm.SqlExpression.LocalSql._12(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_userID}), $Ku.byForm.SqlExpression.LocalSql._13(new $Ku.by.ToolClass.ITableSource[]{this.rFormSys.rFormField}, new Object[]{f_userID}));
            return new $Ku.by.Object.List[]{tmpMuiltList.<$Ku.by.ToolClass.SqlType>getExecItem("select1").rows,tmpMuiltList.<$Ku.by.ToolClass.SqlType>getExecItem("select2").rows};
        }
    }

    public $Ku.by.Object.List<$Ku.by.Object.Row>[] loadSingle(java.lang.String f_FormID) {
        if (!$Ku.byCommon.Object.verifyRequest.isOk(f_FormID, 32)) {
            return null;
        }
        {
            if (this.pCacheDic.containsKey(f_FormID)) {
                return this.pCacheDic.get(f_FormID);
            }
            else {
                $Ku.byForm.SqlExpression.Exec$1 tmpMuiltList = new $Ku.byForm.SqlExpression.Exec$1($Ku.byForm.SqlExpression.LocalSql._14(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{f_FormID}), $Ku.byForm.SqlExpression.LocalSql._15(new $Ku.by.ToolClass.ITableSource[]{this.rFormSys.rFormField}, new Object[]{f_FormID}));
                $Ku.by.Object.List<$Ku.by.Object.Row>[] tmpListArr = new $Ku.by.Object.List[]{tmpMuiltList.<$Ku.by.ToolClass.SqlType>getExecItem("select1").rows,tmpMuiltList.<$Ku.by.ToolClass.SqlType>getExecItem("select2").rows};
                if (this.pCacheDic.count() < 1000) {
                    this.pCacheDic.add(f_FormID, tmpListArr);
                }
                return tmpListArr;
            }
        }
    }

    public $Ku.by.Object.List<$Ku.by.Object.Row> loadVDataSingle(java.lang.String f_FormID) {
        if (!$Ku.byCommon.Object.verifyRequest.isOk(f_FormID, 32)) {
            return null;
        }
        {
            $Ku.byForm.SqlExpression.Exec$2 tmpExecList = new $Ku.byForm.SqlExpression.Exec$2($Ku.byForm.SqlExpression.LocalSql._16(new $Ku.by.ToolClass.ITableSource[]{this.rFormSys.rVData64}, new Object[]{f_FormID}), $Ku.byForm.SqlExpression.LocalSql._17(new $Ku.by.ToolClass.ITableSource[]{this.rFormSys.rVData256}, new Object[]{f_FormID}), $Ku.byForm.SqlExpression.LocalSql._18(new $Ku.by.ToolClass.ITableSource[]{this.rFormSys.rVData1024}, new Object[]{f_FormID}), $Ku.byForm.SqlExpression.LocalSql._19(new $Ku.by.ToolClass.ITableSource[]{this.rFormSys.rVData4000}, new Object[]{f_FormID}));
            tmpExecList.<$Ku.by.ToolClass.SqlType>getExecItem("select1").rows.addRange(tmpExecList.<$Ku.by.ToolClass.SqlType>getExecItem("select2").rows);
            tmpExecList.<$Ku.by.ToolClass.SqlType>getExecItem("select1").rows.addRange(tmpExecList.<$Ku.by.ToolClass.SqlType>getExecItem("select3").rows);
            tmpExecList.<$Ku.by.ToolClass.SqlType>getExecItem("select1").rows.addRange(tmpExecList.<$Ku.by.ToolClass.SqlType>getExecItem("select4").rows);
            return tmpExecList.<$Ku.by.ToolClass.SqlType>getExecItem("select1").rows;
        }
    }

    public $Ku.by.Object.Result update($Ku.by.Object.List<$Ku.by.Object.Row> f_list, $Ku.by.Enum.Action f_action) {
        if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(f_list.count(), 0)) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byForm.Object.TextHelper.misssingListData));
        }
        $Ku.by.Identity.Table[] tmpID = new $Ku.by.Identity.Table[]{this,this.rFormSys.rVData1024,this.rFormSys.rVData256,this.rFormSys.rVData4000,this.rFormSys.rVData64};
        if (!$Ku.byCommon.Object.verifyRowIdentity.isExists(f_list, tmpID)) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byForm.Object.TextHelper.illegalInjection));
        }
        {
            try {
                java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                $values.add(f_action);
                java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_list)));
                $tmpIdentityList.add(null);
                $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_list)));
                $tmpIdentityList.add(null);
                $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(f_list)));
                $tmpIdentityList.add(null);
                $Ku.byForm.SqlExpression.LocalSql.Tran_0($tmpIdentityList, $objList, $values);
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
                }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("isOk", false), new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", errorInfo));
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

    public void saveField($Ku.by.Object.Row f_formField, $Ku.by.Enum.Action action) {
        this.rFormSys.rFormField.addUpdate(f_formField, action);
    }

    public void delFieldByFormId(java.lang.String formID) {
        this.rFormSys.rFormField.delByFormId(formID);
    }

    public $Ku.byForm.Identity.form $getThis$Ku_byForm_Identity_form() {
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
