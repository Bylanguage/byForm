package $Ku.byCommon.Object;

public class timeSlot extends $Ku.by.Object.ByObject {
    public java.lang.Integer pPrevious = 0;
    public $Ku.by.Object.Datetime pCurrentDT;
    public java.lang.Integer pCurrent = 0;
    public java.lang.Double paraInterval = 0.0;
    public java.lang.Integer paraThreshold = 0;
    public $Ku.byCommon.Event.timeSlotexeSQLEvent exeSQLEvent = new $Ku.byCommon.Event.timeSlotexeSQLEvent();

    public timeSlot(java.lang.Double f_interval, java.lang.Integer f_threshold) {
        this.pPrevious = 0;
        this.pCurrent = 0;
        this.paraInterval = Double.valueOf(20);
        this.paraThreshold = 10;
        this.pCurrentDT = $Ku.by.Object.Datetime.getNow();
        this.paraInterval = f_interval;
        this.paraThreshold = f_threshold;
    }


    public java.lang.Boolean isCache() {
        $Ku.by.Object.Datetime tmpDt = $Ku.by.Object.Datetime.getNow();
        this.pCurrent++;
        if (this.pCurrentDT.diffSeconds(tmpDt) > this.paraInterval) {
            ;
        }
        {
            java.lang.Integer tmpSourcePrevious = this.pPrevious;
            this.pPrevious = this.pCurrent;
            this.pCurrentDT = tmpDt;
            this.pCurrent = 0;
            if (!java.util.Objects.equals(this.exeSQLEvent, null)) {
                this.exeSQLEvent.invoke();
            }
            if (tmpSourcePrevious > this.paraThreshold) {
                return true;
            }
            else {
                return false;
            }
        }
    }

    public $Ku.byCommon.Object.timeSlot $getThis$Ku_byCommon_Object_timeSlot() {
        return this;
    }
}
