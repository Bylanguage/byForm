package $Ku.byUser.Orm;

import $Ku.by.Object.*;
public class TemporaryOrm$1 extends $Ku.by.Object.AbstractOrm {
    public $Ku.by.ToolClass.Sql.SelectTable selectTable;
    public $Ku.by.Object.ReadOnlyList<$Ku.by.Object.Cell> cells;
    public java.util.HashMap<java.lang.String, java.util.ArrayList<java.lang.Integer>> tablesMap = new java.util.HashMap<>();
    public java.lang.Integer Member0 = 0;
    private java.lang.Integer memberIndex0 = 0;
    public $Ku.by.Object.Row Table0;

    public TemporaryOrm$1($Ku.by.ToolClass.Sql.SelectTable f_SelectTable, $Ku.by.Object.Row f_Row) {
        selectTable = f_SelectTable;
        cells = new $Ku.by.Object.ReadOnlyList<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), f_Row.cells().toList());

        $Ku.by.ToolClass.Sql.AbstractSelectField tmpField0 = f_SelectTable.getSelectItems().get(0);
        memberIndex0 = f_SelectTable.GetIndexOfField(tmpField0);
        Member0 = Integer.parseInt(f_Row.getcells().get(memberIndex0).value.toString());
        java.util.ArrayList<$Ku.by.Object.Cell> tmpCells0 = new java.util.ArrayList<>();
        java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> tmpFieldList0 = new java.util.ArrayList<>();
        for ($Ku.by.ToolClass.Sql.AbstractSelectField st : f_SelectTable.getResultItems()){
            if(st.getFieldTable() != null &&  "a".equals(st.getFieldTable().getAlias())){
                tmpFieldList0.add(st);
                if(!this.tablesMap.containsKey("a")){
                    this.tablesMap.put("a", new java.util.ArrayList<>());
                }
                this.tablesMap.get("a").add(f_SelectTable.GetIndexOfField(st));
            }
        }
        $Ku.by.ToolClass.Sql.AbstractTable tmpVar0 = null;
        for ($Ku.by.ToolClass.Sql.AbstractTable at : f_SelectTable.getTableSources()){
            if("a".equals(at.getAlias())){
                tmpVar0 = at;
            }
        }
        $Ku.by.ToolClass.Sql.SqlTable tmpTable0 = ($Ku.by.ToolClass.Sql.SqlTable)((tmpVar0 instanceof $Ku.by.ToolClass.Sql.SqlTable) ? tmpVar0 : null);
        $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet0 = tmpTable0.getSheet();
        $Ku.by.ToolClass.AbstractIdentityBase tmpIdentity0 = tmpDataSheet0.getIdentity();
        for ($Ku.by.ToolClass.Sql.AbstractSelectField item : tmpFieldList0)
        {
            int tmpIndex = f_SelectTable.GetIndexOfField(item);
            if (item instanceof $Ku.by.ToolClass.Sql.IFields){
                $Ku.by.ToolClass.Sql.IFields tmpIFields = ($Ku.by.ToolClass.Sql.IFields)item;
                for (int i = 0; i < tmpIFields.getFieldCount(); i++){
                $Ku.by.Object.Cell tmpCell = f_Row.getcells().get(tmpIndex).CopyValue();
                tmpCell.setSheetName(tmpDataSheet0.getSheetName());
                tmpCells0.add(tmpCell);
                }
            }
            else{
                $Ku.by.Object.Cell tmpCell = f_Row.getcells().get(tmpIndex).CopyValue();
                tmpCell.setSheetName(tmpDataSheet0.getSheetName());
                tmpCells0.add(tmpCell);
            }
        }
        $Ku.by.Object.Row tmpRow0 = new $Ku.by.Object.Row();
        tmpRow0.setcells(tmpCells0);
        tmpRow0.setKuName(tmpDataSheet0.getKuName());
        tmpRow0.setSheetName(tmpDataSheet0.getSheetName());
        tmpRow0.setIdentity(tmpIdentity0);
        this.Table0 = tmpRow0;

    }


    public String toString() {
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
            return new TemporaryOrm$1(selectTable, tmpNewRow);
        } catch (java.lang.Exception e){
            throw new RuntimeException(e);
        }
    }

    public $Ku.by.Object.ReadOnlyList<$Ku.by.Object.Cell> cells() {
        return cells;
    }

    public java.util.ArrayList<$Ku.by.ToolClass.OrmField> getOrmFields() {
        return null;
    }

    public java.util.HashMap<java.lang.String, java.util.ArrayList<java.lang.Integer>> getTablesMap() {
        return this.tablesMap;
    }
}
