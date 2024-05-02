package $Ku.by.Object;

import java.util.*;
public class Dictionary<k, v> extends $Ku.by.Object.ByObject implements java.lang.Iterable<$Ku.by.Object.KeyValue<k, v>>  {
    public $Ku.by.ToolClass.$ClassMessage $k;
    public $Ku.by.ToolClass.$ClassMessage $v;
    public Set<k> keys;
    public Collection<v> values;
    public final LinkedHashMap<k, v> hashtable;

    public Dictionary() {
        hashtable = new LinkedHashMap<>();
        keys = hashtable.keySet(); 
        values = hashtable.values();
    }

    public Dictionary($Ku.by.ToolClass.$ClassMessage $k, $Ku.by.ToolClass.$ClassMessage $v) {
        this.hashtable = new LinkedHashMap<>();
        this.keys = hashtable.keySet();
        this.values = hashtable.values();
        this.$k = $k;
        this.$v = $v;
    }


    public int count() {
        return hashtable.size();
    }

    public v assign(k key, v value) {
        if(this.hashtable.replace(key, value) == null) {
            this.hashtable.put(key, value);
        }
        return value;
    }

    public void add(k key, v value) {
        try
        {
            hashtable.put(key,value);
        }
        catch(java.lang.Exception e)
        {
            String tmpMessage = e.getMessage();
            throw new RuntimeException("Dictionary add 错误 " + tmpMessage);
        }
    }

    public void clear() {
        try
        {
            hashtable.clear();
        }
        catch(java.lang.Exception e)
        {
            String tmpMessage = e.getMessage();
            throw new RuntimeException("Dictionary clear 错误 " + tmpMessage);
        }
    }

    public boolean containsKey(k key) {
        try
        {
            return hashtable.containsKey(key);
        }
        catch(java.lang.Exception e)
        {
            String tmpMessage = e.getMessage();
            throw new RuntimeException("Dictionary containsKey 错误 " + tmpMessage);
        }
    }

    public boolean containsValue(v value) {
        try
        {
            return hashtable.containsValue(value);
        }
        catch(java.lang.Exception e)
        {
            String tmpMessage = e.getMessage();
            throw new RuntimeException("Dictionary containsValue 错误 " + tmpMessage);
        }
    }

    public void remove(k key) {
        if (key==null){
            throw new RuntimeException("Dictionary remove key 为空");
        }
        try
        {
            hashtable.remove(key);
        }
        catch(java.lang.Exception e)
        {
            String tmpMessage = e.getMessage();
            throw new RuntimeException("Dictionary remove 错误 " + tmpMessage);
        }
    }

    public v[] getValues() {
        try
        {
            return hashtable.values().toArray((v[]) java.lang.reflect.Array.newInstance($v.clazz, 0));
        }
        catch(java.lang.Exception e)
        {
            String tmpMessage = e.getMessage();
            throw new RuntimeException("Dictionary add 错误 " + tmpMessage);
        }
    }

    public k[] getKeys() {
        try
        {
            return hashtable.keySet().toArray((k[]) java.lang.reflect.Array.newInstance($k.clazz, 0));
        }
        catch(java.lang.Exception e)
        {
            String tmpMessage = e.getMessage();
            throw new RuntimeException("Dictionary add 错误 " + tmpMessage);
        }
    }

    public int getCount() {
        return this.hashtable.size();
    }

    public v get(k key) {
        return hashtable.get(key);
    }

    public java.util.Iterator<$Ku.by.Object.KeyValue<k, v>> iterator() {
        return new MyIterator();
    }

    public v preIncrement(k key) {
        v oldValue = get(key);
        if(oldValue instanceof Byte ){
            Byte value = (Byte) oldValue;
            value++;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Short ){
            Short value = (Short) oldValue;
            value++;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Integer ){
            Integer value = (Integer) oldValue;
            value++;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Long ){
            Long value = (Long) oldValue;
            value++;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Float ){
            Float value = (Float) oldValue;
            value++;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Double ){
            Double value = (Double) oldValue;
            value++;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Character ){
            Character value = (Character) oldValue;
            value++;
            return assign(key, (v) value);
        }

        if(oldValue instanceof $Ku.by.Object.Decimal ){
            $Ku.by.Object.Decimal value = ($Ku.by.Object.Decimal) oldValue;
            value.decimalPostfixIncrement();
            return assign(key, (v) value);
        }

        throw new RuntimeException("值类型不支持自增");
    }

