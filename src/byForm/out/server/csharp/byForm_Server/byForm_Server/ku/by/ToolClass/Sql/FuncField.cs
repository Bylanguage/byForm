using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class FuncField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField
    {
        public override string Alias { get; set; }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public override string FieldAccess
        {
            get
            {
                if (this.AggregateFunction != FunctionEnum.NONE)
                {
                    if (this.Params.Count != 1)
                    {
                        ThrowHelper.ThrowUnKnownException("聚合函数 " + this.FuncName + " 填充错误");
                    }
                }

                if (this.FieldTable != null)
                {
                    if (this.FieldTable.Alias == null)
                    {
                        ThrowHelper.ThrowUnKnownException(ErrorInfo.ColumnWithoutAlias);
                    }

                    if (this.Alias == null)
                    {
                        ThrowHelper.ThrowUnKnownException(ErrorInfo.ColumnWithoutAlias);
                    }

                    return this.FieldTable.Alias + "." + this.Alias;
                }

                StringBuilder tmpReturnValue = new StringBuilder();

                if (this.FuncName == "DATE_ADD")
                {
                    string tmpType = this.Params[2].FieldAccess;
                    tmpReturnValue.Append(this.FuncName);
                    tmpReturnValue.Append("(");
                    tmpReturnValue.Append(this.Params[0].FieldAccess);
                    tmpReturnValue.Append(", ");
                    tmpReturnValue.Append("INTERVAL ");
                    if (tmpType == "MICROSECOND")
                    {
                        tmpReturnValue.Append("(");
                    }
                    tmpReturnValue.Append(Params[1].FieldAccess);
                    if (tmpType == "MICROSECOND")
                    {
                        tmpReturnValue.Append(" * 1000)");
                    }
                    tmpReturnValue.Append(" ");
                    tmpReturnValue.Append(tmpType);
                    tmpReturnValue.Append(")");
                    return tmpReturnValue.ToString();
                }

                if (this.FuncName == "EXTRACT")
                {
                    tmpReturnValue.Append(this.FuncName);
                    tmpReturnValue.Append("(");
                    tmpReturnValue.Append(this.Params[0].FieldAccess);
                    tmpReturnValue.Append(" FROM ");
                    tmpReturnValue.Append(this.Params[1].FieldAccess);
                    tmpReturnValue.Append(")");
                    return tmpReturnValue.ToString();
                }

                if (this.FuncName == "CAST")
                {
                    tmpReturnValue.Append(this.FuncName);
                    tmpReturnValue.Append("(");
                    tmpReturnValue.Append(this.Params[0].FieldAccess);
                    tmpReturnValue.Append(" AS ");
                    tmpReturnValue.Append(this.Params[1].FieldAccess);
                    tmpReturnValue.Append(")");
                    return tmpReturnValue.ToString();
                }

                tmpReturnValue.Append(this.FuncName);
                tmpReturnValue.Append("(");

                for (int i = 0; i < this.Params.Count; i++)
                {
                    if (i != 0)
                    {
                        tmpReturnValue.Append(", ");
                    }

                    var tmpItem = this.Params[i];
                    tmpReturnValue.Append(tmpItem.FieldAccess);
                }

                tmpReturnValue.Append(")");


                return tmpReturnValue.ToString();
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                StringBuilder tmpReturnValue = new StringBuilder();

                if (this.FuncName == "DATE_ADD")
                {
                    string tmpType = this.Params[2].FieldAccess;
                    tmpReturnValue.Append(this.FuncName);
                    tmpReturnValue.Append("(");
                    tmpReturnValue.Append(this.Params[0].FieldAccess);
                    tmpReturnValue.Append(", ");
                    tmpReturnValue.Append("INTERVAL ");
                    if (tmpType == "MICROSECOND")
                    {
                        tmpReturnValue.Append("(");
                    }
                    tmpReturnValue.Append(Params[1].FieldAccess);
                    if (tmpType == "MICROSECOND")
                    {
                        tmpReturnValue.Append(" * 1000)");
                    }
                    tmpReturnValue.Append(" ");
                    tmpReturnValue.Append(tmpType);
                    tmpReturnValue.Append(")");
                    return tmpReturnValue.ToString();
                }

                if (this.FuncName == "EXTRACT")
                {
                    tmpReturnValue.Append(this.FuncName);
                    tmpReturnValue.Append("(");
                    tmpReturnValue.Append(this.Params[0].FieldAccess);
                    tmpReturnValue.Append(" FROM ");
                    tmpReturnValue.Append(this.Params[1].FieldAccess);
                    tmpReturnValue.Append(")");
                    return tmpReturnValue.ToString();
                }

                if (this.FuncName == "CAST")
                {
                    tmpReturnValue.Append(this.FuncName);
                    tmpReturnValue.Append("(");
                    tmpReturnValue.Append(this.Params[0].FieldAccess);
                    tmpReturnValue.Append(" AS ");
                    tmpReturnValue.Append(this.Params[1].FieldAccess);
                    tmpReturnValue.Append(")");
                    return tmpReturnValue.ToString();
                }

                tmpReturnValue.Append(this.FuncName);
                tmpReturnValue.Append("(");

                for (int i = 0; i < this.Params.Count; i++)
                {
                    if (i != 0)
                    {
                        tmpReturnValue.Append(", ");
                    }

                    var tmpItem = this.Params[i];
                    tmpReturnValue.Append(tmpItem.FieldAccess);
                }

                tmpReturnValue.Append(")");

                if (this.Alias != null)
                {
                    tmpReturnValue.Append(" " + this.Alias);
                }
                return tmpReturnValue.ToString();
            }
        }

        public string FuncName { get; set; }

        public System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField> Params { get; set; }

        public byForm_Server.ku.FunctionEnum AggregateFunction { get; set; }

        public FuncField(string f_FuncName, byForm_Server.ku.DataTypeEnum f_Type, string f_DecKuName, byForm_Server.ku.DBTypeEnum f_ExecuteDBType)
        {
            switch (f_FuncName.ToUpper())
            {
                case "AVG":
                    this.AggregateFunction = FunctionEnum.AVG;
                    break;
                case "SUM":
                    this.AggregateFunction = FunctionEnum.SUM;
                    break;
                case "MIN":
                    this.AggregateFunction = FunctionEnum.MIN;
                    break;
                case "COUNT":
                    this.AggregateFunction = FunctionEnum.COUNT;
                    break;
                case "MAX":
                    this.AggregateFunction = FunctionEnum.MAX;
                    break;
                default:
                    this.AggregateFunction = FunctionEnum.NONE;
                    break;
            }

            if (f_DecKuName != null)
            {
                DBTypeEnum tmpDBType;

                if (!Root.GetInstance().KuTypeDic.TryGetValue(f_DecKuName, out tmpDBType))
                {
                    ThrowHelper.ThrowUnKnownException(string.Format(ErrorInfo.KuTypeNotLoad, f_DecKuName));
                }
            }

            this.FuncName = f_FuncName;
            this.Params = new List<AbstractSelectField>();
            this.FieldType = f_Type;
        }

        public void GenerateType()
        {
            if (this.AggregateFunction != FunctionEnum.NONE)
            {
                if (this.AggregateFunction == FunctionEnum.COUNT)
                {
                    this.FieldType = DataTypeEnum.Int;
                    return;
                }

                var tmpParam = this.Params[0];
                this.FieldType = tmpParam.FieldType;
            }
        }
    }
}
