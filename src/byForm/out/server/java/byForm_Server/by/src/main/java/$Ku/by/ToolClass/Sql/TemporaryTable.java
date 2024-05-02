package $Ku.by.ToolClass.Sql;

import $Ku.by.ToolClass.ThrowHelper;
public class TemporaryTable extends AbstractTable {
    private java.lang.String privateAlias;

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
        if (this.getAlias() == null ){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("临时表别名为空") ;
        }
        return this.getAlias();
    }

    @Override
    public $Ku.by.ToolClass.AbstractIdentityBase GetIdentity() {
        throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("临时表无法获取身份");
    }

    @Override
    public $Ku.by.ToolClass.IBaseDataSheet GetSource() {
        throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("临时表无法获取表源");
    }

    @Override
    public $Ku.by.ToolClass.Sql.AbstractTable Copy() {
        throw new RuntimeException("临时表无法复制");
    }
}
