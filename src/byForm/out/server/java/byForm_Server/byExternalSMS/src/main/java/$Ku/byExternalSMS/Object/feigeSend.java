package $Ku.byExternalSMS.Object;

public class feigeSend extends $Ku.by.Object.ByObject {
    public static java.lang.String p_apikey;
    public static java.lang.String p_secret;
    public static java.lang.String p_sign_id;
    public static java.lang.String p_template_id;

    public feigeSend() {
    }


    public static java.lang.String sendSafetyCode(java.lang.String f_mobile, java.lang.String f_content) {
        if (java.util.Objects.equals(p_apikey, null) || java.util.Objects.equals(p_apikey, "") || java.util.Objects.equals(p_secret, null) || java.util.Objects.equals(p_secret, "")) {
            return "发送短信的接口没有配置，要发送短信就在系统启动时配置运营高的账号与密码等！";
        }
        return byExternalSMS.feige.send(p_apikey, p_secret, p_sign_id, p_template_id, f_mobile, f_content);
    }

    public $Ku.byExternalSMS.Object.feigeSend $getThis$Ku_byExternalSMS_Object_feigeSend() {
        return this;
    }
}
