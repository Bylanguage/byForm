package $Ku.by.Object;

import java.util.*;
import java.lang.reflect.Array;
public class HashSet<T> extends $Ku.by.Object.ByObject {
    public java.util.HashSet<T> hashSet;
    public $Ku.by.ToolClass.$ClassMessage $T;

    public HashSet($Ku.by.ToolClass.$ClassMessage $T) {
        this.hashSet = new java.util.HashSet<>();
        this.$T = $T;
    }

    public HashSet($Ku.by.ToolClass.$ClassMessage $T, T[] items) {
        this.hashSet = new java.util.HashSet<>(Arrays.asList(items));
        this.$T = $T;
    }

    public HashSet($Ku.by.ToolClass.$ClassMessage $T, $Ku.by.Object.List<T> items) {
        this.hashSet = new java.util.HashSet<>(Arrays.asList(items.toArray()));
        this.$T = $T;
    }


    public int count() {
        return hashSet.size();
    }

    public boolean add(T item) {
        return hashSet.add(item);
    }

    public void clear() {
        hashSet.clear();
    }

    public boolean contains(T item) {
        return hashSet.contains(item);
    }

    public boolean remove(T item) {
        return hashSet.remove(item);
    }

    public T[] toArray() {
        return hashSet.toArray((T[]) Array.newInstance($T.clazz, 0));
    }
}
