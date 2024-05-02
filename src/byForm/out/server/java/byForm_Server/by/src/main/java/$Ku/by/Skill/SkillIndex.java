package $Ku.by.Skill;

import $Ku.by.JsonUtils.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.ErrorInfo;
public class SkillIndex {
    public static void _8($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        Class<?> tmpP0Type = java.lang.String[].class;
        JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
        if(tmpJsonP0 == null)
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "by.Identity.Sys.start", "args"));
        }
        java.lang.String[] tmpP0 = (java.lang.String[])f_Parse.parseArray(tmpP0Type, tmpJsonP0);


        (($Ku.by.Identity.Sys)f_Identity).start(tmpP0);
    }
}
