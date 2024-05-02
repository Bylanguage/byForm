package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.*;
public class SqlField {
    public $Ku.by.ToolClass.Sql.SqlField ReferenceField;
    private java.lang.String privateName;
    private java.lang.String privateKuName;
    private java.lang.String privateSheetName;
    private $Ku.by.ToolClass.DataTypeEnum privateFieldType = $Ku.by.ToolClass.DataTypeEnum.forValue(0);
    private $Ku.by.ToolClass.FunctionEnum privateFunc = $Ku.by.ToolClass.FunctionEnum.forValue(0);
    private java.lang.Class<?> privateEnumType;
    private $Ku.by.ToolClass.AbstractIdentityBase privateIdentity;

    public SqlField(java.lang.String f_KuName, java.lang.String f_SheetName, java.lang.String f_Name, $Ku.by.ToolClass.DataTypeEnum f_Type) {
        this.setKuName(f_KuName);
        this.setName(f_Name);
        this.setSheetName(f_SheetName);
        this.setFieldType(f_Type);
        this.setFunc(FunctionEnum.NONE);
    }

    public SqlField(java.lang.String f_KuName, java.lang.String f_SheetName, java.lang.String f_Name, $Ku.by.ToolClass.DataTypeEnum f_Type, $Ku.by.ToolClass.FunctionEnum f_Func) {
        this.setKuName(f_KuName);
        this.setName(f_Name);
        this.setSheetName(f_SheetName);
        this.setFieldType(f_Type);
        this.setFunc(f_Func);
    }

    public SqlField(java.lang.String f_KuName, java.lang.String f_SheetName, java.lang.String f_Name, java.lang.Class<?> f_EnumPath) {
        this.setKuName(f_KuName);
        this.setFieldType(DataTypeEnum.Enum);
        this.setName(f_Name);
        this.setSheetName(f_SheetName);
        this.setEnumType(f_EnumPath);
        this.setFunc(FunctionEnum.NONE);
    }

    public SqlField(java.lang.String f_KuName, java.lang.String f_SheetName, java.lang.String f_Name, java.lang.Class<?> f_EnumPath, $Ku.by.ToolClass.FunctionEnum f_Func) {
        this.setKuName(f_KuName);
        this.setName(f_Name);
        this.setSheetName(f_SheetName);
        this.setEnumType(f_EnumPath);
        this.setFunc(f_Func);
        this.setFieldType(DataTypeEnum.Enum);
    }


    public final java.lang.String getName() {
        return privateName;
    }

    private void setName(java.lang.String value) {
        privateName = value;
    }

    public final java.lang.String getKuName() {
        return privateKuName;
    }

    private void setKuName(java.lang.String value) {
        privateKuName = value;
    }

    public final java.lang.String getSheetName() {
        return privateSheetName;
    }

    private void setSheetName(java.lang.String value) {
        privateSheetName = value;
    }

    public final $Ku.by.ToolClass.DataTypeEnum getFieldType() {
        return privateFieldType;
    }

    private void setFieldType($Ku.by.ToolClass.DataTypeEnum value) {
        privateFieldType = value;
    }

    public final $Ku.by.ToolClass.FunctionEnum getFunc() {
        return privateFunc;
    }

    private void setFunc($Ku.by.ToolClass.FunctionEnum value) {
        privateFunc = value;
    }

    public final java.lang.Class<?> getEnumType() {
        return privateEnumType;
    }

    private void setEnumType(java.lang.Class<?> value) {
        privateEnumType = value;
    }

    public final $Ku.by.ToolClass.AbstractIdentityBase getIdentity() {
        return privateIdentity;
    }

    public void setIdentity($Ku.by.ToolClass.AbstractIdentityBase value) {
        privateIdentity = value;
    }

    public final boolean ValueIsSame($Ku.by.ToolClass.Sql.SqlField f_Field) {
        if (f_Field == null)
        {
            return false;
        }

        if (this.getName().equals(f_Field.getName()) && this.getKuName().equals(f_Field.getKuName()) && this.getSheetName().equals(f_Field.getSheetName()) && f_Field.getFieldType() == this.getFieldType() && f_Field.getFunc() == this.getFunc() && f_Field.getEnumType() == this.getEnumType())
        {
            return true;
        }

        return false;
    }

    public java.lang.String toString() {
        return this.getName();
    }

    public $Ku.by.ToolClass.Sql.SqlField CopyWithoutSheet() {
        return new $Ku.by.ToolClass.Sql.SqlField(null, null, privateName, privateFieldType);
    }
}
