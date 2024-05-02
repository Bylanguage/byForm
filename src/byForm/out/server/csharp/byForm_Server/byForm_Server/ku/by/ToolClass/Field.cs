using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class Field
    {
        public string Name { get; private set; }

        public string KuName { get; private set; }

        public string SheetName { get; private set; }

        public byForm_Server.ku.DataTypeEnum FieldType { get; private set; }

        public byForm_Server.ku.FunctionEnum Func { get; private set; }

        public System.Type EnumType { get; private set; }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity { get; set; }

        public byForm_Server.ku.by.ToolClass.Field ReferenceField { get; set; }

        public Field(string f_KuName, string f_SheetName, string f_Name, byForm_Server.ku.DataTypeEnum f_Type)
        {
            this.KuName = f_KuName;
            this.Name = f_Name;
            this.SheetName = f_SheetName;
            this.FieldType = f_Type;
            this.Func = FunctionEnum.NONE;
        }

        public Field(string f_KuName, string f_SheetName, string f_Name, byForm_Server.ku.DataTypeEnum f_Type, byForm_Server.ku.FunctionEnum f_Func)
        {
            this.KuName = f_KuName;
            this.Name = f_Name;
            this.SheetName = f_SheetName;
            this.FieldType = f_Type;
            this.Func = f_Func;
        }

        public Field(string f_KuName, string f_SheetName, string f_Name, System.Type f_EnumPath)
        {
            this.KuName = f_KuName;
            this.FieldType = DataTypeEnum.Enum;
            this.Name = f_Name;
            this.SheetName = f_SheetName;
            this.EnumType = f_EnumPath;
            this.Func = FunctionEnum.NONE;
        }

        public Field(string f_KuName, string f_SheetName, string f_Name, System.Type f_EnumPath, byForm_Server.ku.FunctionEnum f_Func)
        {
            this.KuName = f_KuName;
            this.Name = f_Name;
            this.SheetName = f_SheetName;
            this.EnumType = f_EnumPath;
            this.Func = f_Func;
            this.FieldType = DataTypeEnum.Enum;
        }

        public bool ValueIsSame(byForm_Server.ku.by.ToolClass.Field f_Field)
        {
            if (f_Field == null)
            {
                return false;
            }

            if (f_Field.Name == this.Name && f_Field.KuName == this.KuName && f_Field.SheetName == this.SheetName && f_Field.FieldType == this.FieldType && f_Field.Func == this.Func && f_Field.EnumType == this.EnumType)
            {
                return true;
            }

            return false;
        }

        public byForm_Server.ku.by.ToolClass.Field CopyWithoutSheet()
        {
            return new Field(null, null, Name, FieldType);
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}",this.KuName ,this.SheetName ,this.Name);
        }
    }
}
