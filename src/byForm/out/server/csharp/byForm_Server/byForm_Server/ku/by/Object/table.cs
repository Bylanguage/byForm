using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class table : byForm_Server.ku.by.ToolClass.IIdentity
    {
        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase Identity
        {
            get
            {
                if (this.DataSheet == null)
                {
                    return null;
                }
                else
                {
                    return this.DataSheet.Identity;
                }
            }
            set
            {
                this.DataSheet.Identity = value;
            }
        }

        public byForm_Server.ku.by.Enum.TableType tableType { get; set; }

        public byForm_Server.ku.by.Object.ReadOnlyList<byForm_Server.ku.by.Object.Row> rows
        {
            get
            {
                if (_rows == null)
                {
                    this._rows = new ReadOnlyList<Row>(Rows);
                }

                return _rows;
            }
        }

        private byForm_Server.ku.by.Object.ReadOnlyList<byForm_Server.ku.by.Object.Row> _rows;

        public System.Collections.Generic.List<byForm_Server.ku.by.Object.Row> Rows { get; set; }

        public string kuName
        {
            get
            {
                if (DataSheet == null)
                {
                    return null;
                }

                return DataSheet.KuName;
            }
        }

        public string name
        {
            get
            {
                if (DataSheet == null)
                {
                    return null;
                }

                return DataSheet.SheetName;
            }
        }

        public virtual int max { get; set; }

        public byForm_Server.ku.by.ToolClass.IBaseDataSheet DataSheet { get; set; }

        public byForm_Server.ku.by.Object.ReadOnlyList<byForm_Server.ku.by.Object.field> fields
        {
            get
            {
                if (_fields == null)
                {
                    List<field> list = new List<field>();
                    foreach (var field in Fields)
                    {
                        list.Add(field.Value);
                    }
                    _fields = new ReadOnlyList<field>(list);
                }

                return _fields;
            }
        }

        public string summary { get; set; }

        private byForm_Server.ku.by.Object.ReadOnlyList<byForm_Server.ku.by.Object.field> _fields;

        public System.Collections.Generic.Dictionary<string, byForm_Server.ku.by.Object.field> Fields { get; set; }

        public byForm_Server.ku.by.Object.field getField(string fieldName)
        {
            field tmpValue;

            if (Fields.TryGetValue(fieldName, out tmpValue))
            {
                return tmpValue;
            }

            return null;
        }

        public void RefreshMax()
        {
            max = ToolClass.ToolFunction.SetMax(DataSheet);
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
