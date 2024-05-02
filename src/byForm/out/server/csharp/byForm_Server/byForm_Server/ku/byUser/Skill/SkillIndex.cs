using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.byUser.Skill
{
    public class SkillIndex
    {
        public static bool _0(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.byUser.Object.resultUser tmpP0 = null;
            Type tmpP0Type = typeof(ku.byUser.Object.resultUser);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.byUser.Object.resultUser;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userLoginChild", "f_resultValue"));
                }
            }

            string tmpP1 = null;
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = tmpJsonP1.Value;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userLoginChild", "f_user"));
                }
            }

            string tmpP2 = null;
            if (tmpParameterList[2] is StringClass)
            {
                var tmpJsonP2 = tmpParameterList[2] as StringClass;
                tmpP2 = tmpJsonP2.Value;
            }
            else
            {
                if (!(tmpParameterList[2] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userLoginChild", "f_pwd"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).userLoginChild(tmpP0, tmpP1, tmpP2);
        }

        public static byForm_Server.ku.byUser.Object.resultUser _1(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userLogin", "f_user"));
                }
            }

            string tmpP1 = null;
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = tmpJsonP1.Value;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userLogin", "f_pwd"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).userLogin(tmpP0, tmpP1);
        }

        public static bool _2(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byUser.Identity.user).confirmUserIsLogin();
        }

        public static bool _3(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.byUser.Enum.confirmUserIsLoginMode tmpP0;
            var tmpP0Type = typeof(ku.byUser.Enum.confirmUserIsLoginMode);
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = (ku.byUser.Enum.confirmUserIsLoginMode)System.Enum.Parse(tmpP0Type, tmpJsonP0.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.confirmUserIsLogin", "f_verifyMode"));
            }


            return (f_Identity as ku.byUser.Identity.user).confirmUserIsLogin_(tmpP0);
        }

        public static bool _4(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.confirmUserIsLogin", "f_userID"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).confirmUserIsLogin_(tmpP0);
        }

        public static void _8(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            (f_Identity as ku.byUser.Identity.user).exit();
        }

        public static byForm_Server.ku.by.Object.Result _9(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.by.Object.Row tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.Row);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.Row;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userReg", "f_userRow"));
                }
            }

            string tmpP1 = null;
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = tmpJsonP1.Value;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userReg", "f_SafetyCode"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).userReg(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.Result _10(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.by.Object.Row tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.Row);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.Row;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userReg", "f_userRow"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).userReg_(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _11(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userPwdModif", "f_sourcePwd"));
                }
            }

            string tmpP1 = null;
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = tmpJsonP1.Value;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userPwdModif", "f_newPwd"));
                }
            }

            string tmpP2 = null;
            if (tmpParameterList[2] is StringClass)
            {
                var tmpJsonP2 = tmpParameterList[2] as StringClass;
                tmpP2 = tmpJsonP2.Value;
            }
            else
            {
                if (!(tmpParameterList[2] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userPwdModif", "f_ID"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).userPwdModif(tmpP0, tmpP1, tmpP2);
        }

        public static byForm_Server.ku.by.Object.Result _12(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userPwdModif", "f_userMailMobile"));
                }
            }

            ku.byUser.Enum.safetyCodeMode tmpP1;
            var tmpP1Type = typeof(ku.byUser.Enum.safetyCodeMode);
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = (ku.byUser.Enum.safetyCodeMode)System.Enum.Parse(tmpP1Type, tmpJsonP1.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userPwdModif", "f_safetyCodeMode"));
            }

            string tmpP2 = null;
            if (tmpParameterList[2] is StringClass)
            {
                var tmpJsonP2 = tmpParameterList[2] as StringClass;
                tmpP2 = tmpJsonP2.Value;
            }
            else
            {
                if (!(tmpParameterList[2] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userPwdModif", "f_newPwd"));
                }
            }

            string tmpP3 = null;
            if (tmpParameterList[3] is StringClass)
            {
                var tmpJsonP3 = tmpParameterList[3] as StringClass;
                tmpP3 = tmpJsonP3.Value;
            }
            else
            {
                if (!(tmpParameterList[3] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userPwdModif", "f_safetyCode"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).userPwdModif_(tmpP0, tmpP1, tmpP2, tmpP3);
        }

        public static string _13(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyMobileFormat", "f_mobile"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyMobileFormat(tmpP0);
        }

        public static bool _14(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyMobileExists", "f_mobile"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyMobileExists(tmpP0);
        }

        public static string _15(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyRegMail", "f_mail"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyRegMail(tmpP0);
        }

        public static string _16(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyMailFormat", "f_mail"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyMailFormat(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _17(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyMailExists", "f_mail"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyMailExists(tmpP0);
        }

        public static bool _18(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifySafetyCodeFormat", "f_SafetyCode"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifySafetyCodeFormat(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _19(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifySafetyCode", "f_safetyCode"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifySafetyCode(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _20(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyCookies", "f_cookie"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyCookies(tmpP0);
        }

        public static int _21(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byUser.Identity.user).generateSafetyCode();
        }

        public static byForm_Server.ku.by.Object.Result _22(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.byUser.Enum.safetyCodeMode tmpP0;
            var tmpP0Type = typeof(ku.byUser.Enum.safetyCodeMode);
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = (ku.byUser.Enum.safetyCodeMode)System.Enum.Parse(tmpP0Type, tmpJsonP0.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.postSafety", "f_safetyCodeMode"));
            }

            string tmpP1 = null;
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = tmpJsonP1.Value;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.postSafety", "f_userMobileMail"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).postSafety(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.Result _23(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.postSafetyModbile", "f_mobile"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).postSafetyModbile(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _24(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.postSafetyMail", "f_mail"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).postSafetyMail(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _25(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.postSafetyReg", "f_mail"));
                }
            }

            string tmpP1 = null;
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = tmpJsonP1.Value;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.postSafetyReg", "f_mobile"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).postSafetyReg(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.Result _26(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.postSafetyCodeToMobile", "f_mobile"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).postSafetyCodeToMobile(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _27(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.postSafetyCodeToMail", "f_mail"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).postSafetyCodeToMail(tmpP0);
        }

        public static byForm_Server.ku.byUser.Object.resultUser _28(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byUser.Identity.user).getAnonymousUser();
        }

        public static byForm_Server.ku.byUser.Object.resultUser _29(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.byUser.Object.resultUser tmpP0 = null;
            Type tmpP0Type = typeof(ku.byUser.Object.resultUser);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.byUser.Object.resultUser;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.createAnonymousUser", "f_resultUser"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).createAnonymousUser(tmpP0);
        }

        public static byForm_Server.ku.byUser.Orm.Orm0 _30(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byUser.Identity.user).getSessionUserRow();
        }

        public static void _32(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            (f_Identity as ku.byUser.Identity.user).init();
        }

        public static void _33(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            (f_Identity as ku.byUser.Identity.user).generateRsaKey();
        }

        public static string _34(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byUser.Identity.user).getPublicKey();
        }

        public static bool _35(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.regPublicKey", "f_publicKey"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).regPublicKey(tmpP0);
        }

        public static string _36(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.rsaEncode", "f_encede"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).rsaEncode(tmpP0);
        }

        public static string _37(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.rsaDecode", "f_decode"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).rsaDecode(tmpP0);
        }

        public static string _38(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.md5Plus", "f_sourcePwd"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).md5Plus(tmpP0);
        }

        public static string _39(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyPwd", "f_pwd"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyPwd(tmpP0);
        }

        public static string _40(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyUserFormat", "f_user"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyUserFormat(tmpP0);
        }

        public static string _41(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.verifyRegisterUser", "f_user"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).verifyRegisterUser(tmpP0);
        }

        public static bool _42(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.user.userExists", "f_user"));
                }
            }


            return (f_Identity as ku.byUser.Identity.user).userExists(tmpP0);
        }

        public static string _44(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.getIcoUrlPath", "f_pathICO"));
                }
            }


            return (f_Identity as ku.byUser.Identity.userICO).getIcoUrlPath(tmpP0);
        }

        public static string _45(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.getIcoDiskPath", "f_fileName"));
                }
            }

            string tmpP1 = null;
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = tmpJsonP1.Value;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.getIcoDiskPath", "f_extendName"));
                }
            }

            ku.byUser.Enum.uploadMode tmpP2;
            var tmpP2Type = typeof(ku.byUser.Enum.uploadMode);
            if (tmpParameterList[2] is StringClass)
            {
                var tmpJsonP2 = tmpParameterList[2] as StringClass;
                tmpP2 = (ku.byUser.Enum.uploadMode)System.Enum.Parse(tmpP2Type, tmpJsonP2.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.getIcoDiskPath", "f_uploadMode"));
            }


            return (f_Identity as ku.byUser.Identity.userICO).getIcoDiskPath(tmpP0, tmpP1, tmpP2);
        }

        public static string _46(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.getIcoDiskPath", "f_fileFullName"));
                }
            }

            ku.byUser.Enum.uploadMode tmpP1;
            var tmpP1Type = typeof(ku.byUser.Enum.uploadMode);
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = (ku.byUser.Enum.uploadMode)System.Enum.Parse(tmpP1Type, tmpJsonP1.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.getIcoDiskPath", "f_uploadMode"));
            }


            return (f_Identity as ku.byUser.Identity.userICO).getIcoDiskPath_(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.Result _47(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            sbyte[] tmpP0 = null;
            Type tmpP0Type = typeof(sbyte[]);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as sbyte[];
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.fileUpload", "f_fileBytes"));
                }
            }

            ku.byUser.Enum.uploadMode tmpP1;
            var tmpP1Type = typeof(ku.byUser.Enum.uploadMode);
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = (ku.byUser.Enum.uploadMode)System.Enum.Parse(tmpP1Type, tmpJsonP1.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.fileUpload", "f_dirMode"));
            }

            string tmpP2 = null;
            if (tmpParameterList[2] is StringClass)
            {
                var tmpJsonP2 = tmpParameterList[2] as StringClass;
                tmpP2 = tmpJsonP2.Value;
            }
            else
            {
                if (!(tmpParameterList[2] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userICO.fileUpload", "f_extendName"));
                }
            }


            return (f_Identity as ku.byUser.Identity.userICO).fileUpload(tmpP0, tmpP1, tmpP2);
        }

        public static byForm_Server.ku.by.Object.Row _48(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userAdmin.getAdmin", "f_userID"));
                }
            }


            return (f_Identity as ku.byUser.Identity.userAdmin).getAdmin(tmpP0);
        }

        public static bool _49(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byUser.Identity.userAdmin).isAdmin();
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.byUser.Orm.Orm1> _50(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byUser.Identity.userAdmin).getAdmin_();
        }

        public static byForm_Server.ku.by.Object.Result _51(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.by.Object.Row tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.Row);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.Row;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userAdmin.adminAddRemove", "f_adminRow"));
                }
            }

            ku.by.Enum.Action tmpP1;
            var tmpP1Type = typeof(ku.by.Enum.Action);
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = (ku.by.Enum.Action)System.Enum.Parse(tmpP1Type, tmpJsonP1.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userAdmin.adminAddRemove", "f_action"));
            }


            return (f_Identity as ku.byUser.Identity.userAdmin).adminAddRemove(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _52(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            string tmpP0 = null;
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = tmpJsonP0.Value;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byUser.identity.userAdmin.getPopupUser", "f_keyword"));
                }
            }


            return (f_Identity as ku.byUser.Identity.userAdmin).getPopupUser(tmpP0);
        }

        public static bool _53(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byUser.Identity.userAdmin).isFirstRun();
        }

        public static void _54(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            (f_Identity as ku.byUser.Identity.userAdmin).initInsertAdmin();
        }
    }
}
