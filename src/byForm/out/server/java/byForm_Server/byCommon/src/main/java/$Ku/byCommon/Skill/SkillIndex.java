package $Ku.byCommon.Skill;

import $Ku.by.JsonUtils.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.ErrorInfo;
public class SkillIndex {
    public static $Ku.by.Object.List<$Ku.by.Object.Row> _8($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedTable.cloneListRow", "f_sourceList"));
           }
        }


        return $Ku.byCommon.Identity.relatedTable.cloneListRow(tmpP0);
    }

    public static java.lang.Boolean _15($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedTable.isExists", "f_sourceRow"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedTable.isExists", "f_targetList"));
           }
        }


        return $Ku.byCommon.Identity.relatedTable.isExists(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _16($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedTable.isExists", "f_sourceList"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedTable.isExists", "f_targetList"));
           }
        }


        return $Ku.byCommon.Identity.relatedTable.isExists(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _17($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedTable.isNotExists", "f_sourceList"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedTable.isNotExists", "f_targetList"));
           }
        }


        return $Ku.byCommon.Identity.relatedTable.isNotExists(tmpP0, tmpP1);
    }

    public static java.lang.String _19($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return $Ku.byCommon.Identity.general.getGuidPrefix();
    }

    public static java.lang.String _20($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return $Ku.byCommon.Identity.general.getGuid();
    }

    public static java.lang.String _21($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.getPlusZero", "f_num"));
           }
        }
        Integer tmpP1 = 0;
        JsonNumber tmpJsonP1 = (JsonNumber)tmpParameterList.get(1);
        if(tmpJsonP1 == null)
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.getPlusZero", "f_length"));
        }
        tmpP1 = Integer.parseInt(tmpJsonP1.getNumberStr());

        return $Ku.byCommon.Identity.general.getPlusZero(tmpP0, tmpP1);
    }

    public static java.lang.String _22($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.List<String> tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.List<String>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class),tmpJsonP0));
        } 
        else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.getNoRepeatName", "f_list"));
           }
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.getNoRepeatName", "f_name"));
           }
        }

        return $Ku.byCommon.Identity.general.getNoRepeatName(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Datetime _23($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return $Ku.byCommon.Identity.general.getServerDatetime();
    }

    public static java.lang.String _24($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.joinString", "f_sourceOldStr"));
           }
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.joinString", "f_newStr"));
           }
        }

        return $Ku.byCommon.Identity.general.joinString(tmpP0, tmpP1);
    }

    public static java.lang.String _25($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.getIDGroup", "f_list"));
           }
        }


        return $Ku.byCommon.Identity.general.getIDGroup(tmpP0);
    }

    public static java.lang.Boolean _26($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.contains", "f_str1"));
           }
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.contains", "f_str2"));
           }
        }

        return $Ku.byCommon.Identity.general.contains(tmpP0, tmpP1);
    }

    public static java.lang.Boolean _27($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.by.Object.List<String> tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.List<String>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class),tmpJsonP0));
        } 
        else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.contains", "f_stringList"));
           }
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.contains", "f_str"));
           }
        }

        return $Ku.byCommon.Identity.general.contains(tmpP0, tmpP1);
    }

    public static void _28($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.copyRow", "f_Row"));
        }
        }
        $Ku.by.Object.Row tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonObject)
        {
            JsonObject tmpJsonP1 = (JsonObject)tmpParameterList.get(1);
            tmpP1 = ($Ku.by.Object.Row)f_Parse.parseObject(tmpJsonP1);
        }
        else
        {
            if(!(tmpParameterList.get(1) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.general.copyRow", "f_copy"));
        }
        }

        $Ku.byCommon.Identity.general.copyRow(tmpP0, tmpP1);
    }

    public static java.lang.String _35($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedField.getFieldValue", "f_row"));
        }
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedField.getFieldValue", "f_fieldNmae"));
           }
        }

        return $Ku.byCommon.Identity.relatedField.getFieldValue(tmpP0, tmpP1);
    }

    public static java.lang.String _36($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedField.getFieldSummery", "f_row"));
        }
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byCommon.Identity.relatedField.getFieldSummery", "f_fieldNmae"));
           }
        }

        return $Ku.byCommon.Identity.relatedField.getFieldSummery(tmpP0, tmpP1);
    }
}
