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

        public void AddParticipant(Person newParticipant)
        {
            listOfParticipants.Add(newParticipant);
        }
        
        public Person GetParticipant(int index)
        {
            return index > -1 ? listOfParticipants[index] : null;
        }

        public int GetNumberOfParticipants()
        {
            return listOfParticipants.Count;
        }

        public int GetIndexOfParticipant(Person thisParticipant)
        {
            for (int i = 0; i < listOfParticipants.Count; i++)
            {
                if (listOfParticipants[i].Equals(thisParticipant))
                {
                    return i;
                }
            }

            return -1;
        }

        public void DeleteParticipant(int index)
        {
            if (index != -1)
            {
                listOfParticipants.RemoveAt(index);
            }
        }

        public void AddActivity(string name, string description, string timeStart, string timeEnd)
        {
            listOfActivities.Add(new Activity(name, description, timeStart, timeEnd));
        }

        public Activity GetActivity(int index)
        {
            return index > -1 ? listOfActivities[index] : null;
        }

        public int GetNumberOfActivities()
        {
            return listOfActivities.Count;
        }

        public int GetIndexOfActivity(Activity thisActivity)
        {
            for (int i = 0; i < listOfActivities.Count; i++)
            {

                if (listOfActivities[i].Equals(thisActivity))
                {
                    return i;
                }
            }

            return -1;
        }

        public void DeleteActivity(int index)
        {
            if (index != -1)
            {
                listOfActivities.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
