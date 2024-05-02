Byt.defineKu("byInterface", [ "by" ], ($by, $byInterface) => ({
    enum: { curdAction: { modifBegin: 0, modifSave: 1, addBegin: 2, addSave: 3, delete: 4, selectChange: 5 } },
    identity: { IBy: {
        kind: "interface",
        type: class IBy { }
    } },
    dialog: {
        IBy$IMaster: {
            kind: "interface",
            type: class IMaster { }
        },
        IBy$ISlave: {
            kind: "interface",
            type: class ISlave { }
        }
    }
}))