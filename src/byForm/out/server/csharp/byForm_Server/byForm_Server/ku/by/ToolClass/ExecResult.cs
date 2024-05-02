using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class ExecResult
    {
        public ExecResult(int[] f_ItemIndex, byForm_Server.ku.by.ToolClass.IExecItem[] f_QueryResults)
        {
            Results = new Object.dictionary<string, IExecItem>();

            for (int i = 0; i < f_ItemIndex.Length; i++)
            {
                int tmpIndex = f_ItemIndex[i];
                string tmpItemName = "select" + i;
                var tmpQueryResult = f_QueryResults.ElementAtOrDefault(tmpIndex);

                if (tmpQueryResult == null || tmpQueryResult is SqlIDUResult)
                {
                    ThrowHelper.ThrowUnKnownException("Exec表达式装填索引错误");
                }

                Results.Add(tmpItemName, tmpQueryResult);
            }
        }

        public T GetMember<T>(string f_MemberName) where T : byForm_Server.ku.by.ToolClass.IExecItem
        {
            if (!Results.containsKey(f_MemberName))
            {
                ThrowHelper.ThrowUnKnownException("Exec表达式成员访问错误");
            }

            return (T)Results[f_MemberName];
        }

        public byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.ToolClass.IExecItem> Results { get; set; }
    }
}
