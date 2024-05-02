package $Ku.by.Object;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
public class List<t> extends $Ku.by.Object.ByObject implements Iterable<t>  {
    public $Ku.by.ToolClass.$ClassMessage $t;
    private ArrayList<t> _list;

    public List($Ku.by.ToolClass.$ClassMessage $t) {
        this._list = new ArrayList<>();
        this.$t = $t;
    }

    public List() {
        this._list = new ArrayList<>();
    }

    public List($Ku.by.ToolClass.$ClassMessage $t, $Ku.by.Object.List<t> f_Source) {
        this.$t = $t;
        _list = new ArrayList<>();
        _list.addAll(f_Source._list);
    }

    public List($Ku.by.ToolClass.$ClassMessage $t, t[] f_Source) {
        this.$t = $t;
        _list = new ArrayList<>();
        _list.addAll(Arrays.asList(f_Source));
    }

    public List($Ku.by.ToolClass.$ClassMessage $t, ArrayList<t> _list) {
        this.$t = $t;
        this._list = _list;
    }


    public int count() {
        return _list.size();
    }

    public t assign(int index, t value) {
        _list.set(index, value);
        return value;
    }

    public void add(t obj) {
        try {
            _list.add(obj);
        }
        catch (java.lang.Exception e) {
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List add错误" + tmpMessage);
        }
    }

    public void addRange(t[] obj) {
        if (obj == null){
            throw new RuntimeException("添加array为null");
        }
        try{
            _list.addAll(Arrays.asList(obj));
        }
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List addArray错误" + tmpMessage);
}
    }

    public void addRange(List<t> obj) {
        if (obj == null){
            throw new RuntimeException("添加array为null");
        }
        try{
            _list.addAll((Arrays.asList(obj.toArray())));
        }
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List addRange错误" + tmpMessage);
}
    }

    public void insert(int index, t obj) {
        if (index > _list.size() - 1){
            throw new RuntimeException("$Ku.by.Object.List insert 超出范围");
        }
        try{
            _list.add(index, obj);
        }
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List insert 错误" + tmpMessage);
}
    }

    public void clear() {
        _list.clear();
    }

    public boolean contains(t obj) {
        try{
            return _list.contains(obj);
        }
        
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List contains 错误" + tmpMessage);
        }
    }

    public int indexOf(t obj) {
        try{
            return _list.indexOf(obj);
        }
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List indexOf 错误" + tmpMessage);
        }
    }

    public int lastIndexOf(t obj) {
        try{
            return _list.lastIndexOf(obj);
        }
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List lastIndexOf 错误" + tmpMessage);
        }
    }

    public void remove(t obj) {
        try{
            _list.remove(obj);
        }
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List remove 错误" + tmpMessage);
        }
    }

    public void removeAt(int index) {
        try{
            _list.remove(index);
        }
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List removeAt 错误" + tmpMessage);
        }
    }

    public t[] toArray() {
        try{
            return _list.toArray((t[]) java.lang.reflect.Array.newInstance($t.clazz, 0));
        }
        catch (java.lang.Exception e){
            String tmpMessage = e.getMessage();
            throw new RuntimeException("$Ku.by.Object.List toArray 错误" + tmpMessage);
        }
    }

    public int getCount() {
        return _list.size();
    }

    public Iterator<t> iterator() {
        return _list.iterator();
    }

    public t get(int index) {
        return _list.get(index);
    }

    public int size() {
        return _list.size();
    }

    public void Add(t item) {
        _list.add(item);
    }

    public t preIncrement(java.lang.Integer index) {
        t oldValue = get(index);
        if(oldValue instanceof Byte ){
            Byte value = (Byte) oldValue;
            value++;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Short ){
            Short value = (Short) oldValue;
            value++;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Integer ){
            Integer value = (Integer) oldValue;
            value++;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Long ){
            Long value = (Long) oldValue;
            value++;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Float ){
            Float value = (Float) oldValue;
            value++;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Double ){
            Double value = (Double) oldValue;
            value++;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Character ){
            Character value = (Character) oldValue;
            value++;
            return assign(index, (t) value);
        }

        if(oldValue instanceof $Ku.by.Object.Decimal ){
            $Ku.by.Object.Decimal value = ($Ku.by.Object.Decimal) oldValue;
            value.decimalPostfixIncrement();
            return assign(index, (t) value);
        }

        throw new RuntimeException("值类型不支持自增");
    }

    public t preDecrement(java.lang.Integer index) {
        t oldValue = get(index);
        if(oldValue instanceof Byte ){
            Byte value = (Byte) oldValue;
            value--;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Short ){
            Short value = (Short) oldValue;
            value--;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Integer ){
            Integer value = (Integer) oldValue;
            value--;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Long ){
            Long value = (Long) oldValue;
            value--;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Float ){
            Float value = (Float) oldValue;
            value--;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Double ){
            Double value = (Double) oldValue;
            value--;
            return assign(index, (t) value);
        }

        if(oldValue instanceof Character ){
            Character value = (Character) oldValue;
            value--;
            return assign(index, (t) value);
        }

        if(oldValue instanceof $Ku.by.Object.Decimal ){
            $Ku.by.Object.Decimal value = ($Ku.by.Object.Decimal) oldValue;
            value.decimalPostfixDecrement();
            return assign(index, (t) value);
        }

        throw new RuntimeException("值类型不支持自减");
    }

    public t postIncrement(java.lang.Integer index) {
        t oldValue = get(index);
        if(oldValue instanceof Byte ){
            Byte value = (Byte) oldValue;
            value++;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Short ){
            Short value = (Short) oldValue;
            value++;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Integer ){
            Integer value = (Integer) oldValue;
            value++;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Long ){
            Long value = (Long) oldValue;
            value++;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Float ){
            Float value = (Float) oldValue;
            value++;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Double ){
            Double value = (Double) oldValue;
            value++;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Character ){
            Character value = (Character) oldValue;
            value++;
            assign(index, (t) value);
        }

        else if(oldValue instanceof $Ku.by.Object.Decimal ){
            $Ku.by.Object.Decimal value = ($Ku.by.Object.Decimal) oldValue;
            value.decimalPostfixIncrement();
            assign(index, (t) value);
        }
        else
        {
            throw new RuntimeException("值类型不支持自增");
        }
        return oldValue;
    }

    public t postDecrement(java.lang.Integer index) {
        t oldValue = get(index);
        if(oldValue instanceof Byte ){
            Byte value = (Byte) oldValue;
            value--;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Short ){
            Short value = (Short) oldValue;
            value--;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Integer ){
            Integer value = (Integer) oldValue;
            value--;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Long ){
            Long value = (Long) oldValue;
            value--;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Float ){
            Float value = (Float) oldValue;
            value--;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Double ){
            Double value = (Double) oldValue;
            value--;
            assign(index, (t) value);
        }

        else if(oldValue instanceof Character ){
            Character value = (Character) oldValue;
            value--;
            assign(index, (t) value);
        }

        else if(oldValue instanceof $Ku.by.Object.Decimal ){
            $Ku.by.Object.Decimal value = ($Ku.by.Object.Decimal) oldValue;
            value.decimalPostfixDecrement();
            assign(index, (t) value);
        }
        else
        {
            throw new RuntimeException("值类型不支持自减");
        }
        return oldValue;
    }
}
