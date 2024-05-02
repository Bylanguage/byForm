package $Ku.by.Object;

import java.math.BigDecimal;
import java.math.RoundingMode;
public class Math extends $Ku.by.Object.ByObject {
    public static final double e = 2.718281828459045D;
    public static final double pi = 3.141592653589793D;
    public static final double ln2 = 0.6931471805599453D;
    public static final double ln10 = 2.302585092994046D;
    public static final double log2e = 1.4426950408889634D;
    public static final double log10e = 0.4342944819032518D;
    public static final double sqrt1_2 = 0.7071067811865476D;
    public static final double sqrt2 = 1.4142135623730951D;

    private Math() {
    }


    public static $Ku.by.Object.Decimal abs($Ku.by.Object.Decimal dcm) {
        return new $Ku.by.Object.Decimal(dcm.getValue().abs());
    }

    public static double random() {
        return java.lang.Math.random();
    }

    public static double abs(double d) {
        return java.lang.Math.abs(d);
    }

    public static float abs(float f) {
        return java.lang.Math.abs(f);
    }

    public static int abs(int i) {
        return java.lang.Math.abs(i);
    }

    public static long abs(long lng) {
        return java.lang.Math.abs(lng);
    }

    public static short abs(short sh) {
        return (short) java.lang.Math.abs(sh);
    }

    public static double acos(double d) {
        return java.lang.Math.acos(d);
    }

    public static double asin(double d) {
        return java.lang.Math.asin(d);
    }

    public static double atan(double d) {
        return java.lang.Math.atan(d);
    }

    public static double cbrt(double d) {
        return java.lang.Math.cbrt(d);
    }

    public static $Ku.by.Object.Decimal ceiling($Ku.by.Object.Decimal dcm) {
        return new $Ku.by.Object.Decimal(dcm.getValue().setScale(0, RoundingMode.CEILING));
    }

    public static double ceiling(double d) {
        return java.lang.Math.ceil(d);
    }

    public static double cos(double d) {
        return java.lang.Math.cos(d);
    }

    public static double cosh(double d) {
        return java.lang.Math.cosh(d);
    }

    public static double exp(double d) {
        return java.lang.Math.exp(d);
    }

    public static $Ku.by.Object.Decimal floor($Ku.by.Object.Decimal dcm) {
        return new $Ku.by.Object.Decimal(dcm.getValue().setScale(0, RoundingMode.FLOOR));
    }

    public static double floor(double d) {
        return java.lang.Math.floor(d);
    }

    public static double log(double d) {
        return java.lang.Math.log(d);
    }

    public static double log10(double d) {
        return java.lang.Math.log10(d);
    }

    public static $Ku.by.Object.Decimal round($Ku.by.Object.Decimal dcm) {
        return new $Ku.by.Object.Decimal(dcm.getValue().setScale(0, RoundingMode.HALF_UP));
    }

    public static double round(double d1) {
        BigDecimal dcm = new BigDecimal(String.valueOf(d1));
        return dcm.setScale(10, RoundingMode.HALF_UP).doubleValue();
    }

    public static int sign($Ku.by.Object.Decimal dcm) {
        return dcm.getValue().signum();
    }

    public static int sign(double d) {
        return (int)java.lang.Math.signum(d);
    }

    public static int sign(float f) {
        return (int)java.lang.Math.signum(f);
    }

    public static int sign(int i) {
        return (int) java.lang.Math.signum(i);
    }

    public static int sign(long lng) {
        return (int) java.lang.Math.signum(lng);
    }

    public static int sign(short sh) {
        return (int) java.lang.Math.signum(sh);
    }

    public static double sin(double d) {
        return java.lang.Math.sin(d);
    }

    public static double sinh(double d) {
        return java.lang.Math.sinh(d);
    }

    public static double sqrt(double d) {
        return java.lang.Math.sqrt(d);
    }

    public static double tan(double d) {
        return java.lang.Math.tan(d);
    }

    public static double tanh(double d) {
        return java.lang.Math.tanh(d);
    }

    public static double toDegrees(double d) {
        return java.lang.Math.toDegrees(d);
    }

    public static double toRadians(double d) {
        return java.lang.Math.toRadians(d);
    }

    public static double truncate($Ku.by.Object.Decimal dcm) {
        return dcm.getValue().divideAndRemainder(BigDecimal.ONE)[0].doubleValue();
    }

    public static double truncate(double d) {
        BigDecimal dcm = new BigDecimal(String.valueOf(d));
        return dcm.divideAndRemainder(BigDecimal.ONE)[0].doubleValue();
    }

    public static $Ku.by.Object.Decimal round($Ku.by.Object.Decimal dcm, int i) {
        return new $Ku.by.Object.Decimal(dcm.getValue().setScale(i, RoundingMode.HALF_UP));
    }

    public static double round(double d, int i) {
        BigDecimal dcm = new BigDecimal(String.valueOf(d));
        return dcm.setScale(i, RoundingMode.HALF_UP).doubleValue();
    }

    public static byte max(byte bt1, byte bt2) {
        return (byte) java.lang.Math.max(bt1,bt2);
    }

    public static $Ku.by.Object.Decimal max($Ku.by.Object.Decimal dcm1, $Ku.by.Object.Decimal dcm2) {
        return new $Ku.by.Object.Decimal(dcm1.getValue().max(dcm2.getValue()));
    }

    public static double max(double d1, double d2) {
        return java.lang.Math.max(d1,d2);
    }

    public static float max(float f1, float f2) {
        return java.lang.Math.max(f1,f2);
    }

    public static int max(int i1, int i2) {
        return java.lang.Math.max(i1,i2);
    }

    public static long max(long lng1, long lng2) {
        return java.lang.Math.max(lng1,lng2);
    }

    public static short max(short sh1, short sh2) {
        return (short) java.lang.Math.max(sh1,sh2);
    }

    public static byte min(byte bt1, byte bt2) {
        return (byte) java.lang.Math.min(bt1,bt2);
    }

    public static $Ku.by.Object.Decimal min($Ku.by.Object.Decimal dcm1, $Ku.by.Object.Decimal dcm2) {
        return new $Ku.by.Object.Decimal(dcm1.getValue().min(dcm2.getValue()));
    }

    public static double min(double d1, double d2) {
        return java.lang.Math.min(d1,d2);
    }

    public static float min(float f1, float f2) {
        return java.lang.Math.min(f1,f2);
    }

    public static int min(int i1, int i2) {
        return java.lang.Math.min(i1,i2);
    }

    public static long min(long lng1, long lng2) {
        return java.lang.Math.min(lng1,lng2);
    }

    public static short min(short sh1, short sh2) {
        return (short) java.lang.Math.min(sh1,sh2);
    }

    public static double pow(double d1, double d2) {
        return java.lang.Math.pow(d1,d2);
    }

    public static double log(double d1, double d2) {
        return java.lang.Math.log(d1)/java.lang.Math.log(d2);
    }

    public static double ieeeRemainder(double d1, double d2) {
        return java.lang.Math.IEEEremainder(d1,d2);
    }

    public static double atan2(double d1, double d2) {
        return java.lang.Math.atan2(d1,d2);
    }

    public static long bigMul(int i1, int i2) {
        return (long)i1 * (long) i2;
    }

    public static int addExact(int i1, int i2) {
        return java.lang.Math.addExact(i1,i2);
    }

    public static long addExact(long lng1, long lng2) {
        return java.lang.Math.addExact(lng1, lng2);
    }
}
