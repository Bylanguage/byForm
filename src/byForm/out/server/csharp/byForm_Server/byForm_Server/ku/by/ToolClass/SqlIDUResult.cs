using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class SqlIDUResult : byForm_Server.ku.by.ToolClass.IExecItem
    {
        public SqlIDUResult(string f_SqlCommand, string f_OracleMethodName, string f_DecKu)
        {
            sqlCommandText = f_SqlCommand;
            OracleMethodName = f_OracleMethodName;
            decKu = f_DecKu;
        }

        private string decKu;

        private string sqlCommandText;

        public string SqlCommandText
        {
            get
            {
                return sqlCommandText;
            }
        }

        public string OracleMethodName { get; set; }

        public void FillDateset(System.Data.DataTable f_DataTable)
        {
            ThrowHelper.ThrowUnKnownException("查询结果填充错误");
        }

        public string ExecuteKuName()
        {
            return Root.GetInstance().KuNameReflectionDic.ContainsKey(decKu) ? Root.GetInstance().KuNameReflectionDic[decKu] : decKu;
        }

        public string DecKuName()
        {
            return decKu;
        }
    }
}
