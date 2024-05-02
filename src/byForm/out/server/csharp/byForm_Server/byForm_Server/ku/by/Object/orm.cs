using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class orm
    {
        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Cell> cells { get; set; }

        public virtual byForm_Server.ku.by.Object.ReadOnlyList<byForm_Server.ku.by.Object.Cell> Cells
        {
            get
            {
                return new ReadOnlyList<ku.by.Object.Cell>(cells);
            }
            set
            {
                return;
            }
        }

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

        public virtual bool equals(byForm_Server.ku.by.Object.orm orm)
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

        public virtual byForm_Server.ku.by.Object.orm clone()
        {
            Row tmpNewRow = new Row();

            foreach (var item in cells)
            {
                var tmpNewCell = item.CopyValue();
                tmpNewCell.row = tmpNewRow;
                tmpNewRow.cells.Add(tmpNewCell);
            }

            return new orm() { cells = new list<Cell>(tmpNewRow.cells) };
        }

        public virtual System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> GenerateFieldMap()
        {
            return null;//生成实际索引非声明索引
        }

        public virtual void SetValue(byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, byForm_Server.ku.by.Object.Row f_Row)
        {
            return;
        }

        public byForm_Server.ku.by.Object.dictionary<int, string> aliasMap;
    }
}
