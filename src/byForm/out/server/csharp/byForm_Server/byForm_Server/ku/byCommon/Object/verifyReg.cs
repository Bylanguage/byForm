using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Object
{
    public class verifyReg
    {
        public verifyReg()
        {
        }

        public static string getVeriable(int f_min, int f_max)
        {
            if (f_min >= 1)
            {
                f_min = f_min - 1;
            }
            return "^[a-zA-Z_]{1}[a-zA-Z0-9_]{" + f_min.ToString() + "," + f_max.ToString() + "}$";
        }

        public static string getText(int f_min, int f_max)
        {
            return "^[a-zA-Z0-9_\\xff-\\uffff,.; \\r\\n\\t   ]{" + f_min.ToString() + "," + f_max.ToString() + "}$";
        }

        public static string getStrictText(int f_min, int f_max)
        {
            if (f_min >= 1)
            {
                f_min = f_min - 1;
            }
            return "^[a-zA-Z\\xff-\\uffff{1}][a-zA-Z0-9_\\xff-\\uffff]{" + f_min.ToString() + "," + f_max.ToString() + "}$";
        }

        public static string getInteger(int f_min, int f_max)
        {
            return "^[0-9]{" + f_min.ToString() + "," + f_max.ToString() + "}$";
        }

        public static string verfyLength(int f_min, int f_max)
        {
            return "^.{" + f_min.ToString() + "," + f_max.ToString() + "}$";
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
