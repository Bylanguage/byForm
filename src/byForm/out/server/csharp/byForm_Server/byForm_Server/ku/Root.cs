using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku
{
    public class Root
    {
        private readonly static object LockObj = new object();

        private static byForm_Server.ku.Root MyClass;

        public readonly System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.BaseKu> KuDic = new System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.BaseKu>();

        public readonly System.Collections.Generic.Dictionary<string, string> ReNamedObjDicKeyIsOld = new System.Collections.Generic.Dictionary<string, string>();

        public readonly System.Collections.Generic.Dictionary<string, string> RenamedObjDicKeyIsNew = new System.Collections.Generic.Dictionary<string, string>();

        public readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, string>> ReNamedPropDicKeyIsOld = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, string>>();

        public readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, string>> ReNamedPropDicKeyIsNew = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, string>>();

        public readonly System.Collections.Generic.Dictionary<string, string> PreinstallClassNameDic = new System.Collections.Generic.Dictionary<string, string>();

        public readonly System.Collections.Generic.Dictionary<string, byForm_Server.ku.DBTypeEnum> KuTypeDic = new System.Collections.Generic.Dictionary<string, byForm_Server.ku.DBTypeEnum>();

        public readonly System.Collections.Generic.Dictionary<string, string> KuNameReflectionDic = new System.Collections.Generic.Dictionary<string, string>();

        public readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.KeyValuePair<System.Type, byForm_Server.ku.by.ToolClass.IOrmType>> OrmTypeDic = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.KeyValuePair<System.Type, byForm_Server.ku.by.ToolClass.IOrmType>>();

        public readonly System.Collections.Generic.Dictionary<System.Type, string> OrmNameDic = new System.Collections.Generic.Dictionary<System.Type, string>();

        private System.Boolean hasCreated = false;

        private static System.Boolean existTest = false;

        public byForm_Server.ku.by.ToolClass.BaseKu this[string f_KuName]
        {
            get
            {
                if (!this.KuDic.ContainsKey(f_KuName))
                {
                    ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindKu, f_KuName));
                }
                return this.KuDic[f_KuName];
            }
        }

        public static byForm_Server.ku.Root GetInstance()
        {
            if (MyClass == null)
            {
                lock (LockObj)
                {
                    if (existTest)
                    {
                        throw new Exception("root资源被释放，及时报告修复");
                    }

                    if (MyClass == null)
                    {
                        try
                        {
                            MyClass = new Root();
                            existTest = true;
                        }
                        catch(Exception ex)
                        {
                            by.ToolClass.ThrowHelper.ThrowKuInitException(ex.Message);
                        }
                    }
                }
            }

            if (!MyClass.hasCreated)
            {
                MyClass.hasCreated = true;

                foreach (var kuKV in MyClass.KuDic)
                {
                    foreach (var item in kuKV.Value.NewIdentityDic)
                    {
                        var tmpNewIdentity = item.Value;
                        tmpNewIdentity.NewIdentitySetDefault();
                    }
                }
            }

            return MyClass;
        }

        public bool ContainsSheet(string f_KuName, string f_SheetName)
        {
            if (!this.KuDic.ContainsKey(f_KuName))
            {
                return false;
            }

            var tmpKu = this[f_KuName];
            if (!tmpKu.ContainsKey(f_SheetName))
            {
                return false;
            }

            return true;
        }

        public byForm_Server.ku.by.ToolClass.IBaseDataSheet GetDataSheetByInstance(byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Instance)
        {
            //现在不存在跨库调用
            if (f_Instance == null)
            {
                by.ToolClass.ThrowHelper.ThrowUnKnownException(ku.by.ToolClass.ErrorInfo.IdentityInstanceError);
            }

            if (f_Instance.ku == null)
            {
                by.ToolClass.ThrowHelper.ThrowUnKnownException(ku.by.ToolClass.ErrorInfo.IdentityInstanceError);
            }
            var tmpKu = this[f_Instance.ku];
            by.ToolClass.IBaseDataSheet tmpValue;
            if (!tmpKu.DataSheetIdentityDic.TryGetValue(f_Instance,out tmpValue))
            {
                ThrowHelper.ThrowDataMatchException(ErrorInfo.GetIdentityByInstanceError);
            }
            return tmpValue;
        }

        public static T GetNewIdentity<T>(string f_KuName, string f_Name) where T : byForm_Server.ku.by.ToolClass.AbstractIdentityBase
        {
            var tmpNewIdentityDic = Root.GetInstance()[f_KuName].NewIdentityDic;

            if (!tmpNewIdentityDic.ContainsKey(f_Name))
            {
                by.ToolClass.ThrowHelper.ThrowDataMatchException(by.ToolClass.ErrorInfo.UnClearIdentity + f_Name);
            }

            return (T)tmpNewIdentityDic[f_Name];
        }

        public Root()
        {
            this.PreinstallClassNameDic.Add("list", "List");
            this.PreinstallClassNameDic.Add("object", "object");
            this.PreinstallClassNameDic.Add("String", "string");
            this.PreinstallClassNameDic.Add("Boolean", "bool");
            this.PreinstallClassNameDic.Add("Byte", "byte");
            this.PreinstallClassNameDic.Add("Char", "char");
            this.PreinstallClassNameDic.Add("Decimal", "decimal");
            this.PreinstallClassNameDic.Add("Int16", "short");
            this.PreinstallClassNameDic.Add("Int32", "int");
            this.PreinstallClassNameDic.Add("Int64", "long");
            this.PreinstallClassNameDic.Add("Single", "float");
            this.PreinstallClassNameDic.Add("Double", "double");
            this.KuDic.Add("byExternal", new ku.byExternal.byExternal());
            this.KuDic.Add("byFormNew", new ku.byFormNew.byFormNew());
            this.KuDic.Add("byExternalSMS", new ku.byExternalSMS.byExternalSMS());
            this.KuDic.Add("byWebCommon", new ku.byWebCommon.byWebCommon());
            this.KuDic.Add("byExternalChartjs", new ku.byExternalChartjs.byExternalChartjs());
            this.KuDic.Add("byBase", new ku.byBase.byBase());
            this.KuDic.Add("by", new ku.by.by());
            this.KuDic.Add("byUser", new ku.byUser.byUser());
            this.KuDic.Add("byLog", new ku.byLog.byLog());
            this.KuDic.Add("byInterface", new ku.byInterface.byInterface());
            this.KuDic.Add("byForm", new ku.byForm.byForm());
            this.KuDic.Add("byCommon", new ku.byCommon.byCommon());
            this.KuTypeDic.Add("byFormNew", DBTypeEnum.SqlServer);
            this.KuTypeDic.Add("byUser", DBTypeEnum.SqlServer);
            this.KuNameReflectionDic.Add("byUser", "buUserTest");
            this.OrmTypeDic.Add("byBase.bridge.myOrm", new KeyValuePair<Type, by.ToolClass.IOrmType>(typeof(byForm_Server.ku.byBase.Orm.Orm0), new byForm_Server.ku.byBase.Orm.OrmType0()));
            this.OrmTypeDic.Add("byUser.user.userOrm", new KeyValuePair<Type, by.ToolClass.IOrmType>(typeof(byForm_Server.ku.byUser.Orm.Orm0), new byForm_Server.ku.byUser.Orm.OrmType0()));
            this.OrmTypeDic.Add("byUser.userAdmin.adminOrm", new KeyValuePair<Type, by.ToolClass.IOrmType>(typeof(byForm_Server.ku.byUser.Orm.Orm1), new byForm_Server.ku.byUser.Orm.OrmType1()));
            this.OrmNameDic.Add(typeof(byForm_Server.ku.byBase.Orm.Orm0), "byBase.bridge.myOrm");
            this.OrmNameDic.Add(typeof(byForm_Server.ku.byUser.Orm.Orm0), "byUser.user.userOrm");
            this.OrmNameDic.Add(typeof(byForm_Server.ku.byUser.Orm.Orm1), "byUser.userAdmin.adminOrm");
        }

        public void AssembleComponent()
        {
            foreach (var ku in KuDic.Values)
            {
                foreach (var datasheet in ku.DataSheetDic.Values)
                {
                    datasheet.AssembleFieldRefrence();
                }
            }
            ((ku.byFormNew.byFormNew)KuDic["byFormNew"]).FillIdentityComponent();
        }
    }
}
