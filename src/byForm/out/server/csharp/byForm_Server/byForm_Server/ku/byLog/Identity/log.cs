using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byLog.Identity
{
    public class log : byForm_Server.ku.by.Identity.Table
    {
        public log()
        {
        }

        public override string ku { get; set; }

        public override object to { get; set; }

        public override void NewIdentitySetDefault()
        {
            base.NewIdentitySetDefault();
            pPathFileName = byForm_Server.ku.by.Object.system.currentDirectory + "byLog.txt";
            pPathErrorFileName = byForm_Server.ku.by.Object.system.currentDirectory + "byErrorLog.txt";
            pLogMode = byForm_Server.ku.byLog.Enum.logMode.file;
        }

        public string pPathFileName { get; set; }

        public string pPathErrorFileName { get; set; }

        public byForm_Server.ku.byLog.Enum.logMode pLogMode { get; set; }

        public override byForm_Server.ku.by.Identity.ID iID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iSceneType { get; set; }

        public byForm_Server.ku.by.Identity.Reference iUserID { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iUserName { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iState { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iIp { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iSummary { get; set; }

        public byForm_Server.ku.by.Identity.Attribute iDt { get; set; }

        public byForm_Server.ku.by.Object.Row getRow(byForm_Server.ku.byLog.Enum.logState f_logState, string f_content)
        {
            byForm_Server.ku.by.Object.Row tmpRow = new byForm_Server.ku.by.Object.Row() { _InitIdentity_ = this };
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpRow, "iID", byForm_Server.ku.byCommon.Identity.general.getGuid(), "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iState").value = f_logState;
            byForm_Server.ku.by.ToolClass.ToolFunction.CompoundAssignmentReturnString(tmpRow, "iSummary", f_content, "=");
            byForm_Server.ku.by.ToolClass.ToolFunction.GetRowComponent(tmpRow, "iDt").value = byForm_Server.ku.by.Object.datetime.getNow();
            return tmpRow;
        }

        public void writeTable(byForm_Server.ku.byLog.Enum.logState f_logState, string f_content)
        {
            {
                byForm_Server.ku.by.Object.Row tmpRow = this.getRow(f_logState, f_content);
                byForm_Server.ku.byLog.SqlExpression.LocalSql._0(new object[] { tmpRow });
            }
        }

        public void writeFile(byForm_Server.ku.byLog.Enum.logState f_logState, string f_content)
        {
            {
                byForm_Server.ku.by.Object.Row tmpRow = this.getRow(f_logState, f_content);
                if (f_logState == byForm_Server.ku.byLog.Enum.logState.Error)
                {
                    byForm_Server.ku.ExtendMethod.writeAllText(this.pPathErrorFileName, tmpRow.ToString(), true);
                }
                else
                {
                    byForm_Server.ku.ExtendMethod.writeAllText(this.pPathFileName, tmpRow.ToString(), true);
                }
            }
        }

        public void write(byForm_Server.ku.byLog.Enum.logState f_logState, string f_content)
        {
            {
                if (this.pLogMode == byForm_Server.ku.byLog.Enum.logMode.fileDatabase)
                {
                    this.writeFile(f_logState, f_content);
                    this.writeTable(f_logState, f_content);
                }
                else
                {
                    if (this.pLogMode == byForm_Server.ku.byLog.Enum.logMode.file)
                    {
                        this.writeFile(f_logState, f_content);
                    }
                    else
                    {
                        if (this.pLogMode == byForm_Server.ku.byLog.Enum.logMode.database)
                        {
                            this.writeTable(f_logState, f_content);
                        }
                    }
                }
            }
        }
    }
}
