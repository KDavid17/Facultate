using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class DateAndTime
    {
        public string Year { get; private set; }
        public string Month { get; private set; }
        public string Day { get; private set; }
        public string Hour { get; private set; }
        public string Minute { get; private set; }

        private DateAndTime()
        {

        }

        public DateAndTime(string time)
        {
            string[] helper = time.Split(':');

            this.Year = helper[0];
            this.Month = helper[1];
            this.Day = helper[2];
            this.Hour = helper[3];
            this.Minute = helper[4];
        }

        public override string ToString()
        {
            return "Date: " + Day + "/" + Month + "/" + Year + "\nTime: " + Hour + ":" + Minute;
        }
    }
}
