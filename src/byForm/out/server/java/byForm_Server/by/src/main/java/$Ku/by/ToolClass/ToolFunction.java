package $Ku.by.ToolClass;

import $Ku.by.Object.*;
import $Ku.by.ToolClass.Sql.*;
import java.util.*;
import java.math.BigDecimal;
import java.lang.reflect.Array;
import $Ku.by.ToolClass.Root;
import $Ku.by.ToolClass.Exceptions.*;
public class ToolFunction {
    public static java.lang.Boolean isByPrimitive(Object obj) {
        if(obj == null){
            return false;
        }
        Class<?> clazz = obj.getClass();
        return clazz == $Ku.by.Object.Decimal.class || clazz == Integer.class || clazz == Byte.class || clazz == Short.class || clazz == Long.class
                || clazz == Character.class || clazz == Float.class || clazz == Double.class || clazz == Boolean.class;
    }

    public static <T> T castTo(Object f_Value) {
        if(f_Value == null){
            return null;
        }
        Class<?> clazz = f_Value.getClass();

        for (java.lang.reflect.Method item : clazz.getMethods()){
            if(item.getName().equals("$getIdentity")){
                try {
                    return (T)item.invoke(f_Value);
                } catch (java.lang.Exception e) {
                    throw new RuntimeException(e);
                }
            }
        }

        throw ThrowHelper.ThrowUnKnownException("类型转换失败");
    }

    public static <T> T createInstance(T t, Create<T> method, $Ku.by.ToolClass.Entry<java.lang.String, Object> ... objs) {
        return method.setProps(t, objs);
    }

    public static java.lang.String toString(Object obj) {
        if(obj == null){
            return null;
        }
        return obj.toString();
    }

    public static <T> T ListAssignment($Ku.by.Object.List<T> tmpList, java.lang.Integer index, T value) {
        tmpList.assign(index, value);
        return value;
    }

    public static <K, V> V DictionaryAssignment($Ku.by.Object.Dictionary<K, V> tmpDic, K index, V value) {
        tmpDic.assign(index, value);
        return value;
    }

    public static java.lang.Boolean ByPrimitiveTypeEquals(Object obj1, Object obj2) {
        if(!isByPrimitive(obj1) || ! isByPrimitive(obj2)){
            return false;
        }
        if(obj1 instanceof $Ku.by.Object.Decimal || obj2 instanceof $Ku.by.Object.Decimal){
            java.math.BigDecimal decimal1 = new java.math.BigDecimal(obj1.toString());
            java.math.BigDecimal decimal2 = new java.math.BigDecimal(obj2.toString());
            return decimal1.equals(decimal2);
        }
        if(obj1 instanceof Boolean || obj2 instanceof Boolean){
            return (boolean)obj1==(boolean)obj2;
        }
        if(obj1 instanceof Double || obj2 instanceof Double){
            obj1 = Double.valueOf(obj1.toString());
            obj2 = Double.valueOf(obj2.toString());
            return (double)obj1==(double)obj2;
        }

        if(obj1 instanceof Float || obj2 instanceof Float){
            obj1 = Float.valueOf(obj1.toString());
            obj2 = Float.valueOf(obj2.toString());
            return (float)obj1==(float)obj2;
        }

        if(obj1 instanceof Long || obj2 instanceof Long){
            obj1 = Long.valueOf(obj1.toString());
            obj2 = Long.valueOf(obj2.toString());
            return (long)obj1==(long)obj2;
        }
        if(obj1 instanceof Character){
            Character ch = (Character) obj1;
            obj1 = Integer.valueOf(ch);
        }
        if(obj2 instanceof Character){
            Character ch = (Character) obj2;
            obj2 = Integer.valueOf(ch);
        }
        obj1 = Integer.valueOf(obj1.toString());
        obj2 = Integer.valueOf(obj2.toString());
        return (int)obj1==(int)obj2;
    }

