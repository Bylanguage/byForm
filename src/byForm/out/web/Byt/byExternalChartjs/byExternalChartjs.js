Byt.defineKu("byExternalChartjs", { ref: [ "by" ], ext: [ "chart.js" ] }, ($by, $byExternalChartjs) => ({
    enum: {
        chartTypeRange: { all: 0, general: 1, generalRadar: 2, scatterRadar: 3, linearBubble: 4 },
        chartType: { bar: 0, bubble: 1, doughnut: 2, pie: 3, line: 4, scatter: 5, polarArea: 6, radar: 7, linear: 8 }
    },
    object: {
        RGB: {
            type: class RGB extends Byt.Object {
                $1(f_r, f_g, f_b){
                    this.r = f_r;
                    this.g = f_g;
                    this.b = f_b;
                }
                toJsFormat(){ return "'rgb(" + this.r + "," + this.g + "," + this.b + ")'"; }
            },
            transmit: [ "r", "g", "b" ],
            instance: { props: { r: Byt.Int, g: Byt.Int, b: Byt.Int } }
        },
        RGBA: {
            type: class RGBA extends Byt.Object {
                $1(f_r, f_g, f_b, f_a){
                    super.$1(f_r, f_g, f_b);
                    this.a = f_a;
                }
                $2(f_rgb, f_a){
                    super.$1(f_rgb[0], f_rgb[1], f_rgb[2]);
                    this.a = f_a;
                }
                toJsFormat(){ return "'rgba(" + this.r + "," + this.g + "," + this.b + "," + this.a + ")'"; }
            },
            base: { inherit: "byExternalChartjs.object.RGB" },
            transmit: [ "a" ],
            instance: { props: { a: Byt.Decimal } }
        },
        color: {
            type: class color extends Byt.Object { },
            transmit: [ ]
        },
        chartjs: {
            type: class chartjs extends Byt.Object { },
            external: "byExternalCharjs_byCharjs",
            static: { methods: { fullBar: Byt.Void, fullBubble: Byt.Void, fullDoughnut: Byt.Void, fullPie: Byt.Void, fullLine: Byt.Void, fullPolarArea: Byt.Void, fullScatter: Byt.Void, fullRadar: Byt.Void, fullMix: Byt.Void } }
        }
    }
}))