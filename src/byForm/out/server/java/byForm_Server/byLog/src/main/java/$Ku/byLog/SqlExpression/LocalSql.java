package $Ku.byLog.SqlExpression;

import $Ku.*;
import $Ku.by.Identity.*;
import $Ku.by.ToolClass.Sql.*;
import $Ku.by.Object.Cell;
import $Ku.by.Object.Row;
import $Ku.by.Object.List;
import $Ku.by.ToolClass.*;
import java.util.ArrayList;
public class LocalSql {
    public static Integer _0(Object[] f_Params) {
        ArrayList<AbstractTable> tmpTables = new ArrayList<>();
        ArrayList<Object> tmpParamList = new ArrayList<>();
        ParamsPackage tmpParamsPackage = new ParamsPackage(null, null, tmpTables, tmpParamList);
        tmpParamList.addAll(java.util.Arrays.asList(f_Params));
        return SqlHelper.ExecuteNonQuery($Ku.byLog.SqlExpression.Sql._0(tmpParamsPackage), ToolFunction.GetKuInSql(tmpParamsPackage));
    }
}
