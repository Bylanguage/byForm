package $Ku.byFormNew.DataSheet;

import $Ku.*;
import $Ku.by.Object.*;
import $Ku.by.ToolClass.*;
import java.util.*;
public class biao$form extends $Ku.by.Object.Table implements $Ku.by.ToolClass.IBaseDataSheet  {
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
    public java.util.ArrayList<$Ku.by.ToolClass.Source> flow$delete = new java.util.ArrayList<>();
    public java.util.ArrayList<$Ku.by.ToolClass.Source> flow$select = new java.util.ArrayList<>();
    public java.util.ArrayList<$Ku.by.ToolClass.Source> flow$popup = new java.util.ArrayList<>();

    public biao$form() {
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
            this.KuName = "byFormNew";

            this.SheetName = "form";
            this.IdentityName = "byForm.form";

            VerifyDic.put("iD", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean iD_notNull = true;
            VerifyDic.get("iD").put($Ku.by.Enum.Attribute.notNull, iD_notNull.toString());
            Integer iD_max = 32;
            VerifyDic.get("iD").put($Ku.by.Enum.Attribute.max, iD_max.toString());
            VerifyDic.put("name", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean name_notNull = true;
            VerifyDic.get("name").put($Ku.by.Enum.Attribute.notNull, name_notNull.toString());
            VerifyDic.put("successMsg", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("submitButton", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("summary", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            Boolean summary_notNull = true;
            VerifyDic.get("summary").put($Ku.by.Enum.Attribute.notNull, summary_notNull.toString());
            Integer summary_max = 256;
            VerifyDic.get("summary").put($Ku.by.Enum.Attribute.max, summary_max.toString());
            VerifyDic.put("userID", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("createDt", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            VerifyDic.put("currentModifyDt", new java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>());
            this.FieldDic.put("iD", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "iD", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iID", this.FieldDic.get("iD"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("iD")));
            this.FieldDic.put("name", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "name", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iName", this.FieldDic.get("name"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("name")));
            this.FieldDic.put("successMsg", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "successMsg", $Ku.by.ToolClass.DataTypeEnum.String));
            this.DefaultColumnList.add("successMsg");
            this.ComponentDic.put("iSuccessMsg", this.FieldDic.get("successMsg"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("successMsg")));
            this.FieldDic.put("submitButton", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "submitButton", $Ku.by.ToolClass.DataTypeEnum.String));
            this.DefaultColumnList.add("submitButton");
            this.ComponentDic.put("iSubmitButton", this.FieldDic.get("submitButton"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("submitButton")));
            this.FieldDic.put("summary", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "summary", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iSummary", this.FieldDic.get("summary"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("summary")));
            this.FieldDic.put("userID", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "userID", $Ku.by.ToolClass.DataTypeEnum.String));
            this.ComponentDic.put("iUserID", this.FieldDic.get("userID"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("userID")));
            this.FieldDic.put("createDt", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "createDt", $Ku.by.ToolClass.DataTypeEnum.Datetime));
            this.ComponentDic.put("iCreateDt", this.FieldDic.get("createDt"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("createDt")));
            this.FieldDic.put("currentModifyDt", new $Ku.by.ToolClass.Sql.SqlField(this.KuName, this.SheetName, "currentModifyDt", $Ku.by.ToolClass.DataTypeEnum.Datetime));
            this.ComponentDic.put("iCurrentModifyDt", this.FieldDic.get("currentModifyDt"));
            tmpFields.add(new $Ku.by.Object.Field(this.FieldDic.get("currentModifyDt")));
            this.fields = new $Ku.by.Object.ReadOnlyList<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Field.class), tmpFields);
            this.SourceDic.put("iD", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("iD")));
            this.SourceDic.put("name", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("name")));
            this.SourceDic.put("successMsg", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("successMsg")));
            this.SourceDic.put("submitButton", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("submitButton")));
            this.SourceDic.put("summary", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("summary")));
            this.SourceDic.put("userID", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("userID")));
            this.SourceDic.put("createDt", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("createDt")));
            this.SourceDic.put("currentModifyDt", new $Ku.by.ToolClass.Source(this, "equal", FieldDic.get("currentModifyDt")));
            this.RowFlowDic.put("insert", this::FlowString$insert);
            this.RowsFlowDic.put("insert", this::FlowString$insert);
            this.RowArrayFlowDic.put("insert", this::FlowString$insert);
            this.RowFlowInTranDic.put("insert", this::FlowStringInTran$insert);
            this.RowsFlowInTranDic.put("insert", this::FlowStringInTran$insert);
            this.RowArrayFlowInTranDic.put("insert", this::FlowStringInTran$insert);
            this.FlowDic.put("insert", flow$insert);
            this.FlowDic.get("insert").add(this.SourceDic.get("iD"));
            this.FlowDic.get("insert").add(this.SourceDic.get("name"));
            this.FlowDic.get("insert").add(this.SourceDic.get("successMsg"));
            this.FlowDic.get("insert").add(this.SourceDic.get("submitButton"));
            this.FlowDic.get("insert").add(this.SourceDic.get("summary"));
            this.FlowDic.get("insert").add(this.SourceDic.get("userID"));
            this.FlowDic.get("insert").add(this.SourceDic.get("createDt"));
            this.FlowDic.get("insert").add(this.SourceDic.get("currentModifyDt"));
            this.RowFlowDic.put("update", this::FlowString$update);
            this.RowsFlowDic.put("update", this::FlowString$update);
            this.RowArrayFlowDic.put("update", this::FlowString$update);
            this.RowFlowInTranDic.put("update", this::FlowStringInTran$update);
            this.RowsFlowInTranDic.put("update", this::FlowStringInTran$update);
            this.RowArrayFlowInTranDic.put("update", this::FlowStringInTran$update);
            this.FlowDic.put("update", flow$update);
            this.FlowDic.get("update").add(this.SourceDic.get("name"));
            this.FlowDic.get("update").add(this.SourceDic.get("successMsg"));
            this.FlowDic.get("update").add(this.SourceDic.get("submitButton"));
            this.FlowDic.get("update").add(this.SourceDic.get("summary"));
            this.FlowDic.get("update").add(this.SourceDic.get("userID"));
            this.FlowDic.get("update").add(this.SourceDic.get("currentModifyDt"));
            this.RowFlowDic.put("delete", this::FlowString$delete);
            this.RowsFlowDic.put("delete", this::FlowString$delete);
            this.RowArrayFlowDic.put("delete", this::FlowString$delete);
            this.RowFlowInTranDic.put("delete", this::FlowStringInTran$delete);
            this.RowsFlowInTranDic.put("delete", this::FlowStringInTran$delete);
            this.RowArrayFlowInTranDic.put("delete", this::FlowStringInTran$delete);
            this.FlowDic.put("delete", flow$delete);
            this.FlowDic.get("delete").add(this.SourceDic.get("iD"));
            this.FlowDic.put("select", flow$select);
            this.FlowDic.get("select").add(this.SourceDic.get("iD"));
            this.FlowDic.get("select").add(this.SourceDic.get("name"));
            this.FlowDic.get("select").add(this.SourceDic.get("successMsg"));
            this.FlowDic.get("select").add(this.SourceDic.get("submitButton"));
            this.FlowDic.get("select").add(this.SourceDic.get("summary"));
            this.FlowDic.get("select").add(this.SourceDic.get("userID"));
            this.FlowDic.get("select").add(this.SourceDic.get("createDt"));
            this.FlowDic.get("select").add(this.SourceDic.get("currentModifyDt"));
            this.FlowDic.put("popup", flow$popup);
            this.FlowDic.get("popup").add(this.SourceDic.get("iD"));
            this.FlowDic.get("popup").add(this.SourceDic.get("name"));
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

    public java.lang.String FlowString$insert(java.lang.Iterable<$Ku.by.Object.Row> f_Rows, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_Rows.iterator().hasNext()){
            return "";
        }
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_Rows);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();
        String[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
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
        String[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
        tmpSql.append(SqlInvocation.insertSql(this, tmpColumns, tmpRowCopy));
        tmpSql.append("\r\n");
        tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$insert(java.lang.String f_EffectCount, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_CurrentRow.iterator().hasNext()){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();String[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "iD", "name", "successMsg", "submitButton", "summary", "userID", "createDt", "currentModifyDt" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
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
        String[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
        tmpSql.append(SqlInvocation.updateSql(tmpDataSheet, tmpColumns, tmpRowCopy, tmpDataSheet.PrimaryKeyList));
        tmpSql.append("\r\n");
        tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$update(java.lang.String f_EffectCount, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_CurrentRow.iterator().hasNext()){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();String[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "name", "successMsg", "submitButton", "summary", "userID", "currentModifyDt" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "iD" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "iD" };
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
        String[] tmpColumns = { "iD" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "iD" };
        tmpSql.append(SqlInvocation.deleteSql(tmpDataSheet, tmpColumns, tmpRowCopy));
        tmpSql.append("\r\n");
        tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectCount, f_EffectCount));
        return tmpSql.toString();
    }

    public java.lang.String FlowStringInTran$delete(java.lang.String f_EffectCount, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        if(!f_CurrentRow.iterator().hasNext()){}
        java.util.ArrayList<$Ku.by.Object.Row> tmpRowsCopy = ToolFunction.CopyRows(f_CurrentRow);
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpRelationRowCopy = ToolFunction.CopyRowsArray((java.util.List<$Ku.by.Object.Row>[]) f_RelationRow);
        StringBuilder tmpSql = new StringBuilder();String[] tmpColumns = { "iD" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
        String[] tmpColumns = { "iD" };
        biao$form tmpDataSheet = (biao$form)Root.GetInstance().KuDic.get("byFormNew").DataSheetDic.get("form");
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
            case "successMsg":
                return "'" + Default_successMsg(this) + "'";
            case "submitButton":
                return "'" + Default_submitButton(this) + "'";
            default :
                throw new RuntimeException(String.format("表 %1$s 错误的字段 %2$s 默认值调用", this.SheetName, f_FieldName));
        }
    }

    public java.lang.String Default_successMsg($Ku.by.Object.Table f_Table) {
        return "谢谢，我们会尽快处理！";
    }

    public java.lang.String Default_submitButton($Ku.by.Object.Table f_Table) {
        return "确认提交";
    }

    public void assembleFieldReference() {
        this.FieldDic.get("userID").ReferenceField = $Ku.by.ToolClass.Root.GetInstance().KuDic.get("byUser").DataSheetDic.get("user").getFieldDic().get("ID");
    }
}
