using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Person
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public List<Agenda> ListOfAgendas { get; private set; }

        private Person()
        {

        }

        public Person(string firstName, string lastName)
        {
            this.Name = firstName;
            this.Surname = lastName;
        }


    }
}
