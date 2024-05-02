package $Ku.byUser.Skill;

import $Ku.by.JsonUtils.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.ErrorInfo;
public class SkillIndex {
    public static java.lang.Boolean _0($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.byUser.Object.resultUser tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.byUser.Object.resultUser)f_Parse.parseObject(tmpJsonP0);
        }
        else
        {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userLoginChild", "f_resultValue"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userLoginChild", "f_user"));
           }
        }
        String tmpP2 = null;
        if(tmpParameterList.get(2) instanceof JsonString)
        {
            JsonString tmpJsonP2 = (JsonString)tmpParameterList.get(2);
            tmpP2 = tmpJsonP2.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(2) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userLoginChild", "f_pwd"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).userLoginChild(tmpP0, tmpP1, tmpP2);
    }

    public static $Ku.byUser.Object.resultUser _1($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userLogin", "f_user"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userLogin", "f_pwd"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).userLogin(tmpP0, tmpP1);
    }

    public static java.lang.Boolean _2($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byUser.Identity.user)f_Identity).confirmUserIsLogin();
    }

    public static java.lang.Boolean _3($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.byUser.Enum.confirmUserIsLoginMode tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonString)
        {
            JsonString tmpJsonP0 = (JsonString)tmpParameterList.get(0);
            tmpP0 = Enum.valueOf($Ku.byUser.Enum.confirmUserIsLoginMode.class, tmpJsonP0.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.confirmUserIsLogin", "f_verifyMode"));
        }


        return (($Ku.byUser.Identity.user)f_Identity).confirmUserIsLogin(tmpP0);
    }

    public static java.lang.Boolean _4($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.confirmUserIsLogin", "f_userID"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).confirmUserIsLogin(tmpP0);
    }

    public static void _8($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        (($Ku.byUser.Identity.user)f_Identity).exit();
    }

    public static $Ku.by.Object.Result _9($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userReg", "f_userRow"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userReg", "f_SafetyCode"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).userReg(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Result _10($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userReg", "f_userRow"));
        }
        }

        return (($Ku.byUser.Identity.user)f_Identity).userReg(tmpP0);
    }

    public static $Ku.by.Object.Result _11($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userPwdModif", "f_sourcePwd"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userPwdModif", "f_newPwd"));
           }
        }
        String tmpP2 = null;
        if(tmpParameterList.get(2) instanceof JsonString)
        {
            JsonString tmpJsonP2 = (JsonString)tmpParameterList.get(2);
            tmpP2 = tmpJsonP2.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(2) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userPwdModif", "f_ID"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).userPwdModif(tmpP0, tmpP1, tmpP2);
    }

    public static $Ku.by.Object.Result _12($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userPwdModif", "f_userMailMobile"));
           }
        }
        $Ku.byUser.Enum.safetyCodeMode tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = Enum.valueOf($Ku.byUser.Enum.safetyCodeMode.class, tmpJsonP1.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userPwdModif", "f_safetyCodeMode"));
        }

        String tmpP2 = null;
        if(tmpParameterList.get(2) instanceof JsonString)
        {
            JsonString tmpJsonP2 = (JsonString)tmpParameterList.get(2);
            tmpP2 = tmpJsonP2.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(2) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userPwdModif", "f_newPwd"));
           }
        }
        String tmpP3 = null;
        if(tmpParameterList.get(3) instanceof JsonString)
        {
            JsonString tmpJsonP3 = (JsonString)tmpParameterList.get(3);
            tmpP3 = tmpJsonP3.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(3) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userPwdModif", "f_safetyCode"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).userPwdModif(tmpP0, tmpP1, tmpP2, tmpP3);
    }

    public static java.lang.String _13($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyMobileFormat", "f_mobile"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyMobileFormat(tmpP0);
    }

    public static java.lang.Boolean _14($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyMobileExists", "f_mobile"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyMobileExists(tmpP0);
    }

    public static java.lang.String _15($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyRegMail", "f_mail"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyRegMail(tmpP0);
    }

    public static java.lang.String _16($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyMailFormat", "f_mail"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyMailFormat(tmpP0);
    }

    public static $Ku.by.Object.Result _17($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyMailExists", "f_mail"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyMailExists(tmpP0);
    }

    public static java.lang.Boolean _18($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifySafetyCodeFormat", "f_SafetyCode"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifySafetyCodeFormat(tmpP0);
    }

    public static $Ku.by.Object.Result _19($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifySafetyCode", "f_safetyCode"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifySafetyCode(tmpP0);
    }

    public static $Ku.by.Object.Result _20($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyCookies", "f_cookie"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyCookies(tmpP0);
    }

    public static java.lang.Integer _21($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byUser.Identity.user)f_Identity).generateSafetyCode();
    }

    public static $Ku.by.Object.Result _22($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.byUser.Enum.safetyCodeMode tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonString)
        {
            JsonString tmpJsonP0 = (JsonString)tmpParameterList.get(0);
            tmpP0 = Enum.valueOf($Ku.byUser.Enum.safetyCodeMode.class, tmpJsonP0.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.postSafety", "f_safetyCodeMode"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.postSafety", "f_userMobileMail"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).postSafety(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Result _23($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.postSafetyModbile", "f_mobile"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).postSafetyModbile(tmpP0);
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.postSafetyMail", "f_mail"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).postSafetyMail(tmpP0);
    }

    public static $Ku.by.Object.Result _25($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.postSafetyReg", "f_mail"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.postSafetyReg", "f_mobile"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).postSafetyReg(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Result _26($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.postSafetyCodeToMobile", "f_mobile"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).postSafetyCodeToMobile(tmpP0);
    }

    public static $Ku.by.Object.Result _27($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.postSafetyCodeToMail", "f_mail"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).postSafetyCodeToMail(tmpP0);
    }

    public static $Ku.byUser.Object.resultUser _28($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byUser.Identity.user)f_Identity).getAnonymousUser();
    }

    public static $Ku.byUser.Object.resultUser _29($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        $Ku.byUser.Object.resultUser tmpP0 = null;
        if(tmpParameterList.get(0) instanceof JsonObject)
        {
            JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
            tmpP0 = ($Ku.byUser.Object.resultUser)f_Parse.parseObject(tmpJsonP0);
        }
        else
        {
            if(!(tmpParameterList.get(0) instanceof JsonNull))
            {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.createAnonymousUser", "f_resultUser"));
        }
        }

        return (($Ku.byUser.Identity.user)f_Identity).createAnonymousUser(tmpP0);
    }

    public static $Ku.byUser.Orm.Orm0 _30($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byUser.Identity.user)f_Identity).getSessionUserRow();
    }

    public static void _32($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        (($Ku.byUser.Identity.user)f_Identity).init();
    }

    public static void _33($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        (($Ku.byUser.Identity.user)f_Identity).generateRsaKey();
    }

    public static java.lang.String _34($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byUser.Identity.user)f_Identity).getPublicKey();
    }

    public static java.lang.Boolean _35($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.regPublicKey", "f_publicKey"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).regPublicKey(tmpP0);
    }

    public static java.lang.String _36($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.rsaEncode", "f_encede"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).rsaEncode(tmpP0);
    }

    public static java.lang.String _37($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.rsaDecode", "f_decode"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).rsaDecode(tmpP0);
    }

    public static java.lang.String _38($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.md5Plus", "f_sourcePwd"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).md5Plus(tmpP0);
    }

    public static java.lang.String _39($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyPwd", "f_pwd"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyPwd(tmpP0);
    }

    public static java.lang.String _40($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyUserFormat", "f_user"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyUserFormat(tmpP0);
    }

    public static java.lang.String _41($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.verifyRegisterUser", "f_user"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).verifyRegisterUser(tmpP0);
    }

    public static java.lang.Boolean _42($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.user.userExists", "f_user"));
           }
        }

        return (($Ku.byUser.Identity.user)f_Identity).userExists(tmpP0);
    }

    public static java.lang.String _44($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.getIcoUrlPath", "f_pathICO"));
           }
        }

        return (($Ku.byUser.Identity.userICO)f_Identity).getIcoUrlPath(tmpP0);
    }

    public static java.lang.String _45($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.getIcoDiskPath", "f_fileName"));
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.getIcoDiskPath", "f_extendName"));
           }
        }
        $Ku.byUser.Enum.uploadMode tmpP2 = null;
        if(tmpParameterList.get(2) instanceof JsonString)
        {
            JsonString tmpJsonP2 = (JsonString)tmpParameterList.get(2);
            tmpP2 = Enum.valueOf($Ku.byUser.Enum.uploadMode.class, tmpJsonP2.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.getIcoDiskPath", "f_uploadMode"));
        }


        return (($Ku.byUser.Identity.userICO)f_Identity).getIcoDiskPath(tmpP0, tmpP1, tmpP2);
    }

    public static java.lang.String _46($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.getIcoDiskPath", "f_fileFullName"));
           }
        }
        $Ku.byUser.Enum.uploadMode tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = Enum.valueOf($Ku.byUser.Enum.uploadMode.class, tmpJsonP1.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.getIcoDiskPath", "f_uploadMode"));
        }


        return (($Ku.byUser.Identity.userICO)f_Identity).getIcoDiskPath(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.Result _47($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        java.util.ArrayList<IJsonValue> tmpParameterList = f_Parameters.getValues();
        
        Class<?> tmpP0Type = java.lang.Byte[].class;
        JsonObject tmpJsonP0 = (JsonObject)tmpParameterList.get(0);
        if(tmpJsonP0 == null)
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.fileUpload", "f_fileBytes"));
        }
        java.lang.Byte[] tmpP0 = (java.lang.Byte[])f_Parse.parseArray(tmpP0Type, tmpJsonP0);

        $Ku.byUser.Enum.uploadMode tmpP1 = null;
        if(tmpParameterList.get(1) instanceof JsonString)
        {
            JsonString tmpJsonP1 = (JsonString)tmpParameterList.get(1);
            tmpP1 = Enum.valueOf($Ku.byUser.Enum.uploadMode.class, tmpJsonP1.getValue());
        }
        else
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.fileUpload", "f_dirMode"));
        }

        String tmpP2 = null;
        if(tmpParameterList.get(2) instanceof JsonString)
        {
            JsonString tmpJsonP2 = (JsonString)tmpParameterList.get(2);
            tmpP2 = tmpJsonP2.getValue();
        }
        else
        {
            if (!(tmpParameterList.get(2) instanceof JsonNull))
           {
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userICO.fileUpload", "f_extendName"));
           }
        }

        return (($Ku.byUser.Identity.userICO)f_Identity).fileUpload(tmpP0, tmpP1, tmpP2);
    }

    public static $Ku.by.Object.Row _48($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userAdmin.getAdmin", "f_userID"));
           }
        }

        return (($Ku.byUser.Identity.userAdmin)f_Identity).getAdmin(tmpP0);
    }

    public static java.lang.Boolean _49($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byUser.Identity.userAdmin)f_Identity).isAdmin();
    }

    public static $Ku.by.Object.List<$Ku.byUser.Orm.Orm1> _50($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byUser.Identity.userAdmin)f_Identity).getAdmin();
    }

    public static $Ku.by.Object.Result _51($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
                throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userAdmin.adminAddRemove", "f_adminRow"));
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
            throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userAdmin.adminAddRemove", "f_action"));
        }


        return (($Ku.byUser.Identity.userAdmin)f_Identity).adminAddRemove(tmpP0, tmpP1);
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> _52($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
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
              throw $Ku.by.ToolClass.ThrowHelper.ThrowFuncException(String.format(ErrorInfo.FuncTypeMatchError, "byUser.Identity.userAdmin.getPopupUser", "f_keyword"));
           }
        }

        return (($Ku.byUser.Identity.userAdmin)f_Identity).getPopupUser(tmpP0);
    }

    public static java.lang.Boolean _53($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        return (($Ku.byUser.Identity.userAdmin)f_Identity).isFirstRun();
    }

    public static void _54($Ku.by.ToolClass.Parse f_Parse, $Ku.by.ToolClass.AbstractIdentityBase f_Identity, $Ku.by.JsonUtils.JsonArray f_Parameters) {
        if(f_Identity == null)
        {
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.IdentityIsNull);
        }
        
        if(f_Parameters == null)
        {
            throw new RuntimeException();
        }
        

        (($Ku.byUser.Identity.userAdmin)f_Identity).initInsertAdmin();
    }
}
