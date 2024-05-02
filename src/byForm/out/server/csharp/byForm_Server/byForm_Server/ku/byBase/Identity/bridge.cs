using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class bridge : byForm_Server.ku.byBase.Identity.TableSafe, byForm_Server.ku.byInterface.Identity.IBy
    {
        public bridge()
        {
            this.add += Body_add;
            this.change += Body_change;
            this.delete += Body_delete;
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Reference iLeft { get; set; }

        public byForm_Server.ku.by.Identity.Reference iRight { get; set; }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> load(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_selectRowList, byForm_Server.ku.by.Enum.MouseButton f_leftRight)
        {
            {
                if (f_leftRight == byForm_Server.ku.by.Enum.MouseButton.left)
                {
                    return (byForm_Server.ku.byBase.SqlExpression.LocalSql._12(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_selectRowList })).rows;
                }
                else
                {
                    return (byForm_Server.ku.byBase.SqlExpression.LocalSql._13(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_selectRowList })).rows;
                }
            }
        }

        public void addDeleteUpdate(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_addList, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_deleteList)
        {
            {
                try
                {
                    System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                    System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                    System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                    _objList_.Add(new object[] { f_addList });
                    _tmpIdentityList_.Add(null);
                    _objList_.Add(new object[] { f_deleteList });
                    _tmpIdentityList_.Add(null);
                    SqlExpression.LocalSql.Tran_3(_tmpIdentityList_.ToArray(), _objList_, _values_);
                }
                catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                {
                    string message = thisiscsharpserverxclusiveexceptionidentifier.Message;
                }
            }
        }

        public event byForm_Server.ku.by.Action.Action.Delegate_2<byForm_Server.ku.byBase.Identity.bridge, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.Result> add;

        public byForm_Server.ku.by.Object.Result Body_add(byForm_Server.ku.byBase.Identity.bridge f_ThisReference, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_bridgeRowList)
        {
            if (!this.confirmUserIsLogin())
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login() };
            }
            byForm_Server.ku.by.Object.Result tmpResult = new byForm_Server.ku.by.Object.Result();
            tmpResult.isOk = true;
            foreach (byForm_Server.ku.by.Object.Row item in f_bridgeRowList)
            {
                if (System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value) == null || System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value) == "")
                {
                    byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(item, "iID", byForm_Server.ku.byCommon.Identity.general.getGuid(), "=");
                }
            }
            int tmpListCount = f_bridgeRowList.count;
            try
            {
                System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                _values_.Add(tmpListCount);
                System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                _objList_.Add(new object[] { f_bridgeRowList });
                _tmpIdentityList_.Add(null);
                SqlExpression.LocalSql.Tran_4(_tmpIdentityList_.ToArray(), _objList_, _values_);
            }
            catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
            {
                string errorInfo = thisiscsharpserverxclusiveexceptionidentifier.Message;
                tmpResult.isOk = false;
                tmpResult.info = errorInfo;
            }
            return tmpResult;
        }

        public byForm_Server.ku.by.Object.Result Execute_add(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_bridgeRowList)
        {
            return this.add(this, f_bridgeRowList);
        }

        public event byForm_Server.ku.by.Action.Action.Delegate_3<byForm_Server.ku.byBase.Identity.bridge, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.Result> change;

        public byForm_Server.ku.by.Object.Result Body_change(byForm_Server.ku.byBase.Identity.bridge f_ThisReference, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_bridgeAddList, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_bridgeDeleteList)
        {
            if (!this.confirmUserIsLogin())
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login() };
            }
            byForm_Server.ku.by.Object.Result tmpResult = new byForm_Server.ku.by.Object.Result();
            tmpResult.isOk = true;
            if (f_bridgeAddList.count > 0 || f_bridgeDeleteList.count > 0)
            {
                foreach (byForm_Server.ku.by.Object.Row item in f_bridgeAddList)
                {
                    if (System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value) == null || System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(item, "iID").value) == "")
                    {
                        byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(item, "iID", byForm_Server.ku.byCommon.Identity.general.getGuid(), "=");
                    }
                }
                try
                {
                    System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                    System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                    System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                    _objList_.Add(new object[] { f_bridgeAddList });
                    _tmpIdentityList_.Add(null);
                    _objList_.Add(new object[] { f_bridgeDeleteList });
                    _tmpIdentityList_.Add(null);
                    SqlExpression.LocalSql.Tran_5(_tmpIdentityList_.ToArray(), _objList_, _values_);
                }
                catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                {
                    string message = thisiscsharpserverxclusiveexceptionidentifier.Message;
                    tmpResult.isOk = false;
                    tmpResult.info = message;
                }
            }
            return tmpResult;
        }

        public byForm_Server.ku.by.Object.Result Execute_change(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_bridgeAddList, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_bridgeDeleteList)
        {
            return this.change(this, f_bridgeAddList, f_bridgeDeleteList);
        }

        public event byForm_Server.ku.by.Action.Action.Delegate_2<byForm_Server.ku.byBase.Identity.bridge, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.Result> delete;

        public byForm_Server.ku.by.Object.Result Body_delete(byForm_Server.ku.byBase.Identity.bridge f_ThisReference, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_bridgeRowList)
        {
            if (!this.confirmUserIsLogin())
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login() };
            }
            byForm_Server.ku.by.Object.Result tmpResult = new byForm_Server.ku.by.Object.Result();
            tmpResult.isOk = true;
            try
            {
                byForm_Server.ku.byBase.SqlExpression.LocalSql._19(new object[] { f_bridgeRowList, f_bridgeRowList });
            }
            catch (System.Exception e)
            {
                tmpResult.isOk = false;
                tmpResult.info = e.Message;
            }
            return tmpResult;
        }

        public byForm_Server.ku.by.Object.Result Execute_delete(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_bridgeRowList)
        {
            return this.delete(this, f_bridgeRowList);
        }
    }
}
