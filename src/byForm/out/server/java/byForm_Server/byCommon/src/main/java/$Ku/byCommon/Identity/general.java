package $Ku.byCommon.Identity;

public class general extends $Ku.by.Identity.Identity {
    private static java.lang.Integer serialNumber = 0;
    private static java.lang.Integer serverSerialNumber = 0;
    public static java.lang.String guidPrefix;
    private static java.lang.String cpuSerialNumber;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public general() {
    }


    public static java.lang.String getGuidPrefix() {
        {
            java.lang.String tmpResultValue = "";
            $Ku.by.Object.Datetime tmpDt = $Ku.byCommon.Identity.general.getServerDatetime();
            java.lang.Integer tmpDiffSecond = $Ku.by.ToolClass.ToolFunction.castToInteger($Ku.by.Object.Datetime.getNow().diffSeconds($Ku.by.Object.Datetime.parse("2023-02-01")));
            if ($Ku.byCommon.Identity.general.serverSerialNumber >= 65535) {
                $Ku.byCommon.Identity.general.serverSerialNumber = 0;
            }
            if (java.util.Objects.equals($Ku.byCommon.Identity.general.cpuSerialNumber, null) || java.util.Objects.equals($Ku.byCommon.Identity.general.cpuSerialNumber, "")) {
                $Ku.byCommon.Identity.general.cpuSerialNumber = byExternal.hardware.getCPU();
            }
            java.lang.Integer tmpSN = ++$Ku.byCommon.Identity.general.serverSerialNumber;
            tmpResultValue = $Ku.byCommon.Identity.general.cpuSerialNumber + $Ku.byCommon.Identity.general.getPlusZero(java.lang.Integer.toString(tmpDiffSecond, 16), 8) + $Ku.byCommon.Identity.general.getPlusZero(java.lang.Integer.toString(tmpSN, 16), 4);
            return tmpResultValue;
        }
    }

    public static java.lang.String getGuid() {
        java.lang.String tmpResultValue = "";
        {
            if (java.util.Objects.equals($Ku.byCommon.Identity.general.guidPrefix, null) || java.util.Objects.equals($Ku.byCommon.Identity.general.guidPrefix, "") || $Ku.byCommon.Identity.general.serialNumber >= 65535) {
                $Ku.byCommon.Identity.general.guidPrefix = $Ku.byCommon.Identity.general.getGuidPrefix();
                $Ku.byCommon.Identity.general.serialNumber = 0;
            }
        }
        java.lang.Integer tmpSN = ++$Ku.byCommon.Identity.general.serialNumber;
        tmpResultValue = $Ku.byCommon.Identity.general.guidPrefix + $Ku.byCommon.Identity.general.getPlusZero(java.lang.Integer.toString(tmpSN, 16), 4);
        return tmpResultValue;
    }

    public static java.lang.String getPlusZero(java.lang.String f_num, java.lang.Integer f_length) {
        java.lang.StringBuilder tmpSb = new java.lang.StringBuilder();
        for (java.lang.Integer i = f_num.length(); i < f_length; i++) {
            tmpSb.append("0");
        }
        return tmpSb.toString() + f_num;
    }

    public static java.lang.String getNoRepeatName($Ku.by.Object.List<java.lang.String> f_list, java.lang.String f_name) {
        if (f_list.contains(f_name)) {
            for (java.lang.Integer i = 1; i < 1000; i++) {
                java.lang.String tmpValue = f_name + "_" + i;
                if (!f_list.contains(tmpValue)) {
                    return tmpValue;
                }
            }
        }
        return f_name;
    }

    public static $Ku.by.Object.Datetime getServerDatetime() {
        {
            return $Ku.by.Object.Datetime.getNow();
        }
    }

    public static java.lang.String joinString(java.lang.String f_sourceOldStr, java.lang.String f_newStr) {
        if (java.util.Objects.equals(f_sourceOldStr, null) || java.util.Objects.equals(f_sourceOldStr, "")) {
            return f_newStr;
        }
        return f_sourceOldStr + "," + f_newStr;
    }

    public static java.lang.String getIDGroup($Ku.by.Object.List<$Ku.by.Object.Row> f_list) {
        java.lang.StringBuilder tmpSb = new java.lang.StringBuilder();
        for (java.lang.Integer i = 0; i < f_list.count(); i++) {
            if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(i, 0)) {
                tmpSb.append(((java.lang.Object) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_list.get(i), "iID").value).toString());
            }
            else {
                tmpSb.append("," + ((java.lang.Object) $Ku.by.ToolClass.ToolFunction.GetRowComponent(f_list.get(i), "iID").value).toString());
            }
        }
        return tmpSb.toString();
    }

    public static java.lang.Boolean contains(java.lang.String f_str1, java.lang.String f_str2) {
        f_str1 = f_str1.toLowerCase();
        f_str2 = f_str2.toLowerCase();
        if (f_str1.contains(f_str2)) {
            return true;
        }
        else {
            return false;
        }
    }

    public static java.lang.Boolean contains($Ku.by.Object.List<java.lang.String> f_stringList, java.lang.String f_str) {
        for (java.lang.Integer i = 0; i < f_stringList.count(); i++) {
            f_stringList.assign(i, f_stringList.get(i).toLowerCase());
        }
        f_str = f_str.toLowerCase();
        if (f_stringList.contains(f_str)) {
            return true;
        }
        else {
            return false;
        }
    }

    public static void copyRow($Ku.by.Object.Row f_Row, $Ku.by.Object.Row f_copy) {
        for ($Ku.by.Object.Cell item : f_Row.cells()) {
            for ($Ku.by.Object.Cell itemCopy : f_copy.cells()) {
                if (java.util.Objects.equals(item.field().name, itemCopy.field().name)) {
                    item.value = itemCopy.value;
                    break;
                }
            }
        }
    }

    public $Ku.byCommon.Identity.general $getThis$Ku_byCommon_Identity_general() {
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
