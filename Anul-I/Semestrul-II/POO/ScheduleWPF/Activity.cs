using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF
{
    public class Activity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateAndTime TimeStart { get; private set; }
        public DateAndTime TimeEnd { get; private set; }

        private Activity()
        {

        }

        public Activity(string name, string description, string timeStart, string timeEnd)
        {
            this.Name = name;
            this.Description = description;
            this.TimeStart = new DateAndTime(timeStart);
            this.TimeEnd = new DateAndTime(timeEnd);
        }

        public override string ToString()
        {
            return Name + "\n" + Description + "\n" + TimeStart + "\n" + TimeEnd;
        }
    }
}
