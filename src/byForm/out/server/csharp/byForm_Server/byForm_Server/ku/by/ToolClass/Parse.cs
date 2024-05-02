using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using byForm_Server.ku.by.ToolClass.JsonParser.Value;
namespace byForm_Server.ku.by.ToolClass
{
    public class Parse
    {
        public Parse()
        {
            RootNameSpace = this.GetType().ToString().Split('.')[0];
            this.InstanceDic = new Dictionary<string, object>();
            this.ToJsonInstanceDic = new Dictionary<object, string>();
        }

        private string RootNameSpace;

        public string ResponseValue { get; private set; }

        public string SqlLocation { get; set; }

        public byForm_Server.ku.by.ToolClass.RequestTypeEnum ResponseType { get; set; }

        public bool ComeInHasError = false;

        private readonly string MessageUserDefined = "USERDEFINED";

        private readonly string MessageTable = "$TABLE";

        private readonly string MessageTableSql = "SQL";

        private readonly string MessageDollerTableSql = "$SQL";

        private readonly string MessageNo = "$NO";

        private readonly string MessageFrom = "$FR";

        private readonly string MessageParameters = "$PA";

        private readonly string MessageID = "$ID";

        private readonly string MessageRef = "$REF";

        private readonly string MessageInstance = "$INSTANCE";

        private readonly string MessageInner = "$INNER";

        private readonly string MessageValue = "$VALUE";

        private readonly string MessageParameterObjType = "#";

        private readonly string MessageArray = "ARRAY";

        private readonly string MessageDollarVA = "$VA";

        private readonly string MessageArrayValue = "$VALUES";

        private readonly string MessageIdentity = "IDENTITY";

        private readonly string MessageDollarIdentity = "$IDENTITY";

        private readonly string MessageQuery = "QUERY";

        private readonly string MessageRow = "ROW";

        private readonly string MessageSheetName = "$SH";

        private readonly string MessageSourceNames = "$SS";

        private readonly string MessageSourceName = "$SO";

        private readonly string MessageParamsList = "$PS";

        private readonly string MessageKu = "$KU";

        private readonly string MessageFields = "$FIELDS";

        private readonly string MessageValues = "$VALUES";

        private readonly string MessageCookie = "$COOKIE";

        private readonly string MessageRequest = "$REQUEST";

        private readonly string MessageTarget = "$TARGET";

        private readonly string MessageType = "$TYPE";

        private readonly string MessageList = "LIST";

        private readonly string MessageDictionary = "DICTIONARY";

        private readonly string MessageKeys = "$KEYS";

        private readonly string MessageOrm = "ORM";

        private readonly string MessageDollarIDentitys = "$IDENTITYS";

        private readonly string MessageSessionID = "$SESSIONID";

        private readonly string MessageFIELDSMAP = "$FIELDSMAP";

        private readonly string MessageTableFieldsMap = "$TABLESMAP";

        private readonly string MessageSaasID = "$SAASID";

        private readonly string MessageExec = "EXEC";

        private readonly static System.Type charType = typeof(char);

        private readonly static System.Type byteType = typeof(sbyte);

        private readonly static System.Type shortType = typeof(short);

        private readonly static System.Type intType = typeof(int);

        private readonly static System.Type longType = typeof(long);

        private readonly static System.Type floatType = typeof(float);

        private readonly static System.Type doubleType = typeof(double);

        private readonly static System.Type decimalType = typeof(decimal);

        private readonly static System.Type boolType = typeof(bool);

        private readonly static System.Type dateTimeType = typeof(byForm_Server.ku.by.Object.datetime);

        private readonly static System.Type stringType = typeof(string);

        private readonly System.Collections.Generic.Dictionary<string, object> InstanceDic;

        private readonly System.Collections.Generic.Dictionary<object, string> ToJsonInstanceDic;

        private static System.Collections.Generic.Dictionary<string, System.Type> TypeDic = new System.Collections.Generic.Dictionary<string, System.Type>();

        private byForm_Server.ku.by.Object.ServerSession serverSession = null;

        private string url = null;

        public void ParsePostContent(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj, string f_IP, string f_Url)
        {
            if (!f_Obj.ContainsKey(MessageCookie))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseCookieError);
            }

