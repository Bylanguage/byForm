package $Ku.by.Object;

import java.util.*;
import java.io.*;
import java.nio.file.*;
public class Directory extends $Ku.by.Object.ByObject {
    public java.io.File file;

    private Directory() {
    }

    public Directory(java.lang.String path) {
        this.file = new java.io.File(path);
    }


    public static void createDirectory(java.lang.String path) {
        java.io.File directory = new java.io.File(path);
        if (!directory.exists()) {
            boolean wasSuccessful = directory.mkdirs();
        }
    }

    public static void delete(java.lang.String path, boolean recursive) {
        java.io.File directory = new java.io.File(path);
        if (directory.exists()) {
            if (recursive) {
                $deleteRecursively(directory);
            } else {
                boolean wasSuccessful = directory.delete();
            }
        }
    }

    private static void $deleteRecursively(java.io.File file) {
        if (file.isDirectory()) {
            for (java.io.File subFile : Objects.requireNonNull(file.listFiles())) {
                $deleteRecursively(subFile);
            }
        }
        boolean wasSuccessful = file.delete();
    }

    public static boolean exists(java.lang.String path) {
        return new java.io.File(path).exists();
    }

    public static java.lang.String[] getDirectories(java.lang.String path) {
        ArrayList<String> directories = new ArrayList<>();
        java.io.File directory = new java.io.File(path);
        if (directory.exists() && directory.isDirectory()) {
            for (java.io.File subFile : Objects.requireNonNull(directory.listFiles())) {
                if (subFile.isDirectory()) {
                    directories.add(subFile.getAbsolutePath());
                }
            }
            int length = directories.size();
            return directories.toArray(new String[length]);
        }
        else{
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.DirectoryNotFound ,path));
        }
    }

    public static java.lang.String getDirectoryRoot(java.lang.String path) {
        java.io.File directory = new java.io.File(path);
        if (directory.exists()) {
            return directory.toPath().getRoot().toString();
        }
        throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.DirectoryNotFound ,path));
    }

    public static java.lang.String[] getFiles(java.lang.String path) {
        ArrayList<String> files = new ArrayList<>();
        java.io.File directory = new java.io.File(path);
        if (directory.exists() && directory.isDirectory()) {
            for (java.io.File subFile : Objects.requireNonNull(directory.listFiles())) {
                if (subFile.isFile()) {
                    files.add(subFile.getAbsolutePath());
                }
            }
            int length = files.size();
            return files.toArray(new String[length]);
        }
        throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.DirectoryNotFound ,path));
    }

    public static void move(java.lang.String path, java.lang.String newPath) {
        java.io.File sourceDirectory = new java.io.File(path);
        java.io.File targetDirectory = new java.io.File(newPath);
        if (sourceDirectory.exists()) {
            if (!targetDirectory.exists()) {
                try {
                    Files.move(sourceDirectory.toPath(), targetDirectory.toPath(), StandardCopyOption.REPLACE_EXISTING);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        } else {
            throw new RuntimeException(String.format($Ku.by.ToolClass.ErrorInfo.DirectoryNotFound ,path));
        }
    }
}
