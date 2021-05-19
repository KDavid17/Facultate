using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF
{
    public class Person
    {
        private readonly List<Agenda> listOfAgendas = new List<Agenda>();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EMail { get; private set; }

        private Person()
        {

        }

        public Person(string firstName, string lastName, string eMail)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EMail = eMail;
        }

        public void AddAgenda(string name)
        {
            listOfAgendas.Add(new Agenda(name));

            listOfAgendas[listOfAgendas.Count - 1].AddParticipant(this);
        }

        public void AddAgenda(Agenda agenda)
        {
            listOfAgendas.Add(agenda);

            listOfAgendas[listOfAgendas.Count - 1].AddParticipant(this);
        }

        public Agenda GetAgenda(int index)
        {
            return index > -1 ? listOfAgendas[index] : null;
        }
        
        public int GetNumberOfAgendas()
        {
            return listOfAgendas.Count;
        }

        public int GetIndexOfAgenda(Agenda thisAgenda)
        {
            for (int i = 0; i < listOfAgendas.Count; i++)
            {
                if (listOfAgendas[i].Equals(thisAgenda))
                {
                    return i;
                }
            }

            return -1;
        }

        public void DeleteAgenda(int index)
        {
            listOfAgendas.RemoveAt(index);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + EMail;
        }
    }
}
