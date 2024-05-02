using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Action
{
    public class Action
    {
        public delegate ReturnType Delegate_3<T_0, T_1, T_2, ReturnType>(T_0 f_0, T_1 f_1, T_2 f_2);

        public delegate ReturnType Delegate_5<T_0, T_1, T_2, T_3, T_4, ReturnType>(T_0 f_0, T_1 f_1, T_2 f_2, T_3 f_3, T_4 f_4);

        public delegate ReturnType Delegate_2<T_0, T_1, ReturnType>(T_0 f_0, T_1 f_1);
    }
}
