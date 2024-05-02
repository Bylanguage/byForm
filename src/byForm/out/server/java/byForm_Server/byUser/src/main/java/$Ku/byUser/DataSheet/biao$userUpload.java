package $Ku.byUser.DataSheet;

import $Ku.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import java.util.*;
public class biao$userUpload extends $Ku.by.Object.Table implements $Ku.by.ToolClass.IBaseDataSheet  {
    public java.util.LinkedHashMap<java.lang.String, java.util.ArrayList<$Ku.by.ToolClass.Source>> FlowDic;
    public java.util.LinkedHashMap<java.lang.String, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String>> VerifyDic;
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Sql.SqlField> FieldDic;
    public java.util.LinkedHashMap<java.lang.String, java.lang.String> ReferenceDic;
    public java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> PrimaryKeyList;
    java.util.ArrayList<java.lang.String> DefaultColumnList;
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Source> SourceDic;
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Sql.SqlField> ComponentDic;
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowFlow> RowFlowDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowsFlow> RowsFlowDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowArrayFlow> RowArrayFlowDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowFlowInTran> RowFlowInTranDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowsFlowInTran> RowsFlowInTranDic = new java.util.LinkedHashMap<>();
    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowArrayFlowInTran> RowArrayFlowInTranDic = new java.util.LinkedHashMap<>();
    public java.lang.String KuName;
    public java.lang.String SheetName;
    public java.lang.String IdentityName;
    public java.lang.Boolean IsConst = false;
    public $Ku.by.ToolClass.AbstractIdentityBase Identity;
    private java.lang.Integer _max = 0;
    private java.lang.Boolean maxSet = false;

    public biao$userUpload() {
        try {
            $Ku.by.Object.List<$Ku.by.Object.Field> tmpFields = new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Field.class));
            
            this.FieldDic = new java.util.LinkedHashMap<>();
            this.FlowDic = new java.util.LinkedHashMap<>();
            this.PrimaryKeyList = new java.util.ArrayList<>();
            this.ReferenceDic = new java.util.LinkedHashMap<>();
            this.ComponentDic = new java.util.LinkedHashMap<>();
            this.VerifyDic = new java.util.LinkedHashMap<>();
            this.SourceDic = new java.util.LinkedHashMap<>();
            this.DefaultColumnList = new java.util.ArrayList<>();
            this.IsConst = false;
            this.DataSheet = this;
            this.KuName = "byUser";

            this.SheetName = "userUpload";
            this.IdentityName = "byUser.userUpload";

