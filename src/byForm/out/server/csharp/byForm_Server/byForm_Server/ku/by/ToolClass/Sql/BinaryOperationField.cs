using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class BinaryOperationField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField
    {
        private readonly static string plus = "+";

        public override string Alias { get; set; }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public override string FieldAccess
        {
            get
            {
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
                else
                {
                    StringBuilder tmpReturn = new StringBuilder();
                    var tmpLeftField = this.Left;
                    tmpReturn.Append(tmpLeftField.FieldAccess);
                    tmpReturn.Append(" ");
                    tmpReturn.Append(this.Operator);
                    tmpReturn.Append(" ");
                    var tmpRightField = this.Right;
                    tmpReturn.Append(tmpRightField.FieldAccess);
                    return tmpReturn.ToString();
                }
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                if (this.Operator == null)
                {
                    ThrowHelper.ThrowUnKnownException(ErrorInfo.OperatorIsNull);
                }
                StringBuilder tmpReturnValue = new StringBuilder();
                var tmpLeft = this.Left;
                tmpReturnValue.Append(tmpLeft.FieldAccess);
                tmpReturnValue.Append(" ");
                tmpReturnValue.Append(this.Operator);
                tmpReturnValue.Append(" ");
                var tmpRight = this.Right;
                tmpReturnValue.Append(tmpRight.FieldAccess);
                if (this.Alias != null)
                {
                    tmpReturnValue.Append(" " + this.Alias);
                }

                return tmpReturnValue.ToString();
            }
        }

        public string Operator { get; set; }

        public byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField Left { get; set; }

        public byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField Right { get; set; }

        public BinaryOperationField(byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_Left, byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_Right, string f_Operator)
        {
            this.Left = f_Left;
            this.Right = f_Right;
            this.Operator = f_Operator;
            this.GenerateType();
        }

        private void GenerateType()
        {
            if (this.Left == null && this.Right == null)
            {
                ThrowHelper.ThrowUnKnownException("未知的二元运算表达式类型");
            }

if (this.Left != null && this.Right != null)
            {
                if (this.Operator == plus)
                {
                    if (this.Left.FieldType == DataTypeEnum.String || this.Right.FieldType == DataTypeEnum.String)
                    {
                        this.FieldType = DataTypeEnum.String;
                        return;
                    }
                }
                //char和任何类型数值加返回对应类型

                if (this.Left.FieldType == this.Right.FieldType)
                {
                    this.FieldType = this.Left.FieldType;
                    return;
                }

                if (this.Left.FieldType == DataTypeEnum.Double || this.Right.FieldType == DataTypeEnum.Double)
                {
                    this.FieldType = DataTypeEnum.Double;
                    return;
                }

                if (this.Left.FieldType == DataTypeEnum.Float || this.Right.FieldType == DataTypeEnum.Float)
                {
                    this.FieldType = DataTypeEnum.Float;
                    return;
                }

                if (this.Left.FieldType == DataTypeEnum.Decimal || this.Right.FieldType == DataTypeEnum.Decimal)
                {
                    this.FieldType = DataTypeEnum.Decimal;
                    return;
                }

                if (this.Left.FieldType == DataTypeEnum.Long || this.Right.FieldType == DataTypeEnum.Long)
                {
                    this.FieldType = DataTypeEnum.Long;
                    return;
                }

                if (this.Left.FieldType == DataTypeEnum.Int || this.Right.FieldType == DataTypeEnum.Int)
                {
                    this.FieldType = DataTypeEnum.Int;
                    return;
                }

                if (this.Left.FieldType == DataTypeEnum.Short || this.Right.FieldType == DataTypeEnum.Short)
                {
                    this.FieldType = DataTypeEnum.Short;
                    return;
                }

                if (this.Left.FieldType == DataTypeEnum.Byte || this.Right.FieldType == DataTypeEnum.Byte)
                {
                    this.FieldType = DataTypeEnum.Byte;
                    return;
                }
            }

            if (this.Right == null)
            {
                this.FieldType = this.Left.FieldType;
            }
            
            if(this.Left == null)
            {
                this.FieldType = this.Right.FieldType;
            }

            ThrowHelper.ThrowUnKnownException("未知的二元运算表达式类型");
        }
    }
}
