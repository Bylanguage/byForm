using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass.Sql
{
    public class AssignmentField : byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField
    {
        public override string Alias
        {
            get
            {
                return null;
            }
            set
            {
                ThrowHelper.ThrowSqlPreCompileException("");
            }
        }

        public override byForm_Server.ku.by.ToolClass.Sql.AbstractTable FieldTable
        {
            get
            {
                return null;
            }
            set
            {
                ThrowHelper.ThrowSqlPreCompileException("");
            }
        }

        public override string FieldAccess
        {
            get
            {
                throw ThrowHelper.ThrowSqlPreCompileException("");
            }
        }

        public override string SelectItemDeclare
        {
            get
            {
                throw ThrowHelper.ThrowSqlPreCompileException("");
            }
        }

        public string LocalVariable { get; set; }

        public byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField Field { get; set; }

        private string decKuName { get; set; }

        public AssignmentField(string f_LocalVariable, string f_DecKuName, byForm_Server.ku.by.ToolClass.Sql.AbstractSelectField f_Field)
        {
            LocalVariable = f_LocalVariable;
            Field = f_Field;
            decKuName = f_DecKuName;
        }
    }
}
