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
        private int _fakeNotificationDatabaseID = 1;

        public TestPersonRepository()
        {
            // For the moment, we will load some sample data during initialization. 
            this.Add(new Person
            {
                last_name = "Kreminski",
                first_name = "Boris",
                birth = (new DateTime(1975, 8, 3)).ToString(),
                gender = "Male",
                role = "Right wing-back (RWB)",
                status = "Active",
                contact = new Contact
                {
                    email = "krembf@gmail.com",
                    phone = "+12675216016",
                },
                address = new Address
                {
                    street = "301 Heights Ln, Apt 40D",
                    city = "Feasterville-Trevose",
                    state = "PA",
                    zip = "19053",
                },
                access_level = new AccessLevel
                {
                    group = "dev",
                    level = 5,
                },

                notifications = new List<Notification>()

            });
            this.Add(new Person
            {
                last_name = "Chudnovsky",
                first_name = "Alex",
                birth = (new DateTime(1975, 8, 3)).ToString(),
                gender = "Male",
                role = "Center-back (CB)",
                status = "Active",
                contact = new Contact
                {
                    email = "achudnovsky@gmail.com",
                    phone = "+12675216016",
                },
                address = new Address
                {
                    street = "1234 Street Road",
                    city = "Feasterville-Trevose",
                    state = "PA",
                    zip = "19053",
                },
                access_level = new AccessLevel
                {
                    group = "dev",
                    level = 5,
                },

                notifications = new List<Notification>()

            });
        }


        public IEnumerable<Person> GetAll()
        {
            return _people;
        }


        public Person Get(int id)
        {
            return _people.Find(p => p.id == id);
        }


        public Person Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            person.id = _fakeDatabaseID++;
            _people.Add(person);
            return person;
        }


        public void Remove(int id)
        {
            _people.RemoveAll(p => p.id == id);
        }


        public bool Update(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            int index = _people.FindIndex(p => p.id == person.id);
            if (index == -1)
            {
                return false;
            }
            _people.RemoveAt(index);
            _people.Add(person);
            return true;
        }

        public Notification Add(Notification notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException("notification");
            }

            Person person = Get(notification.personid);

            if(null != person)
            {
                notification.id = _fakeNotificationDatabaseID++;
                person.notifications.Add(notification);
            }

            return notification;
        }
    }
}
