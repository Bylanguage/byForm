package $Ku.byLog.Skill;

import $Ku.by.JsonUtils.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.ErrorInfo;
public class SkillIndex {
    public static $Ku.by.Object.Row _0($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.byLog.Enum.logState tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonString)
        {
            JsonString tmpJsonP0 = (JsonString)tmpParameterList.get(0);
            tmpP0 = Enum.valueOf($Ku.byLog.Enum.logState.class, tmpJsonP0.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byLog.Identity.log.getRow", "f_logState"));
        }

        String tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = tmpJsonP1.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(1) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byLog.Identity.log.getRow", "f_content"));
           }
        }

        return (($Ku.byLog.Identity.log)f_Identity).getRow(tmpP0, tmpP1);
    }

    public static void _1($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.byLog.Enum.logState tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonString)
        {
            JsonString tmpJsonP0 = (JsonString)tmpParameterList.get(0);
            tmpP0 = Enum.valueOf($Ku.byLog.Enum.logState.class, tmpJsonP0.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byLog.Identity.log.writeTable", "f_logState"));
        }

        String tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = tmpJsonP1.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(1) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byLog.Identity.log.writeTable", "f_content"));
           }
        }

        (($Ku.byLog.Identity.log)f_Identity).writeTable(tmpP0, tmpP1);
    }

    public static void _2($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.byLog.Enum.logState tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonString)
        {
            JsonString tmpJsonP0 = (JsonString)tmpParameterList.get(0);
            tmpP0 = Enum.valueOf($Ku.byLog.Enum.logState.class, tmpJsonP0.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byLog.Identity.log.writeFile", "f_logState"));
        }

        String tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = tmpJsonP1.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(1) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byLog.Identity.log.writeFile", "f_content"));
           }
        }

        (($Ku.byLog.Identity.log)f_Identity).writeFile(tmpP0, tmpP1);
    }

    public static void _3($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.byLog.Enum.logState tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonString)
        {
            JsonString tmpJsonP0 = (JsonString)tmpParameterList.get(0);
            tmpP0 = Enum.valueOf($Ku.byLog.Enum.logState.class, tmpJsonP0.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byLog.Identity.log.write", "f_logState"));
        }

        String tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = tmpJsonP1.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(1) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byLog.Identity.log.write", "f_content"));
           }
        }

        (($Ku.byLog.Identity.log)f_Identity).write(tmpP0, tmpP1);
    }
}
