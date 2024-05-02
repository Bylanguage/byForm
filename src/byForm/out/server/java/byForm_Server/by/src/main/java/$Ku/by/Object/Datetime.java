package $Ku.by.Object;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.regex.Pattern;
public class Datetime extends $Ku.by.Object.ByObject {
    public LocalDateTime value;

    public Datetime(LocalDateTime value) {
        this.value = value;
    }

    public Datetime() {
        this.value = LocalDateTime.of(1, 1, 1, 0, 0, 0);
    }


    public java.lang.Integer getYear() {
        return value.getYear();
    }

    public java.lang.Integer getMonth() {
        return value.getMonthValue();
    }

    public java.lang.Integer getDay() {
        return value.getDayOfMonth();
    }

    public java.lang.Integer getHour() {
        return value.getHour();
    }

    public java.lang.Integer getMinute() {
        return value.getMinute();
    }

    public java.lang.Integer getSecond() {
        return value.getSecond();
    }

    public java.lang.Integer getMilliSecond() {
        return value.getNano()/1000000;
    }

    public java.lang.Integer getDayOfWeekValue() {
        switch (value.getDayOfWeek()){
            case MONDAY:
                return 1;
            case TUESDAY:
                return 2;
            case WEDNESDAY:
                return 3;
            case THURSDAY:
                return 4;
            case FRIDAY:
                return 5;
            case SATURDAY:
                return 6;
            case SUNDAY:
                return 0;
            default:
                throw new RuntimeException("无法获取DayOfWeekValue");
        }
    }

    public $Ku.by.Enum.DayOfWeek getDayOfWeek() {
        switch (value.getDayOfWeek()){
            case MONDAY:
                return $Ku.by.Enum.DayOfWeek.monday;
            case TUESDAY:
                return $Ku.by.Enum.DayOfWeek.tuesday;
            case WEDNESDAY:
                return $Ku.by.Enum.DayOfWeek.wednesday;
            case THURSDAY:
                return $Ku.by.Enum.DayOfWeek.thursday;
            case FRIDAY:
                return $Ku.by.Enum.DayOfWeek.friday;
            case SATURDAY:
                return $Ku.by.Enum.DayOfWeek.saturday;
            case SUNDAY:
                return $Ku.by.Enum.DayOfWeek.sunday;
            default:
                throw new RuntimeException("无法获取DayofWeek");
        }
    }

    public static $Ku.by.Object.Datetime getNow() {
        return new $Ku.by.Object.Datetime(LocalDateTime.now());
    }

