using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using byForm_Server. ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);

        [DllImport("Ws2_32.dll")]
        static extern Int32 inet_addr(string ipaddr);
        private static volatile bool LogIsWriting = false;
        private const string sessionID = "$SESSIONID";
        public static Dictionary<int, ku.by.Object.ServerSession> CurrentThreadIDSession = new Dictionary<int, ku.by.Object.ServerSession>();

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "POST")
            {
                if (Global.InitErrorException != null)
                {
                    JsonObject tmpResponseJson = new JsonObject();
                    tmpResponseJson.Add("$SESSIONID", new NullValue());
                    tmpResponseJson.Add("$E", new BoolValue(true));
                    tmpResponseJson.Add("$V", new StringClass("服务器程序初始化出现错误" + Global.InitErrorException.Message));
                    context.Response.Write(ku.by.ToolClass.JsonParser.Utils.TransformToJson(tmpResponseJson));
                    return;
                }
                this.HandlePost(context);
                return;
            }

            if (context.Request.HttpMethod == "GET")
            {
                if (Global.InitErrorException != null)
                {
                    context.Response.Write("服务器程序初始化出现错误" + Global.InitErrorException.Message);
                    return;
                }
                string tmpHeader = this.GenerateLogHeader(context);
                tmpHeader += " GET 200";
                this.WriteLog(tmpHeader, false, null);
                context.Response.ContentType = "text/plain";
                context.Response.Write("服务器已连接，当前服务器框架.NET Framework 4.5.2");
                context.Response.Write("\r\n数据库连接成功");
                return;
            }

        }

        //[HandleProcessCorruptedStateExceptions]
        private void HandlePost(HttpContext context)
        {
            CurrentThreadIDSession.Remove(Thread.CurrentThread.ManagedThreadId);
            var tmpBuffedInPutStream = context.Request.GetBufferedInputStream();

            if (tmpBuffedInPutStream.Length > 10485760)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 200;
                context.Response.Write("暂不支持body内容大于10MB的请求");
                return;
            }

            string tmpBody = this.StreamReadAll(tmpBuffedInPutStream);
            string tmpResponseValue = null;
            ku.by.ToolClass.RequestTypeEnum tmpResquestType = ku.by.ToolClass.RequestTypeEnum.None;
            JsonObject tmpObj = null;
            ku.by.ToolClass.Parse tmpParse = new ku.by.ToolClass.Parse();
            StringBuilder tmpLogContent = new StringBuilder(this.GenerateLogHeader(context));
            tmpLogContent.Append(" POST ");
            string tmpIp = GetIp(context);

            try
            {
                tmpObj = ku.by.ToolClass.JsonParser.Root.CreateObj(tmpBody);
            }
            catch (Exception e)
            {
                //开始执行解析程序之前抛出的错误
                string tmpErrorMessage = this.HandleResponseValue(ku.by.ToolClass.RequestTypeEnum.None, e.Message, false);
                tmpLogContent.Append("HAS ERROR 200 \r\n");
                tmpLogContent.Append("--------------------------------------------------------------------------------------\r\n");
                tmpLogContent.Append("数据包解析错误信息： " + e.Message + "\r\n");
                tmpLogContent.Append("数据包内容 ：\r\n" + tmpBody + "\r\n");
                tmpLogContent.Append("--------------------------------------------------------------------------------------\r\n");
                this.WriteLog(tmpLogContent.ToString(), true, tmpBody);
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/plain";
                context.Response.Write(tmpErrorMessage);
                return;
            }

            try
            {
                tmpParse.ParsePostContent(tmpObj, tmpIp, context.Request.Url.ToString());

                if (tmpParse.ComeInHasError)
                {
                    tmpLogContent.Append("comeIn failed ");
                    this.WriteLog(tmpLogContent.ToString(), true, null);
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = "text/plain";
                    string tmpErrorMessage = "by.Identity.IDoor.comeIn执行错误 -> " + tmpParse.ResponseValue;
                    context.Response.Write(this.HandleResponseValue(tmpParse.ResponseType, tmpErrorMessage, false));
                    return;
                }

                tmpResponseValue = tmpParse.ResponseValue;
                tmpResquestType = tmpParse.ResponseType;
            }
            catch (Exception e)
            {
                string tmpErrorMessage = e.Message;
                tmpLogContent.Append("HAS ERROR 200 \r\n");
                tmpLogContent.Append("--------------------------------------------------------------------------------------\r\n");
                tmpLogContent.Append("错误信息： " + tmpErrorMessage + "\r\n");
                if (e is System.Data.SqlClient.SqlException || e is MySql.Data.MySqlClient.MySqlException)
                {
                    tmpErrorMessage = "数据库执行出错->" + tmpErrorMessage;
                    tmpErrorMessage = this.HandleResponseValue(tmpParse.ResponseType, tmpErrorMessage, false);
                    //tmpLogContent.Append(e.Message);
                }
                else
                {
                    if (tmpParse.ResponseType == ku.by.ToolClass.RequestTypeEnum.SQL && !string.IsNullOrEmpty(tmpParse.SqlLocation))
                    {
                        string tmpAppendContent = " sql错误位置: " + tmpParse.SqlLocation + "\r\n";
                        tmpLogContent.Append(tmpAppendContent);
                    }
                    tmpErrorMessage = this.HandleResponseValue(tmpParse.ResponseType, tmpErrorMessage, false);
                    //tmpLogContent.Append(tmpErrorMessage);
                }
                tmpLogContent.Append("接收数据： " + tmpBody + "\r\n");
                tmpLogContent.Append("返回数据： " + tmpErrorMessage + "\r\n");
                tmpLogContent.Append("堆栈信息： " + e.StackTrace + "\r\n");
                tmpLogContent.Append("--------------------------------------------------------------------------------------\r\n");
                this.WriteLog(tmpLogContent.ToString(), true, tmpBody);
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/plain";
                context.Response.Write(tmpErrorMessage);
                return;
            }

            tmpLogContent.Append("SUCESS 200");
            this.WriteLog(tmpLogContent.ToString(), false, null);
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/plain";
            context.Response.Write(this.HandleResponseValue(tmpParse.ResponseType, tmpParse.ResponseValue, true));
        }

        private string HandleResponseValue(ku.by.ToolClass.RequestTypeEnum f_RequestType, string f_ResponseValue, bool f_IsSucessful)
        {
            switch (f_RequestType)
            {
                case ku.by.ToolClass.RequestTypeEnum.None:
                    //只有在解析到请求类型之前出错才会跳到这
                case ku.by.ToolClass.RequestTypeEnum.ACTION:
                case ku.by.ToolClass.RequestTypeEnum.SKILL:
                case ku.by.ToolClass.RequestTypeEnum.AUTOID:
                case ku.by.ToolClass.RequestTypeEnum.SOURCE:
                case ku.by.ToolClass.RequestTypeEnum.TRAN:
                    return this.GenerateSource(f_ResponseValue, f_IsSucessful);
                default:
                    //在格式上和事务应该是一样的
                    return this.GenerateSqlResult(f_ResponseValue, f_IsSucessful);
            }
        }

        private string GenerateSource(string f_Value, bool f_IsSucessful)
        {
            //f_Value为执行结果tostring后的值
            JsonObject tmpObj = new JsonObject();
            try
            {
                tmpObj.Add(sessionID, new StringClass(ku.by.Object.ServerSession.getCurrentSession().ID));
            }
            catch
            {
                tmpObj.Add(sessionID, new NullValue());
            }
            tmpObj.Add("$E", new BoolValue((!f_IsSucessful).ToString().ToLower()));

            if (f_IsSucessful)
            {
                //执行成功返回的字符串为完整的json格式
                if (f_Value == null)
                {
                    tmpObj.Add("$V", new NullValue());
                }
                else if (f_Value.StartsWith("[") && f_Value.EndsWith("]"))
                {
                    tmpObj.Add("$V", new ArrayClass(f_Value));
                }
                else if (f_Value.StartsWith("\"") && f_Value.EndsWith("\""))
                {
                    tmpObj.Add("$V", ku.by.ToolClass.JsonParser.Utils.GetNewStringClass(f_Value.Substring(1, f_Value.Length - 2)));
                }
                else if (f_Value.ToLower() == "true" || f_Value.ToLower() == "false")
                {
                    tmpObj.Add("$V", new BoolValue(f_Value.ToLower()));
                }
                else if (f_Value.Trim().StartsWith("{") && f_Value.Trim().EndsWith("}"))
                {
                    tmpObj.Add("$V", new JsonObject(f_Value.Trim()));
                }
                else
                {
                    tmpObj.Add("$V", new Num(f_Value));
                }
            }
            else
            {
                //所有的错误信息都用双引号包裹
                tmpObj.Add("$V", ku.by.ToolClass.JsonParser.Utils.GetNewStringClass(f_Value));
            }
            return ku.by.ToolClass.JsonParser.Utils.TransformToJson(tmpObj);
        }

        private string GenerateSqlResult(string f_Value, bool f_IsSucessful)
        {
            JsonObject tmpObj = new JsonObject();
            tmpObj.Add(sessionID, new StringClass(ku.by.Object.ServerSession.getCurrentSession().ID));
            tmpObj.Add("$E", new BoolValue((!f_IsSucessful).ToString().ToLower()));

            if (f_IsSucessful)
            {
                //数字或者数组
                if (f_Value.StartsWith("{"))
                {
                    tmpObj.Add("$V", new JsonObject(f_Value));
                }
                else
                {
                    tmpObj.Add("$V", new Num(f_Value));
                }
            }
            else
            {
                tmpObj.Add("$V", ku.by.ToolClass.JsonParser.Utils.GetNewStringClass(f_Value));
            }
            return ku.by.ToolClass.JsonParser.Utils.TransformToJson(tmpObj);
        }

        private string GenerateLogHeader(HttpContext f_HttpContext)
        {
            string tmpNow = DateTime.Now.ToString();
            StringBuilder tmpContent = new StringBuilder();
            tmpContent.Append(tmpNow);
            tmpContent.Append(" ");
            tmpContent.Append(this.GetIp(f_HttpContext));
            return tmpContent.ToString();
        }

        private string GetIp(HttpContext f_HttpContext)
        {
            var tmpServerVariable = f_HttpContext.Request.ServerVariables;
            string tmpCdnIP = f_HttpContext.Request.Headers["Cdn-Src-Ip"];

            if (!string.IsNullOrEmpty(tmpCdnIP))
            {
                return this.CheckIp(tmpCdnIP);
            }

            string tmpHTTP_X_FORWARDED_FOR = tmpServerVariable["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(tmpHTTP_X_FORWARDED_FOR))
            {
                return this.CheckIp(tmpHTTP_X_FORWARDED_FOR);
            }

            string tmpRemote_Addr = tmpServerVariable["REMOTE_ADDR"];
            string tmpHttp_Via = tmpServerVariable["HTTP_VIA"];
            string tmpIp = null;

            if (tmpHttp_Via != null)
            {
                tmpIp = tmpHTTP_X_FORWARDED_FOR;
                if (tmpHTTP_X_FORWARDED_FOR == null)
                {
                    tmpIp = tmpRemote_Addr;
                }
            }
            else
            {
                if (tmpRemote_Addr != "::1")
                {
                    tmpIp = tmpRemote_Addr;
                }
                else
                {
                    tmpIp = "127.0.0.1";
                }
            }

            if (string.Compare(tmpIp, "unknown", true) == 0)
            {
                return f_HttpContext.Request.UserHostAddress;
            }
            return this.CheckIp(tmpIp);
        }

        private string CheckIp(string f_IpAddr)
        {
            Regex tmpRegex = new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
            if (tmpRegex.IsMatch(f_IpAddr))
            {
                return f_IpAddr;
            }
            else
            {
                throw new Exception("错误的ip地址 " + f_IpAddr);
            }
        }

        public static string GetMac(string f_RemoteIp)
        {
            StringBuilder tmpMacAddr = new StringBuilder();
            int tmpRemote = inet_addr(f_RemoteIp);
            Int64 macinfo = new Int64();
            Int32 length = 6;
            SendARP(tmpRemote, 0, ref macinfo, ref length);
            string tmpValue = Convert.ToString(macinfo, 16).PadLeft(12, '0').ToUpper();
            int x = 12;
            for (int i = 0; i < 6; i++)
            {
                if (i == 5)
                {
                    tmpMacAddr.Append(tmpValue.Substring(x - 2, 2));
                }
                else
                {
                    tmpMacAddr.Append(tmpValue.Substring(x - 2, 2) + "-");
                }
                x -= 2;
            }

            if (f_RemoteIp!= "127.0.0.1" && tmpMacAddr.ToString() == "00-00-00-00-00-00")
            {
                throw new Exception("无法匹配的mac地址 00-00-00-00-00-00");
            }

            return tmpMacAddr.ToString();
        }

        private void WriteLog(string f_LogContent, bool f_HasError, string f_Body)
        {
            string tmpPrePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string tmpLogDirectory = tmpPrePath + "log";
            if (!System.IO.Directory.Exists(tmpLogDirectory))
            {
                System.IO.Directory.CreateDirectory(tmpLogDirectory);
            }

            var tmpNow = DateTime.Today.Date;
            string tmpLogFileName = string.Format("{0}\\{1}_{2}_{3}.log", tmpLogDirectory, tmpNow.Year, tmpNow.Month, tmpNow.Day);
            Stopwatch tmpStopWatch = new Stopwatch();
            tmpStopWatch.Start();
            while (true)
            {
                if (tmpStopWatch.ElapsedMilliseconds > 2000)
                {
                    throw new Exception("日志响应超时");
                }
                if (LogIsWriting)
                {
                    continue;
                }
                else
                {
                    if (!LogIsWriting)
                    {
                        LogIsWriting = true;
                    }
                    else
                    {
                        continue;
                    }

                    if (f_HasError)
                    {
                        f_LogContent = f_LogContent + f_Body;
                    }

                    using (StreamWriter tmpStreamWriter = new StreamWriter(tmpLogFileName, true))
                    {
                        tmpStreamWriter.WriteLine(f_LogContent);
                    }
                    LogIsWriting = false;
                    break;
                }
            }
            tmpStopWatch.Stop();

        }

        private string StreamReadAll(Stream f_Input)
        {
            StringBuilder tmpValue = new StringBuilder();

            using (StreamReader tmpReader = new StreamReader(f_Input, Encoding.UTF8, true, 1024))//默认是1024
            {
                char[] tmpCharBuffer = new char[1024];
                int tmpLastCount = 0;

                while (tmpReader.Peek() >= 0)
                {
                    tmpLastCount = tmpReader.Read(tmpCharBuffer, 0, 1024);
                    tmpValue.Append(new string(tmpCharBuffer, 0, tmpLastCount));
                }
            }

            return tmpValue.ToString();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //public void CurrentSessionClear()
        //{
        //    currentSession.other = null;
        //    currentSession.ip = null;
        //    currentSession.time = null;
        //    currentSession.ID = null;
        //    currentSession.Cookie = null;
        //    currentSession.user = null;
        //    currentSession.identityName = null;
        //    currentSession.methodName = null;
        //}
    }
}