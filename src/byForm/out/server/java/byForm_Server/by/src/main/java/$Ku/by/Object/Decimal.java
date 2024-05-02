package $Ku.by.Object;

import java.math.BigDecimal;
public class Decimal implements Cloneable  {
    private java.math.BigDecimal value;
    public final static $Ku.by.Object.Decimal MAX = new $Ku.by.Object.Decimal("79228162514264337593543950335");
    public final static $Ku.by.Object.Decimal MIN = new $Ku.by.Object.Decimal("-79228162514264337593543950335");

    public Decimal(java.lang.String input) {
        value = new BigDecimal(input);
    }

    public Decimal(java.lang.Double input) {
        value = BigDecimal.valueOf(input);
    }

    public Decimal(java.lang.Integer input) {
        value = new BigDecimal(input);
    }

    public Decimal(java.lang.Long input) {
        value = new BigDecimal(input);
    }

    public Decimal(java.math.BigDecimal input) {
        value = input;
    }

    public Decimal($Ku.by.Object.Decimal input) {
        value = input.value;
    }

    public Decimal(java.lang.Character input) {
        value = new BigDecimal(input);
    }


    public $Ku.by.Object.Decimal decimalPostfixIncrement() {
        $Ku.by.Object.Decimal oldValue = new $Ku.by.Object.Decimal(value);
        value = value.add(BigDecimal.ONE);
        return oldValue;
    }

    public $Ku.by.Object.Decimal decimalPostfixDecrement() {
        $Ku.by.Object.Decimal oldValue = new $Ku.by.Object.Decimal(value);
        value = value.subtract(BigDecimal.ONE);

        return oldValue;
    }

    public $Ku.by.Object.Decimal decimalPrefixIncrement() {
        value = value.add(BigDecimal.ONE);
        return this;
    }

    public $Ku.by.Object.Decimal decimalPrefixDecrement() {
        value = value.subtract(BigDecimal.ONE);
        return this;
    }

    public static $Ku.by.Object.Decimal parse(java.lang.String input) {
        return new $Ku.by.Object.Decimal(input);
    }

    public static $Ku.by.Object.Decimal minus($Ku.by.Object.Decimal input) {
        return $Ku.by.Object.DecimalUtil.sub(new $Ku.by.Object.Decimal(0), input);
    }

    public java.math.BigDecimal getValue() {
        return value;
    }

    public java.lang.String toString() {
        return value.toString();
    }

    public $Ku.by.Object.Decimal clone() {
        try {
            return ($Ku.by.Object.Decimal) super.clone();
        } catch (CloneNotSupportedException e) {
            throw new RuntimeException(e);
        }
    }

    public java.lang.Boolean byObjectEquals(Object obj) {
        if(obj instanceof $Ku.by.Object.Decimal){
            return value.equals((($Ku.by.Object.Decimal)obj).value);
        }
        return false;
    }

    public boolean equals(Object obj) {
        if(obj instanceof $Ku.by.Object.Decimal){
            return value.equals((($Ku.by.Object.Decimal)obj).value);
        }
        return false;
    }

    public int hashCode() {
        return value.hashCode();
    }

    public java.lang.Byte byteValue() {
        return value.byteValue();
    }

    public java.lang.Short shortValue() {
        return value.shortValue();
    }

    public java.lang.Integer intValue() {
        return value.intValue();
    }

    public java.lang.Long longValue() {
        return value.longValue();
    }

    public java.lang.Float floatValue() {
        return value.floatValue();
    }

    public java.lang.Double doubleValue() {
        return value.doubleValue();
    }

    public java.lang.Character charValue() {
        short s = value.shortValueExact();
        return (char)s;
    }
}
