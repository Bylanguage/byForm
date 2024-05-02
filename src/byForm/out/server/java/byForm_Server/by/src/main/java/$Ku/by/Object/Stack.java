package $Ku.by.Object;

import java.lang.reflect.Array;
public class Stack<t> extends $Ku.by.Object.ByObject implements Iterable<t>  {
    private final java.util.Stack<t> _stack = new java.util.Stack<>();
    private $Ku.by.ToolClass.$ClassMessage $t;

    public Stack($Ku.by.ToolClass.$ClassMessage $t, t[] items) {
        this.$t = $t;
        _stack.addAll(java.util.Arrays.asList(items));
    }

    public Stack($Ku.by.ToolClass.$ClassMessage $t) {
        this.$t = $t;
    }

    public Stack() {
    }


    public java.lang.Integer size() {
        return _stack.size();
    }

    public void push(t obj) {
        _stack.push(obj);
    }

    public t pop() {
        return _stack.pop();
    }

    public void clear() {
         _stack.clear();
    }

    public t peek() {
        return _stack.peek();
    }

    public boolean contains(t obj) {
        return _stack.contains(obj);
    }

    public t[] toArray() {
        return _stack.toArray((t[])Array.newInstance($t.clazz, 0));
    }

    public java.util.Iterator<t> iterator() {
        return _stack.iterator();
    }
}
