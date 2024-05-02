package $Ku.byUser.DataSheet;

import $Ku.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import java.util.*;
public class biao$user extends $Ku.by.Object.Table implements $Ku.by.ToolClass.IBaseDataSheet  {
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
    public java.util.ArrayList<$Ku.by.ToolClass.Source> flow$insert = new java.util.ArrayList<>();
    public java.util.ArrayList<$Ku.by.ToolClass.Source> flow$update = new java.util.ArrayList<>();
    public java.util.ArrayList<$Ku.by.ToolClass.Source> flow$updatePwd = new java.util.ArrayList<>();
    public java.util.ArrayList<$Ku.by.ToolClass.Source> flow$delete = new java.util.ArrayList<>();

    public biao$user() {
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

            this.SheetName = "user";
            this.IdentityName = "byUser.user";

            VerifyDic.put("ID", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean ID_notNull = true;
            VerifyDic.get("ID").put($Ku.by.Enum.Attribute.notNull, ID_notNull.toString());
            VerifyDic.put("freeze", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean freeze_notNull = true;
            VerifyDic.get("freeze").put($Ku.by.Enum.Attribute.notNull, freeze_notNull.toString());
            VerifyDic.put("rank", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("name", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean name_notNull = true;
            VerifyDic.get("name").put($Ku.by.Enum.Attribute.notNull, name_notNull.toString());
            VerifyDic.put("password", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean password_notNull = true;
            VerifyDic.get("password").put($Ku.by.Enum.Attribute.notNull, password_notNull.toString());
            VerifyDic.put("displayName", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean displayName_notNull = true;
            VerifyDic.get("displayName").put($Ku.by.Enum.Attribute.notNull, displayName_notNull.toString());
            VerifyDic.put("mobile", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean mobile_notNull = true;
            VerifyDic.get("mobile").put($Ku.by.Enum.Attribute.notNull, mobile_notNull.toString());
            VerifyDic.put("mail", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean mail_notNull = true;
            VerifyDic.get("mail").put($Ku.by.Enum.Attribute.notNull, mail_notNull.toString());
            VerifyDic.put("cerMode", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("cerName", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("cerNO", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("money", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("regDt", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("Remark", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            this.FieldDic.put("ID", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "ID", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iID", this.FieldDic.get("ID"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("ID")));
            this.FieldDic.put("freeze", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "freeze", $Ku.by.ToolClass.DataTypeEnum.Bool));
            this.ComponentDic.put("iFreeze", this.FieldDic.get("freeze"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("freeze")));
            this.FieldDic.put("rank", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "rank", $Ku.byUser.Enum.rank.class));
            this.ComponentDic.put("iRank", this.FieldDic.get("rank"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("rank")));
            this.FieldDic.put("name", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "name", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iName", this.FieldDic.get("name"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("name")));
            this.FieldDic.put("password", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "password", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iPassword", this.FieldDic.get("password"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("password")));
            this.FieldDic.put("displayName", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "displayName", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iDisplayName", this.FieldDic.get("displayName"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("displayName")));
            this.FieldDic.put("mobile", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "mobile", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iMobile", this.FieldDic.get("mobile"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("mobile")));
            this.FieldDic.put("mail", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "mail", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iMail", this.FieldDic.get("mail"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("mail")));
            this.FieldDic.put("cerMode", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "cerMode", $Ku.byUser.Enum.cer.class));
            this.ComponentDic.put("iCerMode", this.FieldDic.get("cerMode"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("cerMode")));
            this.FieldDic.put("cerName", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "cerName", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iCerName", this.FieldDic.get("cerName"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("cerName")));
            this.FieldDic.put("cerNO", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "cerNO", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iCerNO", this.FieldDic.get("cerNO"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("cerNO")));
            this.FieldDic.put("money", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "money", $Ku.by.ToolClass.DataTypeEnum.Decimal));
            this.ComponentDic.put("iMoney", this.FieldDic.get("money"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("money")));
            this.FieldDic.put("regDt", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "regDt", $Ku.by.ToolClass.DataTypeEnum.Datetime));
            this.ComponentDic.put("iRegDt", this.FieldDic.get("regDt"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("regDt")));
            this.FieldDic.put("Remark", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "Remark", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iRemark", this.FieldDic.get("Remark"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("Remark")));
            this.fields = new $Ku.by.Object.ReadOnlyList<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Field.class), tmpFields);
            this.SourceDic.put("ID", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("ID")));
            this.SourceDic.put("freeze", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("freeze")));
            this.SourceDic.put("name", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("name")));
            this.SourceDic.put("password", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("password")));
            this.SourceDic.put("displayName", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("displayName")));
            this.SourceDic.put("mobile", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("mobile")));
            this.SourceDic.put("mail", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("mail")));
            this.SourceDic.put("cerMode", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("cerMode")));
            this.SourceDic.put("cerName", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("cerName")));
            this.SourceDic.put("cerNO", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("cerNO")));
            this.SourceDic.put("money", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("money")));
            this.SourceDic.put("Remark", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("Remark")));
            this.SourceDic.put("rank", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("rank")));
            this.RowFlowDic.put("insert", this::FlowString$insert);
            this.RowsFlowDic.put("insert", this::FlowString$insert);
            this.RowArrayFlowDic.put("insert", this::FlowString$insert);
            this.RowFlowInTranDic.put("insert", this::FlowStringInTran$insert);
            this.RowsFlowInTranDic.put("insert", this::FlowStringInTran$insert);
            this.RowArrayFlowInTranDic.put("insert", this::FlowStringInTran$insert);
            this.FlowDic.put("insert", flow$insert);
            this.FlowDic.get("insert").add(this.SourceDic.get("cerMode"));
            this.FlowDic.get("insert").add(this.SourceDic.get("cerName"));
            this.FlowDic.get("insert").add(this.SourceDic.get("cerNO"));
            this.FlowDic.get("insert").add(this.SourceDic.get("displayName"));
            this.FlowDic.get("insert").add(this.SourceDic.get("freeze"));
            this.FlowDic.get("insert").add(this.SourceDic.get("mail"));
            this.FlowDic.get("insert").add(this.SourceDic.get("mobile"));
            this.FlowDic.get("insert").add(this.SourceDic.get("money"));
            this.FlowDic.get("insert").add(this.SourceDic.get("name"));
            this.FlowDic.get("insert").add(this.SourceDic.get("Remark"));
            this.FlowDic.get("insert").add(this.SourceDic.get("ID"));
            this.FlowDic.get("insert").add(this.SourceDic.get("password"));
            this.FlowDic.get("insert").add(this.SourceDic.get("rank"));
            this.RowFlowDic.put("update", this::FlowString$update);
            this.RowsFlowDic.put("update", this::FlowString$update);
            this.RowArrayFlowDic.put("update", this::FlowString$update);
            this.RowFlowInTranDic.put("update", this::FlowStringInTran$update);
            this.RowsFlowInTranDic.put("update", this::FlowStringInTran$update);
            this.RowArrayFlowInTranDic.put("update", this::FlowStringInTran$update);
            this.FlowDic.put("update", flow$update);
            this.FlowDic.get("update").add(this.SourceDic.get("cerMode"));
            this.FlowDic.get("update").add(this.SourceDic.get("cerName"));
            this.FlowDic.get("update").add(this.SourceDic.get("cerNO"));
            this.FlowDic.get("update").add(this.SourceDic.get("displayName"));
            this.FlowDic.get("update").add(this.SourceDic.get("freeze"));
            this.FlowDic.get("update").add(this.SourceDic.get("mail"));
            this.FlowDic.get("update").add(this.SourceDic.get("mobile"));
            this.FlowDic.get("update").add(this.SourceDic.get("money"));
            this.FlowDic.get("update").add(this.SourceDic.get("name"));
            this.FlowDic.get("update").add(this.SourceDic.get("Remark"));
            this.FlowDic.get("update").add(this.SourceDic.get("rank"));
            this.RowFlowDic.put("updatePwd", this::FlowString$updatePwd);
            this.RowsFlowDic.put("updatePwd", this::FlowString$updatePwd);
            this.RowArrayFlowDic.put("updatePwd", this::FlowString$updatePwd);
            this.RowFlowInTranDic.put("updatePwd", this::FlowStringInTran$updatePwd);
            this.RowsFlowInTranDic.put("updatePwd", this::FlowStringInTran$updatePwd);
            this.RowArrayFlowInTranDic.put("updatePwd", this::FlowStringInTran$updatePwd);
            this.FlowDic.put("updatePwd", flow$updatePwd);
            this.FlowDic.get("updatePwd").add(this.SourceDic.get("password"));
            this.FlowDic.get("updatePwd").add(this.SourceDic.get("rank"));
            this.RowFlowDic.put("delete", this::FlowString$delete);
            this.RowsFlowDic.put("delete", this::FlowString$delete);
            this.RowArrayFlowDic.put("delete", this::FlowString$delete);
            this.RowFlowInTranDic.put("delete", this::FlowStringInTran$delete);
            this.RowsFlowInTranDic.put("delete", this::FlowStringInTran$delete);
            this.RowArrayFlowInTranDic.put("delete", this::FlowStringInTran$delete);
            this.FlowDic.put("delete", flow$delete);
            this.FlowDic.get("delete").add(this.SourceDic.get("ID"));
            this.PrimaryKeyList.add(this.FieldDic.get("ID"));

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

    public java.lang.String FlowString$insert(java.lang.Iterable<$Ku.by.Object.Row> f_Rows, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_Rows.iterator().hasNext()){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "ID", "password", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.insertSql(this, tmpColumns, tmpRow));
            tmpSql.append("\r\n");
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowString$insert($Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        if (f_CurrentRow == null){
            return "";
        }
        if (!Objects.equals(f_CurrentRow.getKuName(), this.KuName) || !Objects.equals(f_CurrentRow.getSheetName(), this.SheetName)){
            String tmpRowSheetName = f_CurrentRow.getKuName() + "." + f_CurrentRow.getSheetName();
            String tmpThisSheetName = this.KuName + "." + this.SheetName;
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
        }
        $Ku.by.Object.Row tmpRowCopy = f_CurrentRow.Copy();
        java.util.ArrayList<$Ku.by.Object.Row> tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for($Ku.by.Object.Row item : tmpRelationRowCopy){
            ToolFunction.Replace(tmpRowCopy.cells, item, tmpDataSheet.ReferenceDic);
        }
        
        for($Ku.by.Object.Cell column : f_CurrentRow.cells){
            if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                continue;
            }
            String tmpValue = null;
            if(column.value != null){
                tmpValue = column.value.toString();
            }
            if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
            }
            column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());
        }
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "ID", "password", "rank" };
        return SqlInvocation.insertSql(this, tmpColumns, tmpRowCopy);
    }

