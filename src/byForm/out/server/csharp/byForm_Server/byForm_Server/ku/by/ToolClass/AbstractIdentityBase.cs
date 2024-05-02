using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public abstract class AbstractIdentityBase
    {
        public AbstractIdentityBase()
        {
        }

        public abstract string ku { get; set; }

        public abstract object to { get; set; }

        public virtual void NewIdentitySetDefault()
        {
        }

        public string RealKu
        {
            get
            {
                string tmpKu;
                if (Root.GetInstance().KuNameReflectionDic.TryGetValue(this.ku, out tmpKu))
                {
                    return tmpKu;
                }

                return this.ku;
            }
        }
    }
}
