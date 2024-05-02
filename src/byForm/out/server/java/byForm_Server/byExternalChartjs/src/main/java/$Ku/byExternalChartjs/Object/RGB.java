package $Ku.byExternalChartjs.Object;

public class RGB extends $Ku.by.Object.ByObject {
    public java.lang.Integer r = 0;
    public java.lang.Integer g = 0;
    public java.lang.Integer b = 0;

    public RGB(java.lang.Integer f_r, java.lang.Integer f_g, java.lang.Integer f_b) {
        this.r = f_r;
        this.g = f_g;
        this.b = f_b;
    }


    public java.lang.String toJsFormat() {
        return "'rgb(" + this.r + "," + this.g + "," + this.b + ")'";
    }

    public $Ku.byExternalChartjs.Object.RGB $getThis$Ku_byExternalChartjs_Object_RGB() {
        return this;
    }
}
