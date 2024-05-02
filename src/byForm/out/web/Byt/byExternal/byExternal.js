Byt.defineKu("byExternal", { ref: [ "by" ], ext: [ "byExternal.js" ] }, ($by, $byExternal) => ({ object: {
    encoders: {
        type: class encoders extends Byt.Object { },
        external: "byExternal_encoders",
        static: { methods: { base64Encode: Byt.String, base64Decode: Byt.String } }
    },
    random: {
        type: class random extends Byt.Object { },
        external: "byExternal_random",
        static: { methods: { next: Byt.Int, next$1: Byt.Int, next$2: Byt.Int, nextDouble: Byt.Double } }
    },
    security: {
        type: class security extends Byt.Object { },
        external: "byExternal_security",
        static: { methods: { md5: Byt.String, AESEncrypt: Byt.String, AESDecrypt: Byt.String, rsaCreatePublicKeyAndPrivateKey: [ Byt.Array, Byt.String ], rsaEncrypt: Byt.String, rsaDecrypt: Byt.String, DESEncrypt: Byt.String, DESDecrypt: Byt.String, DESTripleEncrypt: Byt.String, DESTripleDecrypt: Byt.String, RabbitEncrypt: Byt.String, RabbitDecrypt: Byt.String, RC4Encrypt: Byt.String, RC4Decrypt: Byt.String, RC4DropEncrypt: Byt.String, RC4DropDecrypt: Byt.String } }
    }
} }))