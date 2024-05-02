using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class ServerSession
    {
        public ServerSession()
        {
        }

        public ServerSession(double time)
        {
            this.timer = new System.Timers.Timer();
            this.timer.Elapsed += AutoClear;
            this.timer.Interval = time;
            this.timer.Start();
        }

        public string ID
        {
            get
            {
                this.TimeRestart();
                return _id;
            }
            set
            {
                _id = value;
                this.TimeRestart();
            }
        }

        private string _id;

        public string ip
        {
            get
            {
                this.TimeRestart();
                return _ip;
            }
            set
            {
                _ip = value;
                this.TimeRestart();
            }
        }

        private string _ip;

        public object other
        {
            get
            {
                this.TimeRestart();
                return _other;
            }
            set
            {
                _other = value;
                this.TimeRestart();
            }
        }

        private object _other;

        public byForm_Server.ku.by.Object.datetime time
        {
            get
            {
                this.TimeRestart();
                return _time;
            }
            set
            {
                _time = value;
                this.TimeRestart();
            }
        }

        private byForm_Server.ku.by.Object.datetime _time;

        public byForm_Server.ku.by.Object.Row user
        {
            get
            {
                this.TimeRestart();
                return _user;
            }
            set
            {
                _user = value;
                this.TimeRestart();
            }
        }

        private byForm_Server.ku.by.Object.Row _user;

        public string Cookie
        {
            get
            {
                this.TimeRestart();
                return _cookie;
            }
            set
            {
                _cookie = value;
                this.TimeRestart();
            }
        }

        private string _cookie;

        public string identityName
        {
            get
            {
                this.TimeRestart();
                return _identityName;
            }
            set
            {
                _identityName = value;
                this.TimeRestart();
            }
        }

        private string _identityName;

        public string methodName
        {
            get
            {
                this.TimeRestart();
                return _methodName;
            }
            set
            {
                _methodName = value;
                this.TimeRestart();
            }
        }

        private string _methodName;

        public string url
        {
            get
            {
                this.TimeRestart();
                return _url;
            }
            set
            {
                _url = value;
                this.TimeRestart();
            }
        }

        private string _url;

        public string saasID
        {
            get
            {
                this.TimeRestart();
                return _saasID;
            }
            set
            {
                _saasID = value;
                this.TimeRestart();
            }
        }

        private string _saasID;

        private System.Timers.Timer timer;

        public static byForm_Server.ku.by.Object.ServerSession getCurrentSession()
        {
            int tmpThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;

            if (!Handler.CurrentThreadIDSession.ContainsKey(tmpThreadID))
            {
                ToolClass.ThrowHelper.ThrowUnKnownException("获取CurrentSession失败，线程ID不存在");
            }

            var tmpCurrentSession = Handler.CurrentThreadIDSession[tmpThreadID];
            string tmpCurrentId = tmpCurrentSession.ID;

            if (!Identity.Server.cacheSessionDic.containsKey(tmpCurrentId))
            {
                ToolClass.ThrowHelper.ThrowUnKnownException("获取CurrentSession失败, SessionID不存在");
            }

            return Identity.Server.cacheSessionDic[tmpCurrentId];
        }

        public byForm_Server.ku.by.Object.ServerCallInfo getCallInfo()
        {
            return new ServerCallInfo() { identityName = _identityName, methodName = _methodName };
        }

        private void AutoClear(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ku.by.Identity.Server.cacheSessionDic == null)
            {
                throw new Exception("session缓存区为null");
            }
            if (ku.by.Identity.Server.cacheSessionDic.containsKey(this.ID))
            {
                ku.by.Identity.Server.cacheSessionDic.remove(this.ID);
                this.timer.Stop();
                this.timer.Dispose();
            }
            else
            {
                this.timer.Stop();
                this.timer.Dispose();
            }
        }

        public static string getMac(string remoteIP)
        {
            return Handler.GetMac(remoteIP);
        }

        public void TimeRestart()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer.Start();
            }
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
