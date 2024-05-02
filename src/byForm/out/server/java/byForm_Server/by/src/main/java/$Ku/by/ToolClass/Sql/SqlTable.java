package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
public class SqlTable extends AbstractTable {
    private java.lang.String privateAlias;
    private $Ku.by.ToolClass.IBaseDataSheet privateSheet;

    public SqlTable($Ku.by.ToolClass.IBaseDataSheet f_DataSheet, java.lang.String f_Alias) {
        if (f_DataSheet == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("空的表源项");
        }
        this.setSheet(f_DataSheet);
        this.setAlias(f_Alias);
        this.setJoinTables(new java.util.ArrayList<JoinTable>());
    }


    @Override
    public java.lang.String getAlias() {
        return privateAlias;
    }

    @Override
    public void setAlias(java.lang.String value) {
        privateAlias = value;
    }

    public final $Ku.by.ToolClass.IBaseDataSheet getSheet() {
        return privateSheet;
    }

    private void setSheet($Ku.by.ToolClass.IBaseDataSheet value) {
        privateSheet = value;
    }

    public final java.lang.String getSourceName() {
        return this.getSheet().getSheetName();
    }

    public final java.lang.String getKuName() {
        return this.getSheet().getKuName();
    }

    @Override
    public java.lang.String getTableAccess() {
        String tmpKuName = this.privateSheet.getKuName();
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);
        if (this.getAlias() != null) {
            if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Oracle) {
                return "\"" + this.getAlias() + "\"";
            } else if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.SqlServer) {
                return "[" + this.getAlias() + "]";
            } else {
                return "`" + this.getAlias() + "`";
            }
        } else {
            if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.SqlServer) {
                return "[" + this.getSheet().getSheetName() + "]";
            } else if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Mysql) {
                return "`" + this.getSheet().getSheetName() + "`";
            } else if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Oracle) {
                return "\"" + this.getSheet().getSheetName() + "\"";
            } else {
                return this.getSheet().getSheetName();
            }
        }
    }

    public java.lang.String getTableDeclare() {
        $Ku.by.ToolClass.DBTypeEnum tmpDBType;
        if (!$Ku.by.ToolClass.Root.GetInstance().KuTypeDic.containsKey(this.getKuName())) {
            ThrowHelper.ThrowUnKnownException(String.format("库 %s 类型未填充", this.getKuName()));
        }
        tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(this.getKuName());
        StringBuilder tmpDec = new StringBuilder();
        if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.SqlServer) {
            tmpDec.append("[").append(this.getSheet().getSheetName()).append("]");
        } else if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Mysql) {
            tmpDec.append("`").append(this.getSheet().getSheetName()).append("`");
        } else {
            tmpDec.append("\"").append(this.getSheet().getSheetName()).append("\"");
        }

        if (this.getAlias() != null) {
            if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.SqlServer) {
                tmpDec.append("[").append(this.getAlias()).append("]");
            } else if (tmpDBType == $Ku.by.ToolClass.DBTypeEnum.Mysql) {
                tmpDec.append("`").append(this.getAlias()).append("`");
            } else {
                tmpDec.append("\"").append(this.getAlias()).append("\"");
            }
        }
        return tmpDec.toString();
    }

    @Override
    public $Ku.by.ToolClass.AbstractIdentityBase GetIdentity() {
        if (this.getSheet() == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("空的表源");
        }

        return this.getSheet().getIdentity();
    }

    @Override
    public $Ku.by.ToolClass.IBaseDataSheet GetSource() {
        return this.getSheet();
    }

    @Override
    public $Ku.by.ToolClass.Sql.AbstractTable Copy() {
        return null;
    }
}
