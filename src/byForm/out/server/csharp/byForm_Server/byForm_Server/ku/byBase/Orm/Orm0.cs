using System.Collections.Generic;
using byForm_Server.ku.by.ToolClass.Sql;
using System;
using System.Text;
using byForm_Server.ku.by.Object;
using byForm_Server.ku.by.ToolClass;

namespace byForm_Server.ku.byBase.Orm
{
    public class Orm0 : byForm_Server.ku.by.Object.orm
    {
        public override void SetValue(byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, byForm_Server.ku.by.Object.Row f_Row)
        {
            selectTable = f_SelectTable;
            cells = new list<Cell>(f_Row.cells);
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
            this.Tablea = tmpRow0;
            if (aliasMap.Count != 0)
            {
                return;
            }

            for (int i = 0; i < cells.count; i++)
            {
                var tmpCell = cells[i];
                
                if (tmpCell.TableAlias != null)
                {
                    aliasMap.add(i, tmpCell.TableAlias);
                }
            }
            List<ku.by.Object.Cell> tmpCells1 = new List<ku.by.Object.Cell>();
            var tmpFieldList1 = f_SelectTable.SelectItems.FindAll(item => item.FieldTable != null && item.FieldTable.Alias == "b");
            var tmpIdentity1 = f_SelectTable.FindTableIdentityWithAlias("b");
            foreach (var item in tmpFieldList1)
            {
                int tmpIndex = f_SelectTable.GetIndexOfField(item);
                if (item is IFields)
                {
                    var tmpIFields = item as IFields;
                    for (int i = 0; i < tmpIFields.FieldCount; i++)
                    {
                        var tmpCell = f_Row.cells[i];
                        tmpCells1.Add(tmpCell);
                    }
                }
                else
                {
                    var tmpCell = f_Row.cells[tmpIndex];
                    tmpCells1.Add(tmpCell);

                }
            }
            var tmpRow1 = new ku.by.Object.Row() { cells = tmpCells1, Identity = tmpIdentity1, OrmSource = this };
            this.Tableb = tmpRow1;
            if (aliasMap.Count != 0)
            {
                return;
            }

            for (int i = 0; i < cells.count; i++)
            {
                var tmpCell = cells[i];
                
                if (tmpCell.TableAlias != null)
                {
                    aliasMap.add(i, tmpCell.TableAlias);
                }
            }
        }

        private byForm_Server.ku.by.ToolClass.Sql.SelectTable selectTable;

        public Orm0()
        {
            aliasMap = new dictionary<int, string>();
        }

        public byForm_Server.ku.by.Object.Row Tablea { get; set; }

        public byForm_Server.ku.by.Object.Row Tableb { get; set; }

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
            
            foreach (var item in cells)
            {
                var tmpNewCell = item.CopyValue();
                tmpNewCell.row = tmpNewRow;
                tmpNewRow.cells.Add(tmpNewCell);
            }

            var tmpNewOrm = new Orm0();
            tmpNewOrm.SetValue(selectTable, tmpNewRow);
            return tmpNewOrm;
        }

        public static System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> GenetateTemOrm(byForm_Server.ku.by.ToolClass.Sql.SelectTable f_SelectTable, byForm_Server.ku.by.Object.Row f_Row)
        {
            Orm0 tmpOrm = new Orm0();
            tmpOrm.SetValue(f_SelectTable, f_Row);
            return tmpOrm.GenerateFieldMap();
        }