            VerifyDic.put("iD", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean iD_notNull = true;
            VerifyDic.get("iD").put($Ku.by.Enum.Attribute.notNull, iD_notNull.toString());
            VerifyDic.put("fileName", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean fileName_notNull = true;
            VerifyDic.get("fileName").put($Ku.by.Enum.Attribute.notNull, fileName_notNull.toString());
            VerifyDic.put("fileSize", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("userID", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("summery", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("dT", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            this.FieldDic.put("iD", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "iD", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iID", this.FieldDic.get("iD"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("iD")));
            this.FieldDic.put("fileName", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "fileName", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iFileName", this.FieldDic.get("fileName"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("fileName")));
            this.FieldDic.put("fileSize", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "fileSize", $Ku.by.ToolClass.DataTypeEnum.Int));
            this.ComponentDic.put("iFileSize", this.FieldDic.get("fileSize"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("fileSize")));
            this.FieldDic.put("userID", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "userID", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iUserID", this.FieldDic.get("userID"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("userID")));
            this.FieldDic.put("summery", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "summery", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iSummery", this.FieldDic.get("summery"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("summery")));
            this.FieldDic.put("dT", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "dT", $Ku.by.ToolClass.DataTypeEnum.Datetime));
            this.ComponentDic.put("iDT", this.FieldDic.get("dT"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("dT")));
            this.fields = new $Ku.by.Object.ReadOnlyList<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Field.class), tmpFields);
            this.SourceDic.put("fileSize", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("fileSize")));
            this.PrimaryKeyList.add(this.FieldDic.get("iD"));

        }
        catch (java.lang.RuntimeException e) {
            StringBuilder tmpMessage = new StringBuilder(String.format("库 %1$s中数据表 %2$s 初始化出错", this.KuName, this.SheetName));
            tmpMessage.append(" " + e);
            throw new $Ku.by.ToolClass.Exceptions.KuInitException(tmpMessage.toString());
        }

    }


    public java.lang.String getKuName() {
        return this.KuName;
    }

    public void setKuName(java.lang.String kuName) {
        this.KuName = kuName;
    }

    public java.lang.String getSheetName() {
        return this.SheetName;
    }

    public void setSheetName(java.lang.String sheetName) {
        this.SheetName = sheetName;
    }

    public java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> getPrimaryKeyList() {
        return this.PrimaryKeyList;
    }

    public void setPrimaryKeyList(java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> PrimaryKeyList) {
        this.PrimaryKeyList = PrimaryKeyList;
    }

    public java.util.ArrayList<java.lang.String> getDefaultColumnList() {
        return this.DefaultColumnList;
    }

    public void setDefaultColumnList(java.util.ArrayList<java.lang.String> DefaultColumnList) {
        this.DefaultColumnList = DefaultColumnList;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Sql.SqlField> getComponentDic() {
        return this.ComponentDic;
    }

    public void setComponentDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Sql.SqlField> ComponentDic) {
        this.ComponentDic = ComponentDic;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Sql.SqlField> getFieldDic() {
        return this.FieldDic;
    }

    public void setFieldDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Sql.SqlField> FieldDic) {
        this.FieldDic = FieldDic;
    }

    public java.util.LinkedHashMap<java.lang.String, java.util.ArrayList<$Ku.by.ToolClass.Source>> getFlowDic() {
        return this.FlowDic;
    }

    public void setFlowDic(java.util.LinkedHashMap<java.lang.String, java.util.ArrayList<$Ku.by.ToolClass.Source>> FlowDic) {
        this.FlowDic = FlowDic;
    }

    public java.util.LinkedHashMap<java.lang.String, java.lang.String> getReferenceDic() {
        return this.ReferenceDic;
    }

    public void setReferenceDic(java.util.LinkedHashMap<java.lang.String, java.lang.String> ReferenceDic) {
        this.ReferenceDic = ReferenceDic;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Source> getSourceDic() {
        return this.SourceDic;
    }

    public void setSourceDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.Source> SourceDic) {
        this.SourceDic = SourceDic;
    }

    public java.util.LinkedHashMap<java.lang.String, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String>> getVerifyDic() {
        return this.VerifyDic;
    }

    public void setVerifyDic(java.util.LinkedHashMap<java.lang.String, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, java.lang.String>> VerifyDic) {
        this.VerifyDic = VerifyDic;
    }

    public $Ku.by.ToolClass.AbstractIdentityBase getIdentity() {
        return this.Identity;
    }

    public void setIdentity($Ku.by.ToolClass.AbstractIdentityBase Identity) {
        this.Identity = Identity;
    }

    public java.lang.String getIdentityName() {
        return this.IdentityName;
    }

    public java.lang.Boolean getIsConst() {
        return this.IsConst;
    }

    public void setIsConst(java.lang.Boolean IsConst) {
        this.IsConst = IsConst;
    }

    public void setIdentityName(java.lang.String IdentityName) {
        this.IdentityName = IdentityName;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowFlow> getRowFlowDic() {
        return this.RowFlowDic;
    }

    public void setRowFlowDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowFlow> value) {
        this.RowFlowDic = value;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowsFlow> getRowsFlowDic() {
        return this.RowsFlowDic;
    }

    public void setRowsFlowDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowsFlow> value) {
        this.RowsFlowDic = value;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowArrayFlow> getRowArrayFlowDic() {
        return this.RowArrayFlowDic;
    }

    public void setRowArrayFlowDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowArrayFlow> value) {
        this.RowArrayFlowDic = value;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowFlowInTran> getRowFlowInTranDic() {
        return this.RowFlowInTranDic;
    }

    public void setRowFlowInTranDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowFlowInTran> value) {
        this.RowFlowInTranDic = value;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowsFlowInTran> getRowsFlowInTranDic() {
        return this.RowsFlowInTranDic;
    }

    public void setRowsFlowInTranDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowsFlowInTran> value) {
        this.RowsFlowInTranDic = value;
    }

    public java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowArrayFlowInTran> getRowArrayFlowInTranDic() {
        return this.RowArrayFlowInTranDic;
    }

    public void setRowArrayFlowInTranDic(java.util.LinkedHashMap<java.lang.String, $Ku.by.ToolClass.IRowArrayFlowInTran> value) {
        this.RowArrayFlowInTranDic = value;
    }

    public java.lang.String getFieldDefault(java.lang.String f_FieldName) {
        switch (f_FieldName) {
            default :
                throw new RuntimeException(String.format("表 %1$s 错误的字段 %2$s 默认值调用", this.SheetName, f_FieldName));
        }
    }

    public void assembleFieldReference() {
        this.FieldDic.get("userID").ReferenceField = $Ku.by.ToolClass.Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user").getFieldDic().get("ID");
    }
}
