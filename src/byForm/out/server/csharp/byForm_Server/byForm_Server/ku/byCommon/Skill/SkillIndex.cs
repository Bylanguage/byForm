using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.byCommon.Skill
{
    public class SkillIndex
    {
        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _8(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedTable.cloneListRow", "f_sourceList"));
                }
            }


            return ku.byCommon.Identity.relatedTable.cloneListRow(tmpP0);
        }

        public static bool _15(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedTable.isExists", "f_sourceRow"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedTable.isExists", "f_targetList"));
                }
            }


            return ku.byCommon.Identity.relatedTable.isExists(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _16(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedTable.isExists", "f_sourceList"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedTable.isExists", "f_targetList"));
                }
            }


            return ku.byCommon.Identity.relatedTable.isExists_(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _17(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedTable.isNotExists", "f_sourceList"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedTable.isNotExists", "f_targetList"));
                }
            }


            return ku.byCommon.Identity.relatedTable.isNotExists(tmpP0, tmpP1);
        }

        public static string _19(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return ku.byCommon.Identity.general.getGuidPrefix();
        }

        public static string _20(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return ku.byCommon.Identity.general.getGuid();
        }

        public static string _21(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.getPlusZero", "f_num"));
                }
            }

            int tmpP1 = 0;
            var tmpJsonP1 = f_Parameters.ValueList[1] as Num;
            if (tmpJsonP1 == null)
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.getPlusZero", "f_length"));
            }
            tmpP1 = int.Parse(tmpJsonP1.Value);

            return ku.byCommon.Identity.general.getPlusZero(tmpP0, tmpP1);
        }

        public static string _22(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.by.Object.list<string> tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.list<string>);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.list<string>;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.getNoRepeatName", "f_list"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.getNoRepeatName", "f_name"));
                }
            }


            return ku.byCommon.Identity.general.getNoRepeatName(tmpP0, tmpP1);
        }

        public static byForm_Server.ku.by.Object.datetime _23(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return ku.byCommon.Identity.general.getServerDatetime();
        }

        public static string _24(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.joinString", "f_sourceOldStr"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.joinString", "f_newStr"));
                }
            }


            return ku.byCommon.Identity.general.joinString(tmpP0, tmpP1);
        }

        public static string _25(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.getIDGroup", "f_list"));
                }
            }


            return ku.byCommon.Identity.general.getIDGroup(tmpP0);
        }

        public static bool _26(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.contains", "f_str1"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.contains", "f_str2"));
                }
            }


            return ku.byCommon.Identity.general.contains(tmpP0, tmpP1);
        }

        public static bool _27(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            var tmpParameterList = f_Parameters.ValueList;
            
            ku.by.Object.list<string> tmpP0 = null;
            Type tmpP0Type = typeof(ku.by.Object.list<string>);
            if (tmpParameterList[0] is JsonObject)
            {
                var tmpJsonP0 = tmpParameterList[0] as JsonObject;
                tmpP0 = f_Parse.ParseObject(tmpJsonP0, tmpP0Type) as ku.by.Object.list<string>;
            }
            else
            {
                if (!(tmpParameterList[0] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.contains", "f_stringList"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.contains", "f_str"));
                }
            }


            return ku.byCommon.Identity.general.contains_(tmpP0, tmpP1);
        }

        public static void _28(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.copyRow", "f_Row"));
                }
            }

            ku.by.Object.Row tmpP1 = null;
            Type tmpP1Type = typeof(ku.by.Object.Row);
            if (tmpParameterList[1] is JsonObject)
            {
                var tmpJsonP1 = tmpParameterList[1] as JsonObject;
                tmpP1 = f_Parse.ParseObject(tmpJsonP1, tmpP1Type) as ku.by.Object.Row;
            }
            else
            {
                if (!(tmpParameterList[1] is NullValue))
                {
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.general.copyRow", "f_copy"));
                }
            }


            ku.byCommon.Identity.general.copyRow(tmpP0, tmpP1);
        }

        public static string _35(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedField.getFieldValue", "f_row"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedField.getFieldValue", "f_fieldNmae"));
                }
            }


            return ku.byCommon.Identity.relatedField.getFieldValue(tmpP0, tmpP1);
        }

        public static string _36(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedField.getFieldSummery", "f_row"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byCommon.identity.relatedField.getFieldSummery", "f_fieldNmae"));
                }
            }


            return ku.byCommon.Identity.relatedField.getFieldSummery(tmpP0, tmpP1);
        }
    }
}
