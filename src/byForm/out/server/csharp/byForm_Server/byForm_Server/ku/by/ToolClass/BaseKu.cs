using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class BaseKu
    {
        public string Name;

        public readonly System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.IBaseDataSheet> DataSheetDic = new System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.IBaseDataSheet>();

        public readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.SheetRelation>> RelationDic = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.SheetRelation>>();

        public readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Config>> ConfigDic = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Config>>();

        public readonly System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.AbstractIdentityBase> NewIdentityDic = new System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.AbstractIdentityBase>();

        public readonly System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.AbstractIdentityBase, string> NewIdentityDicKeyIsId = new System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.AbstractIdentityBase, string>();

        public readonly System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.AbstractIdentityBase, byForm_Server.ku.by.ToolClass.IBaseDataSheet> DataSheetIdentityDic = new System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.AbstractIdentityBase, byForm_Server.ku.by.ToolClass.IBaseDataSheet>();

        public readonly System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.AbstractIdentityBase> NewIdentityDicKeyIsActionNo = new System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.AbstractIdentityBase>();

        public byForm_Server.ku.by.ToolClass.IBaseDataSheet this[string f_SheetName]
        {
            get
            {
                if (!this.DataSheetDic.ContainsKey(f_SheetName))
                {
                    throw new Exception(string.Format(ku.by.ToolClass.ErrorInfo.CanNotFindSheetInKu, this.Name, f_SheetName));
                }
                return this.DataSheetDic[f_SheetName];
            }
        }

        public static byForm_Server.ku.by.ToolClass.BaseKu GetKu(string f_KuName)
        {
            return Root.GetInstance()[f_KuName];
        }

        public bool ContainsKey(string f_Key)
        {
            return this.DataSheetDic.ContainsKey(f_Key);
        }

        public byForm_Server.ku.by.ToolClass.ISqlLocation sqlLocation;
    }
}
