using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser
{
    public class Utils
    {
        public static string TransformToJson(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj)
        {
            StringBuilder tmpJsonCode = new StringBuilder("{");
            int tmpCount = 0;
            foreach (var item in f_Obj.keyPairDic)
            {
                tmpJsonCode.Append("\"" + item.Key + "\" : ");
                item.Value.GenerateCode(tmpJsonCode, 1);
                if (tmpCount != f_Obj.keyPairDic.Count - 1)
                {
                    tmpJsonCode.Append(",\r\n");
                    tmpJsonCode.Append("    ");
                }
                tmpCount++;
            }
            tmpJsonCode.Append("\r\n}");
            return tmpJsonCode.ToString();
        }

        public static string TransformToJson(byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_ArrayClass)
        {
            StringBuilder tmpJsonCode = new StringBuilder("[");
            int tmpCount = 0;
            foreach (var item in f_ArrayClass.ValueList)
            {
                if (tmpJsonCode.Length != 1)
                {
                    tmpJsonCode.Append(",\r\n    ");
                }
                item.GenerateCode(tmpJsonCode, 1);
                tmpCount++;
            }
            tmpJsonCode.Append("\r\n]");
            return tmpJsonCode.ToString();
        }

        public static byForm_Server.ku.by.ToolClass.JsonParser.Value.StringClass GetNewStringClass(string f_Content)
        {
            List<char> tmpNewContent = new List<char>();
            for (int i = 0; i < f_Content.Length; i++)
            {
                //if (f_Content[i] == '"')
                //{
                //    tmpNewContent.Add('\\');
                //}
                tmpNewContent.Add(f_Content[i]);
            }
            var tmpArray = tmpNewContent.ToArray();
            return new Value.StringClass(new string(tmpArray));
        }
    }
}
