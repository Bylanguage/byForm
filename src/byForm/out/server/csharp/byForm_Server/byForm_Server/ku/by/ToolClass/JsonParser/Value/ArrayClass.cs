using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser.Value
{
    public class ArrayClass : byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue
    {
        public ArrayClass(string f_Content)
        {
            if (!(f_Content.StartsWith("[") && f_Content.EndsWith("]")))
            {
                throw new Exception("非json格式数组");
            }
            this.ParseArray(f_Content, this);
        }

        public ArrayClass()
        {
        }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue> ValueList
        {
            get
            {
                return this.valueList;
            }
        }

        internal System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue> valueList = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue>();

        public int Count
        {
            get
            {
                return this.valueList.Count;
            }
        }

        public void ParseArray(string f_Input, byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Array)
        {
            char[] tmpInput = f_Input.ToCharArray();

            int tmpFirst = Fill.FindFirstNotSpace(0, tmpInput);

            if (tmpFirst == -1)
            {
                return;
            }
            if (tmpFirst == f_Input.Length - 1)
            {
                if (f_Input[0] == '[' && f_Input[tmpFirst] == ']')
                {
                    //说明是空数组
                    return;
                }
                throw new Exception(string.Format(ErrorInfo.ParseError, f_Input[tmpFirst]));
            }

            while (true)
            {
                int tmpEndOfValue;
                string tmpValue;
                switch (tmpInput[tmpFirst])
                {
                    case '{':
                        tmpValue = Fill.GetTargetValue(tmpFirst, tmpInput, out tmpEndOfValue);
                        f_Array.ValueList.Add(new JsonObject(tmpValue));
                        break;
                    case '[':
                        tmpValue = Fill.GetArrayValue(tmpFirst, tmpInput, out tmpEndOfValue);
                        f_Array.ValueList.Add(new ArrayClass(tmpValue));
                        break;
                    case '"':
                        tmpValue = Fill.GetStringValue(tmpFirst, tmpInput, out tmpEndOfValue);
                        f_Array.ValueList.Add(new StringClass(tmpValue));
                        break;
                    default:
                        tmpValue = Fill.GetNormValue(tmpFirst, tmpInput, true, out tmpEndOfValue);
                        if (tmpValue.ToLower() == "true" || tmpValue.ToLower() == "false")
                        {
                            f_Array.ValueList.Add(new BoolValue(tmpValue));
                            break;
                        }
                        if (tmpValue == "null")
                        {
                            f_Array.valueList.Add(new NullValue());
                            break;
                        }
                        float tmpFloat;
                        if (float.TryParse(tmpValue, out tmpFloat))
                        {
                            f_Array.ValueList.Add(new Num(tmpValue));
                            break;
                        }
                        throw new Exception();
                }
                int tmpDividerIndex = Fill.FindFirstNotSpace(tmpEndOfValue, tmpInput);
                if (tmpInput[tmpDividerIndex] == ',')
                {
                    tmpFirst = Fill.FindFirstNotSpace(tmpDividerIndex, tmpInput);
                    if (tmpFirst == f_Input.Length - 1)
                    {
                        throw new Exception(string.Format(ErrorInfo.ParseError, tmpValue));
                    }
                    continue;
                }
                if (tmpInput[tmpDividerIndex] == ']')
                {
                    break;
                }
                throw new Exception(string.Format(ErrorInfo.ParseError, tmpValue));
            }
        }

        public void Add(byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue f_Value)
        {
            this.valueList.Add(f_Value);
        }

        internal override void GenerateCode(System.Text.StringBuilder f_Code, int f_Tab)
        {
            StringBuilder tmpIndentation = new StringBuilder();
            for (int i = 0; i < f_Tab; i++)
            {
                tmpIndentation.Append("    ");
            }
            f_Code.Append("[\r\n");
            f_Code.Append(tmpIndentation);
            int tmpCount = 0;
            foreach (var item in this.valueList)
            {
                item.GenerateCode(f_Code, f_Tab + 1);
                if (tmpCount != this.valueList.Count - 1)
                {
                    f_Code.Append(",\r\n");
                    f_Code.Append(tmpIndentation);
                }
                tmpCount++;
            }
            f_Code.Append("\r\n");
            for (int i = 0; i < f_Tab - 1; i++)
            {
                f_Code.Append("    ");
            }
            f_Code.Append("]");
        }
    }
}
