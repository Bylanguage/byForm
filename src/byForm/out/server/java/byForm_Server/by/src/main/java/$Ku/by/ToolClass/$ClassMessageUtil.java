package $Ku.by.ToolClass;

import java.lang.reflect.Field;
import java.lang.reflect.ParameterizedType;
import java.lang.reflect.Type;
import java.lang.reflect.TypeVariable;
import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
public class $ClassMessageUtil {
    public static final ConcurrentHashMap<java.lang.Class< ? >, $Ku.by.ToolClass.$ClassMessage> classMessageMap = new ConcurrentHashMap<>();

    public static $Ku.by.ToolClass.$ClassMessage add(java.lang.Class< ? > clazz, $Ku.by.ToolClass.$ClassMessage message) {
        classMessageMap.put(clazz, message);
        return message;
    }

    public static $Ku.by.ToolClass.$ClassMessage add(java.lang.Class< ? > clazz, java.lang.Integer typePaCount) {
        return add(clazz, new $ClassMessage(clazz, typePaCount));
    }

    public static $Ku.by.ToolClass.$ClassMessage add(java.lang.Class< ? > clazz) {
        return add(clazz, 0);
    }

    public static $Ku.by.ToolClass.$ClassMessage get(java.lang.Class< ? > clazz) {
        if(classMessageMap.containsKey(clazz)){
            $ClassMessage message = classMessageMap.get(clazz).clone();
            fillGenericMessage(message);
            return message;
        }
        if(clazz.isArray()){
            $ClassMessage message = new $ClassMessage(clazz, 0);
            classMessageMap.put(clazz, message);
            fillGenericMessage(message);
            return message.clone();
        }
        throw new RuntimeException(clazz.getTypeName() + " 未记录");
    }

    public static void init() {
        for(Map.Entry<Class<?>, $ClassMessage> item : classMessageMap.entrySet()){
            Class<?> fa = item.getValue().clazz.getSuperclass();
            if(fa != null){
                if(classMessageMap.containsKey(fa)){
                    item.getValue().superClass = classMessageMap.get(fa);
                }
            }
            for(Class<?> in : item.getValue().clazz.getInterfaces()){
                if(classMessageMap.containsKey(in)){
                    item.getValue().interfaces.add(classMessageMap.get(in));
                }
            }
        }
    }

    private static void fillGenericMessage($Ku.by.ToolClass.$ClassMessage message) {
        Class<?> clazz = message.clazz;
        if(message.superClass != null){
            fillGenericMessage(message.superClass);
        }
        for ($ClassMessage item : message.interfaces){
            fillGenericMessage(item);
        }
        //父类
        Type superType = clazz.getGenericSuperclass();
        if(superType instanceof ParameterizedType  && message.superClass != null){
            ParameterizedType type = (ParameterizedType) superType;
            Type[] typeArguments = type.getActualTypeArguments();
            Integer count = 0;
            for(Type argument : typeArguments){
                if(argument instanceof Class){
                    if(clazz.equals(argument)){
                        message.superClass.addTypeArgument(count, message);
                    }
                    else{
                        message.superClass.addTypeArgument(count, get((Class<?>) argument));
                    }
                }
                else if(argument instanceof ParameterizedType){
                    message.superClass.addTypeArgument(count, parameterizedTypeToClassMessage((ParameterizedType) argument));
                }
                else if(argument instanceof TypeVariable){
                    count++;
                    continue;
                }
                else{
                    throw new RuntimeException("未考虑到的泛型参数类型:" + argument.getClass());
                }
                count++;
            }
        }

        //接口
        Type[] types = clazz.getGenericInterfaces();
        for(Type item : types){
            if(item instanceof ParameterizedType){
                ParameterizedType tmpType = (ParameterizedType) item;
                Class<?> tmpClass = (Class<?>) tmpType.getRawType();
                $ClassMessage interfaceMessage = message.getInterface(tmpClass);
                if(interfaceMessage == null){
                    continue;
                }
                Type[] tmpTypeArguments = tmpType.getActualTypeArguments();
                Integer count = 0;
                for(Type argument : tmpTypeArguments){
                    if(argument instanceof Class){
                        if(clazz.equals(argument)){
                            interfaceMessage.addTypeArgument(count, message);
                        }
                        else{
                            interfaceMessage.addTypeArgument(count, get((Class<?>) argument));
                        }
                    }
                    else if(argument instanceof ParameterizedType){
                        interfaceMessage.addTypeArgument(count, parameterizedTypeToClassMessage((ParameterizedType) argument));
                    }
                    else if(argument instanceof TypeVariable){
                        count++;
                        continue;
                    }
                    else{
                        throw new RuntimeException("未考虑到的泛型参数类型:" + argument.getClass());
                    }
                    count++;
                }

            }
        }
    }

