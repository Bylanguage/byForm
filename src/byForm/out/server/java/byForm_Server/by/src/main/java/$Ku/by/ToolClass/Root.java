package $Ku.by.ToolClass;

import $Ku.by.ToolClass.*;
import java.util.Hashtable;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;
public class Root {
    private final static java.util.concurrent.locks.Lock lock = new ReentrantLock();
    private static $Ku.by.ToolClass.Root MyClass;
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.BaseKu> KuDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, java.lang.String> ReNamedObjDicKeyIsOld = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, java.lang.String> ReNamedObjDicKeyIsNew = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, java.util.LinkedHashMap<java.lang.String, java.lang.String>> ReNamedPropDicKeyIsOld = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, java.util.LinkedHashMap<java.lang.String, java.lang.String>> ReNamedPropDicKeyIsNew = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.Class< ? >, java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.$ClassMessage>> ObjProListTypeDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.DBTypeEnum> KuTypeDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.Class< ? >, java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.$ClassMessage>> ObjProDicKeyTypeDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.Class< ? >, java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.$ClassMessage>> ObjProDicValueTypeDic = new java.util.LinkedHashMap<>();
    public final java.util.LinkedHashMap<java.lang.String, $Ku.by.Object.KeyValue<java.lang.Class< ? >, $Ku.by.Object.IOrmType>> OrmTypeDic = new java.util.LinkedHashMap<>();
    public final java.util.LinkedHashMap<java.lang.Class< ? >, java.lang.String> OrmNameDic = new java.util.LinkedHashMap<>();
    public final java.util.HashMap<java.lang.String, java.util.HashMap<java.lang.String, java.lang.String>> ExecSqlNameDic = new java.util.HashMap<>();
    public final java.util.HashMap<java.lang.String, java.lang.String> KuConnectDic = new java.util.HashMap<>();

    public $Ku.by.ToolClass.BaseKu get(java.lang.String f_KuName) {
        if (this.KuDic.get(f_KuName) == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindKu, f_KuName));
        }
        return this.KuDic.get(f_KuName);
    }

    public static $Ku.by.ToolClass.Root GetInstance() {
        if (MyClass == null){
            lock.lock();
            MyClass = new Root();
            //MyClass.assembleComponent();
            //Main.byMain(null);
            lock.unlock();
        }
        return MyClass;
    }

    public boolean ContainsSheet(java.lang.String f_KuName, java.lang.String f_SheetName) {
        if (this.KuDic.get(f_KuName)==null){
            return false;
        }

        BaseKu tmpKu = this.KuDic.get(f_KuName);
        return tmpKu.get(f_SheetName) != null;
    }

    public $Ku.by.ToolClass.IBaseDataSheet GetDataSheetByInstance($Ku.by.ToolClass.AbstractIdentityBase f_Instance) {
        if(f_Instance == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException($Ku.by.ToolClass.ErrorInfo.IdentityInstanceError);
        }

        if(f_Instance.getKu() == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException($Ku.by.ToolClass.ErrorInfo.IdentityInstanceError);
        }
        BaseKu tmpKu = this.KuDic.get(f_Instance.getKu());
        IBaseDataSheet tmpValue = tmpKu.DataSheetIdentityDic.get(f_Instance);
        if (tmpValue == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(ErrorInfo.CanNotFindDataSheetByInstance);
        }
        return tmpValue;
    }
}
