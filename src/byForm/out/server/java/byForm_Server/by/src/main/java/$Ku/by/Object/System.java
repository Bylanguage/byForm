package $Ku.by.Object;

import java.io.*;
import java.net.*;
import java.util.*;
public class System extends $Ku.by.Object.ByObject {
    public static java.lang.String language = java.util.Locale.getDefault().toString().replace("_", "-");

    private System() {
    }


    public static java.lang.String getLanguage() {
        return  language;
    }

    public static java.lang.String setLanguage(java.lang.String value) {
        language = value;

        String[] values = value.split("-");
        java.util.ResourceBundle resourceBundle = null;
        try{
            resourceBundle = java.util.ResourceBundle.getBundle("ErrorInfo", new  java.util.Locale(values[0], values[1]), new UTF8Control());
        } catch (java.lang.Exception e){

            e.printStackTrace();
        }
        if(resourceBundle != null){
            $Ku.by.ToolClass.ErrorInfo.ParseSessionIDError = resourceBundle.getString("ParseSessionIDError");
            $Ku.by.ToolClass.ErrorInfo.PositiveInfinity = resourceBundle.getString("PositiveInfinity");
            $Ku.by.ToolClass.ErrorInfo.FuncTypeMatchError = resourceBundle.getString("FuncTypeMatchError");
            $Ku.by.ToolClass.ErrorInfo.ConditionIsNull = resourceBundle.getString("ConditionIsNull");
            $Ku.by.ToolClass.ErrorInfo.DirectoryNotFound = resourceBundle.getString("DirectoryNotFound");
            $Ku.by.ToolClass.ErrorInfo.FileNotFound = resourceBundle.getString("FileNotFound");
            $Ku.by.ToolClass.ErrorInfo.FileReadingError = resourceBundle.getString("FileReadingError");
            $Ku.by.ToolClass.ErrorInfo.FileAppendingError = resourceBundle.getString("FileAppendingError");
            $Ku.by.ToolClass.ErrorInfo.FileWritingError = resourceBundle.getString("FileWritingError");
            $Ku.by.ToolClass.ErrorInfo.FileCopyingError = resourceBundle.getString("FileCopyingError");
            $Ku.by.ToolClass.ErrorInfo.FileMovingError = resourceBundle.getString("FileMovingError");
            $Ku.by.ToolClass.ErrorInfo.FileExistError = resourceBundle.getString("FileExistError");
            $Ku.by.ToolClass.ErrorInfo.FileCreatingError = resourceBundle.getString("FileCreatingError");
            $Ku.by.ToolClass.ErrorInfo.OrderbyUnClearColumn = resourceBundle.getString("OrderbyUnClearColumn");
            $Ku.by.ToolClass.ErrorInfo.ColumnsNotMatch = resourceBundle.getString("ColumnsNotMatch");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindSheetInKu = resourceBundle.getString("CanNotFindSheetInKu");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindFlowInSheet = resourceBundle.getString("CanNotFindFlowInSheet");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindComponentInSheet = resourceBundle.getString("CanNotFindComponentInSheet");
            $Ku.by.ToolClass.ErrorInfo.ComponentInSheetHasNotConfigureField = resourceBundle.getString("ComponentInSheetHasNotConfigureField");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindFieldInSheet = resourceBundle.getString("CanNotFindFieldInSheet");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindRelationCellInRow = resourceBundle.getString("CanNotFindRelationCellInRow");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindConfigList = resourceBundle.getString("CanNotFindConfigList");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindConfig = resourceBundle.getString("CanNotFindConfig");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindKu = resourceBundle.getString("CanNotFindKu");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindDataSheetByInstance = resourceBundle.getString("CanNotFindDataSheetByInstance");
            $Ku.by.ToolClass.ErrorInfo.CanNotMatchingSource = resourceBundle.getString("CanNotMatchingSource");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindSourceSheet = resourceBundle.getString("CanNotFindSourceSheet");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindSourceSheetWithAlias = resourceBundle.getString("CanNotFindSourceSheetWithAlias");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindEnumByPath = resourceBundle.getString("CanNotFindEnumByPath");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindCellInRow = resourceBundle.getString("CanNotFindCellInRow");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindPKInSheet = resourceBundle.getString("CanNotFindPKInSheet");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindEnumValue = resourceBundle.getString("CanNotFindEnumValue");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindRelationBetweenSheets = resourceBundle.getString("CanNotFindRelationBetweenSheets");
            $Ku.by.ToolClass.ErrorInfo.NoRelationBetweenSheetsOrReferenceColumn = resourceBundle.getString("NoRelationBetweenSheetsOrReferenceColumn");
            $Ku.by.ToolClass.ErrorInfo.ComponentIsNotRelationColumn = resourceBundle.getString("ComponentIsNotRelationColumn");
            $Ku.by.ToolClass.ErrorInfo.ExistRowFromDifferentSheet = resourceBundle.getString("ExistRowFromDifferentSheet");
            $Ku.by.ToolClass.ErrorInfo.IllegalFillFrom = resourceBundle.getString("IllegalFillFrom");
            $Ku.by.ToolClass.ErrorInfo.IllegalComponent = resourceBundle.getString("IllegalComponent");
            $Ku.by.ToolClass.ErrorInfo.IllegalRowParameter = resourceBundle.getString("IllegalRowParameter");
            $Ku.by.ToolClass.ErrorInfo.DifferentParameterOfInsert = resourceBundle.getString("DifferentParameterOfInsert");
            $Ku.by.ToolClass.ErrorInfo.HasRepetitiveField = resourceBundle.getString("HasRepetitiveField");
            $Ku.by.ToolClass.ErrorInfo.InsertValueIsNull = resourceBundle.getString("InsertValueIsNull");
            $Ku.by.ToolClass.ErrorInfo.UpdateValueIsNull = resourceBundle.getString("UpdateValueIsNull");
            $Ku.by.ToolClass.ErrorInfo.InsertValueHasNoValue = resourceBundle.getString("InsertValueHasNoValue");
            $Ku.by.ToolClass.ErrorInfo.EmptyEnum = resourceBundle.getString("EmptyEnum");
            $Ku.by.ToolClass.ErrorInfo.UnKnowType = resourceBundle.getString("UnKnowType");
            $Ku.by.ToolClass.ErrorInfo.RowIsNull = resourceBundle.getString("RowIsNull");
            $Ku.by.ToolClass.ErrorInfo.RowsIsNull = resourceBundle.getString("RowsIsNull");
            $Ku.by.ToolClass.ErrorInfo.RowsHasNoRow = resourceBundle.getString("RowsHasNoRow");
            $Ku.by.ToolClass.ErrorInfo.UnCurrentSheetField = resourceBundle.getString("UnCurrentSheetField");
            $Ku.by.ToolClass.ErrorInfo.QueryAreaParameterError = resourceBundle.getString("QueryAreaParameterError");
            $Ku.by.ToolClass.ErrorInfo.UnKnownQueryDataParameter = resourceBundle.getString("UnKnownQueryDataParameter");
            $Ku.by.ToolClass.ErrorInfo.RelationOverFlow = resourceBundle.getString("RelationOverFlow");
            $Ku.by.ToolClass.ErrorInfo.HavingInSimpleQuery = resourceBundle.getString("HavingInSimpleQuery");
            $Ku.by.ToolClass.ErrorInfo.DifferentKuInRelationExpression = resourceBundle.getString("DifferentKuInRelationExpression");
            $Ku.by.ToolClass.ErrorInfo.SeveralRelationCells = resourceBundle.getString("SeveralRelationCells");
            $Ku.by.ToolClass.ErrorInfo.HasNullRowInRows = resourceBundle.getString("HasNullRowInRows");
            $Ku.by.ToolClass.ErrorInfo.ParseSheetNameError = resourceBundle.getString("ParseSheetNameError");
            $Ku.by.ToolClass.ErrorInfo.ParseKuNameError = resourceBundle.getString("ParseKuNameError");
            $Ku.by.ToolClass.ErrorInfo.ParseParamsError = resourceBundle.getString("ParseParamsError");
            $Ku.by.ToolClass.ErrorInfo.ParseParamsTypeError = resourceBundle.getString("ParseParamsTypeError");
            $Ku.by.ToolClass.ErrorInfo.ParseParamsValueError = resourceBundle.getString("ParseParamsValueError");
            $Ku.by.ToolClass.ErrorInfo.ParseRequestError = resourceBundle.getString("ParseRequestError");
            $Ku.by.ToolClass.ErrorInfo.ParseIneffectiveRequest = resourceBundle.getString("ParseIneffectiveRequest");
            $Ku.by.ToolClass.ErrorInfo.ParseNoError = resourceBundle.getString("ParseNoError");
            $Ku.by.ToolClass.ErrorInfo.ParseFromError = resourceBundle.getString("ParseFromError");
            $Ku.by.ToolClass.ErrorInfo.ParseTranParametersError = resourceBundle.getString("ParseTranParametersError");
            $Ku.by.ToolClass.ErrorInfo.ParseIllegalTranParameter = resourceBundle.getString("ParseIllegalTranParameter");
            $Ku.by.ToolClass.ErrorInfo.ParseRowColumnsError = resourceBundle.getString("ParseRowColumnsError");
            $Ku.by.ToolClass.ErrorInfo.ParseRowValueError = resourceBundle.getString("ParseRowValueError");
            $Ku.by.ToolClass.ErrorInfo.ParseIllegalRow = resourceBundle.getString("ParseIllegalRow");
            $Ku.by.ToolClass.ErrorInfo.ParseSourceError = resourceBundle.getString("ParseSourceError");
            $Ku.by.ToolClass.ErrorInfo.ParseIdentityError = resourceBundle.getString("ParseIdentityError");
            $Ku.by.ToolClass.ErrorInfo.ParseCanNotFindSource = resourceBundle.getString("ParseCanNotFindSource");
            $Ku.by.ToolClass.ErrorInfo.ParseCanNotMatchintMethod = resourceBundle.getString("ParseCanNotMatchintMethod");
            $Ku.by.ToolClass.ErrorInfo.ParseCannotFindActionKu = resourceBundle.getString("ParseCannotFindActionKu");
            $Ku.by.ToolClass.ErrorInfo.ParseQueryParamsSheetNodeMissing = resourceBundle.getString("ParseQueryParamsSheetNodeMissing");
            $Ku.by.ToolClass.ErrorInfo.ParseQueryValueMissing = resourceBundle.getString("ParseQueryValueMissing");
            $Ku.by.ToolClass.ErrorInfo.ParseQueryNameError = resourceBundle.getString("ParseQueryNameError");
            $Ku.by.ToolClass.ErrorInfo.ParseQueryValueError = resourceBundle.getString("ParseQueryValueError");
            $Ku.by.ToolClass.ErrorInfo.ParseSheetNameFormatError = resourceBundle.getString("ParseSheetNameFormatError");
            $Ku.by.ToolClass.ErrorInfo.ParseCannotFindQueryName = resourceBundle.getString("ParseCannotFindQueryName");
            $Ku.by.ToolClass.ErrorInfo.ParseQueryValueCountNotMatch = resourceBundle.getString("ParseQueryValueCountNotMatch");
            $Ku.by.ToolClass.ErrorInfo.ParseIllegalQueryValue = resourceBundle.getString("ParseIllegalQueryValue");
            $Ku.by.ToolClass.ErrorInfo.ParseIllegalBetweenLength = resourceBundle.getString("ParseIllegalBetweenLength");
            $Ku.by.ToolClass.ErrorInfo.ParseBetweenValueIsNull = resourceBundle.getString("ParseBetweenValueIsNull");
            $Ku.by.ToolClass.ErrorInfo.ParseIllegalJsonObj = resourceBundle.getString("ParseIllegalJsonObj");
            $Ku.by.ToolClass.ErrorInfo.ColumnNotNull = resourceBundle.getString("ColumnNotNull");
            $Ku.by.ToolClass.ErrorInfo.IllegalDatetime = resourceBundle.getString("IllegalDatetime");
            $Ku.by.ToolClass.ErrorInfo.IllegalDecimal = resourceBundle.getString("IllegalDecimal");
            $Ku.by.ToolClass.ErrorInfo.IllegalInt = resourceBundle.getString("IllegalInt");
            $Ku.by.ToolClass.ErrorInfo.IllegalShort = resourceBundle.getString("IllegalShort");
            $Ku.by.ToolClass.ErrorInfo.IllegalLong = resourceBundle.getString("IllegalLong");
            $Ku.by.ToolClass.ErrorInfo.IllegalByte = resourceBundle.getString("IllegalByte");
            $Ku.by.ToolClass.ErrorInfo.IllegalFloat = resourceBundle.getString("IllegalFloat");
            $Ku.by.ToolClass.ErrorInfo.IllegalDouble = resourceBundle.getString("IllegalDouble");
            $Ku.by.ToolClass.ErrorInfo.IllegalString = resourceBundle.getString("IllegalString");
            $Ku.by.ToolClass.ErrorInfo.IllegalChar = resourceBundle.getString("IllegalChar");
            $Ku.by.ToolClass.ErrorInfo.BiggerthanMax = resourceBundle.getString("BiggerthanMax");
            $Ku.by.ToolClass.ErrorInfo.SmallerthanMin = resourceBundle.getString("SmallerthanMin");
            $Ku.by.ToolClass.ErrorInfo.VerifyFormatError = resourceBundle.getString("VerifyFormatError");
            $Ku.by.ToolClass.ErrorInfo.VerifyPattern = resourceBundle.getString("VerifyPattern");
            $Ku.by.ToolClass.ErrorInfo.VerifyDigit = resourceBundle.getString("VerifyDigit");
            $Ku.by.ToolClass.ErrorInfo.SqlUnknownError = resourceBundle.getString("SqlUnknownError");
            $Ku.by.ToolClass.ErrorInfo.FieldIsNull = resourceBundle.getString("FieldIsNull");
            $Ku.by.ToolClass.ErrorInfo.IllegalBool1 = resourceBundle.getString("IllegalBool1");
            $Ku.by.ToolClass.ErrorInfo.TableIsNull = resourceBundle.getString("TableIsNull");
            $Ku.by.ToolClass.ErrorInfo.RowTableIsDifferentFormTable = resourceBundle.getString("RowTableIsDifferentFormTable");
            $Ku.by.ToolClass.ErrorInfo.RowHasRepetitiveField = resourceBundle.getString("RowHasRepetitiveField");
            $Ku.by.ToolClass.ErrorInfo.UpdateSetIsNull = resourceBundle.getString("UpdateSetIsNull");
            $Ku.by.ToolClass.ErrorInfo.TableNotReferenceField = resourceBundle.getString("TableNotReferenceField");
            $Ku.by.ToolClass.ErrorInfo.SeveralMatchingCellsInInsertRow = resourceBundle.getString("SeveralMatchingCellsInInsertRow");
            $Ku.by.ToolClass.ErrorInfo.ConvertIdentityError = resourceBundle.getString("ConvertIdentityError");
            $Ku.by.ToolClass.ErrorInfo.RowKuNameNull = resourceBundle.getString("RowKuNameNull");
            $Ku.by.ToolClass.ErrorInfo.RowSheetNameNull = resourceBundle.getString("RowSheetNameNull");
            $Ku.by.ToolClass.ErrorInfo.RowsHasSeveralInstance = resourceBundle.getString("RowsHasSeveralInstance");
            $Ku.by.ToolClass.ErrorInfo.RowsHasServerKu = resourceBundle.getString("RowsHasServerKu");
            $Ku.by.ToolClass.ErrorInfo.ParseInstanceNameError = resourceBundle.getString("ParseInstanceNameError");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindColumn = resourceBundle.getString("CanNotFindColumn");
            $Ku.by.ToolClass.ErrorInfo.UnClearColumnName = resourceBundle.getString("UnClearColumnName");
            $Ku.by.ToolClass.ErrorInfo.FieldWithoutTableSource = resourceBundle.getString("FieldWithoutTableSource");
            $Ku.by.ToolClass.ErrorInfo.UnExceptedField = resourceBundle.getString("UnExceptedField");
            $Ku.by.ToolClass.ErrorInfo.ColumnWithoutAlias = resourceBundle.getString("ColumnWithoutAlias");
            $Ku.by.ToolClass.ErrorInfo.SelectResultAccessWithoutAlias = resourceBundle.getString("SelectResultAccessWithoutAlias");
            $Ku.by.ToolClass.ErrorInfo.OperatorIsNull = resourceBundle.getString("OperatorIsNull");
            $Ku.by.ToolClass.ErrorInfo.OperatorFieldIsNull = resourceBundle.getString("OperatorFieldIsNull");
            $Ku.by.ToolClass.ErrorInfo.IdentityNameSpaceError = resourceBundle.getString("IdentityNameSpaceError");
            $Ku.by.ToolClass.ErrorInfo.RowIdentityError = resourceBundle.getString("RowIdentityError");
            $Ku.by.ToolClass.ErrorInfo.CannotFindProp = resourceBundle.getString("CannotFindProp");
            $Ku.by.ToolClass.ErrorInfo.RowIdentityInstanceError = resourceBundle.getString("RowIdentityInstanceError");
            $Ku.by.ToolClass.ErrorInfo.RowIdentityNotMatchSheet = resourceBundle.getString("RowIdentityNotMatchSheet");
            $Ku.by.ToolClass.ErrorInfo.CellIdentityNotMatchSheet = resourceBundle.getString("CellIdentityNotMatchSheet");
            $Ku.by.ToolClass.ErrorInfo.IdentityIsNull = resourceBundle.getString("IdentityIsNull");
            $Ku.by.ToolClass.ErrorInfo.ParseCookieError = resourceBundle.getString("ParseCookieError");
            $Ku.by.ToolClass.ErrorInfo.ParseRequestMissing = resourceBundle.getString("ParseRequestMissing");
            $Ku.by.ToolClass.ErrorInfo.ParseParameterObjTypeError = resourceBundle.getString("ParseParameterObjTypeError");
            $Ku.by.ToolClass.ErrorInfo.ParseInstanceIdError = resourceBundle.getString("ParseInstanceIdError");
            $Ku.by.ToolClass.ErrorInfo.ParseJoinSheetError = resourceBundle.getString("ParseJoinSheetError");
            $Ku.by.ToolClass.ErrorInfo.ParseSqlTableError = resourceBundle.getString("ParseSqlTableError");
            $Ku.by.ToolClass.ErrorInfo.ParseRefError = resourceBundle.getString("ParseRefError");
            $Ku.by.ToolClass.ErrorInfo.RefCanNotFind = resourceBundle.getString("RefCanNotFind");
            $Ku.by.ToolClass.ErrorInfo.ConflictInstance = resourceBundle.getString("ConflictInstance");
            $Ku.by.ToolClass.ErrorInfo.ParseInstanceError = resourceBundle.getString("ParseInstanceError");
            $Ku.by.ToolClass.ErrorInfo.ParseArrayError = resourceBundle.getString("ParseArrayError");
            $Ku.by.ToolClass.ErrorInfo.UnSupportedArrayType = resourceBundle.getString("UnSupportedArrayType");
            $Ku.by.ToolClass.ErrorInfo.ParseDicError = resourceBundle.getString("ParseDicError");
            $Ku.by.ToolClass.ErrorInfo.UnSupportedDicType = resourceBundle.getString("UnSupportedDicType");
            $Ku.by.ToolClass.ErrorInfo.DicKeyIsNull = resourceBundle.getString("DicKeyIsNull");
            $Ku.by.ToolClass.ErrorInfo.ParseObjectError = resourceBundle.getString("ParseObjectError");
            $Ku.by.ToolClass.ErrorInfo.ObjectPropError = resourceBundle.getString("ObjectPropError");
            $Ku.by.ToolClass.ErrorInfo.CellValueTypeError = resourceBundle.getString("CellValueTypeError");
            $Ku.by.ToolClass.ErrorInfo.UnSupportPropType = resourceBundle.getString("UnSupportPropType");
            $Ku.by.ToolClass.ErrorInfo.UnClearIdentity = resourceBundle.getString("UnClearIdentity");
            $Ku.by.ToolClass.ErrorInfo.NotFieldIdentity = resourceBundle.getString("NotFieldIdentity");
            $Ku.by.ToolClass.ErrorInfo.NotTableIdentity = resourceBundle.getString("NotTableIdentity");
            $Ku.by.ToolClass.ErrorInfo.SkillNameIndexBug = resourceBundle.getString("SkillNameIndexBug");
            $Ku.by.ToolClass.ErrorInfo.ActionNameIndexBug = resourceBundle.getString("ActionNameIndexBug");
            $Ku.by.ToolClass.ErrorInfo.SkillNameValueBug = resourceBundle.getString("SkillNameValueBug");
            $Ku.by.ToolClass.ErrorInfo.ActionNameValueBug = resourceBundle.getString("ActionNameValueBug");
            $Ku.by.ToolClass.ErrorInfo.LimitFieldNotNamed = resourceBundle.getString("LimitFieldNotNamed");
            $Ku.by.ToolClass.ErrorInfo.JsonNumParseError = resourceBundle.getString("JsonNumParseError");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindRelationInQueryArea = resourceBundle.getString("CanNotFindRelationInQueryArea");
            $Ku.by.ToolClass.ErrorInfo.InsertFieldConflict = resourceBundle.getString("InsertFieldConflict");
            $Ku.by.ToolClass.ErrorInfo.ParseAutoNoError = resourceBundle.getString("ParseAutoNoError");
            $Ku.by.ToolClass.ErrorInfo.IdentityInstanceError = resourceBundle.getString("IdentityInstanceError");
            $Ku.by.ToolClass.ErrorInfo.SqlNameIndexBug = resourceBundle.getString("SqlNameIndexBug");
            $Ku.by.ToolClass.ErrorInfo.FlowExpressionRowSheetError = resourceBundle.getString("FlowExpressionRowSheetError");
            $Ku.by.ToolClass.ErrorInfo.SqlInTranTableSourceError = resourceBundle.getString("SqlInTranTableSourceError");
            $Ku.by.ToolClass.ErrorInfo.DifferentKuInTran = resourceBundle.getString("DifferentKuInTran");
            $Ku.by.ToolClass.ErrorInfo.KuTypeNotLoad = resourceBundle.getString("KuTypeNotLoad");
            $Ku.by.ToolClass.ErrorInfo.FlowIdentityError = resourceBundle.getString("FlowIdentityError");
            $Ku.by.ToolClass.ErrorInfo.ConflictFields = resourceBundle.getString("ConflictFields");
            $Ku.by.ToolClass.ErrorInfo.DBMethodInvocationError = resourceBundle.getString("DBMethodInvocationError");
            $Ku.by.ToolClass.ErrorInfo.CanNotAssignmentNullToRowValue = resourceBundle.getString("CanNotAssignmentNullToRowValue");
            $Ku.by.ToolClass.ErrorInfo.SelectConstSheet = resourceBundle.getString("SelectConstSheet");
            $Ku.by.ToolClass.ErrorInfo.SeveralPKInRelationSheet = resourceBundle.getString("SeveralPKInRelationSheet");
            $Ku.by.ToolClass.ErrorInfo.RelationPKIsNull = resourceBundle.getString("RelationPKIsNull");
            $Ku.by.ToolClass.ErrorInfo.UnknownErrorInReflection = resourceBundle.getString("UnknownErrorInReflection");
            $Ku.by.ToolClass.ErrorInfo.FlowInvocationFiledInRowMissing = resourceBundle.getString("FlowInvocationFiledInRowMissing");
            $Ku.by.ToolClass.ErrorInfo.ParseValueArrayError = resourceBundle.getString("ParseValueArrayError");
            $Ku.by.ToolClass.ErrorInfo.AssignmentNotAllowed = resourceBundle.getString("AssignmentNotAllowed");
            $Ku.by.ToolClass.ErrorInfo.CannotConvertType = resourceBundle.getString("CannotConvertType");
            $Ku.by.ToolClass.ErrorInfo.CannotConvertNull = resourceBundle.getString("CannotConvertNull");
            $Ku.by.ToolClass.ErrorInfo.RowDmlRowIsNull = resourceBundle.getString("RowDmlRowIsNull");
            $Ku.by.ToolClass.ErrorInfo.TranNameIndexBug = resourceBundle.getString("TranNameIndexBug");
            $Ku.by.ToolClass.ErrorInfo.ParseOrmError = resourceBundle.getString("ParseOrmError");
            $Ku.by.ToolClass.ErrorInfo.CanNotFindOrmType = resourceBundle.getString("CanNotFindOrmType");
            $Ku.by.ToolClass.ErrorInfo.ParseSaasIDError = resourceBundle.getString("ParseSaasIDError");
            $Ku.by.ToolClass.ErrorInfo.RowValueTypeConvertError = resourceBundle.getString("RowValueTypeConvertError");
            $Ku.by.ToolClass.ErrorInfo.UnsupportedDatabaseError = resourceBundle.getString("UnsupportedDatabaseError");
            $Ku.by.ToolClass.ErrorInfo.ReflectTypeOrMethodError = resourceBundle.getString("ReflectTypeOrMethodError");
            $Ku.by.ToolClass.ErrorInfo.ParseError = resourceBundle.getString("ParseError");
            $Ku.by.ToolClass.ErrorInfo.KuInitError = resourceBundle.getString("KuInitError");
            $Ku.by.ToolClass.ErrorInfo.SqlPreCompileError = resourceBundle.getString("SqlPreCompileError");
            $Ku.by.ToolClass.ErrorInfo.FuncInvocationError = resourceBundle.getString("FuncInvocationError");
            $Ku.by.ToolClass.ErrorInfo.VerifyError = resourceBundle.getString("VerifyError");
            $Ku.by.ToolClass.ErrorInfo.DataMatchError = resourceBundle.getString("DataMatchError");
            $Ku.by.ToolClass.ErrorInfo.RelationOperationError = resourceBundle.getString("RelationOperationError");
            $Ku.by.ToolClass.ErrorInfo.OrmError = resourceBundle.getString("OrmError");
            $Ku.by.ToolClass.ErrorInfo.UnKnownError = resourceBundle.getString("UnKnownError");
            $Ku.by.ToolClass.ErrorInfo.ConfigPropertiesError = resourceBundle.getString("ConfigPropertiesError");
        }
        return language;
    }

