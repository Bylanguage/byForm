package $Ku.byWebCommon;

public class byWebCommon extends $Ku.by.ToolClass.BaseKu {
    public byWebCommon() {
        this.Name = "byWebCommon";

        $Ku.byWebCommon.Identity.webCommon NewInstancewebCommon = new $Ku.byWebCommon.Identity.webCommon();
        this.NewIdentityDic.put("New_webCommon", NewInstancewebCommon);
        this.NewIdentityKeyIsId.put(NewInstancewebCommon, "New_webCommon");
        NewInstancewebCommon.setKu("byWebCommon");
        this.sqlLocation = new $Ku.byWebCommon.SqlExpression.SqlLocation();
    }
}