    public static $Ku.by.Object.Datetime parse(java.lang.String str) {
        String pattern1 = "\\d{4}-\\d{2}-\\d{2}";
        if(Pattern.matches(pattern1, str)){
            LocalDateTime value = LocalDate.parse(str).atStartOfDay();
            return new $Ku.by.Object.Datetime(value);
        }
        String[] strings = str.split("\\.");
        if(strings.length != 2){
            throw new RuntimeException("$Ku.by.Object.Datetime parse输入格式有误");
        }
        String SSS = strings[1];
        while (SSS.length() < 3){
            SSS += "0";
        }
        LocalDateTime value;
        if(SSS.length()==6){
            value = LocalDateTime.parse(strings[0] + "." + SSS, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss.SSSSSS"));
        }
        else if(SSS.length()==3){
            value = LocalDateTime.parse(strings[0] + "." + SSS, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss.SSS"));
        }
        else{
            value = LocalDateTime.parse(str, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss.SSSSSSS"));
        }
        return new $Ku.by.Object.Datetime(value);
    }

    public java.lang.Integer compareTo($Ku.by.Object.Datetime dt) {
        int result = this.value.compareTo(dt.value);
        return Integer.compare(result, 0);
    }

    public static java.lang.Integer compare($Ku.by.Object.Datetime dt1, $Ku.by.Object.Datetime dt2) {
        return dt1.compareTo(dt2);
    }

    public static $Ku.by.Object.Datetime create(java.lang.Integer year, java.lang.Integer month, java.lang.Integer dayOfMonth, java.lang.Integer hour, java.lang.Integer minute, java.lang.Integer second, java.lang.Integer milliSecond) {
        String yearStr = String.format("%04d", year);
        String monthStr = String.format("%02d", month);
        String dayStr = String.format("%02d", dayOfMonth);
        String hourStr = String.format("%02d", hour);
        String minuteStr = String.format("%02d", minute);
        String secondStr = String.format("%02d", second);
        String milliSecondStr = String.format("%03d", milliSecond);

        String string = yearStr+"-"+monthStr+"-"+dayStr+" "+hourStr+":"+minuteStr+":"+secondStr+"."+milliSecondStr;
        return new $Ku.by.Object.Datetime(LocalDateTime.parse(string, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss.SSS")));
    }

    public static $Ku.by.Object.Datetime create(java.lang.Integer year, java.lang.Integer month, java.lang.Integer dayOfMonth, java.lang.Integer hour, java.lang.Integer minute, java.lang.Integer second) {
        String yearStr = String.format("%04d", year);
        String monthStr = String.format("%02d", month);
        String dayStr = String.format("%02d", dayOfMonth);
        String hourStr = String.format("%02d", hour);
        String minuteStr = String.format("%02d", minute);
        String secondStr = String.format("%02d", second);

        String string = yearStr+"-"+monthStr+"-"+dayStr+" "+hourStr+":"+minuteStr+":"+secondStr;

        return new $Ku.by.Object.Datetime(LocalDateTime.parse(string, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss")));
    }

    public static $Ku.by.Object.Datetime create(java.lang.Integer year, java.lang.Integer month, java.lang.Integer dayOfMonth) {
        String yearStr = String.format("%04d", year);
        String monthStr = String.format("%02d", month);
        String dayStr = String.format("%02d", dayOfMonth);

        String string = yearStr+"-"+ monthStr +"-"+ dayStr;
        LocalDate localDate = LocalDate.parse(string, DateTimeFormatter.ISO_LOCAL_DATE);
        return new $Ku.by.Object.Datetime(localDate.atStartOfDay());
    }

    public java.lang.Double diffDays($Ku.by.Object.Datetime dt) {
        return (double) ChronoUnit.DAYS.between(dt.value, this.value);
    }

    public java.lang.Double diffHours($Ku.by.Object.Datetime dt) {
        return (double) ChronoUnit.HOURS.between(dt.value, this.value);
    }

    public java.lang.Double diffMinutes($Ku.by.Object.Datetime dt) {
        return (double) ChronoUnit.MINUTES.between(dt.value, this.value);
    }

    public java.lang.Double diffSeconds($Ku.by.Object.Datetime dt) {
        return (double) ChronoUnit.SECONDS.between(dt.value, this.value);
    }

    public java.lang.Double diffMilliseconds($Ku.by.Object.Datetime dt) {
        return (double) ChronoUnit.MILLIS.between(dt.value, this.value);
    }

    public $Ku.by.Object.Datetime addYears(java.lang.Integer num) {
        return new $Ku.by.Object.Datetime(this.value.plusYears(num));
    }

    public $Ku.by.Object.Datetime addMonths(java.lang.Integer num) {
        return new $Ku.by.Object.Datetime(this.value.plusMonths(num));
    }

    public $Ku.by.Object.Datetime addDays(java.lang.Integer num) {
        return new $Ku.by.Object.Datetime(this.value.plusDays(num));
    }

    public $Ku.by.Object.Datetime addHours(java.lang.Integer num) {
        return new $Ku.by.Object.Datetime(this.value.plusHours(num));
    }

    public $Ku.by.Object.Datetime addMinutes(java.lang.Integer num) {
        return new $Ku.by.Object.Datetime(this.value.plusMinutes(num));
    }

    public $Ku.by.Object.Datetime addSeconds(java.lang.Integer num) {
        return new $Ku.by.Object.Datetime(this.value.plusSeconds(num));
    }

    public $Ku.by.Object.Datetime addMilliseconds(java.lang.Integer num) {
        return new $Ku.by.Object.Datetime(this.value.plusNanos(num*1000000));
    }

    public java.lang.String format(java.lang.String pattern) {
        return this.value.format(DateTimeFormatter.ofPattern(pattern));
    }

    public static $Ku.by.Object.Datetime ConvertToDatetime(Object value) {
        if(value instanceof $Ku.by.Object.Datetime){
            return ($Ku.by.Object.Datetime) value;
        }
        else if(value instanceof java.time.LocalDateTime){
            return new $Ku.by.Object.Datetime((java.time.LocalDateTime)value);
        }
        else{
            return $Ku.by.Object.Datetime.parse(value.toString());
        }
    }

    public java.lang.String toString() {
        return this.value.format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss.SSS"));
    }

    public boolean equals(Object obj) {
        if(this == obj){
            return true;
        }
        else if(obj instanceof $Ku.by.Object.Datetime){
            return this.value.equals((($Ku.by.Object.Datetime)obj).value);
        }
        return false;
    }
}
