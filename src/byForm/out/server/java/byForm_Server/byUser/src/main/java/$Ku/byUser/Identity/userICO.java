package $Ku.byUser.Identity;

public class userICO extends $Ku.by.Identity.Table {
    public java.lang.String pAllowUploadFileType;
    private java.lang.Integer pUploadSerialNumber = 0;
    public java.lang.Integer pUploadFileSize = 0;
    public java.lang.Integer pUploadUserICOFileSize = 0;
    public $Ku.by.Identity.Attribute iIcoFile;
    public $Ku.by.Identity.Attribute iFileName;
    public $Ku.by.Identity.Attribute iExtendName;
    public $Ku.by.Identity.Attribute iUploadDt;
    public $Ku.byUser.Identity.user rUser;
    private $Ku.by.ToolClass.Sql.SelectTable Source;
    public $Ku.byUser.Event.userICOuserICOChangeEvent userICOChangeEvent = new $Ku.byUser.Event.userICOuserICOChangeEvent();

    public userICO() {
        this.pAllowUploadFileType = ",txt,jpg,png,ico,sql,by,mp4,zip,rar,";
        this.pUploadFileSize = 2097152;
        this.pUploadUserICOFileSize = 50000;
    }


    public java.lang.String getIcoUrlPath(java.lang.String f_pathICO) {
        java.lang.String tmpServerPath = null;
        {
            tmpServerPath = $Ku.by.Object.ServerSession.getCurrentSession().url;
        }
        return $Ku.by.ToolClass.StringUtil.replaceReg(tmpServerPath, "[^/]+$", "", $Ku.by.Enum.RegexMode.none) + $Ku.byUser.Enum.uploadMode.userIco.toString() + "/" + $Ku.by.ToolClass.StringUtil.replaceReg(f_pathICO, "[\\\\]+", "/", $Ku.by.Enum.RegexMode.none);
    }

    public java.lang.String getIcoDiskPath(java.lang.String f_fileName, java.lang.String f_extendName, $Ku.byUser.Enum.uploadMode f_uploadMode) {
        return getIcoDiskPath(f_fileName + "." + f_extendName, f_uploadMode);
    }

    public java.lang.String getIcoDiskPath(java.lang.String f_fileFullName, $Ku.byUser.Enum.uploadMode f_uploadMode) {
        java.lang.String tmpDir = $Ku.by.Object.System.currentDirectory() + f_uploadMode.toString();
        if (!$Ku.by.Object.Directory.exists(tmpDir)) {
            $Ku.by.Object.Directory.createDirectory(tmpDir);
        }
        return tmpDir + "\\" + f_fileFullName;
    }

