package $Ku.byLog.SqlExpression;

import $Ku.by.ToolClass.Sql.*;
import $Ku.by.ToolClass.*;
import java.util.ArrayList;
import $Ku.by.ToolClass.*;
import $Ku.by.ToolClass.Root;
public class Sql {
    public static java.lang.String[] _0($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        String tmpKuName = ToolFunction.GetKuInSql(f_Parameter);
        $Ku.by.ToolClass.DBTypeEnum tmpDBType = $Ku.by.ToolClass.Root.GetInstance().KuTypeDic.get(tmpKuName);

        if (tmpDBType == DBTypeEnum.SqlServer){
            return SqlserverAssembler._0(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Mysql){
            return MysqlAssembler._0(f_Parameter);
        }
        else if(tmpDBType == DBTypeEnum.Oracle){
            return OracleAssembler._0(f_Parameter);
        }
        else
        {
            throw new RuntimeException(ErrorInfo.UnsupportedDatabaseError);
        }
    }
}