    private static $Ku.by.ToolClass.$ClassMessage parameterizedTypeToClassMessage(ParameterizedType f_Type) {
        Class<?> rawType = (Class<?>) f_Type.getRawType();
        $ClassMessage result = get(rawType);
        Type[] typeArguments = f_Type.getActualTypeArguments();
        Integer count = 0;
        for(Type argument : typeArguments){
            if(argument instanceof Class){
                result.addTypeArgument(count, get((Class<?>)argument));
            } else if(argument instanceof ParameterizedType){
                result.addTypeArgument(count, parameterizedTypeToClassMessage((ParameterizedType) argument));
            } else if(argument instanceof TypeVariable){
                count++;
                continue;
            } else {
                throw new RuntimeException("未考虑到的泛型参数类型:" + argument.getClass());
            }
            count++;
        }

        return result;
    }

    public static java.lang.Boolean is(Object obj, $Ku.by.ToolClass.$ClassMessage message) {
        if(obj == null){
            return false;
        }
        Class<?> clazz = obj.getClass();
        if(!message.clazz.isAssignableFrom(clazz)){
            return false;
        }
        $ClassMessage objMessage = objToMessage(obj);
        return objMessage.isAssignableTo(message);
    }

    public static <T> T as(Object obj, $Ku.by.ToolClass.$ClassMessage message) {
        if(is(obj, message)){
            return (T)obj;
        }
        return null;
    }

    public static $Ku.by.ToolClass.$ClassMessage objToMessage(Object obj) {
        Class<?> clazz = obj.getClass();

        $ClassMessage objMessage = get(clazz);
        for(int i = 0; i < clazz.getTypeParameters().length; i++){
            String fieldName = "$" + clazz.getTypeParameters()[i].getName();
            try{
                Field field = clazz.getDeclaredField(fieldName);
                field.setAccessible(true);
                $ClassMessage fieldMessage = ($ClassMessage) field.get(obj);
                objMessage.addTypeArgument(i, fieldMessage);
            }catch (java.lang.Exception e){
                throw new RuntimeException(e);
            }
        }
        return objMessage;
    }

    public static java.util.HashMap<$Ku.by.ToolClass.$ClassMessage, Object> generateMap() {
        HashMap<$ClassMessage, Object> map = new HashMap<>();
        map.put(get(Character.class), (char) 0);
        map.put(get(Boolean.class), false);
        map.put(get(Byte.class), (byte)0);
        map.put(get(Short.class), (short)0);
        map.put(get(Integer.class), 0);
        map.put(get(Long.class), 0L);
        map.put(get(Float.class), (float)0.0);
        map.put(get(Double.class), 0.0);
        map.put(get($Ku.by.Object.Decimal.class), new $Ku.by.Object.Decimal("0.0"));

        for ($ClassMessage item : classMessageMap.values()){
            if(!map.containsKey(item)){
                map.put(item, null);
            }
        }
        return map;
    }

    public static <T> T mapGet(java.util.HashMap<$Ku.by.ToolClass.$ClassMessage, Object> map, $Ku.by.ToolClass.$ClassMessage key) {
        if(!map.containsKey(key)){
            map.put(key, null);
            return null;
        }
        return (T)map.get(key);
    }

    public static <T> T mapSet(java.util.HashMap<$Ku.by.ToolClass.$ClassMessage, Object> map, $Ku.by.ToolClass.$ClassMessage key, Object value) {
        map.put(key, value);
        return (T)value;
    }

    public static Object getDefaultValue($Ku.by.ToolClass.$ClassMessage f_Class) {
        if(f_Class.clazz == Double.class){
            return 0.0;
        }
        if(f_Class.clazz == Float.class){
            return 0.0f;
        }
        if(f_Class.clazz == Long.class){
            return 0L;
        }
        if(f_Class.clazz == Integer.class){
            return 0;
        }
        if(f_Class.clazz == Short.class){
            return (short)0;
        }
        if(f_Class.clazz == Byte.class){
            return (byte)0;
        }
        if(f_Class.clazz == Character.class){
            return Character.MIN_VALUE;
        }
        if(f_Class.clazz == Boolean.class){
            return false;
        }
        if(f_Class.clazz == $Ku.by.Object.Decimal.class){
            return new $Ku.by.Object.Decimal(0);
        }
        if(f_Class.clazz.isEnum()){
            return f_Class.clazz.getEnumConstants()[0];
        }
        return null;
    }
}
