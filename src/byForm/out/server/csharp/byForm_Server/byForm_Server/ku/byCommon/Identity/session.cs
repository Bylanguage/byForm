using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Identity
{
    public class session : byForm_Server.ku.by.Identity.Identity_
    {
        public session()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public void remove(byForm_Server.ku.by.Object.ServerSession f_session)
        {
            if (removeEvent != null)
            {
                removeEvent(f_session);
            }
        }

        public void clear(byForm_Server.ku.by.Object.ServerSession f_session)
        {
            if (clearEvent != null)
            {
                clearEvent();
            }
        }

        public static event byForm_Server.ku.by.Delegates.KuDelegates.Delegate_1<byForm_Server.ku.by.Object.ServerSession> removeEvent;

        public static event byForm_Server.ku.by.Delegates.KuDelegates.Delegate_0 clearEvent;
    }
}
