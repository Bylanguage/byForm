package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
import $Ku.by.ToolClass.ErrorInfo;
import java.util.*;
public class SelectTable extends AbstractTable {
    public java.lang.Class< ? > ormType;
    public java.lang.Integer ReturnTypeIndex = 0;
    public java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> ResultItemsWithoutAsterisk;
    private java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> privateSelectItems;
    private java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> privateResultItems;
    private java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> privateTableSources;
    private java.lang.String privateSqlValue;
    private java.lang.String privateAlias;

    public SelectTable(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_ResultItems, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableSources, java.lang.String f_Sql, java.lang.Class< ? > ... f_OrmType) {
        this.setSelectItems(f_SelectItems);
        this.setResultItems(f_ResultItems);
        this.setTableSources(f_TableSources);
        this.setSqlValue(f_Sql);
        this.setJoinTables(new java.util.ArrayList<JoinTable>());
        this.ResultItemsWithoutAsterisk = new ArrayList<>();
        this.ReturnTypeIndex = -1;

        for (AbstractSelectField item : f_ResultItems)
        {
            if (item instanceof AsteriskField)
            {
                AsteriskField tmpAsteriskField =(AsteriskField) item;
                this.ResultItemsWithoutAsterisk.addAll(tmpAsteriskField.getFieldList());
            }
                else
            {
                this.ResultItemsWithoutAsterisk.add(item);
            }
        }
        if(f_OrmType.length > 0){
            ormType = f_OrmType[0];
        }
    }


    public final java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> getSelectItems() {
        return privateSelectItems;
    }

    public final void setSelectItems(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> value) {
        privateSelectItems = value;
    }

    public final java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> getResultItems() {
        return privateResultItems;
    }

    public final void setResultItems(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> value) {
        privateResultItems = value;
    }

    public final java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> getTableSources() {
        return privateTableSources;
    }

    public final void setTableSources(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> value) {
        privateTableSources = value;
    }

    public final java.lang.String getSqlValue() {
        return privateSqlValue;
    }

    public final void setSqlValue(java.lang.String value) {
        privateSqlValue = value;
    }

    @Override
    public java.lang.String getAlias() {
        return privateAlias;
    }

    @Override
    public void setAlias(java.lang.String value) {
        privateAlias = value;
    }

    @Override
    public java.lang.String getTableAccess() {
        if (this.getAlias() == null)
        {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.SelectResultAccessWithoutAlias);
        }
        else
        {
            return this.getAlias();
        }
    }

    @Override
    public $Ku.by.ToolClass.AbstractIdentityBase GetIdentity() {
        if (this.getTableSources().isEmpty())
        {
            return null;
        }

        return this.getTableSources().get(0).GetIdentity();
    }

    @Override
    public $Ku.by.ToolClass.IBaseDataSheet GetSource() {
        if (this.getTableSources().isEmpty())
        {
            return null;
        }

        return this.getTableSources().get(0).GetSource();
    }

    @Override
    public $Ku.by.ToolClass.Sql.AbstractTable Copy() {
        return null;
    }

    public final int GetIndexOfField($Ku.by.ToolClass.Sql.AbstractSelectField f_Field) {
        int tmpIndex = 0;
        boolean tmpHasFound = false;
        for (AbstractSelectField item : this.getResultItems())
        {
            if (item != f_Field)
            {
                if (item instanceof AsteriskField)
                {
                    AsteriskField tmpField = (AsteriskField) item;
                    tmpIndex += tmpField.getFieldCount();
                } else if (item instanceof PlusField) {
                    PlusField tmpField = (PlusField) item;
                    tmpIndex += tmpField.getFieldCount();
                } else
                {
                    tmpIndex++;
                }
            }
            else
            {
                tmpHasFound = true;
                break;
            }
        }
        if (!tmpHasFound)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("无法获取字段在查询结果中的索引");
        }
        return tmpIndex;
    }

    public $Ku.by.ToolClass.AbstractIdentityBase findTableIdentityWithAlias(java.lang.String f_Alias) {
        for (AbstractTable tablesource : this.getTableSources()) {
            if (Objects.equals(tablesource.getAlias(), f_Alias)) {
                return tablesource.GetIdentity();
            }

            for (JoinTable jointable : tablesource.getJoinTables()) {
                if (Objects.equals(jointable.getJoinTable().getAlias(), f_Alias)) {
                    return jointable.getJoinTable().GetIdentity();
                }
            }
        }

        throw ThrowHelper.ThrowUnKnownException(String.format("无法获取别名为 %s 的表源", f_Alias));
    }

    @Override
    public java.lang.String toString() {
        return this.privateSqlValue;
    }
}
