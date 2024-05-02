using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Delegates
{
    public class KuDelegates
    {
        public delegate string RowFlowDelegate(byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_Relation);

        public delegate string RowFlowInTranDelegate(string f_EffectCount, byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_Relation);

        public delegate string RowsFlowDelegatge(System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, params System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_Relation);

        public delegate string RowsFlowInTranDelegate(string f_EffectCount, System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, params System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_Relation);

        public delegate void Delegate_1<T0>(T0 f_0);

        public delegate void Delegate_0();
    }
}
