package $Ku.byLog.Identity;

public class log extends $Ku.by.Identity.Table {
    public java.lang.String pPathFileName;
    public java.lang.String pPathErrorFileName;
    public $Ku.byLog.Enum.logMode pLogMode = $Ku.byLog.Enum.logMode.values()[0];
    public $Ku.by.Identity.Attribute iSceneType;
    public $Ku.by.Identity.Reference iUserID;
    public $Ku.by.Identity.Attribute iUserName;
    public $Ku.by.Identity.Attribute iState;
    public $Ku.by.Identity.Attribute iIp;
    public $Ku.by.Identity.Attribute iSummary;
    public $Ku.by.Identity.Attribute iDt;
    private $Ku.by.ToolClass.Sql.SelectTable Source;

    public log() {
        this.pPathFileName = $Ku.by.Object.System.currentDirectory() + "byLog.txt";
        this.pPathErrorFileName = $Ku.by.Object.System.currentDirectory() + "byErrorLog.txt";
        this.pLogMode = $Ku.byLog.Enum.logMode.file;
    }


    public $Ku.by.Object.Row getRow($Ku.byLog.Enum.logState f_logState, java.lang.String f_content) {
        $Ku.by.Object.Row tmpRow = $Ku.by.ToolClass.ToolFunction.createInstance(new $Ku.by.Object.Row(), ($t, $objs) -> {
            Class<?> $clazz = $t.getClass();
            try {
                for ($Ku.by.ToolClass.Entry<String, Object> $item : $objs){
                    if($item.k.equals("$Identity")){
                        java.lang.reflect.Method method = $clazz.getMethod("$setIdentity", $Ku.by.ToolClass.AbstractIdentityBase.class);
                        method.invoke($t, $item.v);
                    }
                    else{
                        $clazz.getField($item.k).set($t, $item.v);
                    }
                }
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
            return $t;
        }, new $Ku.by.ToolClass.Entry<java.lang.String, Object>("$Identity", this));
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iID").value = $Ku.byCommon.Identity.general.getGuid();
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iState").value = f_logState;
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iSummary").value = f_content;
        $Ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iDt").value = $Ku.by.Object.Datetime.getNow();
        return tmpRow;
    }

    public void writeTable($Ku.byLog.Enum.logState f_logState, java.lang.String f_content) {
        {
            $Ku.by.Object.Row tmpRow = this.getRow(f_logState, f_content);
            $Ku.byLog.SqlExpression.LocalSql._0(new Object[]{tmpRow});
        }
    }

    public void writeFile($Ku.byLog.Enum.logState f_logState, java.lang.String f_content) {
        {
            $Ku.by.Object.Row tmpRow = this.getRow(f_logState, f_content);
            if (java.util.Objects.equals(f_logState, $Ku.byLog.Enum.logState.Error)) {
                $Ku.by.Object.File.writeAllText(this.pPathErrorFileName, tmpRow.toString(), true);
            }
            else {
                $Ku.by.Object.File.writeAllText(this.pPathFileName, tmpRow.toString(), true);
            }
        }
    }

    public void write($Ku.byLog.Enum.logState f_logState, java.lang.String f_content) {
        {
            if (java.util.Objects.equals(this.pLogMode, $Ku.byLog.Enum.logMode.fileDatabase)) {
                this.writeFile(f_logState, f_content);
                this.writeTable(f_logState, f_content);
            }
            else {
                if (java.util.Objects.equals(this.pLogMode, $Ku.byLog.Enum.logMode.file)) {
                    this.writeFile(f_logState, f_content);
                }
                else {
                    if (java.util.Objects.equals(this.pLogMode, $Ku.byLog.Enum.logMode.database)) {
                        this.writeTable(f_logState, f_content);
                    }
                }
            }
        }
    }

    public $Ku.byLog.Identity.log $getThis$Ku_byLog_Identity_log() {
        return this;
    }

    public void $setProps() {
    }

    public $Ku.by.ToolClass.Sql.SelectTable getSource() {
        return this.Source;
    }

    public void setSource($Ku.by.ToolClass.Sql.SelectTable value) {
        this.Source = value;
    }
}
