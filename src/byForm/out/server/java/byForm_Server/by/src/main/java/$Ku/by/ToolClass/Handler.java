package $Ku.by.ToolClass;

import $Ku.by.JsonUtils.*;
import $Ku.by.ToolClass.Root;
import javax.imageio.ImageIO;
import jakarta.servlet.ServletOutputStream;
import jakarta.servlet.http.*;
import javax.swing.*;
import java.awt.*;
import java.io.*;
import java.net.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.*;
import java.time.LocalDate;
import java.util.Arrays;
import java.util.Date;
import java.util.Hashtable;
import java.util.UUID;
import java.util.regex.Pattern;
import static $Ku.by.JsonUtils.ConvertStringJson.*;
import $Ku.by.Object.*;
import java.io.InputStream;
import java.util.Properties;
public class Handler extends HttpServlet {
    public static java.lang.String currentDirectory = java.net.URLDecoder.decode(java.util.Objects.requireNonNull(Thread.currentThread().getContextClassLoader().getResource("")).getPath()).replace("WEB-INF/classes/", "");
    private static java.lang.String resourceRootPath;
    private static final java.lang.String SESSIONID = "$SESSIONID";
    private static boolean logIsWriting = false;
    private final java.util.LinkedHashMap<java.lang.String, java.lang.String> macDic = new java.util.LinkedHashMap<>();
    public static java.util.LinkedHashMap<java.lang.Long, $Ku.by.Object.ServerSession> currentThreadIDSession = new java.util.LinkedHashMap<>();

    protected void doPost(jakarta.servlet.http.HttpServletRequest request, jakarta.servlet.http.HttpServletResponse response) {
        try {
            response.setHeader("Access-Control-Allow-Origin", " * ");
            Root.GetInstance();
            if(currentDirectory == null){
                currentDirectory = java.lang.System.getProperty("user.dir");
            }
            handlePost(request, response);
        } catch (java.lang.Exception e) {
            String tmpErrorMessage = handleResponseValue($Ku.by.ToolClass.RequestTypeEnum.None, e.getMessage(), false);
            StringBuilder tmpLogContent = new StringBuilder(generateLogHeader(request));
            tmpLogContent.append(" POST ");
            tmpLogContent.append("HAS ERROR 200 \r\n");

            writeLog(tmpLogContent.toString(), true, tmpErrorMessage);
            response.setStatus(HttpServletResponse.SC_OK);
            response.setContentType("text/plain;charset=UTF-8");
            try {
                response.getWriter().write(tmpErrorMessage);
            } catch (IOException ex) {
                throw new RuntimeException(ex.getMessage());
            }
        }
    }

    protected void doGet(jakarta.servlet.http.HttpServletRequest request, jakarta.servlet.http.HttpServletResponse response) {
        String tmpHeader = generateLogHeader(request);
        tmpHeader += " GET 200";
        writeLog(tmpHeader, false, null);

        response.setContentType("text/plain;charset=UTF-8");
        PrintWriter out = null;
        try {
            out = response.getWriter();
        } catch (java.lang.Exception e) {
            throw new RuntimeException(e.getMessage());
        }
        out.println("Java Tomcat 服务器已连接");
        try{
            $Ku.by.ToolClass.Sql.SqlHelper.TestConnection();
            out.println("数据库连接成功");
        }catch (java.lang.Exception e){
            out.println(e);
        }
    }

    private java.lang.String generateLogHeader(jakarta.servlet.http.HttpServletRequest request) {
        
        String ipAddress = getClientIPAddress(request);
        String userAgent = request.getHeader("User-Agent");

        return "IP: " + ipAddress + " | " +
                "User-Agent: " + userAgent;
    
    }

