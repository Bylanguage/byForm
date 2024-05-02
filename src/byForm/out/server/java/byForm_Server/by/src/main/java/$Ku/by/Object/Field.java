package $Ku.by.Object;

import java.util.ArrayList;
import $Ku.by.ToolClass.ToolFunction;
import $Ku.by.ToolClass.*;
public class Field extends $Ku.by.Object.ByObject {
    public java.lang.String name;
    public java.lang.String summary;
    public $Ku.by.Object.Field refField;
    public $Ku.by.Object.Table table;
    public $Ku.by.ToolClass.Sql.SqlField Field;

    public Field($Ku.by.ToolClass.Sql.SqlField f_Field) {
        this.Field = f_Field;
        this.name = f_Field.getName();
        this.summary = null;
    }

    public Field($Ku.by.ToolClass.Sql.SqlField f_SqlField, java.lang.String f_Summary) {
        this.Field = f_SqlField;
        this.name = f_SqlField.getName();
        this.summary = f_Summary;
    }


    public $Ku.by.Object.Table getRefTable() {
        BaseKu tmpKu = ToolFunction.GetKu(this.Field.getKuName());
        String tmpSheetName = this.Field.getSheetName();
        if (!tmpKu.RelationDic.containsKey(tmpSheetName)){
            return null;
        }
        ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(tmpSheetName);
        SheetRelation tmpRelation = null;
        for (SheetRelation relation : tmpRelations){
            if (relation.ReferenceSheet.equals(tmpSheetName) && relation.ReferenceFieldName.equals(this.Field.getName())){
                tmpRelation = relation;
            }
        }
        if (tmpRelation == null){
            return null;
        }
        String tmpRelationSheetName = tmpRelation.ReferencedSheet;
        if (!tmpKu.DataSheetDic.containsKey(tmpSheetName)){
            throw new RuntimeException();
        }
        return ($Ku.by.Object.Table)tmpKu.DataSheetDic.get(tmpSheetName);
    }

    public $Ku.by.Object.Field refField() {
        if (refField == null)
        {
            BaseKu tmpKu = $Ku.by.ToolClass.ToolFunction.GetKu(this.Field.getKuName());
            String tmpSheetName = this.Field.getSheetName();
            if (!tmpKu.RelationDic.containsKey(tmpSheetName))
            {
                return null;
            }
            ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(tmpSheetName);
            SheetRelation tmpRelation = null;
            for (SheetRelation relation : tmpRelations) {
                if (relation.getReferenceSheet().equals(tmpSheetName) && relation.getReferenceFieldName().equals(this.Field.getName())) {
                    tmpRelation = relation;
                    break;
                }
            }
            if (tmpRelation == null)
            {
                return null;
            }

            String tmpRelationSheetName = tmpRelation.getReferencedSheet();
            String tmpRelationFieldName = tmpRelation.ReferencedFieldName;
            $Ku.by.Object.Table tmpRefTable = ($Ku.by.Object.Table)tmpKu.DataSheetDic.get(tmpRelationSheetName);
            refField = tmpRefTable.getField(tmpRelationFieldName);
        }

        return refField;
    }

    public boolean isReference($Ku.by.Object.Table tmpLocalVariable0) {
        if (!this.Field.getKuName().equals(tmpLocalVariable0.DataSheet.getKuName())){
            throw new RuntimeException();
        }
        BaseKu tmpKu = ToolFunction.GetKu(this.Field.getKuName());
        String tmpSheetName = this.Field.getSheetName();
        if (!tmpKu.RelationDic.containsKey(tmpSheetName)){
            return false;
        }
        ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(tmpSheetName);
        for (SheetRelation relation : tmpRelations){
            if(relation.ReferenceSheet .equals(tmpSheetName) && relation.ReferenceFieldName.equals(this.Field.getName())
                    && relation.ReferencedSheet.equals(tmpLocalVariable0.DataSheet.getSheetName())){
                return true;
            }
        }
        return false;
    }

    public $Ku.by.ToolClass.AbstractIdentityBase getIdentity() {
        if (this.Field == null){
            return null;
        }
        else {
            return this.Field.getIdentity();
        }
    }

    public void setIdentity($Ku.by.ToolClass.AbstractIdentityBase Identity) {
        this.Field.setIdentity(Identity);
    }

    public boolean isBool() {
        return this.Field.getFieldType() == DataTypeEnum.Bool;
    }

    public boolean isEnum() {
        return this.Field.getFieldType() == DataTypeEnum.Enum;
    }

    public boolean isDatetime() {
        return this.Field.getFieldType() == DataTypeEnum.Datetime;
    }

    public boolean isString() {
        return this.Field.getFieldType() == DataTypeEnum.String;
    }

    public boolean isDecimal() {
        return this.Field.getFieldType() == DataTypeEnum.Decimal;
    }

    public boolean isDouble() {
        return this.Field.getFieldType() == DataTypeEnum.Double;
    }

    public boolean isFloat() {
        return this.Field.getFieldType() == DataTypeEnum.Float;
    }

    public boolean isLong() {
        return this.Field.getFieldType() == DataTypeEnum.Long;
    }

    public boolean isInt() {
        return this.Field.getFieldType() == DataTypeEnum.Int;
    }

    public boolean isShort() {
        return this.Field.getFieldType() == DataTypeEnum.Short;
    }

    public boolean isByte() {
        return this.Field.getFieldType() == DataTypeEnum.Byte;
    }

    public boolean isChar() {
        return this.Field.getFieldType() == DataTypeEnum.Char;
    }

    public $Ku.by.Object.Result verify(Object target) {
        Result tmpReturnValue = new Result();

        if (Field == null)
        {
            return tmpReturnValue;
        }

        try
        {
            java.util.LinkedHashMap<String, java.util.LinkedHashMap<$Ku.by.Enum.Attribute, String>> tmpVerifyDic = table.DataSheet.getVerifyDic();
            $Ku.by.ToolClass.VerifyFunction.FieldVerify(tmpVerifyDic.get(Field.getName()),Field,target == null?null : target.toString());
        }
        catch(java.lang.Exception ex)
        {
            tmpReturnValue.isOk = false;
            tmpReturnValue.info = ex.getMessage();
            return tmpReturnValue;
        }

        tmpReturnValue.isOk = true;
        return tmpReturnValue;
    }
}
