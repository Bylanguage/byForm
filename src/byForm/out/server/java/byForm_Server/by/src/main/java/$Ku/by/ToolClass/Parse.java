package $Ku.by.ToolClass;

import java.lang.reflect.*;
import java.util.*;
import java.util.regex.*;
import java.util.stream.Collectors;
import static $Ku.by.ToolClass.ThrowHelper.*;
import $Ku.by.ToolClass.Exceptions.*;
import $Ku.by.Identity.Server;
import $Ku.by.Object.*;
import $Ku.by.JsonUtils.*;
public class Parse {
    public java.lang.Boolean ComeInHasError = false;
    private java.lang.String url;
    private $Ku.by.Object.ServerSession serverSession = null;
    public java.lang.String RootNameSpace;
    public java.lang.String ResponseValue;
    public java.lang.String SqlLocation;
    public $Ku.by.ToolClass.RequestTypeEnum ResponseType = $Ku.by.ToolClass.RequestTypeEnum.values()[0];
    private final java.lang.String MessageSessionID = "$SESSIONID";
    public final java.lang.String MessageUserDefined = "USERDEFINED";
    public final java.lang.String MessageTable = "$TABLE";
    public final java.lang.String MessageJoin = "JOIN";
    public final java.lang.String MessageTableSql = "$SQL";
    public final java.lang.String MessageDollarTableSql = "$SQL";
    public final java.lang.String MessageDollarVA = "$VA";
    public final java.lang.String MessageNo = "$NO";
    public final java.lang.String MessageFrom = "$FR";
    public final java.lang.String MessageParameters = "$PA";
    public final java.lang.String MessageID = "$ID";
    public final java.lang.String MessageRef = "$REF";
    public final java.lang.String MessageInstance = "$INSTANCE";
    public final java.lang.String MessageInner = "$INNER";
    public final java.lang.String MessageValue = "$VALUE";
    public final java.lang.String MessageParameterObjType = "#";
    public final java.lang.String MessageType = "$TYPE";
    public static java.lang.String MessageTarget = "$TARGET";
    public final java.lang.String MessageArray = "ARRAY";
    public final java.lang.String MessageList = "LIST";
    public final java.lang.String MessageArrayValue = "$VALUES";
    public final java.lang.String MessageIdentity = "IDENTITY";
    public final java.lang.String MessageDollarIdentity = "$IDENTITY";
    public final java.lang.String MessageDollarIdentitys = "$IDENTITYS";
    public final java.lang.String MessageQuery = "QUERY";
    public final java.lang.String MessageRow = "ROW";
    public final java.lang.String MessageSheetName = "$SH";
    public final java.lang.String MessageRefresh = "$Refresh";
    public final java.lang.String MessageSS = "$SS";
    public final java.lang.String MessageAction = "ACTION";
    public final java.lang.String MessageSourceName = "$SO";
    public final java.lang.String MessageParamsList = "$PS";
    public final java.lang.String MessageKu = "$KU";
    public final java.lang.String MessageFields = "$FIELDS";
    public final java.lang.String MessageValues = "$VALUES";
    public final java.lang.String MessageCookie = "$COOKIE";
    public final java.lang.String MessageRequest = "$REQUEST";
    public final java.lang.String MessageDictionary = "DICTIONARY";
    public final java.lang.String MessageKey = "$KEYS";
    public final java.lang.String MessageDicValue = "$VALUES";
    public final java.lang.String MessageValueArray = "$VA";
    public final java.lang.String MessageOrm = "ORM";
    public final java.lang.String MessageFieldsMap = "$FIELDSMAP";
    public final java.lang.String MessageTablesMap = "$TABLESMAP";
    public final java.lang.String MessageExec = "EXEC";
    public final java.lang.String MessageSaasId = "$SAASID";
    public final java.lang.Class<?> charType;
    public final java.lang.Class<?> byteByte;
    public final java.lang.Class<?> shortType;
    public final java.lang.Class<?> intType;
    public final java.lang.Class<?> longType;
    public final java.lang.Class<?> floatType;
    public final java.lang.Class<?> doubleType;
    public final java.lang.Class<?> decimalType;
    public final java.lang.Class<?> boolType;
    public final java.lang.Class<?> dateTimeType;
    public final java.lang.Class<?> stringType;
    public final java.util.LinkedHashMap<java.lang.String, Object> InstanceDic;
    public final java.util.LinkedHashMap<Object, java.lang.String> toJsonInstanceDic;

    public Parse() {
        RootNameSpace = this.getClass().getName().split("\\.")[0];
        InstanceDic = new java.util.LinkedHashMap<>();
        toJsonInstanceDic = new java.util.LinkedHashMap<>();
        charType = Character.class;
        byteByte = Byte.class;
        shortType = Short.class;
        intType = Integer.class;
        longType = Long.class;
        floatType = Float.class;
        doubleType = Double.class;
        decimalType = $Ku.by.Object.Decimal.class;
        boolType = Boolean.class;
        dateTimeType = $Ku.by.Object.Datetime.class;
        stringType = String.class;
    }


    public $Ku.by.JsonUtils.JsonObject arrayToJson(java.lang.Class<?> f_ArrayType, Object f_ArrayValue) {
        JsonObject tmpArrayJson = new JsonObject();
        if (this.toJsonInstanceDic.containsKey(f_ArrayValue)) {
            String tmpRefValue = this.toJsonInstanceDic.get(f_ArrayValue);
            tmpArrayJson.Add(MessageRef, new JsonString(tmpRefValue));
            return tmpArrayJson;
        }

        Object[] tmpIlist = (Object[]) f_ArrayValue;
        if (tmpIlist == null) {
            throw new ParseTransferException(ErrorInfo.UnSupportedArrayType);
        }

        if (f_ArrayType.getTypeParameters().length > 0) {
            throw new ParseTransferException(ErrorInfo.UnSupportedArrayType);
        }

        JsonArray tmpJson = new JsonArray();
        tmpArrayJson.Add(MessageParameterObjType, new JsonString(MessageArray));
        tmpArrayJson.Add(MessageID, new JsonString(String.valueOf(this.toJsonInstanceDic.size())));
        this.toJsonInstanceDic.put(f_ArrayValue, String.valueOf(this.toJsonInstanceDic.size()));
        for (Object item : tmpIlist) {

            if (f_ArrayType.isArray()) {
                tmpJson.Add(arrayToJson(f_ArrayType.getComponentType(), item));
                continue;
            }

            if (f_ArrayType == Byte.class || f_ArrayType == Short.class || f_ArrayType == Integer.class || f_ArrayType == Double.class || f_ArrayType == Float.class) {
                tmpJson.Add(new JsonNumber(item.toString()));
                continue;
            }

            if (f_ArrayType == Boolean.class) {
                tmpJson.Add(new JsonBool(Boolean.parseBoolean(item.toString())));
                continue;
            }

            if (f_ArrayType == String.class || f_ArrayType == Character.class || f_ArrayType == Long.class || f_ArrayType == $Ku.by.Object.Decimal.class || f_ArrayType == $Ku.by.Object.Datetime.class) {
                tmpJson.Add(new JsonString(item.toString()));
                continue;
            }

            // 自定义类型
            tmpJson.Add(this.objToJson(item));
        }

        tmpArrayJson.Add(MessageArrayValue, tmpJson);
        return tmpArrayJson;
    }

    public $Ku.by.JsonUtils.JsonObject listToJson(java.lang.Class< ? > f_ValueType, Object f_ListValue) {
        JsonObject tmpListJson = new JsonObject();
        if(this.toJsonInstanceDic.containsKey(f_ListValue)){
            String tmpRefValue = this.toJsonInstanceDic.get(f_ListValue);
            tmpListJson.Add(MessageRef, new JsonString(tmpRefValue));
            return tmpListJson;
        }

        $Ku.by.Object.List<?> tmpList = ($Ku.by.Object.List<?>) f_ListValue;
        if(tmpList == null){
            throw new ParseTransferException(ErrorInfo.UnSupportedArrayType);
        }

        if(f_ValueType.isArray()){
            throw new ParseTransferException(ErrorInfo.UnSupportedArrayType);
        }

        JsonArray tmpJson = new JsonArray();
        tmpListJson.Add(MessageParameterObjType, new JsonString(MessageList));
        tmpListJson.Add(MessageID, new JsonString(String.valueOf(this.toJsonInstanceDic.size())));
        this.toJsonInstanceDic.put(f_ListValue, String.valueOf(this.toJsonInstanceDic.size()));
        for(Object item : tmpList){
            if(item == null){
                tmpJson.Add(new JsonNull());
                continue;
            }

            if(f_ValueType == Byte.class || f_ValueType == Short.class || f_ValueType == Integer.class || f_ValueType == Double.class || f_ValueType == Float.class){
                tmpJson.Add(new JsonNumber(item.toString()));
                continue;
            }

            if(f_ValueType == Boolean.class){
                tmpJson.Add(new JsonBool(Boolean.parseBoolean(item.toString())));
                continue;
            }

            if(f_ValueType == String.class || f_ValueType == Character.class || f_ValueType == Long.class || f_ValueType == $Ku.by.Object.Decimal.class || f_ValueType == $Ku.by.Object.Datetime.class){
                tmpJson.Add(new JsonString(item.toString()));
                continue;
            }
            if(f_ValueType == $Ku.by.Object.List.class){
                tmpJson.Add(listToJson((($Ku.by.Object.List)item).$t.clazz, item));
                continue;
            }

            if(f_ValueType == $Ku.by.Object.Dictionary.class){
                tmpJson.Add(dicToJson((($Ku.by.Object.Dictionary)item).$k.clazz, (($Ku.by.Object.Dictionary)item).$v.clazz, item));
                continue;
            }
            tmpJson.Add(this.objToJson(item));

        }

        tmpListJson.Add(MessageArrayValue, tmpJson);
        return tmpListJson;
    }

    public $Ku.by.JsonUtils.JsonObject dicToJson(java.lang.Class< ? > f_KeyType, java.lang.Class< ? > f_ValueType, Object f_DicValue) {
        JsonObject tmpDicJson = new JsonObject();
        if(this.toJsonInstanceDic.containsKey(f_DicValue)){
            String tmpRefValue = this.toJsonInstanceDic.get(f_DicValue);
            tmpDicJson.Add(MessageRef, new JsonString(tmpRefValue));
            return tmpDicJson;
        }

        $Ku.by.Object.Dictionary<?, ?> tmpDic = ($Ku.by.Object.Dictionary<?, ?>) f_DicValue;

        if(tmpDic == null){
            throw new ParseTransferException(ErrorInfo.UnSupportedDicType);
        }

        if(f_KeyType.isArray() || f_ValueType.isArray()){
            throw new ParseTransferException(ErrorInfo.UnSupportedDicType);
        }


        JsonArray tmpKeyJson = new JsonArray();
        JsonArray tmpValueJson = new JsonArray();

        tmpDicJson.Add(MessageParameterObjType, new JsonString(MessageDictionary));
        tmpDicJson.Add(MessageID, new JsonString(String.valueOf(this.toJsonInstanceDic.size())));
        this.toJsonInstanceDic.put(f_DicValue, String.valueOf(this.toJsonInstanceDic.size()));

        for (Object key : tmpDic.hashtable.keySet()){
            if(key == null){
                throw new ParseTransferException(ErrorInfo.DicKeyIsNull);
            }

            if(f_KeyType == Byte.class || f_KeyType == Short.class || f_KeyType == Integer.class || f_KeyType == Double.class || f_KeyType == Float.class){
                tmpKeyJson.Add(new JsonNumber(key.toString()));

            }

            else if(f_KeyType == Boolean.class){
                tmpKeyJson.Add(new JsonBool(Boolean.parseBoolean(key.toString())));

            }

            else if(f_KeyType == String.class || f_KeyType == Character.class || f_KeyType == Long.class || f_KeyType == $Ku.by.Object.Decimal.class || f_KeyType == $Ku.by.Object.Datetime.class){
                tmpKeyJson.Add(new JsonString(key.toString()));
            }
            else if(f_KeyType == $Ku.by.Object.List.class){
                tmpKeyJson.Add(listToJson((($Ku.by.Object.List)key).$t.clazz, key));
            }

            else if(f_KeyType == $Ku.by.Object.Dictionary.class){
                tmpKeyJson.Add(dicToJson((($Ku.by.Object.Dictionary)key).$k.clazz, (($Ku.by.Object.Dictionary)key).$v.clazz, key));
            }
            else tmpKeyJson.Add(this.objToJson(key));

            Object value = tmpDic.hashtable.get(key);

            if(value == null){
                tmpValueJson.Add(new JsonNull());
                continue;
            }

            if(f_ValueType == Byte.class || f_ValueType == Short.class || f_ValueType == Integer.class || f_ValueType == Double.class || f_ValueType == Float.class){
                tmpValueJson.Add(new JsonNumber(value.toString()));
                continue;
            }

            if(f_ValueType == Boolean.class){
                tmpValueJson.Add(new JsonBool(Boolean.parseBoolean(value.toString())));
                continue;
            }

            if(f_ValueType == String.class || f_ValueType == Character.class || f_ValueType == Long.class || f_ValueType == $Ku.by.Object.Decimal.class || f_ValueType == $Ku.by.Object.Datetime.class){
                tmpValueJson.Add(new JsonString(value.toString()));
                continue;
            }
            if(f_ValueType == $Ku.by.Object.List.class){
                tmpValueJson.Add(listToJson((($Ku.by.Object.List)value).$t.clazz, value));
                continue;
            }

            if(f_ValueType == $Ku.by.Object.Dictionary.class){
                tmpValueJson.Add(dicToJson((($Ku.by.Object.Dictionary)value).$k.clazz, (($Ku.by.Object.Dictionary)value).$v.clazz, value));
                continue;
            }
            tmpValueJson.Add(this.objToJson(value));
            
        }

        tmpDicJson.Add(MessageKey, tmpKeyJson);
        tmpDicJson.Add(MessageDicValue, tmpValueJson);
        return tmpDicJson;
    }

