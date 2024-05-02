using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byWebCommon
{
    public class byWebCommon : byForm_Server.ku.by.ToolClass.BaseKu
    {
        public byWebCommon()
        {
            this.Name = "byWebCommon";

            byForm_Server.ku.byWebCommon.Identity.webCommon NewInstancewebCommon = new byForm_Server.ku.byWebCommon.Identity.webCommon();
            this.NewIdentityDic.Add("New_webCommon", NewInstancewebCommon);
            this.NewIdentityDicKeyIsId.Add(NewInstancewebCommon, "New_webCommon");
            NewInstancewebCommon.ku = "byWebCommon";
            this.sqlLocation = new SqlExpression.SqlLocation();
        }
    }
}
