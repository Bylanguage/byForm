using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byWebCommon.Identity
{
    public class webCommon : byForm_Server.ku.by.Identity.Identity_
    {
        public webCommon()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public static byForm_Server.ku.by.Object.dictionary<string, string> getQueryArgDic(string f_queryArg)
        {
            byForm_Server.ku.by.Object.dictionary<string, string> tmpDic = new byForm_Server.ku.by.Object.dictionary<string, string>();
            if (f_queryArg == null || f_queryArg == "")
            {
                return tmpDic;
            }
            string tmpQuery = byForm_Server.ku.ExtendMethod.replaceReg(f_queryArg.Trim(), "^[\\?]", "", byForm_Server.ku.by.Enum.RegexMode.none);
            string[] tmpArr = tmpQuery.Split('&');
            foreach (string item in tmpArr)
            {
                string[] tmpForArr = item.Split('=');
                string tmpKey = tmpForArr[0].ToLower().Trim();
                if (!tmpDic.containsKey(tmpKey))
                {
                    tmpDic.add(tmpKey, tmpForArr[1].Trim());
                }
                else
                {
                    tmpDic[tmpKey] = tmpForArr[1].Trim();
                }
            }
            return tmpDic;
        }
    }
}