    public $Ku.by.Object.Result fileUpload(java.lang.Byte[] f_fileBytes, $Ku.byUser.Enum.uploadMode f_dirMode, java.lang.String f_extendName) {
        if (java.util.Objects.equals(f_extendName, null) || $Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(this.pAllowUploadFileType.indexOf("," + f_extendName.toLowerCase() + ","), -1)) {
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
            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_Upload_Format_Unsupported($Ku.by.ToolClass.StringUtil.replaceReg(this.pAllowUploadFileType, "(^,)|(,$)", "", $Ku.by.Enum.RegexMode.none))));
        }
        if (java.util.Objects.equals(f_dirMode, $Ku.byUser.Enum.uploadMode.userIco)) {
            if (f_fileBytes.length > this.pUploadUserICOFileSize) {
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
                }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_Upload_File_To_Large(this.pUploadUserICOFileSize / 1024)));
            }
        }
        else {
            if (java.util.Objects.equals(f_dirMode, $Ku.byUser.Enum.uploadMode.contentOther)) {
                if (f_fileBytes.length > this.pUploadFileSize) {
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
                    }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_Upload_File_To_Large(this.pUploadFileSize / 1024)));
                }
                ;
            }
        }
        {
            if (!this.rUser.confirmUserIsLogin($Ku.byUser.Enum.confirmUserIsLoginMode.verifyLogin)) {
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
                }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_Upload_User_Not_Login()));
            }
            try {
                $Ku.by.Object.Row tmpUploadRow = $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Row(), ($t, $objs) -> {
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
                }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("$Identity", this.rUser.rUserUpload));
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iID").value = $Ku.byCommon.Identity.general.getGuid();
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iDT").value = $Ku.by.Object.Datetime.getNow();
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iUserID").value = ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent((($Ku.by.Object.Row) $Ku.by.Object.ServerSession.getCurrentSession().user), "iID").value);
                $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iFileSize").value = f_fileBytes.length / 1024;
                if (java.util.Objects.equals(f_dirMode, $Ku.byUser.Enum.uploadMode.userIco)) {
                    $Ku.by.Object.Row tmpUserIcoRow = $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Row(), ($t, $objs) -> {
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
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iID").value = ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iUserID").value);
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iIcoFile").value = $Ku.byCommon.Object.convert.base64ToString(f_fileBytes);
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iFileName").value = $Ku.byCommon.Identity.general.getGuid();
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iExtendName").value = f_extendName;
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iUploadDt").value = $Ku.by.Object.Datetime.getNow();
                    $Ku.by.Object.List<$Ku.by.Object.Row> tmpOldIcoList = ($Ku.byUser.SqlExpression.LocalSql._26(new $Ku.by.ToolClass.ITableSource[]{this}, new Object[]{((java.lang.String)$Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iID").value)})).rows;
                    if (tmpOldIcoList.count() > 0) {
                        java.lang.String tmpPathFileName = this.getIcoDiskPath(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpOldIcoList.get(0), "iFileName").value), ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpOldIcoList.get(0), "iExtendName").value), f_dirMode);
                        if ($Ku.by.Object.File.exists(tmpPathFileName)) {
                            $Ku.by.Object.File.delete(tmpPathFileName);
                        }
                    }
                    java.lang.String newIcoPath = getIcoDiskPath(((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iFileName").value), f_extendName, f_dirMode);
                    $Ku.by.Object.File.writeAllBytes(newIcoPath, f_fileBytes, false);
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iSummery").value = "上传图标";
                    $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iFileName").value = ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iFileName").value) + "." + f_extendName;
                    if (tmpOldIcoList.count() > 0) {
                        try {
                            java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                            java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                            java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(tmpUploadRow)));
                            $tmpIdentityList.add(null);
                            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(tmpUserIcoRow)));
                            $tmpIdentityList.add(null);
                            $Ku.byUser.SqlExpression.LocalSql.Tran_2($tmpIdentityList, $objList, $values);
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
                            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_SQL_Execution_Failed() + errorInfo));
                        }

                    }
                    else {
                        try {
                            java.util.ArrayList<java.util.ArrayList<Object>> $objList = new java.util.ArrayList<>();
                            java.util.ArrayList<Object> $values = new java.util.ArrayList<>();
                            java.util.ArrayList<$Ku.by.ToolClass.ITableSource> $tmpIdentityList = new java.util.ArrayList<>();
                            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(tmpUploadRow)));
                            $tmpIdentityList.add(null);
                            $objList.add(new java.util.ArrayList<>(java.util.Arrays.asList(tmpUserIcoRow)));
                            $tmpIdentityList.add(null);
                            $Ku.byUser.SqlExpression.LocalSql.Tran_3($tmpIdentityList, $objList, $values);
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
                            }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_SQL_Execution_Failed() + errorInfo));
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
                    }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("isOk", true), new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", f_dirMode.toString() + "\\" + ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserIcoRow, "iFileName").value) + "." + f_extendName));
                }
                else {
                    if (java.util.Objects.equals(f_dirMode, $Ku.byUser.Enum.uploadMode.contentOther)) {
                        java.lang.String tmpFileName = $Ku.byCommon.Identity.general.getGuid();
                        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iSummery").value = "上传文件";
                        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iFileName").value = tmpFileName + "." + f_extendName;
                        $Ku.byUser.SqlExpression.LocalSql._31(new Object[]{tmpUploadRow});
                        $Ku.by.Object.File.writeAllBytes(this.getIcoDiskPath(tmpFileName, f_extendName, f_dirMode), f_fileBytes, false);
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
                        }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("isOk", true), new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", f_dirMode.toString() + "\\" + ((java.lang.String) $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUploadRow, "iFileName").value)));
                    }
                    else {
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
                        }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", $Ku.byUser.Object.ByUserStrings.Info_Upload_File_Only_Allow_Icon()));
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
                }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("info", ex.message() + "[" + $Ku.by.Object.System.currentDirectory() + "]"));
            }

        }
    }

    public $Ku.byUser.Identity.userICO $getThis$Ku_byUser_Identity_userICO() {
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
