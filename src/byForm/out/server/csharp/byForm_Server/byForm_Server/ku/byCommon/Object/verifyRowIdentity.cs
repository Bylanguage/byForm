using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Object
{
    public class verifyRowIdentity
    {
        public verifyRowIdentity()
        {
        }

        public static bool isExists(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_verifyList, byForm_Server.ku.by.Identity.Table[] f_tableIdentity)
        {
            foreach (byForm_Server.ku.by.Object.Row item in f_verifyList)
            {
                bool tmpVia = false;
                foreach (byForm_Server.ku.by.Identity.Table ID in f_tableIdentity)
                {
                    if (ID == byForm_Server.ku.by.ToolClass.ToolFunction.GetIdentityOfTildeValue<byForm_Server.ku.by.Identity.Table>(item))
                    {
                        tmpVia = true;
                    }
                }
                if (!tmpVia)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
