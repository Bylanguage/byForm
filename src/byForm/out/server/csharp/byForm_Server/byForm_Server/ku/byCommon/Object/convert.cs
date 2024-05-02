using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Object
{
    public class convert
    {
        public convert()
        {
        }

        private static string base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        public static string base64ToString(sbyte[] data)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            int i = 0;
            int j = 0;
            sbyte[] octets = byForm_Server.ku.by.ToolClass.ToolFunction.CrateArray<sbyte[]>(4);
            while (i < data.Length)
            {
                octets[j++] = data[i++];
                if (j == 3)
                {
                    result.Append(base64[(octets[0] & 0xFC) >> 2]);
                    result.Append(base64[((octets[0] & 0x3) << 4) | ((octets[1] & 0xF0) >> 4)]);
                    result.Append(base64[((octets[1] & 0xF) << 2) | ((octets[2] & 0xC0) >> 6)]);
                    result.Append(base64[octets[2] & 0x3F]);
                    j = 0;
                }
            }
            if (j != 0)
            {
                for (int k = j; k < 3; k++)
                {
                    octets[k] = 0;
                }
                result.Append(base64[(octets[0] & 0xFC) >> 2]);
                result.Append(base64[((octets[0] & 0x3) << 4) | ((octets[1] & 0xF0) >> 4)]);
                if (j == 1)
                {
                    result.Append("==");
                }
                else
                {
                    result.Append(base64[((octets[1] & 0xF) << 2)]);
                    result.Append("=");
                }
            }
            return result.ToString();
        }

        public static sbyte[] base64ToBytes(string base64String)
        {
            int length = base64String.Length;
            int padding = base64String.EndsWith("==") ? 2 : base64String.EndsWith("=") ? 1 : 0;
            int bufferLen = length * 3 / 4 - padding;
            sbyte[] buffer = byForm_Server.ku.by.ToolClass.ToolFunction.CrateArray<sbyte[]>(bufferLen);
            int bufferIdx = 0;
            for (int i = 0; i < length; i += 4)
            {
                int sextet0 = base64.IndexOf(base64String[i].ToString());
                int sextet1 = base64.IndexOf(base64String[i + 1].ToString());
                int sextet2 = base64.IndexOf(base64String[i + 2].ToString());
                int sextet3 = base64.IndexOf(base64String[i + 3].ToString());
                sbyte b0 = (sbyte)((sextet0 << 2) | (sextet1 >> 4));
                sbyte b1 = (sbyte)(((sextet1 & 0xF) << 4) | (sextet2 >> 2));
                sbyte b2 = (sbyte)(((sextet2 & 0x3) << 6) | sextet3);
                buffer[bufferIdx++] = b0;
                if (bufferIdx < bufferLen)
                {
                    buffer[bufferIdx++] = b1;
                }
                if (bufferIdx < bufferLen)
                {
                    buffer[bufferIdx++] = b2;
                }
            }
            return buffer;
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