    public v preDecrement(k key) {
        v oldValue = get(key);
        if(oldValue instanceof Byte ){
            Byte value = (Byte) oldValue;
            value--;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Short ){
            Short value = (Short) oldValue;
            value--;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Integer ){
            Integer value = (Integer) oldValue;
            value--;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Long ){
            Long value = (Long) oldValue;
            value--;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Float ){
            Float value = (Float) oldValue;
            value--;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Double ){
            Double value = (Double) oldValue;
            value--;
            return assign(key, (v) value);
        }

        if(oldValue instanceof Character ){
            Character value = (Character) oldValue;
            value--;
            return assign(key, (v) value);
        }

        if(oldValue instanceof $Ku.by.Object.Decimal ){
            $Ku.by.Object.Decimal value = ($Ku.by.Object.Decimal) oldValue;
            value.decimalPostfixDecrement();
            return assign(key, (v) value);
        }

        throw new RuntimeException("值类型不支持自减");
    }

    public v postIncrement(k key) {
        v oldValue = get(key);
        if(oldValue instanceof Byte ){
            Byte value = (Byte) oldValue;
            value++;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Short ){
            Short value = (Short) oldValue;
            value++;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Integer ){
            Integer value = (Integer) oldValue;
            value++;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Long ){
            Long value = (Long) oldValue;
            value++;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Float ){
            Float value = (Float) oldValue;
            value++;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Double ){
            Double value = (Double) oldValue;
            value++;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Character ){
            Character value = (Character) oldValue;
            value++;
            assign(key, (v) value);
        }

        else if(oldValue instanceof $Ku.by.Object.Decimal ){
            $Ku.by.Object.Decimal value = ($Ku.by.Object.Decimal) oldValue;
            value.decimalPostfixIncrement();
            assign(key, (v) value);
        }
        else
        {
            throw new RuntimeException("值类型不支持自增");
        }
        return oldValue;
    }

    public v postDecrement(k key) {
        v oldValue = get(key);
        if(oldValue instanceof Byte ){
            Byte value = (Byte) oldValue;
            value--;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Short ){
            Short value = (Short) oldValue;
            value--;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Integer ){
            Integer value = (Integer) oldValue;
            value--;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Long ){
            Long value = (Long) oldValue;
            value--;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Float ){
            Float value = (Float) oldValue;
            value--;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Double ){
            Double value = (Double) oldValue;
            value--;
            assign(key, (v) value);
        }

        else if(oldValue instanceof Character ){
            Character value = (Character) oldValue;
            value--;
            assign(key, (v) value);
        }

        else if(oldValue instanceof $Ku.by.Object.Decimal ){
            $Ku.by.Object.Decimal value = ($Ku.by.Object.Decimal) oldValue;
            value.decimalPostfixDecrement();
            assign(key, (v) value);
        }
        else
        {
            throw new RuntimeException("值类型不支持自减");
        }
        return oldValue;
    }

    public $Ku.by.Object.ReadOnlyList<k> keys() {
        return new $Ku.by.Object.ReadOnlyList<>($k, new $Ku.by.Object.List<>($k, getKeys()));
    }

    public $Ku.by.Object.ReadOnlyList<v> values() {
        return new $Ku.by.Object.ReadOnlyList<>($v, new $Ku.by.Object.List<>($v, getValues()));
    }


    private class MyIterator implements java.util.Iterator<$Ku.by.Object.KeyValue<k, v>>  {
        int cur = 0;
        Iterator<k> keys = hashtable.keySet().iterator();

        public boolean hasNext() {
            return cur != count();
        }

        public $Ku.by.Object.KeyValue<k, v> next() {
            if(cur >= count()){
                throw new RuntimeException();
            }
            k nextK = keys.next();
            cur++;
            return new $Ku.by.Object.KeyValue<>($k, $v, nextK, hashtable.get(nextK));
        }
    }
}
