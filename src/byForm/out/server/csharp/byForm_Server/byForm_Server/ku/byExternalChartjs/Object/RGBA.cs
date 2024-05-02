using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byExternalChartjs.Object
{
    public class RGBA : byForm_Server.ku.byExternalChartjs.Object.RGB
    {
        public RGBA(int f_r, int f_g, int f_b, decimal f_a)
            : base(f_r, f_g, f_b)
        {
            this.a = f_a;
        }

        public RGBA(int[] f_rgb, decimal f_a)
            : base(f_rgb[0], f_rgb[1], f_rgb[2])
        {
            this.a = f_a;
        }

        public decimal a { get; set; }

        public override string toJsFormat()
        {
            return "'rgba(" + this.r + "," + this.g + "," + this.b + "," + this.a + ")'";
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
