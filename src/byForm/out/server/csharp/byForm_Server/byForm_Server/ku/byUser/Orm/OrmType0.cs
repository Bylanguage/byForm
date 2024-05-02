using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byUser.Orm
{
    public class OrmType0 : byForm_Server.ku.by.ToolClass.IOrmType
    {
        public OrmType0()
        {
            IdentityDec = new Dictionary<string, Type>();
            OrmFields = new List<OrmField>();
            OrmFields.Add(new OrmField("userIcoPath", 2));
            OrmFields.Add(new OrmField("iFileName", 3));
            OrmFields.Add(new OrmField("iExtendName", 4));
            IdentityDec.Add("a", typeof(byForm_Server.ku.byUser.Identity.user));
            IdentityDec.Add("b", typeof(byForm_Server.ku.byUser.Identity.userAdmin));
            Type = typeof(byForm_Server.ku.byUser.Orm.Orm0);
        }

        public System.Type Type { get; set; }

        public System.Collections.Generic.Dictionary<string, System.Type> IdentityDec { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> OrmFields { get; set; }
    }
}
