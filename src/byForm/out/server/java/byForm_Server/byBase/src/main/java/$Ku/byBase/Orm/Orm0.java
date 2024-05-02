package $Ku.byBase.Orm;

import $Ku.by.Object.*;
import $Ku.by.ToolClass.Sql.*;
import java.util.*;
import $Ku.by.ToolClass.Exceptions.*;
public class Orm0 extends $Ku.by.Object.AbstractOrm {
    public $Ku.by.ToolClass.Sql.SelectTable selectTable;
    public $Ku.by.Object.List<$Ku.by.Object.Cell> cells;
    public java.util.HashMap<java.lang.String, java.util.ArrayList<java.lang.Integer>> tablesMap = new java.util.HashMap<>();
    public java.util.ArrayList<$Ku.by.ToolClass.OrmField> ormFields = new ArrayList<>();
    public $Ku.by.Object.Row Table0;
    public $Ku.by.Object.Row Table1;

    public Orm0($Ku.by.ToolClass.Sql.SelectTable f_SelectTable, $Ku.by.Object.Row f_Row) {
        selectTable = f_SelectTable;
        cells = new $Ku.by.Object.List<$Ku.by.Object.Cell>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), f_Row.cells);
        java.util.ArrayList<$Ku.by.Object.Cell> tmpCells0 = new java.util.ArrayList<>();
        java.util.ArrayList<AbstractSelectField> tmpFieldList0 = new java.util.ArrayList<>();
        for (AbstractSelectField st : f_SelectTable.getResultItems()){
            if(st.getFieldTable() != null &&  "a".equals(st.getFieldTable().getAlias())){
                tmpFieldList0.add(st);
                if(!this.tablesMap.containsKey("a")){
                    this.tablesMap.put("a", new ArrayList<>());
                }
                this.tablesMap.get("a").add(f_SelectTable.GetIndexOfField(st));
            }
        }
        $Ku.by.ToolClass.AbstractIdentityBase tmpIdentity0 = f_SelectTable.findTableIdentityWithAlias("a");
        for (AbstractSelectField item : tmpFieldList0)
        {
            int tmpIndex = f_SelectTable.GetIndexOfField(item);
            if (item instanceof IFields){
                IFields tmpIFields = (IFields)item;
                for (int i = 0; i < tmpIFields.getFieldCount(); i++){
                    $Ku.by.Object.Cell tmpCell = f_Row.cells.get(i);
                    tmpCells0.add(tmpCell);
                }
            }
            else{
                $Ku.by.Object.Cell tmpCell = f_Row.cells.get(tmpIndex);
                tmpCells0.add(tmpCell);
            }
        }
        $Ku.by.Object.Row tmpRow0 = new $Ku.by.Object.Row();
        tmpRow0.cells = tmpCells0;
        tmpRow0.OrmSource = this;
        tmpRow0.$Identity = tmpIdentity0;
        this.Table0 = tmpRow0;

        java.util.ArrayList<$Ku.by.Object.Cell> tmpCells1 = new java.util.ArrayList<>();
        java.util.ArrayList<AbstractSelectField> tmpFieldList1 = new java.util.ArrayList<>();
        for (AbstractSelectField st : f_SelectTable.getResultItems()){
            if(st.getFieldTable() != null &&  "b".equals(st.getFieldTable().getAlias())){
                tmpFieldList1.add(st);
                if(!this.tablesMap.containsKey("b")){
                    this.tablesMap.put("b", new ArrayList<>());
                }
                this.tablesMap.get("b").add(f_SelectTable.GetIndexOfField(st));
            }
        }
        $Ku.by.ToolClass.AbstractIdentityBase tmpIdentity1 = f_SelectTable.findTableIdentityWithAlias("b");
        for (AbstractSelectField item : tmpFieldList1)
        {
            int tmpIndex = f_SelectTable.GetIndexOfField(item);
            if (item instanceof IFields){
                IFields tmpIFields = (IFields)item;
                for (int i = 0; i < tmpIFields.getFieldCount(); i++){
                    $Ku.by.Object.Cell tmpCell = f_Row.cells.get(i);
                    tmpCells1.add(tmpCell);
                }
            }
            else{
                $Ku.by.Object.Cell tmpCell = f_Row.cells.get(tmpIndex);
                tmpCells1.add(tmpCell);
            }
        }
        $Ku.by.Object.Row tmpRow1 = new $Ku.by.Object.Row();
        tmpRow1.cells = tmpCells1;
        tmpRow1.OrmSource = this;
        tmpRow1.$Identity = tmpIdentity1;
        this.Table1 = tmpRow1;

    }

    public Orm0() {
        cells = new $Ku.by.Object.List<$Ku.by.Object.Cell>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class));
    }


    public java.util.ArrayList<$Ku.by.ToolClass.OrmField> getOrmFields() {
        return this.ormFields;
    }

    public java.util.HashMap<java.lang.String, java.util.ArrayList<java.lang.Integer>> getTablesMap() {
        return this.tablesMap;
    }

    public java.lang.String toString() {
        StringBuilder tmpValue = new StringBuilder();
		for (int i = 0; i < cells.size(); i++) {
			if(i != 0){
				tmpValue.append("\r\n");
            }
            tmpValue.append(cells.get(i).toString());
		}
		return tmpValue.toString();
    }

    public java.lang.Boolean byObjectEquals($Ku.by.Object.AbstractOrm orm) {
        if(this.getClass() != orm.getClass()){
			return false;
		}
		if(this.cells.size() != orm.cells().size()){
			return false;
		}
		for (int i = 0; i < cells.size(); i++) {
			$Ku.by.Object.Cell tmpCell1 = cells.get(i);
			$Ku.by.Object.Cell tmpCell2 = orm.cells().get(i);
			if (!tmpCell1.equals(tmpCell2))
			{
				return false;
			}
		}
		return true;
    }

    public $Ku.by.Object.AbstractOrm clone() {
        $Ku.by.Object.Row tmpNewRow = new $Ku.by.Object.Row();
        java.util.ArrayList<$Ku.by.Object.Cell> tmpNewCells = new java.util.ArrayList<>();
        for($Ku.by.Object.Cell item: cells){
            tmpNewCells.add(item.CopyValue());
        }
        tmpNewRow.cells = tmpNewCells;
        try{
            return new Orm0(selectTable, tmpNewRow);
        } catch (java.lang.Exception e){
            throw new RuntimeException(e);
        }
    }

    public static $Ku.byBase.Orm.Orm0 create($Ku.by.Object.Row f_Row0, $Ku.by.Object.Row f_Row1) {
        Orm0 tmpOrm = new Orm0();
        
        if (f_Row0 == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowOrmException("无法通过空引用创建orm实例");
        }

        if (f_Row0.getIdentity() == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowOrmException($Ku.by.ToolClass.ErrorInfo.RowIdentityError);
        }

        $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet0 = ($Ku.by.ToolClass.IBaseDataSheet) f_Row0.getIdentity().to;

        if (tmpDataSheet0 == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowOrmException($Ku.by.ToolClass.ErrorInfo.RowIdentityNotMatchSheet);
        }

        tmpOrm.cells.addRange(new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), f_Row0.cells));
        ArrayList<Cell> tmpCells0 = new ArrayList<>();

        for (Map.Entry<java.lang.String, $Ku.by.ToolClass.Sql.SqlField> fieldKeyPair : tmpDataSheet0.getFieldDic().entrySet()) {
            String tmpFileName = fieldKeyPair.getKey();
            ArrayList<Cell> tmpMatchedCells = new ArrayList<>();
            for ($Ku.by.Object.Cell cell : f_Row0.cells) {
                if (Objects.equals(cell.KuName, tmpDataSheet0.getKuName()) && Objects.equals(cell.SheetName, tmpDataSheet0.getSheetName()) && Objects.equals(cell.ColumnName, tmpFileName)) {
                    tmpMatchedCells.add(cell);
                }
            }

            if (tmpMatchedCells.isEmpty()) {
                Cell tmpNewCell = new Cell();
                $Ku.by.Object.Table tmpTable = ($Ku.by.Object.Table) tmpDataSheet0;
                tmpNewCell.cellField = tmpTable.getField(fieldKeyPair.getKey());
                tmpNewCell.value = $Ku.by.ToolClass.ToolFunction.CellValueNullToDefault(fieldKeyPair.getValue().getFieldType(), fieldKeyPair.getValue().getEnumType());
                tmpOrm.cells.add(tmpNewCell);
            } else {
                tmpCells0.addAll(tmpMatchedCells);
            }
        }

        Row tmpNewRow0 = new Row();
        tmpNewRow0.cells = tmpCells0;
        tmpNewRow0.$Identity = f_Row0.$Identity;
        tmpNewRow0.OrmSource = tmpOrm;

        tmpOrm.Table0 = tmpNewRow0;

        
        if (f_Row1 == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowOrmException("无法通过空引用创建orm实例");
        }

        if (f_Row1.getIdentity() == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowOrmException($Ku.by.ToolClass.ErrorInfo.RowIdentityError);
        }

        $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet1 = ($Ku.by.ToolClass.IBaseDataSheet) f_Row1.getIdentity().to;

        if (tmpDataSheet1 == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowOrmException($Ku.by.ToolClass.ErrorInfo.RowIdentityNotMatchSheet);
        }

        tmpOrm.cells.addRange(new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), f_Row1.cells));
        ArrayList<Cell> tmpCells1 = new ArrayList<>();

        for (Map.Entry<java.lang.String, $Ku.by.ToolClass.Sql.SqlField> fieldKeyPair : tmpDataSheet0.getFieldDic().entrySet()) {
            String tmpFileName = fieldKeyPair.getKey();
            ArrayList<Cell> tmpMatchedCells = new ArrayList<>();
            for ($Ku.by.Object.Cell cell : f_Row0.cells) {
                if (Objects.equals(cell.KuName, tmpDataSheet0.getKuName()) && Objects.equals(cell.SheetName, tmpDataSheet0.getSheetName()) && Objects.equals(cell.ColumnName, tmpFileName)) {
                    tmpMatchedCells.add(cell);
                }
            }

            if (tmpMatchedCells.isEmpty()) {
                Cell tmpNewCell = new Cell();
                $Ku.by.Object.Table tmpTable = ($Ku.by.Object.Table) tmpDataSheet0;
                tmpNewCell.cellField = tmpTable.getField(fieldKeyPair.getKey());
                tmpNewCell.value = $Ku.by.ToolClass.ToolFunction.CellValueNullToDefault(fieldKeyPair.getValue().getFieldType(), fieldKeyPair.getValue().getEnumType());
                tmpOrm.cells.add(tmpNewCell);
            } else {
                tmpCells1.addAll(tmpMatchedCells);
            }
        }

        Row tmpNewRow1 = new Row();
        tmpNewRow1.cells = tmpCells1;
        tmpNewRow1.$Identity = f_Row1.$Identity;
        tmpNewRow1.OrmSource = tmpOrm;

        tmpOrm.Table1 = tmpNewRow1;

        return tmpOrm;
    }

    public $Ku.by.Object.ReadOnlyList<$Ku.by.Object.Cell> cells() {
        return new $Ku.by.Object.ReadOnlyList<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), cells));
    }
}
