using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF
{
    public class Agenda
    {
        private List<Activity> listOfActivities = new List<Activity>();

        public string Name { get; private set; }

        private Agenda()
        {

        }

        public Agenda(string name)
        {
            this.Name = name;
        }

        public void AddActivity(string name, string description, string timeStart, string timeEnd)
        {
            listOfActivities.Add(new Activity(name, description, timeStart, timeEnd));
        }

        public Activity GetActivity(int index)
        {
            return listOfActivities[index];
        }

        public int GetNumberOfActivities()
        {
            return listOfActivities.Count;
        }

        public void DeleteActivity(int index)
        {
            listOfActivities.RemoveAt(index);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
