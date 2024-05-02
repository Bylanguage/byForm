package $Ku.byBase.Skill;

import $Ku.by.JsonUtils.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.ErrorInfo;
public class SkillIndex {
    public static java.lang.Boolean _2($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byBase.Identity.TableSafe)f_Identity).confirmUserIsLogin();
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _3($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.QueryData tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.QueryData)f_Parse.parseObject(tmpJsonP0);
        }
        else
        {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.popupTable.popupLoad", "f_QueryData"));
        }
        }

        return (($Ku.byBase.Identity.popupTable)f_Identity).popupLoad(tmpP0);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _4($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.QueryData tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.QueryData)f_Parse.parseObject(tmpJsonP0);
        }
        else
        {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.Tree.popupLoad", "f_QueryData"));
        }
        }

        return (($Ku.byBase.Identity.Tree)f_Identity).popupLoad(tmpP0);
    }

    public static java.lang.Boolean _16($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byBase.Identity.Tree)f_Identity).confirmUserIsLogin();
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _17($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP0));
        } 
        else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.bridge.load", "f_selectRowList"));
           }
        }

        $Ku.by.Enum.MouseButton tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = Enum.valueOf($Ku.by.Enum.MouseButton.class, tmpJsonP1.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.bridge.load", "f_leftRight"));
        }


        return (($Ku.byBase.Identity.bridge)f_Identity).load(tmpP0, tmpP1);
    }

    public static void _18($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP0));
        } 
        else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.bridge.addDeleteUpdate", "f_addList"));
           }
        }

        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonObject)
        {
            JsonObject tmpJsonP1 = (JsonObject)tmpParameterList.get(1);
            tmpP1 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP1));
        } 
        else {
            if(!(tmpParameterList.get(1) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.bridge.addDeleteUpdate", "f_deleteList"));
           }
        }


        (($Ku.byBase.Identity.bridge)f_Identity).addDeleteUpdate(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Row _21($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        String tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonString)
        {
            JsonString tmpJsonP0 = (JsonString)tmpParameterList.get(0);
            tmpP0 = tmpJsonP0.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(0) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.extend.load", "f_ID"));
           }
        }

        return (($Ku.byBase.Identity.extend)f_Identity).load(tmpP0);
    }

    public static java.lang.Integer _22($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.Row tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.Row)f_Parse.parseObject(tmpJsonP0);
        }
        else
        {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.extend.addUpdateDelete", "f_row"));
        }
        }
        $Ku.by.Enum.Action tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = Enum.valueOf($Ku.by.Enum.Action.class, tmpJsonP1.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.extend.addUpdateDelete", "f_action"));
        }


        return (($Ku.byBase.Identity.extend)f_Identity).addUpdateDelete(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _23($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.Row tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.Row)f_Parse.parseObject(tmpJsonP0);
        }
        else
        {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.detail.load", "f_row"));
        }
        }

        return (($Ku.byBase.Identity.detail)f_Identity).load(tmpP0);
    }

    public static $Ku.by.Object.Result _24($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.Row tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.Row)f_Parse.parseObject(tmpJsonP0);
        }
        else
        {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.dic.addModifDelete", "f_row"));
        }
        }
        $Ku.by.Enum.Action tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = Enum.valueOf($Ku.by.Enum.Action.class, tmpJsonP1.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.dic.addModifDelete", "f_action"));
        }


        return (($Ku.byBase.Identity.dic)f_Identity).addModifDelete(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _26($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP0));
        } 
        else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.dic.load", "f_selectRowList"));
           }
        }

        $Ku.by.Object.QueryData tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonObject)
        {
            JsonObject tmpJsonP1 = (JsonObject)tmpParameterList.get(1);
            tmpP1 = ($Ku.by.Object.QueryData)f_Parse.parseObject(tmpJsonP1);
        }
        else
        {
            if(!(tmpParameterList.get(1) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byBase.Identity.dic.load", "f_QueryData"));
        }
        }

        return (($Ku.byBase.Identity.dic)f_Identity).load(tmpP0, tmpP1);
    }
}
