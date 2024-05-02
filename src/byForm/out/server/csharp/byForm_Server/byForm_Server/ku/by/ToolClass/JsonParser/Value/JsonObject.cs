using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser.Value
{
    public class JsonObject : byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue
    {
        public JsonObject(string f_Content)
        {
            f_Content = f_Content.Trim();
            if (!(f_Content.StartsWith("{") && f_Content.EndsWith("}")))
            {
                throw new Exception("非json格式对象");
            }

            this.ParseTarget(f_Content, this);
        }

        public JsonObject()
        {
        }

        public byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue this[string f_Index]
        {
            get
            {
                if (this.keyPairDic.ContainsKey(f_Index))
                {
                    return this.keyPairDic[f_Index];
                }
                else
                {
                    return null;
                }
            }
        }

        public bool ContainsKey(string f_Key)
        {
            return this.keyPairDic.ContainsKey(f_Key);
        }

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue> KeyPairDic
        {
            get
            {
                return this.keyPairDic;
            }
        }

        internal System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue> keyPairDic = new System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue>();

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        internal string name;

        private void ParseTarget(string f_Input, byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Target)
        {
            //大括号起始和结尾
            //先去空白字符
            char[] tmpInput = f_Input.ToCharArray();
            int tmpFirst = Fill.FindFirstNotSpace(0, tmpInput);//在对象中为第一个"的位置
            if (tmpFirst == -1)
            {
                return;
            }
            if (tmpInput[tmpFirst] != '"')
            {
                if (tmpFirst == f_Input.Length - 1 && tmpInput[tmpFirst] == '}')
                {
                    //说明当前是一个空的对象
                    return;
                }
                throw new Exception(string.Format("{0} 索引 {1} 不是期望的字符 \"", f_Input, tmpFirst));
            }
            if (tmpFirst == f_Input.Length - 1)
            {
                throw new Exception("错误的格式");
            }

            //寻找键
            int tmpEndOfAttribute;
            while (true)
            {
                int tmpEndOfQuotes = Fill.FindFirstDoublequotation(tmpFirst, tmpInput);
                if (tmpEndOfQuotes == -1)
                {
                    throw new Exception("匹配不到 \"");
                }
                string tmpKey = f_Input.Substring(tmpFirst + 1, tmpEndOfQuotes - 1 - tmpFirst);
                if (f_Target.keyPairDic.ContainsKey(tmpKey))
                {
                    throw new Exception(string.Format("存在重复的对象名 \"{0}\"", tmpKey));
                }
                //找冒号
                int tmpNext = Fill.FindFirstNotSpace(tmpEndOfQuotes, tmpInput);
                if (tmpInput[tmpNext] != ':')
                {
                    throw new Exception("匹配不到 :");
                }
                int tmpValueBegin = Fill.FindFirstNotSpace(tmpNext, tmpInput);
                string tmpValue;
                switch (tmpInput[tmpValueBegin])
                {
                    case '{':
                        tmpValue = Fill.GetTargetValue(tmpValueBegin, tmpInput, out tmpEndOfAttribute);
                        f_Target.keyPairDic.Add(tmpKey, new JsonObject(tmpValue));
                        break;
                    case '[':
                        tmpValue = Fill.GetArrayValue(tmpValueBegin, tmpInput, out tmpEndOfAttribute);
                        f_Target.keyPairDic.Add(tmpKey, new ArrayClass(tmpValue));
                        break;
                    case '"':
                        tmpValue = Fill.GetStringValue(tmpValueBegin, tmpInput, out tmpEndOfAttribute);
                        f_Target.keyPairDic.Add(tmpKey, new StringClass(tmpValue));
                        break;
                    default:
                        tmpValue = Fill.GetNormValue(tmpValueBegin, tmpInput, false, out tmpEndOfAttribute);
                        if (tmpValue.ToLower() == "null")
                        {
                            f_Target.keyPairDic.Add(tmpKey, new NullValue());
                            break;
                        }
                        if (tmpValue.ToLower() == "true" || tmpValue.ToLower() == "false")
                        {
                            f_Target.keyPairDic.Add(tmpKey, new BoolValue(tmpValue));
                            break;
                        }
                        if (tmpValue == "}" || tmpValue == ",")
                        {
                            //冒号后没有写值
                            throw new Exception("对象值缺失");
                        }
                        float tmpFloat;
                        if (!float.TryParse(tmpValue, out tmpFloat))
                        {
                            throw new Exception(tmpValue + "不是数字");
                        }
                        f_Target.keyPairDic.Add(tmpKey, new Num(tmpValue));
                        break;
                }
                int tmpDividerIndex = Fill.FindFirstNotSpace(tmpEndOfAttribute, tmpInput);
                if (tmpInput[tmpDividerIndex] == ',')
                {
                    tmpFirst = Fill.FindFirstNotSpace(tmpDividerIndex, tmpInput);
                    if (tmpInput[tmpFirst] != '"')
                    {
                        throw new Exception(string.Format("{0} 索引 {1} 不是期望的字符 \"", f_Input, tmpFirst));
                    }
                    if (tmpFirst == f_Input.Length - 1)
                    {
                        throw new Exception("匹配不到 \"");
                    }
                    continue;
                }
                if (tmpInput[tmpDividerIndex] == '}')
                {
                    break;
                }
                throw new Exception("非法格式");
            }
        }

        public void Add(string f_Key, byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue f_Value)
        {
            this.keyPairDic.Add(f_Key, f_Value);
        }

        internal override void GenerateCode(System.Text.StringBuilder f_Code, int f_Tab)
        {
            StringBuilder tmpIndentation = new StringBuilder();
            for (int i = 0; i < f_Tab; i++)
            {
                tmpIndentation.Append("    ");
            }
            f_Code.Append("{\r\n");
            f_Code.Append(tmpIndentation);
            int tmpCount = 0;
            foreach (var item in this.keyPairDic)
            {
                f_Code.Append("\"" + item.Key + "\":");
                item.Value.GenerateCode(f_Code, f_Tab + 1);
                if (tmpCount != this.keyPairDic.Count - 1)
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
            f_Code.Append("}");
        }
    }
}
