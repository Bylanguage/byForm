using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.byBase.Action
{
    public class ActionIndex
    {
        public static byForm_Server.ku.by.Object.Result _0(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            ku.by.Object.Row[] tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.Row[]);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.Row[];
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.remove", "f_treeRows"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.remove", "f_slaveDelete"));
                }
            }


            return (f_Identity as ku.byBase.Identity.Tree).Execute_remove(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.Result _1(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.modify", "f_treeRow"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.modify", "f_slaveAdd"));
                }
            }

            ku.by.Object.list<ku.by.Object.Row> tmpP2 = null;
            Type tmpP2Type = typeof(ku.by.Object.list<ku.by.Object.Row>);
            if (tmpParameterList[2] is JsonObject)
            {
                var tmpJsonP2 = tmpParameterList[2] as JsonObject;
                tmpP2 = f_Parse.ParseObject(tmpJsonP2, tmpP2Type) as ku.by.Object.list<ku.by.Object.Row>;
            }
            else
            {
                if (!(tmpParameterList[2] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.modify", "f_slaveUpdate"));
                }
            }

            ku.by.Object.list<ku.by.Object.Row> tmpP3 = null;
            Type tmpP3Type = typeof(ku.by.Object.list<ku.by.Object.Row>);
            if (tmpParameterList[3] is JsonObject)
            {
                var tmpJsonP3 = tmpParameterList[3] as JsonObject;
                tmpP3 = f_Parse.ParseObject(tmpJsonP3, tmpP3Type) as ku.by.Object.list<ku.by.Object.Row>;
            }
            else
            {
                if (!(tmpParameterList[3] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.modify", "f_slaveDelete"));
                }
            }


            return (f_Identity as ku.byBase.Identity.Tree).Execute_modify(tmpP0, tmpP1, tmpP2, tmpP3);
        }

        public static byForm_Server.ku.by.Object.Result _2(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.add", "f_treeRow"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.Tree.add", "f_slaveAdd"));
                }
            }


            return (f_Identity as ku.byBase.Identity.Tree).Execute_add(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.Result _3(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.bridge.add", "f_bridgeRowList"));
                }
            }


            return (f_Identity as ku.byBase.Identity.bridge).Execute_add(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _4(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.bridge.change", "f_bridgeAddList"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.bridge.change", "f_bridgeDeleteList"));
                }
            }


            return (f_Identity as ku.byBase.Identity.bridge).Execute_change(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.Result _5(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byBase.identity.bridge.delete", "f_bridgeRowList"));
                }
            }


            return (f_Identity as ku.byBase.Identity.bridge).Execute_delete(tmpP0);
        }
    }
}
