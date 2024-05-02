package $Ku.by.ToolClass;

import $Ku.by.ToolClass.ThrowHelper;
import $Ku.by.JsonUtils.*;
import $Ku.by.ToolClass.Sql.SqlHelper;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import $Ku.by.Object.*;
import java.util.Date;
public class Response {
    public static final java.lang.String SqlSelect = "SELECT";
    public static final java.lang.String SqlInsert = "INSERT";
    public static final java.lang.String SqlUpdate = "UPDATE";
    public static final java.lang.String SqlDelete = "DELETE";
    public static final java.lang.String SqlSelectLimit = "WITH T";
    public static final java.lang.Class<?> charType;
    public static final java.lang.Class<?> byteByte;
    public static final java.lang.Class<?> shortType;
    public static final java.lang.Class<?> intType;
    public static final java.lang.Class<?> longType;
    public static final java.lang.Class<?> floatType;
    public static final java.lang.Class<?> doubleType;
    public static final java.lang.Class<?> decimalType;
    public static final java.lang.Class<?> boolType;
    public static final java.lang.Class<?> stringType;
    public static final java.lang.Class<?> dateTimeType;

    static {
        charType = Character.class;
        byteByte = Byte.class;
        shortType = Short.class;
        intType = Integer.class;
        longType = Long.class;
        floatType = Float.class;
        doubleType = Double.class;
        decimalType = $Ku.by.Object.Decimal.class;
        boolType = Boolean.class;
        stringType = String.class;
        dateTimeType = $Ku.by.Object.Datetime.class;
    }


    public static java.lang.String ActionResponse($Ku.by.Object.Result f_Result) {
        String tmpResultMessage = null;
        if (f_Result.isOk) {
            f_Result.info = null;
            tmpResultMessage = SqlInvocation.SqlResult;
        }
        SqlInvocation.SqlResult = null;

        JsonObject tmpResultObj = new JsonObject();
        tmpResultObj.Add("isOk", new JsonBool(f_Result.isOk));

        if (f_Result.info == null) {
            tmpResultObj.Add("info", new JsonNull());
        } else {
            tmpResultObj.Add("info", new JsonString(f_Result.info));
        }
        return tmpResultObj.toString();
    }

