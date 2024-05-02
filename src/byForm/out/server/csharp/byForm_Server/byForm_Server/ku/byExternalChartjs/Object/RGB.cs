using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.byExternalChartjs.Object
{
    public class RGB
    {
        public RGB(int f_r, int f_g, int f_b)
        {
            this.r = f_r;
            this.g = f_g;
            this.b = f_b;
        }

        public int r { get; set; }

        public int g { get; set; }

        public int b { get; set; }

        public virtual string toJsFormat()
        {
            return "'rgb(" + this.r + "," + this.g + "," + this.b + ")'";
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
