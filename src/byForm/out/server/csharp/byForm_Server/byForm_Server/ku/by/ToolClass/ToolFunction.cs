using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;
using byForm_Server.ku.by.ToolClass.Sql;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.by.ToolClass
{
    public class ToolFunction
    {
        public readonly static System.Type charType;

        public readonly static System.Type byteType;

        public readonly static System.Type shortType;

        public readonly static System.Type intType;

        public readonly static System.Type longType;

        public readonly static System.Type floatType;

        public readonly static System.Type doubleType;

        public readonly static System.Type decimalType;

        public readonly static System.Type boolType;

        public readonly static System.Type stringType;

        public readonly static System.Type dateTimeType;

        static ToolFunction()
        {
            charType = typeof(char);
            byteType = typeof(sbyte);
            shortType = typeof(short);
            intType = typeof(int);
            longType = typeof(long);
            floatType = typeof(float);
            doubleType = typeof(double);
            decimalType = typeof(decimal);
            boolType = typeof(bool);
            stringType = typeof(string);
            dateTimeType = typeof(ku.by.Object.datetime);
        }

        public static T CrateArray<T>(params int[] dims)
        {
            var type = typeof(T);
            if (!type.IsArray)
                throw new System.ArgumentException(typeof(T) + " 不是数组类型。");

            if (dims == null)
                throw new System.ArgumentNullException("dims");

            if (dims.Length == 0)
                throw new System.ArgumentException("初始维度数组 dims 的长度为零。");

            return (T)CreateArray(typeof(T), dims);
        }

        public static object CreateArray(System.Type type, int[] dims, int index = 0)
        {
            if (dims.Length <= index)
            {
                if (type.IsEnum)
                {
                    var fields = type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Default);
                    if (fields.Length == 0)
                        throw new Exception("数组类型内包含的枚举类型未声明任何枚举成员，无法初始化。");
                    else
                        return fields[0].GetValue(null);
                }
                else if (type.IsValueType)
                    return System.Activator.CreateInstance(type);
                else
                    return null;
            }

            if (!type.IsArray)
                throw new System.ArgumentException("数组类型的秩长度小于 dims 的长度。");

            var itemType = type.GetElementType();
            var dim = dims[index];

            var array = System.Array.CreateInstance(itemType, dim);
            for (int i = 0; i < dim; i++)
                array.SetValue(CreateArray(itemType, dims, index + 1), i);
            return array;
        }

        public static T[] GetValues<T>()
        {
            var tmpType = typeof(T);
            var tmpArrayType = System.Enum.GetValues(tmpType);
            return (T[])tmpArrayType;
        }

        public static T ValueOf<T>(string f_Value)
        {
            var tmpType = typeof(T);
            var tmpValue = System.Enum.Parse(tmpType, f_Value);
            return (T)tmpValue;
        }

        public static string ObjTypeToString(System.Type f_Type)
        {
            string tmpFullName = f_Type.FullName;
            string tmpTypeName = f_Type.Name;
            string[] tmpFullNameParts = tmpFullName.Split('.');
            //身份类型需要实例做判断,泛型无法获取
            //var tmpIdentity = f_Type.GetProperty("Identity");
            if (tmpFullNameParts[1] == "ku")
            {
                //自定义类 xxx..ku.kuname.Object.objname
                //if (tmpFullNameParts.Length != 5)
                //{
                //    throw new Exception(string.Format(ErrorInfo.TypeFullNameError, tmpFullName));
                //}
                string tmpKuName = tmpFullNameParts[2];
                return tmpKuName + ".object." + tmpTypeName;
            }
            else
            {
                string tmpBytName;
                //预设类
                if (!Root.GetInstance().PreinstallClassNameDic.TryGetValue(tmpTypeName, out tmpBytName))
                {
                    throw new Exception(string.Format(ErrorInfo.TypePreInstallNameError, tmpTypeName));
                }

                string tmpReturnValue = "by.object." + tmpBytName;

                if (!f_Type.IsGenericType)
                {
                    return tmpReturnValue;
                }
                else
                {
                    StringBuilder tmpValue = new StringBuilder(tmpReturnValue);
                    tmpValue.Append("<");
                    for (int i = 0; i < f_Type.GenericTypeArguments.Length; i++)
                    {
                        if (i != 0)
                        {
                            tmpValue.Append(", ");
                        }

                        var tmpTypeArgument = f_Type.GenericTypeArguments[i];
                        tmpValue.Append(ObjTypeToString(tmpTypeArgument));
                    }
                    tmpValue.Append(">");
                    return tmpValue.ToString();
                }
            }
        }

        public static string GetKuInSql(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_Parameter)
        {
            if (f_Parameter.Paramters.Count == 0)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.TranHasNoSqlCanNotFindExecKu);
            }

            string tmpKuName = null;
            bool tmpAssigned = false;
            foreach (var item in f_Parameter.Paramters)
            {
                if (item.TableSourceList.Count == 0)
                {
                    if (item.ParameterList.Count != 0)
                    {
                        var tmpRowParameter = item.ParameterList[0];

                        if (tmpRowParameter is Row)
                        {
                            var tmpRow = tmpRowParameter as Row;

                            if (tmpRow == null || tmpRow.Identity == null || tmpRow.Identity.to == null || !(tmpRow.Identity.to is IBaseDataSheet))
                            {
                                 ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
                            }

                            string tmpNewRowKuName = (tmpRow.Identity.to as IBaseDataSheet).KuName;

                            if (tmpKuName != tmpNewRowKuName && tmpAssigned)
                            {
                                HashSet<string> strings = new HashSet<string>();
                                StringBuilder tmpErrorValue = new StringBuilder();

                                foreach (var paramter in f_Parameter.Paramters)
                                {
                                    foreach (var table in paramter.TableSourceList)
                                    {
                                        var tmpDataSheet = table.GetSource();
                                        string tmpSheetName = tmpDataSheet.KuName + "." + tmpDataSheet.SheetName;

                                        if (strings.Contains(tmpSheetName))
                                        {
                                            continue;
                                        }

                                        strings.Add(tmpSheetName);

                                        if (tmpErrorValue.Length != 0)
                                        {
                                            tmpErrorValue.Append(", ");
                                        }

                                        tmpErrorValue.Append(tmpSheetName);
                                    }
                                }

                                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.TranHasDiffenentExecKu + tmpErrorValue);
                            }

                            if (tmpKuName != tmpNewRowKuName)
                            {
                                tmpKuName = tmpNewRowKuName;
                                tmpAssigned = true;
                            }
                        }
                        else if (tmpRowParameter is ICollection<Row>)
                        {
                            var tmpRows = tmpRowParameter as ICollection<Row>;

                            foreach (var tmpRow in tmpRows)
                            {
                                if (tmpRow == null || tmpRow.Identity == null || tmpRow.Identity.to == null || !(tmpRow.Identity.to is IBaseDataSheet))
                                {
                                    continue;
                                }

                                string tmpNewRowKuName = (tmpRow.Identity.to as IBaseDataSheet).KuName;

                                if (tmpKuName != tmpNewRowKuName && tmpAssigned)
                                {
                                    HashSet<string> tmpSheetNames = new HashSet<string>();
                                    StringBuilder tmpErrorValue = new StringBuilder();

                                    foreach (var row in tmpRows)
                                    {
                                        if (row == null || row.Identity == null || row.Identity.to == null || !(row.Identity.to is IBaseDataSheet))
                                        {
                                            continue;
                                        }

                                        var tmpDataSheet = row.Identity.to as IBaseDataSheet;
                                        string tmpSheetName = tmpDataSheet.KuName + "." + tmpDataSheet.SheetName;

                                        if (tmpSheetNames.Contains(tmpSheetName))
                                        {
                                            continue;
                                        }

                                        if (tmpErrorValue.Length != 0)
                                        {
                                            tmpErrorValue.Append(", ");
                                        }

                                        tmpErrorValue.Append(tmpSheetName);
                                    }

                                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.TranHasDiffenentExecKu + tmpErrorValue);
                                }

                                if (tmpKuName != tmpNewRowKuName)
                                {
                                    tmpKuName = tmpNewRowKuName;
                                    tmpAssigned = true;
                                }
                            }
                        }
                        else
                        {
                            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
                        }
                    }
                    else
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
                    }

                    continue;
                }
                else
                {
                    foreach (var tablesource in item.TableSourceList)
                    {
                        string tmpNewKuName = tablesource.GetSource().KuName;

                        if (tmpKuName != tmpNewKuName && tmpAssigned)
                        {
                            HashSet<string> tmpSheetNames = new HashSet<string>();
                            StringBuilder tmpErrorValues = new StringBuilder();

                            foreach (var table in item.TableSourceList)
                            {
                                var tmpDataSheet = table.GetSource();
                                string tmpSheetName = tmpDataSheet.KuName + "." + tmpDataSheet.SheetName;

                                if (tmpSheetNames.Contains(tmpSheetName))
                                {
                                    continue;
                                }

                                tmpSheetNames.Add(tmpSheetName);

                                if (tmpErrorValues.Length != 0)
                                {
                                    tmpErrorValues.Append(", ");
                                }

                                tmpErrorValues.Append(tmpSheetName);
                            }

                            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.TranHasDiffenentExecKu + tmpErrorValues);
                        }

                        if (tmpKuName != tmpNewKuName)
                        {
                            tmpKuName = tmpNewKuName;
                            tmpAssigned = true;
                        }
                    }
                }
            }

            if (tmpKuName == null)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
            }

            f_Parameter.ExecuteKuName = tmpKuName;
            return tmpKuName;
        }

        public static string GetKuInSql(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            if (f_Parameter.TableSourceList.Count == 0)
            {
                if (f_Parameter.ParameterList.Count != 0)
                {
                    if (f_Parameter.ParameterList[0] is Row)
                    {
                        var tmpRow = f_Parameter.ParameterList[0] as Row;

                        if (tmpRow == null || tmpRow.Identity == null || tmpRow.Identity.to == null || !(tmpRow.Identity.to is IBaseDataSheet))
                        {
                            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
                        }

                        f_Parameter.TableSourceList.Add(new Table(tmpRow.Identity.to as IBaseDataSheet, null));
                        var tmpRowDataSheet = tmpRow.Identity.to as IBaseDataSheet;

                        if (tmpRowDataSheet == null)
                        {
                            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
                        }

                        return tmpRowDataSheet.KuName;
                    }
                    else if (f_Parameter.ParameterList[0] is ICollection<Row>)
                    {
                        string tmpKuName = null;
                        string tmpRealKuName = null;
                        var tmpRows = f_Parameter.ParameterList[0] as ICollection<Row>;

                        foreach (var tmpRow in tmpRows)
                        {
                            if (tmpRow == null || tmpRow.Identity == null || tmpRow.Identity.to == null || !(tmpRow.Identity.to is IBaseDataSheet))
                            {
                                continue;
                            }

                            var tmpRowDataSheet = tmpRow.Identity.to as IBaseDataSheet;

                            if (f_Parameter.TableSourceList.Find(item => item.GetSource() != tmpRowDataSheet) == null)
                            {
                                f_Parameter.TableSourceList.Add(new Table(tmpRowDataSheet, null));
                            }

                            string tmpNewRowKuName = (tmpRow.Identity.to as IBaseDataSheet).KuName;

                            if (tmpKuName == null)
                            {
                                tmpKuName = tmpNewRowKuName;
                            }
                            else
                            {
                                if (tmpKuName != tmpNewRowKuName)
                                {
                                    HashSet<string> tmpSheetNames = new HashSet<string>();
                                    StringBuilder tmpErrorValue = new StringBuilder();

                                    foreach (var row in tmpRows)
                                    {
                                        if (row == null || row.Identity == null || row.Identity.to == null || !(row.Identity.to is IBaseDataSheet))
                                        {
                                            continue;
                                        }

                                        var datasheet = row.Identity.to as IBaseDataSheet;
                                        string tmpSheetName = datasheet.KuName + "." + datasheet.SheetName;

                                        if (!tmpSheetNames.Contains(tmpSheetName))
                                        {
                                            continue;
                                        }

                                        tmpSheetNames.Add(tmpSheetName);
                                        
                                        if (tmpErrorValue.Length != 0)
                                        {
                                            tmpErrorValue.Append(", ");
                                        }

                                        tmpErrorValue.Append(tmpSheetName);
                                    }

                                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.TranHasDiffenentExecKu + tmpErrorValue);
                                }
                            }
                        }

                        if (tmpKuName == null)
                        {
                            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
                        }
                        else
                        {
                            return tmpKuName;
                        }
                    }
                    else
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
                    }
                }
                else
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
                }

            }

            var tmpDataSheet = f_Parameter.TableSourceList[0].GetSource();

            if (tmpDataSheet == null)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasNoTableCanNotFindExecKu);
            }

            return tmpDataSheet.KuName;
        }

        public static object CellValueNullToDefault(byForm_Server.ku.DataTypeEnum f_TypeEnum, System.Type f_EnumType)
        {
            switch (f_TypeEnum)
            {
                case DataTypeEnum.Bool:
                    return false;
                case DataTypeEnum.Byte:
                    return (sbyte)0;
                case DataTypeEnum.Char:
                    return '\0';
                case DataTypeEnum.Datetime:
                    return datetime.GetDefault();
                case DataTypeEnum.Decimal:
                    return (decimal)0;
                case DataTypeEnum.Double:
                    return (double)0;
                case DataTypeEnum.Enum:
                    if (f_EnumType == null)
                    {
                        throw ThrowHelper.ThrowUnKnownException("枚举类型未填充");
                    }

                    var tmpEnums = System.Enum.GetValues(f_EnumType);

                    if (tmpEnums.Length == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return tmpEnums.GetValue(0);
                    }
                case DataTypeEnum.Float:
                    return (float)0;
                case DataTypeEnum.Int:
                    return 0;
                case DataTypeEnum.Long:
                    return (long)0;
                case DataTypeEnum.Short:
                    return (short)0;
                default:
                    return "";
            }
        }

        public static string CellValueNullToDefaultReturnString(byForm_Server.ku.DataTypeEnum f_TypeEnum, System.Type f_EnumType, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            switch (f_TypeEnum)
            {
                case DataTypeEnum.Bool:
                case DataTypeEnum.Byte:
                case DataTypeEnum.Decimal:
                case DataTypeEnum.Double:
                case DataTypeEnum.Float:
                case DataTypeEnum.Int:
                case DataTypeEnum.Long:
                case DataTypeEnum.Short:
                    return "0";
                case DataTypeEnum.Char:
                    return "'" + '\0'.ToString() + "'";
                case DataTypeEnum.Datetime:
                    if (f_DBType == DBTypeEnum.Oracle)
                    {
                        return "TO_TIMESTAMP('" + default(DateTime).ToString() + "', 'YYYY-MM-DD HH24:MI:SS.FF')";
                    }
                    else
                    {
                        return "'" + default(DateTime).ToString() + "'";
                    }
                case DataTypeEnum.String:
                    return "''";
                case DataTypeEnum.Enum:
                    if (f_EnumType == null)
                    {
                        throw ThrowHelper.ThrowUnKnownException("枚举类型未填充");
                    }
                    var tmpEnums = System.Enum.GetValues(f_EnumType);
                    if (tmpEnums.Length == 0)
                    {
                        return "''";
                    }
                    else
                    {
                        return  "'" + tmpEnums.GetValue(0).ToString() + "'";
                    }
                default:
                    throw ThrowHelper.ThrowUnKnownException("单元格类型填充错误，无法由null转化为默认值");
            }
        }

        public static string ConvertType(object f_Value, byForm_Server.ku.DataTypeEnum f_Type)
        {
            if (f_Value == null)
            {
                return "NULL";
            }
            switch (f_Type)
            {
                case DataTypeEnum.Bool:
                    if (!(f_Value is bool))
                    {
                        ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.IlleagalBool1, f_Value.ToString()));
                    }
                    if (f_Value.ToString().ToLower() == "true")
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
                case DataTypeEnum.String:
                case DataTypeEnum.Enum:
                case DataTypeEnum.Datetime:
                case DataTypeEnum.Char:
                    return SaveInspect.CharactorEscape(f_Value.ToString());
                default:
                    return f_Value.ToString();
            }
        }

        public static string ConvertBool(object f_Value)
        {
            if (f_Value == null)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.BoolTypParameterError, "null"));
            }

            if (f_Value is bool)
            {
                var tmpValue = (bool)f_Value;

                if (tmpValue)
                {
                    return "1";
                }

                return "0";
            }
            else
            {
               throw ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.BoolTypParameterError, f_Value));
            }
        }

        public static string ConvertBoolInWhere(object f_Value)
        {
            if (f_Value == null)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.BoolTypParameterError, "null"));
            }
            if (f_Value is bool)
            {
                bool tmpValue = (bool)f_Value;
                if (tmpValue)
                {
                    return "1 = 1";
                }
                else
                {
                    return "0 = 1";
                }
            }

            throw ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.BoolTypParameterError, f_Value));
        }

        public static T GetIdentity<T>(byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity) where T : byForm_Server.ku.by.ToolClass.AbstractIdentityBase
        {
            T tmpIdentity = f_Identity as T;
            if (tmpIdentity == null)
            {
                Type tmpIdentityType = typeof(T);
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.ConvertIdentityError, tmpIdentityType.Name));
            }
            return tmpIdentity;
        }

        public static T GetIdentityOfTildeValue<T>(byForm_Server.ku.by.ToolClass.IIdentity f_Object) where T : byForm_Server.ku.by.ToolClass.AbstractIdentityBase
        {
            if (f_Object == null)
            {
                return null;
            }

            if (f_Object.Identity == null)
            {
                return null;
            }

            return f_Object.Identity as T;
        }

        public static byForm_Server.ku.by.Object.list<T> GetIdentityCollection<T>(System.Collections.IEnumerable f_Value) where T : byForm_Server.ku.by.ToolClass.AbstractIdentityBase
        {
            if (f_Value == null)
            {
                return null;
            }

            list<T> tmpList = new list<T>();

            foreach (var item in f_Value)
            {
                if (item == null)
                {
                    tmpList.add(null);
                }

                IIdentity tmpValue = item as IIdentity;

                if (tmpValue == null)
                {
                    ThrowHelper.ThrowUnKnownException("GetIdentityCollection Error");
                }

                tmpList.add((T)tmpValue.Identity);
            }

            return tmpList;
        }

        public static string SqlserverSetAssignmentExpression(byForm_Server.ku.by.ToolClass.Sql.TableField f_TableField, string f_Operator, object f_Value, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> f_SetFields, System.Text.StringBuilder f_Set)
        {
            if (f_SetFields.Contains(f_TableField.SelectedField))
            {
                return "";
            }

            StringBuilder tmpValue = new StringBuilder();

            if (f_Set.Length != 5)
            {
                tmpValue.Append(", ");
            }

            tmpValue.Append(f_TableField.FieldAccess);
            tmpValue.Append(f_Operator);

            if (f_Value == null)
            {
                var tmpField = f_TableField.SelectedField;
                tmpValue.Append(CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, DBTypeEnum.SqlServer));
            }
            else
            {
                tmpValue.Append(f_Value);
            }

            f_SetFields.Add(f_TableField.SelectedField);
            return tmpValue.ToString();
        }

        public static string MySqlSetAssignmentExpression(byForm_Server.ku.by.ToolClass.Sql.TableField f_TableField, string f_Operator, object f_Value, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> f_SetFields, System.Text.StringBuilder f_Set)
        {
            if (f_SetFields.Contains(f_TableField.SelectedField))
            {
                return "";
            }

            StringBuilder tmpValue = new StringBuilder();

            if (f_Set.Length != 5)
            {
                tmpValue.Append(", ");
            }

            tmpValue.Append(f_TableField.FieldAccess);
            tmpValue.Append(" = ");
            object tmpUpdateValue = f_Value;
            if (f_Value == null)
            {
                var tmpField = f_TableField.SelectedField;
                tmpUpdateValue = CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, DBTypeEnum.Mysql);
            }

            if (!string.IsNullOrEmpty(f_Operator))
            {
                tmpValue.Append(f_TableField.FieldAccess);
                tmpValue.Append(f_Operator);
            }

            tmpValue.Append(tmpUpdateValue);
            f_SetFields.Add(f_TableField.SelectedField);
            return tmpValue.ToString();
        }

        public static string OracleSetAssignmentExpression(byForm_Server.ku.by.ToolClass.Sql.TableField f_TableField, string f_Operator, object f_Value, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> f_SetFields, System.Text.StringBuilder f_Set)
        {
            if (f_SetFields.Contains(f_TableField.SelectedField))
            {
                return "";
            }

            StringBuilder tmpValue = new StringBuilder();

            if (f_Set.Length != 5)
            {
                tmpValue.Append(", ");
            }

            tmpValue.Append(f_TableField.FieldAccess);
            tmpValue.Append(" = ");
            object tmpUpdateValue = f_Value;
            if (f_Value == null)
            {
                var tmpField = f_TableField.SelectedField;
                tmpUpdateValue = CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, DBTypeEnum.Oracle);
            }

            f_SetFields.Add(f_TableField.SelectedField);

            if (!string.IsNullOrEmpty(f_Operator))
            {
                if (f_Operator == " ^ ")
                {
                    tmpValue.Append(f_TableField.FieldAccess);
                    tmpValue.Append(" + (");
                    tmpValue.Append(tmpUpdateValue);
                    tmpValue.Append(") - 2 * BITAND(");
                    tmpValue.Append(tmpUpdateValue);
                    tmpValue.Append(", ");
                    tmpValue.Append(tmpUpdateValue);
                    tmpValue.Append(")");
                    return tmpValue.ToString();
                }
                else if (f_Operator == " | ")
                {
                    tmpValue.Append(f_TableField.FieldAccess);
                    tmpValue.Append(" + (");
                    tmpValue.Append(tmpUpdateValue);
                    tmpValue.Append(") - BITAND(");
                    tmpValue.Append(f_TableField.FieldAccess);
                    tmpValue.Append(", ");
                    tmpValue.Append(tmpUpdateValue);
                    tmpValue.Append(")");
                    return tmpValue.ToString();
                }
                else if (f_Operator == " % ")
                {
                    tmpValue.Append("MOD(");
                    tmpValue.Append(f_TableField.FieldAccess);
                    tmpValue.Append(", ");
                    tmpValue.Append(tmpUpdateValue);
                    tmpValue.Append(")");
                    return tmpValue.ToString();
                }
                else if (f_Operator == " & ")
                {
                    tmpValue.Append("BITAND(");
                    tmpValue.Append(f_TableField.FieldAccess);
                    tmpValue.Append(", ");
                    tmpValue.Append(tmpUpdateValue);
                    tmpValue.Append(")");
                    return tmpValue.ToString();
                }
                else
                {
                    tmpValue.Append(f_TableField.FieldAccess);
                    tmpValue.Append(f_Operator);
                    tmpValue.Append(tmpUpdateValue);
                    return tmpValue.ToString();
                }
            }
            else
            {
                tmpValue.Append(tmpUpdateValue);
                return tmpValue.ToString();
            }
        }

        public static string EqualExpression(object f_Left, object f_Right)
        {
            if (f_Left != null && f_Left.ToString() != "NULL" && f_Right != null && f_Right.ToString() != "NULL")
            {
                return f_Left.ToString() + " = " + f_Right.ToString();
            }

            if ((f_Right == null || f_Right.ToString() == "NULL") && (f_Left == null || f_Left.ToString() == "NULL"))
            {
                return "NULL IS NULL";
            }

            if (f_Right == null || f_Right.ToString() == "NULL")
            {
                return f_Left.ToString() + " IS NULL";
            }
            else
            {
                return f_Right.ToString() + " IS NULL";
            }
        }

        public static string NotEqualExpression(object f_Left, object f_Right)
        {
            if (f_Left != null && f_Left.ToString() != "NULL" && f_Right != null && f_Right.ToString() != "NULL")
            {
                return f_Left.ToString() + " != " + f_Right.ToString();
            }

            if ((f_Right == null || f_Right.ToString() == "NULL") && (f_Left == null || f_Left.ToString() == "NULL"))
            {
                return "NULL IS NOT NULL";
            }

            if (f_Right == null || f_Right.ToString() == "NULL")
            {
                return f_Left.ToString() + " IS NOT NULL";
            }
            else
            {
                return f_Right.ToString() + " IS NOT NULL";
            }
        }

        public static string UnaryExpression(string f_Operator, object f_Value)
        {
            if (f_Value == null)
            {
                return "null";
            }

            if (f_Operator == "NOT")
            {
                return f_Operator + "(" + f_Value.ToString() + ")";
            }

            return f_Operator + f_Value.ToString();
        }

        public static string OracleBitNot(string f_Value)
        {
            if (f_Value == null)
            {
                return "null";
            }

            return "((0 - (" + f_Value + ")) - 1)";
        }

        public static string BinaryExpression(object f_Left, string f_Operator, object f_Right)
        {
            StringBuilder tmpValue = new StringBuilder();
            if (f_Left == null)
            {
                tmpValue.Append("NULL");
            }
            else
            {
                tmpValue.Append(f_Left);
            }

            tmpValue.Append(f_Operator);

            if(f_Right == null)
            {
                tmpValue.Append("NULL");
            }
            else
            {
                tmpValue.Append(f_Right);
            }

            return tmpValue.ToString();
        }

        public static string OracleBitBinaryExpression(object f_Left, string f_Operator, object f_Right)
        {
            StringBuilder tmpValue = new StringBuilder();
            string tmpLeftValue = f_Left == null ? "NULL" : f_Left.ToString();
            string tmpRightValue = f_Right == null ? "NULL" : f_Right.ToString();

            if (f_Operator == "&")
            {
                tmpValue.Append("BITAND(");
                tmpValue.Append(tmpLeftValue);
                tmpValue.Append(", ");
                tmpValue.Append(tmpRightValue);
                tmpValue.Append(")");
                return tmpValue.ToString();
            }
            else
            {
                tmpValue.Append("(");
                tmpValue.Append(tmpLeftValue);
                tmpValue.Append(" + ");
                tmpValue.Append(tmpRightValue);

                if (f_Operator == "|")
                {
                    tmpValue.Append(" - BITAND(");
                }
                else
                {
                    tmpValue.Append("- 2 * BITAND(");
                }

                tmpValue.Append(tmpLeftValue);
                tmpValue.Append(", ");
                tmpValue.Append(tmpRightValue);
                tmpValue.Append("))");
                return tmpValue.ToString();
            }
        }

        public static string TernaryExpression(object f_Condition, object f_Then, object f_Else, byForm_Server.ku.DBTypeEnum f_DBTypeEnum)
        {
            StringBuilder tmpValue = new StringBuilder();

            if (f_Condition == null)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ConditionIsNull);
            }

            if (f_DBTypeEnum == DBTypeEnum.SqlServer || f_DBTypeEnum == DBTypeEnum.Oracle)
            {
                tmpValue.Append(" CASE WHEN ");
                tmpValue.Append(f_Condition);
                tmpValue.Append(" THEN ");

                if (f_Then == null)
                {
                    tmpValue.Append("NULL");
                }
                else
                {
                    tmpValue.Append(f_Then);
                }

                tmpValue.Append(" ELSE ");

                if (f_Else == null)
                {
                    tmpValue.Append("NULL");
                }
                else
                {
                    tmpValue.Append(f_Else);
                }

                tmpValue.Append(" END ");
                return tmpValue.ToString();
            }

            if (f_DBTypeEnum == DBTypeEnum.Mysql)
            {
                tmpValue.Append(" IF(");
                tmpValue.Append(f_Condition);
                tmpValue.Append(", ");
                tmpValue.Append(f_Then);
                tmpValue.Append(", ");
                tmpValue.Append(f_Else);
                tmpValue.Append(") ");
                return tmpValue.ToString();
            }

            return null;
        }

        public static int SetMax(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_Sheet)
        {
            if (f_Sheet.PrimaryKeyList.Count != 1)
            {
                return 0;
            }
            else
            {
                if (f_Sheet.FieldDic[f_Sheet.PrimaryKeyList[0].Name].FieldType == ku.DataTypeEnum.Int)
                {
                    string tmpGetMax;
                    DBTypeEnum tmpDBType;
                    if (!Root.GetInstance().KuTypeDic.TryGetValue(f_Sheet.KuName, out tmpDBType))
                    {
                        ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_Sheet.KuName));
                    }

                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpGetMax = "SELECT MAX([" + f_Sheet.PrimaryKeyList[0].Name + "]) FROM [" + f_Sheet.SheetName + "]";
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpGetMax = "SELECT MAX(`" + f_Sheet.PrimaryKeyList[0].Name + "`) FROM `" + f_Sheet.SheetName + "`";
                    }
                    else
                    {
                        tmpGetMax = "SELECT MAX(\"" + f_Sheet.PrimaryKeyList[0].Name + "\") FROM \"" + f_Sheet.SheetName + "\"";
                    }

                    var tmpReturnValue = ToolClass.SqlHelper.Inquiry(tmpGetMax, f_Sheet.KuName);
                    if (tmpReturnValue == DBNull.Value)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(tmpReturnValue);
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public static void Replace(System.Collections.Generic.List<byForm_Server.ku.by.Object.Cell> f_Cells, byForm_Server.ku.by.Object.Row f_Referenced)
        {
            //都是数据流填充时用到，不需要对cell的row赋值
            foreach (var item in f_Cells)
            {
                if (item.field == null)
                {
                    continue;
                }

                if (item.field.Field == null)
                {
                    continue;
                }

                if (item.field.Field.ReferenceField == null)
                {
                    continue;
                }

                var tmpReferenceField = item.field.Field.ReferenceField;
                var tmpCell = f_Referenced.cells.FirstOrDefault(cell => cell.field != null && cell.field.Field == tmpReferenceField);
                if (tmpCell == null)
                {
                    continue;
                }
                else
                {
                    item.SetValue(tmpCell.CopyValue());
                }
            }
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.Object.Row> CopyRows(System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows)
        {
            List<Object.Row> tmpNewRows = new List<Object.Row>();
            foreach (var item in f_Rows)
            {
                tmpNewRows.Add(item.Copy());
            }
            return tmpNewRows;
        }

        public static System.Collections.Generic.List<System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>> CopyRowsArray(System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row>[] f_RowsArray)
        {
            if (f_RowsArray == null)
            {
                return null;
            }

            List<IList<Object.Row>> tmpNewRows = new List<IList<Object.Row>>();

            foreach (var item in f_RowsArray)
            {
                tmpNewRows.Add(CopyRows(item));
            }

            return tmpNewRows;
        }

        public static byForm_Server.ku.by.ToolClass.BaseKu GetKu(string f_KuName)
        {
            return ku.Root.GetInstance()[f_KuName];
        }

        public static byForm_Server.ku.by.ToolClass.IBaseDataSheet GetDataSheet(string f_QualifiedName)
        {
            if (f_QualifiedName == null)
            {
                return null;
            }
            var tmpArray = f_QualifiedName.Split('.');
            if (tmpArray.Length != 2)
            {
                ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotMatchingSource, f_QualifiedName));
            }
            string tmpKuName = tmpArray[0];
            string tmpSheetName = tmpArray[1];
            return ku.Root.GetInstance()[tmpKuName][tmpSheetName];
        }

        public static string GetDecKuFromRowOrRowList(object f_Param)
        {
            if (f_Param is Row)
            {
                var tmpRow = f_Param as Row;

                if (tmpRow.Identity == null)
                {
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                var tmpDataSheet = tmpRow.Identity.to as IBaseDataSheet;

                if (tmpDataSheet == null)
                {
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                return tmpDataSheet.RealKuName;
            }

            if (f_Param is list<Row>)
            {
                var tmpRows = f_Param as list<Row>;

                if (tmpRows.Count == 0)
                {
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                if (tmpRows[0].Identity == null)
                {
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                var tmpDataSheet = tmpRows[0].Identity.to as IBaseDataSheet;

                if (tmpDataSheet == null)
                {
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                return tmpDataSheet.RealKuName;
            }

            if (f_Param is Row[])
            {
                var tmpRows = f_Param as Row[];

                if (tmpRows.Length == 0)
                {
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                if (tmpRows[0].Identity == null)
                {
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                var tmpDataSheet = tmpRows[0].Identity.to as IBaseDataSheet;

                if (tmpDataSheet == null)
                {
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                return tmpDataSheet.RealKuName;
            }

            throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
        }

        public static byForm_Server.ku.by.ToolClass.IBaseDataSheet GetDataSheet(string f_KuName, string f_SheetName)
        {
            return ku.Root.GetInstance()[f_KuName][f_SheetName];
        }

        public static byForm_Server.ku.by.ToolClass.IBaseDataSheet GetDataSheetOfRow(byForm_Server.ku.by.Object.Row f_Row)
        {
            if (f_Row == null || f_Row.Identity == null)
            {
                return null;
            }

            var tmpIdentity = GetIdentityOfRow(f_Row);

            if (tmpIdentity.to == null)
            {
                return null;
            }

            IBaseDataSheet tmpDataSheet = tmpIdentity.to as IBaseDataSheet;

            return tmpDataSheet;
        }

        public static byForm_Server.ku.by.Object.Cell GetRowComponent(byForm_Server.ku.by.Object.Row f_Row, string f_Component)
        {
            var tmpDataSheet = GetDataSheet(f_Row.KuName, f_Row.SheetName);
            var tmpIdentityType = f_Row.Identity.GetType();
            string tmpIdentityName = tmpIdentityType.Name;
            string tmpIdentityNS = tmpIdentityType.Namespace;//xxxx.ku.kuname.identity
            var tmpArray = tmpIdentityNS.Split('.');
            if (tmpArray.Length != 4)
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.IdentityNameSpaceError);
            }
            string tmpQualifiedName = tmpArray[2] + "." + tmpIdentityName;
            if (tmpQualifiedName != tmpDataSheet.IdentityName)
            {
                ThrowHelper.ThrowDataMatchException(ErrorInfo.RowIdentityError);
            }
            if (!tmpDataSheet.ComponentDic.ContainsKey(f_Component))
            {
                ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.SheetName, f_Component));
            }
            var tmpField = tmpDataSheet.ComponentDic[f_Component];
            var tmpFieldType = tmpField.FieldType;
            string tmpFieldQualifiedName = tmpField.KuName + "." + tmpField.SheetName + "." + tmpField.Name;
            var tmpCell = f_Row[tmpFieldQualifiedName];
            if (tmpCell.value == null)
            {
                switch (tmpFieldType)
                {
                    case DataTypeEnum.Byte:
                    case DataTypeEnum.Decimal:
                    case DataTypeEnum.Double:
                    case DataTypeEnum.Float:
                    case DataTypeEnum.Int:
                    case DataTypeEnum.Long:
                    case DataTypeEnum.Short:
                        tmpCell.SetValue(0);
                        break;
                    case DataTypeEnum.Bool:
                        tmpCell.SetValue(false);
                        break;
                    case DataTypeEnum.Char:
                        tmpCell.SetValue('\0');
                        break;
                    case DataTypeEnum.Datetime:
                        tmpCell.SetValue(default(DateTime));
                        break;
                    case DataTypeEnum.String:
                        tmpCell.SetValue("");
                        break;
                    case DataTypeEnum.Enum:
                        var tmpEnumType = tmpField.EnumType;
                        var tmpEnumValues = System.Enum.GetValues(tmpEnumType);
                        if (tmpEnumValues.Length == 0)
                        {
                            tmpCell.SetValue(Activator.CreateInstance(tmpEnumType));
                        }
                        else
                        {
                            tmpCell.SetValue(tmpEnumValues.GetValue(0));
                        }
                        break;
                }
            }
            if (tmpCell.DataTypeEnum == DataTypeEnum.None)
            {
                tmpCell.DataTypeEnum = tmpField.FieldType;
                tmpCell.EnumType = tmpField.EnumType;
            }
            return tmpCell;
        }

        public static byForm_Server.ku.by.ToolClass.Config GetConfigByIdentityName(string f_KuName, string f_IdentityName, string f_ConfigName, string f_SheetName)
        {
            var tmpKu = GetKu(f_KuName);
            if (!tmpKu.ConfigDic.ContainsKey(f_IdentityName))
            {
                return null;
                //ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindConfigList, f_KuName, f_ConfigName));
            }
            var tmpConfig = tmpKu.ConfigDic[f_IdentityName].Find(item => item.Name == f_ConfigName && item.SheetName == f_SheetName);
            if (tmpConfig == null)
            {
                return null;
                //ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindConfig, f_ConfigName));
            }
            return tmpConfig;
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> GetConfigList(string f_Kuname, byForm_Server.ku.by.ToolClass.Config f_Config)
        {
            if (f_Config == null)
            {
                return null;
            }
            var tmpDataSheet = GetDataSheet(f_Kuname, f_Config.SheetName);
            if (!tmpDataSheet.FlowDic.ContainsKey(f_Config.FlowName))
            {
                return null;
                //ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.SheetName, f_Config.FlowName));
            }
            return tmpDataSheet.FlowDic[f_Config.FlowName];
        }

        public static string GetConfigIdentityByTable(byForm_Server.ku.by.ToolClass.Sql.Table f_Table)
        {
            var tmpDataSheet = f_Table.Sheet;
            return tmpDataSheet.IdentityName;
        }

        public static bool FieldHasRefernece(byForm_Server.ku.by.ToolClass.BaseKu f_Ku, string f_QualifiedName1, string f_QualifiedName2)
        {
            var tmpArray1 = f_QualifiedName1.Split('.');
            var tmpArray2 = f_QualifiedName2.Split('.');

            if (tmpArray1.Length != 2 || tmpArray2.Length != 2)
            {
                return false;
            }

            string tmpSheetName1 = tmpArray1[0];
            string tmpSheetName2 = tmpArray2[0];
            string tmpColName1 = tmpArray1[1];
            string tmpColName2 = tmpArray2[1];

            foreach (var item in f_Ku.RelationDic)
            {
                if (item.Key != tmpSheetName1 && item.Key != tmpSheetName2)
                {
                    continue;
                }

                if (item.Key == tmpSheetName1)
                {
                    var tmpList = item.Value;
                    if (tmpList.Exists(element => element.ReferencedSheet == tmpSheetName2 && element.ReferencedFieldName == tmpColName2))
                    {
                        return true;
                    }
                }

                if (item.Key == tmpSheetName2)
                {
                    var tmpList = item.Value;
                    if (tmpList.Exists(element => element.ReferencedSheet == tmpSheetName1 && element.ReferencedFieldName == tmpColName1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static byForm_Server.ku.by.ToolClass.SheetRelation FindReferenceBetweenFieldAndSheet(byForm_Server.ku.by.ToolClass.BaseKu f_Ku, byForm_Server.ku.by.ToolClass.Field f_Field, string f_SheetName)
        {
            string tmpFieldSheetName = f_Field.SheetName;

            if (!f_Ku.RelationDic.ContainsKey(tmpFieldSheetName) && !f_Ku.RelationDic.ContainsKey(f_SheetName))
            {
                ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, tmpFieldSheetName, f_SheetName));
            }

            if (f_Ku.RelationDic.ContainsKey(tmpFieldSheetName))
            {
                foreach (var item in f_Ku.RelationDic[tmpFieldSheetName])
                {
                    if (item.ReferenceSheet == tmpFieldSheetName && item.ReferenceFieldName == f_Field.Name)
                    {
                        return item;
                    }

                    if (item.ReferencedSheet == tmpFieldSheetName && item.ReferencedFieldName == f_Field.Name)
                    {
                        return item;
                    }
                }
            }

            if (f_Ku.RelationDic.ContainsKey(f_SheetName))
            {
                foreach (var item in f_Ku.RelationDic[f_SheetName])
                {
                    if (item.ReferencedSheet == tmpFieldSheetName && item.ReferencedFieldName == f_Field.Name)
                    {
                        return item;
                    }

                    if (item.ReferenceSheet == tmpFieldSheetName && item.ReferenceFieldName == f_Field.Name)
                    {
                        return item;
                    }
                }
            }

            throw ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.TableNotReferenceField, f_Field.ToString(), f_Ku.Name + "." + f_SheetName));
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.SheetRelation> FindReferenceRelationBetweenSheet(byForm_Server.ku.by.ToolClass.BaseKu f_Ku, string f_SheetName1, string f_SheetName2)
        {
            string tmpSign1 = f_SheetName1;
            string tmpSign2 = f_SheetName2;
            List<SheetRelation> tmpList = new List<SheetRelation>();
            if (!f_Ku.RelationDic.ContainsKey(f_SheetName1) && !f_Ku.RelationDic.ContainsKey(f_SheetName2))
            {
                //没有引用关系
                ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, f_SheetName1, f_SheetName2));
            }

            if (f_Ku.RelationDic.ContainsKey(f_SheetName1))
            {
                foreach (var item in f_Ku.RelationDic[f_SheetName1])
                {
                    if (item.ReferencedSheet == tmpSign1)
                    {
                        if (item.ReferenceSheet == tmpSign2)
                        {
                            tmpList.Add(item);
                        }
                    }

                    if (item.ReferencedSheet == tmpSign2)
                    {
                        if (item.ReferenceSheet == tmpSign1)
                        {
                            tmpList.Add(item);
                        }
                    }
                }
            }

            if (f_Ku.RelationDic.ContainsKey(f_SheetName2))
            {
                foreach (var item in f_Ku.RelationDic[f_SheetName2])
                {
                    if (item.ReferencedSheet == tmpSign1)
                    {
                        if (item.ReferenceSheet == tmpSign2)
                        {
                            tmpList.Add(item);
                        }
                    }

                    if (item.ReferencedSheet == tmpSign2)
                    {
                        if (item.ReferenceSheet == tmpSign1)
                        {
                            tmpList.Add(item);
                        }
                    }
                }
            }

            if (tmpList.Count == 0)
            {
                ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, f_SheetName1, f_SheetName2));
            }

            if (tmpList.Count > 1)
            {
                StringBuilder tmpSB = new StringBuilder();
                for (int i = 0; i < tmpList.Count; i++)
                {
                    if (i != 0)
                    {
                        tmpSB.Append(", ");
                    }

                    tmpSB.Append(tmpList[i].ToString());
                }
                ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.HasSeveralReferenceFieldsBetweenSheets, f_SheetName1, f_SheetName2, tmpSB.ToString()));
            }

            return tmpList;
        }

        public static string TableRelationEqualField(byForm_Server.ku.by.ToolClass.Sql.Table f_Table, string f_Component, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableList, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            if (f_Table == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.TableIsNull);
            }
            StringBuilder tmpSqlExpression = new StringBuilder();
            var tmpTableField = ConvertComponentToTableField(f_Component, f_TableList) as Sql.TableField;

            if (tmpTableField == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.FieldIsNull);
            }

            var tmpField = tmpTableField.SelectedField;
            string tmpFieldKuName = tmpField.KuName;
            string tmpFieldSheetName = tmpField.SheetName;

            if (tmpFieldKuName != f_Table.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            var tmpKu = GetKu(tmpFieldKuName);
            StringBuilder tmpLeft = new StringBuilder();
            StringBuilder tmpRight = new StringBuilder();
            if (f_Table.Alias != null)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + f_Table.Alias + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + f_Table.Alias + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + f_Table.Alias + "\".");
                }
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + f_Table.SourceName + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + f_Table.SourceName + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + f_Table.SourceName + "\".");
                }
            }
            if (f_Table.SourceName == tmpFieldSheetName)
            {
                //同表
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpTableField.SelectedField.Name + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpTableField.SelectedField.Name + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpTableField.SelectedField.Name + "\"");
                }

                tmpRight.Append(tmpTableField.FieldAccess);
                return tmpLeft.ToString() + " = " + tmpRight.ToString();
            }

            var tmpRelation = FindReferenceBetweenFieldAndSheet(tmpKu, tmpField, f_Table.TableAccess);
            bool tmpRightIsReference = false;

            if (f_Table.SourceName == tmpRelation.ReferencedSheet)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpRelation.ReferencedFieldName + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpRelation.ReferencedFieldName + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpTableField.SelectedField.Name + "\"");
                }

                tmpRightIsReference = true;
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpRelation.ReferenceFieldName + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpRelation.ReferenceFieldName + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpRelation.ReferencedFieldName + "\"");
                }
            }

            tmpLeft.Append(" = ");

            if (tmpRightIsReference)
            {
                if (tmpRelation.ReferenceFieldName != tmpField.Name)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.TableNotReferenceField, tmpField.Name, f_Table.SourceName));
                }
            }
            else
            {
                if (tmpRelation.ReferencedFieldName != tmpField.Name)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.TableNotReferenceField, tmpField.Name, f_Table.SourceName));
                }
            }

            var tmpSelectTable = tmpTableField.FieldTable as Sql.Table;
            if (tmpSelectTable.Alias == null)
            {
                if (f_DBType != DBTypeEnum.SqlServer)
                {
                    tmpRight.Append("[" + tmpSelectTable.SourceName + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpRight.Append("`" + tmpSelectTable.SourceName + "`.");
                }
                else
                {
                    tmpRight.Append("\"" + tmpSelectTable.SourceName + "\".");
                }
            }
            else
            {
                tmpRight.Append(tmpSelectTable.Alias + ".");
            }

            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpRight.Append("[" + tmpTableField.SelectedField.Name + "]");
            }
            else if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpRight.Append("`" + tmpTableField.SelectedField.Name + "`");
            }
            else
            {
                tmpRight.Append("\"" + tmpTableField.SelectedField.Name + "\"");
            }

            tmpSqlExpression.Append(tmpLeft);
            tmpSqlExpression.Append(tmpRight);
            return tmpSqlExpression.ToString();
        }

        public static string TableRelationEqualRow(byForm_Server.ku.by.ToolClass.Sql.Table f_Table, byForm_Server.ku.by.Object.Row f_Row, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            if (f_Table == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.TableIsNull);
            }
            StringBuilder tmpSqlExpression = new StringBuilder();
            if (f_Row == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowIsNull);
            }

            string tmpRowKuName = f_Row.KuName;
            string tmpRowSheetName = f_Row.SheetName;

            if (tmpRowKuName != f_Table.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            var tmpKu = GetKu(tmpRowKuName);
            StringBuilder tmpLeft = new StringBuilder();
            StringBuilder tmpRight = new StringBuilder();

            if (f_Table.Alias != null)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + f_Table.Alias + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + f_Table.Alias + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + f_Table.Alias + "\".");
                }
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + f_Table.SourceName + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + f_Table.SourceName + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + f_Table.SourceName + "\".");
                }
            }

            if (f_Table.SourceName == tmpRowSheetName)
            {
                //同表
                var tmpDataSheet = f_Table.GetSource();
                string tmpTableValue = tmpLeft.ToString();

                for (int i = 0; i < tmpDataSheet.PrimaryKeyList.Count; i++)
                {
                    var tmpPrimaryKey = tmpDataSheet.PrimaryKeyList[i];
                    string tmpColumnName = tmpPrimaryKey.Name;
                    var tmpCell = f_Row.cells.Find(cell => cell.ColumnName == tmpColumnName);
                    if (tmpCell == null)
                    {
                        ThrowHelper.ThrowRelationOperationException(ErrorInfo.CanNotFindRelationCellInRow);
                    }

                    if (i != 0)
                    {
                        tmpSqlExpression.Append(" and ");
                    }

                    tmpSqlExpression.Append(tmpTableValue);
                    if (f_DBType == DBTypeEnum.SqlServer)
                    {
                        tmpSqlExpression.Append("[" + tmpColumnName + "] = ");
                    }
                    else if (f_DBType == DBTypeEnum.Mysql)
                    {
                        tmpSqlExpression.Append("`" + tmpColumnName + "` = ");
                    }
                    else
                    {
                        tmpSqlExpression.Append("\"" + tmpColumnName + "\" = ");
                    }

                    var tmpValue = tmpCell.value;

                    if (tmpValue is string || tmpValue is Object.datetime || tmpValue is char || tmpValue is DateTime || tmpValue.GetType().IsEnum)
                    {
                        tmpSqlExpression.Append(SaveInspect.CharactorEscape(tmpValue.ToString()));
                    }
                    else if (tmpValue is sbyte || tmpValue is short || tmpValue is int || tmpValue is long || tmpValue is float || tmpValue is double
                         || tmpValue is decimal)
                    {
                        tmpSqlExpression.Append(tmpValue.ToString());
                    }
                    else if (tmpValue is bool)
                    {
                        var tmpBoolValue = (bool)tmpValue;
                        tmpSqlExpression.Append(tmpBoolValue ? 1 : 0);
                    }
                    else
                    {
                        ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                    }
                }

                return tmpSqlExpression.ToString();
            }

            var tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, f_Table.SourceName, tmpRowSheetName);
            var tmpRelation = tmpRelations[0];
            bool tmpRightIsReference = false;
            if (f_Table.SourceName == tmpRelation.ReferencedSheet)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpRelation.ReferencedFieldName + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpRelation.ReferencedFieldName + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpRelation.ReferencedFieldName + "\"");
                }

                tmpRightIsReference = true;
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpRelation.ReferenceFieldName + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpRelation.ReferenceFieldName + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpRelation.ReferenceFieldName + "\"");
                }
            }

            tmpLeft.Append(" = ");

            Object.Cell tmpMeetConditionCell = null;
            if (tmpRightIsReference)
            {
                tmpMeetConditionCell = f_Row.cells.Find(cell => cell.ColumnName == tmpRelation.ReferenceFieldName);
            }
            else
            {
                tmpMeetConditionCell = f_Row.cells.Find(cell => cell.ColumnName == tmpRelation.ReferencedFieldName);
            }
            if (tmpMeetConditionCell == null)
            {
                ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
            }

            if (tmpMeetConditionCell.value == null)
            {
                tmpRight.Append("null");
            }
            else
            {
                var tmpValue = tmpMeetConditionCell.value;
                if (tmpValue is string || tmpValue is Object.datetime || tmpValue is char || tmpValue is DateTime || tmpValue.GetType().IsEnum)
                {
                    tmpRight.Append(SaveInspect.CharactorEscape(tmpValue.ToString()));
                }
                else if (tmpValue is sbyte || tmpValue is short || tmpValue is int || tmpValue is long || tmpValue is float || tmpValue is double
                     || tmpValue is decimal)
                {
                    tmpRight.Append(tmpValue.ToString());
                }
                else if (tmpValue is bool)
                {
                    var tmpBoolValue = (bool)tmpValue;
                    tmpRight.Append(tmpBoolValue ? 1 : 0);
                }
                else
                {
                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                }
            }
            tmpSqlExpression.Append(tmpLeft);
            tmpSqlExpression.Append(tmpRight);
            return tmpSqlExpression.ToString();
        }

        public static string TableRelationEqualQueryData(byForm_Server.ku.by.ToolClass.Sql.Table f_Table, byForm_Server.ku.by.Object.QueryData f_QueryData, System.Text.StringBuilder f_Having, int f_JoinTableCount, byForm_Server.ku.DBTypeEnum f_DBType, out int f_OutJoinTableCount)
        {
            if (f_Table == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.TableIsNull);
            }
            if (f_QueryData == null)
            {
                f_OutJoinTableCount = f_JoinTableCount;
                return " 1 = 1 ";
            }

            StringBuilder tmpWhereValue = new StringBuilder("( ");
            Dictionary<IBaseDataSheet, Sql.Table> tmpDic = new Dictionary<IBaseDataSheet, Sql.Table>();
            var tmpKu = GetKu(f_Table.KuName);
            foreach (var item in f_QueryData._QueryDataParameter.ValueDic)
            {
                if (item.Value == null)
                {
                    continue;
                }

                if (item.Value is string)
                {
                    string tmpStringValue = item.Value as string;
                    if (tmpStringValue == "")
                    {
                        continue;
                    }
                }

                var tmpQueryAreaField = item.Key;
                if (tmpQueryAreaField.IsRelation)
                {
                    continue;
                }
                var tmpField = tmpQueryAreaField.DataSheetField;
                var tmpFieldDataSheet = GetDataSheet(tmpField.KuName, tmpField.SheetName);
                if (!tmpDic.ContainsKey(tmpFieldDataSheet) && tmpFieldDataSheet != f_Table.Sheet)
                {
                    string tmpJoinTableName = "#" + f_JoinTableCount++;

                    //if (f_DBType == DBTypeEnum.SqlServer)
                    //{
                    //    tmpJoinTableName = "[#" + f_JoinTableCount++ + "]";
                    //}
                    //else if (f_DBType == DBTypeEnum.Mysql)
                    //{
                    //    tmpJoinTableName = "`#" + f_JoinTableCount++ + "`";
                    //}
                    //else
                    //{
                    //    tmpJoinTableName = "\"#" + f_JoinTableCount++ + "\"";
                    //}

                    var tmpNewTable = new Sql.Table(tmpFieldDataSheet, tmpJoinTableName);
                    tmpDic.Add(tmpFieldDataSheet, tmpNewTable);
                    var tmpJoinTable = new Sql.JoinTable(tmpNewTable);
                    tmpJoinTable.JoinMode = " left join ";
                    f_Table.JoinTables.Add(tmpJoinTable);
                    if (tmpKu.RelationDic.ContainsKey(f_Table.SourceName))
                    {
                        var tmpRelations = tmpKu.RelationDic[f_Table.SourceName];
                        var tmpMatched = tmpRelations.FirstOrDefault(value => value.ReferencedSheet == tmpFieldDataSheet.SheetName);
                        if (tmpMatched == null)
                        {
                            ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationInQueryArea, f_Table.SourceName));
                        }

                        if (f_DBType == DBTypeEnum.SqlServer)
                        {
                            tmpJoinTable.Condition.Append(" on [" + tmpMatched.ReferenceSheet + "].[" + tmpMatched.ReferenceFieldName + "] = [" + tmpNewTable.Alias + "].[" + tmpMatched.ReferencedFieldName + "]");
                        }
                        else if (f_DBType == DBTypeEnum.Mysql)
                        {
                            tmpJoinTable.Condition.Append(" on `" + tmpMatched.ReferenceSheet + "`.`" + tmpMatched.ReferenceFieldName + "` = `" + tmpNewTable.Alias + "`.`" + tmpMatched.ReferencedFieldName + "`");
                        }
                        else
                        {
                            tmpJoinTable.Condition.Append(" on \"" + tmpMatched.ReferenceSheet + "\".\"" + tmpMatched.ReferenceFieldName + "\" = \"" + tmpNewTable.Alias + "\".\"" + tmpMatched.ReferencedFieldName + "\"");
                        }
                    }
                    else if (tmpKu.RelationDic.ContainsKey(tmpFieldDataSheet.SheetName))
                    {
                        //当前table为被引用的表时
                        var tmpRelations = tmpKu.RelationDic[tmpFieldDataSheet.SheetName];
                        var tmpMatched = tmpRelations.FirstOrDefault(value => value.ReferenceSheet == tmpFieldDataSheet.SheetName);
                        if (tmpMatched == null)
                        {
                            ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationInQueryArea, f_Table.SourceName));
                        }

                        if (f_DBType == DBTypeEnum.SqlServer)
                        {
                            tmpJoinTable.Condition.Append(" ON [" + tmpMatched.ReferencedSheet + "].[" + tmpMatched.ReferencedFieldName + "] = [" + tmpNewTable.Alias + "].[" + tmpMatched.ReferenceFieldName + "]");
                        }
                        else if (f_DBType == DBTypeEnum.Mysql)
                        {
                            tmpJoinTable.Condition.Append(" ON `" + tmpMatched.ReferencedSheet + "`.`" + tmpMatched.ReferencedFieldName + "` = `" + tmpNewTable.Alias + "`.`" + tmpMatched.ReferenceFieldName + "`");
                        }
                        else
                        {
                            tmpJoinTable.Condition.Append(" ON \"" + tmpMatched.ReferencedSheet + "\".\"" + tmpMatched.ReferencedFieldName + "\" = \"" + tmpNewTable.Alias + "\".\"" + tmpMatched.ReferenceFieldName + "\"");
                        }
                    }
                    else
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationInQueryArea, f_Table.SourceName));
                    }
                }

                Sql.Table tmpTable = null;
                if (tmpFieldDataSheet != f_Table.Sheet)
                {
                    tmpTable = tmpDic[tmpFieldDataSheet];
                }
                else
                {
                    tmpTable = f_Table;
                }

                if (tmpQueryAreaField.DataSheetField.Func == FunctionEnum.NONE)
                {
                    if (tmpWhereValue.Length != 2)
                    {
                        tmpWhereValue.Append(" AND ");
                    }

                    tmpWhereValue.Append(GenerateQueryDataExpression(tmpTable, tmpQueryAreaField, item.Value));
                }
                else
                {
                    if (f_Having.Length == 0)
                    {
                        f_Having.Append(" HAVING ");
                    }

                    if (f_Having.Length != 8)
                    {
                        f_Having.Append(" AND ");
                    }
                    f_Having.Append(GenerateQueryDataExpression(tmpTable, tmpQueryAreaField, item.Value));
                }
            }
            if (tmpWhereValue.Length == 2)
            {
                tmpWhereValue.Append("1 = 1");
            }
            tmpWhereValue.Append(")");
            f_OutJoinTableCount = f_JoinTableCount;
            return tmpWhereValue.ToString();
        }

        public static string TableRelationEqualTable(byForm_Server.ku.by.ToolClass.Sql.Table f_LeftTable, byForm_Server.ku.by.ToolClass.Sql.Table f_RightTable, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            if (f_LeftTable == null || f_RightTable == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.TableIsNull);
            }
            if (f_LeftTable.KuName != f_RightTable.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            var tmpKu = GetKu(f_LeftTable.KuName);
            StringBuilder tmpSqlExpression = new StringBuilder();
            StringBuilder tmpLeft = new StringBuilder();
            StringBuilder tmpRight = new StringBuilder();

            if (f_LeftTable.Alias != null)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + f_LeftTable.Alias + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + f_LeftTable.Alias + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + f_LeftTable.Alias + "\"");
                }
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + f_LeftTable.SourceName + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + f_LeftTable.SourceName + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + f_LeftTable.SourceName + "\"");
                }
            }

            if (f_RightTable.Alias != null)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpRight.Append("[" + f_RightTable.Alias + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpRight.Append("`" + f_RightTable.Alias + "`.");
                }
                else
                {
                    tmpRight.Append("\"" + f_RightTable.Alias + "\".");
                }
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpRight.Append("[" + f_RightTable.SourceName + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpRight.Append("`" + f_RightTable.SourceName + "`.");
                }
                else
                {
                    tmpRight.Append("\"" + f_RightTable.SourceName + "\".");
                }
            }

            if (f_LeftTable.Sheet.SheetName == f_RightTable.Sheet.SheetName)
            {
                string tmpLeftTableValue = tmpLeft.ToString();
                string tmpRightTableValue = tmpRight.ToString();

                for (int i = 0; i < f_LeftTable.GetSource().PrimaryKeyList.Count; i++)
                {
                    if (i != 0)
                    {
                        tmpSqlExpression.Append(" and ");
                    }

                    var tmpPrimaryField = f_LeftTable.GetSource().PrimaryKeyList[i];
                    string tmpColumnName = tmpPrimaryField.Name;
                    if (f_DBType == DBTypeEnum.SqlServer)
                    {
                        tmpSqlExpression.Append(string.Format("{0}[{1}] = {2}[{1}]", tmpLeftTableValue, tmpColumnName, tmpRightTableValue));
                    }
                    else if (f_DBType == DBTypeEnum.Mysql)
                    {
                        tmpSqlExpression.Append(string.Format("{0}`{1}` = {2}`{1}`", tmpLeftTableValue, tmpColumnName, tmpRightTableValue));
                    }
                    else
                    {
                        tmpSqlExpression.Append(string.Format("{0}\"{1}\" = {2}\"{1}\"", tmpLeftTableValue, tmpColumnName, tmpRightTableValue));
                    }
                }
                return tmpSqlExpression.ToString();
            }

            var tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, f_LeftTable.SourceName, f_RightTable.SourceName);
            var tmpRelation = tmpRelations[0];


            if (f_LeftTable.SourceName == tmpRelation.ReferencedSheet)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpRelation.ReferencedFieldName + "] = ");
                    tmpRight.Append("[" + tmpRelation.ReferenceFieldName + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpRelation.ReferencedFieldName + "` = ");
                    tmpRight.Append("`" + tmpRelation.ReferenceFieldName + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpRelation.ReferencedFieldName + "\" = ");
                    tmpRight.Append("\"" + tmpRelation.ReferenceFieldName + "\"");
                }
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpRelation.ReferenceFieldName + "] = ");
                    tmpRight.Append("[" + tmpRelation.ReferencedFieldName + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpRelation.ReferenceFieldName + "` = ");
                    tmpRight.Append("`" + tmpRelation.ReferencedFieldName + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpRelation.ReferenceFieldName + "\" = ");
                    tmpRight.Append("\"" + tmpRelation.ReferencedFieldName + "\"");
                }
            }

            tmpSqlExpression.Append(tmpLeft);
            tmpSqlExpression.Append(tmpRight);
            return tmpSqlExpression.ToString();
        }

        public static string FieldRelationEqualRow(byForm_Server.ku.by.ToolClass.Sql.TableField f_Field, byForm_Server.ku.by.Object.Row f_Row)
        {
            if (f_Row == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowIsNull);
            }

            //先判断字段和行对应的表是否存在关系
            if (f_Field.SelectedField.KuName != f_Row.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            var tmpKu = GetKu(f_Field.SelectedField.KuName);
            DBTypeEnum tmpDBType;

            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_Row.KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_Row.KuName));
            }

            StringBuilder tmpSqlExpression = new StringBuilder();
            if (f_Field.SelectedField.SheetName == f_Row.SheetName)
            {
                //表相同时
                string tmpColumnName = f_Field.SelectedField.Name;
                var tmpMatchedCell = f_Row.cells.Find(item => item.ColumnName == tmpColumnName);
                if (tmpMatchedCell == null)
                {
                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.CanNotFindRelationCellInRow);
                }

                if (tmpMatchedCell.DataTypeEnum == DataTypeEnum.None)
                {
                    tmpMatchedCell.DataTypeEnum = f_Field.SelectedField.FieldType;
                    tmpMatchedCell.EnumType = f_Field.SelectedField.EnumType;
                }

                var tmpMacthedValue = tmpMatchedCell.value;
                tmpSqlExpression.Append(f_Field.FieldAccess);
                tmpSqlExpression.Append(" = ");

                if (tmpMacthedValue == null || tmpMacthedValue is DBNull)
                {
                    tmpSqlExpression.Append(CellValueNullToDefaultReturnString(f_Field.FieldType, f_Field.EnumType, tmpDBType));
                }
                else if (tmpMacthedValue is char || tmpMacthedValue is string || tmpMacthedValue is Object.datetime || tmpMacthedValue.GetType().IsEnum)
                {
                    if (tmpMacthedValue is datetime && tmpDBType == DBTypeEnum.Oracle)
                    {
                        tmpSqlExpression.Append("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpMacthedValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                    }
                    else
                    {
                        tmpSqlExpression.Append(SaveInspect.CharactorEscape(tmpMacthedValue.ToString()));
                    }
                }
                else if (tmpMacthedValue is sbyte || tmpMacthedValue is short || tmpMacthedValue is int || tmpMacthedValue is long || tmpMacthedValue is float || tmpMacthedValue is double
                    || tmpMacthedValue is decimal)
                {
                    tmpSqlExpression.Append(tmpMacthedValue.ToString());
                }
                else if (tmpMacthedValue is bool)
                {
                    var tmpBoolValue = (bool)tmpMacthedValue;
                    tmpSqlExpression.Append(tmpBoolValue ? 1 : 0);
                }
                else
                {
                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                }
                return tmpSqlExpression.ToString();
            }

            var tmpRelation = FindReferenceBetweenFieldAndSheet(tmpKu, f_Field.SelectedField, f_Row.SheetName);
            //var tmpRelation = tmpRelations[0];
            Object.Cell tmpCell = null;
            if (tmpRelation.ReferencedSheet == f_Field.SelectedField.SheetName)
            {
                if (tmpRelation.ReferencedFieldName != f_Field.SelectedField.Name)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
                }

                tmpCell = f_Row.cells.Find(item => item.SheetName == tmpRelation.ReferenceSheet && item.ColumnName == tmpRelation.ReferenceFieldName);
            }
            else
            {
                if (tmpRelation.ReferenceFieldName != f_Field.SelectedField.Name)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
                }

                tmpCell = f_Row.cells.Find(item => item.SheetName == tmpRelation.ReferencedSheet && item.ColumnName == tmpRelation.ReferencedFieldName);
            }

            if (tmpCell == null)
            {
                ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
            }

            //字段 = 行中某个值

            tmpSqlExpression.Append(GenerateQueryField((Sql.Table)f_Field.FieldTable, f_Field.SelectedField));
            tmpSqlExpression.Append(" = ");
            var tmpCellValue = tmpCell.value;

            if (tmpCellValue == null || tmpCellValue is DBNull)
            {
                tmpSqlExpression.Append(CellValueNullToDefaultReturnString(f_Field.FieldType, f_Field.EnumType, tmpDBType));
            }
            else if (tmpCellValue is char || tmpCellValue is string || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
            {
                if (tmpCellValue is datetime && tmpDBType == DBTypeEnum.Oracle)
                {
                    tmpSqlExpression.Append("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCell.value.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                }
                else
                {
                    tmpSqlExpression.Append(SaveInspect.CharactorEscape(tmpCell.value.ToString()));
                }
            }
            else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                || tmpCellValue is decimal)
            {
                tmpSqlExpression.Append(tmpCellValue.ToString());
            }
            else if (tmpCellValue is bool)
            {
                var tmpBoolValue = (bool)tmpCellValue;
                tmpSqlExpression.Append(tmpBoolValue ? 1 : 0);
            }
            else
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
            }
            return tmpSqlExpression.ToString();
        }

        public static string TableRelationInRows(byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            StringBuilder tmpSqlExpression = new StringBuilder();
            if (f_Rows == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
            }
            if (f_Rows.Count == 0)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsHasNoRow);
            }
            string tmpRowKuName = f_Rows[0].KuName;
            string tmpRowSheetName = f_Rows[0].SheetName;

            if (tmpRowKuName != f_Table.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            var tmpKu = GetKu(tmpRowKuName);
            StringBuilder tmpLeft = new StringBuilder();
            if (f_Table.Alias != null)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + f_Table.Alias + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + f_Table.Alias + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + f_Table.Alias + "\".");
                }
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + f_Table.SourceName + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + f_Table.SourceName + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + f_Table.SourceName + "\".");
                }
            }
            if (f_Table.SourceName == tmpRowSheetName)
            {
                var tmpDataSheet = f_Table.GetSource();
                if (tmpDataSheet.PrimaryKeyList.Count > 1)
                {
                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.ServeralPKInRelationSheet);
                }

                var tmpPrimaryKey = tmpDataSheet.PrimaryKeyList[0];
                string tmpColumnName = tmpPrimaryKey.Name;
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append(string.Format("[{0}] IN (", tmpColumnName));
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append(string.Format("`{0}` IN (", tmpColumnName));
                }
                else
                {
                    tmpLeft.Append(string.Format("\"{0}\" IN (", tmpColumnName));
                }

                tmpSqlExpression.Append(tmpLeft);

                for (int i = 0; i < f_Rows.Count; i++)
                {
                    var row = f_Rows[i];
                    if (row.KuName != tmpRowKuName || row.SheetName != tmpRowSheetName)
                    {
                        ThrowHelper.ThrowRelationOperationException(ErrorInfo.ExistRowFromDifferentSheet);
                    }

                    if (row == null)
                    {
                        ThrowHelper.ThrowRelationOperationException(ErrorInfo.HasNullRowInRows);
                    }

                    var tmpCell = row.cells.Find(cell => cell.ColumnName == tmpColumnName);
                    if (tmpCell == null)
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, row.SheetName));
                    }

                    if (i != 0)
                    {
                        tmpSqlExpression.Append(", ");
                    }

                    var tmpCellValue = tmpCell.value;

                    if (tmpCellValue == null || tmpCellValue is DBNull)
                    {
                        ThrowHelper.ThrowRelationOperationException(ErrorInfo.RelationPKIsNull);
                    }

                    if (tmpCellValue is char || tmpCellValue is string || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
                    {
                        tmpSqlExpression.Append(SaveInspect.CharactorEscape(tmpCellValue.ToString()));
                        continue;
                    }
                    else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                            || tmpCellValue is decimal)
                    {
                        tmpSqlExpression.Append(tmpCellValue.ToString());
                        continue;
                    }
                    else if (tmpCellValue is bool)
                    {
                        var tmpBoolValue = (bool)tmpCellValue;
                        tmpSqlExpression.Append(tmpBoolValue ? 1 : 0);
                        continue;
                    }
                    else
                    {
                        ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                    }
                }
                tmpSqlExpression.Append(") ");
                return tmpSqlExpression.ToString();

            }

            var tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, f_Table.SourceName, tmpRowSheetName);
            var tmpRelation = tmpRelations[0];
            StringBuilder tmpRight = new StringBuilder("( ");
            bool tmpRightIsReference = false;
            Field tmpField;
            string tmpKuName = f_Table.KuName;
            if (f_Table.SourceName == tmpRelation.ReferencedSheet)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpRelation.ReferencedFieldName + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpRelation.ReferencedFieldName + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpRelation.ReferencedFieldName + "\"");
                }

                var tmpDataSheet = GetDataSheet(tmpKuName, tmpRelation.ReferencedSheet);
                if (!tmpDataSheet.FieldDic.TryGetValue(tmpRelation.ReferencedFieldName, out tmpField))
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindFieldInSheet, tmpRelation.ReferencedSheet, tmpRelation.ReferencedFieldName));
                }

                tmpRightIsReference = true;
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpRelation.ReferenceFieldName + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpRelation.ReferenceFieldName + "`");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpRelation.ReferenceFieldName + "\"");
                }

                var tmpDataSheet = GetDataSheet(tmpKuName, tmpRelation.ReferenceSheet);
                if (!tmpDataSheet.FieldDic.TryGetValue(tmpRelation.ReferenceFieldName, out tmpField))
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindFieldInSheet, tmpRelation.ReferenceSheet, tmpRelation.ReferenceFieldName));
                }
            }
            tmpLeft.Append(" IN ");
            foreach (var item in f_Rows)
            {
                if (item.KuName != tmpRowKuName || item.SheetName != tmpRowSheetName)
                {
                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.ExistRowFromDifferentSheet);
                }

                if (item == null)
                {
                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.HasNullRowInRows);
                }

                if (tmpRight.Length != 2)
                {
                    tmpRight.Append(", ");
                }

                Object.Cell tmpMatchedCell = null;
                if (tmpRightIsReference)
                {
                    tmpMatchedCell = item.cells.Find(cell => cell.ColumnName == tmpRelation.ReferenceFieldName && cell.SheetName == item.SheetName);
                }
                else
                {
                    tmpMatchedCell = item.cells.Find(cell => cell.ColumnName == tmpRelation.ReferencedFieldName && cell.SheetName == item.SheetName);
                }
                if (tmpMatchedCell == null)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, item.SheetName));
                }

                var tmpCellValue = tmpMatchedCell.value;
                if (tmpCellValue == null || tmpCellValue is DBNull)
                {
                    tmpRight.Append(CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                    continue;
                }
                else if (tmpCellValue is char || tmpCellValue is string || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
                {
                    if (tmpCellValue is datetime && f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpRight.Append("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                    }
                    else
                    {
                        tmpRight.Append(SaveInspect.CharactorEscape(tmpCellValue.ToString()));
                    }

                    continue;
                }
                else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                        || tmpCellValue is decimal)
                {
                    tmpRight.Append(tmpCellValue.ToString());
                    continue;
                }
                else if (tmpCellValue is bool)
                {
                    var tmpBoolValue = (bool)tmpCellValue;
                    tmpRight.Append(tmpBoolValue ? 1 : 0);
                    continue;
                }
                else
                {
                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                }
            }
            tmpRight.Append(" )");
            tmpSqlExpression.Append(tmpLeft);
            tmpSqlExpression.Append(tmpRight);
            return tmpSqlExpression.ToString();
        }

        public static string FieldRelationInRows(byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_AbstractField, System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_Rows, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            var tmpField = f_AbstractField as Sql.TableField;
            StringBuilder tmpSqlExpression = new StringBuilder();

            if (f_Rows == null)
            {
                return "1 = 0";
            }

            if (f_Rows.Count == 0)
            {
                return "1 = 0";
            }

            string tmpRowKuName = f_Rows[0].KuName;
            string tmpRowSheetName = f_Rows[0].SheetName;
            StringBuilder tmpLeft = new StringBuilder();
            StringBuilder tmpRight = new StringBuilder("( ");
            var tmpFieldTable = tmpField.FieldTable as Sql.Table;

            if (tmpFieldTable.Alias != null)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpFieldTable.Alias + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpFieldTable.Alias + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpFieldTable.Alias + "\".");
                }
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.Append("[" + tmpFieldTable.SourceName + "].");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.Append("`" + tmpFieldTable.SourceName + "`.");
                }
                else
                {
                    tmpLeft.Append("\"" + tmpFieldTable.SourceName + "\".");
                }
            }

            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.Append("[" + tmpField.SelectedField.Name + "] IN ");
            }
            else if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.Append("`" + tmpField.SelectedField.Name + "` IN ");
            }
            else
            {
                tmpLeft.Append("\"" + tmpField.SelectedField.Name + "\" IN ");
            }

            foreach (var item in f_Rows)
            {
                if (item == null)
                {
                    continue;
                }

                Cell tmpCell;
                if (tmpField.SelectedField.ReferenceField == null)
                {
                    tmpCell = item.cells.FirstOrDefault(cell => cell.field != null && cell.field.Field == tmpField.SelectedField);
                }
                else
                {
                    tmpCell = item.cells.FirstOrDefault(cell => cell.field != null && (cell.field.Field == tmpField.SelectedField || cell.field.Field.ReferenceField == tmpField.SelectedField));
                }

                if (tmpCell == null)
                {
                    continue;
                }
                else
                {
                    if (tmpRight.Length != 2)
                    {
                        tmpRight.Append(", ");
                    }

                    var tmpCellValue = tmpCell.value;
                    if (tmpCellValue == null || tmpCellValue is DBNull)
                    {
                        tmpRight.Append(CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                        continue;
                    }
                    else if (tmpCellValue is char || tmpCellValue is string || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
                    {
                        if (tmpCellValue is datetime && f_DBType == DBTypeEnum.Oracle)
                        {
                            tmpRight.Append("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                        }
                        else
                        {
                            tmpRight.Append(SaveInspect.CharactorEscape(tmpCellValue.ToString()));
                        }
                        continue;
                    }
                    else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                        || tmpCellValue is decimal)
                    {
                        tmpRight.Append(tmpCellValue.ToString());
                        continue;
                    }
                    else if (tmpCellValue is bool)
                    {
                        var tmpBoolValue = (bool)tmpCellValue;
                        tmpRight.Append(tmpBoolValue ? 1 : 0);
                        continue;
                    }
                    else
                    {
                        ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                    }
                }
            }

            tmpRight.Append(") ");

            if (tmpRight.Length == 4)
            {
                return "1 = 0";
            }

            tmpSqlExpression.Append(tmpLeft);
            tmpSqlExpression.Append(tmpRight);
            return tmpSqlExpression.ToString();
        }

        public static byForm_Server.ku.by.ToolClass.Sql.UpdateSetValue FieldRelationAssignmentRow(byForm_Server.ku.by.ToolClass.Field f_Field, byForm_Server.ku.by.Object.Row f_Row)
        {
            //先判断字段和行对应的表是否存在关系
            if (f_Field.KuName != f_Row.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            if (f_Row == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowIsNull);
            }

            if (f_Field.SheetName == f_Row.SheetName)
            {
                var tmpMatchedCell = f_Row.cells.Find(item => item.ColumnName == f_Field.Name);
                if (tmpMatchedCell == null)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
                }
                //if (tmpMeetConditionCell.Count > 1)
                //{
                //    throw new Exception(String.Format(ErrorInfo.SeveralRelationCells, f_Field.SheetName, f_Row.SheetName, f_Field.Name));
                //}

                return new Sql.UpdateSetValue(f_Field, tmpMatchedCell.value, " = ");
            }
            else
            {
                //先判断是否存在关系
                var tmpKu = GetKu(f_Field.KuName);
                var tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, f_Field.SheetName, f_Row.SheetName);
                var tmpRelation = tmpRelations[0];

                if (f_Field.SheetName != tmpRelation.ReferencedSheet && f_Field.SheetName != tmpRelation.ReferenceSheet)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Field.SheetName, f_Row.SheetName));
                }

                if (f_Field.SheetName == tmpRelation.ReferencedSheet && f_Row.SheetName == tmpRelation.ReferenceSheet)
                {
                    if (f_Field.Name != tmpRelation.ReferencedFieldName)
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.TableNotReferenceField, f_Field.Name, tmpRelation.ReferencedSheet));
                    }

                    var tmpMatchedCell = f_Row.cells.Find(cell => cell.ColumnName == tmpRelation.ReferenceFieldName);
                    if (tmpMatchedCell == null)
                    {
                           ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
                    }
                    //if (tmpMatchedCell.Count > 1)
                    //{
                    //    throw new Exception(String.Format(ErrorInfo.SeveralRelationCells, f_Field.SheetName, f_Row.SheetName, f_Field.Name));
                    //}
                    return new Sql.UpdateSetValue(f_Field, tmpMatchedCell.value, " = ");
                }

                if (f_Field.SheetName == tmpRelation.ReferenceSheet && f_Row.SheetName == tmpRelation.ReferencedSheet)
                {
                    if (f_Field.Name != tmpRelation.ReferenceFieldName)
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.TableNotReferenceField, f_Field.Name, tmpRelation.ReferenceSheet));
                    }

                    var tmpMatchedCell = f_Row.cells.Find(cell => cell.ColumnName == tmpRelation.ReferencedFieldName);
                    if (tmpMatchedCell == null)
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
                    }
                    //if (tmpMatchedCell.Count > 1)
                    //{
                    //    throw new Exception(String.Format(ErrorInfo.SeveralRelationCells, f_Field.SheetName, f_Row.SheetName, f_Field.Name));
                    //}

                    return new Sql.UpdateSetValue(f_Field, tmpMatchedCell.value, " = ");
                }
            }
            throw ThrowHelper.ThrowRelationOperationException(ErrorInfo.NoRelationBetweenSheetsOrReferenceColumn);
        }

        public static byForm_Server.ku.by.ToolClass.Sql.UpdateSetValue FieldAssignmentRowComponent(byForm_Server.ku.by.ToolClass.Field f_Field, byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName)
        {
            if (f_Field.KuName != f_Row.KuName)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.DifferentKuInRelationExpression);
            }
            var tmpRowSheet = GetDataSheet(f_Row.KuName, f_Row.SheetName);
            if (!tmpRowSheet.ComponentDic.ContainsKey(f_ComponentName))
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindComponentInSheet, f_Row.SheetName, f_ComponentName));
            }
            var tmpFieldName = tmpRowSheet.ComponentDic[f_ComponentName].Name;
            var tmpCell = f_Row.cells.Find(cell => cell.ColumnName == tmpFieldName);
            if (tmpCell == null)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, tmpFieldName));
            }

            if (tmpCell.DataTypeEnum == DataTypeEnum.None)
            {
                tmpCell.DataTypeEnum = f_Field.FieldType;
                tmpCell.EnumType = f_Field.EnumType;
            }

            return new Sql.UpdateSetValue(f_Field, tmpCell.value, " = ");
        }

        private static byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField FindFieldInAsterFieldReturnNull(string f_Component, byForm_Server.ku.by.ToolClass.Sql.AsteriskField f_AsterField, bool f_IsComponent)
        {
            var tmpArray = f_Component.Split('.');

            foreach (var item in f_AsterField.FieldList)
            {
                if (item is TableField)
                {
                    var tmpTableField = item as Sql.TableField;
                    string tmpFieldName;
                    if (tmpArray.Length == 2)
                    {
                        tmpFieldName = tmpArray[1];
                        //if (tmpTableField.SelectedField.Name != tmpFieldName)
                        //{
                        //    continue;
                        //}
                    }
                    else
                    {
                        tmpFieldName = f_Component;
                    }
                    var tmpDataSheet = GetDataSheet(tmpTableField.SelectedField.KuName, tmpTableField.SelectedField.SheetName);
                    if (f_IsComponent)
                    {
                        if (tmpDataSheet.ComponentDic.ContainsKey(tmpFieldName) && tmpTableField.SelectedField == tmpDataSheet.ComponentDic[tmpFieldName])
                        {
                            return item;
                            //return tmpDataSheet.ComponentDic[f_Component];
                        }
                    }
                    else
                    {
                        if (tmpDataSheet.ComponentDic.ContainsKey(tmpFieldName) && tmpTableField.SelectedField == tmpDataSheet.ComponentDic[tmpFieldName])
                        {
                            return item;
                        }
                    }
                }

                if (item is SelectField)
                {
                    var tmpSelectField = item as SelectField;
                    if (item.Alias == f_Component)
                    {
                        return item;
                    }

                    if(item.Alias == null && tmpSelectField.name == f_Component)
                    {
                        return item;
                    }
                }

                if (item is AsteriskField)
                {
                    return FindFieldInAsterFieldReturnNull(f_Component, (Sql.AsteriskField)item, f_IsComponent);
                }

                if (item is PlusField)
                {
                    return FindFieldInPlusFieldReturnNull(f_Component, (Sql.PlusField)item);
                }
            }
            return null;
        }

        private static byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField FindFieldInPlusFieldReturnNull(string f_Component, byForm_Server.ku.by.ToolClass.Sql.PlusField f_PlusField)
        {
            var tmpArray = f_Component.Split('.');
            var tmpTable = f_PlusField.FieldTable as Sql.Table;
            var tmpDataSheet = tmpTable.Sheet;

            if (tmpArray.Length != 1 && tmpArray.Length != 2)
            {
                return null;
            }

            string tmpFieldName;

            if (tmpArray.Length == 2)
            {
                if (tmpTable.Alias != tmpTable.Alias)
                {
                    return null;
                }

                string tmpComponentName = tmpArray[1];
                if (!tmpDataSheet.ComponentDic.ContainsKey(tmpComponentName))
                {
                    return null;
                }
                else
                {
                    tmpFieldName = tmpDataSheet.ComponentDic[tmpComponentName].Name;
                }
            }
            else
            {
                string tmpComponentName = tmpArray[0];
                if (!tmpDataSheet.ComponentDic.ContainsKey(tmpComponentName))
                {
                    return null;
                }
                else
                {
                    tmpFieldName = tmpDataSheet.ComponentDic[tmpComponentName].Name;
                }
            }

            foreach (var item in f_PlusField.FieldList)
            {
                var tmpTableField = item as TableField;
                if (tmpTableField.SelectedField.Name == tmpFieldName)
                {
                    return item;
                }
            }

            //if (tmpArray.Length == 1)
            //{
            //    if (tmpDataSheet.ComponentDic.ContainsKey(f_Component))
            //    {
            //        return tmpDataSheet.ComponentDic[f_Component];
            //    }
            //}

            //if (tmpArray.Length == 2)
            //{
            //    var tmpTableAlias = tmpArray[0];
            //    if (tmpTable.Alias != tmpTableAlias)
            //    {
            //        var tmpJoinTable = tmpTable.JoinTables.FirstOrDefault(table => table.JointTable.Alias == tmpTableAlias);
            //        if (tmpJoinTable != null)
            //        {
            //            return ConvertComponetToFieldReturnNull(f_Component, tmpJoinTable.JointTable);
            //        }
            //        return null;
            //    }

            //    if (tmpDataSheet.ComponentDic.ContainsKey(f_Component))
            //    {
            //        return tmpDataSheet.ComponentDic[f_Component];
            //    }
            //}

            return null;
        }

        public static byForm_Server.ku.by.ToolClass.Field ConvertComponentToField(string f_Component, byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet)
        {
            if (!f_DataSheet.ComponentDic.ContainsKey(f_Component))
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindComponentInSheet, f_DataSheet, f_Component));
            }

            return f_DataSheet.ComponentDic[f_Component];
        }

        public static byForm_Server.ku.by.ToolClass.Sql.TableField ConvertComponentToTableField(string f_Component, byForm_Server.ku.by.ToolClass.Sql.Table f_Table)
        {
            //insert 用到
            var tmpDataSheet = f_Table.Sheet;
            Field tmpField = null;
            if (!tmpDataSheet.ComponentDic.TryGetValue(f_Component, out tmpField))
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.SheetName, f_Component));
            }
            return new Sql.TableField(tmpField, f_Table, null);
        }

        public static byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField ConvertComponentToTableField(string f_Component, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableList)
        {
            var tmpArray = f_Component.Split('.');
            List<ToolClass.Sql.AbstractSelectField> tmpCompared = new List<Sql.AbstractSelectField>();
            if (tmpArray.Length == 1)
            {
                foreach (var item in f_TableList)
                {
                    GetTableFieldInTableLength1(f_Component, item, tmpCompared, true);
                    if (tmpCompared.Count > 1)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_Component));
                    }
                }
            }

            if (tmpArray.Length == 2)
            {
                string tmpTableSourceAlias = tmpArray[0];
                string tmpFieldAlias = tmpArray[1];
                foreach (var item in f_TableList)
                {
                    if (item.Alias != tmpTableSourceAlias)
                    {
                        continue;
                    }

                    GetTableFieldInTableLength2(tmpTableSourceAlias, tmpFieldAlias, item, tmpCompared, true);
                    if (tmpCompared.Count > 1)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_Component));
                    }
                }
            }

            if (tmpCompared.Count == 0)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindColumn, f_Component));
            }

            //var tmpReturnValue = tmpCompared[0] as Sql.TableField;
            //if (tmpReturnValue == null)
            //{
            //    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_Component));
            //}

            return tmpCompared[0];
        }

        public static byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField ConvertFieldNameToField(string f_FieldName, byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table)
        {
            if (f_Table is SelectTable)
            {
                throw new Exception();
            }

            var tmpArray = f_FieldName.Split('.');
            List<ToolClass.Sql.AbstractSelectField> tmpCompared = new List<Sql.AbstractSelectField>();

            if (tmpArray.Length == 1)
            {
                GetTableFieldInTableLength1(f_FieldName, f_Table, tmpCompared, true);
                if (tmpCompared.Count > 1)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_FieldName));
                }
            }

            if (tmpArray.Length == 2)
            {
                string tmpAlias = tmpArray[0];
                if (tmpAlias != f_Table.Alias)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_FieldName));
                }

                GetTableFieldInTableLength2(tmpAlias, tmpArray[1], f_Table, tmpCompared, true);
                if (tmpCompared.Count > 1)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_FieldName));
                }
            }
            if (tmpCompared.Count == 0)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindColumn, f_FieldName));
            }

            return tmpCompared[0];
        }

        public static byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField ConvertFieldNameToField(string f_FieldName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables)
        {
            var tmpArray = f_FieldName.Split('.');
            List<ToolClass.Sql.AbstractSelectField> tmpCompared = new List<Sql.AbstractSelectField>();
            if (tmpArray.Length == 1)
            {
                foreach (var item in f_Tables)
                {
                    GetTableFieldInTableLength1(f_FieldName, item, tmpCompared, true);
                    if (tmpCompared.Count > 1)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_FieldName));
                    }
                }
            }

            if (tmpArray.Length == 2)
            {
                string tmpTableSourceAlias = tmpArray[0];
                string tmpFieldAlias = tmpArray[1];
                foreach (var item in f_Tables)
                {
                    if (item.Alias != tmpTableSourceAlias)
                    {
                        continue;
                    }

                    GetTableFieldInTableLength2(tmpTableSourceAlias, tmpFieldAlias, item, tmpCompared, true);
                    if (tmpCompared.Count > 1)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_FieldName));
                    }
                }
            }

            if (tmpCompared.Count == 0)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindColumn, f_FieldName));
            }

            return tmpCompared[0];
        }

        public static void GetTableFieldInTableLength1(string f_Component, byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_FieldList, bool f_IsComponent)
        {
            if (f_Table is Sql.Table)
            {
                //不能有别名
                var tmpTable = f_Table as Sql.Table;
                var tmpDataSheet = tmpTable.Sheet;
                if (tmpDataSheet == null)
                {
                    return;
                }

                if (f_IsComponent)
                {
                    if (tmpDataSheet.ComponentDic.ContainsKey(f_Component))
                    {
                        f_FieldList.Add(new Sql.TableField(tmpDataSheet.ComponentDic[f_Component], tmpTable, null));
                    }
                }
                else
                {
                    if (tmpDataSheet.FieldDic.ContainsKey(f_Component))
                    {
                        f_FieldList.Add(new TableField(tmpDataSheet.FieldDic[f_Component], tmpTable, null));
                    }
                }
            }
            else
            {
                var tmpSelectTable = f_Table as Sql.SelectTable;
                foreach (var item in tmpSelectTable.ResultItems)
                {
                    if (item.Alias == f_Component)
                    {
                        var tmpSelectField = new SelectField(f_Component, item, tmpSelectTable);
                        tmpSelectField.FieldType = item.FieldType;
                        f_FieldList.Add(tmpSelectField);
                        continue;
                    }

                    if (item is AsteriskField)
                    {
                        var tmpAsterField = item as AsteriskField;
                        var tmpField = FindFieldInAsterFieldReturnNull(f_Component, tmpAsterField, f_IsComponent);
                        if (tmpField == null)
                        {
                            continue;
                        }

                        //只有两种可能
                        string tmpName = null;
                        if (tmpField is TableField)
                        {
                            var tmpMatchedField = tmpField as TableField;
                            tmpName = tmpMatchedField.SelectedField.Name;
                        }
                        else if (tmpField is SelectField)
                        {
                            var tmpSelectField = tmpField as SelectField;
                            tmpName = tmpSelectField.name;
                        }
                        else
                        {
                            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ColumnWithoutAlias);
                        }

                        var tmpNewSelectField = new SelectField(tmpName, item, tmpSelectTable);
                        tmpNewSelectField.FieldType = item.FieldType;
                        f_FieldList.Add(tmpNewSelectField);
                        continue;
                    }

                    //if (item is PlusField)
                    //{
                    //    //ResultItems中目前不存在该类型字段
                    //    var tmpPlusField = item as PlusField;
                    //    var tmpField = FindFieldInPlusFieldReturnNull(f_Component, tmpPlusField);
                    //    if(tmpField == null)
                    //    {
                    //        continue;
                    //    }

                    //    var tmpMatchedTableField = tmpField as TableField;
                    //    var tmpNewField = new SelectField(tmpMatchedTableField.SelectedField.Name, tmpMatchedTableField, tmpSelectTable);
                    //    tmpNewField.FieldType = tmpMatchedTableField.FieldType;
                    //    f_FieldList.Add(tmpNewField);
                    //}

                    var tmpTableField = item as Sql.TableField;
                    if (tmpTableField == null)
                    {
                        continue;
                    }
                    var tmpFieldTable = tmpTableField.FieldTable as Sql.Table;
                    if (tmpFieldTable == null)
                    {
                        continue;
                    }
                    var tmpDataSheet = tmpFieldTable.Sheet;
                    if (tmpDataSheet == null)
                    {
                        continue;
                    }
                    if (!tmpDataSheet.ComponentDic.ContainsKey(f_Component) && !tmpDataSheet.FieldDic.ContainsKey(f_Component))
                    {
                        continue;
                    }
                    //默认不会出现构件名和字段名相同的情况
                    if (tmpDataSheet.ComponentDic.ContainsKey(f_Component) && tmpTableField.SelectedField == tmpDataSheet.ComponentDic[f_Component])
                    {
                        var tmpNewField = new SelectField(tmpTableField.SelectedField.Name, tmpTableField, tmpSelectTable);
                        tmpNewField.FieldType = tmpTableField.FieldType;
                        f_FieldList.Add(tmpNewField);
                    }

                    if (tmpDataSheet.FieldDic.ContainsKey(f_Component) && tmpTableField.SelectedField == tmpDataSheet.FieldDic[f_Component])
                    {
                        var tmpNewField = new SelectField(tmpTableField.SelectedField.Name, tmpTableField, tmpSelectTable);
                        tmpNewField.FieldType = tmpTableField.FieldType;
                        f_FieldList.Add(tmpNewField);
                    }
                }
            }
        }

        public static void GetTableFieldInTableLength2(string f_Sheet, string f_Column, byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_FieldList, bool f_IsComponent)
        {
            if (f_Table.Alias != f_Sheet)
            {
                return;
            }
            if (f_Table is Sql.Table)
            {
                var tmpTable = f_Table as Sql.Table;
                var tmpDataSheet = tmpTable.Sheet;
                if (f_IsComponent)
                {
                    if (!tmpDataSheet.ComponentDic.ContainsKey(f_Column))
                    {
                        return;
                    }
                    f_FieldList.Add(new Sql.TableField(tmpDataSheet.ComponentDic[f_Column], tmpTable, null));
                }
                else
                {
                    if (!tmpDataSheet.FieldDic.ContainsKey(f_Column))
                    {
                        return;
                    }
                    f_FieldList.Add(new TableField(tmpDataSheet.FieldDic[f_Column], tmpTable, null));
                }
            }
            else
            {
                var tmpSelectTable = f_Table as Sql.SelectTable;
                foreach (var item in tmpSelectTable.ResultItems)
                {
                    //先找别名再找列
                    if (item.Alias == f_Column)
                    {
                        var tmpSelectField = new SelectField(f_Column, item, tmpSelectTable);
                        tmpSelectField.FieldType = item.FieldType;
                        f_FieldList.Add(tmpSelectField);
                        continue;
                    }

                    if (item is AsteriskField)
                    {
                        var tmpAsterField = item as AsteriskField;
                        var tmpField = FindFieldInAsterFieldReturnNull(f_Column, tmpAsterField, true);
                        if (tmpField == null)
                        {
                            continue;
                        }
                        //只有两种可能
                        string tmpName = null;
                        if (tmpField is TableField)
                        {
                            var tmpMatchedField = tmpField as TableField;
                            tmpName = tmpMatchedField.SelectedField.Name;
                        }
                        else if (tmpField is SelectField)
                        {
                            var tmpSelectField = tmpField as SelectField;
                            tmpName = tmpSelectField.name;
                        }
                        else
                        {
                            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ColumnWithoutAlias);
                        }

                        var tmpNewSelectField = new SelectField(tmpName, item, tmpSelectTable);
                        tmpNewSelectField.FieldType = item.FieldType;
                        f_FieldList.Add(tmpNewSelectField);
                        continue;
                    }

                    var tmpTableField = item as Sql.TableField;
                    if (tmpTableField == null)
                    {
                        continue;
                    }
                    var tmpFieldTable = tmpTableField.FieldTable as Sql.Table;
                    if (tmpFieldTable == null)
                    {
                        continue;
                    }
                    var tmpDataSheet = tmpFieldTable.Sheet;
                    if (tmpDataSheet == null)
                    {
                        continue;
                    }

                    if (!tmpDataSheet.ComponentDic.ContainsKey(f_Column) && !tmpDataSheet.FieldDic.ContainsKey(f_Column))
                    {
                        continue;
                    }

                    if (tmpDataSheet.ComponentDic.ContainsKey(f_Column) && tmpTableField.SelectedField == tmpDataSheet.ComponentDic[f_Column])
                    {
                        var tmpNewField = new SelectField(tmpTableField.SelectedField.Name, tmpTableField, tmpSelectTable);
                        tmpNewField.FieldType = tmpTableField.FieldType;
                        f_FieldList.Add(tmpNewField);
                    }

                    if(tmpDataSheet.FieldDic.ContainsKey(f_Column) && tmpTableField.SelectedField == tmpDataSheet.FieldDic[f_Column])
                    {
                        var tmpNewField = new SelectField(tmpTableField.SelectedField.Name, tmpTableField, tmpSelectTable);
                        tmpNewField.FieldType = tmpTableField.FieldType;
                        f_FieldList.Add(tmpNewField);
                    }
                }
            }
        }

        private static System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> GetAsteriskOfTable(byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table, bool f_ContainsJoin)
        {
            List<Sql.AbstractSelectField> tmpFieldList = new List<Sql.AbstractSelectField>();
            if (f_Table is Sql.Table)
            {
                var tmpTable = f_Table as Sql.Table;
                foreach (var item in tmpTable.Sheet.FieldDic)
                {
                    tmpFieldList.Add(new Sql.TableField(item.Value, tmpTable, null));
                }
            }
            else
            {
                var tmpTable = f_Table as Sql.SelectTable;
                foreach (var item in tmpTable.ResultItems)
                {
                    if (item is Sql.IFields)
                    {
                        var tmpField = item as Sql.IFields;

                        foreach (var selectItem in tmpField.FieldList)
                        {
                            if (selectItem.Alias == null)
                            {
                                //只可能是表字段
                                var tmpTableField = selectItem as Sql.TableField;
                                tmpFieldList.Add(new SelectField(tmpTableField.SelectedField.Name, selectItem, tmpTable));
                            }
                            else
                            {
                                tmpFieldList.Add(new SelectField(selectItem.Alias, selectItem, tmpTable));
                            }
                        }
                    }
                    else
                    {
                        string tmpName = null;
                        if (item.Alias != null)
                        {
                            tmpName = item.Alias;
                        }
                        else
                        {
                            if (item is Sql.TableField)
                            {
                                var tmpTableField = item as Sql.TableField;
                                tmpName = tmpTableField.SelectedField.Name;
                            }
                            else if (item is Sql.SelectField)
                            {
                                var tmpSelectField = item as Sql.SelectField;
                                tmpName = tmpSelectField.name;
                            }
                            else
                            {
                                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ColumnWithoutAlias);
                            }
                        }
                        tmpFieldList.Add(new Sql.SelectField(tmpName, item, tmpTable));
                    }
                }
            }

            if (f_ContainsJoin)
            {
                if (f_Table.JoinTables != null)
                {
                    foreach (var item in f_Table.JoinTables)
                    {
                        tmpFieldList.AddRange(GetAsteriskOfTable(item.JointTable, f_ContainsJoin));
                    }
                    //tmpFieldList.AddRange(GetAsteriskOfTable(f_Table.JoinTables.JointTable));
                }
            }

            return tmpFieldList;
        }

        public static byForm_Server.ku.by.ToolClass.Sql.AsteriskField GetAsteriskField(string f_Asterisk, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableList)
        {
            List<Sql.AbstractSelectField> tmpTableFieldList = new List<Sql.AbstractSelectField>();
            var tmpArray = f_Asterisk.Split('.');
            Sql.AbstractTable tmpAsteriskTable = null;
            if (tmpArray.Length == 1)
            {
                foreach (var table in f_TableList)
                {
                    tmpTableFieldList.AddRange(GetAsteriskOfTable(table, true));
                }
            }

            if (tmpArray.Length == 2)
            {
                string tmpAlias = tmpArray[0];
                var tmpComparedTable = f_TableList.Find(item => item.Alias == tmpAlias);
                if (tmpComparedTable == null)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindSourceSheetWithAlias, tmpAlias));
                }

                tmpTableFieldList.AddRange(GetAsteriskOfTable(tmpComparedTable, false));
                tmpAsteriskTable = tmpComparedTable;
            }

            return new Sql.AsteriskField(tmpTableFieldList, tmpAsteriskTable);
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.TableField> FillJoinTableList(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> f_ConfigList, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.Table> f_JoinTableList, byForm_Server.ku.by.ToolClass.Sql.Table f_Table)
        {
            List<Sql.TableField> tmpSelectFieldList = new List<Sql.TableField>();
            int tmpNum = 0;
            foreach (var field in f_ConfigList)
            {
                if (field.SheetName == f_Table.SourceName)
                {
                    tmpSelectFieldList.Add(new Sql.TableField(field, f_Table, null));
                    continue;
                }

                var tmpReference = GetDataSheet(field.KuName, field.SheetName);
                //不可能存在一个表源join多次
                var tmpReferenceTable = f_JoinTableList.FirstOrDefault(table => table.Sheet == tmpReference);
                if (tmpReferenceTable == null)
                {
                    string tmpJoinTableName = "#" + tmpNum;
                    string tmpKuName = field.KuName;
                    DBTypeEnum tmpDBType;
                    if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpKuName, out tmpDBType))
                    {
                        ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpKuName));
                    }

                    //if (tmpDBType == DBTypeEnum.SqlServer)
                    //{
                    //    tmpJoinTableName = "[#" + tmpNum.ToString() + "]";
                    //}
                    //else if (tmpDBType == DBTypeEnum.Mysql)
                    //{
                    //    tmpJoinTableName = "`#" + tmpNum.ToString() + "`";
                    //}
                    //else
                    //{
                    //    tmpJoinTableName = "\"#" + tmpNum.ToString() + "\"";
                    //}

                    var tmpNewReferenceTable = new Sql.Table(tmpReference, tmpJoinTableName);
                    f_JoinTableList.Add(tmpNewReferenceTable);
                    tmpNum++;
                    tmpSelectFieldList.Add(new Sql.TableField(field, tmpNewReferenceTable, null));
                    continue;
                }
                tmpSelectFieldList.Add(new Sql.TableField(field, tmpReferenceTable, null));
            }

            return tmpSelectFieldList;
        }

        public static string GenerateQueryField(byForm_Server.ku.by.ToolClass.Sql.Table f_Table, byForm_Server.ku.by.ToolClass.Field f_Field)
        {
            string tmpKuName = f_Table.KuName;
            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpKuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpKuName));
            }

            StringBuilder tmpFieldValue = new StringBuilder();

            if (f_Table.Alias != null)
            {
                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpFieldValue.Append("[" + f_Table.Alias + "].");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpFieldValue.Append("`" + f_Table.Alias + "`.");
                }
                else
                {
                    tmpFieldValue.Append("\"" + f_Table.Alias + "\".");
                }
            }

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                tmpFieldValue.Append("[" + f_Field.Name + "]");
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                tmpFieldValue.Append("`" + f_Field.Name + "`");
            }
            else
            {
                tmpFieldValue.Append("\"" + f_Field.Name + "\"");
            }

            if (f_Field.Func == FunctionEnum.NONE)
            {
                return tmpFieldValue.ToString();
            }
            return string.Format("{0}({1})", f_Field.Func, tmpFieldValue);
        }

        public static string GenerateQueryDataExpression(byForm_Server.ku.by.ToolClass.Sql.Table f_Table, byForm_Server.ku.by.ToolClass.Source f_Source, object f_Value)
        {
            //like left, like both, like right, between, >, <, >=, <=, =, !=
            //值为null前面跳过了
            StringBuilder tmpExpression = new StringBuilder();
            if (f_Value == null)
            {
                return null;
            }

            if (f_Value is List<string> && f_Source.Operator != "between")
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.QueryAreaParameterError);
            }
            if (f_Source.Operator != "between")
            {
                tmpExpression.Append(GenerateQueryField(f_Table, f_Source.DataSheetField) + " ");

            }
            string tmpValue = f_Value.ToString();
            if (f_Value is string || f_Value is char)
            {
                tmpValue = SaveInspect.CheckSingleQuotes(tmpValue);
            }

            switch (f_Source.Operator)
            {
                case "likeleft":
                    // xx.xx like 'xx%'
                    tmpExpression.Append(string.Format("like '{0}%'", tmpValue));
                    break;
                case "likeright":
                    tmpExpression.Append(string.Format("like '%{0}'", tmpValue));
                    //%xx
                    break;
                case "likeboth":
                    //%xxx%
                    tmpExpression.Append(string.Format("like '%{0}%'", tmpValue));
                    break;
                case "between":
                    var tmpArrayValue = f_Value as List<string>;
                    if (tmpArrayValue == null)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.QueryAreaParameterError);
                    }
                    if (tmpArrayValue.Count != 2)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.QueryAreaParameterError);
                    }
                    string tmpGreaterThan = tmpArrayValue[0];
                    string tmpSmallerThan = tmpArrayValue[1];
                    if (tmpGreaterThan == null || tmpSmallerThan == null)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.QueryAreaParameterError);
                    }
                    tmpExpression.Append(string.Format("( {0} >= '{1}' and {0} <= '{2}' )", GenerateQueryField(f_Table, f_Source.DataSheetField), tmpGreaterThan, tmpSmallerThan));
                    break;
                case "greater":
                    tmpExpression.Append(string.Format("> '{0}'", tmpValue));
                    break;
                case "greaterthanorequal":
                    tmpExpression.Append(string.Format(">= '{0}'", tmpValue));
                    break;
                case "equal":
                    tmpExpression.Append(string.Format("= '{0}'", tmpValue));
                    break;
                case "lessthanorequal":
                    tmpExpression.Append(string.Format("<= '{0}'", tmpValue));
                    break;
                case "less":
                    tmpExpression.Append(string.Format("< '{0}'", tmpValue));
                    break;
                case "notEqual":
                    tmpExpression.Append(string.Format("!= '{0}'", tmpValue));
                    break;
                default:
                    throw ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.UnKnownQueryAreaParameter);
            }
            return tmpExpression.ToString();
        }

        public static System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Field, object> GetNewInsertValues()
        {
            return new Dictionary<Field, object>();
        }

        public static void FillNormalInsertValues(System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Field, object> f_InsertValues, object f_Parameter, byForm_Server.ku.by.ToolClass.Field f_Field)
        {
            if (f_InsertValues.ContainsKey(f_Field))
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.InsertFieldConflict, f_Field.Name));
            }

            f_InsertValues.Add(f_Field, f_Parameter);
        }

        public static void FillInsertValues(System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Field, object> f_InsertValues, object f_Parameter, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            //插入行专用
            List<Field> tmpFieldList = new List<Field>();

            if (f_InsertValues.Count == 0)
            {
                foreach (var item in f_Table.Sheet.FieldDic)
                {
                    tmpFieldList.Add(item.Value);
                }
            }
            else
            {
                foreach (var item in f_InsertValues)
                {
                    tmpFieldList.Add(item.Key);
                }
            }

            //参数只能为行或者行集合
            if (f_Parameter is Object.Row)
            {
                var tmpRow = f_Parameter as Object.Row;

                foreach (var item in tmpFieldList)
                {
                    var tmpCell = tmpRow.cells.Find(value => value.ColumnName == item.Name);
                    object tmpCellValue = tmpCell == null ? null : tmpCell.value;
                    string tmpAppendvalue = null;

                    if (tmpCellValue == null)
                    {
                        tmpAppendvalue = null;
                    }
                    else if (tmpCellValue is Object.datetime || tmpCellValue is char || tmpCellValue is string || tmpCellValue.GetType().IsEnum)
                    {
                        if (f_DBType == DBTypeEnum.Oracle && tmpCellValue is datetime)
                        {
                            tmpAppendvalue = "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')";
                        }
                        else
                        {
                            tmpAppendvalue = SaveInspect.CharactorEscape(tmpCellValue.ToString());
                        }
                    }
                    else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double || tmpCellValue is decimal)
                    {
                        tmpAppendvalue = tmpCellValue.ToString();
                    }
                    else if (tmpCellValue is bool)
                    {
                        var tmpBoolValue = (bool)tmpCellValue;
                        tmpAppendvalue = (tmpBoolValue ? 1 : 0).ToString();
                    }
                    else
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);//未知类型
                    }

                    if (f_InsertValues.ContainsKey(item))
                    {
                        f_InsertValues[item] = tmpAppendvalue;
                    }
                    else
                    {
                        f_InsertValues.Add(item, tmpAppendvalue);
                    }
                }

                return;
            }

            //存储的值行数要相同
            if (f_Parameter is ICollection<Object.Row>)
            {
                var tmpRows = f_Parameter as ICollection<Object.Row>;

                foreach (var item in tmpFieldList)
                {
                    if (f_InsertValues.ContainsKey(item))
                    {
                        continue;
                    }
                    else
                    {
                        var tmpObjectList = FindCellValuesInRows(item, tmpRows);
                        f_InsertValues.Add(item, tmpObjectList);
                    }
                }

                return;
            }

            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.IlleagalRowParameter);
        }

        public static string GenerateSqlByInsertValues(System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Field, object> f_InsertValues, byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            //装拆时直接验证
            //inservavlue里面的值都是字符串或者字符串列表
            if (f_InsertValues.Count == 0)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.InsertValueHasNoValue);
            }

            var tmpFirst = f_InsertValues.ElementAt(0);
            var tmpFirstValue = tmpFirst.Value;
            bool tmpIsRowList = tmpFirstValue is List<object>;
            StringBuilder tmpSql = new StringBuilder();

            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpSql.Append("INSERT INTO [" + f_DataSheet.SheetName + "] ");
            }
            else if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append("INSERT INTO `" + f_DataSheet.SheetName + "` ");
            }
            else
            {
                if (!tmpIsRowList)
                {
                    tmpSql.Append("INSERT INTO \"" + f_DataSheet.SheetName + "\" ");
                }
                else
                {
                    tmpSql.AppendLine("INSERT ALL ");
                }
            }

            //insert into sheet 
            StringBuilder tmpFieldsStringBuilder = new StringBuilder();
            StringBuilder tmpValuesStringBuilder = new StringBuilder();

            if (!(tmpIsRowList && f_DBType == DBTypeEnum.Oracle))
            {
                tmpValuesStringBuilder.Append(" VALUES");
                tmpFieldsStringBuilder.Append("(");
            }
            else
            {
                tmpFieldsStringBuilder.Append("INTO \"" + f_DataSheet.SheetName + "\" (");
            }

            for (int i = 0; i < f_DataSheet.FieldDic.Count; i++)
            {
                var tmpFieldKeyPair = f_DataSheet.FieldDic.ElementAt(i);
                var tmpField = tmpFieldKeyPair.Value;

                if (i != 0)
                {
                    tmpFieldsStringBuilder.Append(",");
                }

                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpFieldsStringBuilder.Append("[" + tmpFieldKeyPair.Key + "]");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpFieldsStringBuilder.Append("`" + tmpFieldKeyPair.Key + "`");
                }
                else
                {
                    tmpFieldsStringBuilder.Append("\"" + tmpFieldKeyPair.Key + "\"");
                }

                if (tmpIsRowList)
                {
                    //有且只有一个元素
                    var tmpStamdard = tmpFirstValue as List<object>;
                    int tmpStandardCount = tmpStamdard.Count;

                    if (!f_InsertValues.ContainsKey(tmpField))
                    {
                        List<object> tmpObjList = new List<object>();
                        f_InsertValues.Add(tmpField, tmpObjList);

                        for (int j = 0; j < tmpStandardCount; j++)
                        {
                            tmpObjList.Add(CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                        }
                    }
                }
                else
                {
                    if (!f_InsertValues.ContainsKey(tmpField))
                    {
                        f_InsertValues.Add(tmpField, CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                    }
                }
            }

            tmpFieldsStringBuilder.Append(")");

            if (tmpIsRowList)
            {
                var tmpFirstValues = f_InsertValues.ElementAt(0).Value as List<object>;
                int tmpFirstValueCount = tmpFirstValues.Count;
                for (int i = 0; i < tmpFirstValueCount; i++)
                {
                    if (i != 0 && f_DBType != DBTypeEnum.Oracle)
                    {
                        tmpValuesStringBuilder.Append(", ");
                    }

                    StringBuilder tmpPerRowValue = new StringBuilder();

                    if (f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpPerRowValue.Append(tmpFieldsStringBuilder.ToString());
                        tmpPerRowValue.Append("VALUES (");
                    }
                    else
                    {
                        tmpPerRowValue.Append("(");
                    }

                    for (int j = 0; j < f_InsertValues.Count; j++)
                    {
                        if (j != 0)
                        {
                            tmpPerRowValue.Append(", ");
                        }
                        //字符串已经经过处理直接添加即可
                        var tmpKeyPair = f_InsertValues.First(item => item.Key == f_DataSheet.FieldDic.ElementAt(j).Value);
                        var tmpValues = tmpKeyPair.Value as List<object>;
                        var tmpValue = tmpValues[i];
                        tmpPerRowValue.Append(tmpValue.ToString());
                    }

                    tmpPerRowValue.Append(")");
                    tmpValuesStringBuilder.AppendLine(tmpPerRowValue.ToString());
                }
            }
            else
            {
                tmpValuesStringBuilder.Append("(");
                for (int i = 0; i < f_InsertValues.Count; i++)
                {
                    if (i != 0)
                    {
                        tmpValuesStringBuilder.Append(", ");
                    }

                    var tmpKeyPair = f_InsertValues.First(item => item.Key == f_DataSheet.FieldDic.ElementAt(i).Value);
                    tmpValuesStringBuilder.Append(tmpKeyPair.Value.ToString());
                }
                tmpValuesStringBuilder.Append(")");
            }

            if (!tmpIsRowList || f_DBType != DBTypeEnum.Oracle)
            {
                tmpSql.Append(tmpFieldsStringBuilder);
            }

            tmpSql.Append(tmpValuesStringBuilder);

            if (tmpIsRowList && f_DBType == DBTypeEnum.Oracle)
            {
                tmpSql.Append("SELECT * FROM DUAL");
            }

            if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append(";");
            }

            if (f_DBType != DBTypeEnum.Oracle)
            {
                tmpSql.Append("\r\n");
            }

            return tmpSql.ToString();
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.UpdateSetValue> GetNewUpdateValues()
        {
            return new List<Sql.UpdateSetValue>();
        }

        public static void FillUpdateValues(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.UpdateSetValue> f_UpdateList, object f_Row, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> f_FieldList, string f_ConfigSheetName)
        {
            var tmpRow = f_Row as Object.Row;
            if (tmpRow == null)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIsNull);
            }
            foreach (var field in f_FieldList)
            {
                if (field.SheetName != f_ConfigSheetName)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnCurrentSheetField, field.Name));
                }

                var tmpValue = tmpRow.cells.Find(item => item.ColumnName == field.Name);
                if (tmpValue == null)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, field.Name));
                }

                if (!f_UpdateList.Exists(item => item.SetField.ValueIsSame(field)))
                {
                    f_UpdateList.Add(new Sql.UpdateSetValue(field, tmpValue.value, " = "));
                }
                else
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.HasRepetitiveField, field.Name));
                    //f_UpdateValues[field] = tmpValue.value;
                }
            }
        }

        public static void AddUpdateValue(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.UpdateSetValue> f_UpdateValues, object f_Value, byForm_Server.ku.by.ToolClass.Field f_Field, string f_Operator)
        {
            if (!f_UpdateValues.Exists(item => item.SetField.ValueIsSame(f_Field)))
            {
                f_UpdateValues.Add(new Sql.UpdateSetValue(f_Field, f_Value, f_Operator));
            }
            else
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.HasRepetitiveField, f_Field.Name));
            }
        }

        public static System.Collections.Generic.List<object> FindCellValuesInRows(byForm_Server.ku.by.ToolClass.Field f_Field, System.Collections.Generic.ICollection<byForm_Server.ku.by.Object.Row> f_Rows)
        {
            List<object> tmpList = new List<object>();
            string tmpKuName = f_Field.KuName;
            string tmpSheetName = f_Field.SheetName;
            string tmpColName = f_Field.Name;
            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpKuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpKuName));
            }

            foreach (var item in f_Rows)
            {
                var tmpCell = item.cells.Find(field => field.KuName == tmpKuName && field.SheetName == tmpSheetName && field.ColumnName == tmpColName);
                string tmpCellInsertValue = null;

                if (tmpCell == null || tmpCell.value == null || tmpCell.value is DBNull)
                {
                    tmpCellInsertValue = CellValueNullToDefaultReturnString(f_Field.FieldType, f_Field.EnumType, tmpDBType);
                }

                var tmpCellValue = tmpCell.value;

                if (tmpCellValue is string || tmpCellValue is char || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
                {
                    if (tmpCellValue is datetime && tmpDBType == DBTypeEnum.Oracle)
                    {
                        tmpCellInsertValue = "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')";
                    }
                    else
                    {
                        tmpCellInsertValue = SaveInspect.CharactorEscape(tmpCellValue.ToString());
                    }
                }

                if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                    || tmpCellValue is decimal)
                {
                    tmpCellInsertValue = tmpCellValue.ToString();
                }

                if (tmpCellInsertValue == null)
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
                }

                //if (tmpCell == null)
                //{
                //    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, f_Field.Name));
                //}

                tmpList.Add(tmpCellInsertValue);
            }
            return tmpList;
        }

        private static string FillPkOfWhere(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet, byForm_Server.ku.by.Object.Row f_Row, System.Text.StringBuilder f_Where, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            //null或者同表检查放在调用的地方
            var tmpPkList = f_DataSheet.PrimaryKeyList;

            if (tmpPkList == null || tmpPkList.Count == 0)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindPKInSheet, f_DataSheet.SheetName));
            }

            if (f_Where.Length == 0)
            {
                f_Where.Append(" WHERE ");
            }

            StringBuilder tmpNewWhere = new StringBuilder(f_Where.ToString());

            if (tmpNewWhere.Length != 7)
            {
                tmpNewWhere.Append(" AND (");
            }
            else
            {
                tmpNewWhere.Append("(");
            }

            for (int i = 0; i < tmpPkList.Count; i++)
            {
                var tmpPkField = tmpPkList[i];
                if (i != 0)
                {
                    tmpNewWhere.Append(" AND ");
                }

                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpNewWhere.Append(string.Format("[{0}].[{1}] = ", tmpPkField.SheetName, tmpPkField.Name));
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpNewWhere.Append(string.Format("`{0}`.`{1}` = ", tmpPkField.SheetName, tmpPkField.Name));
                }
                else
                {
                    tmpNewWhere.Append(string.Format("\"{0}\".\"{1}\" = ", tmpPkField.SheetName, tmpPkField.Name));
                }

                var tmpPkCell = f_Row.cells.Find(cell => cell.ColumnName == tmpPkField.Name && cell != null);
                if (tmpPkCell == null)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.RowHasRepetitiveField, tmpPkField.Name));
                }

                var tmpPkCellValue = tmpPkCell.value;
                if (tmpPkCellValue == null)
                {
                    tmpNewWhere.Append(" null ");
                    continue;
                }

                if (tmpPkCellValue is string || tmpPkCellValue is char || tmpPkCellValue is Object.datetime || tmpPkCellValue.GetType().IsEnum)
                {
                    tmpNewWhere.Append(SaveInspect.CharactorEscape(tmpPkCellValue.ToString()));
                    continue;
                }

                if (tmpPkCellValue is sbyte || tmpPkCellValue is short || tmpPkCellValue is int || tmpPkCellValue is long || tmpPkCellValue is float || tmpPkCellValue is double
                    || tmpPkCellValue is decimal)
                {
                    tmpNewWhere.Append(tmpPkCellValue.ToString());
                    continue;
                }

                if (tmpPkCellValue is bool)
                {
                    var tmpBoolValue = (bool)tmpPkCellValue;
                    tmpNewWhere.Append(tmpBoolValue ? 1 : 0);
                    continue;
                }

                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
            }
            tmpNewWhere.Append(")");
            return tmpNewWhere.ToString();
        }

        public static string FillUpdateRow(byForm_Server.ku.by.Object.Row f_Row, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.SetField> f_SetList, System.Text.StringBuilder f_Where, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            StringBuilder tmpSql = new StringBuilder();

            if (f_Row == null || f_Row.Identity == null)
            {
                return null;
            }

            var tmpIdentity = GetIdentityOfRow(f_Row);

            if (tmpIdentity.to == null)
            {
                return null;
            }

            IBaseDataSheet tmpDataSheet = tmpIdentity.to as IBaseDataSheet;

            if (tmpDataSheet == null)
            {
                return null;
            }

            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpSql.Append(string.Format("UPDATE [{0}] ", tmpDataSheet.SheetName));
            }
            else if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append(string.Format("UPDATE `{0}` ", tmpDataSheet.SheetName));
            }
            else
            {
                tmpSql.Append(string.Format("UPDATE \"{0}\" ", tmpDataSheet.SheetName));
            }

            if (f_SetList.Count != 0)
            {
                tmpSql.Append("SET ");
                for (int i = 0; i < f_SetList.Count; i++)
                {
                    if (i != 0)
                    {
                        tmpSql.Append(", ");
                    }

                    var tmpSetField = f_SetList[i];
                    var tmpField = ConvertComponentToField(tmpSetField.ComponentName, tmpDataSheet);
                    var tmpCell = f_Row.cells.Find(cell => cell.ColumnName == tmpField.Name && cell != null);

                    if (tmpCell == null)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.RowHasRepetitiveField, tmpField.Name));
                    }

                    object tmpCellValue = null;
                    bool tmpCellValueHasSet = false;

                    if (tmpSetField.Operator == "~")
                    {
                        var tmpUpdateSetField = FieldRelationAssignmentRow(tmpSetField.Field, f_Row);
                        tmpCellValue = tmpUpdateSetField.Value;
                        tmpCellValueHasSet = true;
                    }

                    if (!tmpCellValueHasSet)
                    {
                        tmpCellValue = tmpCell.value;
                    }

                    if (tmpCellValue == null || tmpCellValue is DBNull)
                    {
                        tmpCellValue = CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType);
                    }
                    else if (tmpCellValue is char || tmpCellValue is string || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
                    {
                        if (tmpCellValue is datetime && f_DBType == DBTypeEnum.Oracle)
                        {
                            tmpCellValue = "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')";
                        }
                        else
                        {
                            tmpCellValue = SaveInspect.CharactorEscape(tmpCellValue.ToString());
                        }
                    }
                    else if (tmpCell.value is sbyte || tmpCell.value is short || tmpCell.value is int || tmpCell.value is long || tmpCell.value is float || tmpCell.value is double
                        || tmpCell.value is decimal)
                    {
                        tmpCellValue = tmpCellValue.ToString();
                    }
                    else if (tmpCell.value is bool)
                    {
                        var tmpBoolValue = (bool)tmpCell.value;
                        tmpCellValue = tmpBoolValue ? 1 : 0;
                    }
                    else
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
                    }

                    if (f_DBType == DBTypeEnum.SqlServer)
                    {
                        string tmpFieldName = "[" + tmpDataSheet.SheetName + "].[" + tmpField.Name + "]";
                        if (tmpSetField.Operator == "=" || tmpSetField.Operator == "~")
                        {
                            tmpSql.Append(string.Format("{0} = {1}", tmpFieldName, tmpCellValue));
                        }
                        else
                        {
                            tmpSql.Append(string.Format("{0} {1}= {2}", tmpFieldName, tmpSetField.Operator, tmpCellValue));
                        }
                    }
                    else if (f_DBType == DBTypeEnum.Mysql)
                    {
                        string tmpFieldName = "`" + tmpDataSheet.SheetName + "`.`" + tmpField.Name + "`";
                        if (tmpSetField.Operator == "=" || tmpSetField.Operator == "~")
                        {
                            tmpSql.Append(string.Format("{0} = {1}", tmpFieldName, tmpCellValue));
                        }
                        else
                        {
                            tmpSql.Append(string.Format("{0} = {0} {1} {2}", tmpFieldName, tmpSetField.Operator, tmpCellValue));
                        }
                    }
                    else
                    {
                        string tmpFieldName = "\"" + tmpDataSheet.SheetName + "\".\"" + tmpField.Name + "\"";

                        if (tmpSetField.Operator == "%")
                        {
                            tmpSql.Append(string.Format("{0} = MOD({0}, {1})", tmpFieldName, tmpCellValue));
                        }
                        else if (tmpSetField.Operator == "&")
                        {
                            tmpSql.Append(string.Format("{0} = BITAND({0}, {1})", tmpFieldName, tmpCellValue));
                        }
                        else if (tmpSetField.Operator == "|")
                        {
                            tmpSql.Append(string.Format("{0} = {0} + ({1}) - BITAND({0}, {1})", tmpFieldName, tmpCellValue));
                        }
                        else if (tmpSetField.Operator == "^")
                        {
                            tmpSql.Append(string.Format("{0} = {0} + ({1}) - 2 * BITAND({0}, {1})", tmpFieldName, tmpCellValue));
                        }
                        else if (tmpSetField.Operator == "~" || tmpSetField.Operator == "=")
                        {
                            tmpSql.Append(string.Format("{0} = {1}", tmpFieldName, tmpCellValue));
                        }
                        else
                        {
                            tmpSql.Append(string.Format("{0} = {0} {1} {2} ", tmpField, tmpSetField.Operator, tmpCellValue));
                        }
                    }
                }
            }
            else
            {
                //根据行内容填充set
                var tmpPkList = tmpDataSheet.PrimaryKeyList;
                if (tmpPkList == null || tmpPkList.Count == 0)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindPKInSheet, tmpDataSheet.SheetName));
                }
                int tmpSetCount = 0;
                tmpSql.Append("SET ");
                for (int i = 0; i < f_Row.cells.Count; i++)
                {
                    var tmpCell = f_Row.cells[i];
                    if (tmpCell.SheetName != tmpDataSheet.SheetName)
                    {
                        continue;
                    }
                    if (tmpPkList.Exists(field => field.Name == tmpCell.ColumnName))
                    {
                        continue;
                    }
                    if (tmpSetCount != 0)
                    {
                        tmpSql.Append(", ");
                    }
                    tmpSetCount++;
                    var tmpField = tmpDataSheet.FieldDic[tmpCell.ColumnName];
                    if (tmpCell.value == null || tmpCell.value is DBNull)
                    {
                        if (f_DBType == DBTypeEnum.SqlServer)
                        {
                            tmpSql.Append(string.Format("[{0}].[{1}] = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, DBTypeEnum.SqlServer)));
                        }
                        else if (f_DBType == DBTypeEnum.Mysql)
                        {
                            tmpSql.Append(string.Format("`{0}`.`{1}` = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, DBTypeEnum.Mysql)));
                        }
                        else
                        {
                            tmpSql.Append(string.Format("\"{0}\".\"{1}\" = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, DBTypeEnum.Oracle)));
                        }
                        continue;
                    }

                    if (tmpCell.value is sbyte || tmpCell.value is short || tmpCell.value is int || tmpCell.value is long || tmpCell.value is float || tmpCell.value is double
                        || tmpCell.value is decimal)
                    {
                        if (f_DBType == DBTypeEnum.SqlServer)
                        {
                            tmpSql.Append(string.Format("[{0}].[{1}] = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, tmpCell.value.ToString()));
                        }
                        else if (f_DBType == DBTypeEnum.Mysql)
                        {
                            tmpSql.Append(string.Format("`{0}`.`{1}` = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, tmpCell.value.ToString()));
                        }
                        else
                        {
                            tmpSql.Append(string.Format("\"{0}\".\"{1}\" = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, tmpCell.value.ToString()));
                        }
                        continue;
                    }

                    if (tmpCell.value is string || tmpCell.value is char || tmpCell.value is ku.by.Object.datetime || tmpCell.value.GetType().IsEnum)
                    {
                        if (f_DBType == DBTypeEnum.SqlServer)
                        {
                            tmpSql.Append(string.Format("[{0}].[{1}] = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, SaveInspect.CharactorEscape(tmpCell.value.ToString())));
                        }
                        else if (f_DBType == DBTypeEnum.Mysql)
                        {
                            tmpSql.Append(string.Format("`{0}`.`{1}` = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, SaveInspect.CharactorEscape(tmpCell.value.ToString())));
                        }
                        else
                        {
                            string tmpValue;
                            if (tmpCell.value is datetime)
                            {
                                tmpValue = "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCell.value.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')";
                            }
                            else
                            {
                                tmpValue = SaveInspect.CharactorEscape(tmpCell.value.ToString());
                            }

                            tmpSql.Append(string.Format("\"{0}\".\"{1}\" = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, tmpValue));
                        }

                        continue;
                    }

                    if (tmpCell.value is bool)
                    {
                        var tmpBoolValue = (bool)tmpCell.value;

                        if (f_DBType == DBTypeEnum.SqlServer)
                        {
                            tmpSql.Append(string.Format("[{0}].[{1}] = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, tmpBoolValue ? 1 : 0));
                        }
                        else if (f_DBType == DBTypeEnum.Mysql)
                        {
                            tmpSql.Append(string.Format("`{0}`.`{1}` = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, tmpBoolValue ? 1 : 0));
                        }
                        else
                        {
                            tmpSql.Append(string.Format("\"{0}\".\"{1}\" = {2}", tmpDataSheet.SheetName, tmpCell.ColumnName, tmpBoolValue ? 1 : 0));
                        }

                        continue;
                    }

                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
                }
            }

            tmpSql.Append(FillPkOfWhere(tmpDataSheet, f_Row, f_Where, f_DBType));

            if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append(";");
            }

            if (f_DBType!= DBTypeEnum.Oracle)
            {
                tmpSql.Append("\r\n");
            }

            return tmpSql.ToString();
        }

        private static string FillInsertRow(byForm_Server.ku.by.Object.Row f_Row, System.Collections.Generic.List<string> f_InsertColumns, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            if (f_Row == null || f_Row.Identity == null)
            {
                return null;
            }

            var tmpIdentity = GetIdentityOfRow(f_Row);

            if (tmpIdentity.to == null)
            {
                return null;
            }

            IBaseDataSheet tmpDataSheet = tmpIdentity.to as IBaseDataSheet;

            if (tmpDataSheet == null)
            {
                return null;
            }

            StringBuilder tmpSql = new StringBuilder("INSERT INTO ");
            StringBuilder tmpValues = new StringBuilder(" VALUES(");

            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpSql.Append(string.Format("[{0}] (", tmpDataSheet.SheetName));
            }
            else if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append(string.Format("`{0}` (", tmpDataSheet.SheetName));
            }
            else
            {
                tmpSql.Append(string.Format("\"{0}\" (", tmpDataSheet.SheetName));
            }

            List<Field> tmpInsertFields = new List<Field>();

            for (int i = 0; i < tmpDataSheet.FieldDic.Count; i++)
            {
                if (i != 0)
                {
                    tmpSql.Append(", ");
                    tmpValues.Append(", ");
                }

                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpSql.Append(string.Format("[{0}]", tmpDataSheet.FieldDic.ElementAt(i).Key));
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpSql.Append(string.Format("`{0}`", tmpDataSheet.FieldDic.ElementAt(i).Key));
                }
                else
                {
                    tmpSql.Append(string.Format("\"{0}\"", tmpDataSheet.FieldDic.ElementAt(i).Key));
                }

                var tmpField = tmpDataSheet.FieldDic.ElementAt(i).Value;
                string tmpKuName = tmpField.KuName;
                string tmpSheetName = tmpField.SheetName;
                string tmpColumnName = tmpField.Name;
                object tmpCellValue = null;
                //未指定插入的列，则将行中第一个当前表的单元格插入

                if (f_InsertColumns.Count == 0)
                {
                    var tmpCell = f_Row.cells.Find(item => item.KuName == tmpKuName && item.SheetName == tmpSheetName && item.ColumnName == tmpColumnName);

                    if (tmpCell != null && tmpCell.value != null)
                    {
                        tmpCellValue = tmpCell.value;
                    }
                }
                else
                {
                    foreach (var componentName in f_InsertColumns)
                    {
                        var tmpInsertField = ConvertComponentToField(componentName, tmpDataSheet);

                        if (tmpInsertField == tmpField)
                        {
                            var tmpCell = f_Row.cells.FirstOrDefault(item => item.KuName == tmpKuName && item.SheetName == tmpSheetName && item.ColumnName == tmpColumnName);
                            if (tmpCell != null && tmpCell.value != null)
                            {
                                tmpCellValue = tmpCell.value;
                            }
                            continue;
                        }
                    }
                }

                if (tmpCellValue == null || tmpCellValue is DBNull)
                {
                    if (tmpDataSheet.DefaultColumnList.Contains(tmpColumnName))
                    {
                        tmpValues.Append(tmpDataSheet.GetFieldDefault(tmpColumnName));
                        continue;
                    }
                    else
                    {
                        tmpValues.Append(CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                        continue;
                    }
                }

                if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                    || tmpCellValue is decimal)
                {
                    tmpValues.Append(tmpCellValue.ToString());
                    continue;
                }

                if (tmpCellValue is string || tmpCellValue is char || tmpCellValue is ku.by.Object.datetime || tmpCellValue.GetType().IsEnum)
                {
                    if (tmpCellValue is datetime && f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpValues.Append("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                    }
                    else
                    {
                        tmpValues.Append(SaveInspect.CharactorEscape(tmpCellValue.ToString()));
                    }

                    continue;
                }

                if (tmpCellValue is bool)
                {
                    var tmpBoolValue = (bool)tmpCellValue;
                    tmpValues.Append(tmpBoolValue ? 1 : 0);
                    continue;
                }

                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
            }

            tmpSql.Append(")");
            tmpValues.Append(")");
            tmpSql.Append(tmpValues);
            return tmpSql.ToString();
        }

        public static string InsertRowOrRowListInTran(object f_RowParameter, string f_EffectedVariable, System.Collections.Generic.List<string> f_InsertCols, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            if (f_RowParameter == null)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    return string.Format("SET @{0} = 0\r\n", f_EffectedVariable);
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    return string.Format("SET ${0} = 0;\r\n", f_EffectedVariable);
                }
                else
                {
                    return string.Format("\"{0}\" := 0;\r\n", f_EffectedVariable);
                }
            }

            StringBuilder tmpSql = new StringBuilder();
            if (f_RowParameter is Object.Row)
            {
                var tmpRow = f_RowParameter as Object.Row;
                string tmpInsertSql = FillInsertRow(tmpRow, f_InsertCols, f_DBType);

                if (string.IsNullOrEmpty(tmpInsertSql))
                {
                    if (f_DBType == DBTypeEnum.SqlServer)
                    {
                        tmpSql.AppendLine(string.Format("SET @{0} = 0", f_EffectedVariable));
                    }
                    else if (f_DBType == DBTypeEnum.Mysql)
                    {
                        tmpSql.AppendLine(string.Format("SET ${0} = 0;", f_EffectedVariable));
                    }
                    else
                    {
                        tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedVariable));
                    }
                }
                else
                {
                    tmpSql.Append(tmpInsertSql);

                    if (f_DBType == DBTypeEnum.Mysql || f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpSql.AppendLine(";");
                    }
                    else
                    {
                        tmpSql.AppendLine("");
                    }

                    if (f_DBType == DBTypeEnum.SqlServer)
                    {
                        tmpSql.AppendLine(string.Format("SET @{0} = @@ROWCOUNT", f_EffectedVariable));
                    }
                    else if (f_DBType == DBTypeEnum.Mysql)
                    {
                        tmpSql.AppendLine(string.Format("SET ${0} = ROW_COUNT();", f_EffectedVariable));
                    }
                    else
                    {
                        tmpSql.AppendLine(string.Format("\"{0}\" := SQL%ROWCOUNT", f_EffectedVariable));
                    }
                }
            }
            else if (f_RowParameter is ICollection<Object.Row>)
            {
                var tmpRows = f_RowParameter as ICollection<Object.Row>;

                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpSql.AppendLine(string.Format("SET @{0} = 0", f_EffectedVariable));
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpSql.AppendLine(string.Format("SET ${0} = 0;", f_EffectedVariable));
                }
                else
                {
                    tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedVariable));
                }

                for (int i = 0; i < tmpRows.Count; i++)
                {
                    var tmpRow = tmpRows.ElementAt(i);
                    string tmpInsertSql = FillInsertRow(tmpRow, f_InsertCols, f_DBType);

                    if (string.IsNullOrEmpty(tmpInsertSql))
                    {
                        continue;
                    }

                    tmpSql.Append(tmpInsertSql);

                    if (f_DBType == DBTypeEnum.Mysql || f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpSql.Append(";");
                    }

                    tmpSql.AppendLine("");


                    if (f_DBType == DBTypeEnum.SqlServer)
                    {
                        tmpSql.AppendLine(string.Format("SET @{0} = @{0} + @@ROWCOUNT", f_EffectedVariable));
                    }
                    else if (f_DBType == DBTypeEnum.Mysql)
                    {
                        tmpSql.AppendLine(string.Format("SET ${0} = ${0} + ROW_COUNT();", f_EffectedVariable));
                    }
                    else
                    {
                        tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedVariable));
                    }
                }
            }
            else
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.IlleagalRowParameter);
            }
            return tmpSql.ToString();
        }

        public static string InsertRowOrRowList(object f_RowParameter, System.Collections.Generic.List<string> f_InsertCols, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            if (f_RowParameter == null)
            {
                return "";
            }

            StringBuilder tmpSql = new StringBuilder();
            if (f_RowParameter is Object.Row)
            {
                var tmpRow = f_RowParameter as Object.Row;
                string tmpInsertSql = FillInsertRow(tmpRow, f_InsertCols, f_DBType);
                tmpSql.Append(tmpInsertSql);
            }
            else if (f_RowParameter is ICollection<Object.Row>)
            {
                var tmpRows = f_RowParameter as ICollection<Object.Row>;

                for (int i = 0; i < tmpRows.Count; i++)
                {
                    var tmpRow = tmpRows.ElementAt(i);
                    string tmpInsertSql = FillInsertRow(tmpRow, f_InsertCols, f_DBType);

                    if (string.IsNullOrEmpty(tmpInsertSql))
                    {
                        continue;
                    }

                    tmpSql.Append(tmpInsertSql);

                    if (f_DBType == DBTypeEnum.Mysql || f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpSql.Append(";");
                    }

                    tmpSql.AppendLine("");

                    if (f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpSql.AppendLine("EFFECTCOUNT := EFFECTCOUNT + SQL%ROWCOUNT;");
                    }
                }
            }
            else
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.IlleagalRowParameter);
            }
            return tmpSql.ToString();
        }

        public static string FillDeleteRow(byForm_Server.ku.by.Object.Row f_Row, System.Text.StringBuilder f_Where, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            if (f_Row == null || f_Row.Identity == null)
            {
                return null;
            }

            var tmpIdentity = GetIdentityOfRow(f_Row);

            if (tmpIdentity.to == null)
            {
                return null;
            }

            IBaseDataSheet tmpDataSheet = tmpIdentity.to as IBaseDataSheet;

            if (tmpDataSheet == null)
            {
                return null;
            }

            StringBuilder tmpSql = new StringBuilder();
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpSql.Append(string.Format("DELETE FROM [{0}] ", tmpDataSheet.SheetName));
            }
            else if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append(string.Format("DELETE FROM `{0}` ", tmpDataSheet.SheetName));
            }
            else
            {
                tmpSql.Append(string.Format("DELETE FROM \"{0}\" ", tmpDataSheet.SheetName));
            }

            tmpSql.Append(FillPkOfWhere(tmpDataSheet, f_Row, f_Where, f_DBType));

            if (f_DBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append(";");
            }

            if (f_DBType != DBTypeEnum.Oracle)
            {
                tmpSql.Append("\r\n");
            }

            return tmpSql.ToString();
        }

        public static bool RowRelationEqualRow(byForm_Server.ku.by.Object.Row f_Row1, byForm_Server.ku.by.Object.Row f_Row2)
        {
            if (f_Row1 == null || f_Row2 == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
            }

            if (f_Row1.KuName != f_Row2.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            List<Cell> tmpDifferentCells1 = new List<Cell>();
            List<string> tmpColumnNames1 = new List<string>();
            List<Cell> tmpDifferentCells2 = new List<Cell>();
            List<string> tmpColumnNames2 = new List<string>();

            foreach (var item in f_Row1.cells)
            {
                if (item.KuName != f_Row1.KuName)
                {
                    continue;
                }

                string tmpQualifiedName = item.SheetName + "." + item.ColumnName;
                if (tmpColumnNames1.Contains(tmpQualifiedName))
                {
                    continue;
                }

                tmpColumnNames1.Add(tmpQualifiedName);
                tmpDifferentCells1.Add(item);
            }

            foreach (var item in f_Row2.cells)
            {
                if (item.KuName != f_Row2.KuName)
                {
                    continue;
                }

                string tmpQualifiedName = item.SheetName + "." + item.ColumnName;
                if (tmpColumnNames2.Contains(tmpQualifiedName))
                {
                    continue;
                }

                tmpColumnNames2.Add(tmpQualifiedName);
                tmpDifferentCells2.Add(item);
            }

            var tmpKu = Root.GetInstance()[f_Row1.KuName];
            string tmpSheetName1 = f_Row1.SheetName;
            string tmpSheetName2 = f_Row2.SheetName;

            if (tmpSheetName1 == tmpSheetName2)
            {
                //找主键
                var tmpDataSheet = tmpKu.DataSheetDic[tmpSheetName1];
                foreach (var item in tmpDataSheet.PrimaryKeyList)
                {
                    string tmpColumnName = item.Name;
                    var tmpCell1 = tmpDifferentCells1.Find(cell => cell.ColumnName == tmpColumnName);
                    var tmpCell2 = tmpDifferentCells2.Find(cell => cell.ColumnName == tmpColumnName);

                    if (tmpCell1 == null || tmpCell2 == null)
                    {
                        return false;
                    }

                    if (tmpCell1.value == null || tmpCell2.value == null)
                    {
                        return false;
                    }

                    if (tmpCell1.value != tmpCell2.value)
                    {
                        return false;
                    }
                }
                return true;
            }

            //不同名的表
            bool tmpHasReferencedField = false;
            foreach (var cell1 in tmpDifferentCells1)
            {
                string tmpCellQualifiedName1 = cell1.SheetName + "." + cell1.ColumnName;

                foreach (var cell2 in tmpDifferentCells2)
                {
                    string tmpCellQualifiedName2 = cell2.SheetName + "." + cell2.ColumnName;

                    if (FieldHasRefernece(tmpKu, tmpCellQualifiedName1, tmpCellQualifiedName2))
                    {
                        tmpHasReferencedField = true;
                        if (cell1.value != cell2.value)
                        {
                            return false;
                        }
                    }
                }
            }

            if (tmpHasReferencedField)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RowComponentRelationEqualRow(byForm_Server.ku.by.Object.Row f_ComponentRow, byForm_Server.ku.by.Object.Row f_Row, string f_Component)
        {
            if (f_Row == null || f_ComponentRow == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
            }

            var tmpKu = Root.GetInstance()[f_Row.KuName];
            var tmpDataSheet = GetDataSheet(tmpKu.Name, f_ComponentRow.SheetName);
            if (!tmpDataSheet.ComponentDic.ContainsKey(f_Component))
            {
                ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.SheetName, f_Component));
            }

            var tmpField = tmpDataSheet.ComponentDic[f_Component];
            if (tmpField.ReferenceField == null)
            {
                var tmpTargetCell = f_Row.cells.FirstOrDefault(item => item.field != null && item.field.Field == tmpField);
                if (tmpTargetCell == null)
                {
                    return false;
                }
                else
                {
                    string tmpComponentQualifiedName = tmpKu.Name + "." + tmpField.SheetName + "." + tmpField.Name;
                    var tmpCell = f_ComponentRow[tmpComponentQualifiedName];
                    if (tmpCell.DataTypeEnum == DataTypeEnum.None)
                    {
                        tmpCell.DataTypeEnum = tmpField.FieldType;
                        tmpCell.EnumType = tmpField.EnumType;
                    }
                    return tmpTargetCell.value == tmpCell.value;
                }
            }

            var tmpRefCell = f_Row.cells.FirstOrDefault(item => item.field != null && (item.field.Field == tmpField.ReferenceField || item.field.Field == tmpField));

            if (tmpRefCell == null)
            {
                return false;
            }
            else
            {
                string tmpComponentQualifiedName = tmpKu.Name + "." + tmpField.SheetName + "." + tmpField.Name;
                var tmpCell = f_ComponentRow[tmpComponentQualifiedName];
                if (tmpCell.DataTypeEnum == DataTypeEnum.None)
                {
                    tmpCell.DataTypeEnum = tmpField.FieldType;
                    tmpCell.EnumType = tmpField.EnumType;
                }
                return tmpCell.value == tmpRefCell.value;
            }
        }

        public static void RowRelationAssignRow(byForm_Server.ku.by.Object.Row f_Row1, byForm_Server.ku.by.Object.Row f_Row2)
        {
            if (f_Row1 == null || f_Row2 == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
            }

            if (f_Row1.KuName != f_Row2.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            var tmpKu = Root.GetInstance()[f_Row1.KuName];
            List<Cell> tmpDifferentCells = new List<Cell>();
            List<string> tmpColumnNames = new List<string>();
            //先去重，重复的取第一个
            foreach (var item in f_Row2.cells)
            {
                if (item.KuName != tmpKu.Name)
                {
                    continue;
                }

                string tmpQualifiedColumnName = item.SheetName + "." + item.ColumnName;
                if (tmpColumnNames.Contains(tmpQualifiedColumnName))
                {
                    continue;
                }

                tmpColumnNames.Add(tmpQualifiedColumnName);
                tmpDifferentCells.Add(item);
            }

            foreach (var item in f_Row1.cells)
            {
                if (item.KuName != tmpKu.Name)
                {
                    continue;
                }

                string tmpQualifiedName = item.SheetName + "." + item.ColumnName;

                foreach (var element in tmpDifferentCells)
                {
                    string tmpCellQualifiedName = element.SheetName + "." + element.ColumnName;

                    if (FieldHasRefernece(tmpKu, tmpQualifiedName, tmpCellQualifiedName))
                    {
                        item.SetValue(element.value);
                    }

                    if (tmpCellQualifiedName == tmpQualifiedName)
                    {
                        item.SetValue(element.value);
                    }
                }
            }
        }

        public static void RowRelationAssignRowComponent(byForm_Server.ku.by.Object.Row f_Row, byForm_Server.ku.by.Object.Row f_ComponentRow, string f_Component)
        {
            if (f_Row == null || f_ComponentRow == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
            }

            //目前不支持不同库
            if (f_ComponentRow.KuName != f_Row.KuName)
            {
                ThrowHelper.ThrowDataMatchException(ErrorInfo.DifferentKuInRelationExpression);
            }
            var tmpKu = Root.GetInstance()[f_ComponentRow.KuName];
            var tmpDataSheet = GetDataSheet(tmpKu.Name, f_ComponentRow.SheetName);
            if (!tmpDataSheet.ComponentDic.ContainsKey(f_Component))
            {
                ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.SheetName, f_Component));
            }
            var tmpField = tmpDataSheet.ComponentDic[f_Component];
            string tmpComponentQualifiedName = tmpKu.Name + "." + f_ComponentRow.SheetName + "." + tmpField.Name;
            var tmpCell = f_ComponentRow[tmpComponentQualifiedName];
            if (tmpCell.value == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.CanNotAssinmentNullToRowValue);
            }
            if (tmpCell.DataTypeEnum == DataTypeEnum.None)
            {
                tmpCell.DataTypeEnum = tmpField.FieldType;
                tmpCell.EnumType = tmpField.EnumType;
            }
            string tmpCellQualifiedName = tmpCell.SheetName + "." + tmpCell.ColumnName;
            foreach (var item in f_Row.cells)
            {
                if (item.KuName == null || item.KuName != tmpKu.Name)
                {
                    continue;
                }

                string tmpQualifiedName = item.SheetName + "." + item.ColumnName;

                if (FieldHasRefernece(tmpKu, tmpCellQualifiedName, tmpQualifiedName))
                {
                    item.SetValue(tmpCell.value);
                }

                if (tmpQualifiedName == tmpCellQualifiedName)
                {
                    item.SetValue(tmpCell.value);
                }
            }
        }

        private static void CheckNullBeforeAssignment(byForm_Server.ku.DataTypeEnum f_Type, System.Type f_EnumType)
        {
            string tmpValueTypeName = null;
            switch (f_Type)
            {
                case DataTypeEnum.Bool:
                    tmpValueTypeName = "bool";
                    break;
                case DataTypeEnum.Byte:
                    tmpValueTypeName = "byte";
                    break;
                case DataTypeEnum.Char:
                    tmpValueTypeName = "char";
                    break;
                case DataTypeEnum.Decimal:
                    tmpValueTypeName = "decimal";
                    break;
                case DataTypeEnum.Double:
                    tmpValueTypeName = "double";
                    break;
                case DataTypeEnum.Enum:
                    if (f_EnumType == null)
                    {
                        tmpValueTypeName = "enum";
                    }
                    else
                    {
                        tmpValueTypeName = f_EnumType.Name;
                    }
                    break;
                case DataTypeEnum.Float:
                    tmpValueTypeName = "float";
                    break;
                case DataTypeEnum.Int:
                    tmpValueTypeName = "int";
                    break;
                case DataTypeEnum.Long:
                    tmpValueTypeName = "long";
                    break;
                case DataTypeEnum.Short:
                    tmpValueTypeName = "short";
                    break;
                default:
                    break;
            }

            if (tmpValueTypeName != null)
            {
                ThrowHelper.ThrowVerifyException(string.Format(ToolClass.ErrorInfo.CannotConvertNull, tmpValueTypeName));
            }
        }

        public static void RowComponentSimpleAssignment(byForm_Server.ku.by.Object.Cell f_Cell, object f_Value)
        {
            if (f_Cell.DataTypeEnum == DataTypeEnum.None)
            {
                f_Cell.SetValue(f_Value);
                return;
            }

            if (f_Value == null)
            {
                CheckNullBeforeAssignment(f_Cell.DataTypeEnum, f_Cell.EnumType);
                f_Cell.SetValue(null);
            }

            var tmpValueType = f_Value.GetType();

            try
            {
                object tmpValue = f_Value;
                if (f_Value is char)
                {
                    tmpValue = Convert.ToInt32(f_Value);
                }
                switch (f_Cell.DataTypeEnum)
                {
                    case DataTypeEnum.Bool:
                        bool tmpBoolValue = Convert.ToBoolean(tmpValue);
                        f_Cell.SetValue(tmpBoolValue);
                        break;
                    case DataTypeEnum.Byte:
                        sbyte tmpByteValue = Convert.ToSByte(tmpValue);
                        f_Cell.SetValue(tmpByteValue);
                        break;
                    case DataTypeEnum.Char:
                        char tmpCharValue = Convert.ToChar(tmpValue);
                        f_Cell.SetValue(tmpCharValue);
                        break;
                    case DataTypeEnum.Datetime:
                        Object.datetime tmpDatetimeValue = Object.datetime.ConvertToDatetime(tmpValue);
                        f_Cell.SetValue(tmpDatetimeValue);
                        break;
                    case DataTypeEnum.Decimal:
                        decimal tmpDecimalValue = Convert.ToDecimal(tmpValue);
                        f_Cell.SetValue(tmpDecimalValue);
                        break;
                    case DataTypeEnum.Double:
                        double tmpDoubleValue = Convert.ToDouble(tmpValue);
                        f_Cell.SetValue(tmpDoubleValue);
                        break;
                    case DataTypeEnum.Enum:
                        var tmpEnumType = f_Cell.EnumType;
                        var tmpEnumValue = System.Enum.Parse(tmpEnumType, tmpValue.ToString(), true);
                        f_Cell.SetValue(tmpEnumValue);
                        break;
                    case DataTypeEnum.Float:
                        float tmpFloatValue = Convert.ToSingle(tmpValue);
                        f_Cell.SetValue(tmpFloatValue);
                        break;
                    case DataTypeEnum.Int:
                        int tmpIntValue = Convert.ToInt32(tmpValue);
                        f_Cell.SetValue(tmpIntValue);
                        break;
                    case DataTypeEnum.Long:
                        long tmpLongValue = Convert.ToInt64(tmpValue);
                        f_Cell.SetValue(tmpLongValue);
                        break;
                    case DataTypeEnum.Short:
                        short tmpShortValue = Convert.ToInt16(tmpValue);
                        f_Cell.SetValue(tmpShortValue);
                        break;
                    case DataTypeEnum.String:
                        f_Cell.SetValue(tmpValue);
                        break;
                }
            }
            catch
            {
                if (f_Cell.DataTypeEnum == DataTypeEnum.Enum)
                {
                    ThrowHelper.ThrowVerifyException(string.Format(ToolClass.ErrorInfo.CannotConvertType, f_Cell.EnumType.Name));
                }
                ThrowHelper.ThrowVerifyException(string.Format(ToolClass.ErrorInfo.CannotConvertType, f_Cell.DataTypeEnum.ToString().ToLower()));
            }
        }

        public static void RowComponentAssignment(byForm_Server.ku.by.Object.Cell f_Cell, object f_Value, string f_Operator)
        {
            //+-*/%&|<<>>^
            if (f_Cell.DataTypeEnum == DataTypeEnum.None)
            {
                return;
            }

            if (f_Value == null)
            {
                CheckNullBeforeAssignment(f_Cell.DataTypeEnum, f_Cell.EnumType);
                f_Cell.SetValue(null);
            }

            string tmpOperator = f_Operator.Trim();
            var tmpValueType = f_Value.GetType();

            try
            {
                //默认单元格里面的值没有问题
                switch (f_Cell.DataTypeEnum)
                {
                    case DataTypeEnum.Bool:
                        throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, "bool", tmpValueType.Name));
                    case DataTypeEnum.Byte:
                        sbyte tmpByteValue = Convert.ToSByte(f_Value);
                        sbyte tmpByteCellValue = (sbyte)f_Cell.value;
                        if (tmpOperator == "+=")
                        {
                            tmpByteCellValue += tmpByteValue;
                        }
                        else if (tmpOperator == "-=")
                        {
                            tmpByteCellValue -= tmpByteValue;
                        }
                        else if (tmpOperator == "*=")
                        {
                            tmpByteCellValue *= tmpByteValue;
                        }
                        else if (tmpOperator == "/=")
                        {
                            tmpByteCellValue /= tmpByteValue;
                        }
                        else if (tmpOperator == "%=")
                        {
                            tmpByteCellValue %= tmpByteValue;
                        }
                        else if (tmpOperator == "^=")
                        {
                            tmpByteCellValue ^= tmpByteValue;
                        }
                        else if (tmpOperator == "&=")
                        {
                            tmpByteCellValue &= tmpByteValue;
                        }
                        else if (tmpOperator == "|=")
                        {
                            tmpByteCellValue |= tmpByteValue;
                        }
                        else if (tmpOperator == ">>=")
                        {
                            tmpByteCellValue >>= tmpByteValue;
                        }
                        else if (tmpOperator == "<<=")
                        {
                            tmpByteCellValue <<= tmpByteValue;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                        }
                        f_Cell.SetValue(tmpByteCellValue);
                        break;
                    case DataTypeEnum.Char:
                        char tmpCharValue = Convert.ToChar(f_Value);
                        char tmpCharCellValue = (char)f_Cell.value;
                        if (tmpOperator == "+=")
                        {
                            tmpCharCellValue += tmpCharValue;
                        }
                        else if (tmpOperator == "-=")
                        {
                            tmpCharCellValue -= tmpCharValue;
                        }
                        else if (tmpOperator == "*=")
                        {
                            tmpCharCellValue *= tmpCharValue;
                        }
                        else if (tmpOperator == "/=")
                        {
                            tmpCharCellValue /= tmpCharValue;
                        }
                        else if (tmpOperator == "%=")
                        {
                            tmpCharCellValue %= tmpCharValue;
                        }
                        else if (tmpOperator == "^=")
                        {
                            tmpCharCellValue ^= tmpCharValue;
                        }
                        else if (tmpOperator == "&=")
                        {
                            tmpCharCellValue &= tmpCharValue;
                        }
                        else if (tmpOperator == "|=")
                        {
                            tmpCharCellValue |= tmpCharValue;
                        }
                        else if (tmpOperator == ">>=")
                        {
                            tmpCharCellValue >>= tmpCharValue;
                        }
                        else if (tmpOperator == "<<=")
                        {
                            tmpCharCellValue <<= tmpCharValue;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                        }
                        f_Cell.SetValue(tmpCharCellValue);
                        break;
                    case DataTypeEnum.Datetime:
                        throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, "datetime", tmpValueType.Name));
                    case DataTypeEnum.Decimal:
                        decimal tmpDecimalValue = Convert.ToDecimal(f_Value);
                        decimal tmpDecimalCellValue = (decimal)f_Cell.value;
                        if (tmpOperator == "+=")
                        {
                            tmpDecimalCellValue += tmpDecimalValue;
                        }
                        else if (tmpOperator == "-=")
                        {
                            tmpDecimalCellValue -= tmpDecimalValue;
                        }
                        else if (tmpOperator == "*=")
                        {
                            tmpDecimalCellValue *= tmpDecimalValue;
                        }
                        else if (tmpOperator == "/=")
                        {
                            tmpDecimalCellValue /= tmpDecimalValue;
                        }
                        else if (tmpOperator == "%=")
                        {
                            tmpDecimalCellValue %= tmpDecimalValue;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                        }
                        tmpDecimalCellValue += tmpDecimalValue;
                        f_Cell.SetValue(tmpDecimalCellValue);
                        break;
                    case DataTypeEnum.Double:
                        double tmpDoubleValue = Convert.ToDouble(f_Value);
                        double tmpDoubleCellValue = (double)f_Cell.value;
                        if (tmpOperator == "+=")
                        {
                            tmpDoubleCellValue += tmpDoubleValue;
                        }
                        else if (tmpOperator == "-=")
                        {
                            tmpDoubleCellValue -= tmpDoubleValue;
                        }
                        else if (tmpOperator == "*=")
                        {
                            tmpDoubleCellValue *= tmpDoubleValue;
                        }
                        else if (tmpOperator == "/=")
                        {
                            tmpDoubleCellValue /= tmpDoubleValue;
                        }
                        else if (tmpOperator == "%=")
                        {
                            tmpDoubleCellValue %= tmpDoubleValue;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                        }
                        tmpDoubleCellValue += tmpDoubleValue;
                        f_Cell.SetValue(tmpDoubleCellValue);
                        break;
                    case DataTypeEnum.Enum:
                        throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                    case DataTypeEnum.Float:
                        float tmpFloatValue = Convert.ToSingle(f_Value);
                        float tmpFloatCellValue = (float)f_Cell.value;
                        if (tmpOperator == "+=")
                        {
                            tmpFloatCellValue += tmpFloatValue;
                        }
                        else if (tmpOperator == "-=")
                        {
                            tmpFloatCellValue -= tmpFloatValue;
                        }
                        else if (tmpOperator == "*=")
                        {
                            tmpFloatCellValue *= tmpFloatValue;
                        }
                        else if (tmpOperator == "/=")
                        {
                            tmpFloatCellValue /= tmpFloatValue;
                        }
                        else if (tmpOperator == "%=")
                        {
                            tmpFloatCellValue %= tmpFloatValue;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                        }
                        f_Cell.SetValue(tmpFloatCellValue);
                        break;
                    case DataTypeEnum.Int:
                        int tmpIntValue = Convert.ToInt32(f_Value);
                        int tmpIntCellValue = (int)f_Cell.value;
                        if (tmpOperator == "+=")
                        {
                            tmpIntCellValue += tmpIntValue;
                        }
                        else if (tmpOperator == "-=")
                        {
                            tmpIntCellValue -= tmpIntValue;
                        }
                        else if (tmpOperator == "*=")
                        {
                            tmpIntCellValue *= tmpIntValue;
                        }
                        else if (tmpOperator == "/=")
                        {
                            tmpIntCellValue /= tmpIntValue;
                        }
                        else if (tmpOperator == "%=")
                        {
                            tmpIntCellValue %= tmpIntValue;
                        }
                        else if (tmpOperator == "^=")
                        {
                            tmpIntCellValue ^= tmpIntValue;
                        }
                        else if (tmpOperator == "&=")
                        {
                            tmpIntCellValue &= tmpIntValue;
                        }
                        else if (tmpOperator == "|=")
                        {
                            tmpIntCellValue |= tmpIntValue;
                        }
                        else if (tmpOperator == ">>=")
                        {
                            tmpIntCellValue >>= tmpIntValue;
                        }
                        else if (tmpOperator == "<<=")
                        {
                            tmpIntCellValue <<= tmpIntValue;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                        }
                        f_Cell.SetValue(tmpIntCellValue);
                        break;
                    case DataTypeEnum.Long:
                        long tmpLongValue = Convert.ToInt64(f_Value);
                        long tmpLongCellValue = (long)f_Cell.value;
                        if (tmpOperator == "+=")
                        {
                            tmpLongCellValue += tmpLongValue;
                        }
                        else if (tmpOperator == "-=")
                        {
                            tmpLongCellValue -= tmpLongValue;
                        }
                        else if (tmpOperator == "*=")
                        {
                            tmpLongCellValue *= tmpLongValue;
                        }
                        else if (tmpOperator == "/=")
                        {
                            tmpLongCellValue /= tmpLongValue;
                        }
                        else if (tmpOperator == "%=")
                        {
                            tmpLongCellValue %= tmpLongValue;
                        }
                        else if (tmpOperator == "^=")
                        {
                            tmpLongCellValue ^= tmpLongValue;
                        }
                        else if (tmpOperator == "&=")
                        {
                            tmpLongCellValue &= tmpLongValue;
                        }
                        else if (tmpOperator == "|=")
                        {
                            tmpLongCellValue |= tmpLongValue;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                        }
                        f_Cell.SetValue(tmpLongCellValue);
                        break;
                    case DataTypeEnum.Short:
                        short tmpShortValue = Convert.ToInt16(f_Value);
                        short tmpShortCellValue = (short)f_Cell.value;
                        if (tmpOperator == "+=")
                        {
                            tmpShortCellValue += tmpShortValue;
                        }
                        else if (tmpOperator == "-=")
                        {
                            tmpShortCellValue -= tmpShortValue;
                        }
                        else if (tmpOperator == "*=")
                        {
                            tmpShortCellValue *= tmpShortValue;
                        }
                        else if (tmpOperator == "/=")
                        {
                            tmpShortCellValue /= tmpShortValue;
                        }
                        else if (tmpOperator == "%=")
                        {
                            tmpShortCellValue %= tmpShortValue;
                        }
                        else if (tmpOperator == "^=")
                        {
                            tmpShortCellValue ^= tmpShortValue;
                        }
                        else if (tmpOperator == "&=")
                        {
                            tmpShortCellValue &= tmpShortValue;
                        }
                        else if (tmpOperator == "|=")
                        {
                            tmpShortCellValue |= tmpShortValue;
                        }
                        else if (tmpOperator == ">>=")
                        {
                            tmpShortCellValue >>= tmpShortValue;
                        }
                        else if (tmpOperator == "<<=")
                        {
                            tmpShortCellValue <<= tmpShortValue;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.GetType().Name, tmpValueType.Name));
                        }
                        tmpShortCellValue += tmpShortValue;
                        f_Cell.SetValue(tmpShortCellValue);
                        break;
                    case DataTypeEnum.String:
                        if (tmpOperator == "+=")
                        {
                            string tmpStringCellValue = (string)f_Cell.value;
                            tmpStringCellValue += f_Value;
                            f_Cell.SetValue(tmpStringCellValue);
                            break;
                        }
                        else
                        {
                            throw new TheKnownException(string.Format(ErrorInfo.AssignmentNotAllowed, tmpOperator, "string", tmpValueType.Name));
                        }
                }
            }
            catch (Exception ex)
            {
                if (ex is TheKnownException || ex is OverflowException)
                {
                    ThrowHelper.ThrowVerifyException(ex.Message);
                }

                if (f_Cell.DataTypeEnum == DataTypeEnum.Enum)
                {
                    ThrowHelper.ThrowVerifyException(string.Format(ToolClass.ErrorInfo.CannotConvertType, f_Cell.EnumType.Name));
                }
                ThrowHelper.ThrowVerifyException(string.Format(ToolClass.ErrorInfo.CannotConvertType, f_Cell.DataTypeEnum.ToString().ToLower()));
            }
        }

        public static void RowComponentAssignRow(byForm_Server.ku.by.Object.Row f_ComponentRow, byForm_Server.ku.by.Object.Row f_Row, string f_Component)
        {
            if (f_Row == null || f_ComponentRow == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
            }

            //目前不支持不同库
            if (f_ComponentRow.KuName != f_Row.KuName)
            {
                ThrowHelper.ThrowDataMatchException(ErrorInfo.DifferentKuInRelationExpression);
            }

            var tmpKu = Root.GetInstance()[f_Row.KuName];
            var tmpDataSheet = GetDataSheet(tmpKu.Name, f_ComponentRow.SheetName);
            if (!tmpDataSheet.ComponentDic.ContainsKey(f_Component))
            {
                ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.SheetName, f_Component));
            }
            var tmpField = tmpDataSheet.ComponentDic[f_Component];
            string tmpComponentQualifiedName = tmpKu.Name + "." + tmpField.SheetName + "." + tmpField.Name;
            var tmpCell = f_ComponentRow[tmpComponentQualifiedName];
            if (tmpCell.DataTypeEnum == DataTypeEnum.None)
            {
                tmpCell.DataTypeEnum = tmpField.FieldType;
                tmpCell.EnumType = tmpField.EnumType;
            }
            //已经做过同库的限制
            string tmpCellQualifiedName = tmpCell.SheetName + "." + tmpCell.ColumnName;
            Object.Cell tmpMatchedCell = null;

            foreach (var item in f_Row.cells)
            {
                if (item.KuName == null || item.KuName != tmpKu.Name)
                {
                    continue;
                }

                string tmpQualifiedName = item.SheetName + "." + item.ColumnName;

                if (FieldHasRefernece(tmpKu, tmpCellQualifiedName, tmpQualifiedName))
                {
                    tmpMatchedCell = item;
                    break;
                }

                if (tmpCellQualifiedName == tmpQualifiedName)
                {
                    tmpMatchedCell = item;
                    break;
                }
            }

            if (tmpMatchedCell == null)
            {
                return;
            }

            if (tmpMatchedCell.value == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.CanNotAssinmentNullToRowValue);
            }
            if(tmpMatchedCell.DataTypeEnum == DataTypeEnum.None)
            {
                tmpMatchedCell.DataTypeEnum = tmpCell.DataTypeEnum;
                tmpMatchedCell.EnumType = tmpCell.EnumType;
            }
            tmpCell.SetValue(tmpMatchedCell.value);
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> ConvertConfigList(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> f_ConfigList, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables)
        {
            //给localsql填充field用，里面表信息不重要，数量索引对就可以
            List<Sql.AbstractSelectField> tmpFieldList = new List<Sql.AbstractSelectField>();
            if (f_ConfigList == null)
            {
                return tmpFieldList;
            }

            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_Table.KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_Table.KuName));
            }

            Dictionary<IBaseDataSheet, Sql.Table> tmpDic = new Dictionary<IBaseDataSheet, Sql.Table>();//填充所有非本表的表
            foreach (var item in f_ConfigList)
            {
                var tmpField = item.DataSheetField;
                var tmpDataSheet = GetDataSheet(tmpField.KuName, tmpField.SheetName);

                if (tmpDataSheet == f_Table.Sheet)
                {
                    if (tmpField.Func != FunctionEnum.NONE)
                    {
                        var tmpFuncField = new Sql.FuncField(tmpField.Func.ToString(), DataTypeEnum.None, null, tmpDBType);
                        if (tmpField.Func == FunctionEnum.COUNT && tmpField.Name == "*")
                        {
                            tmpFuncField.Params.Add(new Sql.AsteriskField());
                        }
                        else
                        {
                            tmpFuncField.Params.Add(new Sql.TableField(tmpField, f_Table, null));
                        }

                        tmpFuncField.GenerateType();
                        tmpFieldList.Add(tmpFuncField);
                    }
                    else
                    {
                        tmpFieldList.Add(new Sql.TableField(tmpField, f_Table, null));
                    }
                }
                else
                {
                    if (!tmpDic.ContainsKey(tmpDataSheet))
                    {
                        var tmpNewTable = new Sql.Table(tmpDataSheet, null);
                        tmpDic.Add(tmpDataSheet, tmpNewTable);
                        f_Tables.Add(tmpNewTable);
                    }
                    if (tmpField.Func != FunctionEnum.NONE)
                    {
                        var tmpFuncField = new Sql.FuncField(tmpField.Func.ToString(), DataTypeEnum.None, null, tmpDBType);
                        tmpFuncField.Params.Add(new Sql.TableField(tmpField, f_Table, null));
                        tmpFuncField.GenerateType();
                        tmpFieldList.Add(tmpFuncField);
                    }
                    else
                    {
                        tmpFieldList.Add(new Sql.TableField(tmpField, f_Table, null));
                    }

                }
            }
            return tmpFieldList;
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> ConvertConfigList(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> f_ConfigList, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, int f_ConfigTableCount, out int f_ConfigJoinCountr)
        {
            List<Sql.AbstractSelectField> tmpFieldList = new List<Sql.AbstractSelectField>();
            if (f_ConfigList == null)
            {
                f_ConfigJoinCountr = f_ConfigTableCount;
                return tmpFieldList;
            }
            Dictionary<IBaseDataSheet, Sql.Table> tmpDic = new Dictionary<IBaseDataSheet, Sql.Table>();//填充所有非本表的表
            Dictionary<string, Sql.Table> tmpNewDic = new Dictionary<string, Sql.Table>();
            var tmpKu = GetKu(f_Table.KuName);
            DBTypeEnum tmpDBType;

            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_Table.KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_Table.KuName));
            }   
            int tmpConfigNamedField = 0;
            foreach (var item in f_ConfigList)
            {
                var tmpField = item.DataSheetField;
                var tmpFieldDataSheet = GetDataSheet(tmpField.KuName, tmpField.SheetName);

                if (item.RelationValue != null)
                {
                    if (!tmpNewDic.ContainsKey(item.RelationValue))
                    {
                        //
                        if (tmpFieldDataSheet != f_Table.Sheet)
                        {
                            string tmpConfigTableName = "#" + f_ConfigTableCount++;

                            //if (tmpDBType == DBTypeEnum.SqlServer)
                            //{
                            //    tmpConfigTableName = "[#" + f_ConfigTableCount++ + "]";
                            //}
                            //else if (tmpDBType == DBTypeEnum.Mysql)
                            //{
                            //    tmpConfigTableName = "`#" + f_ConfigTableCount++ + "`";
                            //}
                            //else
                            //{
                            //    tmpConfigTableName = "\"#" + f_ConfigTableCount++ + "\"";
                            //}

                            var tmpNewTable = new Sql.Table(tmpFieldDataSheet, tmpConfigTableName);
                            //tmpdic不添加
                            var tmpJoinTable = new JoinTable(tmpNewTable);
                            tmpJoinTable.JoinMode = " LEFT JOIN ";
                            bool tmpHasMatched = false;
                            f_Table.JoinTables.Add(tmpJoinTable);

                            if (tmpKu.RelationDic.ContainsKey(f_Table.SourceName))
                            {
                                var tmpRelations = tmpKu.RelationDic[f_Table.SourceName];
                                tmpHasMatched = FillRelationTableKeyIsTable(f_Table, tmpRelations, tmpJoinTable, tmpNewTable, item);
                            }

                            if (!tmpHasMatched)
                            {
                                if (!tmpKu.RelationDic.ContainsKey(tmpFieldDataSheet.SheetName))
                                {
                                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Table.SourceName, tmpFieldDataSheet.SheetName));
                                }
                                var tmpRelations = tmpKu.RelationDic[tmpFieldDataSheet.SheetName];
                                tmpHasMatched = FillRelationTableKeyIsFieldTable(f_Table, tmpRelations, tmpJoinTable, tmpNewTable, item);
                            }

                            if (!tmpHasMatched)
                            {
                                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Table.SourceName, tmpFieldDataSheet.SheetName));
                            }

                            tmpNewDic.Add(item.RelationValue, tmpNewTable);
                        }
                    }
                }
                else
                {
                    if (!tmpDic.ContainsKey(tmpFieldDataSheet) && tmpFieldDataSheet != f_Table.Sheet)
                    {
                        string tmpConfigTableName = "#" + f_ConfigTableCount++;

                        //if (tmpDBType == DBTypeEnum.SqlServer)
                        //{
                        //    tmpConfigTableName = "[#" + f_ConfigTableCount++ + "]";
                        //}
                        //else if (tmpDBType == DBTypeEnum.Mysql)
                        //{
                        //    tmpConfigTableName = "`#" + f_ConfigTableCount++ + "`";
                        //}
                        //else
                        //{
                        //    tmpConfigTableName = "\"#" + f_ConfigTableCount++ + "\"";
                        //}

                        var tmpNewTable = new Sql.Table(tmpFieldDataSheet, tmpConfigTableName);
                        tmpDic.Add(tmpFieldDataSheet, tmpNewTable);
                        var tmpJoinTable = new Sql.JoinTable(tmpNewTable);
                        tmpJoinTable.JoinMode = " LEFT JOIN ";
                        bool tmpHasMatched = false;
                        f_Table.JoinTables.Add(tmpJoinTable);

                        if (tmpKu.RelationDic.ContainsKey(f_Table.SourceName))
                        {
                            //当前table引用其他的表(newtable)
                            var tmpRelations = tmpKu.RelationDic[f_Table.SourceName];
                            tmpHasMatched = FillRelationTableKeyIsTable(f_Table, tmpRelations, tmpJoinTable, tmpNewTable, item);
                        }

                        if (!tmpHasMatched)
                        {
                            if (!tmpKu.RelationDic.ContainsKey(tmpFieldDataSheet.SheetName))
                            {
                                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Table.SourceName, tmpFieldDataSheet.SheetName));
                            }
                            var tmpRelations = tmpKu.RelationDic[tmpFieldDataSheet.SheetName];
                            tmpHasMatched = FillRelationTableKeyIsFieldTable(f_Table, tmpRelations, tmpJoinTable, tmpNewTable, item);
                        }

                        if (!tmpHasMatched)
                        {
                            ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Table.SourceName, tmpFieldDataSheet.SheetName));
                        }
                    }
                    else
                    {
                        if (!tmpDic.ContainsKey(tmpFieldDataSheet))
                        {
                            tmpDic.Add(tmpFieldDataSheet, f_Table);
                        }
                    }
                }

                if (tmpField.Func != FunctionEnum.NONE)
                {
                    string tmpAlias = "#Config_" + tmpConfigNamedField++;
                    var tmpFuncField = new Sql.FuncField(tmpField.Func.ToString(), DataTypeEnum.None, null, tmpDBType);
                    tmpFuncField.Alias = tmpAlias;
                    tmpFieldList.Add(tmpFuncField);
                    if (tmpField.Func == FunctionEnum.COUNT && tmpField.Name == "*")
                    {
                        tmpFuncField.Params.Add(new Sql.AsteriskField());
                    }
                    else if (item.RelationValue != null)
                    {
                        tmpFuncField.Params.Add(new Sql.TableField(tmpField, tmpNewDic[item.RelationValue], null));
                    }
                    else
                    {
                        tmpFuncField.Params.Add(new Sql.TableField(tmpField, tmpDic[tmpFieldDataSheet], null));
                    }

                    tmpFuncField.GenerateType();
                }
                else
                {
                    if (item.RelationValue != null)
                    {
                        tmpFieldList.Add(new Sql.TableField(tmpField, tmpNewDic[item.RelationValue], null));
                    }
                    else
                    {
                        tmpFieldList.Add(new Sql.TableField(tmpField, tmpDic[tmpFieldDataSheet], null));
                    }
                }
            }

            f_ConfigJoinCountr = f_ConfigTableCount;
            return tmpFieldList;
        }

        private static bool FillRelationTableKeyIsTable(byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.SheetRelation> f_Relations, byForm_Server.ku.by.ToolClass.Sql.JoinTable f_JoinTable, byForm_Server.ku.by.ToolClass.Sql.Table f_NewTable, byForm_Server.ku.by.ToolClass.Source f_Item)
        {
            //当前table引用其他的表(newtable)
            if (f_Item.DataSheetField.Name == "*")
            {
                return false;
            }

            DBTypeEnum tmpDBType;

            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_Table.KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_Table.KuName));
            }


            if (f_Item.RelationColumn != null && f_Item.RelationValue != null)
            {
                string[] tmpRelatValueionArray = f_Item.RelationValue.Split('.');
                string[] tmpRelationColumnArray = f_Item.RelationColumn.Split('.');
                string tmpRefSheetName = tmpRelatValueionArray[1];
                string tmpRefFieldName = tmpRelatValueionArray[2];
                string tmpSheetName = tmpRelationColumnArray[1];
                string tmpFieldName = tmpRelationColumnArray[2];

                var tmpMatched = f_Relations.FirstOrDefault(value => value.ReferenceSheet == tmpRefSheetName && value.ReferenceFieldName == tmpRefFieldName && value.ReferencedSheet == tmpSheetName && value.ReferencedFieldName == tmpFieldName);
                if (tmpMatched == null)
                {
                    return false;
                }
                //tmpJoinTable.Condition.Append(" on " + f_Table.Alias == null ? "[" + tmpMatched.ReferenceSheet + "]" : f_Table.Alias + ".[" + tmpMatched.ReferenceFieldName + "] = " + tmpNewTable.Alias + ".[" + tmpMatched.ReferencedFieldName + "]");
                f_JoinTable.Condition.Append(" ON ");

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "[" + tmpMatched.ReferenceSheet + "]" : f_Table.Alias);
                    f_JoinTable.Condition.Append(".[" + tmpMatched.ReferenceFieldName + "] = [" + f_NewTable.Alias + "].[" + tmpMatched.ReferencedFieldName + "]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "`" + tmpMatched.ReferenceSheet + "`" : f_Table.Alias);
                    f_JoinTable.Condition.Append(".`" + tmpMatched.ReferenceFieldName + "` = `" + f_NewTable.Alias + "`.`" + tmpMatched.ReferencedFieldName + "`");
                }
                else
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "\"" + tmpMatched.ReferenceSheet + "\"" : f_Table.Alias);
                    f_JoinTable.Condition.Append(".\"" + tmpMatched.ReferenceFieldName + "\" = \"" + f_NewTable.Alias + "\".\"" + tmpMatched.ReferencedFieldName + "\"");
                }

                return true;
            }
            else
            {
                //主动引用的表在连接被引用的表时需要标明字段
                var tmpMatches = f_Relations.FindAll(value => value.ReferencedSheet == f_Item.DataSheetField.SheetName);
                if (tmpMatches == null || tmpMatches.Count == 0)
                {
                    return false;
                }
                var tmpMatched = tmpMatches[0];
                f_JoinTable.Condition.Append(" on ");

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "[" + tmpMatched.ReferenceSheet + "]" : f_Table.Alias);
                    f_JoinTable.Condition.Append(".[" + tmpMatched.ReferenceFieldName + "] = [" + f_NewTable.Alias + "].[" + tmpMatched.ReferencedFieldName + "]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "`" + tmpMatched.ReferenceSheet + "`" : f_Table.Alias);
                    f_JoinTable.Condition.Append(".`" + tmpMatched.ReferenceFieldName + "` = `" + f_NewTable.Alias + "`.`" + tmpMatched.ReferencedFieldName + "`");
                }
                else
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "\"" + tmpMatched.ReferenceSheet + "\"" : f_Table.Alias);
                    f_JoinTable.Condition.Append(".\"" + tmpMatched.ReferenceFieldName + "\" = \"" + f_NewTable.Alias + "\".\"" + tmpMatched.ReferencedFieldName + "\"");
                }

                return true;
            }
        }

        private static bool FillRelationTableKeyIsFieldTable(byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.SheetRelation> f_Relations, byForm_Server.ku.by.ToolClass.Sql.JoinTable f_JoinTable, byForm_Server.ku.by.ToolClass.Sql.Table f_NewTable, byForm_Server.ku.by.ToolClass.Source f_Item)
        {
            //当前table为被引用的表时
            if (f_Item.DataSheetField.Name == "*")
            {
                return false;
            }

            DBTypeEnum tmpDBType;

            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_Table.KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_Table.KuName));
            }

            if (f_Item.RelationColumn != null && f_Item.RelationValue != null)
            {
                string[] tmpRelatValueionArray = f_Item.RelationValue.Split('.');
                string[] tmpRelationColumnArray = f_Item.RelationColumn.Split('.');
                string tmpRefSheetName = tmpRelatValueionArray[1];
                string tmpRefFieldName = tmpRelatValueionArray[2];
                string tmpSheetName = tmpRelationColumnArray[1];
                string tmpFieldName = tmpRelationColumnArray[2];

                var tmpMatched = f_Relations.FirstOrDefault(value => value.ReferenceSheet == tmpRefSheetName && value.ReferenceFieldName == tmpRefFieldName && value.ReferencedSheet == tmpSheetName && value.ReferencedFieldName == tmpFieldName);
                if (tmpMatched == null)
                {
                    return false;
                }

                if (tmpMatched.ReferencedSheet != f_Table.SourceName)
                {
                    return false;
                }
                //tmpJoinTable.Condition.Append(" on " + f_Table.Alias == null ? "[" + tmpMatched.ReferencedSheet + "]" : f_Table.Alias + ".[" + tmpMatched.ReferencedFieldName + "] = " + tmpNewTable.Alias + ".[" + tmpMatched.ReferenceFieldName + "]");
                f_JoinTable.Condition.Append(" ON ");

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "[" + tmpMatched.ReferencedSheet + "]" : "[" + f_Table.Alias + "]");
                    f_JoinTable.Condition.Append(".[" + tmpMatched.ReferencedFieldName + "] = [" + f_NewTable.Alias + "].[" + tmpMatched.ReferenceFieldName + "]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "`" + tmpMatched.ReferencedSheet + "`" : "`" + f_Table.Alias + "`");
                    f_JoinTable.Condition.Append(".`" + tmpMatched.ReferencedFieldName + "` = `" + f_NewTable.Alias + "`.`" + tmpMatched.ReferenceFieldName + "`");
                }
                else
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "\"" + tmpMatched.ReferencedSheet + "\"" : "\"" + f_Table.Alias + "\"");
                    f_JoinTable.Condition.Append(".\"" + tmpMatched.ReferencedFieldName + "\" = \"" + f_NewTable.Alias + "\".\"" + tmpMatched.ReferenceFieldName + "\"");
                }

                return true;
            }
            else
            {
                var tmpMatcheds = f_Relations.FindAll(value => value.ReferencedSheet == f_Table.SourceName);
                if (tmpMatcheds.Count == 0)
                {
                    return false;
                }
                var tmpMatched = tmpMatcheds[0];
                f_JoinTable.Condition.Append(" ON ");

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "[" + tmpMatched.ReferencedSheet + "]" : "[" + f_Table.Alias + "]");
                    f_JoinTable.Condition.Append(".[" + tmpMatched.ReferencedFieldName + "] = [" + f_NewTable.Alias + "].[" + tmpMatched.ReferenceFieldName + "]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "`" + tmpMatched.ReferencedSheet + "`" : "`" + f_Table.Alias + "`");
                    f_JoinTable.Condition.Append(".`" + tmpMatched.ReferencedFieldName + "` = `" + f_NewTable.Alias + "`.`" + tmpMatched.ReferenceFieldName + "`");
                }
                else
                {
                    f_JoinTable.Condition.Append(f_Table.Alias == null ? "\"" + tmpMatched.ReferencedSheet + "\"" : "\"" + f_Table.Alias + "\"");
                    f_JoinTable.Condition.Append(".\"" + tmpMatched.ReferencedFieldName + "\" = \"" + f_NewTable.Alias + "\".\"" + tmpMatched.ReferenceFieldName + "\"");
                }

                return true;
            }
        }

        public static void AddPlusField(byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_FieldIdentity, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_FieldList, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, string f_ComponentName)
        {
            if (f_FieldIdentity == null)
            {
                //ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.ComponentInSheetHasNotConfigureField, f_Table.Sheet.SheetName, f_ComponentName));
                return;
            }
            var tmpField = f_FieldIdentity.to as Object.field;
            if (tmpField == null)
            {
                return;
            }
            f_FieldList.Add(new Sql.TableField(tmpField.Field, f_Table, null));
        }

        public static void GenerateSelectGroupBy(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_GroupBy, System.Text.StringBuilder f_GroupBySB, System.Text.StringBuilder f_Having, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectFields, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            string[] tmpGroupByName = { "count", "max", "min", "avg", "sum" };
            bool tmpHasGroupByFunc = f_SelectFields.Exists(item => item is Sql.FuncField && tmpGroupByName.Contains(((Sql.FuncField)item).FuncName.ToLower()));

            if (tmpHasGroupByFunc || f_GroupBy.Count != 0)
            {
                foreach (var item in f_SelectFields)
                {
                    if (item is Sql.TableField)
                    {
                        if (!f_GroupBy.Contains(item))
                        {
                            f_GroupBy.Add(item);
                        }
                    }

                    if (item is Sql.IFields)
                    {
                        var tmpField = (Sql.IFields)item;
                        foreach (var field in tmpField.FieldList)
                        {
                            if (!f_GroupBy.Contains(field))
                            {
                                f_GroupBy.Add(field);
                            }
                        }
                    }
                }
            }

            if (f_GroupBy.Count == 0)
            {
                return;
            }

            f_GroupBySB.Append(" GROUP BY ");

            if (f_Having.Length != 0)
            {
                foreach (var item in f_SelectFields)
                {
                    var tmpField = item as Sql.TableField;
                    if (tmpField == null)
                    {
                        continue;
                    }
                    if (f_GroupBy.Contains(tmpField))
                    {
                        continue;
                    }
                    f_GroupBy.Add(tmpField);
                }
            }

            for (int i = 0; i < f_GroupBy.Count; i++)
            {
                var tmpField = f_GroupBy[i];
                if (tmpField.FieldTable == null)
                {
                    ThrowHelper.ThrowUnKnownException(ErrorInfo.FieldWithoutTableSource);
                }

                if (i != 0)
                {
                    f_GroupBySB.Append(", ");
                }
                if (tmpField.FieldTable != null && tmpField.FieldTable.Alias != null)
                {
                    if (f_DBType == DBTypeEnum.SqlServer)
                    {
                        f_GroupBySB.Append(string.Format("[{0}]", tmpField.FieldTable.Alias));
                    }
                    else if (f_DBType == DBTypeEnum.Mysql)
                    {
                        f_GroupBySB.Append(string.Format("`{0}`", tmpField.FieldTable.Alias));
                    }
                    else
                    {
                        f_GroupBySB.Append(string.Format("\"{0}\"", tmpField.FieldTable.Alias));
                    }
                }
                else
                {
                    if (f_DBType == DBTypeEnum.SqlServer)
                    {
                        f_GroupBySB.Append(string.Format("[{0}]", tmpField.FieldTable.GetSource().SheetName));
                    }
                    else if (f_DBType == DBTypeEnum.Mysql)
                    {
                        f_GroupBySB.Append(string.Format("`{0}`", tmpField.FieldTable.GetSource().SheetName));
                    }
                    else
                    {
                        f_GroupBySB.Append(string.Format("\"{0}\"", tmpField.FieldTable.GetSource().SheetName));
                    }
                }

                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    f_GroupBySB.Append(string.Format(".[{0}]", ((Sql.TableField)tmpField).SelectedField.Name));
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    f_GroupBySB.Append(string.Format(".`{0}`", ((Sql.TableField)tmpField).SelectedField.Name));
                }
                else
                {
                    f_GroupBySB.Append(string.Format(".\"{0}\"", ((Sql.TableField)tmpField).SelectedField.Name));
                }
            }
        }

        public static void MergeSelectItem(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_Merged)
        {
            foreach (var item in f_SelectItems)
            {
                if (item is PlusField)
                {
                    var tmpPlusField = item as PlusField;
                    f_Merged.AddRange(tmpPlusField.FieldList);
                }
                else
                {
                    f_Merged.Add(item);
                }
            }
        }

        public static string GenerateSelectItemAndFrom(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables, System.Text.StringBuilder f_From, bool f_HasLimit, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.OrderByField> f_OrderByList, byForm_Server.ku.DBTypeEnum f_DBType, bool f_Lock)
        {
            StringBuilder tmpSelectItemsSB = new StringBuilder();
            //select 后面开始
            //字段
            if (f_HasLimit && f_DBType == DBTypeEnum.SqlServer)
            {
                CheckSqlserverLimitSelectFields(f_SelectItems, f_OrderByList);
            }

            if (f_HasLimit && f_DBType == DBTypeEnum.Oracle)
            {
                CheckOracleLimitSelectFields(f_SelectItems);
            }

            for (int i = 0; i < f_SelectItems.Count; i++)
            {
                if (i != 0)
                {
                    tmpSelectItemsSB.Append(", ");
                }

                var tmpSelectItem = f_SelectItems[i];
                tmpSelectItemsSB.Append(tmpSelectItem.SelectItemDeclare);
            }

            //需要把sqlserver中额外添加的列去掉
            if (f_HasLimit && f_DBType == DBTypeEnum.SqlServer)
            {
                string tmpNewPattern = "#NewOrderBy\\d{1,}";
                f_SelectItems.RemoveAll(item => item.Alias != null && Regex.IsMatch(item.Alias, tmpNewPattern));
            }

            FillFrom(f_Tables, f_From, f_Lock);
            tmpSelectItemsSB.Append(f_From);
            return tmpSelectItemsSB.ToString();
        }

        public static string GenerateSelectItemAndFrom(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables, System.Text.StringBuilder f_From, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            //默认没有limit
            StringBuilder tmpSelectItem = new StringBuilder();

            if (f_DBType == DBTypeEnum.SqlServer)
            {
                for (int i = 0; i < f_SelectItems.Count; i++)
                {
                    var tmpItem = f_SelectItems[i] as AssignmentField;

                    if (tmpSelectItem.Length != 0)
                    {
                        tmpSelectItem.Append(", ");
                    }

                    if (tmpItem == null)
                    {
                        ThrowHelper.ThrowUnKnownException("SELECT变量赋值表达式填充错误");
                    }

                    string tmpVarName = "@" + tmpItem.LocalVariable;
                    tmpSelectItem.Append(tmpVarName);
                    tmpSelectItem.Append(" = ");
                    tmpSelectItem.Append(tmpItem.Field.SelectItemDeclare);
                }
            }

            if (f_DBType == DBTypeEnum.Mysql)
            {
                StringBuilder tmpVarSB = new StringBuilder();
                StringBuilder tmpValueSB = new StringBuilder();

                for (int i = 0; i < f_SelectItems.Count; i++)
                {
                    var tmpItem = f_SelectItems[i] as AssignmentField;

                    if (i != 0)
                    {
                        tmpVarSB.Append(", ");
                        tmpValueSB.Append(", ");
                    }

                    string tmpVarName = "`" + tmpItem.LocalVariable + "`";
                    string tmpValue = tmpItem.Field.SelectItemDeclare;
                    tmpVarSB.Append(tmpVarName);
                    tmpValueSB.Append(tmpValue);
                }

                tmpSelectItem.Append(tmpValueSB.ToString());
                tmpSelectItem.Append(" INTO ");
                tmpSelectItem.Append(tmpVarSB.ToString());
            }

            if (f_DBType == DBTypeEnum.Oracle)
            {
                StringBuilder tmpVarSB = new StringBuilder();
                StringBuilder tmpValueSB = new StringBuilder();

                for (int i = 0; i < f_SelectItems.Count; i++)
                {
                    var tmpItem = f_SelectItems[i] as AssignmentField;

                    if (i != 0)
                    {
                        tmpVarSB.Append(", ");
                        tmpValueSB.Append(", ");
                    }

                    string tmpVarName = "\"" + tmpItem.LocalVariable + "\"";
                    string tmpValue = tmpItem.Field.SelectItemDeclare;
                    tmpVarSB.Append(tmpVarName);
                    tmpValueSB.Append(tmpValue);
                }

                tmpSelectItem.Append(tmpValueSB.ToString());
                tmpSelectItem.Append(" INTO ");
                tmpSelectItem.Append(tmpVarSB.ToString());
            }

            FillFrom(f_Tables, f_From, false);
            tmpSelectItem.Append(f_From);
            return tmpSelectItem.ToString();
        }

        public static string GenerateDeleteFrom(byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Target, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            StringBuilder tmpSB = new StringBuilder("DELETE ");
            //现在f_Tables中只会存在一张表
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                if (f_Target.Alias != null)
                {
                    tmpSB.Append("[" + f_Target.Alias + "] ");
                }
            }

            tmpSB.Append("FROM ");
            tmpSB.Append(TableToCode(f_Target));
            return tmpSB.ToString();
        }

        public static void FillFrom(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tablse, System.Text.StringBuilder f_From, bool f_Lock)
        {
            if (f_Tablse.Count == 0)
            {
                return;
            }

            f_From.Append(" FROM ");
            string tmpKuName = f_Tablse[0].GetIdentity().ku;

            for (int i = 0; i < f_Tablse.Count; i++)
            {
                var tmpTable = f_Tablse[i];

                if (tmpTable.IsOuterTable)
                {
                    continue;
                }

                if (tmpTable.GetSource().IsConst)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.SelectConstSheeet,tmpTable.GetSource().ToString()));
                }

                if (tmpTable.GetIdentity().ku != tmpKuName)
                {
                    HashSet<string> tmpSheetNames = new HashSet<string>();
                    StringBuilder tmpErrorValue = new StringBuilder();

                    for (int j = 0; j < f_Tablse.Count; j++)
                    {
                        var tmpDatatable = f_Tablse[j].GetSource();
                        string tmpSheetName = tmpDatatable.KuName + "." + tmpDatatable.SheetName;
                        
                        if (tmpSheetNames.Contains(tmpSheetName))
                        {
                            continue;
                        }

                        tmpSheetNames.Add(tmpSheetName);

                        if (tmpErrorValue.Length != 0)
                        {
                            tmpErrorValue.Append(", ");
                        }

                        tmpErrorValue.Append(tmpSheetName);
                    }

                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlHasDifferentExecKu + tmpErrorValue.ToString());
                }

                if (i != 0)
                {
                    f_From.Append(", ");
                }

                f_From.Append(TableToCode(tmpTable, tmpKuName, f_Lock));
            }
        }

        public static string TableToCode(byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table)
        {
            StringBuilder tmpValue = new StringBuilder();
            if (f_Table is Sql.Table)
            {
                var tmpTable = f_Table as Sql.Table;
                DBTypeEnum tmpDBType;

                if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpTable.KuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpTable.KuName));
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpValue.Append("[");
                    tmpValue.Append(tmpTable.SourceName);
                    tmpValue.Append("] ");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpValue.Append("`");
                    tmpValue.Append(tmpTable.SourceName);
                    tmpValue.Append("` ");
                }
                else
                {
                    tmpValue.Append("\"");
                    tmpValue.Append(tmpTable.SourceName);
                    tmpValue.Append("\" ");
                }

                if (tmpTable.Alias != null)
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpValue.Append("[");
                        tmpValue.Append(tmpTable.Alias);
                        tmpValue.Append("]");
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpValue.Append("`");
                        tmpValue.Append(tmpTable.Alias);
                        tmpValue.Append("`");
                    }
                    else
                    {
                        tmpValue.Append("\"");
                        tmpValue.Append(tmpTable.Alias);
                        tmpValue.Append("\"");
                    }
                }
            }
            else
            {
                var tmpSelectTable = f_Table as Sql.SelectTable;
                DBTypeEnum tmpDBType;

                if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpSelectTable.DeclarKuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpSelectTable.DeclarKuName));
                }
                tmpValue.Append("( ");
                tmpValue.Append(tmpSelectTable.SqlValue);
                tmpValue.Append(" ) ");

                if (tmpSelectTable.Alias == null)
                {
                    ThrowHelper.ThrowUnKnownException(ErrorInfo.SelectResultAccessWithoutAlias);
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpValue.Append("[");
                    tmpValue.Append(tmpSelectTable.Alias);
                    tmpValue.Append("]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpValue.Append("`");
                    tmpValue.Append(tmpSelectTable.Alias);
                    tmpValue.Append("`");
                }
                else
                {
                    tmpValue.Append("\"");
                    tmpValue.Append(tmpSelectTable.Alias);
                    tmpValue.Append("\"");
                }
            }

            foreach (var item in f_Table.JoinTables)
            {
                tmpValue.Append(item.JoinMode);
                tmpValue.Append(TableToCode(item.JointTable));
                tmpValue.Append(item.Condition);
            }
            return tmpValue.ToString();
        }

        public static string TableToCode(byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table, string f_KuName, bool f_Lock)
        {
            StringBuilder tmpValue = new StringBuilder();

            if (f_Table is Sql.Table)
            {
                var tmpTable = f_Table as Sql.Table;
                DBTypeEnum tmpDBType;

                if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpTable.KuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpTable.KuName));
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpValue.Append("[");
                    tmpValue.Append(tmpTable.SourceName);
                    tmpValue.Append("] ");

                    if (f_Lock)
                    {
                        tmpValue.Append("WITH(UPDLOCK) ");
                    }
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpValue.Append("`");
                    tmpValue.Append(tmpTable.SourceName);
                    tmpValue.Append("` ");
                }
                else
                {
                    tmpValue.Append("\"");
                    tmpValue.Append(tmpTable.SourceName);
                    tmpValue.Append("\" ");
                }

                if (tmpTable.Alias != null)
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpValue.Append("[");
                        tmpValue.Append(tmpTable.Alias);
                        tmpValue.Append("] ");
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpValue.Append("`");
                        tmpValue.Append(tmpTable.Alias);
                        tmpValue.Append("` ");
                    }
                    else
                    {
                        tmpValue.Append("\"");
                        tmpValue.Append(tmpTable.Alias);
                        tmpValue.Append("\" ");
                    }
                }
            }
            else
            {
                var tmpSelectTable = f_Table as Sql.SelectTable;
                tmpValue.Append("( ");
                tmpValue.Append(tmpSelectTable.SqlValue);
                tmpValue.Append(" ) ");
                if (tmpSelectTable.Alias == null)
                {
                    ThrowHelper.ThrowUnKnownException(ErrorInfo.SelectResultAccessWithoutAlias);
                }
                tmpValue.Append(tmpSelectTable.Alias);
            }

            foreach (var item in f_Table.JoinTables)
            {
                tmpValue.Append(item.JoinMode);
                tmpValue.Append(TableToCode(item.JointTable, f_KuName, f_Lock));
                tmpValue.Append(item.Condition);
            }
            return tmpValue.ToString();
        }

        public static byForm_Server.ku.by.ToolClass.Sql.OrderByField GetOrderByFieldWithLimit(string f_Value, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectFields, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables, bool f_IsDesc)
        {
            var tmpArray = f_Value.Split('.');
            var tmpAliasMatchedField = f_SelectFields.Find(item => item.Alias == f_Value);
            List<AbstractSelectField> tmpCompared = new List<AbstractSelectField>();
            if (tmpArray.Length == 1)
            {
                //可能是别名，可能是构件名,可能会有列名不明确的情况
                //全部遍历
                //List<string> tmpComparedNameList = new List<string>();
                foreach (var item in f_Tables)
                {
                    GetTableFieldInTableLength1(f_Value, item, tmpCompared, true);
                    if (tmpCompared.Count > 1)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_Value));
                    }
                }

                if (tmpAliasMatchedField != null && tmpCompared.Count > 0)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.OrderbyUnClearColumn, f_Value));
                }

                if (tmpAliasMatchedField == null && tmpCompared.Count == 0)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.OrderbyUnClearColumn, f_Value));
                }

                if (tmpAliasMatchedField != null)
                {
                    return new OrderByField(f_Value, f_IsDesc, tmpAliasMatchedField);
                }
                else
                {
                    return new OrderByField(null, f_IsDesc, tmpCompared[0]);//需要在后面填充
                }
            }

            if (tmpArray.Length == 2)
            {
                string tmpTableSourceAlais = tmpArray[0];
                string tmpFieldAlias = tmpArray[1];
                var tmpTable = f_Tables.Find(item => item.Alias == tmpTableSourceAlais);
                GetTableFieldInTableLength2(tmpTableSourceAlais, tmpFieldAlias, tmpTable, tmpCompared, true);

                if (tmpAliasMatchedField != null && tmpCompared.Count > 0)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.OrderbyUnClearColumn, f_Value));
                }

                if (tmpAliasMatchedField == null && tmpCompared.Count == 0)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.OrderbyUnClearColumn, f_Value));
                }

                if (tmpCompared.Count > 1)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_Value));
                }

                if (tmpAliasMatchedField != null)
                {
                    ThrowHelper.ThrowUnKnownException("未知的orderby错误");
                    //return new OrderByField(f_Value, f_IsDesc, tmpAliasMatchedField);
                }
                else
                {
                    return new OrderByField(null, f_IsDesc, tmpCompared[0]);
                }
            }

            throw ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.UnClearColumnName, f_Value));
        }

        public static string GetOrderByField(string f_Value, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectFields, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            var tmpArray = f_Value.Split('.');
            if (tmpArray.Length == 1)
            {
                List<string> tmpComaredNameList = new List<string>();
                //可能是别名，可能是字段没加表别名
                var tmpAliasField = f_SelectFields.FirstOrDefault(item => item.Alias == f_Value);
                if (tmpAliasField != null)
                {
                    //先找别名
                    return f_Value;
                }
                //去各个表里找
                foreach (var item in f_Tables)
                {
                    if (item is Sql.SelectTable)
                    {
                        var tmpSelectTable = item as Sql.SelectTable;

                        foreach (var field in tmpSelectTable.ResultItems)
                        {
                            //找a.*
                            if (field.Alias == f_Value)
                            {
                                if (f_DBType == DBTypeEnum.SqlServer)
                                {
                                    tmpComaredNameList.Add("[" + f_Value + "]");
                                }
                                else if (f_DBType == DBTypeEnum.Mysql)
                                {
                                    tmpComaredNameList.Add("`" + f_Value + "`");
                                }
                                else
                                {
                                    tmpComaredNameList.Add("\"" + f_Value + "\"");
                                }

                                continue;
                            }

                            if (field is TableField)
                            {
                                var tmpTableField = field as TableField;
                                var tmpDataSheet = tmpTableField.FieldTable.GetSource();
                                if (tmpDataSheet != null && tmpDataSheet.ComponentDic.ContainsKey(f_Value) && tmpDataSheet.ComponentDic[f_Value].Name == tmpTableField.SelectedField.Name)
                                {
                                    if (f_DBType == DBTypeEnum.SqlServer)
                                    {
                                        tmpComaredNameList.Add("[" + tmpTableField.SelectedField.Name + "]");
                                    }
                                    else if (f_DBType == DBTypeEnum.Mysql)
                                    {
                                        tmpComaredNameList.Add("`" + tmpTableField.SelectedField.Name + "`");
                                    }
                                    else
                                    {
                                        tmpComaredNameList.Add("\"" + tmpTableField.SelectedField.Name + "\"");
                                    }
                                }
                                continue;
                            }

                            if (field is SelectField)
                            {
                                var tmpSelectField = field as SelectField;
                                if (tmpSelectField.name == f_Value)
                                {
                                    if (f_DBType == DBTypeEnum.SqlServer)
                                    {
                                        tmpComaredNameList.Add("[" + f_Value + "]");
                                    }
                                    else if (f_DBType == DBTypeEnum.Mysql)
                                    {
                                        tmpComaredNameList.Add("`" + f_Value + "`");
                                    }
                                    else
                                    {
                                        tmpComaredNameList.Add("\"" + f_Value + "\"");
                                    }
                                }
                                continue;
                            }

                            var tmpAsterField = field as Sql.AsteriskField;
                            if (tmpAsterField == null)
                            {
                                continue;
                            }
                            //构件名
                            var tmpField = FindFieldInAsterFieldReturnNull(f_Value, tmpAsterField, true);
                            if (tmpField != null)
                            {
                                if (f_DBType == DBTypeEnum.SqlServer)
                                {
                                    tmpComaredNameList.Add("[" + f_Value + "]");
                                }
                                else if (f_DBType == DBTypeEnum.Mysql)
                                {
                                    tmpComaredNameList.Add("`" + f_Value + "`");
                                }
                                else
                                {
                                    tmpComaredNameList.Add("\"" + f_Value + "\"");
                                }
                                continue;
                            }
                        }
                    }
                    else
                    {
                        var tmpTable = item as Sql.Table;
                        var tmpDataSheet = tmpTable.Sheet;
                        Field tmpField = null;
                        if (!tmpDataSheet.ComponentDic.TryGetValue(f_Value, out tmpField))
                        {
                            continue;
                        }

                        if (f_DBType == DBTypeEnum.SqlServer)
                        {
                            tmpComaredNameList.Add("[" + f_Value + "]");
                        }
                        else if (f_DBType == DBTypeEnum.Mysql)
                        {
                            tmpComaredNameList.Add("`" + f_Value + "`");
                        }
                        else
                        {
                            tmpComaredNameList.Add("\"" + f_Value + "\"");
                        }

                        continue;
                    }
                }

                if (tmpComaredNameList.Count != 1)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.OrderbyUnClearColumn, f_Value));
                }

                return tmpComaredNameList[0];
            }

            if (tmpArray.Length == 2)
            {
                //别名.别名或者别名.构件
                string tmpTableAlias = tmpArray[0];
                string tmpFieldAlias = tmpArray[1];
                //直接去找表
                var tmpMatchedTable = f_Tables.FirstOrDefault(item => item.Alias == tmpTableAlias);
                if (tmpMatchedTable != null)
                {
                    if (tmpMatchedTable is Sql.SelectTable)
                    {
                        var tmpSelectTable = tmpMatchedTable as Sql.SelectTable;

                        foreach (var item in tmpSelectTable.ResultItems)
                        {
                            if (item.Alias == tmpFieldAlias)
                            {
                                if (f_DBType == DBTypeEnum.SqlServer)
                                {
                                    return "[" + tmpTableAlias + "].[" + tmpFieldAlias + "]";
                                }
                                else if (f_DBType == DBTypeEnum.Mysql)
                                {
                                    return "`" + tmpTableAlias + "`.`" + tmpFieldAlias + "`";
                                }
                                else
                                {
                                    return "\"" + tmpTableAlias + "\".\"" + tmpFieldAlias + "\"";
                                }
                            }

                            if (item is TableField)
                            {
                                var tmpTableField = item as TableField;
                                var tmpDataSheet = tmpTableField.FieldTable.GetSource();
                                if (tmpDataSheet != null && tmpDataSheet.ComponentDic.ContainsKey(tmpFieldAlias) && tmpDataSheet.ComponentDic[tmpFieldAlias].Name == tmpTableField.SelectedField.Name)
                                {
                                    if (f_DBType == DBTypeEnum.SqlServer)
                                    {
                                        return "[" + tmpTableAlias + "].[" + tmpTableField.SelectedField.Name + "]";
                                    }
                                    else if (f_DBType == DBTypeEnum.Mysql)
                                    {
                                        return "`" + tmpTableAlias + "`.`" + tmpTableField.SelectedField.Name + "`";
                                    }
                                    else
                                    {
                                        return "\"" + tmpTableAlias + "\".\"" + tmpTableField.SelectedField.Name + "\"";
                                    }
                                }
                                continue;
                            }

                            if (item is SelectField)
                            {
                                var tmpSelectField = item as SelectField;
                                if (tmpSelectField.name == tmpFieldAlias)
                                {
                                    if (f_DBType == DBTypeEnum.SqlServer)
                                    {
                                        return "[" + tmpTableAlias + "].[" + tmpFieldAlias + "]";
                                    }
                                    else if (f_DBType == DBTypeEnum.Mysql)
                                    {
                                        return "`" + tmpTableAlias + "`.`" + tmpFieldAlias + "`";
                                    }
                                    else
                                    {
                                        return "\"" + tmpTableAlias + "\".\"" + tmpFieldAlias + "\"";
                                    }
                                }
                                continue;
                            }

                            var tmpAsterField = item as Sql.AsteriskField;
                            if (tmpAsterField == null)
                            {
                                continue;
                            }
                            //构件名
                            var tmpField = FindFieldInAsterFieldReturnNull(f_Value, tmpAsterField, true);
                            if (tmpField != null)
                            {
                                if (tmpField.Alias == tmpFieldAlias)
                                {
                                    if (f_DBType == DBTypeEnum.SqlServer)
                                    {
                                        return "[" + tmpTableAlias + "].[" + tmpFieldAlias + "]";
                                    }
                                    else if (f_DBType == DBTypeEnum.Mysql)
                                    {
                                        return "`" + tmpTableAlias + "`.`" + tmpFieldAlias + "`";
                                    }
                                    else
                                    {
                                        return "\"" + tmpTableAlias + "\".\"" + tmpFieldAlias + "\"";
                                    }
                                }
                                var tmpTableField = tmpField as TableField;
                                if (tmpTableField == null)
                                {
                                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.OrderbyUnClearColumn, f_Value));
                                }

                                if (f_DBType == DBTypeEnum.SqlServer)
                                {
                                    return "[" + tmpTableAlias + "].[" + tmpTableField.SelectedField.Name + "]";
                                }
                                else if (f_DBType == DBTypeEnum.Mysql)
                                {
                                    return "`" + tmpTableAlias + "`.`" + tmpTableField.SelectedField.Name + "`";
                                }
                                else
                                {
                                    return "\"" + tmpTableAlias + "\".\"" + tmpTableField.SelectedField.Name + "\"";
                                }
                            }
                        }
                    }
                    else
                    {
                        var tmpTable = tmpMatchedTable as Sql.Table;
                        //只能是构件
                        var tmpDatasheet = tmpTable.Sheet;
                        if (tmpDatasheet.ComponentDic.ContainsKey(tmpFieldAlias))
                        {
                            if (f_DBType == DBTypeEnum.SqlServer)
                            {
                                return "[" + tmpTableAlias + "].[" + tmpDatasheet.ComponentDic[tmpFieldAlias].Name + "]";
                            }
                            else if (f_DBType == DBTypeEnum.Mysql)
                            {
                                return "`" + tmpTableAlias + "`.`" + tmpDatasheet.ComponentDic[tmpFieldAlias].Name + "`";
                            }
                            else
                            {
                                return "\"" + tmpTableAlias + "\".\"" + tmpDatasheet.ComponentDic[tmpFieldAlias].Name + "\"";
                            }
                        }
                    }
                }
            }

            throw ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.OrderbyUnClearColumn, f_Value));
        }

        public static void GenerateOrderBy(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.OrderByField> f_OrderByList, System.Text.StringBuilder f_OrderBy)
        {
            if (f_OrderByList.Count == 0)
            {
                return;
            }

            f_OrderBy.Append(" ORDER BY ");

            for (int i = 0; i < f_OrderByList.Count; i++)
            {
                if (i != 0)
                {
                    f_OrderBy.Append(", ");
                }
                var tmpOrderByField = f_OrderByList[i];
                f_OrderBy.Append(tmpOrderByField.OField);
                if (tmpOrderByField.IsDesc)
                {
                    f_OrderBy.Append(" DESC ");
                }
                else
                {
                    f_OrderBy.Append(" ASC ");
                }
            }
        }

        public static string TableFieldRelationAssignmentRow(byForm_Server.ku.by.ToolClass.Sql.TableField f_TableField, byForm_Server.ku.by.Object.Row f_Row)
        {
            if (f_TableField == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.FieldIsNull);
            }

            if (f_Row == null)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowIsNull);
            }
            //先判断字段和行对应的表是否存在关系
            var tmpField = f_TableField.SelectedField;
            string tmpKuName = tmpField.KuName;

            if (tmpField.KuName != f_Row.KuName)
            {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
            }

            DBTypeEnum tmpDBType;

            if (!Root.GetInstance().KuTypeDic.TryGetValue(tmpKuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, tmpKuName));
            }

            if (tmpField.SheetName == f_Row.SheetName)
            {
                var tmpMatchedCell = f_Row.cells.Find(item => item.ColumnName == tmpField.Name);
                if (tmpMatchedCell == null)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
                }
                //if (tmpMeetConditionCell.Count > 1)
                //{
                //    throw new Exception(String.Format(ErrorInfo.SeveralRelationCells, tmpField.SheetName, f_Row.SheetName, tmpField.Name));
                //}
                var tmpCellValue = tmpMatchedCell.value;
                if (tmpCellValue == null || tmpCellValue is DBNull)
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        return " [" + tmpField.Name + "] = " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        return " `" + tmpField.Name + "` = " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                    }
                    else
                    {
                        return "\"" + tmpField.Name + "\" := " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                    }
                }

                if (tmpCellValue is string || tmpCellValue is char || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
                {
                    string tmpValue = SaveInspect.CharactorEscape(tmpCellValue.ToString());
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        return " [" + tmpField.Name + "] = " + tmpValue;
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        return " `" + tmpField.Name + "` = " + tmpValue;
                    }
                    else
                    {
                        if (tmpCellValue is datetime)
                        {
                            tmpValue = "TO_TIMESTAMP(" + tmpValue + ", 'YYYY-MM-DD HH24:MI:SS.FF')";
                        }

                        return " \"" + tmpField.Name + "\" := " + tmpValue;
                    }
                }

                if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                    || tmpCellValue is decimal)
                {
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        return " [" + tmpField.Name + "] = " + tmpCellValue.ToString();
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        return " `" + tmpField.Name + "` = " + tmpCellValue.ToString();
                    }
                    else
                    {
                        return " \"" + tmpField.Name + "\" := " + tmpCellValue.ToString();
                    }
                }

                if (tmpCellValue is bool)
                {
                    var tmpBoolValue = (bool)tmpCellValue;
                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        return " [" + tmpField.Name + "] = " + (tmpBoolValue ? 1 : 0);
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        return " `" + tmpField.Name + "` = " + (tmpBoolValue ? 1 : 0);
                    }
                    else
                    {
                        return " \"" + tmpField.Name + "\" := " + (tmpBoolValue ? 1 : 0);
                    }
                }

                ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
            }
            else
            {
                //先判断是否存在关系
                var tmpKu = GetKu(tmpField.KuName);
                var tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, tmpField.SheetName, f_Row.SheetName);
                var tmpRelation = tmpRelations[0];

                if (tmpField.SheetName != tmpRelation.ReferencedSheet && tmpField.SheetName != tmpRelation.ReferenceSheet)
                {
                    ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationBetweenSheets, tmpField.SheetName, f_Row.SheetName));
                }

                if (tmpField.SheetName == tmpRelation.ReferencedSheet && f_Row.SheetName == tmpRelation.ReferenceSheet)
                {
                    var tmpMatchedCell = f_Row.cells.Find(cell => cell.ColumnName == tmpRelation.ReferenceSheet);
                    if (tmpMatchedCell == null)
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
                    }

                    var tmpCellValue = tmpMatchedCell.value;
                    if (tmpCellValue == null || tmpCellValue is DBNull)
                    {
                        if (tmpDBType == DBTypeEnum.SqlServer)
                        {
                            return " [" + tmpField.Name + "] = " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                        }
                        else if (tmpDBType == DBTypeEnum.Mysql)
                        {
                            return " `" + tmpField.Name + "` = " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                        }
                        else
                        {
                            return " \"" + tmpField.Name + "\" := " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                        }
                    }

                    if (tmpCellValue is string || tmpCellValue is char || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
                    {
                        string tmpValue = SaveInspect.CharactorEscape(tmpCellValue.ToString());
                        if (tmpDBType == DBTypeEnum.SqlServer)
                        {
                            return " [" + tmpField.Name + "] = " + tmpValue;
                        }
                        else if (tmpDBType == DBTypeEnum.Mysql)
                        {
                            return " `" + tmpField.Name + "` = " + tmpValue;
                        }
                        else
                        {
                            if (tmpCellValue is datetime)
                            {
                                tmpValue = "TO_TIMESTAMP(" + tmpValue + ", 'YYYY-MM-DD HH24:MI:SS.FF')";
                            }

                            return " \"" + tmpField.Name + "\" := " + tmpValue;
                        }
                    }

                    if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                        || tmpCellValue is decimal)
                    {
                        if (tmpDBType == DBTypeEnum.SqlServer)
                        {
                            return " [" + tmpField.Name + "] = " + tmpCellValue.ToString();
                        }
                        else if (tmpDBType == DBTypeEnum.Mysql)
                        {
                            return " `" + tmpField.Name + "` = " + tmpCellValue.ToString();
                        }
                        else
                        {
                            return " \"" + tmpField.Name + "\" := " + tmpCellValue.ToString();
                        }
                    }

                    if (tmpCellValue is bool)
                    {
                        var tmpBoolValue = (bool)tmpCellValue;
                        if (tmpDBType == DBTypeEnum.SqlServer)
                        {
                            return " [" + tmpField.Name + "] = " + (tmpBoolValue ? 1 : 0);
                        }
                        else if (tmpDBType == DBTypeEnum.Mysql)
                        {
                            return " `" + tmpField.Name + "` = " + (tmpBoolValue ? 1 : 0);
                        }
                        else
                        {
                            return " \"" + tmpField.Name + "\" := " + (tmpBoolValue ? 1 : 0);
                        }
                    }

                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                }

                if (tmpField.SheetName == tmpRelation.ReferenceSheet && f_Row.SheetName == tmpRelation.ReferencedSheet)
                {
                    if (tmpField.Name != tmpRelation.ReferenceFieldName)
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.TableNotReferenceField, tmpField.Name, tmpRelation.ReferenceSheet));
                    }

                    if (tmpField.Name != tmpRelation.ReferenceFieldName)
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.TableNotReferenceField, tmpField.Name, tmpRelation.ReferenceSheet));
                    }

                    var tmpMatchedCell = f_Row.cells.Find(cell => cell.ColumnName == tmpRelation.ReferencedSheet);
                    if (tmpMatchedCell == null)
                    {
                        ThrowHelper.ThrowRelationOperationException(string.Format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.SheetName));
                    }
                    //if (tmpMatchedCell.Count > 1)
                    //{
                    //    throw new Exception(String.Format(ErrorInfo.SeveralRelationCells, tmpField.SheetName, f_Row.SheetName, tmpField.Name));
                    //}

                    var tmpCellValue = tmpMatchedCell.value;
                    if (tmpCellValue == null || tmpCellValue is DBNull)
                    {
                        if (tmpDBType == DBTypeEnum.SqlServer)
                        {
                            return " [" + tmpField.Name + "] = " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                        }
                        else if (tmpDBType == DBTypeEnum.Mysql)
                        {
                            return " `" + tmpField.Name + "` = " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                        }
                        else
                        {
                            return " \"" + tmpField.Name + "\" := " + CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, tmpDBType);
                        }
                    }

                    if (tmpCellValue is string || tmpCellValue is char || tmpCellValue is Object.datetime || tmpCellValue.GetType().IsEnum)
                    {
                        string tmpValue = SaveInspect.CharactorEscape(tmpCellValue.ToString());
                        if (tmpDBType == DBTypeEnum.SqlServer)
                        {
                            return " [" + tmpField.Name + "] = " + tmpValue;
                        }
                        else if (tmpDBType == DBTypeEnum.Mysql)
                        {
                            return " `" + tmpField.Name + "` = " + tmpValue;
                        }
                        else
                        {
                            if (tmpCellValue is datetime)
                            {
                                tmpValue = "TO_TIMESTAMP(" + tmpValue + ", 'YYYY-MM-DD HH24:MI:SS.FF')";
                            }

                            return " \"" + tmpField.Name + "\" := " + tmpValue;
                        }
                    }

                    if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double
                        || tmpCellValue is decimal)
                    {
                        if (tmpDBType == DBTypeEnum.SqlServer)
                        {
                            return " [" + tmpField.Name + "] = " + tmpCellValue.ToString();
                        }
                        else if (tmpDBType == DBTypeEnum.Mysql)
                        {
                            return " `" + tmpField.Name + "` = " + tmpCellValue.ToString();
                        }
                        else
                        {
                            return " \"" + tmpField.Name + "\" := " + tmpCellValue.ToString();
                        }
                    }

                    if (tmpCellValue is bool)
                    {
                        var tmpBoolValue = (bool)tmpCellValue;
                        if (tmpDBType == DBTypeEnum.SqlServer)
                        {
                            return " [" + tmpField.Name + "] = " + (tmpBoolValue ? 1 : 0);
                        }
                        else if (tmpDBType == DBTypeEnum.Mysql)
                        {
                            return " `" + tmpField.Name + "` = " + (tmpBoolValue ? 1 : 0);
                        }
                        else
                        {
                            return " \"" + tmpField.Name + "\" := " + (tmpBoolValue ? 1 : 0);
                        }
                    }

                    ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                }
            }
            throw ThrowHelper.ThrowRelationOperationException(ErrorInfo.NoRelationBetweenSheetsOrReferenceColumn); 
        }

        public static void GetUpdateConfig(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> f_FieldList, byForm_Server.ku.by.Object.Row f_Row, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Text.StringBuilder f_Set, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> f_SetFields, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            string tmpKuName = f_Table.KuName;
            string tmpShetName = f_Table.SourceName;
            if (f_Row.KuName != tmpKuName)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
            }
            if (f_Row.SheetName != tmpShetName)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
            }

            StringBuilder tmpSet = new StringBuilder();

            for (int i = 0; i < f_FieldList.Count; i++)
            {
                var tmpFieldSource = f_FieldList[i];

                if (f_SetFields.Contains(tmpFieldSource.DataSheetField))
                {
                    continue;
                }

                f_SetFields.Add(tmpFieldSource.DataSheetField);

                if (tmpSet.Length != 0)
                {
                    tmpSet.Append(", ");
                }

                if (tmpFieldSource.DataSheetField.KuName != tmpKuName)
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
                }
                if (tmpFieldSource.DataSheetField.SheetName != tmpShetName)
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
                }
                var tmpMatchedCells = f_Row.cells.FindAll(item => item.KuName == tmpKuName && item.SheetName == tmpShetName && item.ColumnName == tmpFieldSource.DataSheetField.Name);
                if (tmpMatchedCells.Count == 0)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, tmpFieldSource.DataSheetField.Name));
                }
                if (tmpMatchedCells.Count > 1)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, tmpFieldSource.DataSheetField.Name));
                }

                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpSet.Append("[" + tmpFieldSource.DataSheetField.Name + "] = ");
                }
                else if (f_DBType == DBTypeEnum.Mysql)
                {
                    tmpSet.Append("`" + tmpFieldSource.DataSheetField.Name + "` = ");
                }
                else
                {
                    tmpSet.Append("\"" + tmpFieldSource.DataSheetField.Name + "\" = ");
                }

                var tmpValue = tmpMatchedCells[0].value;

                if (tmpValue == null || tmpValue is DBNull)
                {
                    tmpSet.Append(CellValueNullToDefaultReturnString(tmpFieldSource.DataSheetField.FieldType, tmpFieldSource.DataSheetField.EnumType, f_DBType));
                    continue;
                }

                if (tmpValue is char || tmpValue is string || tmpValue is Object.datetime || tmpValue.GetType().IsEnum)
                {
                    if (tmpValue is datetime && f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpSet.Append("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                    }
                    else
                    {
                        tmpSet.Append(SaveInspect.CharactorEscape(tmpValue.ToString()));
                    }

                    continue;
                }

                if (tmpValue is sbyte || tmpValue is short || tmpValue is int || tmpValue is long || tmpValue is float || tmpValue is double
                    || tmpValue is decimal)
                {
                    tmpSet.Append(tmpValue.ToString());
                    continue;
                }

                if (tmpValue is bool)
                {
                    var tmpBoolValue = (bool)tmpValue;
                    tmpSet.Append(tmpBoolValue ? 1 : 0);
                    continue;
                }

                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
            }

            if (f_Set.Length != 5 && tmpSet.Length != 0)
            {
                f_Set.Append(", ");
            }

            f_Set.Append(tmpSet);
        }

        public static void GetInsertConfig(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> f_FieldList, byForm_Server.ku.by.Object.Row f_Row, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Field, object> f_InsertValues, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            string tmpKuName = f_Table.KuName;
            string tmpShetName = f_Table.SourceName;

            if (f_Row.KuName != tmpKuName)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
            }

            if (f_Row.SheetName != tmpShetName)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
            }

            for (int i = 0; i < f_FieldList.Count; i++)
            {
                var tmpField = f_FieldList[i].DataSheetField;
                if (tmpField.KuName != tmpKuName)
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
                }
                if (tmpField.SheetName != tmpShetName)
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
                }

                if (f_InsertValues.ContainsKey(tmpField))
                {
                    continue;
                    //ThrowHelper.ThrowSqlPreCompileException(string.Format("insert语句重复插入的列 {0}", tmpField.SheetName + "." + tmpField.Name));
                }

                var tmpMatchedCells = f_Row.cells.FindAll(item => item.KuName == tmpKuName && item.SheetName == tmpShetName && item.ColumnName == tmpField.Name);

                if (tmpMatchedCells.Count == 0)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, tmpField.Name));
                }

                if (tmpMatchedCells.Count > 1)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.InsertFieldConflict, tmpField.Name));
                }
                object tmpCellValue = null;
                tmpCellValue = tmpMatchedCells[0].value;
                //if (tmpMatchedCells.Count != 0)
                //{
                //    tmpCellValue = tmpMatchedCells[0].value;
                //}
                if (tmpCellValue == null || tmpCellValue is DBNull)
                {
                    f_InsertValues.Add(tmpField, CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                }
                else if (tmpCellValue is Object.datetime || tmpCellValue is char || tmpCellValue is string || tmpCellValue.GetType().IsEnum)
                {
                    if (f_DBType == DBTypeEnum.Oracle && tmpCellValue is datetime)
                    {
                        f_InsertValues.Add(tmpField, "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                    }
                    else
                    {
                        f_InsertValues.Add(tmpField, SaveInspect.CharactorEscape(tmpCellValue.ToString()));
                    }
                }
                else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double || tmpCellValue is decimal)
                {
                    f_InsertValues.Add(tmpField, tmpCellValue.ToString());
                }
                else if (tmpCellValue is bool)
                {
                    var tmpBool = (bool)tmpCellValue;
                    f_InsertValues.Add(tmpField, tmpBool ? 1 : 0);
                }
                else
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);//未知类型
                }
                //if (f_InsertValues.ContainsKey(tmpField))
                //{
                //    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.InsertFieldConflict, tmpField.Name));
                //}
                //f_InsertValues.Add(tmpField, tmpMatchedCells[0].value);
            }
        }

        public static void GetInsertConfig(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Source> f_FieldList, System.Collections.Generic.ICollection<byForm_Server.ku.by.Object.Row> f_Rows, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Field, object> f_InsertValues, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            string tmpKuName = f_Table.KuName;
            string tmpSheetName = f_Table.SourceName;

            for (int i = 0; i < f_FieldList.Count; i++)
            {
                var tmpField = f_FieldList[i].DataSheetField;
                if (tmpField.KuName != tmpKuName || tmpField.SheetName != tmpSheetName)
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
                }

                if (f_InsertValues.ContainsKey(tmpField))
                {
                    continue;
                    //ThrowHelper.ThrowSqlPreCompileException(string.Format("insert语句重复插入的列 {0}", tmpField.SheetName + "." + tmpField.Name));
                }

                foreach (var row in f_Rows)
                {
                    if (row.KuName != tmpKuName || row.SheetName != tmpSheetName)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                    }

                    var tmpMatchedCells = row.cells.FindAll(item => item.KuName == tmpKuName && item.SheetName == tmpSheetName && item.ColumnName == tmpField.Name);
                    object tmpCellValue = null;

                    if (tmpMatchedCells.Count == 0)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, tmpField.Name));
                    }
                    if (tmpMatchedCells.Count > 1)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.RowHasRepetitiveField, tmpField.Name));
                    }

                    tmpCellValue = tmpMatchedCells[0].value;                    

                    if (!f_InsertValues.ContainsKey(tmpField))
                    {
                        f_InsertValues.Add(tmpField, new List<object>());
                    }
                    var tmpValue = f_InsertValues[tmpField] as List<object>;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.DifferentParameterOfInsert);
                    }

                    if (tmpCellValue == null || tmpCellValue is DBNull)
                    {
                        tmpValue.Add(CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                    }
                    else if (tmpCellValue is Object.datetime || tmpCellValue is char || tmpCellValue is string || tmpCellValue.GetType().IsEnum)
                    {
                        if (tmpCellValue is datetime && f_DBType == DBTypeEnum.Oracle)
                        {
                            tmpValue.Add("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                        }
                        else
                        {
                            tmpValue.Add(SaveInspect.CharactorEscape(tmpCellValue.ToString()));
                        }
                    }
                    else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double || tmpCellValue is decimal)
                    {
                        tmpValue.Add(tmpCellValue.ToString());
                    }
                    else if (tmpCellValue is bool)
                    {
                        var tmpBool = (bool)tmpCellValue;
                        tmpValue.Add(tmpBool? 1 : 0);
                    }
                    else
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);//未知类型
                    }
                }
            }
        }

        public static void GetInsertComponentInRow(string f_Component, byForm_Server.ku.by.Object.Row f_Row, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Field, object> f_InsertValues, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            string tmpKuName = f_Table.KuName;
            string tmpSheetName = f_Table.SourceName;
            if (f_Row.KuName != tmpKuName)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
            }
            if (f_Row.SheetName != tmpSheetName)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
            }
            var tmpDataSheet = f_Table.Sheet;
            Field tmpField = null;
            if (!tmpDataSheet.ComponentDic.TryGetValue(f_Component, out tmpField))
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.SheetName, f_Component));
            }
            if (f_InsertValues.ContainsKey(tmpField))
            {
                //说明已经填过
                return;
            }
            var tmpMatchedCells = f_Row.cells.FindAll(item => item.KuName == tmpKuName && item.SheetName == tmpSheetName && item.ColumnName == tmpField.Name);
            if (tmpMatchedCells.Count == 0)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, tmpField.Name));
            }

            if (tmpMatchedCells.Count > 1)
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.RowHasRepetitiveField, tmpField.Name));
            }

            object tmpCellValue = null;
            tmpCellValue = tmpMatchedCells[0].value;
            //if (tmpMatchedCells.Count != 0)
            //{
            //    tmpCellValue = tmpMatchedCells[0].value;
            //}

            if (tmpCellValue == null || tmpCellValue is DBNull)
            {
                f_InsertValues.Add(tmpField, CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
            }
            else if (tmpCellValue is Object.datetime || tmpCellValue is char || tmpCellValue is string || tmpCellValue.GetType().IsEnum)
            {
                if (f_DBType == DBTypeEnum.Oracle && tmpCellValue is datetime)
                {
                    f_InsertValues.Add(tmpField, "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                }
                else
                {
                    f_InsertValues.Add(tmpField, SaveInspect.CharactorEscape(tmpCellValue.ToString()));
                }
            }
            else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double || tmpCellValue is decimal)
            {
                f_InsertValues.Add(tmpField, tmpCellValue.ToString());
            }
            else if (tmpCellValue is bool)
            {
                var tmpBool = (bool)tmpCellValue;
                f_InsertValues.Add(tmpField, tmpBool ? 1 : 0);
            }
            else
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);//未知类型
            }
        }

        public static void GetInsertComponentInRows(string f_Component, System.Collections.Generic.ICollection<byForm_Server.ku.by.Object.Row> f_Rows, byForm_Server.ku.by.ToolClass.Sql.Table f_Table, System.Collections.Generic.Dictionary<byForm_Server.ku.by.ToolClass.Field, object> f_InsertValues, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            string tmpKuName = f_Table.KuName;
            string tmpSheetName = f_Table.SourceName;
            var tmpDataSheet = f_Table.Sheet;
            Field tmpField = null;
            if (!tmpDataSheet.ComponentDic.TryGetValue(f_Component, out tmpField))
            {
                ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.SheetName, f_Component));
            }
            if (f_InsertValues.ContainsKey(tmpField))
            {
                //说明已经填过
                return;
            }
            foreach (var row in f_Rows)
            {
                if (row.KuName != tmpKuName || row.SheetName != tmpSheetName)
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }
                var tmpMatchedCells = row.cells.FindAll(item => item.KuName == tmpKuName && item.SheetName == tmpSheetName && item.ColumnName == tmpField.Name);

                if (tmpMatchedCells.Count == 0)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.CanNotFindCellInRow, tmpField.Name));
                }

                if (tmpMatchedCells.Count > 1)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.RowHasRepetitiveField, tmpField.Name));
                }

                object tmpCellValue = null;
                tmpCellValue = tmpMatchedCells[0].value;

                if (tmpMatchedCells.Count != 0)
                //{
                //    tmpCellValue = tmpMatchedCells[0].value;
                //}

                if (!f_InsertValues.ContainsKey(tmpField))
                {
                    f_InsertValues.Add(tmpField, new List<object>());
                }
                var tmpValue = f_InsertValues[tmpField] as List<object>;
                if (tmpValue == null)
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.DifferentParameterOfInsert);
                }

                if (tmpCellValue == null || tmpCellValue is DBNull)
                {
                    tmpValue.Add(CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                }
                else if (tmpCellValue is Object.datetime || tmpCellValue is char || tmpCellValue is string || tmpCellValue.GetType().IsEnum)
                {
                    if (tmpCellValue is datetime && f_DBType == DBTypeEnum.Oracle)
                    {
                        tmpValue.Add("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.ToString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                    }
                    else
                    {
                        tmpValue.Add(SaveInspect.CharactorEscape(tmpCellValue.ToString()));
                    }
                }
                else if (tmpCellValue is sbyte || tmpCellValue is short || tmpCellValue is int || tmpCellValue is long || tmpCellValue is float || tmpCellValue is double || tmpCellValue is decimal)
                {
                    tmpValue.Add(tmpCellValue.ToString());
                }
                else if (tmpCellValue is bool)
                {
                    var tmpBoolValue = (bool)tmpCellValue;
                    tmpValue.Add(tmpBoolValue ? 1 : 0);
                }
                else
                {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);//未知类型
                }
            }
        }

        public static System.Text.StringBuilder GetLimit(System.Text.StringBuilder f_Sql, string f_StartIndex, string f_Offsets, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.OrderByField> f_OrderList, byForm_Server.ku.DBTypeEnum f_DBType)
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                string tmpStartIndexValue = f_StartIndex + " + 1";
                string tmpEndIndexValue = f_StartIndex + " + " + f_Offsets;
                StringBuilder tmpNewSql = new StringBuilder("SELECT * ");
                tmpNewSql.Append(" FROM (");
                tmpNewSql.Append("SELECT *, ROW_NUMBER()OVER(");
                tmpNewSql.Append("ORDER BY ");

                if (f_OrderList.Count == 0)
                {
                    tmpNewSql.Append("GETDATE()) [#RowNum]");
                }
                else
                {
                    for (int i = 0; i < f_OrderList.Count; i++)
                    {
                        if (i != 0)
                        {
                            tmpNewSql.Append(", ");
                        }

                        tmpNewSql.Append(f_OrderList[i].OField);
                        if (f_OrderList[i].IsDesc)
                        {
                            tmpNewSql.Append(" DESC");
                        }
                        else
                        {
                            tmpNewSql.Append(" ASC");
                        }
                    }

                    tmpNewSql.Append(") [#RowNum]");
                }

                tmpNewSql.Append(" FROM (");
                tmpNewSql.Append(f_Sql);
                tmpNewSql.Append(") ");
                tmpNewSql.Append("[#NewTable])");
                tmpNewSql.Append("[#NewTable1]");
                tmpNewSql.Append(string.Format(" where [#NewTable1].[#RowNum] BETWEEN {0} and {1}", tmpStartIndexValue, tmpEndIndexValue));
                return tmpNewSql;
            }
            else if (f_DBType == DBTypeEnum.Mysql)
            {
                StringBuilder tmpNewSql = new StringBuilder();
                tmpNewSql.Append(f_Sql);
                tmpNewSql.Append(" LIMIT ");
                tmpNewSql.Append(f_StartIndex);
                tmpNewSql.Append(", ");
                tmpNewSql.Append(f_Offsets);
                tmpNewSql.Append("; ");
                return tmpNewSql;
            }
            else
            {
                StringBuilder tmpInnerSelect = new StringBuilder("SELECT \"#NewTable\".*, ROWNUM \"#RowNum\" FROM ( ");
                tmpInnerSelect.Append(f_Sql);
                tmpInnerSelect.Append(") \"#NewTable\" WHERE ROWNUM < 1 + ");
                tmpInnerSelect.Append(f_StartIndex);
                tmpInnerSelect.Append(" + ");
                tmpInnerSelect.Append(f_Offsets);
                StringBuilder tmpReturnValue = new StringBuilder("SELECT * FROM ( ");
                tmpReturnValue.Append(tmpInnerSelect);
                tmpReturnValue.Append(" ) WHERE \"#RowNum\" > ");
                tmpReturnValue.Append(f_StartIndex);
                //tmpReturnValue.Append(";");
                return tmpReturnValue;
            }
        }

        public static void CheckSqlserverLimitSelectFields(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.OrderByField> f_OrderByList)
        {
            //需要确保在最后时刻调用
            //无别名的查询列名和某个别名冲突会报错
            List<string> tmpNames = new List<string>();
            List<string> tmpAliasList = new List<string>();

            foreach (var item in f_SelectItems)
            {
                //先检查带别名的
                if (item.Alias == null)
                {
                    continue;
                }

                //不改只加,理论上只用给没加别名的重复字段和表达式加
                string tmpAlias = item.Alias.ToLower();
                if (tmpNames.Contains(item.Alias))
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.ConflictFields, item.Alias));
                }
                tmpNames.Add(tmpAlias);
                tmpAliasList.Add(tmpAlias);
            }

            foreach (var item in f_SelectItems)
            {
                if (item.Alias != null)
                {
                    continue;
                }

                if (item is Sql.AsteriskField)
                {
                    continue;
                }

                if (item is Sql.TableField)
                {
                    var tmpTableField = item as Sql.TableField;
                    string tmpName = tmpTableField.SelectedField.Name;
                    if (tmpAliasList.Contains(tmpName))
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.ConflictFields, tmpName));
                    }
                }

                if (item is Sql.SelectField)
                {
                    var tmpSelectField = item as Sql.SelectField;
                    string tmpName = tmpSelectField.name;
                    if (tmpAliasList.Contains(tmpName))
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.ConflictFields, tmpName));
                    }
                }

                string tmpNewName = "#TmpName" + tmpNames.Count;//不会有重名

                if (item is TableField)
                {
                    var tmpTableField = item as TableField;
                    tmpTableField.SetAlias(tmpNewName);
                }
                else
                {
                    item.Alias = tmpNewName;
                }

                tmpNames.Add(tmpNewName);
            }

            List<OrderByField> tmpOrderByList = new List<OrderByField>();//替换成一个新的
            //给所有没加别名的需要orderby的列加带别名的查询列
            for (int i = 0; i < f_OrderByList.Count; i++)
            {
                string tmpOrderByValue = f_OrderByList[i].OField;
                bool tmpIsDesc = f_OrderByList[i].IsDesc;
                var tmpField = f_OrderByList[i].SourceField;

                if (tmpOrderByValue == null)
                {
                    //说明需要新添加查询列
                    f_SelectItems.Add(tmpField);
                    tmpField.Alias = "#NewOrderBy" + i;
                    tmpOrderByValue = "[#NewTable]." + tmpField.Alias;
                }
                else
                {
                    tmpOrderByValue = "[#NewTable]." + tmpOrderByValue;
                }
                tmpOrderByList.Add(new OrderByField(tmpOrderByValue, tmpIsDesc));
            }

            f_OrderByList.Clear();
            f_OrderByList.AddRange(tmpOrderByList);
        }

        private static void CheckOracleLimitSelectFields(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems)
        {
            //无别名的查询列名和某个别名冲突会报错
            List<string> tmpNames = new List<string>();
            List<string> tmpAliasList = new List<string>();

            foreach (var item in f_SelectItems)
            {
                //先检查带别名的
                if (item.Alias == null)
                {
                    continue;
                }

                //不改只加,理论上只用给没加别名的重复字段和表达式加
                string tmpAlias = item.Alias.ToLower();
                if (tmpNames.Contains(item.Alias))
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.ConflictFields, item.Alias));
                }
                tmpNames.Add(tmpAlias);
                tmpAliasList.Add(tmpAlias);
            }

            foreach (var item in f_SelectItems)
            {
                if (item.Alias != null)
                {
                    continue;
                }

                if (item is Sql.AsteriskField)
                {
                    continue;
                }

                if (item is Sql.TableField)
                {
                    var tmpTableField = item as Sql.TableField;
                    string tmpName = tmpTableField.SelectedField.Name;
                    if (tmpAliasList.Contains(tmpName))
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.ConflictFields, tmpName));
                    }
                }

                if (item is Sql.SelectField)
                {
                    var tmpSelectField = item as Sql.SelectField;
                    string tmpName = tmpSelectField.name;
                    if (tmpAliasList.Contains(tmpName))
                    {
                        ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.ConflictFields, tmpName));
                    }
                }

                string tmpNewName = "#TmpName" + tmpNames.Count;//不会有重名

                if (item is TableField)
                {
                    var tmpTableField = item as TableField;
                    tmpTableField.SetAlias(tmpNewName);
                }
                else
                {
                    item.Alias = tmpNewName;
                }

                tmpNames.Add(tmpNewName);
            }
        }

        public static string GetAllSheetNameInTables(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables)
        {
            List<string> tmpNames = new List<string>();

            foreach (var item in f_Tables)
            {
                GetSheetNamesInTable(item, tmpNames);
            }

            StringBuilder tmpValue = new StringBuilder();
            for (int i = 0; i < tmpNames.Count; i++)
            {
                if (i != 0)
                {
                    tmpValue.Append(", ");
                }

                tmpValue.Append(tmpNames[i]);
            }

            return tmpValue.ToString();
        }

        public static void GetSheetNamesInTable(byForm_Server.ku.by.ToolClass.Sql.AbstractTable f_Table, System.Collections.Generic.List<string> f_Names)
        {
            if (f_Table is Table)
            {
                var tmpTable = f_Table as Table;
                string tmpQualifiedName = tmpTable.KuName + "." + tmpTable.SourceName;
                if (!f_Names.Contains(tmpQualifiedName))
                {
                    f_Names.Add(tmpQualifiedName);
                }
            }

            foreach (var item in f_Table.JoinTables)
            {
                var tmpAbstractTable = item.JointTable;
                GetSheetNamesInTable(tmpAbstractTable, f_Names);
            }
        }

        public static byForm_Server.ku.by.Identity.Table GetIdentityOfRow(byForm_Server.ku.by.Object.Row f_Row)
        {
            if (f_Row == null)
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowDmlRowIsNull);
            }

            return (Identity.Table)f_Row.Identity;
        }

        public static string ValueInCollection(string f_Value, System.Collections.IList f_List)
        {
            StringBuilder tmpValue = new StringBuilder();
            tmpValue.Append(f_Value);
            tmpValue.Append(" in (");
            int tmpIndex = 0;
            foreach (var item in f_List)
            {
                if (tmpIndex != 0)
                {
                    tmpValue.Append(", ");
                }
                var tmpObjType = item.GetType();
                string tmpElement = item.ToString();
                if (tmpObjType == typeof(string) || tmpObjType == typeof(char) || tmpObjType == typeof(ku.by.Object.datetime))
                {
                    tmpValue.Append(SaveInspect.CharactorEscape(tmpElement));
                }
                else
                {
                    tmpValue.Append(tmpElement);
                }
                tmpIndex++;
            }
            tmpValue.Append(")");
            return tmpValue.ToString();
        }

        public static bool DoubleTypeIsIdentity(object f_Value, System.Type f_IdentityType)
        {
            var tmpType = f_Value.GetType();
            //双类型
            var tmpProps = tmpType.GetProperties();
            foreach (var item in tmpProps)
            {
                if (item.Name == "Identity")
                {
                    var tmpPropInstance = item.GetValue(f_Value);
                    if (tmpPropInstance == null)
                    {
                        return false;
                    }
                    if (tmpPropInstance.GetType() == f_IdentityType)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public static bool DoubleTypeIs(object f_LHS, System.Type f_ObjectType, System.Type f_IdentityType)
        {
            if (f_LHS == null)
            {
                return false;
            }

            var tmpLType = f_LHS.GetType();
            var tmpLIdentityProp = tmpLType.GetProperty("Identity");

            if (tmpLIdentityProp == null)
            {
                return false;
            }

            var tmpLIdentityInstance = tmpLIdentityProp.GetValue(f_LHS);

            if (tmpLIdentityInstance == null)
            {
                return false;
            }

            var tmpLActualIdentityType = tmpLIdentityInstance.GetType();
            bool tmpObjectIs = false;
            bool tmpIdentityIs = true;

            if (tmpLType == f_ObjectType || tmpLType.IsSubclassOf(f_ObjectType))
            {
                tmpObjectIs = true;
            }

            if (tmpLActualIdentityType == f_IdentityType || tmpLActualIdentityType.IsSubclassOf(f_IdentityType))
            {
                tmpIdentityIs = true;
            }

            if (tmpObjectIs && tmpIdentityIs)
            {
                return true;
            }

            return false;
        }

        public static T AsJudge<T>(object f_Value) where T : byForm_Server.ku.by.ToolClass.AbstractIdentityBase
        {
            if (f_Value== null)
            {
                return null;
            }

            var tmpOjType = f_Value.GetType();
            var tmpProps = tmpOjType.GetProperties();
            foreach (var item in tmpProps)
            {
                if (item.Name == "Identity")
                {
                    var tmpPropInstance = item.GetValue(f_Value);
                    return tmpPropInstance as T;
                }
            }

            return null;
        }

        public static T CastTo<T>(object f_Value) where T : byForm_Server.ku.by.ToolClass.AbstractIdentityBase
        {
            if (f_Value == null)
            {
                return null;
            }

            var tmpObjType = f_Value.GetType();
            var tmpProps = tmpObjType.GetProperties();
            foreach (var item in tmpProps)
            {
                if (item.Name == "Identity")
                {
                    var tmpPropInstance = item.GetValue(f_Value);
                    return (T)tmpPropInstance;
                }
            }

            return null;
        }

        public static string ExecuteRowFlow(string f_FlowName, byForm_Server.ku.by.Identity.Table f_Identity, byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            var tmpDataSheet = f_Identity.to as IBaseDataSheet;

            if(tmpDataSheet == null)
            {
                throw ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.FlowIdentityError, f_Identity.ku, f_Identity.GetType().Name));
            }

            if (!tmpDataSheet.RowFlowDic.ContainsKey(f_FlowName))
            {
                throw ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.KuName + "." + tmpDataSheet.SheetName, f_FlowName));
            }

            return tmpDataSheet.RowFlowDic[f_FlowName].Invoke(f_CurrentRow, f_RelationRow);
        }

        public static string ExecuteRowsFlow(string f_FlowName, byForm_Server.ku.by.Identity.Table f_Identity, System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            var tmpDataSheet = f_Identity.to as IBaseDataSheet;
            if (tmpDataSheet == null)
            {
                throw ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.FlowIdentityError, f_Identity.ku, f_Identity.GetType().Name));
            }

            if (!tmpDataSheet.RowsFlowDic.ContainsKey(f_FlowName))
            {
                throw ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.KuName + "." + tmpDataSheet.SheetName, f_FlowName));
            }

            return tmpDataSheet.RowsFlowDic[f_FlowName].Invoke(f_CurrentRow, f_RelationRow);
        }

        public static string ExecuteRowFlowInTran(string f_FlowName, byForm_Server.ku.by.Identity.Table f_Identity, string f_EffectCount, byForm_Server.ku.by.Object.Row f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            var tmpDataSheet = f_Identity.to as IBaseDataSheet;

            if (tmpDataSheet == null)
            {
                throw ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.FlowIdentityError, f_Identity.ku, f_Identity.GetType().Name));
            }

            if (!tmpDataSheet.RowFlowInTranDic.ContainsKey(f_FlowName))
            {
                throw ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.KuName + "." + tmpDataSheet.SheetName, f_FlowName));
            }

            return tmpDataSheet.RowFlowInTranDic[f_FlowName].Invoke(f_EffectCount, f_CurrentRow, f_RelationRow);
        }

        public static string ExecuteRowsFlowInTran(string f_FlowName, byForm_Server.ku.by.Identity.Table f_Identity, string f_EffectCount, System.Collections.Generic.IList<byForm_Server.ku.by.Object.Row> f_CurrentRow, params byForm_Server.ku.by.Object.Row[] f_RelationRow)
        {
            var tmpDataSheet = f_Identity.to as IBaseDataSheet;

            if (tmpDataSheet == null)
            {
                throw ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.FlowIdentityError, f_Identity.ku, f_Identity.GetType().Name));
            }

            if (!tmpDataSheet.RowsFlowInTranDic.ContainsKey(f_FlowName))
            {
                throw ThrowHelper.ThrowDataMatchException(string.Format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.KuName + "." + tmpDataSheet.SheetName, f_FlowName));
            }

            return tmpDataSheet.RowsFlowInTranDic[f_FlowName].Invoke(f_EffectCount, f_CurrentRow, f_RelationRow);
        }

        public static object PreAdd(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);

            if (tmpCell.value is char)
            {
                char tmpValue = (char)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue + 1;
            }

            if (tmpCell.value is sbyte)
            {
                sbyte tmpValue = (sbyte)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue + 1;
            }

            if (tmpCell.value is short)
            {
                short tmpValue = (short)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue + 1;
            }

            if (tmpCell.value is int)
            {
                int tmpValue = (int)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue + 1;
            }

            if (tmpCell.value is long)
            {
                long tmpValue = (long)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue + 1;
            }

            if (tmpCell.value is float)
            {
                float tmpValue = (float)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue + 1;
            }

            if (tmpCell.value is double)
            {
                double tmpValue = (double)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue + 1;
            }

            if (tmpCell.value is decimal)
            {
                decimal tmpValue = (decimal)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue + 1;
            }

            throw new Exception("++" + ErrorInfo.PostOrPreExpressionOnly);
        }

        public static object PreSub(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);

            if (tmpCell.value is char)
            {
                char tmpValue = (char)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue - 1;
            }

            if (tmpCell.value is sbyte)
            {
                sbyte tmpValue = (sbyte)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue - 1;
            }

            if (tmpCell.value is short)
            {
                short tmpValue = (short)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue - 1;
            }

            if (tmpCell.value is int)
            {
                int tmpValue = (int)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue - 1;
            }

            if (tmpCell.value is long)
            {
                long tmpValue = (long)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue - 1;
            }

            if (tmpCell.value is float)
            {
                float tmpValue = (float)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue - 1;
            }

            if (tmpCell.value is double)
            {
                double tmpValue = (double)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue - 1;
            }

            if (tmpCell.value is decimal)
            {
                decimal tmpValue = (decimal)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue - 1;
            }

            throw new Exception("--" + ErrorInfo.PostOrPreExpressionOnly);
        }

        public static object PostAdd(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);

            if (tmpCell.value is char)
            {
                char tmpValue = (char)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue;
            }

            if (tmpCell.value is sbyte)
            {
                sbyte tmpValue = (sbyte)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue;
            }

            if (tmpCell.value is short)
            {
                short tmpValue = (short)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue;
            }

            if (tmpCell.value is int)
            {
                int tmpValue = (int)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue;
            }

            if (tmpCell.value is long)
            {
                long tmpValue = (long)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue;
            }

            if (tmpCell.value is float)
            {
                float tmpValue = (float)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue;
            }

            if (tmpCell.value is double)
            {
                double tmpValue = (double)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue;
            }

            if (tmpCell.value is decimal)
            {
                decimal tmpValue = (decimal)tmpCell.value;
                tmpCell.value = tmpValue + 1;
                return tmpValue;
            }

            throw new Exception("++" + ErrorInfo.PostOrPreExpressionOnly);
        }

        public static object PostSub(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);

            if (tmpCell.value is char)
            {
                char tmpValue = (char)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue;
            }

            if (tmpCell.value is sbyte)
            {
                sbyte tmpValue = (sbyte)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue;
            }

            if (tmpCell.value is short)
            {
                short tmpValue = (short)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue;
            }

            if (tmpCell.value is int)
            {
                int tmpValue = (int)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue;
            }

            if (tmpCell.value is long)
            {
                long tmpValue = (long)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue;
            }

            if (tmpCell.value is float)
            {
                float tmpValue = (float)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue;
            }

            if (tmpCell.value is double)
            {
                double tmpValue = (double)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue;
            }

            if (tmpCell.value is decimal)
            {
                decimal tmpValue = (decimal)tmpCell.value;
                tmpCell.value = tmpValue - 1;
                return tmpValue;
            }

            throw new Exception("--" + ErrorInfo.PostOrPreExpressionOnly);
        }

        public static string CompoundAssignmentReturnString(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName, object f_RValue, string f_Operator)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);
            var tmpCallValue = tmpCell.value.ToString();

            if (f_Operator == "+")
            {
                var tmpNewCellValue = tmpCallValue += f_RValue;
                tmpCell.value = tmpNewCellValue;
                return tmpNewCellValue;
            }
            else
            {
                RowComponentSimpleAssignment(tmpCell, f_RValue);
                return f_RValue.ToString();
            }
        }

        public static System.SByte CompoundAssignmentReturnSbyte(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName, System.SByte f_RValue, string f_Operator)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);
            var tmpCellValue = Convert.ToSByte(tmpCell.value);

            if (f_Operator == "+")
            {
                sbyte tmpNewValue = tmpCellValue += f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "-")
            {
                sbyte tmpNewValue = tmpCellValue -= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "*")
            {
                sbyte tmpNewValue = tmpCellValue *= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "/")
            {
                sbyte tmpNewValue = tmpCellValue /= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "%")
            {
                sbyte tmpNewValue = tmpCellValue %= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "&")
            {
                sbyte tmpNewValue = tmpCellValue &= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "|")
            {
                sbyte tmpNewValue = tmpCellValue |= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "^")
            {
                sbyte tmpNewValue = tmpCellValue ^= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == ">>")
            {
                sbyte tmpNewValue = tmpCellValue >>= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "<<")
            {
                sbyte tmpNewValue = tmpCellValue <<= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else
            {
                RowComponentSimpleAssignment(tmpCell, f_RValue);
                return f_RValue;
            }
        }

        public static System.Int16 CompoundAssignmentReturnShort(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName, System.Int16 f_RValue, string f_Operator)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);
            var tmpCellValue = Convert.ToInt16(tmpCell.value);

            if (f_Operator == "+")
            {
                short tmpNewValue = tmpCellValue += f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "-")
            {
                short tmpNewValue = tmpCellValue -= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "*")
            {
                short tmpNewValue = tmpCellValue *= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator== "/")
            {
                short tmpNewValue = tmpCellValue /= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "%")
            {
                short tmpNewValue = tmpCellValue %= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "&")
            {
                short tmpNewValue = tmpCellValue &= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "|")
            {
                short tmpNewValue = tmpCellValue |= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "^")
            {
                short tmpNewValue = tmpCellValue ^= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == ">>")
            {
                short tmpNewValue = tmpCellValue >>= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "<<")
            {
                short tmpNewValue = tmpCellValue <<= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else
            {
                RowComponentSimpleAssignment(tmpCell, f_RValue);
                return f_RValue;
            }
        }

        public static System.Int32 CompoundAssignmentReturnInt(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName, System.Int32 f_RValue, string f_Operator)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);
            var tmpCellValue = Convert.ToInt32(tmpCell.value);

            if (f_Operator == "+")
            {
                int tmpNewValue = tmpCellValue += f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "-")
            {
                int tmpNewValue = tmpCellValue -= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "*")
            {
                int tmpNewValue = tmpCellValue *= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "/")
            {
                int tmpNewValue = tmpCellValue /= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "%")
            {
                int tmpNewValue = tmpCellValue %= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "&")
            {
                int tmpNewValue = tmpCellValue &= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "|")
            {
                int tmpNewValue = tmpCellValue |= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "^")
            {
                int tmpNewValue = tmpCellValue ^= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == ">>")
            {
                int tmpNewValue = tmpCellValue >>= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "<<")
            {
                int tmpNewValue = tmpCellValue <<= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else
            {
                RowComponentSimpleAssignment(tmpCell, f_RValue);
                return f_RValue;
            }
        }

        public static System.Int64 CompoundAssignmentReturnLong(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName, System.Int64 f_RValue, string f_Operator)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);
            var tmpCellValue = Convert.ToInt64(tmpCell.value);

            if (f_Operator == "+")
            {
                long tmpNewValue = tmpCellValue += f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "-")
            {
                long tmpNewValue = tmpCellValue -= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "*")
            {
                long tmpNewValue = tmpCellValue *= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "/")
            {
                long tmpNewValue = tmpCellValue /= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "%")
            {
                long tmpNewValue = tmpCellValue %= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "&")
            {
                long tmpNewValue = tmpCellValue &= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "|")
            {
                long tmpNewValue = tmpCellValue |= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "^")
            {
                long tmpNewValue = tmpCellValue ^= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == ">>")
            {
                int tmpIntRvalue;

                if (!int.TryParse(f_RValue.ToString(), out tmpIntRvalue))
                {
                    throw new Exception(string.Format(ErrorInfo.ShiftAssignCanNotApplyLong, ">>="));
                }

                long tmpNewValue = tmpCellValue >>= tmpIntRvalue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "<<")
            {
                int tmpIntRvalue;

                if (!int.TryParse(f_RValue.ToString(), out tmpIntRvalue))
                {
                    throw new Exception(string.Format(ErrorInfo.ShiftAssignCanNotApplyLong, "<<="));
                }

                long tmpNewValue = tmpCellValue <<= tmpIntRvalue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else
            {
                RowComponentSimpleAssignment(tmpCell, f_RValue);
                return f_RValue;
            }
        }

        public static System.Single CompoundAssignmentReturnFloat(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName, System.Single f_RValue, string f_Operator)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);
            var tmpCellValue = Convert.ToSingle(tmpCell.value);

            if (f_Operator == "+")
            {
                float tmpNewValue = tmpCellValue += f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "-")
            {
                float tmpNewValue = tmpCellValue -= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "*")
            {
                float tmpNewValue = tmpCellValue *= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "/")
            {
                float tmpNewValue = tmpCellValue /= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "%")
            {
                float tmpNewValue = tmpCellValue %= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else
            {
                RowComponentSimpleAssignment(tmpCell, f_RValue);
                return f_RValue;
            }
        }

        public static System.Double CompoundAssignmentReturnDouble(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName, System.Double f_RValue, string f_Operator)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);
            var tmpCellValue = Convert.ToDouble(tmpCell.value);

            if (f_Operator == "+")
            {
                double tmpNewValue = tmpCellValue += f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "-")
            {
                double tmpNewValue = tmpCellValue -= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "*")
            {
                double tmpNewValue = tmpCellValue *= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "/")
            {
                double tmpNewValue = tmpCellValue /= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "%")
            {
                double tmpNewValue = tmpCellValue %= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else
            {
                RowComponentSimpleAssignment(tmpCell, f_RValue);
                return f_RValue;
            }
        }

        public static System.Decimal CompoundAssignmentReturnDecimal(byForm_Server.ku.by.Object.Row f_Row, string f_ComponentName, System.Decimal f_RValue, string f_Operator)
        {
            var tmpCell = GetRowComponent(f_Row, f_ComponentName);
            var tmpCellValue = Convert.ToDecimal(tmpCell.value);

            if (f_Operator == "+")
            {
                decimal tmpNewValue = tmpCellValue += f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "-")
            {
                decimal tmpNewValue = tmpCellValue -= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "*")
            {
                decimal tmpNewValue = tmpCellValue *= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "/")
            {
                decimal tmpNewValue = tmpCellValue /= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else if (f_Operator == "%")
            {
                decimal tmpNewValue = tmpCellValue %= f_RValue;
                tmpCell.value = tmpNewValue;
                return tmpNewValue;
            }
            else
            {
                RowComponentSimpleAssignment(tmpCell, f_RValue);
                return f_RValue;
            }
        }
    }
}
