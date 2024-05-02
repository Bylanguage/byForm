package $Ku.by.JsonUtils;

public class JsonNull implements IJsonValue  {
    public static $Ku.by.JsonUtils.JsonNull instance = new $Ku.by.JsonUtils.JsonNull();

    public JsonNull() {
    }


    @Override
    public java.lang.String toString() {
        return "null";
    }

    public static $Ku.by.JsonUtils.JsonNull getInstance() {
        return instance;
    }
}
