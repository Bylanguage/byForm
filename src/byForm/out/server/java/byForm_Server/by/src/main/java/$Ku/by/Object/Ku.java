package $Ku.by.Object;

public class Ku {
    public final java.lang.String name;
    private static final java.util.HashMap<java.lang.String, $Ku.by.Object.Ku> KuDic = new java.util.HashMap<>();

    static {
        KuDic.put("byExternal", new Ku("byExternal"));
        KuDic.put("byFormNew", new Ku("byFormNew"));
        KuDic.put("byExternalSMS", new Ku("byExternalSMS"));
        KuDic.put("byWebCommon", new Ku("byWebCommon"));
        KuDic.put("byExternalChartjs", new Ku("byExternalChartjs"));
        KuDic.put("byBase", new Ku("byBase"));
        KuDic.put("by", new Ku("by"));
        KuDic.put("byUser", new Ku("byUser"));
        KuDic.put("byLog", new Ku("byLog"));
        KuDic.put("byInterface", new Ku("byInterface"));
        KuDic.put("byForm", new Ku("byForm"));
        KuDic.put("byCommon", new Ku("byCommon"));
    }


    private Ku(java.lang.String name) {
        this.name = name;
    }


    public static $Ku.by.Object.Ku getKu(java.lang.String kuName) {
        return KuDic.get(kuName);
    }
}
