using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byExternalSMS.Object
{
    public class feigeSend
    {
        public feigeSend()
        {
        }

        public static string p_apikey;

        public static string p_secret;

        public static string p_sign_id;

        public static string p_template_id;

        public static string sendSafetyCode(string f_mobile, string f_content)
        {
            if (p_apikey == null || p_apikey == "" || p_secret == null || p_secret == "")
            {
                return "发送短信的接口没有配置，要发送短信就在系统启动时配置运营高的账号与密码等！";
            }
            return byExternalSMScsharp.feige.send(p_apikey, p_secret, p_sign_id, p_template_id, f_mobile, f_content);
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
