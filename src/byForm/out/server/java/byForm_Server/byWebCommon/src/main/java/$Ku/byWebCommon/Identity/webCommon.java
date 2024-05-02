package $Ku.byWebCommon.Identity;

public class webCommon extends $Ku.by.Identity.Identity {
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public webCommon() {
    }


    public static $Ku.by.Object.Dictionary<java.lang.String, java.lang.String> getQueryArgDic(java.lang.String f_queryArg) {
        $Ku.by.Object.Dictionary<java.lang.String, java.lang.String> tmpDic = new $Ku.by.Object.Dictionary<java.lang.String, java.lang.String>($Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class), $Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class));
        if (java.util.Objects.equals(f_queryArg, null) || java.util.Objects.equals(f_queryArg, "")) {
            return tmpDic;
        }
        java.lang.String tmpQuery = $Ku.by.ToolClass.StringUtil.replaceReg(f_queryArg.trim(), "^[\\?]", "", $Ku.by.Enum.RegexMode.none);
        java.lang.String[] tmpArr = $Ku.by.ToolClass.StringUtil.split(tmpQuery, '&');
        for (java.lang.String item : tmpArr) {
            java.lang.String[] tmpForArr = $Ku.by.ToolClass.StringUtil.split(item, '=');
            java.lang.String tmpKey = tmpForArr[0].toLowerCase().trim();
            if (!tmpDic.containsKey(tmpKey)) {
                tmpDic.add(tmpKey, tmpForArr[1].trim());
            }
            else {
                tmpDic.assign(tmpKey, tmpForArr[1].trim());
            }
        }
        return tmpDic;
    }

    public $Ku.byWebCommon.Identity.webCommon $getThis$Ku_byWebCommon_Identity_webCommon() {
        return this;
    }

    public void $setProps() {
    }

    public $Ku.by.ToolClass.Sql.SelectTable getSource() {
        return this.Source;
    }

    public void setSource($Ku.by.ToolClass.Sql.SelectTable value) {
        this.Source = value;
    }
}
