package $Ku.by.JsonUtils;

public class JsonString implements IJsonValue  {
    private java.lang.String privateValue;

    public JsonString(java.lang.String value) {
        setValue(parseValue(value));
    }


    public final java.lang.String getValue() {
        return jsonValueToJavaValue(privateValue);
    }

    private void setValue(java.lang.String value) {
        privateValue = value;
    }

    @Override
    public java.lang.String toString() {
        return '"'+privateValue+'"';
    }

    public java.lang.String parseValue(java.lang.String value) {
        char[] chars = value.toCharArray();

        StringBuilder buff = new StringBuilder();
        for(char cc : chars){
            switch (cc){
                case '\\':
                    buff.append("\\\\");
                    break;
                case '\r':
                    buff.append("\\r");
                    break;
                case '\n':
                    buff.append("\\n");
                    break;
                case '\t':
                    buff.append("\\t");
                    break;
                case '\f':
                    buff.append("\\f");
                    break;
                case '\"':
                    buff.append("\\\"");
                    break;
                default:
                    buff.append(cc);
                    break;
            }

        }
        return buff.toString();
    }

    private java.lang.String jsonValueToJavaValue(java.lang.String jsonValue) {
        char[] chars = jsonValue.toCharArray();

        StringBuilder buff = new StringBuilder();
        for(int i = 0; i < chars.length; i++){
            char cc = chars[i];
            if(cc=='\\' && (i+1) < chars.length){
                char nextCC = chars[i+1];
                switch (nextCC){
                    case '\\':
                        buff.append("\\");
                        i++;
                        break;
                    case 'r':
                        buff.append("\r");
                        i++;
                        break;
                    case 'n':
                        buff.append("\n");
                        i++;
                        break;
                    case 't':
                        buff.append("\t");
                        i++;
                        break;
                    case 'f':
                        buff.append("\f");
                        i++;
                        break;
                    case '"':
                        buff.append("\"");
                        i++;
                        break;
                    default:
                        buff.append(cc);
                        break;
                }
            }
            else{
                buff.append(cc);
            }
        }
        return buff.toString();
    }
}
