package $Ku.$Web;

import jakarta.servlet.ServletRequestEvent;
import jakarta.servlet.ServletRequestListener;
import java.lang.ref.Reference;
import java.lang.reflect.Array;
import java.lang.reflect.Method;
public class ThreadLocalCleanListener implements ServletRequestListener  {
    public void requestDestroyed(ServletRequestEvent sre) {
        try {
                cleanUpThreadLocals();
        } catch (java.lang.Exception e) {
                e.printStackTrace();
        }
    }

    public void cleanUpThreadLocals() throws java.lang.Exception {
        Thread thread = Thread.currentThread();
        java.lang.reflect.Field threadLocalsField = Thread.class.getDeclaredField("threadLocals");
        threadLocalsField.setAccessible(true);
        Object threadLocalsInThread = threadLocalsField.get(thread);
        Class threadLocalMapClass = Class
                .forName("java.lang.ThreadLocal$ThreadLocalMap");
        Method removeInThreadLocalMap = threadLocalMapClass.getDeclaredMethod("remove", ThreadLocal.class);
        removeInThreadLocalMap.setAccessible(true);

        java.lang.reflect.Field tableField = threadLocalMapClass.getDeclaredField("table");
        tableField.setAccessible(true);
        Object table = tableField.get(threadLocalsInThread);
        for (int i = 0; i < Array.getLength(table); i++) {
                Object entry = Array.get(table, i);
            Method getMethod = Reference.class.getDeclaredMethod("get");
            if (entry != null) {
                    ThreadLocal threadLocal = (ThreadLocal) getMethod.invoke(entry);
                removeInThreadLocalMap.invoke(threadLocalsInThread, threadLocal);
            }
        }
    }
}
