using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Identity
{
    public class general : byForm_Server.ku.by.Identity.Identity_
    {
        public general()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        private static int serialNumber;

        private static int serverSerialNumber;

        public static string guidPrefix;

        private static string cpuSerialNumber;

        public static string getGuidPrefix()
        {
            {
                string tmpResultValue = "";
                byForm_Server.ku.by.Object.datetime tmpDt = byForm_Server.ku.byCommon.Identity.general.getServerDatetime();
                int tmpDiffSecond = (int)byForm_Server.ku.by.Object.datetime.getNow().diffSeconds(byForm_Server.ku.by.Object.datetime.parse("2023-02-01"));
                if (byForm_Server.ku.byCommon.Identity.general.serverSerialNumber >= 65535)
                {
                    byForm_Server.ku.byCommon.Identity.general.serverSerialNumber = 0;
                }
                if (byForm_Server.ku.byCommon.Identity.general.cpuSerialNumber == null || byForm_Server.ku.byCommon.Identity.general.cpuSerialNumber == "")
                {
                    byForm_Server.ku.byCommon.Identity.general.cpuSerialNumber = byExternalBase.hardware.getCPU();
                }
                int tmpSN = ++byForm_Server.ku.byCommon.Identity.general.serverSerialNumber;
                tmpResultValue = byForm_Server.ku.byCommon.Identity.general.cpuSerialNumber + byForm_Server.ku.byCommon.Identity.general.getPlusZero(byForm_Server.ku.ExtendMethod.intToString(tmpDiffSecond, 16), 8) + byForm_Server.ku.byCommon.Identity.general.getPlusZero(byForm_Server.ku.ExtendMethod.intToString(tmpSN, 16), 4);
                return tmpResultValue;
            }
        }

        public static string getGuid()
        {
            string tmpResultValue = "";
            {
                if (byForm_Server.ku.byCommon.Identity.general.guidPrefix == null || byForm_Server.ku.byCommon.Identity.general.guidPrefix == "" || byForm_Server.ku.byCommon.Identity.general.serialNumber >= 65535)
                {
                    byForm_Server.ku.byCommon.Identity.general.guidPrefix = byForm_Server.ku.byCommon.Identity.general.getGuidPrefix();
                    byForm_Server.ku.byCommon.Identity.general.serialNumber = 0;
                }
            }
            int tmpSN = ++byForm_Server.ku.byCommon.Identity.general.serialNumber;
            tmpResultValue = byForm_Server.ku.byCommon.Identity.general.guidPrefix + byForm_Server.ku.byCommon.Identity.general.getPlusZero(byForm_Server.ku.ExtendMethod.intToString(tmpSN, 16), 4);
            return tmpResultValue;
        }

        public static string getPlusZero(string f_num, int f_length)
        {
            System.Text.StringBuilder tmpSb = new System.Text.StringBuilder();
            for (int i = f_num.Length; i < f_length; i++)
            {
                tmpSb.Append("0");
            }
            return tmpSb.ToString() + f_num;
        }

        public static string getNoRepeatName(byForm_Server.ku.by.Object.list<string> f_list, string f_name)
        {
            if (f_list.contains(f_name))
            {
                for (int i = 1; i < 1000; i++)
                {
                    string tmpValue = f_name + "_" + i;
                    if (!f_list.contains(tmpValue))
                    {
                        return tmpValue;
                    }
                }
            }
            return f_name;
        }

        public static byForm_Server.ku.by.Object.datetime getServerDatetime()
        {
            {
                return byForm_Server.ku.by.Object.datetime.getNow();
            }
        }

        public static string joinString(string f_sourceOldStr, string f_newStr)
        {
            if (f_sourceOldStr == null || f_sourceOldStr == "")
            {
                return f_newStr;
            }
            return f_sourceOldStr + "," + f_newStr;
        }

        public static string getIDGroup(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_list)
        {
            System.Text.StringBuilder tmpSb = new System.Text.StringBuilder();
            for (int i = 0; i < f_list.count; i++)
            {
                if (i == 0)
                {
                    tmpSb.Append(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_list[i], "iID").value.ToString());
                }
                else
                {
                    tmpSb.Append("," + byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_list[i], "iID").value.ToString());
                }
            }
            return tmpSb.ToString();
        }

        public static bool contains(string f_str1, string f_str2)
        {
            f_str1 = f_str1.ToLower();
            f_str2 = f_str2.ToLower();
            if (f_str1.Contains(f_str2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool contains_(byForm_Server.ku.by.Object.list<string> f_stringList, string f_str)
        {
            for (int i = 0; i < f_stringList.count; i++)
            {
                f_stringList[i] = f_stringList[i].ToLower();
            }
            f_str = f_str.ToLower();
            if (f_stringList.contains(f_str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void copyRow(byForm_Server.ku.by.Object.Row f_Row, byForm_Server.ku.by.Object.Row f_copy)
        {
            foreach (byForm_Server.ku.by.Object.Cell item in f_Row.Cells)
            {
                foreach (byForm_Server.ku.by.Object.Cell itemCopy in f_copy.Cells)
                {
                    if (item.field.name == itemCopy.field.name)
                    {
                        item.value = itemCopy.value;
                        break;
                    }
                }
            }
        }
    }
}
