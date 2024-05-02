package $Ku.by.Object;

import $Ku.by.ToolClass.*;
import java.util.ArrayList;
public class Row extends $Ku.by.Object.ByObject {
    public $Ku.by.Object.Table table;
    public $Ku.by.Object.AbstractOrm OrmSource;
    public java.util.ArrayList<$Ku.by.Object.Cell> cells;
    private java.lang.String SheetName;
    private java.lang.String KuName;

    public Row() {
        this.cells = new ArrayList<>();
    }

    public Row(java.lang.String f_QualifiedName) {
        this.cells = new ArrayList<>();
        String[] tmpArray = f_QualifiedName.split("\\.");
        if (tmpArray.length != 2){
            throw new RuntimeException("表名格式错误");
        }
        this.KuName = tmpArray[0];
        this.SheetName = tmpArray[1];
    }


    public $Ku.by.ToolClass.AbstractIdentityBase getComponent(java.lang.String f_ComponentName) {
        try{
            Class<?> clazz = Class.forName("$Ku."+this.KuName+"."+this.KuName);
            BaseKu ku = (BaseKu) clazz.getDeclaredConstructor().newInstance();
            String identityName = ku.NewIdentityKeyIsId.get(this.$Identity);
            String componentName = identityName + "." + f_ComponentName;
            return ku.NewIdentityDic.get(componentName);
        }catch (java.lang.Exception e){
            throw new RuntimeException(e);
        }
    }

    public void addCell($Ku.by.Object.Field f_Field, Object f_Value) {
        
    }

    public Object getComponentValue(java.lang.String f_ComponentName) {
        $Ku.by.Object.Field to = ($Ku.by.Object.Field) this.getComponent(f_ComponentName).to;
        return this.getItem(to.name).value;
    }

    public final $Ku.by.Object.Cell getItem(java.lang.String f_FieldName) {
        $Ku.by.Object.Cell tmpCell = null;
        for ($Ku.by.Object.Cell item:this.cells){
            if (f_FieldName.equals(item.ColumnName)){
                tmpCell = item;
            }
        }
        if (tmpCell == null)
        {
            throw new RuntimeException(String.format("无法获取列名为 %1$s 的单元格", f_FieldName));
        }
        return tmpCell;
    }

    public $Ku.by.Object.Row Copy() {
        $Ku.by.Object.Row tmpRow = new $Ku.by.Object.Row();
        tmpRow.KuName = this.KuName;
        tmpRow.SheetName = this.SheetName;
        tmpRow.$Identity = this.$Identity;
        tmpRow.cells = new ArrayList<>();
        for($Ku.by.Object.Cell item : this.cells){
            tmpRow.cells.add(item.CopyValue());
        }
        tmpRow.table = this.table;
        return tmpRow;
    }

    public java.util.ArrayList<$Ku.by.Object.Cell> getcells() {
        return cells;
    }

    public void setcells(java.util.ArrayList<$Ku.by.Object.Cell> cells) {
        this.cells = cells;
    }

    public final java.lang.String getSheetName() {
        if (this.SheetName != null) {
            return this.SheetName;
        }

        if (this.$Identity == null) {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException("行身份为空或身份未配置表无法获取库名信息");
        } else {
            IBaseDataSheet tmpDataSheet = (IBaseDataSheet) this.$Identity.to;

            if (tmpDataSheet == null) {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException("行身份为空或身份未配置表无法获取库名信息");
            }
            this.SheetName = tmpDataSheet.getSheetName();
            return this.SheetName;
        }
    }

    public void setSheetName(java.lang.String value) {
        this.SheetName = value;
    }

    public final java.lang.String getKuName() {
        if (this.KuName != null) {
            return this.KuName;
        }

        if (this.$Identity == null) {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException("行身份为空或身份未配置表无法获取库名信息");
        } else {
            IBaseDataSheet tmpDataSheet = (IBaseDataSheet) this.$Identity.to;

            if (tmpDataSheet == null) {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException("行身份为空或身份未配置表无法获取库名信息");
            }
            this.KuName = tmpDataSheet.getKuName();
            return this.KuName;
        }
    }

    public void setKuName(java.lang.String value) {
        this.KuName = value;
    }

    public $Ku.by.ToolClass.AbstractIdentityBase getIdentity() {
        return this.$Identity;
    }

    public void setIdentity($Ku.by.ToolClass.AbstractIdentityBase Identity) {
        $setIdentity(Identity);
    }

