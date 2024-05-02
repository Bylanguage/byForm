using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.byFormNew.Skill
{
    public class SkillIndex
    {
        public static void _1(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string[] tmpP0 = null;
            Type tmpP0Type = typeof(string[]);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as string[];
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byFormNew.identity.ServerStartup.main", "args"));
                }
            }


            ku.byFormNew.Identity.ServerStartup.main(tmpP0);
        }
    }
}
