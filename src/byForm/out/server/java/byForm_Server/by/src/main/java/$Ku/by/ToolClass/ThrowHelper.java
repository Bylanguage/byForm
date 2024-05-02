package $Ku.by.ToolClass;

import $Ku.by.ToolClass.Exceptions.*;
public class ThrowHelper {
    public static $Ku.by.ToolClass.Exceptions.ParseTransferException ThrowFuncException(java.lang.String f_Message) {
        throw new FuncInvocationException($Ku.by.ToolClass.ErrorInfo.ParseError + f_Message);
    }

    public static $Ku.by.ToolClass.Exceptions.ParseTransferException ThrowParseTransferException(java.lang.String f_Message) {
        throw new ParseTransferException($Ku.by.ToolClass.ErrorInfo.ParseError + f_Message);
    }

    public static $Ku.by.ToolClass.Exceptions.KuInitException ThrowKuInitException(java.lang.String f_Message) {
        throw new KuInitException($Ku.by.ToolClass.ErrorInfo.KuInitError + f_Message);
    }

    public static $Ku.by.ToolClass.Exceptions.SqlPreCompileException ThrowSqlPreCompileException(java.lang.String f_Message) {
        throw new SqlPreCompileException($Ku.by.ToolClass.ErrorInfo.SqlPreCompileError + f_Message);
    }

    public static $Ku.by.ToolClass.Exceptions.VerifyException ThrowVerifyException(java.lang.String f_Message) {
        throw new VerifyException($Ku.by.ToolClass.ErrorInfo.VerifyError + f_Message);
    }

    public static $Ku.by.ToolClass.Exceptions.FuncInvocationException ThrowFuncInvocationException(java.lang.String f_Message) {
        throw new FuncInvocationException($Ku.by.ToolClass.ErrorInfo.FuncInvocationError + f_Message);
    }

    public static $Ku.by.ToolClass.Exceptions.DataMatchException ThrowDataMatchException(java.lang.String f_Message) {
        throw new DataMatchException($Ku.by.ToolClass.ErrorInfo.DataMatchError + f_Message);
    }

    public static $Ku.by.ToolClass.Exceptions.RelationOperationException ThrowRelationOperationException(java.lang.String f_Message) {
        throw new RelationOperationException($Ku.by.ToolClass.ErrorInfo.RelationOperationError + f_Message);
    }

    public static $Ku.by.ToolClass.Exceptions.OrmException ThrowOrmException(java.lang.String f_Message) {
        throw new OrmException($Ku.by.ToolClass.ErrorInfo.OrmError + f_Message);
    }

    public static java.lang.RuntimeException ThrowUnKnownException(java.lang.String f_Message) {
        throw new RuntimeException($Ku.by.ToolClass.ErrorInfo.UnKnownError + f_Message);
    }
}