    public $Ku.by.JsonUtils.JsonObject objToJson(Object f_Object) {
        JsonObject tmpJsonValue = new JsonObject();
        if (this.toJsonInstanceDic.containsKey(f_Object)) {
            String tmpRefValue = this.toJsonInstanceDic.get(f_Object);
            tmpJsonValue.Add(MessageRef, new JsonString(tmpRefValue));
            return tmpJsonValue;
        }

        if (f_Object instanceof $Ku.by.Object.Row) {
            return this.rowToJson(($Ku.by.Object.Row) f_Object);
        }
        if(f_Object instanceof $Ku.by.Object.AbstractOrm){
            return this.ormToJson((AbstractOrm) f_Object);
        }
        Class<?> tmpObjType = f_Object.getClass();
        java.lang.reflect.Field[] tmpProps = tmpObjType.getFields();
        tmpJsonValue.Add(MessageParameterObjType, new JsonString(MessageUserDefined));
        tmpJsonValue.Add(MessageID, new JsonString(String.valueOf(this.toJsonInstanceDic.size())));
        this.toJsonInstanceDic.put(f_Object, String.valueOf(this.toJsonInstanceDic.size()));

        String tmpObjFullName = tmpObjType.getName(); // $Ku.xx.Object.xx
        String[] tmpObjNameCollection = tmpObjFullName.split("\\.");
        String tmpKuName = tmpObjNameCollection[1];
        String tmpObjName = tmpObjType.getSimpleName();
        tmpJsonValue.Add(MessageType, new JsonString(tmpKuName + "." + tmpObjName));

        java.util.LinkedHashMap<String, String> tmpRenamedPropNameDic = new java.util.LinkedHashMap<>();
        if (Root.GetInstance().ReNamedPropDicKeyIsNew.containsKey(tmpKuName)) {
            tmpRenamedPropNameDic = Root.GetInstance().ReNamedPropDicKeyIsNew.get(tmpKuName);
        }

        // 不支持类型为自定义类型的属性
        for (java.lang.reflect.Field item : tmpProps) {
            Class<?> tmpPropType = item.getType();
            item.setAccessible(true);
            Object tmpValue;
            try {
                tmpValue = item.get(f_Object);
            } catch (IllegalAccessException e) {
                throw new RuntimeException(e);
            }

            String tmpPropName = item.getName();
            if (!tmpRenamedPropNameDic.isEmpty()) {
                String tmpComparedName = tmpObjName + "." + tmpPropName;
                if (tmpRenamedPropNameDic.containsKey(tmpComparedName)) {
                    tmpPropName = tmpRenamedPropNameDic.get(tmpComparedName).split("\\.")[1];
                }
            }

            if (tmpPropName.equals("$Identity")) {
                tmpPropName = MessageDollarIdentity;
            }

            if (tmpValue == null) {
                tmpJsonValue.Add(tmpPropName, new JsonNull());
                continue;
            }
   
            if (tmpValue instanceof AbstractOrm) {
                tmpJsonValue.Add(tmpPropName, this.ormToJson(($Ku.by.Object.AbstractOrm) tmpValue));
                continue;
            }

            if(tmpPropType == $Ku.by.Object.List.class){
                tmpJsonValue.Add(tmpPropName, this.listToJson((($Ku.by.Object.List)tmpValue).$t.clazz , tmpValue));
                continue;
            }
            if(tmpPropType == $Ku.by.Object.Dictionary.class){
                tmpJsonValue.Add(tmpPropName, this.dicToJson( (($Ku.by.Object.Dictionary)tmpValue).$k.clazz ,(($Ku.by.Object.Dictionary)tmpValue).$v.clazz , tmpValue));
                continue;
            }

            if (tmpPropType == Byte.class || tmpPropType == Short.class || tmpPropType == Integer.class || tmpPropType == Double.class || tmpPropType == Float.class) {
                tmpJsonValue.Add(tmpPropName, new JsonNumber(tmpValue.toString()));
                continue;
            }

            if (tmpPropType == Boolean.class) {
                tmpJsonValue.Add(tmpPropName, new JsonBool(Boolean.parseBoolean(tmpValue.toString())));
                continue;
            }

            if (tmpPropType == String.class || tmpPropType == Character.class || tmpPropType == Long.class || tmpPropType == $Ku.by.Object.Decimal.class || tmpPropType == $Ku.by.Object.Datetime.class) {
                tmpJsonValue.Add(tmpPropName, new JsonString(tmpValue.toString()));
                continue;
            }

            if (tmpPropType == $Ku.by.Object.Row.class) {
                tmpJsonValue.Add(tmpPropName, this.rowToJson(($Ku.by.Object.Row) tmpValue));
                continue;
            }

            if (tmpPropType.isArray()) {
                String tmpTypeFullName = tmpPropType.getName();
                String tmpTypeName = tmpTypeFullName.substring(2, tmpTypeFullName.length() - 1);
                Class<?> tmpType;
                try {
                    tmpType = Class.forName(tmpTypeName);
                } catch (ClassNotFoundException e) {
                    throw new RuntimeException(e);
                }

                if (tmpPropType == Byte[].class || tmpPropType == Short[].class || tmpPropType == Integer[].class || tmpPropType == Double[].class || tmpPropType == Float[].class
                        || tmpPropType == Boolean[].class || tmpPropType == String[].class || tmpPropType == Character[].class || tmpPropType == Long[].class || tmpPropType == $Ku.by.Object.Decimal[].class
                        || tmpPropType == $Ku.by.Object.Datetime[].class || tmpPropType == $Ku.by.Object.Row[].class) {
                    tmpJsonValue.Add(tmpPropName, this.arrayToJson(tmpType, tmpValue));
                    continue;
                } else {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
                }
            }

            if (tmpPropName.equals(MessageDollarIdentity)) {
                tmpJsonValue.Add(MessageDollarIdentity, this.identityToJson((AbstractIdentityBase) tmpValue));
                continue;
            }

            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportPropType);
        }

        if (!tmpJsonValue.ContainsKey(MessageDollarIdentity)) {
            tmpJsonValue.Add(MessageDollarIdentity, new JsonNull());
        }

