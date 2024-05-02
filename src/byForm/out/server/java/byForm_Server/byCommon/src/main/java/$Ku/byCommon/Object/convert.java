package $Ku.byCommon.Object;

public class convert extends $Ku.by.Object.ByObject {
    private static java.lang.String base64;

    static {
        base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    }


    public convert() {
    }


    public static java.lang.String base64ToString(java.lang.Byte[] data) {
        java.lang.StringBuilder result = new java.lang.StringBuilder();
        java.lang.Integer i = 0;
        java.lang.Integer j = 0;
        java.lang.Byte[] octets = $Ku.by.ToolClass.ToolFunction.GenerateDefaultArray(Byte[].class, new int[]{4}, Byte.parseByte("0"));
        while (i < data.length) {
            octets[j++] = data[i++];
            if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(j, 3)) {
                result.append($Ku.by.ToolClass.StringUtil.charAt(base64, (octets[0] & 0xFC) >> 2));
                result.append($Ku.by.ToolClass.StringUtil.charAt(base64, ((octets[0] & 0x03) << 4) | ((octets[1] & 0xF0) >> 4)));
                result.append($Ku.by.ToolClass.StringUtil.charAt(base64, ((octets[1] & 0x0F) << 2) | ((octets[2] & 0xC0) >> 6)));
                result.append($Ku.by.ToolClass.StringUtil.charAt(base64, octets[2] & 0x3F));
                j = 0;
            }
        }
        if (!java.util.Objects.equals(j, 0)) {
            for (java.lang.Integer k = j; k < 3; k++) {
                octets[k] = 0;
            }
            result.append($Ku.by.ToolClass.StringUtil.charAt(base64, (octets[0] & 0xFC) >> 2));
            result.append($Ku.by.ToolClass.StringUtil.charAt(base64, ((octets[0] & 0x03) << 4) | ((octets[1] & 0xF0) >> 4)));
            if ($Ku.by.ToolClass.ToolFunction.ByPrimitiveTypeEquals(j, 1)) {
                result.append("==");
            }
            else {
                result.append($Ku.by.ToolClass.StringUtil.charAt(base64, ((octets[1] & 0x0F) << 2)));
                result.append("=");
            }
        }
        return result.toString();
    }

    public static java.lang.Byte[] base64ToBytes(java.lang.String base64String) {
        java.lang.Integer length = base64String.length();
        java.lang.Integer padding = base64String.endsWith("==") ? 2 : base64String.endsWith("=") ? 1 : 0;
        java.lang.Integer bufferLen = length * 3 / 4 - padding;
        java.lang.Byte[] buffer = $Ku.by.ToolClass.ToolFunction.GenerateDefaultArray(Byte[].class, new int[]{bufferLen}, Byte.parseByte("0"));
        java.lang.Integer bufferIdx = 0;
        for (java.lang.Integer i = 0; i < length; i += 4) {
            java.lang.Integer sextet0 = base64.indexOf($Ku.by.ToolClass.ToolFunction.toString($Ku.by.ToolClass.StringUtil.charAt(base64String, i)));
            java.lang.Integer sextet1 = base64.indexOf($Ku.by.ToolClass.ToolFunction.toString($Ku.by.ToolClass.StringUtil.charAt(base64String, i + 1)));
            java.lang.Integer sextet2 = base64.indexOf($Ku.by.ToolClass.ToolFunction.toString($Ku.by.ToolClass.StringUtil.charAt(base64String, i + 2)));
            java.lang.Integer sextet3 = base64.indexOf($Ku.by.ToolClass.ToolFunction.toString($Ku.by.ToolClass.StringUtil.charAt(base64String, i + 3)));
            java.lang.Byte b0 = $Ku.by.ToolClass.ToolFunction.castToByte(((sextet0 << 2) | (sextet1 >> 4)));
            java.lang.Byte b1 = $Ku.by.ToolClass.ToolFunction.castToByte((((sextet1 & 0x0F) << 4) | (sextet2 >> 2)));
            java.lang.Byte b2 = $Ku.by.ToolClass.ToolFunction.castToByte((((sextet2 & 0x03) << 6) | sextet3));
            buffer[bufferIdx++] = b0;
            if (bufferIdx < bufferLen) {
                buffer[bufferIdx++] = b1;
            }
            if (bufferIdx < bufferLen) {
                buffer[bufferIdx++] = b2;
            }
        }
        return buffer;
    }

    public $Ku.byCommon.Object.convert $getThis$Ku_byCommon_Object_convert() {
        return this;
    }
}
