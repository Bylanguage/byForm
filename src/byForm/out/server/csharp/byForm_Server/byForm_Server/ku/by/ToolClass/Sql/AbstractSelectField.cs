using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public abstract class AbstractSelectField
    {
        public abstract string Alias { get; set; }

        public abstract byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable { get; set; }

        public abstract string FieldAccess { get; }

        public abstract string SelectItemDeclare { get; }

        public byForm_Server.ku.DataTypeEnum FieldType { get; set; }

        public System.Type EnumType { get; set; }

        public void GenerateEnumType(string f_Value)
        {
            var tmpEnumArray = f_Value.Split('.');
            string tmpQualifiedName = "Myserver7" + ".ku." + tmpEnumArray[0] + ".Enum." + tmpEnumArray[2];
            EnumType = System.Type.GetType(tmpQualifiedName);
        }

        public override string ToString()
        {
            return FieldAccess;
        }
    }
}