        return tmpJsonValue;
    }

    public $Ku.by.JsonUtils.JsonObject identityToJson($Ku.by.ToolClass.AbstractIdentityBase f_Identity) {
        
        JsonObject tmpJson = new JsonObject();
        if (toJsonInstanceDic.containsKey(f_Identity)) {
            String tmpRefValue = toJsonInstanceDic.get(f_Identity);
            tmpJson.Add(MessageRef, new JsonString(tmpRefValue));
            return tmpJson;
        }

        if (f_Identity == null) {
            return tmpJson;
        }
        tmpJson.Add(MessageParameterObjType, new JsonString(MessageIdentity));
        tmpJson.Add(MessageID, new JsonString(String.valueOf(toJsonInstanceDic.size())));
        toJsonInstanceDic.put(f_Identity, String.valueOf(toJsonInstanceDic.size()));
        String tmpInstanceKu = f_Identity.getKu();
        BaseKu tmpKu = ToolFunction.GetKu(tmpInstanceKu);
        if (!tmpKu.NewIdentityKeyIsId.containsKey(f_Identity)) {
            throw new IllegalArgumentException("UnClearIdentity");
        }

        String tmpInstanceName = tmpKu.NewIdentityKeyIsId.get(f_Identity);
        if (tmpInstanceName.contains(".")) {
            if (!(f_Identity.getTo() instanceof $Ku.by.ToolClass.Sql.SqlField)) {
                throw new IllegalArgumentException("NotFieldIdentity");
            }
            $Ku.by.ToolClass.Sql.SqlField tmpField = ($Ku.by.ToolClass.Sql.SqlField) f_Identity.getTo();
            String tmpSheetName = tmpField.getSheetName();
            JsonObject tmpInstanceJson = new JsonObject();
            String tmpValue = tmpKu.Name + "." + tmpSheetName + "." + tmpField.getName();
            tmpInstanceJson.Add(MessageInner, new JsonBool(true));
            tmpInstanceJson.Add(MessageValue, new JsonString(tmpValue));
            tmpJson.Add(MessageInstance, tmpInstanceJson);
            return tmpJson;
        } else {
            if (tmpInstanceName.startsWith("New_")) {
                String tmpNewIdentityName = tmpInstanceName.substring(4);
                JsonObject tmpInstance = new JsonObject();
                tmpInstance.Add(MessageInner, new JsonBool(false));
                tmpInstance.Add(MessageValue, new JsonString(tmpKu.Name + "." + tmpNewIdentityName));
                tmpJson.Add(MessageInstance, tmpInstance);
                return tmpJson;
            } else if (tmpInstanceName.startsWith("Local_")) {
                String tmpSheetName = tmpInstanceName.substring(6);
                JsonObject tmpInstance = new JsonObject();
                tmpInstance.Add(MessageInner, new JsonBool(true));
                tmpInstance.Add(MessageValue, new JsonString(tmpKu.Name + "." + tmpSheetName));
                tmpJson.Add(MessageInstance, tmpInstance);
                return tmpJson;
            } else {
                throw new IllegalArgumentException("UnClearIdentity");
            }
        }
    
    }

    public $Ku.by.JsonUtils.JsonObject rowToJson($Ku.by.Object.Row f_Row) {
        JsonObject tmpJson = new JsonObject();
        if (toJsonInstanceDic.containsKey(f_Row)) {
            String tmpRefValue = toJsonInstanceDic.get(f_Row);
            tmpJson.Add(MessageRef, new JsonString(tmpRefValue));
            return tmpJson;
        }

        tmpJson.Add(MessageParameterObjType, new JsonString(MessageRow));
        tmpJson.Add(MessageID, new JsonString(String.valueOf(toJsonInstanceDic.size())));
        toJsonInstanceDic.put(f_Row, String.valueOf(toJsonInstanceDic.size()));
        String tmpSheetName = null;
        if (f_Row.$Identity == null) {
            tmpJson.Add(MessageDollarIdentity, null);
        } else {
            IBaseDataSheet tmpDataSheet = (IBaseDataSheet) f_Row.$Identity.getTo();
            if (tmpDataSheet == null) {
                throw new IllegalArgumentException("NotTableIdentity");
            }
            tmpSheetName = tmpDataSheet.getKuName() + "." + tmpDataSheet.getSheetName();
            tmpJson.Add(MessageDollarIdentity, identityToJson(f_Row.$Identity));
        }

        JsonArray tmpFields = new JsonArray();
        JsonArray tmpValues = new JsonArray();
        tmpJson.Add(MessageFields, tmpFields);
        tmpJson.Add(MessageValues, tmpValues);
        for ($Ku.by.Object.Cell cell : f_Row.cells) {
            Object tmpValue = cell.value;

            tmpFields.Add(this.cellToJson(cell));

            if (tmpValue == null) {
                tmpValues.Add(new JsonNull());
                continue;
            }

            if (tmpValue instanceof Byte || tmpValue instanceof Short || tmpValue instanceof Integer
                    || tmpValue instanceof Float || tmpValue instanceof Double) {
                tmpValues.Add(new JsonNumber(tmpValue.toString()));
                continue;
            }

            if (tmpValue instanceof Boolean) {
                tmpValues.Add(new JsonBool(Boolean.parseBoolean(tmpValue.toString())));
                continue;
            }

            if (tmpValue instanceof String || tmpValue instanceof Character || tmpValue instanceof $Ku.by.Object.Decimal
                    || tmpValue instanceof Long || tmpValue instanceof $Ku.by.Object.Datetime || tmpValue instanceof java.time.LocalDateTime) {
                tmpValues.Add(new JsonString(tmpValue.toString()));
                continue;
            }

            if (tmpValue instanceof Date) {
                throw new IllegalArgumentException("存在未转换的Datetime类型");
            }

            if (tmpValue.getClass().isEnum()) {
                tmpValues.Add(new JsonString(tmpValue.toString()));
                continue;
            }

            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.CellValueTypeError);
        }
        return tmpJson;
    }

    public $Ku.by.JsonUtils.JsonObject ormToJson($Ku.by.Object.AbstractOrm f_Orm) {
        JsonObject tmpJson = new JsonObject();
        if(this.toJsonInstanceDic.containsKey(f_Orm)){
            String tmpRefValue = this.toJsonInstanceDic.get(f_Orm);
            tmpJson.Add(MessageRef, new JsonString(tmpRefValue));
            return tmpJson;
        }
        
        java.util.LinkedHashMap<Class<?>, String> tmpOrmNameDic = Root.GetInstance().OrmNameDic;
        Class<?> tmpOrmType = f_Orm.getClass();

        if(!tmpOrmNameDic.containsKey(tmpOrmType)){
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("传输的orm类型查找失败");
        }

        String tmpOrmDecName = tmpOrmNameDic.get(tmpOrmType);

        JsonArray tmpCells = new JsonArray();
        JsonArray tmpValues = new JsonArray();

        for($Ku.by.Object.Cell item : f_Orm.cells()){
            tmpCells.Add(cellToJson(item));

            Object tmpValue = item.value;

            if(tmpValue == null){
                tmpValues.Add(new JsonNull());
                continue;
            }

            if(tmpValue instanceof Byte || tmpValue instanceof Short || tmpValue instanceof Integer || tmpValue instanceof Float || tmpValue instanceof Double){
                if(tmpValue instanceof Double){
                    Double tmpDoubleValue = (Double) tmpValue;

                    if(tmpDoubleValue.equals(Double.POSITIVE_INFINITY)){
                        $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.PositiveInfinity);
                    }
                }
                tmpValues.Add(new JsonNumber(tmpValue.toString()));
                continue;
            }

            if(tmpValue instanceof Boolean){
                tmpValues.Add(new JsonBool((Boolean) tmpValue));
                continue;
            }

            if(tmpValue instanceof String || tmpValue instanceof Character || tmpValue instanceof Decimal || tmpValue instanceof Long || tmpValue instanceof $Ku.by.Object.Datetime){
                tmpValues.Add(new JsonString(tmpValue.toString()));
            }

            if(tmpValue.getClass().isEnum()){
                tmpValues.Add(new JsonString(tmpValue.toString()));
            }

        }

        HashMap<Integer, AbstractIdentityBase> identityMap = new HashMap<>();
        for(java.lang.reflect.Field item : tmpOrmType.getFields()){
            if(!item.getName().startsWith("Table")){
                continue;
            }
            String indexString = item.getName().substring(5);
            try {
                $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row) item.get(f_Orm);
                identityMap.put(Integer.valueOf(indexString), tmpRow.$Identity);
            }catch (java.lang.Exception e){
                throw new RuntimeException(e);
            }
        }
        Integer[] tmpOrderIndex = identityMap.keySet().stream().sorted().toArray(Integer[]::new);
        JsonArray tmpIdentityList = new JsonArray();
        for(Integer item : tmpOrderIndex){
            tmpIdentityList.Add(identityToJson(identityMap.get(item)));
        }

        JsonObject tmpMap = new JsonObject();
        for(OrmField item : f_Orm.getOrmFields()){
            tmpMap.Add(item.name, new JsonNumber(item.index.toString()));
        }

        JsonObject tmpTablesMap = new JsonObject();
        for(Map.Entry<String, ArrayList<Integer>> set : f_Orm.getTablesMap().entrySet()){
            JsonArray tmpTableValues = new JsonArray();
            for (Integer iii : set.getValue()){
                tmpTableValues.Add(new JsonNumber(iii.toString()));
            }
            tmpTablesMap.Add(set.getKey(), tmpTableValues);
        }

        tmpJson.Add(MessageParameterObjType, new JsonString(MessageOrm));
        tmpJson.Add(MessageID, new JsonString(this.toJsonInstanceDic.size() + ""));
        tmpJson.Add(MessageType, new JsonString(tmpOrmDecName));
        tmpJson.Add(MessageFieldsMap, tmpMap);
        tmpJson.Add(MessageTablesMap, tmpTablesMap);
        tmpJson.Add(MessageFields, tmpCells);
        tmpJson.Add(MessageValues, tmpValues);
        tmpJson.Add(MessageDollarIdentitys, tmpIdentityList);

        this.toJsonInstanceDic.put(f_Orm, this.toJsonInstanceDic.size() + "");
        return tmpJson;
    }

    public static $Ku.by.JsonUtils.JsonString cellToJson($Ku.by.Object.Cell f_Cell) {
        if(f_Cell.field() != null){
            $Ku.by.ToolClass.Sql.SqlField tmpField = f_Cell.field().Field;
            String tmpFieldName = tmpField.getKuName() + "." + tmpField.getSheetName() + "." + tmpField.getName();
            StringBuilder tmpValue = new StringBuilder();
            if(f_Cell.AggregateFunctionName != null){
                tmpValue.append(f_Cell.AggregateFunctionName);
                tmpValue.append("(");
                tmpValue.append(tmpFieldName);
                tmpValue.append(")");
            }else{
                tmpValue.append(tmpFieldName);
            }
            return new JsonString(tmpValue.toString());
        }
        else{
            if(f_Cell.DataTypeEnum == DataTypeEnum.None){
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("$Ku.by.Object.Cell数据类型未赋值");
            }
            String tmpFieldName;
            if(f_Cell.DataTypeEnum == DataTypeEnum.Enum){
                if(f_Cell.EnumType == null){
                    $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("$Ku.by.Object.Cell数据枚举类型未赋值");
                }
                String tmpEnumFullName = f_Cell.EnumType.getName();
                String[] tmpEnumSplit = tmpEnumFullName.replaceAll("\\$", "").split("\\.");
                //Ku.by.Enum.Action
                if(tmpEnumSplit.length != 4){
                    $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("$Ku.by.Object.Cell数据枚举类型错误");
                }
                String tmpEnumName = tmpEnumSplit[1] + ".enum." + tmpEnumSplit[3];
                tmpFieldName = "[" + tmpEnumName + "]";
            }else{
                tmpFieldName = "[" + f_Cell.DataTypeEnum.name().toLowerCase() + "]";
            }
            if(f_Cell.alias != null){
                tmpFieldName += f_Cell.alias;
            }
            return new JsonString(tmpFieldName);
        }
    }

    public void parsePostContent($Ku.by.JsonUtils.JsonObject obj, java.lang.String f_Ip, java.lang.String f_Url) {
        if (!obj.ContainsKey(MessageCookie)) {
            throw new RuntimeException(ErrorInfo.ParseCookieError);
        }

        if (!obj.ContainsKey(MessageRequest)) {
            throw new RuntimeException(ErrorInfo.ParseRequestMissing);
        }

        if (!obj.ContainsKey(MessageSessionID)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSessionIDError);
        }

        IJsonValue cookieNode = obj.GetValue(MessageCookie);
        String tmpCookieValue;
        if (cookieNode instanceof JsonNull || cookieNode instanceof JsonString) {
            if (cookieNode instanceof JsonNull) {
                tmpCookieValue = null;
            } else {
                JsonString cookieValue = (JsonString) cookieNode;
                tmpCookieValue = cookieValue.getValue();
            }
        } else {
            throw new RuntimeException(ErrorInfo.ParseCookieError);
        }

        IJsonValue tmpSessionIDNode = obj.GetValue(MessageSessionID);
        url = f_Url;

        if (tmpSessionIDNode instanceof JsonNull) {
            serverSession = generateUserData(null, f_Ip, tmpCookieValue);
        } else if (tmpSessionIDNode instanceof JsonString) {
            JsonString tmpSessionID = (JsonString) tmpSessionIDNode;
            serverSession = generateUserData(tmpSessionID.getValue(), f_Ip, tmpCookieValue);
        }

        long tmpThreadIndex = Thread.currentThread().getId();
        Handler.currentThreadIDSession.remove(tmpThreadIndex);
        Handler.currentThreadIDSession.put(tmpThreadIndex, serverSession);
        JsonObject value = obj.GetValue(MessageRequest);
        if (value == null) {
            throw new RuntimeException(ErrorInfo.ParseRequestMissing);
        }

        parseRequestValue(value);
    }

    private $Ku.by.Object.ServerSession generateUserData(java.lang.String f_SessionID, java.lang.String f_Ip, java.lang.String f_Cookie) {
        $Ku.by.Object.ServerSession tmpSession;
        if ($Ku.by.Identity.Server.cacheSessionDic == null) {
            $Ku.by.Identity.Server.cacheSessionDic = new $Ku.by.Object.Dictionary<>();
        }
        if (f_SessionID == null || !Server.cacheSessionDic.containsKey(f_SessionID)) {
            String tmpGUID = java.util.UUID.randomUUID().toString();
            tmpSession = new $Ku.by.Object.ServerSession(900000);
            Server.cacheSessionDic.add(tmpGUID, tmpSession);
            tmpSession.ID = tmpGUID;
        } else {
            tmpSession = Server.cacheSessionDic.get(f_SessionID);
        }
        tmpSession.url = url;
        tmpSession.ip = f_Ip;
        tmpSession.setLoginDt($Ku.by.Object.Datetime.getNow());
        tmpSession.setCookie(f_Cookie);
        return tmpSession;
    }

    public void parseRequestValue($Ku.by.JsonUtils.JsonObject obj) {
        this.InstanceDic.clear();
        this.toJsonInstanceDic.clear();
        this.ResponseType = RequestTypeEnum.None;

        if (!obj.ContainsKey(MessageParameterObjType)) {
            throw new RuntimeException(ErrorInfo.ParseParameterObjTypeError);
        }

        JsonString typeNode = obj.GetValue(MessageParameterObjType);
        if (typeNode == null) {
            throw new RuntimeException(ErrorInfo.ParseParameterObjTypeError);
        }

        String requestType = typeNode.getValue();

        try {
            if (!Arrays.toString(RequestTypeEnum.values()).contains(requestType)) {
                throw new java.lang.Exception(ErrorInfo.ParseIneffectiveRequest);
            }

            if (requestType.equals(RequestTypeEnum.ACTION.toString())) {
                this.ResponseType = RequestTypeEnum.ACTION;
                parseAction(obj);
            }

            if (requestType.equals(RequestTypeEnum.SKILL.toString())) {
                this.ResponseType = RequestTypeEnum.SKILL;
                parseSkill(obj);
            }

            if (requestType.equals(RequestTypeEnum.SOURCE.toString())) {
                this.ResponseType = RequestTypeEnum.SOURCE;
                this.ResponseValue = parseSource(obj);
            }

            if (requestType.equals(RequestTypeEnum.AUTOID.toString())) {
                this.ResponseType = RequestTypeEnum.AUTOID;
                parseAutoNo(obj);
            }

            if (requestType.equals(RequestTypeEnum.SQL.toString())) {
                this.ResponseType = RequestTypeEnum.SQL;
                if (!obj.ContainsKey(MessageKu)) {
                    throw new java.lang.Exception(ErrorInfo.ParseKuNameError);
                }

                JsonString kuNode = obj.GetValue(MessageKu);

                if (kuNode == null) {
                    throw new java.lang.Exception(ErrorInfo.ParseKuNameError);
                }
                String kuName = kuNode.getValue();
                $Ku.by.ToolClass.Sql.ParamsPackage tmpParamsPackage = fillSqlParams(obj);
                String tmpPath = tmpParamsPackage.getPath() + "." + tmpParamsPackage.getMethodName();
                java.util.LinkedHashMap<String, String> tmpLocationDic = Root.GetInstance().KuDic.get(kuName).sqlLocation.getSqlLocalDic();
                if (!tmpLocationDic.containsKey(tmpParamsPackage.getMethodName())) {
                    throw new java.lang.Exception(ErrorInfo.SqlUnknownError);
                }
                this.SqlLocation = tmpLocationDic.get(tmpParamsPackage.getMethodName());
                this.ResponseValue = Response.SqlExpressionResponse(tmpPath, tmpParamsPackage);
            }

            if (requestType.equals(RequestTypeEnum.TRAN.toString())) {
                this.ResponseType = RequestTypeEnum.TRAN;
                $Ku.by.ToolClass.Sql.TranParamsPackage tranParamsPackage = parseTran(obj);
                String tmpPath = null;
                if (tranParamsPackage != null) {
                    tmpPath = tranParamsPackage.getPath() + "." + tranParamsPackage.getMethodName();
                }
                if (tranParamsPackage != null) {
                    this.ResponseValue = Response.TranResponse(tmpPath, tranParamsPackage);
                }
            }

            if(requestType.equals(RequestTypeEnum.EXEC.toString())){
                this.ResponseType = RequestTypeEnum.EXEC;
                this.parseExec(obj);
            }
        } catch (Throwable ex) {
            throw new RuntimeException(ex.toString());
        }
    }

    private void parseExec($Ku.by.JsonUtils.JsonObject f_ExecObj) {
        JsonArray tmpPs = f_ExecObj.GetValue(MessageParamsList);
        JsonObject tmpExecResult = new JsonObject();

        tmpExecResult.Add(MessageParameterObjType, new JsonString("EXEC"));

        if(tmpPs == null){
            throw new RuntimeException();
        }

        for(IJsonValue item : tmpPs.getValues()){
            JsonObject tmpSql = (JsonObject) item;
            JsonObject tmpResult = parseSelectSqlResult(tmpSql);
            tmpExecResult.Add("", tmpResult);
        }
        this.ResponseValue = tmpExecResult.toString();
    }

    private $Ku.by.JsonUtils.JsonObject parseSelectSqlResult($Ku.by.JsonUtils.JsonObject f_SelectSql) {
        if (!f_SelectSql.ContainsKey(MessageKu)) {
            throw new RuntimeException(ErrorInfo.ParseKuNameError);
        }

        JsonString kuNode = f_SelectSql.GetValue(MessageKu);

        if (kuNode == null) {
            throw new RuntimeException(ErrorInfo.ParseKuNameError);
        }
        String kuName = kuNode.getValue();
        $Ku.by.ToolClass.Sql.ParamsPackage tmpParamsPackage = fillSqlParams(f_SelectSql);
        String tmpPath = tmpParamsPackage.getPath() + "." + tmpParamsPackage.getMethodName();
        java.util.LinkedHashMap<String, String> tmpLocationDic = Root.GetInstance().KuDic.get(kuName).sqlLocation.getSqlLocalDic();
        if (!tmpLocationDic.containsKey(tmpParamsPackage.getMethodName())) {
            throw new RuntimeException(ErrorInfo.SqlUnknownError);
        }

        return ConvertStringJson.ParseValue(Response.SqlExpressionResponse(tmpPath, tmpParamsPackage));
    }

    private void parseAction($Ku.by.JsonUtils.JsonObject f_ActionObj) {
        if (!f_ActionObj.ContainsKey(MessageParameters)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
        }

        if (!f_ActionObj.ContainsKey(MessageTarget)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceNameError);
        }

        if (!f_ActionObj.ContainsKey(MessageNo)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (!f_ActionObj.ContainsKey(MessageKu)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
        }

        JsonString tmpKuString = f_ActionObj.GetValue(MessageKu);
        JsonArray tmpParamsArray = f_ActionObj.GetValue(MessageParameters);
        IJsonValue tmpIdentity = f_ActionObj.GetValue(MessageTarget);
        JsonString tmpNoString = f_ActionObj.GetValue(MessageNo);

        if (tmpParamsArray == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(MessageParameters);
        }

        if (tmpIdentity == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
        }

        if (tmpNoString == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (tmpKuString == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
        }

        String tmpKuName = tmpKuString.getValue();
        String tmpNo = tmpNoString.getValue();
        String tmpActionIndex = tmpKuName + "." + tmpNo;

        if (!MethodNameStorage.ActionIdentityNames.containsKey(tmpActionIndex)) {
            ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ActionNameIndexBug, tmpActionIndex));
        }

        String tmpActionValue = MethodNameStorage.ActionIdentityNames.get(tmpActionIndex);
        serverSession.methodName = tmpActionValue;
        String[] tmpActionValueArray = tmpActionValue.split("\\.");

        if (tmpActionValueArray.length != 4) {
            ThrowHelper.ThrowParseTransferException(ErrorInfo.ActionNameValueBug);
        }

        serverSession.identityName = tmpActionValueArray[0] + "." + tmpActionValueArray[2];
        String tmpFullName = "$Ku." + tmpKuName + ".Action.ActionIndex";

        try {
            Class<?> tmpActionClass = Class.forName(tmpFullName);
            Method[] methods = tmpActionClass.getDeclaredMethods();
            Method method = null;
            for (Method item : methods) {
                if (item.getName().equals("_" + tmpNo)) {
                    method = item;
                    break;
                }
            }

            if (method == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ParseCanNotMatchintMethod, tmpNo));
            }
            //this.AddSessionToDic();
            Result tmpComeInResult = this.methodBeforeInvoke();
            if (tmpComeInResult != null) {
                if (!tmpComeInResult.isOk) {
                    this.ComeInHasError = true;
                    this.ResponseValue = tmpComeInResult.info;
                    return;
                }
            }
            if (tmpIdentity instanceof JsonNull) {
                //静态
                this.ResponseValue = Response.SkillOrActionResponse(this, method, null, new Object[]{null, this, tmpParamsArray});
            } else {
                JsonObject tmpIdentityNode = (JsonObject) tmpIdentity;
                AbstractIdentityBase tmpIdentityInstance = parseIdentity(tmpIdentityNode);
                this.ResponseValue = Response.SkillOrActionResponse(this, method, tmpIdentityInstance, new Object[]{tmpIdentityInstance, this, tmpParamsArray});
            }
        } catch (java.lang.Exception e) {
            throw new RuntimeException(e);
        }
    }

    private $Ku.by.Object.Result methodBeforeInvoke() {
        if ($Ku.by.Identity.Server.mIDoor != null) {
            return $Ku.by.Identity.Server.mIDoor.comeIn($Ku.by.Object.ServerSession.getCurrentSession());
        } else {
            return null;
        }
    }

    public void parseSkill($Ku.by.JsonUtils.JsonObject skillObject) {
        if (!skillObject.ContainsKey(MessageParameters)) {
            ThrowParseTransferException(ErrorInfo.ParseParamsError);
        }

        if (!skillObject.ContainsKey(MessageTarget)) {
            ThrowParseTransferException(ErrorInfo.ParseInstanceNameError);
        }

        if (!skillObject.ContainsKey(MessageNo)) {
            ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (!skillObject.ContainsKey(MessageKu)) {
            ThrowParseTransferException(ErrorInfo.ParseKuNameError);
        }

        JsonString kuJsonString = skillObject.GetValue(MessageKu);
        JsonArray paramsArray = skillObject.GetValue(MessageParameters);
        IJsonValue identity = skillObject.GetValue(MessageTarget);
        JsonString skillNoJsonString = skillObject.GetValue(MessageNo);

        if (paramsArray == null) {
            ThrowParseTransferException(ErrorInfo.ParseParamsError);
        }

        if (skillNoJsonString == null) {
            ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (kuJsonString == null) {
            ThrowParseTransferException(ErrorInfo.ParseKuNameError);
        }

        if (!(identity instanceof JsonNull || identity instanceof JsonObject)) {
            ThrowParseTransferException(ErrorInfo.ParseIdentityError);
        }

        String skillKuName = kuJsonString.getValue();
        String skillNo = skillNoJsonString.getValue();
        String skillIndexPath = String.format("$Ku.%s.Skill.SkillIndex", skillKuName);
        String storageIndex = String.format("%s.%s", skillKuName, skillNo);

        if (!$Ku.by.ToolClass.MethodNameStorage.SkillNames.containsKey(storageIndex)) {
            ThrowParseTransferException(String.format(ErrorInfo.SkillNameIndexBug, storageIndex));
        }
        String methodName = $Ku.by.ToolClass.MethodNameStorage.SkillNames.get(storageIndex);
        // 先填充session
        serverSession.identityName = methodName.substring(0, methodName.lastIndexOf('.'));
        serverSession.methodName = methodName;
        Class<?> skillIndexType;
        try {
            skillIndexType = Class.forName(skillIndexPath);
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
        Method method = null;
        try {
            Method[] methods = skillIndexType.getDeclaredMethods();
            for (Method item : methods) {
                if (item.getName().equals("_" + skillNo)) {
                    method = item;
                    break;
                }
            }
        } catch (java.lang.Exception e) {
            throw new RuntimeException(e);
        }
        if (method == null) {
            ThrowParseTransferException(String.format(ErrorInfo.ParseCanNotMatchintMethod, skillNo));
        }
        this.methodBeforeInvoke();

        if (identity instanceof JsonNull) {
            // 说明是静态方法
            Object[] skillParams = new Object[]{this, null, paramsArray};
            this.ResponseValue = Response.SkillOrActionResponse(this, method, null, skillParams);
        } else {
            JsonObject identityNode = (JsonObject) identity;
            Object identityInstance = parseIdentity(identityNode);
            Object[] skillParams = new Object[]{this, identityInstance, paramsArray};
            this.ResponseValue = Response.SkillOrActionResponse(this, method, identityInstance, skillParams);
        }
    }

    private java.lang.String parseSource($Ku.by.JsonUtils.JsonObject sourceObj) {
        if (!sourceObj.ContainsKey(MessageSheetName)) {
            ThrowParseTransferException(ErrorInfo.ParseSheetNameError);
        }

        JsonString sheetNameNode = sourceObj.GetValue(MessageSheetName);
        JsonString sourceNameNode = sourceObj.GetValue(MessageSourceName);
        JsonNumber paNode = sourceObj.GetValue(MessageParameters);

        if (sheetNameNode == null) {
            ThrowParseTransferException(ErrorInfo.ParseSheetNameError);
        }

        if (sourceNameNode == null && paNode == null) {
            ThrowParseTransferException(ErrorInfo.ParseRequestError);
        }

        if (sourceNameNode != null) {
            String[] sheetArray = sheetNameNode.getValue().split("\\.");
            if (sheetArray.length != 2) {
                ThrowParseTransferException(ErrorInfo.ParseSourceError);
            }
            String kuName = sheetArray[0];
            String sheetName = sheetArray[1];
            String sourceName = sourceNameNode.getValue();
            String path = String.format("$Ku.%s.Source.%s", kuName, sheetName);
            Class<?> type = null;
            try {
                type = Class.forName(path);
            } catch (ClassNotFoundException e) {
                throw new RuntimeException(e);
            }
            Method method = null;
            try {
                method = type.getMethod(sourceName, $Ku.by.Object.Table.class);
            } catch (NoSuchMethodException e) {
                ThrowParseTransferException(String.format(ErrorInfo.ParseCanNotMatchintMethod, MessageSourceName));
            }


            IBaseDataSheet sheet;
            try {
                sheet = Root.GetInstance().get(kuName).get(sheetName);
            } catch (java.lang.Exception e) {
                throw new RuntimeException(e);
            }
            if (!sheet.getSourceDic().containsKey(sourceName)) {
                ThrowParseTransferException(String.format(ErrorInfo.ParseCanNotFindSource, sheetName, sourceName));
            }
            Source source = sheet.getSourceDic().get(sourceName);
            String sourceIndex = kuName + "." + sheetName + "." + sourceName;
            if ($Ku.by.ToolClass.MethodNameStorage.SourceMethodNames.containsKey(sourceIndex)) {
                serverSession.methodName = $Ku.by.ToolClass.MethodNameStorage.SourceMethodNames.get(sourceIndex);
            }

            this.methodBeforeInvoke();

            Object result;
            try {
                result = method.invoke(null, source.Parameters);
            } catch (InvocationTargetException ex) {
                if (ex.getTargetException() != null) {
                    try {
                        throw ex.getTargetException();
                    } catch (Throwable e) {
                        throw new RuntimeException(e);
                    }
                }
                try {
                    throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException($Ku.by.ToolClass.ErrorInfo.UnknownErrorInReflection);
                } catch (java.lang.Exception e) {
                    throw new RuntimeException(e);
                }
            } catch (IllegalAccessException e) {
                throw new RuntimeException(e);
            }
            // 结果可能是数据库数据类型，枚举，前两个的集合
            if (result instanceof java.util.List) {
                java.util.List listResult = (java.util.List) result;
                StringBuilder value = new StringBuilder("[");
                for (Object o : listResult) {
                    if (value.length() != 1) {
                        value.append(".:");
                    }
                    value.append(o.toString());
                }
                value.append("]");
                return value.toString();
            }
            if (result == null) {
                return null;
            }
            if (result instanceof String || result instanceof $Ku.by.Object.Datetime || result instanceof java.time.LocalDateTime || result instanceof $Ku.by.Object.Decimal || result instanceof Double) {
                return "\"" + result + "\"";
            }
            return result.toString();
        } else {
            throw ThrowParseTransferException("特殊数据源");
        }
    }

    public $Ku.by.ToolClass.AbstractIdentityBase parseIdentity($Ku.by.JsonUtils.JsonObject identityJsonObj) {
        if (identityJsonObj.ContainsKey(MessageRef)) {
            if (identityJsonObj.keyObjectDic.size() > 1) {
                throw ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            JsonString refNode =  identityJsonObj.GetValue(MessageRef);
            if (refNode == null) {
                throw ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            String refValue = refNode.getValue();
            if (!this.InstanceDic.containsKey(refValue)) {
                throw ThrowParseTransferException(ErrorInfo.RefCanNotFind);
            }

            Object identity =  this.InstanceDic.get(refValue);
            if (!(identity instanceof AbstractIdentityBase)) {
                throw ThrowParseTransferException(ErrorInfo.RefCanNotFind);
            }

            return (AbstractIdentityBase) identity;
        }

        if (!identityJsonObj.ContainsKey(MessageID) || !identityJsonObj.ContainsKey(MessageInstance)) {
            throw ThrowParseTransferException(ErrorInfo.ParseIdentityError);
        }

        JsonObject instanceObj = identityJsonObj.GetValue(MessageInstance);
        JsonString id =  identityJsonObj.GetValue(MessageID);

        if (id == null) {
            throw ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
        }

        if (InstanceDic.containsKey(id.getValue())) {
            throw ThrowParseTransferException(ErrorInfo.ConflictInstance);
        }

        if (instanceObj == null || !instanceObj.ContainsKey(MessageInner) || !instanceObj.ContainsKey(MessageValue)) {
            throw ThrowParseTransferException(ErrorInfo.ParseInstanceError);
        }

        JsonBool inner =  instanceObj.GetValue(MessageInner);
        JsonString value = instanceObj.GetValue(MessageValue);

        if (inner == null || value == null) {
            throw ThrowParseTransferException(ErrorInfo.ParseInstanceError);
        }

        String[] valueArray = value.getValue().split("\\.");
        if (valueArray.length != 2 && valueArray.length != 3) {
            throw ThrowParseTransferException(ErrorInfo.ParseInstanceError);
        }

        String kuName = valueArray[0];
        if (inner.getValue()) {
            // 数据表内标记的
            String dataSheetName = valueArray[1];
            IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheet(kuName, dataSheetName);

            if (valueArray.length == 2) {
                AbstractIdentityBase identity = tmpDataSheet.getIdentity();
                this.InstanceDic.put(id.getValue(), identity);
                return identity;
            } else {
                String colName = valueArray[2];
                if (!tmpDataSheet.getFieldDic().containsKey(colName)) {
                    throw ThrowParseTransferException(ErrorInfo.CanNotFindColumn);
                }
                AbstractIdentityBase field = tmpDataSheet.getFieldDic().get(colName).getIdentity();
                this.InstanceDic.put(id.getValue(), field);
                return field;
            }
        } else {
            // new中标记的
            String instanceName = valueArray[1];
            String newInstanceName = "New_" + instanceName;
            BaseKu tmpKu = Root.GetInstance().get(kuName);
            if (!tmpKu.NewIdentityDic.containsKey(newInstanceName)) {
                throw ThrowParseTransferException(ErrorInfo.ParseIdentityError);
            }
            AbstractIdentityBase newInstance = tmpKu.NewIdentityDic.get(newInstanceName);
            this.InstanceDic.put(id.getValue(), newInstance);
            return newInstance;
        }

    }

    public void parseAutoNo($Ku.by.JsonUtils.JsonObject autoNoObj) {
        if (!autoNoObj.ContainsKey(MessageSheetName) || !autoNoObj.ContainsKey("$VA")) {
            throw ThrowParseTransferException(ErrorInfo.ParseAutoNoError);
        }

        JsonString sheetNameNode = autoNoObj.GetValue(MessageSheetName);
        JsonNumber valueNode = autoNoObj.GetValue("$VA");
        JsonBool needRefresh = autoNoObj.GetValue(MessageRefresh);

        if (sheetNameNode == null || valueNode == null || needRefresh == null) {
            throw ThrowParseTransferException(ErrorInfo.ParseAutoNoError);
        }
        serverSession.methodName = "by.object.System.autoID";
        Result tmpComeInResult = this.methodBeforeInvoke();
        if (tmpComeInResult != null) {
            if (!tmpComeInResult.isOk) {
                this.ComeInHasError = true;
                this.ResponseValue = tmpComeInResult.info;
                return;
            }
        }
        IBaseDataSheet tmpDataSheet = getDataSheet(sheetNameNode.getValue());
        this.ResponseValue = String.valueOf($Ku.by.Object.System.autoID(($Ku.by.Object.Table) tmpDataSheet, Integer.parseInt(valueNode.getNumberStr()), needRefresh.getValue()));
    }

    public static $Ku.by.ToolClass.IBaseDataSheet getDataSheet(java.lang.String qualifiedName) {
        if (qualifiedName == null) {
            return null;
        }
        String[] tmpArray = qualifiedName.split("\\.");
        if (tmpArray.length != 2) {
            throw new DataMatchException(String.format(ErrorInfo.CanNotMatchingSource, qualifiedName));
        }
        String tmpKuName = tmpArray[0];
        String tmpSheetName = tmpArray[1];
        try {
            return Root.GetInstance().get(tmpKuName).get(tmpSheetName);
        } catch (java.lang.Exception e) {
            throw new RuntimeException(e);
        }
    }

    private $Ku.by.ToolClass.Sql.ParamsPackage fillSqlParams($Ku.by.JsonUtils.JsonObject f_Obj) {
        if (!f_Obj.ContainsKey(MessageKu)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
        }

        if (!f_Obj.ContainsKey(MessageValue)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsValueError);
        }

        JsonString tmpKuNode = f_Obj.GetValue(MessageKu);
        JsonObject tmpSqlValue = f_Obj.GetValue(MessageValue);

        if (tmpKuNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
        }

        if (tmpSqlValue == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsValueError);
        }

        String tmpKuName = tmpKuNode.getValue();
        ArrayList<Object> tmpParams = new ArrayList<>();
        return ($Ku.by.ToolClass.Sql.ParamsPackage)parseSqlValue(tmpKuName, tmpSqlValue, tmpParams, false, null);
    }

    private Object parseSqlValue(java.lang.String f_KuName, $Ku.by.JsonUtils.JsonObject f_SqlValue, Object f_ParamsList, boolean f_IsExist, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables) {
        if (!f_SqlValue.ContainsKey(MessageFrom)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
        }

        if (!f_SqlValue.ContainsKey(MessageParameters)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
        }

        if (!f_SqlValue.ContainsKey(MessageNo)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (f_SqlValue.ContainsKey(MessageParameterObjType)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIllegalJsonObj);
        }

        ArrayList<Object> tmpParamsList = new ArrayList<>();
        JsonArray tmpFromArray = f_SqlValue.GetValue(MessageFrom);
        JsonArray tmpParameterNode = f_SqlValue.GetValue(MessageParameters);
        JsonString tmpSqlNo = f_SqlValue.GetValue(MessageNo);

        if (tmpFromArray == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
        }

        if (tmpParameterNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
        }

        if (tmpSqlNo == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        String tmpNO = tmpSqlNo.getValue();
        String tmpStorageIndex = String.format("%s.%s", f_KuName, tmpNO);
        if (!MethodNameStorage.SqlNames.containsKey(tmpStorageIndex)) {
            ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.SqlNameIndexBug, tmpStorageIndex));
        }
        serverSession.methodName = MethodNameStorage.SqlNames.get(tmpStorageIndex);
        //this.AddSessionToDic();
        Result tmpComeInResult = this.methodBeforeInvoke();
        if (tmpComeInResult != null) {
            if (!tmpComeInResult.isOk) {
                this.ComeInHasError = true;
                this.ResponseValue = tmpComeInResult.info;
                return null;
            }
        }
        String tmpTypePath = String.format("$Ku.%s.SqlExpression.Sql", f_KuName);
        String tmpMethod = String.format("_%s", tmpNO);

        // 填充source
        ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new ArrayList<>();
        for (Object item : tmpFromArray.getValues()) {
            JsonObject tmpTableObj = (JsonObject) item;
            if (tmpTableObj == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSheetNameFormatError);
            }
            parseTableSource(tmpTableObj, f_KuName, tmpTableList, tmpParamsList);
        }
        if (f_IsExist) {
            tmpTableList.addAll(f_Tables);
        }
        generateParameterList(tmpParameterNode.getValues(), tmpParamsList, f_KuName, tmpTableList);
        if (f_IsExist) {
            try {
                Class<?> tmpSqlType = Class.forName(tmpTypePath);
                Method tmpReflectMethod = tmpSqlType.getMethod(tmpMethod, $Ku.by.ToolClass.Sql.ParamsPackage.class);
                $Ku.by.ToolClass.Sql.ParamsPackage tmpParameterPackage = new $Ku.by.ToolClass.Sql.ParamsPackage(tmpTypePath, tmpMethod, tmpTableList, tmpParamsList);
                return tmpReflectMethod.invoke(null, tmpParameterPackage);
            } catch (java.lang.Exception e) {
                if (e instanceof InvocationTargetException) {
                    throw new java.lang.RuntimeException(((InvocationTargetException) e).getTargetException());
                }
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }
        }
        return new $Ku.by.ToolClass.Sql.ParamsPackage(tmpTypePath, tmpMethod, tmpTableList, tmpParamsList);
    }

    private $Ku.by.ToolClass.Sql.AbstractTable parseTableSource($Ku.by.JsonUtils.JsonObject f_TableSourceObj, java.lang.String f_KuName, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList, java.util.ArrayList<Object> f_Params) {
        boolean tmpIsTable = false;
        boolean tmpIsSql = false;

        if (f_TableSourceObj.ContainsKey(MessageTable)) {
            tmpIsTable = true;
        }

        if (f_TableSourceObj.ContainsKey(MessageTableSql)) {
            tmpIsSql = true;
        }

        if (tmpIsTable == tmpIsSql) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.IllegalFillFrom);
        }

        if (tmpIsTable) {
            return parseSimpleSqlTable(f_TableSourceObj, f_KuName, f_TableList, f_Params);
        }

        if (tmpIsSql) {
            return parseSqlTable(f_TableSourceObj, f_KuName, f_TableList);
        }

        throw $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.IllegalFillFrom);
    }

    private $Ku.by.ToolClass.Sql.SqlTable parseSimpleSqlTable($Ku.by.JsonUtils.JsonObject f_TableObj, java.lang.String f_KuName, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList, java.util.ArrayList<Object> f_Params) {
        if (!f_TableObj.ContainsKey(MessageTable)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.IllegalFillFrom);
        }

        JsonString tmpTableName = f_TableObj.GetValue(MessageTable);

        if (tmpTableName == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.IllegalFillFrom);
        }

        String tmpTableQualifiedName = tmpTableName.getValue();
        String[] tmpTableArray = tmpTableQualifiedName.split("\\.");

        if (tmpTableArray.length != 2) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.IllegalFillFrom);
        }

        $Ku.by.ToolClass.IBaseDataSheet tmpSheet = getDataSheet(tmpTableQualifiedName);
        $Ku.by.ToolClass.Sql.SqlTable tmpTable;
        try {
            tmpTable = new $Ku.by.ToolClass.Sql.SqlTable(tmpSheet, null);
        } catch (java.lang.Exception e) {
            throw new RuntimeException(e);
        }
        f_TableList.add(tmpTable);

        if (f_TableObj.ContainsKey(MessageJoin)) {
            if (f_TableObj.ContainsKey(MessageParameters)) {
                JsonArray tmpParamsArray = f_TableObj.GetValue(MessageParameters);

                if (tmpParamsArray == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
                }

                generateParameterList(tmpParamsArray.getValues(), f_Params, f_KuName, f_TableList);
            }

            JsonArray tmpJoinArray = f_TableObj.GetValue(MessageJoin);

            if (tmpJoinArray == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.IllegalFillFrom);
            }

            for (Object item : tmpJoinArray.getValues()) {
                JsonObject tmpJoinJson =(JsonObject) item;

                if (tmpJoinJson == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.IllegalFillFrom);
                }

                if (tmpJoinJson.ContainsKey(MessageTable)) {
                    tmpTable.getJoinTables().add(new $Ku.by.ToolClass.Sql.JoinTable(parseSimpleSqlTable(tmpJoinJson, f_KuName, f_TableList, f_Params)));
                } else {
                    tmpTable.getJoinTables().add(new $Ku.by.ToolClass.Sql.JoinTable(parseSqlTable(tmpJoinJson, f_KuName, f_TableList)));
                }
            }
        }

        return tmpTable;
    }

    private void generateParameterList(java.util.ArrayList<$Ku.by.JsonUtils.IJsonValue> f_JsonValue, java.util.ArrayList<Object> f_Params, java.lang.String f_KuName, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables) {
        for (IJsonValue item : f_JsonValue) {
            if (item instanceof JsonNumber) {
                JsonNumber tmpValue = (JsonNumber) item;
                f_Params.add(tmpValue.toString());
                continue;
            }

            if (item instanceof JsonString) {
                JsonString tmpValue = (JsonString) item;
                f_Params.add("'" + tmpValue.getValue() + "'");
                continue;
            }

            if (item instanceof JsonNull) {
                f_Params.add(null);
                continue;
            }

            if (item instanceof JsonObject) {
                //行实例
                JsonObject tmpValue = (JsonObject) item;

                // if (!tmpValue.containsKey(MessageParameterObjType)) {
                //     tmpParamsList.add(parseSqlValue(f_KuName, tmpValue, new ArrayList<>()));
                //     continue;
                // }

                JsonString tmpObjType = tmpValue.GetValue(MessageParameterObjType);

                if (tmpObjType == null) {
                    //有可能是ref
                    if (tmpValue.ContainsKey(MessageRef)) {
                        JsonString tmpRefId = tmpValue.GetValue(MessageRef);
                        if (tmpRefId == null) {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                        }

                        String tmpRefValue = tmpRefId.getValue();
                        if (!InstanceDic.containsKey(tmpRefValue)) {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                        }

                        f_Params.add(InstanceDic.get(tmpRefValue));
                        continue;
                    }

                    if (this.ResponseType == RequestTypeEnum.SQL || this.ResponseType == RequestTypeEnum.TRAN) {
                        //说明是sql参数
                        ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTablesCopy = new ArrayList<>(f_Tables);
                        f_Params.add(this.parseSqlValue(f_KuName, tmpValue, new ArrayList<Object>(), true, tmpTablesCopy));
                        continue;
                    }

                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsTypeError);
                }

                String tmpTypeValue = tmpObjType.getValue();

                switch (tmpTypeValue) {
                    case MessageArray: {
                        //只可能是行集合
                        Class<?> tmpType = $Ku.by.Object.Row[].class;
                        f_Params.add(parseArray(tmpType, tmpValue));
                        continue;
                    }
                    case MessageList: {
                        f_Params.add(this.parseList($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class), tmpValue));
                        continue;
                    }
                    case MessageRow: {
                        f_Params.add(parseRow(tmpValue));
                        continue;
                    }
                    case MessageQuery: {
                        f_Params.add(parseQueryDataValue(tmpValue));
                        continue;
                    }
                    case MessageTableSql: {
                        //说明是exist里面的sql
                        ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTablesCopy = new ArrayList<>(f_Tables);
                        f_Params.add(this.parseSqlValue(f_KuName, tmpValue, new ArrayList<>(), true, tmpTablesCopy));
                        continue;
                    }
                }

                if (tmpValue.ContainsKey(MessageParameterObjType)) {
                    JsonString tmpParamType = tmpValue.GetValue(MessageParameterObjType);

                    if (tmpParamType == null) {
                        $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsTypeError);
                    }

                    if (tmpParamType.getValue().equals(MessageTableSql)) {
                        //说明是exist里面的sql
                        ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTablesCopy = new ArrayList<>(f_Tables);
                        f_Params.add(parseSqlValue(f_KuName, tmpValue, new ArrayList<>(), true, tmpTablesCopy));
                        continue;
                    }
                }

                try {
                    f_Params.add(parseObject(tmpValue));
                } catch (java.lang.Exception e) {
                    throw new RuntimeException(e);
                }
            }

            if (item instanceof JsonArray) {
                //行实例集合
                JsonArray tmpValue = (JsonArray) item;
                f_Params.add(parseRows(tmpValue));
            }

            if (item instanceof JsonBool) {
                JsonBool tmpValue = (JsonBool) item;
                f_Params.add(tmpValue.getValue() ? "1 = 1" : "1 = 0");
            }
        }
    }

    private $Ku.by.ToolClass.Sql.SelectTable parseSqlTable($Ku.by.JsonUtils.JsonObject f_TableObj, java.lang.String f_KuName, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList) {
        JsonObject tmpSqlObj = f_TableObj.GetValue(MessageTableSql);
        if (tmpSqlObj == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSqlTableError);
        }

        if (!tmpSqlObj.ContainsKey(MessageNo)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (!tmpSqlObj.ContainsKey(MessageFrom)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
        }

        if (!tmpSqlObj.ContainsKey(MessageParameters)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
        }

        JsonString tmpNoKeyPair = tmpSqlObj.GetValue(MessageNo);
        JsonArray tmpFromKeyPair = tmpSqlObj.GetValue(MessageFrom) ;
        JsonArray tmpParametersKeyPair = tmpSqlObj.GetValue(MessageParameters);

        if (tmpNoKeyPair == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (tmpFromKeyPair == null) {
            if (!(tmpSqlObj.GetValue(MessageFrom) instanceof JsonNull)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
            }
        }

        if (tmpParametersKeyPair == null) {
            if (!(tmpSqlObj.GetValue(MessageParameters) instanceof JsonArray)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }
        }

        String tmpNo = tmpNoKeyPair.getValue();
        String tmpTypePath = String.format("$Ku.%s.SqlExpression.Sql", f_KuName);
        String tmpMethodName = String.format("_%s", tmpNo);
        ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> tmpTableList = new ArrayList<>();
        ArrayList<Object> tmpParamsList = new ArrayList<>();

        if (tmpFromKeyPair != null) {
            for (IJsonValue item : tmpFromKeyPair.getValues()) {
                JsonObject tmpTable = (JsonObject) item;
                if (tmpTable == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
                }

                if (!tmpTable.ContainsKey(MessageTable)) {
                    tmpTableList.add(parseSqlTable(tmpTable, f_KuName, new ArrayList<>()));
                } else {
                    tmpTableList.add(parseSimpleSqlTable(tmpTable, f_KuName, new ArrayList<>(), new ArrayList<>()));
                }
            }
        }

        if (tmpParametersKeyPair != null) {
            generateParameterList(tmpParametersKeyPair.getValues(), tmpParamsList, f_KuName, tmpTableList);
        }
        $Ku.by.ToolClass.Sql.ParamsPackage tmpParamsPackage = new $Ku.by.ToolClass.Sql.ParamsPackage(tmpTypePath, tmpMethodName, tmpTableList, tmpParamsList);
        Class<?> tmpSqlType;
        try {
            tmpSqlType = Class.forName(tmpParamsPackage.getPath());
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
        Class<?> tmpParamsPackageType = tmpParamsPackage.getClass();
        Method tmpMethod;
        try {
            tmpMethod = tmpSqlType.getMethod(tmpParamsPackage.getMethodName(), tmpParamsPackageType);
        } catch (NoSuchMethodException e) {
            throw new RuntimeException(e);
        }
        $Ku.by.ToolClass.Sql.SelectTable tmpResult;

        try {
            tmpResult = ($Ku.by.ToolClass.Sql.SelectTable) tmpMethod.invoke(null, tmpParamsPackage);
        } catch (InvocationTargetException ex) {
            if (ex.getCause() != null) {
                try {
                    throw ex.getCause();
                } catch (Throwable e) {
                    throw new RuntimeException(e);
                }
            }
            try {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException($Ku.by.ToolClass.ErrorInfo.UnknownErrorInReflection);
            } catch (java.lang.Exception e) {
                throw new RuntimeException(e);
            }
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }

        if (tmpResult == null) {
            try {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.SqlUnknownError);
            } catch (java.lang.Exception e) {
                throw new RuntimeException(e);
            }
        }

        f_TableList.add(tmpResult);

        if (f_TableObj.ContainsKey(MessageJoin)) {
            JsonArray tmpJoinList = f_TableObj.GetValue(MessageJoin);

            if (tmpJoinList != null) {
                for (IJsonValue item : tmpJoinList.getValues()) {
                    JsonObject tmpJsonTable = (JsonObject) item;
                    if (tmpJsonTable == null) {
                        try {
                            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.SqlUnknownError);
                        } catch (java.lang.Exception e) {
                            throw new RuntimeException(e);
                        }
                    }
                    $Ku.by.ToolClass.Sql.AbstractTable tmpJoinTable = parseTableSource(tmpJsonTable, f_KuName, f_TableList, tmpParamsList);
                    tmpResult.getJoinTables().add(new $Ku.by.ToolClass.Sql.JoinTable(tmpJoinTable));
                }
            }
        }

        return tmpResult;
    }

    private $Ku.by.ToolClass.Sql.TranParamsPackage parseTran($Ku.by.JsonUtils.JsonObject f_TranObj) {
        if (!f_TranObj.ContainsKey(MessageKu)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
        }

        if (!f_TranObj.ContainsKey(MessageParamsList)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseTranParametersError);
        }

        if (!f_TranObj.ContainsKey(MessageNo)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (!f_TranObj.ContainsKey(MessageDollarVA)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseTranParametersError);
        }

        JsonString tmpKuNode = f_TranObj.GetValue(MessageKu);
        JsonArray tmpParameterListNode = f_TranObj.GetValue(MessageParamsList);
        JsonString tmpNoNode = f_TranObj.GetValue(MessageNo);
        JsonArray tmpVaNode = f_TranObj.GetValue(MessageDollarVA);

        if (tmpKuNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
        }

        if (tmpParameterListNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
        }

        if (tmpNoNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
        }

        if (tmpVaNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseTranParametersError);
        }

        //路径相关
        String tmpKuName = tmpKuNode.getValue();
        String tmpPath = String.format("$Ku.%s.SqlExpression.Sql", tmpKuName);
        String tmpMethod = "Tran_" + tmpNoNode.getValue();
        String tmpStorageIndex = String.format("%s.%s", tmpKuName, tmpNoNode.getValue());
        if (!MethodNameStorage.TranNames.containsKey(tmpStorageIndex)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.TranNameIndexBug, tmpStorageIndex));
        }
        serverSession.methodName = MethodNameStorage.TranNames.get(tmpStorageIndex);
        Result tmpComeInResult = this.methodBeforeInvoke();
        if (tmpComeInResult != null) {
            if (!tmpComeInResult.isOk) {
                this.ComeInHasError = true;
                this.ResponseValue = tmpComeInResult.info;
                return null;
            }
        }

        ArrayList<$Ku.by.ToolClass.Sql.ParamsPackage> tmpParameterList = new ArrayList<>();
        //填充参数列,顺便取第一条第一个表源的库作为执行库
        
        for (IJsonValue value : tmpParameterListNode.getValues()) {
            JsonObject tmpValue = (JsonObject) value;

            if (tmpValue == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRowValueError);
            }

            tmpParameterList.add(($Ku.by.ToolClass.Sql.ParamsPackage)this.parseSqlValue(tmpKuName, tmpValue, new ArrayList<>(), false, null));
        }

        ArrayList<Object> tmpValues = new ArrayList<>();

        for (Object Tranobj : tmpVaNode.getValues()) {
            if (Tranobj instanceof String) {
                String tmpStringValueNode = (String) Tranobj;
                tmpValues.add(tmpStringValueNode);
                continue;
            }

            if (Tranobj instanceof Number) {
                Number tmpNumNode = (Number) Tranobj;
                tmpValues.add(tmpNumNode);
                continue;
            }

            if (Tranobj instanceof Boolean) {
                Boolean tmpBoolNode = (Boolean) Tranobj;
                tmpValues.add(tmpBoolNode);
                continue;
            }

            if (Tranobj == null) {
                tmpValues.add(null);
                continue;
            }
            ThrowParseTransferException(ErrorInfo.ParseTranParametersError);
        }

        return new $Ku.by.ToolClass.Sql.TranParamsPackage(tmpKuName, tmpPath, tmpMethod, tmpParameterList, tmpValues);
    }

    private boolean isTranKey(java.lang.String f_Key) {
        String pattern = "^S[0-9]+$";
        Pattern tmpPattern = Pattern.compile(pattern);
        Matcher matcher = tmpPattern.matcher(f_Key);
        return matcher.matches();
    }

    public Object parseArray(java.lang.Class<?> f_Type, $Ku.by.JsonUtils.JsonObject f_Obj) {
        if (!f_Type.isArray()) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        if (f_Obj.ContainsKey(MessageRef)) {
            if (f_Obj.keyObjectDic.size() > 1) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            JsonString tmpNode = f_Obj.GetValue(MessageRef);
            if (tmpNode == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            String tmpRefValue = tmpNode.getValue();
            if (!this.InstanceDic.containsKey(tmpRefValue)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
            }

            return this.InstanceDic.get(tmpRefValue);
        }

        if (!f_Obj.ContainsKey(MessageParameterObjType)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
        }

        if (!f_Obj.ContainsKey(MessageID)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        if (!f_Obj.ContainsKey(MessageArrayValue)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        JsonString tmpTypeNode = f_Obj.GetValue(MessageParameterObjType);
        JsonString tmpIdNode = f_Obj.GetValue(MessageID);
        JsonArray tmpArrayNode = f_Obj.GetValue(MessageArrayValue);

        if (tmpTypeNode == null || !tmpTypeNode.getValue().equals(MessageArray)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
        }

        if (tmpIdNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        if (tmpArrayNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        String tmpId = tmpIdNode.getValue();
        ArrayList<IJsonValue> tmpValueList = tmpArrayNode.getValues();
        Class<?> tmpGenericType = f_Type.getComponentType();
        
        
        int size = tmpValueList.size();
        Object array = Array.newInstance(f_Type.getComponentType(), size);
        int count = -1;
        for (IJsonValue item : tmpValueList) {
            count++;
            if (item instanceof JsonNumber) {
                JsonNumber tmpNum = (JsonNumber) item;
                String tmpValue = tmpNum.toString();
                if (tmpGenericType.equals(Byte.class)) {
                    Array.set(array, count, Byte.parseByte(tmpValue));
                    continue;
                }

                if (tmpGenericType.equals(Short.class)) {
                    Array.set(array, count, Short.parseShort(tmpValue));
                    continue;
                }

                if (tmpGenericType.equals(Integer.class)) {
                    Array.set(array, count, Integer.parseInt(tmpValue));
                    continue;
                }

                if (tmpGenericType.equals(Float.class)) {
                    Array.set(array, count, Float.parseFloat(tmpValue));
                    continue;
                }

                if (tmpGenericType.equals(Double.class)) {
                    Array.set(array, count, Double.parseDouble(tmpValue));
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
            }

            if (item instanceof JsonString) {
                JsonString tmpString = (JsonString) item;
                String tmpValue = tmpString.toString();
                if (tmpGenericType.equals(Long.class)) {
                    Array.set(array, count, Long.parseLong(tmpValue));
                    continue;
                }

                if (tmpGenericType.equals($Ku.by.Object.Decimal.class)) {
                    Array.set(array, count, new $Ku.by.Object.Decimal(tmpValue));
                    continue;
                }

                if (tmpGenericType.equals(String.class)) {
                    Array.set(array, count, tmpValue);
                    continue;
                }

                if (tmpGenericType.equals($Ku.by.Object.Datetime.class)) {
                    Array.set(array, count, $Ku.by.Object.Datetime.parse(tmpValue));
                    continue;
                }

                if (tmpGenericType.equals(Character.class)) {
                    Array.set(array, count, tmpValue.charAt(0));
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
            }

            if (item instanceof JsonBool) {
                if (tmpGenericType.equals(Boolean.class)) {
                    JsonBool tmpBool = (JsonBool) item;
                    Array.set(array, count, tmpBool.getValue());
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
            }

            if (item instanceof JsonNull) {
                if (tmpGenericType.isEnum() || tmpGenericType.isPrimitive()) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
                }

                Array.set(array, count, null);
                continue;
            }

            if (item instanceof JsonObject) {
                JsonObject tmpJson = (JsonObject) item;
                if(f_Type.getComponentType().isArray()){

                    Array.set(array, count, parseArray(f_Type.getComponentType(), tmpJson));
                }
                else{

                    Array.set(array, count, parseObject(tmpJson));
                }
                continue;
            }

            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
        }

        this.InstanceDic.put(tmpId, array);
        return array;
    }

    public Object parseList($Ku.by.ToolClass.$ClassMessage f_ValueType, $Ku.by.JsonUtils.JsonObject f_Obj) {
        if (f_Obj.ContainsKey(MessageRef)) {
            if (f_Obj.keyObjectDic.size() > 1) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            JsonString tmpNode = f_Obj.GetValue(MessageRef);
            if (tmpNode == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            String tmpRefValue = tmpNode.getValue();
            if (!this.InstanceDic.containsKey(tmpRefValue)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
            }

            return this.InstanceDic.get(tmpRefValue);
        }

        if (!f_Obj.ContainsKey(MessageParameterObjType)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
        }

        if (!f_Obj.ContainsKey(MessageID)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        if (!f_Obj.ContainsKey(MessageArrayValue)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        JsonString tmpTypeNode = f_Obj.GetValue(MessageParameterObjType);
        JsonString tmpIdNode = f_Obj.GetValue(MessageID);
        JsonArray tmpArrayNode = f_Obj.GetValue(MessageArrayValue);

        if (tmpTypeNode == null || !tmpTypeNode.getValue().equals(MessageList)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
        }

        if (tmpIdNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        if (tmpArrayNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
        }

        String tmpId = tmpIdNode.getValue();
        ArrayList<IJsonValue> tmpValueList = tmpArrayNode.getValues();
        $Ku.by.Object.List<Object> tmpInstance = new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get(f_ValueType.clazz));

        for (IJsonValue item : tmpValueList) {
            if (item instanceof JsonNumber) {
                JsonNumber tmpNum = (JsonNumber) item;
                String tmpValue = tmpNum.toString();
                if (f_ValueType.clazz.equals(Byte.class)) {
                    tmpInstance.add(Byte.parseByte(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Short.class)) {
                    tmpInstance.add(Short.parseShort(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Integer.class)) {
                    tmpInstance.add(Integer.parseInt(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Float.class)) {
                    tmpInstance.add(Float.parseFloat(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Double.class)) {
                    tmpInstance.add(Double.parseDouble(tmpValue));
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
            }

            if (item instanceof JsonString) {
                JsonString tmpString = (JsonString) item;
                String tmpValue = tmpString.getValue();
                if (f_ValueType.clazz.equals(Long.class)) {
                    tmpInstance.add(Long.parseLong(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals($Ku.by.Object.Decimal.class)) {
                    tmpInstance.add(new $Ku.by.Object.Decimal(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(String.class)) {
                    tmpInstance.add(tmpValue);
                    continue;
                }

                if (f_ValueType.clazz.equals($Ku.by.Object.Datetime.class)) {
                    tmpInstance.add($Ku.by.Object.Datetime.parse(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Character.class)) {
                    tmpInstance.add(tmpValue.charAt(0));
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
            }

            if (item instanceof JsonBool) {
                if (f_ValueType.clazz.equals(Boolean.class)) {
                    JsonBool tmpBool = (JsonBool) item;
                    tmpInstance.add(tmpBool.getValue());
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
            }

            if (item instanceof JsonNull) {
                if (f_ValueType.clazz.isEnum() || f_ValueType.clazz.isPrimitive()) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
                }

                tmpInstance.add(null);
                continue;
            }

            if (item instanceof JsonObject) {
                //泛型嵌套的情况
                if(f_ValueType.clazz == $Ku.by.Object.Dictionary.class){
                    tmpInstance.add(parseDictionary(f_ValueType.typeArguments[0], f_ValueType.typeArguments[1], (JsonObject) item));
                    continue;
                }

                if(f_ValueType.clazz == $Ku.by.Object.List.class){
                    tmpInstance.add(parseList(f_ValueType.typeArguments[0], (JsonObject) item));
                    continue;
                }

                JsonObject tmpJson = (JsonObject) item;
                try {
                    tmpInstance.add(parseObject(tmpJson));
                } catch (java.lang.Exception e) {
                    throw new RuntimeException(e);
                }
                continue;
            }

            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
        }

        this.InstanceDic.put(tmpId, tmpInstance);
        return tmpInstance;
    }

    public Object parseDictionary($Ku.by.ToolClass.$ClassMessage f_KeyType, $Ku.by.ToolClass.$ClassMessage f_ValueType, $Ku.by.JsonUtils.JsonObject f_Obj) {
        if(f_Obj.ContainsKey(MessageRef)){
            if(f_Obj.keyObjectDic.size() > 1){
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }
            JsonString tmpNode = f_Obj.GetValue(MessageRef);
            if(tmpNode == null){
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            String tmpRefValue = tmpNode.getValue();
            if(!this.InstanceDic.containsKey(tmpRefValue)){
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
            }
            return this.InstanceDic.get(tmpRefValue);
        }

        if(!f_Obj.ContainsKey(MessageParameterObjType)){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
        }

        if(!f_Obj.ContainsKey(MessageID)){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDicError);
        }

        if(!f_Obj.ContainsKey(MessageKey)){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDicError);
        }

        if(!f_Obj.ContainsKey(MessageDicValue)){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDicError);
        }

        JsonString tmpTypeNode = f_Obj.GetValue(MessageParameterObjType);
        JsonString tmpIdNode = f_Obj.GetValue(MessageID);
        JsonArray tmpKeyNode = f_Obj.GetValue(MessageKey);
        JsonArray tmpValueNode = f_Obj.GetValue(MessageDicValue);

        if(tmpTypeNode == null || !tmpTypeNode.getValue().equals(MessageDictionary)){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
        }

        if(tmpIdNode == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDicError);
        }

        if(tmpKeyNode == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDicError);
        }

        if(tmpValueNode == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDicError);
        }

        String tmpId = tmpIdNode.getValue();
        ArrayList<IJsonValue> tmpKeyList = tmpKeyNode.getValues();
        ArrayList<IJsonValue> tmpValueList = tmpValueNode.getValues();

        ArrayList<Object> tmpKeyInstance = new ArrayList<>();
        ArrayList<Object> tmpValueInstance = new ArrayList<>();

        for (IJsonValue item : tmpKeyList){
            if(item instanceof JsonNumber){
                JsonNumber tmpNum = (JsonNumber) item;
                String tmpValue = tmpNum.getNumberStr();
                if(f_KeyType.clazz.equals(Byte.class)){
                    tmpKeyInstance.add(Byte.parseByte(tmpValue));
                    continue;
                }

                if (f_KeyType.clazz.equals(Short.class)) {
                    tmpKeyInstance.add(Short.parseShort(tmpValue));
                    continue;
                }

                if (f_KeyType.clazz.equals(Integer.class)) {
                    tmpKeyInstance.add(Integer.parseInt(tmpValue));
                    continue;
                }

                if (f_KeyType.clazz.equals(Float.class)) {
                    tmpKeyInstance.add(Float.parseFloat(tmpValue));
                    continue;
                }

                if (f_KeyType.clazz.equals(Double.class)) {
                    tmpKeyInstance.add(Double.parseDouble(tmpValue));
                    continue;
                }

                if(f_KeyType.clazz.equals(Object.class)){
                    tmpKeyInstance.add(Double.parseDouble(tmpValue));
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);
            }

            if(item instanceof JsonString){
                JsonString tmpString = (JsonString) item;
                String tmpValue = tmpString.getValue();
                if (f_KeyType.clazz.equals(Long.class)) {
                    tmpKeyInstance.add(Long.parseLong(tmpValue));
                    continue;
                }

                if (f_KeyType.clazz.equals($Ku.by.Object.Decimal.class)) {
                    tmpKeyInstance.add(new $Ku.by.Object.Decimal(tmpValue));
                    continue;
                }

                if (f_KeyType.clazz.equals($Ku.by.Object.Datetime.class)) {
                    tmpKeyInstance.add($Ku.by.Object.Datetime.parse(tmpValue));
                    continue;
                }

                if (f_KeyType.clazz.equals(Character.class)) {
                    tmpKeyInstance.add(tmpValue.charAt(0));
                    continue;
                }

                if (f_KeyType.clazz.equals(String.class) || f_KeyType.clazz.equals(Object.class)) {
                    tmpKeyInstance.add(tmpValue);
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);

            }

            if(item instanceof JsonBool){
                if (f_KeyType.clazz.equals(Boolean.class) || f_KeyType.clazz.equals(Object.class)) {
                    JsonBool tmpBool = (JsonBool) item;
                    tmpKeyInstance.add(tmpBool.getValue());
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);
            }

            if(item instanceof JsonNull){
                if (f_KeyType.clazz.isEnum() || f_KeyType.clazz.isPrimitive()) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);
                }

                tmpKeyInstance.add(null);
                continue;
            }

            if(item instanceof JsonObject){
                //泛型嵌套的情况
                if(f_KeyType.clazz == $Ku.by.Object.Dictionary.class){
                    //key为By Dic类型
                    tmpKeyInstance.add(parseDictionary(f_KeyType.typeArguments[0], f_KeyType.typeArguments[1], (JsonObject) item));
                    continue;
                }

                if(f_KeyType.clazz == $Ku.by.Object.List.class){
                    //key为By List类型
                    tmpKeyInstance.add(parseList(f_KeyType.typeArguments[0], (JsonObject) item));
                    continue;
                }

                JsonObject tmpJson = (JsonObject) item;
                try {
                    tmpKeyInstance.add(parseObject(tmpJson));
                } catch (java.lang.Exception e) {
                    throw new RuntimeException(e);
                }
                continue;
            }
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
        }

        for (IJsonValue item : tmpValueList){
            if(item instanceof JsonNumber){
                JsonNumber tmpNum = (JsonNumber) item;
                String tmpValue = tmpNum.getNumberStr();
                if(f_ValueType.clazz.equals(Byte.class)){
                    tmpValueInstance.add(Byte.parseByte(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Short.class)) {
                    tmpValueInstance.add(Short.parseShort(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Integer.class)) {
                    tmpValueInstance.add(Integer.parseInt(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Float.class)) {
                    tmpValueInstance.add(Float.parseFloat(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Double.class)) {
                    tmpValueInstance.add(Double.parseDouble(tmpValue));
                    continue;
                }

                if(f_ValueType.clazz.equals(Object.class)){
                    tmpValueInstance.add(Double.parseDouble(tmpValue));
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);

            }

            if(item instanceof JsonString){
                JsonString tmpString = (JsonString) item;
                String tmpValue = tmpString.getValue();
                if (f_ValueType.clazz.equals(Long.class)) {
                    tmpValueInstance.add(Long.parseLong(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals($Ku.by.Object.Decimal.class)) {
                    tmpValueInstance.add(new $Ku.by.Object.Decimal(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals($Ku.by.Object.Datetime.class)) {
                    tmpValueInstance.add($Ku.by.Object.Datetime.parse(tmpValue));
                    continue;
                }

                if (f_ValueType.clazz.equals(Character.class)) {
                    tmpValueInstance.add(tmpValue.charAt(0));
                    continue;
                }

                if (f_ValueType.clazz.equals(String.class) || f_ValueType.clazz.equals(Object.class)) {
                    tmpValueInstance.add(tmpValue);
                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);

            }

            if(item instanceof JsonBool){
                if (f_ValueType.clazz.equals(Boolean.class) || f_ValueType.clazz.equals(Object.class)) {
                    JsonBool tmpBool = (JsonBool) item;
                    tmpValueInstance.add(tmpBool.getValue());
                    continue;
                }
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);
            }

            if(item instanceof JsonNull){
                if (f_ValueType.clazz.isEnum() || f_ValueType.clazz.isPrimitive()) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);
                }

                tmpValueInstance.add(null);
                continue;
            }

            if(item instanceof JsonObject){
                //可能是嵌套的List或者Dic
                //泛型嵌套的情况
                if(f_ValueType.clazz == $Ku.by.Object.Dictionary.class){
                    //key为By Dic类型
                    tmpValueInstance.add(parseDictionary(f_ValueType.typeArguments[0], f_ValueType.typeArguments[1], (JsonObject) item));
                    continue;
                }

                if(f_ValueType.clazz == $Ku.by.Object.List.class){
                    //key为By List类型
                    tmpValueInstance.add(parseList(f_ValueType.typeArguments[0], (JsonObject) item));
                    continue;
                }

                JsonObject tmpJson = (JsonObject) item;
                try {
                    tmpValueInstance.add(parseObject(tmpJson));
                } catch (java.lang.Exception e) {
                    throw new RuntimeException(e);
                }
                continue;
            }
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedDicType);
        }

        $Ku.by.Object.Dictionary<Object, Object> tmpInstance = new $Ku.by.Object.Dictionary<>(f_KeyType, f_ValueType);

        int size = tmpKeyInstance.size();
        for(int i = 0; i < size; i++){
            tmpInstance.add(tmpKeyInstance.get(i), tmpValueInstance.get(i));
        }
        this.InstanceDic.put(tmpId, tmpInstance);
        return tmpInstance;
    }

    public Object parseObject($Ku.by.JsonUtils.JsonObject f_Obj) {
        if (f_Obj.ContainsKey(MessageRef)) {
            if (f_Obj.keyObjectDic.size() > 1) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            JsonString tmpNode =  f_Obj.GetValue(MessageRef);
            if (tmpNode == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            String tmpRefValue = tmpNode.getValue();
            if (!this.InstanceDic.containsKey(tmpRefValue)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
            }

            return this.InstanceDic.get(tmpRefValue);
        }

        if (!f_Obj.ContainsKey(MessageParameterObjType)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIllegalJsonObj);
        }
        JsonString tmpObjType =  f_Obj.GetValue(MessageParameterObjType);
        if (tmpObjType == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsTypeError);
        }
        String tmpTypeValue = tmpObjType.getValue();

        if (tmpTypeValue.equals(MessageArray)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
        }


        switch (tmpTypeValue) {
            case MessageQuery:
                //说明是查询区
                return parseQueryDataValue(f_Obj);
            case MessageRow:
                //说明是行
                return parseRow(f_Obj);
            case MessageOrm:
                if (!f_Obj.ContainsKey(MessageType)) {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
                }

                JsonString tmpOrmNameNode = f_Obj.GetValue(MessageType);

                if (tmpOrmNameNode == null) {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
                }

                String tmpName = tmpOrmNameNode.getValue();

                if (!Root.GetInstance().OrmTypeDic.containsKey(tmpName)) {
                    ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CanNotFindOrmType, tmpName));
                }

                return parseOrm(f_Obj, Root.GetInstance().OrmTypeDic.get(tmpName).value);
            default:
                //说明是用户自定义类型的对象
                if (!f_Obj.ContainsKey(MessageType)) {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceNameError);
                }

                JsonString tmpTypeNode = f_Obj.GetValue(MessageType);

                if (tmpTypeNode == null) {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
                }

                String tmpObjTypeName = tmpTypeNode.getValue();
                String[] tmpNames = tmpObjTypeName.split("\\.");

                if (tmpNames.length != 2) {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
                }

                String tmpKuName = tmpNames[0];
                String tmpObjName = tmpNames[1];

                if (Root.GetInstance().ReNamedObjDicKeyIsOld.containsKey(tmpObjTypeName)) {
                    tmpObjName = Root.GetInstance().ReNamedObjDicKeyIsOld.get(tmpObjTypeName);
                }

                String tmpTypePath = "$Ku." + tmpKuName + ".Object." + tmpObjName;
                try {
                    return parseUserDefinedObject(tmpKuName, Class.forName(tmpTypePath), f_Obj);
                } catch (ClassNotFoundException e) {
                    throw new RuntimeException(e);
                }
        }
    }

    public java.util.ArrayList<$Ku.by.Object.Row> parseRows($Ku.by.JsonUtils.JsonArray f_Rows) {
        ArrayList<$Ku.by.Object.Row> tmpRows = new ArrayList<>();

        for (IJsonValue item : f_Rows.getValues()) {
            if (item instanceof JsonNull) {
                tmpRows.add(null);
                continue;
            }

            if (!(item instanceof JsonObject)) {
                throw new RuntimeException(ErrorInfo.ParseIllegalRow);
            }

            JsonObject tmpRow = (JsonObject) item;

            if (!tmpRow.ContainsKey(MessageParameterObjType)) {
                throw new RuntimeException(ErrorInfo.ParseIllegalRow);
            }

           JsonString tmpTypeNode = tmpRow.GetValue(MessageParameterObjType);

            if (tmpTypeNode == null) {
                throw new RuntimeException(ErrorInfo.ParseParameterObjTypeError);
            }

            if (!tmpTypeNode.getValue().equals(MessageRow)) {
                throw new RuntimeException(ErrorInfo.ParseIllegalRow);
            }

            tmpRows.add(parseRow(tmpRow));
        }

        return tmpRows;
    }

    public $Ku.by.Object.Row parseRow($Ku.by.JsonUtils.JsonObject f_RowObj) {
        if (f_RowObj.ContainsKey(MessageRef)) {
            if (f_RowObj.keyObjectDic.size() > 1) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            JsonString tmpNode = f_RowObj.GetValue(MessageRef);

            if (tmpNode == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            String tmpRefValue = tmpNode.getValue();

            if (!this.InstanceDic.containsKey(tmpRefValue)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
            }

            Object tmpRow = this.InstanceDic.get(tmpRefValue);

            if (!(tmpRow instanceof $Ku.by.Object.Row)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIllegalRow);
            }

            return ($Ku.by.Object.Row) tmpRow;
        }

        if (!f_RowObj.ContainsKey(MessageFields) || !f_RowObj.ContainsKey(MessageValues) || !f_RowObj.ContainsKey(MessageDollarIdentity)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIllegalRow);
        }

        JsonArray tmpCellNameArray = f_RowObj.GetValue(MessageFields);
        JsonArray tmpCellValueArray = f_RowObj.GetValue(MessageValues);

        if (tmpCellNameArray != null && tmpCellValueArray != null && tmpCellNameArray.getValues().size() != tmpCellValueArray.getValues().size()) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRowColumnsError);
        }

        $Ku.by.Object.Row tmpNewRow = new $Ku.by.Object.Row();

        for(int i = 0; i < tmpCellNameArray.size(); i++){
            JsonString tmpFieldNameJsonString = tmpCellNameArray.GetValue(i);
            IJsonValue tmpCellValue = tmpCellValueArray.GetValue(i);

            if(tmpFieldNameJsonString == null){
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRowColumnsError);
            }

            String tmpFieldName = tmpFieldNameJsonString.getValue();
            $Ku.by.Object.Cell tmpCell = this.parseField(tmpFieldName);

            tmpCell.row = tmpNewRow;

            if(tmpCellValue instanceof JsonString){
                JsonString tmpStringValue = (JsonString) tmpCellValue;
                tmpCell.value = tmpStringValue.getValue();
            }

            if(tmpCellValue instanceof JsonNumber){
                JsonNumber tmpNumValue = (JsonNumber) tmpCellValue;
                String[] tmpNumArray = tmpNumValue.getNumberStr().split("\\.");
                if(tmpNumArray.length == 1){
                    tmpCell.value = Integer.valueOf(tmpNumValue.getNumberStr());
                }
                else if(tmpNumArray.length == 2){
                    tmpCell.value = Double.valueOf(tmpNumValue.getNumberStr());
                }else {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.JsonNumParseError, tmpCellValue.toString()));
                }
            }

            if(tmpCellValue instanceof JsonBool){
                JsonBool tmpBoolValue = (JsonBool) tmpCellValue;
                tmpCell.value = tmpBoolValue.getValue();
                tmpCell.DataTypeEnum = DataTypeEnum.Bool;
            }

            if(tmpCellValue instanceof JsonNull){
                tmpCell.value = null;
            }

            if(tmpCellValue instanceof JsonObject){
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.CellValueTypeError);
            }
            tmpNewRow.cells.add(tmpCell);
        }

        if(f_RowObj.GetValue(MessageDollarIdentity) instanceof JsonNull){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
        }

        JsonObject tmpIdentityObj = f_RowObj.GetValue(MessageDollarIdentity);
        tmpNewRow.$Identity = this.parseIdentity(tmpIdentityObj);
        tmpNewRow.setKuName(tmpNewRow.$Identity.ku);

        JsonString tmpInstanceID = f_RowObj.GetValue(MessageID);

        if(tmpInstanceID == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
        }

        String tmpID = tmpInstanceID.getValue();

        if(this.InstanceDic.containsKey(tmpID)){
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
        }
        this.InstanceDic.put(tmpID, tmpNewRow);

        return tmpNewRow;
    }

    public $Ku.by.Object.QueryData parseQueryDataValue($Ku.by.JsonUtils.JsonObject f_QueryObj) {
        if (!f_QueryObj.ContainsKey(MessageID)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
        }
        if (!f_QueryObj.ContainsKey(MessageSheetName)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryParamsSheetNodeMissing);
        }
        if (!f_QueryObj.ContainsKey(MessageDollarVA)) {
            ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryValueMissing);
        }

        if (!f_QueryObj.ContainsKey(MessageSS)) {
            ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryNameError);
        }

        JsonString tmpSheetNameNode = f_QueryObj.GetValue(MessageSheetName);
        JsonArray tmpSourceNamesNode = f_QueryObj.GetValue(MessageSS);
        JsonArray tmpValueNode = f_QueryObj.GetValue(MessageDollarVA);
        JsonString tmpIdNode = f_QueryObj.GetValue(MessageID);

        if (tmpSheetNameNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSheetNameError);
        }
        if (tmpSourceNamesNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryNameError);
        }
        if (tmpValueNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryValueError);
        }
        if (tmpIdNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
        }

        String tmpId = tmpIdNode.getValue();
        String[] tmpSheetArray = tmpSheetNameNode.getValue().split("\\.");

        if (tmpSheetArray.length != 2) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSheetNameFormatError);
        }

        if (f_QueryObj.GetValue(MessageSheetName) instanceof JsonNull
                || f_QueryObj.GetValue(MessageSS) instanceof JsonNull
                || f_QueryObj.GetValue(MessageDollarVA) instanceof JsonNull) {
            if (!(f_QueryObj.GetValue(MessageSheetName) instanceof JsonNull
                    && f_QueryObj.GetValue(MessageSS) instanceof JsonNull
                    && f_QueryObj.GetValue(MessageDollarVA) instanceof JsonNull)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException("空查询区格式填充错误");
            }

            this.InstanceDic.put(tmpId, null);
            return null;
        }

        String tmpKuName = tmpSheetArray[0];
        String tmpSheetName = tmpSheetArray[1];
        ArrayList<IJsonValue> tmpSourceNames = tmpSourceNamesNode.getValues();
        IBaseDataSheet tmpDataSheet = ToolFunction.GetDataSheet(tmpKuName, tmpSheetName);

        if (tmpSourceNames.size() != tmpValueNode.size()) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryValueCountNotMatch);
        }

        ArrayList<IJsonValue> tmpValueList = tmpValueNode.getValues();
        java.util.LinkedHashMap<Source, Object> tmpDic = new java.util.LinkedHashMap<>();

        for (int i = 0; i < tmpValueList.size(); i++) {
            IJsonValue tmpObj = tmpValueList.get(i);
            JsonString tmpSourceNameNode = (JsonString) tmpSourceNames.get(i);
            if (tmpSourceNameNode == null) {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.QueryAreaParameterError);
            }

            String tmpSourceName = tmpSourceNameNode.getValue();
            Source tmpSource = tmpDataSheet.getSourceDic().get(tmpSourceName);
            if (tmpSource == null) {
                ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.ParseCanNotFindSource, tmpDataSheet.getSheetName(), tmpSourceName));
            }

            if (tmpObj instanceof JsonString) {
                JsonString tmpObjInstance = (JsonString) tmpObj;
                tmpDic.put(tmpSource, tmpObjInstance.getValue());
                continue;
            }

            if (tmpObj instanceof JsonNumber) {
                JsonNumber tmpObjInstance = (JsonNumber) tmpObj;
                tmpDic.put(tmpSource, tmpObjInstance.toString());
                continue;
            }

            if (tmpObj instanceof JsonArray) {
                JsonArray tmpObjInstance = (JsonArray) tmpObj;
                tmpDic.put(tmpSource, this.parseQueryBetween(tmpObjInstance));
                continue;
            }

            if (tmpObj instanceof JsonNull) {
                tmpDic.put(tmpSource, null);
                continue;
            }


            if (tmpObj instanceof JsonBool) {
                JsonBool tmpObjInstance = (JsonBool) tmpObj;
                tmpDic.put(tmpSource, tmpObjInstance.getValue());
                continue;
            }
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIllegalQueryValue);
        }
        $Ku.by.ToolClass.Sql.QueryDataParameter tmpNewQuery = new $Ku.by.ToolClass.Sql.QueryDataParameter(tmpDic);
        QueryData tmpReturnValue = new $Ku.by.Object.QueryData();
        tmpReturnValue._QueryDataParameter = tmpNewQuery;
        tmpReturnValue.values = tmpNewQuery.getValueDic().values().toArray();
        tmpReturnValue.table = ($Ku.by.Object.Table)tmpDataSheet;
        tmpReturnValue.Identity = tmpReturnValue.table.$Identity;
        this.InstanceDic.put(tmpId, tmpReturnValue);
        return tmpReturnValue;
    }

    public java.util.ArrayList<java.lang.String> parseQueryBetween($Ku.by.JsonUtils.JsonArray f_Array) {
        ArrayList<String> tmpList = new ArrayList<>();
        ArrayList<IJsonValue> tmpValueList = f_Array.getValues();
        if (tmpValueList.size() != 2) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIllegalBetweenLength);
        }

        IJsonValue tmpValue1Node = tmpValueList.get(0);
        IJsonValue tmpValue2Node = tmpValueList.get(1);
        if (tmpValue1Node instanceof JsonNull || tmpValue2Node instanceof JsonNull) {
            if (!(tmpValue1Node instanceof JsonNull && tmpValue2Node instanceof JsonNull)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseBetweenValueIsNull);
            } else {
                return null;
            }
        }

        String tmpValue1 = this.getStringOrNumValue(tmpValue1Node);
        String tmpValue2 = this.getStringOrNumValue(tmpValue2Node);
        if (tmpValue1 == null || tmpValue2 == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseBetweenValueIsNull);
        }
        tmpList.add(tmpValue1);
        tmpList.add(tmpValue2);
        return tmpList;
    }

    public java.lang.String getStringOrNumValue($Ku.by.JsonUtils.IJsonValue f_Value) {
        if (f_Value instanceof JsonString) {
            JsonString tmpValue = (JsonString) f_Value;
            return tmpValue.getValue();
        }

        if (f_Value instanceof JsonNumber) {
            JsonNumber tmpValue = (JsonNumber) f_Value;
            return tmpValue.toString();
        }

        return null;
    }

    public Object parseUserDefinedObject(java.lang.String f_KuName, java.lang.Class<?> f_Type, $Ku.by.JsonUtils.JsonObject f_Obj) {
        if (f_Obj.ContainsKey(MessageRef)) {
            if (f_Obj.keyObjectDic.size() > 1) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            JsonString tmpNode = f_Obj.GetValue(MessageRef);
            if (tmpNode == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
            }

            String tmpRefValue = tmpNode.getValue();
            if (!this.InstanceDic.containsKey(tmpRefValue)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
            }

            return this.InstanceDic.get(tmpRefValue);
        }

        if (!f_Obj.ContainsKey(MessageID)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseObjectError);
        }

        JsonString tmpIdNode = f_Obj.GetValue(MessageID) ;

        if (tmpIdNode == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseObjectError);
        }

        if (!f_Obj.ContainsKey(MessageDollarIdentity)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
        }

        String tmpId = tmpIdNode.getValue();
        if (this.InstanceDic.containsKey(tmpId)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ConflictInstance);
        }
        java.lang.reflect.Field[] tmpProperty = f_Type.getFields();
        Object tmpInstance;
        try {
            tmpInstance = f_Type.newInstance();
        } catch (InstantiationException | IllegalAccessException e) {
            throw new RuntimeException(e);
        }
        java.util.LinkedHashMap<String, String> tmpReNamedPropDic = new java.util.LinkedHashMap<>();

        if (Root.GetInstance().ReNamedPropDicKeyIsOld.containsKey(f_KuName)) {
            tmpReNamedPropDic = Root.GetInstance().ReNamedPropDicKeyIsOld.get(f_KuName);
        }

        for (java.lang.reflect.Field item : tmpProperty) {
            String tmpPropName = item.getName();
            if (!tmpReNamedPropDic.isEmpty()) {
                String tmpComparedName = f_Type.getName() + "." + tmpPropName;
                if (tmpReNamedPropDic.containsKey(tmpComparedName)) {
                    String tmpQualifiedObjName = tmpReNamedPropDic.get(tmpComparedName);
                    tmpPropName = tmpQualifiedObjName.split("\\.")[1];
                }
            }

            if (!f_Obj.ContainsKey(tmpPropName) && !tmpPropName.equals("$Identity")) {
                $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
            }

            if (tmpPropName.equals("$Identity")) {
                IJsonValue tmpIdentityNode = f_Obj.GetValue(MessageDollarIdentity);
                if (tmpIdentityNode instanceof JsonNull) {
                    continue;
                } else {
                    JsonObject tmpIdentity = (JsonObject) tmpIdentityNode;
                    if (tmpIdentity != null) {
                        try {
                            item.set(tmpInstance, this.parseIdentity(tmpIdentity));
                        } catch (IllegalAccessException e) {
                            throw new RuntimeException(e);
                        }
                    }
                }
            }
            //不可能有查询区类型，

            if (item.getType() == this.byteByte) {
                JsonNumber tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, Byte.parseByte(tmpValue.toString()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == this.shortType) {
                JsonNumber tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, Short.parseShort(tmpValue.toString()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == this.intType) {
                JsonNumber tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, Integer.parseInt(tmpValue.toString()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == this.longType) {
                JsonString tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, Long.parseLong(tmpValue.getValue()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == this.floatType) {
                JsonNumber tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, Float.parseFloat(tmpValue.toString()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == this.doubleType) {
                JsonNumber tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, Double.parseDouble(tmpValue.toString()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == this.decimalType) {
                JsonString tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, new $Ku.by.Object.Decimal(tmpValue.getValue()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == this.boolType) {
                JsonBool tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, tmpValue.getValue());
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == this.charType) {
                JsonString tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, $Ku.by.ToolClass.ToolFunction.parseChar(tmpValue.getValue()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == String.class) {
                if (f_Obj.GetValue(tmpPropName) instanceof JsonNull) {
                    try {
                        item.set(tmpInstance, null);
                    } catch (IllegalAccessException e) {
                        throw new RuntimeException(e);
                    }
                    continue;
                }
                JsonString tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, tmpValue.getValue());
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else if (item.getType() == dateTimeType) {
                if (f_Obj.GetValue(tmpPropName) instanceof JsonNull) {
                    try {
                        item.set(tmpInstance, null);
                    } catch (IllegalAccessException e) {
                        throw new RuntimeException(e);
                    }
                    continue;
                }
                JsonString tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(String.format(ErrorInfo.CannotFindProp, tmpPropName));
                }
                try {
                    item.set(tmpInstance, $Ku.by.Object.Datetime.parse(tmpValue.getValue()));
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            } else {
                if (f_Obj.GetValue(tmpPropName) instanceof JsonNull) {
                    try {
                        item.set(tmpInstance, null);
                    } catch (IllegalAccessException e) {
                        throw new RuntimeException(e);
                    }
                    this.InstanceDic.put(tmpId, null);
                    continue;
                }

                Class<?> tmpType = item.getType();

                JsonObject tmpValue = f_Obj.GetValue(tmpPropName);
                if (tmpValue == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ObjectPropError);
                }
                if(tmpType==$Ku.by.Object.List.class){
                    try {
                        item.set(tmpInstance, parseList(Root.GetInstance().ObjProListTypeDic.get(f_Type).get(tmpPropName), tmpValue));
                    } catch (IllegalAccessException e) {
                        throw new RuntimeException(e);
                    }
                }
                else if(tmpType==$Ku.by.Object.Dictionary.class){
                    try {
                        item.set(tmpInstance, parseDictionary(
                                Root.GetInstance().ObjProDicKeyTypeDic.get(f_Type).get(tmpPropName),
                                Root.GetInstance().ObjProDicValueTypeDic.get(f_Type).get(tmpPropName),
                                tmpValue));
                    } catch (IllegalAccessException e) {
                        throw new RuntimeException(e);
                    }
                }
                else if (item.getType().isArray()) {
                    try {
                        item.set(tmpInstance, parseArray(item.getType(), tmpValue));
                    } catch (IllegalAccessException e) {
                        throw new RuntimeException(e);
                    }
                } else {
                    Object tmpObj;
                    try {
                        tmpObj = parseObject(tmpValue);
                    } catch (java.lang.Exception e) {
                        throw new RuntimeException(e);
                    }
                    if (tmpType != tmpObj.getClass()) {
                        $Ku.by.ToolClass.ThrowHelper.ThrowParseTransferException(ErrorInfo.ObjectPropError);
                    }
                    try {
                        item.set(tmpInstance, tmpObj);
                    } catch (IllegalAccessException e) {
                        throw new RuntimeException(e);
                    }
                }
            }
        }
        this.InstanceDic.put(tmpId, tmpInstance);
        return tmpInstance;
    }

    public $Ku.by.Object.Cell parseField(java.lang.String f_JsonField) {
        $Ku.by.Object.Cell tmpReturnValue = new $Ku.by.Object.Cell();
        String pattern1 = "\\((.*?)\\)";
        String pattern2 = "\\[(.*?)\\]";
        //"COUNT(ku.biao.field)"
        if(f_JsonField.contains("(") && f_JsonField.endsWith(")")){
            Pattern pattern = Pattern.compile(pattern1);
            Matcher matcher = pattern.matcher(f_JsonField);
            int count = 0;
            String tmpFieldValue = "";
            while (matcher.find()){
                tmpFieldValue = matcher.group();
                count++;
            }
            if(count != 1){
                throw new RuntimeException();
            }
            String[] tmpFieldSplit = tmpFieldValue.substring(1, tmpFieldValue.length()-1).split("\\.");

            if(tmpFieldSplit.length != 3){
                throw new RuntimeException();
            }
            String tmpFieldKuName = tmpFieldSplit[0];
            String tmpFieldSheetName = tmpFieldSplit[1];
            String tmpFieldName = tmpFieldSplit[2];
            int tmpStartIndex = f_JsonField.indexOf('(');
            String tmpAggregateFunctionName = f_JsonField.substring(0, tmpStartIndex);
            $Ku.by.Object.Table tmpFieldTable;

            try{
                tmpFieldTable = ($Ku.by.Object.Table) ToolFunction.GetDataSheet(tmpFieldKuName, tmpFieldSheetName);
            }catch (java.lang.Exception e){
                throw new RuntimeException(e);
            }
            if(tmpFieldTable.getField(tmpFieldName) == null){
                throw new RuntimeException();
            }
            $Ku.by.Object.Field tmpField = tmpFieldTable.getField(tmpFieldName);

            try{
                FunctionEnum tmpFunc = Enum.valueOf(FunctionEnum.class, tmpAggregateFunctionName);
                if(tmpFunc == FunctionEnum.NONE){
                    throw new RuntimeException();
                }

                tmpReturnValue.AggregateFunctionName = tmpFunc.name();

                if(tmpFunc == FunctionEnum.COUNT){
                    tmpReturnValue.DataTypeEnum = DataTypeEnum.Int;
                }
                else{
                    tmpReturnValue.DataTypeEnum = tmpField.Field.getFieldType();
                }
            }catch (java.lang.Exception e){
                throw new RuntimeException();
            }

            tmpReturnValue.KuName = tmpFieldKuName;
            tmpReturnValue.SheetName = tmpFieldSheetName;
            tmpReturnValue.ColumnName = tmpFieldName;
            tmpReturnValue.cellField = tmpField;

        }
        //"[int]a"
        if(f_JsonField.contains("[") && f_JsonField.contains("]")){
            Pattern pattern = Pattern.compile(pattern2);
            Matcher matcher = pattern.matcher(f_JsonField);
            int count = 0;
            String tmpTypeName = "";

            while(matcher.find()){
                tmpTypeName = matcher.group();
                count++;
            }

            if(count != 1){
                throw new RuntimeException();
            }
            tmpTypeName = tmpTypeName.substring(1, tmpTypeName.length() - 1);
            tmpTypeName = this.firstCharacterToUpper(tmpTypeName);
            DataTypeEnum tmpDataType;

            try{
                if(tmpTypeName.split("\\.").length != 1){
                    //说明是枚举类型
                    tmpDataType = DataTypeEnum.Enum;
                    String[] tmpEnumSplit = tmpTypeName.split("\\.");
                    if(tmpEnumSplit.length != 3){
                        throw new RuntimeException();
                    }
                    String tmpEnumTypePath = "$Ku." + tmpEnumSplit[0] + ".Enum." + tmpEnumSplit[2];
                    tmpReturnValue.EnumType = Class.forName(tmpEnumTypePath);
                }
                else{
                    tmpDataType = Enum.valueOf(DataTypeEnum.class, tmpTypeName);
                }
            }catch (java.lang.Exception e){
                throw new RuntimeException();
            }

            tmpReturnValue.DataTypeEnum = tmpDataType;
            int tmpAliasIndex = f_JsonField.lastIndexOf("]") + 1;

            if(tmpAliasIndex != f_JsonField.length()){
                //说明有别名
                String tmpAlias = f_JsonField.substring(tmpAliasIndex);
                tmpReturnValue.alias = tmpAlias;


            }
            tmpReturnValue.ColumnName = tmpDataType.name();
            return tmpReturnValue;

        }
        //"ku.biao.field"
        String[] tmpSplit = f_JsonField.split("\\.");

        if(tmpSplit.length != 3){
            throw new RuntimeException();
        }

        String tmpKuName = tmpSplit[0];
        String tmpSheetName = tmpSplit[1];
        String tmpName = tmpSplit[2];
        $Ku.by.Object.Table tmpTable;

        try{
            tmpTable = ($Ku.by.Object.Table) ToolFunction.GetDataSheet(tmpKuName, tmpSheetName);
        }catch (java.lang.Exception e){
            throw new RuntimeException();
        }
        $Ku.by.Object.Field tmpCellField = tmpTable.getField(tmpName);
        tmpReturnValue.KuName = tmpKuName;
        tmpReturnValue.SheetName = tmpSheetName;
        tmpReturnValue.ColumnName = tmpName;
        tmpReturnValue.cellField = tmpCellField;
        tmpReturnValue.DataTypeEnum = tmpCellField.Field.getFieldType();
        tmpReturnValue.EnumType = tmpCellField.Field.getEnumType();
        return tmpReturnValue;
    }

    public java.lang.String firstCharacterToUpper(java.lang.String input) {
        if(input == null){
            return null;
        }
        if(input.length() == 0){
            return "";
        }
        return input.substring(0,1).toUpperCase() + input.substring(1, input.length());
    }

    public Object parseOrm($Ku.by.JsonUtils.JsonObject f_OrmObj, $Ku.by.Object.IOrmType f_OrmType) {
        if(!f_OrmObj.ContainsKey(MessageID) || !f_OrmObj.ContainsKey(MessageFields) || !f_OrmObj.ContainsKey(MessageType) || !f_OrmObj.ContainsKey(MessageValues) || !f_OrmObj.ContainsKey(MessageDollarIdentitys)
        || !f_OrmObj.ContainsKey(MessageFieldsMap) || !f_OrmObj.ContainsKey(MessageTablesMap)){
            throw new RuntimeException();
        }

        JsonString tmpIDNode = f_OrmObj.GetValue(MessageID);
        JsonArray tmpFieldsNode = f_OrmObj.GetValue(MessageFields);
        JsonArray tmpValuesNode = f_OrmObj.GetValue(MessageValues);
        JsonString tmpParameterTypeNode = f_OrmObj.GetValue(MessageParameterObjType);
        JsonArray tmpIdentitysNode = f_OrmObj.GetValue(MessageDollarIdentitys);
        JsonObject tmpFieldsMap = f_OrmObj.GetValue(MessageFieldsMap);
        JsonObject tmpTablesMap = f_OrmObj.GetValue(MessageTablesMap);
        ArrayList<OrmField> tmpOrmFields = new ArrayList<>();
        HashMap<String, ArrayList<Integer>> tmpOrmTables = new HashMap<>();



        if(tmpIDNode == null || tmpFieldsNode == null || tmpValuesNode == null || tmpIdentitysNode == null || tmpParameterTypeNode == null || tmpFieldsMap == null || tmpTablesMap == null){
            throw new RuntimeException();
        }
        if(!tmpParameterTypeNode.getValue().equals(MessageOrm)){
            throw new RuntimeException();
        }
        if(tmpFieldsNode.size() != tmpValuesNode.size()){
            throw new RuntimeException();
        }
        tmpFieldsMap.keyObjectDic.forEach((key, value) -> {
            tmpOrmFields.add(new OrmField(key, Integer.valueOf(((JsonNumber)value).getNumberStr())));
        });
        tmpTablesMap.keyObjectDic.forEach((key, value) ->{
            ArrayList<Integer> indexes = new ArrayList<>();
            JsonArray tmpJsIndexes = (JsonArray) value;
            for(IJsonValue index : tmpJsIndexes.getValues()){
                indexes.add(Integer.valueOf(((JsonNumber)index).getNumberStr()));
            }
            tmpOrmTables.put(key, indexes);
        });
        ArrayList<$Ku.by.Object.Cell> tmpCells = new ArrayList<>();
        $Ku.by.Object.Row tmpNewRow = new $Ku.by.Object.Row();
        tmpNewRow.cells = tmpCells;

        for(IJsonValue item : tmpFieldsNode.getValues()){
            JsonString tmpFieldNode = (JsonString) item;
            if(tmpFieldNode == null){
                throw new RuntimeException();
            }
            $Ku.by.Object.Cell tmpCell = this.parseField(tmpFieldNode.getValue());
            tmpCell.row = tmpNewRow;
            tmpCells.add(tmpCell);
        }

        for(int i = 0; i < tmpFieldsNode.size(); i++){
            IJsonValue tmpCellValue = tmpValuesNode.GetValue(i);
            $Ku.by.Object.Cell tmpCell = tmpCells.get(i);
            if(tmpCellValue instanceof JsonString){
                JsonString tmpStringValue = (JsonString) tmpCellValue;
                tmpCell.value = tmpStringValue.getValue();
            }
            if(tmpCellValue instanceof JsonNumber){
                JsonNumber tmpNumValue = (JsonNumber) tmpCellValue;
                String[] tmpNumArray = tmpNumValue.getNumberStr().split("\\.");
                if(tmpNumArray.length == 1){
                    tmpCell.value = Integer.valueOf(tmpNumValue.getNumberStr());
                }
                else if(tmpNumArray.length == 2){
                    tmpCell.value = Double.valueOf(tmpNumValue.getNumberStr());
                }
                else{
                    throw new RuntimeException();
                }
            }
            if(tmpCellValue instanceof JsonBool){
                JsonBool tmpBoolValue = (JsonBool) tmpCellValue;
                tmpCell.value = tmpBoolValue.getValue();
                tmpCell.DataTypeEnum = DataTypeEnum.Bool;
            }
            if(tmpCellValue instanceof JsonNull){
                tmpCell.value = null;
            }
            if(tmpCellValue instanceof JsonObject){
                throw new RuntimeException();
            }

        }

        LinkedList<IBaseDataSheet> tmpDataSheetList = new LinkedList<>();

        for(IJsonValue item : tmpIdentitysNode.getValues()){
            JsonObject tmpIdentityNode = (JsonObject) item;

            if(tmpIdentityNode == null){
                throw new RuntimeException();
            }

            AbstractIdentityBase tmpIdentity = parseIdentity(tmpIdentityNode);
            IBaseDataSheet tmpDataSheet = (IBaseDataSheet) tmpIdentity.to;

            if(tmpDataSheet == null){
                throw new RuntimeException();
            }
            tmpDataSheetList.add(tmpDataSheet);
        }

        if(tmpDataSheetList.size() < f_OrmType.getIdentityDec().size()){
            throw new RuntimeException();
        }
        Object tmpOrmInstance = null;
        try{
            tmpOrmInstance = f_OrmType.getType().newInstance();
            java.lang.reflect.Field tmpCellsProp = f_OrmType.getType().getDeclaredField("cells");
            tmpCellsProp.set(tmpOrmInstance, new $Ku.by.Object.List<$Ku.by.Object.Cell>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), tmpCells));

            java.lang.reflect.Field ormFields = f_OrmType.getType().getDeclaredField("ormFields");
            ormFields.set(tmpOrmInstance, tmpOrmFields);
            java.lang.reflect.Field tablesMap = f_OrmType.getType().getDeclaredField("tablesMap");
            tablesMap.set(tmpOrmInstance, tmpOrmTables);

            for(Map.Entry<String, String> item : f_OrmType.getAliasPropertiesMap().entrySet()){
                String tmpAlias = item.getKey();
                String tmpIndexPropName = item.getValue();
                java.lang.reflect.Field tmpIndexProp = f_OrmType.getType().getDeclaredField(tmpIndexPropName);

                for(OrmField tmpOrmField : tmpOrmFields){
                    if(tmpOrmField.name.equals(tmpAlias)){
                        tmpIndexProp.set(tmpOrmInstance, tmpOrmField.index);
                    }
                }
            }

            for(int i = 0; i < f_OrmType.getIdentityDec().size(); i++){
                String tmpPropName = "Table" + i;
                java.lang.reflect.Field tmpProp = f_OrmType.getType().getDeclaredField(tmpPropName);
                Class<?> tmpIdentityType = f_OrmType.getIdentityDec().get(i);
                IBaseDataSheet tmpDataSheet = tmpDataSheetList.get(i);

                if(tmpDataSheet.getIdentity().getClass() != tmpIdentityType){
                    throw new RuntimeException("orm中身份类型和预设类型不一致");
                }

                ArrayList<$Ku.by.Object.Cell> tmpTableCells = new ArrayList<>(tmpCells.stream()
                        .filter(item->tmpDataSheet.getKuName().equals(item.getKuName()) && tmpDataSheet.getSheetName().equals(item.getSheetName()) && item.AggregateFunctionName == null)
                        .collect(Collectors.toList()));
                $Ku.by.Object.Row tmpNewTableRow = new $Ku.by.Object.Row();
                tmpNewTableRow.cells = tmpTableCells;
                tmpNewTableRow.setKuName(tmpDataSheet.getKuName());
                tmpNewTableRow.setSheetName(tmpDataSheet.getSheetName());
                tmpNewTableRow.$Identity = tmpDataSheet.getIdentity();
                tmpNewTableRow.OrmSource = (AbstractOrm) tmpOrmInstance;

                tmpProp.set(tmpOrmInstance, tmpNewTableRow);
            }

        }catch (java.lang.Exception e){
            throw new RuntimeException(e);
        }

        return tmpOrmInstance;
    }
}
