package $Ku.by.ToolClass.Sql;

import $Ku.by.JsonUtils.*;
import java.sql.*;
import java.io.*;
import java.math.BigDecimal;
import java.util.*;
public class SqlHelper {
    public static void TestConnection() {
        try {
            Connection tmpConnection = getConnectMessage("byFormNew");
            tmpConnection.close();
        }catch (java.lang.Exception e){
            if(e instanceof RuntimeException){
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }

        try {
            Connection tmpConnection = getConnectMessage("byUser");
            tmpConnection.close();
        }catch (java.lang.Exception e){
            if(e instanceof RuntimeException){
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }

    }

    public static Object Inquiry(java.lang.String f_Sql, java.lang.String f_KuName) {
        try (Connection tmpConnection = getConnectMessage(f_KuName);
             PreparedStatement tmpStmt = tmpConnection.prepareStatement(f_Sql);
             ResultSet tmpRs = tmpStmt.executeQuery()) {
            if (tmpRs.next()) {
                return tmpRs.getObject(1);
            }
        } catch (Exception e) {
            if(e instanceof RuntimeException){
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
        return null;
    }

    public static java.lang.String Select(java.lang.String f_Sql, java.lang.String f_KuName) {
        try (Connection tmpConnection = getConnectMessage(f_KuName);
             PreparedStatement tmpStmt = tmpConnection.prepareStatement(f_Sql);
             ResultSet tmpRs = tmpStmt.executeQuery()) {
            JsonArray jsonArray = new JsonArray();
            int columnCount = tmpRs.getMetaData().getColumnCount();
            while (tmpRs.next()) {
                JsonArray rowArray = new JsonArray();
                for (int i = 0; i < columnCount; i++) {
                    Object value = tmpRs.getObject(i + 1);
                    if (value instanceof String || value instanceof java.sql.Date ||
                            value instanceof BigDecimal || value instanceof Long) {
                        rowArray.Add(new JsonString(value.toString()));
                    } else if (value == null) {
                        rowArray.Add(new JsonNull());
                    } else if (value instanceof Byte || value instanceof Short ||
                            value instanceof Integer || value instanceof Float ||
                            value instanceof Double) {
                        rowArray.Add(new JsonNumber(value.toString()));
                    } else if (value instanceof Boolean) {
                        if (value.toString().equals("false")) {
                            rowArray.Add(new JsonBool(false));
                        } else if (value.toString().equals("true")) {
                            rowArray.Add(new JsonBool(true));
                        }
                    }
                }
                jsonArray.Add(rowArray);
            }
            return jsonArray.toString();
        } catch (Exception e) {
            if(e instanceof RuntimeException){
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
    }

    public static int ExecuteNonQuery(java.lang.String f_Sql, java.lang.String f_KuName) {
        try (Connection tmpConnection = getConnectMessage(f_KuName);
             PreparedStatement tmpStmt = tmpConnection.prepareStatement(f_Sql)) {
            return tmpStmt.executeUpdate();
        } catch (Exception e) {
            if(e instanceof RuntimeException){
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
    }

    public static $Ku.by.Object.List<$Ku.by.Object.Row> SelectReturnRows(java.lang.String f_Sql, java.lang.String f_KuName) {
        ArrayList<$Ku.by.Object.Row> tmpRowList = new ArrayList<>();
        try {
            Connection tmpConnection = getConnectMessage(f_KuName);
            PreparedStatement tmpStmt = tmpConnection.prepareStatement(f_Sql);
            ResultSet tmpRs = tmpStmt.executeQuery();
            int columnCount = tmpRs.getMetaData().getColumnCount();
            while (tmpRs.next()) {
                $Ku.by.Object.Row tmpNewRow = new $Ku.by.Object.Row();
                tmpNewRow.setKuName(f_KuName);
                for (int i = 0; i < columnCount; i++) {
                    if (Objects.equals(tmpRs.getMetaData().getColumnName(i + 1), "#RowNum")) {
                        continue;
                    }
                    $Ku.by.Object.Cell tmpCell = new $Ku.by.Object.Cell();
                    Object value = tmpRs.getObject(i + 1);
                    if (value instanceof java.sql.Timestamp || value instanceof java.sql.Date || value instanceof java.sql.Time || value instanceof oracle.sql.TIMESTAMP) {
                        value = $Ku.by.Object.Datetime.ConvertToDatetime(value);
                    } else if (value instanceof java.time.LocalDateTime) {
                        value = new $Ku.by.Object.Datetime((java.time.LocalDateTime) value);
                    }
                    tmpCell.value = value;
                    tmpNewRow.cells.add(tmpCell);
                }
                tmpRowList.add(tmpNewRow);
            }
        } catch (Exception e) {
            if(e instanceof RuntimeException){
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
        return new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class), tmpRowList);
    }

    public static int ExecuteNonQuery(java.lang.String[] f_SqlArray, java.lang.String f_KuName) {
        int[] resultArray;
        try (Connection tmpConnection = getConnectMessage(f_KuName);
             Statement statement = tmpConnection.createStatement()) {
            for (String item : f_SqlArray) {
                statement.addBatch(item);
            }
            resultArray = statement.executeBatch();
        } catch (Exception e) {
            if(e instanceof RuntimeException){
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
        return Arrays.stream(resultArray).sum();
    }

    public static void ExecuteTran(java.lang.String[] f_SqlArray, java.lang.String f_KuName) {
        try (Connection tmpConnection = getConnectMessage(f_KuName);
             Statement statement = tmpConnection.createStatement()) {
            for (String tmpSql : f_SqlArray) {
                statement.executeUpdate(tmpSql);
            }
        } catch (Exception e) {
            if(e instanceof RuntimeException){
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
    }

    private static Connection getConnectMessage(java.lang.String f_KuName) {
        String tmpConnectionString;
        String address;
        String port;
        String username;
        String password;
        String serviceName;
        String databaseName = $Ku.by.ToolClass.Root.GetInstance().KuDic.get(f_KuName).getDatabaseName();
        String connectName = $Ku.by.ToolClass.Root.GetInstance().KuConnectDic.get(f_KuName);
        Properties properties = new Properties();
        try {
            // 加载属性文件
            InputStream i = $Ku.by.ToolClass.Root.class.getClassLoader().getResourceAsStream("config.properties");
            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            byte[] bytes = new byte[2048];
            boolean first = true;
            int byteCount;
            while ((byteCount = i.read(bytes)) != -1)
            {
                if (first)
                {
                    first = false;
                    if (bytes[0] == (byte)0xEF && bytes[1] == (byte)0xBB && bytes[2] == (byte)0xBF)
                    {
                        baos.write(bytes, 3, byteCount);
                        continue;
                    }
                }
                baos.write(bytes, 0, byteCount);
            }
            ByteArrayInputStream byteArrayInputStream = new ByteArrayInputStream(baos.toByteArray());
            properties.load(byteArrayInputStream);
            byteArrayInputStream.close();
            baos.close();
            i.close();

            // 获取配置项的值
            address = properties.getProperty(connectName + "Address");
            port = properties.getProperty(connectName + "Port");
            username = properties.getProperty(connectName + "Username");
            password = properties.getProperty(connectName + "Password");
            serviceName = properties.getProperty(connectName + "ServiceName");
            switch ($Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(f_KuName)){
                case SqlServer:
                    tmpConnectionString = "jdbc:sqlserver://" + address + ":" + port + ";" + "databaseName=" + databaseName + ";encrypt=false";
                    break;
                case Mysql:
                    tmpConnectionString = "jdbc:mysql://" + address + ":" + port + "/" + databaseName + "?";
                    break;
                case Oracle:
                    tmpConnectionString = "jdbc:oracle:thin:@" + address + ":" + port + "/" + serviceName;
                    break;
                default:
                    throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError);
            }
            return DriverManager.getConnection(tmpConnectionString, username, password);
        } catch (Exception e) {
            throw new RuntimeException(e + $Ku.by.ToolClass.ErrorInfo.ConfigPropertiesError);
        }
    }
}
