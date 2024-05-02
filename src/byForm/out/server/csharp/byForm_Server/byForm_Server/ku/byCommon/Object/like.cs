using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Object
{
    public class like
    {
        public like()
        {
            this.pDicThreshold = 100000;
            this.pDic = new byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.list<string>>();
            this.pDay = byForm_Server.ku.by.Object.datetime.getNow().day;
        }

        public int pDicThreshold { get; set; }

        public int pDay { get; set; }

        public byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.list<string>> pDic { get; set; }

        public bool analyseLike(string f_contentID, string f_userID)
        {
            int tmpDay = byForm_Server.ku.by.Object.datetime.getNow().day;
            if (tmpDay != this.pDay || this.pDic.count > this.pDicThreshold)
            {
                this.pDay = tmpDay;
                this.pDic.clear();
            }
            if (!this.pDic.containsKey(f_contentID))
            {
                byForm_Server.ku.by.Object.list<string> tmpList = new byForm_Server.ku.by.Object.list<string>();
                tmpList.add(f_userID);
                this.pDic.add(f_contentID, tmpList);
                return true;
            }
            else
            {
                byForm_Server.ku.by.Object.list<string> tmpList = this.pDic[f_contentID];
                if (tmpList.contains(f_userID))
                {
                    tmpList.remove(f_userID);
                    return false;
                }
                else
                {
                    tmpList.add(f_userID);
                    return true;
                }
            }
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