    public static java.lang.Integer autoID($Ku.by.Object.Table table) {
        return autoID(table, 1);
    }

    public static java.lang.Integer autoID($Ku.by.Object.Table table, java.lang.Integer count) {
        return autoID(table,count,false);
    }

    public static java.lang.Integer autoID($Ku.by.Object.Table table, boolean needRefresh) {
        return autoID(table,1,needRefresh);
    }

    public static java.lang.Integer autoID($Ku.by.Object.Table f_table, java.lang.Integer f_Value, boolean needRefresh) {
        if (f_Value < 1)
        {
            throw new RuntimeException("autoID错误的操作数 " + f_Value);
        }

        if (needRefresh)
        {
            f_table.$RefreshMax();
        }

        f_table.max = f_table.max + f_Value;
        return f_table.max;
    }

    public static $Ku.by.Enum.SceneType currentScene() {
        return $Ku.by.Enum.SceneType.server;
    }

    public static java.lang.String currentDirectory() {
        return $Ku.by.ToolClass.Handler.currentDirectory;
    }


    static class UTF8Control extends ResourceBundle.Control {
        public ResourceBundle newBundle(String baseName, Locale locale, String format, ClassLoader loader, boolean reload) throws IllegalAccessException, InstantiationException, IOException {
            String bundleName = toBundleName(baseName, locale);
            String resourceName = toResourceName(bundleName, "properties");
            ResourceBundle bundle = null;
            InputStream stream = null;
            if (reload) {
                URL url = loader.getResource(resourceName);
                if (url != null) {
                    URLConnection connection = url.openConnection();
                    if (connection != null) {
                        connection.setUseCaches(false);
                        stream = connection.getInputStream();
                    }
                }
            } else {
                stream = loader.getResourceAsStream(resourceName);
            }
            if (stream != null) {
                try {
                    bundle = new PropertyResourceBundle(new InputStreamReader(stream, "UTF-8"));
                } finally {
                    stream.close();
                }
            }
            return bundle;
        }
    }
}
