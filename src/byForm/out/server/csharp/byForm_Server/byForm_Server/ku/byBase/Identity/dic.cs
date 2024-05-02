using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class dic : byForm_Server.ku.byBase.Identity.popupTable, byForm_Server.ku.byInterface.Identity.IBy
    {
        public dic()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public virtual byForm_Server.ku.by.Identity.Name iName { get; set; }

        public virtual byForm_Server.ku.by.Identity.Attribute iSummary { get; set; }

        public byForm_Server.ku.by.Object.Result addModifDelete(byForm_Server.ku.by.Object.Row f_row, byForm_Server.ku.by.Enum.Action f_action)
        {
            {
                if (f_action == byForm_Server.ku.by.Enum.Action.insert)
                {
                    try
                    {
                        System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                        System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                        System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                        _objList_.Add(new object[] { f_row });
                        _tmpIdentityList_.Add(null);
                        SqlExpression.LocalSql.Tran_8(_tmpIdentityList_.ToArray(), _objList_, _values_);
                    }
                    catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                    {
                        string errorInfo = thisiscsharpserverxclusiveexceptionidentifier.Message;
                        return new byForm_Server.ku.by.Object.Result() { info = errorInfo };
                    }
                }
                else
                {
                    if (f_action == byForm_Server.ku.by.Enum.Action.update)
                    {
                        try
                        {
                            System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                            System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                            System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                            _objList_.Add(new object[] { f_row });
                            _tmpIdentityList_.Add(null);
                            SqlExpression.LocalSql.Tran_9(_tmpIdentityList_.ToArray(), _objList_, _values_);
                        }
                        catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                        {
                            string errorInfo = thisiscsharpserverxclusiveexceptionidentifier.Message;
                            return new byForm_Server.ku.by.Object.Result() { info = errorInfo };
                        }
                    }
                    else
                    {
                        if (f_action == byForm_Server.ku.by.Enum.Action.delete)
                        {
                            try
                            {
                                System.Collections.Generic.List<object[]> _objList_ = new System.Collections.Generic.List<object[]>();
                                System.Collections.Generic.List<object> _values_ = new System.Collections.Generic.List<object>();
                                System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource> _tmpIdentityList_ = new System.Collections.Generic.List<byForm_Server.ku.by.ToolClass.ITableSource>();
                                _objList_.Add(new object[] { f_row });
                                _tmpIdentityList_.Add(null);
                                SqlExpression.LocalSql.Tran_10(_tmpIdentityList_.ToArray(), _objList_, _values_);
                            }
                            catch (System.Exception thisiscsharpserverxclusiveexceptionidentifier)
                            {
                                string errorInfo = thisiscsharpserverxclusiveexceptionidentifier.Message;
                                return new byForm_Server.ku.by.Object.Result() { info = errorInfo };
                            }
                        }
                    }
                }
                return new byForm_Server.ku.by.Object.Result() { isOk = true };
            }
        }

        public byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> load(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_selectRowList, byForm_Server.ku.by.Object.QueryData f_QueryData)
        {
            {
                byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpGridRows = new byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>();
                if (f_selectRowList == null || f_selectRowList.count == 0)
                {
                    if (f_QueryData != null)
                    {
                        tmpGridRows = (byForm_Server.ku.byBase.SqlExpression.LocalSql._34(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_QueryData })).rows;
                    }
                    else
                    {
                        tmpGridRows = (byForm_Server.ku.byBase.SqlExpression.LocalSql._35(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { })).rows;
                    }
                }
                else
                {
                    if (f_QueryData != null)
                    {
                        tmpGridRows = (byForm_Server.ku.byBase.SqlExpression.LocalSql._36(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_QueryData, f_selectRowList[0] })).rows;
                    }
                    else
                    {
                        tmpGridRows = (byForm_Server.ku.byBase.SqlExpression.LocalSql._37(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_selectRowList[0] })).rows;
                    }
                }
                return tmpGridRows;
            }
        }
    }
}
