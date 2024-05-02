package $Ku.by.ToolClass;

public class SheetRelation {
    public java.lang.String ReferenceFieldName;
    public java.lang.String ReferencedFieldName;
    public java.lang.String ReferenceSheet;
    public java.lang.String ReferencedSheet;

    public SheetRelation(java.lang.String f_Referenced, java.lang.String f_Reference) {
        String[] tmpReferenceField = f_Reference.split("\\.");
        String[] tmpReferencedField = f_Referenced.split("\\.");

        if (tmpReferenceField.length != 2 || tmpReferencedField.length != 2)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("关系建立失败，存在非法格式字符");
        }

        this.ReferenceSheet = tmpReferenceField[0];
        this.ReferencedSheet = tmpReferencedField[0];
        this.ReferencedFieldName = tmpReferencedField[1];
        this.ReferenceFieldName = tmpReferenceField[1];
    }

    public SheetRelation(java.lang.String f_Referenced, java.lang.String f_SheetName, java.lang.String f_Name, java.lang.String f_Reference) {
        String[] tmpReferenceField = f_Reference.split(".");
        String[] tmpReferencedField = f_Referenced.split(".");

        if (tmpReferenceField.length != 2 || tmpReferencedField.length != 2){
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("关系建立失败，存在非法格式字符");
        }
        this.setReferencedSheet(tmpReferencedField[0]);
        this.setReferencedFieldName (tmpReferencedField[1]);
        this.setReferenceSheet (tmpReferenceField[0]);
        this.setReferenceFieldName (tmpReferenceField[1]);
    }


    public final java.lang.String getReferenceFieldName() {
        return ReferenceFieldName;
    }

    private void setReferenceFieldName(java.lang.String value) {
        ReferenceFieldName = value;
    }

    public final java.lang.String getReferencedFieldName() {
        return ReferencedFieldName;
    }

    private void setReferencedFieldName(java.lang.String value) {
        ReferencedFieldName = value;
    }

    public final java.lang.String getReferenceSheet() {
        return ReferenceSheet;
    }

    private void setReferenceSheet(java.lang.String value) {
        ReferenceSheet = value;
    }

    public final java.lang.String getReferencedSheet() {
        return ReferencedSheet;
    }

    private void setReferencedSheet(java.lang.String value) {
        ReferencedSheet = value;
    }
}
