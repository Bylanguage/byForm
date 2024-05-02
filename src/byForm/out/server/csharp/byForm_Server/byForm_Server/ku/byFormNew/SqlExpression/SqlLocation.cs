using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byFormNew.SqlExpression
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
            
        }
    }
}
