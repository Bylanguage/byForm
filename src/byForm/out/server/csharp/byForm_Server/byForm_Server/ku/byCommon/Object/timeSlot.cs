using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Object
{
    public class timeSlot
    {
        public timeSlot(double f_interval, int f_threshold)
        {
            this.pPrevious = 0;
            this.pCurrent = 0;
            this.paraInterval = 20;
            this.paraThreshold = 10;
            this.pCurrentDT = byForm_Server.ku.by.Object.datetime.getNow();
            this.paraInterval = f_interval;
            this.paraThreshold = f_threshold;
        }

        public int pPrevious { get; set; }

        public byForm_Server.ku.by.Object.datetime pCurrentDT { get; set; }

        public int pCurrent { get; set; }

        public double paraInterval { get; set; }

        public int paraThreshold { get; set; }

        public bool isCache()
        {
            byForm_Server.ku.by.Object.datetime tmpDt = byForm_Server.ku.by.Object.datetime.getNow();
            this.pCurrent++;
            if (this.pCurrentDT.diffSeconds(tmpDt) > this.paraInterval)
            {
                ;
            }
            {
                int tmpSourcePrevious = this.pPrevious;
                this.pPrevious = this.pCurrent;
                this.pCurrentDT = tmpDt;
                this.pCurrent = 0;
                if (this.exeSQLEvent != null)
                {
                    this.exeSQLEvent();
                }
                if (tmpSourcePrevious > this.paraThreshold)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (this.pPrevious > this.paraThreshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }

        public event byForm_Server.ku.by.Delegates.KuDelegates.Delegate_0 exeSQLEvent;
    }
}
