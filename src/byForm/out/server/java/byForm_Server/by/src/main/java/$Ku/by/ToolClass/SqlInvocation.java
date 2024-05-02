package $Ku.by.ToolClass;

import $Ku.by.ToolClass.Root;
import $Ku.by.JsonUtils.IJsonValue;
import $Ku.by.Object.Cell;
import java.util.Arrays;
public class SqlInvocation implements IJsonValue  {
    public static java.lang.String SqlResult;

    public static java.lang.String insertSql($Ku.by.ToolClass.IBaseDataSheet f_DataSheet, java.lang.String[] f_Columns, $Ku.by.Object.Row f_Row) {
        if (f_Columns.length == 0){
			return "";
		}
		DBTypeEnum tmpDBType;
		if (!Root.GetInstance().KuTypeDic.containsKey(f_DataSheet.getKuName()))
		{
			$Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_DataSheet.getKuName()));
		}
		tmpDBType = Root.GetInstance().KuTypeDic.get(f_DataSheet.getKuName());
		StringBuilder tmpSql = new StringBuilder();
		StringBuilder tmpValues = new StringBuilder(" VALUES(");
		tmpSql.append("INSERT INTO ");
		if (tmpDBType == DBTypeEnum.SqlServer) {
			tmpSql.append("[").append(f_DataSheet.getSheetName()).append("] (");
		}
		else
		{
			tmpSql.append("`").append(f_DataSheet.getSheetName()).append("` (");
		}
		for (int i = 0; i < f_Columns.length; i++){

			if (tmpDBType == DBTypeEnum.SqlServer)
			{
				tmpSql.append("[").append(f_Columns[i]).append("]");
			}
			else
			{
				tmpSql.append("`").append(f_Columns[i]).append("`");
			}

			String name = f_Columns[i];
			$Ku.by.Object.Cell tmpCell = f_Row.cells.stream().filter(item->item.ColumnName.equals(name)).findAny().orElse(null);
			if (tmpCell!=null){
				tmpValues.append(tmpCell.value.toString());
			}
			else {
				throw ThrowHelper.ThrowSqlPreCompileException(String.format($Ku.by.ToolClass.ErrorInfo.FlowInvocationFiledInRowMissing,f_DataSheet.getKuName() + "." + f_DataSheet.getSheetName(), "insert", f_Columns[i]));
			}
			if (i != f_Columns.length - 1)
			{
				tmpSql.append(", ");
				if (tmpCell != null)
				{
					tmpValues.append(", ");
				}
			}
		}

		for (String column : f_DataSheet.getDefaultColumnList()){
			if (Arrays.asList(f_Columns).contains(column)){
				continue;
			}
			if (tmpSql.length() != 16 + f_DataSheet.getSheetName().length())
			{
				tmpSql.append(", ");
			}

			if (tmpValues.length() != 8)
			{
				tmpSql.append(", ");
			}
			if (tmpDBType == DBTypeEnum.SqlServer)
			{
				tmpSql.append("[").append(column).append("]");
			}
			else
			{
				tmpSql.append("`").append(column).append("`");
			}
			String tmpDefault = f_DataSheet.getFieldDefault(column);
			tmpValues.append(tmpDefault);
		}

		tmpSql.append(")");
		tmpValues.append(")");
		if (tmpDBType == DBTypeEnum.Mysql || tmpDBType == DBTypeEnum.Oracle)
		{
			tmpSql.append(";");
		}
		tmpSql.append(tmpValues);
		return tmpSql.toString();
    
    }

    public static java.lang.String deleteSql($Ku.by.ToolClass.IBaseDataSheet f_DataSheet, java.lang.String[] f_Columns, $Ku.by.Object.Row f_Row) {
        {
        if (f_Columns.length == 0){
			return "";
		}
		DBTypeEnum tmpDBType;
		if (!Root.GetInstance().KuTypeDic.containsKey(f_DataSheet.getKuName()))
		{
			$Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_DataSheet.getKuName()));
		}
		tmpDBType = Root.GetInstance().KuTypeDic.get(f_DataSheet.getKuName());
		StringBuilder tmpSql = new StringBuilder("DELETE FROM ");
		if (tmpDBType == DBTypeEnum.SqlServer)
		{
			tmpSql.append("[").append(f_DataSheet.getSheetName()).append("] WHERE ");
		}
		else
		{
			tmpSql.append("`").append(f_DataSheet.getSheetName()).append("` WHERE ");
		}
		for (int i = 0; i < f_Columns.length ; i++){
			String name = f_Columns[i];
			$Ku.by.Object.Cell tmpCell = f_Row.cells.stream().filter(item->item.ColumnName.equals(name)).findAny().orElse(null);
			if (tmpCell==null){
				throw ThrowHelper.ThrowSqlPreCompileException(String.format($Ku.by.ToolClass.ErrorInfo.FlowInvocationFiledInRowMissing,f_DataSheet.getKuName() + "." + f_DataSheet.getSheetName(), "insert", f_Columns[i]));
			}
			if (tmpDBType == DBTypeEnum.SqlServer)
			{
				tmpSql.append("[").append(f_Columns[i]).append("] = ");
			}
			else
			{
				tmpSql.append("`").append(f_Columns[i]).append("` = ");
			}

			tmpSql.append(tmpCell.value.toString());
			if (i != f_Columns.length - 1){
				tmpSql.append(" AND ");
			}
		}

		if (tmpDBType == DBTypeEnum.Mysql || tmpDBType == DBTypeEnum.Oracle)
		{
			tmpSql.append(";");
		}

		return tmpSql.toString();
    }
    }

    public static java.lang.String updateSql($Ku.by.ToolClass.IBaseDataSheet f_DataSheet, java.lang.String[] f_Columns, $Ku.by.Object.Row f_Row, java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> f_PKList) {
        if (f_Columns.length == 0){
			return "";
		}
		DBTypeEnum tmpDBType;
		if (!Root.GetInstance().KuTypeDic.containsKey(f_DataSheet.getKuName()))
		{
			$Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_DataSheet.getKuName()));
		}

		StringBuilder tmpSql = new StringBuilder("UPDATE ");
		tmpDBType = Root.GetInstance().KuTypeDic.get(f_DataSheet.getKuName());
		if (tmpDBType == DBTypeEnum.SqlServer)
		{
			tmpSql.append("[").append(f_DataSheet.getSheetName()).append("] SET ");
		}
		else
		{
			tmpSql.append("`").append(f_DataSheet.getSheetName()).append("` SET ");
		}
        for (int i = 0; i < f_Columns.length; i++){
			String name = f_Columns[i];
			$Ku.by.Object.Cell tmpCell = f_Row.cells.stream().filter(item->item.ColumnName.equals(name)).findAny().orElse(null);
			if (tmpCell==null){
				throw ThrowHelper.ThrowSqlPreCompileException(String.format($Ku.by.ToolClass.ErrorInfo.FlowInvocationFiledInRowMissing,f_DataSheet.getKuName() + "." + f_DataSheet.getSheetName(), "insert", f_Columns[i]));
			}
			if (tmpDBType == DBTypeEnum.SqlServer)
			{
				tmpSql.append("[").append(f_Columns[i]).append("] = ");
			}
			else
			{
				tmpSql.append("`").append(f_Columns[i]).append("` = ");
			}
			tmpSql.append(tmpCell.value.toString());
			if (i != f_Columns.length - 1){
				tmpSql.append(", ");
			}
		}
		if (!f_PKList.isEmpty()){
			tmpSql.append(" WHERE ");
			for (int i = 0; i < f_PKList.size(); i++){
				String name = f_PKList.get(i).getName();
				$Ku.by.Object.Cell tmpCell = f_Row.cells.stream().filter(item->item.ColumnName.equals(name)).findAny().orElse(null);
				if (tmpCell==null){
					throw new RuntimeException("更新流表达式主键不完整");
				}
				if (tmpDBType == DBTypeEnum.SqlServer)
				{
					tmpSql.append("[").append(f_PKList.get(i).getName()).append("]").append(" = ");
				}
				else
				{
					tmpSql.append("`").append(f_PKList.get(i).getName()).append("`").append(" = ");
				}

				tmpSql.append(tmpCell.value.toString());
				if (i != f_PKList.size() - 1){
					tmpSql.append(", ");
				}
			}
		}

		if (tmpDBType == DBTypeEnum.Mysql || tmpDBType == DBTypeEnum.Oracle)
		{
			tmpSql.append(";");
		}

		return tmpSql.toString();
    }
}
