package $Ku.by.ToolClass;

import $Ku.by.ToolClass.ThrowHelper;
import java.util.regex.Pattern;
import java.math.BigDecimal;
import java.text.*;
import java.util.*;
public class VerifyFunction {
    public static void FieldVerify(java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic, $Ku.by.ToolClass.Sql.SqlField f_Field, java.lang.String f_Value) {
        if (f_VerifyDic == null)
		{
			return;
		}
		//notnull提前检查
		if (IsNull(f_Value))
		{
			if (!CheckNotNullBeforeParse(f_Value, f_VerifyDic))
			{
				$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.ColumnNotNull, f_Field.getName()));
			}
			return;
		}
		switch (f_Field.getFieldType())
		{
			case Bool:
				boolean boolValue = false;

				boolean tempVar = false;
				try {
					boolValue = Boolean.parseBoolean(f_Value);
				}catch (java.lang.Exception e){
					tempVar = true;
				}
				if (tempVar)
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalBool1, f_Field.getName(), f_Value));
				}
				break;
			case Byte:
				byte byteValue = 0;
				boolean tempVar2 = true;
				try {
					byteValue = Byte.parseByte(f_Value);
				}catch (java.lang.Exception e){
					tempVar2 = false;
				}
				if (tempVar2)
				{
					VerifyByte(f_Field.getName(), byteValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalByte, f_Field.getName(), f_Value));
				}
				break;
			case Char:
				char charValue = '\0';
				boolean tempVar3 = true;
				try {
					charValue = f_Value.charAt(0);
				}catch (java.lang.Exception e){
					tempVar3 =false;
				}
				if (tempVar3)
				{
					VerifyChar(f_Field.getName(), charValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalChar, f_Field.getName(), f_Value));
				}
				break;
			case Datetime:
				java.util.Date dateTimeValue = new java.util.Date(0);
				boolean tempVar4 = true;
				try {
					dateTimeValue = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").parse(f_Value);
				} catch (ParseException e) {
					tempVar4=false;
				}
				if (tempVar4)
				{
					VerifyDateTime(f_Field.getName(), dateTimeValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalDatetime, f_Field.getName(), f_Value));
				}
				break;
			case Decimal:
				java.math.BigDecimal decimalValue = new java.math.BigDecimal(0);
				boolean tempVar5 = true;
				try {
					decimalValue = new BigDecimal(f_Value);
				}catch (java.lang.Exception e){
					tempVar5 = false;
				}
				if (tempVar5)
				{
					VerifyDecimal(f_Field.getName(), decimalValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalDecimal, f_Field.getName(), f_Value));
				}
				break;
			case Double:
				double doubleValue = 0;
				boolean tempVar6 = true;
				try {
					doubleValue = Double.parseDouble(f_Value);
				}catch (java.lang.Exception e){
					tempVar6 = false;
				}
				if (tempVar6)
				{
					VerifyDouble(f_Field.getName(), doubleValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalDouble, f_Field.getName(), f_Value));
				}
				break;
			case Float:
				float floatValue = 0F;
				boolean tempVar7 = true;
				try {
					floatValue = Float.parseFloat(f_Value);
				}catch (java.lang.Exception e){
					tempVar7 = false;
				}
				if (tempVar7)
				{
					VerifyFloat(f_Field.getName(), floatValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalFloat, f_Field.getName(), f_Value));
				}
				break;
			case Int:
				int intValue = 0;
				//超出范围返回值也是false
				boolean tempVar8 = true;
				try {
					intValue = Integer.parseInt(f_Value);
				}catch (java.lang.Exception e){
					tempVar8 = false;
				}
				if (tempVar8)
				{
					VerifyInteger(f_Field.getName(), intValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalInt, f_Field.getName(), f_Value));
				}
				break;
			case Long:
				long longValue = 0;
				boolean tempVar9 = true;
				try {
					longValue = Long.parseLong(f_Value);
				}catch (java.lang.Exception e){
					tempVar9 = false;
				}
				if (tempVar9)
				{
					VerifyLong(f_Field.getName(), longValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalLong, f_Field.getName(), f_Value));
				}
				break;
			case Short:
				short shortValue = 0;
				boolean tempVar10 = true;
				try {
					shortValue = Short.parseShort(f_Value);
				}catch (java.lang.Exception e){
					tempVar10 = false;
				}
				if (tempVar10)
				{
					VerifyShort(f_Field.getName(), shortValue, f_VerifyDic);
				}
				else
				{
					$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.IllegalShort, f_Field.getName(), f_Value));
				}
				break;
			case String:
				VerifyString(f_Field.getName(), f_Value, f_VerifyDic);
				break;
			case Enum:
				VerifyEnum(f_Field.getName(), f_Value, f_Field.getEnumType());
				break;
			default:
				break;
		}
    }

    public static void VerifyByte(java.lang.String f_ColumnName, byte f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it =f_VerifyDic.entrySet().iterator();
		while (it.hasNext()) {
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					byte tmpMax = Byte.parseByte(item.getValue());
					if (f_Value > tmpMax)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					byte tmpMin = Byte.parseByte(item.getValue());
					break;
				default:
					break;
			}
		}
    }

    public static void VerifyChar(java.lang.String f_ColumnName, char f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
		while (it.hasNext())
		//for (var item : f_VerifyDic)
		{
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					char tmpMax = item.getValue().charAt(0);
					if (f_Value > tmpMax)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					char tmpMin = item.getValue().charAt(0);
					if (f_Value < tmpMin)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.SmallerthanMin, f_ColumnName, f_Value));
					}
					break;
				default:
					break;
			}
		}
    }

    public static void VerifyDateTime(java.lang.String f_ColumnName, java.util.Date f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
        DateFormat fmt =new SimpleDateFormat("yyyy-MM-dd");
		while (it.hasNext()) {
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					Date tmpMax = null;
					try {
						tmpMax = fmt.parse(item.getValue());
					} catch (ParseException e) {
						throw new RuntimeException(e);
					}
					if (f_Value.compareTo(tmpMax) > 0)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					Date tmpMin = null;
					try {
						tmpMin = fmt.parse(item.getValue());
					} catch (ParseException e) {
						throw new RuntimeException(e);
					}
					if (f_Value.compareTo(tmpMin) < 0)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.SmallerthanMin, f_ColumnName, f_Value));
					}
					break;
				case pattern:
					String tmpDatetime = item.getValue();
					Date tmpDatetime2 = null;
					try {
						tmpDatetime2 = fmt.parse(tmpDatetime);
					} catch (ParseException e) {
						throw new RuntimeException(e);
					}
					if (!f_Value.equals(tmpDatetime2))
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.VerifyFormatError, f_ColumnName, tmpDatetime));
					}
					break;
				default:
					break;
			}
		}
    }

    public static void VerifyDecimal(java.lang.String f_ColumnName, java.math.BigDecimal f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
		while (it.hasNext()) {
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					java.math.BigDecimal tmpMax = new java.math.BigDecimal(item.getValue());
					if (f_Value.compareTo(tmpMax) > 0)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					java.math.BigDecimal tmpMin = new java.math.BigDecimal(item.getValue());
					if (f_Value.compareTo(tmpMin) < 0)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.SmallerthanMin, f_ColumnName, f_Value));
					}
					break;
				case digit:
					String tmpValue = f_Value.toString();

					String[] tmpArray = tmpValue.split("[.]", -1);
					if (tmpArray.length == 1)
					{
						if (Integer.parseInt(item.getValue()) != 0)
						{
							$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.VerifyDigit, f_ColumnName, f_Value));
						}
					}
					else
					{
						int tmpNum = tmpValue.split("[.]", -1)[1].length();
						if (tmpNum != Integer.parseInt(item.getValue()))
						{
							$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.VerifyDigit, f_ColumnName, f_Value));
						}
					}
					break;
				default:
					break;
			}
		}
    }

    public static void VerifyDouble(java.lang.String f_ColumnName, double f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
		while (it.hasNext()) {
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					double tmpMax = Double.parseDouble(item.getValue());
					if (f_Value > tmpMax)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					double tmpMin = Double.parseDouble(item.getValue());
					if (f_Value < tmpMin)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.SmallerthanMin, f_ColumnName, f_Value));
					}
					break;
				default:
					break;
			}
		}
    }

    public static void VerifyFloat(java.lang.String f_ColumnName, float f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
		while (it.hasNext()) {
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					float tmpMax = Float.parseFloat(item.getValue());

					break;
			}
		}
    }

    public static void VerifyInteger(java.lang.String f_ColumnName, int f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
		while (it.hasNext())
		{
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					int tmpMax = Integer.parseInt(item.getValue());
					if (f_Value > tmpMax)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					int tmpMin = Integer.parseInt(item.getValue());
					if (f_Value < tmpMin)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.SmallerthanMin, f_ColumnName, f_Value));
					}
					break;
				default:
					break;
			}
		}
    }

    public static void VerifyLong(java.lang.String f_ColumnName, long f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
		while (it.hasNext()) {
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					long tmpMax = Long.parseLong(item.getValue());
					if (f_Value > tmpMax)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					long tmpMin = Long.parseLong(item.getValue());
					if (f_Value < tmpMin)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.SmallerthanMin, f_ColumnName, f_Value));
					}
					break;
			}
		}
    }

    public static void VerifyShort(java.lang.String f_ColumnName, short f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
		while (it.hasNext()) {
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					short tmpMax = Short.parseShort(item.getValue());
					if (f_Value > tmpMax)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					short tmpMin = Short.parseShort(item.getValue());
					if (f_Value < tmpMin)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.SmallerthanMin, f_ColumnName, f_Value));
					}
					break;
			}
		}
    }

    public static void VerifyString(java.lang.String f_ColumnName, java.lang.String f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        Iterator<Map.Entry<$Ku.by.Enum.Attribute, String>> it = f_VerifyDic.entrySet().iterator();
		while (it.hasNext())
		{
			Map.Entry<$Ku.by.Enum.Attribute, String> item = it.next();
			switch (item.getKey())
			{
				case max:
					int tmpMax = Integer.parseInt(item.getValue());
					if (f_Value.length() > tmpMax)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.BiggerthanMax, f_ColumnName, f_Value));
					}
					break;
				case min:
					int tmpMin = Integer.parseInt(item.getValue());
					if (f_Value.length() < tmpMin)
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.SmallerthanMin, f_ColumnName, f_Value));
					}
					break;
				case pattern:
					String tmpRegex = item.getValue();
					//if (!tmpRegex.IsMatch(f_Value))
					if (!Pattern.matches(tmpRegex,f_Value))
					{
						$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.VerifyPattern, f_ColumnName, f_Value));
					}
					break;
				default:
					break;
			}
		}
    }

    public static void VerifyEnum(java.lang.String f_ColumnName, java.lang.String f_Value, java.lang.Class<?> f_EnumType) {
        //几个都不适用，仅检测是否为对应枚举值，为空则自动跳过，在生成sql程序中自动填充
		//eg.  by.enum.xxx=>path:Transpiler.RootName.$Ku.by.enum.xxx
		if (f_Value == null)
		{
			return;
		}
		Class tmpType = f_EnumType;
		if (tmpType == null)
		{
			//路径出错找不到枚举
			String[] tmpArray = f_EnumType.toString().split("[.]", -1);
			$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.CanNotFindEnumByPath, tmpArray[tmpArray.length - 1]));
		}

		java.lang.reflect.Field[] tmpEnumFields = tmpType.getFields();
		java.lang.reflect.Field tmpMatchEnum = null;
		for (java.lang.reflect.Field item:tmpEnumFields){
			if (f_Value.equals(item.getName())){
				tmpMatchEnum = item;
				break;
			}
		}
		if (tmpMatchEnum == null)
		{
			//枚举值不存在
			$Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.CanNotFindEnumValue, f_Value));
		}
    }

    public static boolean IsNull(java.lang.String f_Value) {
        if (f_Value == null)
		{
			return true;
		}
		return false;
    }

    public static boolean CheckNotNullBeforeParse(java.lang.String f_Value, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String> f_VerifyDic) {
        if (f_VerifyDic.containsKey($Ku.by.Enum.Attribute.notNull))
		{
			if (f_VerifyDic.get($Ku.by.Enum.Attribute.notNull).equals("true"))
			{
				return false;
			}
			return true;
		}
		else
		{
			//可以为空
			return true;
		}
    }
}
