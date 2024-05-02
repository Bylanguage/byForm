package $Ku.byExternalChartjs.Object;

public class RGBA extends $Ku.byExternalChartjs.Object.RGB {
    public $Ku.by.Object.Decimal a = $Ku.by.Object.Decimal.parse("0") ;

    public RGBA(java.lang.Integer f_r, java.lang.Integer f_g, java.lang.Integer f_b, $Ku.by.Object.Decimal f_a) {
        super(f_r, f_g, f_b);
        this.a = f_a.clone();
    }

    public RGBA(java.lang.Integer[] f_rgb, $Ku.by.Object.Decimal f_a) {
        super(f_rgb[0], f_rgb[1], f_rgb[2]);
        this.a = f_a.clone();
    }


    public java.lang.String toJsFormat() {
        return "'rgba(" + this.r + "," + this.g + "," + this.b + "," + this.a.toString() + ")'";
    }

    public $Ku.byExternalChartjs.Object.RGBA $getThis$Ku_byExternalChartjs_Object_RGBA() {
        return this;
    }
}
