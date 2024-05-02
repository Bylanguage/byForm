using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace byForm_Server
{
    public class Global : System.Web.HttpApplication
    {
        public static string CurrentPath { get { return currentPath; } }
        private static string currentPath;
        public static Exception InitErrorException { get; protected set; }
        

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
                string tmpLogDirectory = currentPath + "log";

                if (!System.IO.Directory.Exists(tmpLogDirectory))
                {
                    System.IO.Directory.CreateDirectory(tmpLogDirectory);
                }
                //测试用
                var tmpNow = DateTime.Now;
                string tmpLogFileName = string.Format("{0}\\{1}_{2}_{3}.log", tmpLogDirectory, tmpNow.Year, tmpNow.Month, tmpNow.Day);
                using (StreamWriter tmpStreamWriter = new StreamWriter(tmpLogFileName, true))
                {
                    tmpStreamWriter.WriteLine("服务器开始初始化 " + tmpNow); ;
                }
                ku.Root.GetInstance().AssembleComponent();
                ku.by.ToolClass.SqlHelper.TestConnetion();
                ku.Start.main();
            }
            catch(Exception ex)
            {
                InitErrorException = ex;
            }
        }
    }
}