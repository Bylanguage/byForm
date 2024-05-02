using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class SqlInvocation
    {
        public static string SqlResult;

        public static string InsertSql(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet, string[] f_Columns, byForm_Server.ku.by.Object.Row f_Row)
        {
            if (f_Columns.Length == 0)
            {
                return "";
            }

            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_DataSheet.KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_DataSheet.KuName));
            }

            StringBuilder tmpSql = new StringBuilder();
            StringBuilder tmpValues = new StringBuilder(" VALUES(");
            tmpSql.Append("INSERT INTO ");

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                tmpSql.Append("[" + f_DataSheet.SheetName + "] (");
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append("`" + f_DataSheet.SheetName + "` (");
            }
            else
            {
                tmpSql.Append("\"" + f_DataSheet.SheetName + "\" (");
            }

            for (int i = 0; i < f_Columns.Length; i++)
            {
                //tmpSql.Append("[" + f_DataSheet.SheetName);
                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpSql.Append("[" + f_Columns[i] + "]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpSql.Append("`" + f_Columns[i] + "`");
                }
                else
                {
                    tmpSql.Append("\"" + f_Columns[i] + "\"");
                }

                var tmpCell = f_Row.cells.Find(item => item.ColumnName == f_Columns[i]);
                if (tmpCell != null)
                {
                    tmpValues.Append(tmpCell.value.ToString());
                }
                else
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowInvocationFiledInRowMissing, f_DataSheet.KuName + "." + f_DataSheet.SheetName, "insert", f_Columns[i]));
                }

                if (i != f_Columns.Length - 1)
                {
                    tmpSql.Append(", ");
                    if (tmpCell != null)
                    {
                        tmpValues.Append(", ");
                    }
                }
            }

            foreach (var column in f_DataSheet.DefaultColumnList)
            {
                if (f_Columns.Contains(column))
                {
                    continue;
                }
                if (tmpSql.Length != 16 + f_DataSheet.SheetName.Length)
                {
                    tmpSql.Append(", ");
                }

                if (tmpValues.Length != 8)
                {
                    tmpValues.Append(", ");
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    //tmpSql.Append("[" + f_DataSheet.SheetName);
                    //tmpSql.Append("].[" + column + "]");
                    tmpSql.Append("[" + column + "]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpSql.Append("`" + column + "`");
                }
                else
                {
                    tmpSql.Append("\"" + column + "\"");
                }

                string tmpDefault = f_DataSheet.GetFieldDefault(column);
                tmpValues.Append(tmpDefault);
            }

            tmpSql.Append(")");
            tmpValues.Append(")");
            tmpSql.Append(tmpValues);

            if (tmpDBType == DBTypeEnum.Mysql || tmpDBType == DBTypeEnum.Oracle)
            {
                tmpSql.Append(";");
            } 

            return tmpSql.ToString();
        }

        public static string UpdateSql(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet, string[] f_Columns, byForm_Server.ku.by.Object.Row f_Row, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Field> f_PKList)
        {
            //原则上主键不更新
            if (f_Columns.Length == 0)
            {
                return "";
            }

            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_DataSheet.KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_DataSheet.KuName));
            }

            StringBuilder tmpSql = new StringBuilder("UPDATE ");

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                tmpSql.Append("[" + f_DataSheet.SheetName + "] SET ");
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append("`" + f_DataSheet.SheetName + "` SET ");
            }
            else
            {
                tmpSql.Append("\"" + f_DataSheet.SheetName + "\" SET ");
            }

            for (int i = 0; i < f_Columns.Length; i++)
            {
                var tmpCell = f_Row.cells.Find(item => item.ColumnName == f_Columns[i]);
                if (tmpCell == null)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowInvocationFiledInRowMissing, f_DataSheet.KuName + "." + f_DataSheet.SheetName, "update", f_Columns[i]));
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpSql.Append("[" + f_Columns[i] + "] = ");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpSql.Append("`" + f_Columns[i] + "` = ");
                }
                else
                {
                    tmpSql.Append("\"" + f_Columns[i] + "\" = ");
                }

                tmpSql.Append(tmpCell.value.ToString());

                if (i != f_Columns.Length - 1)
                {
                    tmpSql.Append(", ");
                }
            }

            if (f_PKList.Count != 0)
            {
                tmpSql.Append(" WHERE ");
                for (int i = 0; i < f_PKList.Count; i++)
                {
                    var tmpCell = f_Row.cells.Find(item => item.ColumnName == f_PKList[i].Name);
                    if (tmpCell == null)
                    {
                        ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.UpdateFlowRowParmPKMissing);
                    }

                    if (tmpDBType == DBTypeEnum.SqlServer)
                    {
                        tmpSql.Append("[" + f_PKList[i].Name + "]" + " = ");
                    }
                    else if (tmpDBType == DBTypeEnum.Mysql)
                    {
                        tmpSql.Append("`" + f_PKList[i].Name + "`" + " = ");
                    }
                    else
                    {
                        tmpSql.Append("\"" + f_PKList[i].Name + "\"" + " = ");
                    }

                    tmpSql.Append(tmpCell.value.ToString());

                    if (i != f_PKList.Count - 1)
                    {
                        tmpSql.Append(", ");
                    }
                }
            }

            if (tmpDBType == DBTypeEnum.Mysql || tmpDBType == DBTypeEnum.Oracle)
            {
                tmpSql.Append(";");
            } 

            return tmpSql.ToString();
        }

        public static string DeleteSql(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet, string[] f_Columns, byForm_Server.ku.by.Object.Row f_Row)
        {
            if (f_Columns.Length == 0)
            {
                return "";
            }

            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.TryGetValue(f_DataSheet.KuName, out tmpDBType))
            {
                ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_DataSheet.KuName));
            }

            StringBuilder tmpSql = new StringBuilder("DELETE FROM ");

            if (tmpDBType == DBTypeEnum.SqlServer)
            {
                tmpSql.Append("[" + f_DataSheet.SheetName + "] WHERE ");
            }
            else if (tmpDBType == DBTypeEnum.Mysql)
            {
                tmpSql.Append("`" + f_DataSheet.SheetName + "` WHERE ");
            }
            else
            {
                tmpSql.Append("\"" + f_DataSheet.SheetName + "\" WHERE ");
            }

            for (int i = 0; i < f_Columns.Length; i++)
            {
                var tmpCell = f_Row.cells.Find(item => item.ColumnName == f_Columns[i]);
                if (tmpCell == null)
                {
                    ThrowHelper.ThrowSqlPreCompileException(string.Format(ErrorInfo.FlowInvocationFiledInRowMissing, f_DataSheet.KuName + "." + f_DataSheet.SheetName, "delete", f_Columns[i]));
                }

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpSql.Append("[" + f_Columns[i] + "] = ");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpSql.Append("`" + f_Columns[i] + "` = ");
                }
                else
                {
                    tmpSql.Append("\"" + f_Columns[i] + "\" = ");
                }

                tmpSql.Append(tmpCell.value.ToString());

                if (i != f_Columns.Length - 1)
                {
                    tmpSql.Append(" AND ");
                }
            }

            if (tmpDBType == DBTypeEnum.Mysql || tmpDBType == DBTypeEnum.Oracle)
            {
                tmpSql.Append(";");
            } 

            return tmpSql.ToString();
        }
    }
}
