package $Ku.$Web;

import com.mysql.cj.jdbc.AbandonedConnectionCleanupThread;
import jakarta.servlet.ServletContextEvent;
import jakarta.servlet.ServletContextListener;
import java.sql.Driver;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Enumeration;
public class ContextListener implements ServletContextListener  {
    public void contextInitialized(ServletContextEvent sce) {
        if(!RootInit.initialized){
            RootInit.Init($Ku.by.ToolClass.Root.GetInstance());
            RootInit.assembleComponent($Ku.by.ToolClass.Root.GetInstance());
            Main.byMain(null);
        }
        ServletContextListener.super.contextInitialized(sce);
    }

    public void contextDestroyed(ServletContextEvent sce) {
        Enumeration drivers = DriverManager.getDrivers();
        while (drivers.hasMoreElements()) {
            Driver driver = (Driver) drivers.nextElement();
            try {
                DriverManager.deregisterDriver(driver);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
        //手动停止名为[mysql-cj-abandoned-connection-cleanup]的线程
        AbandonedConnectionCleanupThread.uncheckedShutdown();
        ServletContextListener.super.contextDestroyed(sce);
    }
}
