package $Ku.by.Object;

import java.lang.reflect.Array;
import java.util.Iterator;
import java.util.concurrent.ConcurrentLinkedDeque;
public class Queue<t> extends $Ku.by.Object.ByObject implements Iterable<t>  {
    private final ConcurrentLinkedDeque<t> _queue = new ConcurrentLinkedDeque<>();
    public $Ku.by.ToolClass.$ClassMessage $t;

    public Queue($Ku.by.ToolClass.$ClassMessage $t, t[] items) {
        this.$t = $t;
        _queue.addAll(java.util.Arrays.asList(items));
    }

    public Queue($Ku.by.ToolClass.$ClassMessage $t) {
        this.$t = $t;
    }

    public Queue() {
    }


    public void enqueue(t obj) {
        _queue.add(obj);
    }

    public t dequeue() {
        return _queue.poll();
    }

    public void clear() {
        _queue.clear();
    }

    public t peek() {
        return _queue.peek();
    }

    public boolean contains(t obj) {
        return _queue.contains(obj);
    }

    public t[] toArray() {
        return _queue.toArray((t[])Array.newInstance($t.clazz, 0));
    }

    public java.util.Iterator<t> iterator() {
        return _queue.iterator();
    }

    public int count() {
        return _queue.size();
    }
}
