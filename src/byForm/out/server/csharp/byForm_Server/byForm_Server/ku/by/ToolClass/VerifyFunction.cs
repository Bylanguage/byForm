using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
namespace byForm_Server.ku.by.ToolClass
{
    public class VerifyFunction
    {
        public static void FieldVerify(System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic, byForm_Server.ku.by.ToolClass.Field f_Field, object f_Value)
        {
            if (f_VerifyDic == null)
            {
                return;
            }
            //notnull提前检查
            if (f_Value == null || IsNull(f_Value.ToString()))
            {
                if (!CheckNotNullBeforeParse(f_VerifyDic))
                {
                    ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.ColumnNotNull, f_Field, f_Field.FieldType.ToString().ToLower()));
                }
                return;
            }
            switch (f_Field.FieldType)
            {
                case ku.DataTypeEnum.Bool:
                    bool boolValue;
                    if (!bool.TryParse(f_Value.ToString(), out boolValue))
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalBool1, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Byte:
                    sbyte byteValue;
                    if (sbyte.TryParse(f_Value.ToString(), out byteValue))
                    {
                        VerifyByte(f_Field, byteValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalByte, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Char:
                    char charValue;
                    if (char.TryParse(f_Value.ToString(), out charValue))
                    {
                        VerifyChar(f_Field, charValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalChar, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Datetime:
                    DateTime dateTimeValue;
                    if (DateTime.TryParse(f_Value.ToString(), out dateTimeValue))
                    {
                        VerifyDateTime(f_Field, dateTimeValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalDatetime, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Decimal:
                    decimal decimalValue;
                    if (decimal.TryParse(f_Value.ToString(), out decimalValue))
                    {
                        VerifyDecimal(f_Field, decimalValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalDecimal, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Double:
                    double doubleValue;
                    if (double.TryParse(f_Value.ToString(), out doubleValue))
                    {
                        VerifyDouble(f_Field, doubleValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalDouble, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Float:
                    float floatValue;
                    if (float.TryParse(f_Value.ToString(), out floatValue))
                    {
                        VerifyFloat(f_Field, floatValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalFloat, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Int:
                    int intValue;
                    //超出范围返回值也是false
                    if (int.TryParse(f_Value.ToString(), out intValue))
                    {
                        VerifyInteger(f_Field, intValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalInt, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Long:
                    long longValue;
                    if (long.TryParse(f_Value.ToString(), out longValue))
                    {
                        VerifyLong(f_Field, longValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalLong, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.Short:
                    short shortValue;
                    if (short.TryParse(f_Value.ToString(), out shortValue))
                    {
                        VerifyShort(f_Field, shortValue, f_VerifyDic);
                    }
                    else
                    {
                        ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.IlleagalShort, f_Field.Name, f_Value));
                    }
                    break;
                case ku.DataTypeEnum.String:
                    VerifyString(f_Field, f_Value.ToString(), f_VerifyDic);
                    break;
                case DataTypeEnum.Enum:
                    VerifyEnum(f_Field, f_Value.ToString(), f_Field.EnumType);
                    break;
            }
        }

        private static void VerifyByte(byForm_Server.ku.by.ToolClass.Field f_ColumnName, sbyte f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        sbyte tmpMax = sbyte.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "byte", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        byte tmpMin = byte.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "byte", tmpMin));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void VerifyChar(byForm_Server.ku.by.ToolClass.Field f_ColumnName, char f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        char tmpMax = char.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "char", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        char tmpMin = char.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "char", tmpMin));
                        }
                        break;
                }
            }
        }

        private static void VerifyDateTime(byForm_Server.ku.by.ToolClass.Field f_ColumnName, System.DateTime f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        DateTime tmpMax = DateTime.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "datetime", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        DateTime tmpMin = DateTime.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "datetime", tmpMin));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void VerifyDecimal(byForm_Server.ku.by.ToolClass.Field f_ColumnName, decimal f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        decimal tmpMax = decimal.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "decimal", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        decimal tmpMin = decimal.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "decimal", tmpMin));
                        }
                        break;
                    case ku.by.Enum.attribute.digit:
                        string tmpValue = f_Value.ToString();
                        var tmpArray = tmpValue.Split('.');
                        int tmpVerifyValue = Convert.ToInt32(item.Value);
                        if (tmpVerifyValue < 0)
                        {
                            break;
                        }
                        if (tmpArray.Length == 1)
                        {
                            break;
                        }
                        else
                        {
                            int tmpNum = tmpValue.Split('.')[1].Length;
                            if (tmpNum > tmpVerifyValue)
                            {
                                ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.VerifyDigit, f_ColumnName, "decimal", item.Value));
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void VerifyDouble(byForm_Server.ku.by.ToolClass.Field f_ColumnName, double f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        double tmpMax = double.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "double", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        double tmpMin = double.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "double", tmpMin));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void VerifyFloat(byForm_Server.ku.by.ToolClass.Field f_ColumnName, float f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        double tmpMax = double.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "float", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        double tmpMin = double.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "float", tmpMin));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void VerifyInteger(byForm_Server.ku.by.ToolClass.Field f_ColumnName, int f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        int tmpMax = int.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "int", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        int tmpMin = int.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "int", tmpMin));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void VerifyLong(byForm_Server.ku.by.ToolClass.Field f_ColumnName, long f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        long tmpMax = long.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "long", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        long tmpMin = long.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "long", tmpMin));
                        }
                        break;
                }
            }
        }

        private static void VerifyShort(byForm_Server.ku.by.ToolClass.Field f_ColumnName, short f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        short tmpMax = short.Parse(item.Value);
                        if (f_Value > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.BiggerthanMax, f_ColumnName, "short", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        short tmpMin = short.Parse(item.Value);
                        if (f_Value < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.SmallerthanMin, f_ColumnName, "short", tmpMin));
                        }
                        break;
                }
            }
        }

        private static void VerifyString(byForm_Server.ku.by.ToolClass.Field f_ColumnName, string f_Value, System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            foreach (var item in f_VerifyDic)
            {
                switch (item.Key)
                {
                    case ku.by.Enum.attribute.max:
                        int tmpMax = int.Parse(item.Value);
                        if (f_Value.Length > tmpMax)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.ColumnStringBiggerThanMax, f_ColumnName, "string", tmpMax));
                        }
                        break;
                    case ku.by.Enum.attribute.min:
                        int tmpMin = int.Parse(item.Value);
                        if (f_Value.Length < tmpMin)
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.ColumnStringLessThanMin, f_ColumnName, "string", tmpMin));
                        }
                        break;
                    case ku.by.Enum.attribute.pattern:
                        Regex tmpRegex = new Regex(item.Value);
                        if (!tmpRegex.IsMatch(f_Value))
                        {
                            ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.VerifyPattern, f_ColumnName, item.Value));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void VerifyEnum(byForm_Server.ku.by.ToolClass.Field f_ColumnName, string f_Value, System.Type f_EnumType)
        {
            //几个都不适用，仅检测是否为对应枚举值，为空则自动跳过，在生成sql程序中自动填充
            //eg.  by.enum.xxx=>path:Translator.RootName.ku.by.enum.xxx
            if (f_Value == null)
            {
                return;
            }
            var tmpType = f_EnumType;
            if (tmpType == null)
            {
                //路径出错找不到枚举
                var tmpArray = f_EnumType.ToString().Split('.');
                ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.CanNotFindEnumByPath, tmpArray[tmpArray.Length - 1]));
            }
            var tmpEnumFields = tmpType.GetFields(BindingFlags.Public | BindingFlags.Static);
            var tmpMatchEnum = tmpEnumFields.FirstOrDefault(item => item.Name == f_Value);
            if (tmpMatchEnum == null)
            {
                //枚举值不存在
                ThrowHelper.ThrowVerifyException(string.Format(ErrorInfo.CanNotFindEnumValue, f_Value));
            }
        }

        private static bool IsNull(string f_Value)
        {
            if (f_Value == null)
            {
                return true;
            }
            return false;
        }

        private static bool CheckNotNullBeforeParse(System.Collections.Generic.Dictionary<byForm_Server.ku.by.Enum.attribute, string> f_VerifyDic)
        {
            if (f_VerifyDic.ContainsKey(ku.by.Enum.attribute.notNull))
            {
                if (f_VerifyDic[ku.by.Enum.attribute.notNull] == "true")
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
}
