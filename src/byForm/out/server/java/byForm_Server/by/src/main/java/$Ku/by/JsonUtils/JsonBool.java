package $Ku.by.JsonUtils;

public class JsonBool implements IJsonValue  {
    private boolean privateValue;

    public JsonBool(boolean value) {
        setValue(value);
    }


    public final boolean getValue() {
        return privateValue;
    }

    public void setValue(boolean value) {
        this.privateValue = value;
    }

    @Override
    public java.lang.String toString() {
        if (!privateValue){
            return "false";
        }
        else if(privateValue){
            return "true";
        }
        return null;
    }
}
