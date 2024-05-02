using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace byForm_Server.ku.by.Object
{
    public class datetime
    {
        public int day
        {
            get
            {
                return this.value.Day;
            }
        }

        public byForm_Server.ku.by.Enum.DayOfWeek dayOfWeek
        {
            get
            {
                switch (this.value.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        return ku.by.Enum.DayOfWeek.monday;
                    case DayOfWeek.Tuesday:
                        return ku.by.Enum.DayOfWeek.tuesday;
                    case DayOfWeek.Wednesday:
                        return ku.by.Enum.DayOfWeek.wednesday;
                    case DayOfWeek.Thursday:
                        return ku.by.Enum.DayOfWeek.thursday;
                    case DayOfWeek.Friday:
                        return ku.by.Enum.DayOfWeek.friday;
                    case DayOfWeek.Saturday:
                        return ku.by.Enum.DayOfWeek.saturday;
                    default:
                        return ku.by.Enum.DayOfWeek.sunday;
                }
            }
        }

        public int dayOfWeekValue
        {
            get
            {
                return (int)this.value.DayOfWeek;
            }
        }

        public int hour
        {
            get
            {
                return this.value.Hour;
            }
        }

        public int millisecond
        {
            get
            {
                return this.value.Millisecond;
            }
        }

        public int minute
        {
            get
            {
                return this.value.Minute;
            }
        }

        public int month
        {
            get
            {
                return this.value.Month;
            }
        }

        public int second
        {
            get
            {
                return this.value.Second;
            }
        }

        public int year
        {
            get
            {
                return this.value.Year;
            }
        }

        public static int compare(byForm_Server.ku.by.Object.datetime t1, byForm_Server.ku.by.Object.datetime t2)
        {
            return t1.compareTo(t2);
        }

        public static byForm_Server.ku.by.Object.datetime create(int year, int month, int dayOfMonth, int hour, int minute, int second, int milliSceond)
        {
            DateTime tmpValue = new DateTime(year, month, dayOfMonth, hour, minute, second, milliSceond);
            return new datetime(tmpValue);
        }

        public static byForm_Server.ku.by.Object.datetime create(int year, int month, int dayOfMonth, int hour, int minute, int second)
        {
            DateTime tmpValue = new DateTime(year, month, dayOfMonth, hour, minute, second);
            return new datetime(tmpValue);
        }

        public static byForm_Server.ku.by.Object.datetime create(int year, int month, int dayOfMonth)
        {
            DateTime tmpValue = new DateTime(year, month, dayOfMonth);
            return new datetime(tmpValue);
        }

        public static byForm_Server.ku.by.Object.datetime getNow()
        {
            var tmpValue = DateTime.Now;
            return new datetime(tmpValue);
        }

        public static byForm_Server.ku.by.Object.datetime parse(string str)
        {
            var tmpValue = DateTime.Parse(str);
            return new datetime(tmpValue);
        }

        public byForm_Server.ku.by.Object.datetime addYears(int num)
        {
            if (num == 0)
            {
                return this;
            }

            return new datetime(this.value.AddYears(num));
        }

        public byForm_Server.ku.by.Object.datetime addMonths(int num)
        {
            if (num == 0)
            {
                return this;
            }

            return new datetime(this.value.AddMonths(num));
        }

        public byForm_Server.ku.by.Object.datetime addDays(int num)
        {
            if (num == 0)
            {
                return this;
            }

            return new datetime(this.value.AddDays(num));
        }

        public byForm_Server.ku.by.Object.datetime addHours(int num)
        {
            if (num == 0)
            {
                return this;
            }

            return new datetime(this.value.AddHours(num));
        }

        public byForm_Server.ku.by.Object.datetime addMinutes(int num)
        {
            if (num == 0)
            {
                return this;
            }

            return new datetime(this.value.AddMinutes(num));
        }

        public byForm_Server.ku.by.Object.datetime addSeconds(int num)
        {
            if (num == 0)
            {
                return this;
            }

            return new datetime(this.value.AddSeconds(num));
        }

        public byForm_Server.ku.by.Object.datetime addMilliseconds(int num)
        {
            if (num == 0)
            {
                return this;
            }
            return new datetime(this.value.AddMilliseconds(num));
        }

        public int compareTo(byForm_Server.ku.by.Object.datetime dt)
        {
            return this.value.CompareTo(dt.value);
        }

        public double diffDays(byForm_Server.ku.by.Object.datetime dt)
        {
            var tmpTimeSpan = this.value.Subtract(dt.value);
            return tmpTimeSpan.TotalDays;
        }

        public double diffHours(byForm_Server.ku.by.Object.datetime dt)
        {
            var tmpTimesSpan = this.value.Subtract(dt.value);
            return tmpTimesSpan.TotalHours;
        }

        public double diffMinutes(byForm_Server.ku.by.Object.datetime dt)
        {
            var tmpTimeSpan = this.value.Subtract(dt.value);
            return tmpTimeSpan.TotalMinutes;
        }

        public double diffSeconds(byForm_Server.ku.by.Object.datetime dt)
        {
            var tmpTimeSpan = this.value.Subtract(dt.value);
            return tmpTimeSpan.TotalSeconds;
        }

        public double diffMilliseconds(byForm_Server.ku.by.Object.datetime dt)
        {
            var tmpTimeSpan = this.value.Subtract(dt.value);
            return tmpTimeSpan.TotalMilliseconds;
        }

        public bool equals(object obj)
        {
            var tmpDatetimeValue = obj as datetime;

            if (tmpDatetimeValue == null)
            {
                return false;
            }

            return tmpDatetimeValue.value.Equals(this.value);
        }

        public string format(string pattern)
        {
            return this.value.ToString(pattern);
        }

        public override string ToString()
        {
            return this.value.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public static byForm_Server.ku.by.Object.datetime ConvertToDatetime(object value)
        {
            if (value is datetime)
            {
                var tmpDatetimeValue = value as datetime;
                return new datetime(tmpDatetimeValue.value);
            }
            var tmpDatetime = Convert.ToDateTime(value);
            return new datetime(tmpDatetime);
        }

        public static byForm_Server.ku.by.Object.datetime GetDefault()
        {
            return new datetime(default(DateTime));
        }

        private datetime(System.DateTime f_Value)
        {
            this.value = f_Value;
        }

        private System.DateTime value;

        public datetime()
        {
            this.value = new DateTime();
        }
    }
}
