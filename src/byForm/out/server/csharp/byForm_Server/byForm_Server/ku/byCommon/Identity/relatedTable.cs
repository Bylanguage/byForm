using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byCommon.Identity
{
    public class relatedTable : byForm_Server.ku.by.Identity.Identity_
    {
        public relatedTable()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> cloneListRow(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_sourceList)
        {
            byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpList = new byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>();
            foreach (byForm_Server.ku.by.Object.Row item in f_sourceList)
            {
                tmpList.add(item.clone());
            }
            return tmpList;
        }

        public static bool isExists(byForm_Server.ku.by.Object.Row f_sourceRow, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_targetList)
        {
            foreach (byForm_Server.ku.by.Object.Row item in f_targetList)
            {
                if (byForm_Server.ku.by.ToolClass.ToolFunction.RowRelationEqualRow(item, f_sourceRow))
                {
                    return true;
                }
            }
            return false;
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> isExists_(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_sourceList, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_targetList)
        {
            byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpResultList = new byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>();
            foreach (byForm_Server.ku.by.Object.Row item in f_sourceList)
            {
                if (byForm_Server.ku.byCommon.Identity.relatedTable.isExists(item, f_targetList))
                {
                    tmpResultList.add(item);
                }
            }
            return tmpResultList;
        }

        public static byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> isNotExists(byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_sourceList, byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> f_targetList)
        {
            byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row> tmpResultList = new byForm_Server.ku.by.Object.list<byForm_Server.ku.by.Object.Row>();
            foreach (byForm_Server.ku.by.Object.Row item in f_sourceList)
            {
                if (!byForm_Server.ku.byCommon.Identity.relatedTable.isExists(item, f_targetList))
                {
                    tmpResultList.add(item);
                }
            }
            return tmpResultList;
        }
    }
}
