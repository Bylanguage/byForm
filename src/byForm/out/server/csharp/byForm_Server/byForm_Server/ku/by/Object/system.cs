using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class system
    {
        static system()
        {
            language = System.Globalization.CultureInfo.CurrentCulture.ToString();
        }

        public static byForm_Server.ku.by.Enum.SceneType currentScene
        {
            get
            {
                return Enum.SceneType.server;
            }
        }

        public static string currentDirectory
        {
            get
            {
                return System.AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public static string language { get; set; }

        public static int autoID(byForm_Server.ku.by.Object.table table)
        {
            return ++table.max;
        }

        public static int autoID(byForm_Server.ku.by.Object.table table, int value)
        {
            if (value < 1)
            {
                throw new System.Exception("autoID错误的操作数 " + value);
            }

            table.max = table.max + value;
            return table.max;
        }

        public static int autoID(byForm_Server.ku.by.Object.table table, bool needRefresh)
        {
            if (needRefresh)
            {
                table.RefreshMax();
            }

            return ++table.max;
        }

        public static int autoID(byForm_Server.ku.by.Object.table table, int value, bool needRefresh)
        {
            if (value < 1)
            {
                throw new System.Exception("autoID错误的操作数 " + value);
            }

            if (needRefresh)
            {
                table.RefreshMax();
            }

            table.max = table.max + value;
            return table.max;
        }
    }
}
