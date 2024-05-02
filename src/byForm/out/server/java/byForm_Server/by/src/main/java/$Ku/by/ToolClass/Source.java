package $Ku.by.ToolClass;

import java.util.Objects;
public class Source {
    public $Ku.by.ToolClass.IBaseDataSheet Parameters;
    public $Ku.by.ToolClass.Sql.SqlField DataSheetField;
    public java.lang.String Operator;
    public java.lang.Boolean IsRelation = false;
    public java.lang.String RelationColumn;
    public java.lang.String RelationValue;

    public Source($Ku.by.ToolClass.IBaseDataSheet f_Parameters, java.lang.String f_Operator, $Ku.by.ToolClass.Sql.SqlField f_Field) {
        this.Parameters = f_Parameters;
        this.Operator = f_Operator;
        this.DataSheetField = f_Field;
        this.IsRelation = !Objects.equals(f_Parameters.getSheetName(), f_Field.getSheetName());
    }

    public Source($Ku.by.ToolClass.IBaseDataSheet f_Parameters, java.lang.String f_Operator, $Ku.by.ToolClass.Sql.SqlField f_Field, java.lang.String f_RelationColumn, java.lang.String f_RelationValue) {
        this.Parameters = f_Parameters;
        this.Operator = f_Operator;
        this.DataSheetField = f_Field;
        this.RelationColumn = f_RelationColumn;
        this.RelationValue = f_RelationValue;
        this.IsRelation = true;
    }
}
