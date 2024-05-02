using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byLog.SqlExpression
{
    public class SqlLocation : byForm_Server.ku.by.ToolClass.ISqlLocation
    {
        public System.Collections.Generic.Dictionary<string, string> SqlLocationDic
        {
            get
            {
                return this.SqlLocalDic;
            }
        }

        public readonly System.Collections.Generic.Dictionary<string, string> SqlLocalDic = new System.Collections.Generic.Dictionary<string, string>();

        public SqlLocation()
        {
            SqlLocalDic.Add("_0", "D:\\byForm\\src\\lib\\byLog.byz!\\identity.skill.by 行：28 列：17 ");

        }
    }
}
