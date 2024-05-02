using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using byForm_Server.ku.by.ToolClass;
using byForm_Server.ku.by.ToolClass.Sql;
namespace byForm_Server.ku.byBase.SqlExpression
{
    public class OracleAssembler
    {
        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _0(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            int tmpConfigJoinTableCount = 0;
            string tmpConfigName0 = "selectPopup";
            var tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
            var tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.KuName, tmpIdentityName0, tmpConfigName0, tmpTable0.Sheet.SheetName);
            var tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.KuName, tmpConfig0);
            tmpMergedFieldList.AddRange(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, out tmpConfigJoinTableCount));
            var tmpPlusField0 = new PlusField(tmpTable0);
            tmpPlusField0.AddField("a.iID", tmpTableList);
            tmpSelectFieldList.Add(tmpPlusField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationEqualQueryData(tmpTable0, (ku.by.Object.QueryData)f_Parameter.ParameterList[0], tmpHaving, tmpConfigJoinTableCount, DBTypeEnum.Oracle, out tmpConfigJoinTableCount));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "0");

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _1(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            int tmpConfigJoinTableCount = 0;
            string tmpConfigName0 = "selectPopup";
            var tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
            var tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.KuName, tmpIdentityName0, tmpConfigName0, tmpTable0.Sheet.SheetName);
            var tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.KuName, tmpConfig0);
            tmpMergedFieldList.AddRange(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, out tmpConfigJoinTableCount));
            var tmpPlusField0 = new PlusField(tmpTable0);
            tmpPlusField0.AddField("a.iID", tmpTableList);
            tmpPlusField0.AddField("a.iParent", tmpTableList);
            tmpPlusField0.AddField("a.iName", tmpTableList);
            tmpSelectFieldList.Add(tmpPlusField0);
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationEqualQueryData(tmpTable0, (ku.by.Object.QueryData)f_Parameter.ParameterList[0], tmpHaving, tmpConfigJoinTableCount, DBTypeEnum.Oracle, out tmpConfigJoinTableCount));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "1");

        }

        public static string _2(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.Append(tmpDeleteSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static string _3(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.Append(tmpDeleteSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static string _4(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            StringBuilder tmpWhere = new StringBuilder();
            if (!(tmpRowParameter is ku.by.Object.Row))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return string.Format("\"{0}\" := 0;\r\n", f_EffectedCount);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));
            string tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Oracle);

            if (string.IsNullOrEmpty(tmpUpdateSql))
            {
                return tmpSql.ToString();
            }

            tmpSql.Append(tmpUpdateSql);
            tmpSql.AppendLine(";");
            tmpSql.AppendLine(string.Format("\"{0}\" := SQL%ROWCOUNT;", f_EffectedCount));
            return tmpSql.ToString();

        }

        public static string _5(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.Oracle);
        }

        public static string _6(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            if (!(tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpUpdateSql = ToolFunction.FillUpdateRow(row, tmpSetList, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpUpdateSql))
                {
                    continue;
                }

                tmpSql.Append(tmpUpdateSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static string _7(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.Append(tmpDeleteSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static string _8(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.Oracle);
        }

        public static string _9(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.Oracle);
        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _10(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpOrderByList.Add(new OrderByField(ToolFunction.GetOrderByField("a.iID", tmpSelectFieldList, tmpTableList, DBTypeEnum.Oracle), false));
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            ToolFunction.GenerateOrderBy(tmpOrderByList, tmpOrderBy);
            tmpSql.Append(tmpOrderBy);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "10");

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _11(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationInRows((Table)tmpTable0,(IList<ku.by.Object.Row>)f_Parameter.ParameterList[0], DBTypeEnum.Mysql));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "11");

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _12(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            int tmpConfigJoinTableCount = 0;
            string tmpConfigName0 = "selectLeft";
            var tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
            var tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.KuName, tmpIdentityName0, tmpConfigName0, tmpTable0.Sheet.SheetName);
            var tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.KuName, tmpConfig0);
            tmpMergedFieldList.AddRange(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, out tmpConfigJoinTableCount));
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationInRows((Table)tmpTable0,(IList<ku.by.Object.Row>)f_Parameter.ParameterList[0], DBTypeEnum.Mysql));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "12");

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _13(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            int tmpConfigJoinTableCount = 0;
            string tmpConfigName0 = "selectRight";
            var tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
            var tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.KuName, tmpIdentityName0, tmpConfigName0, tmpTable0.Sheet.SheetName);
            var tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.KuName, tmpConfig0);
            tmpMergedFieldList.AddRange(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, out tmpConfigJoinTableCount));
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationInRows((Table)tmpTable0,(IList<ku.by.Object.Row>)f_Parameter.ParameterList[0], DBTypeEnum.Mysql));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "13");

        }

        public static string _14(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.Oracle);
        }

        public static string _15(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.Append(tmpDeleteSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static string _16(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.Oracle);
        }

        public static string _17(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.Oracle);
        }

        public static string _18(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.Append(tmpDeleteSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _19(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();

            tmpSql.AppendLine(@"CREATE OR REPLACE FUNCTION ""ORows$byBase$19""
RETURN INT IS
EFFECTCOUNT INT;
BEGIN
EFFECTCOUNT:= 0;");
            string tmpKuName = null;            

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                if (tmpKuName == null)
                {
                    tmpKuName = tmpDataSheet.KuName;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.Append(tmpDeleteSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine("EFFECTCOUNT := EFFECTCOUNT + SQL%ROWCOUNT;");
            }

            tmpSql.AppendLine(@"RETURN  EFFECTCOUNT;
END;");
            return new SqlIDUResult(tmpSql.ToString(), "ORows$byBase$19", tmpKuName);

        }

        public static string _20(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.Append(tmpDeleteSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static string _21(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.Oracle);
        }

        public static string _22(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            var tmpRows = f_Parameter.ParameterList[0] as ICollection<ku.by.Object.Row>;
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));

            foreach (var row in tmpRows)
            {
                var tmpDataSheet = ToolFunction.GetDataSheetOfRow(row);

                if (tmpDataSheet == null)
                {
                    continue;
                }

                StringBuilder tmpWhere = new StringBuilder();
                var tmpTableList = new Table(tmpDataSheet, null);
                string tmpDeleteSql = ToolFunction.FillDeleteRow(row, tmpWhere, DBTypeEnum.Oracle);

                if (string.IsNullOrEmpty(tmpDeleteSql))
                {
                    continue;
                }

                tmpSql.Append(tmpDeleteSql);
                tmpSql.AppendLine(";");
                tmpSql.AppendLine(string.Format("\"{0}\" := \"{0}\" + SQL%ROWCOUNT;", f_EffectedCount));
            }

            return tmpSql.ToString();

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _23(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.EqualExpression(ToolFunction.ConvertFieldNameToField("a.iID", tmpTableList), SaveInspect.CharactorEscape(f_Parameter.ParameterList[0])));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "23");

        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _24(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            StringBuilder tmpSql = new StringBuilder();

                tmpSql.AppendLine(@"CREATE OR REPLACE FUNCTION ""ORows$byBase$24""
    RETURN INT IS
    EFFECTCOUNT INT;
    BEGIN
    EFFECTCOUNT:= 0;");
            tmpSql.AppendLine(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.Oracle));
                return new SqlIDUResult(tmpSql.ToString(), "ORows$byBase$24", ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));

        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _25(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            StringBuilder tmpWhere = new StringBuilder();
            if (!(tmpRowParameter is ku.by.Object.Row))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return new SqlIDUResult("", null, null);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            string tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Oracle);

            if (string.IsNullOrEmpty(tmpUpdateSql))
            {
                return new SqlIDUResult("", null, null);
                //return "";
            }

            return new SqlIDUResult(tmpUpdateSql, null, tmpDataSheet.KuName);
            //return tmpUpdateSql;
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _26(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            StringBuilder tmpWhere = new StringBuilder();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return new SqlIDUResult("", null, null);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            string tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.Oracle);

            if (string.IsNullOrEmpty(tmpDeleteSql))
            {
                return new SqlIDUResult("", null, null);
            }

            return new SqlIDUResult(tmpDeleteSql, null, tmpDataSheet.KuName);
            //return tmpDeleteSql;

        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _27(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            List<string> tmpColList = new List<string>();
            StringBuilder tmpSql = new StringBuilder();

                tmpSql.AppendLine(@"CREATE OR REPLACE FUNCTION ""ORows$byBase$27""
    RETURN INT IS
    EFFECTCOUNT INT;
    BEGIN
    EFFECTCOUNT:= 0;");
            tmpSql.AppendLine(ToolFunction.InsertRowOrRowList(f_Parameter.ParameterList[0], tmpColList, DBTypeEnum.Oracle));
                return new SqlIDUResult(tmpSql.ToString(), "ORows$byBase$27", ToolFunction.GetDecKuFromRowOrRowList(f_Parameter.ParameterList[0]));

        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _28(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            StringBuilder tmpWhere = new StringBuilder();
            if (!(tmpRowParameter is ku.by.Object.Row))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return new SqlIDUResult("", null, null);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            string tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Oracle);

            if (string.IsNullOrEmpty(tmpUpdateSql))
            {
                return new SqlIDUResult("", null, null);
                //return "";
            }

            return new SqlIDUResult(tmpUpdateSql, null, tmpDataSheet.KuName);
            //return tmpUpdateSql;
        }

        public static byForm_Server.ku.by.ToolClass.SqlIDUResult _29(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            StringBuilder tmpWhere = new StringBuilder();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return new SqlIDUResult("", null, null);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            string tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.Oracle);

            if (string.IsNullOrEmpty(tmpDeleteSql))
            {
                return new SqlIDUResult("", null, null);
            }

            return new SqlIDUResult(tmpDeleteSql, null, tmpDataSheet.KuName);
            //return tmpDeleteSql;

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _30(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationEqualRow(tmpTable0, (ku.by.Object.Row)f_Parameter.ParameterList[0], DBTypeEnum.Oracle));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "30");

        }

        public static string _31(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            List<string> tmpColList = new List<string>();
            return ToolFunction.InsertRowOrRowListInTran(f_Parameter.ParameterList[0], f_EffectedCount, tmpColList, DBTypeEnum.Oracle);
        }

        public static string _32(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];
            StringBuilder tmpWhere = new StringBuilder();
            if (!(tmpRowParameter is ku.by.Object.Row))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }
            List<SetField> tmpSetList = new List<SetField>();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return string.Format("\"{0}\" := 0;\r\n", f_EffectedCount);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));
            string tmpUpdateSql = ToolFunction.FillUpdateRow(tmpRow, tmpSetList, tmpWhere, DBTypeEnum.Oracle);

            if (string.IsNullOrEmpty(tmpUpdateSql))
            {
                return tmpSql.ToString();
            }

            tmpSql.Append(tmpUpdateSql);
            tmpSql.AppendLine(";");
            tmpSql.AppendLine(string.Format("\"{0}\" := SQL%ROWCOUNT;", f_EffectedCount));
            return tmpSql.ToString();

        }

        public static string _33(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter, string f_EffectedCount)
        {
            var tmpRowParameter = f_Parameter.ParameterList[0];

            if (!(tmpRowParameter is ku.by.Object.Row||tmpRowParameter is ICollection<ku.by.Object.Row>))
            {
                ThrowHelper.ThrowSqlPreCompileException(ErrorInfo.ParseRowValueError);
            }

            StringBuilder tmpWhere = new StringBuilder();
            var tmpRow = tmpRowParameter as ku.by.Object.Row;
            var tmpDataSheet = ToolFunction.GetDataSheetOfRow(tmpRow);

            if (tmpDataSheet == null)
            {
                return string.Format("\"{0}\" := 0;\r\n", f_EffectedCount);
            }

            var tmpTableList = new Table(tmpDataSheet, null);
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.AppendLine(string.Format("\"{0}\" := 0;", f_EffectedCount));
            string tmpDeleteSql = ToolFunction.FillDeleteRow(tmpRow, tmpWhere, DBTypeEnum.Oracle);

            if (string.IsNullOrEmpty(tmpDeleteSql))
            {
                return tmpSql.ToString();
            }

            tmpSql.Append(tmpDeleteSql);
            tmpSql.AppendLine(";");
            tmpSql.AppendLine(string.Format("\"{0}\" := SQL%ROWCOUNT;", f_EffectedCount));
            return tmpSql.ToString();

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _34(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            int tmpConfigJoinTableCount = 0;
            string tmpConfigName0 = "select";
            var tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
            var tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.KuName, tmpIdentityName0, tmpConfigName0, tmpTable0.Sheet.SheetName);
            var tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.KuName, tmpConfig0);
            tmpMergedFieldList.AddRange(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, out tmpConfigJoinTableCount));
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationEqualQueryData(tmpTable0, (ku.by.Object.QueryData)f_Parameter.ParameterList[0], tmpHaving, tmpConfigJoinTableCount, DBTypeEnum.Oracle, out tmpConfigJoinTableCount));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "34");

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _35(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            int tmpConfigJoinTableCount = 0;
            string tmpConfigName0 = "select";
            var tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
            var tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.KuName, tmpIdentityName0, tmpConfigName0, tmpTable0.Sheet.SheetName);
            var tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.KuName, tmpConfig0);
            tmpMergedFieldList.AddRange(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, out tmpConfigJoinTableCount));
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "35");

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _36(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            int tmpConfigJoinTableCount = 0;
            string tmpConfigName0 = "select";
            var tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
            var tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.KuName, tmpIdentityName0, tmpConfigName0, tmpTable0.Sheet.SheetName);
            var tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.KuName, tmpConfig0);
            tmpMergedFieldList.AddRange(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, out tmpConfigJoinTableCount));
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationEqualQueryData(tmpTable0, (ku.by.Object.QueryData)f_Parameter.ParameterList[0], tmpHaving, tmpConfigJoinTableCount, DBTypeEnum.Oracle, out tmpConfigJoinTableCount));
            tmpWhere.Append(" AND ");
            tmpWhere.Append(ToolFunction.TableRelationEqualRow(tmpTable0, (ku.by.Object.Row)f_Parameter.ParameterList[1], DBTypeEnum.Oracle));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "36");

        }

        public static byForm_Server.ku.by.ToolClass.Sql.SelectTable _37(byForm_Server.ku.by.ToolClass.Sql.ParamsPackage f_Parameter)
        {
            StringBuilder tmpSql = new StringBuilder("SELECT ");
            StringBuilder tmpFrom = new StringBuilder();
            StringBuilder tmpGroupBy = new StringBuilder();
            StringBuilder tmpWhere = new StringBuilder();
            StringBuilder tmpHaving = new StringBuilder();
            StringBuilder tmpOrderBy = new StringBuilder();
            List<AbstractTable> tmpTableList = new List<AbstractTable>();
            List<AbstractTable> tmpEquivalentTables = new List<AbstractTable>();
            List<AbstractSelectField> tmpSelectFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpMergedFieldList = new List<AbstractSelectField>();
            List<AbstractSelectField> tmpGroupByFieldList = new List<AbstractSelectField>();
            List<OrderByField> tmpOrderByList = new List<OrderByField>();
            var tmpTable0 = f_Parameter.TableSourceList[0] as Table;
            tmpTable0.Alias = "a";
            tmpTableList.Add(tmpTable0);
            tmpEquivalentTables.Add(tmpTable0);
            int tmpConfigJoinTableCount = 0;
            string tmpConfigName0 = "select";
            var tmpIdentityName0 = ToolFunction.GetConfigIdentityByTable(tmpTable0);
            var tmpConfig0 = ToolFunction.GetConfigByIdentityName(tmpTable0.KuName, tmpIdentityName0, tmpConfigName0, tmpTable0.Sheet.SheetName);
            var tmpConfigList0 = ToolFunction.GetConfigList(tmpTable0.KuName, tmpConfig0);
            tmpMergedFieldList.AddRange(ToolFunction.ConvertConfigList(tmpConfigList0, tmpTable0, tmpConfigJoinTableCount, out tmpConfigJoinTableCount));
            tmpSelectFieldList.Add(ToolFunction.GetAsteriskField("a.*", tmpTableList));
            ToolFunction.MergeSelectItem(tmpSelectFieldList, tmpMergedFieldList);
            tmpSql.Append(ToolFunction.GenerateSelectItemAndFrom(tmpMergedFieldList, tmpEquivalentTables, tmpFrom, false, null, DBTypeEnum.Oracle, false));
            tmpWhere.Append(" WHERE ");
            tmpWhere.Append(ToolFunction.TableRelationEqualRow(tmpTable0, (ku.by.Object.Row)f_Parameter.ParameterList[0], DBTypeEnum.Oracle));
            ToolFunction.GenerateSelectGroupBy(tmpGroupByFieldList, tmpGroupBy, tmpHaving, tmpMergedFieldList, DBTypeEnum.Oracle);
            tmpSql.Append(tmpWhere);
            tmpSql.Append(tmpGroupBy);
            tmpSql.Append(tmpHaving);
            return new SelectTable(tmpSelectFieldList, tmpMergedFieldList, tmpTableList, tmpSql.ToString(), "byBase", null, "37");

        }

        public static string Tran_0(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"""tmpLineCount"" NUMBER;
");
            string tmpLocalDec_0 = _2(f_TranParmas.Paramters[0], "EffectedCount");
            tmpBody.Append(tmpLocalDec_0);
            tmpBody.AppendLine("\"tmpLineCount\" := \"EffectedCount\";");

            tmpBody.Append("IF ");
            string tmpLocalDec_1 = "\"tmpLineCount\"";
            string tmpLocalDec_2 = "1";
            tmpBody.Append(ToolFunction.BinaryExpression(tmpLocalDec_1, " < ", tmpLocalDec_2));

            tmpBody.AppendLine(" THEN");
            tmpBody.Append("RAISE_APPLICATION_ERROR(-20000,'");
            tmpBody.Append(SaveInspect.CharactorEscape("删除失败：没有符合条件的行！"));

            tmpBody.AppendLine("', FALSE);");
            tmpBody.AppendLine("END IF;");
            tmpBody.Append(_3(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_1(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"""tmpLineCount"" NUMBER;
");
            string tmpLocalDec_0 = _4(f_TranParmas.Paramters[0], "EffectedCount");
            tmpBody.Append(tmpLocalDec_0);
            tmpBody.AppendLine("\"tmpLineCount\" := \"EffectedCount\";");

            tmpBody.Append("IF ");
            string tmpLocalDec_1 = "\"tmpLineCount\"";
            string tmpLocalDec_2 = "0";
            tmpBody.Append(ToolFunction.EqualExpression(tmpLocalDec_1, tmpLocalDec_2));

            tmpBody.AppendLine(" THEN");
            tmpBody.Append("RAISE_APPLICATION_ERROR(-20000,'");
            tmpBody.Append(SaveInspect.CharactorEscape("更新失败：返回0行！"));

            tmpBody.AppendLine("', FALSE);");
            tmpBody.AppendLine("END IF;");
            tmpBody.Append(_5(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpBody.Append(_6(f_TranParmas.Paramters[2], "EffectedCount"));
            tmpBody.Append(_7(f_TranParmas.Paramters[3], "EffectedCount"));
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_2(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"""tmpLineCount"" NUMBER;
");
            string tmpLocalDec_0 = _8(f_TranParmas.Paramters[0], "EffectedCount");
            tmpBody.Append(tmpLocalDec_0);
            tmpBody.AppendLine("\"tmpLineCount\" := \"EffectedCount\";");

            tmpBody.Append("IF ");
            string tmpLocalDec_1 = "\"tmpLineCount\"";
            string tmpLocalDec_2 = "1";
            tmpBody.Append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

            tmpBody.AppendLine(" THEN");
            tmpBody.Append("RAISE_APPLICATION_ERROR(-20000,'");
            tmpBody.Append(SaveInspect.CharactorEscape("数据插入失败！"));

            tmpBody.AppendLine("', FALSE);");
            tmpBody.AppendLine("END IF;");
            tmpBody.Append(_9(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_3(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"");
            tmpBody.Append(_14(f_TranParmas.Paramters[0], "EffectedCount"));
            tmpBody.Append(_15(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_4(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"""tmpRowCount"" NUMBER;
");
            string tmpLocalDec_0 = _16(f_TranParmas.Paramters[0], "EffectedCount");
            tmpBody.Append(tmpLocalDec_0);
            tmpBody.AppendLine("\"tmpRowCount\" := \"EffectedCount\";");

            tmpBody.Append("IF ");
            string tmpLocalDec_1 = "\"tmpRowCount\"";
            string tmpLocalDec_2 = SaveInspect.CharactorEscape(f_TranParmas.Values[0]);
            tmpBody.Append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

            tmpBody.AppendLine(" THEN");
            tmpBody.AppendLine("ROLLBACK;");
            tmpBody.Append("RAISE_APPLICATION_ERROR(-20000,'");
            tmpBody.Append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

            tmpBody.AppendLine("', FALSE);");
            tmpBody.AppendLine("END IF;");
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_5(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"""tmpTotal"" NUMBER;
""tmpTotal2"" NUMBER;
");
            string tmpLocalDec_0 = _17(f_TranParmas.Paramters[0], "EffectedCount");
            tmpBody.Append(tmpLocalDec_0);
            tmpBody.AppendLine("\"tmpTotal\" := \"EffectedCount\";");

            string tmpLocalDec_1 = _18(f_TranParmas.Paramters[1], "EffectedCount");
            tmpBody.Append(tmpLocalDec_1);
            tmpBody.AppendLine("\"tmpTotal2\" := \"EffectedCount\";");

            tmpBody.Append("IF ");
            string tmpLocalDec_3 = "\"tmpTotal2\"";

            string tmpLocalDec_4 = "0";

            string tmpLocalDec_2 = ToolFunction.EqualExpression(tmpLocalDec_3, tmpLocalDec_4);
            string tmpLocalDec_6 = "\"tmpTotal\"";

            string tmpLocalDec_7 = "0";

            string tmpLocalDec_5 = ToolFunction.EqualExpression(tmpLocalDec_6, tmpLocalDec_7);
            tmpBody.Append(ToolFunction.BinaryExpression(tmpLocalDec_2, " AND ", tmpLocalDec_5));

            tmpBody.AppendLine(" THEN");
            tmpBody.AppendLine("ROLLBACK;");
            tmpBody.Append("RAISE_APPLICATION_ERROR(-20000,'");
            tmpBody.Append(SaveInspect.CharactorEscape("没有返回更新成功的行数！"));

            tmpBody.AppendLine("', FALSE);");
            tmpBody.AppendLine("END IF;");
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_6(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"");
            tmpBody.Append(_20(f_TranParmas.Paramters[0], "EffectedCount"));
            tmpBody.Append(_21(f_TranParmas.Paramters[1], "EffectedCount"));
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_7(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"");
            tmpBody.Append(_22(f_TranParmas.Paramters[0], "EffectedCount"));
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_8(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"""tmpRowCount"" NUMBER;
");
            string tmpLocalDec_0 = _31(f_TranParmas.Paramters[0], "EffectedCount");
            tmpBody.Append(tmpLocalDec_0);
            tmpBody.AppendLine("\"tmpRowCount\" := \"EffectedCount\";");

            tmpBody.Append("IF ");
            string tmpLocalDec_1 = "\"tmpRowCount\"";
            string tmpLocalDec_2 = "1";
            tmpBody.Append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

            tmpBody.AppendLine(" THEN");
            tmpBody.AppendLine("ROLLBACK;");
            tmpBody.Append("RAISE_APPLICATION_ERROR(-20000,'");
            tmpBody.Append(SaveInspect.CharactorEscape("对数据库 insert 失败"));

            tmpBody.AppendLine("', FALSE);");
            tmpBody.AppendLine("END IF;");
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_9(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"""tmpRowCount"" NUMBER;
");
            string tmpLocalDec_0 = _32(f_TranParmas.Paramters[0], "EffectedCount");
            tmpBody.Append(tmpLocalDec_0);
            tmpBody.AppendLine("\"tmpRowCount\" := \"EffectedCount\";");

            tmpBody.Append("IF ");
            string tmpLocalDec_1 = "\"tmpRowCount\"";
            string tmpLocalDec_2 = "1";
            tmpBody.Append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

            tmpBody.AppendLine(" THEN");
            tmpBody.AppendLine("ROLLBACK;");
            tmpBody.Append("RAISE_APPLICATION_ERROR(-20000,'");
            tmpBody.Append(SaveInspect.CharactorEscape("对数据库 update 失败"));

            tmpBody.AppendLine("', FALSE);");
            tmpBody.AppendLine("END IF;");
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }

        public static string Tran_10(byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage f_TranParmas)
        {
            StringBuilder tmpTran = new StringBuilder();
            StringBuilder tmpDec = new StringBuilder("DECLARE\r\n\"tran\" sys_refcursor;\r\n");
            StringBuilder tmpBody = new StringBuilder("BEGIN\r\n");
            tmpDec.AppendLine("\"EffectedCount\" NUMBER;");
            tmpDec.AppendLine(@"""tmpRowCount"" NUMBER;
");
            string tmpLocalDec_0 = _33(f_TranParmas.Paramters[0], "EffectedCount");
            tmpBody.Append(tmpLocalDec_0);
            tmpBody.AppendLine("\"tmpRowCount\" := \"EffectedCount\";");

            tmpBody.Append("IF ");
            string tmpLocalDec_1 = "\"tmpRowCount\"";
            string tmpLocalDec_2 = "1";
            tmpBody.Append(ToolFunction.NotEqualExpression(tmpLocalDec_1, tmpLocalDec_2));

            tmpBody.AppendLine(" THEN");
            tmpBody.AppendLine("ROLLBACK;");
            tmpBody.Append("RAISE_APPLICATION_ERROR(-20000,'");
            tmpBody.Append(SaveInspect.CharactorEscape("对数据库 delete 失败"));

            tmpBody.AppendLine("', FALSE);");
            tmpBody.AppendLine("END IF;");
            tmpBody.Append("\r\nEND;");
            tmpTran.AppendLine(tmpDec.ToString());
            tmpTran.Append(tmpBody.ToString());
            return tmpTran.ToString();
        }
    }
}
