using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public interface IBaseDataSheet
    {
        string KuName { get; set; }

        string RealKuName { get; }

        string SheetName { get; set; }

        System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> PrimaryKeyList { get; set; }

        System.Collections.Generic.List<string> DefaultColumnList { get; set; }

        System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.Field> ComponentDic { get; set; }

        System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.Field> FieldDic { get; set; }

        System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source>> FlowDic { get; set; }

        System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.Source> SourceDic { get; set; }

        System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string>> VerifyDic { get; set; }

        byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }

        string IdentityName { get; set; }

        bool IsConst { get; set; }

        string GetFieldDefault(string f_FieldName);

        void AssembleFieldRefrence();

        System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Delegates.KuDelegates.RowFlowDelegate> RowFlowDic { get; set; }

        System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Delegates.KuDelegates.RowsFlowDelegatge> RowsFlowDic { get; set; }

        System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Delegates.KuDelegates.RowFlowInTranDelegate> RowFlowInTranDic { get; set; }

        System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Delegates.KuDelegates.RowsFlowInTranDelegate> RowsFlowInTranDic { get; set; }
    }
}
