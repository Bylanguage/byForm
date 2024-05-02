package $Ku.byCommon.Object;

public class like extends $Ku.by.Object.ByObject {
    public java.lang.Integer pDicThreshold = 0;
    public java.lang.Integer pDay = 0;
    public $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.List<java.lang.String>> pDic;

    public like() {
        this.pDicThreshold = 100000;
        this.pDic = new $Ku.by.Object.Dictionary<java.lang.String, $Ku.by.Object.List<java.lang.String>>($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.List.class).addTypeArgument(0, $Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class)));
        this.pDay = $Ku.by.Object.Datetime.getNow().getDay();
    }


    public java.lang.Boolean analyseLike(java.lang.String f_contentID, java.lang.String f_userID) {
        java.lang.Integer tmpDay = $Ku.by.Object.Datetime.getNow().getDay();
        if (!java.util.Objects.equals(tmpDay, this.pDay) || this.pDic.count() > this.pDicThreshold) {
            this.pDay = tmpDay;
            this.pDic.clear();
        }
        if (!this.pDic.containsKey(f_contentID)) {
            $Ku.by.Object.List<java.lang.String> tmpList = new $Ku.by.Object.List<java.lang.String>($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class));
            tmpList.add(f_userID);
            this.pDic.add(f_contentID, tmpList);
            return true;
        }
        else {
            $Ku.by.Object.List<java.lang.String> tmpList = this.pDic.get(f_contentID);
            if (tmpList.contains(f_userID)) {
                tmpList.remove(f_userID);
                return false;
            }
            else {
                tmpList.add(f_userID);
                return true;
            }
        }
    }

    public $Ku.byCommon.Object.like $getThis$Ku_byCommon_Object_like() {
        return this;
    }
}
