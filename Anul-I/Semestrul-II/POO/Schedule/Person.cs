using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Person
    {
        private List<Agenda> listOfAgendas = new List<Agenda>();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private Person()
        {

        }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public void AddAgenda(string name)
        {
            listOfAgendas.Add(new Agenda(name));
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
            return FirstName + " " + LastName;
        }
    }
}
