package $Ku.byBase.Action;

import java.util.ArrayList;
import $Ku.by.JsonUtils.*;
public class ActionIndex {
    public static $Ku.by.Object.Result _0($Ku.byBase.Identity.Tree f_Identity, $Ku.by.ToolClass.Parse f_Parse, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null){
            throw new RuntimeException();
        }
        ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        Class<?> tmpP0Type = $Ku.by.Object.Row[].class;
        JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
        if(tmpJsonP0 == null)
        {
            throw new RuntimeException();
        }
        $Ku.by.Object.Row[] tmpP0 = ($Ku.by.Object.Row[])f_Parse.parseArray(tmpP0Type, tmpJsonP0);

        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonObject)
        {
            JsonObject tmpJsonP1 = (JsonObject)tmpParameterList.get(1);
            tmpP1 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP1));
        } else {
            if(!(tmpParameterList.get(1) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        return f_Identity.remove.invoke(f_Identity, tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Result _1($Ku.byBase.Identity.Tree f_Identity, $Ku.by.ToolClass.Parse f_Parse, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null){
            throw new RuntimeException();
        }
        ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        $Ku.by.Object.Row tmpP0 = null;

        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.Row)(f_Parse.parseObject(tmpJsonP0));
        } else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonObject)
        {
            JsonObject tmpJsonP1 = (JsonObject)tmpParameterList.get(1);
            tmpP1 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP1));
        } else {
            if(!(tmpParameterList.get(1) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP2 = null;
        if(tmpParameterList.get(2) instanceof JsonObject)
        {
            JsonObject tmpJsonP2 = (JsonObject)tmpParameterList.get(2);
            tmpP2 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP2));
        } else {
            if(!(tmpParameterList.get(2) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP3 = null;
        if(tmpParameterList.get(3) instanceof JsonObject)
        {
            JsonObject tmpJsonP3 = (JsonObject)tmpParameterList.get(3);
            tmpP3 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP3));
        } else {
            if(!(tmpParameterList.get(3) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        return f_Identity.modify.invoke(f_Identity, tmpP0, tmpP1, tmpP2, tmpP3);
    }

    public static $Ku.by.Object.Result _2($Ku.byBase.Identity.Tree f_Identity, $Ku.by.ToolClass.Parse f_Parse, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null){
            throw new RuntimeException();
        }
        ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        $Ku.by.Object.Row tmpP0 = null;

        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.Row)(f_Parse.parseObject(tmpJsonP0));
        } else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonObject)
        {
            JsonObject tmpJsonP1 = (JsonObject)tmpParameterList.get(1);
            tmpP1 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP1));
        } else {
            if(!(tmpParameterList.get(1) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        return f_Identity.add.invoke(f_Identity, tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Result _3($Ku.byBase.Identity.bridge f_Identity, $Ku.by.ToolClass.Parse f_Parse, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null){
            throw new RuntimeException();
        }
        ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP0));
        } else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        return f_Identity.add.invoke(f_Identity, tmpP0);
    }

    public static $Ku.by.Object.Result _4($Ku.byBase.Identity.bridge f_Identity, $Ku.by.ToolClass.Parse f_Parse, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null){
            throw new RuntimeException();
        }
        ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP0));
        } else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonObject)
        {
            JsonObject tmpJsonP1 = (JsonObject)tmpParameterList.get(1);
            tmpP1 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP1));
        } else {
            if(!(tmpParameterList.get(1) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        return f_Identity.change.invoke(f_Identity, tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Result _5($Ku.byBase.Identity.bridge f_Identity, $Ku.by.ToolClass.Parse f_Parse, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Parameters == null){
            throw new RuntimeException();
        }
        ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        $Ku.by.Object.List<$Ku.by.Object.Row> tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.by.Object.List<$Ku.by.Object.Row>)(f_Parse.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class),tmpJsonP0));
        } else {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw new RuntimeException();
            }
        }

        return f_Identity.delete.invoke(f_Identity, tmpP0);
    }
}
