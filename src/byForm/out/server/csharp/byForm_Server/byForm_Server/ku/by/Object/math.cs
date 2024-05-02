using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class math
    {
        private static double E = 2.718281828459045d;

        public static double e
        {
            get
            {
                return E;
            }
        }

        private static double Ln10 = 2.302585092994046d;

        public static double ln10
        {
            get
            {
                return Ln10;
            }
        }

        private static double Ln2 = 0.6931471805599453d;

        public static double ln2
        {
            get
            {
                return Ln2;
            }
        }

        private static double Log10e = 0.4342944819032518d;

        public static double log10e
        {
            get
            {
                return Log10e;
            }
        }

        private static double Log2e = 1.4426950408889634d;

        public static double log2e
        {
            get
            {
                return Log2e;
            }
        }

        private static double Pi = 3.141592653589793d;

        public static double pi
        {
            get
            {
                return Pi;
            }
        }

        private static double Sqrt1_2 = 0.7071067811865476d;

        public static double sqrt1_2
        {
            get
            {
                return Sqrt1_2;
            }
        }

        private static double Sqrt2 = 1.4142135623730951d;

        public static double sqrt2
        {
            get
            {
                return Sqrt2;
            }
        }

        public static System.Int16 abs(System.Int16 sh)
        {
            return Math.Abs(sh);
        }

        public static int abs(int i)
        {
            return Math.Abs(i);
        }

        public static System.Int64 abs(System.Int64 lng)
        {
            return Math.Abs(lng);
        }

        public static System.Single abs(System.Single f)
        {
            return Math.Abs(f);
        }

        public static double abs(double d)
        {
            return Math.Abs(d);
        }

        public static System.Decimal abs(System.Decimal dcm)
        {
            return Math.Abs(dcm);
        }

        public static double acos(double d)
        {
            return Math.Acos(d);
        }

        public static int addExact(int i1, int i2)
        {
            return i1 + i2;
        }

        public static System.Int64 addExact(System.Int64 lng1, System.Int64 lng2)
        {
            return lng1 + lng2;
        }

        public static double asin(double d)
        {
            return Math.Asin(d);
        }

        public static double atan(double d)
        {
            return Math.Atan(d);
        }

        public static double atan2(double d1, double d2)
        {
            return Math.Atan2(d1, d2);
        }

        public static System.Int64 bigMul(int i1, int i2)
        {
            return Math.BigMul(i1, i2);
        }

        public static double cbrt(double d)
        {
            return Math.Pow(d, (double)1 / 3);
        }

        public static System.Decimal ceiling(System.Decimal dcm)
        {
            return Math.Ceiling(dcm);
        }

        public static double ceiling(double d)
        {
            return Math.Ceiling(d);
        }

        public static double cos(double d)
        {
            return Math.Cos(d);
        }

        public static double cosh(double d)
        {
            return Math.Cosh(d);
        }

        public static double exp(double d)
        {
            return Math.Exp(d);
        }

        public static System.Decimal floor(System.Decimal dcm)
        {
            return Math.Floor(dcm);
        }

        public static double floor(double d)
        {
            return Math.Floor(d);
        }

        public static double ieeeRemainder(double d1, double d2)
        {
            return Math.IEEERemainder(d1, d2);
        }

        public static double log(double d)
        {
            return Math.Log(d);
        }

        public static double log(double d, double newBase)
        {
            return Math.Log(d, newBase);
        }

        public static double log10(double d)
        {
            return Math.Log10(d);
        }

        public static System.SByte max(System.SByte bt1, System.SByte bt2)
        {
            return Math.Max(bt1, bt2);
        }

        public static System.Int16 max(System.Int16 sh1, System.Int16 sh2)
        {
            return Math.Max(sh1, sh2);
        }

        public static int max(int i1, int i2)
        {
            return Math.Max(i1, i2);
        }

        public static System.Int64 max(System.Int64 lng1, System.Int64 lng2)
        {
            return Math.Max(lng1, lng2);
        }

        public static System.Single max(System.Single f1, System.Single f2)
        {
            return Math.Max(f1, f2);
        }

        public static double max(double d1, double d2)
        {
            return Math.Max(d1, d2);
        }

        public static System.Decimal max(System.Decimal dcm1, System.Decimal dcm2)
        {
            return Math.Max(dcm1, dcm2);
        }

        public static System.SByte min(System.SByte bt1, System.SByte bt2)
        {
            return Math.Min(bt1, bt2);
        }

        public static System.Int16 min(System.Int16 sh1, System.Int16 sh2)
        {
            return Math.Min(sh1, sh2);
        }

        public static int min(int i1, int i2)
        {
            return Math.Min(i1, i2);
        }

        public static System.Int64 min(System.Int64 lng1, System.Int64 lng2)
        {
            return Math.Min(lng1, lng2);
        }

        public static System.Single min(System.Single f1, System.Single f2)
        {
            return Math.Min(f1, f2);
        }

        public static double min(double d1, double d2)
        {
            return Math.Min(d1, d2);
        }

        public static System.Decimal min(System.Decimal dcm1, System.Decimal dcm2)
        {
            return Math.Min(dcm1, dcm2);
        }

        public static double pow(double d1, double d2)
        {
            return Math.Pow(d1, d2);
        }

        public static double random()
        {
            Random tmpRandom = new Random();
            return tmpRandom.NextDouble();
        }

        public static System.Decimal round(System.Decimal dcm)
        {
            return Math.Round(dcm);
        }

        public static double round(double d)
        {
            return Math.Round(d);
        }

        public static System.Decimal round(System.Decimal dcm, int i)
        {
            return Math.Round(dcm, i);
        }

        public static double round(double d, int i)
        {
            return Math.Round(d, i);
        }

        public static int sign(System.Int16 sh)
        {
            return Math.Sign(sh);
        }

        public static int sign(int i)
        {
            return Math.Sign(i);
        }

        public static int sign(System.Int64 lng)
        {
            return Math.Sign(lng);
        }

        public static int sign(System.Single f)
        {
            return Math.Sign(f);
        }

        public static int sign(double d)
        {
            return Math.Sign(d);
        }

        public static int sign(System.Decimal dcm)
        {
            return Math.Sign(dcm);
        }

        public static double sin(double d)
        {
            return Math.Sin(d);
        }

        public static double sinh(double d)
        {
            return Math.Sinh(d);
        }

        public static double sqrt(double d)
        {
            return Math.Sqrt(d);
        }

        public static double toDegrees(double d)
        {
            return 180 * d / Pi;
        }

        public static double toRadians(double d)
        {
            return Pi * d / 180;
        }

        public static double tan(double d)
        {
            return Math.Tan(d);
        }

        public static double tanh(double d)
        {
            return Math.Tanh(d);
        }

        public static System.Decimal truncate(System.Decimal dcm)
        {
            return Math.Truncate(dcm);
        }

        public static double truncate(double d)
        {
            return Math.Truncate(d);
        }

        public override string ToString()
        {
            return ku.by.ToolClass.ToolFunction.ObjTypeToString(this.GetType());
        }
    }
}