            if (!f_Obj.ContainsKey(MessageRequest))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRequestMissing);
            }

            if (!f_Obj.ContainsKey(MessageSessionID))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSessionIDError);
            }

            var tmpCookieNode = f_Obj[MessageCookie];
            string tmpCookieValue = null;
            if (tmpCookieNode is NullValue || tmpCookieNode is StringClass)
            {
                if (tmpCookieNode is NullValue)
                {
                    tmpCookieValue = null;
                }
                else
                {
                    tmpCookieValue = (tmpCookieNode as StringClass).value;
                }
            }
            else
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseCookieError);
            }

            var tmpSessionIDNode = f_Obj[MessageSessionID];
            url = f_Url;
            string tmpSaasID = null;

            if (f_Obj.ContainsKey(MessageSaasID))
            {
                if (f_Obj[MessageSaasID] is StringClass || f_Obj[MessageSaasID] is NullValue)
                {
                    var tmpSaasIDNode = f_Obj[MessageSaasID] as StringClass;

                    if (tmpSaasIDNode != null)
                    {
                        tmpSaasID = tmpSaasIDNode.Value;
                    }
                }
                else
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSaasIDError);
                }
            }

            if (tmpSessionIDNode is NullValue || tmpSessionIDNode is StringClass)
            {
                if (tmpSessionIDNode is NullValue)
                {
                    serverSession = GenerateUserDate(null, f_IP, tmpCookieValue, tmpSaasID);
                }
                else
                {
                    var tmpSessionID = tmpSessionIDNode as StringClass;
                    serverSession = GenerateUserDate(tmpSessionID.value, f_IP, tmpCookieValue, tmpSaasID);
                }
            }
            else
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSessionIDError);
            }

            int tmpThreadIndex = Thread.CurrentThread.ManagedThreadId;
            Handler.CurrentThreadIDSession.Remove(tmpThreadIndex);
            Handler.CurrentThreadIDSession.Add(tmpThreadIndex, serverSession);
            var tmpValue = f_Obj[MessageRequest] as JsonObject;

            if (tmpValue == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRequestMissing);
            }

            this.ParseRequestValue(tmpValue);
        }

        private byForm_Server.ku.by.Object.ServerSession GenerateUserDate(string f_SessionID, string f_IP, string f_Cookie, string f_SaassID)
        {
            if (ku.by.Identity.Server.cacheSessionDic == null)
            {
                ku.by.Identity.Server.cacheSessionDic = new ku.by.Object.dictionary<string, ku.by.Object.ServerSession>();
            }

            ku.by.Object.ServerSession tmpSession;

            if (f_SessionID == null || !ku.by.Identity.Server.cacheSessionDic.containsKey(f_SessionID))
            {
                string tmpGUID = Guid.NewGuid().ToString();
                tmpSession = new Object.ServerSession(900000);
                ku.by.Identity.Server.cacheSessionDic.add(tmpGUID, tmpSession);
                tmpSession.ID = tmpGUID;
            }
            else
            {
                tmpSession = ku.by.Identity.Server.cacheSessionDic[f_SessionID];
            }

            tmpSession.ip = f_IP;
            tmpSession.time = ku.by.Object.datetime.getNow();
            tmpSession.Cookie = f_Cookie;
            tmpSession.url = url;
            tmpSession.saasID = f_SaassID;
            return tmpSession;
        }

        public void ParseRequestValue(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj)
        {
            this.InstanceDic.Clear();
            this.ToJsonInstanceDic.Clear();
            this.ResponseType = RequestTypeEnum.None;

            if (!f_Obj.ContainsKey(MessageParameterObjType))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
            }

            var tmpTypeNode = f_Obj[MessageParameterObjType] as StringClass;
            if (tmpTypeNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
            }

            string tmpRequestType = tmpTypeNode.Value;

            try
            {
                if (!System.Enum.IsDefined(typeof(RequestTypeEnum), tmpRequestType))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIneffectiveRequest);
                }

                if (tmpRequestType == RequestTypeEnum.ACTION.ToString())
                {
                    this.ResponseType = RequestTypeEnum.ACTION;
                    ParseAction(f_Obj);
                    if (ComeInHasError)
                    {
                        return;
                    }
                }

                if (tmpRequestType == RequestTypeEnum.SKILL.ToString())
                {
                    this.ResponseType = RequestTypeEnum.SKILL;
                    this.ParseSkill(f_Obj);
                    if (ComeInHasError)
                    {
                        return;
                    }
                }

                if (tmpRequestType == RequestTypeEnum.SOURCE.ToString())
                {
                    this.ResponseType = RequestTypeEnum.SOURCE;
                    ParseSource(f_Obj);
                    if (ComeInHasError)
                    {
                        return;
                    }
                }

                if (tmpRequestType == RequestTypeEnum.AUTOID.ToString())
                {
                    this.ResponseType = RequestTypeEnum.AUTOID;
                    ParseAutoID(f_Obj);
                    if (ComeInHasError)
                    {
                        return;
                    }
                }

                if (tmpRequestType == RequestTypeEnum.SQL.ToString())
                {
                    this.ResponseType = RequestTypeEnum.SQL;
                    if (!f_Obj.ContainsKey(MessageKu))
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
                    }

                    var tmpKuNode = f_Obj[MessageKu] as StringClass;

                    if (tmpKuNode == null)
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
                    }
                    string tmpKuName = tmpKuNode.Value;
                    var tmpParamsPackage = this.FillSqlParams(f_Obj);
                    if (ComeInHasError)
                    {
                        return;
                    }
                    string tmpPath = tmpParamsPackage.Path + "." + tmpParamsPackage.MethodName;
                    var tmpLocationDic = Root.GetInstance().KuDic[tmpKuName].sqlLocation.SqlLocationDic;
                    if (!tmpLocationDic.ContainsKey(tmpParamsPackage.MethodName))
                    {
                        ThrowHelper.ThrowUnKnownException(ErrorInfo.SqlUnknoweError);
                    }
                    string tmpLocation = tmpLocationDic[tmpParamsPackage.MethodName];
                    this.SqlLocation = tmpLocation;
                    this.ResponseValue = Response.SqlExpressionResponse(tmpPath, tmpParamsPackage);
                }

                if (tmpRequestType == RequestTypeEnum.EXEC.ToString())
                {
                    this.ResponseType = RequestTypeEnum.EXEC;

                    if (!f_Obj.ContainsKey(MessageKu) || !f_Obj.ContainsKey(MessageNo) || !f_Obj.ContainsKey(MessageParamsList))
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseExecError);
                    }

                    var tmpKuNode = f_Obj[MessageKu] as StringClass;
                    var tmpNoNode = f_Obj[MessageNo] as StringClass;
                    var tmpPsNode = f_Obj[MessageParamsList] as ArrayClass;

                    if (tmpKuNode == null || tmpNoNode == null || tmpPsNode == null)
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseExecError);
                    }

                    List<Sql.ParamsPackage> tmpParamsPackges = new List<Sql.ParamsPackage>();

                    foreach (var item in tmpPsNode.ValueList)
                    {
                        var tmpSqlObj = item as JsonObject;

                        if (tmpSqlObj == null)
                        {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseExecError);
                        }

                        var tmpPackge = FillSqlParams(tmpSqlObj);

                        if (tmpPackge.DecKuName != tmpKuNode.value)
                        {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseExecError);
                        }

                        tmpParamsPackges.Add(FillSqlParams(tmpSqlObj));
                    }

                    if (ComeInHasError)
                    {
                        return;
                    }

                    string tmpPath = string.Format("{0}.ku.{1}.SqlExpression.sql", this.RootNameSpace, tmpKuNode.value) + ".Exec" + "_" + tmpNoNode.value;
                    //位置信息后面再填
                    this.ResponseValue = Response.ExecExpressionResponse(tmpPath, tmpParamsPackges);
                }

                if (tmpRequestType == RequestTypeEnum.TRAN.ToString())
                {
                    //一条语句一个参数包？包括sql和非sql  sql参数格式已经确定   非sql：
                    //按从左到右的顺序排列一个if ()算一条,是否需要区分sql和普通语句参数格式区分开
                    this.ResponseType = RequestTypeEnum.TRAN;
                    var tmpParameterPackge = this.ParseTran(f_Obj);
                    if (ComeInHasError)
                    {
                        return;
                    }
                    string tmpPath = tmpParameterPackge.Path + "." + tmpParameterPackge.MethodName;
                    this.ResponseValue = Response.TranResponse(tmpPath, tmpParameterPackge);
                }
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ThrowHelper.ThrowUnKnownException(ex.Message);
            }
        }

        private void ParseAutoID(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_AutoIDObj)
        {
            if (!f_AutoIDObj.ContainsKey(MessageSheetName) || !f_AutoIDObj.ContainsKey(MessageDollarVA) || !f_AutoIDObj.ContainsKey("$Refresh"))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseAutoNoError);
            }

            var tmpSheetNameNode = f_AutoIDObj[MessageSheetName] as StringClass;
            var tmpValueNode = f_AutoIDObj[MessageDollarVA] as Num;
            var tmpNeedRefresgNode = f_AutoIDObj["$Refresh"] as BoolValue;

            if (tmpSheetNameNode == null || tmpValueNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseAutoNoError);
            }
            serverSession.methodName = "by.object.System.autoID";
            //this.AddSessionToDic();
            var tmpComeInResult = this.MethodBeforeInvoke();
            if (tmpComeInResult != null)
            {
                if (!tmpComeInResult.isOk)
                {
                    this.ComeInHasError = true;
                    this.ResponseValue = tmpComeInResult.info;
                    return;
                }
            }

            var tmpDataSheet = ToolFunction.GetDataSheet(tmpSheetNameNode.Value);
            this.ResponseValue = ku.by.Object.system.autoID((Object.table)tmpDataSheet, int.Parse(tmpValueNode.Value), tmpNeedRefresgNode.value).ToString();
            return;
        }

        private byForm_Server.ku.by.ToolClass.Sql.TranParamsPackage ParseTran(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_TranObj)
        {
            if (!f_TranObj.ContainsKey(MessageKu))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
            }

            if (!f_TranObj.ContainsKey(MessageParamsList))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseTranParametersError);
            }

            if (!f_TranObj.ContainsKey(MessageNo))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            if (!f_TranObj.ContainsKey(MessageDollarVA))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseTranParametersError);
            }

            var tmpKuNode = f_TranObj[MessageKu] as StringClass;
            //var tmpMethodNode = f_TranObj[MessageMethodName] as StringClass;
            var tmpParameterListNode = f_TranObj[MessageParamsList] as ArrayClass;
            var tmpNoNode = f_TranObj[MessageNo] as StringClass;
            var tmpVaNode = f_TranObj[MessageDollarVA] as ArrayClass;

            if (tmpKuNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
            }

            if (tmpParameterListNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }

            if (tmpNoNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            if (tmpVaNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseTranParametersError);
            }

            //路径相关
            string tmpKuName = tmpKuNode.Value;
            string tmpPath = string.Format("{0}.ku.{1}.SqlExpression.sql", this.RootNameSpace, tmpKuName);
            string tmpMethod = "Tran_" + tmpNoNode.Value;
            string tmpStorageIndex =  string.Format("{0}.{1}", tmpKuName, tmpNoNode.Value);
            if (!MethodNameStorage.TranNames.ContainsKey(tmpStorageIndex))
            {
                ThrowHelper.ThrowParseTransferException(String.Format(ErrorInfo.TranNameIndexBug, tmpStorageIndex));
            }
            string tmpEnclosedMethodName = MethodNameStorage.TranNames[tmpStorageIndex];
            serverSession.methodName = tmpEnclosedMethodName;
            //this.AddSessionToDic();
            var tmpComeInResult = this.MethodBeforeInvoke();
            if (tmpComeInResult != null)
            {
                if (!tmpComeInResult.isOk)
                {
                    this.ComeInHasError = true;
                    this.ResponseValue = tmpComeInResult.info;
                    return null;
                }
            }

            List<Sql.ParamsPackage> tmpParameterList = new List<Sql.ParamsPackage>();
            List<object> tmpValues = new List<object>();

            foreach (var item in tmpVaNode.ValueList)
            {
                if (item is StringClass)
                {
                    var tmpStringValueNode = item as StringClass;
                    tmpValues.Add(tmpStringValueNode.value);
                    continue;
                }

                if (item is Num)
                {
                    var tmpNumNode = item as Num;
                    tmpValues.Add(tmpNumNode.Value);
                    continue;
                }

                if (item is BoolValue)
                {
                    var tmpBoolNode = item as BoolValue;
                    tmpValues.Add(tmpBoolNode.Value);
                    continue;
                }

                if (item is NullValue)
                {
                    tmpValues.Add(null);
                    continue;
                }

                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseTranParametersError);
            }

            //填充参数列,顺便取第一条第一个表源的库作为执行库
            //string tmpKuName = null;
            foreach (var item in tmpParameterListNode.ValueList)
            {
                //序号只做去重复，按遍历顺序填充
                var tmpValue = item as JsonObject;

                if (tmpValue == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRowValueError);
                }

                tmpParameterList.Add((Sql.ParamsPackage)this.ParseSqlValue(tmpKuName, tmpValue, new List<object>(), false, null));
            }

            return new Sql.TranParamsPackage(tmpKuName, tmpPath, tmpMethod, tmpParameterList, tmpValues);
        }

        private void ParseAction(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_ActionObj)
        {
            if (!f_ActionObj.ContainsKey(MessageKu))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
            }

            if (!f_ActionObj.ContainsKey(MessageNo))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            if (!f_ActionObj.ContainsKey(MessageParameters))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }

            if (!f_ActionObj.ContainsKey(MessageTarget))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceNameError);
            }

            var tmpKuNameNode = f_ActionObj[MessageKu] as StringClass;

            if (tmpKuNameNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
            }

            var tmpNoNode = f_ActionObj[MessageNo] as StringClass;

            if (tmpNoNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            var tmpPaNode = f_ActionObj[MessageParameters] as ArrayClass;

            if (tmpPaNode == null)
            {
                ThrowHelper.ThrowParseTransferException (ErrorInfo.ParseParamsError);
            }

            var tmpIdentity = f_ActionObj[MessageTarget] as JsonObject;//不可能为null
            string tmpKuName = tmpKuNameNode.Value;
            string tmpActionNo = tmpNoNode.Value;
            string tmpActionIndex = tmpKuName + "." + tmpNoNode.Value;

            if (!MethodNameStorage.ActionIdentityNames.ContainsKey(tmpActionIndex))
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ActionNameIndexBug, tmpActionIndex));
            }

            string tmpActionValue = MethodNameStorage.ActionIdentityNames[tmpActionIndex];
            serverSession.methodName = tmpActionValue;
            var tmpActionValueArray = tmpActionValue.Split('.');

            if (tmpActionValueArray.Length != 4)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ActionNameValueBug);
            }

            serverSession.identityName = tmpActionValueArray[0] + "." + tmpActionValueArray[2];
            string tmpActionQualifiedName = string.Format("{0}.ku.{1}.Action.ActionIndex", RootNameSpace, tmpKuName);
            var tmpType = Type.GetType(tmpActionQualifiedName);

            if (tmpType == null)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseCannotFindActionKu, tmpKuName));
            }

            var tmpMethod = tmpType.GetMethod("_" + tmpActionNo);

            if (tmpMethod == null)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseCanNotMatchintMethod, tmpActionNo));
            }

            //this.AddSessionToDic();
            var tmpComeInResult = this.MethodBeforeInvoke();
            if (tmpComeInResult != null)
            {
                if (!tmpComeInResult.isOk)
                {
                    this.ComeInHasError = true;
                    this.ResponseValue = tmpComeInResult.info;
                    return;
                }
            }

            var tmpIdentityInstance = ParseIdentity(tmpIdentity);
            object[] tmpActionParams = new object[] { this, tmpIdentityInstance, tmpPaNode};
            this.ResponseValue = Response.FuncResponse(this, tmpMethod, tmpIdentityInstance, tmpActionParams);
        }

        private byForm_Server.ku.by.Object.QueryData ParseQueryDataValue(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_QueryObj)
        {
            if (!f_QueryObj.ContainsKey(MessageID))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
            }


            if (!f_QueryObj.ContainsKey(MessageSheetName))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
            }

            if (!f_QueryObj.ContainsKey(MessageDollarVA))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
            }

            if (!f_QueryObj.ContainsKey(MessageSourceNames))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
            }

            var tmpSheetNameNode = f_QueryObj[MessageSheetName] as StringClass;
            var tmpSourceNamesNode = f_QueryObj[MessageSourceNames] as ArrayClass;
            var tmpValueNode = f_QueryObj[MessageDollarVA] as ArrayClass;
            var tmpIdNode = f_QueryObj[MessageID] as StringClass;
            if (tmpSheetNameNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
            }

            if (tmpSourceNamesNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
            }

            if (tmpValueNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
            }

            if (tmpIdNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
            }
            string tmpId = tmpIdNode.Value;
            var tmpSheetArray = tmpSheetNameNode.Value.Split('.');
            if (tmpSheetArray.Length != 2)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
            }

            if (f_QueryObj[MessageSheetName] is NullValue || f_QueryObj[MessageSourceNames] is NullValue || f_QueryObj[MessageDollarVA] is NullValue)
            {
                if (!(f_QueryObj[MessageSheetName] is NullValue && f_QueryObj[MessageSourceNames] is NullValue && f_QueryObj[MessageDollarVA] is NullValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
                }

                this.InstanceDic.Add(tmpId, null);
                return null;
            }

            string tmpKuName = tmpSheetArray[0];
            string tmpSheetName = tmpSheetArray[1];
            var tmpSourceNames = tmpSourceNamesNode.valueList;
            var tmpDataSheet = ToolFunction.GetDataSheet(tmpKuName, tmpSheetName);

            if (tmpSourceNames.Count != tmpValueNode.Count)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.QueryAreaParameterError);
            }

            var tmpValueList = tmpValueNode.ValueList;

            Dictionary<Source, object> tmpDic = new Dictionary<Source, object>();
            for (int i = 0; i < tmpValueList.Count; i++)
            {
                var tmpObj = tmpValueList[i];
                var tmpSourceNameNode = tmpSourceNames[i] as StringClass;
                if (tmpSourceNameNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.QueryAreaParameterError);
                }

                string tmpSourceName = tmpSourceNameNode.value;
                Source tmpSource;
                if (!tmpDataSheet.SourceDic.TryGetValue(tmpSourceName, out tmpSource))
                {
                    ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseCanNotFindSource, tmpDataSheet.SheetName, tmpSourceName));
                }

                if (tmpObj is StringClass)
                {
                    var tmpObjInstance = tmpObj as StringClass;
                    tmpDic.Add(tmpSource, tmpObjInstance.Value);
                    continue;
                }

                if (tmpObj is Num)
                {
                    var tmpObjINstance = tmpObj as Num;
                    tmpDic.Add(tmpSource, tmpObjINstance.Value);
                    continue;
                }

                if (tmpObj is ArrayClass)
                {
                    var tmpObjInstance = tmpObj as ArrayClass;
                    tmpDic.Add(tmpSource, this.ParseQueryBetween(tmpObjInstance));
                    continue;
                }

                if (tmpObj is NullValue)
                {
                    tmpDic.Add(tmpSource, null);
                    continue;
                }

                if (tmpObj is BoolValue)
                {
                    var tmpObjInstance = tmpObj as BoolValue;
                    tmpDic.Add(tmpSource, tmpObjInstance.Value);
                    continue;
                }
                
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalQueryValue);
            }

            var tmpNewQuery = new Sql.QueryDataParameter(tmpDic);
            var tmpReturnValue = new ku.by.Object.QueryData();
            tmpReturnValue._QueryDataParameter = tmpNewQuery;
            tmpReturnValue.values = tmpNewQuery.ValueDic.Values.ToArray();
            tmpReturnValue.table = tmpDataSheet as ku.by.Object.table;
            tmpReturnValue.Identity = tmpReturnValue.table.Identity;
            this.InstanceDic.Add(tmpId, tmpReturnValue);
            return tmpReturnValue;
        }

        private System.Collections.Generic.List<string> ParseQueryBetween(byForm_Server.ku.by.ToolClass.JsonParser.Value.ArrayClass f_Array)
        {
            List<string> tmpList = new List<string>();
            var tmpValueList = f_Array.ValueList;
            if (tmpValueList.Count != 2)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalBetweenLength);
            }

            var tmpValue1Node = tmpValueList[0];
            var tmpValue2Node = tmpValueList[1];
            if (tmpValue1Node is NullValue || tmpValue2Node is NullValue)
            {
                if (!(tmpValue1Node is NullValue && tmpValue2Node is NullValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseBetweenValueIsNull);
                }
                else
                {
                    return null;
                }
            }

            string tmpValue1 = this.GetStringOrNumValue(tmpValue1Node);
            string tmpValue2 = this.GetStringOrNumValue(tmpValue2Node);
            if (tmpValue1 == null || tmpValue2 == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseBetweenValueIsNull);
            }
            tmpList.Add(tmpValue1);
            tmpList.Add(tmpValue2);
            return tmpList;
        }

        private string GetStringOrNumValue(byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue f_Value)
        {
            if (f_Value is StringClass)
            {
                var tmpValue = f_Value as StringClass;
                return tmpValue.Value;
            }

            if (f_Value is Num)
            {
                var tmpValue = f_Value as Num;
                return tmpValue.Value;
            }

            return null;
        }

        private byForm_Server.ku.by.ToolClass.Sql.AbstractTable ParseTableSource(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_TableSourceObj, string f_KuName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableList, System.Collections.Generic.List<object> f_Params)
        {
            bool tmpIsTable = false;
            bool tmpIsSql = false;
            
            if (f_TableSourceObj.ContainsKey(MessageTable))
            {
                tmpIsTable = true;
            }

            if (f_TableSourceObj.ContainsKey(MessageDollerTableSql))
            {
                tmpIsSql = true;
            }

            if (!(tmpIsTable ^ tmpIsSql))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.IlleagalFillFrom);
            }

            if (tmpIsTable)
            {
                return this.ParseSimpleSqlTable(f_TableSourceObj, f_KuName, f_TableList, f_Params);
            }

            if (tmpIsSql)
            {
                return this.ParseSqlTable(f_TableSourceObj, f_KuName, f_TableList);
            }

            throw ThrowHelper.ThrowParseTransferException(ErrorInfo.IlleagalFillFrom);
        }

        private byForm_Server.ku.by.ToolClass.Sql.Table ParseSimpleSqlTable(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_TableObj, string f_KuName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableList, System.Collections.Generic.List<object> f_Params)
        {
            if (!f_TableObj.ContainsKey(MessageTable))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.IlleagalFillFrom);
            }

            var tmpTableName = f_TableObj[MessageTable] as StringClass;

            if (tmpTableName == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.IlleagalFillFrom);
            }

            string tmpTableQualifiedName = tmpTableName.Value;
            var tmpTableArray = tmpTableQualifiedName.Split('.');
            if (tmpTableArray.Length != 2)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.IlleagalFillFrom);
            }

            var tmpSheet = ToolFunction.GetDataSheet(tmpTableQualifiedName);
            var tmpTable = new Sql.Table(tmpSheet, null);
            f_TableList.Add(tmpTable);
            return tmpTable;
        }

        private byForm_Server.ku.by.ToolClass.Sql.SelectTable ParseSqlTable(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_TableObj, string f_KuName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_TableList)
        {
            var tmpSqlObj = f_TableObj[MessageDollerTableSql] as JsonObject;
            if (tmpSqlObj == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSqlTableError);
            }

            if (!tmpSqlObj.ContainsKey(MessageNo))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            if (!tmpSqlObj.ContainsKey(MessageFrom))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
            }

            if (!tmpSqlObj.ContainsKey(MessageParameters))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }

            var tmpNoKeyPair = tmpSqlObj[MessageNo] as StringClass;
            var tmpFromKeyPair = tmpSqlObj[MessageFrom] as ArrayClass;
            var tmpParametersKeyPair = tmpSqlObj[MessageParameters] as ArrayClass;

            if (tmpNoKeyPair == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            if (tmpFromKeyPair == null)
            {
                if (!(tmpSqlObj[MessageFrom] is NullValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
                }
            }

            if (tmpParametersKeyPair == null)
            {
                if (!(tmpSqlObj[MessageParameters] is ArrayClass))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
                }
            }

            string tmpNo = tmpNoKeyPair.Value;
            string tmpTypePath = string.Format("{0}.ku.{1}.SqlExpression.sql", RootNameSpace, f_KuName);
            string tmpMethodName = string.Format("_{0}", tmpNo);
            List<Sql.AbstractTable> tmpTableList = new List<Sql.AbstractTable>();
            List<object> tmpParamsList = new List<object>();
            if (tmpFromKeyPair != null)
            {
                foreach (var item in tmpFromKeyPair.ValueList)
                {
                    var tmpTable = item as JsonObject;
                    if (tmpTable == null)
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
                    }

                    if (!tmpTable.ContainsKey(MessageTable))
                    {
                        tmpTableList.Add(ParseSqlTable(tmpTable, f_KuName, new List<Sql.AbstractTable>()));
                    }
                    else
                    {
                        tmpTableList.Add(ParseSimpleSqlTable(tmpTable, f_KuName, new List<Sql.AbstractTable>(), new List<object>()));
                    }
                }
            }

            this.GenerateParameterList(tmpParametersKeyPair.ValueList, tmpParamsList, f_KuName, tmpTableList);
            Sql.ParamsPackage tmpParamsPackage = new Sql.ParamsPackage(tmpTypePath, tmpMethodName, tmpTableList, tmpParamsList, null);
            Type tmpSqlType = Type.GetType(tmpParamsPackage.Path);
            Type tmpParamsPackageType = tmpParamsPackage.GetType();
            var tmpMethod = tmpSqlType.GetMethod(tmpParamsPackage.MethodName, new Type[] { tmpParamsPackageType });
            Sql.SelectTable tmpResult;
            try
            {
                tmpResult = tmpMethod.Invoke(null, new object[] { tmpParamsPackage }) as Sql.SelectTable;
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ThrowHelper.ThrowUnKnownException(ex.Message);
            }
            if (tmpResult == null)
            {
                ThrowHelper.ThrowUnKnownException(ErrorInfo.SqlUnknoweError);
            }
            f_TableList.Add(tmpResult);
            return tmpResult;
        }

        public byForm_Server.ku.by.ToolClass.AbstractIdentityBase ParseIdentity(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_IdentityJsonObj)
        {
            if (f_IdentityJsonObj.ContainsKey(MessageRef))
            {
                if (f_IdentityJsonObj.KeyPairDic.Count > 1)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpNode = f_IdentityJsonObj[MessageRef] as StringClass;
                if (tmpNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpRefValue = tmpNode.Value;
                if (!this.InstanceDic.ContainsKey(tmpRefValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                }

                var tmpIdentity = this.InstanceDic[tmpRefValue];

                if (!(tmpIdentity is AbstractIdentityBase))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                }

                return (AbstractIdentityBase)this.InstanceDic[tmpRefValue];
            }

            if (!f_IdentityJsonObj.ContainsKey(MessageID))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
            }

            if (!f_IdentityJsonObj.ContainsKey(MessageInstance))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
            }

            var tmpInstanceObj = f_IdentityJsonObj[MessageInstance] as JsonObject;
            var tmpId = f_IdentityJsonObj[MessageID] as StringClass;

            if (tmpId == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
            }

            if (this.InstanceDic.ContainsKey(tmpId.Value))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ConflictInstance);
            }

            if (tmpInstanceObj == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
            }

            if (!tmpInstanceObj.ContainsKey(MessageInner))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
            }

            if (!tmpInstanceObj.ContainsKey(MessageValue))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
            }

            var tmpInner = tmpInstanceObj[MessageInner] as BoolValue;
            var tmpValue = tmpInstanceObj[MessageValue] as StringClass;

            if (tmpInner == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
            }

            if (tmpValue == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
            }

            string[] tmpValueArray = tmpValue.Value.Split('.');
            if (tmpValueArray.Length != 2 && tmpValueArray.Length != 3)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
            }

            string tmpKuName = tmpValueArray[0];
            if (tmpInner.Value)
            {
                //数据表内标记的

                string tmpDataSheetName = tmpValueArray[1];
                var tmpDataSheet = ToolFunction.GetDataSheet(tmpKuName, tmpDataSheetName);

                if (tmpValueArray.Length == 2)
                {
                    var tmpIdentity = tmpDataSheet.Identity;
                    this.InstanceDic.Add(tmpId.Value, tmpIdentity);
                    return tmpIdentity;
                }
                else
                {
                    string tmpColName = tmpValueArray[2];
                    if (!tmpDataSheet.FieldDic.ContainsKey(tmpColName))
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.CanNotFindColumn);
                    }
                    var tmpField = tmpDataSheet.FieldDic[tmpColName].Identity;
                    this.InstanceDic.Add(tmpId.Value, tmpField);
                    return tmpField;
                }

            }
            else
            {
                //new中标记的
                string tmpInstanceName = tmpValueArray[1];
                string tmpNewInstanceName = "New_" + tmpInstanceName;
                var tmpKu = Root.GetInstance()[tmpKuName];
                if (!tmpKu.NewIdentityDic.ContainsKey(tmpNewInstanceName))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
                }
                var tmpNewInstance = tmpKu.NewIdentityDic[tmpNewInstanceName];
                this.InstanceDic.Add(tmpId.Value, tmpNewInstance);
                return tmpNewInstance;
            }
        }

        public object ParseObject(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj, System.Type f_Type)
        {
            //f_Type检查继承
            if (f_Obj.ContainsKey(MessageRef))
            {
                if (f_Obj.KeyPairDic.Count > 1)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpNode = f_Obj[MessageRef] as StringClass;

                if (tmpNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpRefValue = tmpNode.Value;
                if (!this.InstanceDic.ContainsKey(tmpRefValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                }

                return this.InstanceDic[tmpRefValue];
            }

            var tmpValue = f_Obj;

            if (!tmpValue.ContainsKey(MessageParameterObjType))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalJsonObj);
            }

            var tmpObjType = tmpValue[MessageParameterObjType] as StringClass;
            if (tmpObjType == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsTypeError);
            }
            string tmpTypeValue = tmpObjType.Value;

            if (tmpTypeValue == MessageArray)
            {
                //参数中数组只以json格式数组形式传输
                return this.ParseArray(f_Type, f_Obj);
            }

            if (tmpTypeValue == MessageList)
            {
                return this.ParseList(f_Type, f_Obj);
            }

            if (tmpTypeValue == MessageDictionary)
            {
                return this.ParseDictionary(f_Type, f_Obj);
            }

            if (!System.Enum.IsDefined(typeof(SqlObjParameterTypeEnum), tmpTypeValue))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalJsonObj);
            }

            if (tmpTypeValue == MessageQuery)
            {
                //说明是查询区
                return this.ParseQueryDataValue(tmpValue);
            }
            else if (tmpTypeValue == MessageRow)
            {
                //说明是行
                return this.ParseRow(tmpValue);
            }
            else if (tmpTypeValue == MessageOrm)
            {
                if (!f_Obj.ContainsKey(MessageType))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
                }

                var tmpOrmNameNode = f_Obj[MessageType] as StringClass;

                if (tmpOrmNameNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
                }

                string tmpName = tmpOrmNameNode.value;
                KeyValuePair<Type, IOrmType> tmpOrmType;

                if (!Root.GetInstance().OrmTypeDic.TryGetValue(tmpName, out tmpOrmType))
                {
                    ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CanNotFindOrmType, tmpName));
                }

                if (f_Type != tmpOrmType.Key)
                {
                    ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CanNotFindOrmType, tmpName));
                }

                return ParseOrm(f_Obj, tmpOrmType.Value);
            }
            else
            {
                //说明是用户自定义类型的对象
                if (!f_Obj.ContainsKey(MessageType))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceNameError);
                }

                var tmpTypeNode = f_Obj[MessageType] as StringClass;

                if (tmpTypeNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
                }

                string tmpObjTypeName = tmpTypeNode.Value;
                string[] tmpNames = tmpObjTypeName.Split('.');

                if (tmpNames.Length != 2)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceError);
                }

                string tmpKuName = tmpNames[0];
                string tmpComparedName = tmpNames[1];

                string tmpFullName = tmpKuName + "." + tmpComparedName;

                if (TypeDic.ContainsKey(tmpFullName))
                {
                    return this.ParseUserDefinedObject(tmpKuName, TypeDic[tmpFullName], f_Obj);
                }

                if (tmpKuName == "by")
                {
                    Type tmpType = null;

                    if (tmpComparedName == "Object")
                    {
                        tmpType = typeof(object);
                    }

                    if (tmpComparedName == "Exception")
                    {
                        tmpType = typeof(Exception);
                    }

                    if (tmpComparedName == "CastException")
                    {
                        tmpType = typeof(InvalidCastException);
                    }

                    if (tmpComparedName == "IndexOutOfRangeException")
                    {
                        tmpType = typeof(IndexOutOfRangeException);
                    }

                    if (tmpComparedName == "KeyNotFoundException")
                    {
                        tmpType = typeof(KeyNotFoundException);
                    }

                    if (tmpComparedName == "NullReferenceException")
                    {
                        tmpType = typeof(NullReferenceException);
                    }

                    if (tmpComparedName == "StackOverflowException")
                    {
                        tmpType = typeof(StackOverflowException);
                    }

                    if (tmpComparedName == "StringBuilder")
                    {
                        tmpType = typeof(StringBuilder);
                    }

                    if (tmpComparedName == "Table")
                    {
                        tmpType = typeof(Object.table);
                    }

                    if (tmpComparedName == "Field")
                    {
                        tmpType = typeof(Object.field);
                    }

                    if (tmpComparedName == "EventArgs")
                    {
                        tmpType = typeof(EventArgs);
                    }

                    if (tmpType != null)
                    {
                        TypeDic.Add(tmpFullName, tmpType);
                        return this.ParseUserDefinedObject(tmpKuName, tmpType, f_Obj);
                    }
                }

                if (Root.GetInstance().ReNamedObjDicKeyIsOld.ContainsKey(tmpComparedName))
                {
                    tmpComparedName = Root.GetInstance().ReNamedObjDicKeyIsOld[tmpComparedName];
                }

                string tmpTypePath = this.RootNameSpace + ".ku." + tmpKuName + ".Object." + tmpComparedName;
                Type tmpRefType;

                try
                {
                    tmpRefType = Type.GetType(tmpTypePath);
                }
                catch
                {
                    throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ObjectTypeNotMatch, tmpObjTypeName));
                }

                if (tmpRefType != f_Type)
                {
                    throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ObjectTypeNotMatch, tmpObjTypeName));
                }

                TypeDic.Add(tmpFullName, tmpRefType);
                return this.ParseUserDefinedObject(tmpKuName, tmpRefType, f_Obj);
            }
        }

        public object ParseList(System.Type f_Type, byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj)
        {
            if (f_Type.GetGenericArguments().Length != 1)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseListError);
            }

            if (f_Obj.ContainsKey(MessageRef))
            {
                if (f_Obj.KeyPairDic.Count > 1)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpNode = f_Obj[MessageRef] as StringClass;
                if (tmpNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpRefValue = tmpNode.Value;
                if (!this.InstanceDic.ContainsKey(tmpRefValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                }

                return this.InstanceDic[tmpRefValue];
            }

            if (!f_Obj.ContainsKey(MessageParameterObjType))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
            }

            if (!f_Obj.ContainsKey(MessageID))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseListError);
            }

            var tmpTypeNode = f_Obj[MessageParameterObjType] as StringClass;
            var tmpIdNode = f_Obj[MessageID] as StringClass;
            var tmpArrayNode = f_Obj[MessageArrayValue] as ArrayClass;

            if (tmpTypeNode == null || tmpTypeNode.Value != MessageList)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
            }

            if (tmpIdNode == null || tmpArrayNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseListError);
            }

            string tmpId = tmpIdNode.Value;
            var tmpValueList = tmpArrayNode.ValueList;
            var tmpInstance = Activator.CreateInstance(f_Type) as IList;
            var tmpGenericType = f_Type.GetGenericArguments()[0];

            //if (tmpGenericType.IsGenericType)
            //{
            //    ThrowHelper.ThrowParseTransferException("list不支持嵌套泛型类型");
            //}

            FillIList(tmpInstance, tmpValueList, tmpGenericType);
            this.InstanceDic.Add(tmpId, tmpInstance);
            return tmpInstance;
        }

        public object ParseArray(System.Type f_Type, byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj)
        {
            if (!f_Type.IsArray)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            if (f_Obj.ContainsKey(MessageRef))
            {
                if (f_Obj.KeyPairDic.Count > 1)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpNode = f_Obj[MessageRef] as StringClass;
                if (tmpNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpRefValue = tmpNode.Value;
                if (!this.InstanceDic.ContainsKey(tmpRefValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                }

                return this.InstanceDic[tmpRefValue];
            }

            if (!f_Obj.ContainsKey(MessageParameterObjType))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
            }

            if (!f_Obj.ContainsKey(MessageID))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            if (!f_Obj.ContainsKey(MessageArrayValue))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            var tmpTypeNode = f_Obj[MessageParameterObjType] as StringClass;
            var tmpIdNode = f_Obj[MessageID] as StringClass;
            var tmpArrayNode = f_Obj[MessageArrayValue] as ArrayClass;

            if (tmpTypeNode == null || tmpTypeNode.Value != MessageArray)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParameterObjTypeError);
            }

            if (tmpIdNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            if (tmpArrayNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            string tmpId = tmpIdNode.Value;
            var tmpValueList = tmpArrayNode.ValueList;
            var tmpElementType = f_Type.GetElementType();
            var tmpInstance = Array.CreateInstance(tmpElementType, tmpValueList.Count);
            IList tmpValues = new List<object>();
            FillIList(tmpValues, tmpValueList, tmpElementType);
            tmpValues.CopyTo(tmpInstance, 0);
            this.InstanceDic.Add(tmpId, tmpInstance);
            return tmpInstance;
        }

        public object ParseDictionary(System.Type f_Type, byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj)
        {
            if (f_Obj.ContainsKey(MessageRef))
            {
                if (f_Obj.KeyPairDic.Count > 1)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpNode = f_Obj[MessageRef] as StringClass;
                if (tmpNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpRefValue = tmpNode.Value;
                if (!this.InstanceDic.ContainsKey(tmpRefValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                }

                return this.InstanceDic[tmpRefValue];
            }

            if (!f_Obj.ContainsKey(MessageID))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            if (!f_Obj.ContainsKey(MessageKeys))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            if (!f_Obj.ContainsKey(MessageArrayValue))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            var tmpIdNode = f_Obj[MessageID] as StringClass;
            var tmpKeysNode = f_Obj[MessageKeys] as ArrayClass;
            var tmpValuesNode = f_Obj[MessageValues] as ArrayClass;

            if (tmpIdNode == null || tmpKeysNode == null || tmpValuesNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseArrayError);
            }

            string tmpID = tmpIdNode.Value;
            var tmpKeyList = tmpKeysNode.valueList;
            var tmpValueList = tmpValuesNode.valueList;
            Type tmpListType = typeof(List<>);
            var tmpTypeArgs = f_Type.GetGenericArguments();
            if (tmpTypeArgs.Length != 2)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDictionaryError);
            }
            var tmpKeysType = tmpListType.MakeGenericType(tmpTypeArgs[0]);
            var tmpValuesType = tmpListType.MakeGenericType(tmpTypeArgs[1]);
            //if (!(tmpKeysType.IsGenericType || tmpValuesType.IsGenericType))
            //{
            //    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDictionaryError);
            //}
            var tmpKeysInstance = Activator.CreateInstance(tmpKeysType) as System.Collections.IList;
            var tmpValuesInstance = Activator.CreateInstance(tmpValuesType) as System.Collections.IList;
            var tmpInstance = Activator.CreateInstance(f_Type) as IDictionary;
            FillIList(tmpKeysInstance, tmpKeyList, tmpKeysType.GetGenericArguments()[0]);
            FillIList(tmpValuesInstance, tmpValueList, tmpValuesType.GetGenericArguments()[0]);

            if (tmpKeyList.Count != tmpValueList.Count)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseDictionaryError);
            }

            for (int i = 0; i < tmpValueList.Count; i++)
            {
                var tmpKey = tmpKeysInstance[i];
                var tmpValue = tmpValuesInstance[i];
                tmpInstance.Add(tmpKey, tmpValue);
            }

            this.InstanceDic.Add(tmpID, tmpInstance);
            return tmpInstance;
        }

        private void FillIList(System.Collections.IList f_Target, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue> f_Values, System.Type f_ValueType)
        {
            foreach (var item in f_Values)
            {
                if (item is Num)
                {
                    var tmpNum = item as Num;
                    string tmpValue = tmpNum.Value;

                    if (f_ValueType == byteType)
                    {
                        f_Target.Add(Convert.ToSByte(tmpValue));
                        continue;
                    }

                    if (f_ValueType == shortType)
                    {
                        f_Target.Add(Convert.ToInt16(tmpValue));
                        continue;
                    }

                    if (f_ValueType == intType)
                    {
                        f_Target.Add(Convert.ToInt32(tmpValue));
                        continue;
                    }

                    if (f_ValueType == floatType)
                    {
                        f_Target.Add(Convert.ToSingle(tmpValue));
                        continue;
                    }

                    if (f_ValueType == doubleType)
                    {
                        f_Target.Add(Convert.ToDouble(tmpValue));
                        continue;
                    }

                    ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
                }

                if (item is StringClass)
                {
                    var tmpString = item as StringClass;
                    string tmpValue = tmpString.Value;

                    if (f_ValueType == longType)
                    {
                        f_Target.Add(Convert.ToInt64(tmpValue));
                        continue;
                    }

                    if (f_ValueType == decimalType)
                    {
                        f_Target.Add(Convert.ToDecimal(tmpValue));
                        continue;
                    }

                    if (f_ValueType == stringType)
                    {
                        f_Target.Add(tmpValue);
                        continue;
                    }

                    if (f_ValueType == dateTimeType)
                    {
                        f_Target.Add(ku.by.Object.datetime.parse(tmpValue));
                        continue;
                    }

                    if (f_ValueType == charType)
                    {
                        f_Target.Add(Convert.ToChar(tmpValue));
                        continue;
                    }

                    ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
                }

                if (item is BoolValue)
                {
                    if (f_ValueType == boolType)
                    {
                        var tmpBool = item as BoolValue;
                        f_Target.Add(tmpBool.Value);
                        continue;
                    }

                    ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
                }

                if (item is NullValue)
                {
                    //基元类型和值类型不支持

                    if (f_ValueType.IsEnum || f_ValueType.IsPrimitive)
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
                    }

                    f_Target.Add(null);
                    continue;
                }

                if (item is JsonObject)
                {
                    //不可能为数组形式
                    var tmpJson = item as JsonObject;
                    f_Target.Add(ParseObject(tmpJson, f_ValueType));
                    continue;
                }

                ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
            }
        }

        public object ParseUserDefinedObject(string f_KuName, System.Type f_Type, byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj)
        {
            if (f_Obj.ContainsKey(MessageRef))
            {
                if (f_Obj.KeyPairDic.Count > 1)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpNode = f_Obj[MessageRef] as StringClass;
                if (tmpNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpRefValue = tmpNode.Value;
                if (!this.InstanceDic.ContainsKey(tmpRefValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                }

                return this.InstanceDic[tmpRefValue];
            }

            if (!f_Obj.ContainsKey(MessageID))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseObjectError);
            }

            var tmpIdNode = f_Obj[MessageID] as StringClass;

            if (tmpIdNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseObjectError);
            }

            if (!f_Obj.ContainsKey(MessageDollarIdentity))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
            }

            string tmpId = tmpIdNode.Value;
            if (this.InstanceDic.ContainsKey(tmpId))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ConflictInstance);
            }

            if (f_Type == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceNameError);
            }

            var tmpPropertys = f_Type.GetProperties();
            var tmpInstance = System.Activator.CreateInstance(f_Type);
            Dictionary<string, string> tmpReNamedPropDic = new Dictionary<string, string>();

            if (Root.GetInstance().ReNamedPropDicKeyIsOld.ContainsKey(f_KuName))
            {
                tmpReNamedPropDic = Root.GetInstance().ReNamedPropDicKeyIsOld[f_KuName];
            }

            foreach (var item in tmpPropertys)
            {
                string tmpPropName = item.Name;
                if (tmpReNamedPropDic.Count != 0)
                {
                    string tmpComaredName = f_Type.Name + "." + tmpPropName;
                    if (tmpReNamedPropDic.ContainsKey(tmpComaredName))
                    {
                        string tmpQualifiedObjName = tmpReNamedPropDic[tmpComaredName];
                        tmpPropName = tmpQualifiedObjName.Split('.')[1];
                    }
                }

                if (!f_Obj.ContainsKey(tmpPropName) && tmpPropName != "Identity")
                {
                    continue;
                    //ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                }

                if (tmpPropName == "Identity")
                {
                    var tmpIdentityNode = f_Obj[MessageDollarIdentity];
                    if (tmpIdentityNode is NullValue)
                    {
                        continue;
                    }
                    else
                    {
                        var tmpIdentity = tmpIdentityNode as JsonObject;
                        item.SetValue(tmpInstance, this.ParseIdentity(tmpIdentity));
                    }
                }
                //不可能有查询区类型，

                if (item.PropertyType == byteType)
                {
                    var tmpValue = f_Obj[tmpPropName] as Num;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, byte.Parse(tmpValue.Value));
                }

                else if (item.PropertyType == shortType)
                {
                    var tmpValue = f_Obj[tmpPropName] as Num;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, short.Parse(tmpValue.Value));
                }


                else if (item.PropertyType == intType)
                {
                    var tmpValue = f_Obj[tmpPropName] as Num;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, int.Parse(tmpValue.Value));
                }
                else if (item.PropertyType == longType)
                {
                    var tmpValue = f_Obj[tmpPropName] as StringClass;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, long.Parse(tmpValue.Value));
                }
                else if (item.PropertyType == floatType)
                {
                    var tmpValue = f_Obj[tmpPropName] as Num;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, float.Parse(tmpValue.Value));
                }
                else if (item.PropertyType == doubleType)
                {
                    var tmpValue = f_Obj[tmpPropName] as Num;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, double.Parse(tmpValue.Value));
                }
                else if (item.PropertyType == decimalType)
                {
                    var tmpValue = f_Obj[tmpPropName] as Num;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, decimal.Parse(tmpValue.Value));
                }
                else if (item.PropertyType == boolType)
                {
                    var tmpValue = f_Obj[tmpPropName] as BoolValue;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, tmpValue.Value);
                }
                else if (item.PropertyType == charType)
                {
                    var tmpValue = f_Obj[tmpPropName] as StringClass;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, char.Parse(tmpValue.Value));
                }
                else if (item.PropertyType == stringType)
                {
                    if (f_Obj[tmpPropName] is NullValue)
                    {
                        item.SetValue(tmpInstance, null);
                        continue;
                    }
                    var tmpValue = f_Obj[tmpPropName] as StringClass;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, tmpValue.Value);
                }
                else if (item.PropertyType == dateTimeType)
                {
                    if (f_Obj[tmpPropName] is NullValue)
                    {
                        item.SetValue(tmpInstance, null);
                        continue;
                    }
                    var tmpValue = f_Obj[tmpPropName] as StringClass;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.CannotFindProp, tmpPropName));
                    }
                    item.SetValue(tmpInstance, ku.by.Object.datetime.parse(tmpValue.Value));
                }
                else
                {
                    if (f_Obj[tmpPropName] is NullValue)
                    {
                        item.SetValue(tmpInstance, null);
                        this.InstanceDic.Add(tmpId, null);
                        continue;
                    }

                    var tmpArrayType = typeof(Array);
                    var tmpType = item.PropertyType;
                    var tmpValue = f_Obj[tmpPropName] as JsonObject;
                    if (tmpValue == null)
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ObjectPropError);
                    }
                    if (item.PropertyType == tmpArrayType)
                    {
                        item.SetValue(tmpInstance, this.ParseArray(item.PropertyType, tmpValue));
                    }
                    else
                    {
                        var tmpObj = this.ParseObject(tmpValue, tmpType);
                        if (tmpType != tmpObj.GetType())
                        {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.ObjectPropError);
                        }
                        item.SetValue(tmpInstance, tmpObj);
                    }
                }
            }

            this.InstanceDic.Add(tmpId, tmpInstance);
            return tmpInstance;
        }

        private byForm_Server.ku.by.Object.Cell ParseField(string f_JsonField)
        {
            string tmpRegex1 = "\\((.*?)\\)";
            string tmpRegex2 = "\\[(.*?)\\]";
            Object.Cell tmpReturnValue = new Object.Cell();

            if (f_JsonField.Contains('(') && f_JsonField.EndsWith(")"))
            {
                Regex tmpStatistic = new Regex(tmpRegex1);
                var tmpMatches = tmpStatistic.Matches(f_JsonField);

                if (tmpMatches.Count != 1)
                {
                    string.Format(ErrorInfo.ParseFieldError, f_JsonField);
                }

                var tmpFieldValue = tmpMatches[0].Value;
                var tmpFieldSplit = tmpFieldValue.Substring(1, tmpFieldValue.Length - 2).Split('.');

                if (tmpFieldSplit.Length != 3)
                {
                    string.Format(ErrorInfo.ParseFieldError, f_JsonField);
                }

                string tmpFieldKuName = tmpFieldSplit[0];
                string tmpFieldSheetName = tmpFieldSplit[1];
                string tmpFieldName = tmpFieldSplit[2];
                int tmpStartIndex = f_JsonField.IndexOf('(');
                string tmpAggregateFunctionName = f_JsonField.Substring(0, tmpStartIndex);
                Object.table tmpFieldTable;

                try
                {
                    tmpFieldTable = (Object.table)ToolClass.ToolFunction.GetDataSheet(tmpFieldKuName, tmpFieldSheetName);
                }
                catch(Exception ex)
                {
                    throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseFieldError, ex.Message));
                }

                if (!tmpFieldTable.Fields.ContainsKey(tmpFieldName))
                {
                    throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseFieldError, f_JsonField));
                }

                var tmpField = tmpFieldTable.Fields[tmpFieldName];

                try
                {
                    var tmpFunc = (FunctionEnum)System.Enum.Parse(typeof(FunctionEnum), tmpAggregateFunctionName);

                    if (tmpFunc == FunctionEnum.NONE)
                    {
                        throw new Exception();
                    }

                    tmpReturnValue.AggregateFunctionName = tmpFunc.ToString();

                    if (tmpFunc == FunctionEnum.COUNT)
                    {
                        tmpReturnValue.DataTypeEnum = DataTypeEnum.Int;
                    }
                    else
                    {
                        tmpReturnValue.DataTypeEnum = tmpField.Field.FieldType;
                    }
                }
                catch
                {
                    throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseFieldError, f_JsonField));
                }

                tmpReturnValue.KuName = tmpFieldKuName;
                tmpReturnValue.SheetName = tmpFieldSheetName;
                tmpReturnValue.ColumnName = tmpFieldName;
                tmpReturnValue.field = tmpField;
                return tmpReturnValue;
            }

            if (f_JsonField.Contains('[') && f_JsonField.Contains(']'))
            {
                Regex tmpExpressionType = new Regex(tmpRegex2);
                var tmpMatches = tmpExpressionType.Matches(f_JsonField);

                if (tmpMatches.Count != 1)
                {
                    string.Format(ErrorInfo.ParseFieldError, f_JsonField);
                }

                var tmpTypeValue = tmpMatches[0].Value;
                var tmpTypeName = tmpTypeValue.Substring(1, tmpTypeValue.Length - 2);
                string tmpMatchedValue = FirstCharacterToUpper(tmpTypeName);
                DataTypeEnum tmpDataType;

                try
                {
                    if (tmpMatchedValue.Split('.').Length != 1)
                    {
                        tmpDataType = DataTypeEnum.Enum;
                        //枚举重命名还没加
                        var tmpEnumSplit = tmpMatchedValue.Split('.');

                        if (tmpEnumSplit.Length != 3)
                        {
                            throw new Exception();
                        }

                        string tmpEnumTypePath = string.Format("{0}.ku.{1}.Enum.{2}", this.RootNameSpace, tmpEnumSplit[0], tmpEnumSplit[2]);
                        tmpReturnValue.EnumType = Type.GetType(tmpEnumTypePath);
                    }
                    else
                    {
                        tmpDataType = (DataTypeEnum)System.Enum.Parse(typeof(DataTypeEnum), tmpMatchedValue);
                    }


                    if (tmpDataType == DataTypeEnum.None)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseFieldError, f_JsonField));
                }

                tmpReturnValue.DataTypeEnum = tmpDataType;
                int tmpAliasIndex = f_JsonField.LastIndexOf("]") + 1;

                if (tmpAliasIndex != f_JsonField.Length)
                {
                    string tmpAlias = f_JsonField.Substring(tmpAliasIndex);
                    tmpReturnValue.ColumnName = tmpAlias;
                    tmpReturnValue.Alias = tmpAlias;
                    return tmpReturnValue;
                }

                tmpReturnValue.ColumnName = tmpDataType.ToString();
                return tmpReturnValue;
            }

            var tmpSplit = f_JsonField.Split('.');

            if (tmpSplit.Length != 3)
            {
                throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseFieldError, f_JsonField));
            }

            string tmpKuName = tmpSplit[0];
            string tmpSheetName = tmpSplit[1];
            string tmpName = tmpSplit[2];
            Object.table tmpTable;

            try
            {
                tmpTable = (Object.table)ToolClass.ToolFunction.GetDataSheet(tmpKuName, tmpSheetName);
            }
            catch (Exception ex)
            {
                throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseFieldError, ex.Message));
            }

            if (!tmpTable.Fields.ContainsKey(tmpName))
            {
                throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseFieldError, f_JsonField));
            }

            var tmpCellField = tmpTable.Fields[tmpName];
            tmpReturnValue.KuName = tmpKuName;
            tmpReturnValue.SheetName = tmpSheetName;
            tmpReturnValue.ColumnName = tmpName;
            tmpReturnValue.field = tmpCellField;
            tmpReturnValue.DataTypeEnum = tmpCellField.Field.FieldType;
            tmpReturnValue.EnumType = tmpCellField.Field.EnumType;
            return tmpReturnValue;
        }

        private byForm_Server.ku.by.Object.Row ParseRow(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_RowObj)
        {
            if (f_RowObj.ContainsKey(MessageRef))
            {
                if (f_RowObj.KeyPairDic.Count > 1)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpNode = f_RowObj[MessageRef] as StringClass;
                if (tmpNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                }

                var tmpRefValue = tmpNode.Value;
                if (!this.InstanceDic.ContainsKey(tmpRefValue))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                }

                var tmpRow = this.InstanceDic[tmpRefValue];

                if (!(tmpRow is Object.Row))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalRow);
                }

                return (Object.Row)tmpRow;
            }

            if (!f_RowObj.ContainsKey(MessageFields))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalRow);
            }

            if (!f_RowObj.ContainsKey(MessageValues))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalRow);
            }

            if (!f_RowObj.ContainsKey(MessageDollarIdentity))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalRow);
            }

            var tmpCellNameArray = f_RowObj[MessageFields] as ArrayClass;
            var tmpCellValueArray = f_RowObj[MessageValues] as ArrayClass;

            if (tmpCellNameArray.ValueList.Count != tmpCellValueArray.ValueList.Count)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRowColumnsError);
            }

            Object.Row tmpNewRow = new Object.Row();

            for (int i = 0; i < tmpCellNameArray.Count; i++)
            {
                var tmpFieldNameStringClass = tmpCellNameArray.ValueList[i] as StringClass;
                var tmpCellValue = tmpCellValueArray.ValueList[i];

                if (tmpFieldNameStringClass == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRowColumnsError);
                }

                string tmpFieldName = tmpFieldNameStringClass.Value;
                Object.Cell tmpCell = ParseField(tmpFieldName);
                tmpCell.row = tmpNewRow;

                if (tmpCellValue is StringClass)
                {
                    var tmpStringValue = tmpCellValue as StringClass;
                    tmpCell.SetValue(tmpStringValue.Value);
                }

                if (tmpCellValue is Num)
                {
                    var tmpNumValue = tmpCellValue as Num;
                    var tmpNumArray = tmpNumValue.Value.Split('.');
                    if (tmpNumArray.Length == 1)
                    {
                        tmpCell.SetValue(long.Parse(tmpNumValue.Value));
                    }
                    else if (tmpNumArray.Length == 2)
                    {
                        tmpCell.SetValue(double.Parse(tmpNumValue.Value));
                    }
                    else
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.JsonNumParseError, tmpCellValue.ToString()));
                    }
                }

                if (tmpCellValue is BoolValue)
                {
                    var tmpBoolValue = tmpCellValue as BoolValue;
                    tmpCell.SetValue(tmpBoolValue.Value);
                    tmpCell.DataTypeEnum = DataTypeEnum.Bool;
                }

                if (tmpCellValue is NullValue)
                {
                    tmpCell.SetValue(null);
                }

                if (tmpCellValue is JsonObject)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.CellValueTypeError);
                }

                tmpNewRow.cells.Add(tmpCell);
            }

            if (f_RowObj[MessageDollarIdentity] is NullValue)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
            }

            var tmpIdentityObj = f_RowObj[MessageDollarIdentity] as JsonObject;
            tmpNewRow.Identity = this.ParseIdentity(tmpIdentityObj);
            var tmpIntanceID = f_RowObj[MessageID] as StringClass;
            if(tmpIntanceID == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
            }
            string tmpID = tmpIntanceID.Value;
            if (this.InstanceDic.ContainsKey(tmpID))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceIdError);
            }

            this.InstanceDic.Add(tmpID, tmpNewRow);
            return tmpNewRow;
        }

        public object ParseOrm(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_OrmObj, byForm_Server.ku.by.ToolClass.IOrmType f_OrmType)
        {
            if (!f_OrmObj.ContainsKey(MessageID) || !f_OrmObj.ContainsKey(MessageFields) || !f_OrmObj.ContainsKey(MessageType) || !f_OrmObj.ContainsKey(MessageValues) || !f_OrmObj.ContainsKey(MessageDollarIDentitys) ||
                !f_OrmObj.ContainsKey(MessageParameterObjType) || !f_OrmObj.ContainsKey(MessageFIELDSMAP) || !f_OrmObj.ContainsKey(MessageTableFieldsMap))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
            }

            var tmpIDNode = f_OrmObj[MessageID] as StringClass;
            var tmpFieldsNode = f_OrmObj[MessageFields] as ArrayClass;
            var tmpValuesNode = f_OrmObj[MessageValues] as ArrayClass;
            var tmpParameterTypeNode = f_OrmObj[MessageParameterObjType] as StringClass;
            var tmpIdentitysNode = f_OrmObj[MessageDollarIDentitys] as ArrayClass;
            var tmpFieldsMapNode = f_OrmObj[MessageFIELDSMAP] as JsonObject;
            var tmpTableMapNode = f_OrmObj[MessageTableFieldsMap] as JsonObject;

            if (tmpIDNode == null || tmpFieldsNode == null || tmpValuesNode == null || tmpIdentitysNode == null || tmpParameterTypeNode == null || tmpFieldsMapNode == null || tmpTableMapNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
            }

            if (tmpParameterTypeNode.Value != MessageOrm)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
            }

            if (tmpFieldsNode.Count != tmpValuesNode.Count)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRowColumnsError);
            }

            List<ku.by.Object.Cell> tmpCells = new List<Object.Cell>();
            var tmpNewRow = new Object.Row();
            tmpNewRow.cells = tmpCells;

            foreach (var item in tmpFieldsNode.ValueList)
            {
                var tmpFieldNode = item as StringClass;

                if (tmpFieldNode == null)
                {
                    throw ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseFieldError, tmpFieldNode));
                }

                var tmpCell = ParseField(tmpFieldNode.value);
                tmpCell.row = tmpNewRow;
                tmpCells.Add(tmpCell);
            }

            foreach (var item in tmpTableMapNode.keyPairDic)
            {
                string tmpName = item.Key;
                ArrayClass IndexArrayNode = item.Value as ArrayClass;

                if (tmpIdentitysNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
                }

                foreach (var numNode in IndexArrayNode.ValueList)
                {
                    Num tmpCellIndexNode = numNode as Num;

                    if (tmpCellIndexNode == null)
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
                    }

                    if (!tmpCellIndexNode.IsInt)
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
                    }

                    int tmpIndex = Convert.ToInt32(tmpCellIndexNode.Value);
                    tmpCells[tmpIndex].TableAlias = tmpName;
                }
            }

            for (int i = 0; i < tmpFieldsNode.Count; i++)
            {
                var tmpCellValue = tmpValuesNode.ValueList[i];
                var tmpCell = tmpCells[i];
                if (tmpCellValue is StringClass)
                {
                    var tmpStringValue = tmpCellValue as StringClass;
                    tmpCell.SetValue(tmpStringValue.Value);
                }

                if (tmpCellValue is Num)
                {
                    var tmpNumValue = tmpCellValue as Num;
                    var tmpNumArray = tmpNumValue.Value.Split('.');
                    if (tmpNumArray.Length == 1)
                    {
                        tmpCell.SetValue(long.Parse(tmpNumValue.Value));

                    }
                    else if (tmpNumArray.Length == 2)
                    {
                        tmpCell.SetValue(double.Parse(tmpNumValue.Value));

                    }
                    else
                    {
                        ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.JsonNumParseError, tmpCellValue.ToString()));
                    }
                }

                if (tmpCellValue is BoolValue)
                {
                    var tmpBoolValue = tmpCellValue as BoolValue;
                    tmpCell.SetValue(tmpBoolValue.Value);
                    tmpCell.DataTypeEnum = DataTypeEnum.Bool;
                }

                if (tmpCellValue is NullValue)
                {
                    tmpCell.SetValue(null);
                }

                if (tmpCellValue is JsonObject)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.CellValueTypeError);
                }
            }

            List<IBaseDataSheet> tmpDataSheetList = new List<IBaseDataSheet>();

            foreach (var item in tmpIdentitysNode.ValueList)
            {
                var tmpIdentityNode = item as JsonObject;

                if (tmpIdentityNode == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RowIdentityError);
                }

                var tmpIdentity = ParseIdentity(tmpIdentityNode);
                var tmpDataSheet = tmpIdentity.to as IBaseDataSheet;

                if (tmpDataSheet == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RowIdentityError);
                }

                tmpDataSheetList.Add(tmpDataSheet);
            }

            if (tmpDataSheetList.Count < f_OrmType.IdentityDec.Count)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseOrmError);
            }

            var tmpOrmInstance = Activator.CreateInstance(f_OrmType.Type);

            try
            {
                var tmpCellsProp = f_OrmType.Type.GetProperty("cells");
                tmpCellsProp.SetValue(tmpOrmInstance, new Object.list<Object.Cell>(tmpCells));

                foreach (var item in f_OrmType.OrmFields)
                {
                    string tmpOrmFieldName = item.Name;
                    int tmpOrmDecIndex = item.OrmIndex;

                    if (!tmpFieldsMapNode.ContainsKey(tmpOrmFieldName))
                    {
                        ThrowHelper.ThrowSerializeException(string.Format(ErrorInfo.OrmFieldDeserializeError, f_OrmObj[MessageType] as StringClass, tmpOrmFieldName));
                    }

                    var tmpFieldMapNode = tmpFieldsMapNode[tmpOrmFieldName] as Num;
                    
                    if (tmpFieldMapNode == null)
                    {
                        ThrowHelper.ThrowSerializeException(string.Format(ErrorInfo.OrmFieldDeserializeError, f_OrmObj[MessageType] as StringClass, tmpOrmFieldName));
                    }

                    if (!tmpFieldMapNode.IsInt)
                    {
                        ThrowHelper.ThrowSerializeException(string.Format(ErrorInfo.OrmFieldDeserializeError, f_OrmObj[MessageType] as StringClass, tmpOrmFieldName));
                    }

                    int tmpFieldIndex = Convert.ToInt32(tmpFieldMapNode.Value);
                    string tmpFieldName = "memberIndex" + tmpOrmDecIndex;
                    var tmpIndexField = f_OrmType.Type.GetField(tmpFieldName);
                    tmpIndexField.SetValue(tmpOrmInstance, tmpFieldIndex);
                }

                foreach (var item in f_OrmType.IdentityDec)
                {
                    string tmpAlias = item.Key;
                    string tmpPropName = "Table" + tmpAlias;
                    var tmpProp = f_OrmType.Type.GetProperty(tmpPropName);

                    if (tmpProp == null)
                    {
                        ThrowHelper.ThrowSerializeException(ErrorInfo.OrmFieldDeserializeMemberError);
                    }

                    var tmpIdentityType = item.Value;
                    var tmpDataSheet = tmpDataSheetList.FirstOrDefault(datesheet => datesheet.Identity.GetType() == tmpIdentityType);

                    if (tmpDataSheet == null)
                    {
                        ThrowHelper.ThrowSerializeException(ErrorInfo.OrmFieldDeserializeMemberError);
                    }

                    var tmpTableCells = tmpCells.FindAll(cell=>cell.KuName == tmpDataSheet.KuName && cell.SheetName == tmpDataSheet.SheetName && cell.AggregateFunctionName == null && cell.TableAlias == tmpAlias);
                    var tmpNewTableRow = new Object.Row() { cells = tmpTableCells, Identity = tmpDataSheet.Identity, OrmSource = (Object.orm)tmpOrmInstance };
                    tmpProp.SetValue(tmpOrmInstance, tmpNewTableRow);
                }
            }
            catch (Exception ex)
            {
                ThrowHelper.ThrowParseTransferException(ex.Message);
            }

            return tmpOrmInstance;
        }

        public byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject ObjToJson(object f_Object, System.Type f_Type)
        {
            if (f_Object == null)
            {
                return null;
            }

            JsonObject tmpJsonValue = new JsonObject();
            if (this.ToJsonInstanceDic.ContainsKey(f_Object))
            {
                string tmpRefValue = this.ToJsonInstanceDic[f_Object];
                tmpJsonValue.Add(MessageRef, JsonParser.Utils.GetNewStringClass(tmpRefValue));
                return tmpJsonValue;
            }

            if (f_Object is Object.orm)
            {
                return OrmToJson((Object.orm)f_Object);
            }

            if (f_Object is ku.by.Object.Row)
            {
                return this.RowToJson((ku.by.Object.Row)f_Object);
            }

            if (f_Type.IsArray)
            {
                return IListToJson(f_Type, f_Object);
            }

            if (f_Type.GenericTypeArguments.Length != 0)
            {
                var tmpGenericTypeDefinition = f_Type.GetGenericTypeDefinition();

                if (f_Type.GenericTypeArguments.Length == 1)
                {
                    //list
                    if (tmpGenericTypeDefinition != typeof(Object.list<>))
                    {
                        ThrowHelper.ThrowSerializeException(ErrorInfo.OnlySupportlistanddictionary);
                    }

                    return IListToJson(f_Type, f_Object);
                }

                if (f_Type.GenericTypeArguments.Length == 2)
                {
                    //dictionary
                    if (tmpGenericTypeDefinition != typeof(Object.dictionary<,>))
                    {
                        ThrowHelper.ThrowSerializeException(ErrorInfo.OnlySupportlistanddictionary);
                    }

                    return DictionaryToJson(f_Type, f_Object);
                }
            }

            var tmpProps = f_Type.GetProperties();
            tmpJsonValue.Add(MessageParameterObjType, JsonParser.Utils.GetNewStringClass(MessageUserDefined));
            tmpJsonValue.Add(MessageID, JsonParser.Utils.GetNewStringClass(this.ToJsonInstanceDic.Count.ToString()));
            this.ToJsonInstanceDic.Add(f_Object, this.ToJsonInstanceDic.Count.ToString());
            string tmpObjFullName = f_Type.FullName;//xx.ku.xx.Object.xx
            string tmpBaseku = "by";
            string tmpKuName;
            string tmpObjName;
            //可能是object

            switch (tmpObjFullName)
            {
                case "System.Object":
                    tmpKuName = tmpBaseku;
                    tmpObjName = "object";
                    break;
                case "System.Text.StringBuilder":
                    tmpKuName = tmpBaseku;
                    tmpObjName = "StringBuilder";
                    break;
                case "System.Exception":
                    tmpKuName = tmpBaseku;
                    tmpObjName = "Exception";
                    break;
                case "System.InvalidCastException":
                    tmpKuName = tmpBaseku;
                    tmpObjName = "CastException";
                    break;
                case "System.IndexOutOfRangeException":
                    tmpKuName = tmpBaseku;
                    tmpObjName = "IndexOutOfRangeException";
                    break;
                case "System.NullReferenceException":
                    tmpKuName = tmpBaseku;
                    tmpObjName = "NullReferenceException";
                    break;
                case "System.StackOverflowException":
                    tmpKuName = tmpBaseku;
                    tmpObjName = "StackOverflowException";
                    break;
                case "System.Collections.Generic.KeyNotFoundException":
                    tmpKuName = tmpBaseku;
                    tmpObjName = "KeyNotFoundException";
                    break;
                default:
                    string[] tmpObjNameCollection = tmpObjFullName.Split('.');
                    tmpKuName = tmpObjNameCollection[2];
                    tmpObjName = f_Type.Name;

                    if (tmpKuName == tmpBaseku && tmpObjName == "byObject")
                    {
                        tmpObjName = "object";
                    }

                    if (tmpKuName == tmpBaseku && tmpObjName == "field")
                    {
                        tmpObjName = "Field";
                    }

                    if (tmpKuName == tmpBaseku && tmpObjName == "table")
                    {
                        tmpObjName = "Table";
                    }
                    break;
            }


            string tmpObjComparedName = tmpKuName + "." + tmpObjName;

            if (Root.GetInstance().RenamedObjDicKeyIsNew.ContainsKey(tmpObjComparedName))
            {
                tmpObjComparedName = Root.GetInstance().RenamedObjDicKeyIsNew[tmpObjComparedName];
            }

            tmpJsonValue.Add(MessageType, JsonParser.Utils.GetNewStringClass(tmpObjComparedName));
            Dictionary<string, string> tmpRenamedPropNameDic = new Dictionary<string, string>();
            if (Root.GetInstance().ReNamedPropDicKeyIsNew.ContainsKey(tmpKuName))
            {
                tmpRenamedPropNameDic = Root.GetInstance().ReNamedPropDicKeyIsNew[tmpKuName];
            }

            //不支持类型为自定义类型的属性
            foreach (var item in tmpProps)
            {
                object tmpValue = item.GetValue(f_Object);
                Type tmpPropType = tmpValue == null ? item.PropertyType : tmpValue.GetType();
                string tmpPropName = item.Name;

                if (tmpRenamedPropNameDic.Count != 0)
                {
                    string tmpComparedName = tmpObjName + "." + tmpPropName;
                    if (tmpRenamedPropNameDic.ContainsKey(tmpComparedName))
                    {
                        tmpPropName = tmpRenamedPropNameDic[tmpComparedName].Split('.')[1];
                    }
                }
                //props里面的全是公有的
                if (tmpPropName == "Identity")
                {
                    tmpPropName = MessageDollarIdentity;
                }

                if (tmpValue == null)
                {
                    tmpJsonValue.Add(tmpPropName, new NullValue());
                    continue;
                }

                if (tmpPropType == byteType || tmpPropType == shortType || tmpPropType == intType || tmpPropType == doubleType || tmpPropType == floatType)
                {
                    if (tmpPropType == doubleType)
                    {
                        var tmpDoubleValue = (double)tmpValue;
                        if (tmpDoubleValue == double.PositiveInfinity)
                        {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.PositiveInfinity);
                        }
                    }
                    tmpJsonValue.Add(tmpPropName, new Num(tmpValue.ToString()));
                    continue;
                }

                if (tmpPropType == typeof(bool))
                {
                    tmpJsonValue.Add(tmpPropName, new BoolValue(tmpValue.ToString()));
                    continue;
                }

                if (tmpPropType == stringType || tmpPropType == charType || tmpPropType == longType || tmpPropType == decimalType || tmpPropType == dateTimeType)
                {
                    tmpJsonValue.Add(tmpPropName, JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                    continue;
                }

                if (tmpPropType == typeof(Object.Row))
                {
                    tmpJsonValue.Add(tmpPropName, this.RowToJson((Object.Row)tmpValue));
                    continue;

                }

                if (tmpPropType.IsArray)
                {
                    string tmpTypeFullName = tmpPropType.FullName;
                    string tmpTypeName = tmpTypeFullName.Substring(8, tmpTypeFullName.Length - 2);
                    var tmpType = Type.GetType(tmpTypeName);

                    if (tmpPropType == typeof(byte) || tmpPropType == typeof(short) || tmpPropType == typeof(int) || tmpPropType == typeof(double) || tmpPropType == typeof(float)
                        || tmpPropType == typeof(bool) || tmpPropType == typeof(string) || tmpPropType == typeof(char) || tmpPropType == typeof(long) || tmpPropType == typeof(decimal)
                        || tmpPropType == typeof(ku.by.Object.datetime) || tmpPropType == typeof(Object.Row))
                    {
                        tmpJsonValue.Add(tmpPropName, this.IListToJson(tmpType, tmpValue));
                        continue;
                    }
                    else
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.UnSupportedArrayType);
                    }

                }

                if (tmpPropName == MessageDollarIdentity)
                {
                    tmpJsonValue.Add(MessageDollarIdentity, this.IdentityToJson((AbstractIdentityBase)tmpValue));
                    continue;
                }


                if (tmpKuName == "by")
                {
                    throw new Exception("不支持系统库类传输");
                }

                tmpJsonValue.Add(tmpPropName, ObjToJson(tmpValue, tmpPropType));                
            }

            if (!tmpJsonValue.ContainsKey(MessageDollarIdentity))
            {
                tmpJsonValue.Add(MessageDollarIdentity, new NullValue());
            }

            return tmpJsonValue;
        }

        public byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue IdentityToJson(byForm_Server.ku.by.ToolClass.AbstractIdentityBase f_Identity)
        {
            JsonObject tmpJson = new JsonObject();
            if (this.ToJsonInstanceDic.ContainsKey(f_Identity))
            {
                string tmpRefValue = this.ToJsonInstanceDic[f_Identity];
                tmpJson.Add(MessageRef, JsonParser.Utils.GetNewStringClass(tmpRefValue));
                return tmpJson;
            }

            if (f_Identity == null)
            {
                return new NullValue();
            }
            tmpJson.Add(MessageParameterObjType, JsonParser.Utils.GetNewStringClass(MessageIdentity));
            tmpJson.Add(MessageID, JsonParser.Utils.GetNewStringClass(this.ToJsonInstanceDic.Count.ToString()));
            this.ToJsonInstanceDic.Add(f_Identity, this.ToJsonInstanceDic.Count.ToString());
            string tmpInstanceKu = f_Identity.ku;
            var tmpKu = ToolFunction.GetKu(tmpInstanceKu);
            if (!tmpKu.NewIdentityDicKeyIsId.ContainsKey(f_Identity))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.UnClearIdentity);
            }

            string tmpInstanceName = tmpKu.NewIdentityDicKeyIsId[f_Identity];
            if (tmpInstanceName.Contains("."))
            {
                //说明是一个字段里的
                if (!(f_Identity.to is Field))
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.NotFieldIdentity);
                }
                var tmpField = f_Identity.to as Field;
                string tmpSheetName = tmpField.SheetName;
                JsonObject tmpInstanceJson = new JsonObject();
                string tmpValue = tmpKu.Name + "." + tmpSheetName + "." + tmpField.Name;
                tmpInstanceJson.Add(MessageInner, new BoolValue(true));
                tmpInstanceJson.Add(MessageValue, JsonParser.Utils.GetNewStringClass(tmpValue));
                tmpJson.Add(MessageInstance, tmpInstanceJson);
                return tmpJson;
            }
            else
            {
                if (tmpInstanceName.StartsWith("New_"))
                {
                    //new里声明的
                    string tmpNewIdentityName = tmpInstanceName.Substring(4, tmpInstanceName.Length - 4);
                    JsonObject tmpInstance = new JsonObject();
                    tmpInstance.Add(MessageInner, new BoolValue(false));
                    tmpInstance.Add(MessageValue, JsonParser.Utils.GetNewStringClass(tmpKu.Name + "." + tmpNewIdentityName));
                    tmpJson.Add(MessageInstance, tmpInstance);
                    return tmpJson;
                }
                else if (tmpInstanceName.StartsWith("Local_"))
                {
                    //数据表声明
                    string tmpSheetName = tmpInstanceName.Substring(6, tmpInstanceName.Length - 6);
                    JsonObject tmpInstance = new JsonObject();
                    tmpInstance.Add(MessageInner, new BoolValue(true));
                    tmpInstance.Add(MessageValue, JsonParser.Utils.GetNewStringClass(tmpKu.Name + "." + tmpSheetName));
                    tmpJson.Add(MessageInstance, tmpInstance);
                    return tmpJson;
                }
                else
                {
                    throw ThrowHelper.ThrowParseTransferException(ErrorInfo.UnClearIdentity);
                }
            }
        }

        public byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject IListToJson(System.Type f_IListType, System.Object f_ArrayValue)
        {
            JsonObject tmpIListJson = new JsonObject();
            if (this.ToJsonInstanceDic.ContainsKey(f_ArrayValue))
            {
                string tmpRefValue = this.ToJsonInstanceDic[f_ArrayValue];
                tmpIListJson.Add(MessageRef, JsonParser.Utils.GetNewStringClass(tmpRefValue));
                return tmpIListJson;
            }

            var tmpIlist = f_ArrayValue as System.Collections.IList;

            if (tmpIlist == null)
            {
                ThrowHelper.ThrowSerializeException(string.Format(ErrorInfo.ObjectCantSerialized,f_ArrayValue.GetType().ToString(), "list"));
            }

            if (f_IListType.IsArray)
            {
                tmpIListJson.Add(MessageParameterObjType, JsonParser.Utils.GetNewStringClass(MessageArray));
            }
            else
            {
                tmpIListJson.Add(MessageParameterObjType, JsonParser.Utils.GetNewStringClass(MessageList));
            }

            Type tmpValueType = f_IListType.IsArray ? f_IListType.GetElementType() : f_IListType.GenericTypeArguments[0];
            ArrayClass tmpJson = new ArrayClass();
            
            tmpIListJson.Add(MessageID, JsonParser.Utils.GetNewStringClass(this.ToJsonInstanceDic.Count.ToString()));
            this.ToJsonInstanceDic.Add(f_ArrayValue, this.ToJsonInstanceDic.Count.ToString());
            foreach (var item in tmpIlist)
            {
                tmpJson.Add(ObjectToJsonInCollection(tmpValueType, item));
            }

            tmpIListJson.Add(MessageArrayValue, tmpJson);
            return tmpIListJson;
        }

        public byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject DictionaryToJson(System.Type f_IDictionaryType, object f_DictionaryValue)
        {
            JsonObject tmpIDictionaryJson = new JsonObject();
            if (this.ToJsonInstanceDic.ContainsKey(f_DictionaryValue))
            {
                string tmpRefValue = this.ToJsonInstanceDic[f_DictionaryValue];
                tmpIDictionaryJson.Add(MessageRef, JsonParser.Utils.GetNewStringClass(tmpRefValue));
                return tmpIDictionaryJson;
            }

            IDictionary tmpIDictionary = f_DictionaryValue as IDictionary;

            if (tmpIDictionary == null || f_IDictionaryType.GenericTypeArguments.Length != 2)
            {
                ThrowHelper.ThrowSerializeException(string.Format(ErrorInfo.ObjectCantSerialized, f_DictionaryValue.GetType().ToString(), "dictionary"));
            }

            tmpIDictionaryJson.Add(MessageParameterObjType, JsonParser.Utils.GetNewStringClass(MessageDictionary));
            var tmpKeyType = f_IDictionaryType.GenericTypeArguments[0];
            var tmpValueType = f_IDictionaryType.GenericTypeArguments[1];

            ArrayClass tmpKeyItems = new ArrayClass();
            ArrayClass tmpValueItems = new ArrayClass();

            tmpIDictionaryJson.Add(MessageID, JsonParser.Utils.GetNewStringClass(this.ToJsonInstanceDic.Count.ToString()));
            this.ToJsonInstanceDic.Add(f_DictionaryValue, this.ToJsonInstanceDic.Count.ToString());

            var tmpKeys = tmpIDictionary.Keys;
            var tmpValues = tmpIDictionary.Values;

            foreach (var item in tmpKeys)
            {
                tmpKeyItems.Add(ObjectToJsonInCollection(tmpKeyType, item));
            }

            foreach (var item in tmpValues)
            {
                tmpValueItems.Add(ObjectToJsonInCollection(tmpValueType, item));
            }

            tmpIDictionaryJson.Add(MessageKeys, tmpKeyItems);
            tmpIDictionaryJson.Add(MessageArrayValue, tmpValueItems);
            return tmpIDictionaryJson;
        }

        public byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue ObjectToJsonInCollection(System.Type f_CollectionType, object f_Value)
        {
            if (f_CollectionType == byteType || f_CollectionType == shortType || f_CollectionType == intType || f_CollectionType == doubleType || f_CollectionType == floatType)
            {
                if (f_CollectionType == doubleType)
                {
                    double tmpDoubleValue = (double)f_Value;
                    if (tmpDoubleValue == double.PositiveInfinity)
                    {
                        ThrowHelper.ThrowSerializeException(ErrorInfo.PositiveInfinity);
                    }
                }

                return new Num(f_Value.ToString());
            }

            if (f_CollectionType == boolType)
            {
                return new BoolValue(f_Value.ToString());
            }

            if (f_CollectionType == stringType || f_CollectionType == charType || f_CollectionType == longType || f_CollectionType == decimalType || f_CollectionType == dateTimeType)
            {
                return JsonParser.Utils.GetNewStringClass(f_Value.ToString());
            }

            if (f_CollectionType == typeof(DateTime))
            {
                ThrowHelper.ThrowSerializeException(ErrorInfo.RawDatetime);
            }

            return ObjToJson(f_Value, f_CollectionType);
        }

        public static byForm_Server.ku.by.ToolClass.JsonParser.Value.StringClass CellToJson(byForm_Server.ku.by.Object.Cell f_Cell)
        {
            //不存在ref
            if (f_Cell.field != null)
            {
                var tmpField = f_Cell.field.Field;
                string tmpFieldName = tmpField.KuName + "." + tmpField.SheetName + "." + tmpField.Name;
                StringBuilder tmpValue = new StringBuilder();
                if (f_Cell.AggregateFunctionName != null)
                {
                    tmpValue.Append(f_Cell.AggregateFunctionName.ToUpper());
                    tmpValue.Append("(");
                    tmpValue.Append(tmpFieldName);
                    tmpValue.Append(")");
                }
                else
                {
                    tmpValue.Append(tmpFieldName);
                }

                return new StringClass(tmpValue.ToString());
            }
            else
            {
                if (f_Cell.DataTypeEnum == DataTypeEnum.None)
                {
                    ThrowHelper.ThrowUnKnownException("cell数据类型未赋值");
                }
                string tmpFieldName;
                if (f_Cell.DataTypeEnum == DataTypeEnum.Enum)
                {
                    if (f_Cell.EnumType == null)
                    {
                        ThrowHelper.ThrowUnKnownException("cell数据枚举类型未赋值");
                    }

                    string tmpEnumFullName = f_Cell.EnumType.FullName;
                    var tmpEnumSplit = tmpEnumFullName.Split('.');
                    if (tmpEnumSplit.Length != 5)
                    {
                        ThrowHelper.ThrowUnKnownException("cell数据枚举类型错误");
                    }

                    string tmpEnumName = tmpEnumSplit[2] + "." + tmpEnumSplit[3] + "." + tmpEnumSplit[4];
                    tmpFieldName = "[" + tmpEnumName + "]";
                }
                else
                {
                    tmpFieldName = "[" + f_Cell.DataTypeEnum.ToString().ToLower() + "]";
                }
                
                if (f_Cell.Alias != null)
                {
                    tmpFieldName = tmpFieldName + f_Cell.Alias;
                }

                return new StringClass(tmpFieldName);
            }
        }

        private byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject RowToJson(byForm_Server.ku.by.Object.Row f_Row)
        {
            JsonObject tmpJson = new JsonObject();
            if (this.ToJsonInstanceDic.ContainsKey(f_Row))
            {
                string tmpRefValue = this.ToJsonInstanceDic[f_Row];
                tmpJson.Add(MessageRef, JsonParser.Utils.GetNewStringClass(tmpRefValue));
                return tmpJson;
            }

            tmpJson.Add(MessageParameterObjType, JsonParser.Utils.GetNewStringClass(MessageRow));
            tmpJson.Add(MessageID, JsonParser.Utils.GetNewStringClass(this.ToJsonInstanceDic.Count.ToString()));
            this.ToJsonInstanceDic.Add(f_Row, this.ToJsonInstanceDic.Count.ToString());
            string tmpSheetName = null;
            if (f_Row.Identity == null)
            {
                tmpJson.Add(MessageDollarIdentity, new NullValue());
            }
            else
            {
                var tmpDataSheet = f_Row.Identity.to as IBaseDataSheet;
                if (tmpDataSheet == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.NotTableIdentity);
                }
                tmpSheetName = tmpDataSheet.KuName + "." + tmpDataSheet.SheetName;
                tmpJson.Add(MessageDollarIdentity, this.IdentityToJson(f_Row.Identity));
            }

            //JsonObject tmpValueJson = new JsonObject();

            ArrayClass tmpFields = new ArrayClass();
            ArrayClass tmpValues = new ArrayClass();
            tmpJson.Add(MessageFields, tmpFields);
            tmpJson.Add(MessageValues, tmpValues);
            foreach (var cell in f_Row.cells)
            {
                var tmpValue = cell.value;
                tmpFields.Add(CellToJson(cell));

                if (tmpValue == null)
                {
                    tmpValues.Add(new NullValue());
                    continue;
                }

                if (tmpValue is sbyte || tmpValue is short || tmpValue is int || tmpValue is float || tmpValue is double)
                {
                    if (tmpValue is double)
                    {
                        double tmpDoubleValue = (double)tmpValue;
                        if (tmpDoubleValue == double.PositiveInfinity)
                        {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.PositiveInfinity);
                        }
                    }
                    tmpValues.Add(new Num(tmpValue.ToString()));
                    continue;
                }

                if (tmpValue is bool)
                {
                    tmpValues.Add(new BoolValue(tmpValue.ToString()));
                    continue;
                }

                if (tmpValue is string || tmpValue is char || tmpValue is decimal || tmpValue is long || tmpValue is ku.by.Object.datetime)
                {
                    tmpValues.Add(JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                    continue;
                }

                if (tmpValue is DateTime)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RawDatetime);
                }

                if (tmpValue.GetType().IsEnum)
                {
                    tmpValues.Add(JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                    continue;
                }

                //不确定枚举是否转为字符串加入
                ThrowHelper.ThrowParseTransferException(ErrorInfo.CellValueTypeError);
            }
            return tmpJson;
        }

        public byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject OrmToJson(byForm_Server.ku.by.Object.orm f_Orm)
        {
            JsonObject tmpJson = new JsonObject();
            if (this.ToJsonInstanceDic.ContainsKey(f_Orm))
            {
                string tmpRefValue = this.ToJsonInstanceDic[f_Orm];
                tmpJson.Add(MessageRef, JsonParser.Utils.GetNewStringClass(tmpRefValue));
                return tmpJson;
            }

            tmpJson.Add(MessageParameterObjType, new StringClass(MessageOrm));
            tmpJson.Add(MessageID, JsonParser.Utils.GetNewStringClass(this.ToJsonInstanceDic.Count.ToString()));
            this.ToJsonInstanceDic.Add(f_Orm, this.ToJsonInstanceDic.Count.ToString());
            var tmpOrmNameDic = Root.GetInstance().OrmNameDic;
            var tmpOrmType = f_Orm.GetType();

            if (!tmpOrmNameDic.ContainsKey(tmpOrmType))
            {
                ThrowHelper.ThrowUnKnownException("传输的orm类型查找失败");
            }

            string tmpOrmDecName = tmpOrmNameDic[tmpOrmType];
            tmpJson.Add(MessageType, new StringClass(tmpOrmDecName));

            if (f_Orm.Cells == null || f_Orm.Cells.count == 0)
            {
                tmpJson.Add(MessageFIELDSMAP, new NullValue());
            }
            else
            {
                JsonObject tmpFieldsMap = new JsonObject();
                var tmpOrmFieldList = f_Orm.GenerateFieldMap();

                foreach (var item in tmpOrmFieldList)
                {
                    tmpFieldsMap.Add(item.Name, new Num(item.OrmIndex.ToString()));
                }

                tmpJson.Add(MessageFIELDSMAP, tmpFieldsMap);
            }

            List<string> tmpAliasList = new List<string>();
            ArrayClass tmpCells = new ArrayClass();
            ArrayClass tmpValues = new ArrayClass();
            JsonObject tmpTableMaps = new JsonObject();
            List<AbstractIdentityBase> tmpList = new List<AbstractIdentityBase>();

            foreach (var item in tmpOrmType.GetProperties())
            {
                if (!item.Name.StartsWith("Table"))
                {
                    continue;
                }

                string tmpAlias = item.Name.Substring(5);
                tmpAliasList.Add(tmpAlias);
                var tmpRow = item.GetValue(f_Orm) as Object.Row;
                tmpList.Add(tmpRow.Identity);
            }

            foreach (var item in f_Orm.aliasMap)
            {
                string tmpAlias = item.value;

                if (tmpAliasList.Contains(tmpAlias))
                {
                    if (!tmpTableMaps.ContainsKey(tmpAlias))
                    {
                        tmpTableMaps.Add(tmpAlias, new ArrayClass());
                    }

                    (tmpTableMaps[tmpAlias] as ArrayClass).Add(new Num(item.key.ToString()));
                }
            }

            foreach (var item in f_Orm.Cells)
            {
                tmpCells.Add(CellToJson(item));
                var tmpValue = item.value;

                if (tmpValue == null)
                {
                    tmpValues.Add(new NullValue());
                    continue;
                }

                if (tmpValue is sbyte || tmpValue is short || tmpValue is int || tmpValue is float || tmpValue is double)
                {
                    if (tmpValue is double)
                    {
                        double tmpDoubleValue = (double)tmpValue;
                        if (tmpDoubleValue == double.PositiveInfinity)
                        {
                            ThrowHelper.ThrowParseTransferException(ErrorInfo.PositiveInfinity);
                        }
                    }
                    tmpValues.Add(new Num(tmpValue.ToString()));
                    continue;
                }

                if (tmpValue is bool)
                {
                    tmpValues.Add(new BoolValue(tmpValue.ToString()));
                    continue;
                }

                if (tmpValue is string || tmpValue is char || tmpValue is decimal || tmpValue is long || tmpValue is ku.by.Object.datetime)
                {
                    tmpValues.Add(JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                    continue;
                }

                if (tmpValue is DateTime)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.RawDatetime);
                }

                if (tmpValue.GetType().IsEnum)
                {
                    tmpValues.Add(JsonParser.Utils.GetNewStringClass(tmpValue.ToString()));
                    continue;
                }

                //不确定枚举是否转为字符串加入
                ThrowHelper.ThrowParseTransferException(ErrorInfo.CellValueTypeError);
            }

            tmpJson.Add(MessageFields, tmpCells);
            tmpJson.Add(MessageValues, tmpValues);
            tmpJson.Add(MessageTableFieldsMap, tmpTableMaps);
            ArrayClass tmpIdentityList = new ArrayClass();

            foreach (var item in tmpList)
            {
                tmpIdentityList.Add(IdentityToJson(item));
            }

            tmpJson.Add(MessageDollarIDentitys, tmpIdentityList);
            return tmpJson;
        }

        private bool IsAbstractIdentityBase(System.Type f_Type)
        {
            //目前对象属性类型不支持身份所以暂时用不到
            var tmpIdentityType = typeof(AbstractIdentityBase);
            var tmpParentType = f_Type.BaseType;
            while (tmpParentType != null)
            {
                if (tmpParentType == tmpIdentityType)
                {
                    return true;
                }
                tmpParentType = tmpParentType.BaseType;
            }
            return false;
        }

        private void ParseSource(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_SourceObj)
        {
            if (!f_SourceObj.ContainsKey(MessageSheetName))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSheetNameError);
            }

            var tmpSheetNameNode = f_SourceObj[MessageSheetName] as StringClass;
            var tmpSourceNameNode = f_SourceObj[MessageSourceName] as StringClass;
            var tmpPaNode = f_SourceObj[MessageParameters] as Num;

            if (tmpSheetNameNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSheetNameError);
            }

            if (tmpSourceNameNode == null && tmpPaNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRequestError);
            }

            if (tmpSourceNameNode != null)
            {
                var tmpSheetArray = tmpSheetNameNode.Value.Split('.');

                if (tmpSheetArray.Length != 2)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSourceError);
                }

                string tmpKuName = tmpSheetArray[0];
                string tmpSheetName = tmpSheetArray[1];
                string tmpSourceName = tmpSourceNameNode.Value;
                string tmpPath = string.Format("{0}.ku.{1}.Source.{2}", RootNameSpace, tmpKuName, tmpSheetName);
                Type tmpType = Type.GetType(tmpPath);
                var tmpMethod = tmpType.GetMethod(tmpSourceName);

                if (tmpMethod == null)
                {
                    ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseCanNotMatchintMethod, MessageSourceName));
                }

                var tmpSheet = ku.Root.GetInstance()[tmpKuName][tmpSheetName];

                if (!tmpSheet.SourceDic.ContainsKey(tmpSourceName))
                {
                    ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseCanNotFindSource, tmpSheetName, tmpSourceName));
                }

                var tmpSource = tmpSheet.SourceDic[tmpSourceName];
                string tmpSourceIndex = tmpKuName + "." + tmpSheetName + "." + tmpSourceName;

                if (ku.MethodNameStorage.SourceMethodNames.ContainsKey(tmpSourceIndex))
                {
                    serverSession.methodName = ku.MethodNameStorage.SourceMethodNames[tmpSourceIndex];
                }

                //this.AddSessionToDic();
                var tmpComeInResult = this.MethodBeforeInvoke();

                if (tmpComeInResult != null)
                {
                    if (!tmpComeInResult.isOk)
                    {
                        this.ComeInHasError = true;
                        this.ResponseValue = tmpComeInResult.info;
                        return;
                    }
                }

                object tmpResult;
                try
                {
                    tmpResult = tmpMethod.Invoke(null, new object[] { tmpSource.Parameters });
                }
                catch (System.Reflection.TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                    {
                        ThrowHelper.ThrowFuncException(ex.InnerException.Message);
                    }
                    throw ThrowHelper.ThrowUnKnownException(ex.Message);
                }
                //结果可能是数据库数据类型，枚举，前两个的集合
                if (tmpResult is System.Collections.IList)
                {
                    var tmpListResult = tmpResult as System.Collections.IList;
                    StringBuilder tmpValue = new StringBuilder("[");
                    foreach (var item in tmpListResult)
                    {
                        if (tmpValue.Length != 1)
                        {
                            tmpValue.Append(".:");
                        }
                        tmpValue.Append(item.ToString());
                    }
                    tmpValue.Append("]");
                    this.ResponseValue = tmpValue.ToString();
                    return;
                }

                if (tmpResult == null)
                {
                    this.ResponseValue = null;
                    return;
                }

                if (tmpResult is string || tmpResult is ku.by.Object.datetime || tmpResult is decimal || tmpResult is double)
                {
                    this.ResponseValue = "\"" + tmpResult.ToString() + "\"";
                    return;
                }

                this.ResponseValue = tmpResult.ToString();
                return;
            }
            else
            {
                throw ThrowHelper.ThrowParseTransferException("特殊数据源");
            }
        }

        public void ParseSkill(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_SkillObject)
        {
            if (!f_SkillObject.ContainsKey(MessageParameters))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }

            if (!f_SkillObject.ContainsKey(MessageTarget))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseInstanceNameError);
            }

            if (!f_SkillObject.ContainsKey(MessageNo))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            if (!f_SkillObject.ContainsKey(MessageKu))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
            }

            var tmpKuStringClass = f_SkillObject[MessageKu] as StringClass;
            var tmpParamsArray = f_SkillObject[MessageParameters] as ArrayClass;
            var tmpIdentity = f_SkillObject[MessageTarget];
            var tmpSkillNoStringClass = f_SkillObject[MessageNo] as StringClass;

            if (tmpParamsArray == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }

            if (tmpSkillNoStringClass == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            if (tmpKuStringClass == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
            }

            if (!(tmpIdentity is NullValue || tmpIdentity is JsonObject))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIdentityError);
            }

            string tmpSkillKuName = tmpKuStringClass.Value;
            string tmpSkillNo = tmpSkillNoStringClass.Value;
            string tmpSkillIndexPath = string.Format("{0}.ku.{1}.Skill.SkillIndex", this.RootNameSpace, tmpSkillKuName);
            string tmpStorageIndex = tmpSkillKuName + "." + tmpSkillNo;
            if (!ku.MethodNameStorage.SkillNames.ContainsKey(tmpStorageIndex))
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.SkillNameIndexBug, tmpStorageIndex));
            }
            string tmpMethodName = ku.MethodNameStorage.SkillNames[tmpStorageIndex];
            var tmpMethodNameArray = tmpMethodName.Split('.');
            if (tmpMethodNameArray.Length != 4)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.SkillNameValueBug, tmpMethodName));
            }
            string tmpIdentityName = tmpMethodNameArray[0] + "." + tmpMethodNameArray[2];
            //先填充session
            serverSession.identityName = tmpIdentityName;
            serverSession.methodName = tmpMethodName;
            Type tmpSkillIndexType = Type.GetType(tmpSkillIndexPath);
            var tmpMethod = tmpSkillIndexType.GetMethod("_" + tmpSkillNo);
            if (tmpMethod == null)
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.ParseCanNotMatchintMethod, tmpSkillNo));
            }
            //this.AddSessionToDic();
            var tmpComeInResult = this.MethodBeforeInvoke();
            if (tmpComeInResult != null)
            {
                if (!tmpComeInResult.isOk)
                {
                    this.ComeInHasError = true;
                    this.ResponseValue = tmpComeInResult.info;
                    return;
                }
            }

            if (tmpIdentity is NullValue)
            {
                //说明是静态方法
                object[] tmpSkillParams = new object[] { this, null, tmpParamsArray };
                this.ResponseValue = Response.FuncResponse(this, tmpMethod, null, tmpSkillParams);
                return;
            }
            else
            {
                var tmpIdentityNode = tmpIdentity as JsonObject;
                var tmpIdentityInstance = ParseIdentity(tmpIdentityNode);
                object[] tmpSkillParams = new object[] { this, tmpIdentityInstance, tmpParamsArray };
                this.ResponseValue = Response.FuncResponse(this, tmpMethod, tmpIdentityInstance, tmpSkillParams);
                return;
            }
        }

        private byForm_Server.ku.by.ToolClass.Sql.ParamsPackage FillSqlParams(byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_Obj)
        {
            if (!f_Obj.ContainsKey(MessageKu))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
            }

            if (!f_Obj.ContainsKey(MessageValue))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsValueError);
            }

            var tmpKuNode = f_Obj[MessageKu] as StringClass;
            var tmpSqlValue = f_Obj[MessageValue] as JsonObject;

            if (tmpKuNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseKuNameError);
            }

            if (tmpSqlValue == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsValueError);
            }

            string tmpKuName = tmpKuNode.Value;
            List<object> tmpParams = new List<object>();
            return (Sql.ParamsPackage)this.ParseSqlValue(tmpKuName, tmpSqlValue, tmpParams, false, null);
        }

        private object ParseSqlValue(string f_KuName, byForm_Server.ku.by.ToolClass.JsonParser.Value.JsonObject f_SqlValue, object f_ParamsList, bool f_IsExist, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables)
        {
            if (!f_SqlValue.ContainsKey(MessageFrom))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
            }

            if (!f_SqlValue.ContainsKey(MessageParameters))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }

            if (!f_SqlValue.ContainsKey(MessageNo))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            if (f_SqlValue.ContainsKey(MessageParameterObjType))
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseIlleagalJsonObj);
            }

            List<object> tmpParamsList = new List<object>();
            var tmpFromArray = f_SqlValue[MessageFrom] as ArrayClass;
            var tmpParameterNode = f_SqlValue[MessageParameters] as ArrayClass;
            var tmpSqlNo = f_SqlValue[MessageNo] as StringClass;

            if (tmpFromArray == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseFromError);
            }

            if (tmpParameterNode == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsError);
            }

            if (tmpSqlNo == null)
            {
                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseNoError);
            }

            string tmpNO = tmpSqlNo.Value;
            string tmpStorageIndex = string.Format("{0}.{1}", f_KuName, tmpNO); 
            if (!MethodNameStorage.SqlNames.ContainsKey(tmpStorageIndex))
            {
                ThrowHelper.ThrowParseTransferException(string.Format(ErrorInfo.SqlNameIndexBug, tmpStorageIndex));
            }
            serverSession.methodName = MethodNameStorage.SqlNames[tmpStorageIndex];
            //this.AddSessionToDic();
            var tmpComeInResult = this.MethodBeforeInvoke();
            if (tmpComeInResult != null)
            {
                if (!tmpComeInResult.isOk)
                {
                    this.ComeInHasError = true;
                    this.ResponseValue = tmpComeInResult.info;
                    return null;
                }
            }
            string tmpTypePath = string.Format("{0}.ku.{1}.SqlExpression.sql", this.RootNameSpace, f_KuName);
            string tmpMethod = string.Format("_{0}", tmpNO);

            //填充source
            List<Sql.AbstractTable> tmpTableList = new List<Sql.AbstractTable>();
            foreach (var item in tmpFromArray.ValueList)
            {
                var tmpTableObj = item as JsonObject;

                if (tmpTableObj == null)
                {
                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseQueryMessageError);
                }

                ParseTableSource(tmpTableObj, f_KuName, tmpTableList, tmpParamsList);
            }
            if (f_IsExist)
            {
                foreach (var item in f_Tables)
                {
                    tmpTableList.Add(item.Copy());
                }
            }
            this.GenerateParameterList(tmpParameterNode.ValueList, tmpParamsList, f_KuName, tmpTableList);
            if (f_IsExist)
            {
                //string tmpMethodPath = tmpTypePath + "." + tmpMethod;
                Type tmpSqlType = Type.GetType(tmpTypePath);
                //由于是select，不可能存在同名方法
                var tmpReflectMethd = tmpSqlType.GetMethod(tmpMethod);
                var tmpParameterPackge = new Sql.ParamsPackage(tmpTypePath, tmpMethod, tmpTableList, tmpParamsList, tmpNO);
                return tmpReflectMethd.Invoke(null, new object[] { tmpParameterPackge });
            }
            else
            {
                return new Sql.ParamsPackage(tmpTypePath, tmpMethod, tmpTableList, tmpParamsList, tmpNO);
            }
        }

        private void GenerateParameterList(System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.JsonParser.Value.AbstractValue> f_JsonValue, System.Collections.Generic.List<object> f_Parames, string f_KuName, System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.Sql.AbstractTable> f_Tables)
        {
            var tmpParamsList = f_Parames;
            foreach (var item in f_JsonValue)
            {
                if (item is Num)
                {
                    var tmpValue = item as Num;
                    tmpParamsList.Add(tmpValue.ToString());
                    continue;
                }

                if (item is StringClass)
                {
                    var tmpValue = item as StringClass;
                    tmpParamsList.Add(tmpValue.Value);
                    continue;
                }

                if (item is NullValue)
                {
                    tmpParamsList.Add(null);
                    continue;
                }

                if (item is JsonObject)
                {
                    var tmpValue = item as JsonObject;

                   /*if (!tmpValue.ContainsKey(MessageParameterObjType))
                    {
                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSqlParamTypeError);
                    }*/

                    var tmpObjType = tmpValue[MessageParameterObjType] as StringClass;
                    if (tmpObjType == null)
                    {
                        //有可能是ref
                        if (tmpValue.ContainsKey(MessageRef))
                        {
                            var tmpRefId = tmpValue[MessageRef] as StringClass;
                            if (tmpRefId == null)
                            {
                                ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseRefError);
                            }

                            string tmpRefValue = tmpRefId.Value;
                            if (!InstanceDic.ContainsKey(tmpRefValue))
                            {
                                ThrowHelper.ThrowParseTransferException(ErrorInfo.RefCanNotFind);
                            }

                            tmpParamsList.Add(InstanceDic[tmpRefValue]);
                            continue;
                        }

                        if (this.ResponseType == RequestTypeEnum.SQL || this.ResponseType == RequestTypeEnum.TRAN)
                        {
                            //说明是sql参数,暂时特殊处理，错误处理应该不完善,
                            List<Sql.AbstractTable> tmpTablesCopy = new List<Sql.AbstractTable>();
                            tmpTablesCopy.AddRange(f_Tables);
                            tmpParamsList.Add(this.ParseSqlValue(f_KuName, tmpValue, new List<object>(), true, tmpTablesCopy));
                            continue;
                        }

                        ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseParamsTypeError);
                    }
                    string tmpTypeValue = tmpObjType.Value;

                    if (tmpTypeValue == MessageArray)
                    {
                        //只可能是行集合
                        Type tmpType = typeof(Object.Row[]);
                        tmpParamsList.Add(this.ParseArray(tmpType, tmpValue));
                        continue;
                    }

                    if (tmpTypeValue == MessageList)
                    {
                        Type tmpType = typeof(Object.list<Object.Row>);
                        tmpParamsList.Add(this.ParseList(tmpType, tmpValue));
                        continue;
                    }

                    if (tmpTypeValue == MessageRow)
                    {
                        tmpParamsList.Add(ParseRow(tmpValue));
                        continue;
                    }

                    if (tmpTypeValue == MessageTableSql)
                    {
                        //说明是exist里面的sql
                        List<Sql.AbstractTable> tmpTablesCopy = new List<Sql.AbstractTable>();
                        tmpTablesCopy.AddRange(f_Tables);
                        tmpParamsList.Add(this.ParseSqlValue(f_KuName, tmpValue, new List<object>(), true, tmpTablesCopy));
                        continue;
                    }
 
                    if (tmpTypeValue == MessageQuery)
                    {
                        tmpParamsList.Add(ParseQueryDataValue(tmpValue));
                        continue;
                    }

                    ThrowHelper.ThrowParseTransferException(ErrorInfo.ParseSqlParamTypeError + tmpTypeValue);
                }

                //不存在单数组情况
                //if (item is ArrayClass)
                //{
                //    //行实例集合
                //    var tmpValue = item as ArrayClass;
                //    tmpParamsList.Add(this.ParseRows(tmpValue));
                //}

                if (item is BoolValue)
                {
                    var tmpValue = item as BoolValue;
                    tmpParamsList.Add(tmpValue.Value ? "1 = 1" : "1 = 0");
                }
            }
        }

        private string FirstCharacterToUpper(string f_Value)
        {
            if (f_Value == null)
            {
                return null;
            }

            if (f_Value.Length == 0)
            {
                return "";
            }

            char[] tmpNewValue = f_Value.ToCharArray();
            var tmpFirstChar = f_Value[0];

            if ('a' <= tmpFirstChar && tmpFirstChar <= 'z')
            {
                tmpFirstChar = (char)(tmpFirstChar & ~0x20);
            }

            tmpNewValue[0] = tmpFirstChar;
            return new string(tmpNewValue);
        }

        private byForm_Server.ku.by.Object.Result MethodBeforeInvoke()
        {
            if (ku.by.Identity.Server.mIDoor != null)
            {
                return Identity.Server.mIDoor.comeIn(Object.ServerSession.getCurrentSession());
            }
            else
            {
                return null;
            }
        }
    }
}
