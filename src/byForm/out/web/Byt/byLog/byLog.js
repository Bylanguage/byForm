Byt.defineKu("byLog", [ "by", "byCommon", "byExternal" ], ($by, $byCommon, $byExternal, $byLog) => ({
    enum: {
        logMode: { none: 0, file: 1, database: 2, fileDatabase: 3 },
        logState: { log: 0, security: 1, Error: 2, warning: 3, other: 4, user: 5 }
    },
    identity: { log: {
        type: class log extends Byt.Identity {
            $0(){
                super.$0();
                this.pLogMode = "file";
            }
            async writeTable(f_logState, f_content){
                
                { await $byLog.$remote({ kind: "SKILL", NO: 1, target: this, args: [ f_logState, f_content ], argTypes: [ "byLog.enum.logState", Byt.String ] }); }
            }
            async writeFile(f_logState, f_content){
                
                { await $byLog.$remote({ kind: "SKILL", NO: 2, target: this, args: [ f_logState, f_content ], argTypes: [ "byLog.enum.logState", Byt.String ] }); }
            }
            async write(f_logState, f_content){
                
                {
                    if(this.pLogMode == "fileDatabase" || this.pLogMode == "file" || this.pLogMode == "database"){ await $byLog.$remote({ kind: "SKILL", NO: 3, target: this, args: [ f_logState, f_content ], argTypes: [ "byLog.enum.logState", Byt.String ] }); }
                }
            }
        },
        base: { inherit: $by.identity.Table },
        instance: { components: [ "iID", "iSceneType", "iUserID", "iUserName", "iState", "iIp", "iSummary", "iDt" ], props: { pLogMode: "byLog.enum.logMode" } }
    } }
}))