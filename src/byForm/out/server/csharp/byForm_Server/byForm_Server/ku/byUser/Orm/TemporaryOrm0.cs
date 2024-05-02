using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass.Sql;
using System;
using System.Text;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;

namespace byForm_Server.ku.byUser.Orm
{
    public class TemporaryOrm0 : byForm_Server.ku.by.Object.orm
    {
        public override void SetValue(byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, byForm_Server.ku.by.Object.Row f_Row)
        {
            selectTable = f_SelectTable;
            cells = new list<Cell>(f_Row.cells);
            var tmpField0 = f_SelectTable.SelectItems[0];
            memberIndex0 = f_SelectTable.GetIndexOfField(tmpField0);
            List<ku.by.Object.Cell> tmpCells0 = new List<ku.by.Object.Cell>();
            var tmpFieldList0 = f_SelectTable.SelectItems.FindAll(item => item.FieldTable != null && item.FieldTable.Alias == "a");
            var tmpIdentity0 = f_SelectTable.FindTableIdentityWithAlias("a");
            foreach (var item in tmpFieldList0)
            {
                int tmpIndex = f_SelectTable.GetIndexOfField(item);
                if (item is IFields)
                {
                    var tmpIFields = item as IFields;
                    for (int i = 0; i < tmpIFields.FieldCount; i++)
                    {
                        var tmpCell = f_Row.cells[i];
                        tmpCells0.Add(tmpCell);
                    }
                }
                else
                {
                    var tmpCell = f_Row.cells[tmpIndex];
                    tmpCells0.Add(tmpCell);

                }
            }
            var tmpRow0 = new ku.by.Object.Row() { cells = tmpCells0, Identity = tmpIdentity0, OrmSource = this };
            this.Table0 = tmpRow0;
        }

        private byForm_Server.ku.by.ToolClass.Sql.SelectTable selectTable;

        public int Member0
        {
            get
            {
                return Convert.ToInt32(cells[memberIndex0].value);
            }
            set
            {
                this.cells[memberIndex0].SetValue(value);
            }
        }

        private int memberIndex0;

        public byForm_Server.ku.by.Object.Row Table0 { get; set; }

        public override string ToString()
        {
            StringBuilder tmpValue = new StringBuilder();
            for (int i = 0; i < cells.Count; i++)
            {
                if (i != 0)
                {
                    tmpValue.Append("\r\n");
                }

                tmpValue.Append(cells[i].ToString());
            }
            return tmpValue.ToString();
        }

        public override bool equals(byForm_Server.ku.by.Object.orm orm)
        {
            if (this.GetType() != orm.GetType())
            {
                return false;
            }

            if (cells.Count != orm.cells.Count)
            {
                return false;
            }

            for (int i = 0; i < cells.Count; i++)
            {
                var tmpCell1 = cells[i];
                var tmpCell2 = orm.cells[i];
                if (!tmpCell1.equals(tmpCell2))
                {
                    return false;
                }
            }

            return true;
        }

        public override byForm_Server.ku.by.Object.orm clone()
        {
            Row tmpNewRow = new Row();
            List<Cell> tmpNewCells = new List<Cell>();
            foreach (var item in cells)
            {
                tmpNewCells.Add(item.CopyValue());
            }
            tmpNewRow.cells = tmpNewCells;
            var tmpNewOrm = new TemporaryOrm0();
            tmpNewOrm.SetValue(selectTable, tmpNewRow);
            return tmpNewOrm;
        }
    }
}