    public boolean equals($Ku.by.Object.Row row) {
        if (this.cells.size() != row.cells.size()) {
            return false;
        }

        for (int i = 0; i < this.cells.size(); i++) {
            $Ku.by.Object.Cell tmpCell1 = this.cells.get(i);
            $Ku.by.Object.Cell tmpCell2 = row.cells.get(i);

            if (!tmpCell1.ColumnName.equals(tmpCell2.ColumnName)) {
                return false;
            }

            if (!java.util.Objects.equals(tmpCell1.value, tmpCell2.value)) {
                return false;
            }
        }

        return true;
    }

    public java.lang.Boolean byObjectEquals(Object object) {
        return object.equals(this);
    }

    public $Ku.by.Object.Result verify() {
        $Ku.by.Object.Result tmpResult = new $Ku.by.Object.Result();
        try {
            $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = $Ku.by.ToolClass.ToolFunction.GetDataSheet(this.getKuName(), this.getSheetName());
            for ($Ku.by.Object.Cell item : this.cells) {
                if (!item.getKuName().equals(this.getKuName())) {
                    continue;
                }

                if (!item.getSheetName().equals(this.getSheetName())) {
                    continue;
                }

                if (item.AggregateFunctionName != null) {
                    continue;
                }

                $Ku.by.ToolClass.Sql.SqlField tmpField = tmpDataSheet.getFieldDic().getOrDefault(item.ColumnName, null);
                if (tmpField == null) {

                    $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format($Ku.by.ToolClass.ErrorInfo.CanNotFindComponentInSheet,item.KuName + "." + item.SheetName, item.ColumnName));
                }

                $Ku.by.ToolClass.VerifyFunction.FieldVerify(tmpDataSheet.getVerifyDic().get(item.ColumnName), tmpField, item.value==null?null:item.value.toString());
            }
        } catch (java.lang.Exception ex) {
            tmpResult.isOk=false;
            tmpResult.info=ex.getMessage();
            return tmpResult;
        }

        tmpResult.isOk=true;
        tmpResult.info=null;
        return tmpResult;
    }

    public java.lang.String toString() {
        StringBuilder tmpValue = new StringBuilder();
        for (int i = 0; i < this.cells.size(); i++) {
            if (i != 0) {
                tmpValue.append("\r\n");
            }

            $Ku.by.Object.Cell tmpCell = this.cells.get(i);
            tmpValue.append(tmpCell.toString());
        }
        return tmpValue.toString();
    }

    public $Ku.by.Object.ReadOnlyList<$Ku.by.Object.Cell> cells() {
        return new $Ku.by.Object.ReadOnlyList<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Cell.class), cells));
    }

    public void $setIdentity($Ku.by.ToolClass.AbstractIdentityBase value) {
        $Ku.by.Object.Row $this = this;
        if (this.$Identity != null) {
            return;
        }
        this.$Identity = value;
        if (value.to != null && value.to instanceof IBaseDataSheet) {
            IBaseDataSheet tmpDataSheet = (IBaseDataSheet) value.to;
            this.cells = new ArrayList<>();
            for ($Ku.by.ToolClass.Sql.SqlField tmpField : tmpDataSheet.getFieldDic().values()) {
                $Ku.by.Object.Cell tmpNewCell = new $Ku.by.Object.Cell();
                tmpNewCell.DataTypeEnum = tmpField.getFieldType();
                tmpNewCell.EnumType = tmpField.getEnumType();
                tmpNewCell.row = $this;
                tmpNewCell.AssembleField(tmpField.getKuName(), tmpField.getSheetName(), tmpField.getName());
                switch (tmpNewCell.DataTypeEnum) {
                    case Byte:
                    case Decimal:
                    case Double:
                    case Float:
                    case Int:
                    case Long:
                    case Short:
                        tmpNewCell.value = 0;
                        break;
                    case Bool:
                        tmpNewCell.value = false;
                        break;
                    case Char:
                        tmpNewCell.value = '\0';
                        break;
                    case Datetime:
                        tmpNewCell.value = new $Ku.by.Object.Datetime();
                        break;
                    case String:
                        tmpNewCell.value = "";
                        break;
                    case Enum:
                        Class<?> tmpEnumType = tmpField.getEnumType();
                        tmpNewCell.value = tmpEnumType.getEnumConstants()[0];
                        break;
                    default:
                        tmpNewCell.value = null;
                        break;
                }

                this.cells.add(tmpNewCell);
            }
        }
    }
}
