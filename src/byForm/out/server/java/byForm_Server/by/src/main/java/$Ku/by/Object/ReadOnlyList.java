package $Ku.by.Object;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
public class ReadOnlyList<t> extends $Ku.by.Object.ByObject implements Iterable<t>  {
    public $Ku.by.ToolClass.$ClassMessage $t;
    private java.util.ArrayList<t> list;

    public ReadOnlyList($Ku.by.ToolClass.$ClassMessage $t, t[] items) {
        this.$t = $t;
        list.addAll(java.util.Arrays.asList(items));
    }

    public ReadOnlyList($Ku.by.ToolClass.$ClassMessage $t, $Ku.by.Object.List<t> items) {
        this.$t = $t;
        list = new ArrayList<>();
        for(t item : items){
            list.add(item);
        }
    }

    public ReadOnlyList($Ku.by.ToolClass.$ClassMessage $t, java.util.ArrayList<t> items) {
        this.$t = $t;
        list = new ArrayList<>(items);
    }


    public java.lang.Integer size() {
        return list.size();
    }

    public java.lang.Boolean contains(t item) {
        try{
            return list.contains(item);
        }catch (java.lang.Exception e){
            throw new RuntimeException("$Ku.by.Object.ReadOnlyList contains错误 " + e);
        }
    }

    public t get(java.lang.Integer index) {
        return list.get(index);
    }

    public java.lang.Integer lastIndexOf(t item) {
        return this.list.lastIndexOf(item);
    }

    public java.lang.Integer indexOf(t item) {
        try{
            return list.indexOf(item);
        }catch (java.lang.Exception e){
            throw new RuntimeException("$Ku.by.Object.ReadOnlyList indexOf 错误 " + e);
        }
    }

    public t[] toArray() {
        try{
            return list.toArray((t[]) java.lang.reflect.Array.newInstance($t.clazz, 0));
        }catch (java.lang.Exception e){
            throw new RuntimeException("$Ku.by.Object.ReadOnlyList toArray 错误 " + e);
        }
    }

    @Override
    public Iterator<t> iterator() {
        return list.iterator();
    }

    public $Ku.by.Object.List<t> toList() {
        $Ku.by.Object.List<t> result = new $Ku.by.Object.List<>($t);
        for (t item : list){
            result.add(item);
        }
        return result;
    }
}
