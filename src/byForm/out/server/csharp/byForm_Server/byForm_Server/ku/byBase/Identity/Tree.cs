using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class Tree : byForm_Server.ku.byBase.Identity.TableSafe, byForm_Server.ku.byInterface.Identity.IBy
    {
        public Tree()
        {
            this.remove += Body_remove;
            this.modify += Body_modify;
            this.add += Body_add;
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Reference iParent { get; set; }

        public byForm_Server.ku.by.Identity.Name iName { get; set; }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> popupLoad(byForm_Server.ku.by.Object.QueryData f_QueryData)
        {
            {
                return (byForm_Server.ku.byBase.SqlExpression.LocalSql._1(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_QueryData })).rows;
            }
        }

        public bool confirmUserIsLogin()
        {
            return true;
        }

        public event byForm_Server.ku.by.Action.Action.Delegate_3<byForm_Server.ku.byBase.Identity.Tree, byForm_Server.ku.by.Object.Row[], byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.Result> remove;

        public byForm_Server.ku.by.Object.Result Body_remove(byForm_Server.ku.byBase.Identity.Tree f_ThisReference, byForm_Server.ku.by.Object.Row[] f_treeRows, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveDelete)
        {
            if (!this.confirmUserIsLogin())
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login() };
            }
            byForm_Server.ku.by.Object.Result tmpResult = new byForm_Server.ku.by.Object.Result();
            tmpResult.isOk = true;
            try
            {
                System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                _objList_.Add(new object[] { f_treeRows });
                _tmpIdentityList_.Add(null);
                _objList_.Add(new object[] { f_slaveDelete });
                _tmpIdentityList_.Add(null);
                SqlExpression.LocalSql.Tran_0(_tmpIdentityList_.ToArray(), _objList_, _values_);
            }
            catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
            {
                string message = thisiscsharpserverxclusiveexceptionidentifier.Message;
                tmpResult.isOk = false;
                tmpResult.info = message;
            }
            return tmpResult;
        }

        public byForm_Server.ku.by.Object.Result Execute_remove(byForm_Server.ku.by.Object.Row[] f_treeRows, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveDelete)
        {
            return this.remove(this, f_treeRows, f_slaveDelete);
        }

        public event byForm_Server.ku.by.Action.Action.Delegate_5<byForm_Server.ku.byBase.Identity.Tree, byForm_Server.ku.by.Object.Row, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.Result> modify;

        public byForm_Server.ku.by.Object.Result Body_modify(byForm_Server.ku.byBase.Identity.Tree f_ThisReference, byForm_Server.ku.by.Object.Row f_treeRow, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveAdd, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveUpdate, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveDelete)
        {
            if (!this.confirmUserIsLogin())
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login() };
            }
            byForm_Server.ku.by.Object.Result tmpResult = new byForm_Server.ku.by.Object.Result();
            tmpResult.isOk = true;
            try
            {
                System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                _objList_.Add(new object[] { f_treeRow });
                _tmpIdentityList_.Add(null);
                _objList_.Add(new object[] { f_slaveAdd });
                _tmpIdentityList_.Add(null);
                _objList_.Add(new object[] { f_slaveUpdate });
                _tmpIdentityList_.Add(null);
                _objList_.Add(new object[] { f_slaveDelete });
                _tmpIdentityList_.Add(null);
                SqlExpression.LocalSql.Tran_1(_tmpIdentityList_.ToArray(), _objList_, _values_);
            }
            catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
            {
                string message = thisiscsharpserverxclusiveexceptionidentifier.Message;
                tmpResult.isOk = false;
                tmpResult.info = message;
            }
            return tmpResult;
        }

        public byForm_Server.ku.by.Object.Result Execute_modify(byForm_Server.ku.by.Object.Row f_treeRow, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveAdd, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveUpdate, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveDelete)
        {
            return this.modify(this, f_treeRow, f_slaveAdd, f_slaveUpdate, f_slaveDelete);
        }

        public event byForm_Server.ku.by.Action.Action.Delegate_3<byForm_Server.ku.byBase.Identity.Tree, byForm_Server.ku.by.Object.Row, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>, byForm_Server.ku.by.Object.Result> add;

        public byForm_Server.ku.by.Object.Result Body_add(byForm_Server.ku.byBase.Identity.Tree f_ThisReference, byForm_Server.ku.by.Object.Row f_treeRow, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveAdd)
        {
            if (!this.confirmUserIsLogin())
            {
                return new byForm_Server.ku.by.Object.Result() { info = byForm_Server.ku.byBase.Object.ByBaseStrings.Warning_User_Not_Login() };
            }
            byForm_Server.ku.by.Object.Result tmpResult = new byForm_Server.ku.by.Object.Result();
            tmpResult.isOk = true;
            if (System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_treeRow, "iID").value) == null || System.Convert.ToString(byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(f_treeRow, "iID").value) == "")
            {
                byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(f_treeRow, "iID", byForm_Server.ku.byCommon.Identity.general.getGuid(), "=");
            }
            try
            {
                System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                _objList_.Add(new object[] { f_treeRow });
                _tmpIdentityList_.Add(null);
                _objList_.Add(new object[] { f_slaveAdd });
                _tmpIdentityList_.Add(null);
                SqlExpression.LocalSql.Tran_2(_tmpIdentityList_.ToArray(), _objList_, _values_);
            }
            catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
            {
                string message = thisiscsharpserverxclusiveexceptionidentifier.Message;
                tmpResult.isOk = false;
                tmpResult.info = message;
            }
            return tmpResult;
        }

        public byForm_Server.ku.by.Object.Result Execute_add(byForm_Server.ku.by.Object.Row f_treeRow, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_slaveAdd)
        {
            return this.add(this, f_treeRow, f_slaveAdd);
        }
    }
}
