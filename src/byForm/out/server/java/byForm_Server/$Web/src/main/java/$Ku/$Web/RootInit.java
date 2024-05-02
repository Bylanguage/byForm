package $Ku.$Web;

import $Ku.by.ToolClass.*;
import java.util.Hashtable;
public class RootInit {
    public static boolean initialized = false;

    public static void ClassMessageInit() {
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.IOrmType.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(Class.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.AbstractOrm.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ByObject.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Orm.Orm0.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Orm.OrmType0.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Orm.Orm0.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Orm.OrmType0.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Orm.Orm1.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Orm.OrmType1.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Orm.TemporaryOrm$0.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Orm.TemporaryOrm$1.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternal.httpWebRequest.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternal.encoders.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternal.random.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternal.hardware.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternal.security.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternal.UUID.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternal.mail.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternal.snowflake.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byFormNew.Identity.ServerStartup.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(byExternalSMS.feige.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byExternalSMS.Object.feigeSend.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byWebCommon.Identity.webCommon.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byExternalChartjs.Enum.chartTypeRange.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byExternalChartjs.Enum.chartType.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byExternalChartjs.Object.RGBA.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byExternalChartjs.Object.color.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byExternalChartjs.Object.RGB.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.catalog.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.TableSafe.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.popupTable.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.Tree.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.bridge.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.extend.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.detail.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.cloud.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Identity.dic.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Enum.sort.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Enum.ButtonState.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byBase.Object.ByBaseStrings.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Name.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Reference.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Menu.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Table.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Attribute.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.NO.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Identity.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Sys.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Server.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.IServerDoor.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Role.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.ID.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Identity.Field.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.DragDropEffects.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.ImageSizeMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.SceneType.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.CursorStyle.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.DockStyle.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.DateTimeStyle.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.RegexMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.ToolBarItemDisplayStyle.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.DialogManagerMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.DayOfWeek.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.TableType.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.Action.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Enum.MouseButton.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Table.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Cell.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ByException.CastException.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Float.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ReadOnlyList.class, 1);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Queue.class, 1);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.HashSet.class, 1);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ServerCallInfo.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ServerSession.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Integer.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ByException.IndexOutOfRangeException.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Stack.class, 1);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Exception.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Encoding.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Double.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.EventArgs.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Dictionary.class, 2);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Directory.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Object.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ByException.StackOverflowException.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ByException.NullReferenceException.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Short.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.List.class, 1);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.KeyValue.class, 2);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Boolean.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Byte.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.AbstractOrm.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.String.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Character.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Row.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.Long.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.TimeoutEventArgs.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add(java.lang.StringBuilder.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Decimal.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Field.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Result.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.File.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Datetime.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.QueryData.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.ByException.KeyNotFoundException.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Timer.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Ku.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.Math.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.by.Object.System.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Identity.userUpload.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Identity.user.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Identity.userICO.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Identity.anonymous.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Identity.userAdmin.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Enum.confirmUserIsLoginMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Enum.rank.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Enum.safetyCodeMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Enum.uploadMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Enum.adminMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Enum.verifyMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Enum.cer.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Object.resultUser.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byUser.Object.ByUserStrings.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byLog.Identity.log.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byLog.Enum.logMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byLog.Enum.logState.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byInterface.Identity.IBy.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byInterface.Enum.curdAction.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Identity.formField.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Identity.formSys.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Identity.formTemplate.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Identity.formData.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Identity.form.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Identity.fieldTemplate.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Enum.ctrType.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Enum.DraggingItemType.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Enum.memberMode.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Object.ValueHelper.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Object.TextHelper.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Object.CssClassNameHelper.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byForm.Object.NameHelper.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Identity.session.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Identity.relatedTable.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Identity.general.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Identity.relatedField.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Object.like.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Object.ByCommonStrings.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Object.convert.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Object.timeSlot.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Object.verifyReg.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Object.verifyRequest.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.add($Ku.byCommon.Object.verifyRowIdentity.class, 0);
        $Ku.by.ToolClass.$ClassMessageUtil.init();
    }

    public static void Init($Ku.by.ToolClass.Root root) {
        if(!initialized){
            try {
                Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            } catch (java.lang.Exception e) {
                throw new RuntimeException(e.getMessage());
            }
            ClassMessageInit();
            initialized = true;
        }
        else{
            return;
        }
        root.OrmTypeDic.put("byBase.bridge.myOrm", new $Ku.by.Object.KeyValue<>($Ku.by.ToolClass.$ClassMessageUtil.get(Class.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.IOrmType.class), $Ku.byBase.Orm.Orm0.class, new $Ku.byBase.Orm.OrmType0()));
        root.OrmTypeDic.put("byUser.user.userOrm", new $Ku.by.Object.KeyValue<>($Ku.by.ToolClass.$ClassMessageUtil.get(Class.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.IOrmType.class), $Ku.byUser.Orm.Orm0.class, new $Ku.byUser.Orm.OrmType0()));
        root.OrmTypeDic.put("byUser.userAdmin.adminOrm", new $Ku.by.Object.KeyValue<>($Ku.by.ToolClass.$ClassMessageUtil.get(Class.class), $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.IOrmType.class), $Ku.byUser.Orm.Orm1.class, new $Ku.byUser.Orm.OrmType1()));
        root.OrmNameDic.put($Ku.byBase.Orm.Orm0.class, "byBase.bridge.myOrm");
        root.OrmNameDic.put($Ku.byUser.Orm.Orm0.class, "byUser.user.userOrm");
        root.OrmNameDic.put($Ku.byUser.Orm.Orm1.class, "byUser.userAdmin.adminOrm");
        root.KuDic.put("byExternal", new $Ku.byExternal.byExternal());
        root.KuDic.put("byFormNew", new $Ku.byFormNew.byFormNew());
        root.KuDic.put("byExternalSMS", new $Ku.byExternalSMS.byExternalSMS());
        root.KuDic.put("byWebCommon", new $Ku.byWebCommon.byWebCommon());
        root.KuDic.put("byExternalChartjs", new $Ku.byExternalChartjs.byExternalChartjs());
        root.KuDic.put("byBase", new $Ku.byBase.byBase());
        root.KuDic.put("by", new $Ku.by.by());
        root.KuDic.put("byUser", new $Ku.byUser.byUser());
        root.KuDic.put("byLog", new $Ku.byLog.byLog());
        root.KuDic.put("byInterface", new $Ku.byInterface.byInterface());
        root.KuDic.put("byForm", new $Ku.byForm.byForm());
        root.ExecSqlNameDic.put("byForm.0", new java.util.HashMap<>());
        root.ExecSqlNameDic.get("byForm.0").put("byForm.12","select1");
        root.ExecSqlNameDic.get("byForm.0").put("byForm.13","select2");
        root.ExecSqlNameDic.put("byForm.1", new java.util.HashMap<>());
        root.ExecSqlNameDic.get("byForm.1").put("byForm.14","select1");
        root.ExecSqlNameDic.get("byForm.1").put("byForm.15","select2");
        root.ExecSqlNameDic.put("byForm.2", new java.util.HashMap<>());
        root.ExecSqlNameDic.get("byForm.2").put("byForm.16","select1");
        root.ExecSqlNameDic.get("byForm.2").put("byForm.17","select2");
        root.ExecSqlNameDic.get("byForm.2").put("byForm.18","select3");
        root.ExecSqlNameDic.get("byForm.2").put("byForm.19","select4");
        root.KuDic.put("byCommon", new $Ku.byCommon.byCommon());
        for(BaseKu item : root.KuDic.values()){
            for (AbstractIdentityBase tmpIdentity : item.NewIdentityDic.values()){
                tmpIdentity.$setProps();
            }
        }
        
        root.ObjProDicKeyTypeDic.put($Ku.byCommon.Object.like.class, new java.util.LinkedHashMap<>());
        root.ObjProDicKeyTypeDic.get($Ku.byCommon.Object.like.class).put("pDic", $Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class));
        root.ObjProDicValueTypeDic.put($Ku.byCommon.Object.like.class, new java.util.LinkedHashMap<>());
        root.ObjProDicValueTypeDic.get($Ku.byCommon.Object.like.class).put("pDic", $Ku.by.ToolClass.$ClassMessageUtil.get($Ku.by.Object.List.class).addTypeArgument(0, $Ku.by.ToolClass.$ClassMessageUtil.get(java.lang.String.class)));
        root.KuTypeDic.put("byFormNew", DBTypeEnum.SqlServer);
        root.KuConnectDic.put("byFormNew", "byFormNew");
        root.KuTypeDic.put("byUser", DBTypeEnum.SqlServer);
        root.KuDic.get("byUser").setDatabaseName("buUserTest");
        root.KuConnectDic.put("byUser", "byUser");
        MethodNameStorage storage = new MethodNameStorage();
    }

    public static void assembleComponent($Ku.by.ToolClass.Root root) {
        for(BaseKu ku : root.KuDic.values()){
            for(IBaseDataSheet dataSheet : ku.DataSheetDic.values()){
                dataSheet.assembleFieldReference();
            }
        }
        (($Ku.byFormNew.byFormNew)root.KuDic.get("byFormNew")).fillIdentityComponent();
    }
}
