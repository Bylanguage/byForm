package $Ku.by.Object;

import java.math.RoundingMode;
public class DecimalUtil {
    public static $Ku.by.Object.Decimal add($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        $Ku.by.Object.Decimal result = new $Ku.by.Object.Decimal(d1.getValue().add(d2.getValue()).setScale(28, RoundingMode.HALF_UP));
        if (!check(result)) {
            throw new RuntimeException(result.toString() + "值溢出，应为 - 79228162514264337593543950335~79228162514264337593543950335");
        }
        return result;
    }

    public static $Ku.by.Object.Decimal sub($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        $Ku.by.Object.Decimal result = new $Ku.by.Object.Decimal(d1.getValue().subtract(d2.getValue()).setScale(28, RoundingMode.HALF_UP));
        if (!check(result)) {
            throw new RuntimeException(result.toString() + "值溢出，应为 - 79228162514264337593543950335~79228162514264337593543950335");
        }
        return result;
    }

    public static $Ku.by.Object.Decimal mul($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        $Ku.by.Object.Decimal result = new $Ku.by.Object.Decimal(d1.getValue().multiply(d2.getValue()).setScale(28, RoundingMode.HALF_UP));
        if (!check(result)) {
            throw new RuntimeException(result.toString() + "值溢出，应为 - 79228162514264337593543950335~79228162514264337593543950335");
        }
        return result;
    }

    public static $Ku.by.Object.Decimal div($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        $Ku.by.Object.Decimal result = new $Ku.by.Object.Decimal(d1.getValue().divide(d2.getValue(), 28, RoundingMode.HALF_UP));
        if (!check(result)) {
            throw new RuntimeException(result.toString() + "值溢出，应为 - 79228162514264337593543950335~79228162514264337593543950335");
        }
        return result;
    }

    public static $Ku.by.Object.Decimal mod($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        $Ku.by.Object.Decimal result = new $Ku.by.Object.Decimal(d1.getValue().divideAndRemainder(d2.getValue())[1]);
        if (!check(result)) {
            throw new RuntimeException(result.toString() + "值溢出，应为 - 79228162514264337593543950335~79228162514264337593543950335");
        }
        return result;
    }

    public static boolean greaterThan($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        int i = d1.getValue().compareTo(d2.getValue());
        return i > 0;
    }

    public static boolean lessThan($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        int i = d1.getValue().compareTo(d2.getValue());
        return i < 0;
    }

    public static boolean greaterThanOrEqual($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        int i = d1.getValue().compareTo(d2.getValue());
        return  i >= 0;
    }

    public static boolean lessThanOrEqual($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        int i = d1.getValue().compareTo(d2.getValue());
        return i <= 0;
    }

    public static boolean equals($Ku.by.Object.Decimal d1, $Ku.by.Object.Decimal d2) {
        return d1.getValue().compareTo(d2.getValue()) == 0;
    }

    public static boolean check($Ku.by.Object.Decimal result) {
             return !greaterThan(result, new $Ku.by.Object.Decimal($Ku.by.Object.Decimal.MAX)) && !lessThan(result, new $Ku.by.Object.Decimal($Ku.by.Object.Decimal.MIN));
    }
}
