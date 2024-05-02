package $Ku.byForm.Skill;

import $Ku.by.JsonUtils.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.ErrorInfo;
public class SkillIndex {
    public static java.lang.Integer _10($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.formField.addUpdate", "f_formField"));
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
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.formField.addUpdate", "action"));
        }


        return (($Ku.byForm.Identity.formField)f_Identity).addUpdate(tmpP0, tmpP1);
    }

    public static void _12($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.formField.delByFormId", "formID"));
           }
        }

        (($Ku.byForm.Identity.formField)f_Identity).delByFormId(tmpP0);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row>[] _15($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.form.load", "f_userID"));
           }
        }

        return (($Ku.byForm.Identity.form)f_Identity).load(tmpP0);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row>[] _16($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.form.loadSingle", "f_FormID"));
           }
        }

        return (($Ku.byForm.Identity.form)f_Identity).loadSingle(tmpP0);
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.form.loadVDataSingle", "f_FormID"));
           }
        }

        return (($Ku.byForm.Identity.form)f_Identity).loadVDataSingle(tmpP0);
    }

    public static $Ku.by.Object.Result _18($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.form.update", "f_list"));
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
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.form.update", "f_action"));
        }


        return (($Ku.byForm.Identity.form)f_Identity).update(tmpP0, tmpP1);
    }

    public static void _24($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.form.saveField", "f_formField"));
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
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.form.saveField", "action"));
        }


        (($Ku.byForm.Identity.form)f_Identity).saveField(tmpP0, tmpP1);
    }

    public static void _25($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.form.delFieldByFormId", "formID"));
           }
        }

        (($Ku.byForm.Identity.form)f_Identity).delFieldByFormId(tmpP0);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _33($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byForm.Identity.fieldTemplate)f_Identity).getList();
    }

    public static $Ku.by.Object.Row _34($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byForm.Identity.fieldTemplate.getFieldTemplate", "id"));
           }
        }

        return (($Ku.byForm.Identity.fieldTemplate)f_Identity).getFieldTemplate(tmpP0);
    }
}
