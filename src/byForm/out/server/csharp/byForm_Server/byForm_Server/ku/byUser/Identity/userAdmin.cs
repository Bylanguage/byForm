using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byUser.Identity
{
    public class userAdmin : byForm_Server.ku.by.Identity.Table
    {
        public userAdmin()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
            pAdminDic = new byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.Row>();
            pFirstRun = false;
        }

        private byForm_Server.ku.by.Object.dictionary<string, byForm_Server.ku.by.Object.Row> pAdminDic { get; set; }

        public bool pFirstRun { get; set; }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iUserMode { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iDt { get; set; }

        public byForm_Server.ku.byUser.Identity.user rUser { get; set; }

        public byForm_Server.ku.by.Object.Row getAdmin(string f_userID)
        {
            if (this.pAdminDic.count == 0)
            {
                byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpAdminList = (byForm_Server.ku.byUser.SqlExpression.LocalSql._32(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { })).rows;
                foreach (byForm_Server.ku.by.Object.Row item in tmpAdminList)
                {
                    this.pAdminDic.add(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value), item);
                }
            }
            if (!this.pAdminDic.containsKey(byForm_Server.ku.by.Object.ServerSession.getCurrentSession().Cookie))
            {
                return null;
            }
            return this.pAdminDic.containsKey(f_userID) ? this.pAdminDic[f_userID] : null;
        }

        public bool isAdmin()
        {
            return this.getAdmin(byForm_Server.ku.by.Object.ServerSession.getCurrentSession().Cookie) == null ? false : true;
        }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.byUser.Orm.Orm1> getAdmin_()
        {
            if (!this.isAdmin())
            {
                return null;
            }
            {
                byForm_Server.ku.by.Object.list<byForm_Server.ku.byUser.Orm.Orm1> tmpList = (byForm_Server.ku.byUser.SqlExpression.LocalSql._33(new byForm_Server.ku.by.ToolClass.ITableSource[] { this, (byForm_Server.ku.byUser.Identity.user)byForm_Server.ku.Root.GetInstance()["byUser"].NewIdentityDic["New_user"] }, new object[] { })).rows;
                foreach (byForm_Server.ku.byUser.Orm.Orm1 item in tmpList)
                {
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString((item as byForm_Server.ku.byUser.Orm.Orm1).Tablea, "iID", this.rUser.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent((item as byForm_Server.ku.byUser.Orm.Orm1).Tablea, "iID").value)), "=");
                    (item as byForm_Server.ku.byUser.Orm.Orm1).Member2 = this.rUser.rsaEncode((item as byForm_Server.ku.byUser.Orm.Orm1).Member2);
                    (item as byForm_Server.ku.byUser.Orm.Orm1).Member3 = this.rUser.rsaEncode((item as byForm_Server.ku.byUser.Orm.Orm1).Member3);
                    (item as byForm_Server.ku.byUser.Orm.Orm1).Member1 = this.rUser.rsaEncode((item as byForm_Server.ku.byUser.Orm.Orm1).Member3);
                }
                return tmpList;
            }
        }

        public byForm_Server.ku.by.Object.Result adminAddRemove(byForm_Server.ku.by.Object.Row f_adminRow, byForm_Server.ku.by.Enum.Action f_action)
        {
            if (f_action != byForm_Server.ku.by.Enum.Action.delete && f_action != byForm_Server.ku.by.Enum.Action.insert)
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Operation_Limited() };
            }
            if (!this.isAdmin())
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byUser.Object.ByUserStrings.Info_Operation_Forbidden_Must_Be_Admin() };
            }
            {
                byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_adminRow, "iID", this.rUser.rsaDecode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_adminRow, "iID").value)), "=");
                byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_adminRow, "iDt").value = byForm_Server.ku.by.Object.datetime.getNow();
                byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_adminRow, "iUserMode").value = byForm_Server.ku.byUser.Enum.adminMode.general;
                try
                {
                    if (f_action == byForm_Server.ku.by.Enum.Action.delete)
                    {
                        byForm_Server.ku.byUser.SqlExpression.LocalSql._34(new object[] { f_adminRow });
                    }
                    else
                    {
                        if (f_action == byForm_Server.ku.by.Enum.Action.insert)
                        {
                            byForm_Server.ku.byUser.SqlExpression.LocalSql._35(new object[] { f_adminRow, f_adminRow });
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    return new byForm_Server.ku.by.Object.Result() { info = ex.Message };
                }
                return new byForm_Server.ku.by.Object.Result() { isOk = true };
            }
        }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> getPopupUser(string f_keyword)
        {
            if (!this.isAdmin())
            {
                return null;
            }
            {
                byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpList = default(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>);
                if (f_keyword != null && f_keyword != "")
                {
                    tmpList = (byForm_Server.ku.byUser.SqlExpression.LocalSql._36(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rUser }, new object[] { f_keyword, f_keyword, f_keyword, f_keyword, f_keyword })).rows;
                }
                else
                {
                    tmpList = (byForm_Server.ku.byUser.SqlExpression.LocalSql._37(new byForm_Server.ku.by.ToolClass.ITableSource[] { this.rUser }, new object[] { })).rows;
                }
                foreach (byForm_Server.ku.by.Object.Row item in tmpList)
                {
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(item, "iID", this.rUser.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value)), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(item, "iName", this.rUser.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iName").value)), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(item, "iDisplayName", this.rUser.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iDisplayName").value)), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(item, "iMobile", this.rUser.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iMobile").value)), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(item, "iMail", this.rUser.rsaEncode(System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iMail").value)), "=");
                }
                return tmpList;
            }
        }

        public bool isFirstRun()
        {
            {
                if (this.pFirstRun)
                {
                    this.pFirstRun = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void initInsertAdmin()
        {
            byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.TemporaryOrm0> tmpAdmin = byForm_Server.ku.byUser.SqlExpression.LocalSql._38(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { });
            if ((tmpAdmin.rows[0] as byForm_Server.ku.byUser.Orm.TemporaryOrm0).Member0 == 0)
            {
                byForm_Server.ku.by.ToolClass.OrmResult<byForm_Server.ku.byUser.Orm.TemporaryOrm1> tmpUserList = byForm_Server.ku.byUser.SqlExpression.LocalSql._39(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { });
                if ((tmpUserList.rows[0] as byForm_Server.ku.byUser.Orm.TemporaryOrm1).Member0 == 0)
                {
                    byForm_Server.ku.by.Object.Row tmpUserRow = new byForm_Server.ku.by.Object.Row() { _InitIdentity_ = this.rUser };
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserRow, "iDisplayName", "admin", "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iFreeze").value = false;
                    byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRank").value = byForm_Server.ku.byUser.Enum.rank.vip;
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserRow, "iID", byForm_Server.ku.byCommon.Identity.general.getGuid(), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserRow, "iName", "admin", "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserRow, "iPassword", this.rUser.md5Plus("admin123"), "=");
                    byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRegDt").value = byForm_Server.ku.by.Object.datetime.getNow();
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpUserRow, "iRemark", "系统初始化自动生成", "=");
                    byForm_Server.ku.by.Object.Row tmpAdminRow = new byForm_Server.ku.by.Object.Row() { _InitIdentity_ = this };
                    byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAdminRow, "iUserMode").value = byForm_Server.ku.byUser.Enum.adminMode.general;
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpAdminRow, "iID", System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iID").value), "=");
                    ;
                    byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpAdminRow, "iDt").value = byForm_Server.ku.by.Object.datetime.ConvertToDatetime(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpUserRow, "iRegDt").value);
                    try
                    {
                        System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                        System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                        System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                        _objList_.Add(new object[] { tmpUserRow });
                        _tmpIdentityList_.Add(null);
                        _objList_.Add(new object[] { tmpAdminRow });
                        _tmpIdentityList_.Add(null);
                        SqlExpression.LocalSql.Tran_4(_tmpIdentityList_.ToArray(), _objList_, _values_);
                    }
                    catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                    {
                        string message = thisiscsharpserverxclusiveexceptionidentifier.Message;
                        throw new System.Exception("初始inset 管理员数据时出错" + message);
                    }
                    this.pFirstRun = true;
                }
            }
        }
    }
}
