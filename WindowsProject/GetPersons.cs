using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsProject
{
    public class GetPersons
    {
        public static bool canchange = false;
        List<Person> people = null;
        string city = null;
        public static GetPersons persontInst = new GetPersons();
        private GetPersons()
        { }
        public static GetPersons getPersonInst()
        {
            return persontInst;
        }

        public void addPersons(Person person)
        {
            people.Add(person);
        }

        public List<Person> getPersonList()
        {
            return people;
        }

        public void newList()
        {
            people = new List<Person>();
        }

        public string City
        {
            get
            {
                return city;
            }
            set 
            {
                city = value;
            }
        }

        public bool Canchange
        {
            get
            {
                return canchange;

            }
            set
            {
                canchange = value;
            }
        }
    }
}
