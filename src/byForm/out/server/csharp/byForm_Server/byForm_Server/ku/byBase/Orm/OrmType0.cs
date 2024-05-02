using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byBase.Orm
{
    public class OrmType0 : byForm_Server.ku.by.ToolClass.IOrmType
    {
        public OrmType0()
        {
            IdentityDec = new Dictionary<string, Type>();
            OrmFields = new List<OrmField>();
            IdentityDec.Add("a", typeof(byForm_Server.ku.byBase.Identity.bridge));
            IdentityDec.Add("b", typeof(byForm_Server.ku.by.Identity.Table));
            Type = typeof(byForm_Server.ku.byBase.Orm.Orm0);
        }

        public System.Type Type { get; set; }

        public System.Collections.Generic.Dictionary<string, System.Type> IdentityDec { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> OrmFields { get; set; }
    }
}
