using System;
using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.byForm.Skill
{
    public class SkillIndex
    {
        public static int _10(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.formField.addUpdate", "f_formField"));
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
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.formField.addUpdate", "action"));
            }


            return (f_Identity as ku.byForm.Identity.formField).addUpdate(tmpP0, tmpP1);
        }

        public static void _12(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.formField.delByFormId", "formID"));
                }
            }


            (f_Identity as ku.byForm.Identity.formField).delByFormId(tmpP0);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[] _15(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.form.load", "f_userID"));
                }
            }


            return (f_Identity as ku.byForm.Identity.form).load(tmpP0);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>[] _16(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.form.loadSingle", "f_FormID"));
                }
            }


            return (f_Identity as ku.byForm.Identity.form).loadSingle(tmpP0);
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.form.loadVDataSingle", "f_FormID"));
                }
            }


            return (f_Identity as ku.byForm.Identity.form).loadVDataSingle(tmpP0);
        }

        public static byForm_Server.ku.by.Object.Result _18(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.form.update", "f_list"));
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
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.form.update", "f_action"));
            }


            return (f_Identity as ku.byForm.Identity.form).update(tmpP0, tmpP1);
        }

        public static void _24(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.form.saveField", "f_formField"));
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
                throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.form.saveField", "action"));
            }


            (f_Identity as ku.byForm.Identity.form).saveField(tmpP0, tmpP1);
        }

        public static void _25(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.form.delFieldByFormId", "formID"));
                }
            }


            (f_Identity as ku.byForm.Identity.form).delFieldByFormId(tmpP0);
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> _33(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
        {
            if (f_Identity == null)
            {
                throw new Exception(ku.by.ToolClass.ErrorInfo.IdentityIsNull);
            }
            
            if(f_Parameters == null)
            {
                throw new Exception();
            }
            

            return (f_Identity as ku.byForm.Identity.fieldTemplate).getList();
        }

        public static byForm_Server.ku.by.Object.Row _34(byForm_Server.ku.by.ToolClass.Parse f_Parse, byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Parameters)
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
                    throw ThrowHelper.ThrowFuncException(string.Format(ErrorInfo.FuncTypeMatchError, "byForm.identity.fieldTemplate.getFieldTemplate", "id"));
                }
            }


            return (f_Identity as ku.byForm.Identity.fieldTemplate).getFieldTemplate(tmpP0);
        }
    }
}
