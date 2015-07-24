using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAPITemplateProject.Models;

namespace WebAPITemplateProject.Tests.Models
{
    public class TestPersonRepository : IPersonRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
        // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<Person> _people = new List<Person>();
        private int _fakeDatabaseID = 1;

        public TestPersonRepository()
        {
            // For the moment, we will load some sample data during initialization. 
            this.Add(new Person
            {
                LastName = "Kreminski",
                FirstName = "Boris",
                Birth = new DateTime(1975, 8, 3),
                Gender = "Male",
                Role = "Midfielder",
                Status = "Active",
                Contact = new Contact
                {
                    Email = "krembf@gmail.com",
                    Phone = "+12675216016",
                },
                Address = new Address
                {
                    Street = "301 Heights Ln, Apt 40D",
                    City = "Feasterville-Trevose",
                    State = "PA",
                    Zip = "19053",
                },
                AccessLevel = new AccessLevel
                {
                    Group = "dev",
                    Level = "5",
                },

            });
            this.Add(new Person
            {
                LastName = "Chudnovsky",
                FirstName = "Alex",
                Birth = new DateTime(1975, 8, 3),
                Gender = "Male",
                Role = "Defender",
                Status = "Active",
                Contact = new Contact
                {
                    Email = "achudnovsky@gmail.com",
                    Phone = "+12675216016",
                },
                Address = new Address
                {
                    Street = "1234 Street Road",
                    City = "Feasterville-Trevose",
                    State = "PA",
                    Zip = "19053",
                },
                AccessLevel = new AccessLevel
                {
                    Group = "dev",
                    Level = "5",
                },

            });
        }


        public IEnumerable<Person> GetAll()
        {
            return _people;
        }


        public Person Get(int id)
        {
            return _people.Find(p => p.Id == id);
        }


        public Person Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            person.Id = _fakeDatabaseID++;
            _people.Add(person);
            return person;
        }


        public void Remove(int id)
        {
            _people.RemoveAll(p => p.Id == id);
        }


        public bool Update(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            int index = _people.FindIndex(p => p.Id == person.Id);
            if (index == -1)
            {
                return false;
            }
            _people.RemoveAt(index);
            _people.Add(person);
            return true;
        }
    }
}
