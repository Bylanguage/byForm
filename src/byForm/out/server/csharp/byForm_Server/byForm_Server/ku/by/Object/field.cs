using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class field : byForm_Server.ku.by.ToolClass.IIdentity
    {
        public byForm_Server.ku.by.ToolClass.Field Field;

        public field(byForm_Server.ku.by.ToolClass.Field f_Field)
        {
            this.Field = f_Field;
            this.name = f_Field.Name;
            this.summary = null;
        }

        public field(byForm_Server.ku.by.ToolClass.Field f_Field, string f_Summary)
        {
            this.Field = f_Field;
            this.name = f_Field.Name;
            this.summary = f_Summary;
        }

        public field()
        {
        }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity
        {
            get
            {
                if (this.Field == null)
                {
                    return null;
                }
                else return this.Field.Identity;
            }
            set
            {
                this.Field.Identity = value;
            }
        }

        public bool isBool
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Bool;
            }
        }

        public bool isChar
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Char;
            }
        }

        public bool isByte
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Byte;
            }
        }

        public bool isShort
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Short;
            }
        }

        public bool isInt
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Int;
            }
        }

        public bool isLong
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Long;
            }
        }

        public bool isFloat
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Float;
            }
        }

        public bool isDouble
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Double;
            }
        }

        public bool isDecimal
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Decimal;
            }
        }

        public bool isString
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.String;
            }
        }

        public bool isDatetime
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Datetime;
            }
        }

        public bool isEnum
        {
            get
            {
                if (Field == null)
                {
                    return false;
                }

                return Field.FieldType == DataTypeEnum.Enum;
            }
        }

        public string name { get; set; }

        public string summary { get; set; }

        public byForm_Server.ku.by.Object.field refField
        {
            get
            {
                if (_refField == null)
                {
                    var tmpKu = ToolClass.ToolFunction.GetKu(this.Field.KuName);
                    string tmpSheetName = this.Field.SheetName;
                    if (!tmpKu.RelationDic.ContainsKey(tmpSheetName))
                    {
                        return null;
                    }
                    var tmpRelations = tmpKu.RelationDic[tmpSheetName];
                    var tmpRelation = tmpRelations.Find(relation => relation.ReferenceSheet == tmpSheetName && relation.ReferenceFieldName == this.Field.Name);
                    if (tmpRelation == null)
                    {
                        return null;
                    }

                    var tmpRelationSheetName = tmpRelation.ReferencedSheet;
                    var tmpRelationFieldName = tmpRelation.ReferencedFieldName;
                    var tmpRefTable = (table)tmpKu.DataSheetDic[tmpRelationSheetName];
                    _refField = tmpRefTable.Fields[tmpRelationFieldName];
                }

                return _refField;
            }
        }

        private byForm_Server.ku.by.Object.field _refField;

        public byForm_Server.ku.by.Object.table refTable
        {
            get
            {
                if (_refTable == null)
                {
                    var tmpKu = ToolClass.ToolFunction.GetKu(this.Field.KuName);
                    string tmpSheetName = this.Field.SheetName;
                    if (!tmpKu.RelationDic.ContainsKey(tmpSheetName))
                    {
                        return null;
                    }
                    var tmpRelations = tmpKu.RelationDic[tmpSheetName];
                    var tmpRelation = tmpRelations.Find(relation => relation.ReferenceSheet == tmpSheetName && relation.ReferenceFieldName == this.Field.Name);
                    if (tmpRelation == null)
                    {
                        return null;
                    }
                    var tmpRelationSheetName = tmpRelation.ReferencedSheet;
                    _refTable = (table)tmpKu.DataSheetDic[tmpRelationSheetName];
                }

                return _refTable;
            }
        }

        private byForm_Server.ku.by.Object.table _refTable;

        public byForm_Server.ku.by.Object.table table
        {
            get
            {
                if (Field == null)
                {
                    return null;
                }

                if (Field.KuName!=null && Field.SheetName != null)
                {
                    if (_Table == null)
                    {
                        _Table = (table)ToolClass.ToolFunction.GetDataSheet(Field.KuName, Field.SheetName);
                    }
                }

                return _Table;
            }
        }

        private byForm_Server.ku.by.Object.table _Table;

        public byForm_Server.ku.by.Object.Result verify(object target)
        {
            Result tmpReturnValue = new Result();

            if (Field == null)
            {
                return tmpReturnValue;
            }

            try
            {
                var tmpVerifyDic = table.DataSheet.VerifyDic;
                ToolClass.VerifyFunction.FieldVerify(tmpVerifyDic[Field.Name],Field,target == null?null : target.ToString());
            }
            catch(Exception ex)
            {
                tmpReturnValue.isOk = false;
                tmpReturnValue.info = ex.Message;
                return tmpReturnValue;
            }

            tmpReturnValue.isOk = true;
            return tmpReturnValue;
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
