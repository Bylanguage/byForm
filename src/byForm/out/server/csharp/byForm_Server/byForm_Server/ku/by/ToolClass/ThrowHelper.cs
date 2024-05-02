using System;
using byForm_Server.ku.by.ToolClass.Exceptions;
namespace byForm_Server.ku.by.ToolClass
{
    public class ThrowHelper
    {
        public static byForm_Server.ku.by.ToolClass.Exceptions.ParseTransferException ThrowParseTransferException(string f_Message)
        {
            throw new ParseTransferException("传输数据解析错误->" + f_Message);
        }

        public static byForm_Server.ku.by.ToolClass.Exceptions.KuInitException ThrowKuInitException(string f_Message)
        {
            throw new KuInitException("库初始化错误->" + f_Message);
        }

        public static byForm_Server.ku.by.ToolClass.Exceptions.SqlPreCompileException ThrowSqlPreCompileException(string f_Message)
        {
            throw new SqlPreCompileException("sql预编译错误->" + f_Message);
        }

        public static byForm_Server.ku.by.ToolClass.Exceptions.VerifyException ThrowVerifyException(string f_Message)
        {
            throw new VerifyException("和数据表的验证配置不符->" + f_Message);
        }

        public static byForm_Server.ku.by.ToolClass.Exceptions.FuncInvocationException ThrowFuncException(string f_Message)
        {
            throw new FuncInvocationException("调用错误->" + f_Message);
        }

        public static byForm_Server.ku.by.ToolClass.Exceptions.DataMatchException ThrowDataMatchException(string f_Message)
        {
            throw new DataMatchException("数据匹配错误->" + f_Message);
        }

        public static byForm_Server.ku.by.ToolClass.Exceptions.RelationOperationException ThrowRelationOperationException(string f_Message)
        {
            throw new RelationOperationException("关系运算错误->" + f_Message);
        }

        public static byForm_Server.ku.by.ToolClass.Exceptions.SerializeException ThrowSerializeException(string f_Message)
        {
            throw new SerializeException("对象序列化错误->" + f_Message);
        }

        public static byForm_Server.ku.by.ToolClass.Exceptions.OrmException ThrowOrmException(string f_Message)
        {
            throw new OrmException("orm操作错误->" + f_Message);
        }

        public static System.Exception ThrowUnKnownException(string f_Message)
        {
            throw new Exception("未知异常， 请联系开发人员解决->" + f_Message);
        }
    }
}
