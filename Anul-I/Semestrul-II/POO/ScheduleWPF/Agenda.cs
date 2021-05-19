using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF
{
    public class Agenda
    {
        private readonly List<Activity> listOfActivities = new List<Activity>();
        private readonly List<Person> listOfParticipants = new List<Person>();

        public string Name { get; private set; }

        private Agenda()
        {

        }

        public Agenda(string name)
        {
            this.Name = name;
        }

        public void SetParticipants(List<Person> tempListOfParticipants)
        {
            foreach (Person item in tempListOfParticipants)
            {
                listOfParticipants.Add(item);
            }
        }

        public void AddActivity(string name, string description, string timeStart, string timeEnd)
        {
            listOfActivities.Add(new Activity(name, description, timeStart, timeEnd));
        }

        public Activity GetActivity(int index)
        {
            return listOfActivities[index];
        }

        public Person GetParticipant(int index)
        {
            return listOfParticipants[index];
        }

        public int GetNumberOfActivities()
        {
            return listOfActivities.Count;
        }

        public int GetNumberOfParticipants()
        {
            return listOfParticipants.Count;
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
