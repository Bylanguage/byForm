using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.byLog.Skill
{
    public class SkillIndex
    {
        public static byForm_Server.ku.by.Object.Row _0(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.byLog.Enum.logState tmpP0;
            var tmpP0Type = typeof(ku.byLog.Enum.logState);
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = (ku.byLog.Enum.logState)System.Enum.Parse(tmpP0Type, tmpJsonP0.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byLog.identity.log.getRow", "f_logState"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byLog.identity.log.getRow", "f_content"));
                }
            }


            return (f_Identity as ku.byLog.Identity.log).getRow(tmpP0, tmpP1);
        }

        public static void _1(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.byLog.Enum.logState tmpP0;
            var tmpP0Type = typeof(ku.byLog.Enum.logState);
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = (ku.byLog.Enum.logState)System.Enum.Parse(tmpP0Type, tmpJsonP0.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byLog.identity.log.writeTable", "f_logState"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byLog.identity.log.writeTable", "f_content"));
                }
            }


            (f_Identity as ku.byLog.Identity.log).writeTable(tmpP0, tmpP1);
        }

        public static void _2(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.byLog.Enum.logState tmpP0;
            var tmpP0Type = typeof(ku.byLog.Enum.logState);
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = (ku.byLog.Enum.logState)System.Enum.Parse(tmpP0Type, tmpJsonP0.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byLog.identity.log.writeFile", "f_logState"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byLog.identity.log.writeFile", "f_content"));
                }
            }


            (f_Identity as ku.byLog.Identity.log).writeFile(tmpP0, tmpP1);
        }

        public static void _3(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
            
            ku.byLog.Enum.logState tmpP0;
            var tmpP0Type = typeof(ku.byLog.Enum.logState);
            if (tmpParameterList[0] is StringClass)
            {
                var tmpJsonP0 = tmpParameterList[0] as StringClass;
                tmpP0 = (ku.byLog.Enum.logState)System.Enum.Parse(tmpP0Type, tmpJsonP0.value);
            }
            else
            {
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byLog.identity.log.write", "f_logState"));
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byLog.identity.log.write", "f_content"));
                }
            }


            (f_Identity as ku.byLog.Identity.log).write(tmpP0, tmpP1);
        }
    }
}