    private java.lang.String getClientIPAddress(jakarta.servlet.http.HttpServletRequest request) {
        
        String ipAddress = request.getHeader("X-FORWARDED-FOR");

        if (ipAddress == null) {
            ipAddress = request.getRemoteAddr();

            if (ipAddress.equals("0:0:0:0:0:0:0:1")) {
                try {
                    InetAddress inetAddress = InetAddress.getLocalHost();
                    ipAddress = inetAddress.getHostAddress();
                } catch (UnknownHostException ex) {
                    ipAddress = "Unknown";
                }
            }
        } else {
            String[] ipAddresses = ipAddress.split(",");
            if (ipAddresses.length > 0) {
                ipAddress = ipAddresses[0];
            }
        }

        return ipAddress;
    
    }

    private void handlePost(jakarta.servlet.http.HttpServletRequest request, jakarta.servlet.http.HttpServletResponse response) {
        currentThreadIDSession.remove(Thread.currentThread().getId());
        String tmpBody;
        try {
            tmpBody = streamReadAll(request.getReader());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        JsonObject tmpObj;
        $Ku.by.ToolClass.Parse tmpParse = new $Ku.by.ToolClass.Parse();
        StringBuilder tmpLogContent = new StringBuilder(generateLogHeader(request));
        tmpLogContent.append(" POST ");
        String tmpIp = getIp(request);

        try {
            tmpObj = ParseValue(tmpBody);
        } catch (java.lang.Exception e) {
            // 开始执行解析程序之前抛出的错误
            String tmpErrorMessage = handleResponseValue($Ku.by.ToolClass.RequestTypeEnum.None, e.getMessage(), false);
            tmpLogContent.append("HAS ERROR 200 \r\n");
            tmpLogContent.append("--------------------------------------------------------------------------------------\r\n");
            tmpLogContent.append("数据包解析错误信息： ").append(e.getMessage()).append("\r\n");
            tmpLogContent.append("数据包内容：\r\n").append(tmpBody).append("\r\n");
            tmpLogContent.append("--------------------------------------------------------------------------------------\r\n");
            writeLog(tmpLogContent.toString(), true, tmpBody);
            response.setStatus(HttpServletResponse.SC_OK);
            response.setContentType("text/plain;charset=UTF-8");
            try {
                response.getWriter().write(tmpErrorMessage);
            } catch (IOException ex) {
                throw new RuntimeException(ex.getMessage());
            }
            return;
        }
        try {
            tmpParse.parsePostContent(tmpObj, tmpIp,  request.getRequestURL().toString());

            if (tmpParse.ComeInHasError) {
                tmpLogContent.append("comeIn failed ");
                this.writeLog(tmpLogContent.toString(), true, null);
                response.setStatus(HttpServletResponse.SC_OK);
                response.setContentType("text/plain;charset=UTF-8");
                String tmpErrorMessage = this.handleResponseValue(tmpParse.ResponseType, "by.Identity.IDoor.comeIn执行错误 -> " + tmpParse.ResponseValue, false);
                try {
                    response.getWriter().write(tmpErrorMessage);
                } catch (IOException ex) {
                    throw new RuntimeException(ex.getMessage());
                }
                return;
            }
        } catch (java.lang.Exception e) {
            String tmpErrorMessage;
            tmpLogContent.append("HAS ERROR 200 \r\n");
            tmpLogContent.append("--------------------------------------------------------------------------------------\r\n");
            tmpLogContent.append("错误信息： ").append(e.getMessage()).append("\r\n");
            if (tmpParse.ResponseType == $Ku.by.ToolClass.RequestTypeEnum.SQL && tmpParse.SqlLocation != null && !tmpParse.SqlLocation.isEmpty()) {
                String tmpAppendContent = " sql错误位置: " + tmpParse.SqlLocation + "\r\n";
                tmpLogContent.append(tmpAppendContent);
            }
            // tmpLogContent.append(tmpErrorMessage);
            tmpErrorMessage = handleResponseValue(tmpParse.ResponseType, e.getMessage(), false);
            tmpLogContent.append("接收数据： ").append(tmpBody).append("\r\n");
            tmpLogContent.append("返回数据： ").append(tmpErrorMessage).append("\r\n");
            tmpLogContent.append("堆栈信息： ").append(Arrays.toString(e.getStackTrace())).append("\r\n");
            tmpLogContent.append("--------------------------------------------------------------------------------------\r\n");
            writeLog(tmpLogContent.toString(), true, tmpBody);
            response.setStatus(HttpServletResponse.SC_OK);
            response.setContentType("text/plain;charset=UTF-8");
            try {
                response.getWriter().write(tmpErrorMessage);
            } catch (IOException ex) {
                throw new RuntimeException(ex.getMessage());
            }
            return;
        }

        tmpLogContent.append("SUCCESS 200");
        writeLog(tmpLogContent.toString(), false, null);
        response.setStatus(HttpServletResponse.SC_OK);
        response.setContentType("text/plain;charset=UTF-8");
        try {
            response.getWriter().write(handleResponseValue(tmpParse.ResponseType, tmpParse.ResponseValue, true));
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    private java.lang.String handleResponseValue($Ku.by.ToolClass.RequestTypeEnum requestType, java.lang.String responseValue, boolean isSuccessful) {
        
        switch (requestType) {
            case None:
                // 只有在解析到请求类型之前出错才会跳到这
            case ACTION:
            case SKILL:
            case AUTOID:
            case SOURCE:
                return generateSource(responseValue, isSuccessful);
            default:
                // 在格式上和事务应该是一样的
                return generateSqlResult(responseValue, isSuccessful);
        }
    
    }

    private java.lang.String generateAction(java.lang.String value, boolean isSuccessful) {
        
        JsonObject tmpObj = new JsonObject();
        tmpObj.Add("$E", new JsonBool(Boolean.parseBoolean(String.valueOf(!isSuccessful).toLowerCase())));
        if (!(value.startsWith("{") && value.endsWith("}"))) {
            tmpObj.Add("$V", new JsonString(value));
        } else {
            tmpObj.Add("$V", ParseValue(value));
        }

        return tmpObj.formatJson(tmpObj.toString());
    
    }

    private java.lang.String generateSource(java.lang.String value, boolean isSuccessful) {
        JsonObject tmpObj = new JsonObject();
        try {
            tmpObj.Add(SESSIONID, new JsonString($Ku.by.Object.ServerSession.getCurrentSession().ID));
        } catch (java.lang.Exception e) {
            tmpObj.Add(SESSIONID, new JsonNull());
        }
        if (isSuccessful) {           
            tmpObj.Add("$E", new JsonBool(false));
            if (value == null) {
                tmpObj.Add("$V", new JsonNull());
            } else if (value.startsWith("[") && value.endsWith("]")) {
                tmpObj.Add("$V", ParseValue(value));
            } else if (value.startsWith("\"") && value.endsWith("\"")) {
                tmpObj.Add("$V", new JsonString(value.substring(1, value.length() - 1)));
            } else if (value.equalsIgnoreCase("true") || value.equalsIgnoreCase("false")) {
                tmpObj.Add("$V", new JsonBool(Boolean.parseBoolean(value.toLowerCase())));
            } else if (value.trim().startsWith("{") && value.trim().endsWith("}")) {
                tmpObj.Add("$V", ParseValue(value.trim()));
            } else {
                tmpObj.Add("$V", new JsonNumber(value));
            }
        } else {
            tmpObj.Add("$E", new JsonBool(true));
            tmpObj.Add("$V", new JsonString(value));
        }
        return tmpObj.formatJson(tmpObj.toString());
    }

    private java.lang.String generateSqlResult(java.lang.String value, boolean isSuccessful) {
        
        JsonObject tmpObj = new JsonObject();
        tmpObj.Add(SESSIONID, new JsonString($Ku.by.Object.ServerSession.getCurrentSession().ID));
        tmpObj.Add("$E", new JsonBool(Boolean.parseBoolean(String.valueOf(!isSuccessful).toLowerCase())));
        if (isSuccessful) {
            if (value.startsWith("[")) {
                tmpObj.Add("$V", ParseArray(new JsonStr(value)));
            } else {
                tmpObj.Add("$V", new JsonNumber(value));
            }
        } else {
            tmpObj.Add("$V", new JsonString(value));
        }
        return tmpObj.formatJson(tmpObj.toString());
    
    }

    private java.lang.String getIp(jakarta.servlet.http.HttpServletRequest request) {
        
        String ipAddress = request.getHeader("X-FORWARDED-FOR");

        if (ipAddress == null) {
            ipAddress = request.getRemoteAddr();

            if (ipAddress.equals("0:0:0:0:0:0:0:1")) {
                try {
                    InetAddress inetAddress = InetAddress.getLocalHost();
                    ipAddress = inetAddress.getHostAddress();
                } catch (UnknownHostException ex) {
                    ipAddress = "Unknown";
                }
            }
        } else {
            String[] ipAddresses = ipAddress.split(",");
            if (ipAddresses.length > 0) {
                ipAddress = ipAddresses[0];
            }
        }

        return ipAddress;
    
    }

    private java.lang.String checkIp(java.lang.String ipAddr) {
        
        Pattern pattern = Pattern.compile("^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
        if (pattern.matcher(ipAddr).matches()) {
            return ipAddr;
        } else {
            throw new RuntimeException("错误的IP地址");
        }
    
    }

    private java.lang.String getMac(java.lang.String remoteIp) {
        
        StringBuilder macAddr = new StringBuilder();
        InetAddress ipAddress = null;
        try {
            ipAddress = InetAddress.getByName(remoteIp);
        } catch (UnknownHostException e) {
            throw new RuntimeException(e);
        }
        NetworkInterface networkInterface = null;
        try {
            networkInterface = NetworkInterface.getByInetAddress(ipAddress);
        } catch (SocketException e) {
            throw new RuntimeException(e);
        }
        byte[] macBytes = new byte[0];
        try {
            macBytes = networkInterface.getHardwareAddress();
        } catch (SocketException e) {
            throw new RuntimeException(e);
        }
        if (macBytes != null) {
            for (int i = 0; i < macBytes.length; i++) {
                macAddr.append(String.format("%02X", macBytes[i]));
                if (i < macBytes.length - 1) {
                    macAddr.append("-");
                }
            }
        }

        if (!"127.0.0.1".equals(remoteIp) && macAddr.toString().equals("00-00-00-00-00-00")) {
            throw new RuntimeException("无法匹配的IP地址");
        }

        return macAddr.toString();
    
    }

    private void writeLog(java.lang.String logContent, boolean hasError, java.lang.String body) {
        
        String prePath = java.lang.System.getProperty("user.dir");
        String logDirectory = prePath + "/log";
        if (!Files.exists(Paths.get(logDirectory))) {
            try {
                Files.createDirectories(Paths.get(logDirectory));
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }

        LocalDate now = LocalDate.now();
        String logFileName = String.format("%s/%d_%02d_%02d.log", logDirectory, now.getYear(), now.getMonthValue(), now.getDayOfMonth());
        long startTime = java.lang.System.currentTimeMillis();
        while (true) {
            if (java.lang.System.currentTimeMillis() - startTime > 1000) {
                try {
                    throw new InterruptedException("日志响应超时");
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
            if (logIsWriting) {
                continue;
            } else {
                if (!logIsWriting) {
                    logIsWriting = true;
                } else {
                    continue;
                }

                if (hasError) {
                    logContent = logContent + body;
                }

                try (BufferedWriter writer = new BufferedWriter(new FileWriter(logFileName, true))) {
                    writer.write(logContent);
                    writer.newLine();
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }

                logIsWriting = false;
                break;
            }
        }
    
    }

    private java.lang.String streamReadAll(java.io.BufferedReader reader) {
        
        StringBuilder sb = new StringBuilder();
        String line;
        while (true) {
            try {
                if (!((line = reader.readLine()) != null)) break;
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            sb.append(line);
        }
        return sb.toString();
    
    }
}
