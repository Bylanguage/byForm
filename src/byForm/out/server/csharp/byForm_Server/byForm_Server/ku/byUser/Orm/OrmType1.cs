using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
namespace byForm_Server.ku.byUser.Orm
{
    public class OrmType1 : byForm_Server.ku.by.ToolClass.IOrmType
    {
        public OrmType1()
        {
            IdentityDec = new Dictionary<string, Type>();
            OrmFields = new List<OrmField>();
            OrmFields.Add(new OrmField("iName", 1));
            OrmFields.Add(new OrmField("iDisplayName", 2));
            OrmFields.Add(new OrmField("iMobile", 3));
            IdentityDec.Add("a", typeof(byForm_Server.ku.byUser.Identity.userAdmin));
            Type = typeof(byForm_Server.ku.byUser.Orm.Orm1);
        }

        public System.Type Type { get; set; }

        public System.Collections.Generic.Dictionary<string, System.Type> IdentityDec { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> OrmFields { get; set; }
    }
}
