using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.byBase.Skill
{
    public class SkillIndex
    {
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
            

            return (f_Identity as ku.byBase.Identity.TableSafe).confirmUserIsLogin();
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _3(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.by.Object.QueryData tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.QueryData);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.QueryData;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.popupTable.popupLoad", "f_QueryData"));
                }
            }


            return (f_Identity as ku.byBase.Identity.popupTable).popupLoad(tmpP0);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _4(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.by.Object.QueryData tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.QueryData);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.QueryData;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.popupLoad", "f_QueryData"));
                }
            }


            return (f_Identity as ku.byBase.Identity.Tree).popupLoad(tmpP0);
        }

        public static bool _16(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byBase.Identity.Tree).confirmUserIsLogin();
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _17(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.by.Object.list<ku.by.Object.Row> tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.list<ku.by.Object.Row>);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.list<ku.by.Object.Row>;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.bridge.load", "f_selectRowList"));
                }
            }

            ku.by.Enum.MouseButton tmpP1;
            var tmpP1Type = typeof(ku.by.Enum.MouseButton);
            if (tmpParameterList[1] is StringClass)
            {
                var tmpJsonP1 = tmpParameterList[1] as StringClass;
                tmpP1 = (ku.by.Enum.MouseButton)System.Enum.Parse(tmpP1Type, tmpJsonP1.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.bridge.load", "f_leftRight"));
            }


            return (f_Identity as ku.byBase.Identity.bridge).load(tmpP0, tmpP1);
        }

        public static void _18(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.by.Object.list<ku.by.Object.Row> tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.list<ku.by.Object.Row>);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.list<ku.by.Object.Row>;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.bridge.addDeleteUpdate", "f_addList"));
                }
            }

            ku.by.Object.list<ku.by.Object.Row> tmpP1 = null;
            Type tmpP1Type = typeof(ku.by.Object.list<ku.by.Object.Row>);
            if (tmpParameterList[1] is JsonObject)
            {
                var tmpJsonP1 = tmpParameterList[1] as JsonObject;
                tmpP1 = f_Parse.ParseObject(tmpJsonP1, tmpP1Type) as ku.by.Object.list<ku.by.Object.Row>;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.bridge.addDeleteUpdate", "f_deleteList"));
                }
            }


            (f_Identity as ku.byBase.Identity.bridge).addDeleteUpdate(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.Row _21(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.extend.load", "f_ID"));
                }
            }


            return (f_Identity as ku.byBase.Identity.extend).load(tmpP0);
        }

        public static int _22(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.extend.addUpdateDelete", "f_row"));
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
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.extend.addUpdateDelete", "f_action"));
            }


            return (f_Identity as ku.byBase.Identity.extend).addUpdateDelete(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _23(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.detail.load", "f_row"));
                }
            }


            return (f_Identity as ku.byBase.Identity.detail).load(tmpP0);
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.dic.addModifDelete", "f_row"));
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
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.dic.addModifDelete", "f_action"));
            }


            return (f_Identity as ku.byBase.Identity.dic).addModifDelete(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _26(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.by.Object.list<ku.by.Object.Row> tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.list<ku.by.Object.Row>);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.list<ku.by.Object.Row>;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.dic.load", "f_selectRowList"));
                }
            }

            ku.by.Object.QueryData tmpP1 = null;
            Type tmpP1Type = typeof(ku.by.Object.QueryData);
            if (tmpParameterList[1] is JsonObject)
            {
                var tmpJsonP1 = tmpParameterList[1] as JsonObject;
                tmpP1 = f_Parse.ParseObject(tmpJsonP1, tmpP1Type) as ku.by.Object.QueryData;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.dic.load", "f_QueryData"));
                }
            }


            return (f_Identity as ku.byBase.Identity.dic).load(tmpP0, tmpP1);
        }
    }
}
