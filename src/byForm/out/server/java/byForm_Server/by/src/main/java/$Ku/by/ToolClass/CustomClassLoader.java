package $Ku.by.ToolClass;

import java.io.*;
public class CustomClassLoader extends ClassLoader  {
    private final java.lang.String jarFilePath;

    public CustomClassLoader(java.lang.String jarFilePath) {
        
        this.jarFilePath = jarFilePath;
    }


    @Override
    protected java.lang.Class<?> findClass(java.lang.String name) {
        
        try {
            // 从指定的JAR包路径中加载类字节码
            FileInputStream fis = new FileInputStream(jarFilePath);
            byte[] data = new byte[fis.available()];
            fis.read(data);
            fis.close();

            // 使用defineClass方法将类字节码加载到独立的命名空间
            return defineClass(name, data, 0, data.length);
        } catch (IOException e) {
            try {
                throw new ClassNotFoundException("Class not found: " + name, e);
            } catch (ClassNotFoundException ex) {
                throw new RuntimeException(ex.getMessage());
            }
        }
    }
}