    public static $Ku.by.ToolClass.Sql.AbstractSelectField ConvertFieldNameToField(java.lang.String f_FieldName, $Ku.by.ToolClass.Sql.AbstractTable f_Table) {
        if (f_Table instanceof SelectTable)
        {
            throw new RuntimeException();
        }

        String[] tmpArray = f_FieldName.split("[.]", -1);
        ArrayList<AbstractSelectField> tmpCompared = new ArrayList<>();

        if (tmpArray.length == 1)
        {
            GetTableFieldInTableLength1(f_FieldName, f_Table, tmpCompared, true);
            if (tmpCompared.size() > 1)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_FieldName));
            }
        }

        if (tmpArray.length == 2)
        {
            String tmpAlias = tmpArray[0];
            if (!Objects.equals(tmpAlias, f_Table.getAlias()))
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_FieldName));
            }

            GetTableFieldInTableLength2(tmpAlias, tmpArray[1], f_Table, tmpCompared, true);
            if (tmpCompared.size() > 1)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_FieldName));
            }
        }
        if (tmpCompared.isEmpty())
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindColumn, f_FieldName));
        }

        return tmpCompared.get(0);
    }

    public static $Ku.by.ToolClass.IBaseDataSheet GetDataSheetOfRow($Ku.by.Object.Row f_Row) {
        if (f_Row == null || f_Row.getIdentity() == null)
        {
            return null;
        }

        $Ku.by.Identity.Table tmpIdentity = GetIdentityOfRow(f_Row);

        if (tmpIdentity.to == null)
        {
            return null;
        }

        return (IBaseDataSheet)tmpIdentity.to;
    }

    public static java.lang.String ValueInCollection(java.lang.String f_Value, Object f_List) {
        StringBuilder tmpValue = new StringBuilder();
        tmpValue.append(tmpValue);
        tmpValue.append(" in (");
        int tmpIndex = 0;
        Object[] tmpArray;
        if(f_List.getClass().isArray()){
            tmpArray = (Object[]) f_List;
        }
        else if(f_List instanceof $Ku.by.Object.List){
            $Ku.by.Object.List tmpList = ($Ku.by.Object.List) f_List;
            tmpArray = tmpList.toArray();
        }
        else{
            throw new RuntimeException("非数组类型或$Ku.by.Object.List类型，不支持" + f_List.getClass());
        }
        for(Object item : tmpArray){
            if(tmpIndex != 0){
                tmpValue.append(", ");
            }
            String tmpElement = item.toString();
            if(item instanceof String || item instanceof Character || item instanceof $Ku.by.Object.Datetime){
                tmpValue.append(SaveInspect.CharactorEscape(tmpElement));
            }
            else {
                tmpValue.append(tmpElement);
            }
            tmpIndex++;
        }
        tmpValue.append(")");
        return tmpValue.toString();
    }

    public static void AddPlusField($Ku.by.ToolClass.AbstractIdentityBase f_FieldIdentity, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_FieldList, $Ku.by.ToolClass.Sql.SqlTable f_Table, java.lang.String f_ComponentName) {
        if(f_FieldIdentity == null){
            return;
        }
        $Ku.by.Object.Field tmpField = ($Ku.by.Object.Field)f_FieldIdentity.getTo();
        if(tmpField == null){
            return;
        }
        f_FieldList.add(new $Ku.by.ToolClass.Sql.TableField(tmpField.Field, f_Table, null));
    }

    public static java.lang.String GetAllSheetNameInTables(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables) {
        ArrayList<String> tmpNames = new ArrayList<>();
        for(AbstractTable item : f_Tables){
            GetSheetNamesInTable(item, tmpNames);
        }

        StringBuilder tmpValue = new StringBuilder();
        for(int i = 0; i < tmpNames.size(); i++){
            if(i != 0){
                tmpValue.append(", ");
            }
            tmpValue.append(tmpNames.get(i));
        }
            
        return tmpValue.toString();
    }

    private static void GetSheetNamesInTable($Ku.by.ToolClass.Sql.AbstractTable f_Table, java.util.ArrayList<java.lang.String> f_Names) {
        if(f_Table instanceof $Ku.by.ToolClass.Sql.SqlTable){
            $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable)f_Table;
            String tmpQualifiedName = tmpTable.getKuName() + "." + tmpTable.getSourceName();
            if(!f_Names.contains(tmpQualifiedName)){
                f_Names.add(tmpQualifiedName);
            }

        }

        for(JoinTable item : f_Table.getJoinTables()){
            AbstractTable tmpAbstractTable = item.getJoinTable();
            GetSheetNamesInTable(tmpAbstractTable, f_Names);
        }
    }

    public static java.util.ArrayList<$Ku.by.Object.Row> CopyRows(java.lang.Iterable<$Ku.by.Object.Row> f_Rows) {
        java.util.ArrayList<$Ku.by.Object.Row> tmpNewRows = new java.util.ArrayList<$Ku.by.Object.Row>();
        for ($Ku.by.Object.Row item : f_Rows)
        {
            tmpNewRows.add(item.Copy());
        }
        return tmpNewRows;
    }

    public static java.util.ArrayList<$Ku.by.Object.Row> CopyRows($Ku.by.Object.Row[] f_Rows) {
        java.util.ArrayList<$Ku.by.Object.Row> tmpNewRows = new java.util.ArrayList<$Ku.by.Object.Row>();
        for ($Ku.by.Object.Row item : f_Rows)
        {
            tmpNewRows.add(item.Copy());
        }
        return tmpNewRows;
    }

    public static java.lang.String ConvertType(Object f_Value, $Ku.by.ToolClass.DataTypeEnum f_Type) {
        if (f_Value == null)
        {
            return "NULL";
        }
        switch (f_Type)
        {
            case Bool:
                if (!(f_Value instanceof Boolean))
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.IllegalBool1, f_Value.toString()));
                }
                if ("true".equals(f_Value.toString()))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            case String:
            case Enum:
            case Datetime:
            case Char:
                return SaveInspect.CharactorEscape(f_Value);
            default:
                return f_Value.toString();
        }
    }

    public static java.lang.String ConvertBoolInWhere(Object f_Value) {
        if (f_Value == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.SqlUnknownError);
        }
        if (f_Value instanceof Boolean)
        {
            boolean tmpValue = (Boolean) f_Value;
            if (tmpValue)
            {
                return "1 = 1";
            }
            else
            {
                return "0 = 1";
            }
        }

        return f_Value.toString();
    }

    public static java.lang.String IfEqualNull(Object f_Value) {
        if (f_Value == null)
        {
            return " is null";
        }
        else
        {
            return " = " + f_Value;
        }
    }

    public static $Ku.by.ToolClass.BaseKu GetKu(java.lang.String f_KuName) {
        return $Ku.by.ToolClass.Root.GetInstance().get(f_KuName);
    }

    public static $Ku.by.ToolClass.IBaseDataSheet GetDataSheet(java.lang.String f_KuName, java.lang.String f_SheetName) {
        return Root.GetInstance().get(f_KuName).DataSheetDic.get(f_SheetName);
    }

    public static $Ku.by.ToolClass.IBaseDataSheet GetDataSheet(java.lang.String f_QualifiedName) {
        if(f_QualifiedName == null){
            return null;
        }

        String[] tmpArray = f_QualifiedName.split("\\.");
        if(tmpArray.length != 2){
            $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotMatchingSource, f_QualifiedName));
        }

        String tmpKuName = tmpArray[0];
        String tmpSheetName = tmpArray[1];
        return $Ku.by.ToolClass.Root.GetInstance().KuDic.get(tmpKuName).get(tmpSheetName);
    }

    public static $Ku.by.ToolClass.Config GetConfigByIdentityName(java.lang.String f_KuName, java.lang.String f_IdentityName, java.lang.String f_ConfigName, java.lang.String f_SheetName) {
        $Ku.by.ToolClass.BaseKu tmpKu = GetKu(f_KuName);
        if (!tmpKu.ConfigDic.containsKey(f_IdentityName)) {
            return null;
            //$Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindConfigList, f_KuName, f_ConfigName));
        }
        Config tmpConfig = null;
        for ($Ku.by.ToolClass.Config item : tmpKu.ConfigDic.get(f_IdentityName)) {
            if (f_ConfigName.equals(item.getName()) && f_SheetName.equals(item.getSheetName())) {
                tmpConfig = item;
            }
        }
        return tmpConfig;
    }

    public static java.util.ArrayList<$Ku.by.ToolClass.Source> GetConfigList(java.lang.String f_KuName, $Ku.by.ToolClass.Config f_Config) {
        if(f_Config == null){
            return null;
        }
        $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = GetDataSheet(f_KuName, f_Config.getSheetName());
        if (!tmpDataSheet.getFlowDic().containsKey(f_Config.getFlowName()))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.getSheetName(), f_Config.getFlowName()));
        }
        return tmpDataSheet.getFlowDic().get(f_Config.getFlowName());
    }

    public static java.lang.String GetConfigIdentityByTable($Ku.by.ToolClass.Sql.SqlTable f_Table) {
        $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = f_Table.getSheet();
        return tmpDataSheet.getIdentityName();
    }

    public static $Ku.by.ToolClass.SheetRelation FindReferenceBetweenFieldAndSheet($Ku.by.ToolClass.BaseKu f_Ku, $Ku.by.ToolClass.Sql.SqlField f_Field, java.lang.String f_SheetName) {
        String tmpFieldSheetName = f_Field.getSheetName();

        if(!f_Ku.RelationDic.containsKey(tmpFieldSheetName) && !f_Ku.RelationDic.containsKey(f_SheetName)){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, tmpFieldSheetName, f_SheetName));
        }

        if(f_Ku.RelationDic.containsKey(tmpFieldSheetName)){
            for(SheetRelation item : f_Ku.RelationDic.get(tmpFieldSheetName)){
                if(item.ReferenceSheet.equals(tmpFieldSheetName) && item.ReferenceFieldName.equals(f_Field.getName())){
                    return item;
                }

                if(item.ReferencedSheet.equals(tmpFieldSheetName) && item.ReferencedFieldName.equals(f_Field.getName())){
                    return item;
                }
            }
        }

        if(f_Ku.RelationDic.containsKey(f_SheetName)){
            for(SheetRelation item : f_Ku.RelationDic.get(f_SheetName)){
                if(item.ReferenceSheet.equals(tmpFieldSheetName) && item.ReferenceFieldName.equals(f_Field.getName())){
                    return item;
                }
                if(item.ReferencedSheet.equals(tmpFieldSheetName) && item.ReferencedFieldName.equals(f_Field.getName())){
                    return item;
                }
            }
        }

        throw $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.TableNotReferenceField, f_Field.toString(), f_Ku.Name + "." + f_SheetName));
    }

    public static java.util.ArrayList<$Ku.by.ToolClass.SheetRelation> FindReferenceRelationBetweenSheet($Ku.by.ToolClass.BaseKu f_Ku, java.lang.String f_SheetName1, java.lang.String f_SheetName2) {
        java.util.ArrayList<$Ku.by.ToolClass.SheetRelation> tmpList = new java.util.ArrayList<>();
        if (!f_Ku.RelationDic.containsKey(f_SheetName1) && !f_Ku.RelationDic.containsKey(f_SheetName2))
        {
            //没有引用关系
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, f_SheetName1, f_SheetName2));
        }

        if (f_Ku.RelationDic.containsKey(f_SheetName1))
        {

            for ($Ku.by.ToolClass.SheetRelation item : f_Ku.RelationDic.get(f_SheetName1))
            {
                if (f_SheetName1.equals(item.ReferencedSheet))
                {
                    if (f_SheetName2.equals(item.ReferenceSheet))
                    {
                        tmpList.add(item);
                    }
                }

                if (f_SheetName2.equals(item.ReferencedSheet))
                {
                    if (f_SheetName1.equals(item.ReferenceSheet))
                    {
                        tmpList.add(item);
                    }
                }
            }
        }

        if (f_Ku.RelationDic.containsKey(f_SheetName2))
        {

            for ($Ku.by.ToolClass.SheetRelation item : f_Ku.RelationDic.get(f_SheetName2))
            {
                if (f_SheetName1.equals(item.ReferencedSheet))
                {
                    if (f_SheetName2.equals(item.ReferenceSheet))
                    {
                        tmpList.add(item);
                    }
                }

                if (f_SheetName2.equals(item.ReferencedSheet))
                {
                    if (f_SheetName1.equals(item.ReferenceSheet))
                    {
                        tmpList.add(item);
                    }
                }
            }
        }

        if (tmpList.isEmpty())
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, f_SheetName1, f_SheetName2));
        }

        if (tmpList.size() > 1)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, f_SheetName1, f_SheetName2));
        }

        return tmpList;
    }

    public static java.lang.String TableRelationEqualRow($Ku.by.ToolClass.Sql.SqlTable f_Table, $Ku.by.Object.Row f_Row, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_Table == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.TableIsNull);
        }
        StringBuilder tmpSqlExpression = new StringBuilder();
        if (f_Row == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowIsNull);
        }

        String tmpRowKuName = f_Row.getKuName();
        String tmpRowSheetName = f_Row.getSheetName();

        if (!f_Table.getKuName().equals(tmpRowKuName))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }

        $Ku.by.ToolClass.BaseKu tmpKu = GetKu(tmpRowKuName);
        java.util.ArrayList<$Ku.by.ToolClass.SheetRelation> tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, f_Table.getSourceName(), tmpRowSheetName);

        $Ku.by.ToolClass.SheetRelation tmpRelation = tmpRelations.get(0);
        StringBuilder tmpLeft = new StringBuilder();
        StringBuilder tmpRight = new StringBuilder();
        if (f_Table.getAlias() != null)
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(f_Table.getAlias()).append("].");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(f_Table.getAlias()).append("`.");
            }
            else{
                tmpLeft.append("\"").append(f_Table.getAlias()).append("\".");
            }
        }
        else
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(f_Table.getSourceName()).append("].");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(f_Table.getSourceName()).append("`.");
            }
            else{
                tmpLeft.append("\"").append(f_Table.getSourceName()).append("\".");
            }
        }

        if (Objects.equals(f_Table.getSourceName(), tmpRowSheetName))
        {
            //同表
            IBaseDataSheet tmpDataSheet = f_Table.GetSource();
            String tmpTableValue = tmpLeft.toString();

            for (int i = 0; i < tmpDataSheet.getPrimaryKeyList().size(); i++)
            {
                $Ku.by.ToolClass.Sql.SqlField tmpPrimaryKey = tmpDataSheet.getPrimaryKeyList().get(i);
                String tmpColumnName = tmpPrimaryKey.getName();
                $Ku.by.Object.Cell tmpCell = null;
                for ($Ku.by.Object.Cell cell : f_Row.cells){
                    if (cell.ColumnName == tmpColumnName){
                        tmpCell=cell;
                    }
                }
                if (tmpCell == null)
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CanNotFindRelationCellInRow);
                }

                if (i != 0)
                {
                    tmpSqlExpression.append(" and ");
                }

                tmpSqlExpression.append(tmpTableValue);
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpSqlExpression.append(String.format("[%s] = ", tmpColumnName));
                }
                else if(f_DBType == DBTypeEnum.Mysql)
                {
                    tmpSqlExpression.append(String.format("`%s` = ", tmpColumnName));
                }
                else{
                    tmpSqlExpression.append(String.format("%s = ", tmpColumnName));
                }

                Object tmpValue = tmpCell.value;

                if (tmpValue instanceof String || tmpValue instanceof Date || tmpValue instanceof Character || tmpValue instanceof $Ku.by.Object.Datetime || tmpValue.getClass().isEnum())
                {
                    tmpSqlExpression.append(SaveInspect.CharactorEscape(tmpValue));
                }
                else if (tmpValue instanceof Byte || tmpValue instanceof Short || tmpValue instanceof Integer || tmpValue instanceof Long || tmpValue instanceof Float || tmpValue instanceof Double || tmpValue instanceof $Ku.by.Object.Decimal)
                {
                    tmpSqlExpression.append(tmpValue);
                }
                    else if (tmpValue instanceof Boolean)
                {
                    boolean tmpBoolValue = (boolean)tmpValue;
                    tmpSqlExpression.append(tmpBoolValue ? 1 : 0);
                }
                    else
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                }
            }

            return tmpSqlExpression.toString();
        }
        boolean tmpRightIsReference = false;
        if (f_Table.getSourceName().equals(tmpRelation.ReferencedSheet))
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(tmpRelation.ReferencedFieldName).append("]");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(tmpRelation.ReferencedFieldName).append("`");
            }
            else{
                tmpLeft.append(tmpRelation.ReferencedFieldName);
            }
            tmpRightIsReference = true;
        }
        else
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(tmpRelation.ReferenceFieldName).append("]");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(tmpRelation.ReferenceFieldName).append("`");
            }
            else{
                tmpLeft.append(tmpRelation.ReferenceFieldName);
            }
        }
        tmpLeft.append(" = ");

        $Ku.by.Object.Cell tmpMeetConditionCell = null;
        if (tmpRightIsReference)
        {
            for ($Ku.by.Object.Cell ce: f_Row.cells)
            {
                if (ce.ColumnName.equals(tmpRelation.ReferenceFieldName))
                {
                    tmpMeetConditionCell = ce;
                }
            }
        }
        else
        {
             for ($Ku.by.Object.Cell ce: f_Row.cells)
            {
                if (ce.ColumnName.equals(tmpRelation.ReferencedFieldName))
                {
                    tmpMeetConditionCell = ce;
                }
            }
        }
        if (tmpMeetConditionCell == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.getSheetName()));
        }

        if (tmpMeetConditionCell.value == null)
        {
            tmpRight.append("null");
        }
        else
        {

            Object tmpValue = tmpMeetConditionCell.value;
            if (tmpValue instanceof String || tmpValue instanceof Character || tmpValue instanceof java.util.Date || tmpValue.getClass().isEnum())
            {
                tmpRight.append(SaveInspect.CharactorEscape(tmpValue));
            }
            else if (tmpValue instanceof Byte || tmpValue instanceof Short || tmpValue instanceof Integer || tmpValue instanceof Long || tmpValue instanceof Float || tmpValue instanceof Double || tmpValue instanceof java.math.BigDecimal)
            {
                tmpRight.append(tmpValue.toString());
            }
            else
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
            }   
        }
        tmpSqlExpression.append(tmpLeft);
        tmpSqlExpression.append(tmpRight);
        return tmpSqlExpression.toString();
    }

    public static java.lang.String TableRelationEqualQueryData($Ku.by.ToolClass.Sql.SqlTable f_Table, $Ku.by.Object.QueryData f_QueryData, java.lang.StringBuilder f_Having, int f_JoinTableCount, $Ku.by.ToolClass.DBTypeEnum f_DBType, $Ku.by.ToolClass.OutObject<java.lang.Integer> f_OutJoinTableCount) {
        if (f_Table == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.TableIsNull);
        }
        if (f_QueryData == null) {
            f_OutJoinTableCount.outArgValue = f_JoinTableCount;
            return " 1 = 1 ";
        }

        StringBuilder tmpWhereValue = new StringBuilder("( ");
        Hashtable<IBaseDataSheet, $Ku.by.ToolClass.Sql.SqlTable> tmpDic = new Hashtable<>();
        BaseKu tmpKu = GetKu(f_Table.getKuName());
        for (Map.Entry<Source, Object> item : f_QueryData._QueryDataParameter.getValueDic().entrySet()) {
            if (item.getValue() == null) {
                continue;
            }
            if (item.getValue() instanceof String) {
                String tmpStringValue = (String) item.getValue();
                if (Objects.equals(tmpStringValue, "")) {
                    continue;
                }
            }

            $Ku.by.ToolClass.Source tmpSource = item.getKey();
            if (tmpSource.IsRelation) {
                continue;
            }
            $Ku.by.ToolClass.Sql.SqlField tmpField = tmpSource.DataSheetField;
            IBaseDataSheet tmpFieldDataSheet = GetDataSheet(tmpField.getKuName(), tmpField.getSheetName());
            if (!tmpDic.containsKey(tmpFieldDataSheet) && tmpFieldDataSheet != f_Table.getSheet()) {
                String tmpJoinTableName = "#" + f_JoinTableCount++;

                $Ku.by.ToolClass.Sql.SqlTable tmpNewTable = new $Ku.by.ToolClass.Sql.SqlTable(tmpFieldDataSheet, tmpJoinTableName);
                tmpDic.put(tmpFieldDataSheet, tmpNewTable);
                JoinTable tmpJoinTable = new JoinTable(tmpNewTable);
                tmpJoinTable.setJoinMode(" left join ");
                f_Table.getJoinTables().add(tmpJoinTable);
                if (tmpKu.RelationDic.containsKey(f_Table.getSourceName())) {
                    ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(f_Table.getSourceName());
                    SheetRelation tmpMatched = null;
                    for (SheetRelation value : tmpRelations) {
                        if (Objects.equals(value.ReferencedSheet, tmpFieldDataSheet.getSheetName())) {
                            tmpMatched = value;
                            break;
                        }
                    }
                    if (tmpMatched == null) {
                        $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationInQueryArea, f_Table.getSourceName()));
                    }
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpJoinTable.privateCondition.append(" ON [").append(tmpMatched.ReferenceSheet).append("].[").append(tmpMatched.ReferenceFieldName).append("] = [").append(tmpNewTable.getAlias()).append("[.[").append(tmpMatched.ReferencedFieldName).append("]");
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpJoinTable.privateCondition.append(" ON `").append(tmpMatched.ReferenceSheet).append("`.`").append(tmpMatched.ReferenceFieldName).append("` = `").append(tmpNewTable.getAlias()).append("`.`").append(tmpMatched.ReferencedFieldName).append("`");
                    } else if (f_DBType == DBTypeEnum.Oracle) {
                        tmpJoinTable.privateCondition.append(" ON \"").append(tmpMatched.ReferenceSheet).append("\".\"").append(tmpMatched.ReferenceFieldName).append("\" = \"").append(tmpNewTable.getAlias()).append("\".\"").append(tmpMatched.ReferencedFieldName).append("\"");
                    }
                } else if (tmpKu.RelationDic.containsKey(tmpFieldDataSheet.getSheetName())) {
                    //当前table为被引用的表时
                    ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(tmpFieldDataSheet.getSheetName());

                    SheetRelation tmpMatched = null;
                    for (SheetRelation value : tmpRelations) {
                        if (value.ReferenceSheet == tmpFieldDataSheet.getSheetName()) {
                            tmpMatched = value;
                        }
                    }
                    if (tmpMatched == null) {
                        $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationInQueryArea, f_Table.getSourceName()));
                    }
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpJoinTable.privateCondition.append(" ON [").append(tmpMatched.ReferencedSheet).append("].[").append(tmpMatched.ReferencedFieldName).append("] = [").append(tmpNewTable.getAlias()).append("].[").append(tmpMatched.ReferenceFieldName).append("]");
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpJoinTable.privateCondition.append(" ON `").append(tmpMatched.ReferencedSheet).append("`.`").append(tmpMatched.ReferencedFieldName).append("` = `").append(tmpNewTable.getAlias()).append("`.`").append(tmpMatched.ReferenceFieldName).append("`");
                    } else if (f_DBType == DBTypeEnum.Oracle) {
                        tmpJoinTable.privateCondition.append(" ON \"").append(tmpMatched.ReferencedSheet).append("\".\"").append(tmpMatched.ReferencedFieldName).append("\" = \"").append(tmpNewTable.getAlias()).append("\".\"").append(tmpMatched.ReferenceFieldName).append("\"");
                    }
                } else {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationInQueryArea, f_Table.getSourceName()));
                }
            }

            $Ku.by.ToolClass.Sql.SqlTable tmpTable = null;
            if (tmpFieldDataSheet != f_Table.getSheet()) {
                tmpTable = tmpDic.get(tmpFieldDataSheet);
            } else {
                tmpTable = f_Table;
            }

            if (tmpSource.DataSheetField.getFunc() == FunctionEnum.NONE) {
                if (tmpWhereValue.length() != 2) {
                    tmpWhereValue.append(" AND ");
                }
                tmpWhereValue.append(GenerateQueryDataExpression(tmpTable, tmpSource, item.getValue()));
            } else {
                if (f_Having.length() == 0) {
                    f_Having.append(" HAVING ");
                }

                if (f_Having.length() != 8) {
                    f_Having.append(" AND ");
                }
                f_Having.append(GenerateQueryDataExpression(tmpTable, tmpSource, item.getValue()));
            }
        }
        if (tmpWhereValue.length() == 2) {
            tmpWhereValue.append("1 = 1");
        }
        tmpWhereValue.append(")");
        f_OutJoinTableCount.outArgValue = f_JoinTableCount;
        return tmpWhereValue.toString();
    }

    public static java.lang.String TableRelationInRows($Ku.by.ToolClass.Sql.SqlTable f_Table, $Ku.by.Object.List<$Ku.by.Object.Row> f_Rows, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        StringBuilder tmpSqlExpression = new StringBuilder();
        if (f_Rows == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
        }
        if (f_Rows.size() == 0)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsHasNoRow);
        }
        String tmpRowKuName = f_Rows.get(0).getKuName();
        String tmpRowSheetName = f_Rows.get(0).getSheetName();

        if (!f_Table.getKuName().equals(tmpRowKuName))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }

        $Ku.by.ToolClass.BaseKu tmpKu = GetKu(tmpRowKuName);
        StringBuilder tmpLeft = new StringBuilder();
        if (f_Table.getAlias() != null)
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.append("[").append(f_Table.getAlias()).append("].");
                }
                else if(f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.append("`").append(f_Table.getAlias()).append("`.");
                }
                else{
                    tmpLeft.append("\"").append(f_Table.getAlias()).append("\".");
                }
            }
            else
            {
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpLeft.append("[").append(f_Table.getSourceName()).append("].");
                }
                else if(f_DBType == DBTypeEnum.Mysql)
                {
                    tmpLeft.append("`").append(f_Table.getSourceName()).append("`.");
                }
                else{
                    tmpLeft.append("\"").append(f_Table.getSourceName()).append("\".");
                }
            }

        if (Objects.equals(f_Table.getSourceName(), tmpRowSheetName))
        {
            IBaseDataSheet tmpDataSheet = f_Table.GetSource();
            if (tmpDataSheet.getPrimaryKeyList().size() > 1)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.SeveralPKInRelationSheet);
            }

            $Ku.by.ToolClass.Sql.SqlField tmpPrimaryKey = tmpDataSheet.getPrimaryKeyList().get(0);
            String tmpColumnName = tmpPrimaryKey.getName();
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append(String.format("[%s] IN (", tmpColumnName));
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append(String.format("`%s` IN (", tmpColumnName));
            }
            else{
                tmpLeft.append(String.format("%s IN (", tmpColumnName));
            }

            tmpSqlExpression.append(tmpLeft);

            for (int i = 0; i < f_Rows.size(); i++)
            {
                $Ku.by.Object.Row row = f_Rows.get(i);
                if (row.getKuName() != tmpRowKuName || row.getSheetName() != tmpRowSheetName)
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.ExistRowFromDifferentSheet);
                }

                if (row == null)
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.HasNullRowInRows);
                }
                $Ku.by.Object.Cell tmpCell = null;
                for ($Ku.by.Object.Cell cell:row.cells){
                    if (Objects.equals(cell.ColumnName, tmpColumnName)){
                        tmpCell = cell;
                    }
                }
                if (tmpCell == null)
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, row.getSheetName()));
                }

                if (i != 0)
                {
                    tmpSqlExpression.append(", ");
                }

                Object tmpCellValue = tmpCell.value;

                if (tmpCellValue == null)
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RelationPKIsNull);
                }

                if (tmpCellValue instanceof Character || tmpCellValue instanceof String || tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue.getClass().isEnum())
                {
                    tmpSqlExpression.append(SaveInspect.CharactorEscape(tmpCellValue));
                }
                    else if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof Float || tmpCellValue instanceof Double
                            || tmpCellValue instanceof $Ku.by.Object.Decimal)
                {
                    tmpSqlExpression.append(tmpCellValue.toString());
                }
                    else if (tmpCellValue instanceof Boolean)
                {
                    boolean tmpBoolValue = (boolean)tmpCellValue;
                    tmpSqlExpression.append(tmpBoolValue ? 1 : 0);
                }
                    else
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                }
            }
            tmpSqlExpression.append(") ");
            return tmpSqlExpression.toString();
        }

        ArrayList<SheetRelation> tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, f_Table.getSourceName(), tmpRowSheetName);
        SheetRelation tmpRelation = tmpRelations.get(0);
        StringBuilder tmpRight = new StringBuilder("( ");
        boolean tmpRightIsReference = false;
        $Ku.by.ToolClass.Sql.SqlField tmpField;
        String tmpKuName = f_Table.getKuName();
        if (f_Table.getSourceName() == tmpRelation.ReferencedSheet)
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(tmpRelation.ReferencedFieldName).append("]");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(tmpRelation.ReferencedFieldName).append("`");
            }
            else{
                tmpLeft.append(tmpRelation.ReferencedFieldName);
            }

            IBaseDataSheet tmpDataSheet = GetDataSheet(tmpKuName, tmpRelation.ReferencedSheet);
            if (!tmpDataSheet.getFieldDic().containsKey(tmpRelation.ReferencedFieldName)){
                $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindFieldInSheet, tmpRelation.ReferencedSheet, tmpRelation.ReferencedFieldName));
            }
            tmpField = tmpDataSheet.getFieldDic().get(tmpRelation.ReferencedFieldName);
            tmpRightIsReference = true;
        }
        else
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(tmpRelation.ReferenceFieldName).append("]");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(tmpRelation.ReferenceFieldName).append("`");
            }
            else
            {
                tmpLeft.append(tmpRelation.ReferenceFieldName);
            }

            IBaseDataSheet tmpDataSheet = GetDataSheet(tmpKuName, tmpRelation.ReferenceSheet);
            if(!tmpDataSheet.getFieldDic().containsKey(tmpRelation.ReferenceFieldName)){
                $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindFieldInSheet, tmpRelation.ReferenceSheet, tmpRelation.ReferenceFieldName));
            }
            tmpField = tmpDataSheet.getFieldDic().get(tmpRelation.ReferenceFieldName);
        }
        tmpLeft.append(" IN ");
        for ($Ku.by.Object.Row item : f_Rows)
        {
            if (!Objects.equals(item.getKuName(), tmpRowKuName) || !Objects.equals(item.getSheetName(), tmpRowSheetName))
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.ExistRowFromDifferentSheet);
            }

            if (tmpRight.length() != 2)
            {
                tmpRight.append(", ");
            }

            $Ku.by.Object.Cell tmpMatchedCell = null;
            if (tmpRightIsReference)
            {
                for ($Ku.by.Object.Cell cell:item.cells){
                    if(Objects.equals(cell.ColumnName, tmpRelation.ReferenceFieldName) && Objects.equals(cell.SheetName, item.getSheetName())){
                        tmpMatchedCell = cell;
                    }
                }
            }
            else
            {
                for ($Ku.by.Object.Cell cell:item.cells){
                    if(Objects.equals(cell.ColumnName, tmpRelation.ReferencedFieldName) && Objects.equals(cell.SheetName, item.getSheetName())){
                        tmpMatchedCell = cell;
                    }
                }
            }
            if (tmpMatchedCell == null)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, item.getSheetName()));
            }

            Object tmpCellValue = tmpMatchedCell.value;
            if (tmpCellValue == null)
            {
                tmpRight.append(CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType));
            }
                else if (tmpCellValue instanceof Character || tmpCellValue instanceof String || tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue.getClass().isEnum())
            {
                tmpRight.append(SaveInspect.CharactorEscape(tmpCellValue));
            }
                else if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof Float || tmpCellValue instanceof Double
                        || tmpCellValue instanceof $Ku.by.Object.Decimal)
            {
                tmpRight.append(tmpCellValue.toString());
            }
                else if (tmpCellValue instanceof Boolean)
            {
                boolean tmpBoolValue = (boolean)tmpCellValue;
                tmpRight.append(tmpBoolValue ? 1 : 0);
            }
                else
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
            }
        }
        tmpRight.append(" )");
        tmpSqlExpression.append(tmpLeft);
        tmpSqlExpression.append(tmpRight);
        return tmpSqlExpression.toString();
    }

    public static java.lang.String FieldRelationInRows($Ku.by.ToolClass.Sql.AbstractSelectField f_AbstractField, $Ku.by.Object.List<$Ku.by.Object.Row> f_Rows, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        TableField tmpField = (TableField)((f_AbstractField instanceof TableField) ? f_AbstractField : null);
        StringBuilder tmpSqlExpression = new StringBuilder();

        if (f_Rows == null)
        {
            return "1 = 0";
        }

        if (f_Rows.size()==0)
        {
            return "1 = 0";
        }

        StringBuilder tmpLeft = new StringBuilder();
        StringBuilder tmpRight = new StringBuilder("(");
        $Ku.by.ToolClass.Sql.SqlTable tmpFieldTable = null;
        if (tmpField != null) {
            tmpFieldTable = ($Ku.by.ToolClass.Sql.SqlTable)((tmpField.getFieldTable() instanceof $Ku.by.ToolClass.Sql.SqlTable) ? tmpField.getFieldTable() : null);
        }

        if (tmpFieldTable != null && tmpFieldTable.getAlias() != null) {
            tmpLeft.append(tmpFieldTable.getAlias()).append(".");
        }
        else
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                if (tmpFieldTable != null) {
                    tmpLeft.append("[").append(tmpFieldTable.getSourceName()).append("].");
                }
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                if (tmpFieldTable != null) {
                    tmpLeft.append("`").append(tmpFieldTable.getSourceName()).append("`.");
                }
            }
            else{
                if (tmpFieldTable != null) {
                    tmpLeft.append(tmpFieldTable.getSourceName()).append(".");
                }
            }
        }
        if (tmpField != null) {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(tmpField.getSelectedField().getName()).append("]");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(tmpField.getSelectedField().getName()).append("`");
            }
            else{
                tmpLeft.append(tmpField.getSelectedField().getName());
            }

        }
        tmpLeft.append(" in ");
        for ($Ku.by.Object.Row item : f_Rows) {
            if (item == null)
            {
                continue;
            }

            $Ku.by.Object.Cell tmpCell = null;
            if (tmpField.getSelectedField().ReferenceField == null)
            {
                for ($Ku.by.Object.Cell cell:item.cells){
                    if (cell.field() != null && cell.field().Field == tmpField.getSelectedField()){
                        tmpCell = cell;
                        break;
                    }
                }
            }
            else
            {
                for ($Ku.by.Object.Cell cell:item.cells){
                    if (cell.field() != null && (cell.field().Field == tmpField.getSelectedField() || cell.field().Field.ReferenceField == tmpField.getSelectedField())){
                        tmpCell = cell;
                        break;
                    }
                }
            }

            if (tmpCell == null)
            {
                continue;
            }
            else
            {
                if (tmpRight.length() != 2)
                {
                    tmpRight.append(", ");
                }

                Object tmpCellValue = tmpCell.value;
                if (tmpCellValue == null)
                {
                    tmpRight.append(CellValueNullToDefaultReturnString(tmpField.FieldType, tmpField.EnumType, f_DBType));
                }
                    else if (tmpCellValue instanceof Character || tmpCellValue instanceof String || tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue.getClass().isEnum())
                {
                    tmpRight.append(SaveInspect.CharactorEscape(tmpCellValue));
                }
                    else if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof Float || tmpCellValue instanceof Double
                        || tmpCellValue instanceof $Ku.by.Object.Decimal)
                {
                    tmpRight.append(tmpCellValue);
                }
                    else if (tmpCellValue instanceof Boolean)
                {
                    boolean tmpBoolValue = (boolean)tmpCellValue;
                    tmpRight.append(tmpBoolValue ? 1 : 0);
                }
                    else
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
                }
            }
        }

        tmpRight.append(") ");
        if (tmpRight.length() == 4)
        {
            return "1 = 0";
        }
        tmpSqlExpression.append(tmpLeft);
        tmpSqlExpression.append(tmpRight);
        return tmpSqlExpression.toString();
    }

    public static void FillFrom(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList, java.lang.StringBuilder f_From, java.lang.Boolean f_Lock) {
        if (f_TableList.isEmpty()) {
            return;
        }

        f_From.append(" FROM ");
        String tmpKuName = f_TableList.get(0).GetIdentity().ku;

        for (int i = 0; i < f_TableList.size(); i++) {
            AbstractTable tmpTable = f_TableList.get(i);

            if (tmpTable.getIsOuterTable()) {
                continue;
            }

            if (tmpTable.GetSource().getIsConst()) {
                ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.SelectConstSheet, tmpTable.GetSource().toString()));
            }

            if (i != 0) {
                f_From.append(", ");
            }

            f_From.append(TableToCode(tmpTable, tmpKuName, f_Lock));
        }
    }

    private static $Ku.by.ToolClass.Sql.AbstractSelectField FindFieldInAsterFieldReturnNull(java.lang.String f_Component, $Ku.by.ToolClass.Sql.AsteriskField f_AsterField, java.lang.Boolean f_IsComponent) {
        String[] tmpArray = f_Component.split("[.]", -1);

        for (AbstractSelectField item : f_AsterField.getFieldList())
        {
            if (item instanceof TableField)
            {

                TableField tmpTableField = (TableField) item;
                String tmpFieldName = null;
                if (tmpArray.length == 2)
                {
                    tmpFieldName = tmpArray[1];
                }
                $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = GetDataSheet(tmpTableField.getSelectedField().getKuName(), tmpTableField.getSelectedField().getSheetName());
                if (f_IsComponent){
                    if (tmpDataSheet.getComponentDic().containsKey(tmpFieldName))
                    {
                        return item;
                    }
                }
                else {
                    if (tmpDataSheet.getFieldDic().containsKey(tmpFieldName))
                    {
                        return item;
                    }
                }
            }
            if (item instanceof  SelectField){
                SelectField tmpSelectField = (SelectField)item;
                if (Objects.equals(item.getAlias(), f_Component))
                {
                    return item;
                }

                if(item.getAlias() == null && Objects.equals(tmpSelectField.Name, f_Component))
                {
                    return item;
                }
            }
            if (item instanceof AsteriskField)
            {
                return FindFieldInAsterFieldReturnNull(f_Component, (AsteriskField)item,f_IsComponent);
            }

            if (item instanceof PlusField)
            {
                return FindFieldInPlusFieldReturnNull(f_Component, (PlusField)item);
            }
        }
        return null;
    }

    private static $Ku.by.ToolClass.Sql.AbstractSelectField FindFieldInPlusFieldReturnNull(java.lang.String f_Component, $Ku.by.ToolClass.Sql.PlusField f_PlusField) {
        String[] tmpArray = f_Component.split("[.]", -1);
        AbstractTable tempVar = f_PlusField.getFieldTable();

        $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable)((tempVar instanceof $Ku.by.ToolClass.Sql.SqlTable) ? tempVar : null);

        IBaseDataSheet tmpDataSheet = null;
        if (tmpTable != null) {
            tmpDataSheet = tmpTable.getSheet();
        }
        if (tmpArray.length != 1 && tmpArray.length != 2)
        {
            return null;
        }

        String tmpFieldName;

        if (tmpArray.length == 2)
        {
            if (tmpTable.getAlias() != tmpTable.getAlias())
            {
                return null;
            }

            String tmpComponentName = tmpArray[1];
            if (!tmpDataSheet.getComponentDic().containsKey(tmpComponentName))
            {
                return null;
            }
            else
            {
                tmpFieldName = tmpDataSheet.getComponentDic().get(tmpComponentName).getName();
            }
        }
        else
        {
            String tmpComponentName = tmpArray[0];
            if (!tmpDataSheet.getComponentDic().containsKey(tmpComponentName))
            {
                return null;
            }
            else
            {
                tmpFieldName = tmpDataSheet.getComponentDic().get(tmpComponentName).getName();
            }
        }

        for (AbstractSelectField item : f_PlusField.getFieldList())
        {
            TableField tmpTableField = (TableField)item;
            if (tmpTableField.getSelectedField().getName() == tmpFieldName)
            {
                return item;
            }
        }
        return null;
    }

    public static $Ku.by.ToolClass.Sql.SqlField ConvertComponentToField(java.lang.String f_Component, $Ku.by.ToolClass.IBaseDataSheet f_DataSheet) {
        if (f_DataSheet == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.TableIsNull);
        }

        $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = f_DataSheet;
        if (!tmpDataSheet.getComponentDic().containsKey(f_Component))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet, f_Component));
        }

        return tmpDataSheet.getComponentDic().get(f_Component);
    }

    public static $Ku.by.ToolClass.Sql.TableField ConvertComponentToTableField(java.lang.String f_Component, $Ku.by.ToolClass.Sql.SqlTable f_Table) {
        $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = f_Table.getSheet();
        $Ku.by.ToolClass.Sql.SqlField tmpField = null;
        if (!((tmpField = tmpDataSheet.getComponentDic().get(f_Component)) != null))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.getSheetName(), f_Component));
        }
        return new TableField(tmpField, f_Table, null);
    }

    public static $Ku.by.ToolClass.Sql.AbstractSelectField ConvertComponentToTableField(java.lang.String f_Component, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList) {
        String[] tmpArray = f_Component.split("[.]", -1);
        java.util.ArrayList<AbstractSelectField> tmpCompared = new java.util.ArrayList<>();
        if (tmpArray.length == 1) {
            for (AbstractTable item : f_TableList) {
                GetTableFieldInTableLength1(f_Component, item, tmpCompared, true);
                if (tmpCompared.size() > 1) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_Component));
                }
            }
        }

        if (tmpArray.length == 2) {
            String tmpTableSourceAlias = tmpArray[0];
            String tmpFieldAlias = tmpArray[1];

            for (AbstractTable item : f_TableList) {
                if (!tmpTableSourceAlias.equals(item.getAlias())) {
                    continue;
                }

                GetTableFieldInTableLength2(tmpTableSourceAlias, tmpFieldAlias, item, tmpCompared, true);
                if (tmpCompared.size() > 1) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_Component));
                }
            }
        }

        if (tmpCompared.isEmpty()) {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindColumn, f_Component));
        }

        return tmpCompared.get(0);
    }

    public static $Ku.by.ToolClass.Sql.AbstractSelectField ConvertFieldNameToField(java.lang.String f_FieldName, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables) {
        String[] tmpArray = f_FieldName.split("[.]", -1);
        java.util.ArrayList<AbstractSelectField> tmpCompared = new java.util.ArrayList<AbstractSelectField>();
        if (tmpArray.length == 1)
        {
            for (AbstractTable item : f_Tables)
            {
                GetTableFieldInTableLength1(f_FieldName, item, tmpCompared, true);
                if (tmpCompared.size() > 1)
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_FieldName));
                }
            }
        }

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

                GetTableFieldInTableLength2(tmpTableSourceAlias, tmpFieldAlias, item, tmpCompared, true);
                if (tmpCompared.size() > 1)
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_FieldName));
                }
            }
        }

        if (tmpCompared.isEmpty())
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindColumn, f_FieldName));
        }

        return tmpCompared.get(0);
    }

    public static void GetTableFieldInTableLength1(java.lang.String f_Component, $Ku.by.ToolClass.Sql.AbstractTable f_Table, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_FieldList, java.lang.Boolean f_IsComponent) {
        if (f_Table instanceof $Ku.by.ToolClass.Sql.SqlTable)
        {
            //不能有别名
            $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable) f_Table;
            $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = tmpTable.getSheet();
            if (tmpDataSheet == null)
            {
                return;
            }

            if (tmpDataSheet.getComponentDic().containsKey(f_Component))
            {
                f_FieldList.add(new TableField(tmpDataSheet.getComponentDic().get(f_Component), tmpTable, null));
            }
        }
        else
        {

            SelectTable tmpSelectTable = (SelectTable)((f_Table instanceof SelectTable) ? f_Table : null);

            if (tmpSelectTable != null) {
                for (AbstractSelectField item : tmpSelectTable.getResultItems())
                {
                    if (f_Component.equals(item.getAlias()))
                    {
                        SelectField tmpSelectField = new SelectField(f_Component, item, tmpSelectTable);
                        tmpSelectField.FieldType = item.FieldType;
                        f_FieldList.add(tmpSelectField);
                        continue;
                    }
                    if (item instanceof AsteriskField)
                    {
                        AsteriskField tmpAsterField = (AsteriskField)item;
                        AbstractSelectField tmpField = FindFieldInAsterFieldReturnNull(f_Component, tmpAsterField, f_IsComponent);
                        if (tmpField == null)
                        {
                            continue;
                        }

                        //只有两种可能
                        String tmpName = null;
                        if (tmpField instanceof TableField)
                        {
                            TableField tmpMatchedField = (TableField)tmpField;
                            tmpName = tmpMatchedField.getSelectedField().getName();
                        }
                        else if (tmpField instanceof SelectField)
                        {
                            SelectField tmpSelectField = (SelectField)tmpField;
                            tmpName = tmpSelectField.Name;
                        }
                        else
                        {
                            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ColumnWithoutAlias);
                        }

                        SelectField tmpNewSelectField = new SelectField(tmpName, item, tmpSelectTable);
                        tmpNewSelectField.FieldType = item.FieldType;
                        f_FieldList.add(tmpNewSelectField);
                        continue;
                    }
                    TableField tmpTableField = (TableField)((item instanceof TableField) ? item : null);
                    if (tmpTableField == null)
                    {
                        continue;
                    }

                    $Ku.by.ToolClass.Sql.SqlTable tmpFieldTable = ($Ku.by.ToolClass.Sql.SqlTable)((tmpTableField.getFieldTable() instanceof $Ku.by.ToolClass.Sql.SqlTable) ? tmpTableField.getFieldTable() : null);
                    if (tmpFieldTable == null)
                    {
                        continue;
                    }

                    IBaseDataSheet tmpDataSheet = tmpFieldTable.getSheet();
                    if (tmpDataSheet == null)
                    {
                        continue;
                    }
                    if (!tmpDataSheet.getComponentDic().containsKey(f_Component) && !tmpDataSheet.getFieldDic().containsKey(f_Component))
                    {
                        continue;
                    }
                    if (tmpDataSheet.getComponentDic().containsKey(f_Component) && tmpTableField.getSelectedField() == tmpDataSheet.getComponentDic().get(f_Component))
                    {
                        SelectField tmpNewField = new SelectField(tmpTableField.getSelectedField().getName(), tmpTableField, tmpSelectTable);
                        tmpNewField.FieldType = tmpTableField.FieldType;
                        f_FieldList.add(tmpNewField);
                    }

                    if (tmpDataSheet.getFieldDic().containsKey(f_Component) && tmpTableField.getSelectedField() == tmpDataSheet.getFieldDic().get(f_Component))
                    {
                        SelectField tmpNewField = new SelectField(tmpTableField.getSelectedField().getName(), tmpTableField, tmpSelectTable);
                        tmpNewField.FieldType = tmpTableField.FieldType;
                        f_FieldList.add(tmpNewField);
                    }
                }
            }
        }
    }

    public static void GetTableFieldInTableLength2(java.lang.String f_Sheet, java.lang.String f_Column, $Ku.by.ToolClass.Sql.AbstractTable f_Table, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_FieldList, java.lang.Boolean f_IsComponent) {
        if (!f_Table.getAlias().equals(f_Sheet))
        {
            return;
        }
        if (f_Table instanceof $Ku.by.ToolClass.Sql.SqlTable)
        {

            $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable) f_Table;
            IBaseDataSheet tmpDataSheet = tmpTable.getSheet();
            if (f_IsComponent) {
                if (!tmpDataSheet.getComponentDic().containsKey(f_Column)) {
                    return;
                }
                f_FieldList.add(new TableField(tmpDataSheet.getComponentDic().get(f_Column), tmpTable, null));
            }
            else
            {
                if (!tmpDataSheet.getFieldDic().containsKey(f_Column))
                {
                    return;
                }
                f_FieldList.add(new TableField(tmpDataSheet.getFieldDic().get(f_Column), tmpTable, null));
            }
        }
        else
        {
            SelectTable tmpSelectTable = (SelectTable)((f_Table instanceof SelectTable) ? f_Table : null);

            if (tmpSelectTable != null) {
                for (AbstractSelectField item : tmpSelectTable.getResultItems())
                {
                    //先找别名再找列
                    if (f_Column.equals(item.getAlias()))
                    {
                        SelectField tmpSelectField = new SelectField(f_Column, item, tmpSelectTable);
                        tmpSelectField.FieldType = item.FieldType;
                        f_FieldList.add(tmpSelectField);
                        continue;
                    }

                    if (item instanceof AsteriskField)
                    {
                        AbstractSelectField tmpField = FindFieldInAsterFieldReturnNull(f_Column, (AsteriskField)item, true);
                        if (tmpField == null)
                        {
                            continue;
                        }
                        //只有两种可能
                        String tmpName = null;
                        if (tmpField instanceof TableField)
                        {
                            tmpName = ((TableField)tmpField).getSelectedField().getName();
                        }
                        else if (tmpField instanceof SelectField)
                        {
                            tmpName = ((SelectField)tmpField).Name;
                        }
                        else
                        {
                            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ColumnWithoutAlias);
                        }

                        SelectField tmpNewSelectField = new SelectField(tmpName, item, tmpSelectTable);
                        tmpNewSelectField.FieldType = item.FieldType;
                        f_FieldList.add(tmpNewSelectField);
                        continue;
                    }
                    TableField tmpTableField = (TableField)((item instanceof TableField) ? item : null);
                    if (tmpTableField == null)
                    {
                        continue;
                    }

                    $Ku.by.ToolClass.Sql.SqlTable tmpFieldTable = ($Ku.by.ToolClass.Sql.SqlTable)((tmpTableField.getFieldTable() instanceof $Ku.by.ToolClass.Sql.SqlTable) ? tmpTableField.getFieldTable() : null);
                    if (tmpFieldTable == null)
                    {
                        continue;
                    }

                    IBaseDataSheet tmpDataSheet = tmpFieldTable.getSheet();
                    if (tmpDataSheet == null)
                    {
                        continue;
                    }
                    if (!tmpDataSheet.getComponentDic().containsKey(f_Column) && !tmpDataSheet.getFieldDic().containsKey(f_Column))
                    {
                        continue;
                    }

                    if (tmpDataSheet.getComponentDic().containsKey(f_Column) && tmpTableField.getSelectedField() == tmpDataSheet.getComponentDic().get(f_Column))
                    {
                        SelectField tmpNewField = new SelectField(tmpTableField.getSelectedField().getName(), tmpTableField, tmpSelectTable);
                        tmpNewField.FieldType = tmpTableField.FieldType;
                        f_FieldList.add(tmpNewField);
                    }

                    if(tmpDataSheet.getFieldDic().containsKey(f_Column) && tmpTableField.getSelectedField() == tmpDataSheet.getFieldDic().get(f_Column))
                    {
                        SelectField tmpNewField = new SelectField(tmpTableField.getSelectedField().getName(), tmpTableField, tmpSelectTable);
                        tmpNewField.FieldType = tmpTableField.FieldType;
                        f_FieldList.add(tmpNewField);
                    }
                }
            }
        }
    }

    public static java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> GetAsteriskOfTable($Ku.by.ToolClass.Sql.AbstractTable f_Table, java.lang.Boolean f_ContainsJoin) {
        if (f_Table == null) {
            throw new RuntimeException("空的表源项");
        }
        java.util.ArrayList<AbstractSelectField> tmpFieldList = new java.util.ArrayList<>();
        if (f_Table instanceof $Ku.by.ToolClass.Sql.SqlTable) {

            $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable) f_Table;

            for (Map.Entry<String, $Ku.by.ToolClass.Sql.SqlField> item : tmpTable.getSheet().getFieldDic().entrySet()) {
                tmpFieldList.add(new TableField(item.getValue(), tmpTable, null));
            }
        } else {

            SelectTable tmpTable = (SelectTable) ((f_Table instanceof SelectTable) ? f_Table : null);

            if (tmpTable != null) {
                for (AbstractSelectField item : tmpTable.getResultItems()) {
                    if (item instanceof IFields) {

                        IFields tmpField = (IFields) item;
                        for (AbstractSelectField selectItem : tmpField.getFieldList()) {
                            if (selectItem.getAlias() == null) {
                                //只可能是表字段
                                TableField tmpTableField = (TableField) selectItem;
                                tmpFieldList.add(new SelectField(tmpTableField.getSelectedField().getName(), selectItem, tmpTable));
                            } else {
                                tmpFieldList.add(new SelectField(selectItem.getAlias(), selectItem, tmpTable));
                            }
                        }
                    } else {
                        String tmpName = null;
                        if (item.getAlias() != null) {
                            tmpName = item.getAlias();
                        } else {
                            if (item instanceof TableField) {
                                TableField tmpTableField = (TableField) item;
                                tmpName = tmpTableField.getSelectedField().getName();
                            } else if (item instanceof SelectField) {
                                SelectField tmpSelectField = (SelectField) item;
                                tmpName = tmpSelectField.Name;
                            } else {
                                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ColumnWithoutAlias);
                            }
                        }
                        tmpFieldList.add(new SelectField(tmpName, item, tmpTable));
                    }
                }
            }
        }

        if (f_ContainsJoin) {
            if (f_Table.getJoinTables() != null) {

                for (JoinTable item : f_Table.getJoinTables()) {
                    tmpFieldList.addAll(GetAsteriskOfTable(item.getJoinTable(), f_ContainsJoin));
                }
            }
        }

        return tmpFieldList;
    }

    public static $Ku.by.ToolClass.Sql.AsteriskField GetAsteriskField(java.lang.String f_Asterisk, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList) {
        java.util.ArrayList<AbstractSelectField> tmpTableFieldList = new java.util.ArrayList<AbstractSelectField>();
        String[] tmpArray = f_Asterisk.split("[.]", -1);
        AbstractTable tmpAsteriskTable = null;
        if (tmpArray.length == 1) {
            for (AbstractTable table : f_TableList) {
                tmpTableFieldList.addAll(GetAsteriskOfTable(table, true));
            }
        }
        if (tmpArray.length == 2) {
            String tmpAlias = tmpArray[0];
            AbstractTable tmpComparedTable = null;
            for (AbstractTable item : f_TableList) {
                if (tmpAlias.equals(item.getAlias())) {
                    tmpComparedTable = item;
                    break;
                }
            }
            if (tmpComparedTable == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindSourceSheetWithAlias, tmpAlias));
            }

            tmpTableFieldList.addAll(GetAsteriskOfTable(tmpComparedTable, false));
            tmpAsteriskTable = tmpComparedTable;
        }
        return new AsteriskField(tmpTableFieldList, tmpAsteriskTable);
    }

    public static java.lang.String GenerateQueryField($Ku.by.ToolClass.Sql.SqlTable f_Table, $Ku.by.ToolClass.Sql.SqlField f_Field) {
        String tmpKuName = f_Table.getKuName();
        DBTypeEnum tmpDBType = Root.GetInstance().KuTypeDic.get(tmpKuName);
        StringBuilder tmpFieldValue = new StringBuilder();
        if (f_Table.getAlias() != null) {
            if (tmpDBType == DBTypeEnum.SqlServer) {
                tmpFieldValue.append("[").append(f_Table.getAlias()).append("].");
            } else if (tmpDBType == DBTypeEnum.Mysql) {
                tmpFieldValue.append("`").append(f_Table.getAlias()).append("`.");
            } else {
                tmpFieldValue.append("\"").append(f_Table.getAlias()).append("\".");
            }
        }
        if (tmpDBType == DBTypeEnum.SqlServer) {
            tmpFieldValue.append("[").append(f_Field.getName()).append("]");
        } else if (tmpDBType == DBTypeEnum.Mysql) {
            tmpFieldValue.append("`").append(f_Field.getName()).append("`");
        } else {
            tmpFieldValue.append("\"").append(f_Field.getName()).append("\"");
        }
        if (f_Field.getFunc() == FunctionEnum.NONE) {
            return tmpFieldValue.toString();
        }
        return String.format("%1$s(%2$s)", f_Field.getFunc(), tmpFieldValue);
    }

    public static void Replace(java.util.ArrayList<$Ku.by.Object.Cell> f_Cells, $Ku.by.Object.Row f_Referenced, java.util.LinkedHashMap<java.lang.String, java.lang.String> referenceDic) {
        if (referenceDic.isEmpty())
        {
            return;
        }


        for ($Ku.by.Object.Cell item : f_Referenced.cells)
        {
            String tmpReferenceColName = item.SheetName + "." + item.ColumnName;
            $Ku.by.Object.Cell tmpCell =null;
            if (referenceDic.containsKey(tmpReferenceColName))
            {
                String tmpColuName = referenceDic.get(tmpReferenceColName);
                for ($Ku.by.Object.Cell element:f_Cells){
                    if (tmpColuName.equals(element.ColumnName)){
                        tmpCell = element;
                        break;
                    }
                }
                //var tmpCell = f_Cells.Find(element => tmpColuName.equals(element.ColumnName));
                tmpCell.value = item.value;
            }
        }
    }

    public static java.lang.String GenerateQueryDataExpression($Ku.by.ToolClass.Sql.SqlTable f_Table, $Ku.by.ToolClass.Source f_Source, Object f_Value) {
        //like left, like both, like right, between, >, <, >=, <=, =, !=
        //值为null前面跳过了
        StringBuilder tmpExpression = new StringBuilder();
        if (f_Value == null) {
            return null;
        }
        String tmpOperator = f_Source.Operator.toLowerCase();
        if (f_Value instanceof java.util.ArrayList && !"between".equals(tmpOperator)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.QueryAreaParameterError);
        }
        if (!"between".equals(tmpOperator)) {
            tmpExpression.append(GenerateQueryField(f_Table, f_Source.DataSheetField)).append(" ");

        }
        String tmpValue = f_Value.toString();
        if (f_Value instanceof String || f_Value instanceof Character) {
            tmpValue = SaveInspect.CheckSingleQuotes(tmpValue);
        }

        if ("likeleft".equals(tmpOperator)) {
            tmpExpression.append(String.format("like '%1$s%%'", tmpValue));
        }
        else if ("likeright".equals(tmpOperator)) {
            tmpExpression.append(String.format("like '%%%1$s'", tmpValue));
            //%xx
        }
        else if ("likeboth".equals(tmpOperator)) {
            //%xxx%
            tmpExpression.append(String.format("like '%%%1$s%%'", tmpValue));
        }
        else if ("between".equals(tmpOperator)) {
            ArrayList<String> tmpArrayValue = (java.util.ArrayList<String>) ((f_Value instanceof java.util.ArrayList) ? f_Value : null);
            if (tmpArrayValue == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.QueryAreaParameterError);
            }
            if (tmpArrayValue.size() != 2) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.QueryAreaParameterError);
            }
            String tmpGreaterThan = tmpArrayValue.get(0);
            String tmpSmallerThan = tmpArrayValue.get(1);
            if (tmpGreaterThan == null || tmpSmallerThan == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.QueryAreaParameterError);
            }
            tmpExpression.append(String.format("( %1$s >= '%2$s' and %1$s <= '%3$s' )", GenerateQueryField(f_Table, f_Source.DataSheetField), tmpGreaterThan, tmpSmallerThan));
        }
        else if ("greater".equals(tmpOperator)) {
            tmpExpression.append(String.format("> '%1$s'", tmpValue));
        }
        else if ("greaterthanorequal".equals(tmpOperator)) {
            tmpExpression.append(String.format(">= '%1$s'", tmpValue));
        }
        else if ("equal".equals(tmpOperator)) {
            tmpExpression.append(String.format("= '%1$s'", tmpValue));
        }
        else if ("lessthanorequal".equals(tmpOperator)) {
            tmpExpression.append(String.format("<= '%1$s'", tmpValue));
        }
        else if ("less".equals(tmpOperator)) {
            tmpExpression.append(String.format("< '%1$s'", tmpValue));
        }
        else if ("notequal".equals(tmpOperator)) {
            tmpExpression.append(String.format("!= '%1$s'", tmpValue));
        } else {
            throw $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.UnKnownQueryDataParameter);
        }
        return tmpExpression.toString();
    }

    public static java.util.LinkedHashMap<$Ku.by.ToolClass.Sql.SqlField, Object> GetNewInsertValues() {
        return new java.util.LinkedHashMap<$Ku.by.ToolClass.Sql.SqlField, Object>();
    }

    public static void FillInsertValues(java.util.HashMap<$Ku.by.ToolClass.Sql.SqlField, Object> f_InsertValues, Object f_Parameter, java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> f_FieldList, $Ku.by.ToolClass.Sql.SqlTable f_Table) {
        java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> tmpFieldList = new java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField>();

        if (f_FieldList.isEmpty())
        {

            for (Map.Entry<String, $Ku.by.ToolClass.Sql.SqlField> item : f_Table.getSheet().getFieldDic().entrySet())
            {
                tmpFieldList.add(item.getValue());
            }
        }
        else
        {
            tmpFieldList = f_FieldList;
        }
        //参数只能为行或者行集合
        if (f_Parameter instanceof $Ku.by.Object.Row)
        {

            $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row)((f_Parameter instanceof $Ku.by.Object.Row) ? f_Parameter : null);


            for ($Ku.by.ToolClass.Sql.SqlField item : tmpFieldList)
            {

                $Ku.by.Object.Cell tmpValue = null;
                for ($Ku.by.Object.Cell value:tmpRow.cells){
                    if (Objects.equals(value.ColumnName, item.getName())){
                        tmpValue = value;
                    }
                }
                //var tmpValue = tmpRow.cells.Find(value => value.ColumnName == item.getName()).value;
                //有则报错，没有则填
                if (f_InsertValues.containsKey(item))
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.HasRepetitiveField, item.getName()));
                    //f_InsertValues[item] = tmpValue;
                }
                else
                {
                    f_InsertValues.put(item, tmpValue);
                }
            }

            return;
        }
        //存储的值行数要相同
        if (f_Parameter instanceof $Ku.by.Object.List)
        {

            $Ku.by.Object.List<$Ku.by.Object.Row> tmpRowList = ($Ku.by.Object.List<$Ku.by.Object.Row>)((f_Parameter instanceof $Ku.by.Object.List) ? f_Parameter : null);

            for ($Ku.by.ToolClass.Sql.SqlField item : tmpFieldList)
            {
                $Ku.by.Object.List<Object> tmpObjectList = FindCellValuesInRows(item, tmpRowList);
                if (f_InsertValues.containsKey(item))
                {
                    //字段重复就报错
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.HasRepetitiveField, item.getName()));
                    //var tmpValue = f_InsertValues[item] as List<object>;
                    //if (tmpValue == null)
                    //{
                    //    throw new RuntimeException();
                    //}
                    //if (tmpValue.Count != tmpObjectList.Count)
                    //{
                    //    throw new RuntimeException();
                    //}
                    //f_InsertValues[item] = tmpObjectList;
                }
                else
                {
                    f_InsertValues.put(item, tmpObjectList);
                }
            }
            return;
        }

        if (f_Parameter instanceof $Ku.by.Object.Row[])
        {

            $Ku.by.Object.Row[] tmpRows = ($Ku.by.Object.Row[])((f_Parameter instanceof $Ku.by.Object.Row[]) ? f_Parameter : null);
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpRowList = new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class));

            for ($Ku.by.ToolClass.Sql.SqlField item : tmpFieldList)
            {
                $Ku.by.Object.List<Object> tmpObjectList = FindCellValuesInRows(item, tmpRowList);
                if (f_InsertValues.containsKey(item))
                {
                    //字段重复就报错
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.HasRepetitiveField, item.getName()));
                }
                else
                {
                    f_InsertValues.put(item, tmpObjectList);
                }
            }
            return;
        }

        $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.IllegalRowParameter);
    }

    public static void SupplementEnumType(java.util.HashMap<$Ku.by.ToolClass.Sql.SqlField, Object> f_InsertValues, $Ku.by.ToolClass.IBaseDataSheet f_DataSheet) {
        for (Map.Entry<String, $Ku.by.ToolClass.Sql.SqlField> field : f_DataSheet.getFieldDic().entrySet())
        {

            $Ku.by.ToolClass.Sql.SqlField tmpField = field.getValue();
            if (tmpField.getFieldType() != DataTypeEnum.Enum)
            {
                continue;
            }
            if (f_InsertValues.containsKey(tmpField))
            {
                continue;
            }
            f_InsertValues.put(tmpField, null);
        }
    }

    public static java.lang.String GenerateSqlByInsertValues(java.util.LinkedHashMap<$Ku.by.ToolClass.Sql.SqlField, Object> f_InsertValues, $Ku.by.ToolClass.IBaseDataSheet f_DataSheet, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if(f_InsertValues == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.InsertValueIsNull);
        }

        if(f_InsertValues.size() == 0){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.InsertValueHasNoValue);
        }

        StringBuilder tmpSql = new StringBuilder();

        if(f_DBType == DBTypeEnum.SqlServer){
            tmpSql.append("INSERT INTO [" + f_DataSheet.getSheetName() + "] ");
        }
        else if(f_DBType == DBTypeEnum.Mysql){
            tmpSql.append("INSERT INTO `" + f_DataSheet.getSheetName() + "` ");
        }
        else{
            tmpSql.append("INSERT INTO " + f_DataSheet.getSheetName() + " ");
        }

        Map.Entry<$Ku.by.ToolClass.Sql.SqlField, Object> tmpFirst = f_InsertValues.entrySet().iterator().next();

        Object tmpFirstValue = tmpFirst.getValue();
        StringBuilder tmpFieldsStringBuilder = new StringBuilder("(");
        StringBuilder tmpValuesStringBuilder = new StringBuilder(" VALUES");

        boolean tmpIsRowList = false;

        for(Map.Entry<String, $Ku.by.ToolClass.Sql.SqlField> item : f_DataSheet.getFieldDic().entrySet()){
            $Ku.by.ToolClass.Sql.SqlField tmpField = item.getValue();

            if(tmpFieldsStringBuilder.length() != 1){
                tmpFieldsStringBuilder.append(", ");
            }

            if(f_DBType == DBTypeEnum.SqlServer){
                tmpFieldsStringBuilder.append("[" + item.getKey() + "]");
            }
            else if(f_DBType == DBTypeEnum.Mysql){
                tmpFieldsStringBuilder.append("`" + item.getKey() + "`");
            }
            else{
                tmpFieldsStringBuilder.append(item.getKey());
            }
            if(tmpFirstValue instanceof $Ku.by.Object.List){
                $Ku.by.Object.List<Object> tmpStandard = ($Ku.by.Object.List<Object>) tmpFirstValue;
                int tmpSandardCount = tmpStandard.count();
                tmpIsRowList = true;

                if(!f_InsertValues.containsKey(tmpField)){
                    $Ku.by.Object.List<Object> tmpObjList = new $Ku.by.Object.List<>();
                    f_InsertValues.put(tmpField, tmpObjList);
                    for(int j = 0; j < tmpSandardCount; j++){
                        tmpObjList.add(CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType));
                    }
                }

            }
            else{
                if(tmpIsRowList){
                    $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("insert语句待插入值填充错误");
                }

                if(!f_InsertValues.containsKey(tmpField)){
                    f_InsertValues.put(tmpField, CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType));
                }

            }

        }

        tmpFieldsStringBuilder.append(")");

        if(tmpIsRowList){
            $Ku.by.Object.List<Object> tmpFirstValues = ($Ku.by.Object.List<Object>) f_InsertValues.entrySet().iterator().next().getValue();
            int tmpFirstValueCount = tmpFirstValues.count();

            for(int i = 0; i < tmpFirstValueCount; i++){
                if(i != 0){
                    tmpValuesStringBuilder.append(", ");
                }

                StringBuilder tmpPerRowValue = new StringBuilder("(");

                for(Map.Entry<String, $Ku.by.ToolClass.Sql.SqlField> item : f_DataSheet.getFieldDic().entrySet()){
                    if(tmpValuesStringBuilder.length() != 1){
                        tmpPerRowValue.append(", ");
                    }
                    $Ku.by.Object.List<Object> tmpValues = ($Ku.by.Object.List<Object>) f_InsertValues.get(item.getValue());
                    tmpValuesStringBuilder.append(tmpValues.get(i).toString());
                }

                tmpPerRowValue.append(")");
                tmpValuesStringBuilder.append(tmpPerRowValue.toString() + "\r\n");
            }
        }
        else{
            tmpValuesStringBuilder.append("(");
            int count = 0;
            for(Map.Entry<String, $Ku.by.ToolClass.Sql.SqlField> item : f_DataSheet.getFieldDic().entrySet()){
                if(count != 0){
                    tmpValuesStringBuilder.append(", ");
                }
                tmpValuesStringBuilder.append(f_InsertValues.get(item.getValue()).toString());
                count++;
            }
            tmpValuesStringBuilder.append(")");
        }

        tmpSql.append(tmpFieldsStringBuilder);
        tmpSql.append(tmpValuesStringBuilder);

        if(f_DBType == DBTypeEnum.Mysql || f_DBType == DBTypeEnum.Oracle){
            tmpSql.append(";");
        }

        tmpSql.append("\r\n");
        return tmpSql.toString();
    }

    public static java.util.ArrayList<java.lang.String> MatchPkList(java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> f_PKList, Object f_Row, java.lang.String f_SheetName) {
        if (f_PKList.isEmpty())
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindPKInSheet, f_SheetName));
        }
        java.util.ArrayList<String> tmpPKValueList = new java.util.ArrayList<String>();
        if (f_Row instanceof $Ku.by.Object.Row)
        {

            $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row)((f_Row instanceof $Ku.by.Object.Row) ? f_Row : null);
            tmpPKValueList.add(AddRowInPKList(f_PKList, tmpRow));
            return tmpPKValueList;
        }


        ArrayList<$Ku.by.Object.Row> tmpRows = (java.util.ArrayList<$Ku.by.Object.Row>)((f_Row instanceof java.util.ArrayList) ? f_Row : null);
        if (tmpRows == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIsNull);
        }


        for ($Ku.by.Object.Row row : tmpRows)
        {
            tmpPKValueList.add(AddRowInPKList(f_PKList, row));
        }
        return tmpPKValueList;
    }

    public static java.lang.String AddRowInPKList(java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> f_PKList, $Ku.by.Object.Row f_Value) {
        StringBuilder tmpValue = new StringBuilder();
        for (int i = 0; i < f_PKList.size(); i++)
        {

            $Ku.by.ToolClass.Sql.SqlField tmpPK = f_PKList.get(i);

            $Ku.by.Object.Cell tmpCell = null;
            for ($Ku.by.Object.Cell item:f_Value.cells){
                if (Objects.equals(item.ColumnName, tmpPK.getName())){
                    tmpCell = item;
                    break;
                }
            }
            //var tmpCell = f_Value.cells.Find(item => item.ColumnName == tmpPK.getName());
            if (tmpCell == null)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindCellInRow, tmpPK.getName()));
            }
            tmpValue.append("[").append(tmpPK.getName()).append("] ");
            if (tmpCell.value == null)
            {
                tmpValue.append("is null");
            }
            else
            {
                tmpValue.append("'").append(tmpCell.value.toString()).append("'");
            }
            if (i != f_PKList.size() - 1)
            {
                tmpValue.append(" and ");
            }
        }
        return tmpValue.toString();
    }

    public static $Ku.by.Object.List<Object> FindCellValuesInRows($Ku.by.ToolClass.Sql.SqlField f_Field, $Ku.by.Object.List<$Ku.by.Object.Row> f_Rows) {
        $Ku.by.Object.List<Object> tmpList = new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get(Object.class));

        for ($Ku.by.Object.Row item : f_Rows)
        {
            $Ku.by.Object.Cell tmpCell = null;
            for ($Ku.by.Object.Cell field:item.cells){
                if (f_Field.getName().equals(field.ColumnName)){
                    tmpCell = field;
                }
            }
            //var tmpCell = item.cells.Find(field => f_Field.getName().equals(field.ColumnName));
            if (tmpCell == null)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindCellInRow, f_Field.getName()));
            }
            tmpList.add(tmpCell.value);
        }
        return tmpList;
    }

    private static java.lang.String FillPkOfWhere($Ku.by.ToolClass.IBaseDataSheet f_DataSheet, $Ku.by.Object.Row f_Row, java.lang.StringBuilder f_Where, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        //null或者同表检查放在调用的地方
        ArrayList<$Ku.by.ToolClass.Sql.SqlField> tmpPkList = f_DataSheet.getPrimaryKeyList();
        if (tmpPkList == null || tmpPkList.isEmpty())
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindPKInSheet, f_DataSheet.getSheetName()));
        }


        if (f_Where.length() == 0) {
            f_Where.append(" where ");
        }

        StringBuilder tmpNewWhere = new StringBuilder(f_Where.toString());
        if (tmpNewWhere.length() != 7) {
            tmpNewWhere.append("and (");
        } else {
            tmpNewWhere.append("(");
        }

        for (int i = 0; i < tmpPkList.size(); i++) {

            $Ku.by.ToolClass.Sql.SqlField tmpPkField = tmpPkList.get(i);
            if (i != 0) {
                tmpNewWhere.append(" and ");
            }
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpNewWhere.append(String.format("[%1$s].[%2$s] = ", tmpPkField.getSheetName(), tmpPkField.getName()));
                }
                else if(f_DBType == DBTypeEnum.Mysql)
                {
                    tmpNewWhere.append(String.format("`%s`.`%s` = ", tmpPkField.getSheetName(), tmpPkField.getName()));
                }
                else
                {
                    tmpNewWhere.append(String.format("\"%s\".\"%s\" = ", tmpPkField.getSheetName(), tmpPkField.getName()));
                }

            $Ku.by.Object.Cell tmpPkCell = null;
            for ($Ku.by.Object.Cell cell : f_Row.cells) {
                if (Objects.equals(cell.ColumnName, tmpPkField.getName())) {
                    tmpPkCell = cell;
                }
            }
            if (tmpPkCell == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.RowHasRepetitiveField, tmpPkField.getName()));
            }


            Object tmpPkCellValue = tmpPkCell.value;
            if (tmpPkCellValue == null) {
                tmpNewWhere.append("null");
                continue;
            }

            if (tmpPkCellValue instanceof String || tmpPkCellValue instanceof Character || tmpPkCellValue instanceof $Ku.by.Object.Datetime || tmpPkCellValue.getClass().isEnum()) {
                if (f_DBType == DBTypeEnum.Oracle && tmpPkCell.DataTypeEnum.equals(DataTypeEnum.Datetime)) {
                    tmpNewWhere.append("TO_TIMESTAMP(").append(SaveInspect.CharactorEscape(tmpPkCellValue)).append(", 'YYYY-MM-DD HH24:MI:SS.FF')");
                } else {
                    tmpNewWhere.append(SaveInspect.CharactorEscape(tmpPkCellValue));
                }
                continue;
            }

            if (tmpPkCellValue instanceof Byte || tmpPkCellValue instanceof Short || tmpPkCellValue instanceof Integer || tmpPkCellValue instanceof Long || tmpPkCellValue instanceof Float || tmpPkCellValue instanceof Double || tmpPkCellValue instanceof java.math.BigDecimal) {
                tmpNewWhere.append(tmpPkCellValue.toString());
                continue;
            }

            if (tmpPkCellValue instanceof Boolean)
            {
                Boolean tmpBoolValue = (Boolean)tmpPkCellValue;
                tmpNewWhere.append(tmpBoolValue ? 1 : 0);
                continue;
            }
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
        }
        tmpNewWhere.append(")");
        return tmpNewWhere.toString();
    }

    public static java.lang.String FillUpdateRow($Ku.by.Object.Row f_Row, java.util.ArrayList<$Ku.by.ToolClass.Sql.SetField> f_SetList, java.lang.StringBuilder f_Where, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        StringBuilder tmpSql = new StringBuilder();

        if (f_Row == null || f_Row.$Identity == null) {
            return null;
        }

        $Ku.by.Identity.Table tmpIdentity = GetIdentityOfRow(f_Row);

        if (tmpIdentity.to == null) {
            return null;
        }

        IBaseDataSheet tmpDataSheet = (IBaseDataSheet) tmpIdentity.to;

        if (f_DBType == DBTypeEnum.SqlServer) {
            tmpSql.append(String.format("UPDATE [%s] ", tmpDataSheet.getSheetName()));
        } else if (f_DBType == DBTypeEnum.Mysql) {
            tmpSql.append(String.format("UPDATE `%s` ", tmpDataSheet.getSheetName()));
        } else {
            tmpSql.append(String.format("UPDATE \"%s\".\"%s\" ", tmpDataSheet.getKuName(), tmpDataSheet.getSheetName()));
        }

        if (!f_SetList.isEmpty()) {
            tmpSql.append("set ");
            for (int i = 0; i < f_SetList.size(); i++) {
                if (i != 0) {
                    tmpSql.append(", ");
                }

                SetField tmpSetField = f_SetList.get(i);
                $Ku.by.ToolClass.Sql.SqlField tmpField = ConvertComponentToField(tmpSetField.ComponentName, tmpDataSheet);

                $Ku.by.Object.Cell tmpCell = null;
                for ($Ku.by.Object.Cell cell : f_Row.cells) {
                    if (Objects.equals(cell.ColumnName, tmpField.getName())) {
                        tmpCell = cell;
                    }
                }

                if (tmpCell == null) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.RowHasRepetitiveField, tmpField.getName()));
                }

                Object tmpCellValue = null;
                Boolean tmpCellValueHasSet = false;

                if (Objects.equals(tmpSetField.Operator, "~")) {
                    UpdateSetValue tmpUpdateSetField = FieldRelationAssignmentRow(tmpSetField.Field, f_Row);
                    tmpCellValue = tmpUpdateSetField.getValue();
                    tmpCellValueHasSet = true;
                }
                if (!tmpCellValueHasSet) {
                    tmpCellValue = tmpCell.value;
                }

                if (tmpCellValue == null) {
                    tmpCellValue = CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType);
                } else if (tmpCellValue instanceof Character || tmpCellValue instanceof String || tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue.getClass().isEnum()) {
                    if (f_DBType == DBTypeEnum.Oracle && tmpCell.DataTypeEnum.equals(DataTypeEnum.Datetime)) {
                        tmpCellValue = "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCell.value.toString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')";
                    } else {
                        tmpCellValue = SaveInspect.CharactorEscape(tmpCellValue.toString());
                    }
                } else if (tmpCell.value instanceof Byte || tmpCell.value instanceof Short || tmpCell.value instanceof Integer || tmpCell.value instanceof Long || tmpCell.value instanceof Float || tmpCell.value instanceof Double || tmpCell.value instanceof $Ku.by.Object.Decimal) {
                    tmpCellValue = tmpCellValue.toString();
                } else if (tmpCell.value instanceof Boolean) {
                    boolean tmpBoolValue = (boolean) tmpCell.value;
                    tmpSql.append(tmpBoolValue ? 1 : 0);
                } else {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
                }

                if (f_DBType == DBTypeEnum.SqlServer) {
                    String tmpFieldName = "[" + tmpDataSheet.getSheetName() + "].[" + tmpField.getName() + "]";
                    if (Objects.equals(tmpSetField.Operator, "=") || Objects.equals(tmpSetField.Operator, "~")) {
                        tmpSql.append(String.format("%s = %s", tmpFieldName, tmpCellValue));
                    } else {
                        tmpSql.append(String.format("%s %s= %s", tmpFieldName, tmpSetField.Operator, tmpCellValue));
                    }
                } else if (f_DBType == DBTypeEnum.Mysql) {
                    String tmpFieldName = "`" + tmpDataSheet.getSheetName() + "`.`" + tmpField.getName() + "`";
                    if (Objects.equals(tmpSetField.Operator, "=") || Objects.equals(tmpSetField.Operator, "~")) {
                        tmpSql.append(String.format("%s = %s", tmpFieldName, tmpCellValue));
                    } else {
                        tmpSql.append(String.format("%1$s = %1$s %2$s %3$s", tmpFieldName, tmpSetField.Operator, tmpCellValue));
                    }
                } else {
                    String tmpFieldName = "\"" + tmpDataSheet.getSheetName() + "\".\"" + tmpField.getName() + "\"";

                    if (Objects.equals(tmpSetField.Operator, "%")) {
                        tmpSql.append(String.format("%1$s = MOD(%1$s, %2$s)", tmpFieldName, tmpCellValue));
                    } else if (Objects.equals(tmpSetField.Operator, "&")) {
                        tmpSql.append(String.format("%1$s = BITAND(%1$s, %2$s)", tmpFieldName, tmpCellValue));
                    } else if (Objects.equals(tmpSetField.Operator, "|")) {
                        tmpSql.append(String.format("%1$s = %1$s + (%2$s) - BITAND(%1$s, %2$s)", tmpFieldName, tmpCellValue));
                    } else if (Objects.equals(tmpSetField.Operator, "^")) {
                        tmpSql.append(String.format("%1$s = %1$s + (%2$s) - 2 * BITAND(%1$s, %2$s)", tmpFieldName, tmpCellValue));
                    } else if (Objects.equals(tmpSetField.Operator, "~") || tmpSetField.Operator == "=") {
                        tmpSql.append(String.format("%1$s = %2$s", tmpFieldName, tmpCellValue));
                    } else {
                        tmpSql.append(String.format("%1$s = %1$s %2$s %3$s ", tmpField, tmpSetField.Operator, tmpCellValue));
                    }
                }
            }
        } else {
            //根据行内容填充set
            java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> tmpPkList = tmpDataSheet.getPrimaryKeyList();
            if (tmpPkList == null || tmpPkList.isEmpty()) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindPKInSheet, tmpDataSheet.getSheetName()));
            }
            int tmpSetCount = 0;
            tmpSql.append("set ");
            for (int i = 0; i < f_Row.cells.size(); i++) {
                $Ku.by.Object.Cell tmpCell = f_Row.cells.get(i);
                if (!tmpDataSheet.getSheetName().equals(tmpCell.SheetName)) {
                    continue;
                }
                $Ku.by.ToolClass.Sql.SqlField tmpField = null;
                for ($Ku.by.ToolClass.Sql.SqlField field : tmpPkList) {
                    if (Objects.equals(field.getName(), tmpCell.ColumnName)) {
                        tmpField = field;
                        break;
                    }
                }
                if (tmpPkList.contains(tmpField)) {
                    continue;
                }
                if (tmpSetCount != 0) {
                    tmpSql.append(", ");
                }
                tmpSetCount++;
                tmpField = tmpDataSheet.getFieldDic().get(tmpCell.ColumnName);
                if (tmpCell.value == null) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("[%s].[%s] = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType)));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("`%s`.`%s` = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType)));
                    } else {
                        tmpSql.append(String.format("\"%s\".\"%s\" = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType)));
                    }
                    continue;
                }

                if (tmpCell.value instanceof Byte || tmpCell.value instanceof Short || tmpCell.value instanceof Integer || tmpCell.value instanceof Long || tmpCell.value instanceof Float || tmpCell.value instanceof Double || tmpCell.value instanceof Decimal) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("[%s].[%s] = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, tmpCell.value.toString()));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("`%s`.`%s` = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, tmpCell.value.toString()));
                    } else {
                        tmpSql.append(String.format("\"%s\".\"%s\" = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, tmpCell.value.toString()));
                    }

                    continue;
                }

                if (tmpCell.value instanceof String || tmpCell.value instanceof Character || tmpCell.value instanceof $Ku.by.Object.Datetime || tmpCell.value.getClass().isEnum()) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("[%s].[%s] = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, SaveInspect.CharactorEscape(tmpCell.value.toString())));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("`%s`.`%s` = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, SaveInspect.CharactorEscape(tmpCell.value.toString())));
                    } else {
                        if (f_DBType == DBTypeEnum.Oracle && tmpCell.DataTypeEnum.equals(DataTypeEnum.Datetime)) {
                            tmpSql.append(String.format("\"%s\".\"%s\" = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCell.value.toString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')"));
                        } else {
                            tmpSql.append(String.format("\"%s\".\"%s\" = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, SaveInspect.CharactorEscape(tmpCell.value.toString())));
                        }
                    }

                    continue;
                }

                if (tmpCell.value instanceof Boolean) {
                    boolean tmpBoolValue = (boolean) tmpCell.value;
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("[%s].[%s] = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, tmpBoolValue ? 1 : 0));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("`%s`.`%s` = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, tmpBoolValue ? 1 : 0));
                    } else {
                        tmpSql.append(String.format("\"%s\".\"%s\" = %s", tmpDataSheet.getSheetName(), tmpCell.ColumnName, tmpBoolValue ? 1 : 0));
                    }

                    continue;
                }

                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
            }
        }

        tmpSql.append(FillPkOfWhere(tmpDataSheet, f_Row, f_Where, f_DBType));
        if (f_DBType != DBTypeEnum.SqlServer) {
            tmpSql.append(";");
        }
        tmpSql.append("\r\n");
        return tmpSql.toString();
    }

    public static $Ku.by.ToolClass.Sql.UpdateSetValue FieldRelationAssignmentRow($Ku.by.ToolClass.Sql.SqlField f_Field, $Ku.by.Object.Row f_Row) {
        //先判断字段和行对应的表是否存在关系
        if (!Objects.equals(f_Field.getKuName(), f_Row.getKuName())) {
            ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }

        if (Objects.equals(f_Field.getSheetName(), f_Row.getSheetName())) {
            Cell tmpMatchedCell = null;
            for (Cell item : f_Row.cells) {
                if (Objects.equals(item.ColumnName, f_Field.getName())) {
                    tmpMatchedCell = item;
                    break;
                }
            }
            if (tmpMatchedCell == null) {
                ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.getSheetName()));
            }
            return new UpdateSetValue(f_Field, tmpMatchedCell.value, " = ");
        } else {
            //先判断是否存在关系
            BaseKu tmpKu = GetKu(f_Field.getKuName());
            ArrayList<SheetRelation> tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, f_Field.getSheetName(), f_Row.getSheetName());
            SheetRelation tmpRelation = tmpRelations.get(0);

            if (!Objects.equals(f_Field.getSheetName(), tmpRelation.ReferencedSheet) && !Objects.equals(f_Field.getSheetName(), tmpRelation.ReferenceSheet)) {
                ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Field.getSheetName(), f_Row.getSheetName()));
            }

            if (Objects.equals(f_Field.getSheetName(), tmpRelation.ReferencedSheet) && Objects.equals(f_Row.getSheetName(), tmpRelation.ReferenceSheet)) {
                if (!Objects.equals(f_Field.getName(), tmpRelation.ReferencedFieldName)) {
                    ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.TableNotReferenceField, f_Field.getName(), tmpRelation.ReferencedSheet));
                }
                Cell tmpMatchedCell = null;
                for (Cell item : f_Row.cells) {
                    if (Objects.equals(item.ColumnName, tmpRelation.ReferenceFieldName)) {
                        tmpMatchedCell = item;
                        break;
                    }
                }
                if (tmpMatchedCell == null) {
                    ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.getSheetName()));
                }
                return new UpdateSetValue(f_Field, tmpMatchedCell.value, " = ");
            }

            if (Objects.equals(f_Field.getSheetName(), tmpRelation.ReferenceSheet) && Objects.equals(f_Row.getSheetName(), tmpRelation.ReferencedSheet)) {
                if (f_Field.getName() != tmpRelation.ReferenceFieldName) {
                    ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.TableNotReferenceField, f_Field.getName(), tmpRelation.ReferenceSheet));
                }
                Cell tmpMatchedCell = null;
                for (Cell item : f_Row.cells) {
                    if (Objects.equals(item.ColumnName, tmpRelation.ReferencedFieldName)) {
                        tmpMatchedCell = item;
                        break;
                    }
                }
                if (tmpMatchedCell == null) {
                    ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.getSheetName()));
                }

                return new UpdateSetValue(f_Field, tmpMatchedCell.value, " = ");
            }
        }
        throw ThrowHelper.ThrowRelationOperationException(ErrorInfo.NoRelationBetweenSheetsOrReferenceColumn);
    }

    public static java.lang.String UpdateRowListOrRow(Object f_RowParameter, java.lang.StringBuilder f_Where, java.lang.String f_EffectedVariable, java.util.ArrayList<$Ku.by.ToolClass.Sql.SetField> f_SetList, boolean f_InTran, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_RowParameter == null || f_SetList == null) {
            if (f_InTran) {
                if (f_DBType == DBTypeEnum.SqlServer) {
                    return String.format("SET @%s = 0\r\n", f_EffectedVariable);
                } else if (f_DBType == DBTypeEnum.Mysql) {
                    return String.format("SET $%s = 0;\r\n", f_EffectedVariable);
                } else {
                    return String.format("SET $%s = 0;\r\n", f_EffectedVariable);
                }
            }
        }

        StringBuilder tmpSql = new StringBuilder();

        if (f_RowParameter instanceof $Ku.by.Object.Row) {
            $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row) f_RowParameter;
            String tmpUpdateSql = FillUpdateRow(tmpRow, f_SetList, f_Where, f_DBType);

            if (tmpUpdateSql == null || tmpUpdateSql.isEmpty()) {
                if (f_InTran) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedVariable));
                    } else {
                        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedVariable));
                    }
                }
            } else {
                tmpSql.append(tmpUpdateSql);

                if (f_InTran) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("SET @%s = @@ROWCOUNT", f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("SET $%s = ROW_COUNT();", f_EffectedVariable));
                    } else {
                        tmpSql.append("SET $" + f_EffectedVariable + " = SQL%ROWCOUNT;");
                    }
                }
            }
        } else if (f_RowParameter instanceof $Ku.by.Object.Row[] || f_RowParameter instanceof Iterable) {
            ArrayList<$Ku.by.Object.Row> tmpRowList = new ArrayList<>();
            if (f_RowParameter instanceof $Ku.by.Object.Row[]) {
                $Ku.by.Object.Row[] rows = ($Ku.by.Object.Row[]) f_RowParameter;
                tmpRowList.addAll(Arrays.asList(rows));
            } else {
                Iterable<$Ku.by.Object.Row> rows = (Iterable) f_RowParameter;
                for ($Ku.by.Object.Row row : rows) {
                    tmpRowList.add(row);
                }
            }
            if (f_InTran) {
                if (f_DBType == DBTypeEnum.SqlServer) {
                    tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectedVariable));
                } else if (f_DBType == DBTypeEnum.Mysql) {
                    tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedVariable));
                } else {
                    tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedVariable));
                }
            }
            for ($Ku.by.Object.Row row : tmpRowList) {
                String tmpUpdateSql = FillUpdateRow(row, f_SetList, f_Where, f_DBType);

                if (tmpUpdateSql == null || tmpUpdateSql.isEmpty()) {
                    continue;
                }

                tmpSql.append(tmpUpdateSql);
                if (f_InTran) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("SET @%s = @%s+@@ROWCOUNT", f_EffectedVariable, f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("SET $%s = $%s+ROW_COUNT();", f_EffectedVariable, f_EffectedVariable));
                    } else {
                        tmpSql.append("SET $" + f_EffectedVariable + " = $" + f_EffectedVariable + "+SQL%ROWCOUNT;");
                    }
                }
            }

        } else {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.IllegalRowParameter);
        }

        return tmpSql.toString();
    }

    private static java.lang.String FillInsertRow($Ku.by.Object.Row f_Row, java.util.ArrayList<java.lang.String> f_InsertColumns, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_Row == null || f_Row.getIdentity() == null) {
            return null;
        }

        $Ku.by.Identity.Table tmpIdentity = GetIdentityOfRow(f_Row);

        if (tmpIdentity.to == null) {
            return null;
        }

        IBaseDataSheet tmpDataSheet = (IBaseDataSheet) tmpIdentity.to;

        StringBuilder tmpSql = new StringBuilder("INSERT INTO ");
        StringBuilder tmpValues = new StringBuilder(" VALUES(");
        if (f_DBType == DBTypeEnum.SqlServer) {
            tmpSql.append(String.format("[%s] (", tmpDataSheet.getSheetName()));
        } else if (f_DBType == DBTypeEnum.Mysql) {
            tmpSql.append(String.format("`%s` (", tmpDataSheet.getSheetName()));
        } else if (f_DBType == DBTypeEnum.Oracle) {
            tmpSql.append(String.format("\"%s\".\"%s\" (", f_Row.getKuName(), tmpDataSheet.getSheetName()));
        }

        int counter = 0;
        for (Map.Entry<String, $Ku.by.ToolClass.Sql.SqlField> entry : tmpDataSheet.getFieldDic().entrySet()) {
            if (counter != 0) {
                tmpSql.append(", ");
                tmpValues.append(", ");
            }
            counter++;
            if (f_DBType == DBTypeEnum.SqlServer) {
                tmpSql.append(String.format("[%s]", entry.getKey()));
            } else if (f_DBType == DBTypeEnum.Mysql) {
                tmpSql.append(String.format("`%s`", entry.getKey()));
            } else if (f_DBType == DBTypeEnum.Oracle) {
                tmpSql.append(String.format("\"%s\"", entry.getKey()));
            }
            $Ku.by.ToolClass.Sql.SqlField tmpField = entry.getValue();
            String tmpKuName = tmpField.getKuName();
            String tmpSheetName = tmpField.getSheetName();
            String tmpColumnName = tmpField.getName();
            Object tmpCellValue = null;
            //未指定插入的列，则将行中第一个当前表的单元格插入

            if (f_InsertColumns.isEmpty()) {
                $Ku.by.Object.Cell tmpCell = null;
                for ($Ku.by.Object.Cell item : f_Row.cells) {
                    if (Objects.equals(item.KuName, tmpKuName) && Objects.equals(item.SheetName, tmpSheetName) && Objects.equals(item.ColumnName, tmpColumnName)) {
                        tmpCell = item;
                    }
                }

                if (tmpCell != null && tmpCell.value != null) {
                    tmpCellValue = tmpCell.value;
                }
            } else {
                for (String componentName : f_InsertColumns) {
                    $Ku.by.ToolClass.Sql.SqlField tmpInsertField = ConvertComponentToField(componentName, tmpDataSheet);

                    if (tmpInsertField == tmpField) {
                        $Ku.by.Object.Cell tmpCell = null;
                        for ($Ku.by.Object.Cell item : f_Row.cells) {
                            if (Objects.equals(item.KuName, tmpKuName) && Objects.equals(item.SheetName, tmpSheetName) && Objects.equals(item.ColumnName, tmpColumnName)) {
                                tmpCell = item;
                            }
                            break;
                        }
                        if (tmpCell != null && tmpCell.value != null) {
                            tmpCellValue = tmpCell.value;
                        }
                    }
                }
            }
            if (tmpCellValue == null) {
                if (tmpDataSheet.getDefaultColumnList().contains(tmpColumnName)) {
                    tmpValues.append(tmpDataSheet.getFieldDefault(tmpColumnName));
                    continue;
                } else {
                    tmpValues.append(CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType));
                    continue;
                }
            }
            if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof Float || tmpCellValue instanceof Double || tmpCellValue instanceof $Ku.by.Object.Decimal) {
                tmpValues.append(tmpCellValue);
                continue;
            }

            if (tmpCellValue instanceof String || tmpCellValue instanceof Character || tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue.getClass().isEnum()) {
                if ((tmpCellValue instanceof $Ku.by.Object.Datetime || tmpField.getFieldType() == DataTypeEnum.Datetime) && f_DBType == DBTypeEnum.Oracle) {
                    tmpValues.append("TO_TIMESTAMP(").append(SaveInspect.CharactorEscape(tmpCellValue.toString())).append(", 'YYYY-MM-DD HH24:MI:SS.FF')");
                } else {
                    tmpValues.append(SaveInspect.CharactorEscape(tmpCellValue.toString()));
                }
                continue;
            }
            if (tmpCellValue instanceof Boolean) {
                Boolean tmpBoolValue = (Boolean) tmpCellValue;
                tmpValues.append(tmpBoolValue ? 1 : 0);
                continue;
            }
            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
        }

        tmpSql.append(")");
        tmpValues.append(")");
        tmpSql.append(tmpValues);

        if (f_DBType == DBTypeEnum.Mysql || f_DBType == DBTypeEnum.Oracle) {
            tmpSql.append(";");
        }
        tmpSql.append("\r\n");
        return tmpSql.toString();
    }

    public static java.lang.String InsertRowOrRowList(Object f_RowParameter, java.lang.String f_EffectedVariable, java.util.ArrayList<java.lang.String> f_InsertCols, boolean f_InTran, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_RowParameter == null) {
            if (f_InTran) {
                if (f_DBType == DBTypeEnum.SqlServer) {
                    return String.format("SET @%s = 0\r\n", f_EffectedVariable);
                } else if (f_DBType == DBTypeEnum.Mysql) {
                    return String.format("SET $%s = 0;\r\n", f_EffectedVariable);
                } else if (f_DBType == DBTypeEnum.Oracle){
                    return String.format("\"%s\" := 0;\r\n", f_EffectedVariable);
                }
            }
        }

        StringBuilder tmpSql = new StringBuilder();
        if (f_RowParameter instanceof $Ku.by.Object.Row) {
            $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row) f_RowParameter;
            String tmpInsertSql = FillInsertRow(tmpRow, f_InsertCols, f_DBType);

            if (tmpInsertSql.isEmpty()) {
                if (f_InTran) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Oracle){
                        tmpSql.append(String.format("\"%s\" := 0;\r\n", f_EffectedVariable));
                    }
                }
            } else {
                tmpSql.append(tmpInsertSql);

                if (f_InTran) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("SET @%s = @@ROWCOUNT\r\n", f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("SET $%s = ROW_COUNT();\r\n", f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Oracle){
                        tmpSql.append("\"").append(f_EffectedVariable).append("\" := SQL%ROWCOUNT;\r\n");
                    }
                }
            }
        } else if (f_RowParameter instanceof $Ku.by.Object.Row[] || f_RowParameter instanceof Iterable) {
            ArrayList<$Ku.by.Object.Row> tmpRowList = new ArrayList<>();
            if (f_RowParameter instanceof $Ku.by.Object.Row[]) {
                $Ku.by.Object.Row[] rows = ($Ku.by.Object.Row[]) f_RowParameter;
                tmpRowList.addAll(Arrays.asList(rows));
            } else {
                Iterable<$Ku.by.Object.Row> rows = (Iterable) f_RowParameter;
                for ($Ku.by.Object.Row row : rows) {
                    tmpRowList.add(row);
                }
            }
            if (f_InTran) {
                if (f_DBType == DBTypeEnum.SqlServer) {
                    tmpSql.append(String.format("SET @%s = 0\r\n", f_EffectedVariable));
                } else if (f_DBType == DBTypeEnum.Mysql) {
                    tmpSql.append(String.format("SET $%s = 0;\r\n", f_EffectedVariable));
                } else if (f_DBType == DBTypeEnum.Oracle){
                    tmpSql.append(String.format("\"%s\" := 0;\r\n", f_EffectedVariable));
                }
            }
            for ($Ku.by.Object.Row tmpRow : tmpRowList) {
                String tmpInsertSql = FillInsertRow(tmpRow, f_InsertCols, f_DBType);

                if (tmpInsertSql.isEmpty()) {
                    continue;
                }

                tmpSql.append(tmpInsertSql);

                if (f_InTran) {
                    if (f_DBType == DBTypeEnum.SqlServer) {
                        tmpSql.append(String.format("SET @%s = @%s + @@ROWCOUNT\r\n", f_EffectedVariable, f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Mysql) {
                        tmpSql.append(String.format("SET $%s = $%s + ROW_COUNT();\r\n", f_EffectedVariable, f_EffectedVariable));
                    } else if (f_DBType == DBTypeEnum.Oracle){
                        tmpSql.append("\"").append(f_EffectedVariable).append("\" := \"").append(f_EffectedVariable).append("\" + SQL%ROWCOUNT;\r\n");
                    }
                }
            }
        } else {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.IllegalRowParameter);
        }
        return tmpSql.toString();
    }

    public static java.lang.String[] InsertRowOrRowListNotInTran(Object f_RowParameter, java.util.ArrayList<java.lang.String> f_InsertCols, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_RowParameter == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIsNull);
        }

        ArrayList<String> tmpSql = new ArrayList<>();
        if (f_RowParameter instanceof $Ku.by.Object.Row) {
            $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row) f_RowParameter;
            tmpSql.add(FillInsertRow(tmpRow, f_InsertCols, f_DBType));
        } else if (f_RowParameter instanceof $Ku.by.Object.List) {
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpRowList = ($Ku.by.Object.List<$Ku.by.Object.Row>) f_RowParameter;
            for ($Ku.by.Object.Row tmpRow : tmpRowList) {
                tmpSql.add(FillInsertRow(tmpRow, f_InsertCols, f_DBType));
            }
        } else if (f_RowParameter instanceof $Ku.by.Object.Row[]) {
            $Ku.by.Object.Row[] tmpRowArray = ($Ku.by.Object.Row[]) f_RowParameter;
            for ($Ku.by.Object.Row item : tmpRowArray) {
                tmpSql.add(FillInsertRow(item, f_InsertCols, f_DBType));
            }
        } else {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.IllegalRowParameter);
        }
        String[] result = tmpSql.toArray(new String[0]);
        if (f_DBType == DBTypeEnum.Oracle) {
            for (int i = 0; i < result.length; i++) {
                result[i] = result[i].substring(0, result[i].length() - 3);
            }
        }
        return result;
    }

    public static java.lang.String FillDeleteRow($Ku.by.Object.Row f_Row, java.lang.StringBuilder f_Where, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_Row == null || f_Row.getIdentity() == null)
        {
            return null;
        }

        $Ku.by.Identity.Table tmpIdentity = GetIdentityOfRow(f_Row);

        if (tmpIdentity.to == null)
        {
            return null;
        }

        IBaseDataSheet tmpDataSheet = (IBaseDataSheet)tmpIdentity.to;

        StringBuilder tmpSql = new StringBuilder();
        if (f_DBType == DBTypeEnum.SqlServer)
        {
            tmpSql.append(String.format("DELETE FROM [%s] ", tmpDataSheet.getSheetName()));
        }
        else if (f_DBType == DBTypeEnum.Mysql)
        {
            tmpSql.append(String.format("DELETE FROM `%s` ", tmpDataSheet.getSheetName()));
        }
        else
        {
            tmpSql.append(String.format("DELETE FROM \"%s\".\"%s\" ", tmpDataSheet.getKuName(), tmpDataSheet.getSheetName()));
        }
        tmpSql.append(FillPkOfWhere(tmpDataSheet, f_Row, f_Where, f_DBType));

        if (f_DBType != DBTypeEnum.SqlServer) {
            tmpSql.append(";");
        }

        tmpSql.append("\r\n");
        return tmpSql.toString();
    }

    public static java.lang.String FieldRelationEqualRow($Ku.by.ToolClass.Sql.TableField f_Field, $Ku.by.Object.Row f_Row) {
        if (f_Row == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowIsNull);
        }

        //先判断字段和行对应的表是否存在关系
        if (!f_Row.getKuName().equals(f_Field.getSelectedField().getKuName())) {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }

        $Ku.by.ToolClass.BaseKu tmpKu = GetKu(f_Field.getSelectedField().getKuName());
        DBTypeEnum tmpDBType;
        if (!Root.GetInstance().KuTypeDic.containsKey(f_Row.getKuName())) {
            ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_Row.getKuName()));
        }
        tmpDBType = Root.GetInstance().KuTypeDic.get(f_Row.getKuName());
        StringBuilder tmpSqlExpression = new StringBuilder();
        if (f_Field.getSelectedField().getSheetName().equals(f_Row.getSheetName())) {
            //表相同时
            String tmpColumnName = f_Field.getSelectedField().getName();
            Cell tmpMatchedCell = null;
            for ($Ku.by.Object.Cell item : f_Row.cells) {
                if (Objects.equals(item.ColumnName, tmpColumnName)) {
                    tmpMatchedCell = item;
                    break;
                }
            }
            if (tmpMatchedCell == null) {
                ThrowHelper.ThrowRelationOperationException(ErrorInfo.CanNotFindRelationCellInRow);
            }

            if (tmpMatchedCell.DataTypeEnum == DataTypeEnum.None) {
                tmpMatchedCell.DataTypeEnum = f_Field.getSelectedField().getFieldType();
                tmpMatchedCell.EnumType = f_Field.getSelectedField().getEnumType();
            }

            Object tmpMacthedValue = tmpMatchedCell.value;
            tmpSqlExpression.append(f_Field.getFieldAccess());
            tmpSqlExpression.append(" = ");

            if (tmpMacthedValue == null) {
                tmpSqlExpression.append(CellValueNullToDefaultReturnString(f_Field.FieldType, f_Field.EnumType, tmpDBType));
            }
            if (tmpMacthedValue instanceof Character || tmpMacthedValue instanceof String || tmpMacthedValue instanceof $Ku.by.Object.Datetime || Objects.requireNonNull(tmpMacthedValue).getClass().isEnum()) {
                if (tmpMacthedValue instanceof $Ku.by.Object.Datetime && tmpDBType == DBTypeEnum.Oracle) {
                    tmpSqlExpression.append("TO_TIMESTAMP(").append(SaveInspect.CharactorEscape(tmpMacthedValue.toString())).append(", 'YYYY-MM-DD HH24:MI:SS.FF')");
                }
                tmpSqlExpression.append(SaveInspect.CharactorEscape(tmpMacthedValue.toString()));
            } else if (tmpMacthedValue instanceof Byte || tmpMacthedValue instanceof Short || tmpMacthedValue instanceof Integer || tmpMacthedValue instanceof Long || tmpMacthedValue instanceof Float || tmpMacthedValue instanceof Double || tmpMacthedValue instanceof $Ku.by.Object.Decimal) {
                tmpSqlExpression.append(tmpMacthedValue);
            } else if (tmpMacthedValue instanceof Boolean) {
                Boolean tmpBoolValue = (Boolean) tmpMacthedValue;
                tmpSqlExpression.append(tmpBoolValue ? 1 : 0);
            } else {
                $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
            }
            return tmpSqlExpression.toString();
        }
        SheetRelation tmpRelation = FindReferenceBetweenFieldAndSheet(tmpKu, f_Field.getSelectedField(), f_Row.getSheetName());
        $Ku.by.Object.Cell tmpCell = null;
        if (Objects.equals(tmpRelation.ReferencedSheet, f_Field.getSelectedField().getSheetName())) {
            if (!Objects.equals(tmpRelation.ReferencedFieldName, f_Field.getSelectedField().getName())) {
                ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.getSheetName()));
            }
            for (Cell item : f_Row.cells) {
                if (Objects.equals(item.SheetName, tmpRelation.ReferenceSheet) && Objects.equals(item.ColumnName, tmpRelation.ReferenceFieldName)) {
                    tmpCell = item;
                }
            }
        } else {
            if (!Objects.equals(tmpRelation.ReferenceFieldName, f_Field.getSelectedField().getName())) {
                ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.getSheetName()));
            }
            for (Cell item : f_Row.cells) {
                if (Objects.equals(item.SheetName, tmpRelation.ReferencedSheet) && Objects.equals(item.ColumnName, tmpRelation.ReferencedFieldName)) {
                    tmpCell = item;
                }
            }
        }

        if (tmpCell == null) {
            ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindRelationCellInRow, f_Row.getSheetName()));
        }

        //字段 = 行中某个值
        tmpSqlExpression.append(GenerateQueryField((SqlTable) f_Field.getFieldTable(), f_Field.getSelectedField()));
        tmpSqlExpression.append(" = ");
        Object tmpCellValue = tmpCell.value;

        if (tmpCellValue == null) {
            tmpSqlExpression.append(CellValueNullToDefaultReturnString(f_Field.FieldType, f_Field.EnumType, tmpDBType));
        } else if (tmpCellValue instanceof Character || tmpCellValue instanceof String || tmpCellValue instanceof $Ku.by.Object.Datetime
                || tmpCellValue.getClass().isEnum()) {
            if (tmpCellValue instanceof $Ku.by.Object.Datetime && tmpDBType == DBTypeEnum.Oracle) {
                tmpSqlExpression.append("TO_TIMESTAMP(").append(SaveInspect.CharactorEscape(tmpCell.value.toString())).append(", 'YYYY-MM-DD HH24:MI:SS.FF')");
            } else {
                tmpSqlExpression.append(SaveInspect.CharactorEscape(tmpCell.value.toString()));
            }
        } else if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof
                Float || tmpCellValue instanceof Double
                || tmpCellValue instanceof $Ku.by.Object.Decimal) {
            tmpSqlExpression.append(tmpCellValue);
        } else if (tmpCellValue instanceof Boolean) {
            Boolean tmpBoolValue = (Boolean) tmpCellValue;
            tmpSqlExpression.append(tmpBoolValue ? 1 : 0);
        } else {
            ThrowHelper.ThrowRelationOperationException(ErrorInfo.CellValueTypeError);
        }
        return tmpSqlExpression.toString();
    }

    public static java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> ConvertConfigList(java.util.ArrayList<$Ku.by.ToolClass.Source> f_ConfigList, $Ku.by.ToolClass.Sql.SqlTable f_Table, int f_ConfigTableCount, $Ku.by.ToolClass.OutObject<java.lang.Integer> f_ConfigJoinCountr) {
        ArrayList<AbstractSelectField> tmpFieldList = new ArrayList<>();

        if (f_ConfigList == null) {
            f_ConfigJoinCountr.outArgValue = f_ConfigTableCount;
            return tmpFieldList;
        }
        Hashtable<IBaseDataSheet, $Ku.by.ToolClass.Sql.SqlTable> tmpDic = new Hashtable<>();//填充所有非本表的表
        Hashtable<String, $Ku.by.ToolClass.Sql.SqlTable> tmpNewDic = new Hashtable<>();
        BaseKu tmpKu = GetKu(f_Table.getKuName());

        DBTypeEnum tmpDBType = null;
        if (!Root.GetInstance().KuTypeDic.containsKey(f_Table.getKuName())) {
            ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_Table.getKuName()));
        } else {
            tmpDBType = Root.GetInstance().KuTypeDic.get(f_Table.getKuName());
        }

        int tmpConfigNamedField = 0;
        for (Source item : f_ConfigList) {
            $Ku.by.ToolClass.Sql.SqlField tmpField = item.DataSheetField;
            IBaseDataSheet tmpFieldDataSheet = GetDataSheet(tmpField.getKuName(), tmpField.getSheetName());
            if (item.RelationValue != null) {
                if (!tmpNewDic.containsKey(item.RelationValue)) {
                    if (tmpFieldDataSheet != f_Table.getSheet()) {
                        String tmpConfigTableName = "#" + f_ConfigTableCount++;
                        $Ku.by.ToolClass.Sql.SqlTable tmpNewTable = new $Ku.by.ToolClass.Sql.SqlTable(tmpFieldDataSheet, tmpConfigTableName);
                        //tmpdic不添加
                        JoinTable tmpJoinTable = new JoinTable(tmpNewTable);
                        tmpJoinTable.setJoinMode(" LEFT JOIN ");
                        boolean tmpHasMatched = false;
                        f_Table.getJoinTables().add(tmpJoinTable);

                        if (tmpKu.RelationDic.containsKey(f_Table.getSourceName())) {
                            ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(f_Table.getSourceName());
                            tmpHasMatched = FillRelationTableKeyIsTable(f_Table, tmpRelations, tmpJoinTable, tmpNewTable, item);
                        }

                        if (!tmpHasMatched) {
                            if (!tmpKu.RelationDic.containsKey(tmpFieldDataSheet.getSheetName())) {
                                ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Table.getSourceName(), tmpFieldDataSheet.getSheetName()));
                            }
                            ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(tmpFieldDataSheet.getSheetName());
                            tmpHasMatched = FillRelationTableKeyIsFieldTable(f_Table, tmpRelations, tmpJoinTable, tmpNewTable, item);
                        }

                        if (!tmpHasMatched) {
                            ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Table.getSourceName(), tmpFieldDataSheet.getSheetName()));
                        }
                        tmpNewDic.put(item.RelationValue, tmpNewTable);
                    }
                }
            } else {
                if (!tmpDic.containsKey(tmpFieldDataSheet) && tmpField.getFunc() != FunctionEnum.NONE) {
                    String tmpConfigTableName = "#" + f_ConfigTableCount++;

                    $Ku.by.ToolClass.Sql.SqlTable tmpNewTable = new $Ku.by.ToolClass.Sql.SqlTable(tmpFieldDataSheet, tmpConfigTableName);
                    JoinTable tmpJoinTable = new JoinTable(tmpNewTable);
                    tmpDic.put(tmpFieldDataSheet, tmpNewTable);
                    tmpJoinTable.setJoinMode(" LEFT JOIN ");
                    boolean tmpHasMatched = false;
                    f_Table.getJoinTables().add(tmpJoinTable);
                    if (tmpKu.RelationDic.containsKey(f_Table.getSourceName())) {
                        //当前table引用其他的表(newtable)
                        ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(f_Table.getSourceName());
                        tmpHasMatched = FillRelationTableKeyIsTable(f_Table, tmpRelations, tmpJoinTable, tmpNewTable, item);
                    }
                    if (!tmpHasMatched) {
                        if (!tmpKu.RelationDic.containsKey(tmpFieldDataSheet.getSheetName())) {
                            ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Table.getSourceName(), tmpFieldDataSheet.getSheetName()));
                        }
                        ArrayList<SheetRelation> tmpRelations = tmpKu.RelationDic.get(tmpFieldDataSheet.getSheetName());
                        tmpHasMatched = FillRelationTableKeyIsFieldTable(f_Table, tmpRelations, tmpJoinTable, tmpNewTable, item);
                    }

                    if (!tmpHasMatched) {
                        ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindRelationBetweenSheets, f_Table.getSourceName(), tmpFieldDataSheet.getSheetName()));
                    }
                } else {
                    if (!tmpDic.containsKey(tmpFieldDataSheet)) {
                        tmpDic.put(tmpFieldDataSheet, f_Table);
                    }
                }
            }
            if (tmpField.getFunc() != FunctionEnum.NONE) {
                String tmpAlias = "#Config_" + tmpConfigNamedField++;
                FuncField tmpFuncField = new FuncField(tmpField.getFunc().toString(), DataTypeEnum.None, null, tmpDBType);
                tmpFuncField.setAlias(tmpAlias);
                tmpFieldList.add(tmpFuncField);
                if (tmpField.getFunc() == FunctionEnum.COUNT && Objects.equals(tmpField.getName(), "*")) {
                    tmpFuncField.getParams().add(new AsteriskField());
                } else if (item.RelationValue != null) {
                    tmpFuncField.getParams().add(new TableField(tmpField, tmpNewDic.get(item.RelationValue), null));
                } else {
                    tmpFuncField.getParams().add(new TableField(tmpField, tmpDic.get(tmpFieldDataSheet), null));
                }

                tmpFuncField.GenerateType();
            } else {
                if (item.RelationValue != null) {
                    tmpFieldList.add(new TableField(tmpField, tmpNewDic.get(item.RelationValue), null));
                } else {
                    tmpFieldList.add(new TableField(tmpField, tmpDic.get(tmpFieldDataSheet), null));
                }
            }
        }

        f_ConfigJoinCountr.outArgValue = f_ConfigTableCount;
        return tmpFieldList;
    }

    public static java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> ConvertConfigList(java.util.ArrayList<$Ku.by.ToolClass.Source> f_ConfigList, $Ku.by.ToolClass.Sql.SqlTable f_Table, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables) {
        //给localsql填充field用，里面表信息不重要，数量索引对就可以
        ArrayList<AbstractSelectField> tmpFieldList = new ArrayList<>();
        if (f_ConfigList == null) {
            return tmpFieldList;
        }

        DBTypeEnum tmpDBType = null;
        if (!Root.GetInstance().KuTypeDic.containsKey(f_Table.getKuName())) {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_Table.getKuName()));
        } else {
            tmpDBType = Root.GetInstance().KuTypeDic.get(f_Table.getKuName());
        }
        HashMap<IBaseDataSheet, $Ku.by.ToolClass.Sql.SqlTable> tmpDic = new HashMap<>();
        for (Source item : f_ConfigList) {
            $Ku.by.ToolClass.Sql.SqlField tmpField = item.DataSheetField;
            IBaseDataSheet tmpDataSheet = GetDataSheet(tmpField.getKuName(), tmpField.getSheetName());
            if (tmpDataSheet == f_Table.getSheet()) {
                if (tmpField.getFunc() != FunctionEnum.NONE) {
                    FuncField tmpFuncField = new FuncField(tmpField.getFunc().toString(), DataTypeEnum.None, null, tmpDBType);
                    if (tmpField.getFunc() == FunctionEnum.COUNT && tmpField.getName().equals("*")) {
                        tmpFuncField.getParams().add(new AsteriskField());
                    } else {
                        tmpFuncField.getParams().add(new TableField(tmpField, f_Table, null));
                    }
                    tmpFuncField.GenerateType();
                    tmpFieldList.add(tmpFuncField);
                } else {
                    tmpFieldList.add(new TableField(tmpField, f_Table, null));
                }
            } else {
                if (!tmpDic.containsKey(tmpDataSheet)) {
                    $Ku.by.ToolClass.Sql.SqlTable tmpNewTable = new $Ku.by.ToolClass.Sql.SqlTable(tmpDataSheet, null);
                    tmpDic.put(tmpDataSheet, tmpNewTable);
                    f_Tables.add(tmpNewTable);
                }
                if (tmpField.getFunc() != FunctionEnum.NONE) {
                    FuncField tmpFuncField = new FuncField(tmpField.getFunc().toString(), DataTypeEnum.None, null, tmpDBType);
                    tmpFuncField.getParams().add(new TableField(tmpField, f_Table, null));
                    tmpFuncField.GenerateType();
                    tmpFieldList.add(tmpFuncField);
                } else {
                    tmpFieldList.add(new TableField(tmpField, f_Table, null));
                }
            }
        }
        return tmpFieldList;
    }

    private static boolean FillRelationTableKeyIsTable($Ku.by.ToolClass.Sql.SqlTable f_Table, java.util.ArrayList<$Ku.by.ToolClass.SheetRelation> f_Relations, $Ku.by.ToolClass.Sql.JoinTable f_JoinTable, $Ku.by.ToolClass.Sql.SqlTable f_NewTable, $Ku.by.ToolClass.Source f_Item) {
        //当前table引用其他的表(newtable)
        if (Objects.equals(f_Item.DataSheetField.getName(), "*"))
        {
            return false;
        }

        DBTypeEnum tmpDBType = null;
        if (!Root.GetInstance().KuTypeDic.containsKey(f_Table.getKuName())) {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_Table.getKuName()));
        } else {
            tmpDBType = Root.GetInstance().KuTypeDic.get(f_Table.getKuName());
        }

        if (f_Item.RelationColumn != null && f_Item.RelationValue != null) {
            String[] tmpRelatValueionArray = f_Item.RelationValue.split("\\.");
            String[] tmpRelationColumnArray = f_Item.RelationColumn.split("\\.");
            String tmpRefSheetName = tmpRelatValueionArray[1];
            String tmpRefFieldName = tmpRelatValueionArray[2];
            String tmpSheetName = tmpRelationColumnArray[1];
            String tmpFieldName = tmpRelationColumnArray[2];
            SheetRelation tmpMatched = null;
            for (SheetRelation value : f_Relations) {
                if (Objects.equals(value.ReferenceSheet, tmpRefSheetName) && Objects.equals(value.ReferenceFieldName, tmpRefFieldName) && Objects.equals(value.ReferencedSheet, tmpSheetName) && Objects.equals(value.ReferencedFieldName, tmpFieldName)) {
                    tmpMatched = value;
                    break;
                }
            }
            if (tmpMatched == null) {
                return false;
            }
            f_JoinTable.privateCondition.append(" ON ");
            if (tmpDBType == DBTypeEnum.SqlServer) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "[" + tmpMatched.ReferenceSheet + "]" : f_Table.getAlias());
                f_JoinTable.privateCondition.append(".[").append(tmpMatched.ReferenceFieldName).append("] = [").append(f_NewTable.getAlias()).append("].[").append(tmpMatched.ReferencedFieldName).append("]");
            } else if (tmpDBType == DBTypeEnum.Mysql) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "`" + tmpMatched.ReferenceSheet + "`" : f_Table.getAlias());
                f_JoinTable.privateCondition.append(".`").append(tmpMatched.ReferenceFieldName).append("` = `").append(f_NewTable.getAlias()).append("`.`").append(tmpMatched.ReferencedFieldName).append("`");
            } else if (tmpDBType == DBTypeEnum.Oracle) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "\"" + tmpMatched.ReferenceSheet + "\"" : "\"" + f_Table.getAlias() + "\"");
                f_JoinTable.privateCondition.append(".\"").append(tmpMatched.ReferenceFieldName).append("\" = \"").append(f_NewTable.getAlias()).append("\".\"").append(tmpMatched.ReferencedFieldName).append("\"");
            }
            return true;
        } else {
            //主动引用的表在连接被引用的表时需要标明字段
            ArrayList<SheetRelation> tmpMatches = new ArrayList<>();
            for (SheetRelation value:f_Relations) {
                if (f_Item.DataSheetField.getSheetName().equals(value.ReferencedSheet)) {
                    tmpMatches.add(value);
                }
            }
            if (tmpMatches.isEmpty()) {
                return false;
            }

            SheetRelation tmpMatched = tmpMatches.get(0);
            f_JoinTable.privateCondition.append(" ON ");
            if (tmpDBType == DBTypeEnum.SqlServer) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "[" + tmpMatched.ReferenceSheet + "]" : f_Table.getAlias());
                f_JoinTable.privateCondition.append(".[").append(tmpMatched.ReferenceFieldName).append("] = [").append(f_NewTable.getAlias()).append("].[").append(tmpMatched.ReferencedFieldName).append("]");
            } else if (tmpDBType == DBTypeEnum.Mysql) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "`" + tmpMatched.ReferenceSheet + "`" : f_Table.getAlias());
                f_JoinTable.privateCondition.append(".`").append(tmpMatched.ReferenceFieldName).append("` = `").append(f_NewTable.getAlias()).append("`.`").append(tmpMatched.ReferencedFieldName).append("`");
            } else if (tmpDBType == DBTypeEnum.Oracle) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "\"" + tmpMatched.ReferenceSheet + "\"" : "\"" + f_Table.getAlias() + "\"");
                f_JoinTable.privateCondition.append(".\"").append(tmpMatched.ReferenceFieldName).append("\" = \"").append(f_NewTable.getAlias()).append("\".\"").append(tmpMatched.ReferencedFieldName).append("\"");
            }
            return true;
        }
    }

    private static boolean FillRelationTableKeyIsFieldTable($Ku.by.ToolClass.Sql.SqlTable f_Table, java.util.ArrayList<$Ku.by.ToolClass.SheetRelation> f_Relations, $Ku.by.ToolClass.Sql.JoinTable f_JoinTable, $Ku.by.ToolClass.Sql.SqlTable f_NewTable, $Ku.by.ToolClass.Source f_Item) {
        //当前table为被引用的表时
        if (f_Item.DataSheetField.getName() == "*") {
            return false;
        }

        DBTypeEnum tmpDBType = null;
        if (!Root.GetInstance().KuTypeDic.containsKey(f_Table.getKuName())) {
            $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_Table.getKuName()));
        } else {
            tmpDBType = Root.GetInstance().KuTypeDic.get(f_Table.getKuName());
        }

        if (f_Item.RelationColumn != null && f_Item.RelationValue != null) {
            String[] tmpRelatValueionArray = f_Item.RelationValue.split("\\.");
            String[] tmpRelationColumnArray = f_Item.RelationColumn.split("\\.");
            String tmpRefSheetName = tmpRelatValueionArray[1];
            String tmpRefFieldName = tmpRelatValueionArray[2];
            String tmpSheetName = tmpRelationColumnArray[1];
            String tmpFieldName = tmpRelationColumnArray[2];
            SheetRelation tmpMatched = null;
            for (SheetRelation value : f_Relations) {
                if (Objects.equals(value.ReferenceSheet, tmpRefSheetName) && Objects.equals(value.ReferenceFieldName, tmpRefFieldName) && Objects.equals(value.ReferencedSheet, tmpSheetName) && Objects.equals(value.ReferencedFieldName, tmpFieldName)) {
                    tmpMatched = value;
                    break;
                }
            }
            if (tmpMatched == null) {
                return false;
            }
            if (!f_Table.getSourceName().equals(tmpMatched.ReferencedSheet)) {
                return false;
            }
            f_JoinTable.privateCondition.append(" ON ");
            if (tmpDBType == DBTypeEnum.SqlServer) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "[" + tmpMatched.ReferencedSheet + "]" : f_Table.getAlias());
                f_JoinTable.privateCondition.append(".[").append(tmpMatched.ReferencedFieldName).append("] = [").append(f_NewTable.getAlias()).append("].[").append(tmpMatched.ReferenceFieldName).append("]");
            } else if (tmpDBType == DBTypeEnum.Mysql) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "`" + tmpMatched.ReferencedSheet + "`" : f_Table.getAlias());
                f_JoinTable.privateCondition.append(".`").append(tmpMatched.ReferencedFieldName).append("` = `").append(f_NewTable.getAlias()).append("`.`").append(tmpMatched.ReferenceFieldName).append("`");
            } else if (tmpDBType == DBTypeEnum.Oracle) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "\"" + tmpMatched.ReferenceSheet + "\"" : "\"" + f_Table.getAlias() + "\"");
                f_JoinTable.privateCondition.append(".\"").append(tmpMatched.ReferencedFieldName).append("\" = \"").append(f_NewTable.getAlias()).append("\".\"").append(tmpMatched.ReferenceFieldName).append("\"");
            }
            return true;
        } else {
            //主动引用的表在连接被引用的表时需要标明字段
            ArrayList<SheetRelation> tmpMatcheds = new ArrayList<>();
            for (SheetRelation value : f_Relations) {
                if (f_Table.getSourceName().equals(value.ReferencedSheet)) {
                    tmpMatcheds.add(value);
                }
            }
            if (tmpMatcheds.isEmpty()) {
                return false;
            }

            SheetRelation tmpMatched = tmpMatcheds.get(0);
            f_JoinTable.privateCondition.append(" ON ");
            if (tmpDBType == DBTypeEnum.SqlServer) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "[" + tmpMatched.ReferencedSheet + "]" : f_Table.getAlias());
                f_JoinTable.privateCondition.append(".[").append(tmpMatched.ReferencedFieldName).append("] = [").append(f_NewTable.getAlias()).append("].[").append(tmpMatched.ReferenceFieldName).append("]");
            } else if (tmpDBType == DBTypeEnum.Mysql) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "`" + tmpMatched.ReferencedSheet + "`" : f_Table.getAlias());
                f_JoinTable.privateCondition.append(".`").append(tmpMatched.ReferencedFieldName).append("` = `").append(f_NewTable.getAlias()).append("`.`").append(tmpMatched.ReferenceFieldName).append("`");
            } else if (tmpDBType == DBTypeEnum.Oracle) {
                f_JoinTable.privateCondition.append(f_Table.getAlias() == null ? "\"" + tmpMatched.ReferenceSheet + "\"" : "\"" + f_Table.getAlias() + "\"");
                f_JoinTable.privateCondition.append(".\"").append(tmpMatched.ReferencedFieldName).append("\" = \"").append(f_NewTable.getAlias()).append("\".\"").append(tmpMatched.ReferenceFieldName).append("\"");
            }
            return true;
        }
    }

    public static void GenerateSelectGroupBy(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_GroupBy, java.lang.StringBuilder f_GroupBySB, java.lang.StringBuilder f_Having, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectFields, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        String[] tmpGroupByName = {"count", "max", "min", "avg", "sum"};

        AbstractSelectField tempField = null;
        for (AbstractSelectField item : f_SelectFields) {
            if (item instanceof FuncField && Arrays.asList(tmpGroupByName).contains(((FuncField) item).getFuncName().toLowerCase())) {
                tempField = item;
                break;
            }
        }
        boolean tmpHasGroupByFunc = f_SelectFields.contains(tempField);
        if (tmpHasGroupByFunc || !f_GroupBy.isEmpty()) {
            for (AbstractSelectField item : f_SelectFields) {
                if (item instanceof TableField) {
                    if (!f_GroupBy.contains(item)) {
                        f_GroupBy.add(item);
                    }
                }
                if (item instanceof IFields) {
                    IFields tmpField = (IFields) item;
                    for (AbstractSelectField field : tmpField.getFieldList()) {
                        if (!f_GroupBy.contains(field)) {
                            f_GroupBy.add(field);
                        }
                    }
                }
            }
        }

        if (f_GroupBy.isEmpty()) {
            return;
        }

        f_GroupBySB.append(" group by ");

        if (f_Having.length() != 0) {

            for (AbstractSelectField item : f_SelectFields) {
                TableField tmpField = (TableField) ((item instanceof TableField) ? item : null);
                if (tmpField == null) {
                    continue;
                }
                if (f_GroupBy.contains(tmpField)) {
                    continue;
                }
                f_GroupBy.add(tmpField);
            }
        }

        for (int i = 0; i < f_GroupBy.size(); i++) {

            AbstractSelectField tmpField = f_GroupBy.get(i);
            if (tmpField.getFieldTable() == null) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.FieldWithoutTableSource);
            }

            if (i != 0) {
                f_GroupBySB.append(", ");
            }
            if (tmpField.getFieldTable() != null && tmpField.getFieldTable().getAlias() != null) {
                if (f_DBType == DBTypeEnum.SqlServer) {
                    f_GroupBySB.append(String.format("[%s]", tmpField.getFieldTable().getAlias()));
                } else if (f_DBType == DBTypeEnum.Mysql) {
                    f_GroupBySB.append(String.format("`%s`", tmpField.getFieldTable().getAlias()));
                } else {
                    f_GroupBySB.append(String.format("\"%s\"", tmpField.getFieldTable().getAlias()));
                }
            } else {
                if (f_DBType == DBTypeEnum.SqlServer) {
                    f_GroupBySB.append(String.format("[%s]", tmpField.getFieldTable().GetSource().getSheetName()));
                } else if (f_DBType == DBTypeEnum.Mysql) {
                    f_GroupBySB.append(String.format("`%s`", tmpField.getFieldTable().GetSource().getSheetName()));
                } else if (f_DBType == DBTypeEnum.Oracle) {
                    f_GroupBySB.append(String.format("\"%s\"", tmpField.getFieldTable().GetSource().getSheetName()));
                }
            }

            if (f_DBType == DBTypeEnum.SqlServer) {
                f_GroupBySB.append(String.format(".[%s]", ((TableField) tmpField).getSelectedField().getName()));
            } else if (f_DBType == DBTypeEnum.Mysql) {
                f_GroupBySB.append(String.format(".`%s`", ((TableField) tmpField).getSelectedField().getName()));
            } else if (f_DBType == DBTypeEnum.Oracle) {
                f_GroupBySB.append(String.format("\".%s\"", ((TableField) tmpField).getSelectedField().getName()));
            }
        }
    }

    public static java.lang.String GenerateSelectItemAndFrom(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables, java.lang.StringBuilder f_From, boolean f_HasLimit, java.util.ArrayList<$Ku.by.ToolClass.Sql.OrderByField> f_OrderByList, $Ku.by.ToolClass.DBTypeEnum f_DBType, java.lang.Boolean f_Lock) {
        StringBuilder tmpSelectItemsSB = new StringBuilder();
        //select 后面开始
        //字段
        if (f_HasLimit && f_DBType == DBTypeEnum.SqlServer) {
            CheckLimitSelectFields(f_SelectItems, f_OrderByList);
        }

        if (f_HasLimit && f_DBType == DBTypeEnum.Oracle) {
            CheckOracleLimitSelectFields(f_SelectItems);
        }

        for (int i = 0; i < f_SelectItems.size(); i++) {
            if (i != 0) {
                tmpSelectItemsSB.append(", ");
            }

            AbstractSelectField tmpSelectItem = f_SelectItems.get(i);
            tmpSelectItemsSB.append(tmpSelectItem.getSelectItemDeclare());
        }

        //需要把sqlserver中额外添加的列去掉
        if (f_HasLimit && f_DBType == DBTypeEnum.SqlServer) {
            String tmpNewPattern = "#NewOrderBy\\d+";
            java.util.regex.Pattern pattern = java.util.regex.Pattern.compile(tmpNewPattern);
            f_SelectItems.removeIf(item -> item.getAlias() != null && pattern.matcher(item.getAlias()).matches());
        }

        FillFrom(f_Tables, f_From, f_Lock);
        tmpSelectItemsSB.append(f_From);
        return tmpSelectItemsSB.toString();
    }

    public static java.lang.String GenerateSelectItemAndFrom(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables, java.lang.StringBuilder f_From, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
         //默认没有limit
        StringBuilder tmpSelectItem = new StringBuilder();

        if (f_DBType == DBTypeEnum.SqlServer) {
            for (AbstractSelectField fSelectItem : f_SelectItems) {
                AssignmentField tmpItem = (AssignmentField) fSelectItem;

                if (tmpSelectItem.length() != 0) {
                    tmpSelectItem.append(", ");
                }

                if (tmpItem == null) {
                    ThrowHelper.ThrowUnKnownException("SELECT变量赋值表达式填充错误");
                }

                String tmpVarName = "@" + tmpItem.LocalVariable;
                tmpSelectItem.append(tmpVarName);
                tmpSelectItem.append(" = ");
                tmpSelectItem.append(tmpItem.Field.getSelectItemDeclare());
            }
        }

        if (f_DBType == DBTypeEnum.Mysql) {
            StringBuilder tmpVarSB = new StringBuilder();
            StringBuilder tmpValueSB = new StringBuilder();

            for (int i = 0; i < f_SelectItems.size(); i++) {
                AssignmentField tmpItem = (AssignmentField) f_SelectItems.get(i);

                if (i != 0) {
                    tmpVarSB.append(", ");
                    tmpValueSB.append(", ");
                }

                String tmpVarName = "`" + tmpItem.LocalVariable + "`";
                String tmpValue = tmpItem.Field.getSelectItemDeclare();
                tmpVarSB.append(tmpVarName);
                tmpValueSB.append(tmpValue);
            }

            tmpSelectItem.append(tmpValueSB);
            tmpSelectItem.append(" INTO ");
            tmpSelectItem.append(tmpVarSB);
        }

        if (f_DBType == DBTypeEnum.Oracle) {
            StringBuilder tmpVarSB = new StringBuilder();
            StringBuilder tmpValueSB = new StringBuilder();

            for (int i = 0; i < f_SelectItems.size(); i++) {
                AssignmentField tmpItem = (AssignmentField) f_SelectItems.get(i);

                if (i != 0) {
                    tmpVarSB.append(", ");
                    tmpValueSB.append(", ");
                }

                String tmpVarName = "\"" + tmpItem.LocalVariable + "\"";
                String tmpValue = tmpItem.Field.getSelectItemDeclare();
                tmpVarSB.append(tmpVarName);
                tmpValueSB.append(tmpValue);
            }

            tmpSelectItem.append(tmpValueSB);
            tmpSelectItem.append(" INTO ");
            tmpSelectItem.append(tmpVarSB);
        }

        FillFrom(f_Tables, f_From, false);
        tmpSelectItem.append(f_From);
        return tmpSelectItem.toString();
    }

    private static int FindRowNumberField(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables) {
        int tmpCount = 0;

        for (AbstractTable item : f_Tables)
        {
            if (item instanceof TemporaryTable)
            {
                tmpCount++;
            }

            if (item instanceof SelectTable)
            {
                SelectTable tmpTable = (SelectTable)((item instanceof SelectTable) ? item : null);
                tmpCount += FindRowNumberField(tmpTable.getTableSources());
            }
        }
        return tmpCount;
    }

    public static java.lang.String TableToCode($Ku.by.ToolClass.Sql.AbstractTable f_Table) {
        StringBuilder tmpValue = new StringBuilder();
        DBTypeEnum tmpDBType = null;
        if (f_Table instanceof $Ku.by.ToolClass.Sql.SqlTable) {
            $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable) f_Table;
            if (!Root.GetInstance().KuTypeDic.containsKey(tmpTable.getKuName())) {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, tmpTable.getKuName()));
            }
            tmpDBType = Root.GetInstance().KuTypeDic.get(tmpTable.getKuName());

            if (tmpDBType == DBTypeEnum.SqlServer) {
                tmpValue.append("[");
                tmpValue.append(tmpTable.getSourceName());
                tmpValue.append("] ");
            } else if (tmpDBType == DBTypeEnum.Mysql) {
                tmpValue.append("`");
                tmpValue.append(tmpTable.getSourceName());
                tmpValue.append("` ");
            } else if (tmpDBType == DBTypeEnum.Oracle) {
                tmpValue.append("\"").append(tmpTable.getKuName()).append("\".");
                tmpValue.append("\"");
                tmpValue.append(tmpTable.getSourceName());
                tmpValue.append("\" ");
            } else {
                tmpValue.append(tmpTable.getSourceName()).append(" ");
            }
            if (tmpTable.getAlias() != null) {
                if (tmpDBType == DBTypeEnum.Oracle) {
                    tmpValue.append("\"").append(tmpTable.getAlias()).append("\"");
                } else if (tmpDBType == DBTypeEnum.SqlServer) {
                    tmpValue.append("[");
                    tmpValue.append(tmpTable.getAlias());
                    tmpValue.append("]");
                } else if (tmpDBType == DBTypeEnum.Mysql) {
                    tmpValue.append("`");
                    tmpValue.append(tmpTable.getAlias());
                    tmpValue.append("`");
                }
            }
        } else {
            SelectTable tmpSelectTable = (SelectTable) ((f_Table instanceof SelectTable) ? f_Table : null);
            if (tmpSelectTable != null) {
                tmpDBType = Root.GetInstance().KuTypeDic.get(tmpSelectTable.GetSource().getKuName());
                tmpValue.append("( ");
                tmpValue.append(tmpSelectTable.getSqlValue());
                tmpValue.append(" ) ");
                if (tmpSelectTable.getAlias() == null) {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SelectResultAccessWithoutAlias);
                }
                if (tmpDBType == DBTypeEnum.Oracle) {
                    tmpValue.append("\"").append(tmpSelectTable.getAlias()).append("\"");
                }else if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpValue.append("[");
                    tmpValue.append(tmpSelectTable.getAlias());
                    tmpValue.append("]");
                }
                else if (tmpDBType == DBTypeEnum.Mysql)
                {
                    tmpValue.append("`");
                    tmpValue.append(tmpSelectTable.getAlias());
                    tmpValue.append("`");
                }
            }
        }
        for (JoinTable item : f_Table.getJoinTables()) {
            tmpValue.append(item.getJoinMode());
            tmpValue.append(TableToCode(item.getJoinTable()));
            tmpValue.append(item.getCondition());
        }
        return tmpValue.toString();
    }

    public static java.lang.String TableToCode($Ku.by.ToolClass.Sql.AbstractTable f_Table, java.lang.String f_KuName, java.lang.Boolean f_Lock) {
        StringBuilder tmpValue = new StringBuilder();

        if (!Objects.equals(f_KuName, f_Table.GetSource().getKuName())) {
            ThrowHelper.ThrowSqlPreCompileException("当前SQL查询表源来自多个不同的数据库，不支持跨库查询");
        }

        if (f_Table instanceof SqlTable) {
            SqlTable tmpTable = (SqlTable) f_Table;
            DBTypeEnum tmpDBType;
            if (!Root.GetInstance().KuTypeDic.containsKey(tmpTable.getKuName())) {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, tmpTable.getKuName()));
            }
            tmpDBType = Root.GetInstance().KuTypeDic.get(tmpTable.getKuName());

            if (tmpDBType == DBTypeEnum.SqlServer) {
                tmpValue.append("[");
                tmpValue.append(tmpTable.getSourceName());
                tmpValue.append("] ");

                if (f_Lock) {
                    tmpValue.append("WITH(UPDLOCK) ");
                }
            } else if (tmpDBType == DBTypeEnum.Mysql) {
                tmpValue.append("`");
                tmpValue.append(tmpTable.getSourceName());
                tmpValue.append("` ");
            } else {
                tmpValue.append("\"");
                tmpValue.append(tmpTable.getSourceName());
                tmpValue.append("\" ");
            }

            if (tmpTable.getAlias() != null) {
                if (tmpDBType == DBTypeEnum.SqlServer) {
                    tmpValue.append("[");
                    tmpValue.append(tmpTable.getAlias());
                    tmpValue.append("] ");
                } else if (tmpDBType == DBTypeEnum.Mysql) {
                    tmpValue.append("`");
                    tmpValue.append(tmpTable.getAlias());
                    tmpValue.append("` ");
                } else {
                    tmpValue.append("\"");
                    tmpValue.append(tmpTable.getAlias());
                    tmpValue.append("\" ");
                }
            }
        } else {
            SelectTable tmpSelectTable = (SelectTable) f_Table;
            tmpValue.append("( ");
            tmpValue.append(tmpSelectTable.getSqlValue());
            tmpValue.append(" ) ");
            if (tmpSelectTable.getAlias() == null) {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SelectResultAccessWithoutAlias);
            }
            tmpValue.append(tmpSelectTable.getAlias());
        }

        for (JoinTable item : f_Table.getJoinTables()) {
            tmpValue.append(item.getJoinMode());
            tmpValue.append(TableToCode(item.getJoinTable(), f_KuName, f_Lock));
            tmpValue.append(item.privateCondition);
        }
        return tmpValue.toString();
    }

    public static java.lang.String GetOrderByField(java.lang.String f_Value, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectFields, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        String[] tmpArray = f_Value.split("\\.");
        if (tmpArray.length == 1)
        {
            ArrayList<String> tmpComaredNameList = new ArrayList<>();
            AbstractSelectField tmpAliasField = null;
            //可能是别名，可能是字段没加表别名
            for (AbstractSelectField abstractSelectField : f_SelectFields){
                if(Objects.equals(abstractSelectField.getAlias(), f_Value)){
                    tmpAliasField = abstractSelectField;
                    break;
                }
            }
            if (tmpAliasField != null)
            {
                //先找别名
                return f_Value;
            }
            //去各个表里找
            for (AbstractTable item : f_Tables)
            {
                if (item instanceof SelectTable)
                {
                    SelectTable tmpSelectTable = (SelectTable)item;

                    for (AbstractSelectField field : tmpSelectTable.getResultItems())
                    {
                        //找a.*
                        if (field.getAlias() == f_Value)
                        {
                            if(f_DBType == DBTypeEnum.SqlServer){
                                tmpComaredNameList.add("[" + f_Value + "]");
                            }
                            else if(f_DBType == DBTypeEnum.Mysql){
                                tmpComaredNameList.add("`" + f_Value + "`");
                            }
                            else if(f_DBType == DBTypeEnum.Oracle){
                                tmpComaredNameList.add("\"" + f_Value + "\"");
                            }
                            else {
                                tmpComaredNameList.add(f_Value);
                            }
                            continue;
                        }

                        if (field instanceof TableField)
                        {
                            TableField tmpTableField = (TableField)field;
                            IBaseDataSheet tmpDataSheet = tmpTableField.getFieldTable().GetSource();
                            if (tmpDataSheet != null && tmpDataSheet.getComponentDic().containsKey(f_Value) && Objects.equals(tmpDataSheet.getComponentDic().get(f_Value).getName(), tmpTableField.getSelectedField().getName()))
                            {
                                if(f_DBType == DBTypeEnum.SqlServer){
                                    tmpComaredNameList.add("[" + tmpTableField.getSelectedField().getName() + "]");
                                }
                                else if(f_DBType == DBTypeEnum.Mysql){
                                    tmpComaredNameList.add("`" + tmpTableField.getSelectedField().getName() + "`");
                                }
                                else if(f_DBType == DBTypeEnum.Oracle){
                                    tmpComaredNameList.add("\"" + tmpTableField.getSelectedField().getName() + "\"");
                                }                                
                                else {
                                    tmpComaredNameList.add(tmpTableField.getSelectedField().getName());
                                }
                            }
                            continue;
                        }

                        if (field instanceof SelectField)
                        {
                            SelectField tmpSelectField = (SelectField)field;
                            if (Objects.equals(tmpSelectField.Name, f_Value))
                            {
                                if(f_DBType == DBTypeEnum.SqlServer){
                                    tmpComaredNameList.add("[" + f_Value + "]");
                                }
                                else if(f_DBType == DBTypeEnum.Mysql){
                                    tmpComaredNameList.add("`" + f_Value + "`");
                                }
                                else if(f_DBType == DBTypeEnum.Oracle){
                                    tmpComaredNameList.add("\"" + f_Value + "\"");
                                }
                                else {
                                    tmpComaredNameList.add(f_Value);
                                }
                            }
                            continue;
                        }

                        AsteriskField tmpAsterField = (AsteriskField)field;
                        //构件名
                        AbstractSelectField tmpField = FindFieldInAsterFieldReturnNull(f_Value, tmpAsterField, true);
                        if (tmpField != null)
                        {
                            if(f_DBType == DBTypeEnum.SqlServer){
                                tmpComaredNameList.add("[" + f_Value + "]");
                            }
                            else if(f_DBType == DBTypeEnum.Mysql){
                                tmpComaredNameList.add("`" + f_Value + "`");
                            }
                            else if(f_DBType == DBTypeEnum.Oracle){
                                tmpComaredNameList.add("\"" + f_Value + "\"");
                            }
                            else {
                                tmpComaredNameList.add(f_Value);
                            }
                        }
                    }
                }
                else
                {
                    $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable)item;
                    IBaseDataSheet tmpDataSheet = tmpTable.getSheet();
                    $Ku.by.ToolClass.Sql.SqlField tmpField = null;
                    if (!tmpDataSheet.getComponentDic().containsKey(f_Value))
                    {
                        continue;
                    }
                    tmpField = tmpDataSheet.getComponentDic().get(f_Value);
                    if(f_DBType == DBTypeEnum.SqlServer){
                        tmpComaredNameList.add("[" + tmpField.getName() + "]");
                    }
                    else if(f_DBType == DBTypeEnum.Mysql){
                        tmpComaredNameList.add("`" + tmpField.getName() + "`");
                    }
                    else if(f_DBType == DBTypeEnum.Oracle){
                        tmpComaredNameList.add("\"" + tmpField.getName() + "\"");
                    }
                    else {
                        tmpComaredNameList.add(tmpField.getName());
                    }
                }
            }

            if (tmpComaredNameList.size() != 1)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.OrderbyUnClearColumn, f_Value));
            }

            return tmpComaredNameList.get(0);
        }

        if (tmpArray.length == 2)
        {
            //别名.别名或者别名.构件
            String tmpTableAlias = tmpArray[0];
            String tmpFieldAlias = tmpArray[1];
            //直接去找表
            AbstractTable tmpMatchedTable =null;
            for (AbstractTable abstractTable:f_Tables){
                if(abstractTable.getAlias().equals(tmpTableAlias)){
                    tmpMatchedTable =abstractTable;
                }
            }
            if (tmpMatchedTable != null)
            {
                if (tmpMatchedTable instanceof SelectTable)
                {
                    SelectTable tmpSelectTable = (SelectTable) tmpMatchedTable;

                    for (AbstractSelectField item : tmpSelectTable.getResultItems())
                    {
                        if (Objects.equals(item.getAlias(), tmpFieldAlias))
                        {
                            if(f_DBType == DBTypeEnum.SqlServer){
                                return "[" + tmpTableAlias + "].[" + tmpFieldAlias + "]";
                            }
                            else if(f_DBType == DBTypeEnum.Mysql){
                                return "`" + tmpTableAlias + "`.`" + tmpFieldAlias + "`";
                            }
                            else if(f_DBType == DBTypeEnum.Oracle){
                                return "\"" + tmpTableAlias + "\".\"" + tmpFieldAlias + "\"";
                            }
                            else {
                                return tmpTableAlias + "." + tmpFieldAlias;
                            }
                        }

                        if (item instanceof TableField)
                        {
                            TableField tmpTableField = (TableField)item;
                            IBaseDataSheet tmpDataSheet = tmpTableField.getFieldTable().GetSource();
                            if (tmpDataSheet != null && tmpDataSheet.getComponentDic().containsKey(tmpFieldAlias) && Objects.equals(tmpDataSheet.getComponentDic().get(tmpFieldAlias).getName(), tmpTableField.getSelectedField().getName()))
                            {
                                if(f_DBType == DBTypeEnum.SqlServer){
                                    return "[" + tmpTableAlias + "].[" + tmpTableField.getSelectedField().getName() + "]";
                                }
                                else if(f_DBType == DBTypeEnum.Mysql){
                                    return "`" + tmpTableAlias + "`.`" + tmpTableField.getSelectedField().getName() + "`";
                                }
                                else if(f_DBType == DBTypeEnum.Oracle){
                                    return "\"" + tmpTableAlias + "\".\"" + tmpTableField.getSelectedField().getName() + "\"";
                                }
                                else {
                                    return tmpTableAlias + "." + tmpTableField.getSelectedField().getName();
                                }

                            }
                            continue;
                        }

                        if (item instanceof SelectField)
                        {
                            SelectField tmpSelectField = (SelectField)item;
                            if (Objects.equals(tmpSelectField.Name, tmpFieldAlias))
                            {
                                if(f_DBType == DBTypeEnum.SqlServer){
                                    return "[" + tmpTableAlias + "].[" + tmpFieldAlias + "]";
                                }
                                else if(f_DBType == DBTypeEnum.Mysql){
                                    return "`" + tmpTableAlias + "`.`" + tmpFieldAlias + "`";
                                }
                                else if(f_DBType == DBTypeEnum.Oracle){
                                    return "\"" + tmpTableAlias + "\".\"" + tmpFieldAlias + "\"";
                                }
                                else {
                                    return tmpTableAlias + "." + tmpFieldAlias;
                                }
                            }
                            continue;
                        }

                        AsteriskField tmpAsterField = (AsteriskField)item;
                        //构件名
                        AbstractSelectField tmpField = FindFieldInAsterFieldReturnNull(f_Value, tmpAsterField, true);
                        if (tmpField != null)
                        {
                            if (Objects.equals(tmpField.getAlias(), tmpFieldAlias))
                            {
                                if(f_DBType == DBTypeEnum.SqlServer){
                                    return "[" + tmpTableAlias + "].[" + tmpFieldAlias + "]";
                                }
                                else if(f_DBType == DBTypeEnum.Mysql){
                                    return "`" + tmpTableAlias + "`.`" + tmpFieldAlias + "`";
                                }
                                else if(f_DBType == DBTypeEnum.Oracle){
                                    return "\"" + tmpTableAlias + "\".\"" + tmpFieldAlias + "\"";
                                }
                                else {
                                    return tmpTableAlias + "." + tmpFieldAlias;
                                }
                            }
                            TableField tmpTableField = (TableField)tmpField;
                            if(f_DBType == DBTypeEnum.SqlServer){
                                return "[" + tmpTableAlias + "].[" + tmpTableField.getSelectedField().getName() + "]";
                            }
                            else if(f_DBType == DBTypeEnum.Mysql){
                                return "`" + tmpTableAlias + "`.`" + tmpTableField.getSelectedField().getName() + "`";
                            }
                            else if(f_DBType == DBTypeEnum.Oracle){
                                return "\"" + tmpTableAlias + "\".\"" + tmpTableField.getSelectedField().getName() + "\"";
                            }
                            else {
                                return tmpTableAlias + "." + tmpTableField.getSelectedField().getName();
                            }
                        }
                    }
                }
                    else
                {
                    $Ku.by.ToolClass.Sql.SqlTable tmpTable = ($Ku.by.ToolClass.Sql.SqlTable)tmpMatchedTable;
                    //只能是构件
                    IBaseDataSheet tmpDatasheet = tmpTable.getSheet();
                    if (tmpDatasheet.getComponentDic().containsKey(tmpFieldAlias))
                    {
                        if(f_DBType == DBTypeEnum.SqlServer){
                            return "[" + tmpTableAlias + "].[" + tmpDatasheet.getComponentDic().get(tmpFieldAlias).getName() + "]";
                        }
                        else if(f_DBType == DBTypeEnum.Mysql){
                            return "`" + tmpTableAlias + "`.`" + tmpDatasheet.getComponentDic().get(tmpFieldAlias).getName() + "`";
                        }
                        else if(f_DBType == DBTypeEnum.Oracle){
                            return "\"" + tmpTableAlias + "\".\"" + tmpDatasheet.getComponentDic().get(tmpFieldAlias).getName() + "\"";
                        }
                        else {
                            return tmpTableAlias + "." + tmpDatasheet.getComponentDic().get(tmpFieldAlias).getName();
                        }
                    }
                }
            }
        }

        throw $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.OrderbyUnClearColumn, f_Value));
    }

    public static void GenerateOrderBy(java.util.ArrayList<$Ku.by.ToolClass.Sql.OrderByField> f_OrderByList, java.lang.StringBuilder f_OrderBy) {
        if (f_OrderByList.isEmpty())
        {
            return;
        }

        f_OrderBy.append(" order by ");

        for (int i = 0; i < f_OrderByList.size(); i++)
        {
            if (i != 0)
            {
                f_OrderBy.append(", ");
            }

            OrderByField tmpOrderByField = f_OrderByList.get(i);
            f_OrderBy.append(tmpOrderByField.getOField());
            if (tmpOrderByField.getIsDesc())
            {
                f_OrderBy.append(" desc ");
            }
            else
            {
                f_OrderBy.append(" asc ");
            }
        }
    }

    private static void CheckOracleLimitSelectFields(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems) {
        //无别名的查询列名和某个别名冲突会报错
        ArrayList<String> tmpNames = new ArrayList<>();
        ArrayList<String> tmpAliasList = new ArrayList<>();

        for (AbstractSelectField item : f_SelectItems) {
            //先检查带别名的
            if (item.getAlias() == null) {
                continue;
            }

            //不改只加,理论上只用给没加别名的重复字段和表达式加
            String tmpAlias = item.getAlias().toLowerCase();
            if (tmpNames.contains(item.getAlias())) {
                ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.ConflictFields, item.getAlias()));
            }
            tmpNames.add(tmpAlias);
            tmpAliasList.add(tmpAlias);
        }

        for (AbstractSelectField item : f_SelectItems) {
            if (item.getAlias() != null) {
                continue;
            }

            if (item instanceof AsteriskField) {
                continue;
            }

            if (item instanceof TableField) {
                TableField tmpTableField = (TableField) item;
                String tmpName = tmpTableField.getSelectedField().getName();
                if (tmpAliasList.contains(tmpName)) {
                    ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.ConflictFields, tmpName));
                }
            }

            if (item instanceof SelectField) {
                SelectField tmpSelectField = (SelectField) item;
                String tmpName = tmpSelectField.Name;
                if (tmpAliasList.contains(tmpName)) {
                    ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.ConflictFields, tmpName));
                }
            }

            String tmpNewName = "#TmpName" + tmpNames.size();//不会有重名

            if (item instanceof TableField) {
                TableField tmpTableField = (TableField) item;
                tmpTableField.setAlias(tmpNewName);
            } else {
                item.setAlias(tmpNewName);
            }

            tmpNames.add(tmpNewName);
        }
    }

    public static void GetUpdateConfig(java.util.ArrayList<$Ku.by.ToolClass.Source> f_FieldList, $Ku.by.Object.Row f_Row, $Ku.by.ToolClass.Sql.SqlTable f_Table, java.lang.StringBuilder f_Set, java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> f_SetFields, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        String tmpKuName = f_Table.getKuName();
        String tmpSheetName = f_Table.getSourceName();
        if (!Objects.equals(f_Row.getKuName(), tmpKuName)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
        }
        if (!Objects.equals(f_Row.getSheetName(), tmpSheetName)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
        }

        StringBuilder tmpSet = new StringBuilder();

        for (Source tmpFieldSource : f_FieldList) {
            if (f_SetFields.contains(tmpFieldSource.DataSheetField)) {
                continue;
            }

            f_SetFields.add(tmpFieldSource.DataSheetField);

            if (!Objects.equals(tmpFieldSource.DataSheetField.getKuName(), tmpKuName)) {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
            }
            if (!Objects.equals(tmpFieldSource.DataSheetField.getSheetName(), tmpSheetName)) {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
            }
            ArrayList<Cell> tmpMatchedCells = new ArrayList<>();
            for (Cell item : f_Row.cells) {
                if (Objects.equals(item.KuName, tmpKuName) && Objects.equals(item.SheetName, tmpSheetName) && Objects.equals(item.ColumnName, tmpFieldSource.DataSheetField.getName())) {
                    tmpMatchedCells.add(item);
                }
            }
            if (tmpMatchedCells.isEmpty()) {
                ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindCellInRow, tmpFieldSource.DataSheetField.getName()));
            }
            if (tmpMatchedCells.size() > 1) {
                ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.RowHasRepetitiveField, tmpFieldSource.DataSheetField.getName()));
            }
            if (f_DBType == DBTypeEnum.SqlServer) {
                f_Set.append("[").append(tmpFieldSource.DataSheetField.getName()).append("] = ");
            } else if (f_DBType == DBTypeEnum.Mysql) {
                f_Set.append("`").append(tmpFieldSource.DataSheetField.getName()).append("` = ");
            } else {
                f_Set.append("\"").append(tmpFieldSource.DataSheetField.getName()).append("\" = ");
            }

            Object tmpValue = tmpMatchedCells.get(0).value;

            if (tmpValue == null) {
                tmpSet.append(CellValueNullToDefaultReturnString(tmpFieldSource.DataSheetField.getFieldType(), tmpFieldSource.DataSheetField.getEnumType(), f_DBType));
                continue;
            }

            if (tmpValue instanceof Character || tmpValue instanceof String || tmpValue instanceof $Ku.by.Object.Datetime || tmpValue.getClass().isEnum()) {
                if (tmpValue instanceof $Ku.by.Object.Datetime && f_DBType == DBTypeEnum.Oracle) {
                    tmpSet.append("TO_TIMESTAMP(").append(SaveInspect.CharactorEscape(tmpValue.toString())).append(", 'YYYY-MM-DD HH24:MI:SS.FF')");
                } else {
                    tmpSet.append(SaveInspect.CharactorEscape(tmpValue.toString()));
                }
                continue;
            }

            if (tmpValue instanceof Byte || tmpValue instanceof Short || tmpValue instanceof Integer || tmpValue instanceof Long || tmpValue instanceof Float ||
                    tmpValue instanceof Double || tmpValue instanceof Decimal) {
                tmpSet.append(tmpValue);
                continue;
            }

            if (tmpValue instanceof Boolean) {
                Boolean tmpBoolValue = (Boolean) tmpValue;
                tmpSet.append(tmpBoolValue ? 1 : 0);
                continue;
            }

            ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellValueTypeError);
        }

        if (f_Set.length() != 5 && tmpSet.length() != 0) {
            f_Set.append(", ");
        }

        f_Set.append(tmpSet);
    }

    public static void GetInsertConfig(java.util.ArrayList<$Ku.by.ToolClass.Source> f_FieldList, $Ku.by.Object.Row f_Row, $Ku.by.ToolClass.Sql.SqlTable f_Table, java.util.HashMap<$Ku.by.ToolClass.Sql.SqlField, Object> f_InsertValues, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        String tmpKuName = f_Table.getKuName();
        String tmpSheetName = f_Table.getSourceName();

        if (!f_Row.getKuName().equals(tmpKuName)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
        }
        if (!f_Row.getSheetName().equals(tmpSheetName)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
        }
        for (Source fieldSource : f_FieldList) {
            $Ku.by.ToolClass.Sql.SqlField tmpField = fieldSource.DataSheetField;
            if (!tmpField.getKuName().equals(tmpKuName)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
            }
            if (!tmpField.getSheetName().equals(tmpSheetName)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
            }

            if (f_InsertValues.containsKey(tmpField)) {
                continue;
            }

            ArrayList<$Ku.by.Object.Cell> tmpMatchedCells = new ArrayList<>();
            for (Cell item : f_Row.cells) {
                if (tmpKuName.equals(item.KuName) && tmpSheetName.equals(item.SheetName) && tmpField.getName().equals(item.ColumnName)) {
                    tmpMatchedCells.add(item);
                }
            }
            if (tmpMatchedCells.isEmpty()) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindCellInRow, tmpField.getName()));
            }
            if (tmpMatchedCells.size() > 1) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.RowHasRepetitiveField, tmpField.getName()));
            }
            Object tmpCellValue = null;
            tmpCellValue = tmpMatchedCells.get(0).value;
            if (tmpCellValue == null) {
                f_InsertValues.put(tmpField, CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType));
            } else if (tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue instanceof Character || tmpCellValue instanceof
                    String || tmpCellValue.getClass().isEnum()) {
                if (f_DBType == DBTypeEnum.Oracle && tmpCellValue instanceof $Ku.by.Object.Datetime) {
                    f_InsertValues.put(tmpField, "TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.toString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                } else {
                    f_InsertValues.put(tmpField, SaveInspect.CharactorEscape(tmpCellValue.toString()));
                }
            } else if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof
                    Float || tmpCellValue instanceof Double || tmpCellValue instanceof $Ku.by.Object.Decimal) {
                f_InsertValues.put(tmpField, tmpCellValue.toString());
            } else if (tmpCellValue instanceof Boolean) {
                Boolean tmpBool = (Boolean) tmpCellValue;
                f_InsertValues.put(tmpField, tmpBool ? 1 : 0);
            } else {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.UnKnowType);//未知类型
            }
        }
    }

    public static void GetInsertConfig(java.util.ArrayList<$Ku.by.ToolClass.Source> f_FieldList, $Ku.by.Object.List<$Ku.by.Object.Row> f_Rows, $Ku.by.ToolClass.Sql.SqlTable f_Table, java.util.HashMap<$Ku.by.ToolClass.Sql.SqlField, Object> f_InsertValues, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        String tmpKuName = f_Table.getKuName();
        String tmpSheetName = f_Table.getSourceName();

        for (Source source : f_FieldList) {
            SqlField tmpField = source.DataSheetField;
            if (!tmpField.getKuName().equals(tmpKuName)) {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
            }
            if (!tmpField.getSheetName().equals(tmpSheetName)) {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
            }
            if (f_InsertValues.containsKey(tmpField)) {
                continue;
            }
            for ($Ku.by.Object.Row tmpRow : f_Rows) {
                if (!tmpRow.getKuName().equals(tmpKuName)) {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }
                if (!tmpRow.getSheetName().equals(tmpSheetName)) {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                ArrayList<Cell> tmpMatchedCells = new ArrayList<>();
                for (Cell item : tmpRow.cells) {
                    if (tmpKuName.equals(item.KuName) && tmpSheetName.equals(item.SheetName) && tmpField.getName().equals(item.ColumnName)) {
                        tmpMatchedCells.add(item);
                    }
                }
                Object tmpCellValue = null;
                if (tmpMatchedCells.isEmpty()) {
                    ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindCellInRow, tmpField.getName()));
                }
                if (tmpMatchedCells.size() > 1) {
                    ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.RowHasRepetitiveField, tmpField.getName()));
                }
                tmpCellValue = tmpMatchedCells.get(0).value;
                if (!f_InsertValues.containsKey(tmpField)) {
                    f_InsertValues.put(tmpField, new $Ku.by.Object.List<>($ClassMessageUtil.get(Object.class)));
                }
                ArrayList<Object> tmpValue = (ArrayList<Object>) f_InsertValues.get(tmpField);
                if (tmpValue == null) {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.DifferentParameterOfInsert);
                }

                if (tmpCellValue == null) {
                    tmpValue.add(CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType));
                } else if (tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue instanceof Character || tmpCellValue instanceof String || tmpCellValue.getClass().isEnum()) {
                    if (tmpCellValue instanceof $Ku.by.Object.Datetime && f_DBType == DBTypeEnum.Oracle) {
                        tmpValue.add("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.toString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                    } else {
                        tmpValue.add(SaveInspect.CharactorEscape(tmpCellValue.toString()));
                    }
                } else if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof Float || tmpCellValue instanceof Double || tmpCellValue instanceof $Ku.by.Object.Decimal) {
                    tmpValue.add(tmpCellValue.toString());
                } else if (tmpCellValue instanceof Boolean) {
                    Boolean tmpBool = (Boolean) tmpCellValue;
                    tmpValue.add(tmpBool ? 1 : 0);
                } else {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.UnKnowType);//未知类型
                }
            }
        }
    }

    public static void GetInsertConfig(java.util.ArrayList<$Ku.by.ToolClass.Source> f_FieldList, $Ku.by.Object.Row[] f_Rows, $Ku.by.ToolClass.Sql.SqlTable f_Table, java.util.HashMap<$Ku.by.ToolClass.Sql.SqlField, Object> f_InsertValues, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        String tmpKuName = f_Table.getKuName();
        String tmpSheetName = f_Table.getSourceName();

        for (Source source : f_FieldList) {
            SqlField tmpField = source.DataSheetField;
            if (!tmpField.getKuName().equals(tmpKuName)) {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
            }
            if (!tmpField.getSheetName().equals(tmpSheetName)) {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.CellIdentityNotMatchSheet);
            }
            if (f_InsertValues.containsKey(tmpField)) {
                continue;
            }
            for ($Ku.by.Object.Row tmpRow : f_Rows) {
                if (!tmpRow.getKuName().equals(tmpKuName)) {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }
                if (!tmpRow.getSheetName().equals(tmpSheetName)) {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
                }

                ArrayList<Cell> tmpMatchedCells = new ArrayList<>();
                for (Cell item : tmpRow.cells) {
                    if (tmpKuName.equals(item.KuName) && tmpSheetName.equals(item.SheetName) && tmpField.getName().equals(item.ColumnName)) {
                        tmpMatchedCells.add(item);
                    }
                }
                Object tmpCellValue = null;
                if (tmpMatchedCells.isEmpty()) {
                    ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindCellInRow, tmpField.getName()));
                }
                if (tmpMatchedCells.size() > 1) {
                    ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.RowHasRepetitiveField, tmpField.getName()));
                }
                tmpCellValue = tmpMatchedCells.get(0).value;
                if (!f_InsertValues.containsKey(tmpField)) {
                    f_InsertValues.put(tmpField, new $Ku.by.Object.List<>($ClassMessageUtil.get(Object.class)));
                }
                ArrayList<Object> tmpValue = (ArrayList<Object>) f_InsertValues.get(tmpField);
                if (tmpValue == null) {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.DifferentParameterOfInsert);
                }

                if (tmpCellValue == null) {
                    tmpValue.add(CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType));
                } else if (tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue instanceof Character || tmpCellValue instanceof String || tmpCellValue.getClass().isEnum()) {
                    if (tmpCellValue instanceof $Ku.by.Object.Datetime && f_DBType == DBTypeEnum.Oracle) {
                        tmpValue.add("TO_TIMESTAMP(" + SaveInspect.CharactorEscape(tmpCellValue.toString()) + ", 'YYYY-MM-DD HH24:MI:SS.FF')");
                    } else {
                        tmpValue.add(SaveInspect.CharactorEscape(tmpCellValue.toString()));
                    }
                } else if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof Float || tmpCellValue instanceof Double || tmpCellValue instanceof $Ku.by.Object.Decimal) {
                    tmpValue.add(tmpCellValue.toString());
                } else if (tmpCellValue instanceof Boolean) {
                    Boolean tmpBool = (Boolean) tmpCellValue;
                    tmpValue.add(tmpBool ? 1 : 0);
                } else {
                    ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.UnKnowType);//未知类型
                }
            }
        }
    }

    public static void GetInsertComponentInRow(java.lang.String f_Component, $Ku.by.Object.Row f_Row, $Ku.by.ToolClass.Sql.SqlTable f_Table, java.util.LinkedHashMap<$Ku.by.ToolClass.Sql.SqlField, Object> f_InsertValues) {
        String tmpKuName = f_Table.getKuName();
        String tmpSheetName = f_Table.getSourceName();
        if (!f_Row.getKuName().equals(tmpKuName))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
        }
        if (!f_Row.getSheetName().equals(tmpSheetName))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIdentityNotMatchSheet);
        }
        $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = f_Table.getSheet();
        $Ku.by.ToolClass.Sql.SqlField tmpField = null;
        if ((tmpField = tmpDataSheet.getComponentDic().get(f_Component)) == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.getSheetName(), f_Component));
        }
        if (f_InsertValues.containsKey(tmpField))
        {
            //说明已经填过
            return;
        }
        Iterator<$Ku.by.Object.Cell> iterator = f_Row.cells.iterator();
        ArrayList<$Ku.by.Object.Cell> tmpMatchedCells = new ArrayList<>();
        while (iterator.hasNext()){
            $Ku.by.Object.Cell item = iterator.next();
            if (tmpKuName.equals(item.KuName) && tmpSheetName.equals(item.SheetName) && tmpField.getName().equals(item.ColumnName)){
                tmpMatchedCells.add(item);
            }
        }
        //var tmpMatchedCells = f_Row.cells.FindAll(item => tmpKuName.equals(item.KuName) && tmpSheetName.equals(item.SheetName) && tmpField.getName().equals(item.ColumnName));
        if (tmpMatchedCells.size() == 0)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.CanNotFindCellInRow, tmpField.getName()));
        }
        if (tmpMatchedCells.size() > 1)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.RowHasRepetitiveField, tmpField.getName()));
        }
        if (f_InsertValues.containsKey(tmpField))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.InsertFieldConflict, tmpField.getName()));
        }
        f_InsertValues.put(tmpField, tmpMatchedCells.get(0).value);
    }

    private static void FillAsterFieldForLimit(java.lang.StringBuilder f_SqlSB, $Ku.by.ToolClass.Sql.AsteriskField f_AsterField, java.lang.String f_TemeroaryName) {
        for (int i = 0; i < f_AsterField.getFieldList().size(); i++)
        {
            if (i != 0)
            {
                f_SqlSB.append(", ");
            }
            AbstractSelectField tmpField = f_AsterField.getFieldList().get(i);
            if (tmpField instanceof AsteriskField)
            {

                AsteriskField tmpAsterField = (AsteriskField) tmpField;
                FillAsterFieldForLimit(f_SqlSB, tmpAsterField, f_TemeroaryName);
                continue;
            }
            f_SqlSB.append(f_TemeroaryName);
            f_SqlSB.append(".");
            if (tmpField.getAlias() != null)
            {
                f_SqlSB.append(tmpField.getAlias());
                continue;
            }

            TableField tmpTableField = (TableField)((tmpField instanceof TableField) ? tmpField : null);
            if (tmpTableField == null)
            {
                throw new RuntimeException(String.format(ErrorInfo.LimitFieldNotNamed, tmpField.getSelectItemDeclare()));
            }
            f_SqlSB.append("[").append(tmpTableField.getSelectedField().getName()).append("]");
        }
    }

    public static $Ku.by.Object.Cell GetRowComponent($Ku.by.Object.Row f_Row, java.lang.String f_Component) {
        try{
            $Ku.by.ToolClass.IBaseDataSheet tmpDataSheet = GetDataSheet(f_Row.getKuName(), f_Row.getSheetName());
            Class<?> tmpIdentityType = f_Row.$Identity.getClass();
            String tmpIdentityName = tmpIdentityType.getSimpleName();
            String tmpIdentityNS = tmpIdentityType.getName(); //$Ku.kuname.Identity.identityName

            String[] tmpArray = tmpIdentityNS.split("[.]", -1);
            if (tmpArray.length != 4) {
                $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(ErrorInfo.IdentityNameSpaceError);
            }
            String tmpQualifiedName = tmpArray[1] + "." + tmpIdentityName;
            if (!tmpDataSheet.getIdentityName().equals(tmpQualifiedName)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(ErrorInfo.RowIdentityError);
            }
            if (!tmpDataSheet.getComponentDic().containsKey(f_Component)) {
                $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.getSheetName(), f_Component));
            }
            $Ku.by.ToolClass.Sql.SqlField tmpField = tmpDataSheet.getComponentDic().get(f_Component);
            $Ku.by.Object.Cell tmpCell = f_Row.getItem(tmpField.getName());
            if (tmpCell.value == null) {
                switch (tmpField.getFieldType()) {
                    case Byte:
                    case Decimal:
                    case Double:
                    case Float:
                    case Int:
                    case Long:
                    case Short:
                        tmpCell.value = 0;
                        break;
                    case Bool:
                        tmpCell.value = false;
                        break;
                    case Char:
                        tmpCell.value = '\0';
                        break;
                    case Datetime:
                        tmpCell.value = new $Ku.by.Object.Datetime();
                        break;
                    case String:
                        tmpCell.value = "";
                        break;
                    case Enum:
                        Class<?> tmpEnumType = tmpField.getEnumType();
                        Enum<?>[] tmpEnumValues = (Enum<?>[]) tmpEnumType.getEnumConstants();
                        if (tmpEnumValues.length == 0) {
                            tmpCell.value = tmpEnumType.newInstance();
                        } else {
                            tmpCell.value = tmpEnumValues[0];
                        }
                        break;
                }
            }
            if (tmpCell.DataTypeEnum == DataTypeEnum.None)
            {
                tmpCell.DataTypeEnum = tmpField.getFieldType();
                tmpCell.EnumType = tmpField.getEnumType();
            }
            return tmpCell;
        } catch (java.lang.Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    public static java.lang.String lTrim(java.lang.String str) {
        int len = str.length();
        int st = 0;
        char[] val = str.toCharArray();    /* avoid getfield opcode */

        while ((st < len) && (val[st] <= ' ')) {
            st++;
        }

        return ((st > 0)) ? str.substring(st, len) : str;
    }

    public static java.lang.String rTrim(java.lang.String str) {
        int len = str.length();
        int st = 0;
        char[] val = str.toCharArray();    /* avoid getfield opcode */

        while ((st < len) && (val[len - 1] <= ' ')) {
            len--;
        }
        return ((len < str.length())) ? str.substring(st, len) : str;
    }

    public static java.lang.Boolean FieldHasReference($Ku.by.ToolClass.BaseKu f_Ku, java.lang.String f_QualifiedName1, java.lang.String f_QualifiedName2) {
        String[] tmpArray1 = f_QualifiedName1.split("\\.");
        String[] tmpArray2 = f_QualifiedName2.split("\\.");

        if(tmpArray1.length != 2 || tmpArray2.length != 2){
            return false;
        }

        String tmpSheetName1 = tmpArray1[0];
        String tmpSheetName2 = tmpArray2[0];
        String tmpColName1 = tmpArray1[1];
        String tmpColName2 = tmpArray2[1];

        if(f_Ku.RelationDic.containsKey(tmpSheetName1)){
            ArrayList<SheetRelation> tmpList = f_Ku.RelationDic.get(tmpSheetName1);
            if(tmpList.stream().anyMatch(element -> element.ReferencedSheet.equals(tmpSheetName2) && element.ReferencedFieldName.equals(tmpColName2))){
                return true;
            }
        }

        if(f_Ku.RelationDic.containsKey(tmpSheetName2)){
            ArrayList<SheetRelation> tmpList = f_Ku.RelationDic.get(tmpSheetName2);
            if(tmpList.stream().anyMatch(element -> element.ReferencedSheet.equals(tmpSheetName1) && element.ReferencedFieldName.equals(tmpColName1))){
                return true;
            }
        }
        return false;
    }

    public static java.lang.Boolean RowRelationEqualRow($Ku.by.Object.Row f_Row1, $Ku.by.Object.Row f_Row2) {
        if(f_Row1 == null || f_Row2 == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowIsNull);
        }
        if(!Objects.equals(f_Row1.getKuName(), f_Row2.getKuName())){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }
        ArrayList<$Ku.by.Object.Cell> tmpDifferentCells1 = new ArrayList<>();
        ArrayList<String> tmpColumnNames1 = new ArrayList<>();
        ArrayList<$Ku.by.Object.Cell> tmpDifferentCells2 = new ArrayList<>();
        ArrayList<String> tmpColumnNames2 = new ArrayList<>();

        for($Ku.by.Object.Cell item : f_Row1.getcells()){
            if(!Objects.equals(item.getKuName(), f_Row1.getKuName())){
                continue;
            }
            String tmpQualifiedName = item.getSheetName() + "." + item.ColumnName;
            if(tmpColumnNames1.contains(tmpQualifiedName)){
                continue;
            }
            tmpColumnNames1.add(tmpQualifiedName);
            tmpDifferentCells1.add(item);
        }

        for($Ku.by.Object.Cell item : f_Row2.getcells()){
            if(!Objects.equals(item.getKuName(), f_Row2.getKuName())){
                continue;
            }
            String tmpQualifiedName = item.getSheetName() + "." + item.ColumnName;
            if(tmpColumnNames2.contains(tmpQualifiedName)){
                continue;
            }
            tmpColumnNames2.add(tmpQualifiedName);
            tmpDifferentCells2.add(item);
        }

        BaseKu tmpKu = Root.GetInstance().get(f_Row1.getKuName());
        String tmpSheetName1 = f_Row1.getSheetName();
        String tmpSheetName2 = f_Row2.getSheetName();

        if(tmpSheetName1.equals(tmpSheetName2)){
           IBaseDataSheet tmpDataSheet = tmpKu.DataSheetDic.get(tmpSheetName1);

           for($Ku.by.ToolClass.Sql.SqlField item : tmpDataSheet.getPrimaryKeyList()){
               String tmpColumnName = item.getName();
               $Ku.by.Object.Cell tmpCell1 = tmpDifferentCells1.stream().filter(cell -> cell.ColumnName.equals(tmpColumnName)).findFirst().orElse(null);
               $Ku.by.Object.Cell tmpCell2 = tmpDifferentCells2.stream().filter(cell -> cell.ColumnName.equals(tmpColumnName)).findFirst().orElse(null);
               if(tmpCell1 == null || tmpCell2 == null){
                   return false;
               }

               if(tmpCell1.value == null || tmpCell2.value == null){
                   return false;
               }

               if(!Objects.equals(tmpCell1.value, tmpCell2.value)){
                   return false;
               }
           }
           return true;
        }

        boolean tmpHasReferencedField = false;

        for($Ku.by.Object.Cell cell1 : tmpDifferentCells1){
            String tmpCellQualifiedName1 = cell1.getSheetName() + "." + cell1.ColumnName;
            for($Ku.by.Object.Cell cell2 : tmpDifferentCells2){
                String tmpCellQualifiedName2 = cell2.getSheetName() + "." + cell2.ColumnName;
                if(FieldHasReference(tmpKu, tmpCellQualifiedName1, tmpCellQualifiedName2)){
                    tmpHasReferencedField = true;
                    if(!Objects.equals(cell1.value, cell2.value)){
                        return false;
                    }
                }
            }
        }

        return tmpHasReferencedField;
    }

    public static java.lang.Boolean RowComponentRelationEqualRow($Ku.by.Object.Row f_ComponentRow, $Ku.by.Object.Row f_Row, java.lang.String f_Component) {
        if(f_Row == null || f_ComponentRow == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
        }

        if (!Objects.equals(f_ComponentRow.getKuName(), f_Row.getKuName()))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }

        BaseKu tmpKu = Root.GetInstance().get(f_Row.getKuName());
        IBaseDataSheet tmpDataSheet = GetDataSheet(tmpKu.Name, f_ComponentRow.getSheetName());

        if(!tmpDataSheet.getComponentDic().containsKey(f_Component)){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.getSheetName(), f_Component));
        }

        $Ku.by.ToolClass.Sql.SqlField tmpField = tmpDataSheet.getComponentDic().get(f_Component);
        String tmpComponentQualifiedName = tmpKu.Name + "." + tmpField.getSheetName() + "." + tmpField.getName();
        $Ku.by.Object.Cell tmpCell = f_ComponentRow.getItem(tmpComponentQualifiedName);

        if(tmpCell.DataTypeEnum == DataTypeEnum.None){
            tmpCell.DataTypeEnum = tmpField.getFieldType();
            tmpCell.EnumType = tmpField.getEnumType();
        }
        String tmpCellQualifiedName = tmpCell.getSheetName() + "." + tmpCell.ColumnName;

        for($Ku.by.Object.Cell item : f_Row.getcells()){
            if(!Objects.equals(item.getKuName(), tmpKu.Name)){
                continue;
            }
            String tmpQualifiedName = item.getSheetName() + "." + item.ColumnName;
            if(FieldHasReference(tmpKu, tmpCellQualifiedName, tmpQualifiedName)){
                return Objects.equals(item.value, tmpCell.value);
            }
        }
        return false;
    }

    public static void RowRelationAssignRow($Ku.by.Object.Row f_Row1, $Ku.by.Object.Row f_Row2) {
        if(f_Row1 == null || f_Row2 == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
        }
        if (!Objects.equals(f_Row1.getKuName(), f_Row2.getKuName()))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }

        BaseKu tmpKu = Root.GetInstance().get(f_Row1.getKuName());
        ArrayList<$Ku.by.Object.Cell> tmpDifferentCells = new ArrayList<>();
        ArrayList<String> tmpColumnNames = new ArrayList<>();

        for($Ku.by.Object.Cell item : f_Row2.cells){
            if(!Objects.equals(item.KuName, tmpKu.Name)){
                continue;
            }
            String tmpQualifiedColumnName = item.getSheetName() + "." + item.ColumnName;

            if(tmpColumnNames.contains(tmpQualifiedColumnName)){
                continue;
            }
            tmpColumnNames.add(tmpQualifiedColumnName);
            tmpDifferentCells.add(item);
        }

        for($Ku.by.Object.Cell item : f_Row1.cells){
            if(!Objects.equals(item.KuName, tmpKu.Name)){
                continue;
            }
            String tmpQualifiedName = item.getSheetName() + "." + item.ColumnName;
            for($Ku.by.Object.Cell element : tmpDifferentCells){
                String tmpCellQualifiedName = element.getSheetName() + "." + element.ColumnName;
                if(FieldHasReference(tmpKu, tmpQualifiedName, tmpCellQualifiedName)){
                    item.value = element.value;
                }
                if(tmpCellQualifiedName.equals(tmpQualifiedName)){
                    item.value = element.value;
                }

            }

        }
    }

    public static void RowRelationAssignRowComponent($Ku.by.Object.Row f_Row, $Ku.by.Object.Row f_ComponentRow, java.lang.String f_Component) {
        if(f_Row == null || f_ComponentRow == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
        }

        if(!Objects.equals(f_ComponentRow.getKuName(), f_Row.getKuName())){
            $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(ErrorInfo.DifferentKuInRelationExpression);
        }
        BaseKu tmpKu = Root.GetInstance().get(f_ComponentRow.getKuName());
        IBaseDataSheet tmpDataSheet = GetDataSheet(tmpKu.Name, f_ComponentRow.getSheetName());
        if(!tmpDataSheet.getComponentDic().containsKey(f_Component)){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.getSheetName(), f_Component));
        }
        $Ku.by.ToolClass.Sql.SqlField tmpField = tmpDataSheet.getComponentDic().get(f_Component);
        String tmpComponentQualifiedName = tmpKu.Name + "." + f_ComponentRow.getSheetName() + "." + tmpField.getName();
        $Ku.by.Object.Cell tmpCell = f_ComponentRow.getItem(tmpComponentQualifiedName);
        if(tmpCell.value == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CanNotAssignmentNullToRowValue);
        }

        if(tmpCell.DataTypeEnum == DataTypeEnum.None){
            tmpCell.DataTypeEnum = tmpField.getFieldType();
            tmpCell.EnumType = tmpField.getEnumType();
        }

        String tmpCellQualifiedName = tmpCell.SheetName + "." + tmpCell.ColumnName;
        for($Ku.by.Object.Cell item : f_Row.cells){
            if(item.KuName ==null || !item.KuName.equals(tmpKu.Name)){
                continue;
            }
            String tmpQualifiedName = item.SheetName + "." + item.ColumnName;

            if(FieldHasReference(tmpKu, tmpCellQualifiedName, tmpQualifiedName)){
                item.value = tmpCell.value;
            }

            if(tmpQualifiedName.equals(tmpCellQualifiedName)){
                item.value = tmpCell.value;
            }

        }
    }

    public static void RowComponentRelationAssignRow($Ku.by.Object.Row f_ComponentRow, $Ku.by.Object.Row f_Row, java.lang.String f_Component) {
        if (Objects.equals(f_Row.getKuName(), f_ComponentRow.getKuName())){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }
        $Ku.by.ToolClass.BaseKu tmpKu = Root.GetInstance().get(f_Row.getKuName());
        String tmpSheet1 = f_ComponentRow.getSheetName();
        IBaseDataSheet tmpDataSheet = GetDataSheet(tmpKu.Name,tmpSheet1);
        if (!tmpDataSheet.getComponentDic().containsKey(f_Component)){
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(String.format(ErrorInfo.CanNotFindComponentInSheet,tmpDataSheet.getSheetName(),f_Component));
        }
        $Ku.by.ToolClass.Sql.SqlField tmpField = tmpDataSheet.getComponentDic().get(f_Component);
        Optional<$Ku.by.Object.Cell> from = f_ComponentRow.cells.stream().filter(item->item.SheetName.equals(tmpField.getSheetName())&&item.ColumnName.equals(tmpField.getName())).findFirst();
        if (from.isPresent()){
            for ($Ku.by.Object.Cell to: f_Row.cells){
                if (to.SheetName.equals(tmpField.getSheetName())&&to.ColumnName.equals(tmpField.getName())){
                    from.get().value  = to.value;
                    break;
                }
            }
        }
        else {
            throw new RuntimeException("component " + f_Component + " 不存在!");
        }
    }

    public static java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> CopyRowsArray(java.util.List<$Ku.by.Object.Row>[] f_RowsArray) {
        if (f_RowsArray == null)
        {
            return null;
        }
        java.util.ArrayList<java.util.List<$Ku.by.Object.Row>> tmpNewRows = new java.util.ArrayList<java.util.List<$Ku.by.Object.Row>>();
        for (java.util.List<$Ku.by.Object.Row> item : f_RowsArray)
        {
            tmpNewRows.add(CopyRows(item));
        }
        return tmpNewRows;
    }

    public static java.lang.String TableRelationEqualTable($Ku.by.ToolClass.Sql.SqlTable f_LeftTable, $Ku.by.ToolClass.Sql.SqlTable f_RightTable, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_LeftTable == null || f_RightTable == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.TableIsNull);
        }
        if (!Objects.equals(f_LeftTable.getKuName(), f_RightTable.getKuName()))
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.DifferentKuInRelationExpression);
        }

        BaseKu tmpKu = GetKu(f_LeftTable.getKuName());
        StringBuilder tmpSqlExpression = new StringBuilder();
        StringBuilder tmpLeft = new StringBuilder();
        StringBuilder tmpRight = new StringBuilder();

        if (f_LeftTable.getAlias() != null)
        {
            tmpLeft.append(f_LeftTable.getAlias()).append(".");
        }
        else
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(f_LeftTable.getSourceName()).append("].");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(f_LeftTable.getSourceName()).append("`.");
            }
            else{
                tmpLeft.append("").append(f_LeftTable.getSourceName()).append(".");
            }
        }

        if (f_RightTable.getAlias() != null)
        {
            tmpRight.append(f_RightTable.getAlias()).append(".");
        }
        else
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpRight.append("[").append(f_RightTable.getSourceName()).append("].");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpRight.append("`").append(f_RightTable.getSourceName()).append("`.");
            }
            else{
                tmpRight.append("").append(f_RightTable.getSourceName()).append(".");
            }
        }

        if (Objects.equals(f_LeftTable.getSheet().getSheetName(), f_RightTable.getSheet().getSheetName()))
        {
            String tmpLeftTableValue = tmpLeft.toString();
            String tmpRightTableValue = tmpRight.toString();

            for (int i = 0; i < f_LeftTable.GetSource().getPrimaryKeyList().size(); i++)
            {
                if (i != 0)
                {
                    tmpSqlExpression.append(" and ");
                }

                $Ku.by.ToolClass.Sql.SqlField tmpPrimaryField = f_LeftTable.GetSource().getPrimaryKeyList().get(i);
                String tmpColumnName = tmpPrimaryField.getName();
                if (f_DBType == DBTypeEnum.SqlServer)
                {
                    tmpSqlExpression.append(String.format("%1$s[%2$s] = %3$s[%2$s]", tmpLeftTableValue, tmpColumnName, tmpRightTableValue));
                }
                else if(f_DBType == DBTypeEnum.Mysql)
                {
                    tmpSqlExpression.append(String.format("%1$s`%2$s` = %3$s`%2$s`", tmpLeftTableValue, tmpColumnName, tmpRightTableValue));
                }
                else{
                    tmpSqlExpression.append(String.format("%1$s%2$s = %3$s%2$s", tmpLeftTableValue, tmpColumnName, tmpRightTableValue));
                }
            }
            return tmpSqlExpression.toString();
        }
        
        ArrayList<SheetRelation> tmpRelations = FindReferenceRelationBetweenSheet(tmpKu, f_LeftTable.getSourceName(), f_RightTable.getSourceName());
        SheetRelation tmpRelation = tmpRelations.get(0);
        
        if (Objects.equals(f_LeftTable.getSourceName(), tmpRelation.ReferencedSheet))
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(tmpRelation.getReferencedFieldName()).append("] = ");
                tmpRight.append("[").append(tmpRelation.getReferenceFieldName()).append("]");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(tmpRelation.ReferencedFieldName).append("` = ");
                tmpRight.append("`").append(tmpRelation.ReferenceFieldName).append("`");
            }
            else{
                tmpLeft.append(tmpRelation.ReferencedFieldName).append(" = ");
                tmpRight.append(tmpRelation.ReferenceFieldName);
            }
        }
        else
        {
            if (f_DBType == DBTypeEnum.SqlServer)
            {
                tmpLeft.append("[").append(tmpRelation.getReferenceFieldName()).append("] = ");
                tmpRight.append("[").append(tmpRelation.getReferencedFieldName()).append("]");
            }
            else if(f_DBType == DBTypeEnum.Mysql)
            {
                tmpLeft.append("`").append(tmpRelation.ReferenceFieldName).append("` = ");
                tmpRight.append("`").append(tmpRelation.ReferencedFieldName).append("`");
            }
            else{
                tmpLeft.append(tmpRelation.ReferenceFieldName).append(" = ");
                tmpRight.append(tmpRelation.ReferencedFieldName);
            }
        }
        tmpSqlExpression.append(tmpLeft);
        tmpSqlExpression.append(tmpRight);
        return tmpSqlExpression.toString();
    }

    public static void MergeSelectItem(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_Merged) {
        for (AbstractSelectField item : f_SelectItems)
        {
            if(item instanceof AsteriskField){
                AsteriskField tmpField = (AsteriskField) item;
                f_Merged.addAll(tmpField.getFieldList());
            }
            else if (item instanceof PlusField) {
                PlusField tmpPlusField = (PlusField) item;
                f_Merged.addAll(tmpPlusField.getFieldList());
            } else {
                f_Merged.add(item);
            }
        }
    }

    public static java.lang.String NotEqualExpression(Object f_Left, Object f_Right) {
        if (f_Left != null && f_Left.toString() != "NULL" && f_Right != null && f_Right.toString() != "NULL") {
            return f_Left + " != " + f_Right;
        }
        if ((f_Right == null || f_Right.toString() == "NULL") && (f_Left == null || f_Left.toString() == "NULL")) {
            return "NULL IS NOT NULL";
        }
        if (f_Right == null || f_Right.toString() == "NULL") {
            return f_Left + " IS NOT NULL";
        } else {
            return f_Right + " IS NOT NULL";
        }
    }

    public static java.lang.String UnaryExpression(java.lang.String f_Operator, Object f_Value) {
        if (f_Value == null){
            return null;
        }
        return f_Operator + f_Value.toString();
    }

    public static java.lang.String OracleBitNot(java.lang.String f_Value) {
        if (f_Value == null)
        {
            return "null";
        }

        return "((0 - (" + f_Value + ")) - 1)";
    }

    public static java.lang.String BinaryExpression(Object f_Left, java.lang.String f_Operator, Object f_Right) {
        StringBuilder tmpValue = new StringBuilder();
        if (f_Left == null)
        {
            tmpValue.append("null");
        }
        else
        {
            tmpValue.append(f_Left);
        }

        tmpValue.append(f_Operator);

        if(f_Right == null)
        {
            tmpValue.append("null");
        }
        else
        {
            tmpValue.append(f_Right);
        }

        return tmpValue.toString();
    }

    private static <T> T[] GenerateOneDimDefaultArray(Class<T> $t, int size, Object defaultValue) {
        T[] array = (T[]) Array.newInstance($t, size);
        Arrays.fill(array, defaultValue);
        return array;
    }

    public static <T> T GenerateDefaultArray(Class<T> $t, int[] sizes, Object defaultValue) {
        Class tmp = $t;
        while (tmp.isArray()){
            tmp = tmp.getComponentType();
        }

        for(int dimCount = sizes.length - 1; dimCount >= 0; dimCount--){
            defaultValue = GenerateOneDimDefaultArray(tmp, sizes[dimCount], defaultValue);
            tmp = defaultValue.getClass();
        }

        return (T)defaultValue;
    }

    public static $Ku.by.ToolClass.AbstractIdentityBase GetByObjectIdentity(Object obj) {
        if(obj == null){
            return null;
        }
        java.lang.reflect.Field[] tmpProps = obj.getClass().getFields();
        for (java.lang.reflect.Field item : tmpProps)
        {
            if (item.getName().equals("$Identity"))
            {
                Object tmpPropInstance = null;
                try {
                    tmpPropInstance = item.get(obj);
                    return ($Ku.by.ToolClass.AbstractIdentityBase)tmpPropInstance;
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
            }
        }
        throw new RuntimeException(obj.getClass().toString() + " 不是复合身份类型");
    }

    public static boolean CheckSpecificTableSource(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableSouces) {
        if (f_TableSouces.size() != 1)
            {
                return false;
            }

            if (f_TableSouces.get(0) == null)
            {
                return false;
            }

            return true;
    }

    public static java.lang.String EqualExpression(Object f_Left, Object f_Right) {
        if (f_Left != null && f_Left.toString() != "NULL" && f_Right != null && f_Right.toString() != "NULL") {
            return f_Left + " = " + f_Right;
        }

        if ((f_Right == null || f_Right.toString() == "NULL") && (f_Left == null || f_Left.toString() == "NULL")) {
            return "NULL IS NULL";
        }

        if (f_Right == null || f_Right.toString() == "NULL") {
            return f_Left + " IS NULL";
        } else {
            return f_Right + " IS NULL";
        }
    }

    public static $Ku.by.ToolClass.Sql.OrderByField GetOrderByFieldWithLimit(java.lang.String f_Value, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectFields, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_Tables, boolean f_IsDesc) {
        String[] tmpArray = f_Value.split("\\.");
        ArrayList<AbstractSelectField> tmpCompared = new ArrayList<>();
        AbstractSelectField tmpAliasMatchedField = f_SelectFields.stream()
                .filter(item -> item.getAlias() != null && item.getAlias().equals(f_Value))
                .findFirst()
                .orElse(null);
        if (tmpArray.length == 1) {
            // 可能是别名，可能是构件名，可能会有列名不明确的情况
            // 全部遍历
            for (AbstractTable item : f_Tables) {
                GetTableFieldInTableLength1(f_Value, item, tmpCompared, true);
                if (tmpCompared.size() > 1) {
                    throw new SqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_Value));
                }
            }

            if (tmpAliasMatchedField != null && !tmpCompared.isEmpty()) {
                throw new SqlPreCompileException(String.format(ErrorInfo.OrderbyUnClearColumn, f_Value));
            }

            if (tmpAliasMatchedField == null && tmpCompared.isEmpty()) {
                throw new SqlPreCompileException(String.format(ErrorInfo.OrderbyUnClearColumn, f_Value));
            }

            if (tmpAliasMatchedField != null) {
                return new OrderByField(f_Value, f_IsDesc, tmpAliasMatchedField);
            } else {
                return new OrderByField(null, f_IsDesc, tmpCompared.get(0));
            }
        }

        if (tmpArray.length == 2) {
            String tmpTableSourceAlias = tmpArray[0];
            String tmpFieldAlias = tmpArray[1];
            AbstractTable tmpTable = f_Tables.stream()
                    .filter(item -> item.getAlias().equals(tmpTableSourceAlias))
                    .findFirst()
                    .orElse(null);

            if (tmpTable == null) {
                throw new SqlPreCompileException(String.format(ErrorInfo.OrderbyUnClearColumn, f_Value));
            }

            GetTableFieldInTableLength2(tmpTableSourceAlias, tmpFieldAlias, tmpTable, tmpCompared, true);

            if (tmpAliasMatchedField != null && !tmpCompared.isEmpty()) {
                throw new SqlPreCompileException(String.format(ErrorInfo.OrderbyUnClearColumn, f_Value));
            }

            if (tmpAliasMatchedField == null && tmpCompared.isEmpty()) {
                throw new SqlPreCompileException(String.format(ErrorInfo.OrderbyUnClearColumn, f_Value));
            }

            if (tmpCompared.size() > 1) {
                throw new SqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_Value));
            }

            if (tmpAliasMatchedField != null) {
                throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("未知的orderby错误");
            } else {
                return new OrderByField(null, f_IsDesc, tmpCompared.get(0));
            }
        }

        throw new SqlPreCompileException(String.format(ErrorInfo.UnClearColumnName, f_Value));
    }

    public static java.lang.String SetAssignmentExpression($Ku.by.ToolClass.Sql.TableField f_TableField, java.lang.String f_Operator, Object f_Value, java.util.ArrayList<$Ku.by.ToolClass.Sql.SqlField> f_SetFields, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        StringBuilder tmpValue = new StringBuilder();
        
        String tmpRight;
        if (f_Value == null)
        {
            $Ku.by.ToolClass.Sql.SqlField tmpField = f_TableField.getSelectedField();
            tmpRight=CellValueNullToDefaultReturnString(tmpField.getFieldType(), tmpField.getEnumType(), f_DBType);
        }
        else
        {
            tmpRight=f_Value.toString();
        }

        f_SetFields.add(f_TableField.getSelectedField());
        switch (f_Operator.replace(" ","")){
            case "+=":
                if (f_DBType.equals(DBTypeEnum.SqlServer)){
                    tmpValue.append(f_TableField.getFieldAccess());
                    tmpValue.append(f_Operator);
                    tmpValue.append(tmpRight);
                }
                else if(f_DBType.equals(DBTypeEnum.Mysql)) {
                    if (f_TableField.FieldType.equals(DataTypeEnum.String)){
                        tmpValue.append(f_TableField.getFieldAccess());
                        tmpValue.append(" = concat(");
                        tmpValue.append(f_TableField.getFieldAccess()).append(", ").append(tmpRight).append(")");
                    }
                    else{
                        tmpValue.append(f_TableField.getFieldAccess());
                        tmpValue.append(" = ");
                        tmpValue.append(f_TableField.getFieldAccess()).append(" + ").append(tmpRight);
                    }
                }
                else if(f_DBType.equals(DBTypeEnum.Oracle)){
                    tmpValue.append(f_TableField.getFieldAccess());
                    tmpValue.append(" = ");
                    tmpValue.append(f_TableField.getFieldAccess()).append(" + ").append(tmpRight);
                }
                break;
            case "/=":
                tmpValue.append(f_TableField.getFieldAccess());
                tmpValue.append(" = ");
                tmpValue.append(f_TableField.getFieldAccess()).append(" / ").append(tmpRight);
                break;
            case "%=":
                tmpValue.append(f_TableField.getFieldAccess());
                tmpValue.append(" = ");
                tmpValue.append(f_TableField.getFieldAccess()).append(" % ").append(tmpRight);
                break;
            case "*=":
                tmpValue.append(f_TableField.getFieldAccess());
                tmpValue.append(" = ");
                tmpValue.append(f_TableField.getFieldAccess()).append(" * ").append(tmpRight);
                break;
            case "-=":
                tmpValue.append(f_TableField.getFieldAccess());
                tmpValue.append(" = ");
                tmpValue.append(f_TableField.getFieldAccess()).append(" * ").append(tmpRight);
                break;
            case "&=":
                tmpValue.append(f_TableField.getFieldAccess());
                tmpValue.append(" = ");
                tmpValue.append(f_TableField.getFieldAccess()).append(" & ").append(tmpRight);
                break;
            case "|=":
                tmpValue.append(f_TableField.getFieldAccess());
                tmpValue.append(" = ");
                tmpValue.append(f_TableField.getFieldAccess()).append(" | ").append(tmpRight);
                break;
            case "^=":
                tmpValue.append(f_TableField.getFieldAccess());
                tmpValue.append(" = ");
                tmpValue.append(f_TableField.getFieldAccess()).append(" ^ ").append(tmpRight);
                break;
            default:
                tmpValue.append(f_TableField.getFieldAccess());
                tmpValue.append(f_Operator);
                tmpValue.append(tmpRight);
                break;
        }
        return tmpValue.toString();
    }

    public static java.lang.StringBuilder GetLimit(java.lang.StringBuilder f_Sql, java.lang.String f_StartIndex, java.lang.String f_Offsets, java.util.ArrayList<$Ku.by.ToolClass.Sql.OrderByField> f_OrderList, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_DBType == DBTypeEnum.SqlServer) {
            String tmpStartIndexValue = f_StartIndex + " + 1";
            String tmpEndIndexValue = f_StartIndex + " + " + f_Offsets;
            StringBuilder tmpNewSql = new StringBuilder("SELECT * ");
            tmpNewSql.append(" FROM (");
            tmpNewSql.append("SELECT *, ROW_NUMBER() OVER (");
            tmpNewSql.append("ORDER BY ");

            if (f_OrderList.isEmpty()) {
                tmpNewSql.append("GETDATE()) [#RowNum]");
            } else {
                for (int i = 0; i < f_OrderList.size(); i++) {
                    if (i != 0) {
                        tmpNewSql.append(", ");
                    }
                    tmpNewSql.append(f_OrderList.get(i).getOField());
                    if (f_OrderList.get(i).getIsDesc()) {
                        tmpNewSql.append(" DESC");
                    } else {
                        tmpNewSql.append(" ASC");
                    }
                }
                tmpNewSql.append(") AS [#RowNum]");
            }

            tmpNewSql.append(" FROM (");
            tmpNewSql.append(f_Sql);
            tmpNewSql.append(") ");
            tmpNewSql.append("[#NewTable])");
            tmpNewSql.append("[#NewTable1]");
            tmpNewSql.append(String.format(" WHERE [#NewTable1].[#RowNum] BETWEEN %s AND %s", tmpStartIndexValue, tmpEndIndexValue));
            return tmpNewSql;
        } else if (f_DBType == DBTypeEnum.Mysql) {
            StringBuilder tmpNewSql = new StringBuilder();
            tmpNewSql.append(f_Sql);
            tmpNewSql.append(" LIMIT ");
            tmpNewSql.append(f_StartIndex);
            tmpNewSql.append(", ");
            tmpNewSql.append(f_Offsets);
            tmpNewSql.append("; ");
            return tmpNewSql;
        } else {
            String tmpNewSql = "SELECT \"#NewTable\".*, ROWNUM \"#RowNum\" FROM ( " +
                    f_Sql +
                    ") \"#NewTable\" WHERE ROWNUM < 1 + " +
                    f_StartIndex +
                    " + " +
                    f_Offsets;
            StringBuilder tmpReturnValue = new StringBuilder("SELECT * FROM ( ");
            tmpReturnValue.append(tmpNewSql);
            tmpReturnValue.append(" ) WHERE \"#RowNum\" > ");
            tmpReturnValue.append(f_StartIndex);
            return tmpReturnValue;
        }
    }

    public static boolean Is(Object obj, java.lang.Class<?> clazz) {
        Class<?> objClass = obj.getClass();
        boolean isOneTree = false;

        while (objClass.getSuperclass() != null){
            if(objClass.equals(clazz)){
                isOneTree = true;
                break;
            }
            objClass = objClass.getSuperclass();
        }

        return isOneTree | CheckInterfacesIsOneTree(objClass, clazz);
    }

    private static boolean CheckInterfacesIsOneTree(java.lang.Class<?> clazz, java.lang.Class<?> target) {
        boolean interfacesResult = false;
        if (clazz.getInterfaces().length > 0){
            for (Class<?> item:
                    clazz.getInterfaces()) {
                interfacesResult = interfacesResult | CheckInterfacesIsOneTree(item, target);

            }
        }
        return clazz.equals(target) | interfacesResult;
    }

    public static java.lang.Character parseChar(java.lang.String input) {
        if(input == null){
            throw new RuntimeException("输入字符串不能为null");
        }
        if(input.length() != 1){
            throw new RuntimeException("输入字符串长度不为1");
        }
        return input.charAt(0);
    }

    public static java.lang.String CheckRowsSheet($Ku.by.Object.List<$Ku.by.Object.Row> f_Rows) {
        if(f_Rows == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowIsNull);
        }
        if(f_Rows.size() == 0){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowsHasNoRow);
        }
        String tmpKuName = null;
        String tmpSheetName = null;
        for($Ku.by.Object.Row row : f_Rows){
            if(row.getKuName() == null){
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowKuNameNull);
            }
            if(row.getSheetName() == null){
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowSheetNameNull);
            }
            if(tmpKuName == null){
                tmpKuName = row.getKuName();
            }
            else{
                if(!tmpKuName.equals(row.getKuName())){
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowsHasServerKu);
                }
            }

            if(tmpSheetName == null){
                tmpSheetName = row.getSheetName();
            }
            else{
                if(!tmpSheetName.equals(row.getSheetName())){
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowsHasSeveralInstance);
                }
            }
        }

        if(tmpKuName == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowKuNameNull);
        }

        if(tmpSheetName == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowSheetNameNull);
        }
        return tmpKuName + "." + tmpSheetName;
    }

    public static java.lang.String CheckRowsSheet($Ku.by.Object.Row[] f_Rows) {
        if(f_Rows == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowsIsNull);
        }

        if(f_Rows.length == 0){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowsHasNoRow);
        }

        String tmpKuName = null;
        String tmpSheetName = null;

        for($Ku.by.Object.Row row : f_Rows){
            if(row.getKuName() == null){
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowKuNameNull);
            }

            if(row.getSheetName() == null){
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowSheetNameNull);
            }

            if(tmpKuName == null){
                tmpKuName = row.getKuName();
            }else{
                if(!tmpKuName.equals(row.getKuName())){
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowsHasServerKu);
                }
            }

            if(tmpSheetName == null){
                tmpSheetName = row.getSheetName();
            }else{
                if(!tmpSheetName.equals(row.getSheetName())){
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowsHasSeveralInstance);
                }
            }
        }

        if(tmpKuName == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowKuNameNull);
        }

        if(tmpSheetName == null){
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowSheetNameNull);
        }
        return tmpKuName + "." + tmpSheetName;
    }

    public static java.lang.String TableRelationEqualField($Ku.by.ToolClass.Sql.SqlTable f_Table, java.lang.String f_Component, java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractTable> f_TableList, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        if (f_Table == null) {
            throw new RelationOperationException(ErrorInfo.TableIsNull);
        }

        StringBuilder tmpSqlExpression = new StringBuilder();
        TableField tmpTableField = (TableField) ConvertComponentToTableField(f_Component, f_TableList);

        if (tmpTableField == null) {
            throw new RelationOperationException(ErrorInfo.FieldIsNull);
        }

        $Ku.by.ToolClass.Sql.SqlField tmpField = tmpTableField.getSelectedField();
        String tmpFieldKuName = tmpField.getKuName();
        String tmpFieldSheetName = tmpField.getSheetName();

        if (!tmpFieldKuName.equals(f_Table.getKuName())) {
            throw new RelationOperationException(ErrorInfo.FieldIsNull);
        }

        BaseKu tmpKu = GetKu(tmpFieldKuName);
        StringBuilder tmpLeft = new StringBuilder();
        StringBuilder tmpRight = new StringBuilder();

        if (f_Table.getAlias() != null) {
            if (f_DBType == DBTypeEnum.SqlServer) {
                tmpLeft.append("[").append(f_Table.getAlias()).append("].");
            } else if (f_DBType == DBTypeEnum.Mysql) {
                tmpLeft.append("`").append(f_Table.getAlias()).append("`.");
            } else {
                tmpLeft.append("\"").append(f_Table.getAlias()).append("\".");
            }
        } else {
            if (f_DBType == DBTypeEnum.SqlServer) {
                tmpLeft.append("[").append(f_Table.getSourceName()).append("].");
            } else if (f_DBType == DBTypeEnum.Mysql) {
                tmpLeft.append("`").append(f_Table.getSourceName()).append("`.");
            } else {
                tmpLeft.append("\"").append(f_Table.getSourceName()).append("\".");
            }
        }

        if (Objects.equals(f_Table.getSourceName(), tmpFieldSheetName)) {
            //同表
            if (f_DBType == DBTypeEnum.SqlServer) {
                tmpLeft.append("[").append(tmpTableField.getSelectedField().getName()).append("]");
            } else if (f_DBType == DBTypeEnum.Mysql) {
                tmpLeft.append("`").append(tmpTableField.getSelectedField().getName()).append("`");
            } else {
                tmpLeft.append("\"").append(tmpTableField.getSelectedField().getName()).append("\"");
            }

            tmpRight.append(tmpTableField.getFieldAccess());
            return tmpLeft.toString() + " = " + tmpRight.toString();
        }
        
        SheetRelation tmpRelation = FindReferenceBetweenFieldAndSheet(tmpKu, tmpField, f_Table.getTableAccess());
        boolean tmpRightIsReference = false;
        
        if (f_Table.getSourceName().equals(tmpRelation.getReferencedSheet())) {
            if (f_DBType == DBTypeEnum.SqlServer) {
                tmpLeft.append("[").append(tmpRelation.getReferencedFieldName()).append("]");
            } else if (f_DBType == DBTypeEnum.Mysql) {
                tmpLeft.append("`").append(tmpRelation.getReferencedFieldName()).append("`");
            } else {
                tmpLeft.append("\"").append(tmpRelation.getReferencedFieldName()).append("\"");
            }
            tmpRightIsReference = true;
        } else {
            if (f_DBType == DBTypeEnum.SqlServer) {
                tmpLeft.append("[").append(tmpRelation.getReferenceFieldName()).append("]");
            } else if (f_DBType == DBTypeEnum.Mysql) {
                tmpLeft.append("`").append(tmpRelation.getReferenceFieldName()).append("`");
            } else {
                tmpLeft.append("\"").append(tmpRelation.getReferenceFieldName()).append("\"");
            }
        }

        tmpLeft.append(" = ");

        if (tmpRightIsReference) {
            if (!tmpRelation.getReferenceFieldName().equals(tmpField.getName())) {
                throw new RelationOperationException(String.format(ErrorInfo.TableNotReferenceField, tmpField.getName(), f_Table.getSourceName()));
            }
        } else {
            if (!tmpRelation.getReferencedFieldName().equals(tmpField.getName())) {
                throw new RelationOperationException(String.format(ErrorInfo.TableNotReferenceField, tmpField.getName(), f_Table.getSourceName()));
            }
        }

        $Ku.by.ToolClass.Sql.SqlTable tmpSelectTable = ($Ku.by.ToolClass.Sql.SqlTable) tmpTableField.getFieldTable();
        if (tmpSelectTable.getAlias() == null) {
            if (f_DBType == DBTypeEnum.SqlServer) {
                tmpRight.append("`").append(tmpSelectTable.getSourceName()).append("`.");
            } else if (f_DBType == DBTypeEnum.Mysql) {
                tmpRight.append("`").append(tmpSelectTable.getSourceName()).append("`.");
            } else {
                tmpRight.append("\"").append(tmpSelectTable.getSourceName()).append("\".");
            }

        } else {
            tmpRight.append(tmpSelectTable.getAlias()).append(".");
        }

        if (f_DBType == DBTypeEnum.SqlServer) {
            tmpRight.append("[").append(tmpTableField.getSelectedField().getName()).append("]");
        } else if (f_DBType == DBTypeEnum.Mysql) {
            tmpRight.append("`").append(tmpTableField.getSelectedField().getName()).append("`");
        } else {
            tmpRight.append("\"").append(tmpTableField.getSelectedField().getName()).append("\"");
        }
        tmpSqlExpression.append(tmpLeft);
        tmpSqlExpression.append(tmpRight);
        return tmpSqlExpression.toString();
    }

    public static void FillInsertValues(java.util.HashMap<$Ku.by.ToolClass.Sql.SqlField, Object> insertValues, Object parameter, $Ku.by.ToolClass.Sql.SqlTable table) {
        ArrayList<$Ku.by.ToolClass.Sql.SqlField> tmpFieldList = new ArrayList<>();

        if (insertValues.isEmpty()) {
            tmpFieldList.addAll(table.getSheet().getFieldDic().values());
        } else {
            tmpFieldList.addAll(insertValues.keySet());
        }

        if (parameter instanceof $Ku.by.Object.Row) {
            $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row) parameter;

            for ($Ku.by.ToolClass.Sql.SqlField item : tmpFieldList) {
                $Ku.by.Object.Cell tmpCell = tmpRow.cells.stream()
                        .filter(cell -> cell.ColumnName.equals(item.getName()))
                        .findFirst()
                        .orElse(null);

                Object tmpCellValue = tmpCell == null ? null : tmpCell.value;
                String tmpAppendValue = null;

                if (tmpCellValue == null) {
                    tmpAppendValue = null;
                } else if (tmpCellValue instanceof $Ku.by.Object.Datetime || tmpCellValue instanceof java.time.LocalDateTime || tmpCellValue instanceof Character || tmpCellValue instanceof String || tmpCellValue.getClass().isEnum()) {
                    // 已经用单引号包裹
                    tmpAppendValue = SaveInspect.CharactorEscape(tmpCellValue);
                } else if (tmpCellValue instanceof Byte || tmpCellValue instanceof Short || tmpCellValue instanceof Integer || tmpCellValue instanceof Long || tmpCellValue instanceof Float || tmpCellValue instanceof Double || tmpCellValue instanceof BigDecimal) {
                    tmpAppendValue = tmpCellValue.toString();
                } else {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.UnKnowType); // 未知类型
                }

                if (insertValues.containsKey(item)) {
                    insertValues.put(item, tmpAppendValue);
                } else {
                    insertValues.put(item, tmpAppendValue);
                }
            }

            return;
        }

        if (parameter instanceof $Ku.by.Object.List) {
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpRowList = ($Ku.by.Object.List<$Ku.by.Object.Row>) parameter;
            for ($Ku.by.ToolClass.Sql.SqlField item : tmpFieldList) {
                $Ku.by.Object.List<Object> tmpObjectList = FindCellValuesInRows(item, tmpRowList);

                if (insertValues.containsKey(item)) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.InsertFieldConflict, item.getName()));
                } else {
                    insertValues.put(item, tmpObjectList);
                }
            }
            return;
        }
        if (parameter instanceof $Ku.by.Object.Row[]) {
            $Ku.by.Object.Row[] tmpRows = ($Ku.by.Object.Row[]) parameter;
            $Ku.by.Object.List<$Ku.by.Object.Row> tmpRowList = new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class), new ArrayList<>(Arrays.asList(tmpRows)));
            for ($Ku.by.ToolClass.Sql.SqlField item : tmpFieldList) {
                $Ku.by.Object.List<Object> tmpObjectList = FindCellValuesInRows(item, tmpRowList);
                if (insertValues.containsKey(item)) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.InsertFieldConflict, item.getName()));
                } else {
                    insertValues.put(item, tmpObjectList);
                }
            }
            return;
        }

        if (parameter instanceof ArrayList) {
            ArrayList<$Ku.by.Object.Row> tmpRowList = (ArrayList<$Ku.by.Object.Row>) parameter;
            for ($Ku.by.ToolClass.Sql.SqlField item : tmpFieldList) {
                $Ku.by.Object.List<Object> tmpObjectList = FindCellValuesInRows(item, new $Ku.by.Object.List<>($Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.Row.class), tmpRowList));
                if (insertValues.containsKey(item)) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.InsertFieldConflict, item.getName()));
                } else {
                    insertValues.put(item, tmpObjectList);
                }
            }
            return;
        }

        $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.IllegalRowParameter);
    }

    public static java.lang.String CheckKuInTran(java.lang.String f_Old, $Ku.by.ToolClass.Sql.ParamsPackage f_Package) {
        if (f_Package.getTableSourceList().isEmpty())
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseSheetNameError);
        }
        AbstractTable tmpTableSource = f_Package.getTableSourceList().get(0);
        if (tmpTableSource == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.SqlInTranTableSourceError);
        }
        AbstractIdentityBase tmpIdentity = tmpTableSource.GetIdentity();
        String tmpKu = tmpIdentity.ku;

        if (f_Old != null && tmpKu != f_Old)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.DifferentKuInTran);
        }

        return tmpKu;
    }

    public static int SetMax($Ku.by.ToolClass.IBaseDataSheet f_Sheet) {
        if (f_Sheet.getPrimaryKeyList().size() != 1)
        {
            return 0;
        }
        else
        {
            if (f_Sheet.getFieldDic().get(f_Sheet.getPrimaryKeyList().get(0).getName()).getFieldType() == $Ku.by.ToolClass.DataTypeEnum.Int)
            {
                String tmpGetMax;
                DBTypeEnum tmpDBType;
                if (!Root.GetInstance().KuTypeDic.containsKey(f_Sheet.getKuName()))
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException(String.format(ErrorInfo.KuTypeNotLoad, f_Sheet.getKuName()));
                }
                tmpDBType = Root.GetInstance().KuTypeDic.get(f_Sheet.getKuName());

                if (tmpDBType == DBTypeEnum.SqlServer)
                {
                    tmpGetMax = "SELECT MAX([" + f_Sheet.getPrimaryKeyList().get(0).getName() + "]) FROM[" + f_Sheet.getKuName() + "].[dbo].[" + f_Sheet.getSheetName() + "]";
                }
                else
                {
                    tmpGetMax = "SELECT MAX(`" + f_Sheet.getPrimaryKeyList().get(0).getName() + "`) FROM `" + f_Sheet.getSheetName() + "`";
                }

                Object tmpReturnValue = $Ku.by.ToolClass.Sql.SqlHelper.Inquiry(tmpGetMax, f_Sheet.getKuName());
                if (tmpReturnValue == null)
                {
                    return 0;
                }
                else
                {
                    return Integer.parseInt(String.valueOf(tmpReturnValue));
                }
            }
            else
            {
                return 0;
            }
        }
    }

    public static java.lang.String ExecuteRowsFlowInTran(java.lang.String f_FlowName, $Ku.by.Identity.Table f_Identity, java.lang.String f_EffectCount, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        IBaseDataSheet tmpDataSheet = (IBaseDataSheet) f_Identity.getTo();
        if(tmpDataSheet == null){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.FlowIdentityError, f_Identity.getKu(), f_Identity.getClass().getName()));
        }

        if(!tmpDataSheet.getRowsFlowInTranDic().containsKey(f_FlowName)){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.getKuName() + "." + tmpDataSheet.getSheetName(), f_FlowName));
        }
        return tmpDataSheet.getRowsFlowInTranDic().get(f_FlowName).invoke(f_EffectCount, f_CurrentRow, f_RelationRow);
    }

    public static java.lang.String ExecuteRowFlowInTran(java.lang.String f_FlowName, $Ku.by.Identity.Table f_Identity, java.lang.String f_EffectCount, $Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        IBaseDataSheet tmpDataSheet = (IBaseDataSheet) f_Identity.getTo();
        if(tmpDataSheet == null){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.FlowIdentityError, f_Identity.getKu(), f_Identity.getClass().getName()));
        }

        if(!tmpDataSheet.getRowFlowInTranDic().containsKey(f_FlowName)){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.getKuName() + "." + tmpDataSheet.getSheetName(), f_FlowName));
        }
        return tmpDataSheet.getRowFlowInTranDic().get(f_FlowName).invoke(f_EffectCount, f_CurrentRow, f_RelationRow);
    }

    public static java.lang.String ExecuteRowArrayFlowInTran(java.lang.String f_FlowName, $Ku.by.Identity.Table f_Identity, java.lang.String f_EffectCount, $Ku.by.Object.Row[] f_CurrentRow, $Ku.by.Object.Row[] ... f_RelationRow) {
        IBaseDataSheet tmpDataSheet = (IBaseDataSheet) f_Identity.getTo();
        if(tmpDataSheet == null){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.FlowIdentityError, f_Identity.getKu(), f_Identity.getClass().getName()));
        }

        if(!tmpDataSheet.getRowArrayFlowInTranDic().containsKey(f_FlowName)){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.getKuName() + "." + tmpDataSheet.getSheetName(), f_FlowName));
        }
        return tmpDataSheet.getRowArrayFlowInTranDic().get(f_FlowName).invoke(f_EffectCount, f_CurrentRow, f_RelationRow);
    }

    public static java.lang.String ExecuteRowsFlow(java.lang.String f_FlowName, $Ku.by.Identity.Table f_Identity, java.lang.Iterable<$Ku.by.Object.Row> f_CurrentRow, java.lang.Iterable<$Ku.by.Object.Row> ... f_RelationRow) {
        IBaseDataSheet tmpDataSheet = (IBaseDataSheet) f_Identity.getTo();
        if(tmpDataSheet == null){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.FlowIdentityError, f_Identity.getKu(), f_Identity.getClass().getName()));
        }

        if(!tmpDataSheet.getRowsFlowDic().containsKey(f_FlowName)){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.getKuName() + "." + tmpDataSheet.getSheetName(), f_FlowName));
        }
        return tmpDataSheet.getRowsFlowDic().get(f_FlowName).invoke(f_CurrentRow, f_RelationRow);
    }

    public static java.lang.String ExecuteRowFlow(java.lang.String f_FlowName, $Ku.by.Identity.Table f_Identity, $Ku.by.Object.Row f_CurrentRow, $Ku.by.Object.Row ... f_RelationRow) {
        IBaseDataSheet tmpDataSheet = (IBaseDataSheet) f_Identity.getTo();
        if(tmpDataSheet == null){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.FlowIdentityError, f_Identity.getKu(), f_Identity.getClass().getName()));
        }

        if(!tmpDataSheet.getRowFlowDic().containsKey(f_FlowName)){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.getKuName() + "." + tmpDataSheet.getSheetName(), f_FlowName));
        }
        return tmpDataSheet.getRowFlowDic().get(f_FlowName).invoke(f_CurrentRow, f_RelationRow);
    }

    public static java.lang.String ExecuteRowArrayFlow(java.lang.String f_FlowName, $Ku.by.Identity.Table f_Identity, $Ku.by.Object.Row[] f_CurrentRow, $Ku.by.Object.Row[] ... f_RelationRow) {
        IBaseDataSheet tmpDataSheet = (IBaseDataSheet) f_Identity.getTo();
        if(tmpDataSheet == null){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.FlowIdentityError, f_Identity.getKu(), f_Identity.getClass().getName()));
        }

        if(!tmpDataSheet.getRowArrayFlowDic().containsKey(f_FlowName)){
            throw $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindFlowInSheet, tmpDataSheet.getKuName() + "." + tmpDataSheet.getSheetName(), f_FlowName));
        }
        return tmpDataSheet.getRowArrayFlowDic().get(f_FlowName).invoke(f_CurrentRow, f_RelationRow);
    }

    public static java.lang.String GetKuInSql($Ku.by.ToolClass.Sql.TranParamsPackage f_Parameter) {
        if (f_Parameter.getParamters().isEmpty())
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("事务中不含sql语句参数无法获取执行库");
        }

        String tmpKuName = null;
        boolean tmpAssigned = false;
        for ($Ku.by.ToolClass.Sql.ParamsPackage item : f_Parameter.getParamters())
        {
            if (item.getTableSourceList().isEmpty())
            {
                if (!item.getParameterList().isEmpty())
                {
                    Object tmpRowParameter = item.getParameterList().get(0);

                    if (tmpRowParameter instanceof $Ku.by.Object.Row)
                    {
                        $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row) tmpRowParameter;

                        if (tmpRow == null || tmpRow.getIdentity() == null || tmpRow.getIdentity().to == null || !(tmpRow.getIdentity().to instanceof IBaseDataSheet))
                        {
                            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
                        }

                        String tmpNewRowKuName = ((IBaseDataSheet)tmpRow.getIdentity().to).getKuName();

                        if (!Objects.equals(tmpKuName, tmpNewRowKuName) && tmpAssigned)
                        {
                            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("事务中sql参数存在不同的执行库");
                        }

                        if (!Objects.equals(tmpKuName, tmpNewRowKuName))
                        {
                            tmpKuName = tmpNewRowKuName;
                            tmpAssigned = true;
                        }
                    }
                    else if (tmpRowParameter instanceof $Ku.by.Object.Row[])
                    {
                        $Ku.by.Object.Row[] tmpRows = ($Ku.by.Object.Row[])tmpRowParameter;

                        for ($Ku.by.Object.Row tmpRow : tmpRows)
                        {
                            if (tmpRow == null || tmpRow.getIdentity() == null || tmpRow.getIdentity().to == null || !(tmpRow.getIdentity().to instanceof IBaseDataSheet))
                            {
                                continue;
                            }

                            String tmpNewRowKuName = ((IBaseDataSheet)tmpRow.getIdentity().to).getKuName();

                            if (!Objects.equals(tmpKuName, tmpNewRowKuName) && tmpAssigned)
                            {
                                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("事务中sql参数存在不同的执行库");
                            }

                            if (!Objects.equals(tmpKuName, tmpNewRowKuName))
                            {
                                tmpKuName = tmpNewRowKuName;
                                tmpAssigned = true;
                            }
                        }
                    }
                    else if (tmpRowParameter instanceof Iterable)
                    {
                        Iterable<$Ku.by.Object.Row> tmpRows = (Iterable<$Ku.by.Object.Row>)tmpRowParameter;

                        for ($Ku.by.Object.Row tmpRow : tmpRows)
                        {
                            if (tmpRow == null || tmpRow.getIdentity() == null || tmpRow.getIdentity().to == null || !(tmpRow.getIdentity().to instanceof IBaseDataSheet))
                            {
                                continue;
                            }

                            String tmpNewRowKuName = ((IBaseDataSheet)tmpRow.getIdentity().to).getKuName();

                            if (!Objects.equals(tmpKuName, tmpNewRowKuName) && tmpAssigned)
                            {
                                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("事务中sql参数存在不同的执行库");
                            }

                            if (!Objects.equals(tmpKuName, tmpNewRowKuName))
                            {
                                tmpKuName = tmpNewRowKuName;
                                tmpAssigned = true;
                            }
                        }
                    }
                    else
                    {
                        $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
                    }
                }
                else
                {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
                }

                continue;
            }

            String tmpNewKuName = item.getTableSourceList().get(0).GetSource().getKuName();

            if (!Objects.equals(tmpKuName, tmpNewKuName) && tmpAssigned)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("事务中sql参数存在不同的执行库");
            }

            if (!Objects.equals(tmpKuName, tmpNewKuName))
            {
                tmpKuName = tmpNewKuName;
                tmpAssigned = true;
            }
        }

        f_Parameter.ExecuteKuName = tmpKuName;
        return tmpKuName;
    }

    public static java.lang.String GetKuInSql($Ku.by.ToolClass.Sql.ParamsPackage f_Parameter) {
        if (f_Parameter.getTableSourceList().isEmpty()) {
            if (!f_Parameter.getParameterList().isEmpty()) {
                if (f_Parameter.getParameterList().get(0) instanceof $Ku.by.Object.Row) {
                    $Ku.by.Object.Row tmpRow = ($Ku.by.Object.Row) f_Parameter.getParameterList().get(0);

                    if (tmpRow == null || tmpRow.getIdentity() == null || tmpRow.getIdentity().to == null || !(tmpRow.getIdentity().to instanceof IBaseDataSheet)) {
                        $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
                    }

                    f_Parameter.getTableSourceList().add(new $Ku.by.ToolClass.Sql.SqlTable((IBaseDataSheet) tmpRow.getIdentity().to, null));
                    IBaseDataSheet tmpRowDataSheet = (IBaseDataSheet) tmpRow.getIdentity().to;

                    if (tmpRowDataSheet == null) {
                        ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
                    }

                    return tmpRowDataSheet.getKuName();
                } else if (f_Parameter.getParameterList().get(0) instanceof $Ku.by.Object.Row[]) {
                    String tmpKuName = null;
                    $Ku.by.Object.Row[] tmpRows = ($Ku.by.Object.Row[]) f_Parameter.getParameterList().get(0);

                    for ($Ku.by.Object.Row tmpRow : tmpRows) {
                        if (tmpRow == null || tmpRow.getIdentity() == null || tmpRow.getIdentity().to == null || !(tmpRow.getIdentity().to instanceof IBaseDataSheet)) {
                            continue;
                        }

                        IBaseDataSheet tmpRowDataSheet = (IBaseDataSheet) tmpRow.getIdentity().to;

                        AbstractTable tmpTable = null;
                        for (AbstractTable item : f_Parameter.getTableSourceList()) {
                            if (item.GetSource() != tmpRowDataSheet) {
                                tmpTable = item;
                                break;
                            }
                        }
                        if (tmpTable == null) {
                            f_Parameter.getTableSourceList().add(new $Ku.by.ToolClass.Sql.SqlTable(tmpRowDataSheet, null));
                        }
                        String tmpNewRowKuName = ((IBaseDataSheet) tmpRow.getIdentity().to).getKuName();

                        if (tmpKuName == null) {
                            tmpKuName = tmpNewRowKuName;
                        } else {
                            if (!tmpKuName.equals(tmpNewRowKuName)) {
                                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("事务中sql参数存在不同的执行库");
                            }
                        }
                    }

                    if (tmpKuName == null) {
                        $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
                    } else {
                        return tmpKuName;
                    }
                } else if (f_Parameter.getParameterList().get(0) instanceof Iterable) {
                    String tmpKuName = null;
                    Iterable<$Ku.by.Object.Row> tmpRows = (Iterable<$Ku.by.Object.Row>) f_Parameter.getParameterList().get(0);

                    for ($Ku.by.Object.Row tmpRow : tmpRows) {
                        if (tmpRow == null || tmpRow.getIdentity() == null || tmpRow.getIdentity().to == null || !(tmpRow.getIdentity().to instanceof IBaseDataSheet)) {
                            continue;
                        }

                        IBaseDataSheet tmpRowDataSheet = (IBaseDataSheet) tmpRow.getIdentity().to;

                        AbstractTable tmpTable = null;
                        for (AbstractTable item : f_Parameter.getTableSourceList()) {
                            if (item.GetSource() != tmpRowDataSheet) {
                                tmpTable = item;
                                break;
                            }
                        }
                        if (tmpTable == null) {
                            f_Parameter.getTableSourceList().add(new $Ku.by.ToolClass.Sql.SqlTable(tmpRowDataSheet, null));
                        }
                        String tmpNewRowKuName = ((IBaseDataSheet) tmpRow.getIdentity().to).getKuName();

                        if (tmpKuName == null) {
                            tmpKuName = tmpNewRowKuName;
                        } else {
                            if (tmpKuName != tmpNewRowKuName) {
                                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("事务中sql参数存在不同的执行库");
                            }
                        }
                    }

                    if (tmpKuName == null) {
                        $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
                    } else {
                        return tmpKuName;
                    }
                } else {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
                }
            } else {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
            }

        }
        IBaseDataSheet tmpDataSheet = f_Parameter.getTableSourceList().get(0).GetSource();

        if (tmpDataSheet == null)
        {
            ThrowHelper.ThrowSqlPreCompileException("服务器接收的sql参数中无表源信息无法获取执行库");
        }

        return tmpDataSheet.getKuName();
    }

    public static void CheckLimitSelectFields(java.util.ArrayList<$Ku.by.ToolClass.Sql.AbstractSelectField> f_SelectItems, java.util.ArrayList<$Ku.by.ToolClass.Sql.OrderByField> f_OrderByList) {
        //需要确保在最后时刻调用
        //无别名的查询列名和某个别名冲突会报错
        ArrayList<String> tmpNames = new ArrayList<>();
        ArrayList<String> tmpAliasList = new ArrayList<>();

        for ($Ku.by.ToolClass.Sql.AbstractSelectField item : f_SelectItems) {
            //先检查带别名的
            if (item.getAlias() == null) {
                continue;
            }

            //不改只加,理论上只用给没加别名的重复字段和表达式加
            String tmpAlias = item.getAlias().toLowerCase();
            if (tmpNames.contains(item.getAlias())) {
                $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.ConflictFields, item.getAlias()));
            }
            tmpNames.add(tmpAlias);
            tmpAliasList.add(tmpAlias);
        }

        for (AbstractSelectField item : f_SelectItems) {
            if (item.getAlias() != null) {
                continue;
            }

            if (item instanceof $Ku.by.ToolClass.Sql.AsteriskField) {
                continue;
            }

            if (item instanceof $Ku.by.ToolClass.Sql.TableField) {
                TableField tmpTableField = (TableField) item;
                String tmpName = tmpTableField.getSelectedField().getName();
                if (tmpAliasList.contains(tmpName)) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.ConflictFields, tmpName));
                }
            }

            if (item instanceof $Ku.by.ToolClass.Sql.SelectField) {
                SelectField tmpSelectField = (SelectField) item;
                String tmpName = tmpSelectField.Name;
                if (tmpAliasList.contains(tmpName)) {
                    $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(String.format(ErrorInfo.ConflictFields, tmpName));
                }
            }

            String tmpNewName = "#TmpName" + tmpNames.size();//不会有重名

            if (item instanceof TableField) {
                TableField tmpTableField = (TableField) item;
                tmpTableField.setAlias(tmpNewName);
            } else {
                item.setAlias(tmpNewName);
            }
            tmpNames.add(tmpNewName);
        }

        ArrayList<OrderByField> tmpOrderByList = new ArrayList<>();//替换成一个新的
        //给所有没加别名的需要orderby的列加带别名的查询列
        for (int i = 0; i < f_OrderByList.size(); i++) {
            String tmpOrderByValue = f_OrderByList.get(i).getOField();
            boolean tmpIsDesc = f_OrderByList.get(i).getIsDesc();
            AbstractSelectField tmpField = f_OrderByList.get(i).getSourceField();

            if (tmpOrderByValue == null) {
                //说明需要新添加查询列
                f_SelectItems.add(tmpField);
                tmpField.setAlias("#NewOrderBy" + i);
                tmpOrderByValue = "[#NewTable]." + tmpField.getAlias();
            } else {
                tmpOrderByValue = "[#NewTable]." + tmpOrderByValue;
            }
            tmpOrderByList.add(new OrderByField(tmpOrderByValue, tmpIsDesc));
        }

        f_OrderByList.clear();
        f_OrderByList.addAll(tmpOrderByList);
    }

    public static Object CellValueNullToDefault($Ku.by.ToolClass.DataTypeEnum f_TypeEnum, java.lang.Class<?> f_EnumType) {
        switch (f_TypeEnum)
        {
            case Bool:
                return false;
            case Byte:
                return (byte)0;
            case Char:
                return '\0';
            case Datetime:
                return new $Ku.by.Object.Datetime();
            case Decimal:
                return new $Ku.by.Object.Decimal(0);
            case Double:
                return (double)0;
            case Enum:
                if (f_EnumType == null)
                {
                    throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("枚举类型未填充");
                }

                Enum<?>[] tmpEnums = (Enum<?>[]) f_EnumType.getEnumConstants();

                if (tmpEnums.length == 0)
                {
                    return null;
                }
                else
                {
                    return tmpEnums[0].toString();
                }
            case Float:
                return (float)0;
            case Int:
                return 0;
            case Long:
                return (long)0;
            case Short:
                return (short)0;
            default:
                return "";
        }
    }

    public static java.lang.String CellValueNullToDefaultReturnString($Ku.by.ToolClass.DataTypeEnum f_TypeEnum, java.lang.Class<?> f_EnumType, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        switch (f_TypeEnum)
        {
            case Bool:
            case Byte:
            case Decimal:
            case Double:
            case Float:
            case Int:
            case Long:
            case Short:
                return "0";
            case Char:
                return "'\\0'";
            case Datetime:
                return "'0001-1-1 00:00:00'";
            case String:
                return "''";
            case Enum:
                if (f_EnumType == null)
                {
                    throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("枚举类型未填充");
                }
                Enum<?>[] tmpEnums = (Enum<?>[]) f_EnumType.getEnumConstants();
                if (tmpEnums.length  == 0)
                {
                    return "''";
                }
                else
                {
                    return  "'" + tmpEnums[0].toString() + "'";
                }
            default:
                throw $Ku.by.ToolClass.ThrowHelper.ThrowUnKnownException("单元格类型填充错误，无法由null转化为默认值");
        }
    }

    public static java.lang.Byte castToByte(Object obj) {
        if(obj.equals(Double.NaN) || obj.equals(Float.NaN) || obj.equals(Double.POSITIVE_INFINITY) || obj.equals(Double.NEGATIVE_INFINITY) || obj.equals(Float.POSITIVE_INFINITY) || obj.equals(Float.NEGATIVE_INFINITY)){
            return 0;
        }
        if(obj instanceof Byte){
            return (Byte)obj;
        }
        if(obj instanceof Short){
            return ((Short)obj).byteValue();
        }
        if(obj instanceof Integer){
            return ((Integer)obj).byteValue();
        }
        if(obj instanceof Long){
            return ((Long)obj).byteValue();
        }
        if(obj instanceof Float){
            return ((Float)obj).byteValue();
        }
        if(obj instanceof Double){
            return ((Double)obj).byteValue();
        }
        if(obj instanceof Character){
            int tmpValue = (char)obj;
            return (byte)tmpValue;
        }
        if(obj instanceof $Ku.by.Object.Decimal){
            return (($Ku.by.Object.Decimal)obj).byteValue();
        }

        throw new RuntimeException("不支持转换的类型：" + obj.getClass());
    }

    public static java.lang.Short castToShort(Object obj) {
        if(obj.equals(Double.NaN) || obj.equals(Float.NaN) || obj.equals(Double.POSITIVE_INFINITY) || obj.equals(Double.NEGATIVE_INFINITY) || obj.equals(Float.POSITIVE_INFINITY) || obj.equals(Float.NEGATIVE_INFINITY)){
            return 0;
        }

        if(obj instanceof Byte){
            return ((Byte)obj).shortValue();
        }
        if(obj instanceof Short){
            return (Short)obj;
        }
        if(obj instanceof Integer){
            return ((Integer)obj).shortValue();
        }
        if(obj instanceof Long){
            return ((Long)obj).shortValue();
        }
        if(obj instanceof Float){
            return ((Float)obj).shortValue();
        }
        if(obj instanceof Double){
            return ((Double)obj).shortValue();
        }
        if(obj instanceof Character){
            int tmpValue = (char)obj;
            return (short)tmpValue;
        }
        if(obj instanceof $Ku.by.Object.Decimal){
            return (($Ku.by.Object.Decimal)obj).shortValue();
        }

        throw new RuntimeException("不支持转换的类型：" + obj.getClass());
    }

    public static java.lang.Integer castToInteger(Object obj) {
        if(obj.equals(Double.NaN) || obj.equals(Float.NaN) || obj.equals(Double.POSITIVE_INFINITY) || obj.equals(Double.NEGATIVE_INFINITY) || obj.equals(Float.POSITIVE_INFINITY) || obj.equals(Float.NEGATIVE_INFINITY)){
            return 0;
        }
        if(obj instanceof Byte){
            return ((Byte)obj).intValue();
        }
        if(obj instanceof Short){
            return ((Short)obj).intValue();
        }
        if(obj instanceof Integer){
            return (Integer)obj;
        }
        if(obj instanceof Long){
            return ((Long)obj).intValue();
        }
        if(obj instanceof Float){
            return ((Float)obj).intValue();
        }
        if(obj instanceof Double){
            return ((Double)obj).intValue();
        }
        if(obj instanceof Character){
            int tmpValue = (char)obj;
            return tmpValue;
        }
        if(obj instanceof $Ku.by.Object.Decimal){
            return (($Ku.by.Object.Decimal)obj).intValue();
        }

        throw new RuntimeException("不支持转换的类型：" + obj.getClass());
    }

    public static java.lang.Long castToLong(Object obj) {
        if(obj.equals(Double.NaN) || obj.equals(Float.NaN) || obj.equals(Double.POSITIVE_INFINITY) || obj.equals(Double.NEGATIVE_INFINITY) || obj.equals(Float.POSITIVE_INFINITY) || obj.equals(Float.NEGATIVE_INFINITY)){
            return 0L;
        }
        if(obj instanceof Byte){
            return ((Byte)obj).longValue();
        }
        if(obj instanceof Short){
            return ((Short)obj).longValue();
        }
        if(obj instanceof Integer){
            return ((Integer)obj).longValue();
        }
        if(obj instanceof Long){
            return (Long)obj;
        }
        if(obj instanceof Float){
            return ((Float)obj).longValue();
        }
        if(obj instanceof Double){
            return ((Double)obj).longValue();
        }
        if(obj instanceof Character){
            int tmpValue = (char)obj;
            return (long)tmpValue;
        }
        if(obj instanceof $Ku.by.Object.Decimal){
            return (($Ku.by.Object.Decimal)obj).longValue();
        }

        throw new RuntimeException("不支持转换的类型：" + obj.getClass());
    }

    public static java.lang.Float castToFloat(Object obj) {
        if(obj instanceof Byte){
            return ((Byte)obj).floatValue();
        }
        if(obj instanceof Short){
            return ((Short)obj).floatValue();
        }
        if(obj instanceof Integer){
            return ((Integer)obj).floatValue();
        }
        if(obj instanceof Long){
            return ((Long)obj).floatValue();
        }
        if(obj instanceof Float){
            return (Float)obj;
        }
        if(obj instanceof Double){
            return ((Double)obj).floatValue();
        }
        if(obj instanceof Character){
            int tmpValue = (char)obj;
            return (float)tmpValue;
        }
        if(obj instanceof $Ku.by.Object.Decimal){
            return (($Ku.by.Object.Decimal)obj).floatValue();
        }

        throw new RuntimeException("不支持转换的类型：" + obj.getClass());
    }

    public static java.lang.Double castToDouble(Object obj) {
        if(obj instanceof Byte){
            return ((Byte)obj).doubleValue();
        }
        if(obj instanceof Short){
            return ((Short)obj).doubleValue();
        }
        if(obj instanceof Integer){
            return ((Integer)obj).doubleValue();
        }
        if(obj instanceof Long){
            return ((Long)obj).doubleValue();
        }
        if(obj instanceof Float){
            return ((Float)obj).doubleValue();
        }
        if(obj instanceof Double){
            return (Double)obj;
        }
        if(obj instanceof Character){
            int tmpValue = (char)obj;
            return (double)tmpValue;
        }
        if(obj instanceof $Ku.by.Object.Decimal){
            return (($Ku.by.Object.Decimal)obj).doubleValue();
        }
        throw new RuntimeException("不支持转换的类型：" + obj.getClass());
    }

    public static java.lang.Character castToCharacter(Object obj) {
        if(obj instanceof Byte){
            byte tmpValue = (Byte)obj;
            return (char)tmpValue;
        }
        if(obj instanceof Short){
            short tmpValue = (Short)obj;
            return (char)tmpValue;
        }
        if(obj instanceof Integer){
            short tmpValue = ((Integer)obj).shortValue();
            return (char)tmpValue;
        }
        if(obj instanceof Long){
            short tmpValue = ((Long)obj).shortValue();
            return (char)tmpValue;
        }
        if(obj instanceof Float){
            short tmpValue = ((Float)obj).shortValue();
            return (char)tmpValue;
        }
        if(obj instanceof Double){
            short tmpValue = ((Double)obj).shortValue();
            return (char)tmpValue;
        }
        if(obj instanceof Character){
            return (Character)obj;
        }
        if(obj instanceof $Ku.by.Object.Decimal){
            return (($Ku.by.Object.Decimal)obj).charValue();
        }

        throw new RuntimeException("不支持转换的类型：" + obj.getClass());
    }

    public static java.lang.Boolean castToBoolean(Object obj) {
        return Boolean.valueOf(obj.toString());
    }

    public static $Ku.by.Object.Decimal castToDecimal(Object obj) {
        return new $Ku.by.Object.Decimal(obj.toString());
    }

    public static java.lang.String GenerateDeleteFrom($Ku.by.ToolClass.Sql.AbstractTable f_Target, $Ku.by.ToolClass.DBTypeEnum f_DBType) {
        StringBuilder tmpSB = new StringBuilder("DELETE ");
        //现在f_Tables中只会存在一张表
        if (f_DBType == DBTypeEnum.SqlServer)
        {
            if (f_Target.getAlias() != null)
            {
                tmpSB.append("[").append(f_Target.getAlias()).append("] ");
            }
        }

        tmpSB.append("FROM ");
        tmpSB.append(TableToCode(f_Target));
        return tmpSB.toString();
    }

    public static void RowComponentAssignRow($Ku.by.Object.Row f_ComponentRow, $Ku.by.Object.Row f_Row, java.lang.String f_Component) {
        if (f_Row == null || f_ComponentRow == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.RowsIsNull);
        }
        //目前不支持不同库
        if (!Objects.equals(f_ComponentRow.getKuName(), f_Row.getKuName())) {
            $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(ErrorInfo.DifferentKuInRelationExpression);
        }
        BaseKu tmpKu = Root.GetInstance().get(f_Row.getKuName());
        IBaseDataSheet tmpDataSheet = GetDataSheet(tmpKu.Name, f_ComponentRow.getSheetName());
        if (!tmpDataSheet.getComponentDic().containsKey(f_Component)) {
            $Ku.by.ToolClass.ThrowHelper.ThrowDataMatchException(String.format(ErrorInfo.CanNotFindComponentInSheet, tmpDataSheet.getSheetName(), f_Component));
        }
        $Ku.by.ToolClass.Sql.SqlField tmpField = tmpDataSheet.getComponentDic().get(f_Component);
        String tmpComponentQualifiedName = tmpKu.Name + "." + tmpField.getSheetName() + "." + tmpField.getName();
        $Ku.by.Object.Cell tmpCell = f_ComponentRow.getItem(tmpComponentQualifiedName);
        if (tmpCell.DataTypeEnum == DataTypeEnum.None) {
            tmpCell.DataTypeEnum = tmpField.getFieldType();
            tmpCell.EnumType = tmpField.getEnumType();
        }
        //已经做过同库的限制
        String tmpCellQualifiedName = tmpCell.SheetName + "." + tmpCell.ColumnName;
        $Ku.by.Object.Cell tmpMatchedCell = null;
        for ($Ku.by.Object.Cell item : f_Row.cells) {
            if (item.KuName == null || !item.KuName.equals(tmpKu.Name)) {
                continue;
            }
            String tmpQualifiedName = item.SheetName +
                    "." + item.ColumnName;
            if (FieldHasReference(tmpKu, tmpCellQualifiedName, tmpQualifiedName)) {
                tmpMatchedCell = item;
                break;
            }
            if (tmpCellQualifiedName.equals(tmpQualifiedName)) {
                tmpMatchedCell = item;
                break;
            }
        }
        if (tmpMatchedCell == null) {
            return;
        }
        if (tmpMatchedCell.value == null) {
            $Ku.by.ToolClass.ThrowHelper.ThrowRelationOperationException(ErrorInfo.CanNotAssignmentNullToRowValue);
        }
        if (tmpMatchedCell.DataTypeEnum == DataTypeEnum.None) {
            tmpMatchedCell.DataTypeEnum = tmpCell.DataTypeEnum;

            tmpMatchedCell.EnumType = tmpCell.EnumType;
        }
        tmpCell.value = tmpMatchedCell.value;
    }

    public static void RowComponentAssignment($Ku.by.Object.Cell f_Cell, Object f_Value, java.lang.String f_Operator) {
        //+-*/%&|<<>>^
        if (f_Cell.DataTypeEnum == DataTypeEnum.None)
        {
            return;
        }

        if (f_Value == null)
        {
            CheckNullBeforeAssignment(f_Cell.DataTypeEnum, f_Cell.EnumType);
        }

        String tmpOperator = f_Operator.trim();
        Class<?> tmpValueType = null;
        if (f_Value != null) {
            tmpValueType = f_Value.getClass();
        }

        try
        {
            //默认单元格里面的值没有问题
            switch (f_Cell.DataTypeEnum)
            {
                case Bool:
                    if (tmpValueType != null) {
                        throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, "bool", tmpValueType.getName()));
                    }
                case Byte:
                    byte tmpByteValue = (byte)f_Value;
                    byte tmpByteCellValue = (byte)f_Cell.value;
                    switch (tmpOperator) {
                        case "+=":
                            tmpByteCellValue += tmpByteValue;
                            break;
                        case "-=":
                            tmpByteCellValue -= tmpByteValue;
                            break;
                        case "*=":
                            tmpByteCellValue *= tmpByteValue;
                            break;
                        case "/=":
                            tmpByteCellValue /= tmpByteValue;
                            break;
                        case "%=":
                            tmpByteCellValue %= tmpByteValue;
                            break;
                        case "^=":
                            tmpByteCellValue ^= tmpByteValue;
                            break;
                        case "&=":
                            tmpByteCellValue &= tmpByteValue;
                            break;
                        case "|=":
                            tmpByteCellValue |= tmpByteValue;
                            break;
                        case ">>=":
                            tmpByteCellValue >>= tmpByteValue;
                            break;
                        case "<<=":
                            tmpByteCellValue <<= tmpByteValue;
                            break;
                        default:
                            if (tmpValueType != null) {
                                throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                            }
                    }
                    f_Cell.value = tmpByteCellValue;
                    break;
                case Char:
                    char tmpCharValue = (char)f_Value;
                    char tmpCharCellValue = (char)f_Cell.value;
                    switch (tmpOperator) {
                        case "+=":
                            tmpCharCellValue += tmpCharValue;
                            break;
                        case "-=":
                            tmpCharCellValue -= tmpCharValue;
                            break;
                        case "*=":
                            tmpCharCellValue *= tmpCharValue;
                            break;
                        case "/=":
                            tmpCharCellValue /= tmpCharValue;
                            break;
                        case "%=":
                            tmpCharCellValue %= tmpCharValue;
                            break;
                        case "^=":
                            tmpCharCellValue ^= tmpCharValue;
                            break;
                        case "&=":
                            tmpCharCellValue &= tmpCharValue;
                            break;
                        case "|=":
                            tmpCharCellValue |= tmpCharValue;
                            break;
                        case ">>=":
                            tmpCharCellValue >>= tmpCharValue;
                            break;
                        case "<<=":
                            tmpCharCellValue <<= tmpCharValue;
                            break;
                        default:
                            throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                    }
                    f_Cell.value = tmpCharCellValue;
                    break;
                case Datetime:
                    if (tmpValueType != null) {
                        throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, "Datetime", tmpValueType.getName()));
                    }
                case Decimal:
                    $Ku.by.Object.Decimal tmpDecimalValue = ($Ku.by.Object.Decimal)f_Value;
                    $Ku.by.Object.Decimal tmpDecimalCellValue = ($Ku.by.Object.Decimal)f_Cell.value;
                    int result = tmpDecimalCellValue.intValue();
                    switch (tmpOperator) {
                        case "+=":
                            result += tmpDecimalValue.intValue();
                            break;
                        case "-=":
                            result -= tmpDecimalValue.intValue();
                            break;
                        case "*=":
                            result *= tmpDecimalValue.intValue();
                            break;
                        case "/=":
                            result /= tmpDecimalValue.intValue();
                            break;
                        case "%=":
                            result %= tmpDecimalValue.intValue();
                            break;
                        default:
                            throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                    }
                    result += tmpDecimalValue.intValue();
                    f_Cell.value = $Ku.by.Object.Decimal.parse(Integer.toString(result));
                    break;
                case Double:
                    double tmpDoubleValue = (double) f_Value;
                    double tmpDoubleCellValue = (double)f_Cell.value;
                    switch (tmpOperator) {
                        case "+=":
                            tmpDoubleCellValue += tmpDoubleValue;
                            break;
                        case "-=":
                            tmpDoubleCellValue -= tmpDoubleValue;
                            break;
                        case "*=":
                            tmpDoubleCellValue *= tmpDoubleValue;
                            break;
                        case "/=":
                            tmpDoubleCellValue /= tmpDoubleValue;
                            break;
                        case "%=":
                            tmpDoubleCellValue %= tmpDoubleValue;
                            break;
                        default:
                            throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                    }
                    tmpDoubleCellValue += tmpDoubleValue;
                    f_Cell.value = tmpDoubleCellValue;
                    break;
                case Enum:
                    throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                case Float:
                    float tmpFloatValue = (float)f_Value;
                    float tmpFloatCellValue = (float)f_Cell.value;
                    switch (tmpOperator) {
                        case "+=":
                            tmpFloatCellValue += tmpFloatValue;
                            break;
                        case "-=":
                            tmpFloatCellValue -= tmpFloatValue;
                            break;
                        case "*=":
                            tmpFloatCellValue *= tmpFloatValue;
                            break;
                        case "/=":
                            tmpFloatCellValue /= tmpFloatValue;
                            break;
                        case "%=":
                            tmpFloatCellValue %= tmpFloatValue;
                            break;
                        default:
                            throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                    }
                    f_Cell.value = tmpFloatCellValue;
                    break;
                case Int:
                    int tmpIntValue = (int)f_Value;
                    int tmpIntCellValue = (int)f_Cell.value;
                    switch (tmpOperator) {
                        case "+=":
                            tmpIntCellValue += tmpIntValue;
                            break;
                        case "-=":
                            tmpIntCellValue -= tmpIntValue;
                            break;
                        case "*=":
                            tmpIntCellValue *= tmpIntValue;
                            break;
                        case "/=":
                            tmpIntCellValue /= tmpIntValue;
                            break;
                        case "%=":
                            tmpIntCellValue %= tmpIntValue;
                            break;
                        case "^=":
                            tmpIntCellValue ^= tmpIntValue;
                            break;
                        case "&=":
                            tmpIntCellValue &= tmpIntValue;
                            break;
                        case "|=":
                            tmpIntCellValue |= tmpIntValue;
                            break;
                        case ">>=":
                            tmpIntCellValue >>= tmpIntValue;
                            break;
                        case "<<=":
                            tmpIntCellValue <<= tmpIntValue;
                            break;
                        default:
                            throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                    }
                    f_Cell.value = tmpIntCellValue;
                    break;
                case Long:
                    long tmpLongValue = (long)f_Value;
                    long tmpLongCellValue = (long)f_Cell.value;
                    switch (tmpOperator) {
                        case "+=":
                            tmpLongCellValue += tmpLongValue;
                            break;
                        case "-=":
                            tmpLongCellValue -= tmpLongValue;
                            break;
                        case "*=":
                            tmpLongCellValue *= tmpLongValue;
                            break;
                        case "/=":
                            tmpLongCellValue /= tmpLongValue;
                            break;
                        case "%=":
                            tmpLongCellValue %= tmpLongValue;
                            break;
                        case "^=":
                            tmpLongCellValue ^= tmpLongValue;
                            break;
                        case "&=":
                            tmpLongCellValue &= tmpLongValue;
                            break;
                        case "|=":
                            tmpLongCellValue |= tmpLongValue;
                            break;
                        default:
                            throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                    }
                    f_Cell.value = tmpLongCellValue;
                    break;
                case Short:
                    short tmpShortValue = (short)f_Value;
                    short tmpShortCellValue = (short)f_Cell.value;
                    switch (tmpOperator) {
                        case "+=":
                            tmpShortCellValue += tmpShortValue;
                            break;
                        case "-=":
                            tmpShortCellValue -= tmpShortValue;
                            break;
                        case "*=":
                            tmpShortCellValue *= tmpShortValue;
                            break;
                        case "/=":
                            tmpShortCellValue /= tmpShortValue;
                            break;
                        case "%=":
                            tmpShortCellValue %= tmpShortValue;
                            break;
                        case "^=":
                            tmpShortCellValue ^= tmpShortValue;
                            break;
                        case "&=":
                            tmpShortCellValue &= tmpShortValue;
                            break;
                        case "|=":
                            tmpShortCellValue |= tmpShortValue;
                            break;
                        case ">>=":
                            tmpShortCellValue >>= tmpShortValue;
                            break;
                        case "<<=":
                            tmpShortCellValue <<= tmpShortValue;
                            break;
                        default:
                            if (tmpValueType != null) {
                                throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, f_Cell.value.getClass().getName(), tmpValueType.getName()));
                            }
                            break;
                    }
                    tmpShortCellValue += tmpShortValue;
                    f_Cell.value = tmpShortCellValue;
                    break;
                case String:
                    if (tmpOperator.equals("+="))
                    {
                        String tmpStringCellValue = null;
                        if (f_Cell.value instanceof String) {
                            tmpStringCellValue = (String)f_Cell.value;
                        }
                        tmpStringCellValue += f_Value;
                        f_Cell.value = tmpStringCellValue;
                        break;
                    }
                    else
                    {
                        if (tmpValueType != null) {
                            throw new TheKnownException(String.format(ErrorInfo.AssignmentNotAllowed, tmpOperator, "String", tmpValueType.getName()));
                        }
                    }
            }
        }
        catch (java.lang.Exception ex)
        {
            if (ex instanceof TheKnownException || ex instanceof $Ku.by.Object.ByException.StackOverflowException)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(ex.getMessage());
            }

            if (f_Cell.DataTypeEnum == DataTypeEnum.Enum)
            {
                $Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.CannotConvertType, f_Cell.EnumType.getName()));
            }
            $Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.CannotConvertType, f_Cell.DataTypeEnum.toString().toLowerCase()));
        }
    }

    private static void CheckNullBeforeAssignment($Ku.by.ToolClass.DataTypeEnum f_Type, java.lang.Class f_EnumType) {
        String tmpValueTypeName = null;
        switch (f_Type)
        {
            case Bool:
                tmpValueTypeName = "bool";
                break;
            case Byte:
                tmpValueTypeName = "byte";
                break;
            case Char:
                tmpValueTypeName = "char";
                break;
            case Decimal:
                tmpValueTypeName = "decimal";
                break;
            case Double:
                tmpValueTypeName = "double";
                break;
            case Enum:
                if (f_EnumType == null)
                {
                    tmpValueTypeName = "enum";
                }
                else
                {
                    tmpValueTypeName = f_EnumType.getName();
                }
                break;
            case Float:
                tmpValueTypeName = "float";
                break;
            case Int:
                tmpValueTypeName = "int";
                break;
            case Long:
                tmpValueTypeName = "long";
                break;
            case Short:
                tmpValueTypeName = "short";
                break;
            default:
                break;
        }

        if (tmpValueTypeName != null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowVerifyException(String.format(ErrorInfo.CannotConvertNull, tmpValueTypeName));
        }
    }

    public static $Ku.by.Identity.Table GetIdentityOfRow($Ku.by.Object.Row f_Row) {
        if (f_Row == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.RowDmlRowIsNull);
        }

        return ($Ku.by.Identity.Table)f_Row.$Identity;
    }

    public static java.lang.Boolean DoubleTypeIs(Object f_LHS, java.lang.Class<?> f_ObjectType, java.lang.Class<?> f_IdentityType) {
        Class<?> tmpLType = f_LHS.getClass();
        java.lang.reflect.Field tmpLIdentityProp = null;
        try {
            tmpLIdentityProp = tmpLType.getField("$Identity");
        } catch (NoSuchFieldException e) {
            throw new RuntimeException(e);
        }

        Object tmpLIdentityInstance = null;
        try {
            tmpLIdentityInstance = tmpLIdentityProp.get(f_LHS);
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }

        if (tmpLIdentityInstance == null)
        {
            return false;
        }

        Class<?> tmpLActualIdentityType = tmpLIdentityInstance.getClass();
        boolean tmpObjectIs = false;
        boolean tmpIdentityIs = true;

        if (tmpLType == f_ObjectType || tmpLType.isAssignableFrom(f_ObjectType))
        {
            tmpObjectIs = true;
        }

        if (tmpLActualIdentityType == f_IdentityType || f_IdentityType.isAssignableFrom(tmpLActualIdentityType) || Is(tmpLIdentityInstance, f_IdentityType))
        {
            tmpIdentityIs = true;
        }

        if (tmpObjectIs && tmpIdentityIs)
        {
            return true;
        }

        return false;
    }

    public static java.lang.Boolean DoubleTypeIsIdentity(Object f_Value, java.lang.Class<?> f_IdentityType) {
        Class<?> tmpType = f_Value.getClass();
        //双类型
        java.lang.reflect.Field[] tmpProps = tmpType.getFields();
        for (java.lang.reflect.Field item : tmpProps)
        {
            if (item.getName().equals("$Identity")) {
                Object tmpPropInstance = null;
                try {
                    tmpPropInstance = item.get(f_Value);
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
                if (tmpPropInstance == null) {
                    return false;
                }
                return Class.class == f_IdentityType;
            }
        }

        return false;
    }

    public static <T> T AsJudge(Object f_Value, java.lang.Class<T> f_Class) {
        Class<?> tmpOjType = f_Value.getClass();
        java.lang.reflect.Field[] tmpProps = tmpOjType.getFields();
        for (java.lang.reflect.Field item : tmpProps)
        {
            if (item.getName().equals("$Identity"))
            {
                Object tmpPropInstance = null;
                try {
                    tmpPropInstance = item.get(f_Value);
                } catch (IllegalAccessException e) {
                    throw new RuntimeException(e);
                }
                return f_Class.cast(tmpPropInstance);
            }
        }
        return null;
    }

    public static java.lang.String TernaryExpression(Object f_Condition, Object f_Then, Object f_Else, $Ku.by.ToolClass.DBTypeEnum f_DBTypeEnum) {
        StringBuilder tmpValue = new StringBuilder();

        if (f_Condition == null)
        {
            $Ku.by.ToolClass.ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ConditionIsNull);
        }

        if (f_DBTypeEnum == DBTypeEnum.SqlServer)
        {
            tmpValue.append(" CASE WHEN ");
            tmpValue.append(f_Condition);
            tmpValue.append(" THEN ");

            if (f_Then == null)
            {
                tmpValue.append("NULL");
            }
            else
            {
                tmpValue.append(f_Then);
            }

            tmpValue.append(" ELSE ");

            if (f_Else == null)
            {
                tmpValue.append("NULL");
            }
            else
            {
                tmpValue.append(f_Else);
            }

            tmpValue.append(" END ");
            return tmpValue.toString();
        }

        if (f_DBTypeEnum == DBTypeEnum.Mysql)
        {
            tmpValue.append(" IF(");
            tmpValue.append(f_Condition);
            tmpValue.append(", ");
            tmpValue.append(f_Then);
            tmpValue.append(", ");
            tmpValue.append(f_Else);
            tmpValue.append(") ");
            return tmpValue.toString();
        }

        return null;
    }

    public static Object PreAdd($Ku.by.Object.Row f_Row, java.lang.String f_ComponentName) {
        $Ku.by.Object.Cell tmpCell = GetRowComponent(f_Row, f_ComponentName);
        if(tmpCell.value instanceof Character){
            Character tmpValue = (Character) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue + 1;
        }
        if(tmpCell.value instanceof Byte){
            Byte tmpValue = (Byte) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue + 1;
        }
        if(tmpCell.value instanceof Short){
            Short tmpValue = (Short) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue + 1;
        }
        if(tmpCell.value instanceof Integer){
            Integer tmpValue = (Integer) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue + 1;
        }
        if(tmpCell.value instanceof Long){
            Long tmpValue = (Long) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue + 1;
        }
        if(tmpCell.value instanceof Float){
            Float tmpValue = (Float) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue + 1;
        }
        if(tmpCell.value instanceof Double){
            Double tmpValue = (Double) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue + 1;
        }
        if(tmpCell.value instanceof $Ku.by.Object.Decimal){
            $Ku.by.Object.Decimal tmpValue = ($Ku.by.Object.Decimal) tmpCell.value;
            return tmpValue.decimalPrefixIncrement();
        }
        throw new RuntimeException("PreAdd不支持的数据类型：" + tmpCell.value.getClass());
    }

    public static Object PreSub($Ku.by.Object.Row f_Row, java.lang.String f_ComponentName) {
        $Ku.by.Object.Cell tmpCell = GetRowComponent(f_Row, f_ComponentName);
        if(tmpCell.value instanceof Character){
            Character tmpValue = (Character) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue - 1;
        }
        if(tmpCell.value instanceof Byte){
            Byte tmpValue = (Byte) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue - 1;
        }
        if(tmpCell.value instanceof Short){
            Short tmpValue = (Short) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue - 1;
        }
        if(tmpCell.value instanceof Integer){
            Integer tmpValue = (Integer) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue - 1;
        }
        if(tmpCell.value instanceof Long){
            Long tmpValue = (Long) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue - 1;
        }
        if(tmpCell.value instanceof Float){
            Float tmpValue = (Float) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue - 1;
        }
        if(tmpCell.value instanceof Double){
            Double tmpValue = (Double) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue - 1;
        }
        if(tmpCell.value instanceof $Ku.by.Object.Decimal){
            $Ku.by.Object.Decimal tmpValue = ($Ku.by.Object.Decimal) tmpCell.value;
            return tmpValue.decimalPrefixDecrement();
        }
        throw new RuntimeException("PreSub不支持的数据类型：" + tmpCell.value.getClass());
    }

    public static Object PostAdd($Ku.by.Object.Row f_Row, java.lang.String f_ComponentName) {
        $Ku.by.Object.Cell tmpCell = GetRowComponent(f_Row, f_ComponentName);
        if(tmpCell.value instanceof Character){
            Character tmpValue = (Character) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Byte){
            Byte tmpValue = (Byte) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Short){
            Short tmpValue = (Short) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Integer){
            Integer tmpValue = (Integer) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Long){
            Long tmpValue = (Long) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Float){
            Float tmpValue = (Float) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue - 1;
        }
        if(tmpCell.value instanceof Double){
            Double tmpValue = (Double) tmpCell.value;
            tmpCell.value = tmpValue + 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof $Ku.by.Object.Decimal){
            $Ku.by.Object.Decimal tmpValue = ($Ku.by.Object.Decimal) tmpCell.value;
            return tmpValue.decimalPostfixIncrement();
        }
        throw new RuntimeException("PostAdd不支持的数据类型：" + tmpCell.value.getClass());
    }

    public static Object PostSub($Ku.by.Object.Row f_Row, java.lang.String f_ComponentName) {
        $Ku.by.Object.Cell tmpCell = GetRowComponent(f_Row, f_ComponentName);
        if(tmpCell.value instanceof Character){
            Character tmpValue = (Character) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Byte){
            Byte tmpValue = (Byte) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Short){
            Short tmpValue = (Short) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Integer){
            Integer tmpValue = (Integer) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Long){
            Long tmpValue = (Long) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Float){
            Float tmpValue = (Float) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof Double){
            Double tmpValue = (Double) tmpCell.value;
            tmpCell.value = tmpValue - 1;
            return tmpValue;
        }
        if(tmpCell.value instanceof $Ku.by.Object.Decimal){
            $Ku.by.Object.Decimal tmpValue = ($Ku.by.Object.Decimal) tmpCell.value;
            return tmpValue.decimalPrefixDecrement();
        }
        throw new RuntimeException("PostSub不支持的数据类型：" + tmpCell.value.getClass());
    }

    public static java.lang.Byte CompoundAssignmentReturnSbyte($Ku.by.Object.Row f_Row, java.lang.String f_ComponentName, java.lang.Byte f_RValue, java.lang.String f_Operator) {
        Cell tmpCell = GetRowComponent(f_Row, f_ComponentName);
        Object tmpCellValueObj = tmpCell.value;
        byte tmpCellValue;

        // 如果 tmpCellValueObj 是一个 Number 类型，可以直接调用 byteValue() 方法
        if (tmpCellValueObj instanceof Number) {
            Number number = (Number) tmpCellValueObj;
            tmpCellValue = number.byteValue();
        } else if (tmpCellValueObj instanceof String) {
            // 如果 tmpCellValueObj 是一个字符串，尝试解析为 byte
            String stringValue = (String) tmpCellValueObj;
            tmpCellValue = Byte.parseByte(stringValue);
        } else {
            // 如果 tmpCellValueObj 不是 Number 也不是 String，则抛出异常
            throw new IllegalArgumentException("Cannot convert value of type " + tmpCellValueObj.getClass().getName() + " to byte");
        }

        if (Objects.equals(f_Operator, "+")) {
            Byte tmpNewValue = (byte) (tmpCellValue + f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else if (Objects.equals(f_Operator, "-")) {
            Byte tmpNewValue = (byte) (tmpCellValue - f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else if (Objects.equals(f_Operator, "*")) {
            Byte tmpNewValue = (byte) (tmpCellValue * f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else if (Objects.equals(f_Operator, "/")) {
            Byte tmpNewValue = (byte) (tmpCellValue / f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else if (Objects.equals(f_Operator, "%")) {
            Byte tmpNewValue = (byte) (tmpCellValue % f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else if (Objects.equals(f_Operator, "&")) {
            Byte tmpNewValue = (byte) (tmpCellValue & f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else if (Objects.equals(f_Operator, "|")) {
            Byte tmpNewValue = (byte) (tmpCellValue | f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else if (Objects.equals(f_Operator, "^")) {
            Byte tmpNewValue = (byte) (tmpCellValue ^ f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else if (Objects.equals(f_Operator, ">>")) {
            Byte tmpNewValue = (byte) (tmpCellValue >> f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        } else {
            Byte tmpNewValue = (byte) (tmpCellValue << f_RValue);
            tmpCell.value = tmpNewValue;
            return tmpNewValue;
        }
    }


    public interface Create<T>{
        public T setProps(T t, $Ku.by.ToolClass.Entry<java.lang.String, Object> ... objs) ;
    }
}