    public java.lang.String FlowString$insert($Ku.by.Object.Row[] f_Rows, $Ku.by.Object.Row[] ... f_RelationRow) {
        if(f_Rows.length == 0){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.List<$Ku.by.Object.Row>[] value = new java.util.List[f_RelationRow.length];

        for(int i = 0; i < f_RelationRow.length; i++){
            value[i] = Arrays.asList(f_RelationRow[i]);
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray(value);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "ID", "password", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.insertSql(this, tmpColumns, tmpRow));
            tmpSql.append("\r\n");
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$insert(java.lang.String f_EffectCount, $Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        if (f_CurrentRow == null){           return String.format("SET @%s = 0\r\n", f_EffectCount);
       }
        if(!Objects.equals(f_CurrentRow.getKuName(), this.KuName) || !Objects.equals(f_CurrentRow.getSheetName(), this.SheetName))
            {
                String tmpRowSheetName = f_CurrentRow.getKuName() + "." + f_CurrentRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
        $Ku.by.Object.Row tmpRowCopy = f_CurrentRow.Copy();
            java.util.ArrayList <$Ku.by.Object.Row > tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
       tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectCount));
biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for($Ku.by.Object.Row item : tmpRelationRowCopy){
            ToolFunction.Replace(tmpRowCopy.cells, item, tmpDataSheet.ReferenceDic);
        }

        for($Ku.by.Object.Cell column : tmpRowCopy.cells){
            if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                continue;
            }
            String tmpValue = null;
            if(column.value != null){
                tmpValue = column.value.toString();
            }
            if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
            }
            column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());
        }
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "ID", "password", "rank" };
        tmpSql.append(SqlInvocation.insertSql(this, tmpColumns, tmpRowCopy));
        tmpSql.append("\r\n");
        tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$insert(java.lang.String f_EffectCount, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_CurrentRow.iterator().hasNext()){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "ID", "password", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.insertSql(this, tmpColumns, tmpRow));
            tmpSql.append("\r\n");
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$insert(java.lang.String f_EffectCount, $Ku.by.Object.Row[] f_CurrentRow, $Ku.by.Object.Row[] ... f_RelationRow) {
        if(f_CurrentRow.length == 0){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.List<$Ku.by.Object.Row>[] value = new java.util.List[f_RelationRow.length];

        for(int i = 0; i < f_RelationRow.length; i++){
            value[i] = Arrays.asList(f_RelationRow[i]);
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray(value);
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("set @%s = 0\r\n", f_EffectCount));
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "ID", "password", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.insertSql(this, tmpColumns, tmpRow));
            tmpSql.append("\r\n");
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowString$update(java.lang.Iterable<$Ku.by.Object.Row> f_Rows, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_Rows.iterator().hasNext()){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
            tmpSql.append("\r\n");
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowString$update($Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        if (f_CurrentRow == null){
            return "";
        }
        if (!Objects.equals(f_CurrentRow.getKuName(), this.KuName) || !Objects.equals(f_CurrentRow.getSheetName(), this.SheetName)){
            String tmpRowSheetName = f_CurrentRow.getKuName() + "." + f_CurrentRow.getSheetName();
            String tmpThisSheetName = this.KuName + "." + this.SheetName;
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
        }
        $Ku.by.Object.Row tmpRowCopy = f_CurrentRow.Copy();
        java.util.ArrayList<$Ku.by.Object.Row> tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for($Ku.by.Object.Row item : tmpRelationRowCopy){
            ToolFunction.Replace(tmpRowCopy.cells, item, tmpDataSheet.ReferenceDic);
        }
        
        for($Ku.by.Object.Cell column : f_CurrentRow.cells){
            if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                continue;
            }
            String tmpValue = null;
            if(column.value != null){
                tmpValue = column.value.toString();
            }
            if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
            }
            column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());
        }
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "rank" };
        return SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRowCopy, tmpDataSheet.PrimaryKeyList);
    }

    public java.lang.String FlowString$update($Ku.by.Object.Row[] f_Rows, $Ku.by.Object.Row[] ... f_RelationRow) {
        if(f_Rows.length == 0){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.List<$Ku.by.Object.Row>[] value = new java.util.List[f_RelationRow.length];

        for(int i = 0; i < f_RelationRow.length; i++){
            value[i] = Arrays.asList(f_RelationRow[i]);
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray(value);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
            tmpSql.append("\r\n");
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$update(java.lang.String f_EffectCount, $Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        if (f_CurrentRow == null){           return String.format("SET @%s = 0\r\n", f_EffectCount);
       }
        if(!Objects.equals(f_CurrentRow.getKuName(), this.KuName) || !Objects.equals(f_CurrentRow.getSheetName(), this.SheetName))
            {
                String tmpRowSheetName = f_CurrentRow.getKuName() + "." + f_CurrentRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
        $Ku.by.Object.Row tmpRowCopy = f_CurrentRow.Copy();
            java.util.ArrayList <$Ku.by.Object.Row > tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
       tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectCount));
biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for($Ku.by.Object.Row item : tmpRelationRowCopy){
            ToolFunction.Replace(tmpRowCopy.cells, item, tmpDataSheet.ReferenceDic);
        }

        for($Ku.by.Object.Cell column : tmpRowCopy.cells){
            if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                continue;
            }
            String tmpValue = null;
            if(column.value != null){
                tmpValue = column.value.toString();
            }
            if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
            }
            column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());
        }
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "rank" };
        tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRowCopy, tmpDataSheet.PrimaryKeyList));
        tmpSql.append("\r\n");
        tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$update(java.lang.String f_EffectCount, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_CurrentRow.iterator().hasNext()){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
            tmpSql.append("\r\n");
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$update(java.lang.String f_EffectCount, $Ku.by.Object.Row[] f_CurrentRow, $Ku.by.Object.Row[] ... f_RelationRow) {
        if(f_CurrentRow.length == 0){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.List<$Ku.by.Object.Row>[] value = new java.util.List[f_RelationRow.length];

        for(int i = 0; i < f_RelationRow.length; i++){
            value[i] = Arrays.asList(f_RelationRow[i]);
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray(value);
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("set @%s = 0\r\n", f_EffectCount));
        String[] tmpColumns = { "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
            tmpSql.append("\r\n");
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowString$updatePwd(java.lang.Iterable<$Ku.by.Object.Row> f_Rows, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_Rows.iterator().hasNext()){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "password", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
            tmpSql.append("\r\n");
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowString$updatePwd($Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        if (f_CurrentRow == null){
            return "";
        }
        if (!Objects.equals(f_CurrentRow.getKuName(), this.KuName) || !Objects.equals(f_CurrentRow.getSheetName(), this.SheetName)){
            String tmpRowSheetName = f_CurrentRow.getKuName() + "." + f_CurrentRow.getSheetName();
            String tmpThisSheetName = this.KuName + "." + this.SheetName;
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
        }
        $Ku.by.Object.Row tmpRowCopy = f_CurrentRow.Copy();
        java.util.ArrayList<$Ku.by.Object.Row> tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for($Ku.by.Object.Row item : tmpRelationRowCopy){
            ToolFunction.Replace(tmpRowCopy.cells, item, tmpDataSheet.ReferenceDic);
        }
        
        for($Ku.by.Object.Cell column : f_CurrentRow.cells){
            if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                continue;
            }
            String tmpValue = null;
            if(column.value != null){
                tmpValue = column.value.toString();
            }
            if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
            }
            column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());
        }
        String[] tmpColumns = { "password", "rank" };
        return SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRowCopy, tmpDataSheet.PrimaryKeyList);
    }

    public java.lang.String FlowString$updatePwd($Ku.by.Object.Row[] f_Rows, $Ku.by.Object.Row[] ... f_RelationRow) {
        if(f_Rows.length == 0){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.List<$Ku.by.Object.Row>[] value = new java.util.List[f_RelationRow.length];

        for(int i = 0; i < f_RelationRow.length; i++){
            value[i] = Arrays.asList(f_RelationRow[i]);
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray(value);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "password", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
            tmpSql.append("\r\n");
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$updatePwd(java.lang.String f_EffectCount, $Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        if (f_CurrentRow == null){           return String.format("SET @%s = 0\r\n", f_EffectCount);
       }
        if(!Objects.equals(f_CurrentRow.getKuName(), this.KuName) || !Objects.equals(f_CurrentRow.getSheetName(), this.SheetName))
            {
                String tmpRowSheetName = f_CurrentRow.getKuName() + "." + f_CurrentRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
        $Ku.by.Object.Row tmpRowCopy = f_CurrentRow.Copy();
            java.util.ArrayList <$Ku.by.Object.Row > tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
       tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectCount));
biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for($Ku.by.Object.Row item : tmpRelationRowCopy){
            ToolFunction.Replace(tmpRowCopy.cells, item, tmpDataSheet.ReferenceDic);
        }

        for($Ku.by.Object.Cell column : tmpRowCopy.cells){
            if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                continue;
            }
            String tmpValue = null;
            if(column.value != null){
                tmpValue = column.value.toString();
            }
            if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
            }
            column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());
        }
        String[] tmpColumns = { "password", "rank" };
        tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRowCopy, tmpDataSheet.PrimaryKeyList));
        tmpSql.append("\r\n");
        tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$updatePwd(java.lang.String f_EffectCount, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_CurrentRow.iterator().hasNext()){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();String[] tmpColumns = { "password", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
            tmpSql.append("\r\n");
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$updatePwd(java.lang.String f_EffectCount, $Ku.by.Object.Row[] f_CurrentRow, $Ku.by.Object.Row[] ... f_RelationRow) {
        if(f_CurrentRow.length == 0){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.List<$Ku.by.Object.Row>[] value = new java.util.List[f_RelationRow.length];

        for(int i = 0; i < f_RelationRow.length; i++){
            value[i] = Arrays.asList(f_RelationRow[i]);
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray(value);
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("set @%s = 0\r\n", f_EffectCount));
        String[] tmpColumns = { "password", "rank" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRow, tmpDataSheet.PrimaryKeyList));
            tmpSql.append("\r\n");
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowString$delete(java.lang.Iterable<$Ku.by.Object.Row> f_Rows, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_Rows.iterator().hasNext()){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "ID" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.deleteSql(tmpDataSheet, tmpColumns, tmpRow));
            tmpSql.append("\r\n");
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowString$delete($Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        if (f_CurrentRow == null){
            return "";
        }
        if (!Objects.equals(f_CurrentRow.getKuName(), this.KuName) || !Objects.equals(f_CurrentRow.getSheetName(), this.SheetName)){
            String tmpRowSheetName = f_CurrentRow.getKuName() + "." + f_CurrentRow.getSheetName();
            String tmpThisSheetName = this.KuName + "." + this.SheetName;
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
        }
        $Ku.by.Object.Row tmpRowCopy = f_CurrentRow.Copy();
        java.util.ArrayList<$Ku.by.Object.Row> tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for($Ku.by.Object.Row item : tmpRelationRowCopy){
            ToolFunction.Replace(tmpRowCopy.cells, item, tmpDataSheet.ReferenceDic);
        }
        
        for($Ku.by.Object.Cell column : f_CurrentRow.cells){
            if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                continue;
            }
            String tmpValue = null;
            if(column.value != null){
                tmpValue = column.value.toString();
            }
            if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
            }
            column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());
        }
        String[] tmpColumns = { "ID" };
        return SqlInvocation.deleteSql(tmpDataSheet, tmpColumns, tmpRowCopy);
    }

    public java.lang.String FlowString$delete($Ku.by.Object.Row[] f_Rows, $Ku.by.Object.Row[] ... f_RelationRow) {
        if(f_Rows.length == 0){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.List<$Ku.by.Object.Row>[] value = new java.util.List[f_RelationRow.length];

        for(int i = 0; i < f_RelationRow.length; i++){
            value[i] = Arrays.asList(f_RelationRow[i]);
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray(value);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "ID" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.deleteSql(tmpDataSheet, tmpColumns, tmpRow));
            tmpSql.append("\r\n");
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$delete(java.lang.String f_EffectCount, $Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        if (f_CurrentRow == null){           return String.format("SET @%s = 0\r\n", f_EffectCount);
       }
        if(!Objects.equals(f_CurrentRow.getKuName(), this.KuName) || !Objects.equals(f_CurrentRow.getSheetName(), this.SheetName))
            {
                String tmpRowSheetName = f_CurrentRow.getKuName() + "." + f_CurrentRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }
        $Ku.by.Object.Row tmpRowCopy = f_CurrentRow.Copy();
            java.util.ArrayList <$Ku.by.Object.Row > tmpRelationRowCopy = ToolFunction.CopyRows(f_RelationRow);
            StringBuilder tmpSql = new StringBuilder();
       tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectCount));
biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for($Ku.by.Object.Row item : tmpRelationRowCopy){
            ToolFunction.Replace(tmpRowCopy.cells, item, tmpDataSheet.ReferenceDic);
        }

        for($Ku.by.Object.Cell column : tmpRowCopy.cells){
            if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                continue;
            }
            String tmpValue = null;
            if(column.value != null){
                tmpValue = column.value.toString();
            }
            if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
            }
            column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());
        }
        String[] tmpColumns = { "ID" };
        tmpSql.append(SqlInvocation.deleteSql(tmpDataSheet, tmpColumns, tmpRowCopy));
        tmpSql.append("\r\n");
        tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$delete(java.lang.String f_EffectCount, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_CurrentRow.iterator().hasNext()){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();String[] tmpColumns = { "ID" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.deleteSql(tmpDataSheet, tmpColumns, tmpRow));
            tmpSql.append("\r\n");
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        }
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$delete(java.lang.String f_EffectCount, $Ku.by.Object.Row[] f_CurrentRow, $Ku.by.Object.Row[] ... f_RelationRow) {
        if(f_CurrentRow.length == 0){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.List<$Ku.by.Object.Row>[] value = new java.util.List[f_RelationRow.length];

        for(int i = 0; i < f_RelationRow.length; i++){
            value[i] = Arrays.asList(f_RelationRow[i]);
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray(value);
        StringBuilder tmpSql = new StringBuilder();
        tmpSql.append(String.format("set @%s = 0\r\n", f_EffectCount));
        String[] tmpColumns = { "ID" };
        biao$user tmpDataSheet = (biao$user)Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user");
        for(int i = 0; i < tmpRowsCopy.size(); i++){
            $Ku.by.Object.Row tmpRow = tmpRowsCopy.get(i);
            if (!Objects.equals(tmpRow.getKuName(), this.KuName) || !Objects.equals(tmpRow.getSheetName(), this.SheetName)){
                String tmpRowSheetName = tmpRow.getKuName() + "." + tmpRow.getSheetName();
                String tmpThisSheetName = this.KuName + "." + this.SheetName;
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.FlowExpressionRowSheetError, tmpRowSheetName, tmpThisSheetName));
            }

            for(java.util.List<$Ku.by.Object.Row> relationrows : tmpRelationRowCopy){
                if(relationrows.size() != tmpRowsCopy.size()){
                    throw new RuntimeException("关系行集合的元素个数与首个参数行集合的元素个数不匹配");
                }
                $Ku.by.Object.Row tmpRelationRow = relationrows.get(i);
                ToolFunction.Replace(tmpRow.cells, tmpRelationRow, tmpDataSheet.ReferenceDic);
            }

            for($Ku.by.Object.Cell column : tmpRow.cells){
                if(!tmpDataSheet.FieldDic.containsKey(column.ColumnName)){
                    continue;
                }
                String tmpValue = null;
                if(column.value != null){
                    tmpValue = column.value.toString();
                }
                if(tmpDataSheet.VerifyDic.containsKey(column.ColumnName)){
                    VerifyFunction.FieldVerify(tmpDataSheet.VerifyDic.get(column.ColumnName), tmpDataSheet.FieldDic.get(column.ColumnName), tmpValue);
                }
                column.value = ToolFunction.ConvertType(column.value, tmpDataSheet.FieldDic.get(column.ColumnName).getFieldType());

            }
            tmpSql.append(SqlInvocation.deleteSql(tmpDataSheet, tmpColumns, tmpRow));
            tmpSql.append("\r\n");
            tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        }
        return tmpSql.toString();
    }

    public java.lang.String getFieldDefault(java.lang.String f_FieldName) {
        switch (f_FieldName) {
            default :
                throw new RuntimeException(String.format("表 %1$s 错误的字段 %2$s 默认值调用", this.SheetName, f_FieldName));
        }
    }

    public void assembleFieldReference() {
    }
}
