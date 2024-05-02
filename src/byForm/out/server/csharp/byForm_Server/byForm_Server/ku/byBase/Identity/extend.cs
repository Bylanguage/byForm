using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byBase.Identity
{
    public class extend : byForm_Server.ku.byBase.Identity.TableSafe
    {
        public extend()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iName { get; set; }

        public byForm_Server.ku.by.Object.Row load(string f_ID)
        {
            {
                byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpList = (byForm_Server.ku.byBase.SqlExpression.LocalSql._23(new byForm_Server.ku.by.ToolClass.ITableSource[] { this }, new object[] { f_ID })).rows;
                if (tmpList.count > 0)
                {
                    return tmpList[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public int addUpdateDelete(byForm_Server.ku.by.Object.Row f_row, byForm_Server.ku.by.Enum.Action f_action)
        {
            {
                int tmpResultValue = 0;
                switch (f_action)
                {
                    case byForm_Server.ku.by.Enum.Action.insert:
                        {
                            tmpResultValue = byForm_Server.ku.byBase.SqlExpression.LocalSql._24(new object[] { f_row });
                            break;
                        }
                    case byForm_Server.ku.by.Enum.Action.update:
                        {
                            tmpResultValue = byForm_Server.ku.byBase.SqlExpression.LocalSql._25(new object[] { f_row });
                            break;
                        }
                    case byForm_Server.ku.by.Enum.Action.delete:
                        {
                            tmpResultValue = byForm_Server.ku.byBase.SqlExpression.LocalSql._26(new object[] { f_row, f_row });
                            break;
                        }
                }
                return tmpResultValue;
            }
        }
    }
}
