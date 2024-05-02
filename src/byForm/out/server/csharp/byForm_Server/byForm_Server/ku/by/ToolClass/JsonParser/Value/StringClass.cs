using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.JsonParser.Value
{
    public class StringClass : byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue
    {
        public StringClass(string f_Content)
        {
            this.value = f_Content;
        }

        public string Value
        {
            get
            {
                return this.value;
            }
        }

        internal string value;

        public override string ToString()
        {
            return this.value;
        }

        internal override void GenerateCode(System.Text.StringBuilder f_Code, int f_Tab)
        {
            if (this.value == null)
            {
                f_Code.Append("null");
                return;
            }

            StringBuilder tmpList = new StringBuilder(this.value.Length * 2);

            foreach (var item in this.value)
            {
                switch (item)
                {
                    case '\u0000':
                        tmpList.Append("\\u0000");
                        continue;
                    case '\u0001':
                        tmpList.Append("\\u0001");
                        continue;
                    case '\u0002':
                        tmpList.Append("\\u0002");
                        continue;
                    case '\u0003':
                        tmpList.Append("\\u0003");
                        continue;
                    case '\u0004':
                        tmpList.Append("\\u0004");
                        continue;
                    case '\u0005':
                        tmpList.Append("\\u0005");
                        continue;
                    case '\u0006':
                        tmpList.Append("\\u0006");
                        continue;
                    case '\u0007':
                        tmpList.Append("\\u0007");
                        continue;
                    case '\b':
                        tmpList.Append("\\b");
                        continue;
                    case '\t':
                        tmpList.Append("\\t");
                        continue;
                    case '\n':
                        tmpList.Append("\\n");
                        continue;
                    case '\u000b':
                        tmpList.Append("\\u000b");
                        continue;
                    case '\f':
                        tmpList.Append("\\f");
                        continue;
                    case '\r':
                        tmpList.Append("\\r");
                        continue;
                    case '\u000e':
                        tmpList.Append("\\u000e");
                        continue;
                    case '\u000f':
                        tmpList.Append("\\u000f");
                        continue;
                    case '\u0010':
                        tmpList.Append("\\u0010");
                        continue;
                    case '\u0011':
                        tmpList.Append("\\u0011");
                        continue;
                    case '\u0012':
                        tmpList.Append("\\u0012");
                        continue;
                    case '\u0013':
                        tmpList.Append("\\u0013");
                        continue;
                    case '\u0014':
                        tmpList.Append("\\u0014");
                        continue;
                    case '\u0015':
                        tmpList.Append("\\u0015");
                        continue;
                    case '\u0016':
                        tmpList.Append("\\u0016");
                        continue;
                    case '\u0017':
                        tmpList.Append("\\u0017");
                        continue;
                    case '\u0018':
                        tmpList.Append("\\u0018");
                        continue;
                    case '\u0019':
                        tmpList.Append("\\u0019");
                        continue;
                    case '\u001a':
                        tmpList.Append("\\u001a");
                        continue;
                    case '\u001b':
                        tmpList.Append("\\u001b");
                        continue;
                    case '\u001c':
                        tmpList.Append("\\u001c");
                        continue;
                    case '\u001d':
                        tmpList.Append("\\u001d");
                        continue;
                    case '\u001e':
                        tmpList.Append("\\u001e");
                        continue;
                    case '\u001f':
                        tmpList.Append("\\u001f");
                        continue;
                    case '"':
                        tmpList.Append(@"\""");
                        continue;
                    case '\\':
                        tmpList.Append(@"\\");
                        continue;
                }

                if (item >= '\ud800' && item <= '\udfff')
                {
                    tmpList.Append("\\u" + Convert.ToString(item - '\u0000', 16));
                    continue;
                }

                tmpList.Append(item);
            }

            f_Code.Append("\"" + tmpList.ToString() + "\"");
        }
    }
}
