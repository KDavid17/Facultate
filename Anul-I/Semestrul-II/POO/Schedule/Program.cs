using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> listOfPersons = new List<Person>()
            {
                new Person("John", "Shepard"),
                new Person("Jane", "Doe"),
                new Person("Zack", "Smith"),
                new Person("Mike", "Fox")
            };

            listOfPersons[0].AddAgenda("John's personal agenda");
            listOfPersons[0].AddAgenda("John's sport agenda");
            listOfPersons[0].AddAgenda("John's family agenda");

            Agenda temp = listOfPersons[0].GetAgenda(1);

            Console.WriteLine(temp);

            temp.AddActivity("Football", "I have to go out and play with my friends", "2020:2:2:13:00", "2020:2:2:14:00");
            
            Activity temp1 = temp.GetActivity(0);

            Console.WriteLine(temp1);
        }
    }
}