        public static byForm_Server.ku.byBase.Orm.Orm0 Create(byForm_Server.ku.by.Object.Row f_Row0, byForm_Server.ku.by.Object.Row f_Row1)
        {
            var tmpOrm = new Orm0();
            tmpOrm.cells = new list<Cell>();
            if (f_Row0 == null)
            {
                ThrowHelper.ThrowOrmException(ErrorInfo.OrmCreateRowParmIsNull);
            }

            if (f_Row0.Identity == null)
            {
                ThrowHelper.ThrowOrmException(ErrorInfo.RowIdentityError);
            }

            var tmpDataSheet0 = f_Row0.Identity.to as IBaseDataSheet;

            if (tmpDataSheet0 == null)
            {
                ThrowHelper.ThrowOrmException(ErrorInfo.RowIdentityNotMatchSheet);
            }

            tmpOrm.cells.addRange(new list<Cell>(f_Row0.cells));
            List<Cell> tmpCells0 = new List<Cell>();

            foreach (var fieldKeyPair in tmpDataSheet0.FieldDic)
            {
                string tmpFileName = fieldKeyPair.Key;
                var tmpMatchedCells = f_Row0.cells.FindAll(cell => cell.KuName == tmpDataSheet0.KuName && cell.SheetName == tmpDataSheet0.SheetName && cell.ColumnName == tmpFileName);

                if (tmpMatchedCells.Count == 0)
                {
                    var tmpNewCell = new Cell();
                    var tmpTable = tmpDataSheet0 as ku.by.Object.table;
                    tmpNewCell.field = tmpTable.getField(fieldKeyPair.Key);
                    tmpNewCell.value = ToolFunction.CellValueNullToDefault(fieldKeyPair.Value.FieldType, fieldKeyPair.Value.EnumType);
                    tmpOrm.cells.add(tmpNewCell);
                    tmpOrm.aliasMap.add(tmpOrm.cells.count, "a");
                }
                else
                {
                    tmpCells0.AddRange(tmpMatchedCells);

                    foreach (var machedCell in tmpMatchedCells)
                    {
                        int tmpCurrentIndex = tmpOrm.cells.indexOf(machedCell);
                        tmpOrm.aliasMap.add(tmpCurrentIndex, "a");
                    }
                }
            }

            Row tmpNewRow0 = new Row() { cells = tmpCells0, Identity = f_Row0.Identity, OrmSource = tmpOrm };
            tmpOrm.Tablea = tmpNewRow0;
            if (f_Row1 == null)
            {
                ThrowHelper.ThrowOrmException(ErrorInfo.OrmCreateRowParmIsNull);
            }

            if (f_Row1.Identity == null)
            {
                ThrowHelper.ThrowOrmException(ErrorInfo.RowIdentityError);
            }

            var tmpDataSheet1 = f_Row1.Identity.to as IBaseDataSheet;

            if (tmpDataSheet1 == null)
            {
                ThrowHelper.ThrowOrmException(ErrorInfo.RowIdentityNotMatchSheet);
            }

            tmpOrm.cells.addRange(new list<Cell>(f_Row1.cells));
            List<Cell> tmpCells1 = new List<Cell>();

            foreach (var fieldKeyPair in tmpDataSheet1.FieldDic)
            {
                string tmpFileName = fieldKeyPair.Key;
                var tmpMatchedCells = f_Row1.cells.FindAll(cell => cell.KuName == tmpDataSheet1.KuName && cell.SheetName == tmpDataSheet1.SheetName && cell.ColumnName == tmpFileName);

                if (tmpMatchedCells.Count == 0)
                {
                    var tmpNewCell = new Cell();
                    var tmpTable = tmpDataSheet1 as ku.by.Object.table;
                    tmpNewCell.field = tmpTable.getField(fieldKeyPair.Key);
                    tmpNewCell.value = ToolFunction.CellValueNullToDefault(fieldKeyPair.Value.FieldType, fieldKeyPair.Value.EnumType);
                    tmpOrm.cells.add(tmpNewCell);
                    tmpOrm.aliasMap.add(tmpOrm.cells.count, "b");
                }
                else
                {
                    tmpCells1.AddRange(tmpMatchedCells);

                    foreach (var machedCell in tmpMatchedCells)
                    {
                        int tmpCurrentIndex = tmpOrm.cells.indexOf(machedCell);
                        tmpOrm.aliasMap.add(tmpCurrentIndex, "b");
                    }
                }
            }

            Row tmpNewRow1 = new Row() { cells = tmpCells1, Identity = f_Row1.Identity, OrmSource = tmpOrm };
            tmpOrm.Tableb = tmpNewRow1;

            int tmpIndex = tmpOrm.cells.Count;

            return tmpOrm;
        }

        public override System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.OrmField> GenerateFieldMap()
        {
            List<OrmField> tmpFields = new List<OrmField>();
            return tmpFields;
        }
    }
}
