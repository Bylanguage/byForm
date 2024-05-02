package $Ku.by.JsonUtils;

public class JsonNumber implements IJsonValue  {
    private java.lang.String privateNumberStr;

    public JsonNumber(java.lang.String value) {
        setNumberStr(value);
    }


    public final java.lang.String getNumberStr() {
        return privateNumberStr;
    }

    private void setNumberStr(java.lang.String NumberStr) {
        privateNumberStr = NumberStr;
    }

    public java.lang.String toString() {
        return getNumberStr();
    }
}