    public static java.lang.String SqlExpressionResponse(java.lang.String f_Path, $Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpClassPath = f_Path.substring(0, f_Path.lastIndexOf('.'));
        Class<?> tmpType;
        try {
            tmpType = Class.forName(tmpClassPath);
        } catch (ClassNotFoundException e) {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ReflectTypeOrMethodError, tmpClassPath));
        }
        String[] tmpPathSpliter = f_Path.split("\\.");
        if (tmpType == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ReflectTypeOrMethodError, tmpClassPath));
        }

        Object tmpInvokeResult = null;
        String tmpSqlCommand = null;
        String tmpResult = null;
        Class<$Ku.by.ToolClass.Sql.ParamsPackage> tmpParamsPackageType = $Ku.by.ToolClass.Sql.ParamsPackage.class;
        Method tmpMethod;
        try {
            tmpMethod = tmpType.getMethod(tmpPathSpliter[tmpPathSpliter.length - 1], tmpParamsPackageType);
        } catch (NoSuchMethodException e) {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ReflectTypeOrMethodError, tmpPathSpliter[tmpPathSpliter.length - 1]));
        }
        if (tmpMethod == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ReflectTypeOrMethodError, tmpPathSpliter[tmpPathSpliter.length - 1]));
        }
        try {
            tmpInvokeResult = tmpMethod.invoke(null, f_Parameter);
        } catch (IllegalAccessException | InvocationTargetException e) {
            if (e.getCause() != null) {
                throw new RuntimeException(e.getCause());
            }
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnknownErrorInReflection, e);
        }

        if (tmpInvokeResult instanceof $Ku.by.ToolClass.Sql.SelectTable) {
            $Ku.by.ToolClass.Sql.SelectTable tmpSelectTable = ($Ku.by.ToolClass.Sql.SelectTable) tmpInvokeResult;
            tmpSqlCommand = tmpSelectTable.getSqlValue();
        } else {
            if(tmpInvokeResult instanceof String[]){
                String[] strings = (String[]) tmpInvokeResult;
                StringBuilder sb = new StringBuilder();
                for(String str : strings){
                    sb.append(str + "\r\n");
                }
                tmpSqlCommand = sb.toString();
            }
            else{
                tmpSqlCommand = (String) tmpInvokeResult;
            }
        }
        String tmpSqlType = tmpSqlCommand.substring(0, 6).toUpperCase();
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        if (tmpSqlType.equals(SqlSelect) || tmpSqlType.equals(SqlSelectLimit)) {
            $Ku.by.ToolClass.Sql.SelectTable tmpSelectTable = ($Ku.by.ToolClass.Sql.SelectTable) tmpInvokeResult;
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpRows = SqlHelper.SelectReturnRows(tmpSqlCommand, tmpKuName);
            for ($Ku.by.Object.Row selectRow : tmpRows) {
                for (int i = 0; i < tmpSelectTable.ResultItemsWithoutAsterisk.size(); i++) {
                    $Ku.by.Object.Cell tmpCell = selectRow.cells.get(i);
                    $Ku.by.ToolClass.Sql.AbstractSelectField tmpField = tmpSelectTable.ResultItemsWithoutAsterisk.get(i);
                    tmpCell.MatchField(tmpField);
                    tmpCell.checkValue();
                }
                selectRow.cells = new java.util.ArrayList<>(selectRow.cells.subList(0, tmpSelectTable.ResultItemsWithoutAsterisk.size()));
            }
            IJsonValue tmpMap;
            IJsonValue tmpTablesMap;
            JsonArray tmpFields = new JsonArray();
            JsonArray tmpValues = new JsonArray();
            if(tmpRows.size() > 0){
                if(tmpSelectTable.ormType == null){
                    tmpMap = new JsonNull();
                    tmpTablesMap = new JsonNull();
                }
                else{
                    try {
                        Class<?> tmpOrmType = tmpSelectTable.ormType;
                        AbstractOrm tmpOrm = (AbstractOrm) tmpOrmType.getConstructor($Ku.by.ToolClass.Sql.SelectTable.class, $Ku.by.Object.Row.class).newInstance(tmpSelectTable, tmpRows.get(0));
                        JsonObject tmpFieldsMap = new JsonObject();
                        for(OrmField item : tmpOrm.getOrmFields()){
                            tmpFieldsMap.Add(item.name, new JsonNumber(item.index.toString()));
                        }
                        tmpMap = tmpFieldsMap;

                        JsonObject tmpOrmTablesMap = new JsonObject();
                        tmpOrm.getTablesMap().forEach((key, value) -> {
                            JsonArray tmpTableValues = new JsonArray();
                            for(Integer num : value){
                                tmpTableValues.Add(new JsonNumber(num.toString()));
                            }
                            tmpOrmTablesMap.Add(key, tmpTableValues);
                        });

                        tmpTablesMap = tmpOrmTablesMap;
                    }catch (java.lang.Exception e){
                        tmpMap = new JsonNull();
                        tmpTablesMap = new JsonNull();
                    }
                }
                for(int i = 0; i < tmpRows.get(0).cells.size(); i++){
                    $Ku.by.Object.Cell tmpCell = tmpRows.get(0).cells.get(i);
                    tmpFields.Add(Parse.cellToJson(tmpCell));
                }
                for(int i = 0; i < tmpRows.size(); i++){
                    $Ku.by.Object.Row tmpRow = tmpRows.get(i);
                    JsonArray tmpValue = new JsonArray();
                    for(int j = 0; j < tmpRow.cells.size(); j++){
                        $Ku.by.Object.Cell tmpCell = tmpRow.cells.get(j);
                        Object tmpCellValue = tmpCell.value;

                        if (tmpCellValue == null) {
                            tmpValue.Add(new JsonNull());
                            continue;
                        }

                        if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer
                                || tmpCellValue instanceof Float || tmpCellValue instanceof Double) {
                            tmpValue.Add(new JsonNumber(tmpCellValue.toString()));
                            continue;
                        }

                        if (tmpCellValue instanceof Boolean) {
                            tmpValue.Add(new JsonBool(Boolean.parseBoolean(tmpCellValue.toString())));
                            continue;
                        }

                        if (tmpCellValue instanceof String || tmpCellValue instanceof Character || tmpCellValue instanceof $Ku.by.Object.Decimal
                                || tmpCellValue instanceof Long || tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue instanceof java.time.LocalDateTime) {
                            tmpValue.Add(new JsonString(tmpCellValue.toString()));
                            continue;
                        }

                        if (tmpCellValue instanceof Date) {
                            throw new IllegalArgumentException("存在未转换的Datetime类型");
                        }

                        if (tmpCellValue.getClass().isEnum()) {
                            tmpValue.Add(new JsonString(tmpCellValue.toString()));
                            continue;
                        }

                        throw new IllegalArgumentException("CellValueTypeError");
                    }
                    tmpValues.Add(tmpValue);
                }
            }
            else{
                tmpMap = new JsonNull();
                tmpTablesMap = new JsonNull();
            }
            JsonObject tmpJsResult = new JsonObject();
            tmpJsResult.Add("#", new JsonString("SQLSELECT"));
            tmpJsResult.Add("$TABLESMAP", tmpTablesMap);
            tmpJsResult.Add("$FIELDSMAP", tmpMap);
            tmpJsResult.Add("$FIELDS", tmpFields);
            tmpJsResult.Add("$VALUES", tmpValues);

            tmpResult = tmpJsResult.toString();
        }

        if (tmpSqlType.equals(SqlInsert) || tmpSqlType.equals(SqlUpdate) || tmpSqlType.equals(SqlDelete) || tmpSqlType.equals("DECLAR")) {
            tmpResult = String.valueOf(SqlHelper.ExecuteNonQuery(tmpSqlCommand, tmpKuName));
        }

        if (tmpResult == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.SqlUnknownError);
        }

        return tmpResult;
    }

    public static java.lang.String FindKu(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList) {
        if (f_TableList == null || f_TableList.isEmpty()) {
            return "by";
        }

        for ($Ku.by.ToolClass.Sql.AbstractTable item : f_TableList) {
            if (item instanceof $Ku.by.ToolClass.Sql.SqlTable) {
                $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable) item;
                return tmpTable.getKuName();
            }

            if (item instanceof $Ku.by.ToolClass.Sql.SelectTable) {
                $Ku.by.ToolClass.Sql.SelectTable tmpSelectTable = ($Ku.by.ToolClass.Sql.SelectTable) item;
                String tmpKuName = FindKu(tmpSelectTable.getTableSources());
                if (tmpKuName.equals("by")) {
                    continue;
                }
                return tmpKuName;
            }
        }

        return "by";
    }

    public static java.lang.String TranResponse(java.lang.String f_Path, $Ku.by.ToolClass.Sql.TranParamsPackage f_Parameters) {
        String tmpClassPath = f_Path.substring(0, f_Path.lastIndexOf('.'));
        Class<?> tmpType;
        try {
            tmpType = Class.forName(tmpClassPath);
        } catch (ClassNotFoundException e) {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ReflectTypeOrMethodError, tmpClassPath));
        }
        String[] tmpPathSpliter = f_Path.split("\\.");
        Method tmpMethod;
        try {
            tmpMethod = tmpType.getMethod(tmpPathSpliter[tmpPathSpliter.length - 1], $Ku.by.ToolClass.Sql.TranParamsPackage.class);
        } catch (NoSuchMethodException e) {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ReflectTypeOrMethodError, tmpPathSpliter[tmpPathSpliter.length - 1]));
        }
        String[] tmpInvokeResult;
        try {
            tmpInvokeResult = (String[]) tmpMethod.invoke(null, f_Parameters);
        } catch (IllegalAccessException | InvocationTargetException e) {
            if (e.getCause() != null) {
                throw new RuntimeException(e.getCause());
            }
            throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnknownErrorInReflection, e);
        }
        int tmpResult = SqlHelper.ExecuteNonQuery(tmpInvokeResult, $Ku.by.ToolClass.ToolFunction.GetKuInSql(f_Parameters));
        return String.format("%d", tmpResult);
    }

    public static java.lang.String SkillOrActionResponse($Ku.by.ToolClass.Parse f_Parse, java.lang.reflect.Method f_Method, Object f_Target, Object[] f_Arguments) {
        if (f_Method.getReturnType().getName().equals("void")) {
            try {
                f_Method.invoke(f_Target, f_Arguments);
            }catch (java.lang.Exception e){
                throw new RuntimeException(e.getCause());
            }
            return "null";
        } else {
            Object tmpResult;
            try {
                tmpResult = f_Method.invoke(f_Target, f_Arguments);
            } catch (IllegalAccessException | InvocationTargetException e) {
                if (e.getCause() != null) {
                    throw new RuntimeException(e.getCause());
                }
                throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnknownErrorInReflection, e);
            }

            if (tmpResult == null) {
                return null;
            }

            if (tmpResult.getClass().isArray()) {

                JsonObject tmpArrayJson = f_Parse.arrayToJson(tmpResult.getClass().getComponentType(), tmpResult);
                return tmpArrayJson.toString();
            }

            Class<?> tmpResultType = tmpResult.getClass();

            if (tmpResultType == charType || tmpResultType == stringType || tmpResultType == longType || tmpResultType == decimalType || tmpResultType == dateTimeType)
            {
                return "\"" + tmpResult.toString() + "\"";
            }
            
            if (tmpResultType == byteByte || tmpResultType == shortType || tmpResultType == intType || tmpResultType == floatType || tmpResultType == doubleType || tmpResultType == boolType)
            {
                return tmpResult.toString();
            }
            if(tmpResultType == $Ku.by.Object.List.class){
                JsonObject tmpObjJson = f_Parse.listToJson( (($Ku.by.Object.List)tmpResult).$t.clazz , tmpResult);
                return tmpObjJson.toString();
            }
            if(tmpResultType == $Ku.by.Object.Dictionary.class){
                JsonObject tmpObjJson = f_Parse.dicToJson( (($Ku.by.Object.Dictionary)tmpResult).$k.clazz ,(($Ku.by.Object.Dictionary)tmpResult).$v.clazz , tmpResult);
                return tmpObjJson.toString();
            }
            JsonObject tmpObjJson = f_Parse.objToJson(tmpResult);
            return tmpObjJson.toString();
        }
    }
}
