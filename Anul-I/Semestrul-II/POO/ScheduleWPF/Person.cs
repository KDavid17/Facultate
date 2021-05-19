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
        }

        public void AddParticipants(string name, List<Person> tempListOfParticipants)
        {
            AddAgenda(name);

            GetAgenda(GetNumberOfAgendas() - 1).SetParticipants(tempListOfParticipants);
        }

        public Agenda GetAgenda(int index)
        {
            return listOfAgendas[index];
        }

        public int GetNumberOfAgendas()
        {
            return listOfAgendas.Count;
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
