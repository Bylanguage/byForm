using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class SheetRelation
    {
        public string ReferenceFieldName { get; private set; }

        public string ReferencedFieldName { get; private set; }

        public string ReferenceSheet { get; private set; }

        public string ReferencedSheet { get; private set; }

        public SheetRelation(string f_Referenced, string f_Reference)
        {
            string[] tmpReferenceField = f_Reference.Split('.');
            string[] tmpReferencedField = f_Referenced.Split('.');

            if (tmpReferenceField.Length != 2 || tmpReferencedField.Length != 2)
            {
                ThrowHelper.ThrowUnKnownException("关系建立失败，存在非法格式字符");
            }

            this.ReferenceSheet = tmpReferenceField[0];
            this.ReferencedSheet = tmpReferencedField[0];
            this.ReferencedFieldName = tmpReferencedField[1];
            this.ReferenceFieldName = tmpReferenceField[1];
        }

        public override string ToString()
        {
            StringBuilder tmpValue = new StringBuilder(this.ReferenceSheet);
            tmpValue.Append(".");
            tmpValue.Append(this.ReferenceFieldName);
            tmpValue.Append(" = ");
            tmpValue.Append(this.ReferencedSheet);
            tmpValue.Append(".");
            tmpValue.Append(this.ReferencedFieldName);
            return tmpValue.ToString();
        }
    }
}
