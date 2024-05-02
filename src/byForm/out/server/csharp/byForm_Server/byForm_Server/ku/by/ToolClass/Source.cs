using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class Source
    {
        public byForm_Server.ku.by.ToolClass.IBaseDataSheet Parameters { get; private set; }

        public string Operator { get; private set; }

        public byForm_Server.ku.by.ToolClass.Field DataSheetField { get; private set; }

        public bool IsRelation { get; private set; }

        public string RelationColumn { get; set; }

        public string RelationValue { get; set; }

        public Source(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_Parameters, string f_Operator, byForm_Server.ku.by.ToolClass.Field f_Field)
        {
            Parameters = f_Parameters;
            Operator = f_Operator;
            DataSheetField = f_Field;
            IsRelation = false;
            if (f_Parameters.SheetName != f_Field.SheetName)
            {
                IsRelation = true;
            }
        }

        public Source(byForm_Server.ku.by.ToolClass.IBaseDataSheet f_DataSheet, string f_Operator, byForm_Server.ku.by.ToolClass.Field f_Field, string f_RelationColumn, string f_RelationValue)
        {
            Parameters = f_DataSheet;
            Operator = f_Operator;
            DataSheetField = f_Field;
            RelationColumn = f_RelationColumn;
            RelationValue = f_RelationValue;
            IsRelation = true;
        }
    }
}
