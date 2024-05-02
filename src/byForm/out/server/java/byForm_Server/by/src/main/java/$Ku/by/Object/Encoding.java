package $Ku.by.Object;

import java.nio.charset.*;
public class Encoding extends $Ku.by.Object.ByObject {
    public java.nio.charset.Charset encoding;
    public static final $Ku.by.Object.Encoding ASCII = new Encoding("ASCII");
    public static final $Ku.by.Object.Encoding LATIN1 = new Encoding("LATIN1");
    public static final $Ku.by.Object.Encoding UNICODE = new Encoding("UNICODE");
    public static final $Ku.by.Object.Encoding UTF8 = new Encoding("UTF8");

    public Encoding(java.lang.String string) {
        switch (string) {
            case "ASCII":
                this.encoding = StandardCharsets.US_ASCII;
                break;
            case "LATIN1":
                this.encoding = StandardCharsets.ISO_8859_1;
                break;
            case "UNICODE":
                this.encoding = StandardCharsets.UTF_16LE;
                break;
            case "UTF8":
                this.encoding = StandardCharsets.UTF_8;
                break;
            default:
                throw new IllegalStateException("Unexpected value: " + string);
            }
    }
}
