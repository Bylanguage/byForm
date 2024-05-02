using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.ToolClass
{
    public class ErrorInfo
    {
        public readonly static string CanNotFindCellInRow = "无法在行中获取列名为 {0} 的值";

        public readonly static string CanNotFindRelationBetweenSheets = "表 {0} 和 {1} 之间不存在引用关系";

        public readonly static string NoRelationBetweenSheetsOrReferenceColumn = "表 {0} 和表 {1} 之间不存在关系或者行中没有引用列";

        public readonly static string DifferentKuInRelationExpression = "关系表达式左右所属库不同";

        public readonly static string ParseCannotFindActionKu = "无法匹配动作所在的库 {0}";

        public readonly static string FieldIsNull = "关系运算的字段为空";

        public readonly static string IlleagalBool1 = "单元格 {0} 中 {1} 无法识别为有效布尔值";

        public readonly static string TableNotReferenceField = "字段 {0} 和 表 {1} 无直接引用关系";

        public readonly static string ConvertIdentityError = "身份类型 {0} 转换失败";

        public readonly static string CanNotFindColumn = "找不到字段 {0} 对应的单元格";

        public readonly static string IdentityNameSpaceError = "身份命名空间错误";

        public readonly static string CellIdentityNotMatchSheet = "字段所在表和表不匹配";

        public readonly static string CellValueTypeError = "错误的单元格类型";

        public readonly static string IdentityInstanceError = "身份实例匹配数据表出错";

        public readonly static string TypePreInstallNameError = "特殊类型 {0} 预设错误";

        public readonly static string HasSeveralReferenceFieldsBetweenSheets = "表 {0} 和表 {1} 之间存在多对引用字段 {2}";

        public readonly static string CanNotAssinmentNullToRowValue = "无法将null赋值给行中的单元格";

        public readonly static string FlowExpressionRowSheetError = "流表达式中首个参数行所属的表为 {0} 与当前表 {1} 不同";

        public readonly static string RowValueTypeConvertError = "无法将字段 {0} 的值 {1} 转化为 {2} 类型";

        public readonly static string CannotConvertType = "构成要件赋值失败，无法将值转化为 {0} 类型";

        public readonly static string CannotConvertNull = "无法将null转换为 {0} 类型";

        public readonly static string AssignmentNotAllowed = "{0} 无法运用于类型 {1} 和 {2}";

        public readonly static string KuTypeNotLoad = "库 {0} 类型未填充";

        public readonly static string BoolTypParameterError = "传输参数中含非法的bool类型参数 {0}";

        public readonly static string PostOrPreExpressionOnly = "只能运用于字符或数值类型表达式";

        public readonly static string ShiftAssignCanNotApplyLong = "运算符 {0} 无法应用于 long 和 long 类型的操作数";

        public readonly static string DatabaseConnectionReflectionError = "数据库连接映射关系填充错误";

        public readonly static string ExecQueryTableNoMatch = "查询结果数量与预设不符";

        public readonly static string SelectTableNeedAlias = "子查询做表源未标记别名";

        public readonly static string FlowInvocationFiledInRowMissing = "调用数据表 {0} 的{1}形式的流的参数行 {2} 字段对应的单元格未填充";

        public readonly static string UpdateFlowRowParmPKMissing = "update流行参数中主键不完整或缺失";

        public readonly static string FromBaseArgError = "错误的进制转换参数 ";

        public readonly static string CanNotFindKu = "无法获取名为 {0} 的库";

        public readonly static string GetIdentityByInstanceError = "无法通过身份实例获取配置的数据表";

        public readonly static string CanNotFindSheetInKu = "无法在库 {0} 中获取表 {1}";

        public readonly static string CanNotFindFlowInSheet = "{0} 表中无法获取名为 {1} 的流";

        public readonly static string CanNotFindComponentInSheet = "{0} 表不包含名为 {1} 的字段构件";

        public readonly static string CanNotFindFieldInSheet = "无法在表 {0} 中获取字段 {1}";

        public readonly static string CanNotFindRelationCellInRow = "来自表 {0} 的行中不存在关系相关列";

        public readonly static string CanNotFindPKInSheet = "数据表 {0} 中无主键";

        public readonly static string ParseSheetNameError = "消息未携带表源信息或传输格式出错";

        public readonly static string ParseKuNameError = "消息未携带库信息或传输格式出错";

        public readonly static string ParseParamsError = "消息未携带参数信息或传输格式出错";

        public readonly static string ParseCookieError = "消息未携带cookie信息或者传输格式出错";

        public readonly static string ParseRequestMissing = "消息未携带Request信息或者传输格式出错";

        public readonly static string ParseParameterObjTypeError = "消息未携带参数类型信息或者传输格式出错";

        public readonly static string ParseInstanceIdError = "消息未携带实例增量信息或者格式出错";

        public readonly static string ParseSqlTableError = "消息未携带查询语句表源信息或者传输格式出错";

        public readonly static string ParseInstanceError = "消息未携带实例信息或者传输格式错误";

        public readonly static string ParseObjectError = "消息未携带对象实例信息或者传输格式出错";

        public readonly static string ParseSaasIDError = "消息SaasID传输格式出错";

        public readonly static string ParseSourceError = "消息未携带数据源信息或者传输格式出错";

        public readonly static string ParseIdentityError = "消息未携带身份信息或者传输格式出错";

        public readonly static string ParseTranParametersError = "消息未携带事务参数信息或传输格式出错";

        public readonly static string ParseQueryMessageError = "消息中查询区传输格式错误";

        public readonly static string ParseParamsTypeError = "参数类型无法明确或传输格式出错";

        public readonly static string ParseParamsValueError = "参数值无法明确或传输格式出错";

        public readonly static string ParseRequestError = "错误的请求格式";

        public readonly static string ParseIneffectiveRequest = "无效的请求信息";

        public readonly static string ParseNoError = "消息未携带编号信息或传输格式出错";

        public readonly static string ParseInstanceNameError = "消息未携带实例类型名信息或解析出错";

        public readonly static string ParseFromError = "sql语句出处信息或传输格式出错";

        public readonly static string ParseRowColumnsError = "单元格传输格式出错";

        public readonly static string ParseRowValueError = "参数行值无法明确或传输出错";

        public readonly static string ParseFieldError = "传输字段解析错误 {0}";

        public readonly static string ParseOrmError = "Orm消息传输格式错误";

        public readonly static string ParseAutoNoError = "auto传输格式错误";

        public readonly static string ParseIlleagalJsonObj = "非法传输参数对象";

        public readonly static string ParseExecError = "Exec表达式消息格式错误";

        public readonly static string ParseSessionIDError = "消息中SessionID传输错误";

        public readonly static string ParseIlleagalRow = "非法参数行";

        public readonly static string IlleagalFillFrom = "存在非法表源填充";

        public readonly static string ParseRefError = "实例引用解析错误";

        public readonly static string RefCanNotFind = "找不到引用的实例";

        public readonly static string ConflictInstance = "重复的实例";

        public readonly static string ParseArrayError = "数组解析错误";

        public readonly static string QueryAreaParameterError = "查询区参数填充错误";

        public readonly static string UnKnownQueryAreaParameter = "未知的查询区参数";

        public readonly static string ParseIlleagalQueryValue = "查询区参数传输类型错误";

        public readonly static string ParseIlleagalBetweenLength = "查询区between长度错误";

        public readonly static string ParseBetweenValueIsNull = "查询区between某一个字段值为null";

        public readonly static string CanNotFindRelationInQueryArea = "查询区中没有和表 {0} 存在关系的字段";

        public readonly static string RowIsNull = "关系运算中行为null";

        public readonly static string RowsIsNull = "关系运算中行集合为null";

        public readonly static string IlleagalRowParameter = "非法行参数";

        public readonly static string DifferentParameterOfInsert = "insert表达式参数类型不同";

        public readonly static string RowTableIsDifferentFormTable = "行所在表非当前操作的表";

        public readonly static string RowHasRepetitiveField = "行中存在重复的列 {0} 或列不存在";

        public readonly static string RowIdentityIsNullCanNotFindSheet = "行身份为null或身份实例未配置数据表无法获取相关数据表信息";

        public readonly static string RowIdentityNotMatchSheet = "行身份实例和表不匹配";

        public readonly static string RowIdentityError = "行身份错误";

        public readonly static string HasNullRowInRows = "行集合中存在空的行引用";

        public readonly static string ServeralPKInRelationSheet = "行集合和表的~in运算,表中有多个主键";

        public readonly static string RelationPKIsNull = "行集合和表的~in运算,表主键值为空";

        public readonly static string CanNotFindEnumByPath = "无法获取字段 {0} 的枚举类型";

        public readonly static string CanNotFindEnumValue = "枚举值 {0} 不存在";

        public readonly static string ColumnNotNull = "违反了字段{0}的notNull约束: {1}值不能为空！";

        public readonly static string IlleagalDatetime = "列 {0} 中 {1} 无法识别为有效日期";

        public readonly static string IlleagalDecimal = "列 {0} 中 {1} 无法识别为有效货币数值";

        public readonly static string IlleagalInt = "列 {0} 中 {1} 无法识别为有效int整数";

        public readonly static string IlleagalShort = "列 {0} 中 {1} 无法识别为有效short整数";

        public readonly static string IlleagalLong = "列 {0} 中 {1} 无法识别为有效long整数";

        public readonly static string IlleagalByte = "列 {0} 中 {1} 无法识别为有效byte整数";

        public readonly static string IlleagalFloat = "列 {0} 中 {1} 无法识别为有效float数据";

        public readonly static string IlleagalDouble = "列 {0} 中 {1} 无法识别为有效double数据";

        public readonly static string IlleagalString = "列 {0} 中 {1} 无法识别为有效string数据";

        public readonly static string IlleagalChar = "列 {0} 中 {1} 无法识别为有效char数据";

        public readonly static string BiggerthanMax = "违反了字段{0}的max约束: {1}值大于{2}!";

        public readonly static string SmallerthanMin = "违反了字段{0}的min约束: {1}值小于{2}!";

        public readonly static string VerifyPattern = "违反了字段{0}的pattern约束: string格式必须符合正则{1}!";

        public readonly static string VerifyDigit = "违反了字段{0}的digit约束: {1}小数位数必须不大于{2}!";

        public readonly static string ColumnStringBiggerThanMax = "违反了字段{0}的max约束: {1}长度大于{2}!";

        public readonly static string ColumnStringLessThanMin = "违反了字段{0}的min约束: {1}长度小于{2}!";

        public readonly static string UnCurrentSheetField = "update存在非当前表的字段 {0}";

        public readonly static string HasRepetitiveField = "update语句中重复的字段 {0}";

        public readonly static string InsertValueHasNoValue = "insert没有插入任何行";

        public readonly static string SqlUnknoweError = "sql操作出错";

        public readonly static string UnClearColumnName = "不明确的列名 {0}";

        public readonly static string FieldWithoutTableSource = "访问的字段没有标记表源";

        public readonly static string UnExceptedField = "字段类型访问错误";

        public readonly static string ColumnWithoutAlias = "未声明别名的非数据表列访问";

        public readonly static string SelectResultAccessWithoutAlias = "访问的查询结果未标记别名";

        public readonly static string OperatorIsNull = "sql运算字段操作符为空";

        public readonly static string OperatorFieldIsNull = "sql一元运算字段存在空字段";

        public readonly static string TableIsNull = "关系运算中比表为null";

        public readonly static string SqlNameIndexBug = "sql语句 {0} 所在封闭节点查找失败";

        public readonly static string TranNameIndexBug = "tran语句 {0} 所以在封闭节点查找失败";

        public readonly static string SelectConstSheeet = "常量表 {0} 无法作为查询语句的表源";

        public readonly static string SqlInTranTableSourceError = "事务中sql语句表源异常";

        public readonly static string FlowIdentityError = "流表达式身份 {0}.{1} 实例未标记数据表";

        public readonly static string DataSheetFieldsError = "数据库中数据表 {0} 和by程序中数据表 {1} 字段数量或位置或名称不匹配";

        public readonly static string ConditionIsNull = "sql中作为条件的表达式为null";

        public readonly static string SelectCanNotFindKu = "无法获取sql语句所在库";

        public readonly static string SelectResultError = "数据库查询结果列数量和计算列数量不一致，请检查表源 {0} 的列在数据库中是否和by文档中一致，错误位置 ：{1}";

        public readonly static string InsertFieldConflict = "insert语句中有含有重复字段 {0}";

        public readonly static string ConflictFields = "多次指定了列名 {0}";

        public readonly static string OrderbyUnClearColumn = "order by 错误 : 不明确的列名 {0}";

        public readonly static string RowDmlRowIsNull = "简写sql语句中行参数为null";

        public readonly static string OrmCreateRowParmIsNull = "用于创建orm新实例的行参数为null";

        public readonly static string ParseSqlParamTypeError = "消息中的sql参数存在不支持的类型";

        public readonly static string TranHasNoSqlCanNotFindExecKu = "事务中不含sql语句参数无法获取执行库";

        public readonly static string SqlHasNoTableCanNotFindExecKu = "sql参数中无表源无法获取执行库";

        public readonly static string TranHasDiffenentExecKu = "事务中sql参数存在不同的执行库, 当前事务中表源如下：";

        public readonly static string SqlHasDifferentExecKu = "当前SQL查询表源来自多个不同的数据库，不支持跨库查询当前数据表如下：";

        public readonly static string CanNotMatchingSource = "表源 {0} 无法与数据表匹配";

        public readonly static string CanNotFindSourceSheetWithAlias = "无法找到别名为 {0} 的表源项";

        public readonly static string ExistRowFromDifferentSheet = "存在来自不同表的行";

        public readonly static string RowsHasNoRow = "行集合中没有元素无法解析获取表源数据";

        public readonly static string SqlExecteTimeout = "sql执行超时";

        public readonly static string ParseCanNotMatchintMethod = "无法匹配 {0} 对应方法";

        public readonly static string ReflectTypeOrMethodError = "反射获取成员失败，路径：";

        public readonly static string ParseCanNotFindSource = "数据表 {0} 中无法匹配数据源 {1}";

        public readonly static string CannotFindProp = "无法获取公共属性 {0}";

        public readonly static string IdentityIsNull = "技能调用传递的身份为空";

        public readonly static string UnSupportedArrayType = "不支持的数组或列表类型";

        public readonly static string ObjectPropError = "对象属性解析错误";

        public readonly static string SkillNameIndexBug = "技能索引 {0} 查找失败";

        public readonly static string ActionNameIndexBug = "动作索引 {0} 查找失败";

        public readonly static string SkillNameValueBug = "技能名 {0} 存储错误";

        public readonly static string ActionNameValueBug = "动作名 {0} 存储错误";

        public readonly static string ParseListError = "list解析错误";

        public readonly static string ParseDictionaryError = "dictionary解析错误";

        public readonly static string ObjectCantSerialized = "{0} 对象无法序列化为 {1}";

        public readonly static string OnlySupportlistanddictionary = "不支持list和dictionary以外的泛型类型序列化";

        public readonly static string PositiveInfinity = "无穷大无法序列化";

        public readonly static string JsonNumParseError = "传输内容 {0} 数字类型解析错误";

        public readonly static string ObjectTypeNotMatch = "传输自定义类型 {0} 和其实例的声明处预设类型不一致";

        public readonly static string CanNotFindOrmType = "无法获取 {0} 的orm类型或与预设接收的orm类型不同";

        public readonly static string FuncTypeMatchError = "技能或动作动作 {0} 调用参数类型不匹配，参数 {1}";

        public readonly static string OrmFieldDeserializeError = "反序列化 {0} 的 {1} 列失败";

        public readonly static string OrmFieldDeserializeMemberError = "orm成员反序列化失败";

        public readonly static string UnClearIdentity = "不明确的身份实例";

        public readonly static string NotFieldIdentity = "不是字段类型身份";

        public readonly static string NotTableIdentity = "不是表类型身份";

        public readonly static string CellTypeConvertError = "Cell中 {0} 转化为 {1} 失败 ";

        public readonly static string DictionaryError = "Dictionary错误 ";

        public readonly static string DictionDeserializeError = "Dictionary反序列化错误 ";

        public readonly static string ListError = "List错误 ";

        public readonly static string ReadonlyListError = "ReadonlyList错误 ";

        public readonly static string RawDatetime = "未转换的datetime类型";
    }
}
