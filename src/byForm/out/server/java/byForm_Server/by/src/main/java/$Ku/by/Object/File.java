package $Ku.by.Object;

import java.util.*;
import java.io.*;
import java.nio.file.*;
public class File extends $Ku.by.Object.ByObject {
    private static final java.util.LinkedHashMap<java.lang.String, byte[]> BOM = initMap();
    public java.io.FileWriter fileWriter;

    private File() {
    }

    public File(java.lang.String path) {
        try {
            this.fileWriter = new FileWriter(path, true);
        } catch (IOException e) {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileCreatingError, path, e));
        }
    }


    private static java.util.LinkedHashMap<java.lang.String, byte[]> initMap() {
        LinkedHashMap<String, byte[]> m = new LinkedHashMap<>(5);
        m.put("UTF-8", new byte[]{(byte) 0xEF, (byte) 0xBB, (byte) 0xBF});
        m.put("UTF-16BE", new byte[]{(byte) 0xFE, (byte) 0xFF});
        m.put("UTF-16LE", new byte[]{(byte) 0xFF, (byte) 0xFE});
        m.put("UTF-32BE", new byte[]{0x00, 0x00, (byte) 0xFE, (byte) 0xFF});
        m.put("UTF-32LE", new byte[]{(byte) 0xFF, (byte) 0xFE, 0x00, 0x00});
        return m;
    }

    public static byte[] getBom($Ku.by.Object.Encoding encoding) {
        if (encoding.encoding.equals(Encoding.UNICODE.encoding)) {
            return BOM.get("UTF-16LE");
        }
        if (encoding.encoding.equals(Encoding.UTF8.encoding)) {
            return BOM.get("UTF-8");
        }
        return new byte[]{};
    }

    public static void appendAllBytes(java.lang.String path, java.lang.Byte[] data) {
        String text = new String($toPrimitives(data), java.nio.charset.StandardCharsets.UTF_8);
        appendAllText(path,text,new Encoding("UTF8"));
    }

    public static void appendAllLines(java.lang.String path, java.lang.String[] lines) {
        appendAllLines(path,lines,new Encoding("UTF8"));
    }

    public static void appendAllLines(java.lang.String path, java.lang.String[] lines, $Ku.by.Object.Encoding encoding) {
        java.io.File file = new java.io.File(path);
        try (BufferedWriter writer = Files.newBufferedWriter(file.toPath(), encoding.encoding, StandardOpenOption.CREATE, StandardOpenOption.APPEND)) {
            for (String line : lines) {
                writer.write(line);
                writer.newLine();
            }
        } catch (IOException e) {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileAppendingError, path, e));
        }
    }

    public static void appendAllText(java.lang.String path, java.lang.String text) {
        appendAllText(path,text,new Encoding("UTF8"));
    }

    public static void appendAllText(java.lang.String path, java.lang.String text, $Ku.by.Object.Encoding encoding) {
        java.io.File file = new java.io.File(path);
        try (BufferedWriter writer = Files.newBufferedWriter(file.toPath(), encoding.encoding, StandardOpenOption.CREATE, StandardOpenOption.APPEND)) {
            writer.write(text);
            writer.newLine();
        } catch (IOException e) {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileAppendingError, path, e));
        }
    }

    public static void copy(java.lang.String path, java.lang.String newPath) {
        java.io.File sourceFile = new java.io.File(path);
        java.io.File targetFile = new java.io.File(newPath);
        if (!targetFile.exists()) {
            try {
                Files.copy(sourceFile.toPath(), targetFile.toPath());
            } catch (IOException e) {
                throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileCopyingError, path, e));
            }
        } else {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileExistError, newPath));
        }
    }

    public static void delete(java.lang.String path) {
        java.io.File file = new java.io.File(path);
        if (file.exists()) {
            boolean wasSuccessful = file.delete();
        } else {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileNotFound, file.getAbsolutePath()));
        }
    }

    public static boolean exists(java.lang.String path) {
        java.io.File file = new java.io.File(path);
        return file.exists();
    }

    public static void move(java.lang.String path, java.lang.String newPath) {
        java.io.File file = new java.io.File(path);
        java.io.File targetFile = new java.io.File(newPath);
        if (!targetFile.exists()) {
            if (file.exists()) {
                if (!file.renameTo(targetFile)) {
                    throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileMovingError, path));
                }
            } else {
                throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileNotFound, file.getAbsolutePath()));
            }
        } else {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileExistError, newPath));
        }
    }

    public static void copy(java.lang.String path, java.lang.String newPath, boolean overwrite) {
        java.io.File file = new java.io.File(path);
        java.io.File targetFile = new java.io.File(newPath);
        if (!targetFile.exists() || (targetFile.exists() && overwrite)) {
            try {
                Files.copy(file.toPath(), targetFile.toPath(), StandardCopyOption.REPLACE_EXISTING);
            } catch (IOException e) {
                throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileCopyingError, path, e));
            }
        } else {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileExistError, newPath));
        }
    }

    public static java.lang.Byte[] readAllBytes(java.lang.String path) {
        java.io.File file = new java.io.File(path);
        try {
            int lengthToCompare = getBom(new Encoding("UTF8")).length;
            if (Files.readAllBytes(file.toPath()).length >= lengthToCompare  && lengthToCompare > 0) {
                byte[] subArray = java.util.Arrays.copyOfRange(Files.readAllBytes(file.toPath()), 0, lengthToCompare);
                if (java.util.Arrays.equals(getBom(new Encoding("UTF8")), subArray)) {
                    byte[] result = new byte[Files.readAllBytes(file.toPath()).length - lengthToCompare];
                    int count = 0;
                    for (int i = lengthToCompare; i < Files.readAllBytes(file.toPath()).length; i++) {
                        result[count] = Files.readAllBytes(file.toPath())[i];
                        count++;
                    }
                    return $toObjects(result);
                }
            }
            return $toObjects(Files.readAllBytes(file.toPath()));
        } catch (IOException e) {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileReadingError, path, e));
        }
    }

    public static java.lang.String[] readAllLines(java.lang.String path) {
        return readAllLines(path,new Encoding("UTF8"));
    }

    public static java.lang.String[] readAllLines(java.lang.String path, $Ku.by.Object.Encoding encoding) {
        java.io.File file = new java.io.File(path);
        try {
            java.util.List<String> files = Files.readAllLines(file.toPath(), encoding.encoding);
            int length = files.size();
            String[] result = files.toArray(new String[length]);
            String bomCs = new String(Objects.requireNonNull(getBom(encoding)), encoding.encoding);
            if (files.get(0).startsWith(bomCs)) {
                result[0] = files.toArray(new String[length])[0].substring(bomCs.length());
            }
            return result;
        } catch (IOException e) {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileReadingError, path, e));
        }
    }

    public static java.lang.String readAllText(java.lang.String path) {
        return readAllText(path,new Encoding("UTF8"));
    }

    public static java.lang.String readAllText(java.lang.String path, $Ku.by.Object.Encoding encoding) {
        Byte[] data;
        data = readAllBytes(path);
        return new String($toPrimitives(data), encoding.encoding);
    }

    public static void writeAllBytes(java.lang.String path, java.lang.Byte[] data, java.lang.Boolean append) {
        if (append) {
            appendAllBytes(path, data);
        } else {
            java.io.File file = new java.io.File(path);
            byte[] tmpdata = $toPrimitives(data);
            try {
                int lengthToCompare = getBom(new Encoding("UTF8")).length;
                if (data.length >= lengthToCompare  && lengthToCompare > 0) {
                    byte[] subArray = java.util.Arrays.copyOfRange($toPrimitives(data), 0, lengthToCompare);
                    if (!java.util.Arrays.equals(getBom(new Encoding("UTF8")),subArray)){
                        Files.write(file.toPath(), getBom(new Encoding("UTF8")));
                    }
                }
                Files.write(file.toPath(), tmpdata);
            } catch (IOException e) {
                throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileWritingError, path, e));
            }
        }
    }

    public static void writeAllLines(java.lang.String path, java.lang.String[] lines, java.lang.Boolean append) {
        if (append){
            appendAllLines(path,lines);
        }
        else {
            writeAllLines(path,lines,append,new Encoding("UTF8"));
        }
    }

    public static void writeAllLines(java.lang.String path, java.lang.String[] lines, java.lang.Boolean append, $Ku.by.Object.Encoding encoding) {
        if (append) {
            appendAllLines(path, lines, encoding);
        } else {
            java.io.File file = new java.io.File(path);
            try {
                Objects.requireNonNull(lines);
                java.nio.charset.CharsetEncoder encoder = encoding.encoding.newEncoder();
                try (OutputStream out = Files.newOutputStream(file.toPath());
                     BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(out, encoder))) {
                    String bomCs = new String(Objects.requireNonNull(getBom(encoding)), encoding.encoding);
                    if (!lines[0].startsWith(bomCs)) {
                        writer.append(bomCs);
                    }
                    writer.append(lines[0]);
                    if (lines.length > 1) {
                        for (int i = 1; i < lines.length; i++) {
                            CharSequence line = lines[i];
                            writer.newLine();
                            writer.append(line);
                        }
                    }
                }
            } catch (IOException e) {
                throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileWritingError, path, e));
            }
        }
    }

    public static void writeAllText(java.lang.String path, java.lang.String text, java.lang.Boolean append) {
        if (append){
            appendAllText(path,text);
        }
        else {
            writeAllText(path,text,append,new Encoding("UTF8"));
        }
    }

    public static void writeAllText(java.lang.String path, java.lang.String text, java.lang.Boolean append, $Ku.by.Object.Encoding encoding) {
        if (append) {
            appendAllText(path, text, encoding);
        } else {
            java.io.File file = new java.io.File(path);
            try {
                Objects.requireNonNull(text);
                java.nio.charset.CharsetEncoder encoder = encoding.encoding.newEncoder();
                try (OutputStream out = Files.newOutputStream(file.toPath());
                     BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(out, encoder))) {
                    String bomCs = new String(Objects.requireNonNull(getBom(encoding)), encoding.encoding);
                    if (!text.startsWith(bomCs)) {
                        writer.append(bomCs);
                    }
                    writer.append(text);
                }
            } catch (IOException e) {
                throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.FileWritingError, path, e));
            }
        }
    }

    public static byte[] $toPrimitives(java.lang.Byte[] oBytes) {
        byte[] bytes = new byte[oBytes.length];

        for(int i = 0; i < oBytes.length; i++) {
            bytes[i] = oBytes[i];
        }

        return bytes;
    }

    public static java.lang.Byte[] $toObjects(byte[] bytesPrim) {
        Byte[] bytes = new Byte[bytesPrim.length];

        int i = 0;
        for (byte b : bytesPrim) bytes[i++] = b; // Autoboxing

        return bytes;
    }
}
