package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.ErrorInfo;
import $Ku.by.ToolClass.ToolFunction;
public class PlusField extends AbstractSelectField implements IFields  {
    private java.lang.String privateAlias;
    private $Ku.by.ToolClass.Sql.AbstractTable privateFieldTable;
    private java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> privateFieldList;

    public PlusField($Ku.by.ToolClass.Sql.AbstractTable f_Table) {
        this.setFieldList(new java.util.ArrayList<AbstractSelectField>());
        this.setFieldTable(f_Table);
    }


    @Override
    public java.lang.String getAlias() {
        return null;
    }

    @Override
    public void setAlias(java.lang.String value) {
        $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("无法设置别名");
    }

    @Override
    public $Ku.by.ToolClass.Sql.AbstractTable getFieldTable() {
        return privateFieldTable;
    }

    @Override
    public void setFieldTable($Ku.by.ToolClass.Sql.AbstractTable value) {
        privateFieldTable = value;
    }

    @Override
    public java.lang.String getFieldAccess() {
        throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.UnExceptedField);
    }

    @Override
    public java.lang.String getSelectItemDeclare() {
        StringBuilder tmpValue = new StringBuilder();

        for (int i = 0; i < this.getFieldList().size(); i++)
        {
            AbstractSelectField tmpField = this.getFieldList().get(i);
            if (tmpField instanceof IFields)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("字段填充错误");
            }
            if (tmpValue.length() != 0)
            {
                tmpValue.append(", ");
            }
            tmpValue.append(tmpField.getSelectItemDeclare());
        }

        return tmpValue.toString();
    }

    public final int getFieldCount() {
        int tmpCount = 0;
        for (AbstractSelectField item : this.getFieldList())
        {
            if (item instanceof IFields)
            {
                try {
                    $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("字段填充错误");
                } catch (java.lang.Exception e) {
                    throw new RuntimeException(e);
                }
            }
            tmpCount++;
        }

        return tmpCount;
    }

    public final java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> getFieldList() {
        return privateFieldList;
    }

    public final void setFieldList(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> value) {
        privateFieldList = value;
    }

    public final void AddField(java.lang.String f_Component, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables) {
        String[] tmpArray = f_Component.split("[.]", -1);
        java.util.ArrayList<AbstractSelectField> tmpCompared = new java.util.ArrayList<>();

        if (tmpArray.length == 2)
        {
            String tmpTableSourceAlias = tmpArray[0];
            String tmpFieldAlias = tmpArray[1];
            for (AbstractTable item : f_Tables)
            {
                if (!tmpTableSourceAlias.equals(item.getAlias()))
                {
                    continue;
                }

                if (item instanceof $Ku.by.ToolClass.Sql.SqlTable)
                {
                    $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable)item;
                    IBaseDataSheet tmpDataSheet = tmpTable.getSheet();

                    if (!tmpDataSheet.getComponentDic().containsKey(tmpFieldAlias))
                    {
                        return;
                    }

                    tmpCompared.add(TableField.GetPlusTableField(tmpDataSheet.getComponentDic().get(tmpFieldAlias), tmpTable));

                    if (tmpCompared.size() > 1)
                    {
                        $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.UnClearColumnName, f_Component));
                    }
                }
            }
        }

        if (!tmpCompared.isEmpty())
        {
            this.getFieldList().add(tmpCompared.get(0));
        }
    }
}
